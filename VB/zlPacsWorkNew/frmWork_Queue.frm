VERSION 5.00
Object = "{9AC3F5EF-1E37-407F-BF04-027E86C0AD8D}#7.0#0"; "zlQueueOper.ocx"
Begin VB.Form frmWork_Queue 
   BorderStyle     =   0  'None
   Caption         =   "�ŶӽкŹ���"
   ClientHeight    =   5700
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11595
   Icon            =   "frmWork_Queue.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   5700
   ScaleWidth      =   11595
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  '����ȱʡ
   Begin zlQueueOper.UcQueue ucPacsQueue 
      Height          =   5085
      Left            =   0
      TabIndex        =   0
      Top             =   15
      Width           =   9150
      _extentx        =   16140
      _extenty        =   8969
      interval        =   30000
      validdays       =   0
   End
End
Attribute VB_Name = "frmWork_Queue"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


Private Const M_LNG_PACS_BUSINESS_IMG_TYPE As Long = 1                  'pacsӰ��ҽ��ҵ�����Ͷ���
Private Const M_LNG_PACS_BUSINESS_CAP_TYPE As Long = 1                  'pacs��Ƶ�ɼ�ҵ�����Ͷ���

Private Const M_STR_NOT_ALLOT_TECHNIC As String = "���Ҷ���"      'δ����������ƶ���
Private Const M_STR_FINDWAY_EX As String = "�����,סԺ��,���￨,ҽ����"


Private mrsPacsQueueGroupConfig As ADODB.Recordset
Private mrsPacsQueueTechnicConfig As ADODB.Recordset


Private mobjOwner As Object
Private mlngCurDeptId As Long                       '��ǰ����ID
Private mstrCurDeptName As String                   '��ǰ��������
Private mstrQueryTechnicQueueNames  As String       'pacs�ŶӽкŲ�ѯ��������
Private mlngQueueNoWay As Long                      '�ŶӺ������ɷ�ʽ
Private mlngValidDays As Long
Private mstrReportNum As String
Private mlngPrintWay As Long
Private mblnUseQueueMsg As Boolean

Private mstrQueueCols As String
Private mstrCalledCols As String


Private mstrCurTechnicRoomName As String            '��ǰִ�м�����
Private mstrCurTechnicDevice As String              '��Ӧ��ǰִ�м��豸
Private mstrCurTechnicGroupName As String           '��ǰִ�м���������
Private mstrTurnPage As String                      '�������תҳ��

Private mlngModule As Long
Private mstrPrivs As String
Private mblnAllDept As Boolean                      'ȫ������
Private mblnIsDataLoading As Boolean

Public Event OnQueueQuick(blnOpenQuick As Boolean)
Public Event OnCallAboutLock(ByVal lngType As Long, ByRef strLockedName As String, ByVal blnLockPara As Boolean)
'104686��أ����к�������飬
'lngType����  1:�ж��Ƿ������˲��������Ƿ��Ѿ��б������ļ��        2:���²���
'strLockedName   ��="" ������û��Ӱ�죬����˵���Ѿ����ò������ҷ���֮ǰ�����ļ�黼������
'blnLockPara   ���ڸ���PacsMain�еĲ���

'�����¼�
Public Event OnResotre(ByVal lngAdviceId As Long, ByVal strExeRoom As String)
'����¼�
Public Event OnCompleted(ByVal lngAdviceId As Long, ByVal strExeRoom As String)
'�����¼�
Public Event OnDiagnose(ByVal lngAdviceId As Long, ByVal strExeRoom As String, ByVal strTurnPage As String)
'�����¼��� ���к���Ҫ���ļ�����ң�ֻ���ڽ�������ʱ�Ž��и���
Public Event OnCalled(ByVal lngAdviceId As Long, ByVal strRoom As String, ByVal TCallWay As zlQueueOper.TCallWay)

'�Ŷӽкŵ�ѡ��ı��¼�
Public Event OnSelChange(ByVal lngAdviceId As Long)
'����������ʾ�ı��¼�
Public Event OnGroupHint(ByVal strHint As String)



Public Sub zlInitPacsQueueCfg(ByVal lngModule As Long, _
                            ByVal lngCurDeptId As Long, _
                            ByVal strCurDeptName As String, _
                            ByVal strPrivs As String, _
                            ByVal blnAllDept As Boolean, _
                            ByVal objOwner As Object)
'��ʼ��pacs�ŶӽкŶ�������
On Error GoTo errH
    Dim lngCurWorkType As Long
    Dim strQueuePrivs As String
    Dim strSQL As String
    Dim strID As String
    Dim rsData As Recordset
    Dim strRooms As String
    
    If Not objOwner Is Nothing Then Set mobjOwner = objOwner
    mlngModule = lngModule
    mlngCurDeptId = lngCurDeptId
    mstrCurDeptName = strCurDeptName
    mstrPrivs = strPrivs
    mblnAllDept = blnAllDept
    
    strQueuePrivs = ";" & GetPrivFunc(glngSys, 1160) & ";"
    
    lngCurWorkType = IIf(mlngModule = 1290, M_LNG_PACS_BUSINESS_IMG_TYPE, M_LNG_PACS_BUSINESS_CAP_TYPE)
    
    '��ȡ�ŶӽкŲ�������
    Call ReadQueueParameters(lngCurDeptId)
    
    
    ucPacsQueue.ValidDays = mlngValidDays
    ucPacsQueue.ReportNum = mstrReportNum
    ucPacsQueue.GroupField = "��������"
    ucPacsQueue.IsReleationQueueTag = True
    
    ucPacsQueue.FindWayEx = M_STR_FINDWAY_EX
    
    '��Ҫʹ����ҵ���йصĲ�ѯʱ����Ҫ��DataFields���Խ�������
    ucPacsQueue.DataFields = "ID,ҵ������,��������,����ID,����ID,ҵ��ID,�Ŷ����,�ŶӺ���,����,��������,�Ա�,����,�����Ŀ,ҽ������,�Ŷ�״̬,�Ŷ�ʱ��,����ҽ��,����ʱ��,��ע"
    ucPacsQueue.DisplayQueueFields = mstrQueueCols '& ",�Ŷ����"
    ucPacsQueue.DisplayCallFields = mstrCalledCols '& ",�Ŷ����"
    
    ucPacsQueue.CalledTarget = mstrCurTechnicRoomName       '���ú�������Ŀ�ĵ�
    
    '�����ŶӶ���
    If mblnAllDept Then
        '��ѯ��Ӧ��Ա���ڿ�������������ִ�м�
        strSQL = "select ����,ִ�м� from ҽ��ִ�з��� a, ������Ա b,���ű� c where a.����id=b.����id and a.����Id=c.Id and b.��Աid = [1]"
        strID = UserInfo.ID
    Else
        strSQL = "Select ����,ִ�м� From ҽ��ִ�з��� a, ���ű� b Where a.����Id=b.Id and  ����ID=[1]"
        strID = mlngCurDeptId
    End If
    
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "�ŶӽкŶ��л�ȡ", strID)
    While Not rsData.EOF
        If strRooms <> "" Then strRooms = strRooms & "|"
        strRooms = strRooms & "" & rsData!���� & "-" & rsData!ִ�м�
        rsData.MoveNext
    Wend
    
    ucPacsQueue.AllDepQuerys = strRooms
    
    If mblnUseQueueMsg = True Then
        '�����Ŷ���Ϣ����
        Call ucPacsQueue.UseMsgCenter(glngSys, lngModule)
    End If
    
    Call ucPacsQueue.InitQueue(gcnOracle, _
                                lngCurWorkType, _
                                Me, _
                                App.ProductName, _
                                UserInfo.����, _
                                strQueuePrivs)
                                                                
    '����Ѿ����ڵ��Ŷӽк�ҵ��
    Call ucPacsQueue.QueueOper.CustomClearData("����ID=" & lngCurDeptId)
    
    'Ӧ�ú������ã���������������
    Call ucPacsQueue.ApplyVoiceConfig
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Public Sub zlRefreshQueueData(ByVal strTechnics As String, Optional blnSetFocus As Boolean = True)
'ˢ���Ŷ�����
    Dim i As Integer
    Dim strTmp As String
    Dim strTechnicGroupNames As String
    
    mblnIsDataLoading = True
On Error GoTo errhandle
    '������Ҫ��ȡ��ִ�м����ݣ���ָ�����ŶӶ������ݣ�
    mstrQueryTechnicQueueNames = ""
    
    If strTechnics <> "" Then
        '0-��Ĭ�Ϲ�����飬1-���������÷���
        If mlngQueueNoWay = 1 Then
            '��ȡ����ѡ���ִ�м��Ӧ�ķ���,�����:80403
            If UBound(Split(strTechnics, ",")) > 0 Then
                For i = 0 To UBound(Split(strTechnics, ","))
                    strTmp = GetTechnicRoomGrounName(mlngCurDeptId, Split(Split(strTechnics, ",")(i), "-")(1))
                    If strTmp <> "" Then strTechnicGroupNames = strTechnicGroupNames & "," & strTmp
                Next
                
                strTechnicGroupNames = Mid(strTechnicGroupNames, 2)
            Else
                strTmp = GetTechnicRoomGrounName(mlngCurDeptId, Split(strTechnics, "-")(1))
                If strTmp <> "" Then strTechnicGroupNames = strTmp
            End If
            
            mstrQueryTechnicQueueNames = strTechnics & "," & strTechnicGroupNames
        Else
            mstrQueryTechnicQueueNames = strTechnics & "," & mstrCurDeptName & "-" & M_STR_NOT_ALLOT_TECHNIC
        End If
    End If

    ucPacsQueue.QueryQueueNames = mstrQueryTechnicQueueNames
    
    If mlngQueueNoWay = 0 Then
        ucPacsQueue.LastFixedQueue = M_STR_NOT_ALLOT_TECHNIC
    Else
        ucPacsQueue.LastFixedQueue = mstrCurTechnicGroupName
    End If
    
    Call ucPacsQueue.RefreshQueueData(blnSetFocus)
    
    mblnIsDataLoading = False
Exit Sub
errhandle:
    mblnIsDataLoading = False
End Sub


Private Sub ReadQueueParameters(ByVal lngCurDeptId As Long)
'��ȡ�ŶӽкŲ���
    Dim strDeptId As String
    Dim strRoomName As String
    
    '��ȡ��ǰִ�м�����
    strDeptId = Val(zlDatabase.GetPara("����ִ�м����", glngSys, mlngModule, ""))
    strRoomName = zlDatabase.GetPara("����ִ�м�����", glngSys, mlngModule, "")
    mstrTurnPage = zlDatabase.GetPara("�������תҳ��", glngSys, mlngModule, "")
    mlngValidDays = Val(GetDeptPara(lngCurDeptId, "�Ŷ����ݱ�������", 1))
    mstrReportNum = GetDeptPara(lngCurDeptId, "�Ŷӵ�������", "")
    mlngPrintWay = Val(GetDeptPara(lngCurDeptId, "�Ŷӵ���ӡ��ʽ", 0))
    mblnUseQueueMsg = Val(GetDeptPara(lngCurDeptId, "�����Ŷ���Ϣ����", 1))
    
    mstrCurTechnicRoomName = Trim(zlStr.NeedCode(strRoomName))
    mstrCurTechnicDevice = Trim(zlStr.NeedName(strRoomName))
    
    mstrQueueCols = zlDatabase.GetPara("�ŶӶ�����Ϣ����", glngSys, mlngModule, "�ŶӺ���,��������") 'GetDeptPara(lngCurDeptId, "�ŶӶ�����Ϣ����", "")
    mstrCalledCols = zlDatabase.GetPara("���ж�����Ϣ����", glngSys, mlngModule, "�ŶӺ���,��������") 'GetDeptPara(lngCurDeptId, "���ж�����Ϣ����", "")
    
    mlngQueueNoWay = Val(GetDeptPara(lngCurDeptId, "�Ŷӽкű������", 0))
    
    mstrCurTechnicGroupName = GetTechnicRoomGrounName(strDeptId, mstrCurTechnicRoomName)   '��ȡ��ǰִ�м����
End Sub

Private Sub ReadQueueRuleConfig()
'��ȡ�Ŷӹ�������
On Error GoTo errH
    Dim strSQL As String
    
    strSQL = "select id,����ID,����,����ǰ׺ from Ӱ��ִ�з���"
    Set mrsPacsQueueGroupConfig = zlDatabase.OpenSQLRecord(strSQL, "��ѯ�Ŷӷ�����Ϣ")
    
    strSQL = "select ����ID,ִ�м�,����,��ǰ����,����豸,����ǰ׺,����ID from ҽ��ִ�з���"
    Set mrsPacsQueueTechnicConfig = zlDatabase.OpenSQLRecord(strSQL, "��ѯִ�м���Ϣ")
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Public Sub zlGetInQueueInf(ByVal lngAdviceId As Long, ByVal lngExecuteDeptId As Long, _
    ByRef strQueueName As String, ByRef strCodeNo As String)
'��ȡ��������Ϣ
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    strQueueName = ""
    strCodeNo = ""
    
    If mlngQueueNoWay = 0 Then
        '�������Ŷ�
        strSQL = "select ���� from ���ű� where id=[1]"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ��������", lngExecuteDeptId)
        
        If rsData.RecordCount <= 0 Then Exit Sub
                
        strQueueName = nvl(rsData!����) & "-" & M_STR_NOT_ALLOT_TECHNIC
        strCodeNo = ""
    Else
        '�������Ŷ�
        strSQL = "select a.����,a.����ǰ׺,b.���� from Ӱ��ִ�з��� a, ���ű� b " & _
                " where a.����Id=b.Id and a.id=(select a.����ID " & _
                        " from Ӱ�������� a, ����ҽ����¼ b " & _
                        " where a.������Ŀid = b.������Ŀid and a.����ID=[1] and b.id=[2] and b.���ID is null)"
                        
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ������", lngExecuteDeptId, lngAdviceId)
        
        If rsData.RecordCount <= 0 Then Exit Sub
        
        strQueueName = nvl(rsData!����) & "-" & nvl(rsData!����)
        strCodeNo = nvl(rsData!����ǰ׺)
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Function zlGetTechnicRoomCodeNo(ByVal strTechnicRoom As String, ByVal lngDeptId As Long) As String
'��ѯִ�м���ŶӺ�����
    mrsPacsQueueTechnicConfig.Filter = "ִ�м�='" & strTechnicRoom & "' and ����ID=" & lngDeptId
    
    zlGetTechnicRoomCodeNo = ""
    
    If mrsPacsQueueTechnicConfig.RecordCount <= 0 Then
        mrsPacsQueueGroupConfig.Filter = ""
        Exit Function
    End If
    
    zlGetTechnicRoomCodeNo = nvl(mrsPacsQueueTechnicConfig!����ǰ׺)
    mrsPacsQueueTechnicConfig.Filter = ""
End Function


Private Function GetTechnicRoomGrounName(ByVal lngDeptId As Long, ByVal strTechnicRoom As String) As String
'��ȡִ�м������
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    GetTechnicRoomGrounName = ""
    strSQL = "select c.����,���� from Ӱ��ִ�з��� a, ҽ��ִ�з��� b, ���ű� c where a.id=b.����ID  and b.����ID=c.Id and b.����Id=[1] and b.ִ�м�=[2]"
    
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯҽ������", lngDeptId, strTechnicRoom)
    If rsData.RecordCount <= 0 Then Exit Function
    
    GetTechnicRoomGrounName = nvl(rsData!����) & "-" & nvl(rsData!����)
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function zlInQueue(ByVal lngAdviceId As Long, _
                                ByVal strName As String, _
                                ByVal lngDeptId As Long, _
                                ByVal strQueueName As String, _
                                ByVal strTarget As String, _
                                ByVal strNoTag As String) As Boolean
        
    Dim rsData As ADODB.Recordset
    Dim rsTmp As ADODB.Recordset
    Dim strSQL As String
    Dim lngTimePoint As Long
    Dim lngTimeInterval As Long
On Error GoTo errhandle
    
    zlInQueue = False

    Set rsData = ucPacsQueue.QueueOper.FindQueueInf(lngAdviceId)
    
    If rsData.RecordCount > 0 Then  '�����Ŷ�����
        '�ж��Ƿ�ԤԼ����
        strSQL = "Select ID,ԤԼ��ʼʱ�� From Ӱ��ԤԼ��¼ Where ҽ��Id=[1]"
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "����ԤԼ��Ϣ", lngAdviceId)
        If rsTmp.RecordCount > 0 Then
            '�Ѿ�ԤԼ�����ж�ԤԼ���ں͵�ǰʱ���Ƿ�һ�£������һ���򵯳���ʾ���������Ŷ�
            '���ԤԼ���ں͵�ǰ����һ�£���ֱ�ӽ����Ŷ�״̬
            If Format(nvl(rsTmp!ԤԼ��ʼʱ��), "yyyy-mm-dd") <> Format(zlDatabase.Currentdate, "yyyy-mm-dd") Then
                If MsgBoxD(Me, "��ǰ����ԤԼ�ļ������Ϊ " & Format(nvl(rsTmp!ԤԼ��ʼʱ��), "yyyy-mm-dd") & "���뵱ǰʱ�䲻һ�£��������Ŷӣ��Ƿ������", vbInformation + vbYesNo, gstrSysName) = vbYes Then
                    Call zlUpdatePacsQueue(lngAdviceId, strName, lngDeptId, strQueueName, strTarget, strNoTag)
                End If
            Else
                Call ReservationQueue(nvl(rsData!ID))
            End If
        Else
            'û��ԤԼ����ͨ����Ŷӷ�ʽ����
            lngTimePoint = Val(Format(time, "h"))
            If lngTimePoint <= 4 Then
                lngTimeInterval = DateDiff("s", nvl(rsData!�Ŷ�ʱ��), Format(zlDatabase.Currentdate - 1, "YYYY-MM-DD 20:00:00"))
            Else
                lngTimeInterval = DateDiff("s", nvl(rsData!�Ŷ�ʱ��), Format(zlDatabase.Currentdate, "YYYY-MM-DD 00:00:00"))
            End If
            
            If lngTimeInterval > 0 Then
                '���ǽ�����ǰ�����ݣ���ֱ�Ӹ����Ŷ�
                Call zlUpdatePacsQueue(lngAdviceId, strName, lngDeptId, strQueueName, strTarget, strNoTag)
            Else
                If MsgBoxD(Me, "��ǰ��黼�������ŶӽкŶ����У��Ƿ������Ŷӣ�", vbInformation + vbYesNo, gstrSysName) = vbYes Then
                    Call zlUpdatePacsQueue(lngAdviceId, strName, lngDeptId, strQueueName, strTarget, strNoTag)
                End If
            End If
        End If
    Else
        Call zlInPacsQueue(lngAdviceId, strName, lngDeptId, strQueueName, strTarget, strNoTag)
    End If
    
    zlInQueue = True
Exit Function
errhandle:
    zlInQueue = False
End Function

Public Function zlInPacsQueue(ByVal lngAdviceId As Long, _
                                ByVal strName As String, _
                                ByVal lngDeptId As Long, _
                                ByVal strQueueName As String, _
                                ByVal strTarget As String, _
                                ByVal strNoTag As String) As Boolean
'����pacs�ŶӶ���

On Error GoTo errhandle
    Dim lngQueueId As Long
    Dim strExpandData As String
    Dim strNewQueueNo As String
    
    zlInPacsQueue = False
    
    strExpandData = "����Id=" & lngDeptId & ",�Ŷӱ��='" & strNoTag & "'"
    '�����������
    lngQueueId = ucPacsQueue.QueueOper.InsertQueue(strQueueName, , lngAdviceId, strName, strTarget, , strExpandData)
    If lngQueueId <= 0 Then Exit Function
    
    '��ʼ�Ŷ�
    Call ucPacsQueue.QueueOper.LineQueue(lngQueueId, strNewQueueNo)
    
    'ˢ���б�������ʾ
    Call ucPacsQueue.RefreshQueueRowState(lngQueueId, TQueueState.qsQueueing)
    
    Call AutoPrintQueueInf(lngQueueId)
    
    zlInPacsQueue = True
Exit Function
errhandle:
    zlInPacsQueue = False
End Function

Public Sub ReservationQueue(ByVal lngAdviceId As Long)
'��ʼ��ԤԼ�����Ŷ�
On Error GoTo errH
    Dim rsData As ADODB.Recordset
    Dim strNewQueueNo As String
    Dim lngQueueId As Long
    Dim strSQL As String
    
    strSQL = "Select Id from �ŶӽкŶ��� Where ҵ������=1 And ҵ��ID=[1]"
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯԤԼ����", lngAdviceId)
    If rsData.RecordCount <= 0 Then
        Exit Sub
    End If
    
    lngQueueId = Val(nvl(rsData!ID))
    
    '��ʼ�Ŷ�
    Call ucPacsQueue.QueueOper.LineQueue(lngQueueId, strNewQueueNo, False)
    
    'ˢ���б�������ʾ
    Call ucPacsQueue.RefreshQueueRowState(lngQueueId, TQueueState.qsQueueing)
    
    Call AutoPrintQueueInf(lngQueueId)
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub AutoPrintQueueInf(ByVal lngQueueId As Long)
'�Զ���ӡ������Ϣ
On Error GoTo errhandle
    If mlngPrintWay = 1 Then
        '�Զ���ӡ
        Call ucPacsQueue.QueueOper.PrintQueueNo(lngQueueId, True, Me)
    ElseIf mlngPrintWay = 2 Then
        '��ʾ��ӡ
        If MsgBoxD(mobjOwner, "�Ƿ��ӡ��ǰ�ź���Ϣ��", vbYesNo, gstrSysName) = vbYes Then
            Call ucPacsQueue.QueueOper.PrintQueueNo(lngQueueId, True, Me)
        End If
    End If
Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Public Function zlUpdatePacsQueue(ByVal lngAdviceId As Long, _
                                ByVal strPatientName As String, _
                                ByVal lngDeptId As Long, _
                                Optional ByVal strQueueName As String = "", _
                                Optional ByVal strTarget As String = " ", _
                                Optional ByVal strNoTag As String = " ") As Boolean
'�����ŶӶ�����Ϣ
    Dim lngQueueId As Long
    Dim strExpandData As String
    
    zlUpdatePacsQueue = False
    
    If strQueueName = "" Then Exit Function
    
    lngQueueId = ucPacsQueue.QueueOper.FindQueueId(lngAdviceId)

    
    If strPatientName <> "" Then
        Call ucPacsQueue.QueueOper.DeleteQueue(lngQueueId)
        zlUpdatePacsQueue = zlInPacsQueue(lngAdviceId, strPatientName, lngDeptId, strQueueName, strTarget, strNoTag)
    Else
    
        strExpandData = ""
        If strPatientName <> "" Then
            strExpandData = strExpandData & "��������=''" & strPatientName & "''"
        End If
    
        If strTarget <> " " Then
            If strExpandData <> "" Then strExpandData = strExpandData & ","
            strExpandData = strExpandData & "����=''" & strTarget & "''"
        End If
        
        If strNoTag <> " " Then
            If strExpandData <> "" Then strExpandData = strExpandData & ","
            strExpandData = strExpandData & "�Ŷӱ��=''" & strNoTag & "''"
        End If
    
        Call ucPacsQueue.QueueOper.UpdateQueue(lngQueueId, strExpandData)
        Call ucPacsQueue.RefreshQueueData
    
        zlUpdatePacsQueue = True
    End If
End Function


Public Function zlCancelPacsQueue(ByVal lngAdviceId As Long) As Boolean
'����pacs�Ŷ�
    Dim lngQueueId As Long
    
    zlCancelPacsQueue = False
    lngQueueId = ucPacsQueue.QueueOper.FindQueueId(lngAdviceId)
    
    'ִ������ɾ������
    Call ucPacsQueue.QueueOper.DeleteQueue(lngQueueId)
    
    zlCancelPacsQueue = True
    
    'ˢ���б�������ʾ
    Call ucPacsQueue.RefreshQueueRowState(lngQueueId, TQueueState.qsAbstain)
End Function


Public Function zlCompletePacsQueue(ByVal lngAdviceId As Long) As Boolean
'���pacs�Ŷ�
    Dim lngQueueId As Long
    
    lngQueueId = ucPacsQueue.QueueOper.FindQueueId(lngAdviceId)
    
    'ִ������ŶӲ���
    zlCompletePacsQueue = ucPacsQueue.QueueOper.CompleteQueue(lngQueueId)
    
    'ˢ���б�������ʾ
    Call ucPacsQueue.RefreshQueueRowState(lngQueueId, TQueueState.qsComplete)
End Function

Public Sub zlExecuteCommandbar(Control As CommandBarControl)
'ִ�в˵��¼�
    Call ucPacsQueue.zlExecuteCommandBars(Control)
End Sub


Private Sub Form_Load()
'    'Debug Code...
'        Call InitDebugObject(1290, Me, "zlhis", "HIS")
'        Call InitPacsQueueCfg("���Զ���,050204-��������", "��������", "�ŶӺ���,��������,ҽ������", "�ŶӺ���,��������")
'    'Debug End

    Call ReadQueueRuleConfig
End Sub

Private Sub Form_Resize()
On Error Resume Next
    ucPacsQueue.Left = 0
    ucPacsQueue.Top = 0
    ucPacsQueue.Width = Me.ScaleWidth
    ucPacsQueue.Height = Me.ScaleHeight
    
    If Me.ScaleWidth < 12900 Then
        ucPacsQueue.IsIconLarge = False
        ucPacsQueue.IsShowToolText = IIf(Me.ScaleWidth < 8000, False, True)
    Else
        ucPacsQueue.IsIconLarge = True
        ucPacsQueue.IsShowToolText = True
    End If
err.Clear
End Sub

Private Function GetRoom(ByVal lngQueueId As Long) As String
'��ȡ�ŶӽкŶ�Ӧ�����ң�ִ�м䣩
    GetRoom = nvl(ucPacsQueue.QueueOper.GetQueueInf(lngQueueId, "����")!����)
End Function


Private Function GetAdviceId(ByVal lngQueueId As Long) As Long
'��ȡ�ŶӽкŶ�Ӧ��ҽ��ID
    GetAdviceId = Val(nvl(ucPacsQueue.QueueOper.GetQueueInf(lngQueueId, "ҵ��ID")!ҵ��ID))
End Function

Private Sub Form_Unload(Cancel As Integer)
    Set mobjOwner = Nothing
    Set mrsPacsQueueGroupConfig = Nothing
    Set mrsPacsQueueTechnicConfig = Nothing
End Sub

Private Sub ucPacsQueue_OnCallPreAfter(ByVal lngQueueId As Long, ByVal lngCallWay As zlQueueOper.TCallWay)
'���к󴥷��¼�
    Dim lngAdviceId As Long
    Dim strRoom As String
    
    lngAdviceId = GetAdviceId(lngQueueId)
    strRoom = GetRoom(lngQueueId)
    
    RaiseEvent OnCalled(lngAdviceId, strRoom, lngCallWay)

End Sub

Private Sub UcPacsQueue_OnCallPreBefore(ByVal lngQueueId As Long, ByVal lngCallWay As zlQueueOper.TCallWay, strCallContext As String, blnCancel As Boolean)
'Pacs�Ŷӽкź����¼�����
On Error GoTo errH
    Dim strOldTechnicRoomName As String
    Dim lngResult As Long
    Dim lngRowIndex As Long
    Dim strSQL As String
    Dim lngAdviceId As Long
    Dim strName As String
    Dim blnTmp As Boolean
        
    '����δ����ִ�м�ļ�飬����Ҫ���뵱ǰ���ڵ�ִ�м䵽�Ŷӽкŵ�������
    If lngCallWay = cwOrder Or lngCallWay = cwSpecify Or lngCallWay = cwWaitRoom Then
        lngAdviceId = GetAdviceId(lngQueueId)
        
        '�Ѿ��������ļ�飬����Ȼ�����������ڵ�
        strName = lngAdviceId
        RaiseEvent OnCallAboutLock(1, strName, blnTmp)
              
        '�жϵ�ǰ�����Ƿ��Ѿ���ִ�м䣬����Ѿ����䵫�뵱ǰִ�м䲻ͬ������Ҫ��������
        strOldTechnicRoomName = Trim(nvl(ucPacsQueue.QueueOper.GetQueueInf(lngQueueId, "����")!����))
        
        If strOldTechnicRoomName <> "" And strOldTechnicRoomName <> mstrCurTechnicRoomName Then
            lngResult = MsgBoxD(Me, "��ǰ����ѱ����䵽 ��" & strOldTechnicRoomName & "�� ִ�м䣬�Ƿ���Ҫ���ĵ���ִ�м�ִ�У�" & vbCrLf & _
                                    "ѡ���ǡ���ʾ���ĵ���ִ�м����У�" & vbCrLf & _
                                    "ѡ�񡰷񡱱�ʾ������ִ�м�ֱ�Ӻ��У�" & vbCrLf & _
                                    "ѡ��ȡ������ʾ�����к��У�", vbYesNoCancel, "��ʾ")
            
            If lngResult = vbCancel Then
                blnCancel = True
                Exit Sub
            End If
        End If
          
        '��������Ŀ�ĵ�
        If lngResult = vbYes Or strOldTechnicRoomName = "" Then
            Call ucPacsQueue.QueueOper.WriteTarget(lngQueueId)
            '��Ҫͬ������ҽ�����͵�ִ�м�
            
            strSQL = "zl_Ӱ����_����ִ�м�(" & lngAdviceId & ",'" & mstrCurTechnicRoomName & "','" & mstrCurTechnicDevice & "')"
            
            Call zlDatabase.ExecuteProcedure(strSQL, "���¼��ִ�м�")
        
            '�����Ŷ��б��ϵ�������ʾ
            lngRowIndex = ucPacsQueue.GetRowIndex(qftWaitQueue, "ID", lngQueueId)
            If lngRowIndex >= 0 Then
                Call ucPacsQueue.SetListValue(qftWaitQueue, lngRowIndex, "����", mstrCurTechnicRoomName)
                Call ucPacsQueue.Populate(qftWaitQueue)
            End If
        End If
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub UcPacsQueue_OnCmdBarUpdate(objComandBarControl As Object)
'���ν��ﰴť
'    If objComandBarControl.ID = TMenuId.mi���� Then
'        objComandBarControl.Visible = False
'    End If
End Sub


Private Sub ucPacsQueue_OnConfigEvent(blnUseCustom As Boolean)
'Pacs�Ŷӽк������¼�
On Error GoTo errhandle
    Dim objCfgWindow As frmWork_QueueCfg
    Dim blnLock As Boolean
    Dim blnQuick As Boolean
    Dim strTmp As String
    
    blnUseCustom = True
    
    Set objCfgWindow = New frmWork_QueueCfg
    
    If objCfgWindow.ShowQueueConfig(ucPacsQueue, mlngModule, mstrPrivs, mlngCurDeptId, mblnAllDept, Me, blnLock, blnQuick) Then
        '���¶�ȡ��Ӧ������
        RaiseEvent OnCallAboutLock(2, strTmp, blnLock)
        RaiseEvent OnQueueQuick(blnQuick)
        Call zlInitPacsQueueCfg(mlngModule, mlngCurDeptId, mstrCurDeptName, mstrPrivs, mblnAllDept, Nothing)
        Call ucPacsQueue.RefreshQueueData
    End If
    
Exit Sub
errhandle:
    Unload objCfgWindow
    Set objCfgWindow = Nothing
    
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub ucPacsQueue_OnFindData(ByVal strFindWay As String, ByVal strFindValue As String, txtFind As Object, rsData As ADODB.Recordset, blnUseCustom As Boolean)
'�Զ������
On Error GoTo errH
    Dim strSQL As String
    Dim strCurQueryQueueNames As String
    Dim strQueryCols As String
    Dim blnQueryProject As Boolean
    Dim strTempCols As String '��Щ�е���������Ϊnumber���ͣ��������val����
    
    blnUseCustom = True
    strCurQueryQueueNames = Replace(mstrQueryTechnicQueueNames, ",", "','")
    
    If strFindWay = "�ŶӺ�" Or strFindWay = "�ŶӺ���" Then strFindWay = "�Ŷӱ��||a.�ŶӺ���"
    If strFindWay = "����" Then strFindWay = "��������"
    strTempCols = "�����,סԺ��,ID,ҵ������,����ID,����ID,ҵ��ID,�Ŷ�״̬"
        
    '"ID,ҵ������,��������,����ID,����ID,ҵ��ID,�Ŷ����,�ŶӺ���,����,��������,�Ա�,����,�����Ŀ,ҽ������,�Ŷ�״̬,�Ŷ�ʱ��,����ҽ��,����ʱ��,��ע"
    
    '��ȡ��Ҫ�����ݿ��в�ѯ���ֶ�
    strQueryCols = ucPacsQueue.GetValidCols("a.ID,a.ҵ������,a.��������,a.����ID,a.����ID,a.ҵ��ID,a.�ŶӺ���,a.�Ŷӱ��,a.�Ŷ����,a.����," & _
                                            "a.��������,b.�Ա�,b.����,c.���� as �����Ŀ,b.ҽ������,a.�Ŷ�״̬," & _
                                            "a.�Ŷ�ʱ��,a.����ҽ��,a.����ʱ��,a.��ע", "a")
    
    blnQueryProject = IIf(InStr(strQueryCols, "�����Ŀ") > 0, True, False)
    
    strSQL = "select " & strQueryCols & _
            " from �ŶӽкŶ��� a, ����ҽ����¼ b,������Ϣ d " & IIf(blnQueryProject, ", ������ĿĿ¼ c ", "") & _
            " where a.ҵ��ID=b.Id and b.����ID=d.����ID " & _
                    IIf(blnQueryProject, " and b.������ĿID=c.ID and c.���='D'", "") & _
            "       and b.���ID is null and a.ҵ������=1 " & _
            "       and a.����ID=[1] " & IIf(strCurQueryQueueNames = "", "", "and �������� in ('" & strCurQueryQueueNames & "') ") & _
            IIf(InStr(M_STR_FINDWAY_EX, strFindWay) > 0, " and upper(d.", " and upper(a.") & IIf(strFindWay = "���￨", "���￨��", strFindWay) & ")=upper([2]) " & _
            IIf(ucPacsQueue.QueueOper.CustomOrder = "", "", " order by " & ucPacsQueue.QueueOper.CustomOrder)
    
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯPACS�ŶӶ���", mlngCurDeptId, IIf(InStr(strTempCols, strFindWay) > 0, Val(strFindValue), Trim(strFindValue)))
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub ucPacsQueue_OnLocateData(ByVal strLocateWay As String, ByVal strLocateValue As String, txtFind As Object, lngQueueId As Long, blnUseCustom As Boolean)
'�Ŷ����ݶ�λ�¼�
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    Dim strTempCols As String '��Щ�е���������Ϊnumber���ͣ��������val����
    
    blnUseCustom = True
    
    If strLocateWay = "�ŶӺ�" Or strLocateWay = "�ŶӺ���" Then strLocateWay = "�Ŷӱ��||a.�ŶӺ���"
    If strLocateWay = "����" Then strLocateWay = "��������"
    strTempCols = "�����,סԺ��,ID,ҵ������,����ID,����ID,ҵ��ID,�Ŷ�״̬"
    
    strSQL = "select a.ID from �ŶӽкŶ��� a, ����ҽ����¼ b, ������Ϣ d" & _
            " where a.ҵ��ID=b.ID and b.����ID=d.����ID and b.���ID is null and upper(" & _
            IIf(InStr(M_STR_FINDWAY_EX, strLocateWay) > 0, " d.", " a.") & IIf(strLocateWay = "���￨", "���￨��", strLocateWay) & ")=upper([1])"
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��λ�Ŷ�����", IIf(InStr(strTempCols, strLocateWay) > 0, Val(strLocateValue), Trim(strLocateValue)))
    
    If rsData.RecordCount <= 0 Then Exit Sub
    
    lngQueueId = Val(nvl(rsData!ID))
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub ucPacsQueue_OnGroupHint(ByVal strHintContext As String)
On Error Resume Next
    RaiseEvent OnGroupHint(strHintContext)
err.Clear
End Sub

Private Sub ucPacsQueue_OnModifyBefore(ByVal lngListType As zlQueueOper.TQueueFromType, ByVal lngQueueId As Long, objInputCfg As Dictionary, blnCancel As Boolean, blnUseCustom As Boolean)
    '��ѯ��ǰ���ҵ�������Ϣ
    Dim strRooms As String
    
    If mrsPacsQueueTechnicConfig Is Nothing Then Exit Sub
    
    mrsPacsQueueTechnicConfig.Filter = "����ID=" & mlngCurDeptId
    If mrsPacsQueueTechnicConfig.RecordCount <= 0 Then Exit Sub
    
    While Not mrsPacsQueueTechnicConfig.EOF
        If strRooms <> "" Then strRooms = strRooms & ","
        strRooms = strRooms & nvl(mrsPacsQueueTechnicConfig!ִ�м�)
        
        Call mrsPacsQueueTechnicConfig.MoveNext
    Wend
    
    mrsPacsQueueTechnicConfig.Filter = ""
    
    objInputCfg.Item("����") = objInputCfg.Item("����") & ":" & strRooms
err.Clear
End Sub

Private Sub ucPacsQueue_OnModifyAfter(ByVal lngQueueId As Long, objUpdateValue As Dictionary)
    objUpdateValue.Item("�ŶӺ���") = objUpdateValue.Item("�Ŷӱ��") & objUpdateValue.Item("�ŶӺ���")
End Sub

Private Sub UcPacsQueue_OnQueryQueueData(rsData As ADODB.Recordset, blnUseCustom As Boolean, strRooms As String)
On Error GoTo errH
'��ѯpacs�ŶӶ�������
'�����漰����ѯpacs�����ص�������Ϣ�������Ҫʹ�ø��¼������Զ����ѯ
'��ѯ������Ŷ����
    Dim strSQL As String
    Dim strCurQueryQueueNames As String
    Dim lngTimePoint As Long
    Dim strStartTime As String
    Dim strEndTime As String
    Dim strQueryCols As String
    Dim blnQueryProject As Boolean
    Dim dtNow As Date
    
    If strRooms <> "" Then
        strCurQueryQueueNames = Replace(strRooms, ",", "','")
    Else
        strCurQueryQueueNames = Replace(mstrQueryTechnicQueueNames, ",", "','")
    End If
    
    blnUseCustom = True
    dtNow = zlDatabase.Currentdate
    
    lngTimePoint = Val(Format(time, "h"))
    If lngTimePoint <= 4 Then
        strStartTime = zlStr.To_Date(Format(dtNow - 1, "yy-mm-dd 20:00:00"))
        strEndTime = zlStr.To_Date(Format(dtNow, "yy-mm-dd 08:00:00"))
    Else
        strStartTime = zlStr.To_Date(Format(dtNow, "yy-mm-dd 00:00:00"))
        strEndTime = zlStr.To_Date(Format(dtNow, "yy-mm-dd 23:59:59"))
    End If
    
    '"ID,ҵ������,��������,����ID,����ID,ҵ��ID,�Ŷ����,�ŶӺ���,����,��������,�Ա�,����,�����Ŀ,ҽ������,�Ŷ�״̬,�Ŷ�ʱ��,����ҽ��,����ʱ��,��ע"
    
    '��ȡ��Ҫ�����ݿ��в�ѯ���ֶ�
    strQueryCols = ucPacsQueue.GetValidCols("a.ID,a.ҵ������,a.��������,a.����ID,a.����ID,a.ҵ��ID,a.�Ŷӱ��,a.�ŶӺ���,a.�Ŷ����,a.����," & _
                                            "a.��������,b.�Ա�,b.����,c.���� as �����Ŀ,b.ҽ������,a.�Ŷ�״̬," & _
                                            "a.�Ŷ�ʱ��,a.����ҽ��,a.����ʱ��,a.��ע", "a")
    
    'strQueryCols = Replace(strQueryCols, "A.�ŶӺ���", "A.�Ŷӱ�� || A.�ŶӺ��� as �ŶӺ���")
    
    blnQueryProject = IIf(InStr(strQueryCols, "�����Ŀ") > 0, True, False)
    
    strSQL = "select " & strQueryCols & _
            " from �ŶӽкŶ��� a, ����ҽ����¼ b" & IIf(blnQueryProject, ", ������ĿĿ¼ c ", "") & _
            " where a.ҵ��ID=b.Id " & _
                    IIf(blnQueryProject, " and b.������ĿID=c.ID and c.���='D'", "") & " and b.���ID is null and a.ҵ������=1 and a.�Ŷ�ʱ�� between " & strStartTime & " and " & strEndTime & _
            "       and a.����ID=[1] " & IIf(strCurQueryQueueNames = "", "", "and �������� in ('" & strCurQueryQueueNames & "') ") & IIf(ucPacsQueue.QueueOper.CustomOrder = "", "", " order by " & ucPacsQueue.QueueOper.CustomOrder)
    
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯPACS�ŶӶ���", mlngCurDeptId)
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub UcPacsQueue_OnSelectionChanged(ByVal lngListType As zlQueueOper.TQueueFromType, ByVal lngQueueId As Long, objQueueList As Object, objReportRow As Object)
'�Ŷӽк�ѡ���иı��¼�
    Dim lngAdviceId As Long
    Dim lngColIndex As Long
    
    If objReportRow Is Nothing Then Exit Sub
    If objReportRow.Record Is Nothing Then Exit Sub
    If mblnIsDataLoading Then Exit Sub  '����ˢ�¹��̲�����selchange��λ�¼�
    
    lngColIndex = ucPacsQueue.GetColumnIndex(lngListType, "ҵ��ID")
    
    lngAdviceId = Val(objReportRow.Record(lngColIndex).value)
    
    RaiseEvent OnSelChange(lngAdviceId)
End Sub

Private Sub ucPacsQueue_OnWorkAfter(ByVal lngQueueId As Long, ByVal strCurQueueName As String, ByVal lngOperationType As zlQueueOper.TOperationType)
'������н������������Ҫ���¼��ġ�ִ�м䡱����
On Error GoTo errH
    Dim lngAdviceId As Long
    Dim strSQL As String
    Dim strRoom As String
    Dim lngRowIndex As Long
    Dim strCodeTag As String
    Dim rsData As ADODB.Recordset
    
    If lngOperationType = otComplete Then
        lngAdviceId = GetAdviceId(lngQueueId)
        
        '���ʱ����Ҫ�������յ�ִ�м�
        strSQL = "zl_Ӱ����_����ִ�м�(" & lngAdviceId & ",'" & mstrCurTechnicRoomName & "','" & mstrCurTechnicDevice & "')"
        Call zlDatabase.ExecuteProcedure(strSQL, Me.Caption)
        
        RaiseEvent OnCompleted(lngAdviceId, mstrCurTechnicRoomName)
        
    ElseIf lngOperationType = otDiagnose Then
        lngAdviceId = GetAdviceId(lngQueueId)
        
        '����ʱ�����µ�ǰ����ִ�м�
        strSQL = "zl_Ӱ����_����ִ�м�(" & lngAdviceId & ",'" & mstrCurTechnicRoomName & "','" & mstrCurTechnicDevice & "')"
        Call zlDatabase.ExecuteProcedure(strSQL, Me.Caption)
                        
        RaiseEvent OnDiagnose(lngAdviceId, mstrCurTechnicRoomName, mstrTurnPage)
    ElseIf lngOperationType = otRestore Then
        strRoom = ""
        
        lngRowIndex = ucPacsQueue.GetRowIndex(qftWaitQueue, "ID", lngQueueId)
            
        '��������ţ���Ҫ�ж��Ƿ�������ŶӶ��У�������н����˵���������Ҫ�����һ�ִ�м���ж�Ӧ�ĸ���
        If strCurQueueName <> mstrCurTechnicGroupName And strCurQueueName <> mstrCurDeptName & "-" & M_STR_NOT_ALLOT_TECHNIC Then
            '��ȡ��ǰ���ж�Ӧ����������
            strRoom = Replace(strCurQueueName, mstrCurDeptName & "-", "")
            
            '�����Ŷ�����
            Call ucPacsQueue.QueueOper.WriteTarget(lngQueueId, strRoom)
        End If
        
        '����ҽ��ִ�м�
        lngAdviceId = GetAdviceId(lngQueueId)
        
        strSQL = "zl_Ӱ����_����ִ�м�(" & lngAdviceId & ",'" & strRoom & "','" & mstrCurTechnicDevice & "')"
        Call zlDatabase.ExecuteProcedure(strSQL, "���¼��ִ�м�")

        'ˢ�½����ŶӺ��뼰�Ŷ����ҵ���ʾ
        If lngRowIndex >= 0 Then
            Call ucPacsQueue.SetListValue(qftWaitQueue, lngRowIndex, "����", strRoom)
            Call ucPacsQueue.Populate(qftWaitQueue)
        End If
        
        RaiseEvent OnResotre(lngAdviceId, strRoom)
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub ucPacsQueue_OnCreateQueueNo(ByVal lngQueueId As Long, ByVal strQueueName As String, strQueueNo As String)
'�ŶӺ��������¼�
On Error GoTo errH
    Dim strRoom As String
    Dim strCodeTag As String
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    If strQueueNo = "" Then Exit Sub
    
    strCodeTag = ""
    If strQueueName <> mstrCurTechnicGroupName And strQueueName <> mstrCurDeptName & "-" & M_STR_NOT_ALLOT_TECHNIC Then
        '��ȡִ�м�ǰ׺
        strRoom = Replace(strQueueName, mstrCurDeptName & "-", "")
        strCodeTag = zlGetTechnicRoomCodeNo(strRoom, mlngCurDeptId)
    Else
        
        '����ǰ������Ŷӣ���û���Ŷӱ��
        If mlngQueueNoWay = 1 Then
            '��ȡ������Ŷӱ��
            strSQL = "select a.����,a.����ǰ׺ from Ӱ��ִ�з��� a " & _
                    " where a.����ID=[1] and a.����=[2]"
            Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ���ŷ���ǰ׺", mlngCurDeptId, Replace(mstrCurTechnicGroupName, mstrCurDeptName & "-", ""))
                    
            If rsData.RecordCount > 0 Then
                strCodeTag = nvl(rsData!����ǰ׺)
            End If
        End If
    End If
    
    '��Ҫ�����Ŷӱ��
    Call ucPacsQueue.QueueOper.UpdateQueue(lngQueueId, "�Ŷӱ��=''" & strCodeTag & "''")
        
    strQueueNo = strCodeTag & strQueueNo
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Sub CloseQueueQuick()
    If Not ucPacsQueue Is Nothing Then
        ucPacsQueue.CloseQueueQuick
    End If
End Sub

Public Sub OpenQueueQuick(ByVal strTechnics As String, objOwer As Object)
    Call zlRefreshQueueData(strTechnics)
    
    If Not ucPacsQueue Is Nothing Then
        ucPacsQueue.OpenQueueQuick objOwer
    End If
End Sub

Public Sub ChangeToAllDept(ByVal blnAllDept As Boolean)
    mblnAllDept = blnAllDept
End Sub

