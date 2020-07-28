VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsPACSWork"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
Public VERSION As String

Public Type TRequestInfo
    lngPatiID As Long  '����ID
    dtTime As Date '��ǰ������ʱ��
    strType As String 'Ӱ�����
End Type

'��ҩ�䷽��������Ҫ�Ĳ�����Ϣ
Public Type TYPE_PatiInfoEx
        lng����ID As Long
        lng��ҳID As Long '��ҳID
        str�Һŵ� As String '�Һŵ���
        str�Ա� As String  '�����Ա�
        intӤ�� As Integer
        int���� As Integer 'ҽ�����˵�����
        blnҽ�� As Boolean '�Ƿ�ҽ������
        lng���˿���ID As Long '����ȷ����ҩ�䷽��ȱʡҩ��
End Type

Private mfrmPacsMain As Object
Private mfrmVideoMain As Object
Private mfrmPatholMain As Object
Private mobjPacsInterface As Object


Private Sub OpenNewRichReportModul(ByVal lngSys As Long, ByVal lngModul As Long, lngMain As Long)
'���°汨���ĵ��༭��������ģ��
    Dim objRegister As Object
    
    If mobjPacsInterface Is Nothing Then
        Set mobjPacsInterface = DynamicCreate("ZLSoft.ZLPacs.Interface.PacsInterface", "PACS���ܱ���༭���ӿڲ���zlPacsInterfaceC")
    End If
    
    If Not mobjPacsInterface Is Nothing Then
        If InitRegister = False Then Exit Sub
        
        BUGEX "zlInit InitRegister " & gstrUserPswd
        
        Call mobjPacsInterface.CodeMain(glngSys, lngModul, "", lngMain, gstrUserName, gstrUserPswd, gstrServerName)
    End If
End Sub


Public Sub CodeMan(lngSys As Long, ByVal lngModul As Long, cnMain As ADODB.Connection, frmMain As Object, ByVal strDBUser As String)
'���ܣ� ����������ָ�����ܣ�����ִ����س���
'������
'   lngModul:��Ҫִ�еĹ������
'   cnMain:����������ݿ�����
'   frmMain:������
'   strDBUser:��ǰ��¼���ݿ��û���

    '------------------------------------------------
On Error GoTo errhandle
    
    
    Set gcnOracle = cnMain
    Set gfrmMain = frmMain
    
    gblUsePacsQuery = GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "��ѯ����", "1") <> "1001"
    gblnUseValidLog = GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "����ͼ��ǩ����֤����", "0") = "1"
    gblnUsePacsV2 = GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "�����Ż���", "1002") <> "1002"

    glngMainHwnd = gfrmMain.hwnd
    gstrDBUser = strDBUser
    gstrInputPwd = frmMain.objLogin.InputPwd
    glngModul = lngModul
    glngSys = lngSys

    '��ȡע������ж��Ƿ����õ�����־
    gblnUseDebugLog = IIf(Val(GetSetting("ZLSOFT", "����ģ��\" & App.ProductName & "\frmPacsMain", "UseDebugLog", 0)) = 0, False, True)
    Call SaveSetting("ZLSOFT", "����ģ��\" & App.ProductName & "\frmPacsMain", "UseDebugLog", IIf(gblnUseDebugLog, 1, 0))
    
    gstrPrivs = ";" & GetPrivFunc(lngSys, lngModul) & ";"
    If gstrPrivs = "" Then MsgBox "�㲻�߱�ʹ�ø�ģ���Ȩ�ޣ�", vbExclamation, gstrSysName: Exit Sub
    
    Call WriteLog("CodeMan -> Step 1")
    
    If Not InitSysPar Then Exit Sub '��ʼ��ϵͳ����
    
    Select Case lngModul
        Case 1049, 2280, 2281, 2282, 2283, 2284, 2286
            Call OpenNewRichReportModul(lngSys, lngModul, frmMain.hwnd)
        
        Case 1056 'Ӱ������Ŀ
            frmRadLists.Show , gfrmMain
        Case 1057 'Ӱ���豸Ŀ¼
            frmPACSDevice.Show , gfrmMain
        Case 1079
            frmPatholSpecimenCfg.Show , gfrmMain
        Case 1290 'Ӱ��ʦ����վ
            gstrOracleOwner = zlDatabase.GetPara("XWOracleӵ����", glngSys, G_LNG_XWPACSVIEW_MODULE, "zlhis")
            
            If mfrmPacsMain Is Nothing Then
                Set mfrmPacsMain = CreateMainModule(gfrmMain, "Ӱ��ҽ������վ", False)
                AttachModuleMsgProc mtImage, mfrmPacsMain
            Else
                If mfrmPacsMain.IsValid = False Then
                    Set mfrmPacsMain = CreateMainModule(gfrmMain, "Ӱ��ҽ������վ", False)
                    AttachModuleMsgProc mtImage, mfrmPacsMain
                Else
                    mfrmPacsMain.WindowState = 0
                    mfrmPacsMain.Show , gfrmMain
                End If
            End If
        
            
        Case 1291   'Ӱ��ɼ�����վ

            If mfrmVideoMain Is Nothing Then
                Set mfrmVideoMain = CreateMainModule(gfrmMain, "Ӱ��ɼ�����վ", False)
                AttachModuleMsgProc mtVideo, mfrmVideoMain
            Else
                If mfrmVideoMain.IsValid = False Then
                    Set mfrmVideoMain = CreateMainModule(gfrmMain, "Ӱ��ɼ�����վ", False)
                    AttachModuleMsgProc mtVideo, mfrmVideoMain
                Else
                    mfrmVideoMain.WindowState = 0
                    mfrmVideoMain.Show , gfrmMain
                End If
            End If
            
            
'        Case 1292   'Ӱ�����̿���
'            frmWorkFlow.Show , gfrmMain
        Case 1294   'Ӱ��������վ
            If mfrmPatholMain Is Nothing Then
                Set mfrmPatholMain = CreateMainModule(gfrmMain, "������鹤��վ", False)
                AttachModuleMsgProc mtImage, mfrmPatholMain
            Else
                If mfrmPatholMain.IsValid = False Then
                    Set mfrmPatholMain = CreateMainModule(gfrmMain, "������鹤��վ", False)
                    AttachModuleMsgProc mtImage, mfrmPatholMain
                Else
                    mfrmPatholMain.WindowState = 0
                    mfrmPatholMain.Show , gfrmMain
                End If
            End If
            
            
        Case 1295   '�����鵵����վ
            frmPatholArchivesStation.Show , gfrmMain
        Case 1296   '�����軹����վ
            frmPatholReborrowStation.Show , gfrmMain
        Case 1297   '����������ʧ��������վ
            frmPatholLoseStation.Show , gfrmMain
    End Select
    
    Call WriteLog("CodeMan -> Step 2")
Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Function CreateMainModule(ByVal objParent As Object, ByVal strCaption As String, ByVal blnIsBHMain As Boolean) As Object
'������ģ��
    Call WriteLog("CreateMainModule -> Step 1�� ��ʼ����������.")
    Call InitBaseComponent(objParent, blnIsBHMain)

    Call WriteLog("CreateMainModule -> Step 2�� ��ʼ������ʾ����ģ�� [" + strCaption + "].")
    
    If gblUsePacsQuery Then
        If gblnUsePacsV2 Then
            Set CreateMainModule = New frmPacsMainV2
        Else
            Set CreateMainModule = New frmPacsMainNew
        End If
    Else
        If gblnUsePacsV2 Then
            Set CreateMainModule = New frmPacsMainV2
        Else
            Set CreateMainModule = New frmPacsMain
        End If
    End If
    If blnIsBHMain = True Then
        OS.ShowChildWindow CreateMainModule.hwnd, glngMainHwnd, True
        CreateMainModule.ShowStation glngModul, Nothing
    Else
        CreateMainModule.ShowStation glngModul, objParent
    End If

    CreateMainModule.Caption = strCaption
        
    Call WriteLog("CreateMainModule -> Step 3�� ����ģ�� [" + strCaption + "] �������.")
End Function

Private Sub InitBaseComponent(ByVal objParent As Object, ByVal blnIsBHMain As Boolean)
'��ʼ����������
'blnIsBHMain=falseʱobjParentΪfrmMain����
'blnIsBHMain=trueʱobjParentΪobjLogin����

    Set gobjEmr = objParent.mobjEMR
    
    If gobjRichEPR Is Nothing Then
        Set gobjRichEPR = New zlRichEPR.cRichEPR
    End If
    
    If blnIsBHMain = False Then
        Call gobjKernel.InitCISKernel(gcnOracle, objParent, glngSys, gstrPrivs) '��ʼ��ҽ�����������Ĳ���
        Call gobjRichEPR.InitRichEPR(gcnOracle, objParent, glngSys, False)

        Call InitPacsControlWithInPro(gcnOracle, glngMainHwnd, glngSys, glngModul, objParent, gblnUseDebugLog)
    Else
        Call gobjKernel.InitCISKernel(gcnOracle, Nothing, glngSys, gstrPrivs) '��ʼ��ҽ�����������Ĳ���
        Call gobjRichEPR.InitRichEPR(gcnOracle, objParent, glngSys, False)
        
        Call InitPacsControlWithInPro(gcnOracle, glngMainHwnd, glngSys, glngModul, Nothing, gblnUseDebugLog)
    End If
End Sub

Public Sub BHCodeMan(lngSys As Long, ByVal lngModul As Long, cnMain As ADODB.Connection, lngMain As Long, ByVal strDBUser As String, Optional ByVal objLogin As Object)
'���ܣ� ����������ָ�����ܣ�����ִ����س���
'������
'   lngModul:��Ҫִ�еĹ������
'   cnMain:����������ݿ�����
'   lngMain:��������
'   strDBUser:��ǰ��¼���ݿ��û���

    '------------------------------------------------
On Error GoTo errhandle
    Set gcnOracle = cnMain
    Set gfrmMain = Nothing
    
    glngMainHwnd = lngMain
    gstrDBUser = strDBUser
    
    If Not objLogin Is Nothing Then
        gstrInputPwd = objLogin.InputPwd
    End If
    
    glngModul = lngModul
    glngSys = lngSys

    gstrPrivs = ";" & GetPrivFunc(lngSys, lngModul) & ";"
    If gstrPrivs = "" Then MsgBox "�㲻�߱�ʹ�ø�ģ���Ȩ�ޣ�", vbExclamation, gstrSysName: Exit Sub

    If Not InitSysPar Then Exit Sub '��ʼ��ϵͳ����
    
    '��ȡע������ж��Ƿ����õ�����־
    gblnUseDebugLog = IIf(Val(GetSetting("ZLSOFT", "����ģ��\" & App.ProductName & "\frmPacsMain", "UseDebugLog", 0)) = 0, False, True)
    Call SaveSetting("ZLSOFT", "����ģ��\" & App.ProductName & "\frmPacsMain", "UseDebugLog", IIf(gblnUseDebugLog, 1, 0))
        

    Select Case lngModul
        Case 1049, 2280, 2281, 2282, 2283, 2284, 2286
            Call OpenNewRichReportModul(lngSys, lngModul, lngMain)
        
        Case 1056 'Ӱ������Ŀ
            OS.ShowChildWindow frmRadLists.hwnd, lngMain
        Case 1057 'Ӱ���豸Ŀ¼
            OS.ShowChildWindow frmPACSDevice.hwnd, lngMain
        Case 1079
            OS.ShowChildWindow frmPatholSpecimenCfg.hwnd, lngMain
        Case 1290 'Ӱ��ʦ����վ
            
            gstrOracleOwner = zlDatabase.GetPara("XWOracleӵ����", glngSys, G_LNG_XWPACSVIEW_MODULE, "zlhis")
                        
            If mfrmPacsMain Is Nothing Then
                Set mfrmPacsMain = CreateMainModule(objLogin, "Ӱ��ҽ������վ", True)
            Else
                If mfrmPacsMain.IsValid = False Then
                    Set mfrmPacsMain = CreateMainModule(objLogin, "Ӱ��ҽ������վ", True)
                Else
                    mfrmPacsMain.WindowState = 0
                    mfrmPacsMain.Show , Nothing
                End If
            End If
            
            AttachModuleMsgProc mtImage, mfrmPacsMain
        Case 1291   'Ӱ��ɼ�����վ
            
            If mfrmVideoMain Is Nothing Then
                Set mfrmVideoMain = CreateMainModule(objLogin, "Ӱ��ɼ�����վ", True)
            Else
                If mfrmVideoMain.IsValid = False Then
                    Set mfrmVideoMain = CreateMainModule(objLogin, "Ӱ��ɼ�����վ", True)
                Else
                    mfrmVideoMain.WindowState = 0
                    mfrmVideoMain.Show , Nothing
                End If
            End If
            
            AttachModuleMsgProc mtVideo, mfrmVideoMain
'        Case 1292   'Ӱ�����̿���
'            zlCommFun.ShowChildWindow frmWorkFlow.hWnd, lngMain
        Case 1294   'Ӱ��������վ
            If mfrmPatholMain Is Nothing Then
                Set mfrmPatholMain = CreateMainModule(objLogin, "������鹤��վ", True)
            Else
                If mfrmPatholMain.IsValid = False Then
                    Set mfrmPatholMain = CreateMainModule(objLogin, "������鹤��վ", True)
                Else
                    mfrmPatholMain.WindowState = 0
                    mfrmPatholMain.Show , Nothing
                End If
            End If
            
            AttachModuleMsgProc mtPathol, mfrmPatholMain
        Case 1295   '�����鵵����վ
            OS.ShowChildWindow frmPatholArchivesStation.hwnd, lngMain, True
        Case 1296   '�����軹����վ
            OS.ShowChildWindow frmPatholReborrowStation.hwnd, lngMain, True
        Case 1297   '����������ʧ��������վ
            OS.ShowChildWindow frmPatholLoseStation.hwnd, lngMain, True
    End Select
Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Public Function CloseWindows() As Boolean
    '--------------------------------------
    '����:�ر������Ӵ���
    '--------------------------------------
On Error GoTo errhandle
    
    Dim frmThis As Form
    
    For Each frmThis In Forms
        UnLoadForm frmThis
    Next
    
    Call gobjEmr.CloseForms
    CloseWindows = (Forms.Count = 0)

errhandle:
End Function

Private Sub UnLoadForm(objForm As Object)
On Error GoTo errhandle
    Unload objForm
Exit Sub
errhandle:
    Debug.Print err.Description
End Sub

Private Sub Class_Initialize()
    VERSION = App.major & "." & App.minor & "." & App.Revision
End Sub

Private Sub Class_Terminate()
On Error GoTo errhandle
    If gblUsePacsQuery Then
        Unload frmPacsMainNew
        Set frmPacsMainNew = Nothing
    Else
        Unload frmPacsMain
        Set frmPacsMain = Nothing
    End If
    
    Set gobjReport = Nothing
    
    If Not gobjRichEPR Is Nothing Then Call gobjRichEPR.CloseWindows
    Set gobjRichEPR = Nothing
    
    If Not gobjKernel Is Nothing Then gobjKernel.CloseWindows
    Set gobjKernel = Nothing
    
    Set gobjEmr = Nothing
    Set gobjESign = Nothing
    Set gobjRegister = Nothing
    
    Set mfrmPacsMain = Nothing
    Set mfrmVideoMain = Nothing
    Set mobjPacsInterface = Nothing
    Set mfrmPatholMain = Nothing
errhandle:
End Sub