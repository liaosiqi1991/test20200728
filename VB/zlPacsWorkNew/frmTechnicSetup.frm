VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form frmTechnicSetup 
   AutoRedraw      =   -1  'True
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "参数设置"
   ClientHeight    =   6810
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6810
   Icon            =   "frmTechnicSetup.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6810
   ScaleWidth      =   6810
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  '所有者中心
   Begin VB.PictureBox PicAction 
      Appearance      =   0  'Flat
      ForeColor       =   &H80000008&
      Height          =   6540
      Left            =   120
      ScaleHeight     =   6510
      ScaleWidth      =   6585
      TabIndex        =   0
      Top             =   120
      Width           =   6615
      Begin VB.CheckBox chkPrintCheck 
         Caption         =   "自动规避重复打印申请单"
         Height          =   255
         Left            =   3840
         TabIndex        =   31
         Top             =   640
         Width           =   2535
      End
      Begin VB.Frame fraValid 
         Caption         =   "图像校对"
         Height          =   800
         Left            =   120
         TabIndex        =   29
         Top             =   5040
         Width           =   6375
         Begin VB.CheckBox chkValid 
            Caption         =   "打开影像工作站时自动校对前一天的图像"
            Height          =   375
            Left            =   240
            TabIndex        =   30
            ToolTipText     =   "打开工作站时自动校对"
            Top             =   240
            Width           =   5130
         End
      End
      Begin VB.Frame fraXwPacs 
         Height          =   855
         Left            =   3840
         TabIndex        =   25
         Top             =   4140
         Visible         =   0   'False
         Width           =   2655
         Begin VB.CheckBox chkLog 
            Caption         =   "记录日志"
            Height          =   255
            Left            =   1560
            TabIndex        =   27
            Top             =   480
            Width           =   1065
         End
         Begin VB.TextBox txtImageShare 
            Height          =   270
            Left            =   120
            TabIndex        =   26
            Text            =   "DCMSHARE"
            Top             =   480
            Width           =   1425
         End
         Begin VB.Label Label11 
            Caption         =   "历史图像共享目录"
            Height          =   255
            Left            =   100
            TabIndex        =   28
            Top             =   210
            Width           =   1605
         End
      End
      Begin VB.Frame frmPatholParameter 
         Height          =   3495
         Left            =   120
         TabIndex        =   18
         Top             =   0
         Width           =   3615
         Begin VB.CheckBox chkIsDirectPrint 
            Caption         =   "是否直接打印"
            Height          =   180
            Left            =   480
            TabIndex        =   21
            Top             =   2040
            Width           =   1575
         End
         Begin VB.TextBox txtDecalinHintTime 
            Height          =   270
            Left            =   2160
            TabIndex        =   20
            Text            =   "30"
            Top             =   1575
            Width           =   495
         End
         Begin VB.CheckBox chkDecalin 
            Caption         =   "脱钙任务声音提醒"
            Height          =   255
            Left            =   480
            TabIndex        =   19
            ToolTipText     =   "当脱钙时间到了会有声音提示。"
            Top             =   1320
            Width           =   1815
         End
         Begin VB.Label Label3 
            Caption         =   "提醒间隔时长：      秒"
            Height          =   255
            Left            =   960
            TabIndex        =   22
            Top             =   1635
            Width           =   2055
         End
      End
      Begin VB.CommandButton CmdDevSet 
         Caption         =   "设备配置(&S)"
         Height          =   350
         Left            =   1440
         TabIndex        =   16
         Top             =   6030
         Width           =   1170
      End
      Begin VB.CheckBox ChkOpenReport 
         Caption         =   "开始检查后自动打开报告窗口"
         Height          =   255
         Left            =   3840
         TabIndex        =   15
         ToolTipText     =   "在报到后自动打开报告窗口。"
         Top             =   1680
         Width           =   2640
      End
      Begin VB.CommandButton CmdCancel 
         Caption         =   "取消(&C)"
         Height          =   350
         Left            =   5355
         TabIndex        =   14
         Top             =   6030
         Width           =   1100
      End
      Begin VB.CommandButton cmdOK 
         Caption         =   "确定(&O)"
         Height          =   350
         Left            =   4095
         TabIndex        =   13
         Top             =   6030
         Width           =   1100
      End
      Begin VB.CommandButton cmdHelp 
         Caption         =   "帮助(&H)"
         Height          =   350
         Left            =   180
         TabIndex        =   12
         TabStop         =   0   'False
         Top             =   6030
         Width           =   1100
      End
      Begin VB.CheckBox chkPrintFormatChoose 
         Caption         =   "报到打印前选择格式"
         Enabled         =   0   'False
         Height          =   255
         Left            =   3840
         TabIndex        =   11
         ToolTipText     =   "报到打印前在多份打印格式中选择需要打印的格式。"
         Top             =   2720
         Width           =   2640
      End
      Begin VB.CheckBox chkBatchInput 
         Caption         =   "连续输入申请"
         Height          =   255
         Left            =   3840
         TabIndex        =   10
         ToolTipText     =   "允许连续登记。"
         Top             =   1160
         Width           =   2640
      End
      Begin VB.CheckBox chkView 
         Caption         =   "填写报告时打开观片站"
         Height          =   255
         Left            =   3840
         TabIndex        =   9
         ToolTipText     =   "打开报告书写窗口时自动打开观片站。"
         Top             =   2200
         Width           =   2280
      End
      Begin VB.Frame Frame6 
         Height          =   45
         Index           =   0
         Left            =   0
         TabIndex        =   8
         Top             =   5880
         Width           =   6595
      End
      Begin VB.CommandButton cmd3DSetup 
         Caption         =   "3D设置"
         Height          =   350
         Left            =   2760
         TabIndex        =   7
         Top             =   6030
         Visible         =   0   'False
         Width           =   1170
      End
      Begin VB.CheckBox chkAutoPrint 
         Caption         =   "报到后自动打印申请单"
         Height          =   255
         Left            =   3840
         TabIndex        =   6
         ToolTipText     =   "病人报到后自动打印申请单。"
         Top             =   120
         Width           =   2100
      End
      Begin VB.CheckBox chkExitAfterSign 
         Caption         =   "签名后退出"
         Height          =   255
         Left            =   3840
         TabIndex        =   5
         ToolTipText     =   "报告签名后自动退出报告书写。"
         Top             =   3240
         Width           =   1320
      End
      Begin VB.Frame Frame2 
         Caption         =   "登记模式"
         Height          =   1395
         Left            =   120
         TabIndex        =   2
         Top             =   3600
         Width           =   3615
         Begin VB.CheckBox chkPasv 
            Caption         =   "启用被动传输"
            Height          =   255
            Left            =   1320
            TabIndex        =   24
            Top             =   240
            Width           =   1380
         End
         Begin VB.CheckBox chkInputOutInfo 
            Caption         =   "录入外院信息"
            Height          =   255
            Left            =   1320
            TabIndex        =   23
            ToolTipText     =   "在登记窗口录入送检单位和送检医生。"
            Top             =   550
            Visible         =   0   'False
            Width           =   1590
         End
         Begin VB.OptionButton optCheckInMode 
            Caption         =   "精简模式"
            Height          =   255
            Index           =   1
            Left            =   135
            TabIndex        =   4
            ToolTipText     =   "只显示和录入必要项目。"
            Top             =   240
            Width           =   1095
         End
         Begin VB.OptionButton optCheckInMode 
            Caption         =   "正常模式"
            Height          =   180
            Index           =   2
            Left            =   135
            TabIndex        =   3
            ToolTipText     =   "显示和录入全部项目。"
            Top             =   570
            Value           =   -1  'True
            Width           =   1095
         End
      End
      Begin VB.ComboBox cbxMainPage 
         Height          =   300
         ItemData        =   "frmTechnicSetup.frx":000C
         Left            =   3840
         List            =   "frmTechnicSetup.frx":000E
         TabIndex        =   1
         Top             =   3840
         Width           =   2655
      End
      Begin MSComDlg.CommonDialog dlgFont 
         Left            =   0
         Top             =   0
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         Caption         =   "主要工作页面："
         Height          =   180
         Left            =   3840
         TabIndex        =   17
         Top             =   3600
         Width           =   1260
      End
   End
End
Attribute VB_Name = "frmTechnicSetup"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit '要求变量声明

Public mlng科室ID As Long 'IN:当前执行科室ID
Public mblnOk As Boolean
Public mlngModul As Long
Public mstrPrivs As String '模块权限

Private Sub chkAutoPrint_Click()
    chkPrintFormatChoose.Enabled = chkAutoPrint.value = 1
End Sub

Private Sub cmd3DSetup_Click()
    frm3DSetup.ShowMe Me, mstrPrivs
End Sub

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub CmdDevSet_Click()
    Call zlCommFun.DeviceSetup(Me, 100, 1101)
End Sub

Private Sub CmdHelp_Click()
    ShowHelp App.ProductName, Me.hwnd, Me.Name
End Sub

Private Sub cmdOk_Click()
On Error GoTo errhandle
    Dim strPar As String, i As Long
    '计数变量
    Dim GrossNum As Long, NormalNum As Long, ImmuneNum As Long, SpecialNum As Long, MoleculeNum As Long
    Dim strSQL As String
    Dim rsExpression As ADODB.Recordset
    

    zlDatabase.SetPara "工作首页", cbxMainPage.Text, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0

    zlDatabase.SetPara "报告时观片", chkView.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    zlDatabase.SetPara "连续登记申请", chkBatchInput.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    zlDatabase.SetPara "报到打印前选择格式", chkPrintFormatChoose.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    
    zlDatabase.SetPara "开始检查自动打开报告", ChkOpenReport.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    'zlDatabase.SetPara "不显示造影剂", chkReagent.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    'zlDatabase.SetPara "不显示附加主述", chkAddons.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    'zlDatabase.SetPara "录入外院信息", chkInputOutInfo.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    zlDatabase.SetPara "登记模式", IIf(optCheckInMode(1).value = True, 1, 2), glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    zlDatabase.SetPara "报到后自动打印申请单", chkAutoPrint.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    zlDatabase.SetPara "自动规避重复申请打印", chkPrintCheck.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    
    
    SaveSetting "ZLSOFT", "公共模块\ZL9PACSWork\frmTechnicSetup", "启用被动传输", IIf(chkPasv.value = 1, 1, 0)
    Call zlDatabase.SetPara("PACS报告签名后退出", chkExitAfterSign.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0)
    
    Call zlDatabase.SetPara("XW历史图像共享目录", txtImageShare.Text, glngSys, G_LNG_XWPACSVIEW_MODULE)
    
    Call zlDatabase.SetPara("XW记录接口日志", chkLog.value, glngSys, G_LNG_XWPACSVIEW_MODULE)

    If mlngModul = G_LNG_PATHOLSYS_NUM Then
        '保存病理系统相关参数
        zlDatabase.SetPara "脱钙声音提醒", chkDecalin.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
        zlDatabase.SetPara "提醒间隔时长", txtDecalinHintTime.Text, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0

        '保存是否直接打印设置
        zlDatabase.SetPara "是否直接打印", chkIsDirectPrint.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
        
    End If
    
    zlDatabase.SetPara "图像校对", chkValid.value, glngSys, mlngModul, InStr(mstrPrivs, ";参数设置;") > 0
    
    mblnOk = True
    Unload Me
    
Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyF1 Then
        Call CmdHelp_Click
    ElseIf KeyCode = vbKeyEscape Then
        Unload Me
    End If
End Sub

Private Sub InitFaceScheme()
    Dim Item As TabControlItem
    
    If mlngModul = 1290 And InStr(mstrPrivs, "三维重建设置") <> 0 Then
        cmd3DSetup.Visible = True
    Else
        cmd3DSetup.Visible = False
    End If
    
    
    '如果是病理系统，则不进行执行间的设置
    If mlngModul = G_LNG_PATHOLSYS_NUM Then
        'chkReagent.Visible = False
        'chkInputOutInfo.Visible = False     '病理系统不进行登记外院送检单位和送检医生
    Else
        frmPatholParameter.Visible = False
    End If
End Sub


Private Sub Form_Load()
    InitFaceScheme
    mblnOk = False
    Dim intTemp As Integer
    Dim strTemp As String
    Dim i As Integer
    Dim blnChkVisible As Boolean
    
    chkPasv.ForeColor = &HFF0000
    
        
    '根据不同的工作站加载不同的 主要工作页面 参数
    Select Case mlngModul

        Case 1290 '医技工作站
            cbxMainPage.Clear
            cbxMainPage.AddItem ("")
            cbxMainPage.AddItem ("影像")
            cbxMainPage.AddItem ("报告")
            cbxMainPage.AddItem ("费用")
            cbxMainPage.AddItem ("医嘱")
            cbxMainPage.AddItem ("病历")
            'chkPasv.Left = optCheckInMode(2).Left
            'chkPasv.Top = optCheckInMode(2).Top + 300
        Case 1291 '采集工作站
            cbxMainPage.Clear
            cbxMainPage.AddItem ("")
            cbxMainPage.AddItem ("采集")
            cbxMainPage.AddItem ("报告")
            cbxMainPage.AddItem ("费用")
            cbxMainPage.AddItem ("医嘱")
            cbxMainPage.AddItem ("病历")
            'chkPasv.Left = optCheckInMode(2).Left
            'chkPasv.Top = optCheckInMode(2).Top + 300
            
        Case 1294 '病理工作站
            cbxMainPage.Clear
            cbxMainPage.AddItem ("")
            cbxMainPage.AddItem ("采集")
            cbxMainPage.AddItem ("核收")
            cbxMainPage.AddItem ("取材")
            cbxMainPage.AddItem ("制片")
            cbxMainPage.AddItem ("特殊")
            cbxMainPage.AddItem ("诊断")
            cbxMainPage.AddItem ("报告")
            cbxMainPage.AddItem ("费用")
            cbxMainPage.AddItem ("医嘱")
            cbxMainPage.AddItem ("病历")
            'chkPasv.Left = optCheckInMode(1).Left + 1575
            'chkPasv.Top = optCheckInMode(1).Top
    End Select
    
    CmdDevSet.Enabled = InStr(mstrPrivs, ";参数设置;") > 0
    CmdOK.Enabled = InStr(mstrPrivs, ";参数设置;") > 0
    chkView.value = Val(zlDatabase.GetPara("报告时观片", glngSys, mlngModul, 0, Array(chkView), InStr(mstrPrivs, ";参数设置;") > 0))
    chkPasv.value = IIf(Val(GetSetting("ZLSOFT", "公共模块\ZL9PACSWork\frmTechnicSetup", "启用被动传输", 0)) = 1, 1, 0)
    chkBatchInput.value = Val(zlDatabase.GetPara("连续登记申请", glngSys, mlngModul, 0, Array(chkBatchInput), InStr(mstrPrivs, ";参数设置;") > 0))
    chkPrintFormatChoose.value = Val(zlDatabase.GetPara("报到打印前选择格式", glngSys, mlngModul, 0, Array(chkPrintFormatChoose), InStr(mstrPrivs, ";参数设置;") > 0))
    ChkOpenReport.value = Val(zlDatabase.GetPara("开始检查自动打开报告", glngSys, mlngModul, 0, Array(ChkOpenReport), InStr(mstrPrivs, ";参数设置;") > 0))
'    chkReagent.value = Val(zlDatabase.GetPara("不显示造影剂", glngSys, mlngModul, 0, Array(chkReagent), InStr(mstrPrivs, ";参数设置;") > 0))
'    chkAddons.value = Val(zlDatabase.GetPara("不显示附加主述", glngSys, mlngModul, 0, Array(chkAddons), InStr(mstrPrivs, ";参数设置;") > 0))
'    chkInputOutInfo.value = Val(zlDatabase.GetPara("录入外院信息", glngSys, mlngModul, 0, Array(chkInputOutInfo), InStr(mstrPrivs, ";参数设置;") > 0))
    intTemp = Val(zlDatabase.GetPara("登记模式", glngSys, mlngModul, 0, Array(optCheckInMode(1)), InStr(mstrPrivs, ";参数设置;") > 0))
    intTemp = Val(zlDatabase.GetPara("登记模式", glngSys, mlngModul, 0, Array(optCheckInMode(2)), InStr(mstrPrivs, ";参数设置;") > 0))
    If intTemp = 1 Then
        optCheckInMode(1).value = True
    Else
        optCheckInMode(2).value = True
    End If

    chkAutoPrint.value = Val(zlDatabase.GetPara("报到后自动打印申请单", glngSys, mlngModul, 0, Array(chkAutoPrint), InStr(mstrPrivs, ";参数设置;") > 0))
    chkPrintCheck.value = Val(zlDatabase.GetPara("自动规避重复申请打印", glngSys, mlngModul, 1, Array(chkPrintCheck), InStr(mstrPrivs, ";参数设置;") > 0))
    
    chkExitAfterSign.value = Val(zlDatabase.GetPara("PACS报告签名后退出", glngSys, mlngModul, "1", Array(chkExitAfterSign), InStr(mstrPrivs, ";参数设置;") > 0))
    cbxMainPage.Text = zlDatabase.GetPara("工作首页", glngSys, mlngModul, "", Array(cbxMainPage), InStr(mstrPrivs, ";参数设置;") > 0)
    
    txtImageShare = zlDatabase.GetPara("XW历史图像共享目录", glngSys, G_LNG_XWPACSVIEW_MODULE, "DCMSHARE")
    
    chkLog.value = IIf(Val(zlDatabase.GetPara("XW记录接口日志", glngSys, G_LNG_XWPACSVIEW_MODULE, "0")) = 1, 1, 0)
    
    If mlngModul = G_LNG_PATHOLSYS_NUM Then
        chkDecalin.value = Val(zlDatabase.GetPara("脱钙声音提醒", glngSys, mlngModul, 1, Array(chkDecalin), InStr(mstrPrivs, ";参数设置;") > 0))
        txtDecalinHintTime.Text = Val(zlDatabase.GetPara("提醒间隔时长", glngSys, mlngModul, "30", Array(txtDecalinHintTime), InStr(mstrPrivs, ";参数设置;") > 0))

        '读取是否直接打印参数信息
        chkIsDirectPrint.value = Val(zlDatabase.GetPara("是否直接打印", glngSys, mlngModul, 0, Array(chkIsDirectPrint), InStr(mstrPrivs, ";参数设置;") > 0))
        
        chkPrintCheck.Enabled = False
    End If

    chkValid.value = Val(zlDatabase.GetPara("图像校对", glngSys, mlngModul, "", , InStr(mstrPrivs, ";参数设置;") > 0))

    Call ResizeFace
End Sub

Private Sub Form_Unload(Cancel As Integer)
    mlng科室ID = 0
End Sub

Private Sub TxtLike_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub TxtShowPhotoNumber_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub
Private Sub Txt默认天数_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub ResizeFace()
    On Error Resume Next
    If mlngModul <> G_LNG_PATHOLSYS_NUM Then
        chkAutoPrint.Left = 240
        chkAutoPrint.Top = 120
        
        chkPrintCheck.Top = chkAutoPrint.Top
        
        chkPrintFormatChoose.Left = 240
        chkPrintFormatChoose.Top = chkAutoPrint.Top + chkAutoPrint.Height + 120

        chkBatchInput.Top = chkPrintFormatChoose.Top
        
        ChkOpenReport.Left = 240
        ChkOpenReport.Top = chkPrintFormatChoose.Top + chkPrintFormatChoose.Height + 120
        
        chkView.Top = ChkOpenReport.Top
        
        chkExitAfterSign.Left = 240
        chkExitAfterSign.Top = ChkOpenReport.Top + ChkOpenReport.Height + 120
        
        Load Frame6(1)
        With Frame6(1)
            .Left = Frame6(0).Left
            .Top = chkExitAfterSign.Top + chkExitAfterSign.Height + 120
            .Width = Frame6(0).Width
            .Height = 25
            
            .Caption = ""
            .Visible = True
        End With
        
        Frame2.Top = Frame6(1).Top + Frame6(1).Height + 200

        Label2.Top = Frame6(1).Top + Frame6(1).Height + 150
        
        cbxMainPage.Top = Label2.Top + Label2.Height + 100
        
    End If
    
    fraValid.Top = Frame2.Top + Frame2.Height + 120
    fraValid.Left = Frame2.Left
    
'    If mlngModul = 1291 Then
'        Frame6(0).Top = Frame2.Top + Frame2.Height + 150
'    Else
        Frame6(0).Top = fraValid.Top + fraValid.Height + 150
'    End If
    
    If mlngModul = G_LNG_PACSSTATION_MODULE Then
        fraXwPacs.Left = cbxMainPage.Left
        fraXwPacs.Top = cbxMainPage.Top + cbxMainPage.Height
        fraXwPacs.Visible = True
    Else
        fraXwPacs.Visible = False
    End If
    
    
    
    cmdHelp.Top = Frame6(0).Top + Frame6(0).Height + 150
    CmdDevSet.Top = cmdHelp.Top
    cmd3DSetup.Top = cmdHelp.Top
    CmdOK.Top = cmdHelp.Top
    cmdCancel.Top = cmdHelp.Top
    
    PicAction.Height = cmdCancel.Top + cmdCancel.Height + 150
    Me.Height = PicAction.Top + PicAction.Height + 600
    
End Sub
