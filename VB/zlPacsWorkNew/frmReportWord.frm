VERSION 5.00
Object = "{945E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.DockingPane.9600.ocx"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmReportWord 
   Caption         =   "�ʾ�ʾ��"
   ClientHeight    =   8100
   ClientLeft      =   165
   ClientTop       =   855
   ClientWidth     =   9270
   Icon            =   "frmReportWord.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   ScaleHeight     =   8100
   ScaleWidth      =   9270
   StartUpPosition =   3  '����ȱʡ
   Begin VB.PictureBox picCommandButton 
      Appearance      =   0  'Flat
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   1935
      Left            =   1800
      ScaleHeight     =   1935
      ScaleWidth      =   4935
      TabIndex        =   10
      Top             =   6000
      Width           =   4935
      Begin VB.CommandButton cmdSure 
         Caption         =   "ȷ ��(&S)"
         Height          =   350
         Left            =   2040
         TabIndex        =   13
         Top             =   1560
         Width           =   1100
      End
      Begin VB.CommandButton cmdClose 
         Caption         =   "ȡ ��(&C)"
         Height          =   350
         Left            =   3600
         TabIndex        =   11
         Top             =   1560
         Width           =   1100
      End
      Begin RichTextLib.RichTextBox rtbEditWord 
         Height          =   975
         Left            =   360
         TabIndex        =   12
         Top             =   0
         Width           =   2775
         _ExtentX        =   4895
         _ExtentY        =   1720
         _Version        =   393217
         BorderStyle     =   0
         Enabled         =   -1  'True
         ScrollBars      =   2
         Appearance      =   0
         AutoVerbMenu    =   -1  'True
         TextRTF         =   $"frmReportWord.frx":0CCA
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
      End
   End
   Begin VB.PictureBox picPrivateWord 
      Height          =   1575
      Left            =   4920
      ScaleHeight     =   1515
      ScaleWidth      =   3675
      TabIndex        =   8
      Top             =   3720
      Visible         =   0   'False
      Width           =   3735
      Begin RichTextLib.RichTextBox rtxtPrivateWord 
         Height          =   975
         Left            =   0
         TabIndex        =   9
         ToolTipText     =   "˫������༭״̬����˫�������޸�"
         Top             =   0
         Width           =   3375
         _ExtentX        =   5953
         _ExtentY        =   1720
         _Version        =   393217
         BorderStyle     =   0
         Enabled         =   -1  'True
         ScrollBars      =   2
         Appearance      =   0
         TextRTF         =   $"frmReportWord.frx":0D67
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
      End
   End
   Begin VB.PictureBox picWordTree 
      Height          =   2655
      Left            =   240
      ScaleHeight     =   2595
      ScaleWidth      =   3795
      TabIndex        =   5
      Top             =   0
      Width           =   3855
      Begin VB.CheckBox ChkAutoExpand 
         Caption         =   "�Զ�չ��"
         Height          =   255
         Left            =   1800
         TabIndex        =   15
         ToolTipText     =   "���شʾ�ʱ�Զ�չ��һ��Ŀ¼"
         Top             =   360
         Width           =   1215
      End
      Begin VB.CheckBox chk�������� 
         Caption         =   "��������������"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   360
         Width           =   1695
      End
      Begin MSComctlLib.TreeView trvWordTree 
         Height          =   1935
         Left            =   120
         TabIndex        =   7
         Top             =   720
         Width           =   3495
         _ExtentX        =   6165
         _ExtentY        =   3413
         _Version        =   393217
         Indentation     =   176
         Style           =   7
         Appearance      =   1
      End
      Begin VB.CheckBox chkֱ�ӱ༭ 
         Caption         =   "ֱ�ӱ༭"
         Height          =   255
         Left            =   120
         TabIndex        =   14
         Top             =   120
         Width           =   1095
      End
   End
   Begin VB.PictureBox picWordShow 
      AutoSize        =   -1  'True
      Height          =   3135
      Left            =   240
      ScaleHeight     =   3075
      ScaleWidth      =   4395
      TabIndex        =   0
      Top             =   2760
      Width           =   4455
      Begin VB.PictureBox picWordContainer 
         BorderStyle     =   0  'None
         Height          =   2295
         Left            =   120
         ScaleHeight     =   2295
         ScaleWidth      =   3495
         TabIndex        =   2
         Top             =   240
         Width           =   3495
         Begin VB.CommandButton cmdSelect 
            Height          =   375
            Index           =   0
            Left            =   0
            Picture         =   "frmReportWord.frx":0DFF
            Style           =   1  'Graphical
            TabIndex        =   3
            TabStop         =   0   'False
            ToolTipText     =   "д�뱨��"
            Top             =   0
            Visible         =   0   'False
            Width           =   375
         End
         Begin RichTextLib.RichTextBox rtxtWord 
            Height          =   975
            Index           =   0
            Left            =   480
            TabIndex        =   4
            TabStop         =   0   'False
            Top             =   0
            Visible         =   0   'False
            Width           =   3015
            _ExtentX        =   5318
            _ExtentY        =   1720
            _Version        =   393217
            ScrollBars      =   2
            Appearance      =   0
            TextRTF         =   $"frmReportWord.frx":1389
         End
      End
      Begin VB.VScrollBar vscroWordH 
         Height          =   1215
         Left            =   3720
         Max             =   500
         TabIndex        =   1
         Top             =   1440
         Value           =   200
         Width           =   250
      End
   End
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   4920
      Top             =   1200
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   2
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmReportWord.frx":1426
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmReportWord.frx":1B20
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin XtremeDockingPane.DockingPane dkpMain 
      Left            =   5040
      Top             =   480
      _Version        =   589884
      _ExtentX        =   450
      _ExtentY        =   423
      _StockProps     =   0
   End
   Begin VB.Menu menuPopup 
      Caption         =   "�����˵�"
      Visible         =   0   'False
      Begin VB.Menu menuAddWord 
         Caption         =   "�����ʾ�"
      End
      Begin VB.Menu menuModifyWord 
         Caption         =   "�޸Ĵʾ�"
      End
      Begin VB.Menu menuDeleteWord 
         Caption         =   "ɾ���ʾ�"
      End
      Begin VB.Menu menuSplit 
         Caption         =   "-"
      End
      Begin VB.Menu menuSaveAllWord 
         Caption         =   "ȫ�״���"
      End
   End
   Begin VB.Menu menuPriWordPopup 
      Caption         =   "���ôʾ䵯���˵�"
      Begin VB.Menu menuInsertPriWord 
         Caption         =   "���뱨��"
      End
   End
End
Attribute VB_Name = "frmReportWord"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Const LVW_KEY_WORD As String = "L"  ' ���οؼ���Ŀ
Private Const LVW_KEY_TYPE As String = "T"   ' ���οؼ�Ŀ¼

Private mpreWinProc As Long
Private mFileID As Long                 '����ID
Private mstrReportViewType As String    '�ʾ�ʾ���������ͣ� ����������������������������顱��
Private mlngAdviceID As Long            'ҽ��ID
Private mdbOwner As String              '���ݿ�������
Private mlngDeptID As Long              '����ID
Public mblnSingleWindow As Boolean     '�Ƿ�ʹ�ö���������ʾ����༭����True-����������ʾ��False-Ƕ��ʽ��ʾ
Public mblnShowWord As Boolean         '��ʾ�ʾ�ʾ����True--��ʾ�ʾ�ʾ����False--˫���������ʾ�ʾ�ʾ��
Private mlngModul As Long               'ģ���
Private mintWordDblClick As Integer     '�ʾ�˫����Ĳ�����0--ֱ��д�뱨�棻1--�򿪴ʾ�༭����
Private mintWordPower As Integer        '�ʾ����Ȩ��Χ
Private mstrReportViewTypeAlias As String

Private intFontSize As Integer          '��¼�����С
Private objNode As MSComctlLib.Node     '��¼ѡ��Ĵʾ�ڵ�

Private mblnEditable As Boolean         '�Ƿ���Ա༭����

Private mlngWordTreeH As Long               '�ʿ�ģ�����ĸ߶�
Private mlngWordShowH As Long               '�ʿ�ģ�����ݵĸ߶�
Private mlngPrivateWordH As Long            '˽�˳��ôʾ�ĸ߶�
Private mlngButtonH As Long                 'ȷ����ȡ����ť����ĸ߶�

Private mPrivatePane As Pane                '˽�˳��ôʾ������ҳ��
Private mblnInitFaseScheme As Boolean       '��ʼ�����棬ִֻ��һ��

Private miWordScale As Integer

'��������¼�
Public Event WordSelected(strWord As String, strReportViewType As String, blnIsPopupWindInsert As Boolean, blnAddCrlf As Boolean) '�ʾ䱻ѡ��
Public Event AddSampleWord(ByVal blnIsAllWord As Boolean)     '�����ʾ�ʾ��
Public Event ModifySampleWord() '�޸Ĵʾ�ʾ��


Private Sub ChkAutoExpand_Click()
    If ChkAutoExpand.value = 1 Then
        Call LoadWordTree(mFileID, mstrReportViewType, True)
    End If
End Sub

Private Sub chk��������_Click()
    Call LoadWordTree(mFileID, mstrReportViewType, True)
End Sub

Private Sub chkֱ�ӱ༭_Click()
    If CBool(chkֱ�ӱ༭.value) Then
        mlngButtonH = Round(Me.Height / 4)
    End If
    
    Call InitFaceScheme
    
    
End Sub

Private Sub cmdClose_Click()
    Unload Me
End Sub

Private Sub cmdSelect_Click(Index As Integer)
    If Not mblnShowWord And CBool(chkֱ�ӱ༭.value) Then
        rtbEditWord.SelLength = 0
        rtbEditWord.SelText = rtxtWord(Index).Text & vbCrLf
    Else
        'д�뱨����տ�
        RaiseEvent WordSelected(rtxtWord(Index).Text, rtxtWord(Index).tag, False, True)
    End If
End Sub

Private Sub cmdSure_Click()
    'д�뱨����տ�
    RaiseEvent WordSelected(rtbEditWord.Text, mstrReportViewType, True, True)
    
    Unload Me
End Sub

Private Sub Form_Load()

    mdbOwner = GetDbOwner(glngSys)
    
    trvWordTree.ImageList = ImageList1
    chk��������.value = 1
    mstrReportViewType = ""
    mblnInitFaseScheme = False
    
    ''''''''''''''''''''''''''����������'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    If App.LogMode <> 0 Then
        Dim ret As Long
        Set mReport.fReport = Me
    '    '��¼ԭ����window�����ַ
        preWinProc = GetWindowLong(Me.hwnd, GWL_WNDPROC)
    '    '���Զ���������ԭ����window����
        ret = SetWindowLong(Me.hwnd, GWL_WNDPROC, AddressOf Wndproc)
    End If
    
    Call InitLoaclParas
    Call InitFaceScheme
End Sub


Private Sub InitFaceScheme()
    '��ʼ���沼��
    Dim Pane1 As Pane, Pane2 As Pane, Pane3 As Pane, pane4 As Pane
    With Me.dkpMain
        .CloseAll
        .options.HideClient = True
        .options.UseSplitterTracker = False 'ʵʱ�϶�
        .options.ThemedFloatingFrames = True
        .options.AlphaDockingContext = True
    End With
    
    Set Pane1 = dkpMain.CreatePane(1, 0, mlngWordTreeH, DockTopOf, Nothing)
    Pane1.title = "�ʾ�ʾ��"
    Pane1.Handle = picWordTree.hwnd
    Pane1.options = PaneNoCaption Or PaneNoCloseable
    
    Set Pane2 = dkpMain.CreatePane(2, 0, mlngWordShowH, DockBottomOf, Pane1)
    Pane2.title = "�ʾ�����"
    Pane2.Handle = picWordShow.hwnd
    Pane2.options = PaneNoCaption Or PaneNoCloseable
    
    Set Pane3 = dkpMain.CreatePane(3, 0, mlngPrivateWordH, DockBottomOf, Pane2)
    Pane3.title = "���ôʾ�"
    Pane3.Handle = picPrivateWord.hwnd
    Pane3.options = PaneNoCloseable Or PaneNoFloatable Or PaneNoHideable
    Set mPrivatePane = Pane3
    
    chkֱ�ӱ༭.Visible = Not mblnShowWord
    picCommandButton.Visible = Not mblnShowWord

    
    If Not mblnShowWord Then    'ͨ��˫���򿪣�����ʾȷ����ȡ����ť
        
        If Not CBool(chkֱ�ӱ༭.value) Then
            Set pane4 = dkpMain.CreatePane(4, 0, cmdClose.Height + 50, DockBottomOf, Pane3)
            pane4.options = PaneNoCloseable Or PaneNoFloatable Or PaneNoHideable Or PaneNoCaption
        Else
            Set pane4 = dkpMain.CreatePane(4, 0, mlngButtonH, DockBottomOf, Pane3)
            pane4.options = PaneNoCloseable Or PaneNoFloatable Or PaneNoHideable
        End If
        
        
        pane4.title = mstrReportViewTypeAlias
        pane4.Handle = picCommandButton.hwnd
        
        
        cmdSure.Visible = CBool(chkֱ�ӱ༭.value)
        rtbEditWord.Visible = CBool(chkֱ�ӱ༭.value)
    End If
    
    '���ôʾ����ͳ��ôʾ������С
    trvWordTree.Font.Size = intFontSize
    rtxtPrivateWord.Font.Size = intFontSize
    
    '����ʾ�����ôʾ䵯���˵�������˵���
    menuPriWordPopup.Visible = False
End Sub


Private Sub LoadWordTree(FileID As Long, strReportViewType As String, Optional blnForceRefresh As Boolean = False)
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim strTextName As String
    Dim lng���ID As Long, lng����ID As Long, lng��ҳID As Long
    Dim objNode As Node
    Dim objPnode As Node
    Dim strKey As String
    
    If strReportViewType = mstrReportViewType And FileID = mFileID And blnForceRefresh = False Then Exit Sub
    
    mstrReportViewType = strReportViewType
    mFileID = FileID
    
    '���ģ������
    Call ClearWordShow
    '��������API�����Ҳ�������ѭ��ɾ��TreeView�ķ�������������ٶȸ���
    Call TrvwClear
    
    strTextName = mstrReportViewType
    
    '�򿪶�Ӧ�Ĵʾ�ʾ�������������Ӧ�Ĵʾ�ʾ��
    strSQL = "Select nvl(C.��id,0) as ���ID ,a.����ID,nvl(a.��ҳid ,0) as ��ҳid  From �����ļ��ṹ C ,����ҽ����¼ a " & _
             " Where C.�ļ�ID=[1] and C.�����ı�=[2] And C.��������=3 And Rownum =1 And a.Id=[3]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, FileID, strTextName, mlngAdviceID)
    If rsTemp.EOF = True Then Exit Sub
    lng���ID = rsTemp!���id
    lng����ID = rsTemp!����ID
    lng��ҳID = rsTemp!��ҳID
        
    If chk��������.value = 0 Then   '�����ղ�λ����
        strSQL = " select /*+ RULE*/ Id,�ϼ�id,����,���� from (" & _
                    " with tmp as( " & _
                    " Select L.����id" & _
                    " From �����ʾ���� C, �����ʾ�ʾ�� L, ������ٴʾ� A, ���ű� D, ��Ա�� P" & _
                    " Where C.ID = L.����id And L.����id = A.�ʾ����id And L.����id = D.ID And L.��Աid = P.ID And A.���id = [1] And" & _
                    " (L.ͨ�ü�=0 Or (L.ͨ�ü�=1 And L.����ID=[2]) Or (L.ͨ�ü�=2 And L.��ԱID= [3]))" & _
                    " )" & _
                    " Select Distinct Id,�ϼ�id,����,���� From �����ʾ����" & _
                    " Start With Id In (" & _
                    " select ����ID from tmp" & _
                    " ) Connect By Prior �ϼ�id=Id)  Order By ����"
            
    Else                            '���ղ�λ����
        strSQL = "select /*+ RULE*/ Id,�ϼ�id,����,���� from(with Tmp as( " & _
                    " Select Distinct L.����id " & _
                    " From �����ʾ���� C, �����ʾ�ʾ�� L, ������ٴʾ� A, ���ű� D, ��Ա�� P, " & _
                    " Table(Cast(f_Sentence_Usable([1], [4], [5], [6]) As " & mdbOwner & ".t_Dic_Rowset)) U " & _
                    " Where C.ID = L.����id And L.����id = A.�ʾ����id And L.����id = D.ID And L.��Աid = P.ID And A.���id = [1] And " & _
                    " l.ID = To_Number(u.����) And (l.ͨ�ü� = 0 Or (l.ͨ�ü� = 1 And l.����id = [2]) Or (l.ͨ�ü� = 2 And l.��Աid = [3])) " & _
                    " )" & _
                    " Select Distinct Id,�ϼ�id,����,����  " & _
                    " From �����ʾ����  " & _
                    " Start With Id In (select ����id from Tmp)  " & _
                    " Connect By Prior �ϼ�id=Id)  Order By ���� "
                    
    End If
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lng���ID, mlngDeptID, UserInfo.ID, lng����ID, lng��ҳID, mlngAdviceID)
    
    Do While Not rsTemp.EOF
        
        Set objNode = Nothing
        
        On Error Resume Next
        Set objNode = trvWordTree.Nodes("T-" & rsTemp("ID").value)
        If zlCommFun.NVL(rsTemp("�ϼ�id").value, 0) <> 0 Then
            Set objPnode = trvWordTree.Nodes("T-" & rsTemp("�ϼ�id").value)
        Else
            Set objPnode = Nothing
        End If
        On Error GoTo errHandle
        
        If objNode Is Nothing Then
            If objPnode Is Nothing Then
                Set objNode = trvWordTree.Nodes.Add(, , "T-" & rsTemp("ID").value, rsTemp("����").value, 2)
                '����CheckBox�ж��Ƿ��Զ�����
                If ChkAutoExpand.value = 0 Then
                    objNode.Expanded = True
                    
                    If Not objNode.Parent Is Nothing Then
                        If InStr(strKey, objNode.Parent.Key) <= 0 Then
                            strKey = strKey & "," & objNode.Parent.Key
                            'װ��Ҷ�ӽڵ�
                            Call LoadClassWork(objNode.Parent)
                        End If
                    End If
                End If
            Else
                Set objNode = trvWordTree.Nodes.Add("T-" & zlCommFun.NVL(rsTemp("�ϼ�id").value, 0), tvwChild, "T-" & rsTemp("ID").value, rsTemp("����").value, 2)
            End If
            objNode.tag = lng���ID & "-" & lng����ID & "-" & lng��ҳID & "-" & mlngAdviceID
            '����CheckBox�ж��Ƿ��Զ�����
            If ChkAutoExpand.value = 1 Then
                objNode.Expanded = True
                
                If Not objNode.Parent Is Nothing Then
                    If InStr(strKey, objNode.Parent.Key) <= 0 Then
                        strKey = strKey & "," & objNode.Parent.Key
                        'װ��Ҷ�ӽڵ�
                        Call LoadClassWork(objNode.Parent)
                    End If
                End If
            End If
            
        End If
        rsTemp.MoveNext
    Loop
    
    Exit Sub
errHandle:
    If err.Number <> 35602 Then
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
    End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Dim strRegPath As String
    
    If mblnSingleWindow = True Then
        strRegPath = "����ģ��\" & App.ProductName & "\frmReportWord\SingleWindow"
    Else
        strRegPath = "����ģ��\" & App.ProductName & "\frmReportWord"
    End If
    
    '����ʾ�ʾ������ĸ߶�
    '285��Pane�ı���߶ȣ�ʹ���˱��⣬����Ҫ�ӻ�����߶�
    If Not (picWordTree.Height = 0 And picWordShow.Height = 0 And picPrivateWord.Height = 0) Then
      SaveSetting "ZLSOFT", strRegPath, "WordTreeH", picWordTree.Height
      SaveSetting "ZLSOFT", strRegPath, "WordShowH", picWordShow.Height
      SaveSetting "ZLSOFT", strRegPath, "PrivateWordH", picPrivateWord.Height ' + 285
    End If
    SaveSetting "ZLSOFT", "˽��ģ��\" & gstrDBUser & "\" & App.ProductName & "\frmReportWord", "ֱ�ӱ༭", CLng(chkֱ�ӱ༭.value)
    SaveSetting "ZLSOFT", "˽��ģ��\" & gstrDBUser & "\" & App.ProductName & "\frmReportWord", "�Զ�չ��", CLng(ChkAutoExpand.value)
    
    If mblnShowWord = False Then    'ͨ��˫���򿪣�����ʾȷ����ȡ����ť,��¼����߶�
        SaveSetting "ZLSOFT", strRegPath, "ButtonH", picCommandButton.Height
    End If
    
    '����ʾ�ʾ������Ŀ���
    If mblnSingleWindow = True Then
        strRegPath = "����ģ��\" & App.ProductName & "\frmReport\SingleWindow"
    Else
        strRegPath = "����ģ��\" & App.ProductName & "\frmReport"
    End If
    SaveSetting "ZLSOFT", strRegPath, "CX1", picWordTree.Width
    
    '����ģʽ,��ģʽ�¼�¼����λ��
    If mblnShowWord = False Then
        Call SaveWinState(Me, App.ProductName)
    End If
    
    Set mPrivatePane = Nothing
End Sub

Private Sub menuAddWord_Click()
On Error GoTo errH
    RaiseEvent AddSampleWord(False)
    Call LoadWordTree(mFileID, mstrReportViewType, True)
    Exit Sub
errH:
End Sub

Private Sub menuDeleteWord_Click()
On Error GoTo errH
    Dim blnDelOK As Boolean

    If Left(trvWordTree.SelectedItem.Key, 1) = LVW_KEY_WORD Then
        If MsgBoxD(Me, "ȷ��Ҫ���дʾ�ɾ��������", vbYesNo + vbDefaultButton2, gstrSysName) = vbNo Then Exit Sub
        If SubDeleteWord(Right(trvWordTree.SelectedItem.Key, Len(trvWordTree.SelectedItem.Key) - 2)) = True Then
            Call LoadWordTree(mFileID, mstrReportViewType, True)
        End If
    End If
    Exit Sub
errH:
End Sub

Private Sub menuInsertPriWord_Click()
On Error GoTo errH
    RaiseEvent WordSelected(rtxtPrivateWord.SelText, mstrReportViewType, False, False)
    Exit Sub
errH:
End Sub

Private Sub menuModifyWord_Click()
On Error GoTo errH
    RaiseEvent ModifySampleWord
    Call LoadWordTree(mFileID, mstrReportViewType, True)
    Exit Sub
errH:
End Sub

Private Sub menuSaveAllWord_Click()
On Error GoTo errH
    RaiseEvent AddSampleWord(True)
    Call LoadWordTree(mFileID, mstrReportViewType, True)
    Exit Sub
errH:
End Sub

Private Sub picCommandButton_Resize()
    On Error Resume Next
    
    If mblnShowWord = False Then
        rtbEditWord.Left = 0
        rtbEditWord.Top = 0
        
        If CBool(chkֱ�ӱ༭.value) Then
            rtbEditWord.Width = picCommandButton.ScaleWidth
            rtbEditWord.Height = picCommandButton.ScaleHeight - cmdSure.Height - 100
        Else
            rtbEditWord.Width = 0
            rtbEditWord.Height = 0
        End If
        
        cmdClose.Left = picCommandButton.ScaleWidth - cmdClose.Width - 200
        cmdSure.Left = cmdClose.Left - cmdSure.Width - 200
        
        cmdClose.Top = picCommandButton.ScaleHeight - cmdClose.Height - 50
        cmdSure.Top = picCommandButton.ScaleHeight - cmdSure.Height - 50
    End If
        
        err.Clear
End Sub

Private Sub picPrivateWord_Resize()
On Error Resume Next

    rtxtPrivateWord.Left = 0
    rtxtPrivateWord.Top = 0
    rtxtPrivateWord.Width = picPrivateWord.ScaleWidth
    rtxtPrivateWord.Height = picPrivateWord.ScaleHeight
End Sub

Private Sub picWordShow_Resize()
    Dim i As Integer
    
    On Error Resume Next
    
    '����ÿһ��RichTextBox�Ŀ���
    For i = 1 To rtxtWord.Count - 1
        rtxtWord(i).Width = Abs(picWordContainer.Width - rtxtWord(i).Left - 60)
    Next i
    
    Call ResizeWordContainer
End Sub

Private Sub picWordTree_Resize()
On Error Resume Next
    
    chk��������.Left = 10
    chk��������.Top = 10
    
    chkֱ�ӱ༭.Left = chk��������.Left + chk��������.Width + 20
    chkֱ�ӱ༭.Top = chk��������.Top
    
    ChkAutoExpand.Left = IIf(chkֱ�ӱ༭.Visible, chkֱ�ӱ༭.Left + chkֱ�ӱ༭.Width + 80, chk��������.Left + chk��������.Width + 20)
    ChkAutoExpand.Top = chk��������.Top
    
    trvWordTree.Left = 0
    trvWordTree.Top = chk��������.Top + chk��������.Height
    trvWordTree.Width = picWordTree.Width
    trvWordTree.Height = Abs(picWordTree.Height - 10 - chk��������.Top - chk��������.Height)
        
        err.Clear
End Sub

Private Sub rtxtPrivateWord_DblClick()
    rtxtPrivateWord.Locked = Not rtxtPrivateWord.Locked
    If rtxtPrivateWord.Locked = True Then
        '���жϴʾ����ݵĳ����Ƿ񳬹�1000���ַ������������������
        If Len(rtxtPrivateWord.Text) > 1000 Then
            MsgBoxD Me, "˽�˴ʾ�ĳ��Ȳ��ܳ��� 1000���ַ����������޸ĺ��ٱ��档", vbInformation, gstrSysName
            mPrivatePane.title = "����༭ģʽ��˫������"
            rtxtPrivateWord.Locked = False
            Exit Sub
        End If
        rtxtPrivateWord.BackColor = vbWhite
        mPrivatePane.title = "���ô���"
        Call zlDatabase.SetPara("���泣�ôʾ�", rtxtPrivateWord.Text, glngSys, mlngModul)
    Else
        mPrivatePane.title = "����༭ģʽ��˫������"
        rtxtPrivateWord.BackColor = &H80000013
    End If
End Sub

Private Sub rtxtPrivateWord_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '����Ҽ������˵�
    If Button = 2 Then
        PopupMenu menuPriWordPopup
    End If
End Sub

Private Sub rtxtWord_DblClick(Index As Integer)
    Call richTextBoxShowElements(rtxtWord(Index))
End Sub

Private Sub trvWordTree_DblClick()
    Dim i As Integer
    
    If Not trvWordTree.SelectedItem Is Nothing Then
        If Left(trvWordTree.SelectedItem.Key, 1) = LVW_KEY_WORD Then
        
        If mblnEditable Then
            If mintWordDblClick = 1 And (mstrReportViewType = ReportViewType_������� _
                Or mstrReportViewType = ReportViewType_������ Or mstrReportViewType = ReportViewType_����) Then              '�ʾ�˫����ֱ��д�뱨��
                '�ʾ�˫���󣬴򿪴ʾ�༭����
                WriteWordEdit Right(trvWordTree.SelectedItem.Key, Len(trvWordTree.SelectedItem.Key) - 2)
            Else
                For i = 1 To cmdSelect.Count - 1
                    cmdSelect_Click i
                Next i
            End If
        End If
            
        
        ElseIf Left(trvWordTree.SelectedItem.Key, 1) = LVW_KEY_TYPE And trvWordTree.SelectedItem.Checked = False Then
            'װ��Ҷ�ӽڵ�
            Call LoadClassWork(trvWordTree.SelectedItem)
        End If
    End If
End Sub

Private Sub LoadClassWork(ByVal objNode As Object)
    '��������µĴʾ�
On Error GoTo errH
    Dim strSQL As String
    Dim strPara() As String
    Dim rsLeaf As ADODB.Recordset
    Dim objCurNode As Node
    Dim objSubNode As Node
    Dim lngClassID As Long
    
    If objNode Is Nothing Then Exit Sub
    
    Set objCurNode = objNode
    
    If objCurNode.tag = "" Then Exit Sub
    
    lngClassID = Right(objNode.Key, Len(objNode.Key) - 2)
    
    'װ��Ҷ�ӽڵ�
    objNode.Checked = True
    
    strPara = Split(objNode.tag, "-")
    If chk��������.value = 0 Then       '��������������
        strSQL = "Select  L.Id as ʾ��ID,L.���� as ʾ������ From �����ʾ�ʾ�� L " & _
            " Where L.����id=[7] and (L.ͨ�ü�=0 Or (L.ͨ�ü�=1 And L.����ID=[1]) Or (L.ͨ�ü�=2 And L.��ԱID= [2]))" & _
            " Order By ���"
    Else                                '������������
        strSQL = "Select /*+ RULE*/ L.Id as ʾ��ID,L.���� as ʾ������,l.��� From �����ʾ�ʾ�� L, Table(Cast(f_Sentence_Usable([3], [4], [5], [6]) As " & mdbOwner & ".t_Dic_Rowset)) U " & _
            " Where L.����id=[7] and L.ID = To_Number(U.����) And (L.ͨ�ü�=0 Or (L.ͨ�ü�=1 And L.����ID=[1]) Or (L.ͨ�ü�=2 And L.��ԱID= [2]))" & _
            " Order By ���"
    End If
    Set rsLeaf = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mlngDeptID, UserInfo.ID, strPara(0), strPara(1), strPara(2), strPara(3), lngClassID)
    
    Do While Not rsLeaf.EOF
        Set objSubNode = trvWordTree.Nodes.Add(objNode, tvwChild, "L-" & rsLeaf("ʾ��ID").value, rsLeaf("ʾ������").value, 1)
        rsLeaf.MoveNext
    Loop
    
    objNode.Expanded = True
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub trvWordTree_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '�����Ҽ������˵����ж��Ƿ��Ҽ�
    If Button = vbRightButton And mintWordPower <> -1 Then
        If trvWordTree.SelectedItem Is trvWordTree.HitTest(X, Y) And Not trvWordTree.SelectedItem Is Nothing Then
            If Left(trvWordTree.SelectedItem.Key, 1) = LVW_KEY_WORD Then 'Ҷ�ӽڵ㣬�����޸Ĵʾ�ʾ��
                menuModifyWord.Visible = True
                menuDeleteWord.Visible = True
            Else    '�����㣬�����޸Ĵʾ�ʾ��
                menuModifyWord.Visible = False
                menuDeleteWord.Visible = False
            End If
            PopupMenu menuPopup
        End If
    End If
End Sub

Private Sub GetSaveSQL(ByVal lngWordID As Long, ByRef ArrySQL() As String, strText As String)
'��֯����ʾ���ɵ�SQL���
'������ ArrySQL --- SQL �������
'       strText --- Ҫ����Ĵʾ�ʾ������
    
    Dim strLine As String       'һ���ı����س�֮����ı�
    Dim lng��� As Long         '����CRLF���ֶ�
    Dim i As Integer
    On Error GoTo err
    
    lng��� = 1
    
    For i = 0 To UBound(Split(strText, "#***#"))
        strLine = Split(strText, "#***#")(i)
        Call GetPlainTextSaveSQL(lngWordID, ArrySQL, strLine, lng���)
    Next
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Function GetPlainTextSaveSQL(ByVal lngWordID As Long, ByRef ArraySQL() As String, ByVal strIn As String, ByRef lng��� As Long) As Boolean
'�Դ��ı���ȡ���䱣�浽�ʾ���ɵ�SQL��䣬���ȴ���4000���ַ��������д洢����ŵ���֮��
'������ ArraySQL --- SQL �������
'       strIn --- ��Ҫ������ı�
'       lng��� --- ���
    
    Dim lngLen As Long, strSub As String, i As Long, lngID As Long
    Dim lngCount As Long, lID As Long
    strIn = Replace(strIn, "'", "' || chr(39) || '")
    strIn = Replace(strIn, vbCrLf, "' || chr(13) || chr(10) || '")  '����strIn�ǲ�������vbCrlf�ġ�
    lngLen = Len(strIn)
    
    '����4000Ϊ��ֶδ洢��
    i = 0
    Do While (i * 2000 + 1 <= lngLen)
        lngCount = UBound(ArraySQL) + 1
        ReDim Preserve ArraySQL(1 To lngCount) As String

        strSub = Mid(strIn, i * 2000 + 1, 2000)

        gstrSQL = "Zl_�����ʾ����_Insert(" & lngWordID & "," & lng��� & ",0,'" & strSub & "',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)"
        
        ArraySQL(lngCount) = gstrSQL
       
        lng��� = lng��� + 1
        i = i + 1
    Loop
    GetPlainTextSaveSQL = True
End Function

Private Sub trvWordTree_NodeClick(ByVal Node As MSComctlLib.Node)
    Dim i As Integer
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim lngWordID As Long, lngCount As Long
    Dim blnNextLine As Boolean
    Dim iFieldCount As Integer
    
    Dim blnStartSegment As Boolean      '��ʼһ������
    Dim str�����ı� As String, strText As String
    Dim str�����ı� As String
    
     '��¼��ǰѡ��Ľڵ�
    Set objNode = trvWordTree.SelectedItem
    '���ԭ�пؼ�
    Call ClearWordShow
    blnNextLine = True
    miWordScale = 0
    
    If Left(Node.Key, 1) = LVW_KEY_WORD Then
        lngWordID = Right(Node.Key, Len(Node.Key) - 2)
        strSQL = "Select �ʾ�id,���д���,��������,�����ı�,����Ҫ��ID,�滻��,Ҫ������,Ҫ������,Ҫ�س���,Ҫ��С��," & _
                 " Ҫ�ص�λ,Ҫ�ر�ʾ,Ҫ��ֵ��,������̬ From �����ʾ���� Where �ʾ�ID=[1] order by ���д��� "
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngWordID)
        blnStartSegment = False
        
        If rsTemp.RecordCount = 1 Then
            If Val(NVL(rsTemp.Fields!��������)) = 0 Then
                On Error GoTo errH
                str�����ı� = NVL(rsTemp!�����ı�)
                
                '�����ʾ���ɣ����ϱ�ǣ�#***#
                If InStr(str�����ı�, "<<") > 0 Then
                    '��һ��<<ǰ�����ݺ��Բ���
                    strText = Mid(str�����ı�, InStr(str�����ı�, "<<"))
                    
                    If InStr(strText, "<<����>>") > 0 Then strText = Replace(strText, "<<����>>", "#***#<<����>>")
                    If InStr(strText, "<<���>>") > 0 Then strText = Replace(strText, "<<���>>", "#***#<<���>>")
                    If InStr(strText, "<<����>>") > 0 Then strText = Replace(strText, "<<����>>", "#***#<<����>>")
                    If Mid(strText, 1, 5) = "#***#" Then strText = Mid(strText, 6)
                Else
                    strText = "#***#" & str�����ı�
                End If
                
                '��ȡSQL�������
                ReDim ArraySQL(1 To 1) As String
                
                'ǰ�ڴ���
                ArraySQL(1) = "Zl_�����ʾ����_Beforesave(" & lngWordID & ")"
                
                '��ȡ����SQL����
                Call GetSaveSQL(lngWordID, ArraySQL, strText)
                
                '���ڴ���
                lngCount = UBound(ArraySQL) + 1
                ReDim Preserve ArraySQL(1 To lngCount) As String
                strSQL = "Zl_�����ʾ����_Aftersave(" & lngWordID & ")"
                ArraySQL(lngCount) = strSQL
                
                'ִ�б������
                gcnOracle.BeginTrans
                For i = 1 To UBound(ArraySQL)
                    strSQL = ArraySQL(i)
                    Call zlDatabase.ExecuteProcedure(strSQL, "frmReportWordList")
                Next
                gcnOracle.CommitTrans
errH:
                strSQL = "Select �ʾ�id,���д���,��������,�����ı�,����Ҫ��ID,�滻��,Ҫ������,Ҫ������,Ҫ�س���,Ҫ��С��," & _
                         " Ҫ�ص�λ,Ҫ�ر�ʾ,Ҫ��ֵ��,������̬ From �����ʾ���� Where �ʾ�ID=[1] order by ���д��� "
                Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngWordID)
            End If
        End If
        
        On Error GoTo errHandle
        '�����ݿ��ж�ȡ�ʾ�����з�������ʾ
        While rsTemp.EOF = False
            '�ȰѼ�¼�еĴʾ����ݶ�ȡ��str�����ı���
            str�����ı� = NVL(rsTemp!�����ı�)
            
            If blnNextLine = True And Not (rsTemp!�������� = 0 And (Trim(str�����ı�) = "" Or Trim(str�����ı�) = vbCrLf)) Then      '���µ�һ������ʾ���򴴽�һ��cmdSelect��rtxtWord��ʾ�����ı�
                blnNextLine = False
                iFieldCount = rtxtWord.Count
                '������ť���ı���
                Load rtxtWord(iFieldCount)
                rtxtWord(iFieldCount).Visible = True
                
                '���ôʾ��ı���������С
                rtxtWord(iFieldCount).Font.Size = intFontSize
                
                Load cmdSelect(iFieldCount)
                cmdSelect(iFieldCount).Visible = True
                
                If Not mblnEditable Then
                    rtxtWord(iFieldCount).Enabled = False
                    cmdSelect(iFieldCount).Enabled = False
                End If
                

                '�ȶ�ȡ�����ı����жϵ�ǰ���ݵ����ͣ�������˱�ǣ����ձ������¼���ͣ������ʹ�õ�ǰ��Ĭ������
                If Left(str�����ı�, 6) = "<<����>>" Then
                    rtxtWord(iFieldCount).tag = ReportViewType_�������
                ElseIf Left(str�����ı�, 6) = "<<���>>" Then
                    rtxtWord(iFieldCount).tag = ReportViewType_������
                ElseIf Left(str�����ı�, 6) = "<<����>>" Then
                    rtxtWord(iFieldCount).tag = ReportViewType_����
                Else
                    rtxtWord(iFieldCount).tag = mstrReportViewType
                End If
                
                '�ڷ�λ��
                If iFieldCount = 1 Then
                    cmdSelect(iFieldCount).Top = 5
                Else
                    cmdSelect(iFieldCount).Top = rtxtWord(iFieldCount - 1).Top + rtxtWord(iFieldCount - 1).Height + 5
                End If
                cmdSelect(iFieldCount).Left = 5
                rtxtWord(iFieldCount).Left = cmdSelect(iFieldCount).Left + cmdSelect(iFieldCount).Width + 10
                rtxtWord(iFieldCount).Top = cmdSelect(iFieldCount).Top
                rtxtWord(iFieldCount).Width = picWordContainer.Width - rtxtWord(iFieldCount).Left - 60
                rtxtWord(iFieldCount).Height = 400
            End If
            
            If rsTemp!�������� = 0 Then     '�������ı���ֱ�Ӽ�������
                If Trim(str�����ı�) <> "" And Trim(str�����ı�) <> vbCrLf Then '�����ı���Ϊ�ջ��߿ջس������������ʾ�����ı�
                    '׼���������֣����ù��λ��
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text)
                    rtxtWord(iFieldCount).SelLength = 0
                    rtxtWord(iFieldCount).SelColor = vbBlack
                    '������ִ�ǰ���б�����дλ�ñ�ʶ��ɾ���ñ�ʶ
                    If Left(str�����ı�, 6) = "<<����>>" Or Left(str�����ı�, 6) = "<<���>>" _
                        Or Left(str�����ı�, 6) = "<<����>>" Then
                        str�����ı� = Right(str�����ı�, Len(str�����ı�) - 6)
                    ElseIf UCase(Left(str�����ı�, 3)) = "<P>" Then
                        '�ж��Ƿ�<P>��</P>��Χ��һ�������Ķ�
                        If UCase(Right(str�����ı�, 4)) = "</P>" Then
                            str�����ı� = Mid(str�����ı�, 4, Len(str�����ı�) - 7)
                        ElseIf UCase(Right(str�����ı�, 6)) = "</P>" & vbCrLf Then
                            str�����ı� = Mid(str�����ı�, 4, Len(str�����ı�) - 9)
                        Else
                            str�����ı� = Right(str�����ı�, Len(str�����ı�) - 3)
                        End If
                        blnStartSegment = True
                    ElseIf UCase(Right(str�����ı�, 4)) = "</P>" Then
                        str�����ı� = Left(str�����ı�, Len(str�����ı�) - 4)
                    ElseIf UCase(Right(str�����ı�, 6)) = "</P>" & vbCrLf Then
                        str�����ı� = Left(str�����ı�, Len(str�����ı�) - 6)
                    Else
                        str�����ı� = str�����ı�
                    End If
                    
                    '�������ı����ӵ��ı���
                    'ɾ���ı�ĩβ�Ļس����У������<P></P>��װ�Ķ�����ϣ���ɾ���س�����
                    If Right(str�����ı�, 2) = vbCrLf And blnStartSegment = False Then
                        str�����ı� = Left(str�����ı�, Len(str�����ı�) - 2)
                    End If
                    rtxtWord(iFieldCount).SelText = str�����ı�
                    '�ж��Ƿ���Ҫ����
                    If blnStartSegment = True Then      '�Ѿ����ö����ǣ�����ҽ�������ı��</P>
                        If UCase(Right(str�����ı�, 4)) = "</P>" Or UCase(Right(str�����ı�, 6)) = "</P>" & vbCrLf Then
                            blnNextLine = True
                            blnStartSegment = False
                        End If
                    Else    '���һس���Ϊ����������
                        If Right(str�����ı�, 2) = vbCrLf Then
                            blnNextLine = True
                        End If
                    End If
                End If
            Else        'rsTemp!��������<>0 ,��Ҫ�أ���Ҫ����
                If rsTemp!Ҫ�ر�ʾ = 0 Then     '�ı�Ҫ�ؽ����ɿա� ��
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text)
                    rtxtWord(iFieldCount).SelLength = 0
                    rtxtWord(iFieldCount).SelText = "  " & NVL(rsTemp!Ҫ�ص�λ)
                    
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text) - Len(NVL(rsTemp!Ҫ�ص�λ))
                    rtxtWord(iFieldCount).SelLength = Len("  " & NVL(rsTemp!Ҫ�ص�λ))
                    rtxtWord(iFieldCount).SelColor = vbBlue
                ElseIf rsTemp!Ҫ�ر�ʾ = 1 Then     '����
                    'Ŀǰû��ʹ�������ʽ
                ElseIf rsTemp!Ҫ�ر�ʾ = 2 Then     '��ѡ
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text)
                    rtxtWord(iFieldCount).SelLength = 0
                    rtxtWord(iFieldCount).SelText = "{{" & NVL(rsTemp!Ҫ��ֵ��) & "}}" & NVL(rsTemp!Ҫ�ص�λ)
                    
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text) - Len("{{" & NVL(rsTemp!Ҫ��ֵ��) & "}}" & NVL(rsTemp!Ҫ�ص�λ))
                    rtxtWord(iFieldCount).SelLength = Len("{{" & NVL(rsTemp!Ҫ��ֵ��) & "}}" & NVL(rsTemp!Ҫ�ص�λ))
                    rtxtWord(iFieldCount).SelColor = vbBlue
                ElseIf rsTemp!Ҫ�ر�ʾ = 3 Then     '��ѡ
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text)
                    rtxtWord(iFieldCount).SelLength = 0
                    rtxtWord(iFieldCount).SelText = "{<" & NVL(rsTemp!Ҫ��ֵ��) & ">}" & NVL(rsTemp!Ҫ�ص�λ)
                    
                    rtxtWord(iFieldCount).SelStart = Len(rtxtWord(iFieldCount).Text) - Len("{<" & NVL(rsTemp!Ҫ��ֵ��) & ">}" & NVL(rsTemp!Ҫ�ص�λ))
                    rtxtWord(iFieldCount).SelLength = Len("{<" & NVL(rsTemp!Ҫ��ֵ��) & ">}" & NVL(rsTemp!Ҫ�ص�λ))
                    rtxtWord(iFieldCount).SelColor = vbBlue
                End If
            End If
            ResizeRichTextBox rtxtWord(iFieldCount)
            If iFieldCount = 1 Then
                miWordScale = rtxtWord(iFieldCount).Height / IIf(Len(rtxtWord(iFieldCount).Text) = 0, 1, Len(rtxtWord(iFieldCount).Text))
            End If
            rsTemp.MoveNext
        Wend
        Call ResizeWordContainer
    End If
    Exit Sub
errHandle:
    If ErrCenter = 1 Then
        Resume
    End If
    Call SaveErrLog
End Sub

Private Sub ClearWordShow()
    Dim i As Integer
    
    For i = 1 To rtxtWord.Count - 1
        Unload rtxtWord(i)
    Next i
    For i = 1 To cmdSelect.Count - 1
        Unload cmdSelect(i)
    Next i
    
    '�������ָ���0
    vscroWordH.value = 0
End Sub

Private Sub TrvwClear()
     Dim X As Integer
     With trvWordTree
        SendMessage .hwnd, WM_SETREDRAW, 0, 0
        For X = .Nodes.Count To 1 Step -1
            .Nodes.Remove X
        Next X
        SendMessage .hwnd, WM_SETREDRAW, 1, 0
     End With
End Sub

Private Sub ResizeWordContainer()
    Dim lngH As Long
        
    On Error Resume Next
    
    '������������λ�ú͸߶�
        vscroWordH.Left = picWordShow.Width - vscroWordH.Width
        vscroWordH.Top = 0
        vscroWordH.Height = picWordShow.Height

        '�����ʾ�������λ�úͿ���
        picWordContainer.Left = 0
        picWordContainer.Top = 0
        If picWordShow.Width > vscroWordH.Width Then
            picWordContainer.Width = picWordShow.Width - vscroWordH.Width
        Else
            picWordContainer.Width = 10
        End If

        '�����ʾ������ĸ߶�
        lngH = 0
        If rtxtWord.Count > 1 Then
            lngH = rtxtWord(rtxtWord.Count - 1).Top + rtxtWord(rtxtWord.Count - 1).Height + 200
        End If

        If lngH < picWordShow.Height Then
            picWordContainer.Height = picWordShow.Height
            vscroWordH.Visible = False
        Else
            picWordContainer.Height = lngH
            vscroWordH.Visible = True
        End If

        '���ù������ķ���
        vscroWordH.Max = picWordContainer.Height / 1000
        vscroWordH.value = 0
                
        err.Clear

End Sub



Private Sub vscroWordH_Change()
    '����33*1000�����������ϵͳ����
    If vscroWordH.value < 33 Then
        picWordContainer.Top = -vscroWordH.value * 1000
    Else
        picWordContainer.Top = -32 * 1000
    End If
End Sub

Public Sub zlRefresh(FileID As Long, strReportViewType As String, strReportViewTypeAlias As String, strContext As String, lngAdviceID As Long, lngDeptId As Long, _
    blnSingleWindow As Boolean, lngModul As Long, blnShowWord As Boolean, intWordDblClick As Integer, _
    intWordPower As Integer, Optional blnEditable As Boolean, Optional blnRefreshWord As Boolean)
'������
'    intWordPower=-1�����߱��ʾ����Ȩ;
'    intWordPower=0��ȫԺ����ʱ��ʾ���е�ʾ����Ҳ���Ը���;
'    intWordPower=1�����ң���ʱ��ʾȫԺͨ��ʾ��(����id is null)�����ڿ��ҹ��л�������Ա˽�е�ʾ���������ܸ���ȫԺͨ��ʾ��;
'    intWordPower=2�����ˣ���ʱ��ʾȫԺͨ��ʾ��(����id is null)�����ڿ���ͨ��ʾ��(��Աid is null)�͸���ʾ����������ʾ���ɸ���
    Dim i As Integer

    mlngAdviceID = lngAdviceID
    mlngDeptID = lngDeptId
    mblnSingleWindow = blnSingleWindow
    mlngModul = lngModul
    mintWordDblClick = intWordDblClick
    mintWordPower = intWordPower
    mstrReportViewTypeAlias = strReportViewTypeAlias
    
    '������� �Ƿ���Ա༭�ı�� ��ģ�����
'    If mblnEditable = False Then
        mblnEditable = blnEditable
'    End If
    
    
    'ˢ�´ʾ䣬���ݱ༭���ȷ���ʾ䰴ť�Ƿ����
    For i = 0 To cmdSelect.Count - 1
        cmdSelect(i).Enabled = mblnEditable
    Next
    If mblnSingleWindow <> blnSingleWindow Or mblnShowWord <> blnShowWord Or blnShowWord = False Then
        mblnSingleWindow = blnSingleWindow
        mblnShowWord = blnShowWord
        mblnInitFaseScheme = True
    ElseIf mblnInitFaseScheme = False Then
        mblnInitFaseScheme = True
    End If
    
    '��������ģʽ�£�˫���ʾ�ģ�壬ֱ��д�뱨�棬����֧�ִ򿪴ʾ�༭����
    If mblnShowWord = False Then mintWordDblClick = 0
    
    Call LoadWordTree(FileID, strReportViewType, blnRefreshWord)
    
    rtxtPrivateWord.Text = zlDatabase.GetPara("���泣�ôʾ�", glngSys, mlngModul)
    rtxtPrivateWord.Locked = True
    rtxtPrivateWord.BackColor = vbWhite
    mPrivatePane.title = "���ô���"
    
    rtbEditWord.Text = strContext
End Sub

Private Function GetDbOwner(ByVal lngSys As Long) As String
    Dim rsTemp As New ADODB.Recordset
    Dim strSQL  As String

    GetDbOwner = ""
    err = 0: On Error GoTo errHand
    strSQL = "Select ������ From Zlsystems Where ��� = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "GetDbOwner", lngSys)
    If rsTemp.RecordCount <> 0 Then GetDbOwner = "" & rsTemp!������
    rsTemp.Close
    Exit Function
errHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Private Sub InitLoaclParas()
    Dim strRegPath As String
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    On Error GoTo err
    
    '��ȡ�ʾ�ʾ����˽�˴ʾ�Ŀ��Ⱥ͸߶�
    If mblnSingleWindow = True Then
        strRegPath = "����ģ��\" & App.ProductName & "\frmReportWord\SingleWindow"
    Else
        strRegPath = "����ģ��\" & App.ProductName & "\frmReportWord"
    End If
    
    mlngWordTreeH = GetSetting("ZLSOFT", strRegPath, "WordTreeH", 200)
    mlngWordShowH = GetSetting("ZLSOFT", strRegPath, "WordShowH", 300) - 15
    mlngPrivateWordH = GetSetting("ZLSOFT", strRegPath, "PrivateWordH", 200) + 355
    mlngButtonH = GetSetting("ZLSOFT", strRegPath, "ButtonH", 500) + 325
    chkֱ�ӱ༭.value = IIf(CBool(GetSetting("ZLSOFT", "˽��ģ��\" & gstrDBUser & "\" & App.ProductName & "\frmReportWord", "ֱ�ӱ༭", False)), 1, 0)
    ChkAutoExpand.value = IIf(CBool(GetSetting("ZLSOFT", "˽��ģ��\" & gstrDBUser & "\" & App.ProductName & "\frmReportWord", "�Զ�չ��", False)), 1, 0)
     '���ôʾ�������ʾ�ֺ�
    intFontSize = Val(zlDatabase.GetPara("������ʾ�ֺ�", glngSys, glngModul))
    If intFontSize = 0 Then intFontSize = gbytFontSize
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume Next
    Call SaveErrLog
End Sub

Private Sub WriteWordEdit(lngWordID As Long)
    Dim strCheckView As String
    Dim strResult As String
    Dim strAdvice As String
    Dim intReportViewType As Integer
    
    Select Case mstrReportViewType
        Case ReportViewType_�������
            intReportViewType = 0
        Case ReportViewType_������
            intReportViewType = 1
        Case ReportViewType_����
            intReportViewType = 2
    End Select
    
    frmReportWordEdit.zlShowMe lngWordID, Me, intReportViewType, strCheckView, strResult, strAdvice
    
    If strCheckView <> "" Then
        RaiseEvent WordSelected(strCheckView, ReportViewType_�������, False, True)
    End If
    
    If strResult <> "" Then
        RaiseEvent WordSelected(strResult, ReportViewType_������, False, True)
    End If
    
    If strAdvice <> "" Then
        RaiseEvent WordSelected(strAdvice, ReportViewType_����, False, True)
    End If
    
    dkpMain.RecalcLayout
End Sub

Public Function ResizeRichTextBox(rtxtBox As RichTextBox) As Boolean           '�жϴ�ֱ�������Ŀɼ���
    Dim wndStyle As Long
    Dim i As Integer
    
    i = 0
    rtxtBox.Refresh
    wndStyle = GetWindowLong(rtxtBox.hwnd, GWL_STYLE)
    
    While (wndStyle And WS_VSCROLL) <> 0 And i < 12
        rtxtBox.Height = rtxtBox.Height + 200
        rtxtBox.Refresh
        If miWordScale <> 0 Then
            '�жϵ�ǰ�߶Ⱥ���������֮��ı����Ƿ���ڵ�һ���ı���ñ�����1��
            If rtxtBox.Height / Len(rtxtBox.Text) > miWordScale Then
                i = 12
            End If
        End If
        wndStyle = GetWindowLong(rtxtBox.hwnd, GWL_STYLE)
        i = i + 1
    Wend
End Function

Public Sub zlShowMe(frmParent As Form, FileID As Long, strReportViewType As String, strReportViewTypeAlias As String, strContext As String, _
    lngAdviceID As Long, lngDeptId As Long, blnSingleWindow As Boolean, lngModul As Long, intWordPower As Integer, blnEditable As Boolean)
    
'    If blnEditable Then
        '������� �Ƿ���Ա༭�ı�� ��ģ�����
'        mblnEditable = blnEditable
        
        Call zlRefresh(FileID, strReportViewType, strReportViewTypeAlias, strContext, lngAdviceID, lngDeptId, blnSingleWindow, lngModul, False, 0, intWordPower, blnEditable)
        Call RestoreWinState(Me, App.ProductName)
        Call refreshFace
        Me.Show 0, frmParent
'    End If
    
End Sub

Private Sub refreshFace()
    Call ResizeWordContainer
    Call picCommandButton_Resize
    Call picWordTree_Resize
End Sub

Private Function SubDeleteWord(ByVal lngWordID As Long) As Boolean
'ɾ���ʾ�ʾ��,���أ��Ƿ���Ҫ���¼��شʾ���
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As Recordset
    
    '����ʾ�Ĵ�����ID ���ǵ�ǰ�û�ID ������ɾ������ʾ�
    strSQL = " SELECT 1 FROM  �����ʾ�ʾ�� WHERE ID=[1] AND ��ԱID=[2] "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "�жϴʾ䴴����", lngWordID, UserInfo.ID)
    
    If rsTemp.RecordCount > 0 Then
        strSQL = "zl_�����ʾ�ʾ��_delete(" & lngWordID & ")"
        
        Call zlDatabase.ExecuteProcedure(strSQL, "ɾ���ʾ�")
        SubDeleteWord = True
    Else
        SubDeleteWord = False
        MsgBoxD Me, "����ɾ���Ĵʾ䲻�ǵ�ǰ�û������ģ�������ɾ����", vbOKOnly, gstrSysName
    End If
    
    Exit Function
errH:
    SubDeleteWord = True
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Sub SetWordFontSize(ByVal intFontSetSize As Integer)
'���ôʾ������С
'������ intFontSize --- �����С
    Dim i As Integer
    
    intFontSize = intFontSetSize
    trvWordTree.Font.Size = intFontSize
    rtxtPrivateWord.Font.Size = intFontSize
    '���ڴʾ������ı���ʱ��̬���ɣ�����ִ�дʾ�ѡ���¼����������ɴʾ��ı���
    If Not objNode Is Nothing Then
        Call trvWordTree_NodeClick(objNode)
    End If
    
End Sub