VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsPacsMsgProcess"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private WithEvents mobjMsgProcess As clsMipModule
Attribute mobjMsgProcess.VB_VarHelpID = -1
Private mobjXml As clsXML

Private mlngModule As Long
Private mlngCurDeptId As Long
Private mstrPrivs As String
Private mblnMsgOpened As Boolean
Private mblnDebugMsg As Boolean


Public Event OnRecevieMsg(ByVal strMsgItemIdentity As String, ByVal strXmlContext As String, rsData As ADODB.Recordset, _
                            objMsgPro As clsMipModule, objXML As clsXML)
                            
Public Event OnOpenModule(ByVal lngSystem As Long, ByVal lngModule As Long)
Public Event OnOpenLink(ByVal strMsgKey As String, ByVal strLinkPara As String)


Public Property Get XML() As clsXML
    Set XML = mobjXml
End Property

Public Property Get Msg() As clsMipModule
    If mblnMsgOpened Then
        Set Msg = mobjMsgProcess
    Else
        Set Msg = Nothing
    End If
End Property

Private Function SendMsg(ByVal lngAdviceID As Long, ByVal strMsgTag As String, Optional strReportId As String = "") As Boolean
'������Ϣ
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    Dim lngStartTime As Long
    
    SendMsg = False
    
    If (Not mblnMsgOpened) And strMsgTag <> G_STR_MSG_ZLHIS_PACS_005 Then Exit Function
    
    If Trim(strReportId) = "" Then
        strSQL = "select zl_Ӱ����Ϣ_XML���ݻ�ȡ([1], [2], [3]) as xml from dual"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯΣ��ֵ��Ϣ����", lngAdviceID, strMsgTag, UserInfo.�û���)
    Else
        strSQL = "select zl_Ӱ����Ϣ_XML���ݻ�ȡ([1], [2], [3], [4]) as xml from dual"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯΣ��ֵ��Ϣ����", lngAdviceID, strMsgTag, UserInfo.�û���, strReportId)
    End If
    
    If rsData.RecordCount <= 0 Then Exit Function
    
    If mblnDebugMsg Then
        lngStartTime = GetTickCount
    End If
    
    If mblnMsgOpened Then SendMsg = mobjMsgProcess.CommitMessage(strMsgTag, nvl(rsData!XML))
    
    If strMsgTag = G_STR_MSG_ZLHIS_PACS_005 Then
        SendMsg = zl9comlib.zlDatabase.SendMsg(strMsgTag, nvl(rsData!XML))
    End If
    
    If mblnDebugMsg Then
        OutputDebugString "��Ϣ [" & strMsgTag & "] ����ʱ��Ϊ" & GetTickCount - lngStartTime & "���롣"
    End If
    
    If SendMsg = False Then
        Debug.Print "��Ϣ" & strMsgTag & "����ʧ�ܡ�"
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Function Send_Msg_Request(ByVal lngAdviceID As Long) As Boolean
'���ͼ��������Ϣ

    Send_Msg_Request = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_CIS_017)
End Function


Public Function Send_Msg_CancelAdvice(ByVal lngAdviceID As Long) As Boolean
'����ҽ��������Ϣ

    Send_Msg_CancelAdvice = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_CIS_024)
End Function


Public Function Send_Msg_StudyComplete(ByVal lngAdviceID As Long, Optional ByVal strReportId As String = "") As Boolean
'���ͼ�������Ϣ
'strReportId,�°汨��ID
    Send_Msg_StudyComplete = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_PACS_001, strReportId)
End Function


Public Function Send_Msg_StateSync(ByVal lngAdviceID As Long) As Boolean
'����״̬ͬ����Ϣ

    Send_Msg_StateSync = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_PACS_002)
End Function

Public Function Send_Msg_Arrange(ByVal lngAdviceID As Long) As Boolean
'���Ͱ�����Ϣ

    Send_Msg_Arrange = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_CIS_005)
End Function

Public Function Send_Msg_StateCancel(ByVal lngAdviceID As Long) As Boolean
'����״̬������Ϣ

    Send_Msg_StateCancel = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_PACS_003)
End Function


Public Function Send_Msg_CancelComplete(ByVal lngAdviceID As Long) As Boolean
'����״̬������Ϣ

    Send_Msg_CancelComplete = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_PACS_004)
End Function


Public Function Send_Msg_Critical(ByVal lngAdviceID As Long) As Boolean
'����Σ��ֵ֪ͨ��Ϣ

    Send_Msg_Critical = SendMsg(lngAdviceID, G_STR_MSG_ZLHIS_PACS_005)
End Function

Public Sub ChangeMsgReceiveDept(ByVal lngCurDeptId As Long)
'�ı���Ϣ���տ���
    mlngCurDeptId = lngCurDeptId
End Sub


Public Sub OpenMsgCenter(ByVal lngModule As Long, ByVal lngCurDeptId As Long, ByVal strPrivs As String)
'��ʼ����Ϣ����
    Dim blnInit As Boolean
    Dim blnAdd As Boolean
    
    mlngModule = lngModule
    mlngCurDeptId = lngCurDeptId
    mstrPrivs = strPrivs
    
    Set mobjMsgProcess = New clsMipModule
    
    blnInit = mobjMsgProcess.InitMessage(glngSys, mlngModule, strPrivs)
    blnAdd = AddMipModule(mobjMsgProcess)
    
    mblnDebugMsg = Val(GetSetting("ZLSOFT", "����ģ��", "��Ϣ����", 0))
    
    If blnInit = True And blnAdd = True Then
        mblnMsgOpened = True
    Else
        mblnMsgOpened = False
    End If
End Sub


Public Sub CloseMsgCenter()
'�ر���Ϣ����
    If mblnMsgOpened = False Then Exit Sub
    
    
    Call DelMipModule(mobjMsgProcess)
    
    Call mobjMsgProcess.CloseMessage
    
    Set mobjMsgProcess = Nothing
    
    mblnMsgOpened = False
End Sub

Private Sub Class_Initialize()
'��ʼ����Ϣ����
    
    Set mobjXml = New clsXML
    
    mblnMsgOpened = False
End Sub

Private Sub Class_Terminate()
    Call CloseMsgCenter
    
    Set mobjXml = Nothing
End Sub



Private Sub mobjMsgProcess_OpenLink(ByVal strMsgKey As String, ByVal strLinkPara As String)
'��ʾ�����Ӵ��¼�
On Error Resume Next
    RaiseEvent OnOpenLink(strMsgKey, strLinkPara)
    
End Sub

Private Sub mobjMsgProcess_OpenModule(ByVal lngSystem As Long, ByVal lngModule As Long, ByVal strPara As String)
'ģ����¼�
On Error Resume Next
    RaiseEvent OnOpenModule(lngSystem, lngModule)
    
End Sub

Private Sub mobjMsgProcess_ReceiveMessage(ByVal strMsgItemIdentity As String, ByVal strMsgContent As String)
'���յ�����Ϣ����
'��Ϣ�����¼�
On Error GoTo errHandle
    Dim rsData As ADODB.Recordset
    Dim strValue As String
        
    '�����Ƿ�Ӱ��ϵͳ��Ҫ���յ���Ϣ�����������ֱ���˳�
    If strMsgItemIdentity <> G_STR_MSG_ZLHIS_CIS_017 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_CIS_024 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_PACS_001 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_PACS_002 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_PACS_003 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_PACS_004 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_PACS_005 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_CHARGE_003 _
        And strMsgItemIdentity <> G_STR_MSG_ZLHIS_CIS_025 Then
        Exit Sub
    End If
        
        
    Call mobjXml.OpenXMLDocument(strMsgContent)
    


    '��ȡ��Ϣ���ͷ���ʵ������
    Call mobjXml.GetSingleNodeValue("send_instance", strValue)

    '���ʵ����ͬ���򲻽�����Ϣ����
    If mobjMsgProcess.Instance = strValue Then Exit Sub
          
          
    
    '�����нڵ�ת��ΪADO���ݼ�
    If Not mobjXml.GetAllNodeRecord(rsData) Then
        Debug.Print "����GetAllNodeRecord����ʧ�ܣ���ֹ��Ϣ������"
        Exit Sub
    End If
    
    If rsData.RecordCount <= 0 Then
        Debug.Print "δ��ȡ����Ч�Ľڵ����ݣ���ֹ��Ϣ������"
        Exit Sub
    End If
    
    '�ж϶�Ӧ��ִ�п��ҽڵ��Ƿ���ڣ�������ڣ�����Ҫ�жϵ�ǰ������ִ�п����Ƿ�һ��
    rsData.Filter = "node_name='study_execute_id'"
    If rsData.RecordCount > 0 Then
        '�ж�ִ�в���ID�뵱ǰ����ID�Ƿ���ͬ
        If nvl(rsData!node_value) <> mlngCurDeptId Then Exit Sub
    End If
    
    
    '�����¼�������Ϣ
    RaiseEvent OnRecevieMsg(strMsgItemIdentity, strMsgContent, rsData, mobjMsgProcess, mobjXml)
    
Exit Sub
errHandle:
    Debug.Print err.Description
End Sub