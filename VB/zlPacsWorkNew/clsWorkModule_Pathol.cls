VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsWorkModule_Pathol"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Implements IWorkMenu


Private Const M_STR_HINT_NoSelectData As String = "��Ч�ļ�����ݣ���ѡ����Ҫִ�еļ���¼��"
Private Const M_STR_MODULE_MENU_TAG As String = "����"

Public Enum TModuleType
    mtAll = -1
    mtSpecimen = 0  '�걾����ģ��
    mtMaterial = 1  '�걾ȡ��ģ��
    mtSlices = 2    '������Ƭģ��
    mtSpeExam = 3   '�����ؼ�ģ��
    mtProRep = 4    '��������ģ��
End Enum


Private mlngModule  As Long
Private mstrPrivs  As String
Private mlngCurDeptId As Long
Private mobjOwner As Object

Private mlngAdviceID As Long
Private mlngSendNo As Long
Private mblnMoved As Boolean
Private mlngStudyState As Long

Private mblnReadOnly As Boolean

Private mfrmPatholSpecimen As frmPatholSpecimen              '�걾����
Attribute mfrmPatholSpecimen.VB_VarHelpID = -1
Private mfrmPatholMaterial As frmPatholMaterials             'ȡ��
Attribute mfrmPatholMaterial.VB_VarHelpID = -1
Private mfrmPatholSlices As frmPatholSlices                  '��Ƭ
Attribute mfrmPatholSlices.VB_VarHelpID = -1
Private mfrmPatholSpeExam As frmPatholSpecialExamined        '�ؼ�
Attribute mfrmPatholSpeExam.VB_VarHelpID = -1
Private mfrmPatholProRep As frmPatholProcedureRep                       '���̱���

Private aryRegModule() As Object                                        '���浱ǰ������ģ��

    
Private mfrmConRequest As frmPatholConsultation                           '��������
Private mfrmPatholDecalinTask As frmPatholDecalcification            '�Ѹ�����

Private mObjActiveMenuBar As CommandBars



'��ȡ�˵��ӿڶ���
Property Get zlMenu() As IWorkMenu
    Set zlMenu = Me
End Property


Public Sub NotificationRefresh(Optional ByVal lngModule As Long = -1)
'֪ͨˢ��
    Dim i As Long
    Dim objModule As Object
    
    If lngModule = -1 Then
        For i = LBound(aryRegModule) To UBound(aryRegModule)
            If Not aryRegModule(i) Is Nothing Then
                Call aryRegModule(i).NotificationRefresh
            End If
        Next i
    Else
        Set objModule = GetModule(lngModule, False)
        
        If Not objModule Is Nothing Then Call objModule.NotificationRefresh
    End If
    
End Sub

Private Sub Class_Initialize()
    Set mfrmPatholDecalinTask = New frmPatholDecalcification
    Set mfrmConRequest = New frmPatholConsultation
    
    '����ʹ��uboundʱ���������Ĭ�ϳ�ʼ��һ��������Ԫ��
    ReDim Preserve aryRegModule(1)
    Set aryRegModule(0) = Nothing
End Sub

Public Sub Free()
On Error GoTo errHandle
    Dim i As Long
    
    If SafeArrayGetDim(aryRegModule) <> 0 Then
        For i = LBound(aryRegModule) To UBound(aryRegModule)
            If Not aryRegModule(i) Is Nothing Then
                Unload aryRegModule(i)
                Set aryRegModule(i) = Nothing
            End If
        Next i
    End If
    
    Set mfrmPatholSpecimen = Nothing
    Set mfrmPatholMaterial = Nothing
    Set mfrmPatholSlices = Nothing
    Set mfrmPatholSpeExam = Nothing
    Set mfrmPatholProRep = Nothing
    
    Unload mfrmConRequest
    Set mfrmConRequest = Nothing
    
    Unload mfrmPatholDecalinTask
    Set mfrmPatholDecalinTask = Nothing
    
errHandle:
End Sub


Public Function GetModule(ByVal lngModule As Long, Optional ByVal blnAutoCreate As Boolean = True) As Object
'��ȡָ��ģ�����
    Set GetModule = Nothing
    
    Select Case lngModule
        Case mtSpecimen
            If mfrmPatholSpecimen Is Nothing And blnAutoCreate Then
                Set mfrmPatholSpecimen = New frmPatholSpecimen

                Call mfrmPatholSpecimen.zlInitModule(mlngModule, mstrPrivs, mlngCurDeptId, mobjOwner)
                
'                FormSetCaption mfrmPatholSpecimen, False, False
                Call SetWindowStyle(mfrmPatholSpecimen.hWnd)
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)) = mfrmPatholSpecimen
            End If
            
            Set GetModule = mfrmPatholSpecimen
            
        Case mtMaterial
            If mfrmPatholMaterial Is Nothing And blnAutoCreate Then
                Set mfrmPatholMaterial = New frmPatholMaterials
                
                Call mfrmPatholMaterial.zlInitModule(mlngModule, mstrPrivs, mlngCurDeptId, mobjOwner)
                
                Call SetWindowStyle(mfrmPatholMaterial.hWnd)
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)) = mfrmPatholMaterial
            End If
            
            Set GetModule = mfrmPatholMaterial
               
        Case mtSlices
            If mfrmPatholSlices Is Nothing And blnAutoCreate Then
                Set mfrmPatholSlices = New frmPatholSlices

                Call mfrmPatholSlices.zlInitModule(mlngModule, mstrPrivs, mlngCurDeptId, mobjOwner)
                
                Call SetWindowStyle(mfrmPatholSlices.hWnd)
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)) = mfrmPatholSlices
            End If
            
            Set GetModule = mfrmPatholSlices
            
        Case mtSpeExam
            If mfrmPatholSpeExam Is Nothing And blnAutoCreate Then
                Set mfrmPatholSpeExam = New frmPatholSpecialExamined

                Call mfrmPatholSpeExam.zlInitModule(mlngModule, mstrPrivs, mlngCurDeptId, mobjOwner)
                
                Call SetWindowStyle(mfrmPatholSpeExam.hWnd)
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)) = mfrmPatholSpeExam
            End If
            
            Set GetModule = mfrmPatholSpeExam
            
        Case mtProRep
            If mfrmPatholProRep Is Nothing And blnAutoCreate Then
                Set mfrmPatholProRep = New frmPatholProcedureRep

                Call mfrmPatholProRep.zlInitModule(mlngModule, mstrPrivs, mlngCurDeptId, mobjOwner)
                
                Call SetWindowStyle(mfrmPatholProRep.hWnd)
                
                ReDim Preserve aryRegModule(UBound(aryRegModule) + 1)
                Set aryRegModule(UBound(aryRegModule)) = mfrmPatholProRep
            End If
            
            Set GetModule = mfrmPatholProRep
    End Select
End Function

Public Function GetActiveModule() As Object
'��ȡ��ǰ��ʾ�ù���ģ��
    Dim i As Long
    
    Set GetActiveModule = Nothing
    
    For i = LBound(aryRegModule) To UBound(aryRegModule)
        If Not aryRegModule(i) Is Nothing Then
            If aryRegModule(i).Visible Then
                Set GetActiveModule = aryRegModule(i)
                Exit For
            End If
        End If
    Next i
End Function

Private Sub Class_Terminate()
    Set mobjOwner = Nothing
    Set mfrmPatholSpecimen = Nothing
    Set mfrmPatholMaterial = Nothing
    Set mfrmPatholSlices = Nothing
    Set mfrmPatholSpeExam = Nothing
    Set mfrmPatholProRep = Nothing
    ReDim aryRegModule(0)
    Set aryRegModule(0) = Nothing
    Set mfrmConRequest = Nothing
    Set mfrmPatholDecalinTask = Nothing
    Set mObjActiveMenuBar = Nothing
End Sub

'�ӿ�ʵ�ֲ���*********************************************************************************

Public Function IWorkMenu_zlIsModuleMenu(ByVal objControlMenu As XtremeCommandBars.ICommandBarControl) As Boolean
'�жϲ˵��Ƿ����ڸ�ģ��˵�
    Dim blnIsModuleMenu As Boolean
    Dim i As Long
    Dim objIWork As IWorkMenu
    
    blnIsModuleMenu = IIf(objControlMenu.Category = M_STR_MODULE_MENU_TAG, True, False)
    
    If Not blnIsModuleMenu Then
        For i = LBound(aryRegModule) To UBound(aryRegModule)
            If Not aryRegModule(i) Is Nothing Then
                Set objIWork = aryRegModule(i)
                
                blnIsModuleMenu = objIWork.zlIsModuleMenu(objControlMenu)
                
                If blnIsModuleMenu Then Exit For
            End If
        Next i
    End If
    
    IWorkMenu_zlIsModuleMenu = blnIsModuleMenu
End Function


Public Sub IWorkMenu_zlCreateMenu(objMenuBar As Object)
'����Ӱ���¼��Ӧ�Ĳ˵�
    Dim cbrMenuBar As CommandBarPopup
    Dim cbrPopControl As CommandBarControl
    Dim cbrControl As CommandBarControl
    Dim objIWork As IWorkMenu
    
    Dim str3DFuncs() As String
    Dim i As Long
    Dim lng3DFunc As Long
    
    
    Set mObjActiveMenuBar = objMenuBar
    
    If Not HasMenu(objMenuBar, conMenu_PatholManage) Then
        Set cbrMenuBar = mObjActiveMenuBar.ActiveMenuBar.Controls.Add(xtpControlPopup, conMenu_PatholManage, "����", 3, False)
        cbrMenuBar.ID = conMenu_PatholManage
        cbrMenuBar.Category = M_STR_MODULE_MENU_TAG
        
        
        With cbrMenuBar.CommandBar
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_Antibody_Manage, "�������", "", 0, True)
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_MealManage, "�ײ�ά��", "", 0, False)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_Decalin_Task, "�Ѹ�����", "", 0, True)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_Request, "��������", "", 0, True)
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_ReportDelay, "�ӳٵǼ�", "", 0, False)
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_ConRequest, "��������", "", 0, False)
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_ConFeedback, "���ﷴ��", "", 0, False)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_BatSlicesAccept, "������Ƭ", "", G_INT_ICONID_SLICES, True)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_BatSpeExamAccept, "�����ؼ�", "", G_INT_ICONID_SPEEXAM, True)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_Quality_Manage, "��������", "", 0, True)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_PatholSlices_Quality, "��Ƭ����", "", 3097, True)
            
            Set cbrControl = CreateModuleMenu(.Controls, xtpControlButton, conMenu_Pathol_NumConfig, "��������", "", 9023, True)
        End With
    End If
    
    Set objIWork = GetActiveModule
    
    If Not objIWork Is Nothing Then Call objIWork.zlCreateMenu(objMenuBar)
End Sub


Public Sub IWorkMenu_zlCreateToolBar(objToolBar As Object)
'����������
    Dim cbrControl As CommandBarControl
    Dim cbrPopControl As CommandBarControl
    Dim cbrLogOut As CommandBarControl
    Dim lngIndex As Long
        
    Dim str3DFuncs() As String
    Dim i As Long
    Dim lng3DFunc As Long
    
    If HasMenu(objToolBar, conMenu_Pathol_BatProcess) Then Exit Sub
    
    Set cbrLogOut = objToolBar.FindControl(, conMenu_Manage_InQueue)
    
    lngIndex = 4
    If Not cbrLogOut Is Nothing Then lngIndex = cbrLogOut.Index
    
    Set cbrControl = CreateModuleMenu(objToolBar.Controls, xtpControlSplitButtonPopup, conMenu_Pathol_BatProcess, "��������", "����������Ƭ���ܡ���Ƭȷ�ϡ��ؼ���ܵȲ���", G_INT_ICONID_BATPROCESS, True, lngIndex + 1)
        Set cbrPopControl = CreateModuleMenu(cbrControl.CommandBar.Controls, xtpControlButton, conMenu_Pathol_BatSlicesAccept, "��Ƭ��������", "��Ƭ��������", G_INT_ICONID_SLICES, False)
        Set cbrPopControl = CreateModuleMenu(cbrControl.CommandBar.Controls, xtpControlButton, conMenu_Pathol_BatSpeExamAccept, "�ؼ���������", "�ؼ���������", G_INT_ICONID_SPEEXAM, False)
    
    Set cbrControl = CreateModuleMenu(objToolBar.Controls, xtpControlButton, conMenu_Pathol_Request, "��������", "��������", 0, False, lngIndex + 2)
    
End Sub

Public Sub IWorkMenu_zlClearMenu()
'����������Ĳ˵�
    Dim cbrControl As CommandBarControl
    
    Set cbrControl = mObjActiveMenuBar.FindControl(, conMenu_PatholManage)
    If Not cbrControl Is Nothing Then Call cbrControl.Delete
End Sub


Public Sub IWorkMenu_zlClearToolBar()
'��������Ĺ�����
    Dim cbrControl As CommandBarControl
    
    Set cbrControl = mObjActiveMenuBar.FindControl(, conMenu_Pathol_BatProcess)
    If Not cbrControl Is Nothing Then Call cbrControl.Delete
    
    Set cbrControl = mObjActiveMenuBar.FindControl(, conMenu_Pathol_Request)
    If Not cbrControl Is Nothing Then Call cbrControl.Delete
End Sub

Public Sub IWorkMenu_zlExecuteMenu(ByVal lngMenuId As Long)
'���ݲ˵�IDִ�ж�Ӧ����
    Dim objCbrControl As XtremeCommandBars.CommandBarControl
    Dim objIWork As IWorkMenu
    
    Select Case lngMenuId
        Case conMenu_Pathol_NumConfig     '������������
            Call Menu_Manage_����������
            
        Case conMenu_Pathol_Antibody_Manage    '�������
            Call Menu_Manage_�������
            
        Case conMenu_Pathol_MealManage        '�ײ�ά��
            Call Menu_Manage_�ײ�ά��
            
        Case conMenu_Pathol_Request     '��������
            Call Menu_Manage_��������
            
        Case conMenu_Pathol_ReportDelay       '�ӳٵǼ�
            Call Menu_Manage_�ӳٵǼ�
        
        Case conMenu_Pathol_ConRequest, conMenu_Pathol_ConFeedback       '�������뷴��
            Call Menu_Manage_�������뷴��(lngMenuId)
            
        Case conMenu_Pathol_Decalin_Task       '�Ѹ�����
            Call Menu_Manage_�Ѹ��������
            
        Case conMenu_Pathol_BatSlicesAccept   '��Ƭ��������
            Call Menu_Manage_��Ƭ��������
            
        Case conMenu_Pathol_BatSpeExamAccept  '�ؼ���������
            Call Menu_Manage_�ؼ���������
            
        Case conMenu_Pathol_Quality_Manage '������������
            Call Menu_Manage_������������
            
         Case conMenu_PatholSlices_Quality  '������Ƭ����
            Call Menu_Manage_������Ƭ����
    End Select
    
    Set objIWork = GetActiveModule
    
    If Not objIWork Is Nothing Then Call objIWork.zlExecuteMenu(lngMenuId)
End Sub


Public Sub IWorkMenu_zlUpdateMenu(ByVal Control As XtremeCommandBars.ICommandBarControl)
'���²˵�
    Dim objIWork As IWorkMenu
    
    Select Case Control.ID
       Case conMenu_Pathol_Antibody_Manage
            If Not (CheckPopedom(mstrPrivs, "�������") Or CheckPopedom(mstrPrivs, "���巴��")) Then
                Control.Enabled = False
            Else
            
            End If
        Case conMenu_Pathol_MealManage
            If Not CheckPopedom(mstrPrivs, "�ײ�ά��") Then
                Control.Enabled = False
            Else
            
            End If
        Case conMenu_Pathol_Request
            If Not (CheckPopedom(mstrPrivs, "�ؼ�����") Or CheckPopedom(mstrPrivs, "��Ƭ����") Or CheckPopedom(mstrPrivs, "��ȡ����")) Then
                Control.Enabled = False
            Else
                Control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_Pathol_ReportDelay
            If Not CheckPopedom(mstrPrivs, "�����ӳ�") Then
                Control.Enabled = False
            Else
                Control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_Pathol_ConRequest
            If Not CheckPopedom(mstrPrivs, "��������") Then
                Control.Enabled = False
            Else
                Control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_Pathol_ConFeedback
            If Not CheckPopedom(mstrPrivs, "���ﷴ��") Then
                Control.Enabled = False
            Else
                Control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_Pathol_Decalin_Task
            If Not CheckPopedom(mstrPrivs, "����ȡ��") Then
                Control.Enabled = False
            Else
                Control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_Pathol_BatSlicesAccept ', conMenu_Pathol_BatSlicesSure
            If Not CheckPopedom(mstrPrivs, "������Ƭ") Then
                Control.Enabled = False
            Else
'                control.Enabled = Not mblnReadOnly
            End If
            
        Case conMenu_Pathol_BatSpeExamAccept
            If Not (CheckPopedom(mstrPrivs, "�����黯") Or CheckPopedom(mstrPrivs, "���Ӳ���") Or CheckPopedom(mstrPrivs, "����Ⱦɫ")) Then
                Control.Enabled = False
            Else
'                control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_Pathol_Quality_Manage
            If Not CheckPopedom(mstrPrivs, "��������") Then
                Control.Enabled = False
            Else
                Control.Enabled = Not mblnReadOnly
            End If
        Case conMenu_PatholSlices_Quality
            '������߱���������Ȩ�ޣ�����Բ鿴��Ƭ����������
'            If Not CheckPopedom(mstrPrivs, "��������") Then
'                control.Enabled = False
'            End If
            Control.Enabled = Not mblnReadOnly
        Case conMenu_Pathol_BatProcess
            If Not (CheckPopedom(mstrPrivs, "������Ƭ") Or CheckPopedom(mstrPrivs, "�����黯") Or CheckPopedom(mstrPrivs, "���Ӳ���") Or CheckPopedom(mstrPrivs, "����Ⱦɫ")) Then
                Control.Enabled = False
            Else
'                control.Enabled = Not mblnReadOnly
            End If
    End Select
    
    Set objIWork = GetActiveModule
    
    If Not objIWork Is Nothing Then Call objIWork.zlUpdateMenu(Control)
End Sub


Public Sub IWorkMenu_zlPopupMenu(objPopup As XtremeCommandBars.ICommandBar)
'�����Ҽ��˵�
    Exit Sub
End Sub

Public Sub IWorkMenu_zlRefreshSubMenu(objMenuBar As Object)
'ˢ�µ������Ӳ˵�
    Exit Sub
End Sub
'*********************************************************************************************


Public Sub zlInitModule(ByVal lngModule As Long, ByVal strPrivs As String, ByVal lngDepartId As Long, Optional owner As Object = Nothing)
'��ʼ��ģ�����
    Dim i As Long
    
    mlngModule = lngModule
    mstrPrivs = strPrivs
    mlngCurDeptId = lngDepartId
    
    If Not owner Is Nothing Then Set mobjOwner = owner

    For i = LBound(aryRegModule) To UBound(aryRegModule)
        If Not aryRegModule(i) Is Nothing Then
            Call aryRegModule(i).zlInitModule(lngModule, strPrivs, lngDepartId, owner)
        End If
    Next i
End Sub


Public Sub zlUpdateAdviceInf(ByVal lngAdviceID As Long, ByVal lngSendNo As Long, ByVal lngStudyState As Long, ByVal blnMoved As Boolean)
'����ҽ����Ϣ
    
    mlngAdviceID = lngAdviceID
    mlngSendNo = lngSendNo
    mblnMoved = blnMoved
    mlngStudyState = lngStudyState
    mblnReadOnly = False
    
    If Not mfrmPatholSpecimen Is Nothing Then Call mfrmPatholSpecimen.zlUpdateAdviceInf(lngAdviceID, lngSendNo, lngStudyState, blnMoved)
    If Not mfrmPatholMaterial Is Nothing Then Call mfrmPatholMaterial.zlUpdateAdviceInf(lngAdviceID, lngSendNo, lngStudyState, blnMoved)
    If Not mfrmPatholSlices Is Nothing Then Call mfrmPatholSlices.zlUpdateAdviceInf(lngAdviceID, lngSendNo, lngStudyState, blnMoved)
    If Not mfrmPatholSpeExam Is Nothing Then Call mfrmPatholSpeExam.zlUpdateAdviceInf(lngAdviceID, lngSendNo, lngStudyState, blnMoved)
    If Not mfrmPatholProRep Is Nothing Then Call mfrmPatholProRep.zlUpdateAdviceInf(lngAdviceID, lngSendNo, lngStudyState, blnMoved)
    
    '���Ϊ��ɣ��Ǽǣ��ܾ�����ˣ����ܶԼ����д��� 'Or lngStudyState = 5
    If mlngAdviceID <= 0 Or lngStudyState = 6 Or lngStudyState = 0 Or lngStudyState = 1 Or lngStudyState = -2 Then
        mblnReadOnly = True
    End If
End Sub



Private Function CreateModuleMenu(objMenuControl As CommandBarControls, _
    ByVal lngType As XTPControlType, ByVal lngID As Long, ByVal strCaption As String, _
    Optional strToolTip As String = "", Optional lngIconId As Long = 0, _
    Optional blnStartGroup As Boolean = False, Optional lngIndex As Long) As CommandBarControl
'������ģ���ڵĲ˵�
    
    If lngIndex >= 0 Then
        Set CreateModuleMenu = objMenuControl.Add(lngType, lngID, strCaption, lngIndex)
    Else
        Set CreateModuleMenu = objMenuControl.Add(lngType, lngID, strCaption)
    End If
    
    CreateModuleMenu.ID = lngID '������ﲻָ��id�����ܽ���Щ�˵����ӵ��Ҽ��˵���
    
    If lngIconId <> 0 Then CreateModuleMenu.IconId = lngIconId
    If blnStartGroup Then CreateModuleMenu.BeginGroup = True
    If strToolTip <> "" Then CreateModuleMenu.ToolTipText = strToolTip
    
    CreateModuleMenu.Category = M_STR_MODULE_MENU_TAG
End Function


Private Sub Menu_Manage_����������()
Dim frmPatholNum As New frmPatholNumConfig
On Error GoTo errFree
    Call frmPatholNum.Show(1, mobjOwner)
    
errFree:
    Call Unload(frmPatholNum)
    Set frmPatholNum = Nothing
End Sub

Public Function GetWindowCaption() As String
    GetWindowCaption = "�������ϵͳ"
End Function

Private Sub Menu_Manage_�������()
'�������
If Not (CheckPopedom(mstrPrivs, "�������") Or CheckPopedom(mstrPrivs, "���巴��")) Then
    Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
    Exit Sub
End If


Dim frmAntibody As New frmPatholAntibody
On Error GoTo errFree
    Call frmAntibody.ShowAntibodyManageWind(mstrPrivs, mobjOwner)
errFree:
    Call Unload(frmAntibody)
    Set frmAntibody = Nothing
End Sub



Private Sub Menu_Manage_�ײ�ά��()
'�ײ�ά��

If Not CheckPopedom(mstrPrivs, "�ײ�ά��") Then
    Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
    Exit Sub
End If

Dim frmMeal As New frmPatholMeal
On Error GoTo errFree
    Call frmMeal.ShowMealWindow(mstrPrivs, mobjOwner)
errFree:
    Call Unload(frmMeal)
    Set frmMeal = Nothing
End Sub


Private Sub Menu_Manage_��������()
'��������
On Error GoTo errFree
    Dim frmRequest As frmPatholRequisition

    If Not (CheckPopedom(mstrPrivs, "�ؼ�����") Or CheckPopedom(mstrPrivs, "��Ƭ����") Or CheckPopedom(mstrPrivs, "��ȡ����")) Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
    End If
    
    If mlngAdviceID = 0 Then
        MsgBoxD mobjOwner, M_STR_HINT_NoSelectData, vbInformation, GetWindowCaption
        Exit Sub
    End If
    
    Set frmRequest = New frmPatholRequisition
    
    Call frmRequest.zlRefresh(mlngAdviceID, mblnReadOnly, mstrPrivs, mblnMoved, mlngCurDeptId, mobjOwner)

    If frmRequest.blnIsUpdate Then
        Call SendMsgToMainWindow(Me, wetPatholRequest, mlngAdviceID)
    End If
errFree:
    Call Unload(frmRequest)
    Set frmRequest = Nothing
End Sub


Private Sub Menu_Manage_�ӳٵǼ�()
'�ӳٵǼ�
On Error GoTo errFree
    Dim frmDelay As frmPatholReportDelay

    If Not CheckPopedom(mstrPrivs, "�����ӳ�") Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
    End If

    If mlngAdviceID = 0 Then
        MsgBoxD Me, M_STR_HINT_NoSelectData, vbInformation, GetWindowCaption
        Exit Sub
    End If
    
    Set frmDelay = frmPatholReportDelay

    Call frmDelay.zlRefresh(mlngAdviceID, mblnReadOnly, mstrPrivs, mblnMoved, mlngCurDeptId, mobjOwner)
errFree:
    Call Unload(frmDelay)
    Set frmDelay = Nothing
End Sub


Private Sub Menu_Manage_������������()
'������������
On Error GoTo errFree
    Dim frmQulity As frmPatholQuality

    If Not CheckPopedom(mstrPrivs, "��������") Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
    End If

    If mlngAdviceID = 0 Then
        MsgBoxD Me, M_STR_HINT_NoSelectData, vbInformation, GetWindowCaption
        Exit Sub
    End If
    
    Set frmQulity = New frmPatholQuality

    Call frmQulity.zlRefresh(mlngAdviceID, mblnReadOnly, mstrPrivs, mblnMoved, mlngCurDeptId, mobjOwner)
    
    If frmQulity.blnIsOk Then
        Call SendMsgToMainWindow(Me, wetPatholQuality, mlngAdviceID, frmQulity.strQuality)
    End If
errFree:
    Call Unload(frmQulity)
    Set frmQulity = Nothing
End Sub

Private Sub Menu_Manage_������Ƭ����()
'��ʾ��Ƭ����
On Error GoTo errHandle
     Dim frmSlicesQuality As frmPatholSlices_Quality
    
     If Not CheckPopedom(mstrPrivs, "��������") Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
     End If
     
     Set frmSlicesQuality = New frmPatholSlices_Quality
     
     Call frmSlicesQuality.ShowSlideEvaluateWindow(mlngAdviceID, mlngStudyState, mstrPrivs, mobjOwner)
     
Exit Sub
errHandle:
    Call Unload(frmSlicesQuality)
    Set frmSlicesQuality = Nothing
End Sub


Private Sub Menu_Manage_�������뷴��(ByVal lngMenuId As Long)
'�������뷴��
On Error GoTo errFree

    If Not (CheckPopedom(mstrPrivs, "��������") Or CheckPopedom(mstrPrivs, "���ﷴ��")) Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
    End If

    If mlngAdviceID = 0 Then
        MsgBoxD mobjOwner, M_STR_HINT_NoSelectData, vbInformation, GetWindowCaption
        Exit Sub
    End If

    Call mfrmConRequest.zlRefresh(mlngAdviceID, mblnReadOnly, mstrPrivs, mblnMoved, mlngCurDeptId, IIf(lngMenuId = conMenu_Pathol_ConFeedback, True, False), mobjOwner)

    Exit Sub
errFree:
    If ErrCenter() = 1 Then Resume
End Sub


Private Sub Menu_Manage_�Ѹ��������()
'�Ѹ��������

If Not CheckPopedom(mstrPrivs, "����ȡ��") Then
    Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
    Exit Sub
End If

Call mfrmPatholDecalinTask.ShowDecalinTaskWind(mstrPrivs, mblnMoved, mlngModule, mobjOwner)

End Sub



Private Sub Menu_Manage_��Ƭ��������()
'��Ƭ��������
On Error GoTo errFree
    Dim frmBatSlices As frmPatholSlices_WorkPrint
  
    If Not CheckPopedom(mstrPrivs, "������Ƭ") Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
    End If
    
    Set frmBatSlices = New frmPatholSlices_WorkPrint
    
    Call frmBatSlices.ShowWorkPrint(Nothing, 0, mobjOwner)
        
        
    If frmBatSlices.blnIsOk Then
        Call SendMsgToMainWindow(Me, wetPatholBatSlices, mlngAdviceID)
    End If
errFree:
    Call Unload(frmBatSlices)
    Set frmBatSlices = Nothing
End Sub



Private Sub Menu_Manage_�ؼ���������()
'�ؼ���������
On Error GoTo errFree
    Dim frmBatSpeExam As frmPatholSpecialExamined_WorkPrint
    
    If Not (CheckPopedom(mstrPrivs, "�����黯") Or CheckPopedom(mstrPrivs, "����Ⱦɫ") Or CheckPopedom(mstrPrivs, "���Ӳ���")) Then
        Call MsgBoxD(mobjOwner, "���߱�ִ�иò�����Ȩ�ޡ�", vbOKOnly, GetWindowCaption)
        Exit Sub
    End If

    Set frmBatSpeExam = frmPatholSpecialExamined_WorkPrint
                
    If CheckPopedom(mstrPrivs, "�����黯") Then
        Call frmBatSpeExam.ShowWorkPrint(Nothing, 0, 0, mstrPrivs, mobjOwner)
    ElseIf CheckPopedom(mstrPrivs, "����Ⱦɫ") Then
        Call frmBatSpeExam.ShowWorkPrint(Nothing, 0, 1, mstrPrivs, mobjOwner)
    ElseIf CheckPopedom(mstrPrivs, "���Ӳ���") Then
        Call frmBatSpeExam.ShowWorkPrint(Nothing, 0, 2, mstrPrivs, mobjOwner)
    End If
    
    If frmBatSpeExam.blnIsOk Then
        Call SendMsgToMainWindow(Me, wetPatholBatSpeExm, mlngAdviceID)
    End If
errFree:
    Call Unload(frmBatSpeExam)
    Set frmBatSpeExam = Nothing
End Sub



