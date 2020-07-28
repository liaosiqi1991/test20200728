VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsWorkModule_His"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Implements IWorkMenu


Private Const M_STR_HINT_NoSelectData As String = "��Ч�ļ�����ݣ���ѡ����Ҫִ�еļ���¼��"
Private Const M_STR_MODULE_MENU_TAG As String = "HIS"
Private mblnNoRegCanPay As Boolean

'HISģ����Ϣ
Public Type TModule
    objModule As Object
    strModuleName As String
    lngModuleType As Long

    lngTmpAdviceId As Long
    lngTmpSendNo As Long
    
    blnRefreshState As Boolean
End Type


'HISģ������
Public Enum THisModule
    hmAll = -1          '����ģ��
    hmExpense = 0       '����
    hmInAdvice = 1      'סԺҽ��
    hmOutAdvices = 2    '����ҽ��
    hmInEPRs = 3        'סԺ����
    hmOutEPRs = 4        '���ﲡ��
    hmEMR = 5           '���Ӳ���
End Enum


Private mlngModule  As Long
Private mstrPrivs  As String
Private mlngCurDeptId As Long
'Private mblnIsClinicalDeptPro As Boolean '�Ƿ�߱��ٴ���������
Private mObjOwner As Object

Private mlngAdviceId As Long
Private mlngSendNo As Long
Private mblnMoved As Boolean
Private mlngStudyState As Long

Private mblnReadOnly As Boolean

'����ģ�������һЩ��Ϣ

Private mlngPatientId As Long
Private mlngUnitId As Long
Private mlngPatientDepartId As Long
Private mintState As Long
Private mstrRegNo As String
Private mblnIsHistory As Boolean
Private mlngPageID As Long
Private mblnIsInsidePatient As Boolean

Private WithEvents mobjInAdvice As zlCISKernel.clsDockInAdvices    'סԺҽ������
Attribute mobjInAdvice.VB_VarHelpID = -1
Private WithEvents mobjOutAdvice As zlCISKernel.clsDockOutAdvices  '����ҽ������
Attribute mobjOutAdvice.VB_VarHelpID = -1
Private mobjExpense As Object 'zlPublicExpense.clsDockExpense       '���ö���
Private mobjInEPRs As zlRichEPR.cDockInEPRs             'סԺ��������
Private mobjOutEPRs As zlRichEPR.cDockOutEPRs           '���ﲡ������
Private mobjEMR As Object

Private aryRegModule() As TModule                       '���浱ǰ������ģ��


Private mObjActiveMenuBar As CommandBars



'��ȡ�˵��ӿڶ���
Property Get zlMenu() As IWorkMenu
    Set zlMenu = Me
End Property



'Public Function GetExpenseObj() As Object
'    Set GetExpenseObj = mobjExpense
'End Function
Public Sub NotificationRefresh(Optional ByVal lngModule As Long = -1)
'֪ͨˢ��
    Dim i As Long
    
    For i = LBound(aryRegModule) To UBound(aryRegModule)
        If lngModule = -1 Then
            aryRegModule(i).blnRefreshState = False
        Else
            If aryRegModule(i).lngModuleType = lngModule Then
                aryRegModule(i).blnRefreshState = False
                Exit For
            End If
        End If
    Next i
End Sub

Private Sub Class_Initialize()
    '����ʹ��uboundʱ���������Ĭ�ϳ�ʼ��һ��������Ԫ��
    ReDim Preserve aryRegModule(1)
    
    aryRegModule(0) = GetNullModule
End Sub


Public Sub Free()
On Error GoTo errhandle
    Dim i As Long
    
    If SafeArrayGetDim(aryRegModule) <> 0 Then
        For i = LBound(aryRegModule) To UBound(aryRegModule)
            If Not aryRegModule(i).objModule Is Nothing Then
                Unload aryRegModule(i).objModule.zlGetForm
                Set aryRegModule(i).objModule = Nothing
            End If
        Next i
    End If
    
    Set mobjExpense = Nothing
    Set mobjInAdvice = Nothing
    Set mobjOutAdvice = Nothing
    Set mobjInEPRs = Nothing
    Set mobjOutEPRs = Nothing
    Set mobjEMR = Nothing
    
    aryRegModule = Null
    
errhandle:
End Sub


Private Function GetNullModule() As TModule
    Set GetNullModule.objModule = Nothing
    
    GetNullModule.strModuleName = ""
    GetNullModule.blnRefreshState = True
    GetNullModule.lngModuleType = hmAll
End Function


Public Function GetExpenseObj() As Object
     If Not mobjExpense Is Nothing Then Set GetExpenseObj = mobjExpense
End Function

Public Function GetAdviceObj() As Object

    If Not mobjInAdvice Is Nothing Or Not mobjOutAdvice Is Nothing Then
    
        If Not mobjInAdvice Is Nothing Then
            Set GetAdviceObj = IIf(mobjInAdvice.zlGetForm.Visible = True, mobjInAdvice, mobjOutAdvice)
        Else
            Set GetAdviceObj = IIf(mobjOutAdvice.zlGetForm.Visible = True, mobjOutAdvice, mobjInAdvice)
        End If
        
    Else
        Set GetAdviceObj = Nothing
    End If

End Function

Public Function GetEMRsObj() As Object
    Set GetEMRsObj = mobjEMR
End Function

Public Function GetEPRsObj() As Object

    If Not mobjInEPRs Is Nothing Or Not mobjOutEPRs Is Nothing Then
        
        If Not mobjInEPRs Is Nothing Then
            Set GetEPRsObj = IIf(mobjInEPRs.zlGetForm.Visible = True, mobjInEPRs, mobjOutEPRs)
        Else
            Set GetEPRsObj = IIf(mobjOutEPRs.zlGetForm.Visible = True, mobjOutEPRs, mobjInEPRs)
        End If
        
    Else
        Set GetEPRsObj = Nothing
    End If
    
End Function

Public Function GetModule(ByVal lngModule As Long, Optional ByVal blnAutoCreate As Boolean = True) As Object
'��ȡָ��ģ�����
    Dim objTmp As zlPublicExpense.clsPublicExpense
    Set GetModule = Nothing
    
    Select Case lngModule
        Case hmExpense  '����
            If mobjExpense Is Nothing And blnAutoCreate Then
                If mlngModule = G_LNG_PATHOLSYS_NUM Then
                    Set mobjExpense = New frmPatholPrice
                    
                    zlControl.FormSetCaption mobjExpense, False, False
                Else
                    Set objTmp = New zlPublicExpense.clsPublicExpense
                    Call objTmp.zlInitCommon(glngSys, gcnOracle, gstrDBUser)
                    Set mobjExpense = objTmp.zlDockExpense
                End If
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjExpense
                
                aryRegModule(UBound(aryRegModule)).strModuleName = "�������"
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmExpense
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If
            
            Set GetModule = mobjExpense.zlGetForm()
            
        Case hmInAdvice 'סԺҽ��
            If mobjInAdvice Is Nothing And blnAutoCreate Then
                Set mobjInAdvice = New zlCISKernel.clsDockInAdvices
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjInAdvice
                
                aryRegModule(UBound(aryRegModule)).strModuleName = "סԺҽ��"
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmInAdvice
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If
            
            Set GetModule = mobjInAdvice.zlGetForm()
               
        Case hmOutAdvices '����ҽ��
            If mobjOutAdvice Is Nothing And blnAutoCreate Then
                Set mobjOutAdvice = New zlCISKernel.clsDockOutAdvices
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjOutAdvice
                
                aryRegModule(UBound(aryRegModule)).strModuleName = "����ҽ��"
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmOutAdvices
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If
            
            Set GetModule = mobjOutAdvice.zlGetForm()
            
        Case hmInEPRs 'סԺ����
            If mobjInEPRs Is Nothing And blnAutoCreate Then
                Set mobjInEPRs = New zlRichEPR.cDockInEPRs
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjInEPRs
                
                aryRegModule(UBound(aryRegModule)).strModuleName = "סԺ����"
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmInEPRs
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If
            
            Set GetModule = mobjInEPRs.zlGetForm()
            
        Case hmOutEPRs '���ﲡ��
            If mobjOutEPRs Is Nothing And blnAutoCreate Then
                Set mobjOutEPRs = New zlRichEPR.cDockOutEPRs
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjOutEPRs
                
                aryRegModule(UBound(aryRegModule)).strModuleName = "���ﲡ��"
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmOutAdvices
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If
            
            Set GetModule = mobjOutEPRs.zlGetForm()
        
        Case hmEMR '���Ӳ���
            If mobjEMR Is Nothing And blnAutoCreate Then
                Call InitEMR
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjEMR
                
                aryRegModule(UBound(aryRegModule)).strModuleName = "���Ӳ���"
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmEMR
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If
            
            Set GetModule = mobjEMR.zlGetForm()
    End Select
End Function

Private Sub InitEMR()
    Set mobjEMR = DynamicCreate("zlRichEMR.clsDockEMR", "���Ӳ���")
    If Not mobjEMR Is Nothing Then
        If Not mobjEMR.Init(gobjEmr, gcnOracle, glngSys) Then
          Set mobjEMR = Nothing
        End If
    End If
End Sub

Public Function GetActiveModule() As TModule
'��ȡ��ǰ��ʾ�ù���ģ��
    Dim i As Long
    Dim objCurModule As Object
    
    GetActiveModule = GetNullModule
    
    For i = LBound(aryRegModule) To UBound(aryRegModule)
        If Not aryRegModule(i).objModule Is Nothing Then
            Set objCurModule = aryRegModule(i).objModule.zlGetForm()
            
            If objCurModule.Visible Then
                GetActiveModule = aryRegModule(i)
                Exit For
            End If
        End If
    Next i
End Function

Private Sub Class_Terminate()
    Set mObjOwner = Nothing
    Set mobjExpense = Nothing
    Set mobjInEPRs = Nothing
    Set mobjOutEPRs = Nothing
    Set mobjEMR = Nothing
    Set mObjActiveMenuBar = Nothing
    Set mobjInAdvice = Nothing
    Set mobjOutAdvice = Nothing
End Sub

'�ӿ�ʵ�ֲ���*********************************************************************************

Public Function IWorkMenu_zlIsModuleMenu(ByVal objControlMenu As XtremeCommandBars.ICommandBarControl) As Boolean
'�жϲ˵��Ƿ����ڸ�ģ��˵�
'ҽ�������ã�����ģ�鴴���Ĳ˵�����ӦΪ��ҽ�����������á�����������
    
    IWorkMenu_zlIsModuleMenu = IIf(objControlMenu.Category = M_STR_MODULE_MENU_TAG Or objControlMenu.Category = "���ж�", True, False)
End Function


Public Sub IWorkMenu_zlCreateMenu(objMenuBar As Object)
'����Ӱ���¼��Ӧ�Ĳ˵�
    Dim objHisModule As TModule
    Dim objNewMenu As CommandBarControl

    Set mObjActiveMenuBar = objMenuBar
    
    
    Set objNewMenu = objMenuBar.FindControl(, conMenu_EditPopup)
    
    '����˵����ڣ�����ɾ����Ӧ�Ĳ˵��͹�������ť���´���
    Call DelModuleMenuAndToolBar(objMenuBar, objNewMenu, M_STR_MODULE_MENU_TAG)
        
    objHisModule = GetActiveModule()
    
    If Not objHisModule.objModule Is Nothing Then
        Select Case objHisModule.strModuleName
            Case "סԺҽ��", "����ҽ��"
                Call objHisModule.objModule.zlDefCommandBars(mObjOwner, mObjActiveMenuBar, 2)
                
                Set objNewMenu = GetNewMenu(objMenuBar, "ҽ��")
                
            Case "�������"
                Call objHisModule.objModule.zlDefCommandBars(mObjOwner, mObjActiveMenuBar)
                
                Set objNewMenu = GetNewMenu(objMenuBar, "����")
                
            Case "סԺ����", "���ﲡ��", "���Ӳ���"
                Call objHisModule.objModule.zlDefCommandBars(mObjActiveMenuBar)
                
                Set objNewMenu = GetNewMenu(objMenuBar, "����")
                
        End Select
        
        Call ConfigMenuCategory(objMenuBar.ActiveMenuBar, M_STR_MODULE_MENU_TAG)
        Call ConfigMenuCategory(objMenuBar.Item(2), M_STR_MODULE_MENU_TAG)
        
        '���ⴴ��ģ�鹤����ʱ���������Ͻǳ��ֲ���ȫ��ʾ��ͼ�꣬һ������������
        Call objMenuBar.RecalcLayout
    End If
End Sub

Private Function GetSubCommandBar(objControl As Object) As Object
On Error GoTo errhandle
    Set GetSubCommandBar = objControl.CommandBar
Exit Function
errhandle:
    Set GetSubCommandBar = Nothing
End Function


Private Sub ConfigMenuCategory(objCommandBar As Object, ByVal strCategory As String)
'����Category����
    Dim objSubMenu As CommandBar
    
    Dim i As Long
    Dim j As Long
    
    If objCommandBar Is Nothing Then Exit Sub

    
    For i = 1 To objCommandBar.Controls.Count
        If objCommandBar.Controls(i).Category = "" Then objCommandBar.Controls(i).Category = strCategory
        
        Set objSubMenu = GetSubCommandBar(objCommandBar.Controls(i))
        If Not objSubMenu Is Nothing Then Call ConfigMenuCategory(objSubMenu, strCategory)
    Next i
End Sub


Private Sub DelModuleMenuAndToolBar(objMenuBar As Object, objModuleMenu As CommandBarControl, ByVal strMenuName As String)
'ɾ��ģ��˵��͹�����
    Dim objToolBar As CommandBar
    Dim objActiveMenu As CommandBar
    Dim objSubMenu As CommandBar
    
    Dim i As Long
    Dim j As Long
    
    If Not objModuleMenu Is Nothing Then
        Call objModuleMenu.Delete
    End If
    
    'ɾ���������˵��´�����ģ��˵�
    Set objActiveMenu = objMenuBar.ActiveMenuBar
    For i = objActiveMenu.Controls.Count To 1 Step -1
        If objActiveMenu.Controls(i).type <> xtpControlButton Then
            Set objSubMenu = objActiveMenu.Controls(i).CommandBar
            
            For j = objSubMenu.Controls.Count To 1 Step -1
                If objSubMenu.Controls(j).Category = strMenuName Or objSubMenu.Controls(j).Category = "���ж�" Then
                    Call objSubMenu.Controls(j).Delete
                End If
            Next j
            
            If objActiveMenu.Controls(i).Category = strMenuName Or objActiveMenu.Controls(i).Category = "���ж�" Then
                Call objActiveMenu.Controls(i).Delete
            End If
        End If
    Next i
    
    'ɾ���������е�ģ���Ӧ��ť
    Set objToolBar = objMenuBar.Item(2)
    If Not objToolBar Is Nothing Then
        For i = objToolBar.Controls.Count To 1 Step -1
            If objToolBar.Controls(i).Category = strMenuName Or objToolBar.Controls(i).Category = "���ж�" Then
                Call objToolBar.Controls(i).Delete
            Else
                If objToolBar.Controls(i).Category = "" Then
                    objToolBar.Controls(i).Category = "TEMP"
                End If
            End If
        Next i
    End If
End Sub


Private Function GetNewMenu(objMenuBar As Object, ByVal strMenuName As String) As CommandBarControl
'��ȡ�´����Ĳ˵�
    Dim i As Long
    Dim objActiveMenu As CommandBar
    
    Set objActiveMenu = objMenuBar.ActiveMenuBar
    
    For i = 1 To objActiveMenu.Controls.Count
        If InStr(objActiveMenu.Controls(i).Caption, strMenuName) > 0 Then
            Set GetNewMenu = objActiveMenu.Controls(i)
            Exit Function
        End If
    Next i
    
    Set GetNewMenu = Nothing
End Function


Public Sub IWorkMenu_zlCreateToolBar(objToolBar As Object)
'����������
    Exit Sub
End Sub


Public Sub IWorkMenu_zlClearMenu()
'����������Ĳ˵�
    Exit Sub
End Sub


Public Sub IWorkMenu_zlClearToolBar()
'��������Ĺ�����
    Exit Sub
End Sub

Public Sub IWorkMenu_zlExecuteMenu(ByVal lngMenuId As Long)
'���ݲ˵�IDִ�ж�Ӧ����
    Dim objCbrControl As XtremeCommandBars.CommandBarControl
    Dim objHisModule As TModule
    
    objHisModule = GetActiveModule()
    
    If Not objHisModule.objModule Is Nothing Then
        Set objCbrControl = mObjActiveMenuBar.FindControl(, lngMenuId, , True)
            
        If Not objCbrControl Is Nothing Then Call objHisModule.objModule.zlExecuteCommandBars(objCbrControl)
    End If
    
End Sub


Public Sub IWorkMenu_zlUpdateMenu(ByVal Control As XtremeCommandBars.ICommandBarControl)
'���²˵�
    Dim objHisModule As TModule
    
    objHisModule = GetActiveModule()
    
    If Not objHisModule.objModule Is Nothing Then
        Call objHisModule.objModule.zlUpdateCommandBars(Control)
        If Control.ID = conMenu_Edit_NewItem Then
            If Control.Caption = "������" Then
                Control.Enabled = Control.Enabled And (mintState >= 2 Or mblnNoRegCanPay)
            End If
        End If
    End If
End Sub


Public Sub IWorkMenu_zlPopupMenu(objPopup As XtremeCommandBars.ICommandBar)
'�����Ҽ��˵�
    Exit Sub
End Sub

Public Sub IWorkMenu_zlRefreshSubMenu(objCommandBar As Object)
'ˢ�µ������Ӳ˵�
    Dim objHisModule As TModule
    
    objHisModule = GetActiveModule()
    
    If Not objHisModule.objModule Is Nothing Then
        Call objHisModule.objModule.zlPopupCommandBars(objCommandBar)
    End If
    
    Call ConfigMenuCategory(objCommandBar, M_STR_MODULE_MENU_TAG)
    Call ConfigMenuCategory(mObjActiveMenuBar.Item(2), M_STR_MODULE_MENU_TAG)
End Sub
'*********************************************************************************************

Public Sub zlInitModule(ByVal lngModule As Long, ByVal strPrivs As String, ByVal lngDepartId As Long, Optional Owner As Object = Nothing)
'��ʼ��ģ�����
    mlngModule = lngModule
    mstrPrivs = strPrivs
    mlngCurDeptId = lngDepartId
    
    '�ж�ִ�п����Ƿ�߱��ٴ�����
    'mblnIsClinicalDeptPro = HasClinicalPro(lngDepartId)
    mblnNoRegCanPay = GetDeptPara(lngDepartId, "����δ��������", 0) = "1" '       '�ޱ���򱨸�δǩ���������
    
    If Not Owner Is Nothing Then Set mObjOwner = Owner
    
    If Not mobjExpense Is Nothing And mlngModule = G_LNG_PATHOLSYS_NUM Then
        Call mobjExpense.zlInitModule(lngModule, strPrivs, lngDepartId, Owner)
    End If
'    Call gobjKernel.InitCISKernel(gcnOracle, gfrmMain, glngSys, strPrivs) '��ʼ��ҽ�����������Ĳ���
'    Call gobjRichEPR.InitRichEPR(gcnOracle, gfrmMain, glngSys, False)
End Sub


Private Function HasClinicalPro(ByVal lngDepartmentId As Long) As Long
'�жϵ�ǰ�����Ƿ�߱��ٴ�����
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset

    HasClinicalPro = False
    
    strSQL = "select ����ID from ��������˵�� where ����ID=[1] and ��������='�ٴ�'"
    
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "�жϲ�������", lngDepartmentId)
    
    If rsData.RecordCount > 0 Then
        '���߱��ٴ����ʣ����ѯҽ��Ĭ�����ڿ���ID
        HasClinicalPro = True
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Sub zlUpdateAdviceInf(ByVal lngAdviceId As Long, ByVal lngSendNo As Long, _
    ByVal lngStudyState As Long, ByVal blnMoved As Boolean)
'����ҽ����Ϣ
    mlngAdviceId = lngAdviceId
    mlngSendNo = lngSendNo
    mblnMoved = blnMoved
    mlngStudyState = lngStudyState
    mblnReadOnly = False
    

    '���Ϊ��ɣ��Ǽǣ��ܾ�����ˣ����ܶԼ����д���
    If lngStudyState = 6 Or lngStudyState = 5 Or lngStudyState = 0 Or lngStudyState = 1 Or lngStudyState = -2 Then
        mblnReadOnly = True
    End If
End Sub

Public Sub zlUpdateOtherInf(ByVal lngPatientID As Long, ByVal lngUnitId As Long, ByVal lngPatientDepartId As Long, _
    ByVal lngPageID As Long, ByVal intState As Long, ByVal strRegNo As String, ByVal blnIsHistory As Boolean, ByVal blnIsInsidePatient As Boolean)
'����ҽ����ص�������Ϣ
    mlngPatientId = lngPatientID
    mlngUnitId = lngUnitId
    mlngPatientDepartId = lngPatientDepartId
    mintState = intState
    mstrRegNo = strRegNo
    mblnIsHistory = blnIsHistory
    mlngPageID = lngPageID
    mblnIsInsidePatient = blnIsInsidePatient
End Sub


Public Sub zlRefreshFace(Optional blnForceRefresh As Boolean = False, Optional ByVal lngPatientFrom As Long = 3)
'ˢ�½���
    Dim rsTemp As ADODB.Recordset
    Dim iRows As Integer
    Dim iCols As Integer
    Dim strStudyUID As String
    Dim objHisModule As TModule
    Dim strSQL As String
    Dim lngBillID As Long
    
    On Error GoTo errhandle
    
    objHisModule = GetActiveModule
    
    If objHisModule.objModule Is Nothing Then Exit Sub
    
    '��ҽ���ı�ʱ�����һ�μ��ؽ���ʱ����ǿ��ˢ��ʱ�Ž��н�������ˢ�²���
    If (objHisModule.lngTmpAdviceId = mlngAdviceId And objHisModule.lngTmpSendNo = mlngSendNo _
        And objHisModule.blnRefreshState) And Not blnForceRefresh Then Exit Sub
    
    objHisModule.lngTmpAdviceId = mlngAdviceId
    objHisModule.lngTmpSendNo = mlngSendNo
    
    objHisModule.blnRefreshState = True
    
    Select Case objHisModule.strModuleName
        Case "�������"
            If mlngModule = G_LNG_PATHOLSYS_NUM Then
                objHisModule.objModule.zlRefresh mlngCurDeptId, mlngAdviceId, mlngSendNo, mblnMoved
            Else
                objHisModule.objModule.zlRefresh mlngCurDeptId, mlngAdviceId & ":" & mlngSendNo & ":0", mblnMoved
            End If
        Case "סԺҽ��"
            objHisModule.objModule.zlRefresh mlngPatientId, mlngPageID, mlngUnitId, mlngPatientDepartId, 0, mblnMoved, mlngAdviceId, mintState, mlngCurDeptId
            
        Case "����ҽ��"
            If mstrRegNo = "" Then   '���еǼǵĲ���û�йҺŵ���
                objHisModule.objModule.zlRefresh mlngPatientId, "", False, , , mlngCurDeptId
            Else
                objHisModule.objModule.zlRefresh mlngPatientId, mstrRegNo, Not mblnIsHistory And mblnIsInsidePatient, mblnMoved, mlngAdviceId, mlngCurDeptId
            End If
            
        Case "סԺ����"
            objHisModule.objModule.zlRefresh mlngPatientId, mlngPageID, mlngCurDeptId, Not mblnIsHistory, mblnMoved, 0, True
            
        Case "���ﲡ��"
            strSQL = "Select Id From ���˹Һż�¼ Where No = [1]"
            
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ѯ�Һ�ID", mstrRegNo)
            If rsTemp.EOF = False Then
                lngBillID = nvl(rsTemp!ID)
            End If
            
            objHisModule.objModule.zlRefresh mlngPatientId, lngBillID, mlngCurDeptId, Not mblnIsHistory, mblnMoved, 0, True
        
        Case "���Ӳ���"
            If lngPatientFrom = 1 Then
                strSQL = "Select Id From ���˹Һż�¼ Where No = [1]"
            
                Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ѯ�Һ�ID", mstrRegNo)
                If rsTemp.EOF = False Then
                    lngBillID = nvl(rsTemp!ID)
                End If
            End If
            objHisModule.objModule.zlRefresh mlngPatientId, IIf(lngPatientFrom = 2, mlngPageID, lngBillID), mlngCurDeptId, IIf(lngPatientFrom = 2, 0, 2), IIf(lngPatientFrom = 2, 2, 1)
    End Select
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub mobjInAdvice_ViewEPRReport(ByVal ����ID As Long, ByVal CanPrint As Boolean)
    Call SendMsgToMainWindow(Me, wetViewEprReport, mlngAdviceId, ����ID & "," & IIf(CanPrint, 1, 0))
End Sub

Private Sub mobjInAdvice_ViewPACSImage(ByVal ҽ��ID As Long)
    Call SendMsgToMainWindow(Me, wetViewPacsImage, ҽ��ID)
End Sub

Private Sub mobjOutAdvice_ViewEPRReport(ByVal ����ID As Long, ByVal CanPrint As Boolean)
    Call SendMsgToMainWindow(Me, wetViewEprReport, mlngAdviceId, ����ID & "," & IIf(CanPrint, 1, 0))
End Sub

Private Sub mobjOutAdvice_ViewPACSImage(ByVal ҽ��ID As Long)
    Call SendMsgToMainWindow(Me, wetViewPacsImage, ҽ��ID)
End Sub


