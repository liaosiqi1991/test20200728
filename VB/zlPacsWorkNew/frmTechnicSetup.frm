VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form frmTechnicSetup 
   AutoRedraw      =   -1  'True
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "��������"
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
   StartUpPosition =   1  '����������
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
         Caption         =   "�Զ�����ظ���ӡ���뵥"
         Height          =   255
         Left            =   3840
         TabIndex        =   31
         Top             =   640
         Width           =   2535
      End
      Begin VB.Frame fraValid 
         Caption         =   "ͼ��У��"
         Height          =   800
         Left            =   120
         TabIndex        =   29
         Top             =   5040
         Width           =   6375
         Begin VB.CheckBox chkValid 
            Caption         =   "��Ӱ����վʱ�Զ�У��ǰһ���ͼ��"
            Height          =   375
            Left            =   240
            TabIndex        =   30
            ToolTipText     =   "�򿪹���վʱ�Զ�У��"
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
            Caption         =   "��¼��־"
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
            Caption         =   "��ʷͼ����Ŀ¼"
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
            Caption         =   "�Ƿ�ֱ�Ӵ�ӡ"
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
            Caption         =   "�Ѹ�������������"
            Height          =   255
            Left            =   480
            TabIndex        =   19
            ToolTipText     =   "���Ѹ�ʱ�䵽�˻���������ʾ��"
            Top             =   1320
            Width           =   1815
         End
         Begin VB.Label Label3 
            Caption         =   "���Ѽ��ʱ����      ��"
            Height          =   255
            Left            =   960
            TabIndex        =   22
            Top             =   1635
            Width           =   2055
         End
      End
      Begin VB.CommandButton CmdDevSet 
         Caption         =   "�豸����(&S)"
         Height          =   350
         Left            =   1440
         TabIndex        =   16
         Top             =   6030
         Width           =   1170
      End
      Begin VB.CheckBox ChkOpenReport 
         Caption         =   "��ʼ�����Զ��򿪱��洰��"
         Height          =   255
         Left            =   3840
         TabIndex        =   15
         ToolTipText     =   "�ڱ������Զ��򿪱��洰�ڡ�"
         Top             =   1680
         Width           =   2640
      End
      Begin VB.CommandButton CmdCancel 
         Caption         =   "ȡ��(&C)"
         Height          =   350
         Left            =   5355
         TabIndex        =   14
         Top             =   6030
         Width           =   1100
      End
      Begin VB.CommandButton cmdOK 
         Caption         =   "ȷ��(&O)"
         Height          =   350
         Left            =   4095
         TabIndex        =   13
         Top             =   6030
         Width           =   1100
      End
      Begin VB.CommandButton cmdHelp 
         Caption         =   "����(&H)"
         Height          =   350
         Left            =   180
         TabIndex        =   12
         TabStop         =   0   'False
         Top             =   6030
         Width           =   1100
      End
      Begin VB.CheckBox chkPrintFormatChoose 
         Caption         =   "������ӡǰѡ���ʽ"
         Enabled         =   0   'False
         Height          =   255
         Left            =   3840
         TabIndex        =   11
         ToolTipText     =   "������ӡǰ�ڶ�ݴ�ӡ��ʽ��ѡ����Ҫ��ӡ�ĸ�ʽ��"
         Top             =   2720
         Width           =   2640
      End
      Begin VB.CheckBox chkBatchInput 
         Caption         =   "������������"
         Height          =   255
         Left            =   3840
         TabIndex        =   10
         ToolTipText     =   "���������Ǽǡ�"
         Top             =   1160
         Width           =   2640
      End
      Begin VB.CheckBox chkView 
         Caption         =   "��д����ʱ�򿪹�Ƭվ"
         Height          =   255
         Left            =   3840
         TabIndex        =   9
         ToolTipText     =   "�򿪱�����д����ʱ�Զ��򿪹�Ƭվ��"
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
         Caption         =   "3D����"
         Height          =   350
         Left            =   2760
         TabIndex        =   7
         Top             =   6030
         Visible         =   0   'False
         Width           =   1170
      End
      Begin VB.CheckBox chkAutoPrint 
         Caption         =   "�������Զ���ӡ���뵥"
         Height          =   255
         Left            =   3840
         TabIndex        =   6
         ToolTipText     =   "���˱������Զ���ӡ���뵥��"
         Top             =   120
         Width           =   2100
      End
      Begin VB.CheckBox chkExitAfterSign 
         Caption         =   "ǩ�����˳�"
         Height          =   255
         Left            =   3840
         TabIndex        =   5
         ToolTipText     =   "����ǩ�����Զ��˳�������д��"
         Top             =   3240
         Width           =   1320
      End
      Begin VB.Frame Frame2 
         Caption         =   "�Ǽ�ģʽ"
         Height          =   1395
         Left            =   120
         TabIndex        =   2
         Top             =   3600
         Width           =   3615
         Begin VB.CheckBox chkPasv 
            Caption         =   "���ñ�������"
            Height          =   255
            Left            =   1320
            TabIndex        =   24
            Top             =   240
            Width           =   1380
         End
         Begin VB.CheckBox chkInputOutInfo 
            Caption         =   "¼����Ժ��Ϣ"
            Height          =   255
            Left            =   1320
            TabIndex        =   23
            ToolTipText     =   "�ڵǼǴ���¼���ͼ쵥λ���ͼ�ҽ����"
            Top             =   550
            Visible         =   0   'False
            Width           =   1590
         End
         Begin VB.OptionButton optCheckInMode 
            Caption         =   "����ģʽ"
            Height          =   255
            Index           =   1
            Left            =   135
            TabIndex        =   4
            ToolTipText     =   "ֻ��ʾ��¼���Ҫ��Ŀ��"
            Top             =   240
            Width           =   1095
         End
         Begin VB.OptionButton optCheckInMode 
            Caption         =   "����ģʽ"
            Height          =   180
            Index           =   2
            Left            =   135
            TabIndex        =   3
            ToolTipText     =   "��ʾ��¼��ȫ����Ŀ��"
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
         Caption         =   "��Ҫ����ҳ�棺"
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
Option Explicit 'Ҫ���������

Public mlng����ID As Long 'IN:��ǰִ�п���ID
Public mblnOk As Boolean
Public mlngModul As Long
Public mstrPrivs As String 'ģ��Ȩ��

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
    '��������
    Dim GrossNum As Long, NormalNum As Long, ImmuneNum As Long, SpecialNum As Long, MoleculeNum As Long
    Dim strSQL As String
    Dim rsExpression As ADODB.Recordset
    

    zlDatabase.SetPara "������ҳ", cbxMainPage.Text, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0

    zlDatabase.SetPara "����ʱ��Ƭ", chkView.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    zlDatabase.SetPara "�����Ǽ�����", chkBatchInput.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    zlDatabase.SetPara "������ӡǰѡ���ʽ", chkPrintFormatChoose.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    
    zlDatabase.SetPara "��ʼ����Զ��򿪱���", ChkOpenReport.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    'zlDatabase.SetPara "����ʾ��Ӱ��", chkReagent.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    'zlDatabase.SetPara "����ʾ��������", chkAddons.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    'zlDatabase.SetPara "¼����Ժ��Ϣ", chkInputOutInfo.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    zlDatabase.SetPara "�Ǽ�ģʽ", IIf(optCheckInMode(1).value = True, 1, 2), glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    zlDatabase.SetPara "�������Զ���ӡ���뵥", chkAutoPrint.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    zlDatabase.SetPara "�Զ�����ظ������ӡ", chkPrintCheck.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    
    
    SaveSetting "ZLSOFT", "����ģ��\ZL9PACSWork\frmTechnicSetup", "���ñ�������", IIf(chkPasv.value = 1, 1, 0)
    Call zlDatabase.SetPara("PACS����ǩ�����˳�", chkExitAfterSign.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0)
    
    Call zlDatabase.SetPara("XW��ʷͼ����Ŀ¼", txtImageShare.Text, glngSys, G_LNG_XWPACSVIEW_MODULE)
    
    Call zlDatabase.SetPara("XW��¼�ӿ���־", chkLog.value, glngSys, G_LNG_XWPACSVIEW_MODULE)

    If mlngModul = G_LNG_PATHOLSYS_NUM Then
        '���没��ϵͳ��ز���
        zlDatabase.SetPara "�Ѹ���������", chkDecalin.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
        zlDatabase.SetPara "���Ѽ��ʱ��", txtDecalinHintTime.Text, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0

        '�����Ƿ�ֱ�Ӵ�ӡ����
        zlDatabase.SetPara "�Ƿ�ֱ�Ӵ�ӡ", chkIsDirectPrint.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
        
    End If
    
    zlDatabase.SetPara "ͼ��У��", chkValid.value, glngSys, mlngModul, InStr(mstrPrivs, ";��������;") > 0
    
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
    
    If mlngModul = 1290 And InStr(mstrPrivs, "��ά�ؽ�����") <> 0 Then
        cmd3DSetup.Visible = True
    Else
        cmd3DSetup.Visible = False
    End If
    
    
    '����ǲ���ϵͳ���򲻽���ִ�м������
    If mlngModul = G_LNG_PATHOLSYS_NUM Then
        'chkReagent.Visible = False
        'chkInputOutInfo.Visible = False     '����ϵͳ�����еǼ���Ժ�ͼ쵥λ���ͼ�ҽ��
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
    
        
    '���ݲ�ͬ�Ĺ���վ���ز�ͬ�� ��Ҫ����ҳ�� ����
    Select Case mlngModul

        Case 1290 'ҽ������վ
            cbxMainPage.Clear
            cbxMainPage.AddItem ("")
            cbxMainPage.AddItem ("Ӱ��")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("ҽ��")
            cbxMainPage.AddItem ("����")
            'chkPasv.Left = optCheckInMode(2).Left
            'chkPasv.Top = optCheckInMode(2).Top + 300
        Case 1291 '�ɼ�����վ
            cbxMainPage.Clear
            cbxMainPage.AddItem ("")
            cbxMainPage.AddItem ("�ɼ�")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("ҽ��")
            cbxMainPage.AddItem ("����")
            'chkPasv.Left = optCheckInMode(2).Left
            'chkPasv.Top = optCheckInMode(2).Top + 300
            
        Case 1294 '��������վ
            cbxMainPage.Clear
            cbxMainPage.AddItem ("")
            cbxMainPage.AddItem ("�ɼ�")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("ȡ��")
            cbxMainPage.AddItem ("��Ƭ")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("���")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("����")
            cbxMainPage.AddItem ("ҽ��")
            cbxMainPage.AddItem ("����")
            'chkPasv.Left = optCheckInMode(1).Left + 1575
            'chkPasv.Top = optCheckInMode(1).Top
    End Select
    
    CmdDevSet.Enabled = InStr(mstrPrivs, ";��������;") > 0
    CmdOK.Enabled = InStr(mstrPrivs, ";��������;") > 0
    chkView.value = Val(zlDatabase.GetPara("����ʱ��Ƭ", glngSys, mlngModul, 0, Array(chkView), InStr(mstrPrivs, ";��������;") > 0))
    chkPasv.value = IIf(Val(GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork\frmTechnicSetup", "���ñ�������", 0)) = 1, 1, 0)
    chkBatchInput.value = Val(zlDatabase.GetPara("�����Ǽ�����", glngSys, mlngModul, 0, Array(chkBatchInput), InStr(mstrPrivs, ";��������;") > 0))
    chkPrintFormatChoose.value = Val(zlDatabase.GetPara("������ӡǰѡ���ʽ", glngSys, mlngModul, 0, Array(chkPrintFormatChoose), InStr(mstrPrivs, ";��������;") > 0))
    ChkOpenReport.value = Val(zlDatabase.GetPara("��ʼ����Զ��򿪱���", glngSys, mlngModul, 0, Array(ChkOpenReport), InStr(mstrPrivs, ";��������;") > 0))
'    chkReagent.value = Val(zlDatabase.GetPara("����ʾ��Ӱ��", glngSys, mlngModul, 0, Array(chkReagent), InStr(mstrPrivs, ";��������;") > 0))
'    chkAddons.value = Val(zlDatabase.GetPara("����ʾ��������", glngSys, mlngModul, 0, Array(chkAddons), InStr(mstrPrivs, ";��������;") > 0))
'    chkInputOutInfo.value = Val(zlDatabase.GetPara("¼����Ժ��Ϣ", glngSys, mlngModul, 0, Array(chkInputOutInfo), InStr(mstrPrivs, ";��������;") > 0))
    intTemp = Val(zlDatabase.GetPara("�Ǽ�ģʽ", glngSys, mlngModul, 0, Array(optCheckInMode(1)), InStr(mstrPrivs, ";��������;") > 0))
    intTemp = Val(zlDatabase.GetPara("�Ǽ�ģʽ", glngSys, mlngModul, 0, Array(optCheckInMode(2)), InStr(mstrPrivs, ";��������;") > 0))
    If intTemp = 1 Then
        optCheckInMode(1).value = True
    Else
        optCheckInMode(2).value = True
    End If

    chkAutoPrint.value = Val(zlDatabase.GetPara("�������Զ���ӡ���뵥", glngSys, mlngModul, 0, Array(chkAutoPrint), InStr(mstrPrivs, ";��������;") > 0))
    chkPrintCheck.value = Val(zlDatabase.GetPara("�Զ�����ظ������ӡ", glngSys, mlngModul, 1, Array(chkPrintCheck), InStr(mstrPrivs, ";��������;") > 0))
    
    chkExitAfterSign.value = Val(zlDatabase.GetPara("PACS����ǩ�����˳�", glngSys, mlngModul, "1", Array(chkExitAfterSign), InStr(mstrPrivs, ";��������;") > 0))
    cbxMainPage.Text = zlDatabase.GetPara("������ҳ", glngSys, mlngModul, "", Array(cbxMainPage), InStr(mstrPrivs, ";��������;") > 0)
    
    txtImageShare = zlDatabase.GetPara("XW��ʷͼ����Ŀ¼", glngSys, G_LNG_XWPACSVIEW_MODULE, "DCMSHARE")
    
    chkLog.value = IIf(Val(zlDatabase.GetPara("XW��¼�ӿ���־", glngSys, G_LNG_XWPACSVIEW_MODULE, "0")) = 1, 1, 0)
    
    If mlngModul = G_LNG_PATHOLSYS_NUM Then
        chkDecalin.value = Val(zlDatabase.GetPara("�Ѹ���������", glngSys, mlngModul, 1, Array(chkDecalin), InStr(mstrPrivs, ";��������;") > 0))
        txtDecalinHintTime.Text = Val(zlDatabase.GetPara("���Ѽ��ʱ��", glngSys, mlngModul, "30", Array(txtDecalinHintTime), InStr(mstrPrivs, ";��������;") > 0))

        '��ȡ�Ƿ�ֱ�Ӵ�ӡ������Ϣ
        chkIsDirectPrint.value = Val(zlDatabase.GetPara("�Ƿ�ֱ�Ӵ�ӡ", glngSys, mlngModul, 0, Array(chkIsDirectPrint), InStr(mstrPrivs, ";��������;") > 0))
        
        chkPrintCheck.Enabled = False
    End If

    chkValid.value = Val(zlDatabase.GetPara("ͼ��У��", glngSys, mlngModul, "", , InStr(mstrPrivs, ";��������;") > 0))

    Call ResizeFace
End Sub

Private Sub Form_Unload(Cancel As Integer)
    mlng����ID = 0
End Sub

Private Sub TxtLike_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub TxtShowPhotoNumber_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub
Private Sub TxtĬ������_KeyPress(KeyAscii As Integer)
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