VERSION 5.00
Object = "{BEEECC20-4D5F-4F8B-BFDC-5D9B6FBDE09D}#1.0#0"; "vsflex8.ocx"
Begin VB.Form frmImgSrv 
   BorderStyle     =   0  'None
   Caption         =   "Ӱ����շ���"
   ClientHeight    =   6390
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   11505
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6390
   ScaleWidth      =   11505
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  '����ȱʡ
   Begin VB.Frame fraReceiveSet 
      ForeColor       =   &H00FF0000&
      Height          =   6315
      Left            =   120
      TabIndex        =   6
      Top             =   0
      Width           =   11310
      Begin VB.Frame Frame2 
         Caption         =   "����ͼ������"
         Height          =   2490
         Left            =   120
         TabIndex        =   23
         Top             =   3720
         Width           =   11055
         Begin VSFlex8Ctl.VSFlexGrid vsfRejectImageList 
            Height          =   2055
            Left            =   120
            TabIndex        =   24
            Top             =   240
            Width           =   10815
            _cx             =   19076
            _cy             =   3625
            Appearance      =   0
            BorderStyle     =   1
            Enabled         =   -1  'True
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "����"
               Size            =   9
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
            BackColorSel    =   16772055
            ForeColorSel    =   -2147483640
            BackColorBkg    =   -2147483643
            BackColorAlternate=   -2147483643
            GridColor       =   -2147483636
            GridColorFixed  =   -2147483636
            TreeColor       =   -2147483632
            FloodColor      =   192
            SheetBorder     =   -2147483643
            FocusRect       =   1
            HighLight       =   1
            AllowSelection  =   -1  'True
            AllowBigSelection=   -1  'True
            AllowUserResizing=   0
            SelectionMode   =   1
            GridLines       =   1
            GridLinesFixed  =   1
            GridLineWidth   =   1
            Rows            =   3
            Cols            =   2
            FixedRows       =   1
            FixedCols       =   0
            RowHeightMin    =   300
            RowHeightMax    =   0
            ColWidthMin     =   0
            ColWidthMax     =   0
            ExtendLastCol   =   -1  'True
            FormatString    =   ""
            ScrollTrack     =   -1  'True
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
            Editable        =   0
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
      End
      Begin VB.TextBox txtPhysician 
         Height          =   270
         Left            =   1740
         TabIndex        =   22
         ToolTipText     =   "��������ȡ��鼼ʦ��DICOM�ֶ������ο���ʽ���£�8:90"
         Top             =   1320
         Width           =   1940
      End
      Begin VB.CheckBox chkPhysician 
         Caption         =   "��ȡ��鼼ʦ"
         Height          =   255
         Left            =   240
         TabIndex        =   21
         Top             =   1320
         Width           =   1575
      End
      Begin VB.ComboBox cboDevice 
         Height          =   300
         ItemData        =   "frmImgSrv.frx":0000
         Left            =   1740
         List            =   "frmImgSrv.frx":0002
         Style           =   2  'Dropdown List
         TabIndex        =   13
         Top             =   345
         Width           =   1940
      End
      Begin VB.ComboBox cboEncode 
         Height          =   300
         ItemData        =   "frmImgSrv.frx":0004
         Left            =   1740
         List            =   "frmImgSrv.frx":0014
         Style           =   2  'Dropdown List
         TabIndex        =   12
         Top             =   840
         Width           =   1940
      End
      Begin VB.Frame FraAuto 
         Caption         =   "�Զ�ƥ������"
         Height          =   1890
         Left            =   120
         TabIndex        =   7
         Top             =   1680
         Width           =   11055
         Begin VB.Frame Frame1 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H80000008&
            Height          =   1140
            Left            =   5400
            TabIndex        =   16
            Top             =   600
            Width           =   4065
            Begin VB.OptionButton optMatch 
               Caption         =   "�� ""ҽ��ID"" ƥ��"
               Height          =   195
               Index           =   2
               Left            =   690
               TabIndex        =   19
               ToolTipText     =   "��ҽ��ID�����˺ͽ��յ�Ӱ�����ƥ��"
               Top             =   780
               Width           =   3300
            End
            Begin VB.OptionButton optMatch 
               Caption         =   "�� ""����"" ƥ��"
               Height          =   195
               Index           =   0
               Left            =   690
               TabIndex        =   18
               ToolTipText     =   "�����Ž����˺ͽ��յ�Ӱ�����ƥ��"
               Top             =   240
               Width           =   3300
            End
            Begin VB.OptionButton optMatch 
               Caption         =   "�� ""���˱�ʶ��(����/סԺ��)"" ƥ��"
               Height          =   195
               Index           =   1
               Left            =   690
               TabIndex        =   17
               ToolTipText     =   "�����˱�ʶ�Ž����˺ͽ��յ�Ӱ�����ƥ��"
               Top             =   510
               Width           =   3300
            End
            Begin VB.Label lblDataItem 
               Caption         =   "���ݿ���Ŀ"
               Height          =   885
               Left            =   90
               TabIndex        =   20
               Top             =   150
               Width           =   225
            End
            Begin VB.Line Line5 
               X1              =   345
               X2              =   510
               Y1              =   585
               Y2              =   585
            End
            Begin VB.Line Line6 
               X1              =   510
               X2              =   510
               Y1              =   315
               Y2              =   890
            End
            Begin VB.Line Line7 
               X1              =   510
               X2              =   630
               Y1              =   315
               Y2              =   315
            End
            Begin VB.Line Line8 
               X1              =   525
               X2              =   630
               Y1              =   870
               Y2              =   870
            End
         End
         Begin VB.OptionButton optImgMatch 
            Caption         =   "Accession Number"
            Height          =   255
            Index           =   1
            Left            =   1440
            TabIndex        =   10
            Top             =   1155
            Width           =   1740
         End
         Begin VB.OptionButton optImgMatch 
            Caption         =   "Patient Name"
            Height          =   255
            Index           =   2
            Left            =   1440
            TabIndex        =   9
            Top             =   1425
            Width           =   1740
         End
         Begin VB.OptionButton optImgMatch 
            Caption         =   "Patient ID"
            Height          =   255
            Index           =   0
            Left            =   1440
            TabIndex        =   8
            Top             =   885
            Width           =   1740
         End
         Begin VB.ComboBox cboMatchOther 
            Height          =   300
            ItemData        =   "frmImgSrv.frx":0045
            Left            =   8070
            List            =   "frmImgSrv.frx":004F
            Style           =   2  'Dropdown List
            TabIndex        =   5
            Top             =   330
            Width           =   1785
         End
         Begin VB.CheckBox chkMatchStudyUID 
            Caption         =   "���� ""���UID"" ƥ��"
            Height          =   300
            Left            =   120
            TabIndex        =   2
            Top             =   360
            Width           =   2100
         End
         Begin VB.CheckBox chkImageType 
            Caption         =   "����ͼ�����Ͳ������"
            Height          =   300
            Left            =   3360
            TabIndex        =   3
            Top             =   375
            Width           =   2130
         End
         Begin VB.Line Line4 
            X1              =   1290
            X2              =   1395
            Y1              =   1545
            Y2              =   1545
         End
         Begin VB.Line Line3 
            X1              =   1275
            X2              =   1395
            Y1              =   990
            Y2              =   990
         End
         Begin VB.Line Line2 
            X1              =   1275
            X2              =   1275
            Y1              =   990
            Y2              =   1565
         End
         Begin VB.Line Line1 
            X1              =   1095
            X2              =   1260
            Y1              =   1260
            Y2              =   1260
         End
         Begin VB.Label lblImgItem 
            Caption         =   "ͼ����Ŀ"
            Height          =   690
            Left            =   840
            TabIndex        =   11
            Top             =   930
            Width           =   225
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            Caption         =   "����ƥ��(&A)"
            Height          =   180
            Left            =   6960
            TabIndex        =   4
            ToolTipText     =   "�ò������[���ݿ���Ŀ]��""���˱�ʶ��""/""����""ƥ����Ч"
            Top             =   390
            Width           =   990
         End
      End
      Begin VSFlex8Ctl.VSFlexGrid vfgList 
         Height          =   1290
         Left            =   5010
         TabIndex        =   14
         Top             =   225
         Width           =   6150
         _cx             =   10848
         _cy             =   2275
         Appearance      =   0
         BorderStyle     =   1
         Enabled         =   -1  'True
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   9
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
         BackColorSel    =   16772055
         ForeColorSel    =   -2147483640
         BackColorBkg    =   -2147483643
         BackColorAlternate=   -2147483643
         GridColor       =   -2147483636
         GridColorFixed  =   -2147483636
         TreeColor       =   -2147483632
         FloodColor      =   192
         SheetBorder     =   -2147483643
         FocusRect       =   0
         HighLight       =   1
         AllowSelection  =   0   'False
         AllowBigSelection=   -1  'True
         AllowUserResizing=   1
         SelectionMode   =   1
         GridLines       =   1
         GridLinesFixed  =   1
         GridLineWidth   =   1
         Rows            =   3
         Cols            =   2
         FixedRows       =   1
         FixedCols       =   0
         RowHeightMin    =   300
         RowHeightMax    =   0
         ColWidthMin     =   0
         ColWidthMax     =   0
         ExtendLastCol   =   -1  'True
         FormatString    =   ""
         ScrollTrack     =   -1  'True
         ScrollBars      =   3
         ScrollTips      =   0   'False
         MergeCells      =   0
         MergeCompare    =   0
         AutoResize      =   0   'False
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
         Editable        =   0
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
      Begin VB.Line Line12 
         X1              =   4545
         X2              =   4710
         Y1              =   840
         Y2              =   840
      End
      Begin VB.Line Line11 
         X1              =   4710
         X2              =   4710
         Y1              =   570
         Y2              =   1145
      End
      Begin VB.Line Line10 
         X1              =   4710
         X2              =   4830
         Y1              =   570
         Y2              =   570
      End
      Begin VB.Line Line9 
         X1              =   4725
         X2              =   4830
         Y1              =   1125
         Y2              =   1125
      End
      Begin VB.Label lblRoute 
         Caption         =   "�Զ�ת������"
         Height          =   1080
         Left            =   4335
         TabIndex        =   15
         Top             =   330
         Width           =   225
      End
      Begin VB.Label LblCmp 
         AutoSize        =   -1  'True
         Caption         =   "ѹ����ʽ(&Y)"
         Height          =   180
         Left            =   240
         TabIndex        =   1
         Top             =   900
         Width           =   990
      End
      Begin VB.Label lblSave 
         AutoSize        =   -1  'True
         Caption         =   "�洢�豸(&F)"
         Height          =   180
         Left            =   240
         TabIndex        =   0
         Top             =   405
         Width           =   990
      End
   End
End
Attribute VB_Name = "frmImgSrv"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private mlngSrvID As Long

'�Զ�·�ɵĲ����ͳ���
Private str�Զ�·��Ŀ�ĵ� As String
Private str�Զ�·��ѹ����ʽ As String
Private str�Զ�·��Ŀ¼�ṹ As String
Private mstr����ͼ�� As String

Private Const AR��ѹ�� = "��ѹ��"
Private Const AR����ѹ�� = "����ǰ��ʽѹ��"
Private Const AR��鼶�� = "��鼶��(Ĭ��)"
Private Const AR���м��� = "���м���(3D)"


Public Sub ShowRefresh(ByVal SrvID As Long)
    mlngSrvID = SrvID
    If mlngSrvID = 0 Then
        fraReceiveSet.Caption = "�Ϸ��б�����ѡ������δ���棬���ܽ������ã�"
        fraReceiveSet.Enabled = False
    Else
        fraReceiveSet.Caption = ""
        fraReceiveSet.Enabled = True
    End If
    RefreshPara
End Sub

Private Sub RefreshPara()
On Error GoTo errH
    Dim rsTemp As New ADODB.Recordset, i As Integer
    
    gstrSQL = "select ����ID,�������� ,����ֵ from Ӱ��DICOM������� where ����ID=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ����", mlngSrvID)
    InitvfgList
    cboDevice.ListIndex = -1
    cboEncode.ListIndex = -1
    chkImageType.value = False
    chkMatchStudyUID.value = False
    cboMatchOther.ListIndex = 0
    chkPhysician.value = 0
    txtPhysician.Text = ""
    str�Զ�·��Ŀ�ĵ� = ""
    str�Զ�·��ѹ����ʽ = ""
    str�Զ�·��Ŀ¼�ṹ = ""
    mstr����ͼ�� = ""
    
    Do Until rsTemp.EOF
        Select Case rsTemp!��������
            Case "�洢�豸"
                Call SeekIndex(cboDevice, nvl(rsTemp!����ֵ), True, , tNeedNo)
            Case "ѹ����ʽ"
                Call SeekIndex(cboEncode, nvl(rsTemp!����ֵ), True)
            Case "�����UIDƥ��"
                chkMatchStudyUID.value = rsTemp!����ֵ
            Case "�����Ͳ������"
                chkImageType.value = rsTemp!����ֵ
            Case "ƥ��ͼ����Ŀ"
                optImgMatch(nvl(rsTemp!����ֵ, 0)) = True
            Case "ƥ�����ݿ���Ŀ"
                optMatch(nvl(rsTemp!����ֵ, 0)) = True
            Case "��Ϣת��" '�����ʽ "Ŀ�ĵ�1|Ŀ�ĵ�2---" ��Ϣ��UDP��Ϣ,��������Ϊ����վ����������ʵ���Զ�����,����鿴ʱ����ȡ
                Call FillBlRoute("��Ϣת��", nvl(rsTemp!����ֵ), "", "")
            Case "�Զ�·��"
                str�Զ�·��Ŀ�ĵ� = nvl(rsTemp!����ֵ)
            Case "�Զ�·��ѹ����ʽ"
                str�Զ�·��ѹ����ʽ = nvl(rsTemp!����ֵ)
            Case "�Զ�·��Ŀ¼�ṹ"
                str�Զ�·��Ŀ¼�ṹ = nvl(rsTemp!����ֵ)
            Case "�洢���˷�ʽ"
                Call SeekIndex(cboMatchOther, nvl(rsTemp!����ֵ, 0), True, , tNeedNo)
            Case "��ȡ��鼼ʦ"
                If InStr(nvl(rsTemp!����ֵ), ":") > 0 Then
                    chkPhysician.value = 1
                    txtPhysician.Text = nvl(rsTemp!����ֵ)
                End If
            Case "����ͼ��"
                mstr����ͼ�� = nvl(rsTemp!����ֵ)
        End Select
        rsTemp.MoveNext
    Loop
    
    '��д�Զ�·�ɲ���
    If str�Զ�·��Ŀ�ĵ� <> "" Then
        Call FillBlRoute("�Զ�·��", str�Զ�·��Ŀ�ĵ�, str�Զ�·��ѹ����ʽ, str�Զ�·��Ŀ¼�ṹ)
    End If
    
    '����ͼ�����Ͳ�����С����������ֻ�����ĳЩCTʹ��
    gstrSQL = "select Ӱ����� from Ӱ��DICOM����� A,Ӱ���豸Ŀ¼ B WHERE A.����ID=[1] AND A.�豸��=B.�豸��"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ����", mlngSrvID)
    If Not rsTemp.EOF Then
        If UCase(rsTemp!Ӱ�����) <> "CT" Then
            chkImageType.value = 0
            chkImageType.Visible = False
        End If
    End If
    
    '��д����ͼ�����
    Call LoadRejectImageList(mstr����ͼ��)
    
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub FillBlRoute(ByVal strType As String, ByVal strData As String, ByVal strPara1 As String, ByVal strPara2 As String)
'------------------------------------------------
'���ܣ���д�Զ�·�ɻ�����Ϣת������Ϣ����Ϣת����ʽ���ڻ�û��ʹ��
'������ strType--����---���Զ�·�ɡ����ߡ���Ϣת����
'       strData--�������ݣ������Զ�·����Ŀ�ĵ�
'       strPara1--��������1�������Զ�·����ѹ����ʽ,
'       strPara2--��������2�������Զ�·����Ŀ¼�ṹ
'���أ��ޣ�ֱ����д�ؼ�
'------------------------------------------------
    Dim i As Integer, j As Integer
    Dim blnWritePara As Boolean
    '�����ʽ "·�ɷ�ʽ,Ŀ�ĵ�|---" ·�ɷ�ʽ��Ϊ ·��/��Ϣ ,·�ɼ���DICOM����,��Ϣ��UDP��Ϣ,��������Ϊ����վ����������ʵ���Զ�����,����鿴ʱ����ȡ
    
    If strData = "" Then Exit Sub
    
    '�������
    If strType = "�Զ�·��" Then
        If UBound(Split(strData, "|")) = UBound(Split(strPara1, "|")) And UBound(Split(strData, "|")) = UBound(Split(strPara2, "|")) Then
            blnWritePara = True
        Else
            blnWritePara = False
        End If
    End If
    
    With vfgList
        For i = 0 To UBound(Split(strData, "|"))
            .TextMatrix(.Rows - 1, 0) = strType
            If strType = "�Զ�·��" Then '�Զ�·�ɱ�����豸��,ͨ��ѭ����Cbo������ȡ��
                For j = 0 To UBound(Split(.ColComboList(1), "|"))
                    If InStr(Split(.ColComboList(1), "|")(j), Split(strData, "|")(i)) > 0 Then
                        .TextMatrix(.Rows - 1, 1) = Split(.ColComboList(1), "|")(j)
                        If blnWritePara = True Then '�в��������ղ�������д
                            .TextMatrix(.Rows - 1, 2) = IIf(Split(strPara1, "|")(i) = 1, AR��ѹ��, AR����ѹ��)
                            .TextMatrix(.Rows - 1, 3) = IIf(Split(strPara2, "|")(i) = 1, AR���м���, AR��鼶��)
                        Else    'û�в���������дĬ��ֵ
                            .TextMatrix(.Rows - 1, 2) = AR����ѹ��
                            .TextMatrix(.Rows - 1, 3) = AR��鼶��
                        End If
                    End If
                Next
            Else
                .TextMatrix(.Rows - 2, 1) = Split(strData, "|")(i)
            End If
            .Rows = .Rows + 1
        Next
        .TextMatrix(.Rows - 1, 0) = "�Զ�·��"
    End With
End Sub

Public Function SavePara() As Boolean
    Dim strData As String
    Dim i As Integer, strData1 As String
    Dim arrSQL() As Variant
    Dim blnInTrans As Boolean       '�Ƿ���������֮��
    
    SavePara = False
    
    On Error GoTo errHandle
    If cboDevice.Text = "" Then
        MsgBoxD Me, "��ѡ��洢�豸��", vbInformation, gstrSysName
        cboDevice.SetFocus
        Exit Function
    End If
    
    If cboEncode.Text = "" Then
        MsgBoxD Me, "��ѡ��ѹ����ʽ��", vbInformation, gstrSysName
        cboEncode.SetFocus
        Exit Function
    End If
    
    If chkPhysician.value = 1 And txtPhysician.Text = "" Then
        MsgBoxD Me, "��������ȡ��鼼ʦ��DICOM�ֶ������ο���ʽ���£�8:90", vbInformation, gstrSysName
        txtPhysician.SetFocus
        Exit Function
    End If
    
    If isRejectImageValid = False Then
        Exit Function
    End If
    
    arrSQL = Array()
    
    If cboDevice.ListIndex <> -1 Then
        gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�洢�豸','" & zlStr.NeedCode(cboDevice.Text) & "')"
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = gstrSQL
    End If
    
    If cboEncode.ListIndex <> -1 Then
        gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'ѹ����ʽ','" & zlStr.NeedName(cboEncode.Text) & "')"
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = gstrSQL
    End If
    
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�����UIDƥ��','" & chkMatchStudyUID.value & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�����Ͳ������','" & chkImageType.value & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�洢���˷�ʽ','" & zlStr.NeedCode(cboMatchOther.Text) & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    strData = 0
    For i = 0 To optImgMatch.UBound
        If optImgMatch(i).value = True Then
            strData = i
            Exit For
        End If
    Next
    If strData = "" Then strData = "0"
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'ƥ��ͼ����Ŀ','" & strData & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL

    strData = 0
    For i = 0 To optMatch.UBound
        If optMatch(i).value = True Then
            strData = i
            Exit For
        End If
    Next
    If strData = "" Then strData = "0"
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'ƥ�����ݿ���Ŀ','" & strData & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    gstrSQL = "Zl_Ӱ��DICOM�������_Delete(" & mlngSrvID & ",'�Զ�·��')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL

    gstrSQL = "Zl_Ӱ��DICOM�������_Delete(" & mlngSrvID & ",'��Ϣת��')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    With vfgList
        strData = ""
        str�Զ�·��ѹ����ʽ = ""
        str�Զ�·��Ŀ¼�ṹ = ""
        For i = 1 To vfgList.Rows - 1
            If Trim(vfgList.TextMatrix(i, 1)) <> "" And vfgList.RowHidden(i) = False Then
                If vfgList.TextMatrix(i, 0) = "�Զ�·��" Then
                    If InStr(strData, zlStr.NeedCode(vfgList.TextMatrix(i, 1))) = 0 Then '�ظ��Ĳ�����
                        strData = strData & "|" & zlStr.NeedCode(vfgList.TextMatrix(i, 1))
                        str�Զ�·��ѹ����ʽ = str�Զ�·��ѹ����ʽ & "|" & IIf(vfgList.TextMatrix(i, 2) = AR��ѹ��, 1, 0)
                        str�Զ�·��Ŀ¼�ṹ = str�Զ�·��Ŀ¼�ṹ & "|" & IIf(vfgList.TextMatrix(i, 3) = AR���м���, 1, 0)
                    End If
                Else
                    If InStr(strData1, vfgList.TextMatrix(i, 1)) = 0 Then '�ظ��Ĳ�����
                        strData1 = strData1 & "|" & vfgList.TextMatrix(i, 1)
                    End If
                End If
            End If
        Next
    End With
    strData = Mid(strData, 2)
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�Զ�·��','" & strData & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    strData1 = Mid(strData1, 2)
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'��Ϣת��','" & strData1 & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    str�Զ�·��ѹ����ʽ = Mid(str�Զ�·��ѹ����ʽ, 2)
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�Զ�·��ѹ����ʽ','" & str�Զ�·��ѹ����ʽ & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    str�Զ�·��Ŀ¼�ṹ = Mid(str�Զ�·��Ŀ¼�ṹ, 2)
    gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'�Զ�·��Ŀ¼�ṹ','" & str�Զ�·��Ŀ¼�ṹ & "')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    If chkPhysician.value = 1 Then
        '������ȡ��鼼ʦ����
        gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'��ȡ��鼼ʦ','" & txtPhysician.Text & "')"
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = gstrSQL
    Else
        'ɾ����ȡ��鼼ʦ����
        gstrSQL = "Zl_Ӱ��DICOM�������_Delete(" & mlngSrvID & ",'��ȡ��鼼ʦ')"
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = gstrSQL
    End If
    
    gstrSQL = "Zl_Ӱ��DICOM�������_Delete(" & mlngSrvID & ",'����ͼ��')"
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = gstrSQL
    
    If vsfRejectImageList.Rows > 1 Then
        strData = ""
        For i = 1 To vsfRejectImageList.Rows - 1
            If vsfRejectImageList.RowHidden(i) = False And _
                Trim(vsfRejectImageList.TextMatrix(i, 0)) <> "" And _
                vsfRejectImageList.TextMatrix(i, 1) <> "" Then
                
                strData = strData & "{;}" & vsfRejectImageList.TextMatrix(i, 0) & "[;]" _
                    & vsfRejectImageList.TextMatrix(i, 1)
            End If
        Next i
        strData = Mid(strData, 4)
        strData = Replace(strData, "'", "''")
        gstrSQL = "Zl_Ӱ��DICOM�������_SAVE(" & mlngSrvID & ",'����ͼ��','" & strData & "')"
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = gstrSQL
    End If
    
    gcnOracle.BeginTrans        '��ʼ�������
    blnInTrans = True
    For i = 0 To UBound(arrSQL)
        Call zlDatabase.ExecuteProcedure(CStr(arrSQL(i)), "����ͼ����ղ���")
    Next i
    gcnOracle.CommitTrans
    blnInTrans = False
    
    RefreshPara
    SavePara = True
    Exit Function
errHandle:
    If blnInTrans = True Then gcnOracle.RollbackTrans
    If ErrCenter = 1 Then
        Resume
    End If
End Function


Private Sub chkPhysician_Click()
    If chkPhysician.value = 1 Then
        txtPhysician.Enabled = True
    Else
        txtPhysician.Enabled = False
    End If
End Sub

Private Sub Form_Load()
    Call InitvfgList
End Sub

Private Sub InitvfgList()
Dim rsTemp As New ADODB.Recordset
    On Error GoTo errHandle
    With vfgList
        .Clear
        .FixedRows = 1
        .Rows = 2
        .Cols = 4
        .ColWidth(0) = 800
        .ColWidth(1) = 800
        .ColWidth(2) = 1000
        .ColWidth(3) = 1000
        .TextMatrix(0, 0) = "ת������"
        .TextMatrix(0, 1) = "ת��Ŀ�ĵ�"
        .TextMatrix(0, 2) = "ѹ����ʽ"
        .TextMatrix(0, 3) = "Ŀ¼�ṹ"
        .ColAlignment(0) = flexAlignLeftCenter
        .ColAlignment(1) = flexAlignLeftCenter
        .ColAlignment(2) = flexAlignLeftCenter
        .ColAlignment(3) = flexAlignLeftCenter
        .TextMatrix(1, 0) = "�Զ�·��"
        .TextMatrix(1, 2) = AR����ѹ��
        .TextMatrix(1, 3) = AR��鼶��
    End With
    gstrSQL = "select �豸��,�豸�� from Ӱ���豸Ŀ¼ where ����=1 and NVL(״̬,0)=1"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ�洢�豸")
    cboDevice.Clear
    Dim strList As String
    Do Until rsTemp.EOF
        cboDevice.AddItem rsTemp!�豸�� & "-" & rsTemp!�豸��
        strList = strList & "|" & rsTemp!�豸�� & "-" & rsTemp!�豸��
        rsTemp.MoveNext
    Loop
    vfgList.ColComboList(1) = strList
    Exit Sub
errHandle:
    If ErrCenter = 1 Then
        Resume
    End If
End Sub

Private Sub vfgList_Click()
    With vfgList
        If .Col = 0 Or .Col = 2 Or .Col = 3 Then
            .Editable = flexEDNone
        Else
            .Editable = flexEDKbdMouse
        End If
    End With
End Sub

Private Sub vfgList_DblClick()
    With vfgList
        If .Col = 0 Then
            If .TextMatrix(.Row, .Col) = "�Զ�·��" Then
                .TextMatrix(.Row, .Col) = "��Ϣת��"
            Else
                .TextMatrix(.Row, .Col) = "�Զ�·��"
            End If
            .TextMatrix(.Row, 1) = ""
            If .TextMatrix(.Row, 0) = "�Զ�·��" Then
                .TextMatrix(.Row, 2) = AR����ѹ��
                .TextMatrix(.Row, 3) = AR��鼶��
            Else
                .TextMatrix(.Row, 2) = ""
                .TextMatrix(.Row, 3) = ""
            End If
        End If
        
        If .Col = 2 Then
            If .TextMatrix(.Row, 2) = AR����ѹ�� Then
                .TextMatrix(.Row, 2) = AR��ѹ��
            Else
                .TextMatrix(.Row, 2) = AR����ѹ��
            End If
        End If
        
        If .Col = 3 Then
            If .TextMatrix(.Row, 3) = AR��鼶�� Then
                .TextMatrix(.Row, 3) = AR���м���
            Else
                .TextMatrix(.Row, 3) = AR��鼶��
            End If
        End If
    End With
End Sub

Private Sub vfgList_KeyDown(KeyCode As Integer, Shift As Integer)
    '�س�������һ��
    If KeyCode = vbKeyReturn Then
        vfgList.Rows = vfgList.Rows + 1
        vfgList.TextMatrix(vfgList.Rows - 1, 0) = "�Զ�·��"
        vfgList.TextMatrix(vfgList.Rows - 1, 2) = AR����ѹ��
        vfgList.TextMatrix(vfgList.Rows - 1, 3) = AR��鼶��
    End If
    'deleteɾ�����һ��
    If KeyCode = vbKeyDelete And vfgList.Row >= 1 Then
        If MsgBoxD(Me, "�Ƿ�ɾ�����У�", vbYesNo) = vbYes Then
            vfgList.RowHidden(vfgList.Row) = True
        End If
    End If
End Sub

Private Sub vfgList_KeyPressEdit(ByVal Row As Long, ByVal Col As Long, KeyAscii As Integer)
    If Col = 0 Then
        KeyAscii = 0
    ElseIf Col = 1 And vfgList.TextMatrix(vfgList.Row, 0) = "�Զ�·��" Then
        KeyAscii = 0
    End If
End Sub

Private Sub LoadRejectImageList(strRejectValue As String)
'------------------------------------------------
'���ܣ����ؾܾ�ͼ���б�
'������ strRejectValue--����ͼ�����
'���أ��ޣ�ֱ����д�ؼ�
'------------------------------------------------
    Dim arrValues() As String
    Dim strName As String
    Dim strValue As String
    Dim i As Integer
    
    On Error GoTo err
    arrValues = Split(strRejectValue, "{;}")
    
    With vsfRejectImageList
        .Clear
        .Rows = UBound(arrValues) + 2
        If .Rows = 1 Then .Rows = 2
        .Cols = 2
        .FixedRows = 1
        .FixedCols = 0
        .AllowUserResizing = flexResizeColumns
        .SelectionMode = flexSelectionByRow
        .Editable = flexEDKbdMouse
        .ScrollBars = flexScrollBarVertical
        .ExtendLastCol = True
        .Appearance = flexFlat
        .FocusRect = flexFocusNone
        .ColAlignment(0) = flexAlignLeftCenter
        .ColAlignment(1) = flexAlignLeftCenter
        .ColWidth(0) = 1200
        .RowHeightMin = 300
        '����
        .TextMatrix(0, 0) = "������������"
        .TextMatrix(0, 1) = "������������"
        
        For i = 0 To UBound(arrValues)
            If UBound(Split(arrValues(i), "[;]")) = 1 Then
                strName = Split(arrValues(i), "[;]")(0)
                strValue = Split(arrValues(i), "[;]")(1)
                .TextMatrix(i + 1, 0) = strName
                .TextMatrix(i + 1, 1) = strValue
            End If
        Next i
    End With
    
    Exit Sub
err:
    If ErrCenter = 1 Then
        Resume
    End If
End Sub

Private Function isRejectImageValid() As Boolean
'------------------------------------------------
'���ܣ��жϾ���ͼ������Ƿ���Ϲ��򣬹�����[8:20] = "xxxx" and [8:21] = "yyyyy"
'������
'���أ��ޣ�ֱ����д�ؼ�
'------------------------------------------------
    '������[8:20] = "xxxx" and [8:21] = "yyyyy" ��ʹ��[8:20] ��ʾͼ���ֶΣ� "xxxx"��ʾ�ֶ�ֵ��ʹ��ǰ����ո��and���Ӷ������
    Dim arrValues() As String
    Dim i As Integer
    Dim strTag As String
    Dim strValue As String
    Dim iRow As Integer
    
    On Error GoTo err
    
    isRejectImageValid = True
    
    For iRow = 1 To vsfRejectImageList.Rows - 1
        If vsfRejectImageList.RowHidden(iRow) = False _
            And Trim(vsfRejectImageList.TextMatrix(iRow, 0)) <> "" _
            And vsfRejectImageList.TextMatrix(iRow, 1) <> "" Then
            
            arrValues = Split(vsfRejectImageList.TextMatrix(iRow, 1), " and ")
            If UBound(arrValues) = -1 Then
                isRejectImageValid = False
            Else
                For i = 0 To UBound(arrValues)
                    If UBound(Split(arrValues(i), " = ")) = 1 Then
                        strTag = Trim(Split(arrValues(i), " = ")(0))
                        strValue = Trim(Split(arrValues(i), " = ")(1))
                        
                        If strTag = "" Then
                            isRejectImageValid = False
                            Exit For
                        End If
                        
                        If Left(strValue, 1) = """" And Right(strValue, 1) = """" Then
                            'ʲô������
                        Else
                            isRejectImageValid = False
                            Exit For
                        End If
                        
                        If Left(strTag, 1) = "[" And Right(strTag, 1) = "]" Then
                            If UBound(Split(strTag, ":")) <> 1 Then
                                isRejectImageValid = False
                                Exit For
                            End If
                        Else
                            isRejectImageValid = False
                            Exit For
                        End If
                    Else
                        isRejectImageValid = False
                        Exit For
                    End If
                Next i
            End If
            
            If isRejectImageValid = False Then
                MsgBoxD Me, "����ͼ������ --- �������������ݡ�����" & vbCrLf & vbCrLf & vsfRejectImageList.TextMatrix(iRow, 1) & vbCrLf & vbCrLf _
                    & "�밴�����¸�ʽ��д����ͼ���������" & vbCrLf & vbCrLf _
                    & "[8:20] = " & """" & "xxxx" & """" & " and [8:21] = " & """" & "yyyyy" & """" & vbCrLf & vbCrLf _
                    & "ͼ�����ݼ�ʹ�á�[���:Ԫ�غ�]����ʾ�����ݵ�ֵ����" & """" & "xxxx" _
                    & """" & vbCrLf & "���������ʹ�� and ���ӣ�ÿ����֮�����Ҫ����һ���ո�", vbOKOnly, "ͼ����շ���"
                Exit Function
            End If
        End If
    Next iRow
    
    Exit Function
err:
    If ErrCenter = 1 Then
        Resume
    End If
End Function

Private Sub vsfRejectImageList_KeyDown(KeyCode As Integer, Shift As Integer)
    Dim i As Integer
    Dim blnRowHidden As Boolean
    
    '�س�������һ��
    If KeyCode = vbKeyReturn Then
        If isRejectImageValid = True Then
            vsfRejectImageList.Rows = vsfRejectImageList.Rows + 1
        End If
    End If
    'deleteɾ�����һ��
    If KeyCode = vbKeyDelete And vsfRejectImageList.Row >= 1 Then
        If MsgBoxD(Me, "�Ƿ�ɾ�����У�", vbYesNo, "��ʾ��Ϣ") = vbYes Then
            vsfRejectImageList.RowHidden(vsfRejectImageList.Row) = True
            
            '������һ�б�ɾ�����Զ�����һ�У������û�����
            blnRowHidden = True
            For i = 1 To vsfRejectImageList.Rows - 1
                blnRowHidden = blnRowHidden And vsfRejectImageList.RowHidden(i)
            Next i
            If blnRowHidden = True Then
                vsfRejectImageList.Rows = vsfRejectImageList.Rows + 1
            End If
        End If
    End If
End Sub
