VERSION 5.00
Object = "{BEEECC20-4D5F-4F8B-BFDC-5D9B6FBDE09D}#1.0#0"; "vsflex8.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmDocPrintPatiList 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "ѡ����"
   ClientHeight    =   6780
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   8580
   ControlBox      =   0   'False
   DrawWidth       =   4684
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6780
   ScaleWidth      =   8580
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  '����������
   Begin VB.CommandButton cmdAllNoPrint 
      Caption         =   "ȫѡδ��ӡ"
      Height          =   375
      Left            =   7320
      TabIndex        =   16
      Top             =   5160
      Width           =   1095
   End
   Begin VB.Frame frmNo 
      Caption         =   "���Ų�ѯ�����ú�ʹ��ʱ�䷶Χ��"
      Height          =   1455
      Left            =   3480
      TabIndex        =   11
      Top             =   4680
      Width           =   3615
      Begin VB.TextBox txtCheckNoEnd 
         Height          =   300
         Left            =   1200
         TabIndex        =   13
         Text            =   "Text2"
         Top             =   960
         Width           =   1935
      End
      Begin VB.TextBox txtCheckNoStart 
         Height          =   300
         Left            =   1200
         TabIndex        =   12
         Text            =   "Text1"
         Top             =   480
         Width           =   1935
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         Caption         =   "��������"
         Height          =   180
         Left            =   240
         TabIndex        =   15
         Top             =   1020
         Width           =   720
      End
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         Caption         =   "��ʼ����"
         Height          =   180
         Left            =   240
         TabIndex        =   14
         Top             =   525
         Width           =   720
      End
   End
   Begin VB.ComboBox cboDep 
      Height          =   300
      Left            =   1080
      Style           =   2  'Dropdown List
      TabIndex        =   10
      Top             =   5760
      Width           =   1995
   End
   Begin VB.CommandButton cmdFind 
      Caption         =   "��������(&F)"
      Height          =   350
      Left            =   120
      TabIndex        =   8
      Top             =   6240
      Width           =   1245
   End
   Begin MSComCtl2.DTPicker dtpEnd 
      Height          =   300
      Left            =   1080
      TabIndex        =   7
      Top             =   5200
      Width           =   1995
      _ExtentX        =   3519
      _ExtentY        =   529
      _Version        =   393216
      Format          =   109707265
      CurrentDate     =   43511
   End
   Begin MSComCtl2.DTPicker dtpStart 
      Height          =   300
      Left            =   1080
      TabIndex        =   6
      Top             =   4700
      Width           =   1995
      _ExtentX        =   3519
      _ExtentY        =   529
      _Version        =   393216
      Format          =   109707265
      CurrentDate     =   43511
   End
   Begin VB.CheckBox chkChoose 
      Caption         =   "ȫѡ(&A)"
      Height          =   350
      Left            =   7320
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   4680
      Width           =   1125
   End
   Begin VB.CommandButton cmdCancel 
      Cancel          =   -1  'True
      Caption         =   "ȡ��(&C)"
      Height          =   350
      Left            =   7320
      TabIndex        =   1
      Top             =   6240
      Width           =   1125
   End
   Begin VB.CommandButton cmdOk 
      Caption         =   "ȷ��(&O)"
      Height          =   350
      Left            =   6000
      TabIndex        =   0
      Top             =   6240
      Width           =   1125
   End
   Begin VSFlex8Ctl.VSFlexGrid vsfList 
      Height          =   4455
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   8295
      _cx             =   14631
      _cy             =   7858
      Appearance      =   1
      BorderStyle     =   1
      Enabled         =   -1  'True
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MousePointer    =   0
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      BackColorFixed  =   -2147483633
      ForeColorFixed  =   -2147483630
      BackColorSel    =   -2147483635
      ForeColorSel    =   0
      BackColorBkg    =   -2147483636
      BackColorAlternate=   -2147483643
      GridColor       =   -2147483633
      GridColorFixed  =   -2147483632
      TreeColor       =   -2147483632
      FloodColor      =   192
      SheetBorder     =   -2147483642
      FocusRect       =   1
      HighLight       =   1
      AllowSelection  =   -1  'True
      AllowBigSelection=   -1  'True
      AllowUserResizing=   1
      SelectionMode   =   1
      GridLines       =   1
      GridLinesFixed  =   2
      GridLineWidth   =   1
      Rows            =   50
      Cols            =   10
      FixedRows       =   1
      FixedCols       =   1
      RowHeightMin    =   0
      RowHeightMax    =   0
      ColWidthMin     =   0
      ColWidthMax     =   0
      ExtendLastCol   =   0   'False
      FormatString    =   ""
      ScrollTrack     =   0   'False
      ScrollBars      =   3
      ScrollTips      =   0   'False
      MergeCells      =   0
      MergeCompare    =   0
      AutoResize      =   -1  'True
      AutoSizeMode    =   0
      AutoSearch      =   0
      AutoSearchDelay =   2
      MultiTotals     =   -1  'True
      SubtotalPosition=   1
      OutlineBar      =   0
      OutlineCol      =   0
      Ellipsis        =   0
      ExplorerBar     =   0
      PicturesOver    =   0   'False
      FillStyle       =   0
      RightToLeft     =   0   'False
      PictureType     =   0
      TabBehavior     =   0
      OwnerDraw       =   0
      Editable        =   2
      ShowComboButton =   1
      WordWrap        =   0   'False
      TextStyle       =   0
      TextStyleFixed  =   0
      OleDragMode     =   0
      OleDropMode     =   0
      DataMode        =   0
      VirtualData     =   -1  'True
      DataMember      =   ""
      ComboSearch     =   3
      AutoSizeMouse   =   -1  'True
      FrozenRows      =   0
      FrozenCols      =   0
      AllowUserFreezing=   0
      BackColorFrozen =   0
      ForeColorFrozen =   0
      WallPaperAlignment=   9
      AccessibleName  =   ""
      AccessibleDescription=   ""
      AccessibleValue =   ""
      AccessibleRole  =   24
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "ִ�п���"
      Height          =   180
      Left            =   120
      TabIndex        =   9
      Top             =   5760
      Width           =   720
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "��������"
      Height          =   180
      Left            =   120
      TabIndex        =   5
      Top             =   5280
      Width           =   720
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "��ʼ����"
      Height          =   180
      Left            =   120
      TabIndex        =   4
      Top             =   4760
      Width           =   720
   End
End
Attribute VB_Name = "frmDocPrintPatiList"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private mstrReturn As String
Private mblUseCheckNo As Boolean
Private mlngModule As Long
Private mlngDepID As Long

Public Function Showfrm(frmParent As Form, ByVal dtStart As Date, ByVal dtEnd As Date, ByVal lngModule As Long, ByVal lngDepID As Long) As String
'������vsList�����б�blnCanPrint ƽ�ﱨ����Ҫ��˲��ܴ�ӡ
    Dim i As Integer
    
    mstrReturn = ""
    
    dtpStart.value = dtStart
    dtpEnd.value = dtEnd
    mlngModule = lngModule
    mlngDepID = lngDepID
    
    
    If mlngModule = G_LNG_PATHSTATION_MODULE Then
        frmNo.Caption = "����Ų�ѯ�����ú�ʹ��ʱ�䷶Χ��"
    Else
        frmNo.Caption = "���Ų�ѯ�����ú�ʹ��ʱ�䷶Χ��"
    End If
    
    For i = 0 To cboDep.ListCount - 1
        If cboDep.ItemData(i) = mlngDepID Then
            cboDep.ListIndex = i
            Exit For
        End If
    Next
    
    Call InitReleationList
    Call LoadListDate
    
    Me.Show 1, frmParent
    Showfrm = mstrReturn
End Function


Private Sub InitReleationList()
'��ʼ�������б�

    With vsfList
        .FixedCols = 0
        .FixedRows = 1
        
        .GridLines = flexGridFlat
        .BackColorBkg = .BackColor
        .SheetBorder = .BackColor
        .ExtendLastCol = True
        .Redraw = flexRDBuffered
        .OutlineCol = 1
        .OutlineBar = flexOutlineBarCompleteLeaf
        .Ellipsis = flexEllipsisEnd
        
        .AllowSelection = False
        .HighLight = flexHighlightAlways
        .ScrollTrack = True
        .SelectionMode = flexSelectionByRow
    End With
End Sub

Private Sub chkChoose_Click()
On Error GoTo errH
    Dim i As Integer
    Dim intCol As Integer
    
    intCol = vsfList.ColIndex("��ӡѡ��")
    
    If chkChoose.value = 1 Then
        chkChoose.Caption = "ȫ��(&D)"
        For i = 1 To vsfList.Rows - 1
            vsfList.Cell(flexcpChecked, i, intCol) = 1
        Next
    Else
        chkChoose.Caption = "ȫѡ(&A)"
        For i = 1 To vsfList.Rows - 1
            vsfList.Cell(flexcpChecked, i, intCol) = 2
        Next
    End If
    Exit Sub
errH:
     MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

Private Sub cmdAllNoPrint_Click()
On Error GoTo errH
    Dim i As Integer
    Dim intColPrint As Integer
    Dim intColName As Integer
    
    intColPrint = vsfList.ColIndex("��ӡ״̬")
    intColName = vsfList.ColIndex("��ӡѡ��")

    For i = 1 To vsfList.Rows - 1
        If Len(Trim(vsfList.TextMatrix(i, intColPrint))) = 0 And Val(vsfList.TextMatrix(i, intColName)) = 0 Then vsfList.Cell(flexcpChecked, i, intColName) = 1
    Next
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdOk_Click()
    '��֯����ֵ������ֵ��"ҽ��ID�������ĵ��༭��:����ID��-�༭������-ִ�п���ID-�Ƿ�ת��|ҽ��ID�������ĵ��༭��:����ID��-�༭������-ִ�п���ID-�Ƿ�ת��|..."���
    Dim i As Long

    mstrReturn = ""
    For i = 1 To vsfList.Rows - 1
        If vsfList.Cell(flexcpChecked, i, vsfList.ColIndex("��ӡѡ��")) = 1 Then
            If vsfList.Cell(flexcpText, i, vsfList.ColIndex("PACS����")) = 2 Then
                mstrReturn = mstrReturn & "|" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("�ĵ�ID")) & "-"
            Else
                mstrReturn = mstrReturn & "|" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("ҽ��ID")) & "-"
            End If
            mstrReturn = mstrReturn & vsfList.Cell(flexcpText, i, vsfList.ColIndex("PACS����")) & "-" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("ִ�п���ID")) & "-" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("�Ƿ�ת��"))
        End If
    Next

    mstrReturn = Mid(mstrReturn, 2)
    Unload Me
End Sub

Private Sub cmdFind_Click()
    Call LoadListDate
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyF2 Then
        cmdOk_Click
    End If
End Sub

Private Sub Form_Load()
    txtCheckNoStart = ""
    txtCheckNoEnd = ""
    Call InitcboDep
End Sub

Private Sub vsfList_BeforeEdit(ByVal Row As Long, ByVal Col As Long, Cancel As Boolean)
    If Col <> 1 Then Cancel = True
End Sub

Private Sub LoadListDate()
'��ʾ�б�����
On Error GoTo errH
    Dim dtStart As Date
    Dim dtEnd As Date
    Dim strSQL As String, strSQLMoved As String
    Dim rsTmp As Recordset
    Dim intColdepID As Integer
    Dim intType As ReportType
    Dim blnCanPrint As Boolean
    Dim strTmp As String
    Dim iCount As Integer
    Dim i As Integer, j As Integer
    Dim strSQLCheckNoOrDate As String
    Dim strSQLDeptID As String
    Dim strMoved As String
    Dim lngDeptId As Long
    
    '''����վSQL����
    Dim strSQLPatholCOL As String
    Dim strSQLPatholTABLE As String
    Dim strSQLPatholFILTER As String
    
    lngDeptId = 0
    strSQLDeptID = ""
    strSQLCheckNoOrDate = ""
    If valInput() = False Then Exit Sub
    If mblUseCheckNo Then
        If mlngModule = G_LNG_PATHSTATION_MODULE Then
            strSQLCheckNoOrDate = " And I.����� Between [3] And [4] "
        Else
            strSQLCheckNoOrDate = " And D.���� Between [3] And [4] "
        End If
    Else
        strSQLCheckNoOrDate = " And A.����ʱ�� Between [1] and [2]  "
    End If
        
    If (cboDep.Text) <> "ȫ������" And cboDep.ListIndex > -1 Then
        strSQLDeptID = " And A.ִ�п���ID=[5] "
        lngDeptId = cboDep.ItemData(cboDep.ListIndex)
    End If
    
    vsfList.Clear
    blnCanPrint = GetDeptPara(UserInfo.����ID, "ƽ������˲��ܴ򱨸�") = "1"
    dtStart = dtpStart.value
    dtEnd = dtpEnd.value
    
    
   strMoved = " 0 as �Ƿ�ת�� "
   
    If mlngModule = G_LNG_PATHSTATION_MODULE Then
        strSQLPatholCOL = "I.����� as �����,"
        strSQLPatholTABLE = ",��������Ϣ I "
        strSQLPatholFILTER = "And A.ID=I.ҽ��ID(+)"
    Else
        strSQLPatholCOL = " '' as �����,"
        strSQLPatholTABLE = ""
        strSQLPatholFILTER = ""
    End If
    
    If blnCanPrint Then
    '�������=true �ϰ汨�������߼�������ҽ���б����ˣ�����������Ҫ�����
      strSQL = "SELECT A.ID as ҽ��ID," & strSQLPatholCOL & "'' as ��ӡѡ��,decode(Nvl(A.Ӥ��, 0), 0, A.����, Decode(G.Ӥ������, null, A.���� || '֮��' || G.���, G.Ӥ������)) as ����," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, A.�Ա�, G.Ӥ���Ա� ) as �Ա�," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, nvl(D.����,A.����), decode(D.����, null, decode(G.����ʱ��, null,Zl_Age_Calc(0, G.����ʱ��, A.����ʱ��), Zl_Age_Calc(0, G.����ʱ��, G.����ʱ��)), D.����)) as ����," & vbNewLine & _
        "decode(nvl(A.������Դ,0),1,'��',2,'ס',4,'��','��') as ��Դ," & vbNewLine & _
        "D.����," & vbNewLine & _
        "A.ҽ������ as ����,A.ִ�п���ID,H.���� as ִ�п���,'' as ��λ,decode(nvl(D.�����ӡ,0),0,'','��') as ��ӡ״̬ ,'' as PACS����,'' as �����ĵ�����,'' As �ĵ�ID, " & strMoved & vbNewLine & _
        "from ����ҽ����¼ A,����ҽ������ B,Ӱ�����¼ D,����ҽ������ E,������������¼ G,���ű� H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=E.ҽ��ID " & strSQLPatholFILTER & " And A.ID=D.ҽ��ID  And A.ID=B.ҽ��ID And B.ִ�й��� In(4,5,6)" & vbNewLine & _
        "And A.ִ�п���ID=H.ID And A.����ID=G.����ID(+) And A.��ҳID=G.��ҳID(+) And A.Ӥ��=G.���(+) And E.��鱨��ID is null  And a.���id is null" & vbNewLine & _
        "And (A.������־<>1 And D.������ is not null) " & strSQLCheckNoOrDate & strSQLDeptID & vbNewLine & _
        "union all" & vbNewLine & _
        "SELECT A.ID as ҽ��ID," & strSQLPatholCOL & "'' as ��ӡѡ��,decode(Nvl(A.Ӥ��, 0), 0, A.����, Decode(G.Ӥ������, null, A.���� || '֮��' || G.���, G.Ӥ������)) as ����," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, A.�Ա�, G.Ӥ���Ա� ) as �Ա�," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, nvl(D.����,A.����), decode(D.����, null, decode(G.����ʱ��, null,Zl_Age_Calc(0, G.����ʱ��, A.����ʱ��), Zl_Age_Calc(0, G.����ʱ��, G.����ʱ��)), D.����)) as ����," & vbNewLine & _
        "decode(nvl(A.������Դ,0),1,'��',2,'ס',4,'��','��') as ��Դ," & vbNewLine & _
        "D.����," & vbNewLine & _
        "A.ҽ������ as ����,A.ִ�п���ID,H.���� as ִ�п���,'' as ��λ,decode(nvl(E.�����ӡ,0),0,'','��') as ��ӡ״̬,'2' as PACS����,E.�ĵ����� as �����ĵ�����,RawToHex(E.ID) As �ĵ�ID, " & strMoved & vbNewLine & _
        "from ����ҽ����¼ A,Ӱ�����¼ D,Ӱ�񱨸��¼ E,����ҽ������ F,������������¼ G,���ű� H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=F.ҽ��ID " & strSQLPatholFILTER & " And A.ID=D.ҽ��ID  And E.ID= F.��鱨��ID" & vbNewLine & _
        "And A.ִ�п���ID=H.ID And A.����ID=G.����ID(+) And A.��ҳID=G.��ҳID(+) And A.Ӥ��=G.���(+)  And F.��鱨��ID is not null" & vbNewLine & _
        "And E.����״̬ In(2,3,4) " & strSQLCheckNoOrDate & strSQLDeptID

    Else
        strSQL = "SELECT A.ID as ҽ��ID," & strSQLPatholCOL & "'' as ��ӡѡ��,decode(Nvl(A.Ӥ��, 0), 0, A.����, Decode(G.Ӥ������, null, A.���� || '֮��' || G.���, G.Ӥ������)) as ����," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, A.�Ա�, G.Ӥ���Ա� ) as �Ա�," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, nvl(D.����,A.����), decode(D.����, null, decode(G.����ʱ��, null,Zl_Age_Calc(0, G.����ʱ��, A.����ʱ��), Zl_Age_Calc(0, G.����ʱ��, G.����ʱ��)), D.����)) as ����," & vbNewLine & _
        "decode(nvl(A.������Դ,0),1,'��',2,'ס',4,'��','��') as ��Դ," & vbNewLine & _
        "D.����," & vbNewLine & _
        "A.ҽ������ as ����,A.ִ�п���ID,H.���� as ִ�п���,'' as ��λ,decode(nvl(D.�����ӡ,0),0,'','��') as ��ӡ״̬ ,'' as PACS����,'' as �����ĵ�����,'' As �ĵ�ID, " & strMoved & vbNewLine & _
        "from ����ҽ����¼ A,����ҽ������ B,Ӱ�����¼ D,����ҽ������ E,������������¼ G,���ű� H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=E.ҽ��ID " & strSQLPatholFILTER & "And A.ID=D.ҽ��ID  And A.ID=B.ҽ��ID And B.ִ�й��� In(4,5,6)" & vbNewLine & _
        "And A.ִ�п���ID=H.ID And A.����ID=G.����ID(+) And A.��ҳID=G.��ҳID(+) And A.Ӥ��=G.���(+) And E.��鱨��ID is null  " & vbNewLine & _
        "And a.���id is null " & strSQLCheckNoOrDate & strSQLDeptID & vbNewLine & _
        "union all" & vbNewLine & _
        "SELECT A.ID as ҽ��ID," & strSQLPatholCOL & "'' as ��ӡѡ��,decode(Nvl(A.Ӥ��, 0), 0, A.����, Decode(G.Ӥ������, null, A.���� || '֮��' || G.���, G.Ӥ������)) as ����," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, A.�Ա�, G.Ӥ���Ա� ) as �Ա�," & vbNewLine & _
        "decode(Nvl(A.Ӥ��, 0), 0, nvl(D.����,A.����), decode(D.����, null, decode(G.����ʱ��, null,Zl_Age_Calc(0, G.����ʱ��, A.����ʱ��), Zl_Age_Calc(0, G.����ʱ��, G.����ʱ��)), D.����)) as ����," & vbNewLine & _
        "decode(nvl(A.������Դ,0),1,'��',2,'ס',4,'��','��') as ��Դ," & vbNewLine & _
        "D.����," & vbNewLine & _
        "A.ҽ������ as ����,A.ִ�п���ID,H.���� as ִ�п���,'' as ��λ,decode(nvl(E.�����ӡ,0),0,'','��') as ��ӡ״̬,'2' as PACS����,E.�ĵ����� as �����ĵ�����,RawToHex(E.ID) As �ĵ�ID, " & strMoved & vbNewLine & _
        "from ����ҽ����¼ A,Ӱ�����¼ D,Ӱ�񱨸��¼ E,����ҽ������ F,������������¼ G,���ű� H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=F.ҽ��ID " & strSQLPatholFILTER & " And A.ID=D.ҽ��ID  And E.ID= F.��鱨��ID" & vbNewLine & _
        "And A.ִ�п���ID=H.ID And A.����ID=G.����ID(+) And A.��ҳID=G.��ҳID(+) And A.Ӥ��=G.���(+)  And F.��鱨��ID is not null" & vbNewLine & _
        "And E.����״̬ In(2,3,4) " & strSQLCheckNoOrDate & strSQLDeptID
    End If

    If MovedByDate(dtStart) Then
        strSQLMoved = Replace(strSQL, strMoved, " 1 as �Ƿ�ת�� ")
        strSQLMoved = Replace(strSQL, "Ӱ�����¼", " 1 as �Ƿ�ת�� ")
        strSQLMoved = Replace(strSQL, "����ҽ����¼", " 1 as �Ƿ�ת�� ")
        strSQLMoved = Replace(strSQL, "����ҽ������", " 1 as �Ƿ�ת�� ")
        strSQLMoved = Replace(strSQL, "Ӱ�񱨸��¼", " 1 as �Ƿ�ת�� ")
        strSQL = strSQL & " union all " & strSQLMoved
    End If
                
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "������ӡ���ݻ�ȡ", dtStart, dtEnd, txtCheckNoStart.Text, txtCheckNoEnd.Text, lngDeptId)
    
    Set vsfList.DataSource = rsTmp
    
    '�б��ʽ�޸�
    
    vsfList.ColPosition(vsfList.ColIndex("��ӡѡ��")) = 1
    vsfList.ColPosition(vsfList.ColIndex("��ӡ״̬")) = 2
    vsfList.ColPosition(vsfList.ColIndex("����")) = 3
    vsfList.ColPosition(vsfList.ColIndex("�����")) = 4
    vsfList.ColPosition(vsfList.ColIndex("����")) = 5
    vsfList.ColPosition(vsfList.ColIndex("�Ա�")) = 6
    vsfList.ColPosition(vsfList.ColIndex("����")) = 7
    vsfList.ColPosition(vsfList.ColIndex("����")) = 8
    
    vsfList.ColDataType(vsfList.ColIndex("��ӡѡ��")) = flexDTBoolean
    vsfList.ColHidden(vsfList.ColIndex("�Ƿ�ת��")) = True
    vsfList.ColHidden(vsfList.ColIndex("�ĵ�ID")) = True
    vsfList.ColHidden(vsfList.ColIndex("PACS����")) = True
    vsfList.ColHidden(vsfList.ColIndex("ִ�п���ID")) = True
    vsfList.ColHidden(vsfList.ColIndex("ҽ��ID")) = True
    'Pacs���������ݿ�����ʾTODO
    
    vsfList.ColHidden(vsfList.ColIndex("�����")) = Not (mlngModule = G_LNG_PATHSTATION_MODULE)
    vsfList.ColHidden(vsfList.ColIndex("����")) = (mlngModule = G_LNG_PATHSTATION_MODULE)
    
    If rsTmp.EOF Then
        Me.Caption = "δ��ѯ�����������ı���"
        Exit Sub
    End If
    
    intColdepID = vsfList.ColIndex("ִ�п���ID")
    
    
    With vsfList
        For i = 1 To rsTmp.RecordCount
            intType = GetDeptPara(.Cell(flexcpText, i, intColdepID), "����༭��", 0)
            
            If intType = PACS����༭�� Then
                .Cell(flexcpText, i, .ColIndex("PACS����")) = 1
            ElseIf intType = ���Ӳ����༭�� Then
                .Cell(flexcpText, i, .ColIndex("PACS����")) = 0
            End If
            
            strTmp = .Cell(flexcpText, i, .ColIndex("����"))
            If InStr(strTmp, ":") > 0 Then
                .Cell(flexcpText, i, .ColIndex("����")) = Split(strTmp, ":")(0)
                .Cell(flexcpText, i, .ColIndex("��λ")) = Split(strTmp, ":")(1)
            End If
            
        Next
    End With
    
    Me.Caption = "ѡ����Ҫ��ӡ�ı��棬�б��б�������Ϊ��" & rsTmp.RecordCount
    
    '�Զ��п�
    vsfList.AutoSize 0, vsfList.Cols - 1
    '���ݿ���
    If vsfList.Rows > 1 Then vsfList.Cell(flexcpAlignment, 1, 1, vsfList.Rows - 1, vsfList.Cols - 1) = flexAlignLeftCenter
    
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

Private Function valInput() As Boolean
'����������֤
'Ŀǰֻ��֤����
'valInput �Ƿ���֤ͨ��
'mblUseCheckNo ���Ƿ�ʹ�ü��ŷ�Χ
    valInput = True
    
    If Len(txtCheckNoStart) <> 0 And Len(txtCheckNoEnd) <> 0 Then
        mblUseCheckNo = True
        Exit Function
    End If
    
    If Len(txtCheckNoStart) > 0 And Len(txtCheckNoEnd) = 0 Then
        MsgBox "�������������"
        valInput = False
    End If
    
    If Len(txtCheckNoEnd) > 0 And Len(txtCheckNoStart) = 0 Then
        MsgBox "�����뿪ʼ����"
        valInput = False
    End If
    mblUseCheckNo = False
End Function

Private Sub InitcboDep()
'��ʼ������
On Error GoTo errH
    Dim strFrom As String
    Dim strSQL As String
    Dim rsData As Recordset
    
    cboDep.Clear
    cboDep.AddItem ("ȫ������")
    cboDep.ItemData(cboDep.ListCount - 1) = 0
    
    strFrom = "1,2,3"
    strSQL = " Select Distinct A.ID,A.����,A.����" & _
        " From ���ű� A,��������˵�� B " & _
        " Where B.����ID = A.ID " & _
        " And (A.����ʱ��=TO_DATE('3000-01-01','YYYY-MM-DD') Or A.����ʱ�� is NULL) " & _
        " And (A.վ��='" & gstrNodeNo & "' Or A.վ�� is Null ) " & _
        " And instr([1],','||B.�������||',')> 0 And B.�������� IN('���')" & _
        " Order by A.����"
        
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, CStr("," & strFrom & ","))
    
    If rsData.RecordCount <= 0 Then Exit Sub

    While Not rsData.EOF
        cboDep.AddItem (rsData!���� & "")
        cboDep.ItemData(cboDep.ListCount - 1) = rsData!ID
        rsData.MoveNext
    Wend
    
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

