VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsWorkModule_HisV2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Implements IWorkMenuV2
Implements IWorkModule

Private Const M_STR_HINT_NoSelectData As String = "��Ч�ļ�����ݣ���ѡ����Ҫִ�еļ���¼��"
Private Const M_STR_MODULE_MENU_TAG As String = "HIS"

'HISģ����Ϣ
Private Type THisModuleInfo
    objModule As Object
    strModuleName As String
    lngModuleType As Long

    lngTmpAdviceId As Long
    lngTmpSendNo As Long
    
    blnRefreshState As Boolean
End Type


''HISģ������
'Public Enum THisModuleType
'    hmtAll = -1          '����ģ��
'    hmtExpense = 0       '����
'    hmtInAdvice = 1      'סԺҽ��
'    hmtOutAdvices = 2    '����ҽ��
'    hmtInEPRs = 3        'סԺ����
'    hmtOutEPRs = 4        '���ﲡ��
'    hmtEMR = 5           '���Ӳ���
'End Enum

Private mblnNoRegCanPay As Boolean
Private mlngModule  As Long
Private mstrPrivs  As String
Private mlngCurDeptId As Long
'Private mblnIsClinicalDeptPro As Boolean '�Ƿ�߱��ٴ���������
Private mObjNotify As IEventNotify

Private mobjStudyInfo As clsStudyInfo

Private WithEvents mobjInAdvice As zlCISKernel.clsDockInAdvices      'סԺҽ������
Attribute mobjInAdvice.VB_VarHelpID = -1
Private WithEvents mobjOutAdvice As zlCISKernel.clsDockOutAdvices  '����ҽ������
Attribute mobjOutAdvice.VB_VarHelpID = -1
Private mobjExpense As Object 'zlPublicExpense.clsDockExpense       '���ö���
Private mobjInEPRs As zlRichEPR.cDockInEPRs             'סԺ��������
Private mobjOutEPRs As zlRichEPR.cDockOutEPRs           '���ﲡ������
Private mobjEMR As Object

Private aryRegModule() As THisModuleInfo                       '���浱ǰ������ģ��


Private mObjActiveMenuBar As CommandBars
Private mblnIsHistoryMode As Boolean



'��ȡ�˵��ӿڶ���
Property Get zlMenu() As IWorkMenuV2
    Set zlMenu = Me
End Property


'��ȡģ��ӿڶ���
Property Get zlModule() As IWorkModule
    Set zlModule = Me
End Property


Private Sub Class_Initialize()
    '����ʹ��uboundʱ���������Ĭ�ϳ�ʼ��һ��������Ԫ��
    ReDim Preserve aryRegModule(0)
    
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


Private Function GetNullModule() As THisModuleInfo
    Set GetNullModule.objModule = Nothing
    
    GetNullModule.strModuleName = ""
    GetNullModule.blnRefreshState = True
    GetNullModule.lngModuleType = hmAll
End Function

Private Sub InitEMR()
    Set mobjEMR = DynamicCreate("zlRichEMR.clsDockEMR", "���Ӳ���")
    If Not mobjEMR Is Nothing Then
        If Not mobjEMR.Init(gobjEmr, gcnOracle, glngSys) Then
          Set mobjEMR = Nothing
        End If
    End If
End Sub
 

Private Sub Class_Terminate()
    Set mObjNotify = Nothing
    Set mobjExpense = Nothing
    Set mobjInEPRs = Nothing
    Set mobjOutEPRs = Nothing
    Set mobjEMR = Nothing
    Set mObjActiveMenuBar = Nothing
    Set mobjInAdvice = Nothing
    Set mobjOutAdvice = Nothing
    Set mobjStudyInfo = Nothing
End Sub

'�ӿ�ʵ�ֲ���*********************************************************************************

Public Function IWorkMenuV2_zlBaseMenuID() As Long

End Function

Public Function IWorkMenuV2_zlExecuteCmd(ByVal lngCmdType As Long)
'ִ�в˵�����

End Function

Public Function IWorkMenuV2_zlIsModuleMenu(ByVal strModuleName As String, objControlMenu As XtremeCommandBars.ICommandBarControl) As Boolean
'�жϲ˵��Ƿ����ڸ�ģ��˵�
'ҽ�������ã�����ģ�鴴���Ĳ˵�����ӦΪ��ҽ�����������á�����������
    IWorkMenuV2_zlIsModuleMenu = IIf(objControlMenu.Category = M_STR_MODULE_MENU_TAG Or objControlMenu.Category = "���ж�", True, False)
End Function


Public Sub IWorkMenuV2_zlCreateMenu(ByVal strModuleName As String, objMenuBar As Object)
'����Ӱ���¼��Ӧ�Ĳ˵�
    Dim objNewMenu As CommandBarControl
    Dim objHisModule As THisModuleInfo
    Dim lngMenuId As Long

    Set mObjActiveMenuBar = objMenuBar

    Set objNewMenu = objMenuBar.FindControl(, conMenu_EditPopup)

    '����˵����ڣ�����ɾ����Ӧ�Ĳ˵��͹�������ť���´���
    Call DelModuleMenuAndToolBar(objMenuBar, objNewMenu, M_STR_MODULE_MENU_TAG)

    objHisModule = GetModuleInfo(strModuleName) 'mobjStudyInfo
    
    If objHisModule.objModule Is Nothing Then Exit Sub
    
    Select Case objHisModule.strModuleName
        Case C_WORKMODULE_NAME_סԺҽ��, C_WORKMODULE_NAME_����ҽ��
            Call objHisModule.objModule.zlDefCommandBars(mObjNotify.Owner, mObjActiveMenuBar, 2)

        Case C_WORKMODULE_NAME_���ü�¼
            Call objHisModule.objModule.zlDefCommandBars(mObjNotify.Owner, mObjActiveMenuBar)
             

        Case C_WORKMODULE_NAME_סԺ����, C_WORKMODULE_NAME_���ﲡ��, C_WORKMODULE_NAME_���Ӳ���
            Call objHisModule.objModule.zlDefCommandBars(mObjActiveMenuBar)
                
    End Select

    Call ConfigMenuCategory(objMenuBar.ActiveMenuBar, M_STR_MODULE_MENU_TAG)
    Call ConfigMenuCategory(objMenuBar.Item(2), M_STR_MODULE_MENU_TAG)

    '���ⴴ��ģ�鹤����ʱ���������Ͻǳ��ֲ���ȫ��ʾ��ͼ�꣬һ������������
'    Call objMenuBar.RecalcLayout
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


Public Sub IWorkMenuV2_zlCreateToolBar(ByVal strModuleName As String, objToolBar As Object)
'����������
    Exit Sub
End Sub


Public Sub IWorkMenuV2_zlClearMenu(ByVal strModuleName As String)
'����������Ĳ˵�
    Dim objNewMenu As CommandBarControl
    
    If mObjActiveMenuBar Is Nothing Then Exit Sub
    
    Set objNewMenu = mObjActiveMenuBar.FindControl(, conMenu_EditPopup)

    '����˵����ڣ�����ɾ����Ӧ�Ĳ˵��͹�������ť���´���
    Call DelModuleMenuAndToolBar(mObjActiveMenuBar, objNewMenu, M_STR_MODULE_MENU_TAG)
End Sub


Public Sub IWorkMenuV2_zlClearToolBar(ByVal strModuleName As String)
'��������Ĺ�����
    Exit Sub
End Sub

Public Sub IWorkMenuV2_zlExecuteMenu(ByVal strModuleName As String, ByVal lngMenuId As Long)
'���ݲ˵�IDִ�ж�Ӧ����
    Dim objCbrControl As XtremeCommandBars.CommandBarControl
    Dim objHisModule As THisModuleInfo
 

    objHisModule = GetModuleInfo(strModuleName) ', mobjStudyInfo
    If objHisModule.objModule Is Nothing Then Exit Sub
    
    
    Set objCbrControl = mObjActiveMenuBar.FindControl(, lngMenuId, , True)
    If objCbrControl Is Nothing Then Exit Sub
    
    
    Select Case objHisModule.strModuleName
        Case C_WORKMODULE_NAME_סԺҽ��, C_WORKMODULE_NAME_����ҽ��
            Call objHisModule.objModule.zlExecuteCommandBars(objCbrControl)

        Case C_WORKMODULE_NAME_���ü�¼
            Call objHisModule.objModule.zlExecuteCommandBars(objCbrControl)

        Case C_WORKMODULE_NAME_סԺ����, C_WORKMODULE_NAME_���ﲡ��, C_WORKMODULE_NAME_���Ӳ���
            Call objHisModule.objModule.zlExecuteCommandBars(objCbrControl)
                
    End Select
End Sub


Public Sub IWorkMenuV2_zlUpdateMenu(ByVal strModuleName As String, Control As XtremeCommandBars.ICommandBarControl)
'���²˵�
    Dim objCbrControl As XtremeCommandBars.CommandBarControl
    Dim objHisModule As THisModuleInfo
    Dim lngMenuId As Long
 
    If Control Is Nothing Then Exit Sub
    
    Control.Enabled = True
    
    If mobjStudyInfo Is Nothing Then
        Control.Enabled = False
        Exit Sub
    End If
    
    objHisModule = GetModuleInfo(strModuleName) ', mobjStudyInfo
    If objHisModule.objModule Is Nothing Then Exit Sub
    
    
    Select Case objHisModule.strModuleName
        Case C_WORKMODULE_NAME_סԺҽ��, C_WORKMODULE_NAME_����ҽ��
            Call objHisModule.objModule.zlUpdateCommandBars(Control)

        Case C_WORKMODULE_NAME_���ü�¼
            Call objHisModule.objModule.zlUpdateCommandBars(Control)
                If Control.ID = conMenu_Edit_NewItem Then
                    If InStr(Control.Caption, "������") > 0 Or InStr(Control.Caption, "���丽�ӷ���") > 0 Then
                        Control.Enabled = Control.Enabled And (mobjStudyInfo.intStep >= 2 Or mblnNoRegCanPay) And Not mblnIsHistoryMode
                    End If
                End If
             
        Case C_WORKMODULE_NAME_סԺ����, C_WORKMODULE_NAME_���ﲡ��, C_WORKMODULE_NAME_���Ӳ���
            Call objHisModule.objModule.zlUpdateCommandBars(Control)
                
    End Select
    
End Sub


Public Sub IWorkMenuV2_zlPopupMenu(ByVal strModuleName As String, objPopup As XtremeCommandBars.ICommandBar)
'�����Ҽ��˵�
    Exit Sub
End Sub

Public Sub IWorkMenuV2_zlRefreshSubMenu(ByVal strModuleName As String, objCommandBar As Object)
'ˢ�µ������Ӳ˵�
    Dim objHisModule As THisModuleInfo

    objHisModule = GetModuleInfo(strModuleName)
    If objHisModule.objModule Is Nothing Then Exit Sub
 
    Call objHisModule.objModule.zlPopupCommandBars(objCommandBar)

    Call ConfigMenuCategory(objCommandBar, M_STR_MODULE_MENU_TAG)
    Call ConfigMenuCategory(mObjActiveMenuBar.Item(2), M_STR_MODULE_MENU_TAG)
End Sub
'*********************************************************************************************


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


Private Function GetModuleInfo(ByVal strModuleName As String) As THisModuleInfo
    Dim i As Long
    Dim strInsideModule As String
    
'    strInsideModule = ConvertInsideModule(strModuleName, objStudyInfo)
    
    GetModuleInfo = GetNullModule
    For i = 1 To UBound(aryRegModule)
        If aryRegModule(i).strModuleName = strModuleName Then
            GetModuleInfo = aryRegModule(i)
            Exit Function
        End If
    Next
End Function


Public Function GetInsideHisModule(ByVal strModuleName As String, ByVal lngPatientFrom As Long) As String
'��ȡHISģ������
'lngPatientFrom��������Դ 2-סԺ�������ʾ����
    Select Case strModuleName
        Case C_TAB_NAME_ҽ����¼
            If lngPatientFrom <> 2 Then
                GetInsideHisModule = "����ҽ��"
            Else
                GetInsideHisModule = "סԺҽ��"
            End If
            
        Case C_TAB_NAME_������¼
            If lngPatientFrom <> 2 Then
                GetInsideHisModule = "���ﲡ��"
            Else
                GetInsideHisModule = "סԺ����"
            End If
            
        Case C_TAB_NAME_���Ӳ���
            GetInsideHisModule = "���Ӳ���"
            
        Case C_TAB_NAME_���ü�¼
            GetInsideHisModule = "���ü�¼"
    End Select
End Function

Property Get IWorkModule_AdviceId() As Long
    IWorkModule_AdviceId = mobjStudyInfo.lngAdviceId
End Property


Public Sub IWorkModule_zlInitModule(objNotify As IEventNotify, ByVal lngModule As Long, ByVal strPrivs As String, ByVal lngDeptId As String)
'��ʼ��ģ�����
    mlngModule = lngModule
    mstrPrivs = strPrivs
    mlngCurDeptId = lngDeptId
    mblnIsHistoryMode = False
    
    '�ж�ִ�п����Ƿ�߱��ٴ�����
    'mblnIsClinicalDeptPro = HasClinicalPro(lngDepartId)
    mblnNoRegCanPay = GetDeptPara(lngDeptId, "����δ��������", 0) = "1" '       '�ޱ���򱨸�δǩ���������
    
    Set mObjNotify = objNotify
    
    If Not mobjExpense Is Nothing And mlngModule = G_LNG_PATHOLSYS_NUM Then
        Call mobjExpense.zlInitModule(lngModule, strPrivs, lngDeptId, mObjNotify.Owner)
    End If
'    Call gobjKernel.InitCISKernel(gcnOracle, gfrmMain, glngSys, strPrivs) '��ʼ��ҽ�����������Ĳ���
'    Call gobjRichEPR.InitRichEPR(gcnOracle, gfrmMain, glngSys, False)
End Sub


Public Function IWorkModule_zlGetModule(ByVal strSelModuleName As String, Optional ByVal blnAutoCreate As Boolean = True) As Object
'��ȡָ��ģ�����
    Dim objTmp As zlPublicExpense.clsPublicExpense
    Dim strInsideModule As String
 
    
    Set IWorkModule_zlGetModule = Nothing

'    strInsideModule = ConvertInsideModule(strSelModuleName, objStudyInfo)
    
    Select Case strSelModuleName
        Case C_WORKMODULE_NAME_���ü�¼  '����
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

                aryRegModule(UBound(aryRegModule)).strModuleName = C_WORKMODULE_NAME_���ü�¼
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmExpense
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If

            Set IWorkModule_zlGetModule = mobjExpense.zlGetForm()

        Case C_WORKMODULE_NAME_סԺҽ�� 'סԺҽ��
            If mobjInAdvice Is Nothing And blnAutoCreate Then
                Set mobjInAdvice = New zlCISKernel.clsDockInAdvices

                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjInAdvice

                aryRegModule(UBound(aryRegModule)).strModuleName = C_WORKMODULE_NAME_סԺҽ��
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmInAdvice
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If

            Set IWorkModule_zlGetModule = mobjInAdvice.zlGetForm()

        Case C_WORKMODULE_NAME_����ҽ��  '����ҽ��
            If mobjOutAdvice Is Nothing And blnAutoCreate Then
                Set mobjOutAdvice = New zlCISKernel.clsDockOutAdvices

                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjOutAdvice

                aryRegModule(UBound(aryRegModule)).strModuleName = C_WORKMODULE_NAME_����ҽ��
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmOutAdvices
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If

            Set IWorkModule_zlGetModule = mobjOutAdvice.zlGetForm()

        Case C_WORKMODULE_NAME_סԺ���� 'סԺ����
            If mobjInEPRs Is Nothing And blnAutoCreate Then
                Set mobjInEPRs = New zlRichEPR.cDockInEPRs

                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjInEPRs

                aryRegModule(UBound(aryRegModule)).strModuleName = C_WORKMODULE_NAME_סԺ����
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmInEPRs
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If

            Set IWorkModule_zlGetModule = mobjInEPRs.zlGetForm()

        Case C_WORKMODULE_NAME_���ﲡ�� '���ﲡ��
            If mobjOutEPRs Is Nothing And blnAutoCreate Then
                Set mobjOutEPRs = New zlRichEPR.cDockOutEPRs

                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjOutEPRs

                aryRegModule(UBound(aryRegModule)).strModuleName = C_WORKMODULE_NAME_���ﲡ��
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmOutAdvices
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If

            Set IWorkModule_zlGetModule = mobjOutEPRs.zlGetForm()

        Case C_WORKMODULE_NAME_���Ӳ��� '���Ӳ���
            If mobjEMR Is Nothing And blnAutoCreate Then
                Call InitEMR

                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)).objModule = mobjEMR

                aryRegModule(UBound(aryRegModule)).strModuleName = C_WORKMODULE_NAME_���Ӳ���
                aryRegModule(UBound(aryRegModule)).lngModuleType = hmEMR
                aryRegModule(UBound(aryRegModule)).blnRefreshState = True
            End If

            Set IWorkModule_zlGetModule = mobjEMR.zlGetForm()
    End Select
End Function


Public Sub IWorkModule_zlRefresh(objStudyInfo As clsStudyInfo, ByVal strModuleName As String, _
    Optional ByVal blnIsForceRefresh As Boolean = False, Optional ByVal blnIsHistory As Boolean = False)
'ˢ�½���
    Dim rsTemp As ADODB.Recordset
    Dim iRows As Integer
    Dim iCols As Integer
    Dim strStudyUID As String
    Dim objHisModule As THisModuleInfo
    Dim strSQL As String
    Dim lngBillID As Long
    
    On Error GoTo errhandle
    
    mblnIsHistoryMode = blnIsHistory
     
    If Not mobjStudyInfo Is Nothing And Not objStudyInfo Is Nothing Then
        If mobjStudyInfo.IsEquals(objStudyInfo) And blnIsForceRefresh = False Then Exit Sub
    End If
    
    Set mobjStudyInfo = objStudyInfo
    
    objHisModule = GetModuleInfo(strModuleName) ', mobjStudyInfo
    
    If objHisModule.objModule Is Nothing Then Exit Sub
    
    objHisModule.lngTmpAdviceId = mobjStudyInfo.lngAdviceId
    objHisModule.lngTmpSendNo = mobjStudyInfo.lngSendNo
    
    objHisModule.blnRefreshState = True
    
    Select Case objHisModule.strModuleName
        Case C_WORKMODULE_NAME_���ü�¼
            If mlngModule = G_LNG_PATHOLSYS_NUM Then
                objHisModule.objModule.zlRefresh mlngCurDeptId, mobjStudyInfo.lngAdviceId, mobjStudyInfo.lngSendNo, mobjStudyInfo.blnMoved
            Else
                objHisModule.objModule.zlRefresh mlngCurDeptId, mobjStudyInfo.lngAdviceId & ":" & mobjStudyInfo.lngSendNo & ":0", mobjStudyInfo.blnMoved
            End If
        Case C_WORKMODULE_NAME_סԺҽ��
            objHisModule.objModule.zlRefresh mobjStudyInfo.lngPatId, mobjStudyInfo.lngPageID, mobjStudyInfo.lngUnit, mobjStudyInfo.lngPatDept, _
                                        IIf(blnIsHistory, -999, mobjStudyInfo.intState), mobjStudyInfo.blnMoved, mobjStudyInfo.lngAdviceId, mobjStudyInfo.intState, mlngCurDeptId
            
        Case C_WORKMODULE_NAME_����ҽ��
            If mobjStudyInfo.strRegNo = "" Then   '���еǼǵĲ���û�йҺŵ���
                objHisModule.objModule.zlRefresh mobjStudyInfo.lngPatId, "", False, , , mlngCurDeptId
            Else
                objHisModule.objModule.zlRefresh mobjStudyInfo.lngPatId, mobjStudyInfo.strRegNo, _
                                            IIf(blnIsHistory, False, mobjStudyInfo.blnIsInsidePatient), mobjStudyInfo.blnMoved, mobjStudyInfo.lngAdviceId, mlngCurDeptId
            End If
            
        Case C_WORKMODULE_NAME_סԺ����
            objHisModule.objModule.zlRefresh mobjStudyInfo.lngPatId, mobjStudyInfo.lngPageID, mlngCurDeptId, _
                                        IIf(blnIsHistory, False, True), mobjStudyInfo.blnMoved, 0, True
            
        Case C_WORKMODULE_NAME_���ﲡ��
            strSQL = "Select Id From ���˹Һż�¼ Where No = [1]"
            
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ѯ�Һ�ID", mobjStudyInfo.strRegNo)
            If rsTemp.EOF = False Then
                lngBillID = nvl(rsTemp!ID)
            End If
            
            objHisModule.objModule.zlRefresh mobjStudyInfo.lngPatId, lngBillID, mlngCurDeptId, _
                                        IIf(blnIsHistory, False, True), mobjStudyInfo.blnMoved, True, 0
        
        Case C_WORKMODULE_NAME_���Ӳ���
            If mobjStudyInfo.lngPatientFrom = 1 Then
                strSQL = "Select Id From ���˹Һż�¼ Where No = [1]"
            
                Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ѯ�Һ�ID", mobjStudyInfo.strRegNo)
                If rsTemp.EOF = False Then
                    lngBillID = nvl(rsTemp!ID)
                End If
            End If
            
            objHisModule.objModule.zlRefresh mobjStudyInfo.lngPatId, IIf(mobjStudyInfo.lngPatientFrom = 2, mobjStudyInfo.lngPageID, lngBillID), mlngCurDeptId, IIf(mobjStudyInfo.lngPatientFrom = 2, 0, 2), IIf(mobjStudyInfo.lngPatientFrom = 2, 2, 1)
    End Select
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub


Private Sub mobjInAdvice_ViewEPRReport(ByVal ����ID As Long, ByVal CanPrint As Boolean)
'�򿪱���
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    If mObjNotify Is Nothing Then Exit Sub

    strSQL = "Select ҽ��ID, 0 as Moved from ����ҽ������ where ����ID=[1] " & vbCrLf & _
                    " Union " & vbCrLf & _
                    "Select ҽ��ID, 1 as Moved from ����ҽ������ where ����ID=[1] "
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ����ҽ����Ϣ", ����ID)
    If rsData.RecordCount <= 0 Then Exit Sub

    If CanPrint Then
        Call mObjNotify.SendRequest(WM_REPORT_PRINT, , Val(nvl(rsData!ҽ��ID)), Val(nvl(rsData!Moved)), ����ID)
    Else
        Call mObjNotify.SendRequest(WM_REPORT_VIEW, , Val(nvl(rsData!ҽ��ID)), Val(nvl(rsData!Moved)), ����ID)
    End If
End Sub

Private Sub mobjOutAdvice_ViewEPRReport(ByVal ����ID As Long, ByVal CanPrint As Boolean)
'�򿪱���
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    If mObjNotify Is Nothing Then Exit Sub

    strSQL = "Select ҽ��ID, 0 as Moved from ����ҽ������ where ����ID=[1] " & vbCrLf & _
                    " Union " & vbCrLf & _
                    "Select ҽ��ID, 1 as Moved from ����ҽ������ where ����ID=[1] "
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ����ҽ����Ϣ", ����ID)
    If rsData.RecordCount <= 0 Then Exit Sub

    If CanPrint Then
        Call mObjNotify.SendRequest(WM_REPORT_PRINT, , Val(nvl(rsData!ҽ��ID)), Val(nvl(rsData!Moved)), ����ID)
    Else
        Call mObjNotify.SendRequest(WM_REPORT_VIEW, , Val(nvl(rsData!ҽ��ID)), Val(nvl(rsData!Moved)), ����ID)
    End If
End Sub

Private Sub mobjInAdvice_ViewPACSImage(ByVal ҽ��ID As Long)
'�򿪹�Ƭ
    If mObjNotify Is Nothing Then Exit Sub
    Call mObjNotify.SendRequest(WM_IMG_OPENVIEW, , ҽ��ID)
End Sub

Private Sub mobjOutAdvice_ViewPACSImage(ByVal ҽ��ID As Long)
'�򿪹�Ƭ
    If mObjNotify Is Nothing Then Exit Sub
    Call mObjNotify.SendRequest(WM_IMG_OPENVIEW, , ҽ��ID)
End Sub


