VERSION 5.00
Object = "{BEEECC20-4D5F-4F8B-BFDC-5D9B6FBDE09D}#1.0#0"; "vsflex8.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{A8E5842E-102B-4289-9D57-3B3F5B5E15D3}#9.60#0"; "Codejock.SuiteCtrls.9600.ocx"
Object = "{555E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.CommandBars.9600.ocx"
Object = "{79EB16A5-917F-4145-AB5F-D3AEA60612D8}#16.3#0"; "Codejock.Calendar.v16.3.1.ocx"
Begin VB.Form frmParPacs 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Ӱ���������"
   ClientHeight    =   8580
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   11250
   Icon            =   "frmParPacs.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8580
   ScaleWidth      =   11250
   StartUpPosition =   1  '����������
   Begin VB.PictureBox picFunc 
      Align           =   3  'Align Left
      Appearance      =   0  'Flat
      BackColor       =   &H80000003&
      BorderStyle     =   0  'None
      FillColor       =   &H8000000A&
      ForeColor       =   &H80000008&
      Height          =   7995
      Left            =   0
      ScaleHeight     =   7995
      ScaleWidth      =   2415
      TabIndex        =   182
      Top             =   0
      Width           =   2415
      Begin VB.PictureBox picTPL 
         BorderStyle     =   0  'None
         Height          =   6135
         Left            =   0
         ScaleHeight     =   6135
         ScaleWidth      =   2250
         TabIndex        =   184
         Top             =   0
         Width           =   2250
         Begin XtremeSuiteControls.TaskPanel tplFunc 
            Height          =   5250
            Left            =   0
            TabIndex        =   185
            Top             =   720
            Width           =   2205
            _Version        =   589884
            _ExtentX        =   3889
            _ExtentY        =   9260
            _StockProps     =   64
            Behaviour       =   1
            ItemLayout      =   2
            HotTrackStyle   =   3
         End
         Begin XtremeCommandBars.ImageManager imgFunc 
            Left            =   1800
            Top             =   360
            _Version        =   589884
            _ExtentX        =   635
            _ExtentY        =   635
            _StockProps     =   0
            Icons           =   "frmParPacs.frx":6852
         End
         Begin XtremeSuiteControls.ShortcutCaption sccFunc 
            Height          =   300
            Left            =   0
            TabIndex        =   186
            Top             =   0
            Width           =   2200
            _Version        =   589884
            _ExtentX        =   3881
            _ExtentY        =   529
            _StockProps     =   6
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "����"
               Size            =   9
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            SubItemCaption  =   -1  'True
            Alignment       =   1
         End
      End
      Begin VB.PictureBox picVbar 
         BackColor       =   &H80000003&
         BorderStyle     =   0  'None
         FillColor       =   &H8000000A&
         Height          =   5820
         Left            =   2280
         MousePointer    =   9  'Size W E
         ScaleHeight     =   5820
         ScaleWidth      =   45
         TabIndex        =   183
         Top             =   120
         Width           =   45
      End
      Begin XtremeSuiteControls.ShortcutBar scbFunc 
         Height          =   6765
         Left            =   0
         TabIndex        =   0
         Top             =   0
         Width           =   2400
         _Version        =   589884
         _ExtentX        =   4233
         _ExtentY        =   11933
         _StockProps     =   64
      End
      Begin XtremeCommandBars.ImageManager imgType 
         Left            =   0
         Top             =   0
         _Version        =   589884
         _ExtentX        =   635
         _ExtentY        =   635
         _StockProps     =   0
         Icons           =   "frmParPacs.frx":B7F6
      End
   End
   Begin VB.PictureBox PicBottom 
      Align           =   2  'Align Bottom
      Appearance      =   0  'Flat
      BackColor       =   &H80000003&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   590
      Left            =   0
      ScaleHeight     =   585
      ScaleWidth      =   11250
      TabIndex        =   165
      Top             =   7995
      Width           =   11250
      Begin VB.CommandButton cmdApply 
         Caption         =   "Ӧ��(&A)"
         Height          =   350
         Left            =   10200
         TabIndex        =   305
         Top             =   120
         Width           =   1100
      End
      Begin VB.TextBox txtLocate 
         Height          =   300
         Index           =   1
         Left            =   4700
         TabIndex        =   188
         Top             =   120
         Visible         =   0   'False
         Width           =   1200
      End
      Begin VB.TextBox txtLocate 
         Height          =   300
         Index           =   0
         Left            =   2400
         TabIndex        =   181
         Top             =   120
         Width           =   1200
      End
      Begin VB.CommandButton cmdHelp 
         Caption         =   "����(&H)"
         CausesValidation=   0   'False
         Height          =   350
         Left            =   60
         TabIndex        =   179
         Top             =   120
         Width           =   1100
      End
      Begin VB.CommandButton cmdCancel 
         Caption         =   "ȡ��(&C)"
         Height          =   350
         Left            =   9000
         TabIndex        =   178
         Top             =   120
         Width           =   1100
      End
      Begin VB.CommandButton cmdOK 
         Caption         =   "ȷ��(&O)"
         Height          =   350
         Left            =   7845
         TabIndex        =   177
         Top             =   120
         Width           =   1100
      End
      Begin VB.Label lblPrompt 
         BackStyle       =   0  'Transparent
         ForeColor       =   &H00C00000&
         Height          =   225
         Left            =   6000
         TabIndex        =   189
         Top             =   165
         Width           =   2055
      End
      Begin VB.Label lblLocate 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BackStyle       =   0  'Transparent
         Caption         =   "���Ҳ���(&F)"
         ForeColor       =   &H80000008&
         Height          =   255
         Index           =   1
         Left            =   3600
         TabIndex        =   187
         Top             =   165
         Visible         =   0   'False
         Width           =   1095
      End
      Begin VB.Label lblLocate 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BackStyle       =   0  'Transparent
         Caption         =   "��������(&S)"
         ForeColor       =   &H80000008&
         Height          =   255
         Index           =   0
         Left            =   1200
         TabIndex        =   180
         Top             =   168
         Width           =   1095
      End
   End
   Begin TabDlg.SSTab stabDesign 
      Height          =   7995
      Left            =   2400
      TabIndex        =   190
      TabStop         =   0   'False
      Top             =   0
      Width           =   8805
      _ExtentX        =   15531
      _ExtentY        =   14102
      _Version        =   393216
      Style           =   1
      Tabs            =   7
      TabsPerRow      =   12
      TabHeight       =   520
      TabCaption(0)   =   "Ӱ����������"
      TabPicture(0)   =   "frmParPacs.frx":14E6A
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "picPar(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).ControlCount=   1
      TabCaption(1)   =   "Ӱ��ҽ������"
      TabPicture(1)   =   "frmParPacs.frx":14E86
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "picPar(1)"
      Tab(1).ControlCount=   1
      TabCaption(2)   =   "Ӱ��ɼ�����"
      TabPicture(2)   =   "frmParPacs.frx":14EA2
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "picPar(2)"
      Tab(2).ControlCount=   1
      TabCaption(3)   =   "Ӱ��������"
      TabPicture(3)   =   "frmParPacs.frx":14EBE
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "picPar(3)"
      Tab(3).ControlCount=   1
      TabCaption(4)   =   "����鵵����"
      TabPicture(4)   =   "frmParPacs.frx":14EDA
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "picPar(4)"
      Tab(4).ControlCount=   1
      TabCaption(5)   =   "����軹����"
      TabPicture(5)   =   "frmParPacs.frx":14EF6
      Tab(5).ControlEnabled=   0   'False
      Tab(5).Control(0)=   "picPar(5)"
      Tab(5).ControlCount=   1
      TabCaption(6)   =   "���ԤԼ����"
      TabPicture(6)   =   "frmParPacs.frx":14F12
      Tab(6).ControlEnabled=   0   'False
      Tab(6).Control(0)=   "picPar(6)"
      Tab(6).ControlCount=   1
      Begin VB.PictureBox picPar 
         BorderStyle     =   0  'None
         Height          =   7890
         Index           =   6
         Left            =   -74880
         ScaleHeight     =   7890
         ScaleWidth      =   8775
         TabIndex        =   380
         Top             =   240
         Width           =   8775
         Begin TabDlg.SSTab sstSchSetup 
            Height          =   7695
            Left            =   0
            TabIndex        =   381
            Top             =   120
            Width           =   8775
            _ExtentX        =   15478
            _ExtentY        =   13573
            _Version        =   393216
            Style           =   1
            Tab             =   1
            TabHeight       =   520
            TabCaption(0)   =   "ԤԼ���ù���"
            TabPicture(0)   =   "frmParPacs.frx":14F2E
            Tab(0).ControlEnabled=   0   'False
            Tab(0).Control(0)=   "imgList"
            Tab(0).Control(1)=   "chkReservations"
            Tab(0).Control(2)=   "fraRest"
            Tab(0).Control(3)=   "fraDept"
            Tab(0).Control(4)=   "pictDay"
            Tab(0).Control(5)=   "chkSchExecFee"
            Tab(0).ControlCount=   6
            TabCaption(1)   =   "ԤԼ�豸����"
            TabPicture(1)   =   "frmParPacs.frx":14F4A
            Tab(1).ControlEnabled=   -1  'True
            Tab(1).Control(0)=   "fraDiagnosis"
            Tab(1).Control(0).Enabled=   0   'False
            Tab(1).Control(1)=   "fraDevice"
            Tab(1).Control(1).Enabled=   0   'False
            Tab(1).ControlCount=   2
            TabCaption(2)   =   "ԤԼ��������"
            TabPicture(2)   =   "frmParPacs.frx":14F66
            Tab(2).ControlEnabled=   0   'False
            Tab(2).Control(0)=   "SchTimeTable"
            Tab(2).Control(1)=   "cmdSchPlanUpdate"
            Tab(2).Control(2)=   "cmdSchPlanAdd"
            Tab(2).Control(3)=   "cmdSchPlanDel"
            Tab(2).Control(4)=   "cmdSchPlanCopy"
            Tab(2).Control(5)=   "Frame5"
            Tab(2).ControlCount=   6
            Begin VB.CheckBox chkSchExecFee 
               Caption         =   "ԤԼʱִ�з���"
               Height          =   255
               Left            =   -74880
               TabIndex        =   451
               Top             =   960
               Width           =   2775
            End
            Begin VB.PictureBox pictDay 
               BackColor       =   &H8000000E&
               Height          =   615
               Left            =   -67560
               ScaleHeight     =   555
               ScaleWidth      =   555
               TabIndex        =   442
               Top             =   240
               Visible         =   0   'False
               Width           =   615
            End
            Begin VB.Frame fraDept 
               Caption         =   "����������ԤԼ"
               Height          =   6225
               Left            =   -70560
               TabIndex        =   438
               Top             =   1320
               Width           =   4215
               Begin VSFlex8Ctl.VSFlexGrid vsfDept 
                  Height          =   5055
                  Left            =   120
                  TabIndex        =   439
                  Top             =   1080
                  Width           =   3975
                  _cx             =   1970346851
                  _cy             =   1970348756
                  Appearance      =   1
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
                  BackColorSel    =   -2147483635
                  ForeColorSel    =   -2147483634
                  BackColorBkg    =   -2147483636
                  BackColorAlternate=   -2147483643
                  GridColor       =   -2147483633
                  GridColorFixed  =   -2147483632
                  TreeColor       =   -2147483632
                  FloodColor      =   192
                  SheetBorder     =   -2147483642
                  FocusRect       =   1
                  HighLight       =   1
                  AllowSelection  =   0   'False
                  AllowBigSelection=   -1  'True
                  AllowUserResizing=   0
                  SelectionMode   =   1
                  GridLines       =   1
                  GridLinesFixed  =   2
                  GridLineWidth   =   1
                  Rows            =   50
                  Cols            =   3
                  FixedRows       =   1
                  FixedCols       =   0
                  RowHeightMin    =   320
                  RowHeightMax    =   0
                  ColWidthMin     =   0
                  ColWidthMax     =   0
                  ExtendLastCol   =   -1  'True
                  FormatString    =   $"frmParPacs.frx":14F82
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
               Begin VB.Label lblDeptHint 
                  AutoSize        =   -1  'True
                  Caption         =   "�ﹴѡ���ң���ʾ�����ҿ�������ԤԼ��"
                  BeginProperty Font 
                     Name            =   "����"
                     Size            =   9
                     Charset         =   134
                     Weight          =   700
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  ForeColor       =   &H000000FF&
                  Height          =   180
                  Index           =   0
                  Left            =   240
                  TabIndex        =   441
                  Top             =   360
                  Width           =   3510
               End
               Begin VB.Label lblDeptHint 
                  AutoSize        =   -1  'True
                  Caption         =   "�ﲻ��ѡ���ң���ʾ��ȫԺ��������ԤԼ��"
                  BeginProperty Font 
                     Name            =   "����"
                     Size            =   9
                     Charset         =   134
                     Weight          =   700
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  ForeColor       =   &H000000FF&
                  Height          =   180
                  Index           =   1
                  Left            =   240
                  TabIndex        =   440
                  Top             =   720
                  Width           =   3705
               End
            End
            Begin VB.Frame fraRest 
               Caption         =   "ȫԺ��Ϣ������"
               Height          =   6225
               Left            =   -74880
               TabIndex        =   433
               Top             =   1320
               Width           =   4215
               Begin VB.CheckBox chkWeekRest 
                  Caption         =   "ÿ������Ϣ"
                  Height          =   255
                  Index           =   0
                  Left            =   120
                  TabIndex        =   435
                  Top             =   5400
                  Width           =   1275
               End
               Begin VB.CheckBox chkWeekRest 
                  Caption         =   "ÿ������Ϣ"
                  Height          =   255
                  Index           =   1
                  Left            =   120
                  TabIndex        =   434
                  Top             =   5760
                  Width           =   1275
               End
               Begin XtremeCalendarControl.DatePicker dtpRestDay 
                  Height          =   4095
                  Left            =   120
                  TabIndex        =   436
                  Top             =   1080
                  Width           =   3975
                  _Version        =   1048579
                  _ExtentX        =   7011
                  _ExtentY        =   7223
                  _StockProps     =   64
                  AutoSize        =   0   'False
                  ShowTodayButton =   0   'False
                  ShowNoneButton  =   0   'False
                  ShowWeekNumbers =   -1  'True
                  ShowNonMonthDays=   0   'False
                  Show3DBorder    =   3
                  MaxSelectionCount=   1
                  AskDayMetrics   =   -1  'True
                  TextTodayButton =   "����"
                  VisualTheme     =   4
               End
               Begin VB.Label lblHintRest 
                  AutoSize        =   -1  'True
                  Caption         =   "˵����������������ӻ�ɾ����Ϣ�ա�"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   437
                  Top             =   480
                  Width           =   3060
               End
            End
            Begin VB.CheckBox chkReservations 
               Caption         =   "����ԤԼ"
               Height          =   255
               Left            =   -74880
               TabIndex        =   432
               Top             =   600
               Width           =   1215
            End
            Begin VB.Frame fraDevice 
               Caption         =   "ԤԼ�豸"
               Height          =   3615
               Left            =   240
               TabIndex        =   421
               Top             =   360
               Width           =   8295
               Begin VB.ComboBox cboSchDept 
                  Height          =   300
                  Left            =   1080
                  Style           =   2  'Dropdown List
                  TabIndex        =   443
                  Top             =   2694
                  Width           =   2295
               End
               Begin VB.TextBox txtEqDevice 
                  Height          =   350
                  Left            =   1080
                  MaxLength       =   64
                  TabIndex        =   427
                  Top             =   1943
                  Width           =   2295
               End
               Begin VB.ComboBox cboImDevice 
                  Height          =   300
                  Left            =   1080
                  Style           =   2  'Dropdown List
                  TabIndex        =   426
                  Top             =   2331
                  Width           =   2295
               End
               Begin VB.TextBox txtNode 
                  Height          =   975
                  Left            =   4680
                  MaxLength       =   200
                  MultiLine       =   -1  'True
                  ScrollBars      =   2  'Vertical
                  TabIndex        =   425
                  Top             =   1943
                  Width           =   3495
               End
               Begin VB.CommandButton cmdAddDevice 
                  Caption         =   "�����豸"
                  Height          =   350
                  Left            =   1320
                  TabIndex        =   424
                  Top             =   3120
                  Width           =   1100
               End
               Begin VB.CommandButton cmdUpdateDevice 
                  Caption         =   "�޸��豸"
                  Height          =   350
                  Left            =   3480
                  TabIndex        =   423
                  Top             =   3120
                  Width           =   1100
               End
               Begin VB.CommandButton cmdDeleteDevice 
                  Caption         =   "ɾ���豸"
                  Height          =   350
                  Left            =   5640
                  TabIndex        =   422
                  Top             =   3120
                  Width           =   1100
               End
               Begin VSFlex8Ctl.VSFlexGrid vsfDevice 
                  Height          =   1605
                  Left            =   120
                  TabIndex        =   428
                  Top             =   240
                  Width           =   8055
                  _cx             =   1970354048
                  _cy             =   1970342671
                  Appearance      =   1
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
                  BackColorSel    =   -2147483635
                  ForeColorSel    =   -2147483634
                  BackColorBkg    =   -2147483636
                  BackColorAlternate=   -2147483643
                  GridColor       =   -2147483633
                  GridColorFixed  =   -2147483632
                  TreeColor       =   -2147483632
                  FloodColor      =   192
                  SheetBorder     =   -2147483642
                  FocusRect       =   1
                  HighLight       =   1
                  AllowSelection  =   0   'False
                  AllowBigSelection=   -1  'True
                  AllowUserResizing=   0
                  SelectionMode   =   1
                  GridLines       =   1
                  GridLinesFixed  =   2
                  GridLineWidth   =   1
                  Rows            =   1
                  Cols            =   7
                  FixedRows       =   1
                  FixedCols       =   0
                  RowHeightMin    =   320
                  RowHeightMax    =   0
                  ColWidthMin     =   0
                  ColWidthMax     =   0
                  ExtendLastCol   =   -1  'True
                  FormatString    =   $"frmParPacs.frx":14FE5
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
               Begin VB.Label Label5 
                  AutoSize        =   -1  'True
                  Caption         =   "ԤԼ���ң�"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   444
                  Top             =   2760
                  Width           =   900
               End
               Begin VB.Label lblEqDevice 
                  AutoSize        =   -1  'True
                  Caption         =   "ԤԼ�豸��"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   431
                  Top             =   2028
                  Width           =   900
               End
               Begin VB.Label lblImDevice 
                  AutoSize        =   -1  'True
                  Caption         =   "Ӱ���豸��"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   430
                  Top             =   2391
                  Width           =   900
               End
               Begin VB.Label lblIntroductions 
                  AutoSize        =   -1  'True
                  Caption         =   "˵    ����"
                  Height          =   180
                  Left            =   3720
                  TabIndex        =   429
                  Top             =   2028
                  Width           =   900
               End
               Begin VB.Image imgNoCheck 
                  Height          =   255
                  Left            =   0
                  Picture         =   "frmParPacs.frx":150B9
                  Stretch         =   -1  'True
                  Tag             =   "0"
                  Top             =   120
                  Visible         =   0   'False
                  Width           =   240
               End
               Begin VB.Image imgCheck 
                  Height          =   255
                  Left            =   240
                  Picture         =   "frmParPacs.frx":1542B
                  Stretch         =   -1  'True
                  Tag             =   "1"
                  Top             =   120
                  Visible         =   0   'False
                  Width           =   240
               End
            End
            Begin VB.Frame fraDiagnosis 
               Caption         =   "ԤԼ�豸��Ӧ--������Ŀ--����"
               Height          =   3495
               Left            =   240
               TabIndex        =   408
               Top             =   4080
               Width           =   8295
               Begin VB.ListBox lstAttentions 
                  BeginProperty Font 
                     Name            =   "����"
                     Size            =   12
                     Charset         =   134
                     Weight          =   400
                     Underline       =   0   'False
                     Italic          =   0   'False
                     Strikethrough   =   0   'False
                  EndProperty
                  Height          =   1740
                  ItemData        =   "frmParPacs.frx":1579D
                  Left            =   4680
                  List            =   "frmParPacs.frx":1579F
                  TabIndex        =   455
                  Top             =   240
                  Visible         =   0   'False
                  Width           =   3495
               End
               Begin VB.CommandButton cmdSelect 
                  Caption         =   "ѡ�� ��"
                  Height          =   855
                  Left            =   7800
                  TabIndex        =   454
                  Top             =   2040
                  Width           =   375
               End
               Begin VB.TextBox txtAttention 
                  Height          =   855
                  Left            =   4680
                  MaxLength       =   1000
                  MultiLine       =   -1  'True
                  ScrollBars      =   2  'Vertical
                  TabIndex        =   415
                  Top             =   2040
                  Width           =   3135
               End
               Begin VB.TextBox txtDgsName 
                  Enabled         =   0   'False
                  Height          =   350
                  Left            =   1080
                  TabIndex        =   414
                  Top             =   2045
                  Width           =   2295
               End
               Begin VB.TextBox txtTime 
                  Height          =   350
                  Left            =   1080
                  MaxLength       =   4
                  TabIndex        =   413
                  Top             =   2555
                  Width           =   855
               End
               Begin VB.CommandButton cmdUpdateDiagnosis 
                  Caption         =   "�޸���Ŀ"
                  Height          =   350
                  Left            =   2760
                  TabIndex        =   412
                  Top             =   3000
                  Width           =   1100
               End
               Begin VB.CommandButton cmdAddDiagnosis 
                  Caption         =   "������Ŀ"
                  Height          =   350
                  Left            =   1320
                  TabIndex        =   411
                  Top             =   3000
                  Width           =   1100
               End
               Begin VB.CommandButton cmdDeleteDiagnosis 
                  Caption         =   "ɾ����Ŀ"
                  Height          =   350
                  Left            =   4200
                  TabIndex        =   410
                  Top             =   3000
                  Width           =   1100
               End
               Begin VB.CommandButton cmdCopyDiagnosis 
                  Caption         =   "������Ŀ"
                  Height          =   350
                  Left            =   5640
                  TabIndex        =   409
                  Top             =   3000
                  Width           =   1100
               End
               Begin VSFlex8Ctl.VSFlexGrid vsfDiagnosis 
                  Height          =   1695
                  Left            =   120
                  TabIndex        =   416
                  Top             =   240
                  Width           =   8055
                  _cx             =   1970354048
                  _cy             =   1970342830
                  Appearance      =   1
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
                  BackColorSel    =   -2147483635
                  ForeColorSel    =   -2147483634
                  BackColorBkg    =   -2147483636
                  BackColorAlternate=   -2147483643
                  GridColor       =   -2147483633
                  GridColorFixed  =   -2147483632
                  TreeColor       =   -2147483632
                  FloodColor      =   192
                  SheetBorder     =   -2147483642
                  FocusRect       =   1
                  HighLight       =   1
                  AllowSelection  =   0   'False
                  AllowBigSelection=   -1  'True
                  AllowUserResizing=   1
                  SelectionMode   =   1
                  GridLines       =   1
                  GridLinesFixed  =   2
                  GridLineWidth   =   1
                  Rows            =   1
                  Cols            =   8
                  FixedRows       =   1
                  FixedCols       =   0
                  RowHeightMin    =   320
                  RowHeightMax    =   0
                  ColWidthMin     =   0
                  ColWidthMax     =   0
                  ExtendLastCol   =   -1  'True
                  FormatString    =   $"frmParPacs.frx":157A1
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
               Begin VB.Label lblNode 
                  AutoSize        =   -1  'True
                  Caption         =   "ע�����"
                  Height          =   180
                  Left            =   3720
                  TabIndex        =   420
                  Top             =   2160
                  Width           =   900
               End
               Begin VB.Label lblDgsName 
                  AutoSize        =   -1  'True
                  Caption         =   "��Ŀ���ƣ�"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   419
                  Top             =   2130
                  Width           =   900
               End
               Begin VB.Label lblTime 
                  AutoSize        =   -1  'True
                  Caption         =   "���ʱ����"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   418
                  Top             =   2640
                  Width           =   900
               End
               Begin VB.Label lblMinu 
                  Caption         =   "����"
                  Height          =   255
                  Left            =   2040
                  TabIndex        =   417
                  Top             =   2640
                  Width           =   375
               End
            End
            Begin VB.Frame Frame5 
               BorderStyle     =   0  'None
               Height          =   6855
               Left            =   -75000
               TabIndex        =   386
               Top             =   360
               Width           =   3420
               Begin TabDlg.SSTab tabSchPlanContent 
                  Height          =   2880
                  Left            =   0
                  TabIndex        =   387
                  Top             =   3960
                  Width           =   3345
                  _ExtentX        =   5900
                  _ExtentY        =   5080
                  _Version        =   393216
                  Style           =   1
                  Tabs            =   4
                  Tab             =   1
                  TabsPerRow      =   4
                  TabHeight       =   520
                  TabCaption(0)   =   "ÿ��"
                  TabPicture(0)   =   "frmParPacs.frx":1589B
                  Tab(0).ControlEnabled=   0   'False
                  Tab(0).Control(0)=   "Frame9"
                  Tab(0).ControlCount=   1
                  TabCaption(1)   =   "ÿ��"
                  TabPicture(1)   =   "frmParPacs.frx":158B7
                  Tab(1).ControlEnabled=   -1  'True
                  Tab(1).Control(0)=   "Frame10"
                  Tab(1).Control(0).Enabled=   0   'False
                  Tab(1).ControlCount=   1
                  TabCaption(2)   =   "ÿ��"
                  TabPicture(2)   =   "frmParPacs.frx":158D3
                  Tab(2).ControlEnabled=   0   'False
                  Tab(2).Control(0)=   "Frame12"
                  Tab(2).ControlCount=   1
                  TabCaption(3)   =   "һ��"
                  TabPicture(3)   =   "frmParPacs.frx":158EF
                  Tab(3).ControlEnabled=   0   'False
                  Tab(3).Control(0)=   "Frame13"
                  Tab(3).ControlCount=   1
                  Begin VB.Frame Frame13 
                     Height          =   2385
                     Left            =   -74880
                     TabIndex        =   402
                     Top             =   360
                     Width           =   3135
                     Begin XtremeCalendarControl.DatePicker dpSchOneday 
                        Height          =   2175
                        Left            =   120
                        TabIndex        =   403
                        Top             =   120
                        Width           =   2895
                        _Version        =   1048579
                        _ExtentX        =   5106
                        _ExtentY        =   3836
                        _StockProps     =   64
                        AutoSize        =   0   'False
                        ShowNoneButton  =   0   'False
                        TextNoneButton  =   "��"
                        TextTodayButton =   "����"
                     End
                     Begin VB.Label Label2 
                        Caption         =   "˵����ѡ��һ�����ԤԼ"
                        Height          =   255
                        Left            =   120
                        TabIndex        =   404
                        Top             =   240
                        Width           =   2295
                     End
                  End
                  Begin VB.Frame Frame12 
                     Height          =   2385
                     Left            =   -74880
                     TabIndex        =   400
                     Top             =   360
                     Width           =   3135
                     Begin VB.Label Label4 
                        Caption         =   $"frmParPacs.frx":1590B
                        Height          =   1455
                        Left            =   240
                        TabIndex        =   401
                        Top             =   480
                        Width           =   2655
                     End
                  End
                  Begin VB.Frame Frame10 
                     Height          =   2385
                     Left            =   120
                     TabIndex        =   391
                     Top             =   360
                     Width           =   3135
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "����"
                        Height          =   255
                        Index           =   3
                        Left            =   1560
                        TabIndex        =   450
                        Top             =   1147
                        Width           =   735
                     End
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "����"
                        BeginProperty Font 
                           Name            =   "����"
                           Size            =   9
                           Charset         =   134
                           Weight          =   700
                           Underline       =   0   'False
                           Italic          =   0   'False
                           Strikethrough   =   0   'False
                        EndProperty
                        ForeColor       =   &H00008000&
                        Height          =   255
                        Index           =   7
                        Left            =   1560
                        TabIndex        =   449
                        Top             =   1593
                        Width           =   735
                     End
                     Begin MSComCtl2.DTPicker dpSchPlanStartTime 
                        Height          =   345
                        Index           =   1
                        Left            =   960
                        TabIndex        =   448
                        Top             =   240
                        Width           =   1575
                        _ExtentX        =   2778
                        _ExtentY        =   609
                        _Version        =   393216
                        Format          =   110821377
                        CurrentDate     =   43306
                     End
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "����"
                        Height          =   255
                        Index           =   5
                        Left            =   120
                        TabIndex        =   398
                        Top             =   1593
                        Width           =   735
                     End
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "�ܶ�"
                        Height          =   255
                        Index           =   2
                        Left            =   840
                        TabIndex        =   397
                        Top             =   1147
                        Width           =   735
                     End
                     Begin VB.CheckBox chkSchUseCanlendar 
                        Caption         =   "��ԤԼ������Ϣ"
                        Height          =   255
                        Left            =   120
                        TabIndex        =   396
                        Top             =   2040
                        Value           =   1  'Checked
                        Width           =   1575
                     End
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "��һ"
                        Height          =   255
                        Index           =   1
                        Left            =   120
                        TabIndex        =   395
                        Top             =   1147
                        Width           =   735
                     End
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "����"
                        Height          =   255
                        Index           =   4
                        Left            =   2280
                        TabIndex        =   394
                        Top             =   1147
                        Width           =   735
                     End
                     Begin VB.CheckBox chkSchWeek 
                        Caption         =   "����"
                        BeginProperty Font 
                           Name            =   "����"
                           Size            =   9
                           Charset         =   134
                           Weight          =   700
                           Underline       =   0   'False
                           Italic          =   0   'False
                           Strikethrough   =   0   'False
                        EndProperty
                        ForeColor       =   &H00008000&
                        Height          =   255
                        Index           =   6
                        Left            =   840
                        TabIndex        =   393
                        Top             =   1593
                        Width           =   735
                     End
                     Begin VB.TextBox txtSchWeekInterval 
                        Height          =   345
                        Left            =   960
                        MaxLength       =   2
                        TabIndex        =   392
                        Text            =   "1"
                        Top             =   671
                        Width           =   1320
                     End
                     Begin VB.Label Label7 
                        Caption         =   "��ʼʱ��"
                        Height          =   255
                        Left            =   120
                        TabIndex        =   447
                        Top             =   285
                        Width           =   1005
                     End
                     Begin VB.Label Label3 
                        Caption         =   "���ʱ��                 ��"
                        Height          =   225
                        Left            =   120
                        TabIndex        =   399
                        Top             =   735
                        Width           =   2775
                     End
                  End
                  Begin VB.Frame Frame9 
                     Height          =   2385
                     Left            =   -74880
                     TabIndex        =   388
                     Top             =   360
                     Width           =   3135
                     Begin MSComCtl2.DTPicker dpSchPlanStartTime 
                        Height          =   345
                        Index           =   0
                        Left            =   1080
                        TabIndex        =   446
                        Top             =   555
                        Width           =   1335
                        _ExtentX        =   2355
                        _ExtentY        =   609
                        _Version        =   393216
                        Format          =   110821377
                        CurrentDate     =   43306
                     End
                     Begin VB.TextBox txtSchDayInterval 
                        Height          =   350
                        Left            =   1110
                        MaxLength       =   3
                        TabIndex        =   389
                        Text            =   "1"
                        Top             =   1365
                        Width           =   600
                     End
                     Begin VB.Label Label6 
                        Caption         =   "��ʼʱ��"
                        Height          =   255
                        Left            =   240
                        TabIndex        =   445
                        Top             =   600
                        Width           =   1005
                     End
                     Begin VB.Label Label1 
                        Caption         =   "���ʱ��          ��"
                        Height          =   225
                        Left            =   240
                        TabIndex        =   390
                        Top             =   1428
                        Width           =   2685
                     End
                  End
               End
               Begin VSFlex8Ctl.VSFlexGrid vsfScheduleDevice 
                  Height          =   1920
                  Left            =   0
                  TabIndex        =   405
                  Top             =   120
                  Width           =   3345
                  _cx             =   1970345740
                  _cy             =   1970343227
                  Appearance      =   1
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
                  BackColorSel    =   -2147483635
                  ForeColorSel    =   -2147483634
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
                  AllowUserResizing=   0
                  SelectionMode   =   0
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
               Begin VSFlex8Ctl.VSFlexGrid vsfSchedulePlan 
                  Height          =   1920
                  Left            =   0
                  TabIndex        =   406
                  Top             =   2040
                  Width           =   3345
                  _cx             =   1970345740
                  _cy             =   1970343227
                  Appearance      =   1
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
                  BackColorSel    =   -2147483635
                  ForeColorSel    =   -2147483634
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
                  AllowUserResizing=   0
                  SelectionMode   =   0
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
            Begin VB.CommandButton cmdSchPlanCopy 
               Caption         =   "���Ʒ���"
               Height          =   350
               Left            =   -68520
               TabIndex        =   385
               Top             =   7280
               Width           =   1100
            End
            Begin VB.CommandButton cmdSchPlanDel 
               Caption         =   "ɾ������"
               Height          =   350
               Left            =   -70280
               TabIndex        =   384
               Top             =   7280
               Width           =   1100
            End
            Begin VB.CommandButton cmdSchPlanAdd 
               Caption         =   "��������"
               Height          =   350
               Left            =   -73800
               TabIndex        =   383
               Top             =   7280
               Width           =   1100
            End
            Begin VB.CommandButton cmdSchPlanUpdate 
               Caption         =   "�޸ķ���"
               Height          =   350
               Left            =   -72040
               TabIndex        =   382
               Top             =   7280
               Width           =   1100
            End
            Begin zl9BaseItem.ucScheduleTimetable SchTimeTable 
               Height          =   6780
               Left            =   -71600
               TabIndex        =   407
               Top             =   450
               Width           =   5340
               _extentx        =   9419
               _extenty        =   11959
            End
            Begin MSComctlLib.ImageList imgList 
               Left            =   -66960
               Top             =   240
               _ExtentX        =   1005
               _ExtentY        =   1005
               BackColor       =   -2147483643
               ImageWidth      =   32
               ImageHeight     =   36
               MaskColor       =   12632256
               _Version        =   393216
               BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
                  NumListImages   =   31
                  BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":15961
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":16733
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":17505
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":182D7
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":190A9
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":19E7B
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1AC4D
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1BA1F
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1C7F1
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1D5C3
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1E395
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1F167
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":1FF39
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":20D0B
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":21ADD
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":228AF
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage17 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":23681
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage18 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":24453
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage19 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":25225
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage20 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":25FF7
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage21 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":26DC9
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage22 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":27B9B
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage23 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2896D
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage24 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2973F
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage25 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2A511
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage26 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2B2E3
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage27 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2C0B5
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage28 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2CE87
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage29 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2DC59
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage30 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2EA2B
                     Key             =   ""
                  EndProperty
                  BeginProperty ListImage31 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                     Picture         =   "frmParPacs.frx":2F7FD
                     Key             =   ""
                  EndProperty
               EndProperty
            End
         End
      End
      Begin VB.PictureBox picPar 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H80000008&
         Height          =   7575
         Index           =   0
         Left            =   0
         ScaleHeight     =   7575
         ScaleWidth      =   8895
         TabIndex        =   196
         Top             =   360
         Width           =   8895
         Begin VB.ComboBox cmbDept 
            Height          =   300
            Left            =   960
            Style           =   2  'Dropdown List
            TabIndex        =   1
            Top             =   120
            Width           =   2055
         End
         Begin VB.TextBox txtLab 
            Appearance      =   0  'Flat
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'None
            Height          =   210
            Left            =   120
            Locked          =   -1  'True
            TabIndex        =   197
            Text            =   "Ӱ�����"
            Top             =   165
            Width           =   735
         End
         Begin TabDlg.SSTab stabWorkFlow 
            Height          =   7095
            Left            =   120
            TabIndex        =   198
            Top             =   480
            Width           =   8715
            _ExtentX        =   15372
            _ExtentY        =   12515
            _Version        =   393216
            Style           =   1
            Tabs            =   7
            TabsPerRow      =   7
            TabHeight       =   520
            TabCaption(0)   =   "����������"
            TabPicture(0)   =   "frmParPacs.frx":305CF
            Tab(0).ControlEnabled=   -1  'True
            Tab(0).Control(0)=   "fra(2)"
            Tab(0).Control(0).Enabled=   0   'False
            Tab(0).Control(1)=   "fra(3)"
            Tab(0).Control(1).Enabled=   0   'False
            Tab(0).Control(2)=   "fra(4)"
            Tab(0).Control(2).Enabled=   0   'False
            Tab(0).Control(3)=   "fra(0)"
            Tab(0).Control(3).Enabled=   0   'False
            Tab(0).Control(4)=   "fra(27)"
            Tab(0).Control(4).Enabled=   0   'False
            Tab(0).Control(5)=   "chkPreView"
            Tab(0).Control(5).Enabled=   0   'False
            Tab(0).ControlCount=   6
            TabCaption(1)   =   "ִ�м�����"
            TabPicture(1)   =   "frmParPacs.frx":305EB
            Tab(1).ControlEnabled=   0   'False
            Tab(1).Control(0)=   "fra(13)"
            Tab(1).Control(1)=   "cmdAdd"
            Tab(1).Control(1).Enabled=   0   'False
            Tab(1).Control(2)=   "cmdDel"
            Tab(1).Control(2).Enabled=   0   'False
            Tab(1).Control(3)=   "cmdSave"
            Tab(1).Control(4)=   "cmdRestore"
            Tab(1).ControlCount=   5
            TabCaption(2)   =   "�Ǽ�¼������"
            TabPicture(2)   =   "frmParPacs.frx":30607
            Tab(2).ControlEnabled=   0   'False
            Tab(2).Control(0)=   "fra(14)"
            Tab(2).Control(1)=   "fra(15)"
            Tab(2).ControlCount=   2
            TabCaption(3)   =   "�����Ŷ�����"
            TabPicture(3)   =   "frmParPacs.frx":30623
            Tab(3).ControlEnabled=   0   'False
            Tab(3).Control(0)=   "fra(16)"
            Tab(3).Control(1)=   "fra(17)"
            Tab(3).ControlCount=   2
            TabCaption(4)   =   "����༭������"
            TabPicture(4)   =   "frmParPacs.frx":3063F
            Tab(4).ControlEnabled=   0   'False
            Tab(4).Control(0)=   "fra(5)"
            Tab(4).Control(1)=   "fra(24)"
            Tab(4).Control(2)=   "fra(19)"
            Tab(4).Control(3)=   "fra(20)"
            Tab(4).Control(4)=   "fra(21)"
            Tab(4).Control(5)=   "fra(22)"
            Tab(4).Control(6)=   "fra(23)"
            Tab(4).ControlCount=   7
            TabCaption(5)   =   "����б�����"
            TabPicture(5)   =   "frmParPacs.frx":3065B
            Tab(5).ControlEnabled=   0   'False
            Tab(5).Control(0)=   "cmdDefault"
            Tab(5).Control(1)=   "fra(28)"
            Tab(5).ControlCount=   2
            TabCaption(6)   =   "��������"
            TabPicture(6)   =   "frmParPacs.frx":30677
            Tab(6).ControlEnabled=   0   'False
            Tab(6).Control(0)=   "fra(1)"
            Tab(6).ControlCount=   1
            Begin VB.CheckBox chkPreView 
               Caption         =   "��������ͼԤ��"
               ForeColor       =   &H00808080&
               Height          =   255
               Left            =   840
               TabIndex        =   376
               Top             =   5400
               Width           =   1575
            End
            Begin VB.Frame fra 
               Height          =   1485
               Index           =   5
               Left            =   -74280
               TabIndex        =   351
               Top             =   1080
               Width           =   7215
               Begin VB.Frame fra 
                  Caption         =   "¼��ʱ��"
                  Height          =   1150
                  Index           =   6
                  Left            =   4920
                  TabIndex        =   368
                  Top             =   240
                  Width           =   2055
                  Begin VB.OptionButton optResultInput 
                     Caption         =   "�����ӡǰ"
                     Height          =   240
                     Index           =   2
                     Left            =   210
                     TabIndex        =   371
                     Top             =   810
                     Width           =   1290
                  End
                  Begin VB.OptionButton optResultInput 
                     Caption         =   "���ǩ����"
                     Height          =   240
                     Index           =   1
                     Left            =   210
                     TabIndex        =   370
                     Top             =   525
                     Width           =   1230
                  End
                  Begin VB.OptionButton optResultInput 
                     Caption         =   "���ǩ����"
                     Height          =   240
                     Index           =   0
                     Left            =   210
                     TabIndex        =   369
                     Top             =   240
                     Value           =   -1  'True
                     Width           =   1215
                  End
               End
               Begin VB.TextBox txtImageLevel 
                  Height          =   270
                  Left            =   3690
                  TabIndex        =   360
                  Text            =   "��,��"
                  ToolTipText     =   "��������Ӱ�������ĵǼǣ�����ĸ��ȼ�"
                  Top             =   990
                  Width           =   1035
               End
               Begin VB.TextBox txtReportLevel 
                  Height          =   270
                  Left            =   3690
                  TabIndex        =   359
                  Text            =   "��,��"
                  Top             =   600
                  Width           =   1035
               End
               Begin VB.CheckBox chkImageLevel 
                  Caption         =   "Ӱ�������ȼ�"
                  Height          =   180
                  Left            =   2280
                  TabIndex        =   358
                  Top             =   1035
                  Width           =   1410
               End
               Begin VB.CheckBox chkReportLevel 
                  Caption         =   "���������ȼ�"
                  Height          =   180
                  Left            =   2280
                  TabIndex        =   357
                  Top             =   657
                  Width           =   1410
               End
               Begin VB.CheckBox chkConformDetermine 
                  Caption         =   "��������ж�"
                  Height          =   180
                  Left            =   2280
                  TabIndex        =   356
                  ToolTipText     =   "�������������ܺͲ˵�"
                  Top             =   280
                  Width           =   1455
               End
               Begin VB.Frame fra 
                  Height          =   1125
                  Index           =   9
                  Left            =   120
                  TabIndex        =   352
                  Top             =   270
                  Width           =   2055
                  Begin VB.CheckBox chkDefaultPosi 
                     Caption         =   "��Ͻ��Ĭ������"
                     Height          =   300
                     Left            =   120
                     TabIndex        =   355
                     ToolTipText     =   "����������ѡ�񴰿ڣ�Ĭ��ѡ�����ԡ�"
                     Top             =   300
                     Width           =   1815
                  End
                  Begin VB.CheckBox chkReportAfterResult 
                     Caption         =   "���������Ϊ����"
                     Height          =   180
                     Left            =   120
                     TabIndex        =   354
                     ToolTipText     =   "��д����ʱ��û��¼����ϣ���Ĭ�ϼ�¼Ϊ���ԡ�"
                     Top             =   720
                     Width           =   1740
                  End
                  Begin VB.CheckBox chkIgnorePosi 
                     Caption         =   "���Խ����������"
                     Height          =   180
                     Left            =   120
                     TabIndex        =   353
                     ToolTipText     =   "����¼�ʹ��������ԡ�"
                     Top             =   0
                     Width           =   1800
                  End
               End
            End
            Begin VB.Frame fra 
               Height          =   1455
               Index           =   27
               Left            =   720
               TabIndex        =   350
               Top             =   5400
               Width           =   4215
               Begin VB.OptionButton optClickPreview 
                  Caption         =   "��굥��ʱԤ��ͼ��"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Left            =   240
                  TabIndex        =   375
                  Top             =   1080
                  Width           =   1935
               End
               Begin VB.OptionButton optMovePreview 
                  Caption         =   "����ƶ�ʱԤ��ͼ��"
                  ForeColor       =   &H00808080&
                  Height          =   375
                  Left            =   240
                  TabIndex        =   374
                  Top             =   360
                  Width           =   2055
               End
               Begin VB.TextBox txtDelayTime 
                  Height          =   270
                  Left            =   2880
                  MaxLength       =   2
                  TabIndex        =   373
                  ToolTipText     =   "0��ʾ���Զ��ر�"
                  Top             =   780
                  Width           =   495
               End
               Begin VB.Label lblDelayTime 
                  Caption         =   "�ƶ�Ԥ��ʱ�Զ��ر���ʱʱ��       ��"
                  ForeColor       =   &H00808080&
                  Height          =   180
                  Left            =   480
                  TabIndex        =   372
                  Top             =   817
                  Width           =   3240
               End
            End
            Begin VB.Frame fra 
               Height          =   6375
               Index           =   1
               Left            =   -74880
               TabIndex        =   310
               Top             =   480
               Width           =   8385
               Begin VB.CheckBox chkCheckMaxNo 
                  Caption         =   "��ȡʵ��������"
                  Height          =   300
                  Left            =   240
                  TabIndex        =   344
                  ToolTipText     =   "��ʵ��������Ϊ����˳���š����ѡ��ǰ׺�������ָ��������������ա����������ݿ������ַ��ͼ��ţ����ֹ����ȡʵ�������롱��"
                  Top             =   5880
                  Width           =   1935
               End
               Begin VB.CheckBox chkChangeNO 
                  Caption         =   "�����ֹ���������"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   343
                  ToolTipText     =   "�������ʵ����Ҫ���ֶ��޸ļ��š�"
                  Top             =   5040
                  Width           =   1935
               End
               Begin VB.CheckBox chkCanOverWrite 
                  Caption         =   "��������ظ�"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   342
                  ToolTipText     =   "����Ǽǲ��˵ļ��ų����ظ�����ѡ�񡰻��߼��ű��ֲ��䡱ʱ����Ҫ��������ظ���"
                  Top             =   5460
                  Width           =   1935
               End
               Begin VB.Frame fra 
                  Caption         =   "����һ����"
                  Height          =   4290
                  Index           =   12
                  Left            =   120
                  TabIndex        =   331
                  Top             =   360
                  Width           =   4000
                  Begin VB.OptionButton OptCode 
                     Caption         =   "ÿ�μ�����¼���"
                     Height          =   180
                     Index           =   0
                     Left            =   120
                     TabIndex        =   341
                     ToolTipText     =   "����ʱ�����µļ��š�"
                     Top             =   360
                     Value           =   -1  'True
                     Width           =   1920
                  End
                  Begin VB.OptionButton OptCode 
                     Caption         =   "���߼��ű��ֲ���"
                     Height          =   180
                     Index           =   1
                     Left            =   120
                     TabIndex        =   340
                     ToolTipText     =   "ͬһ�����ߣ�����ʱ���ּ��Ų��䡣"
                     Top             =   2520
                     Width           =   1935
                  End
                  Begin VB.Frame fra 
                     Height          =   1400
                     Index           =   7
                     Left            =   480
                     TabIndex        =   336
                     Top             =   2760
                     Width           =   3300
                     Begin VB.OptionButton OptUnicode 
                        Caption         =   "��������ͳһ"
                        Height          =   240
                        Index           =   0
                        Left            =   240
                        TabIndex        =   339
                        ToolTipText     =   "��������ͬ�����ּ��Ų��䡣"
                        Top             =   300
                        Value           =   -1  'True
                        Width           =   1590
                     End
                     Begin VB.OptionButton OptUnicode 
                        Caption         =   "������ͳһ"
                        Height          =   210
                        Index           =   1
                        Left            =   240
                        TabIndex        =   338
                        ToolTipText     =   "������ͬ�����ּ��Ų��䡣"
                        Top             =   705
                        Width           =   1290
                     End
                     Begin VB.OptionButton optUsePatientID 
                        Caption         =   "ȫԺͳһ��ʹ�ò���ID��"
                        Height          =   210
                        Left            =   240
                        TabIndex        =   337
                        ToolTipText     =   "ʹ�ò���ID��Ϊ���š�"
                        Top             =   1080
                        Width           =   2370
                     End
                  End
                  Begin VB.Frame Frame2 
                     Height          =   1400
                     Left            =   480
                     TabIndex        =   332
                     Top             =   720
                     Width           =   3300
                     Begin VB.OptionButton OptBuildcode 
                        Caption         =   "��ͬ�������Զ�����"
                        Height          =   210
                        Index           =   0
                        Left            =   240
                        TabIndex        =   335
                        ToolTipText     =   "�����Լ�����Ϊ�������Զ�������"
                        Top             =   300
                        Value           =   -1  'True
                        Width           =   2130
                     End
                     Begin VB.OptionButton OptBuildcode 
                        Caption         =   "���������Զ�����"
                        Height          =   210
                        Index           =   1
                        Left            =   240
                        TabIndex        =   334
                        ToolTipText     =   "�����Կ���Ϊ�������Զ�������"
                        Top             =   690
                        Width           =   1740
                     End
                     Begin VB.OptionButton optUseAdviceID 
                        Caption         =   "ʹ��ҽ��ID"
                        Height          =   210
                        Left            =   240
                        TabIndex        =   333
                        ToolTipText     =   "ʹ��ҽ��ID��Ϊ���š�"
                        Top             =   1080
                        Width           =   1740
                     End
                  End
               End
               Begin VB.Frame Frame3 
                  Caption         =   "���������"
                  Height          =   5895
                  Left            =   4200
                  TabIndex        =   311
                  Top             =   360
                  Width           =   4000
                  Begin VB.ComboBox cboDelimeter 
                     BeginProperty Font 
                        Name            =   "����"
                        Size            =   10.5
                        Charset         =   134
                        Weight          =   400
                        Underline       =   0   'False
                        Italic          =   0   'False
                        Strikethrough   =   0   'False
                     EndProperty
                     Height          =   330
                     Index           =   2
                     Left            =   1280
                     Style           =   2  'Dropdown List
                     TabIndex        =   346
                     Top             =   3694
                     Width           =   2500
                  End
                  Begin VB.ComboBox cboDelimeter 
                     BeginProperty Font 
                        Name            =   "����"
                        Size            =   10.5
                        Charset         =   134
                        Weight          =   400
                        Underline       =   0   'False
                        Italic          =   0   'False
                        Strikethrough   =   0   'False
                     EndProperty
                     Height          =   330
                     Index           =   1
                     Left            =   1280
                     Style           =   2  'Dropdown List
                     TabIndex        =   345
                     Top             =   1942
                     Width           =   2500
                  End
                  Begin VB.CheckBox chkPreText 
                     Caption         =   "ǰ׺"
                     Height          =   375
                     Left            =   240
                     TabIndex        =   330
                     ToolTipText     =   "�������ӹ̶�ǰ׺��"
                     Top             =   360
                     Width           =   1215
                  End
                  Begin VB.Frame frmPreText 
                     Height          =   1100
                     Left            =   480
                     TabIndex        =   326
                     Top             =   720
                     Width           =   3300
                     Begin VB.OptionButton optPreText 
                        Caption         =   "Ӱ�����"
                        Height          =   255
                        Index           =   0
                        Left            =   240
                        TabIndex        =   329
                        ToolTipText     =   "ʹ�ü���Ӱ�������Ϊǰ׺��"
                        Top             =   240
                        Width           =   1455
                     End
                     Begin VB.OptionButton optPreText 
                        Caption         =   "�����ı�"
                        Height          =   255
                        Index           =   1
                        Left            =   240
                        TabIndex        =   328
                        ToolTipText     =   "ʹ�������ı���Ϊǰ׺��"
                        Top             =   600
                        Value           =   -1  'True
                        Width           =   1215
                     End
                     Begin VB.TextBox txtPreText 
                        Height          =   375
                        Left            =   1440
                        MaxLength       =   10
                        TabIndex        =   327
                        ToolTipText     =   "ǰ׺��������10���ַ�"
                        Top             =   540
                        Width           =   1600
                     End
                  End
                  Begin VB.CheckBox chkDelimiter 
                     Caption         =   "�ָ���1"
                     Height          =   375
                     Index           =   1
                     Left            =   240
                     TabIndex        =   325
                     ToolTipText     =   "ǰ׺֮��ķָ�����"
                     Top             =   1920
                     Width           =   975
                  End
                  Begin VB.CheckBox chkDelimiter 
                     Caption         =   "�ָ���2"
                     Height          =   375
                     Index           =   2
                     Left            =   240
                     TabIndex        =   324
                     ToolTipText     =   "������֮��ķָ�����"
                     Top             =   3672
                     Width           =   975
                  End
                  Begin VB.CheckBox chkYear 
                     Caption         =   "��"
                     Height          =   255
                     Left            =   240
                     TabIndex        =   323
                     ToolTipText     =   "�ڼ���֮ǰ���ӵ�ǰ�ꡣ"
                     Top             =   2448
                     Width           =   735
                  End
                  Begin VB.Frame frmYear 
                     Height          =   500
                     Left            =   1280
                     TabIndex        =   320
                     Top             =   2325
                     Width           =   2500
                     Begin VB.OptionButton optYear 
                        Caption         =   "��λ"
                        Height          =   350
                        Index           =   0
                        Left            =   240
                        TabIndex        =   322
                        ToolTipText     =   "��λ��ݣ����硰2008����"
                        Top             =   120
                        Value           =   -1  'True
                        Width           =   735
                     End
                     Begin VB.OptionButton optYear 
                        Caption         =   "��λ"
                        Height          =   350
                        Index           =   1
                        Left            =   1320
                        TabIndex        =   321
                        ToolTipText     =   "��λ��ݣ����硰08����"
                        Top             =   120
                        Width           =   735
                     End
                  End
                  Begin VB.CheckBox chkMonth 
                     Caption         =   "��"
                     Height          =   255
                     Left            =   240
                     TabIndex        =   319
                     ToolTipText     =   "�ڼ���֮ǰ���ӵ�ǰ�¡�"
                     Top             =   2856
                     Width           =   735
                  End
                  Begin VB.CheckBox chkDay 
                     Caption         =   "��"
                     Height          =   255
                     Left            =   240
                     TabIndex        =   318
                     ToolTipText     =   "�ڼ���֮ǰ���ӵ�ǰ�ա�"
                     Top             =   3264
                     Width           =   615
                  End
                  Begin VB.CheckBox chkNumber 
                     Caption         =   "˳���"
                     Height          =   255
                     Left            =   240
                     TabIndex        =   317
                     ToolTipText     =   "˳�����Ĭ�ϱ���Ҫѡ���"
                     Top             =   4200
                     Value           =   1  'Checked
                     Width           =   975
                  End
                  Begin VB.Frame Frame6 
                     Height          =   1335
                     Left            =   480
                     TabIndex        =   312
                     Top             =   4440
                     Width           =   3300
                     Begin VB.TextBox txtStartNum 
                        Height          =   375
                        Left            =   1440
                        MaxLength       =   4
                        TabIndex        =   315
                        ToolTipText     =   "���ű�ŵ���ʼ���룬С��4λ��"
                        Top             =   300
                        Width           =   1600
                     End
                     Begin VB.CheckBox chkFixedLen 
                        Caption         =   "�̶�λ��"
                        Height          =   255
                        Left            =   240
                        TabIndex        =   314
                        ToolTipText     =   "���Ű��չ̶�λ����ţ�ǰ�油�㡣"
                        Top             =   840
                        Width           =   1095
                     End
                     Begin VB.TextBox txtFixedLen 
                        Height          =   375
                        Left            =   1440
                        MaxLength       =   2
                        TabIndex        =   313
                        ToolTipText     =   "�̶�λ��С��18λ"
                        Top             =   780
                        Width           =   1600
                     End
                     Begin VB.Label lblStartNum 
                        Caption         =   "��ʼ����"
                        Height          =   255
                        Left            =   240
                        TabIndex        =   316
                        ToolTipText     =   "���ű�ŵ���ʼ���롣"
                        Top             =   360
                        Width           =   975
                     End
                  End
               End
            End
            Begin VB.Frame fra 
               Height          =   2955
               Index           =   0
               Left            =   720
               TabIndex        =   199
               Top             =   480
               Width           =   7335
               Begin VB.CheckBox chkDirectRepImg 
                  Caption         =   "ͬ����ӹ�Ƭ����ͼ"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   462
                  Top             =   2640
                  Value           =   1  'Checked
                  Width           =   2355
               End
               Begin VB.CheckBox chkNoRegCanPay 
                  Caption         =   "����δ��������"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   461
                  Top             =   2640
                  Width           =   1815
               End
               Begin VB.CheckBox chkEmergencyRequestNotExecuteMoney 
                  Caption         =   "���ﲡ�˱�����ִ�з���"
                  Height          =   180
                  Left            =   4560
                  TabIndex        =   457
                  Top             =   965
                  Width           =   2295
               End
               Begin VB.CheckBox chkNoSignFinish 
                  Caption         =   "�ޱ���򱨸�δǩ���������"
                  Height          =   180
                  Left            =   4560
                  TabIndex        =   456
                  Top             =   610
                  Width           =   2655
               End
               Begin VB.CheckBox chkSetFocusWithReport 
                  Caption         =   "����л�ʱ��λ����༭"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   297
                  ToolTipText     =   "�л�������ҳ��ʱ�Ƿ�λ����༭"
                  Top             =   2043
                  Width           =   2295
               End
               Begin VB.CheckBox chkCompletePrint 
                  Caption         =   "�����ֱ�Ӵ�ӡ"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   293
                  ToolTipText     =   "����ǩ����ֱ�Ӵ�ӡ���档"
                  Top             =   553
                  Width           =   1680
               End
               Begin VB.CheckBox chkFinallyCompleteCommit 
                  Caption         =   "�����ֱ�����"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   292
                  ToolTipText     =   "������˺󣬸ü���Զ���ɣ��������ڱ����ĵ��༭����"
                  Top             =   1447
                  Width           =   1815
               End
               Begin VB.Frame Frame11 
                  Caption         =   "ҽ��վ�鿴����"
                  Height          =   615
                  Left            =   4560
                  TabIndex        =   290
                  ToolTipText     =   "�������ڱ����ĵ��༭����"
                  Top             =   1680
                  Width           =   2415
                  Begin VB.ComboBox cboViewReport 
                     Height          =   300
                     ItemData        =   "frmParPacs.frx":30693
                     Left            =   240
                     List            =   "frmParPacs.frx":3069D
                     Style           =   2  'Dropdown List
                     TabIndex        =   291
                     ToolTipText     =   "�������ڱ����ĵ��༭����"
                     Top             =   240
                     Width           =   1935
                  End
               End
               Begin VB.CheckBox chkAddons 
                  Caption         =   "��ʾ��������"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   285
                  ToolTipText     =   "�ڵǼǱ���������ʾ��������һ��"
                  Top             =   2341
                  Width           =   1935
               End
               Begin VB.CheckBox chkReagent 
                  Caption         =   "��ʾ��Ӱ��"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   284
                  ToolTipText     =   "�ڵǼǱ���������ʾ��Ӱ��һ�������վ����ʾ"
                  Top             =   851
                  Width           =   1935
               End
               Begin VB.TextBox txtRefreshInterval 
                  Enabled         =   0   'False
                  Height          =   270
                  Left            =   6480
                  TabIndex        =   12
                  Text            =   "0"
                  Top             =   2340
                  Width           =   390
               End
               Begin VB.TextBox TxtLike 
                  Enabled         =   0   'False
                  Height          =   270
                  Left            =   6480
                  MaxLength       =   2
                  TabIndex        =   8
                  ToolTipText     =   "0������ʱ������,ģ���������в���"
                  Top             =   225
                  Width           =   270
               End
               Begin VB.CheckBox chkAutoSendWorkList 
                  Caption         =   "����ʱ�Զ�����WorkList"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   18
                  Top             =   1447
                  Value           =   1  'Checked
                  Width           =   2415
               End
               Begin VB.TextBox txtViewHistoryImageDays 
                  Height          =   270
                  Left            =   6480
                  MaxLength       =   2
                  TabIndex        =   19
                  Text            =   "1"
                  Top             =   1280
                  Width           =   465
               End
               Begin VB.CheckBox chkCanViewImage 
                  Caption         =   "��ͼ��ҽ��վ���ɹ�Ƭ"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   15
                  ToolTipText     =   "�ɼ�ͼ�����û�м����ɵ�����£�ҽ��վҲ�ɽ��й�Ƭ��"
                  Top             =   553
                  Width           =   2160
               End
               Begin VB.CheckBox chkPrintCommit 
                  Caption         =   "��ӡ��ֱ�����"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   5
                  ToolTipText     =   "��ӡ����󣬸ü���Զ���ɡ�"
                  Top             =   851
                  Width           =   1815
               End
               Begin VB.CheckBox ChkCompleteCommit 
                  Caption         =   "��˺�ֱ�����"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   9
                  ToolTipText     =   "������˺󣬸ü���Զ���ɡ�"
                  Top             =   1149
                  Width           =   1935
               End
               Begin VB.CheckBox chkSample 
                  Caption         =   "����ǼǺ�ֱ�ӱ���"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   14
                  ToolTipText     =   "�Ǽ��뱨��ͬʱ���С�"
                  Top             =   2043
                  Width           =   1935
               End
               Begin VB.TextBox TxtĬ������ 
                  Height          =   270
                  Left            =   6120
                  MaxLength       =   2
                  TabIndex        =   17
                  Text            =   "2"
                  Top             =   2640
                  Width           =   945
               End
               Begin VB.CheckBox chkReportAfterImging 
                  Caption         =   "��ͼ�����д����"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   2
                  ToolTipText     =   "����ɼ�ͼ�����ܱ�дӰ�񱨸档"
                  Top             =   255
                  Width           =   2040
               End
               Begin VB.CheckBox chkPrintNeedComplete 
                  Caption         =   "ƽ������˲ſɴ�ӡ����"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   10
                  ToolTipText     =   "ƽ����뾭����˺���ܴ�ӡ���档"
                  Top             =   2341
                  Width           =   2355
               End
               Begin VB.CheckBox chkTechReportSame 
                  Caption         =   "ֻ����д�Լ����ı���"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   6
                  ToolTipText     =   "ֻ���Լ��ɼ�ͼ��ļ�飬������д���档"
                  Top             =   1149
                  Width           =   2295
               End
               Begin VB.CheckBox chkWriteCapDoctor 
                  Caption         =   "�ɼ�ͼ����Ϊ��鼼ʦ"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   4
                  ToolTipText     =   "�ɼ�ͼ��֮���Զ�����ǰ�û���¼�ɼ�鼼ʦ��"
                  Top             =   1745
                  Width           =   2280
               End
               Begin VB.CheckBox chkLocalizerBackward 
                  Caption         =   "��λƬ����"
                  Height          =   180
                  Left            =   120
                  TabIndex        =   13
                  ToolTipText     =   "����λƬ�ŵ����һ��������ʾ��"
                  Top             =   1745
                  Width           =   1320
               End
               Begin VB.CheckBox chkRefreshInterval 
                  Caption         =   "�����Զ�ˢ�¼��       ��"
                  ForeColor       =   &H00808080&
                  Height          =   180
                  Left            =   4560
                  TabIndex        =   11
                  ToolTipText     =   "���˼���б����N���Զ�ˢ�¡�"
                  Top             =   2400
                  Width           =   2625
               End
               Begin VB.CheckBox chkAllPatientIsOutside 
                  Caption         =   "���еǼǲ��˱��Ϊ����"
                  Height          =   180
                  Left            =   2160
                  TabIndex        =   3
                  ToolTipText     =   "���ڸù���վ�еǼǵĲ��˾����Ϊ�������ˡ�"
                  Top             =   255
                  Width           =   2295
               End
               Begin VB.CheckBox ChkLike 
                  Caption         =   "�Ǽ�ʱ����ģ������    ��"
                  Height          =   195
                  Left            =   4560
                  TabIndex        =   7
                  ToolTipText     =   "�Ǽ�ʱ֧�ֶ���������ģ�����ң����Բ��ҵ�N���ڵ���Ϣ��"
                  Top             =   240
                  Width           =   2500
               End
               Begin VB.Label lab 
                  Alignment       =   1  'Right Justify
                  AutoSize        =   -1  'True
                  BackStyle       =   0  'Transparent
                  Caption         =   "�Զ�����ʷͼ������"
                  Height          =   180
                  Index           =   1
                  Left            =   4560
                  TabIndex        =   200
                  ToolTipText     =   "�����ǰ���û��ͼ�����Զ���ָ��ʱ����ڵ���ʷͼ��"
                  Top             =   1320
                  Width           =   1800
               End
               Begin VB.Label lab 
                  Alignment       =   1  'Right Justify
                  AutoSize        =   -1  'True
                  BackStyle       =   0  'Transparent
                  Caption         =   "Ĭ�ϼ�¼��ѯ����"
                  Height          =   180
                  Index           =   0
                  Left            =   4560
                  TabIndex        =   16
                  ToolTipText     =   "����б���Ĭ����ʾ��Ӧ�����ڵļ���¼��"
                  Top             =   2680
                  Width           =   1440
               End
            End
            Begin VB.Frame fra 
               Caption         =   "�����ĵ��༭������"
               Height          =   4335
               Index           =   24
               Left            =   -74280
               TabIndex        =   212
               Top             =   2640
               Width           =   7245
               Begin VB.Frame fra 
                  Caption         =   "��ʷ����鿴�༭��"
                  Height          =   615
                  Index           =   25
                  Left            =   240
                  TabIndex        =   213
                  Top             =   360
                  Width           =   6855
                  Begin VB.OptionButton optHistoryReportEditor 
                     Caption         =   "PACS����༭��"
                     Height          =   255
                     Index           =   1
                     Left            =   4080
                     TabIndex        =   215
                     Top             =   240
                     Width           =   1695
                  End
                  Begin VB.OptionButton optHistoryReportEditor 
                     Caption         =   "���Ӳ����༭��"
                     Height          =   255
                     Index           =   0
                     Left            =   360
                     TabIndex        =   214
                     Top             =   240
                     Value           =   -1  'True
                     Width           =   1695
                  End
               End
            End
            Begin VB.Frame fra 
               Height          =   5805
               Index           =   13
               Left            =   -74280
               TabIndex        =   242
               Top             =   480
               Width           =   7305
               Begin VB.TextBox txtNoPrefix 
                  Height          =   300
                  Left            =   6075
                  MaxLength       =   20
                  TabIndex        =   36
                  Top             =   5340
                  Width           =   1050
               End
               Begin VB.ComboBox cboDevice 
                  Height          =   300
                  Left            =   3240
                  Style           =   2  'Dropdown List
                  TabIndex        =   35
                  Top             =   5340
                  Width           =   1830
               End
               Begin VB.TextBox txtName 
                  Height          =   300
                  Left            =   840
                  MaxLength       =   20
                  TabIndex        =   34
                  Top             =   5340
                  Width           =   1635
               End
               Begin MSComctlLib.ImageList img16 
                  Left            =   4320
                  Top             =   600
                  _ExtentX        =   1005
                  _ExtentY        =   1005
                  BackColor       =   -2147483643
                  ImageWidth      =   16
                  ImageHeight     =   16
                  MaskColor       =   12632256
                  _Version        =   393216
                  BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
                     NumListImages   =   1
                     BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
                        Picture         =   "frmParPacs.frx":306C1
                        Key             =   "Room"
                     EndProperty
                  EndProperty
               End
               Begin MSComctlLib.ListView lvwRoom 
                  Height          =   4695
                  Left            =   120
                  TabIndex        =   33
                  Top             =   480
                  Width           =   7065
                  _ExtentX        =   12462
                  _ExtentY        =   8281
                  View            =   3
                  Arrange         =   1
                  LabelEdit       =   1
                  Sorted          =   -1  'True
                  LabelWrap       =   -1  'True
                  HideSelection   =   0   'False
                  FullRowSelect   =   -1  'True
                  GridLines       =   -1  'True
                  _Version        =   393217
                  Icons           =   "img16"
                  SmallIcons      =   "img16"
                  ForeColor       =   -2147483640
                  BackColor       =   -2147483643
                  Appearance      =   1
                  NumItems        =   0
               End
               Begin VB.Label lab 
                  AutoSize        =   -1  'True
                  Caption         =   "����ǰ׺"
                  Height          =   180
                  Index           =   6
                  Left            =   5250
                  TabIndex        =   246
                  Top             =   5400
                  Width           =   720
               End
               Begin VB.Label lab 
                  Caption         =   "�豸(&D)"
                  Height          =   180
                  Index           =   5
                  Left            =   2565
                  TabIndex        =   245
                  Top             =   5400
                  Width           =   630
               End
               Begin VB.Label lab 
                  AutoSize        =   -1  'True
                  Caption         =   "����(&N)"
                  Height          =   180
                  Index           =   4
                  Left            =   150
                  TabIndex        =   244
                  Top             =   5400
                  Width           =   630
               End
               Begin VB.Label lab 
                  Caption         =   "���ñ����ҵ�ִ�м�󣬲�����Ч����ִ�еİ��š�"
                  Height          =   210
                  Index           =   3
                  Left            =   150
                  TabIndex        =   243
                  Top             =   210
                  Width           =   4140
                  WordWrap        =   -1  'True
               End
            End
            Begin VB.CommandButton cmdAdd 
               Caption         =   "����(&A)"
               Height          =   345
               Left            =   -71760
               Picture         =   "frmParPacs.frx":30C5B
               TabIndex        =   37
               TabStop         =   0   'False
               Top             =   6510
               Width           =   1100
            End
            Begin VB.CommandButton cmdDel 
               Caption         =   "ɾ��(&D)"
               Height          =   345
               Left            =   -70560
               Picture         =   "frmParPacs.frx":30DA5
               TabIndex        =   38
               TabStop         =   0   'False
               Top             =   6510
               Width           =   1100
            End
            Begin VB.CommandButton cmdSave 
               Caption         =   "����(&S)"
               Height          =   345
               Left            =   -68160
               TabIndex        =   40
               Top             =   6510
               Width           =   1100
            End
            Begin VB.CommandButton cmdRestore 
               Caption         =   "�ָ�(&R)"
               Height          =   345
               Left            =   -69360
               TabIndex        =   39
               Top             =   6510
               Width           =   1100
            End
            Begin VB.Frame fra 
               Caption         =   "���������Ŀѡ��"
               Height          =   2010
               Index           =   14
               Left            =   -74280
               TabIndex        =   241
               Top             =   480
               Width           =   7300
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "��鼼ʦ��"
                  Height          =   180
                  Index           =   24
                  Left            =   6060
                  TabIndex        =   64
                  Top             =   1320
                  Width           =   1220
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "��������"
                  Height          =   180
                  Index           =   23
                  Left            =   180
                  TabIndex        =   65
                  Top             =   1590
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "��鼼ʦ"
                  Height          =   180
                  Index           =   22
                  Left            =   4800
                  TabIndex        =   63
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "��Ӱ��"
                  Height          =   180
                  Index           =   21
                  Left            =   3525
                  TabIndex        =   62
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "��������"
                  Height          =   180
                  Index           =   20
                  Left            =   3525
                  TabIndex        =   44
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "���ʱ��"
                  Height          =   180
                  Index           =   19
                  Left            =   2415
                  TabIndex        =   61
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����ʱ��"
                  Height          =   180
                  Index           =   18
                  Left            =   1305
                  TabIndex        =   60
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   15
                  Left            =   4800
                  TabIndex        =   57
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   $"frmParPacs.frx":30EEF
                  Height          =   180
                  Index           =   17
                  Left            =   180
                  TabIndex        =   59
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����豸"
                  Height          =   180
                  Index           =   16
                  Left            =   6060
                  TabIndex        =   58
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "ִ�м�"
                  Height          =   180
                  Index           =   14
                  Left            =   3525
                  TabIndex        =   56
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "��ַ"
                  Height          =   180
                  Index           =   13
                  Left            =   2415
                  TabIndex        =   55
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "�ʱ�"
                  Height          =   180
                  Index           =   12
                  Left            =   1305
                  TabIndex        =   54
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "�绰"
                  Height          =   180
                  Index           =   11
                  Left            =   180
                  TabIndex        =   53
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   10
                  Left            =   3525
                  TabIndex        =   50
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "ְҵ"
                  Height          =   180
                  Index           =   9
                  Left            =   2415
                  TabIndex        =   49
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   8
                  Left            =   6060
                  TabIndex        =   52
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "���֤��"
                  Height          =   180
                  Index           =   7
                  Left            =   4800
                  TabIndex        =   51
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "���ʽ"
                  Height          =   180
                  Index           =   6
                  Left            =   4800
                  TabIndex        =   45
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "�ѱ�"
                  Height          =   180
                  Index           =   5
                  Left            =   6060
                  TabIndex        =   46
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   4
                  Left            =   1305
                  TabIndex        =   48
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "���"
                  Height          =   180
                  Index           =   3
                  Left            =   180
                  TabIndex        =   47
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   2
                  Left            =   2415
                  TabIndex        =   43
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "�Ա�"
                  Height          =   180
                  Index           =   1
                  Left            =   1305
                  TabIndex        =   42
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkMouseMove 
                  Caption         =   "Ӣ����"
                  Height          =   180
                  Index           =   0
                  Left            =   180
                  TabIndex        =   41
                  Top             =   360
                  Width           =   1020
               End
            End
            Begin VB.Frame fra 
               Caption         =   "�ǼǱ�¼��Ŀѡ��"
               Height          =   2010
               Index           =   15
               Left            =   -74280
               TabIndex        =   240
               Top             =   2760
               Width           =   7300
               Begin VB.CheckBox ChkInput 
                  Caption         =   "Ӣ����"
                  Height          =   180
                  Index           =   0
                  Left            =   180
                  TabIndex        =   66
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "�Ա�"
                  Height          =   180
                  Index           =   1
                  Left            =   1305
                  TabIndex        =   67
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   2
                  Left            =   2415
                  TabIndex        =   68
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "���"
                  Height          =   180
                  Index           =   3
                  Left            =   180
                  TabIndex        =   72
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   4
                  Left            =   1305
                  TabIndex        =   73
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "�ѱ�"
                  Height          =   180
                  Index           =   5
                  Left            =   6060
                  TabIndex        =   71
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "���ʽ"
                  Height          =   180
                  Index           =   6
                  Left            =   4800
                  TabIndex        =   70
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "���֤��"
                  Height          =   180
                  Index           =   7
                  Left            =   4800
                  TabIndex        =   76
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   8
                  Left            =   6060
                  TabIndex        =   77
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "ְҵ"
                  Height          =   180
                  Index           =   9
                  Left            =   2415
                  TabIndex        =   74
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   10
                  Left            =   3525
                  TabIndex        =   75
                  Top             =   690
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "�绰"
                  Height          =   180
                  Index           =   11
                  Left            =   180
                  TabIndex        =   78
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "�ʱ�"
                  Height          =   180
                  Index           =   12
                  Left            =   1305
                  TabIndex        =   79
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "��ַ"
                  Height          =   180
                  Index           =   13
                  Left            =   2415
                  TabIndex        =   80
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "ִ�м�"
                  Height          =   180
                  Index           =   14
                  Left            =   3525
                  TabIndex        =   81
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����豸"
                  Height          =   180
                  Index           =   16
                  Left            =   6060
                  TabIndex        =   83
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   $"frmParPacs.frx":30EFB
                  Height          =   180
                  Index           =   17
                  Left            =   180
                  TabIndex        =   84
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����"
                  Height          =   180
                  Index           =   15
                  Left            =   4800
                  TabIndex        =   82
                  Top             =   1005
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "����ʱ��"
                  Height          =   180
                  Index           =   18
                  Left            =   1305
                  TabIndex        =   85
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "���ʱ��"
                  Height          =   180
                  Index           =   19
                  Left            =   2415
                  TabIndex        =   86
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "��������"
                  Height          =   180
                  Index           =   20
                  Left            =   3525
                  TabIndex        =   69
                  Top             =   360
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "��Ӱ��"
                  Height          =   180
                  Index           =   21
                  Left            =   3525
                  TabIndex        =   87
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "��鼼ʦ"
                  Height          =   180
                  Index           =   22
                  Left            =   4800
                  TabIndex        =   88
                  Top             =   1320
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "��������"
                  Height          =   180
                  Index           =   23
                  Left            =   180
                  TabIndex        =   90
                  Top             =   1590
                  Width           =   1020
               End
               Begin VB.CheckBox ChkInput 
                  Caption         =   "��鼼ʦ��"
                  Height          =   180
                  Index           =   24
                  Left            =   6060
                  TabIndex        =   89
                  Top             =   1320
                  Width           =   1220
               End
            End
            Begin VB.Frame fra 
               Caption         =   "�б���ɫ����"
               ForeColor       =   &H00808080&
               Height          =   5415
               Index           =   28
               Left            =   -74280
               TabIndex        =   221
               Top             =   480
               Width           =   7305
               Begin VB.Frame fra 
                  Caption         =   "��ɫ��ʾ����"
                  ForeColor       =   &H00808080&
                  Height          =   615
                  Index           =   30
                  Left            =   3960
                  TabIndex        =   223
                  ToolTipText     =   "����б���������ɫ���ͣ�Ϊǰ��ɫʱ�����б��ǰ��ɫ����֮������ɫ��"
                  Top             =   4680
                  Width           =   2055
                  Begin VB.OptionButton optListColorMark 
                     Caption         =   "ǰ��ɫ"
                     ForeColor       =   &H00808080&
                     Height          =   255
                     Index           =   0
                     Left            =   120
                     TabIndex        =   140
                     Top             =   240
                     Value           =   -1  'True
                     Width           =   855
                  End
                  Begin VB.OptionButton optListColorMark 
                     Caption         =   "����ɫ"
                     ForeColor       =   &H00808080&
                     Height          =   255
                     Index           =   1
                     Left            =   1080
                     TabIndex        =   141
                     Top             =   240
                     Width           =   855
                  End
               End
               Begin VB.Frame fra 
                  Height          =   615
                  Index           =   29
                  Left            =   720
                  TabIndex        =   222
                  Top             =   4680
                  Width           =   2895
                  Begin VB.CheckBox chkNameColColorCfg 
                     Caption         =   "��������ɫ��ʾ"
                     ForeColor       =   &H00808080&
                     Height          =   180
                     Left            =   120
                     TabIndex        =   138
                     ToolTipText     =   "������ɫ���ݲ���������ʾ��"
                     Top             =   0
                     Width           =   1800
                  End
                  Begin VB.CheckBox chkOrdinaryNameColColorCfg 
                     Caption         =   "����ȱʡ����������ɫ"
                     ForeColor       =   &H00808080&
                     Height          =   255
                     Left            =   600
                     TabIndex        =   139
                     Top             =   240
                     Width           =   2175
                  End
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   10
                  Left            =   2655
                  TabIndex        =   134
                  Top             =   3600
                  Width           =   255
               End
               Begin VB.TextBox txtAudit 
                  Height          =   270
                  Left            =   4560
                  MaxLength       =   4
                  TabIndex        =   131
                  Text            =   "0"
                  Top             =   2400
                  Width           =   495
               End
               Begin VB.TextBox txtStudy 
                  Height          =   270
                  Left            =   4560
                  MaxLength       =   4
                  TabIndex        =   127
                  Text            =   "0"
                  Top             =   1440
                  Width           =   495
               End
               Begin VB.TextBox txtReport 
                  Height          =   270
                  Left            =   4560
                  MaxLength       =   4
                  TabIndex        =   129
                  Text            =   "0"
                  Top             =   1920
                  Width           =   495
               End
               Begin VB.TextBox txtCheckIn 
                  Height          =   270
                  Left            =   4560
                  MaxLength       =   4
                  TabIndex        =   125
                  Text            =   "0"
                  Top             =   960
                  Width           =   495
               End
               Begin VB.TextBox txtEnreg 
                  Height          =   270
                  Left            =   4560
                  MaxLength       =   4
                  TabIndex        =   123
                  Text            =   "0"
                  Top             =   480
                  Width           =   495
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   9
                  Left            =   5295
                  TabIndex        =   133
                  Top             =   3120
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   8
                  Left            =   2650
                  TabIndex        =   122
                  Top             =   480
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   7
                  Left            =   2650
                  TabIndex        =   132
                  Top             =   3120
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   6
                  Left            =   2650
                  TabIndex        =   130
                  Top             =   2400
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   5
                  Left            =   5310
                  TabIndex        =   137
                  Top             =   4080
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   4
                  Left            =   2650
                  TabIndex        =   128
                  Top             =   1920
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   3
                  Left            =   2655
                  TabIndex        =   136
                  Top             =   4080
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   2
                  Left            =   5295
                  TabIndex        =   135
                  Top             =   3600
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   0
                  Left            =   2650
                  TabIndex        =   126
                  Top             =   1440
                  Width           =   255
               End
               Begin VB.CommandButton cmdColor 
                  Caption         =   "��"
                  Height          =   255
                  Index           =   1
                  Left            =   2650
                  TabIndex        =   124
                  Top             =   960
                  Width           =   255
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   10
                  Left            =   1560
                  Top             =   3600
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�Ѳ��أ�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   19
                  Left            =   720
                  TabIndex        =   239
                  Top             =   3600
                  Width           =   735
               End
               Begin VB.Label lab 
                  BackColor       =   &H00000000&
                  BackStyle       =   0  'Transparent
                  Caption         =   "״̬��������        ������"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   25
                  Left            =   3360
                  TabIndex        =   238
                  Top             =   2430
                  Width           =   2415
               End
               Begin VB.Label lab 
                  BackColor       =   &H00000000&
                  BackStyle       =   0  'Transparent
                  Caption         =   "״̬��������        ������"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   23
                  Left            =   3360
                  TabIndex        =   237
                  Top             =   1470
                  Width           =   2415
               End
               Begin VB.Label lab 
                  BackColor       =   &H00000000&
                  BackStyle       =   0  'Transparent
                  Caption         =   "״̬��������        ������"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   24
                  Left            =   3360
                  TabIndex        =   236
                  Top             =   1950
                  Width           =   2415
               End
               Begin VB.Label lab 
                  BackColor       =   &H00000000&
                  BackStyle       =   0  'Transparent
                  Caption         =   "״̬��������        ������"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   22
                  Left            =   3360
                  TabIndex        =   235
                  Top             =   990
                  Width           =   2415
               End
               Begin VB.Label lab 
                  BackColor       =   &H00000000&
                  BackStyle       =   0  'Transparent
                  Caption         =   "״̬��������        ������"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   21
                  Left            =   3360
                  TabIndex        =   234
                  Top             =   510
                  Width           =   2415
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   9
                  Left            =   4200
                  Top             =   3120
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�Ѿܾ���"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   26
                  Left            =   3360
                  TabIndex        =   233
                  Top             =   3120
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  BackColor       =   &H00FFFFFF&
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   8
                  Left            =   1560
                  Top             =   480
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�ѵǼǣ�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   13
                  Left            =   720
                  TabIndex        =   232
                  Top             =   480
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   7
                  Left            =   1560
                  Top             =   3120
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "����ɣ�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   18
                  Left            =   720
                  TabIndex        =   231
                  Top             =   3120
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   6
                  Left            =   1560
                  Top             =   2400
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "����ˣ�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   17
                  Left            =   720
                  TabIndex        =   230
                  Top             =   2400
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   5
                  Left            =   4215
                  Top             =   4080
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "����У�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   28
                  Left            =   3375
                  TabIndex        =   229
                  Top             =   4080
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   4
                  Left            =   1560
                  Top             =   1920
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�ѱ��棺"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   16
                  Left            =   720
                  TabIndex        =   228
                  Top             =   1920
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   3
                  Left            =   1560
                  Top             =   4080
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�����У�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   20
                  Left            =   720
                  TabIndex        =   227
                  Top             =   4080
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   2
                  Left            =   4200
                  Top             =   3600
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�����У�"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   27
                  Left            =   3360
                  TabIndex        =   226
                  Top             =   3600
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   0
                  Left            =   1560
                  Top             =   1440
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�Ѽ�飺"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   15
                  Left            =   720
                  TabIndex        =   225
                  Top             =   1440
                  Width           =   735
               End
               Begin VB.Shape shpColor 
                  FillColor       =   &H00FFFFFF&
                  FillStyle       =   0  'Solid
                  Height          =   255
                  Index           =   1
                  Left            =   1560
                  Top             =   960
                  Width           =   1095
               End
               Begin VB.Label lab 
                  Caption         =   "�ѱ�����"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   14
                  Left            =   720
                  TabIndex        =   224
                  Top             =   960
                  Width           =   735
               End
            End
            Begin VB.CommandButton cmdDefault 
               Caption         =   "�ָ�Ĭ��(&D)"
               Height          =   375
               Left            =   -69000
               TabIndex        =   142
               Top             =   6240
               Width           =   1335
            End
            Begin VB.Frame fra 
               Caption         =   "����༭��"
               Height          =   615
               Index           =   19
               Left            =   -74280
               TabIndex        =   220
               Top             =   480
               Width           =   7245
               Begin VB.OptionButton optReportEditor 
                  Caption         =   "PACS���ܱ���༭��"
                  ForeColor       =   &H00808080&
                  Height          =   255
                  Index           =   2
                  Left            =   4560
                  TabIndex        =   109
                  Top             =   240
                  Width           =   2052
               End
               Begin VB.OptionButton optReportEditor 
                  Caption         =   "���Ӳ����༭��"
                  Height          =   255
                  Index           =   0
                  Left            =   360
                  TabIndex        =   107
                  Top             =   240
                  Width           =   1575
               End
               Begin VB.OptionButton optReportEditor 
                  Caption         =   "PACS����༭��"
                  Height          =   255
                  Index           =   1
                  Left            =   2400
                  TabIndex        =   108
                  Top             =   240
                  Width           =   1575
               End
            End
            Begin VB.Frame fra 
               Caption         =   "��������"
               Height          =   3375
               Index           =   20
               Left            =   -74280
               TabIndex        =   219
               Top             =   2640
               Width           =   7245
               Begin VB.CheckBox chkPDF 
                  Caption         =   "PDF����洢�豸"
                  Height          =   180
                  Left            =   4440
                  TabIndex        =   468
                  Top             =   720
                  Width           =   1695
               End
               Begin VB.Frame Frame8 
                  Height          =   735
                  Left            =   4320
                  TabIndex        =   466
                  Top             =   720
                  Width           =   2655
                  Begin VB.ComboBox cboPDF 
                     Height          =   300
                     Left            =   120
                     Style           =   2  'Dropdown List
                     TabIndex        =   467
                     Top             =   240
                     Width           =   2490
                  End
               End
               Begin VB.CheckBox chkImageSignVal 
                  Caption         =   "����ǩ��ͼ����֤"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   460
                  Top             =   960
                  Width           =   1740
               End
               Begin VB.Frame fra 
                  Caption         =   "�����ı�������"
                  Height          =   1335
                  Index           =   26
                  Left            =   240
                  TabIndex        =   361
                  Top             =   1920
                  Width           =   3615
                  Begin VB.TextBox txtCheckView 
                     Height          =   270
                     Left            =   1560
                     TabIndex        =   364
                     Top             =   225
                     Width           =   1335
                  End
                  Begin VB.TextBox txtResult 
                     Height          =   270
                     Left            =   1560
                     TabIndex        =   363
                     Top             =   600
                     Width           =   1335
                  End
                  Begin VB.TextBox txtAdvice 
                     Height          =   270
                     Left            =   1560
                     TabIndex        =   362
                     Top             =   960
                     Width           =   1335
                  End
                  Begin VB.Label lab 
                     Caption         =   "���������"
                     Height          =   255
                     Index           =   10
                     Left            =   360
                     TabIndex        =   367
                     Top             =   240
                     Width           =   975
                  End
                  Begin VB.Label lab 
                     Caption         =   "��������"
                     Height          =   255
                     Index           =   11
                     Left            =   360
                     TabIndex        =   366
                     Top             =   608
                     Width           =   975
                  End
                  Begin VB.Label lab 
                     Caption         =   "��    �飺"
                     Height          =   255
                     Index           =   12
                     Left            =   360
                     TabIndex        =   365
                     Top             =   975
                     Width           =   975
                  End
               End
               Begin VB.Frame Frame7 
                  Caption         =   "��ӡ��ʽѡ��ʽ"
                  Height          =   1335
                  Left            =   4200
                  TabIndex        =   294
                  Top             =   1920
                  Width           =   2745
                  Begin VB.CheckBox chkPrintFormat 
                     Caption         =   "��ѡ�����ʽ"
                     Height          =   255
                     Left            =   240
                     TabIndex        =   306
                     Top             =   960
                     Width           =   1455
                  End
                  Begin VB.OptionButton optPrintFormat 
                     Caption         =   "��¼���һ�δ�ӡ��ʽ"
                     Height          =   255
                     Index           =   0
                     Left            =   240
                     TabIndex        =   296
                     Top             =   240
                     Value           =   -1  'True
                     Width           =   2175
                  End
                  Begin VB.OptionButton optPrintFormat 
                     Caption         =   "ʼ�ձ���Ĭ�ϸ�ʽ"
                     Height          =   255
                     Index           =   1
                     Left            =   240
                     TabIndex        =   295
                     Top             =   600
                     Width           =   1815
                  End
               End
               Begin VB.CheckBox chkUntreadPrinted 
                  Caption         =   "��˴�ӡ���������"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   114
                  Top             =   600
                  Width           =   1935
               End
               Begin VB.CheckBox chkSpecialContent 
                  Caption         =   "��ʾר�Ʊ������ݣ�"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   115
                  Top             =   1300
                  Width           =   2055
               End
               Begin VB.ComboBox cboSpecialContent 
                  Enabled         =   0   'False
                  Height          =   300
                  Left            =   240
                  TabIndex        =   116
                  Text            =   "Combo1"
                  Top             =   1560
                  Width           =   6735
               End
               Begin VB.CheckBox chkExitAfterPrint 
                  Caption         =   "��ӡ���˳�"
                  Height          =   180
                  Left            =   2280
                  TabIndex        =   113
                  Top             =   600
                  Width           =   1335
               End
               Begin VB.CheckBox chkShowVideoCapture 
                  Caption         =   "��ʾ��Ƶ�ɼ�����"
                  Height          =   180
                  Left            =   2280
                  TabIndex        =   112
                  Top             =   240
                  Width           =   1935
               End
               Begin VB.TextBox txtMinImageCount 
                  Height          =   270
                  Left            =   6240
                  MaxLength       =   2
                  TabIndex        =   111
                  Text            =   "8"
                  Top             =   240
                  Width           =   615
               End
               Begin VB.CheckBox chkShowImage 
                  Caption         =   "��ʾ����ͼ������                          ��������ͼ��ʾ������"
                  ForeColor       =   &H00808080&
                  Height          =   180
                  Left            =   240
                  TabIndex        =   110
                  Top             =   240
                  Width           =   6855
               End
               Begin VB.Label Label8 
                  Height          =   255
                  Left            =   2880
                  TabIndex        =   465
                  Top             =   840
                  Width           =   1455
               End
            End
            Begin VB.Frame fra 
               Caption         =   "����ʾ�˫����"
               Height          =   855
               Index           =   21
               Left            =   -74280
               TabIndex        =   218
               Top             =   6060
               Width           =   2415
               Begin VB.OptionButton optWordDblClick 
                  Caption         =   "ֱ��д�뱨��"
                  Height          =   255
                  Index           =   0
                  Left            =   360
                  TabIndex        =   117
                  Top             =   240
                  Width           =   1455
               End
               Begin VB.OptionButton optWordDblClick 
                  Caption         =   "�򿪴ʾ�༭����"
                  Height          =   255
                  Index           =   1
                  Left            =   360
                  TabIndex        =   118
                  Top             =   480
                  Width           =   1750
               End
            End
            Begin VB.Frame fra 
               Caption         =   "����ͼ˫����"
               Height          =   855
               Index           =   22
               Left            =   -71880
               TabIndex        =   217
               Top             =   6060
               Width           =   2415
               Begin VB.OptionButton optImageDblClick 
                  Caption         =   "��ͼƬ�༭����"
                  Height          =   255
                  Index           =   1
                  Left            =   360
                  TabIndex        =   120
                  Top             =   480
                  Width           =   1750
               End
               Begin VB.OptionButton optImageDblClick 
                  Caption         =   "ֱ��д�뱨��"
                  Height          =   255
                  Index           =   0
                  Left            =   360
                  TabIndex        =   119
                  Top             =   240
                  Width           =   1575
               End
            End
            Begin VB.Frame fra 
               Caption         =   "�ʾ�ģ����ʾ"
               Height          =   855
               Index           =   23
               Left            =   -69480
               TabIndex        =   216
               Top             =   6060
               Width           =   2450
               Begin VB.OptionButton optShowWord 
                  Caption         =   "˫������"
                  Height          =   180
                  Index           =   1
                  Left            =   360
                  TabIndex        =   149
                  Top             =   480
                  Width           =   1095
               End
               Begin VB.OptionButton optShowWord 
                  Caption         =   "ֱ����ʾ"
                  Height          =   180
                  Index           =   0
                  Left            =   360
                  TabIndex        =   121
                  Top             =   240
                  Width           =   1095
               End
            End
            Begin VB.Frame fra 
               Caption         =   "��������"
               Height          =   4815
               Index           =   16
               Left            =   -74760
               TabIndex        =   211
               Top             =   480
               Width           =   8295
               Begin VB.CheckBox chkSelectRoom 
                  Caption         =   "����ʱ����Ĭ��ִ�м�"
                  Height          =   210
                  Left            =   4461
                  TabIndex        =   97
                  Top             =   4462
                  Width           =   2220
               End
               Begin VB.CommandButton cmdAddGroup 
                  Caption         =   "��������(&A)"
                  Height          =   375
                  Left            =   120
                  Picture         =   "frmParPacs.frx":30F07
                  TabIndex        =   94
                  TabStop         =   0   'False
                  Top             =   4380
                  Width           =   1170
               End
               Begin VB.CommandButton cmdDelGroup 
                  Caption         =   "ɾ������(&D)"
                  Height          =   375
                  Left            =   1567
                  Picture         =   "frmParPacs.frx":31051
                  TabIndex        =   95
                  TabStop         =   0   'False
                  Top             =   4380
                  Width           =   1170
               End
               Begin VB.CommandButton cmdStudyAcc 
                  Caption         =   "������Ŀ(&R)"
                  Height          =   375
                  Left            =   6960
                  Picture         =   "frmParPacs.frx":3119B
                  TabIndex        =   98
                  TabStop         =   0   'False
                  Top             =   4380
                  Width           =   1155
               End
               Begin VB.CommandButton cmdModify 
                  Caption         =   "�޸ķ���(&M)"
                  Height          =   375
                  Left            =   3014
                  Picture         =   "frmParPacs.frx":312E5
                  TabIndex        =   96
                  TabStop         =   0   'False
                  Top             =   4380
                  Width           =   1170
               End
               Begin zl9BaseItem.ucFlexGrid ufgStudyProCfg 
                  Height          =   1905
                  Left            =   4005
                  TabIndex        =   93
                  Top             =   2430
                  Width           =   4095
                  _extentx        =   7223
                  _extenty        =   3360
                  defaultcols     =   ""
                  colnames        =   "|���������Ŀ>����,w2100,read|��Ŀ����>����,w1100,read|"
                  keyname         =   "��"
                  iscopyadomode   =   0   'False
                  isejectconfig   =   -1  'True
                  headfontcharset =   134
                  headfontweight  =   400
                  headcolor       =   0
                  datafontcharset =   134
                  datafontweight  =   400
                  datacolor       =   -2147483640
                  gridlinecolor   =   14737632
                  headcheckvalue  =   1
               End
               Begin zl9BaseItem.ucFlexGrid ufgRoomCfg 
                  Height          =   2175
                  Left            =   4005
                  TabIndex        =   92
                  Top             =   240
                  Width           =   4095
                  _extentx        =   7223
                  _extenty        =   3836
                  defaultcols     =   ""
                  colnames        =   "|ID,hide|ִ�м�,w1400,read|����ǰ׺,w1400,read|"
                  keyname         =   "��"
                  iscopyadomode   =   0   'False
                  isejectconfig   =   -1  'True
                  headfontcharset =   134
                  headfontweight  =   400
                  headcolor       =   0
                  datafontcharset =   134
                  datafontweight  =   400
                  datacolor       =   -2147483640
                  gridlinecolor   =   14737632
                  headcheckvalue  =   1
               End
               Begin zl9BaseItem.ucFlexGrid ufgGroupCfg 
                  Height          =   4095
                  Left            =   120
                  TabIndex        =   91
                  Top             =   240
                  Width           =   3735
                  _extentx        =   6588
                  _extenty        =   7223
                  defaultcols     =   ""
                  colnames        =   "|ID,hide,key|����,w1400,read|����ǰ׺,w1500,read|"
                  keyname         =   "ID"
                  iscopyadomode   =   0   'False
                  isejectconfig   =   -1  'True
                  headfontcharset =   134
                  headfontweight  =   400
                  datafontcharset =   134
                  datafontweight  =   400
               End
            End
            Begin VB.Frame fra 
               Height          =   1635
               Index           =   17
               Left            =   -74760
               TabIndex        =   206
               Top             =   5400
               Width           =   8295
               Begin VB.CheckBox chkUseSchNumInQueue 
                  Caption         =   "ʹ��ԤԼ���Ŷ�"
                  Height          =   180
                  Left            =   6360
                  TabIndex        =   453
                  Top             =   1237
                  Value           =   1  'Checked
                  Width           =   1575
               End
               Begin VB.CheckBox chkUseQueue 
                  Caption         =   "�����Ŷӽк�"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   452
                  ToolTipText     =   "�����ŶӽкŹ��ܣ�������Ӱ��ɼ�վ��Ӱ��ҽ��վ��"
                  Top             =   0
                  Value           =   1  'Checked
                  Width           =   1575
               End
               Begin VB.CheckBox chkAutoInQueue 
                  Caption         =   "�������Զ��Ŷ�"
                  Height          =   180
                  Left            =   6360
                  TabIndex        =   105
                  Top             =   949
                  Value           =   1  'Checked
                  Width           =   1575
               End
               Begin VB.CheckBox chkUseQueueMsg 
                  Caption         =   "�����Ŷ���Ϣ����"
                  Height          =   180
                  Left            =   6360
                  TabIndex        =   106
                  Top             =   375
                  Value           =   1  'Checked
                  Width           =   1815
               End
               Begin VB.ComboBox cbxPrintQueueNoWay 
                  Height          =   300
                  ItemData        =   "frmParPacs.frx":3142F
                  Left            =   1680
                  List            =   "frmParPacs.frx":3143C
                  Style           =   2  'Dropdown List
                  TabIndex        =   104
                  Top             =   742
                  Width           =   1740
               End
               Begin VB.Frame fra 
                  Caption         =   "δָ��ִ�м���Ŷӷ�ʽ"
                  Height          =   810
                  Index           =   18
                  Left            =   3750
                  TabIndex        =   207
                  Top             =   240
                  Width           =   2265
                  Begin VB.OptionButton optNumberRule 
                     Caption         =   "���������Ŷ�"
                     Height          =   180
                     Index           =   0
                     Left            =   105
                     TabIndex        =   102
                     ToolTipText     =   "���ڷ�����ִ�м�ļ�飬�ŶӺ��뽫��ִ�м��������ɣ���δ����ִ�еļ�飬�ŶӺ��뽫�������������ɡ�"
                     Top             =   240
                     Value           =   -1  'True
                     Width           =   1755
                  End
                  Begin VB.OptionButton optNumberRule 
                     Caption         =   "���������Ŷ�"
                     Height          =   180
                     Index           =   1
                     Left            =   105
                     TabIndex        =   103
                     ToolTipText     =   "���ڷ�����ִ�м�ļ�飬�ŶӺ��뽫��ִ�м��������ɣ���δ����ִ�еļ�飬�ŶӺ��뽫���ݼ�����������������ɡ�"
                     Top             =   480
                     Width           =   1665
                  End
               End
               Begin VB.CheckBox chkSynStudyList 
                  Caption         =   "ͬ����λ����б�"
                  Height          =   180
                  Left            =   6360
                  TabIndex        =   100
                  ToolTipText     =   "����Ŷ��б������б����ݺ�ͬ����λ������б�"
                  Top             =   662
                  Width           =   1815
               End
               Begin VB.TextBox txtQueueReport 
                  Height          =   315
                  Left            =   1635
                  TabIndex        =   101
                  Top             =   1170
                  Width           =   4380
               End
               Begin VB.TextBox txtValidDays 
                  Height          =   315
                  Left            =   1515
                  MaxLength       =   2
                  TabIndex        =   99
                  Text            =   "1"
                  Top             =   308
                  Width           =   555
               End
               Begin VB.Label lab 
                  Caption         =   "�źŵ���ӡ��ʽ��"
                  Height          =   255
                  Index           =   9
                  Left            =   240
                  TabIndex        =   210
                  Top             =   765
                  Width           =   1455
               End
               Begin VB.Label lab 
                  Caption         =   "�źŵ������ţ�"
                  Height          =   225
                  Index           =   8
                  Left            =   240
                  TabIndex        =   209
                  ToolTipText     =   "�ŶӴ��ʱ��Ӧ���Զ��屨���š�"
                  Top             =   1215
                  Width           =   1455
               End
               Begin VB.Label lab 
                  Caption         =   "������Ч������       ��"
                  Height          =   210
                  Index           =   7
                  Left            =   240
                  TabIndex        =   208
                  Top             =   360
                  Width           =   2235
               End
            End
            Begin VB.Frame fra 
               Caption         =   "ƴ����"
               Height          =   1455
               Index           =   4
               Left            =   5280
               TabIndex        =   204
               Top             =   5400
               Width           =   2775
               Begin VB.OptionButton optCapital 
                  Caption         =   "��д"
                  Height          =   255
                  Index           =   0
                  Left            =   240
                  TabIndex        =   28
                  ToolTipText     =   "ѡ���ƴ������ʾȫΪ��д��ĸ��"
                  Top             =   240
                  Width           =   735
               End
               Begin VB.OptionButton optCapital 
                  Caption         =   "Сд"
                  Height          =   255
                  Index           =   1
                  Left            =   1560
                  TabIndex        =   29
                  ToolTipText     =   "ѡ���ƴ������ʾȫΪСд��ĸ��"
                  Top             =   240
                  Width           =   735
               End
               Begin VB.OptionButton optCapital 
                  Caption         =   "����ĸ��д"
                  Height          =   255
                  Index           =   2
                  Left            =   240
                  TabIndex        =   30
                  ToolTipText     =   "ѡ���ƴ��������ĸ��д��"
                  Top             =   560
                  Width           =   1215
               End
               Begin VB.Frame fra 
                  Caption         =   "���"
                  Height          =   540
                  Index           =   11
                  Left            =   240
                  TabIndex        =   205
                  Top             =   840
                  Width           =   1695
                  Begin VB.OptionButton optSplitter 
                     Caption         =   "��"
                     Height          =   255
                     Index           =   1
                     Left            =   960
                     TabIndex        =   32
                     ToolTipText     =   "ƴ����֮���޼����"
                     Top             =   200
                     Width           =   495
                  End
                  Begin VB.OptionButton optSplitter 
                     Caption         =   "�ո�"
                     Height          =   255
                     Index           =   0
                     Left            =   120
                     TabIndex        =   31
                     ToolTipText     =   "ƴ����֮��ʹ�ÿո�Ϊ�������"
                     Top             =   200
                     Width           =   735
                  End
               End
            End
            Begin VB.Frame fra 
               Caption         =   "�ȼ��󱨵���ͼ��ƥ��"
               Height          =   1665
               Index           =   3
               Left            =   5280
               TabIndex        =   203
               Top             =   3600
               Width           =   2775
               Begin VB.OptionButton optMatch 
                  Caption         =   "����/סԺ��"
                  Height          =   195
                  Index           =   1
                  Left            =   240
                  TabIndex        =   27
                  ToolTipText     =   "����ʱͨ������/סԺ�ź�ͼ����Ϣ����ƥ�䣬������Ӱ��ҽ��վ��"
                  Top             =   1000
                  Width           =   1335
               End
               Begin VB.OptionButton optMatch 
                  Caption         =   "����"
                  Height          =   195
                  Index           =   0
                  Left            =   240
                  TabIndex        =   25
                  ToolTipText     =   "����ʱͨ�����ź�ͼ����Ϣ����ƥ�䣬������Ӱ��ҽ��վ��"
                  Top             =   360
                  Width           =   855
               End
               Begin VB.OptionButton optMatch 
                  Caption         =   "ҽ��ID"
                  Height          =   195
                  Index           =   2
                  Left            =   240
                  TabIndex        =   26
                  ToolTipText     =   "����ʱͨ��ҽ��ID��ͼ����Ϣ����ƥ�䣬������Ӱ��ҽ��վ��"
                  Top             =   680
                  Width           =   855
               End
            End
            Begin VB.Frame fra 
               Caption         =   "��������"
               Height          =   1665
               Index           =   2
               Left            =   720
               TabIndex        =   201
               Top             =   3600
               Width           =   4215
               Begin VB.CheckBox chkImgShowDesc 
                  Caption         =   "ͼ������ʾ"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   377
                  ToolTipText     =   "����ͼ�Ƿ�ͼ��ɼ�ʱ�䵹����ʾ��"
                  Top             =   1320
                  Width           =   1425
               End
               Begin VB.Frame Frame1 
                  Caption         =   "���ٹ�������"
                  Height          =   780
                  Left            =   2040
                  TabIndex        =   298
                  Top             =   840
                  Width           =   2055
                  Begin VB.CheckBox chkNameQueryTimeLimit 
                     Caption         =   "������ѯʱ������"
                     Height          =   255
                     Left            =   120
                     TabIndex        =   300
                     ToolTipText     =   "��������ѯʱ���Ƿ��в�ѯʱ������"
                     Top             =   480
                     Width           =   1850
                  End
                  Begin VB.CheckBox chkNameFuzzySearch 
                     Caption         =   "����Ĭ��ģ����ѯ"
                     Height          =   255
                     Left            =   120
                     TabIndex        =   299
                     ToolTipText     =   "��������ѯʱʹ��ģ����ѯ��û�й�ѡʱ��ֻ������*��Ž���ģ����ѯ"
                     Top             =   240
                     Width           =   1850
                  End
               End
               Begin VB.CheckBox chkSwitchUser 
                  Caption         =   "�����л��û�"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   21
                  ToolTipText     =   "�����л��û����ܣ����Խ����û��л���"
                  Top             =   680
                  Width           =   1455
               End
               Begin VB.Frame fra 
                  Height          =   660
                  Index           =   10
                  Left            =   2040
                  TabIndex        =   202
                  ToolTipText     =   "ѡ��ɼ�ͼ���ɨ�����뵥��ʹ�õĴ洢�豸��"
                  Top             =   180
                  Width           =   2055
                  Begin VB.ComboBox cboSaveDevice 
                     Height          =   300
                     Left            =   120
                     Style           =   2  'Dropdown List
                     TabIndex        =   24
                     Top             =   240
                     Width           =   1605
                  End
                  Begin VB.CheckBox chkPetitionCapture 
                     Caption         =   "�������뵥ɨ��"
                     Height          =   180
                     Left            =   120
                     TabIndex        =   23
                     ToolTipText     =   "�������뵥ɨ�蹦��"
                     Top             =   0
                     Value           =   1  'Checked
                     Width           =   1575
                  End
               End
               Begin VB.CheckBox chkUseReferencePatient 
                  Caption         =   "���ù�������"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   22
                  ToolTipText     =   "֧�ֶ����������ͬһ��������Ϣ��"
                  Top             =   1000
                  Width           =   1455
               End
               Begin VB.CheckBox chkChangeUser 
                  Caption         =   "���ý����û�"
                  Height          =   180
                  Left            =   240
                  TabIndex        =   20
                  ToolTipText     =   "������û����ܣ����Խ������ҽ���ͱ���ҽ����������Ӱ��ɼ�վ��"
                  Top             =   360
                  Width           =   1455
               End
            End
         End
         Begin MSComDlg.CommonDialog dlgColor 
            Left            =   4920
            Top             =   0
            _ExtentX        =   847
            _ExtentY        =   847
            _Version        =   393216
         End
      End
      Begin VB.PictureBox picPar 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H80000008&
         Height          =   6975
         Index           =   5
         Left            =   -75000
         ScaleHeight     =   6975
         ScaleWidth      =   7815
         TabIndex        =   195
         Top             =   360
         Width           =   7815
         Begin VB.Frame fra 
            Height          =   1695
            Index           =   40
            Left            =   120
            TabIndex        =   280
            Top             =   120
            Width           =   4455
            Begin VB.ComboBox cbo 
               Height          =   300
               Index           =   3
               Left            =   2160
               TabIndex        =   175
               Top             =   720
               Width           =   2175
            End
            Begin VB.TextBox txt 
               Height          =   300
               Index           =   21
               Left            =   2160
               TabIndex        =   174
               Text            =   "100"
               Top             =   240
               Width           =   735
            End
            Begin VB.CheckBox chk 
               Caption         =   "����ȷ�Ϻ��Զ���ӡ���Ļ�ִ��"
               Height          =   255
               Index           =   8
               Left            =   120
               TabIndex        =   176
               Top             =   1200
               Width           =   2895
            End
            Begin VB.Label lab 
               Caption         =   "��"
               Height          =   255
               Index           =   56
               Left            =   3000
               TabIndex        =   283
               Top             =   280
               Width           =   255
            End
            Begin VB.Label lab 
               Caption         =   "���Ļ�ִ��Ӧ�������ƣ�"
               Height          =   255
               Index           =   57
               Left            =   120
               TabIndex        =   282
               Top             =   760
               Width           =   2055
            End
            Begin VB.Label lab 
               Caption         =   "���ļ�¼Ĭ�ϲ�ѯ������"
               Height          =   255
               Index           =   55
               Left            =   120
               TabIndex        =   281
               Top             =   285
               Width           =   2055
            End
         End
      End
      Begin VB.PictureBox picPar 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H80000008&
         Height          =   6975
         Index           =   4
         Left            =   -75000
         ScaleHeight     =   6975
         ScaleWidth      =   7815
         TabIndex        =   194
         Top             =   360
         Width           =   7815
         Begin VB.Frame fra 
            Height          =   1215
            Index           =   39
            Left            =   120
            TabIndex        =   276
            Top             =   120
            Width           =   4455
            Begin VB.TextBox txt 
               Height          =   300
               Index           =   20
               Left            =   2160
               TabIndex        =   172
               Text            =   "30"
               Top             =   240
               Width           =   735
            End
            Begin VB.ComboBox cbo 
               Height          =   300
               Index           =   2
               Left            =   2160
               TabIndex        =   173
               Top             =   720
               Width           =   2175
            End
            Begin VB.Label lab 
               Caption         =   "������¼Ĭ�ϲ�ѯ������"
               Height          =   255
               Index           =   52
               Left            =   120
               TabIndex        =   279
               Top             =   285
               Width           =   2055
            End
            Begin VB.Label lab 
               Caption         =   "������ǩ��Ӧ�������ƣ�"
               Height          =   255
               Index           =   54
               Left            =   120
               TabIndex        =   278
               Top             =   760
               Width           =   2055
            End
            Begin VB.Label lab 
               Caption         =   "��"
               Height          =   255
               Index           =   53
               Left            =   3000
               TabIndex        =   277
               Top             =   280
               Width           =   255
            End
         End
      End
      Begin VB.PictureBox picPar 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H80000008&
         Height          =   6975
         Index           =   3
         Left            =   -75000
         ScaleHeight     =   6975
         ScaleWidth      =   7815
         TabIndex        =   193
         Top             =   360
         Width           =   7815
         Begin VB.CheckBox chk 
            Caption         =   "¼����Ժ��Ϣ"
            Height          =   255
            Index           =   9
            Left            =   240
            TabIndex        =   347
            Top             =   4440
            Width           =   1455
         End
         Begin VB.Frame Frame4 
            Caption         =   "Frame4"
            Height          =   735
            Left            =   120
            TabIndex        =   309
            Top             =   4440
            Width           =   4815
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   22
               Left            =   1680
               TabIndex        =   349
               Top             =   300
               Width           =   2895
            End
            Begin VB.Label lab 
               Caption         =   "�ͼ쵥λ���ã�"
               Height          =   255
               Index           =   61
               Left            =   240
               TabIndex        =   348
               Top             =   360
               Width           =   1335
            End
         End
         Begin VB.ListBox lst 
            Height          =   2790
            Index           =   0
            Left            =   5280
            Style           =   1  'Checkbox
            TabIndex        =   307
            Top             =   600
            Width           =   2055
         End
         Begin VB.ComboBox cbo 
            Height          =   300
            Index           =   5
            ItemData        =   "frmParPacs.frx":3146C
            Left            =   1410
            List            =   "frmParPacs.frx":31479
            Style           =   2  'Dropdown List
            TabIndex        =   303
            Top             =   3960
            Width           =   2205
         End
         Begin VB.Frame fra 
            Caption         =   "����ѡ���ͼ�����ʱ�Զ�������������"
            Height          =   1095
            Index           =   38
            Left            =   120
            TabIndex        =   275
            Top             =   2640
            Width           =   4815
            Begin VB.CheckBox chk 
               Caption         =   "����"
               Height          =   375
               Index           =   2
               Left            =   480
               TabIndex        =   166
               Top             =   240
               Width           =   735
            End
            Begin VB.CheckBox chk 
               Caption         =   "����"
               Height          =   375
               Index           =   3
               Left            =   1800
               TabIndex        =   167
               Top             =   240
               Width           =   735
            End
            Begin VB.CheckBox chk 
               Caption         =   "ϸ��"
               Height          =   375
               Index           =   4
               Left            =   3240
               TabIndex        =   168
               Top             =   240
               Width           =   735
            End
            Begin VB.CheckBox chk 
               Caption         =   "����"
               Height          =   375
               Index           =   5
               Left            =   480
               TabIndex        =   169
               Top             =   600
               Width           =   735
            End
            Begin VB.CheckBox chk 
               Caption         =   "ʬ��"
               Height          =   375
               Index           =   6
               Left            =   1800
               TabIndex        =   170
               Top             =   600
               Width           =   735
            End
            Begin VB.CheckBox chk 
               Caption         =   "��Ƭ"
               Height          =   375
               Index           =   7
               Left            =   3240
               TabIndex        =   171
               Top             =   600
               Width           =   735
            End
         End
         Begin VB.Frame fra 
            Caption         =   "�ʾ�ģ������"
            Height          =   2415
            Index           =   37
            Left            =   120
            TabIndex        =   267
            Top             =   120
            Width           =   4815
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   15
               Left            =   1560
               TabIndex        =   161
               Top             =   495
               Width           =   3015
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   16
               Left            =   1560
               TabIndex        =   162
               Top             =   855
               Width           =   3015
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   17
               Left            =   1560
               TabIndex        =   163
               Top             =   1215
               Width           =   3015
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   18
               Left            =   1560
               TabIndex        =   164
               Top             =   1575
               Width           =   3015
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   19
               Left            =   1560
               TabIndex        =   268
               Top             =   1935
               Width           =   3015
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "��Ӧ�ʾ����"
               Height          =   180
               Index           =   51
               Left            =   2400
               TabIndex        =   274
               Top             =   240
               Width           =   1080
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "�޼�����ģ�壺"
               Height          =   180
               Index           =   46
               Left            =   240
               TabIndex        =   273
               Top             =   540
               Width           =   1260
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "���汨��ģ�壺"
               Height          =   180
               Index           =   47
               Left            =   240
               TabIndex        =   272
               Top             =   900
               Width           =   1260
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "���߱���ģ�壺"
               Height          =   180
               Index           =   48
               Left            =   240
               TabIndex        =   271
               Top             =   1260
               Width           =   1260
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "���ӱ���ģ�壺"
               Height          =   180
               Index           =   50
               Left            =   240
               TabIndex        =   270
               Top             =   1980
               Width           =   1260
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "��Ⱦ����ģ�壺"
               Height          =   180
               Index           =   49
               Left            =   240
               TabIndex        =   269
               Top             =   1620
               Width           =   1260
            End
         End
         Begin VB.Label lab 
            AutoSize        =   -1  'True
            Caption         =   "����ȡ����ʾ��Ϣ"
            Height          =   180
            Index           =   60
            Left            =   5280
            TabIndex        =   308
            Top             =   240
            Width           =   1440
         End
         Begin VB.Label lab 
            Caption         =   "����ִ��ģʽ��"
            Height          =   270
            Index           =   59
            Left            =   120
            TabIndex        =   304
            Top             =   4005
            Width           =   1305
         End
      End
      Begin VB.PictureBox picPar 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H80000008&
         Height          =   6975
         Index           =   2
         Left            =   -75000
         ScaleHeight     =   6975
         ScaleWidth      =   7815
         TabIndex        =   192
         Top             =   360
         Width           =   7815
         Begin VB.Frame fra 
            Height          =   1575
            Index           =   36
            Left            =   120
            TabIndex        =   286
            Top             =   120
            Width           =   4095
            Begin VB.CheckBox chk 
               Caption         =   "��첡�����ʱ���жϽɷ����"
               Height          =   255
               Index           =   11
               Left            =   120
               TabIndex        =   459
               Top             =   1080
               Width           =   2895
            End
            Begin VB.ComboBox cbo 
               Height          =   300
               Index           =   1
               ItemData        =   "frmParPacs.frx":314A1
               Left            =   1410
               List            =   "frmParPacs.frx":314AE
               Style           =   2  'Dropdown List
               TabIndex        =   288
               Top             =   600
               Width           =   2205
            End
            Begin VB.CheckBox chk 
               Caption         =   "¼����Ժ��Ϣ"
               Height          =   255
               Index           =   1
               Left            =   120
               TabIndex        =   287
               Top             =   240
               Width           =   1590
            End
            Begin VB.Label lab 
               Caption         =   "����ִ��ģʽ��"
               Height          =   270
               Index           =   45
               Left            =   120
               TabIndex        =   289
               Top             =   645
               Width           =   1305
            End
         End
      End
      Begin VB.PictureBox picPar 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H80000008&
         Height          =   6975
         Index           =   1
         Left            =   -75000
         ScaleHeight     =   6975
         ScaleWidth      =   7815
         TabIndex        =   191
         Top             =   360
         Width           =   7815
         Begin VB.TextBox txt 
            Height          =   270
            Index           =   12
            Left            =   1530
            TabIndex        =   464
            Top             =   6600
            Width           =   2205
         End
         Begin VB.CheckBox chk 
            Caption         =   "��첡�����ʱ���жϽɷ����"
            Height          =   375
            Index           =   10
            Left            =   4680
            TabIndex        =   458
            Top             =   6120
            Width           =   2910
         End
         Begin VB.ComboBox cbo 
            Height          =   300
            Index           =   4
            ItemData        =   "frmParPacs.frx":314D6
            Left            =   1530
            List            =   "frmParPacs.frx":314E0
            Style           =   2  'Dropdown List
            TabIndex        =   301
            Top             =   6120
            Width           =   2205
         End
         Begin VB.CheckBox chk 
            Caption         =   "¼����Ժ��Ϣ"
            Height          =   255
            Index           =   0
            Left            =   240
            TabIndex        =   143
            Top             =   120
            Width           =   1590
         End
         Begin VB.Frame fra 
            Caption         =   "XWPACS��Ƭ"
            Height          =   5295
            Index           =   31
            Left            =   240
            TabIndex        =   247
            Top             =   600
            Width           =   7335
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   23
               Left            =   1600
               TabIndex        =   378
               Top             =   3870
               Width           =   5640
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   11
               Left            =   1600
               TabIndex        =   157
               Text            =   "zlhis"
               Top             =   4335
               Width           =   5640
            End
            Begin VB.Frame fra 
               Caption         =   "ɾ��ͼ���û�"
               Height          =   1215
               Index           =   32
               Left            =   120
               TabIndex        =   264
               Top             =   360
               Width           =   2295
               Begin VB.TextBox txt 
                  Height          =   270
                  IMEMode         =   3  'DISABLE
                  Index           =   1
                  Left            =   720
                  PasswordChar    =   "*"
                  TabIndex        =   145
                  Top             =   720
                  Width           =   1455
               End
               Begin VB.TextBox txt 
                  Height          =   270
                  Index           =   0
                  Left            =   720
                  TabIndex        =   144
                  Top             =   360
                  Width           =   1455
               End
               Begin VB.Label lab 
                  Caption         =   "����"
                  Height          =   255
                  Index           =   33
                  Left            =   120
                  TabIndex        =   266
                  Top             =   780
                  Width           =   615
               End
               Begin VB.Label lab 
                  Caption         =   "�û���"
                  Height          =   255
                  Index           =   32
                  Left            =   120
                  TabIndex        =   265
                  Top             =   420
                  Width           =   615
               End
            End
            Begin VB.Frame fra 
               Caption         =   "����ͼ���û�"
               Height          =   1215
               Index           =   33
               Left            =   2520
               TabIndex        =   261
               Top             =   360
               Width           =   2295
               Begin VB.TextBox txt 
                  Height          =   270
                  Index           =   2
                  Left            =   720
                  TabIndex        =   146
                  Top             =   360
                  Width           =   1455
               End
               Begin VB.TextBox txt 
                  Height          =   270
                  IMEMode         =   3  'DISABLE
                  Index           =   3
                  Left            =   720
                  PasswordChar    =   "*"
                  TabIndex        =   147
                  Top             =   720
                  Width           =   1455
               End
               Begin VB.Label lab 
                  Caption         =   "�û���"
                  Height          =   255
                  Index           =   34
                  Left            =   120
                  TabIndex        =   263
                  Top             =   420
                  Width           =   615
               End
               Begin VB.Label lab 
                  Caption         =   "����"
                  Height          =   255
                  Index           =   35
                  Left            =   120
                  TabIndex        =   262
                  Top             =   780
                  Width           =   615
               End
            End
            Begin VB.Frame fra 
               Caption         =   "���̿�¼�û�"
               Height          =   1215
               Index           =   34
               Left            =   4920
               TabIndex        =   258
               Top             =   360
               Width           =   2295
               Begin VB.TextBox txt 
                  Height          =   270
                  IMEMode         =   3  'DISABLE
                  Index           =   5
                  Left            =   720
                  PasswordChar    =   "*"
                  TabIndex        =   150
                  Top             =   720
                  Width           =   1455
               End
               Begin VB.TextBox txt 
                  Height          =   270
                  Index           =   4
                  Left            =   720
                  TabIndex        =   148
                  Top             =   360
                  Width           =   1455
               End
               Begin VB.Label lab 
                  Caption         =   "����"
                  Height          =   255
                  Index           =   37
                  Left            =   120
                  TabIndex        =   260
                  Top             =   780
                  Width           =   615
               End
               Begin VB.Label lab 
                  Caption         =   "�û���"
                  Height          =   255
                  Index           =   36
                  Left            =   120
                  TabIndex        =   259
                  Top             =   420
                  Width           =   615
               End
            End
            Begin VB.Frame fra 
               Caption         =   "XWPACS ���ݿ������"
               Height          =   855
               Index           =   35
               Left            =   120
               TabIndex        =   248
               Top             =   1800
               Width           =   7095
               Begin VB.CommandButton cmdTestCon 
                  Caption         =   "��"
                  Height          =   375
                  Left            =   6600
                  TabIndex        =   154
                  Top             =   300
                  Width           =   375
               End
               Begin VB.TextBox txt 
                  Height          =   270
                  Index           =   6
                  Left            =   840
                  TabIndex        =   151
                  Top             =   360
                  Width           =   1455
               End
               Begin VB.TextBox txt 
                  Height          =   270
                  Index           =   7
                  Left            =   3000
                  TabIndex        =   152
                  Top             =   360
                  Width           =   1455
               End
               Begin VB.TextBox txt 
                  Height          =   270
                  IMEMode         =   3  'DISABLE
                  Index           =   8
                  Left            =   5040
                  PasswordChar    =   "*"
                  TabIndex        =   153
                  Top             =   360
                  Width           =   1455
               End
               Begin VB.Label lab 
                  Caption         =   "������"
                  Height          =   255
                  Index           =   29
                  Left            =   240
                  TabIndex        =   251
                  Top             =   420
                  Width           =   855
               End
               Begin VB.Label lab 
                  Caption         =   "�û���"
                  Height          =   255
                  Index           =   30
                  Left            =   2400
                  TabIndex        =   250
                  Top             =   420
                  Width           =   855
               End
               Begin VB.Label lab 
                  Caption         =   "����"
                  Height          =   255
                  Index           =   31
                  Left            =   4560
                  TabIndex        =   249
                  Top             =   420
                  Width           =   495
               End
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   13
               Left            =   1200
               TabIndex        =   158
               Text            =   "1"
               Top             =   4800
               Width           =   960
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   14
               Left            =   3255
               TabIndex        =   159
               Text            =   "2"
               Top             =   4800
               Width           =   960
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   9
               Left            =   1600
               TabIndex        =   155
               Text            =   "http://127.0.0.1:8080/TakeImage.aspx?colid0=22&colvalue0=[@STU_NO]"
               Top             =   2910
               Width           =   5640
            End
            Begin VB.ComboBox cbo 
               Height          =   300
               Index           =   0
               ItemData        =   "frmParPacs.frx":314FC
               Left            =   5428
               List            =   "frmParPacs.frx":31506
               Style           =   2  'Dropdown List
               TabIndex        =   160
               Top             =   4785
               Width           =   1812
            End
            Begin VB.TextBox txt 
               Height          =   270
               Index           =   10
               Left            =   1600
               TabIndex        =   156
               Text            =   "http://127.0.0.1:8080/KeyImage.aspx?colid0=22&colvalue0=[@STU_NO]"
               Top             =   3405
               Width           =   5640
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               Caption         =   "����б��Ƭ��ַ"
               Height          =   180
               Index           =   2
               Left            =   135
               TabIndex        =   379
               Top             =   3915
               Width           =   1560
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               Caption         =   "�ӿڰ�ӵ����"
               Height          =   240
               Index           =   40
               Left            =   135
               TabIndex        =   257
               Top             =   4350
               Width           =   1440
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               Caption         =   "��鷽����"
               Height          =   180
               Index           =   42
               Left            =   135
               TabIndex        =   256
               Top             =   4845
               Width           =   900
            End
            Begin VB.Label lab 
               Caption         =   "���з�����"
               Height          =   180
               Index           =   43
               Left            =   2220
               TabIndex        =   255
               Top             =   4845
               Width           =   975
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               Caption         =   "WEB��Ƭ��ַ"
               Height          =   240
               Index           =   38
               Left            =   135
               TabIndex        =   254
               Top             =   2925
               Width           =   1320
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               Caption         =   "3D��Ƭ����"
               Height          =   180
               Index           =   44
               Left            =   4380
               TabIndex        =   253
               Top             =   4845
               Width           =   960
            End
            Begin VB.Label lab 
               AutoSize        =   -1  'True
               Caption         =   "�ؼ�ͼ���ַ"
               Height          =   240
               Index           =   39
               Left            =   135
               TabIndex        =   252
               Top             =   3420
               Width           =   1440
            End
         End
         Begin VB.Label lab 
            Caption         =   "��ӡ��������"
            Height          =   255
            Index           =   41
            Left            =   240
            TabIndex        =   463
            Top             =   6600
            Width           =   1095
         End
         Begin VB.Label lab 
            Caption         =   "����ִ��ģʽ"
            Height          =   270
            Index           =   58
            Left            =   240
            TabIndex        =   302
            Top             =   6165
            Width           =   1305
         End
      End
   End
End
Attribute VB_Name = "frmParPacs"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


Private Type TYPE_USER_INFO
    ID As Long
    ����ID As Long
    ��� As String
    ���� As String
    ���� As String
    �û��� As String
End Type

Private Enum TNeedType
    tNeedName = 0
    tNeedNo = 1
    tNeedAll = 2
End Enum

'���ԤԼ�豸
Private Enum constScheduleDeviceList
    col_SchDevice_ID = 0
    col_SchDevice_�Ƿ����� = 1
    col_SchDevice_Ӱ����� = 2
    col_SchDevice_�豸���� = 3
End Enum

'���ԤԼ����
Private Enum constSchedulePlanList
    col_SchPlan_ID = 0
    col_SchPlan_�������� = 1
    col_SchPlan_�Ƿ����� = 2
    col_SchPlan_�������� = 3
    col_SchPlan_�������� = 4
    col_SchPlan_��� = 5
    col_SchPlan_�Ƿ�������Ϣ = 6
    col_SchPlan_��ʼʱ�� = 7
End Enum

'���ԤԼ��������
Private Enum constSchedulePlanType
    Sch_PlanType_ÿ�� = 1
    Sch_PlanType_ÿ�� = 2
    Sch_PlanType_ÿ�� = 3
    Sch_PlanType_һ�� = 4
End Enum

Private Const Report_Form_frmReportES  As String = "�ھ�������Ϣ"
Private Const Report_Form_frmReportPathology As String = "������Һ��������Ϣ"
Private Const Report_Form_frmReportUS As String = "B�����������Ϣ"
Private Const Report_Form_frmReportCustom As String = "�Զ���ר�Ʊ���"
Private Const M_STR_NOPDF As String = "�����б���PDFת��"


Private mrsPar As ADODB.Recordset '������ؼ���Ӧ��¼����ͬһ���������ܶ�Ӧһ�����ؼ���
Private marrFunc(1) As String
Private mblnLoading As Boolean   '�Ƿ��������

Private mrsDeptParas As ADODB.Recordset '���Ʋ�������

Private mstrPrivs As String         '��ģ���Ȩ��
Private mlng����ID As Long          'IN:��ǰִ�п���ID
Private mlngCur����ID As Long       '��ǰ����ID
Private mstrCur���� As String       '��ǰ���� ����-����
Private mstrCanUse���� As String    '��ǰ���ÿ���  ID_����-����
Private mblnOk As Boolean

'���ԤԼ
Private mlngDeviceRow As Long
Private mlngDiagnosisRow As Long
Private mstrUseDept As String
Private mstrSchRestDate As String   'ԤԼ��Ϣ��
Private mblnKeyPress As Boolean
Private WithEvents mobjAddDiagnosis As frmSchAddDiagnosis
Attribute mobjAddDiagnosis.VB_VarHelpID = -1
Private mblnClickRestDate As Boolean '�Ƿ񴥷���Ϣ�յĵ����¼�

Private UserInfo As TYPE_USER_INFO

Private Enum constLst
    lst_PatholInfo = 0
End Enum

Private Enum constTxtLocate
    txt_Par = 0
    txt_Dept = 1
End Enum

Private Enum constChk
    chk_¼����Ժ��������Ϣ = 0
    chk_¼����Ժ���������Ϣ = 1
    chk_���没������������ = 2
    chk_������������������ = 3
    chk_ϸ���������������� = 4
    chk_���ﲡ������������ = 5
    chk_ʬ�첡������������ = 6
    chk_��Ƭ�������������� = 7
    chk_���ĺ��Զ���ӡ��ִ�� = 8
    chk_¼����Ժ��Ϣ = 9
    chk_��첡�����ʱ���жϽɷ����1290 = 10
    chk_��첡�����ʱ���жϽɷ����1291 = 11
End Enum

Private Enum constCbo
    cbo_3D��Ƭ���� = 0
    cbo_�ɼ�����ִ��ģʽ = 1    '�ɼ�վ����ִ��ģʽ0-����ʱִ�У�1-���ʱִ�У�2-����ʱִ��
    cbo_������ǩ�������� = 2
    cbo_���Ļ�ִ�������� = 3
    cbo_ҽ������ִ��ģʽ = 4    '�ɼ�վ����ִ��ģʽ0-����ʱִ�У�1-����ʱִ��
    cbo_�������ִ��ģʽ = 5    '����վ����ִ��ģʽ0-����ʱִ�У�1-���ʱִ�У�2-����ʱִ��
End Enum


Private Enum constTxt
    txt_ͼ��ɾ���û����� = 0
    txt_ͼ��ɾ���û����� = 1
    txt_ͼ�����û����� = 2
    txt_ͼ�����û����� = 3
    txt_ͼ���¼�û����� = 4
    txt_ͼ���¼�û����� = 5
    txt_������IP = 6
    txt_�������û����� = 7
    txt_�������û����� = 8
    txt_WEB��Ƭ��ַ = 9
    txt_�ؼ�ͼ���ַ = 10
    txt_��ӵ���� = 11
    txt_��ӡ�������� = 12
    txt_��鷽���� = 13
    txt_���з����� = 14
    txt_�޼�����ģ�� = 15
    txt_��������ģ�� = 16
    txt_��������ģ�� = 17
    txt_��Ⱦ����ģ�� = 18
    txt_��������ģ�� = 19
    txt_����Ĭ�ϲ�ѯ���� = 20
    txt_�軹Ĭ�ϲ�ѯ���� = 21
    txt_������Ժ���� = 22
    txt_����б��Ƭ��ַ = 23
End Enum

Private Enum DeptColTitle
    ctDt�Ƿ����� = 0
    ctDt�������� = 1
    ctDtID = 2
End Enum

Private Enum DvColTitle
    ctID = 0
    ct�Ƿ����� = 1
    ct�豸���� = 2
    ctӰ���豸 = 3
    ctӰ����� = 4
    ctԤԼ���� = 5
    ct�豸˵�� = 6
    ctӰ���豸�� = 7
    ct����ID = 8
End Enum

Private Enum DgColTitle
    ctDgID = 0
    ct���� = 1
    ct������Ŀ = 2
    ct��λ = 3
    ct���ʱ�� = 4
    ctע������ = 5
    ctDgӰ����� = 6
    ct������ĿID = 7
End Enum
'
'Private Enum constListBox
'    lst_סԺ�����Ժ��� = 0
'End Enum
Private Const SERVICE_START = &H10
Private Const STANDARD_RIGHTS_REQUIRED As Long = &HF0000
Private Const SC_MANAGER_CONNECT As Long = &H1
Private Const SC_MANAGER_CREATE_SERVICE As Long = &H2
Private Const SC_MANAGER_ENUMERATE_SERVICE As Long = &H4
Private Const SC_MANAGER_LOCK As Long = &H8
Private Const SC_MANAGER_QUERY_LOCK_STATUS As Long = &H10
Private Const SC_MANAGER_MODIFY_BOOT_CONFIG As Long = &H20
Private Const SC_MANAGER_ALL_ACCESS As Long = (STANDARD_RIGHTS_REQUIRED Or SC_MANAGER_CONNECT Or SC_MANAGER_CREATE_SERVICE Or SC_MANAGER_ENUMERATE_SERVICE Or SC_MANAGER_LOCK Or SC_MANAGER_QUERY_LOCK_STATUS Or SC_MANAGER_MODIFY_BOOT_CONFIG)

Private Declare Function OpenSCManager Lib "advapi32.dll" Alias "OpenSCManagerA" (ByVal lpMachineName As String, ByVal lpDatabaseName As String, ByVal dwDesiredAccess As Long) As Long
Private Declare Function OpenService Lib "advapi32.dll" Alias "OpenServiceA" (ByVal hSCManager As Long, ByVal lpServiceName As String, ByVal dwDesiredAccess As Long) As Long
Private Declare Function StartService Lib "advapi32.dll" Alias "StartServiceA" (ByVal hService As Long, ByVal dwNumServiceArgs As Long, ByVal lpServiceArgVectors As Long) As Long
Private Declare Function CloseServiceHandle Lib "advapi32.dll" (ByVal hSCObject As Long) As Long




Private Sub cbo_Change(Index As Integer)
    If Not Me.Visible Then Exit Sub
    
    If Index = 1 Then
        Call SetParChange(cbo, Index, mrsPar)
    Else
        
        Call SetParChange(cbo, Index, mrsPar, True, cbo(Index).Text)
    End If
End Sub

Private Sub ConfigAppNoState()
'------------------------------------------------
'���ܣ����ü�����ؿؼ��Ŀ�����
'��������
'���أ�
'------------------------------------------------
    Dim blnUseHisNo As Boolean  'ʹ��HIS�Ĳ���ID��ҽ��ID
    Dim blnCanOverWrite As Boolean  '����������ظ���
    Dim blnCheckMaxNo As Boolean    '����ȡʵ�������롱
    Dim blnChangeNo As Boolean      '�������ֹ��������š�
    
    blnCanOverWrite = True
    blnCheckMaxNo = True
    blnChangeNo = True
    
    '���ü���ѡ���һЩ�߼���ϵ
    '��1�����߼��ű��ֲ��䣬ͬʱ��Ҫ��ѡ�һҵ�����������ظ���
    '��2��ѡ���ˡ�ǰ׺�������ָ��������������ա��󣬽�ֹ�һҵ�����ȡʵ�������롱
    '��3�����ű��ֲ��䣬�����������ͳһ��������ʱ�Զ����桰���տ��ҵ���������Ӱ�����ͳһ��������ʱ�Զ����桰����Ӱ����������
    '��4��ѡ��ҽ��ID����������ID������ֹ�һҵ��������ֹ��������š�����ֹ�һҵ�����ȡʵ�������롱�������һҵ��������ظ�������ֹ���ü��ű���
    '��5��˳�����Զ��ѡ��
    '��6��ѡ���ˡ����������Զ��������򣬽�ֹѡ��Ӱ�����ǰ׺��
    
    If OptCode(1).value = True Then
        chkCanOverWrite.value = 1
        blnCanOverWrite = False
    End If
    
    If chkPreText.value = 1 Or chkDelimiter(1).value = 1 Or chkDelimiter(2).value = 1 Or chkYear.value = 1 _
        Or chkMonth.value = 1 Or chkDay.value = 1 Then
        chkCheckMaxNo.value = 0
        blnCheckMaxNo = False
    End If
    
    If (optUseAdviceID.value = True And OptCode(0).value = True) Or (optUsePatientID.value = True And OptCode(1).value = True) Then
        chkChangeNO.value = 0
        blnChangeNo = False
        chkCanOverWrite.value = 1
        blnCanOverWrite = False
        chkCheckMaxNo.value = 0
        blnCheckMaxNo = False
        blnUseHisNo = True
    Else
        blnUseHisNo = False
    End If
    
    chkNumber.value = 1
    
    If Not mblnLoading Then
        If OptBuildcode(1).value = True And optPreText(0).value = True Then
            optPreText(0).value = False
            Call MsgBox("���Ű��ձ��������Զ���������ֹʹ��Ӱ�����ǰ׺��", vbOKOnly)
        End If
    End If
    
    chkPreText.Enabled = Not blnUseHisNo
    chkDelimiter(1).Enabled = Not blnUseHisNo
    chkDelimiter(2).Enabled = Not blnUseHisNo
    chkYear.Enabled = Not blnUseHisNo
    chkMonth.Enabled = Not blnUseHisNo
    chkDay.Enabled = Not blnUseHisNo
    chkChangeNO.Enabled = blnChangeNo
    chkCanOverWrite.Enabled = blnCanOverWrite
    chkCheckMaxNo.Enabled = blnCheckMaxNo
    chkNumber.Enabled = Not blnUseHisNo
    
    '���ð�ť�Ŀ�����
    '����һ����
    OptBuildcode(0).Enabled = OptCode(0).value
    OptBuildcode(1).Enabled = OptCode(0).value
    optUseAdviceID.Enabled = OptCode(0).value
    OptUnicode(0).Enabled = OptCode(1).value
    OptUnicode(1).Enabled = OptCode(1).value
    optUsePatientID.Enabled = OptCode(1).value
    
    'ǰ׺
    optPreText(0).Enabled = chkPreText.value And chkPreText.Enabled And OptBuildcode(1).value = False
    optPreText(1).Enabled = chkPreText.value And chkPreText.Enabled
    txtPreText.Enabled = (optPreText(1).value And optPreText(1).Enabled)
    
    '�ָ���
    cboDelimeter(1).Enabled = chkDelimiter(1).value And chkDelimiter(1).Enabled
    cboDelimeter(2).Enabled = chkDelimiter(2).value And chkDelimiter(2).Enabled
    
    '��
    optYear(0).Enabled = chkYear.value And chkYear.Enabled
    optYear(1).Enabled = chkYear.value And chkYear.Enabled
    
    '˳���--�̶�λ��
    chkFixedLen.Enabled = chkNumber.value And chkNumber.Enabled
    txtFixedLen.Enabled = chkFixedLen.value And chkFixedLen.Enabled
    txtStartNum.Enabled = chkNumber.value And chkNumber.Enabled
    lblStartNum.Enabled = chkNumber.value And chkNumber.Enabled
End Sub

Private Sub chkCanOverWrite_Click()
    Call ConfigAppNoState
End Sub

Private Sub chkCheckMaxNo_Click()
    Call ConfigAppNoState
End Sub



Private Sub chkDay_Click()
    Call ConfigAppNoState
End Sub

Private Sub chkDelimiter_Click(Index As Integer)
    Call ConfigAppNoState
End Sub

Private Sub chkFixedLen_Click()
    Call ConfigAppNoState
End Sub

Private Sub chkMonth_Click()
    Call ConfigAppNoState
End Sub

Private Sub chkNumber_Click()
    Call ConfigAppNoState
End Sub

Private Sub chkPDF_Click()
On Error Resume Next
    cboPDF.Enabled = chkPDF.value = 1
    If chkPDF.value = 0 Then
        cboPDF.ListIndex = 0
    End If
End Sub

Private Sub chkPreText_Click()
    Call ConfigAppNoState
End Sub

Private Sub chkPreView_Click()
    If chkPreView.value = 1 Then
        optMovePreview.Enabled = True
        optClickPreview.Enabled = True
        
        If optMovePreview.value = 1 Then
            lblDelayTime.Enabled = True
            txtDelayTime.Enabled = True
        End If
        
        If optClickPreview.value = 0 And optMovePreview.value = 0 Then
            optClickPreview.value = 1
        End If
    Else
        optMovePreview.Enabled = False
        lblDelayTime.Enabled = False
        txtDelayTime.Enabled = False
        optClickPreview.Enabled = False
    End If
End Sub

Private Sub chkSchExecFee_Click()
    On Error GoTo errHandle
    
    zlDatabase.SetPara "ԤԼʱִ�з���", chkSchExecFee.value, glngSys, 1292
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "���ԤԼ��ʾ"
    err.Clear
End Sub

Private Sub chkYear_Click()
    Call ConfigAppNoState
End Sub

Private Sub cmdSchPlanDel_Click()
    Call SchedulePlanDel
End Sub

Private Sub cmdSchPlanAdd_Click()
    Call SchedulePlanUpdate(1)
End Sub

Private Sub cmdSchPlanUpdate_Click()
    Call SchedulePlanUpdate(2)
End Sub

Private Sub cmdSchPlanCopy_Click()
    
    '���û��ԤԼ�豸����ֱ���˳�
    If vsfScheduleDevice.Rows <= 2 Or vsfScheduleDevice.RowSel < 1 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    Call frmSchPlanCopy.zlShowMe(Me)
    'ˢ��ԤԼ�����б�
    Call loadSchedulePlan(vsfScheduleDevice.TextMatrix(vsfScheduleDevice.RowSel, col_SchDevice_ID))

End Sub

Private Sub chkReservations_Click()
    On Error GoTo errHandle
    
    SetEnabled chkReservations.value = 1
    
    zlDatabase.SetPara "����ԤԼ", chkReservations.value, glngSys, 1292
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub chkWeekRest_Click(Index As Integer)
    Dim Day As VbDayOfWeek
    Dim dtDay As Date
    
    If mblnClickRestDate = False Then Exit Sub
    
    On Error GoTo errHandle
    
    dtDay = dtpRestDay.FirstVisibleDay
    
    If Index = 0 Then
        Day = vbSaturday
    ElseIf Index = 1 Then
        Day = vbSunday
    End If
    
    Do While dtDay <= dtpRestDay.LastVisibleDay
        If Weekday(dtDay) = Day Then
            If chkWeekRest(Index).value = 1 Then
                If InStr(mstrSchRestDate, Format(dtDay, "dd")) = 0 Then
                    Call AddRestDay(Format(dtDay, "dd"))
                End If
            Else
                If InStr(mstrSchRestDate, Format(dtDay, "dd")) > 0 Then
                    Call DeleteRestDay(Format(dtDay, "dd"))
                End If
            End If
        End If
        dtDay = dtDay + 1
    Loop
    
    dtpRestDay.RedrawControl
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ����_����('" & Format(dtpRestDay.FirstVisibleDay, "yyyymm") & "','" & mstrSchRestDate & "')", "����ԤԼ����")
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub cmdAddDiagnosis_Click()
'����ԤԼ��Ŀ
    Dim i As Long
    Dim strItem As String
    
    On Error GoTo errHandle
    
    If Val(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctID)) < 0 Or vsfDevice.Row <= 0 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "��ʾ"
        Exit Sub
    End If
    
'    strSql = "select �豸��,Ӱ����� from Ӱ���豸Ŀ¼ where �豸�� = [1]"
'    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ȡ�豸", vsfDevice.Cell(flexcpText, vsfDevice.Row, ctӰ�����))
    
    For i = 1 To vsfDiagnosis.Rows - 1
        If Len(vsfDiagnosis.TextMatrix(i, ctDgID)) > 0 Then
            strItem = strItem & "<" & vsfDiagnosis.TextMatrix(i, ct������ĿID) & ">"
        End If
    Next
    
    Set mobjAddDiagnosis = New frmSchAddDiagnosis
    mobjAddDiagnosis.zlShowMe strItem, CStr(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctӰ�����)), Me

    Set mobjAddDiagnosis = Nothing
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    Call RefreshDiagnosis(Val(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctID)))
    err.Clear
End Sub

Private Sub cmdAddDevice_Click()
    Dim strSql As String
    Dim rsTemp As Recordset
    Dim strDeviceNo As String
    Dim lngSchDeptID As Long
    
    On Error GoTo errHandle
    
    If Not CheckDevice Then Exit Sub
    
    strSql = "Select a.�豸��, a.Ӱ�����, b.ִ�м� From Ӱ���豸Ŀ¼ A, ҽ��ִ�з��� B " _
        & " Where a.�豸�� = b.����豸 and �豸�� = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ȡ�豸", Trim(cboImDevice.Text))
    
    If rsTemp.RecordCount > 0 Then
        strDeviceNo = rsTemp!�豸��
    Else
        MsgBox "���Ҳ���Ӱ���豸��������û�����ö�Ӧ��ִ�м䡣", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    lngSchDeptID = cboSchDept.ItemData(cboSchDept.ListIndex)
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ�豸_�༭(0,'" & Trim(txtEqDevice.Text) _
        & "','" & strDeviceNo & "'," & lngSchDeptID & ",'" & rsTemp!Ӱ����� & "','" _
        & Replace(Trim(txtNode.Text), "'", "''") & "',0,1)", "�����豸")
    
    Call RefreshDevice
    
    vsfDevice.Row = vsfDevice.Rows - 1
    vsfDevice.ShowCell vsfDevice.Rows - 1, 1
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub cmdSelect_Click()
    lstAttentions.Visible = Not lstAttentions.Visible
End Sub

Private Sub lst_ItemCheck(Index As Integer, Item As Integer)
    Dim blnValue As Boolean
    Dim strValue As String
    Dim i As Long
    Dim blNoPick As Boolean '����ѡ�û�й�ѡ

    If Not Me.Visible Then Exit Sub

    Select Case Index
    Case lst_PatholInfo
        blNoPick = True
        strValue = ""
        With lst(lst_PatholInfo)
            For i = 0 To .ListCount - 1
                If strValue <> "" Then strValue = strValue & ","
                
                If .Selected(i) Then
                    blNoPick = False
                    strValue = strValue & "1"
                Else
                    strValue = strValue & "0"
                End If
            Next
            
            '����ѡ�û�й�ѡ��ͬ�ڶ���ѡ
            If blNoPick Then
                strValue = "1,1,1,1,1,1,1,1,1,1"
            End If
        End With
        blnValue = True
    End Select
    Call SetParChange(lst, lst_PatholInfo, mrsPar, blnValue, strValue)
End Sub

Private Sub chkImageLevel_Click()
    txtImageLevel.Enabled = chkImageLevel.value = 1
End Sub

Private Sub ChkCompleteCommit_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If ChkCompleteCommit.value = 1 Then chkFinallyCompleteCommit.value = 0
End Sub

Private Sub chkFinallyCompleteCommit_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If chkFinallyCompleteCommit.value = 1 Then ChkCompleteCommit.value = 0
End Sub

Private Sub ChkLike_Click()
    TxtLike.Enabled = IIF(ChkLike.value, True, False)
End Sub

Private Sub chkNameColColorCfg_Click()
    If chkNameColColorCfg.value = 1 Then
        chkOrdinaryNameColColorCfg.Enabled = True
    Else
        chkOrdinaryNameColColorCfg.value = 0
        chkOrdinaryNameColColorCfg.Enabled = False
    End If
End Sub

Private Sub chkPetitionCapture_Click()
    cboSaveDevice.Enabled = IIF(chkPetitionCapture.value, True, False)
End Sub

Private Sub chkRefreshInterval_Click()
    txtRefreshInterval.Enabled = IIF(chkRefreshInterval.value, True, False)
End Sub

Private Sub chkReportAfterResult_Click()
    If chkReportAfterResult.value = vbChecked Then
        chkIgnorePosi.Enabled = False
        chkIgnorePosi.value = vbUnchecked
    Else
        chkIgnorePosi.Enabled = True
    End If
End Sub

Private Sub chkReportLevel_Click()
    txtReportLevel.Enabled = chkReportLevel.value = 1
End Sub


Private Sub chkSpecialContent_Click()
    If chkSpecialContent.value = 1 Then
        cboSpecialContent.Enabled = True
    Else
        cboSpecialContent.Enabled = False
    End If
End Sub

Private Sub chkUseQueue_Click()
On Error GoTo errHandle
    optNumberRule(0).Enabled = chkUseQueue.value
    optNumberRule(1).Enabled = chkUseQueue.value
        
    chkSynStudyList.Enabled = chkUseQueue.value
    
    txtValidDays.Enabled = chkUseQueue.value
    txtQueueReport.Enabled = chkUseQueue.value
    cbxPrintQueueNoWay.Enabled = chkUseQueue.value
    chkAutoInQueue.Enabled = chkUseQueue.value
    chkUseSchNumInQueue.Enabled = chkUseQueue.value
    chkUseQueueMsg.Enabled = chkUseQueue.value
    
    lab(7).Enabled = chkUseQueue.value
    lab(8).Enabled = chkUseQueue.value
    lab(9).Enabled = chkUseQueue.value
    fra(18).Enabled = chkUseQueue.value
    
    'framGroup.Enabled = chkUseQueue.value
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cmbDept_Click()
    mlng����ID = cmbDept.ItemData(cmbDept.ListIndex)
    
    'If stabWorkFlow.Tabs = IIF(InStr(GetPrivFunc(glngSys, 1160), "����") > 0, 6, 5) Then '�ж�tab������Ŀ����Ϊ��ȷ����װ����tab֮��Ŵ������е����
        
        Call Load���Ҳ���
        
    'End If
End Sub

Private Sub cmdAdd_Click()
    Me.lab(4).Tag = "": Me.txtName.Text = "": Me.txtName.Enabled = True
    Me.cmdDel.Enabled = True: Me.cmdSave.Enabled = True: Me.cmdRestore.Enabled = True: cboDevice.Enabled = True: If cboDevice.ListCount > 0 Then cboDevice.ListIndex = 0
    Me.txtName.SetFocus
End Sub

Private Sub cmdAddGroup_Click()
'����������Ϣ
On Error GoTo errHandle
    Dim lngGroupId As Long
    Dim strGroupName As String
    Dim strPrefix As String
    Dim objFrmAdd As frmTechnicGroup
    Dim lngRow As Long
    
    '���÷�����Ӵ���
    Set objFrmAdd = New frmTechnicGroup
    If objFrmAdd.ShowGroupCfg(Me, mlng����ID, lngGroupId, strGroupName, strPrefix) Then
        lngRow = ufgGroupCfg.NewRow
    
        ufgGroupCfg.Text(lngRow, "ID") = lngGroupId
        ufgGroupCfg.Text(lngRow, "����") = strGroupName
        ufgGroupCfg.Text(lngRow, "����ǰ׺") = strPrefix
        
        '�������ִ�м�
        Call subLoadTechniRoom(lngGroupId)
    End If
    
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cmdApply_Click()
    '�������ܴ���
    If ValidateData() = False Then Exit Sub
    
    Call Save���Ҳ���
    
    If SavePar(mrsPar, Me) = False Then Exit Sub
End Sub

Private Sub cmdColor_Click(Index As Integer)
    dlgColor.Color = shpColor(Index).FillColor
    dlgColor.ShowColor
    shpColor(Index).FillColor = dlgColor.Color
End Sub

Private Sub cmdDefault_Click()
    Call subLoadListDefColorConfig
End Sub

Private Sub cmdDel_Click()
    Dim strSql As String
    
    If MsgBox("���ɾ��ִ�м䡰" & Trim(Me.txtName.Text) & "����", vbQuestion + vbYesNo + vbDefaultButton2, gstrSysName) = vbNo Then Exit Sub
        
    err = 0: On Error GoTo ErrHand
    
        strSql = "zl_ҽ��ִ�з���_Delete(" & Val(mlng����ID) & ",'" & Trim(Me.txtName.Text) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        Call subLoadRoomConfig
    Exit Sub
ErrHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdDelGroup_Click()
On Error GoTo errHandle
    Dim strSql As String
    Dim lngGroupId As Long
    Dim lngMsgResult As Long
    
    If Not ufgGroupCfg.IsSelectionRow Then
        MsgBox "��ѡ����Ҫɾ���ķ������ݡ�", vbOKOnly, "��ʾ"
        Exit Sub
    End If
    
    lngMsgResult = MsgBox("�Ƿ�ȷ��ɾ���÷�������? ɾ������齫���ɻָ���", vbYesNo, "��ʾ")
    If lngMsgResult = vbNo Then Exit Sub
    
    
    lngGroupId = ufgGroupCfg.KeyValue(ufgGroupCfg.SelectionRow)
    
    strSql = "zl_Ӱ��ִ�з���_Del(" & lngGroupId & ")"
    Call zlDatabase.ExecuteProcedure(strSql, "ɾ��ִ�з���")
    
    Call ufgRoomCfg.ClearListData
    Call ufgGroupCfg.DelCurRow(False)
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cmdHelp_Click()
     ShowHelp App.ProductName, Me.hwnd, Me.Name, Int((glngSys) / 100)
End Sub

Private Sub cmdModify_Click()
'�޸ķ�����Ϣ
On Error GoTo errHandle
    Dim lngGroupId As Long
    Dim strGroupName As String
    Dim strPrefix As String
    Dim objFrmUpdate As frmTechnicGroup
    
    If Not ufgGroupCfg.IsSelectionRow Then
        MsgBox "��ѡ����Ҫ�޸ĵķ������ݡ�", vbOKOnly, "��ʾ"
        Exit Sub
    End If
    
    lngGroupId = ufgGroupCfg.KeyValue(ufgGroupCfg.SelectionRow)
    strGroupName = ufgGroupCfg.Text(ufgGroupCfg.SelectionRow, "����")
    strPrefix = ufgGroupCfg.Text(ufgGroupCfg.SelectionRow, "����ǰ׺")
    
    '���÷�����´���
    Set objFrmUpdate = New frmTechnicGroup
    If objFrmUpdate.ShowGroupCfg(Me, mlng����ID, lngGroupId, strGroupName, strPrefix) Then
        ufgGroupCfg.CurText("����") = strGroupName
        ufgGroupCfg.CurText("����ǰ׺") = strPrefix
        
        Call subLoadTechniRoom(lngGroupId)
    End If
    
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cmdRestore_Click()
    Call subLoadRoomConfig
End Sub

Private Sub cmdSave_Click()
    Dim blnExist As Boolean, i As Integer
    Dim strSql As String

    If Trim(Me.txtName.Text) = "" Then
        MsgBox "���Ʊ�������", vbExclamation, gstrSysName
        Me.txtName.SetFocus
        Exit Sub
    End If
    If LenB(StrConv(Trim(Me.txtName.Text), vbFromUnicode)) > Me.txtName.MaxLength Then
        MsgBox "���Ƴ���" & Me.txtName.MaxLength & "�ĳ�������", vbExclamation, gstrSysName
        Me.txtName.SetFocus
        Exit Sub
    End If
    
    For i = 1 To lvwRoom.ListItems.Count
        If txtName.Text = lvwRoom.ListItems(i).Text Then blnExist = True: Exit For '�Ѿ�����
    Next
    '-----------------------------------------
    err = 0: On Error GoTo ErrHand
    If Me.lab(4).Tag = "" And Not blnExist Then
        strSql = "zl_ҽ��ִ�з���_Insert(" & Val(mlng����ID) & ",'" & Trim(Me.txtName.Text) & "','" & zlStr.NeedCode(cboDevice.Text) & "','" & txtNoPrefix.Text & "')"
    Else
        strSql = "zl_ҽ��ִ�з���_Update(" & Val(mlng����ID) & ",'" & Trim(Me.lab(4).Tag) & "','" & Trim(Me.txtName.Text) & "','" & zlStr.NeedCode(cboDevice.Text) & "','" & txtNoPrefix.Text & "')"
    End If
    
    err = 0: On Error GoTo ErrHand
    
    zlDatabase.ExecuteProcedure strSql, Me.Caption
    MsgBox "ִ�м䱣��ɹ���", vbInformation, gstrSysName
    
    Call subLoadRoomConfig
    
    txtName.SetFocus
    
    Exit Sub
ErrHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdStudyAcc_Click()
'Ӱ������Ŀ��������
On Error GoTo errHandle
    Dim lngGroupId As Long
    Dim objStudyAssocia As frmTechnicStudy
    
    If Not ufgGroupCfg.IsSelectionRow Then
        MsgBox "��ѡ����Ҫ���й����ķ������ݡ�", vbOKOnly, "��ʾ"
        Exit Sub
    End If
    
    lngGroupId = ufgGroupCfg.KeyValue(ufgGroupCfg.SelectionRow)
    
    Set objStudyAssocia = New frmTechnicStudy
    If objStudyAssocia.ShowStudyAssociation(mlng����ID, lngGroupId, Me) Then
        Call ufgStudyProCfg.ClearListData
        Call subLoadStudyProAssociation(lngGroupId)
    End If
    
Exit Sub
errHandle:
If ErrCenter() = 1 Then Resume
End Sub

Private Sub cmdTestCon_Click()
On Error GoTo errHandle
    Call XWTestDBConnection(txt(6).Text, txt(7).Text, txt(8).Text)
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub


Private Sub XWTestDBConnection(ByVal strServerName As String, ByVal strUser As String, ByVal strPwd As String)
'���ܣ� ��������SQLServer���ݿ�����
'������
'���أ��ɹ����ؿ��ַ�
'--------------------------------------------
    Dim cnTest As New ADODB.Connection

    If strServerName = "" Then
        MsgBox "δ�ҵ����ݿ������������Ϣ�������á�"
        Exit Sub
    End If
    
    On Error Resume Next
    err = 0
    
    If cnTest.State = adStateOpen Then cnTest.Close
    
    Set cnTest = OraDataOpen(strServerName, strUser, strPwd)
    
    If err <> 0 Or cnTest Is Nothing Then
        '���ݿ����Ӵ���
        MsgBox "���ݿ�����ʧ�ܡ�" & vbCrLf & vbCrLf & "��������ǣ�" & err.Number & "�����������ǣ� " & err.Description
        Exit Sub
    End If
    
    MsgBox "���ݿ����ӳɹ���"
    Exit Sub
err:
    If ErrCenter() = 1 Then
        Resume
    End If
End Sub


Private Function OraDataOpen(ByVal strServerName As String, ByVal strUserName As String, ByVal strUserPwd As String) As ADODB.Connection
    '------------------------------------------------
    '���ܣ� ��ָ�������ݿ�
    '������
    '   strServerName�������ַ���
    '   strUserName���û���
    '   strUserPwd������
    '���أ� ���ݿ�򿪳ɹ�������true��ʧ�ܣ�����false
    '------------------------------------------------
    Dim strError As String
    Dim cnOra As New ADODB.Connection
    
    On Error Resume Next
    err = 0
    
    DoEvents
    
    With cnOra
        If .State = adStateOpen Then .Close
        
        .Provider = "MSDataShape"
        .Open "Driver={Microsoft ODBC for Oracle};Server=" & strServerName, strUserName, strUserPwd
        
        If err <> 0 Then
            '���������Ϣ
            strError = err.Description
            If InStr(strError, "�Զ�������") > 0 Then
                MsgBox "���Ӵ��޷��������������ݷ��ʲ����Ƿ�������װ��", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-12154") > 0 Then
                MsgBox "�޷���������������" & vbCrLf & "������Oracle�������Ƿ���ڸñ�������������������ַ�������", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-12541") > 0 Then
                MsgBox "�޷����ӣ�����������ϵ�Oracle�����������Ƿ�������", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-01033") > 0 Then
                MsgBox "ORACLE���ڳ�ʼ�����ڹرգ����Ժ����ԡ�", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-01034") > 0 Then
                MsgBox "ORACLE�����ã������������ݿ�ʵ���Ƿ�������", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-02391") > 0 Then
                MsgBox "�û�" & UCase(strUserName) & "�Ѿ���¼���������ظ���¼(�Ѵﵽϵͳ�����������¼��)��", vbExclamation, gstrSysName
            ElseIf InStr(strError, "ORA-01017") > 0 Then
                MsgBox "�����û�������������ָ�������޷���¼��", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-28000") > 0 Then
                MsgBox "�����û��Ѿ������ã��޷���¼��", vbInformation, gstrSysName
            Else
                MsgBox strError, vbInformation, gstrSysName
            End If
            
            'OraDataOpen = Nothing
            Exit Function
        End If
    End With
    
    err = 0
    On Error GoTo ErrHand
    
    Set OraDataOpen = cnOra
    
    Exit Function
    
ErrHand:
    If ErrCenter() = 1 Then Resume
    OraDataOpen = False
    err = 0
End Function

Private Sub Form_Activate()
    If Me.Tag = "��ʼ�ɹ�" Then
        Call scbFunc_SelectedChanged(scbFunc.Selected)
        Me.Tag = ""
    End If
End Sub

Private Sub Form_Load()
    Dim strCategory As String
    Dim blnQuery As Boolean
    
    mblnOk = False
    mlng����ID = 0
    mlngCur����ID = 0
    mstrCur���� = ""
    mstrCanUse���� = ""

    Call GetUserInfo
    
    mstrPrivs = gstrPrivs
    
    strCategory = "��������" ',��������
    
    'ͼ����,TaskPanelItem��ID(ͬʱҲ�ǲ�������Picture�ؼ������),TaskPanelItem�ı���;......
    marrFunc(0) = ""
    marrFunc(0) = marrFunc(0) & "102,0,Ӱ����������"
    marrFunc(0) = marrFunc(0) & ";101,1,Ӱ��ҽ������"
    marrFunc(0) = marrFunc(0) & ";103,2,Ӱ��ɼ�����"
    marrFunc(0) = marrFunc(0) & ";100,3,Ӱ��������"
    marrFunc(0) = marrFunc(0) & ";105,4,����鵵����"
    marrFunc(0) = marrFunc(0) & ";106,5,����軹����"
    marrFunc(0) = marrFunc(0) & ";107,6,���ԤԼ����"
    
    'marrFunc(1) = "102,2,����ҩ������"

    '1.��ʼ���������һ�������б�,ȱʡѡ�е�һ��
    Call InitSCBItem(scbFunc, strCategory, picTPL.hwnd)
    Call scbFunc.Icons.AddIcons(imgType.Icons)
      
    '2.��ʼ���������Ķ��������б�,ȱʡѡ�е�һ��
    Call InitTPLItem(sccFunc, tplFunc, scbFunc.Selected.Caption, marrFunc(0))
    Call tplFunc.Icons.AddIcons(imgFunc.Icons)
    
    '�ж��Ƿ�߱��Ŷӽк�Ȩ��
    If (InStr(GetPrivFunc(glngSys, 1160), "����") <= 0) Then
        stabWorkFlow.TabVisible(3) = False
    End If
    
    blnQuery = GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "��ѯ����", "1") <> "1001"
    chkRefreshInterval.Visible = Not blnQuery
    txtRefreshInterval.Visible = Not blnQuery
    If blnQuery Then
        stabWorkFlow.TabVisible(5) = False
        lab(0).Visible = False
        TxtĬ������.Visible = False
        Frame1.Visible = False
    End If
    
    
    Call InitData
    Call ShowErrParasMsg(Me, mrsPar)
    Me.Tag = "��ʼ�ɹ�"
    
    Call HookDefend(txt(1).hwnd)
    Call HookDefend(txt(3).hwnd)
    Call HookDefend(txt(5).hwnd)
    Call HookDefend(txt(8).hwnd)
End Sub


Private Sub lstAttentions_Click()
    On Error GoTo errHandle
    
    txtAttention.Text = lstAttentions.List(lstAttentions.ListIndex)
    
    lstAttentions.Visible = False
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "���ԤԼ��ʾ"
    err.Clear
End Sub

Private Sub lvwRoom_ItemClick(ByVal Item As MSComctlLib.ListItem)
    Me.txtName.Text = Item.Text
    Me.lab(4).Tag = Me.txtName.Text
    Me.txtNoPrefix.Text = Item.SubItems(2)
        
    SeekIndex cboDevice, Item.SubItems(1), True, , tNeedNo
End Sub

Private Sub OptBuildcode_Click(Index As Integer)
    Call ConfigAppNoState
End Sub

Private Sub OptCode_Click(Index As Integer)
    Call ConfigAppNoState
End Sub

Private Sub optMovePreview_Click()
    If optMovePreview.value = True Then
        txtDelayTime.Enabled = True
        lblDelayTime.Enabled = True
    End If
End Sub

Private Sub optPreText_Click(Index As Integer)
    Call ConfigAppNoState
End Sub

Private Sub optReportEditor_Click(Index As Integer)

On Error GoTo errHandle

    fra(24).Visible = Index = 2
    
    Exit Sub
errHandle:
    
End Sub

Private Sub OptUnicode_Click(Index As Integer)
    Call ConfigAppNoState
End Sub

Private Sub optUseAdviceID_Click()
    Call ConfigAppNoState
End Sub

Private Sub optUsePatientID_Click()
    Call ConfigAppNoState
End Sub

Private Sub SchTimeTable_OnMenuTimeProjectAdd()
    '����ʱ��ƻ�
    Dim lngPlanID As Long
    
    If vsfSchedulePlan.Rows <= 2 Then
        Exit Sub
    End If
    
    lngPlanID = vsfSchedulePlan.TextMatrix(vsfSchedulePlan.RowSel, col_SchPlan_ID)
    Call frmSchPlanTime.zlShowMe(Me, 0, lngPlanID)
    
End Sub

Private Sub SchTimeTable_OnMenuTimeProjectDel()
    'ɾ��ʱ��ƻ�
    Dim lngPlanID As Long
    Dim strSql As String
    
    If vsfSchedulePlan.Rows <= 2 Then
        Exit Sub
    End If
    On Error GoTo errH
    lngPlanID = vsfSchedulePlan.TextMatrix(vsfSchedulePlan.RowSel, col_SchPlan_ID)
    strSql = "Zl_Ӱ��ԤԼʱ��ƻ�_ɾ��(" & lngPlanID & ")"
    zlDatabase.ExecuteProcedure strSql, "ɾ��ʱ��ƻ�"
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub SchTimeTable_OnMenuTimeProjectModify(ByVal lngTimeProjectID As Long)
    '�޸�ʱ��ƻ�
    Dim lngPlanID As Long
    
    If vsfSchedulePlan.Rows <= 2 Then
        Exit Sub
    End If
    
    lngPlanID = vsfSchedulePlan.TextMatrix(vsfSchedulePlan.RowSel, col_SchPlan_ID)
    Call frmSchPlanTime.zlShowMe(Me, lngTimeProjectID, lngPlanID)
End Sub

Private Sub SchTimeTable_OnMenuTimeProjectSetColor()
    frmSchSetTimeTableColoe.Show 1, Me
End Sub

Private Sub sstSchSetup_Click(PreviousTab As Integer)
    '����л�����ԤԼ��������ҳ�棬������ˢ�����ҳ�������
    If PreviousTab <> sstSchSetup.Tab And sstSchSetup.Tab = 2 Then
        Call loadScheduleDevice
    End If
End Sub

Private Sub tplFunc_ItemClick(ByVal Item As XtremeSuiteControls.ITaskPanelGroupItem)
    Dim i As Long
    
    For i = 0 To picPar.UBound
        picPar(i).Visible = (i = Item.ID)
    Next
    
    'PACS���������в����ڰ����Ҳ�ѯ
    'lblLocate(txt_Dept).Visible = (Item.ID = GetFuncID("ҵ�����̿���", marrFunc))
    'txtLocate(txt_Dept).Visible = lblLocate(txt_Dept).Visible
    
    If txtLocate(txt_Dept).Visible Then
        lblPrompt.Left = txtLocate(txt_Dept).Left + txtLocate(txt_Dept).Width + 60
    Else
        lblPrompt.Left = txtLocate(txt_Par).Left + txtLocate(txt_Par).Width + 60
    End If
    
    lblPrompt.Width = cmdOK.Left - lblPrompt.Left - 120
    
    
    tplFunc.Tag = Item.ID   '���ڻ�ȡ��ǰѡ�е�TaskPanelItem
End Sub

Private Sub Form_Resize()
    Dim objPic As PictureBox
    
    On Error Resume Next
    
    If Me.WindowState = vbMinimized Then Exit Sub
    
    If picVbar.Left < 1500 Then picVbar.Left = 1500
    If picVbar.Left > Me.ScaleWidth - 3000 Then picVbar.Left = Me.ScaleWidth - 3000
    picVbar.Top = 0
    
    picFunc.Width = picVbar.Left + picVbar.Width
    
    For Each objPic In picPar
        objPic.Top = 0
        objPic.Left = 0
        objPic.Width = Me.ScaleWidth - objPic.Left
        objPic.Height = Me.ScaleHeight - PicBottom.ScaleHeight
    Next
    
    lstAttentions.Move txtAttention.Left, txtAttention.Top - lstAttentions.Height - 10
End Sub


Private Sub scbFunc_ExpandButtonDown(CancelMenu As Boolean)
    CancelMenu = True
End Sub

Private Sub picBottom_Resize()
    cmdApply.Left = PicBottom.ScaleWidth - cmdApply.Width - 120
    cmdCancel.Left = cmdApply.Left - cmdCancel.Width - 120
    cmdOK.Left = cmdCancel.Left - cmdOK.Width - 120
End Sub


Private Sub picFunc_Resize()
    scbFunc.Top = picFunc.ScaleTop
    scbFunc.Left = picFunc.ScaleLeft + 45
    scbFunc.Width = picFunc.ScaleWidth - picVbar.Width - 45
    scbFunc.Height = picFunc.ScaleHeight
    
    picVbar.Height = picFunc.ScaleHeight
End Sub

Private Sub picTPL_Resize()
    sccFunc.Left = picTPL.ScaleLeft
    sccFunc.Width = picTPL.ScaleWidth
    
    tplFunc.Left = picTPL.ScaleLeft
    tplFunc.Top = sccFunc.Top + sccFunc.Height
    tplFunc.Height = picTPL.ScaleHeight - sccFunc.Height
    tplFunc.Width = picTPL.ScaleWidth
End Sub


Private Sub picVbar_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If Button = 1 Then
        picVbar.Left = IIF(picVbar.Left + X < 2000, 2000, picVbar.Left + X)
        Call Form_Resize
    End If
End Sub

Private Sub scbFunc_SelectedChanged(ByVal Item As XtremeSuiteControls.IShortcutBarItem)
    If Me.Visible Then
        Call InitTPLItem(sccFunc, tplFunc, Item.Caption, marrFunc(Item.ID - 1)) 'ID�Ǵ�1��ʼ�ģ���ΪͬʱΪͼ����ţ�,�����Ǵ�0��ʼ
        Call tplFunc_ItemClick(tplFunc.Groups(1).Items(1))
    End If
End Sub


Public Sub LocateFuncItem(ByVal lngFunc As Long)
'���ܣ�����IDѡ��һ���Ͷ�������
    Dim i As Long, j As Long, lngID As Long
    Dim arrTmp As Variant
    Dim n As Long
    
    For i = 0 To UBound(marrFunc)
        arrTmp = Split(marrFunc(i), ";")
        For j = 0 To UBound(arrTmp)
            lngID = Split(arrTmp(j), ",")(1)
            If lngFunc = lngID Then
                tplFunc.Tag = lngID
                Set scbFunc.Selected = scbFunc(i)
                
                For n = 1 To tplFunc.Groups(1).Items.Count
                    tplFunc.Groups(1).Items(n).Selected = tplFunc.Groups(1).Items(n).ID = lngID
                Next
            End If
        Next
    Next
End Sub


Private Sub Form_Unload(Cancel As Integer)
    If Not mblnOk Then
        mrsPar.Filter = "(�޸�״̬=1 ANd ErrType =Null) OR  (�޸�״̬=1 And ErrType=" & PET_ֵ���� & ")"
        If mrsPar.RecordCount > 0 Then
            If MsgBox("�����޸Ĳ��ֲ����������������˳��Ļ������е��޸Ķ�������Ч��" & vbCrLf & "�Ƿ�ȷ���˳���", vbQuestion Or vbYesNo Or vbDefaultButton2, gstrSysName) = vbNo Then
                Cancel = 1: Exit Sub
            End If
        End If
    End If
    Set mrsPar = Nothing
End Sub

Private Sub InitData()
'���ܣ���ʼ������ؼ�,��ȡ����������
    
    '1.��ʼ������
    
    Call InitSystemPara
    
    
    '2.��ʼ������ؼ�
    Call InitEnv
    
    
    '3.����ϵͳ����
    Call LoadPar
    
    
    '���빤�����̲���
'    Call Load���Ҳ���
End Sub

Private Sub LoadPar()
'���ܣ���ȡ�����ز���������ؼ�
    Dim strValue As String, strTmp As String
    Dim i As Long
    Dim rsTmp As ADODB.Recordset
    Dim arrObj As Variant  '�������ģ��1,������1,�ؼ�����1,ģ��2,������2,�ؼ�����2,......
    

    Set rsTmp = GetPar(mrsPar, pӰ���Ƭ���� & _
                            "," & pӰ��ҽ������ & _
                            "," & pӰ��ɼ����� & _
                            "," & pӰ�������� & _
                            "," & p����鵵���� & _
                            "," & p����軹����)

     '1.����CheckBox�����
    strTmp = pӰ��ҽ������ & ":¼����Ժ��Ϣ:" & chk_¼����Ժ��������Ϣ & _
            "," & pӰ��ҽ������ & ":��첡�����ʱ���жϷ���:" & chk_��첡�����ʱ���жϽɷ����1290 & _
            "," & pӰ��ɼ����� & ":¼����Ժ��Ϣ:" & chk_¼����Ժ���������Ϣ & _
            "," & pӰ��ɼ����� & ":��첡�����ʱ���жϷ���:" & chk_��첡�����ʱ���жϽɷ����1291 & _
            "," & pӰ�������� & ":������������:" & chk_���没������������ & _
            "," & pӰ�������� & ":������������:" & chk_������������������ & _
            "," & pӰ�������� & ":ϸ����������:" & chk_ϸ���������������� & _
            "," & pӰ�������� & ":������������:" & chk_���ﲡ������������ & _
            "," & pӰ�������� & ":ʬ����������:" & chk_ʬ�첡������������ & _
            "," & pӰ�������� & ":����ʯ����������:" & chk_��Ƭ�������������� & _
            "," & pӰ�������� & ":¼����Ժ��Ϣ:" & chk_¼����Ժ��Ϣ & _
            "," & p����軹���� & ":����ȷ�Ϻ��Զ���ӡ��ִ:" & chk_���ĺ��Զ���ӡ��ִ��

    Call SetParToControl(strTmp, mrsPar, chk)
    
    
    rsTmp.Filter = "ģ��=" & pӰ�������� & " and ������='¼����Ժ��Ϣ'"
    If rsTmp.RecordCount > 0 Then
        If Val(NVL(rsTmp!����ֵ)) = 1 Then
            txt(txt_������Ժ����).Enabled = True
        Else
            txt(txt_������Ժ����).Enabled = False
        End If
    End If
    

    '2.����ComboBox�����
    strTmp = pӰ���Ƭ���� & ":XW3D��Ƭ����:" & cbo_3D��Ƭ���� & _
            "," & p����鵵���� & ":������ǩ��������:" & cbo_������ǩ�������� & _
            "," & p����軹���� & ":���Ļ�ִ��������:" & cbo_���Ļ�ִ��������
    Call SetParToControl(strTmp, mrsPar, cbo, 3)
    
    strTmp = pӰ��ɼ����� & ":�ɼ�����ִ��ģʽ:" & cbo_�ɼ�����ִ��ģʽ
    Call SetParToControl(strTmp, mrsPar, cbo)
    
    strTmp = pӰ��ҽ������ & ":ҽ������ִ��ģʽ:" & cbo_ҽ������ִ��ģʽ
    Call SetParToControl(strTmp, mrsPar, cbo)
    
    strTmp = pӰ�������� & ":�������ִ��ģʽ:" & cbo_�������ִ��ģʽ
    Call SetParToControl(strTmp, mrsPar, cbo)
    
    
    
'
'    '3.����UpDown�����
'    strTmp = "0:5:" & ud_��¼ҽ��ʶ����
'    Call SetParToControl(strTmp, mrsPar, ud)     'mrsPar�洢�Ŀؼ�����txtUD
'
    '4.����TextBox�����
'
    '"," & pӰ���Ƭ���� & ":13:" & txt_����Ŀ¼ & _'
    
    strTmp = pӰ���Ƭ���� & ":XWɾ��ͼ���û���:" & txt_ͼ��ɾ���û����� & _
            "," & pӰ���Ƭ���� & ":XWɾ��ͼ������:" & txt_ͼ��ɾ���û����� & _
            "," & pӰ���Ƭ���� & ":XW����ͼ���û���:" & txt_ͼ�����û����� & _
            "," & pӰ���Ƭ���� & ":XW����ͼ������:" & txt_ͼ�����û����� & _
            "," & pӰ���Ƭ���� & ":XW���̿�¼�û���:" & txt_ͼ���¼�û����� & _
            "," & pӰ���Ƭ���� & ":XW���̿�¼����:" & txt_ͼ���¼�û����� & _
            "," & pӰ���Ƭ���� & ":XW���ݿ������IP:" & txt_������IP & _
            "," & pӰ���Ƭ���� & ":XW���ݿ�������û���:" & txt_�������û����� & _
            "," & pӰ���Ƭ���� & ":XW���ݿ����������:" & txt_�������û����� & _
            "," & pӰ���Ƭ���� & ":XWWEB��Ƭ��ַ:" & txt_WEB��Ƭ��ַ & _
            "," & pӰ���Ƭ���� & ":XW�ؼ�ͼ���ַ:" & txt_�ؼ�ͼ���ַ & _
            "," & pӰ���Ƭ���� & ":XWOracleӵ����:" & txt_��ӵ���� & _
            "," & pӰ���Ƭ���� & ":XW��鷽����:" & txt_��鷽���� & _
            "," & pӰ���Ƭ���� & ":XW���з�����:" & txt_���з����� & _
            "," & pӰ�������� & ":�޼�����ģ��:" & txt_�޼�����ģ�� & _
            "," & pӰ�������� & ":���汨��ģ��:" & txt_��������ģ�� & _
            "," & pӰ�������� & ":���߱���ģ��:" & txt_��������ģ�� & _
            "," & pӰ�������� & ":��Ⱦ����ģ��:" & txt_��Ⱦ����ģ�� & _
            "," & pӰ�������� & ":���ӱ���ģ��:" & txt_��������ģ�� & _
            "," & pӰ�������� & ":��Ժ��λ�ṹ����:" & txt_������Ժ���� & _
            "," & p����鵵���� & ":����Ĭ�ϲ�ѯ����:" & txt_����Ĭ�ϲ�ѯ���� & _
            "," & p����軹���� & ":����Ĭ�ϲ�ѯ����:" & txt_�軹Ĭ�ϲ�ѯ���� & _
            "," & pӰ��ҽ������ & ":�����ӡ��������:" & txt_��ӡ��������
            

    Call SetParToControl(strTmp, mrsPar, txt)
    
    '����ʵ��
    rsTmp.Filter = "������='������ǩ��������'"
    If rsTmp.RecordCount > 0 Then
        cbo(2).Text = "" & NVL(rsTmp!����ֵ)
        Call SetParRelation(cbo, cbo_������ǩ��������, mrsPar, CStr(NVL(rsTmp!������)), p����鵵����)
    End If

    rsTmp.Filter = "������='���Ļ�ִ��������'"
    If rsTmp.RecordCount > 0 Then
        cbo(3).Text = "" & NVL(rsTmp!����ֵ)
        Call SetParRelation(cbo, cbo_���Ļ�ִ��������, mrsPar, CStr(NVL(rsTmp!������)), p����軹����)
    End If

    rsTmp.Filter = "������='��Ժ��λ�ṹ����'"
    If rsTmp.RecordCount > 0 Then
        txt(txt_������Ժ����).Text = "" & NVL(rsTmp!����ֵ)
        Call SetParRelation(txt, txt_������Ժ����, mrsPar, CStr(NVL(rsTmp!������)), pӰ��������)
    End If

    
    rsTmp.Filter = "������='ȡ����������'"
    If rsTmp.RecordCount > 0 Then
        strValue = "" & rsTmp!����ֵ
        With lst(lst_PatholInfo)
            For i = 0 To .ListCount - 1
                If Val(Split(strValue, ",")(i)) = 1 Then
                    .Selected(i) = True
                End If
            Next
        End With
        Call SetParRelation(lst, lst_PatholInfo, mrsPar, CStr(NVL(rsTmp!������)), pӰ��������)
    End If
    
    
            
            
        
    '�������ܴ���
    txt(1).Text = GetDecryptionPassW(txt(1).Text)
    txt(3).Text = GetDecryptionPassW(txt(3).Text)
    txt(5).Text = GetDecryptionPassW(txt(5).Text)
    txt(8).Text = GetDecryptionPassW(txt(8).Text)
'    rsTmp.Filter = "����=2"
'    While Not rsTmp.EOF
'
'        strValue = "" & rsTmp!����ֵ
'        Select Case rsTmp!������
'            Case "������ǩ��������"
'                cbo(2).Text = strValue
'                'Call SetParRelation(cbo, cbo_������ǩ��������, mrsPar)
'            Case "���Ļ�ִ��������"
'                cbo(3).Text = strValue
'                'Call SetParRelation(cbo, cbo_���Ļ�ִ��������, mrsPar)
'        End Select
'
'        rsTmp.MoveNext
'    Wend
'
'
    '5.����ListBox�����
'    strTmp = pסԺҽ���´� & ":4:" & lst_סԺ�����Ժ���
'    Call SetParToControl(strTmp, mrsPar, lst)
'
'    '6.����OptionButton�����
'    arrObj = Array(p����ҽ���´�, 45, opt����Ŀ������, _
'                    pסԺҽ���´�, 51, opt����Ŀ��סԺ)
'    Call SetParToControl("", mrsPar, arrObj)
'
'
'    '7.����ϵͳ����
'    rsTmp.Filter = "ģ��=0"
'    Do Until rsTmp.EOF
'        strValue = "" & rsTmp!����ֵ
'        Select Case rsTmp!������
'        Case 70
'            ud(ud_�����Ǽ���Ч����).value = IIF(Val(strValue) = 0, 1, Val(strValue))
'
'            Call zlDatabase.zlInsertCurrRowData(rsTmp, mrsPar, "") '����CheckBox�ؼ���������Ҫ�ٲ���һ����¼
'            Call SetParRelation(txtUD, ud_�����Ǽ���Ч����, mrsPar)
'
'        Case 233
'            Call Load��д��������(strValue)
'            Call SetParRelation(vsUnWriteDept, 0, mrsPar, rsTmp!������)
'        End Select
'
'        rsTmp.MoveNext
'    Loop
'
'    '8.����ģ���������
'    rsTmp.Filter = "ģ��=" & p����ҽ���´�
'    Do Until rsTmp.EOF
'        strValue = "" & rsTmp!����ֵ
'        Select Case rsTmp!������
'
'        End Select
'        rsTmp.MoveNext
'    Loop
'
End Sub

Private Sub InitEnv()
''���ܣ���ʼ������ؼ������ػ�������
On Error GoTo errHandle
    
    Call subInitTechincRoom
    
    Call LoadCheckNoDelimeter   '����Ҫ����subInitDepartInfoǰ�棬ȷ���ȳ�ʼ���ָ������ݣ��ٴ����ݿ��ȡ����
    
    Call subInitDepartInfo
    Call LoadPathol
    
    Call InitScheduleDevice
    Call initSchedulePlan   '��ʼ��ԤԼ��������ҳ��
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdOK_Click()
    '�������ܴ���
    If ValidateData() = False Then Exit Sub
    
    Call Save���Ҳ���
    
    If SavePar(mrsPar, Me) = False Then Exit Sub
    mblnOk = True
    Unload Me
End Sub

Private Function ValidateData() As Boolean
'���ܣ���֤���ݵ���Ч��
    Dim intTxtLen As Integer
    Dim strLen As String
    Dim i As Integer
    
    If chkPDF.value = 1 Then
        If cboPDF.Text = "" Then
            MsgBox "���ñ���PDFת�������ѡ��һ���豸��", vbOKOnly, "��ʾ��Ϣ"
            cboPDF.SetFocus
            Exit Function
        End If
    End If
    
    If txtImageLevel.Enabled Then
        '������״̬�µ� �����滻��Ӣ��״̬
        txtImageLevel.Text = Replace(txtImageLevel.Text, "��", ",")
        
        intTxtLen = Len(txtImageLevel.Text) - Len(Replace(txtImageLevel.Text, ",", ""))
        
        If intTxtLen > 3 Or intTxtLen < 1 Then
            MsgBox "Ӱ��ȼ�����Ϊ2�֣����Ϊ4�֣���������д��", vbOKOnly, "��ʾ��Ϣ"
            txtImageLevel.Text = NVL(GetDeptPara(mlng����ID, "Ӱ�������ȼ�", "��,��"))
            txtImageLevel.SetFocus
            Exit Function
        End If
    End If
    
    
    If txtReportLevel.Enabled Then
        '������״̬�µ� �����滻��Ӣ��״̬
        txtReportLevel.Text = Replace(txtReportLevel.Text, "��", ",")
        
        intTxtLen = Len(txtReportLevel.Text) - Len(Replace(txtReportLevel.Text, ",", ""))
        
        If intTxtLen > 3 Or intTxtLen < 1 Then
            MsgBox "����ȼ�����Ϊ2�֣����Ϊ4�֣���������д��", vbOKOnly, "��ʾ��Ϣ"
            txtReportLevel.Text = NVL(GetDeptPara(mlng����ID, "���������ȼ�", "��,��"))
            txtReportLevel.SetFocus
            Exit Function
        End If
    End If
    
    '����
    If chkFixedLen.value = 1 Then
        '�������λ������С����ʼ����
        For i = 1 To Val(txtFixedLen.Text)
            strLen = strLen & "9"
        Next i
        
        If Val(txtStartNum.Text) >= Val(strLen) Then
            MsgBox "����ʼ���롱��" & Len(txtStartNum.Text) & "λ�����̶�λ����Ӧ�ô��ڵ���" & Len(txtStartNum.Text) & "����������д��", vbOKOnly, "��ʾ��Ϣ"
            txtFixedLen.SetFocus
            Exit Function
        End If
    End If
    
    ValidateData = True
End Function

Private Sub cmdCancel_Click()
    mblnOk = False
    Unload Me
End Sub

Private Sub txt_LostFocus(Index As Integer)
On Error GoTo errHandle
    If Me.Visible = False Then Exit Sub
    
    If Index = 1 Or Index = 3 Or Index = 5 Or Index = 8 Then
        Call SetParChange(txt, Index, mrsPar, True, GetEncryptionPassW(txt(Index).Text))
    ElseIf Index = txt_��ӡ�������� Then
        If Val(txt(txt_��ӡ��������).Text) > 99 Then
            MsgBox "�����ӡ�����������ֻ�����ó�99", vbCritical, Me.Caption
            txt(txt_��ӡ��������).Text = "99"
            Exit Sub
        End If
        Call SetParChange(txt, Index, mrsPar)
    Else
        Call SetParChange(txt, Index, mrsPar)
    End If
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub txtAttention_KeyPress(KeyAscii As Integer)
    If lstAttentions.Visible Then
        lstAttentions.Visible = False
    End If
End Sub

Private Sub txtAudit_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtCheckIn_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtDelayTime_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtEnreg_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtEqDevice_Change()
    Dim lngSel As Long
    Dim strText As String
    
    If LenB(StrConv(txtEqDevice.Text, vbFromUnicode)) > 64 Then
        MsgBox "ԤԼ�豸�������ֻ������64λ��", vbOKOnly, "��ʾ��Ϣ"
        lngSel = txtEqDevice.SelStart
        strText = txtEqDevice.Text
        While LenB(StrConv(strText, vbFromUnicode)) > 64
            strText = Left(strText, Len(strText) - 1)
        Wend
        txtEqDevice.Text = strText
        txtEqDevice.SelStart = lngSel
    End If
End Sub

Private Sub txtFixedLen_Change()
    If Val(txtFixedLen.Text) > 18 Then
        MsgBox "�̶�λ�����Ϊ18λ����������д��", vbOKOnly, "��ʾ��Ϣ"
        txtFixedLen.Text = ""
    End If
End Sub

Private Sub txtFixedLen_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub


Private Sub TxtLike_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtLocate_Change(Index As Integer)
    If Index = txt_Dept Then
    ElseIf Index = txt_Par Then
        txtLocate(Index).Tag = ""
    End If
End Sub

Private Sub txtLocate_GotFocus(Index As Integer)
    txtLocate(Index).SelStart = 0
    txtLocate(Index).SelLength = Len(txtLocate(Index).Text)
End Sub

Private Sub txtLocate_KeyPress(Index As Integer, KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then
        Dim strFind As String

        If Trim(txtLocate(Index).Text) = "" Then Exit Sub
        strFind = UCase(Trim(txtLocate(Index).Text))

        Select Case Index
        Case txt_Par
            Call LocatePar(txtLocate(Index), Me)
        End Select
    End If
End Sub

Private Sub lst_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call SetParTip(lst, Index, mrsPar)
End Sub

Private Sub chk_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call SetParTip(chk, Index, mrsPar)
End Sub

Private Sub txt_KeyPress(Index As Integer, KeyAscii As Integer)
    If Index = txt_��ӡ�������� Then
        If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
        If KeyAscii = 13 Then
            KeyAscii = 0
            Call zlCommFun.PressKey(vbKeyTab)
        End If
        Exit Sub
    End If
    
    If KeyAscii = 13 Then
        KeyAscii = 0
        Call zlCommFun.PressKey(vbKeyTab)
    ElseIf KeyAscii = Asc(gstrParSplit1) Or KeyAscii = Asc(gstrParSplit2) Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Call SetParTip(txt, Index, mrsPar)
End Sub


Private Sub cbo_GotFocus(Index As Integer)
    Call SetParTip(cbo, Index, mrsPar)
End Sub



Private Sub cbo_KeyPress(Index As Integer, KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then zlCommFun.PressKey vbKeyTab
End Sub

Private Sub chk_KeyPress(Index As Integer, KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then zlCommFun.PressKey vbKeyTab
End Sub




Private Sub cbo_Click(Index As Integer)

    If Not Me.Visible Then Exit Sub
    
    Call SetParChange(cbo, Index, mrsPar)
    
'    Select Case Index
'    Case cbo_�ɼ�����ִ��ģʽ   '���������б���
'        Call SetParChange(cbo, Index, mrsPar)
'    Case Else       '���ı����ݽ��б���
'        Call SetParChange(cbo, Index, mrsPar)
'    End Select
'
'    If Me.Visible Then
'        Call SetParChange(cbo, Index, mrsPar, blnValue, strValue)
'    End If
    
End Sub

Private Sub chk_Click(Index As Integer)
    If Me.Visible Then
        Call SetParChange(chk, Index, mrsPar)   'Call SetParChange(chk, Index, mrsPar, blnValue, strValue)
    End If
    
    If Index = chk_¼����Ժ��Ϣ Then
        txt(txt_������Ժ����).Enabled = chk(chk_¼����Ժ��Ϣ).value
    End If
End Sub

Private Sub txtName_GotFocus()
    Me.txtName.SelStart = 0: Me.txtName.SelLength = 100
End Sub

Private Sub txtName_KeyPress(KeyAscii As Integer)
    If KeyAscii = 45 Or KeyAscii = 95 Then KeyAscii = 0
    If KeyAscii = 13 Then Call zlCommFun.PressKey(vbKeyTab)
End Sub

Private Sub txtPreText_Change()
    Dim lngSet As Long
    
    '�ж��Ƿ����Сд�ַ����������������ʾ�û������Զ��ĳɴ�д
    If txtPreText.Text <> UCase(txtPreText.Text) Then
        lngSet = txtPreText.SelStart
        txtPreText.Text = UCase(txtPreText.Text)
        txtPreText.SelStart = lngSet
    End If
End Sub

Private Sub txtRefreshInterval_Change()
    If Val(txtRefreshInterval.Text) > 600 Then
        txtRefreshInterval.Text = 600
    End If
End Sub

Private Sub txtRefreshInterval_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub


Private Sub txtRefreshInterval_LostFocus()
    If Val(txtRefreshInterval.Text) < 10 Then
        txtRefreshInterval.Text = 10
    End If
End Sub

Private Sub txtReport_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtSchDayInterval_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtSchWeekInterval_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtStartNum_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtStudy_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtValidDays_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtViewHistoryImageDays_Change()
    If Val(txtViewHistoryImageDays.Text) > 15 Then
        txtViewHistoryImageDays.Text = 15
    End If
End Sub

Private Sub txtViewHistoryImageDays_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub txtViewHistoryImageDays_LostFocus()
    If Val(txtViewHistoryImageDays.Text) <= 0 Then
        txtViewHistoryImageDays.Text = 1
    End If
End Sub

Private Sub TxtĬ������_Change()
    If Val(TxtĬ������.Text) > 15 Then
        TxtĬ������.Text = 15
    End If
End Sub

Private Sub TxtĬ������_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub TxtĬ������_LostFocus()
    If Val(TxtĬ������.Text) <= 0 Then
        TxtĬ������.Text = 1
    End If
End Sub


Private Sub ufgGroupCfg_OnSelChange()
On Error GoTo errHandle
    Dim lngGroupId As Long
    lngGroupId = Val(ufgGroupCfg.CurKeyValue)
    
    '����ҽ��ִ�з���
    Call subLoadTechniRoom(lngGroupId)
    
    '�����������Ŀ����
    Call subLoadStudyProAssociation(lngGroupId)
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub ufgRoomCfg_OnDblClick()
'˫��ִ�м�ʱ�����з����޸Ĵ���
On Error GoTo errHandle
    Call cmdModify_Click
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub ufgStudyProCfg_OnDblClick()
'˫��Ӱ������Ŀʱ�����й������ô���
On Error GoTo errHandle
    Call cmdStudyAcc_Click
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub



Private Sub Load���Ҳ���()

    Call subLoadWorkFlowConfig      '��ȡ�������̲���
    Call subLoadRoomConfig          '��ȡִ�м����
    Call subLoadInputConfig         '��ȡ¼�������ò���
    
    If stabWorkFlow.TabVisible(3) = True Then
        Call subLoadQueueGroupConfig    '��ȡ���з������ò���
    End If
    
    Call subLoadSpecifyReportItemName
    Call subLoadReportConfig        '��ȡ����༭�����ò���
    Call subLoadListColorConfig     '��ȡ�б���ɫ���ò���
End Sub


Private Sub Save���Ҳ���()
'����ҽ�����ݶ���
    On Error GoTo errHandle
        Call subSaveWorkFlowConfig
        Call subSaveInputConfig
        
        If stabWorkFlow.TabVisible(3) = True Then
            Call subSaveQueueGroupConfig
        End If
        
        Call subSaveReportConfig
        Call subSaveListColorConfig
    Exit Sub
errHandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Sub


'************************************************************************************************************************************
'************************************************************************************************************************************
    Private Sub subSaveListColorConfig()
        Dim strSql As String
        
        If mlng����ID < 0 Then Exit Sub
        
        On Error GoTo errH
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�ѵǼ�','" & shpColor(8).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�ѱ���','" & shpColor(1).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '������','" & shpColor(2).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�Ѽ��','" & shpColor(0).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '������','" & shpColor(3).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�ѱ���','" & shpColor(4).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�����','" & shpColor(6).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�����','" & shpColor(7).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�����','" & shpColor(5).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�Ѿܾ�','" & shpColor(9).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�Ѳ���','" & shpColor(10).FillColor & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�ǼǺ�����','" & Val(txtEnreg.Text) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '����������','" & Val(txtCheckIn.Text) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��������','" & Val(txtStudy.Text) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '���������','" & Val(txtReport.Text) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��˺�����','" & Val(txtAudit.Text) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '������ɫ����','" & chkNameColColorCfg.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", 'ȱʡ���Ͳ���������ɫ����','" & chkOrdinaryNameColColorCfg.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ɫ��ʾ����','" & IIF(optListColorMark(0).value = True, 0, 1) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub
    
    Private Sub subSaveReportConfig()
        Dim intMatch As Integer
        Dim strSql As String
        
        On Error GoTo ErrHand
        
        If mlng����ID < 0 Then Exit Sub
        
        
        If optReportEditor(0).value = True Then         '���Ӳ����༭��
            intMatch = 0
        ElseIf optReportEditor(1).value = True Then     'PACS����༭��
            intMatch = 1
        ElseIf optReportEditor(2).value = True Then     '�����ĵ��༭��
            intMatch = 2
        End If
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '����༭��','" & intMatch & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ʾ����ͼ��','" & chkShowImage.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��������ͼ����','" & txtMinImageCount.Text & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ʾ��Ƶ�ɼ�','" & chkShowVideoCapture.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ӡ���˳�','" & chkExitAfterPrint.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
    
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ʾר�Ʊ���','" & chkSpecialContent.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", 'ר�Ʊ���ҳ','" & cboSpecialContent.Text & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        If optWordDblClick(0).value = True Then         '����ʾ�˫����ֱ��д�뱨��
            intMatch = 0
        ElseIf optWordDblClick(1).value = True Then     '����ʾ�˫����򿪱༭����
            intMatch = 1
        End If
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '����ʾ�˫������','" & intMatch & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        If optImageDblClick(0).value = True Then         '����ͼ˫����ֱ��д�뱨��
            intMatch = 0
        ElseIf optImageDblClick(1).value = True Then     '����ͼ˫�����ͼ��༭����
            intMatch = 1
        End If
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '����ͼ˫������','" & intMatch & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�����������','" & txtCheckView.Text & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '����������','" & txtResult.Text & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��������','" & txtAdvice.Text & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        If optShowWord(0).value = True Then         'ֱ����ʾ�ʾ�ʾ��
            intMatch = 0
        ElseIf optShowWord(1).value = True Then     '˫���������ʾ�ʾ�ʾ��
            intMatch = 1
        End If
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ʾ�ʾ�ʾ��','" & intMatch & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��˴�ӡ���������','" & chkUntreadPrinted.value & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        If optReportEditor(2) Then
            strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '�鿴��ʷ����','" & IIF(optHistoryReportEditor(0).value, 0, 1) & "')"
            zlDatabase.ExecuteProcedure strSql, Me.Caption
        End If
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ӡ��ʽѡ��ʽ','" & IIF(optPrintFormat(0).value, 0, 1) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '��ѡ�����ʽ','" & IIF(chkPrintFormat.value, 1, 0) & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        
        Exit Sub
ErrHand:
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
    End Sub

    Public Sub subSaveQueueGroupConfig()
    '�������ò���
        If mlng����ID < 0 Then Exit Sub
    
        SetDeptPara mlng����ID, "�����Ŷӽк�", chkUseQueue.value
        SetDeptPara mlng����ID, "�Ŷӽкű������", IIF(optNumberRule(0).value, 0, 1)
        SetDeptPara mlng����ID, "�Ŷ����ݱ�������", Val(txtValidDays.Text)
        SetDeptPara mlng����ID, "�Ŷӵ�������", txtQueueReport.Text
        SetDeptPara mlng����ID, "ͬ����λ����б�", chkSynStudyList.value
        SetDeptPara mlng����ID, "����ʱ����Ĭ��ִ�м�", chkSelectRoom.value
        SetDeptPara mlng����ID, "�Ŷӵ���ӡ��ʽ", cbxPrintQueueNoWay.ListIndex
        SetDeptPara mlng����ID, "�����Ŷ���Ϣ����", chkUseQueueMsg.value
        SetDeptPara mlng����ID, "�������Զ��Ŷ�", chkAutoInQueue.value
        SetDeptPara mlng����ID, "ʹ��ԤԼ���Ŷ�", chkUseSchNumInQueue.value
    End Sub
    
    
    Private Function SetDeptPara(ByVal lngDeptID As Long, ByVal varPara As String, ByVal strValue As String) As Boolean
    '���ܣ�����ָ���Ĳ���ֵ
    '������lngDept=����ID
    '      varPara=������
    '      strValue=������ֵ
    '���أ������Ƿ�ɹ�
        Dim strSql As String
        
        On Error GoTo errH
            
        strSql = "ZL_Ӱ�����̲���_UPDATE(" & lngDeptID & ",'" & varPara & "','" & strValue & "')"
        Call zlDatabase.ExecuteProcedure(strSql, "SetPara")
        
        '���óɹ����������
        Set mrsDeptParas = Nothing
        
        SetDeptPara = True
        Exit Function
errH:
        If ErrCenter() = 1 Then Resume
    End Function


    Private Sub subSaveInputConfig()
        Call subSaveInputItem(0)
        Call subSaveInputItem(1)
    End Sub
    
    
    Private Sub subSaveInputItem(intType As Integer)
        Dim i As Integer, strInput As String
        Dim strSql As String
        
        strInput = ""
        If intType = 0 Then
            For i = 0 To ChkMouseMove.UBound
                If ChkMouseMove(i).value = 1 Then strInput = strInput & "|" & ChkMouseMove(i).Caption
            Next
        Else
            For i = 0 To ChkInput.UBound
                If ChkInput(i).value = 1 Then strInput = strInput & "|" & ChkInput(i).Caption
            Next
        End If
        On Error GoTo errH
        strSql = "ZL_Ӱ�����̲���_UPDATE( " & mlng����ID & ", '" & IIF(intType = 0, "�������", "��¼����") & "','" & strInput & "')"
        zlDatabase.ExecuteProcedure strSql, Me.Caption
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub
    
    
    Private Sub subSaveWorkFlowConfig()
        Dim strTemp As String
        Dim lngTemp As Long
        
        On Error GoTo ErrHand
    
        SetDeptPara mlng����ID, "�������뵥ɨ��", chkPetitionCapture.value        '�������뵥ɨ�� ��������
        
        SetDeptPara mlng����ID, "��������ж�", chkConformDetermine.value         '��������ж� ��������
'        SetDeptPara mlng����ID, "Σ������ж�", chkCriticalValues.value           'Σ������ж� ��������
        
        SetDeptPara mlng����ID, "���Խ��������", chkIgnorePosi.value
        SetDeptPara mlng����ID, "��Ӱ�����Ϊ����", chkReportAfterResult.value
        SetDeptPara mlng����ID, "��Ͻ��Ĭ������", chkDefaultPosi.value   '��Ͻ��Ĭ������ ��������
        
        SetDeptPara mlng����ID, "Ӱ�������ж�", chkImageLevel.value           'Ӱ�������ж� ��������
        SetDeptPara mlng����ID, "Ӱ�������ȼ�", txtImageLevel.Text            'ͼ�������ȼ� ��������
        SetDeptPara mlng����ID, "���������ж�", chkReportLevel.value           '���������ж� ��������
        SetDeptPara mlng����ID, "���������ȼ�", txtReportLevel.Text           '���������ȼ� ��������
        
        SetDeptPara mlng����ID, "��Ͻ����ʾ����", IIF(optResultInput(0).value = True, 0, IIF(optResultInput(1).value = True, 1, 2))
        
        SetDeptPara mlng����ID, "��ͼ��ҽ��վ���ɹ�Ƭ", chkCanViewImage.value     '��ͼ��ҽ��վ���ɹ�Ƭ
        SetDeptPara mlng����ID, "��ͼ�����д����", chkReportAfterImging.value
        SetDeptPara mlng����ID, "����δǩ�������ӡ���", chkNoSignFinish.value     'δǩ�������ӡ���
        SetDeptPara mlng����ID, "���ﲡ�˱���ʱ��ִ�з���", chkEmergencyRequestNotExecuteMoney.value     '���ﲡ�˱���ʱ��ִ�з���
        SetDeptPara mlng����ID, "����δ��������", chkNoRegCanPay.value
        
        '��������
        SetDeptPara mlng����ID, "���߼��ű��ֲ���", IIF(OptCode(1).value, 1, 0)
        SetDeptPara mlng����ID, "���ű��ֲ������", IIF(OptUnicode(1).value, 1, 0)
        SetDeptPara mlng����ID, "�ֹ���������", chkChangeNO.value
        SetDeptPara mlng����ID, "��������ظ�", chkCanOverWrite.value
        SetDeptPara mlng����ID, "��ȡʵ��������", chkCheckMaxNo.value
        
        SetDeptPara mlng����ID, "ʹ�û��ߺ�", IIF(optUsePatientID.value And optUsePatientID.Enabled, 1, 0)
        SetDeptPara mlng����ID, "ʹ��ҽ����", IIF(optUseAdviceID.value And optUseAdviceID.Enabled, 1, 0)
        
        If OptCode(0).value = True Then
            SetDeptPara mlng����ID, "�������ɷ�ʽ", IIF(OptBuildcode(1).value, 1, 0)
        Else
            SetDeptPara mlng����ID, "�������ɷ�ʽ", IIF(OptUnicode(1).value, 1, 0)
        End If
        
        If chkPreText.value = 1 Then
            If optPreText(0).value = True Then
                strTemp = 1
            Else
                strTemp = txtPreText.Text
            End If
        Else
            strTemp = ""
        End If
        SetDeptPara mlng����ID, "����ǰ׺", strTemp
        SetDeptPara mlng����ID, "���ŷָ���1", IIF(chkDelimiter(1).value = 1, Left(cboDelimeter(1).Text, 1), "")
        SetDeptPara mlng����ID, "���ŷָ���2", IIF(chkDelimiter(2).value = 1, Left(cboDelimeter(2).Text, 1), "")
        SetDeptPara mlng����ID, "������", IIF(chkYear.value = 1, IIF(optYear(0).value = True, 1, 2), 0)
        SetDeptPara mlng����ID, "������", chkMonth.value
        SetDeptPara mlng����ID, "������", chkDay.value
        SetDeptPara mlng����ID, "������ʼ��", IIF(Val(txtStartNum.Text) = 0, 1, Val(txtStartNum.Text))
        SetDeptPara mlng����ID, "���Ź̶�λ��", IIF(chkFixedLen.value = 1, Val(txtFixedLen.Text), 0)
        
        SetDeptPara mlng����ID, "��λƬ����", chkLocalizerBackward.value
        SetDeptPara mlng����ID, "�������û�", chkChangeUser.value
        SetDeptPara mlng����ID, "�����л��û�", chkSwitchUser.value
        SetDeptPara mlng����ID, "ֻ����д�Լ����ı���", chkTechReportSame.value
        SetDeptPara mlng����ID, "�ɼ�ͼ����Ϊ��鼼ʦ", chkWriteCapDoctor.value
        SetDeptPara mlng����ID, "��˺�ֱ�����", ChkCompleteCommit.value
        SetDeptPara mlng����ID, "�����ֱ�����", chkFinallyCompleteCommit.value
        SetDeptPara mlng����ID, "��ӡ��ֱ�����", chkPrintCommit.value
        SetDeptPara mlng����ID, "�����ֱ�Ӵ�ӡ", chkCompletePrint.value
        SetDeptPara mlng����ID, "�ǼǺ�ֱ�Ӽ��", chkSample.value
        SetDeptPara mlng����ID, "ͬ����ӹ�Ƭ����ͼ", chkDirectRepImg.value
        SetDeptPara mlng����ID, "ƥ�����ݿ���Ŀ", IIF(optMatch(0).value, 0, IIF(optMatch(1), 1, 2))
        
        SetDeptPara mlng����ID, "�Ǽ�ʱ����ģ����������", IIF(ChkLike.value = 1, Abs(Val(TxtLike.Text)), 0)
        SetDeptPara mlng����ID, "���еǼǲ��˱��Ϊ����", chkAllPatientIsOutside
        
        If Val(TxtĬ������.Text) > 15 Or Val(TxtĬ������.Text) <= 0 Then
            TxtĬ������.Text = 2
        End If
        SetDeptPara mlng����ID, "Ĭ�Ϲ�������", Val(TxtĬ������.Text)
        
        If Val(txtViewHistoryImageDays.Text) > 15 Or Val(txtViewHistoryImageDays.Text) <= 0 Then
            txtViewHistoryImageDays.Text = 1
        End If
        SetDeptPara mlng����ID, "�Զ�����ʷͼ������", Val(txtViewHistoryImageDays.Text)
        
        
        SetDeptPara mlng����ID, "������������", chkUseReferencePatient.value
        SetDeptPara mlng����ID, "ƽ������˲��ܴ򱨸�", chkPrintNeedComplete.value
        SetDeptPara mlng����ID, "ͼ������ʾ", chkImgShowDesc.value
        SetDeptPara mlng����ID, "ͼ��ǩ����֤", chkImageSignVal.value
        
        SetDeptPara mlng����ID, "ƴ������Сд", IIF(optCapital(0).value, 0, IIF(optCapital(1), 1, 2))
        SetDeptPara mlng����ID, "ƴ�����ָ���", IIF(optSplitter(0).value, 0, 1)
        
        If cboSaveDevice.Text <> "" Then
            SetDeptPara mlng����ID, "���뵥�洢�豸��", Split(cboSaveDevice.Text, "-")(0)
        Else
            SetDeptPara mlng����ID, "���뵥�洢�豸��", ""
        End If
        
        If cboPDF.Text <> "" Then
            SetDeptPara mlng����ID, "PDFת���洢�豸", Split(cboPDF.Text, "-")(0)
        Else
            SetDeptPara mlng����ID, "PDFת���洢�豸", ""
        End If
        
        If Abs(Val(txtRefreshInterval.Text)) = 0 Or Abs(Val(txtRefreshInterval.Text)) > 65 Then
            txtRefreshInterval.Text = 10
        End If
        SetDeptPara mlng����ID, "�Զ�ˢ�¼��", IIF(chkRefreshInterval.value = 1, Abs(Val(txtRefreshInterval.Text)), 0)
        SetDeptPara mlng����ID, "����ʱ�Զ�����WorkList", chkAutoSendWorkList.value
        SetDeptPara mlng����ID, "��ʾ��������", chkAddons.value
        SetDeptPara mlng����ID, "��ʾ��Ӱ��", chkReagent.value
        SetDeptPara mlng����ID, "ҽ��վ�鿴����", cboViewReport.ListIndex
        SetDeptPara mlng����ID, "����л�ʱ��λ����༭", chkSetFocusWithReport.value
        SetDeptPara mlng����ID, "����Ĭ��ģ����ѯ", chkNameFuzzySearch.value
        SetDeptPara mlng����ID, "������ѯʱ������", chkNameQueryTimeLimit.value
        
        If chkPreView.value = 1 Then
            If optMovePreview.value Then
                lngTemp = 1
            ElseIf optClickPreview.value Then
                lngTemp = 2
            End If
        Else
            lngTemp = 0
        End If
        
        SetDeptPara mlng����ID, "����ͼԤ����ʽ", lngTemp
        SetDeptPara mlng����ID, "�ƶ�Ԥ����ʱ", Val(txtDelayTime.Text)
         
        Exit Sub
ErrHand:
        If 1 = 2 Then
        Resume
        End If
        
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
    End Sub
'************************************************************************************************************************************
'************************************************************************************************************************************
    
    Private Sub subLoadSpecifyReportItemName()
        'װ��ר�Ʊ�������
        Call cboSpecialContent.Clear
        Call cboSpecialContent.AddItem(Report_Form_frmReportES)
        Call cboSpecialContent.AddItem(Report_Form_frmReportPathology)
        Call cboSpecialContent.AddItem(Report_Form_frmReportUS)
        Call cboSpecialContent.AddItem(Report_Form_frmReportCustom)
    End Sub
    
    
    Private Sub subLoadListDefColorConfig()
    '�����б�Ĭ����ɫ����
        shpColor(10).FillColor = ColorConstants.vbYellow
        shpColor(9).FillColor = ColorConstants.vbRed
        shpColor(7).FillColor = ColorConstants.vbGreen
        
        shpColor(0).FillColor = ColorConstants.vbWhite
        shpColor(1).FillColor = ColorConstants.vbWhite
        shpColor(2).FillColor = ColorConstants.vbWhite
        shpColor(3).FillColor = ColorConstants.vbWhite
        shpColor(4).FillColor = ColorConstants.vbWhite
        shpColor(5).FillColor = ColorConstants.vbWhite
        shpColor(6).FillColor = ColorConstants.vbWhite
        shpColor(8).FillColor = ColorConstants.vbWhite
        
        txtEnreg.Text = "0"
        txtCheckIn.Text = "0"
        txtStudy.Text = "0"
        txtReport.Text = "0"
        txtAudit.Text = "0"
    End Sub
    
    Private Sub subLoadListColorConfig()
        Dim strSql As String
        Dim rsTemp As ADODB.Recordset
                 
        On Error GoTo err
        
        
        Call subLoadListDefColorConfig
        
        strSql = "select ID ,����ID,������,����ֵ from Ӱ�����̲��� where ����ID = [1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSql, Me.Caption, mlng����ID)
        
        While Not rsTemp.EOF
            Select Case rsTemp!������
                Case "�ѵǼ�"
                    shpColor(8).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�ѱ���"
                    shpColor(1).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "������"
                    shpColor(2).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�Ѽ��"
                    shpColor(0).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "������"
                    shpColor(3).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�ѱ���"
                    shpColor(4).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�����"
                    shpColor(6).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�����"
                    shpColor(7).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�����"
                    shpColor(5).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�Ѿܾ�"
                    shpColor(9).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�Ѳ���"
                    shpColor(10).FillColor = Val(NVL(rsTemp!����ֵ))
                Case "�ǼǺ�����"
                    txtEnreg.Text = Val(NVL(rsTemp!����ֵ))
                Case "����������"
                    txtCheckIn.Text = Val(NVL(rsTemp!����ֵ))
                Case "��������"
                    txtStudy.Text = Val(NVL(rsTemp!����ֵ))
                Case "���������"
                    txtReport.Text = Val(NVL(rsTemp!����ֵ))
                Case "��˺�����"
                    txtAudit.Text = Val(NVL(rsTemp!����ֵ))
                Case "��ɫ��ʾ����"
                    If Val(NVL(rsTemp!����ֵ)) = 0 Then
                        optListColorMark(0).value = True
                    Else
                        optListColorMark(1).value = True
                    End If
            End Select
            rsTemp.MoveNext
        Wend
        
        chkNameColColorCfg.value = Val(GetDeptPara(mlng����ID, "������ɫ����", 0))
        If chkNameColColorCfg.value = 0 Then
            chkOrdinaryNameColColorCfg.value = 0
            chkOrdinaryNameColColorCfg.Enabled = False
        Else
            chkOrdinaryNameColColorCfg.Enabled = True
            chkOrdinaryNameColColorCfg.value = Val(GetDeptPara(mlng����ID, "ȱʡ���Ͳ���������ɫ����", 0))
        End If
    
        
        Exit Sub
err:
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
    End Sub
    

    Public Sub subLoadReportConfig()
        Dim strSql As String
        Dim rsTemp As ADODB.Recordset
        
        optReportEditor(0).value = True 'Ĭ��ʹ�õ��Ӳ����༭���༭����
        chkShowImage.value = 0          'Ĭ�ϲ���ʾͼ������
        chkShowVideoCapture.value = 0   'Ĭ�ϲ���ʾ��Ƶ�ɼ�����
        
        chkSpecialContent.value = 0     'Ĭ�ϲ���ʾר�Ʊ���
        cboSpecialContent.Enabled = False
        chkExitAfterPrint.value = 0     'Ĭ�ϴ�ӡ���˳�
        optWordDblClick(0).value = True 'Ĭ��˫���ʾ��ֱ��д�뱨��
        optImageDblClick(0).value = True 'Ĭ�ϱ�������ͼ˫����ֱ��д�뱨��
        txtCheckView.Text = "�������"  'Ĭ��Ϊ�������
        txtResult.Text = "������"     'Ĭ��Ϊ������
        txtAdvice.Text = "����"         'Ĭ��Ϊ����
        optShowWord(0).value = True     'Ĭ��Ϊֱ����ʾ�ʾ�ģ��
        chkUntreadPrinted.value = 0     'Ĭ��Ϊ��˴�ӡ���������
         
        On Error GoTo err
        strSql = "select ID ,����ID,������,����ֵ from Ӱ�����̲��� where ����ID = [1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSql, Me.Caption, mlng����ID)
        
        While Not rsTemp.EOF
            Select Case rsTemp!������
                Case "����༭��"
                    If NVL(rsTemp!����ֵ, 0) = 0 Then
                        optReportEditor(0).value = True
                    ElseIf NVL(rsTemp!����ֵ, 0) = 1 Then
                        optReportEditor(1).value = True
                    Else
                        optReportEditor(2).value = True
                    End If
                Case "�鿴��ʷ����"
                    If NVL(rsTemp!����ֵ, 0) = 0 Then
                        optHistoryReportEditor(0).value = True
                    Else
                        optHistoryReportEditor(1).value = True
                    End If
                Case "��ʾ����ͼ��"
                    chkShowImage.value = NVL(rsTemp!����ֵ, 0)
                Case "��������ͼ����"
                    txtMinImageCount.Text = NVL(rsTemp!����ֵ, "8")
                Case "��ʾ��Ƶ�ɼ�"
                    chkShowVideoCapture.value = NVL(rsTemp!����ֵ, 0)
                Case "��ӡ���˳�"
                    chkExitAfterPrint.value = NVL(rsTemp!����ֵ, 0)
                Case "��ʾר�Ʊ���"
                    chkSpecialContent.value = NVL(rsTemp!����ֵ, 0)
                    cboSpecialContent.Enabled = IIF(chkSpecialContent.value = 1, True, False)
                Case "ר�Ʊ���ҳ"
                    cboSpecialContent.Text = NVL(rsTemp!����ֵ)
                Case "����ʾ�˫������"
                    If NVL(rsTemp!����ֵ, 0) = 0 Then
                        optWordDblClick(0).value = True
                    Else
                        optWordDblClick(1).value = True
                    End If
                Case "����ͼ˫������"
                    If NVL(rsTemp!����ֵ, 0) = 0 Then
                        optImageDblClick(0).value = True
                    Else
                        optImageDblClick(1).value = True
                    End If
                Case "�����������"
                    txtCheckView.Text = NVL(rsTemp!����ֵ, "�������")
                Case "����������"
                    txtResult.Text = NVL(rsTemp!����ֵ, "������")
                Case "��������"
                    txtAdvice.Text = NVL(rsTemp!����ֵ, "����")
                Case "��ʾ�ʾ�ʾ��"
                    If NVL(rsTemp!����ֵ, 0) = 0 Then
                        optShowWord(0).value = True
                    Else
                        optShowWord(1).value = True
                    End If
                Case "��˴�ӡ���������"
                    chkUntreadPrinted.value = NVL(rsTemp!����ֵ, 0)
                Case "��ӡ��ʽѡ��ʽ"
                If NVL(rsTemp!����ֵ, 0) = 0 Then
                    optPrintFormat(0).value = True
                Else
                    optPrintFormat(1).value = True
                End If
                Case "��ѡ�����ʽ"
                    chkPrintFormat.value = IIF(NVL(rsTemp!����ֵ, 0), 1, 0)
            End Select
            rsTemp.MoveNext
        Wend
        
        If optReportEditor(2).value Then
            fra(24).Visible = True
        Else
            fra(24).Visible = False
        End If
        
        Exit Sub
err:
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
    End Sub

    Public Sub subLoadQueueGroupConfig()
    'ˢ�����ò���
        Dim lngIndex As Long
    
        On Error GoTo err
    
        lngIndex = Val(GetDeptPara(mlng����ID, "�Ŷӽкű������", 0))
        txtValidDays.Text = GetDeptPara(mlng����ID, "�Ŷ����ݱ�������", 1)
        txtQueueReport.Text = GetDeptPara(mlng����ID, "�Ŷӵ�������", "")
        chkSynStudyList.value = Val(GetDeptPara(mlng����ID, "ͬ����λ����б�", 0))
        chkSelectRoom.value = Val(GetDeptPara(mlng����ID, "����ʱ����Ĭ��ִ�м�", 0))
        chkUseQueueMsg.value = Val(GetDeptPara(mlng����ID, "�����Ŷ���Ϣ����", 1))
        chkAutoInQueue.value = Val(GetDeptPara(mlng����ID, "�������Զ��Ŷ�", 1))
        chkUseSchNumInQueue.value = Val(GetDeptPara(mlng����ID, "ʹ��ԤԼ���Ŷ�", 0))
        
        '0-����ӡ��1-�Զ���ӡ��2-��ʾ��ӡ
        cbxPrintQueueNoWay.ListIndex = Val(GetDeptPara(mlng����ID, "�Ŷӵ���ӡ��ʽ", 0))
        
        chkUseQueue.value = Val(GetDeptPara(mlng����ID, "�����Ŷӽк�", 0))
        
        Call subLoadGroupInf
    
        optNumberRule(lngIndex).value = True
    
        Call chkUseQueue_Click
    
        Exit Sub
err:
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
    End Sub

    Private Sub subLoadGroupInf()
    '����ҽ��������Ϣ
        Dim strSql As String
        Dim rsData As ADODB.Recordset
        
        On Error GoTo errH
        strSql = "select Id, ����,����ǰ׺ from Ӱ��ִ�з��� where ����ID=[1]"
        Set rsData = zlDatabase.OpenSQLRecord(strSql, "��ѯ������Ϣ", mlng����ID)
        
        ufgGroupCfg.ExtendLastCol = True
        Call ufgGroupCfg.ClearListData
        If rsData.RecordCount <= 0 Then Exit Sub
        
        rsData.Sort = "���� asc"
        
        Set ufgGroupCfg.AdoData = rsData
        Call ufgGroupCfg.BindData
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub
    
    Private Sub subLoadTechniRoom(ByVal lngGroupId As Long)
    '�������������ҽ��ִ�з���
        Dim strSql As String
        Dim rsData As ADODB.Recordset
        
        On Error GoTo errH
        strSql = "select ִ�м�, ����ǰ׺ from ҽ��ִ�з��� where ����Id=[1]"
        Set rsData = zlDatabase.OpenSQLRecord(strSql, "��ѯҽ��ִ�з���", lngGroupId)
        
        ufgRoomCfg.ExtendLastCol = True
        Call ufgRoomCfg.ClearListData
        If rsData.RecordCount <= 0 Then Exit Sub
        
        rsData.Sort = "ִ�м� asc"
        
        Set ufgRoomCfg.AdoData = rsData
        Call ufgRoomCfg.BindData
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub
    
    Private Sub subLoadStudyProAssociation(ByVal lngGroupId As Long)
    '��������Ŀ����
        Dim strSql As String
        Dim rsData As ADODB.Recordset
        
        On Error GoTo errH
        strSql = "select ����,���� from ������ĿĿ¼ a, Ӱ�������� b where a.id=b.������ĿId and b.����Id=[1]"
        Set rsData = zlDatabase.OpenSQLRecord(strSql, "��ѯӰ�������������Ŀ", lngGroupId)
        
        ufgStudyProCfg.ExtendLastCol = True
        Call ufgStudyProCfg.ClearListData
        If rsData.RecordCount <= 0 Then Exit Sub
        
        rsData.Sort = "����"
        
        Set ufgStudyProCfg.AdoData = rsData
        Call ufgStudyProCfg.BindData
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub

    Private Sub subLoadInputConfig()
        Call subLoadInputItem(0)
        Call subLoadInputItem(1)
    End Sub
    
    Private Sub subLoadInputItem(intType As Integer)
    '����¼������
    'intType 0-������ƣ�1-��¼����
        Dim i As Integer, strInput As String, j As Integer
        Dim strSql As String
        Dim rsTemp As ADODB.Recordset
        
        
        If intType = 0 Then
            '��ʼ���ر��ƶ�ѡ���
            For i = 0 To ChkMouseMove.UBound
                ChkMouseMove(i).value = 0
            Next
        Else
            '��ʼ��¼ѡ���
            For i = 0 To ChkInput.UBound
                ChkInput(i).value = 0
            Next
        End If
        On Error GoTo errH
        strSql = "select ID ,����ID,����ֵ from Ӱ�����̲��� where ����ID = [1] and ������ = [2]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSql, Me.Caption, mlng����ID, CStr(IIF(intType = 0, "�������", "��¼����")))
        
        If Not rsTemp.EOF Then
            strInput = NVL(rsTemp!����ֵ)
            For i = 0 To UBound(Split(strInput, "|"))
                If intType = 0 Then
                    For j = 0 To ChkMouseMove.UBound
                        If ChkMouseMove(j).Caption = Split(strInput, "|")(i) Then ChkMouseMove(j).value = 1: Exit For
                    Next
                
                Else
                    For j = 0 To ChkInput.UBound
                        If ChkInput(j).Caption = Split(strInput, "|")(i) Then ChkInput(j).value = 1: Exit For
                    Next
                End If
            Next
        End If
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub


    Private Sub SeekIndex(objCbo As Object, ByVal strText As String, Optional blnEvent As Boolean, Optional blnPreserve As Boolean = False, Optional intIsSearchNo As TNeedType = tNeedName)
    '���ܣ���ComboBox�в��Ҳ���λ
    '������blnEvent=��λʱ�Ƿ񴥷�Click�¼�
          'blnPreserve--����Ҳ���ƥ����Ŀ���򱣳�ԭ����Ŀ
          'intIsSearchNo -- 0:ͨ�����붨λ,1:ͨ�����ֶ�λ,2:�ù���������ֶ�λ
    '˵����δ�ܶ�λʱ,����ListIndex=-1
    '       Cbo.SeekIndex���ܱȽϼ򵥣�����index��ᴥ���¼������ʺ�ʹ��
        Dim i As Long
    
        For i = 0 To objCbo.ListCount - 1
            If IIF(Abs(intIsSearchNo) = tNeedAll, objCbo.List(i), IIF(Abs(intIsSearchNo) = tNeedNo, zlStr.NeedCode(objCbo.List(i)), zlStr.NeedName(objCbo.List(i)))) = strText Then
                If blnEvent Then
                    objCbo.ListIndex = i
                Else
                    Call zlControl.CboSetIndex(objCbo.hwnd, i)
                End If
                Exit Sub
            End If
        Next
        
        If blnPreserve = True Then
            If blnEvent = False Then
                Call zlControl.CboSetIndex(objCbo.hwnd, objCbo.ListIndex)
            End If
        Else
            If blnEvent Then
                objCbo.ListIndex = -1
            Else
                Call zlControl.CboSetIndex(objCbo.hwnd, -1)
            End If
        End If
        
    End Sub


    Private Sub subLoadRoomConfig()
        Dim objItem As ListItem
        Dim rsTemp As New ADODB.Recordset
        Dim strSql As String
        
        On Error GoTo ErrHand
        
        strSql = "Select ִ�м�,����豸,����ǰ׺ From ҽ��ִ�з��� where ����id=[1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSql, Me.Caption, CLng(Val(mlng����ID)))
        Me.lvwRoom.ListItems.Clear
        With rsTemp
            Do While Not .EOF
                Set objItem = Me.lvwRoom.ListItems.Add(, , !ִ�м�, 1, 1)
                
                objItem.SubItems(1) = NVL(!����豸)
                objItem.SubItems(2) = NVL(!����ǰ׺)
                .MoveNext
            Loop
        End With
        
        err = 0: On Error Resume Next
        If Me.lvwRoom.ListItems.Count > 0 Then
            Me.lvwRoom.ListItems(1).Selected = True
            Me.lvwRoom.SelectedItem.EnsureVisible
        End If
        
        err = 0: On Error GoTo 0
        If Me.lvwRoom.ListItems.Count > 0 Then
            Call lvwRoom_ItemClick(Me.lvwRoom.SelectedItem)
            Me.txtName.Enabled = True: cboDevice.Enabled = True
            Me.cmdDel.Enabled = True: Me.cmdSave.Enabled = True: Me.cmdRestore.Enabled = True
        Else
            Me.lab(4).Tag = "": Me.txtName.Text = "": If cboDevice.ListCount > 0 Then cboDevice.ListIndex = 0
            Me.txtName.Enabled = False: cboDevice.Enabled = False
            Me.cmdDel.Enabled = False: Me.cmdSave.Enabled = False: Me.cmdRestore.Enabled = False
        End If
        Exit Sub
ErrHand:
        If ErrCenter() = 1 Then Resume
        Call SaveErrLog
    End Sub


    Private Sub subInitTechincRoom()
        Dim rsTemp As New ADODB.Recordset
        Dim strSql As String
        
        Me.lvwRoom.ListItems.Clear
        With Me.lvwRoom.ColumnHeaders
            .Clear
            .Add , "����", "����", 3000
            .Add , "����豸", "����豸", 3000
            .Add , "����ǰ׺", "����ǰ׺", 2000
        End With
        On Error GoTo errH
        strSql = "Select �豸��,�豸�� From Ӱ���豸Ŀ¼ Where ״̬=1 and ����=4"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSql, App.ProductName)
        cboDevice.Clear
        Do Until rsTemp.EOF
            cboDevice.AddItem rsTemp!�豸�� & "-" & rsTemp!�豸��
            rsTemp.MoveNext
        Loop
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub
    
    
    Private Sub subLoadWorkFlowConfig()
        Dim lngTemp As Long
        Dim strTemp As String
            
        mblnLoading = True
        '��ʼ��Ĭ��ֵ,Ӧ����һ��ͳһ�ĵط�����Ĭ��ֵ������������ʾ�����ն�ȡ
        chkIgnorePosi.value = 0     '���Խ��������
        chkReportAfterResult.value = 0 '��Ӱ�����Ϊ����
        chkReportAfterImging.value = 0  '��ͼ�񲻿ɱ༭����
        chkLocalizerBackward.value = 0  '��λƬ����
        chkChangeUser.value = 0         '�������û�
        chkSwitchUser.value = 0         '�����л��û�
        chkTechReportSame.value = 0     'ֻ����д�Լ����ı���
        chkWriteCapDoctor.value = 0     '�ɼ�ͼ����Ϊ��鼼ʦ
        ChkCompleteCommit.value = 0     '��˺�ֱ�����
        chkFinallyCompleteCommit.value = 0  '�����ֱ�����
        optMatch(0).value = True        'ƥ�����ݿ���Ŀ
        chkNoRegCanPay.value = 0
        
        ChkLike.value = 0               '���õǼ�ʱ����ģ������
        TxtLike.Text = 0                '�Ǽ�ʱ����ģ����������
        TxtĬ������.Text = 2            'Ĭ�Ϲ�������
        txtViewHistoryImageDays.Text = 1 'Ĭ���Զ�����ʷͼ������
        chkRefreshInterval.value = 0    '���ò����б��Զ�ˢ��
        txtRefreshInterval.Text = 0     'Ĭ�ϲ����б��Զ�ˢ�¼��Ϊ0�룬��ˢ��
        cboSaveDevice.Clear                 '�洢�豸
        cboPDF.Clear                 'PDF�洢�豸
        chkPrintCommit.value = 0        '��ӡ��ֱ�����
        chkCompletePrint.value = 0      '�����ֱ�Ӵ�ӡ
        chkUseReferencePatient.value = 0  'Ĭ�ϲ����ù�������
        chkImgShowDesc.value = 0
        chkImageSignVal.value = 0
        optCapital(0).value = True      'Ĭ��ƴ��ʹ�ô�д
        optCapital(1).value = True      'Ĭ��ƴ������ÿո�
        chkCheckMaxNo.value = 1         'Ĭ����ȡʵ��������
        chkDefaultPosi.value = 0        '��Ͻ��Ĭ������Ϊδ��ѡ
        chkConformDetermine.value = 1       '��������ж�Ĭ��Ϊѡ��
        txtImageLevel.Text = "��,��"     'Ĭ��Ӱ�������ȼ�
        txtReportLevel.Text = "��,��"    'Ĭ�ϱ��������ȼ�
        chkPetitionCapture.value = 1     'Ĭ�Ϲ�ѡ�������뵥ɨ��
        chkAddons.value = 1              '�ڵǼǴ�����ʾ��������
        chkReagent.value = 1             '�ڵǼǴ�����ʾ��Ӱ��

        If cboViewReport.ListCount > 0 Then cboViewReport.ListIndex = 0
        
        On Error GoTo err
        
        lngTemp = Val(GetDeptPara(mlng����ID, "��Ͻ����ʾ����", 0))
        optResultInput(lngTemp).value = True
        
        chkIgnorePosi.value = Val(GetDeptPara(mlng����ID, "���Խ��������", 0)) '��һ��ʹ��ʱ��Ҫ���¶�ȡ
        chkDefaultPosi.value = Val(GetDeptPara(mlng����ID, "��Ͻ��Ĭ������", 0))  '��ȡĬ�����Բ���
        chkReportAfterResult.value = Val(GetDeptPara(mlng����ID, "��Ӱ�����Ϊ����", 0))
        
        chkConformDetermine.value = Val(GetDeptPara(mlng����ID, "��������ж�", 0))    '��ȡ��������ж�
        
        chkImageLevel.value = Val(GetDeptPara(mlng����ID, "Ӱ�������ж�", 0))   '��ȡӰ�������ж�
        txtImageLevel.Text = NVL(GetDeptPara(mlng����ID, "Ӱ�������ȼ�", "��,��"))  '��ȡӰ�������ȼ�
        txtImageLevel.Enabled = chkImageLevel.value = 1
        
        chkReportLevel.value = Val(GetDeptPara(mlng����ID, "���������ж�", 0)) '��ȡ���������ж�
        txtReportLevel.Text = NVL(GetDeptPara(mlng����ID, "���������ȼ�", "��,��"))  '��ȡ���������ȼ�
        txtReportLevel.Enabled = chkReportLevel.value = 1
        
        chkPetitionCapture.value = Val(GetDeptPara(mlng����ID, "�������뵥ɨ��", 1))    '��ȡ�������뵥ɨ�����
        chkCanViewImage.value = Val(GetDeptPara(mlng����ID, "��ͼ��ҽ��վ���ɹ�Ƭ", 0))
        chkReportAfterImging.value = Val(GetDeptPara(mlng����ID, "��ͼ�����д����", 0))
        chkNoRegCanPay.value = Val(GetDeptPara(mlng����ID, "����δ��������", 0))
        chkNoSignFinish.value = Val(GetDeptPara(mlng����ID, "����δǩ�������ӡ���", 0))
        chkEmergencyRequestNotExecuteMoney.value = Val(GetDeptPara(mlng����ID, "���ﲡ�˱���ʱ��ִ�з���", 0))
        chkCanOverWrite.value = Val(GetDeptPara(mlng����ID, "��������ظ�", 0))
        chkCheckMaxNo.value = Val(GetDeptPara(mlng����ID, "��ȡʵ��������", 1))
        chkChangeNO.value = Val(GetDeptPara(mlng����ID, "�ֹ���������", 0))
        chkLocalizerBackward.value = Val(GetDeptPara(mlng����ID, "��λƬ����", 0))
        chkChangeUser.value = Val(GetDeptPara(mlng����ID, "�������û�", 0))
        chkSwitchUser.value = Val(GetDeptPara(mlng����ID, "�����л��û�", 0))
        chkTechReportSame.value = Val(GetDeptPara(mlng����ID, "ֻ����д�Լ����ı���", 0))
        chkWriteCapDoctor.value = Val(GetDeptPara(mlng����ID, "�ɼ�ͼ����Ϊ��鼼ʦ", 0))
        ChkCompleteCommit.value = Val(GetDeptPara(mlng����ID, "��˺�ֱ�����", 0))
        chkFinallyCompleteCommit.value = Val(GetDeptPara(mlng����ID, "�����ֱ�����", 0))
        chkPrintCommit.value = Val(GetDeptPara(mlng����ID, "��ӡ��ֱ�����", 0))
        chkCompletePrint.value = Val(GetDeptPara(mlng����ID, "�����ֱ�Ӵ�ӡ", 0))
        
        TxtLike.Text = Val(GetDeptPara(mlng����ID, "�Ǽ�ʱ����ģ����������", 0))
        chkSample.value = Val(GetDeptPara(mlng����ID, "�ǼǺ�ֱ�Ӽ��", 0))
        chkDirectRepImg.value = Val(GetDeptPara(mlng����ID, "ͬ����ӹ�Ƭ����ͼ", 1))
        ChkLike.value = IIF(Val(TxtLike.Text) <> 0, 1, 0)
        chkAllPatientIsOutside.value = Val(GetDeptPara(mlng����ID, "���еǼǲ��˱��Ϊ����", 0))
        
        TxtĬ������.Text = Val(GetDeptPara(mlng����ID, "Ĭ�Ϲ�������", 2))
        
        If Val(TxtĬ������.Text) > 15 Or Val(TxtĬ������.Text) <= 0 Then
            TxtĬ������.Text = 2
        End If
        
        txtViewHistoryImageDays.Text = Val(GetDeptPara(mlng����ID, "�Զ�����ʷͼ������", 1))
        If Val(txtViewHistoryImageDays.Text) > 15 Or Val(txtViewHistoryImageDays.Text) <= 0 Then
            txtViewHistoryImageDays.Text = 1
        End If
        
        txtRefreshInterval.Text = Val(GetDeptPara(mlng����ID, "�Զ�ˢ�¼��", 0))
        chkRefreshInterval.value = IIF(Val(txtRefreshInterval.Text) <> 0, 1, 0)
        optMatch(Val(GetDeptPara(mlng����ID, "ƥ�����ݿ���Ŀ", 0))).value = True
        
        chkAutoSendWorkList.value = Val(GetDeptPara(mlng����ID, "����ʱ�Զ�����WorkList", "1"))
        chkAddons.value = Val(GetDeptPara(mlng����ID, "��ʾ��������", "1"))
        chkReagent.value = Val(GetDeptPara(mlng����ID, "��ʾ��Ӱ��", "1"))
        chkSetFocusWithReport.value = Val(GetDeptPara(mlng����ID, "����л�ʱ��λ����༭", "1"))
        chkNameFuzzySearch.value = Val(GetDeptPara(mlng����ID, "����Ĭ��ģ����ѯ", "1"))
        chkNameQueryTimeLimit.value = Val(GetDeptPara(mlng����ID, "������ѯʱ������", "1"))
        
        chkPreView.value = IIF(Val(GetDeptPara(mlng����ID, "����ͼԤ����ʽ", "0")) > 0, 1, 0)
        
        If chkPreView.value = 1 Then
            optMovePreview.Enabled = True
            lblDelayTime.Enabled = True
            txtDelayTime.Enabled = True
            optClickPreview.Enabled = True
        Else
            optMovePreview.Enabled = False
            lblDelayTime.Enabled = False
            txtDelayTime.Enabled = False
            optClickPreview.Enabled = False
        End If
        
        optMovePreview.value = Val(GetDeptPara(mlng����ID, "����ͼԤ����ʽ", "0")) = 1
        optClickPreview.value = Val(GetDeptPara(mlng����ID, "����ͼԤ����ʽ", "0")) = 2
        txtDelayTime.Text = Val(GetDeptPara(mlng����ID, "�ƶ�Ԥ����ʱ", "2"))
        
        If Val(GetDeptPara(mlng����ID, "ҽ��վ�鿴����", "1")) = 0 Then
            cboViewReport.ListIndex = 0
        Else
            cboViewReport.ListIndex = 1
        End If
        
        OptCode(Val(GetDeptPara(mlng����ID, "���߼��ű��ֲ���", 0))).value = True
        OptUnicode(Val(GetDeptPara(mlng����ID, "���ű��ֲ������", 0))).value = True
        optUsePatientID.value = Val(GetDeptPara(mlng����ID, "ʹ�û��ߺ�", 0))
        OptBuildcode(Val(GetDeptPara(mlng����ID, "�������ɷ�ʽ", 0))).value = True
        optUseAdviceID.value = Val(GetDeptPara(mlng����ID, "ʹ��ҽ����", 0))
        
        '���ű������
        strTemp = GetDeptPara(mlng����ID, "����ǰ׺", "")
        If strTemp = "" Then
            '��ʹ��ǰ׺
            chkPreText.value = 0
        Else
            'ʹ��ǰ׺
            chkPreText.value = 1
            If strTemp = "1" Then
                optPreText(0).value = 1
                txtPreText.Text = ""
            Else
                optPreText(1).value = 1
                txtPreText.Text = strTemp
            End If
        End If
        
        strTemp = GetDeptPara(mlng����ID, "���ŷָ���1", "")
        strTemp = Left(strTemp, 1) 'ֻȡһ���ַ�
        Call setCheckNoDelimeter(1, strTemp)
        
        strTemp = GetDeptPara(mlng����ID, "���ŷָ���2", "")
        strTemp = Left(strTemp, 1) 'ֻȡһ���ַ�
        Call setCheckNoDelimeter(2, strTemp)
        
        lngTemp = Val(GetDeptPara(mlng����ID, "������", 0))
        chkYear.value = IIF(lngTemp = 0, 0, 1)
        optYear(0).value = IIF((lngTemp = 1 Or lngTemp = 0), 1, 0)
        optYear(1).value = IIF(lngTemp = 2, 1, 0)
        
        chkMonth.value = IIF(Val(GetDeptPara(mlng����ID, "������", 0)) = 1, 1, 0)
        chkDay.value = IIF(Val(GetDeptPara(mlng����ID, "������", 0)) = 1, 1, 0)
        
        txtStartNum.Text = Val(GetDeptPara(mlng����ID, "������ʼ��", 1))
        lngTemp = Val(GetDeptPara(mlng����ID, "���Ź̶�λ��", 0))
        chkFixedLen.value = IIF(lngTemp = 0, 0, 1)
        txtFixedLen.Text = IIF(lngTemp = 0, "", lngTemp)
        
        '���ü������õĲ�����ؿ�����
        Call ConfigAppNoState
        
        chkUseReferencePatient.value = Val(GetDeptPara(mlng����ID, "������������", 0))
        chkImgShowDesc.value = Val(GetDeptPara(mlng����ID, "ͼ������ʾ", 0))
        
        If Len(GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "����ͼ��ǩ����֤")) > 0 Then
            chkImageSignVal.value = IIF(GetSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "����ͼ��ǩ����֤", "0") = "1", 1, 0)
        Else
            chkImageSignVal.value = Val(GetDeptPara(mlng����ID, "ͼ��ǩ����֤", 0))
        End If
    
        chkPrintNeedComplete.value = Val(GetDeptPara(mlng����ID, "ƽ������˲��ܴ򱨸�", 0))
        
        'ƴ��������
        optCapital(Val(GetDeptPara(mlng����ID, "ƴ������Сд", 0))).value = True
        optSplitter(Val(GetDeptPara(mlng����ID, "ƴ�����ָ���", 0))).value = True
        
        Call LoadDevice
        
        mblnLoading = False
        Exit Sub
err:
        If ErrCenter() = 1 Then Resume Next
        Call SaveErrLog
        mblnLoading = False
    End Sub

    
    Private Function GetDeptPara(ByVal lngDeptID As Long, ByVal varPara As String, Optional ByVal strDefault As String, Optional ByVal blnNotCache As Boolean) As String
    '���ܣ���ȡָ���Ĳ���ֵ
    '������lngDept=����ID
    '      varPara=������
    '      strDefault=�����ݿ���û�иò���ʱʹ�õ�ȱʡֵ(ע�ⲻ��Ϊ��ʱ)
    '      blnNotCache=�Ƿ񲻴ӻ����ж�ȡ
    '���أ�����ֵ���ַ�����ʽ
        Dim rsTmp As ADODB.Recordset
        Dim strSql As String, blnNew As Boolean
        
        On Error GoTo errH
        
        If blnNotCache Then
            Set rsTmp = New ADODB.Recordset
            strSql = "Select ����ֵ from Ӱ�����̲��� where ����ID = [1] and ������=[2]"
            Set rsTmp = zlDatabase.OpenSQLRecord(strSql, "��ȡ����", lngDeptID, varPara)
            
            If Not rsTmp.EOF Then
                GetDeptPara = NVL(rsTmp!����ֵ)
            Else
                GetDeptPara = strDefault
            End If
        Else
            '��һ�μ��ز�������
            If mrsDeptParas Is Nothing Then
                blnNew = True
            ElseIf mrsDeptParas.State = 0 Then
                blnNew = True
            End If
            If blnNew Then
                strSql = "Select ����ֵ,������,����ID from Ӱ�����̲���"
                Set mrsDeptParas = New ADODB.Recordset
                Set mrsDeptParas = zlDatabase.OpenSQLRecord(strSql, "��ȡ����")
            End If
            
            '���ݻ����ȡ����ֵ
            mrsDeptParas.Filter = "������='" & CStr(varPara) & "' AND ����ID=" & lngDeptID
            If Not mrsDeptParas.EOF Then
                GetDeptPara = NVL(mrsDeptParas!����ֵ)
            Else
                GetDeptPara = strDefault
            End If
        End If
        Exit Function
errH:
        If ErrCenter() = 1 Then Resume
    End Function

    Private Sub LoadDevice()
    '�����豸�����뵥�豸��PDFת���豸
        Dim strSql As String
        Dim rsTemp As ADODB.Recordset
        Dim str�豸�� As String
        Dim strPDF As String
        
        
        chkPDF.value = 0
        On Error GoTo errH
        strSql = "Select �豸��,�豸�� From Ӱ���豸Ŀ¼ Where ����=1 and NVL(״̬,0)=1"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSql, Me.Caption)
        If rsTemp.EOF Then
            MsgBox "δ�������뵥�洢�豸���뵽Ӱ���豸Ŀ¼�����ã�", vbInformation, gstrSysName
            Exit Sub
        Else
            cboSaveDevice.AddItem ""
            Call cboPDF.AddItem("")
            
            str�豸�� = GetDeptPara(mlng����ID, "���뵥�洢�豸��", "")
            strPDF = GetDeptPara(mlng����ID, "PDFת���洢�豸", "")
            
            Do While Not rsTemp.EOF
                cboSaveDevice.AddItem rsTemp!�豸�� & "-" & NVL(rsTemp!�豸��)
                cboPDF.AddItem rsTemp!�豸�� & "-" & NVL(rsTemp!�豸��)
                
                If cboSaveDevice.ListIndex = -1 Then
                    If str�豸�� = rsTemp!�豸�� Then
                        cboSaveDevice.ListIndex = cboSaveDevice.NewIndex
                    End If
                End If
                
                If cboPDF.ListIndex = -1 Then
                    If strPDF = rsTemp!�豸�� Then
                        cboPDF.ListIndex = cboPDF.NewIndex
                        chkPDF.value = 1
                        cboPDF.Enabled = True
                    ElseIf strPDF = "" Then
                        cboPDF.ListIndex = 0
                        cboPDF.Enabled = False
                    End If
                End If
                rsTemp.MoveNext
            Loop
        End If
        Exit Sub
errH:
        MsgBox err.Description, vbCritical, Me.Caption
    End Sub

    Private Function GetUserInfo() As Boolean
    '���ܣ���ȡ��½�û���Ϣ
        Dim rsTmp As New ADODB.Recordset
        
        Set rsTmp = zlDatabase.GetUserInfo
        
        UserInfo.�û��� = gstrDbUser
        UserInfo.���� = gstrDbUser
        If Not rsTmp.EOF Then
            UserInfo.ID = rsTmp!ID
            UserInfo.��� = rsTmp!���
            UserInfo.����ID = IIF(IsNull(rsTmp!����ID), 0, rsTmp!����ID)
            UserInfo.���� = IIF(IsNull(rsTmp!����), "", rsTmp!����)
            UserInfo.���� = IIF(IsNull(rsTmp!����), "", rsTmp!����)
            UserInfo.�û��� = IIF(IsNull(rsTmp!�û���), "", rsTmp!�û���)
            GetUserInfo = True
        End If
        Exit Function
errH:
        If ErrCenter() = 1 Then Resume
        Call SaveErrLog
    End Function
    

    Private Function GetUser����IDs(Optional ByVal bln���� As Boolean) As String
    '���ܣ���ȡ����Ա�����Ŀ���(�������ڿ���+�������������Ŀ���),�����ж��
    '�������Ƿ�ȡ���������µĿ���
        Dim rsTmp As New ADODB.Recordset
        Dim strSql As String, i As Long
        
        strSql = "Select ����ID From ������Ա Where ��ԱID=[1]"
        If bln���� Then
            strSql = strSql & " Union" & _
                " Select Distinct B.����ID From ������Ա A,��λ״����¼ B" & _
                " Where A.����ID=B.����ID And A.��ԱID=[1]"
        End If
        
        On Error GoTo errH
        Set rsTmp = zlDatabase.OpenSQLRecord(strSql, "mdlCISWork", UserInfo.ID)
        For i = 1 To rsTmp.RecordCount
            GetUser����IDs = GetUser����IDs & "," & rsTmp!����ID
            rsTmp.MoveNext
        Next
        GetUser����IDs = Mid(GetUser����IDs, 2)
        Exit Function
errH:
        If ErrCenter() = 1 Then Resume
        Call SaveErrLog
    End Function


    Private Function subInitDepartInfo()
    '���������
        Dim rsTmp As New ADODB.Recordset
        Dim strSql As String, i As Long
        Dim str����IDs As String
        Dim strDepartment() As String
        Dim intCurDept As Integer
        
        On Error GoTo errH
        
        If InStr(mstrPrivs, "���п���") > 0 Then
            strSql = _
                " Select Distinct A.ID,A.����,A.����" & _
                " From ���ű� A,��������˵�� B " & _
                " Where B.����ID = A.ID " & _
                " And (A.����ʱ��=TO_DATE('3000-01-01','YYYY-MM-DD') Or A.����ʱ�� is NULL) " & _
                " And B.�������� IN('���')  Order by A.����"
        Else
            strSql = _
                " Select Distinct A.ID,A.����,A.����" & _
                " From ���ű� A,��������˵�� B,������Ա C " & _
                " Where B.����ID = A.ID And A.ID=C.����ID And C.��ԱID=" & UserInfo.ID & _
                " And (A.����ʱ��=TO_DATE('3000-01-01','YYYY-MM-DD') Or A.����ʱ�� is NULL) " & _
                " And B.�������� IN('���')  Order by A.����"
        End If
         
        Set rsTmp = zlDatabase.OpenSQLRecord(strSql, Me.Caption)
        
        If rsTmp.EOF Then
            MsgBox "û�з���ҽ��������Ϣ,���ȵ����Ź��������á�", vbInformation, gstrSysName
            Exit Function
        Else
            str����IDs = GetUser����IDs
            Do Until rsTmp.EOF
                mstrCanUse���� = mstrCanUse���� & "|" & rsTmp!ID & "_" & rsTmp!���� & "-" & rsTmp!����
                If rsTmp!ID = UserInfo.����ID Then mlngCur����ID = rsTmp!ID: mstrCur���� = rsTmp!���� & "-" & rsTmp!���� '��ȡĬ�Ͽ���
                If InStr("," & str����IDs & ",", "," & rsTmp!ID & ",") > 0 And mlngCur����ID = 0 Then mlngCur����ID = rsTmp!ID: mstrCur���� = rsTmp!���� & "-" & rsTmp!���� 'û��Ĭ�Ͽ���,ȡ���������ҵ�һ��
                rsTmp.MoveNext
            Loop
            
            str����IDs = GetUser����IDs
            Do Until rsTmp.EOF
                mstrCanUse���� = mstrCanUse���� & "|" & rsTmp!ID & "_" & rsTmp!���� & "-" & rsTmp!����
                If rsTmp!ID = UserInfo.����ID Then mlngCur����ID = rsTmp!ID: mstrCur���� = rsTmp!���� & "-" & rsTmp!���� '��ȡĬ�Ͽ���
                If InStr("," & str����IDs & ",", "," & rsTmp!ID & ",") > 0 And mlngCur����ID = 0 Then mlngCur����ID = rsTmp!ID: mstrCur���� = rsTmp!���� & "-" & rsTmp!���� 'û��Ĭ�Ͽ���,ȡ���������ҵ�һ��
                rsTmp.MoveNext
            Loop
            mstrCanUse���� = Mid(mstrCanUse����, 2)
            If InStr(mstrPrivs, "���п���") > 0 And mlngCur����ID = 0 Then
                mlngCur����ID = Split(Split(mstrCanUse����, "|")(0), "_")(0)
                mstrCur���� = Split(Split(mstrCanUse����, "|")(0), "_")(1)
            End If
            
            If mlngCur����ID = 0 And InStr(mstrPrivs, "���п���") <= 0 Then 'û�����п��Ҳ���Ȩ��,���Ҳ����߿��Ҳ����ڼ�������
                MsgBox "û�з�������������,����ʹ��ҽ������վ��", vbInformation, gstrSysName
                Exit Function
            End If
            
            '���cmbDept
            cmbDept.Clear
            intCurDept = -1
            strDepartment = Split(mstrCanUse����, "|")
            For i = 0 To UBound(strDepartment)
                cmbDept.AddItem Split(strDepartment(i), "_")(1)
                cmbDept.ItemData(cmbDept.ListCount - 1) = Split(strDepartment(i), "_")(0)
                If Split(strDepartment(i), "_")(0) = mlngCur����ID Then
                    intCurDept = i
                End If
            Next i
            If intCurDept <> -1 Then
                cmbDept.ListIndex = intCurDept
            Else
                cmbDept.ListIndex = 0
            End If
            mlng����ID = cmbDept.ItemData(cmbDept.ListIndex)
            
            subInitDepartInfo = True
        End If
        
        
        Exit Function
errH:
        If ErrCenter() = 1 Then Resume
        Call SaveErrLog
    End Function

Private Function GetEncryptionPassW(ByVal strPswd As String) As String
'��ȡ��������
    Dim strEncryptionPassW As String
    
    If strPswd = "" Then Exit Function
    
    strEncryptionPassW = EncryptionPassW(Trim(strPswd))
    strEncryptionPassW = Mid(strEncryptionPassW, 1, 1) & "��" & Mid(strEncryptionPassW, 2)
    strEncryptionPassW = "��" & strEncryptionPassW & "��"
    strEncryptionPassW = Replace(strEncryptionPassW, "'", "''")
    
    GetEncryptionPassW = strEncryptionPassW
End Function

Private Function GetDecryptionPassW(ByVal strPswd As String) As String
'��ȡ��������
    Dim strDecryptionPassW As String
    
    GetDecryptionPassW = strPswd
    
    If Len(strPswd) >= 3 Then
        If Mid(strPswd, 1, 1) & Mid(strPswd, 3, 1) & Mid(strPswd, Len(strPswd), 1) = "�����" Then
            strDecryptionPassW = Mid(strPswd, 2)
            strDecryptionPassW = Mid(strDecryptionPassW, 1, Len(strDecryptionPassW) - 1)
            strDecryptionPassW = Mid(strDecryptionPassW, 1, 1) & Mid(strDecryptionPassW, 3)
            strDecryptionPassW = DecryptionPassW(strDecryptionPassW)
            
            GetDecryptionPassW = strDecryptionPassW
        End If
    End If
End Function

Private Function GetRandom(ByVal lngBase As Long) As String
    Dim lngNum As Long
    
    Randomize 99
    
    lngNum = Fix(Rnd * lngBase)
    
    If lngNum <= 0 Then lngNum = 1
    
    GetRandom = Chr(lngNum)
End Function

'��ȡ��������
Private Function EncryptionPassW(ByVal strPassW As String) As String
    Dim i As Integer
    Dim lngAsc  As Long
    Dim strTemp() As String
    Dim lngPassWLength As Integer
    Dim strRandom As String
    Dim strBase As String
        
    i = 0
    
    lngPassWLength = Len(strPassW)
    
    strBase = GetRandom(30)
    strRandom = GetRandom(30)
    
    ReDim intASC(0 To lngPassWLength - 1), strTemp(0 To lngPassWLength - 1)
     
    Do While i < lngPassWLength
        lngAsc = Asc(Mid(strPassW, i + 1, 1))
        lngAsc = lngAsc Xor Asc(strBase) Xor Asc(strRandom)
        strTemp(i) = Chr(lngAsc)
        i = i + 1
    Loop
    
    EncryptionPassW = strBase & Join(strTemp, "") & strRandom '���ܺ���ִ�
End Function

'��ȡ��������
Private Function DecryptionPassW(ByVal strPassW As String) As String
    Dim i As Integer
    Dim lngAsc  As Integer
    Dim strTemp() As String
    Dim lngPassWLength As Integer
    Dim lngBase As Long
    Dim strRandom As String
    Dim strPassSouce As String

    i = 0
    
    strPassSouce = Mid(strPassW, 2, Len(strPassW) - 2)
    lngPassWLength = Len(strPassSouce)
    lngBase = Asc(Mid(strPassW, 1, 1))
    
    strRandom = Right(strPassW, 1)
    
    ReDim intASC(0 To lngPassWLength - 1), strTemp(0 To lngPassWLength - 1)
    
    Do While i < lngPassWLength
        lngAsc = Asc(Mid(strPassSouce, i + 1, 1))
        lngAsc = lngAsc Xor Asc(strRandom) Xor lngBase
        strTemp(i) = Chr(lngAsc)
        i = i + 1
    Loop

    DecryptionPassW = Join(strTemp, "") '���ܺ���ִ�
End Function

Private Sub optImageDblClick_Click(Index As Integer)
    If Index = 1 Then
        If chkPreText.value = 1 And optClickPreview.value Then
            MsgBox "���Ѿ����á���굥��ʱԤ��ͼ�񡯣�������ͼ˫�����ͼ��༭�Ĺ����غϣ���������ͼ˫����Ĺ���ѡ��ֱ��д�뱨��", vbOKOnly, "��ʾ��Ϣ"
        End If
    End If
End Sub

'Private Sub optBigImgAction_Click(Index As Integer)
'    If Index = 3 Then optImageDblClick(0).value = True
'End Sub

Private Sub optClickPreview_Click()
    If optClickPreview.value Then optImageDblClick(0).value = True
    
    If optMovePreview.value = False Then
        txtDelayTime.Enabled = False
        lblDelayTime.Enabled = False
    End If
End Sub

Private Sub LoadPathol()
    With lst(lst_PatholInfo)
        .AddItem "�걾����", 0
        .AddItem "ȡ��λ��", 1
        .AddItem "��״", 2
        .AddItem "������", 3
        .AddItem "��Ƭ��", 4
        .AddItem "��ȡҽʦ", 5
        .AddItem "ȡ��ʱ��", 6
        .AddItem "����", 7
        .AddItem "��ɫ", 8
        .AddItem "�걾��", 9
    End With
End Sub

'��ʼ�����ŷָ�������������ַ���֧�ּ����е����е��ֽڷ��ţ�����˫���ź͵�����֮�⡣
Private Sub LoadCheckNoDelimeter()
    Dim i As Integer
    
    For i = 1 To 2
        cboDelimeter(i).Clear
        cboDelimeter(i).AddItem "~"
        cboDelimeter(i).AddItem "`"
        cboDelimeter(i).AddItem "!"
        cboDelimeter(i).AddItem "@"
        cboDelimeter(i).AddItem "#"
        cboDelimeter(i).AddItem "$"
        cboDelimeter(i).AddItem "%"
        cboDelimeter(i).AddItem "^"
        cboDelimeter(i).AddItem "&"
        cboDelimeter(i).AddItem "*"
        cboDelimeter(i).AddItem "("
        cboDelimeter(i).AddItem ")"
        cboDelimeter(i).AddItem "_"
        cboDelimeter(i).AddItem "-"
        cboDelimeter(i).AddItem "+"
        cboDelimeter(i).AddItem "="
        cboDelimeter(i).AddItem "{"
        cboDelimeter(i).AddItem "}"
        cboDelimeter(i).AddItem "["
        cboDelimeter(i).AddItem "]"
        cboDelimeter(i).AddItem "\"
        cboDelimeter(i).AddItem "|"
        cboDelimeter(i).AddItem ";"
        cboDelimeter(i).AddItem ":"
        cboDelimeter(i).AddItem ","
        cboDelimeter(i).AddItem "<"
        cboDelimeter(i).AddItem ">"
        cboDelimeter(i).AddItem "."
        cboDelimeter(i).AddItem "/"
        cboDelimeter(i).AddItem "?"
    Next i
    
End Sub

'���ü��ŷָ���������
Private Sub setCheckNoDelimeter(lngIndex As Long, strText As String)
    On Error GoTo err
    
    cboDelimeter(lngIndex).Text = strText
    chkDelimiter(lngIndex).value = 1
    
    Exit Sub
err:
    '�����ֵʧ�ܣ���ȡ���ָ�����ѡ��
    cboDelimeter(lngIndex).ListIndex = -1
    chkDelimiter(lngIndex).value = 0
End Sub

Private Sub loadScheduleDevice()
'------------------------------------------------
'���ܣ�װ��ԤԼ�豸
'��������
'���أ���
'------------------------------------------------
    Dim strSql As String
    Dim rsTemp As ADODB.Recordset
    Dim i As Integer
    Dim lngDeviceID As Long
    
    On Error GoTo err
    
    strSql = "select ID,�豸����,Ӱ�����,�Ƿ����� from Ӱ��ԤԼ�豸 order by Ӱ�����"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "����ԤԼ�豸")
    
    With vsfScheduleDevice
        .Rows = rsTemp.RecordCount + 2
        .Cols = 4
        .FixedRows = 2
        .FixedCols = 0
        .AllowUserResizing = flexResizeColumns
        .SelectionMode = flexSelectionByRow
        .Editable = flexEDKbdMouse
        .ScrollBars = flexScrollBarVertical
        .CellAlignment = flexAlignLeftCenter
        .Cell(flexcpAlignment, 0, 0, 0, 2) = flexAlignCenterCenter
        .ExtendLastCol = True
        .RowHeight(0) = 350
        .ColWidth(col_SchDevice_ID) = 50
        .ColWidth(col_SchDevice_�豸����) = 2500
        .ColWidth(col_SchDevice_Ӱ�����) = 500
        .ColWidth(col_SchDevice_�Ƿ�����) = 500
        
        '�ϲ���һ��
        .MergeCellsFixed = flexMergeFree
        .MergeRow(0) = True
        For i = 0 To 3
            .TextMatrix(0, i) = "ԤԼ�豸"
        Next i
        
        '�ڶ�����ʾ����
        .TextMatrix(1, col_SchDevice_�Ƿ�����) = "����"
        .TextMatrix(1, col_SchDevice_�豸����) = "�豸����"
        .TextMatrix(1, col_SchDevice_Ӱ�����) = "���"
        .RowHeight(1) = 300
        
        '�����ݿ��������
        For i = 1 To rsTemp.RecordCount
            .TextMatrix(i + 1, col_SchDevice_ID) = rsTemp!ID
            .TextMatrix(i + 1, col_SchDevice_�豸����) = rsTemp!�豸����
            .TextMatrix(i + 1, col_SchDevice_Ӱ�����) = rsTemp!Ӱ�����
            .Cell(flexcpChecked, i + 1, col_SchDevice_�Ƿ�����) = IIF(NVL(rsTemp!�Ƿ�����, 0) = 1, 1, 2)
            rsTemp.MoveNext
        Next i
        
        '���غ�̨������
        .ColHidden(col_SchDevice_ID) = True
        
        '����ѡ�е�һ�У�װ�ض�Ӧ��ԤԼ����
        If .Rows > 2 Then
            
            lngDeviceID = CLng(.TextMatrix(2, col_SchDevice_ID))
        End If
        Call loadSchedulePlan(lngDeviceID)
        
    End With
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub loadSchedulePlan(lngSchduleDeviceID As Long)
'------------------------------------------------
'���ܣ�װ��ԤԼ����
'������lngSchduleDeviceID  -- ԤԼ�豸ID
'���أ���
'------------------------------------------------
    Dim strSql As String
    Dim rsTemp As ADODB.Recordset
    Dim i As Integer
    Dim lngPlanID As Long
    
    On Error GoTo err
    
    strSql = "select ID,��������,��������,�Ƿ�����,��������,�Ƿ�������Ϣ,���,��ʼʱ�� from Ӱ��ԤԼ���� where ԤԼ�豸ID=[1] order by ID"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "����ԤԼ����", lngSchduleDeviceID)
    
    With vsfSchedulePlan
        .Rows = rsTemp.RecordCount + 2
        .Cols = 8
        .FixedRows = 2
        .FixedCols = 0
        .AllowUserResizing = flexResizeColumns
        .SelectionMode = flexSelectionByRow
        .Editable = flexEDKbdMouse
        .ScrollBars = flexScrollBarVertical
        .CellAlignment = flexAlignLeftCenter
        .Cell(flexcpAlignment, 0, 0, 0, 3) = flexAlignCenterCenter
        .ExtendLastCol = True
        .RowHeight(0) = 350
        .ColWidth(col_SchPlan_ID) = 50
        .ColWidth(col_SchPlan_��������) = 50
        .ColWidth(col_SchPlan_�Ƿ�����) = 500
        .ColWidth(col_SchPlan_��������) = 800
        .ColWidth(col_SchPlan_��������) = 50
        .ColWidth(col_SchPlan_���) = 50
        .ColWidth(col_SchPlan_�Ƿ�������Ϣ) = 50
        .ColWidth(col_SchPlan_��ʼʱ��) = 50
        
        '�ϲ���һ��
        .MergeCellsFixed = flexMergeFree
        .MergeRow(0) = True
        For i = 0 To 7
            .TextMatrix(0, i) = "ԤԼ����"
        Next i
        
        '�ڶ���
        .TextMatrix(1, col_SchPlan_�Ƿ�����) = "����"
        .TextMatrix(1, col_SchPlan_��������) = "��������"
        .RowHeight(1) = 300
        
        '�����ݿ��������
        For i = 1 To rsTemp.RecordCount
            .TextMatrix(i + 1, col_SchPlan_ID) = rsTemp!ID
            .TextMatrix(i + 1, col_SchPlan_��������) = rsTemp!��������
            If (.TextMatrix(i + 1, col_SchPlan_��������) = Sch_PlanType_һ��) Then
                'һ�췽��������ʾ���õĹ�ѡ�Ĭ��ֱ������
                .TextMatrix(i + 1, col_SchPlan_�Ƿ�����) = ""
                .Cell(flexcpChecked, i + 1, col_SchPlan_�Ƿ�����) = 0
            Else
                .Cell(flexcpChecked, i + 1, col_SchPlan_�Ƿ�����) = IIF(NVL(rsTemp!�Ƿ�����, 0) = 1, 1, 2)
            End If
            .TextMatrix(i + 1, col_SchPlan_��������) = rsTemp!��������
            .TextMatrix(i + 1, col_SchPlan_��������) = NVL(rsTemp!��������)
            .TextMatrix(i + 1, col_SchPlan_���) = NVL(rsTemp!���, 0)
            .TextMatrix(i + 1, col_SchPlan_�Ƿ�������Ϣ) = rsTemp!�Ƿ�������Ϣ
            .TextMatrix(i + 1, col_SchPlan_��ʼʱ��) = NVL(rsTemp!��ʼʱ��, Format(Now, "YYYY-MM-DD"))
            rsTemp.MoveNext
        Next i
        
        '���غ�̨������
        .ColHidden(col_SchPlan_ID) = True
        .ColHidden(col_SchPlan_��������) = True
        .ColHidden(col_SchPlan_��������) = True
        .ColHidden(col_SchPlan_���) = True
        .ColHidden(col_SchPlan_�Ƿ�������Ϣ) = True
        .ColHidden(col_SchPlan_��ʼʱ��) = True
        
        '��ʾʱ�䷽��
        If .Rows > 2 Then
            lngPlanID = CLng(.TextMatrix(2, col_SchPlan_ID))
        End If
        
        Call vsfSchedulePlan_Click
        
    End With
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub vsfScheduleDevice_AfterEdit(ByVal Row As Long, ByVal Col As Long)
    Dim strSql As String
    Dim lngSchDeviceID As Long
    Dim lngEnableDevice As Long
    
    On Error GoTo err
    
    With vsfScheduleDevice
        If Col = col_SchDevice_�Ƿ����� Then
            If .Cell(flexcpChecked, Row, col_SchDevice_�Ƿ�����) = 1 Then
                '�����ˡ����á�
                lngEnableDevice = 1
            Else
                'ȡ������
                lngEnableDevice = 0
            End If
            'ֱ�ӱ�������
            lngSchDeviceID = .TextMatrix(Row, col_SchDevice_ID)
            strSql = "Zl_Ӱ��ԤԼ�豸_�༭(" & lngSchDeviceID & ",null,null,null,null,null," & lngEnableDevice & ",4)"
            zlDatabase.ExecuteProcedure strSql, "���ü��ԤԼ�豸"
            
            'ˢ������
            'Call loadScheduleDevice
        End If
    End With
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub vsfScheduleDevice_BeforeEdit(ByVal Row As Long, ByVal Col As Long, Cancel As Boolean)
    If Col <> col_SchDevice_�Ƿ����� Then
        Cancel = True
    End If
End Sub

Private Sub vsfScheduleDevice_Click()
    Dim lngDeviceID As Long
    
    If vsfScheduleDevice.RowSel > 0 And vsfScheduleDevice.Rows > 2 Then
        
        lngDeviceID = CLng(vsfScheduleDevice.TextMatrix(vsfScheduleDevice.RowSel, 0))
        Call loadSchedulePlan(lngDeviceID)
    End If
End Sub

Private Sub vsfSchedulePlan_AfterEdit(ByVal Row As Long, ByVal Col As Long)
    Dim strSql As String
    Dim lngSchPlanID As Long
    Dim lngEnablePlan As Long
    Dim lngPlanType As Long
    Dim i As Integer
    
    On Error GoTo err
    
    With vsfSchedulePlan
        If Col = col_SchPlan_�Ƿ����� Then
            If .Cell(flexcpChecked, Row, col_SchPlan_�Ƿ�����) = 0 Then
                Exit Sub
            ElseIf .Cell(flexcpChecked, Row, col_SchPlan_�Ƿ�����) = 1 Then
                '�����ˡ����á�,���ж��Ƿ���Ը���
                '������BeforeEdit�¼��У����ȡ�����ģ��ᵼ�����BeforeEdit�¼����������Σ�����ʹ��AfterEdit������
                lngPlanType = .TextMatrix(Row, col_SchPlan_��������)
                '��������ã������ж��Ƿ��Ѿ�������һ���Ѿ����õķ�����������ڣ�����ʾ�û��Ƿ����ñ�������
                For i = 1 To .Rows - 1
                    If .Cell(flexcpChecked, i, col_SchPlan_�Ƿ�����) = 1 And i <> Row Then
                        If (lngPlanType <> Sch_PlanType_ÿ��) _
                            Or (lngPlanType = Sch_PlanType_ÿ�� And (.TextMatrix(i, col_SchPlan_��������) <> Sch_PlanType_ÿ��)) Then
                            'ÿ�ܷ������������ö������
                            .Cell(flexcpChecked, Row, Col) = 2
                            If MsgBox("��������" & .TextMatrix(i, col_SchPlan_��������) & "��������״̬���Ƿ�ͣ�ô˷����������·�����", vbOKCancel, "���ԤԼ��ʾ") = vbCancel Then
                                Exit Sub
                            End If
                        End If
                    End If
                Next i
                .Cell(flexcpChecked, Row, Col) = 1
                lngEnablePlan = 1
            Else
                'ȡ������
                lngEnablePlan = 0
            End If
            'ֱ�ӱ�������
            lngSchPlanID = .TextMatrix(Row, col_SchPlan_ID)
            strSql = "Zl_Ӱ��ԤԼ����_����(" & lngSchPlanID & "," & lngEnablePlan & ")"
            zlDatabase.ExecuteProcedure strSql, "���ü��ԤԼ����"
            
            'ˢ������
            Call loadSchedulePlan(vsfScheduleDevice.TextMatrix(vsfScheduleDevice.RowSel, col_SchDevice_ID))
        End If
    End With
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub vsfSchedulePlan_BeforeEdit(ByVal Row As Long, ByVal Col As Long, Cancel As Boolean)
    If Col = col_SchPlan_�Ƿ����� Then
        If vsfSchedulePlan.Cell(flexcpChecked, Row, col_SchPlan_�Ƿ�����) = 0 Then
            Cancel = True
        End If
    Else
        Cancel = True
    End If
End Sub

Private Sub vsfSchedulePlan_Click()
    Dim lngSchedulePlanID As Long
    
    With vsfSchedulePlan
        If .RowSel > 0 And .Rows > 2 Then
            lngSchedulePlanID = CLng(.TextMatrix(.RowSel, col_SchPlan_ID))
            '����ԤԼʱ��ƻ�
            Call loadTimePlan(lngSchedulePlanID)
            '����ԤԼ��������
            Call loadSchPlanContent(CLng(.TextMatrix(.RowSel, col_SchPlan_��������)), _
                .TextMatrix(.RowSel, col_SchPlan_��������), CLng(.TextMatrix(.RowSel, col_SchPlan_���)), _
                IIF(.TextMatrix(.RowSel, col_SchPlan_�Ƿ�������Ϣ) = 1, True, False), _
                Format(.TextMatrix(.RowSel, col_SchPlan_��ʼʱ��), "YYYY-MM-DD"))
            Else
                Call loadTimePlan(0)
        End If
    End With
End Sub

Private Sub loadTimePlan(lngSchedulePlanID As Long)
'------------------------------------------------
'���ܣ�װ��ԤԼʱ���
'������lngSchedulePlanID -- ԤԼ����ID
'���أ���
'------------------------------------------------
    
    On Error GoTo err
    
    Call SchTimeTable.RefreshTimeProject(lngSchedulePlanID)
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub loadSchPlanContent(lngSchPlanType As Long, strSchPlanContent As String, _
    lngSchPlanInterval As Long, blnUseSchCalendar As Boolean, dtStartTime As Date)
'------------------------------------------------
'���ܣ�װ��ԤԼ��������
'������ lngSchPlanType -- ԤԼ��������
'       strSchPlanContent -- ԤԼ��������
'       lngSchPlanInterval -- ԤԼʱ����
'       blnUseSchCalendar -- �Ƿ�ԤԼ������Ϣ
'       dtStartTime -- ��ʼʱ��
'���أ���
'------------------------------------------------
    Dim i As Integer
    
    On Error GoTo err
    
    tabSchPlanContent.Tab = lngSchPlanType - 1
    If lngSchPlanType = Sch_PlanType_ÿ�� Then
        dpSchPlanStartTime(0).value = dtStartTime
        txtSchDayInterval = lngSchPlanInterval
    ElseIf lngSchPlanType = Sch_PlanType_ÿ�� Then
        dpSchPlanStartTime(1).value = dtStartTime
        txtSchWeekInterval = lngSchPlanInterval
        chkSchUseCanlendar.value = IIF(blnUseSchCalendar = True, 1, 0)
        For i = 1 To 7
            chkSchWeek(i).value = 0
        Next i
        For i = 1 To Len(strSchPlanContent)
            chkSchWeek(Mid(strSchPlanContent, i, 1)).value = 1
        Next i
    ElseIf lngSchPlanType = Sch_PlanType_ÿ�� Then
        'û�д���
    ElseIf lngSchPlanType = Sch_PlanType_һ�� Then
        dpSchOneday.ClearSelection
        Call dpSchOneday.Select(Left(strSchPlanContent, 4) & "-" & Mid(strSchPlanContent, 5, 2) & "-" & Right(strSchPlanContent, 2))
        dpSchOneday.EnsureVisibleSelection
    End If
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub SchedulePlanUpdate(lngActionType As Long)
'------------------------------------------------
'���ܣ��������޸�ԤԼ����
'������ lngActionType --- 1-������2-�޸�
'���أ���
'------------------------------------------------
    Dim lngPlanType As Long     '�������ͣ�1-ÿ�죻2-ÿ�ܣ�3-ÿ�£�4-һ��
    Dim i As Integer
    Dim strContent As String
    Dim blnUseCalendar As Boolean
    Dim strSql As String
    Dim lngSchDeviceID As Long
    Dim strPlanName As String
    Dim lngInterval As Long
    Dim lngPlanID As Long
    Dim strDuplicateDay As String
    Dim dtStartTime As Date
    
    On Error GoTo err
    
    '���û��ԤԼ�豸����ֱ���˳�
    If vsfScheduleDevice.Rows <= 2 Or vsfScheduleDevice.RowSel < 1 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    '���û��ԤԼ��������ֱ���˳�
    If lngActionType = 2 And vsfSchedulePlan.Rows <= 2 Or vsfSchedulePlan.RowSel < 1 Then
        MsgBox "����ѡ��һ��ԤԼ������", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    'ȷ���������ƺ�����
    '��¼��������
    '1�� ����=1ÿ�죬Ϊ��
    '2�� ����=2ÿ�ܣ�Ϊ7���ַ������֣�������һ�����壬Ϊ��12345������һ������Ϊ��17��
    '3�� ����=3ÿ�£�Ϊ�գ��顰Ӱ��ԤԼÿ���Űࡱ���ȡÿ����Ϣ����Ϣ��
    '4�� ����=4һ�죬Ϊ���ڣ����硰20180201��
    
    '�������ƣ�ȫ���Զ����������ѡ��ÿ�족�򷽰�����Ϊ��ÿ�족��
    '���ѡ��ÿ�ܡ���ѡ������һ�����壬������Ϊ����һ�����塱��
    '����м�Ͽ���������һ�����������壬����ѡ��������������硰ÿ��һ�������塱��
    '���ѡ��ÿ�¡���������Ϊ��ÿ�¡���
    '���ѡ��һ�족���򷽰�����Ϊ��������ڣ����硰2018-2-1����
    'ÿһ�����͵ķ���ֻ������һ�Σ���һ�족�ķ�����ÿһ��Ҳֻ������һ��
    lngSchDeviceID = vsfScheduleDevice.TextMatrix(vsfScheduleDevice.RowSel, col_SchDevice_ID)
    lngPlanID = 0
    strContent = ""
    strPlanName = ""
    lngPlanType = tabSchPlanContent.Tab + 1
    dtStartTime = Now
    If lngPlanType = Sch_PlanType_ÿ�� Then 'ÿ�췽��
        '��������Ϊ��
        strPlanName = "ÿ��"
        dtStartTime = Format(dpSchPlanStartTime(0).value, "YYYY-MM-DD")
        lngInterval = Val(txtSchDayInterval.Text)
    ElseIf lngPlanType = Sch_PlanType_ÿ�� Then 'ÿ�ܷ���
        dtStartTime = Format(dpSchPlanStartTime(1).value, "YYYY-MM-DD")
        lngInterval = Val(txtSchWeekInterval.Text)
        '���û��ѡ���κ�һ�죬��ʾ�û��޷�����˷���
        For i = 1 To 7
            If chkSchWeek(i).value = 1 Then
                strContent = strContent & i
            End If
        Next i
        If strContent = "" Then
            Call MsgBox("����ѡ��ÿ�ܷ����еĹ����գ��ٱ��淽����", vbOKOnly, "���ԤԼ��ʾ")
            Exit Sub
        End If
        blnUseCalendar = (chkSchUseCanlendar.value = 1)
        If strContent = "12345" Then
            strPlanName = "��һ������"
        Else
            For i = 1 To Len(strContent)
                strPlanName = strPlanName & "��" & WeekdayChinese(Val(Mid(strContent, i, 1)))
            Next i
            strPlanName = Mid(strPlanName, 2)
            strPlanName = "ÿ��" & strPlanName
        End If
    ElseIf lngPlanType = Sch_PlanType_ÿ�� Then 'ÿ�·���
        '��������Ϊ��
        strPlanName = "ÿ��"
    ElseIf lngPlanType = Sch_PlanType_һ�� Then 'һ�췽��
        If dpSchOneday.Selection.BlocksCount <> 1 Then
            MsgBox "����ѡ��һ�죬Ȼ���ٱ���ԤԼ������", vbOKOnly, "���ԤԼ��ʾ"
            Exit Sub
        End If
        strContent = Format(dpSchOneday.Selection.Blocks(0).DateBegin, "yyyymmdd")
        strPlanName = Format(dpSchOneday.Selection.Blocks(0).DateBegin, "yyyy-m-d")
    End If
        
    '���ݵ�ǰ����ҳ������ݣ������жϣ��Ƿ����ظ���ͬ�෽��
    '������ظ���ͬ�෽������ʾ�û��Ƿ��滻
    With vsfSchedulePlan
        For i = 2 To .Rows - 1
            If lngPlanType = Sch_PlanType_ÿ�� Then  'ÿ�ܷ���Ҫ�������������û��������7��ÿ�ܷ�����ֻҪ�����ղ��ظ����־Ϳ���
                If .TextMatrix(i, col_SchPlan_��������) = Sch_PlanType_ÿ�� Then
                    If isWeekdayDuplicated(strContent, .TextMatrix(i, col_SchPlan_��������), strDuplicateDay) = True _
                        And (lngActionType = 1 Or (lngActionType = 2 And i <> .RowSel)) Then
                        '�����������������Ա����з�����������޸ķ�����ֻ��Ҫ�Ա���������
                        Call MsgBox("����" & WeekdayChinese(Val(strDuplicateDay)) & "���ڷ�����" & .TextMatrix(i, col_SchPlan_��������) & "�����Ѿ����ڣ�ͬһ���޷���ӵ���������У�" & vbCrLf & vbCrLf & "������ѡ��ÿ�ܹ����պ��ٱ��淽����", vbOKOnly, "���ԤԼ��ʾ")
                        Exit Sub
                    End If
                End If
            ElseIf lngPlanType = Sch_PlanType_һ�� Then    'һ��ķ�������ͬ��һ��ֻ������һ��
                If (.TextMatrix(i, col_SchPlan_��������) = strContent) And (lngActionType = 1 Or (lngActionType = 2 And i <> .RowSel)) Then
                    Call MsgBox("�Ѿ����ڡ�" & strPlanName & "����һ�췽��������Ҫ�ظ�����˷�����", vbOKOnly, "���ԤԼ��ʾ")
                    Exit Sub
                End If
            ElseIf (.TextMatrix(i, col_SchPlan_��������) = lngPlanType) Then
                If lngActionType = 1 Then   '���������������ظ�����ʾ�Ƿ��滻
                    If MsgBox("�Ѿ�����һ��" & IIF(lngPlanType = Sch_PlanType_ÿ��, "��ÿ�족", "��ÿ�¡�") & "���͵�ԤԼ�������Ƿ�Ҫ�滻�˷�����", vbYesNo, "���ԤԼ��ʾ") = vbNo Then
                        Exit Sub
                    Else
                        lngPlanID = .TextMatrix(i, col_SchPlan_ID)
                    End If
                ElseIf lngActionType = 2 And i <> .RowSel Then  '�޸ķ����������ظ�����ʾ�û������ǲ��滻
                    Call MsgBox("�Ѿ�����һ��" & IIF(lngPlanType = Sch_PlanType_ÿ��, "��ÿ�족", "��ÿ�¡�") & "���͵�ԤԼ�������������޸ĺ��ٱ��档", vbOKOnly, "���ԤԼ��ʾ")
                    Exit Sub
                End If
            End If
        Next i
        
        If lngPlanID = 0 And lngActionType = 2 Then '������޸ķ���������ȡԭ����ID
            lngPlanID = .TextMatrix(.RowSel, col_SchPlan_ID)
        End If
    End With
    
    strSql = "Zl_Ӱ��ԤԼ����_����(" & lngPlanID & "," & lngSchDeviceID & ",'" _
            & strPlanName & "'," & lngPlanType & ",'" _
            & strContent & "'," & lngInterval & "," & IIF(blnUseCalendar = True, 1, 0) _
            & "," & zlStr.To_Date(CDate(dtStartTime)) & ")"
    zlDatabase.ExecuteProcedure strSql, "������ԤԼ����"
    
    'ˢ��ԤԼ�����б�
    Call loadSchedulePlan(lngSchDeviceID)
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub SchedulePlanDel()
'------------------------------------------------
'���ܣ�ɾ��ԤԼ����
'������
'���أ���
'------------------------------------------------
    Dim strSql As String
    Dim lngSchPlanID As Long
    Dim lngSchDeviceID As Long
    
    On Error GoTo err
    
    '���û��ԤԼ�豸����ֱ���˳�
    If vsfScheduleDevice.Rows <= 2 Or vsfScheduleDevice.RowSel < 1 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    '���û��ԤԼ��������ֱ���˳�
    If vsfSchedulePlan.Rows <= 2 Or vsfSchedulePlan.RowSel < 1 Then
        MsgBox "����ѡ��һ��ԤԼ������", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    lngSchPlanID = vsfSchedulePlan.TextMatrix(vsfSchedulePlan.RowSel, col_SchPlan_ID)
    
    strSql = "Zl_Ӱ��ԤԼ����_ɾ��(" & lngSchPlanID & ")"
    zlDatabase.ExecuteProcedure strSql, "ɾ�����ԤԼ����"
    
    lngSchDeviceID = vsfScheduleDevice.TextMatrix(vsfScheduleDevice.RowSel, col_SchDevice_ID)
    
    'ˢ��ԤԼ�����б�
    Call loadSchedulePlan(lngSchDeviceID)
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub initSchedulePlan()
'------------------------------------------------
'���ܣ���ʼ�� ԤԼ�������� ҳ��
'������
'���أ���
'------------------------------------------------
    On Error GoTo err
    
    '�ȳ�ʼ��ʱ���ؼ�
    Call SchTimeTable.Init(3)
    
    '����ԤԼ�豸
    Call loadScheduleDevice
    
    '��ʼ����һ�족����־����ʾ����
    dpSchOneday.AllowNoncontinuousSelection = False
    dpSchOneday.HighlightToday = True
    dpSchOneday.MultiSelectionMode = False
    dpSchOneday.ShowNoneButton = False
    dpSchOneday.ShowTodayButton = True
    dpSchOneday.ShowNonMonthDays = True
    dpSchOneday.TextTodayButton = "����"
    dpSchOneday.ShowNonMonthDays = False
    dpSchOneday.MaxSelectionCount = 1
    Call dpSchOneday.Select(Now)
    sstSchSetup.Tab = 0
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Function isWeekdayDuplicated(ByVal strWeekday1 As String, ByVal strWeedday2 As String, ByRef strDuplicateDay As String) As Boolean
'------------------------------------------------
'���ܣ��ж�ÿ�ܵĹ������Ƿ�����ظ�
'������ strWeekday1 -- �����ȶԵ������
'       strWeedday2 -- �����ȶԵ������
'       strDuplicateDay -- ���ز����������ظ�������
'���أ�True --����ų����ظ���False -- ����Ų��ظ�
'------------------------------------------------
    Dim i As Integer
    Dim strOne As String
    
    On Error GoTo err
    
    isWeekdayDuplicated = False
    'ʹ��strWeekday1����ѭ��
    For i = 1 To Len(strWeekday1)
        strOne = Mid(strWeekday1, i, 1)
        If InStr(strWeedday2, strOne) > 0 Then
            strDuplicateDay = strOne
            isWeekdayDuplicated = True
            Exit For
        End If
    Next i
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
End Function

Private Function WeekdayChinese(lngWeekday As Long) As String
'------------------------------------------------
'���ܣ������ֵ�����ţ����������ĵ���һ������
'������ lngWeekday -- ����ţ�1-7
'���أ��ܵ������ַ���һ�����������ġ��塢������
'------------------------------------------------
    On Error GoTo err
    
    Select Case Val(lngWeekday)
        Case 1:
            WeekdayChinese = "һ"
        Case 2:
            WeekdayChinese = "��"
        Case 3:
            WeekdayChinese = "��"
        Case 4:
            WeekdayChinese = "��"
        Case 5:
            WeekdayChinese = "��"
        Case 6:
            WeekdayChinese = "��"
        Case 7:
            WeekdayChinese = "��"
        Case Else
            WeekdayChinese = "��"
    End Select
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
End Function

Private Sub InitScheduleDevice()
'��ʼ��ԤԼ�豸��ԤԼ���ý���
    
    mblnClickRestDate = True
    
    Call InitLocalPar
    Call InitImDevice
    Call InitDept
    Call InitSchDept    '��Ҫ��RefreshDevice֮ǰ
    Call RefreshDevice
    
    Call RefeshRestDay
    
    Call LoadNoticeInfo
End Sub

Private Function CheckDevice(Optional lngRow As Long) As Boolean
    Dim i As Long
    
    If Len(Trim(txtEqDevice.Text)) = 0 Then
        MsgBox "������ԤԼ�豸���ơ�", vbInformation, "��ʾ"
        txtEqDevice.SetFocus
        Exit Function
    End If
    
    If Len(Trim(cboImDevice.Text)) = 0 Then
        MsgBox "��ѡ���Ӧ��Ӱ���豸��", vbInformation, "��ʾ"
        cboImDevice.SetFocus
        Exit Function
    End If
    
    For i = 1 To vsfDevice.Rows - 1
        If Len(Trim(vsfDevice.TextMatrix(i, ct�豸����))) > 0 Then
            If UCase(Trim(vsfDevice.TextMatrix(i, ct�豸����))) = UCase(Trim(txtEqDevice.Text)) And lngRow <> i Then
                MsgBox "ԤԼ�豸�����Ѵ��ڣ����顣", vbInformation, "��ʾ"
                txtEqDevice.SetFocus
                Exit Function
            End If
        End If
    Next
    CheckDevice = True
End Function


Private Sub InitDept()
'��ʼ��������
    Dim strSql As String
    Dim rsTemp As Recordset
    
    On Error GoTo errH
    vsfDept.Rows = 1
    strSql = "Select a.Id, a.����, a.���� From ���ű� a, ��������˵�� b Where a.Id = b.����id And �������� = '���'"
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ѯ������")
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    Do While Not rsTemp.EOF
        vsfDept.Rows = vsfDept.Rows + 1
        '���㵱ǰ���������к���
        If InStr(";" & mstrUseDept & ";", ";" & Val(NVL(rsTemp!ID)) & ";") > 0 Then
            vsfDept.Cell(flexcpPicture, vsfDept.Rows - 1, ctDt�Ƿ�����) = imgCheck.Picture
            vsfDept.Cell(flexcpData, vsfDept.Rows - 1, ctDt�Ƿ�����) = 1
        Else
            vsfDept.Cell(flexcpPicture, vsfDept.Rows - 1, ctDt�Ƿ�����) = imgNoCheck.Picture
            vsfDept.Cell(flexcpData, vsfDept.Rows - 1, ctDt�Ƿ�����) = 0
        End If
        vsfDept.Cell(flexcpPictureAlignment, vsfDept.Rows - 1, ctDt�Ƿ�����) = flexPicAlignCenterCenter
        vsfDept.Cell(flexcpText, vsfDept.Rows - 1, ctDt��������) = NVL(rsTemp!����)
        vsfDept.Cell(flexcpText, vsfDept.Rows - 1, ctDtID) = Val(NVL(rsTemp!ID))
        rsTemp.MoveNext
    Loop
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub RefreshDevice()
'��ʼ��ԤԼ�豸
    Dim strSql As String
    Dim rsTemp As Recordset
    Dim i As Long
    
    mlngDeviceRow = 0
    vsfDevice.Rows = 1
    vsfDevice.Cols = 9
    vsfDevice.AllowUserResizing = flexResizeColumns
    
    vsfDevice.TextMatrix(0, ct����ID) = "����ID"
    vsfDevice.TextMatrix(0, ctԤԼ����) = "ԤԼ����"
    vsfDevice.TextMatrix(0, ct�豸˵��) = "˵��"
    
    On Error GoTo errH
    strSql = "Select a.Id, a.�豸����, a.Ӱ���豸��, a.Ӱ�����, a.�豸˵��, a.�Ƿ�����, b.�豸��, " _
        & " a.����ID,c.���� as ԤԼ���� From Ӱ��ԤԼ�豸 a, Ӱ���豸Ŀ¼ b,���ű� c " _
        & " Where a.Ӱ���豸�� = B.�豸�� And a.����id = c.ID Order By c.����"

    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ѯԤԼ�豸")
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    For i = 0 To rsTemp.RecordCount - 1
        With vsfDevice
            .Rows = .Rows + 1
            If Val(NVL(rsTemp!�Ƿ�����)) = 1 Then
                .Cell(flexcpPicture, .Rows - 1, ct�Ƿ�����) = imgCheck.Picture
                .Cell(flexcpData, .Rows - 1, ct�Ƿ�����) = 1
            Else
                .Cell(flexcpPicture, .Rows - 1, ct�Ƿ�����) = imgNoCheck.Picture
                .Cell(flexcpData, .Rows - 1, ct�Ƿ�����) = 0
            End If
            .Cell(flexcpPictureAlignment, .Rows - 1, ct�Ƿ�����) = flexPicAlignCenterCenter
            .Cell(flexcpText, .Rows - 1, ct�豸����) = NVL(rsTemp!�豸����)
            .Cell(flexcpText, .Rows - 1, ctID) = NVL(rsTemp!ID)
            .Cell(flexcpText, .Rows - 1, ctӰ���豸) = NVL(rsTemp!�豸��)
            .Cell(flexcpText, .Rows - 1, ctӰ�����) = NVL(rsTemp!Ӱ�����)
            .Cell(flexcpText, .Rows - 1, ct�豸˵��) = NVL(rsTemp!�豸˵��)
            .Cell(flexcpText, .Rows - 1, ctӰ���豸��) = NVL(rsTemp!Ӱ���豸��)
            .Cell(flexcpText, .Rows - 1, ct����ID) = NVL(rsTemp!����ID)
            .Cell(flexcpText, .Rows - 1, ctԤԼ����) = NVL(rsTemp!ԤԼ����)
        End With
        rsTemp.MoveNext
    Next
    vsfDevice.ColHidden(ct����ID) = True
    vsfDevice.ColHidden(ctӰ���豸��) = True
    vsfDevice.ColHidden(ct�豸˵��) = False
    
    If vsfDevice.Rows > 0 Then
        vsfDevice.Row = 1
    End If
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub RefreshDiagnosis(lngDeviceID As Long, Optional strItem As String, Optional blnSave As Boolean)
'ˢ��������Ŀ
    Dim strSql As String
    Dim rsTemp As Recordset
    Dim i As Long
    Dim blnOk As Boolean
    
    If Len(strItem) = 0 Then vsfDiagnosis.Rows = 1
    On Error GoTo errH
    strSql = "Select c.����, c.����, c.�걾��λ, b.���ʱ��, b.ע������, b.Id, b.Ӱ�����,b.������Ŀid" & vbNewLine & _
                "From Ӱ��ԤԼ�豸 a, Ӱ��ԤԼ��Ŀ b, ������ĿĿ¼ c" & vbNewLine & _
                "Where a.Id = b.ԤԼ�豸id And b.������Ŀid = c.Id and a.ID = [1] order by c.����"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ѯԤԼ��Ŀ", lngDeviceID)
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    blnOk = False
    For i = 0 To rsTemp.RecordCount - 1
        With vsfDiagnosis
            If Len(strItem) > 0 Then
                blnOk = InStr(strItem, NVL(rsTemp!������Ŀid)) > 0
            End If
            If Not blnOk Then
                 .Rows = .Rows + 1
                .Cell(flexcpText, .Rows - 1, ctDgID) = NVL(rsTemp!ID)
                .Cell(flexcpText, .Rows - 1, ct����) = NVL(rsTemp!����)
                .Cell(flexcpText, .Rows - 1, ct������Ŀ) = NVL(rsTemp!����)
                .Cell(flexcpText, .Rows - 1, ct��λ) = NVL(rsTemp!�걾��λ)
                .Cell(flexcpText, .Rows - 1, ct���ʱ��) = Val(NVL(rsTemp!���ʱ��))
                .Cell(flexcpText, .Rows - 1, ctע������) = NVL(rsTemp!ע������)
                .Cell(flexcpText, .Rows - 1, ctDgӰ�����) = NVL(rsTemp!Ӱ�����)
                .Cell(flexcpText, .Rows - 1, ct������ĿID) = NVL(rsTemp!������Ŀid)
                
                If blnSave Then
                     Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ��Ŀ_�༭(0,'" & NVL(rsTemp!Ӱ�����) & "'," & Val(vsfDevice.TextMatrix(vsfDevice.Row, ctID)) & "," & Val(NVL(rsTemp!������Ŀid)) & "," & Val(NVL(rsTemp!���ʱ��)) & ",'" & Replace(NVL(rsTemp!ע������), "'", "''") & "',1)", "������Ŀ")
                End If
            End If
        End With
        rsTemp.MoveNext
    Next
    
    If vsfDevice.Row > 0 Then
        vsfDevice.RowData(vsfDevice.Row) = GetString
    End If
    
    vsfDiagnosis.Row = 1
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub


Private Sub cmdCopyDiagnosis_Click()
    Dim i As Long
    Dim strTemp As String
    Dim strItem As String
    Dim strSql As String
    Dim rsTemp As Recordset
    Dim lngDeviceID As Long
    
    On Error GoTo errHandle
    
    If Val(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctID)) < 0 Or vsfDevice.Row <= 0 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "��ʾ"
        Exit Sub
    End If
    
    strTemp = frmSchCopyDiagnosis.ShowMe(Val(vsfDevice.TextMatrix(vsfDevice.Row, ctID)), Me)
    
    strSql = "select ID from Ӱ��ԤԼ�豸 where �豸���� = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ȡ�豸��", strTemp)
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    lngDeviceID = Val(NVL(rsTemp!ID))
    
    For i = 1 To vsfDiagnosis.Rows - 1
        If Val(vsfDiagnosis.TextMatrix(i, ct������ĿID)) > 0 Then
            strItem = strItem & "<" & Val(vsfDiagnosis.TextMatrix(i, ct������ĿID)) & ">"
        End If
    Next
    
    If Val(lngDeviceID) > 0 Then
        Call RefreshDiagnosis(lngDeviceID, strItem, True)
    End If
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub cmdDeleteDevice_Click()
'ɾ���豸
    Dim lngRow As Long
    Dim strSql As String
    Dim rsTemp As ADODB.Recordset
    
    On Error GoTo errHandle
    
    lngRow = vsfDevice.Row
    If Val(vsfDevice.Cell(flexcpText, lngRow, ctID)) < 0 Or lngRow <= 0 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    If Val(vsfDevice.Cell(flexcpText, lngRow, ctID)) > 0 Then
        If MsgBox("�Ƿ�ȷ��ɾ��ԤԼ�豸��" & vsfDevice.Cell(flexcpText, lngRow, ct�豸����) & "����", vbYesNo, "���ԤԼ��ʾ") = vbNo Then
            Exit Sub
        End If
    End If
    
    '����Ѿ���ԤԼ��¼������ʾ�û������豸�޷�ɾ����
    strSql = "select count(id) sum from Ӱ��ԤԼ��¼ a where a.ԤԼ�豸id=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "���豸�Ƿ��Ѿ�ԤԼ", Val(vsfDevice.Cell(flexcpText, lngRow, ctID)))
    If rsTemp!Sum > 0 Then
        MsgBox "���ԤԼ�豸�Ѿ�����ԤԼ��¼������ɾ��ԤԼ��¼����ɾ������豸��", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ�豸_�༭(" & Val(vsfDevice.Cell(flexcpText, lngRow, ctID)) & ",'','',0,'','','',3)", "ɾ���豸")
    
    vsfDevice.RemoveItem vsfDevice.Row
    
    If lngRow > 1 Then
        vsfDevice.Row = lngRow - 1
    Else
        Call ClearDeviceInfo
    End If

    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub cmdDeleteDiagnosis_Click()
'ɾ��ԤԼ��Ŀ
    Dim lngRow As Long
    
    On Error GoTo errHandle
    
    lngRow = vsfDiagnosis.Row
    If Val(vsfDiagnosis.TextMatrix(lngRow, ctDgID)) <= 0 Or lngRow <= 0 Then
        MsgBox "����ѡ��һ��ԤԼ��Ŀ", vbInformation, "��ʾ"
        Exit Sub
    End If
    
    If Val(vsfDiagnosis.Cell(flexcpText, lngRow, ctID)) > 0 Then
        If MsgBox("�Ƿ�ȷ��ɾ��ԤԼ��Ŀ��" & vsfDiagnosis.Cell(flexcpText, lngRow, ct������Ŀ) & "����", vbYesNo) = vbNo Then
            Exit Sub
        End If
    End If
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ��Ŀ_�༭(" & Val(vsfDiagnosis.Cell(flexcpText, lngRow, ctDgID)) & ",'','','','','',3)", "ɾ����Ŀ")
    
    vsfDiagnosis.RemoveItem vsfDiagnosis.Row
    If vsfDevice.Row > 0 Then
        vsfDevice.RowData(vsfDevice.Row) = GetString
    End If
    
    If lngRow > 1 Then
        vsfDiagnosis.Row = lngRow - 1
    Else
        ClearDgsInfo
    End If

    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub cmdUpdateDevice_Click()
'�޸��豸
    Dim i As Long
    Dim strSql As String
    Dim rsTemp As Recordset
    Dim strDeviceNo As String
    Dim lngRow As Long
    Dim lngSchDeptID As Long
    Dim strModality As String
    
    On Error GoTo errHandle
    
    lngRow = vsfDevice.Row
    
    If Val(vsfDevice.Cell(flexcpText, lngRow, ctID)) < 0 Or lngRow <= 0 Then
        MsgBox "����ѡ��һ��ԤԼ�豸��", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    If Not CheckDevice(lngRow) Then Exit Sub
    
    strSql = "Select a.�豸��, a.Ӱ�����, b.ִ�м� From Ӱ���豸Ŀ¼ A, ҽ��ִ�з��� B " _
        & " Where a.�豸�� = b.����豸 and �豸�� = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ȡ�豸", Trim(cboImDevice.Text))
    
    If rsTemp.RecordCount = 0 Then
        MsgBox "���Ҳ���Ӱ���豸��������û�����ö�Ӧ��ִ�м䡣", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    strDeviceNo = rsTemp!�豸��
    strModality = rsTemp!Ӱ�����
    '���ж�Ӱ������Ƿ����ı䣬����ı䣬��ʾ�û���Ҫ�������ö�Ӧ��������Ŀ
    If vsfDevice.Cell(flexcpText, lngRow, ctӰ�����) <> strModality Then
        If MsgBox("Ӱ��������ı䣬���豸��������Ŀ��Ҫ����ѡ���Ƿ�ȷ���޸�Ӱ�����", vbYesNo, "���ԤԼ��ʾ") = vbNo Then
            Exit Sub
        Else
            'ɾ������豸������������Ŀ
            For i = 1 To vsfDiagnosis.Rows - 1
                Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ��Ŀ_�༭(" & Val(vsfDiagnosis.Cell(flexcpText, i, ctDgID)) & ",'','','','','',3)", "ɾ����Ŀ")
            Next i
        End If
    End If
    
    lngSchDeptID = cboSchDept.ItemData(cboSchDept.ListIndex)
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ�豸_�༭(" _
        & Val(vsfDevice.Cell(flexcpText, lngRow, ctID)) & ",'" & Trim(txtEqDevice.Text) _
        & "','" & strDeviceNo & "'," & lngSchDeptID & ",'" & rsTemp!Ӱ����� & "','" & Replace(Trim(txtNode.Text), "'", "''") & "'," & Val(vsfDevice.Cell(flexcpData, lngRow, ct�Ƿ�����)) & ",2)", "�޸��豸")
    
    With vsfDevice
        .Cell(flexcpText, lngRow, ct�豸����) = Trim(txtEqDevice.Text)
        .Cell(flexcpText, lngRow, ct�豸˵��) = Trim(txtNode.Text)
        .Cell(flexcpText, lngRow, ctӰ�����) = rsTemp!Ӱ�����
        .Cell(flexcpText, lngRow, ctӰ���豸) = Trim(cboImDevice.Text)
        .Cell(flexcpText, lngRow, ct����ID) = Trim(cboSchDept.ItemData(cboSchDept.ListIndex))
        .Cell(flexcpText, lngRow, ctԤԼ����) = Trim(cboSchDept.Text)
    End With
    
    MsgBox "ԤԼ�豸�޸ĳɹ���", vbInformation, "��ʾ"
    Call RefreshDiagnosis(Val(vsfDevice.Cell(flexcpText, lngRow, ctID)))
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub cmdUpdateDiagnosis_Click()
    Dim lngRow As Long
    
    On Error GoTo errHandle
    
    lngRow = vsfDiagnosis.Row
    
    If Val(vsfDiagnosis.TextMatrix(lngRow, ctDgID)) <= 0 Or lngRow <= 0 Then
        MsgBox "����ѡ��һ��ԤԼ��Ŀ", vbInformation, "���ԤԼ��ʾ"
        Exit Sub
    End If
    
    If Val(txtTime.Text) = 0 Then
        MsgBox "���ʱ����Ҫ����0�����������롣", vbInformation, "���ԤԼ��ʾ"
        txtTime.SetFocus
        Exit Sub
    End If
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ��Ŀ_�༭(" & Val(vsfDiagnosis.TextMatrix(lngRow, ctDgID)) & ",'" & vsfDiagnosis.TextMatrix(lngRow, ctDgӰ�����) & "'," & Val(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctID)) & "," & Val(vsfDiagnosis.TextMatrix(lngRow, ct������ĿID)) & "," & Val(txtTime.Text) & ",'" & Replace(txtAttention.Text, "'", "''") & "',2)", "�޸���Ŀ")
    
    vsfDiagnosis.TextMatrix(lngRow, ct���ʱ��) = Val(txtTime.Text)
    vsfDiagnosis.TextMatrix(lngRow, ctע������) = txtAttention.Text
    If vsfDevice.Row > 0 Then
        vsfDevice.RowData(vsfDevice.Row) = GetString
    End If
    
    MsgBox "ԤԼ��Ŀ�޸ĳɹ���", vbInformation, "���ԤԼ��ʾ"
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "���ԤԼ��ʾ"
    err.Clear
End Sub

Private Sub dtpRestDay_DayMetrics(ByVal Day As Date, ByVal Metrics As XtremeCalendarControl.IDatePickerDayMetrics)
    Dim lngDay As Long
    
    On Error GoTo errHandle
    
    
'    If Weekday(Day) = vbSunday Or Weekday(Day) = vbSaturday Then
'        Metrics.ForeColor = vbRed
'    End If
    
    
    If InStr(mstrSchRestDate, Format(Day, "dd")) > 0 Then
        lngDay = Val(Format(Day, "dd"))
        
        Set pictDay.Picture = imgList.ListImages(lngDay).Picture
        Set Metrics.Picture = pictDay
    End If
    
    mblnClickRestDate = False
    Call RefreshRestDayCHK
    mblnClickRestDate = True
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub


Private Sub dtpRestDay_KeyDown(KeyCode As Integer, Shift As Integer)
    On Error GoTo errHandle
    
    mblnKeyPress = True
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub dtpRestDay_MonthChanged()
    On Error GoTo errHandle
    
    Call RefeshRestDay
    
    mblnClickRestDate = False
    Call RefreshRestDayCHK
    mblnClickRestDate = True
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub RefeshRestDay()
'��������
    Dim strSql As String
    Dim rsTemp As Recordset
    
    mstrSchRestDate = ""
    On Error GoTo errH
    strSql = "select ����,��Ϣ�� from Ӱ��ԤԼ���� where ���� = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ȡ������Ϣ��", Format(dtpRestDay.FirstVisibleDay, "yyyymm"))
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    mstrSchRestDate = NVL(rsTemp!��Ϣ��)
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub dtpRestDay_SelectionChanged()
    
    Dim strDate As String
    
    On Error GoTo errHandle
    
    If mblnKeyPress Then
        mblnKeyPress = False
        Exit Sub
    End If
    
    If dtpRestDay.Selection(0) Is Nothing Then Exit Sub
    
    If Format(dtpRestDay.Selection(0).DateEnd, "yyyymm") <> Format(dtpRestDay.FirstVisibleDay, "yyyymm") Then Exit Sub
    
    strDate = Format(dtpRestDay.Selection(0).DateEnd, "dd")
    If InStr(mstrSchRestDate, strDate) > 0 Then
        Call DeleteRestDay(strDate)
    Else
        Call AddRestDay(strDate)
    End If
    
    Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ����_����('" & Format(dtpRestDay.FirstVisibleDay, "yyyymm") & "','" & mstrSchRestDate & "')", "����ԤԼ����")
'    Call RefeshRestDay

    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub InitLocalPar()
    
    chkReservations.value = Val(zlDatabase.GetPara("����ԤԼ", glngSys, 1292))
    SetEnabled chkReservations.value = 1
    chkSchExecFee.value = Val(zlDatabase.GetPara("ԤԼʱִ�з���", glngSys, 1292))
    mstrUseDept = zlDatabase.GetPara("ԤԼ����", glngSys, 1292)
End Sub

Private Sub InitImDevice()
'��ʼ��Ӱ���豸
    Dim strSql As String
    Dim rsTemp As Recordset
    
    On Error GoTo errH
    strSql = "Select Distinct �豸��, �豸�� From Ӱ���豸Ŀ¼ Where ���� = 4 order by �豸��"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ȡӰ���豸")
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    Do While Not rsTemp.EOF
        cboImDevice.AddItem rsTemp!�豸��
        rsTemp.MoveNext
    Loop
    
    If cboImDevice.ListCount > 0 Then
        cboImDevice.ListIndex = 0
    Else
        cboImDevice.ListIndex = -1
    End If
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub mobjAddDiagnosis_OnAddDiagnosis(ByVal strResult As String, ByVal strItem As String)
    Dim i As Long
    Dim arrResult() As String
    Dim arrItem() As String
    Dim arrSub() As String
    Dim lngTime As Long
    Dim strAttention As String
    
    On Error GoTo errH
    If Len(strResult) > 0 Then
        arrResult = Split(strResult & "<*><*>", "<*>")
        lngTime = Val(arrResult(1))
        strAttention = Replace(arrResult(2), "'", "''")
        
        If Len(arrResult(0)) > 0 Then
            arrItem = Split(arrResult(0), "<->")
            
            For i = 0 To UBound(arrItem)
                If Len(arrItem(i)) > 0 Then
                    arrSub = Split(arrItem(i) & "||", "|")
                    '�ж���Ŀ�Ƿ����
                    If InStr(strItem, arrSub(0) & "|" & arrSub(1) & "|" & arrSub(2)) = 0 Then
                        Call zlDatabase.ExecuteProcedure("Zl_Ӱ��ԤԼ��Ŀ_�༭(0,'" & Replace(arrSub(2), ">", "") & "'," & Val(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctID)) & "," & Val(arrSub(1)) & "," & lngTime & ",'" & strAttention & "',1)", "������Ŀ")
                    End If
                End If
            Next
        End If
        
        Call RefreshDiagnosis(Val(vsfDevice.Cell(flexcpText, vsfDevice.Row, ctID)))
        
        vsfDiagnosis.Row = vsfDiagnosis.Rows - 1
        vsfDiagnosis.ShowCell vsfDiagnosis.Rows - 1, 1
    End If
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub txtTime_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub

Private Sub vsfDept_Click()
    Dim lngRow As Long
    Dim lngCol As Long
    
    On Error GoTo errHandle
    
    If chkReservations.value <> 1 Then Exit Sub
    
    lngRow = vsfDept.MouseRow
    lngCol = vsfDept.Col
    If lngRow <= 0 Then Exit Sub
    
    If lngCol = ctDt�Ƿ����� Then
        If Val(vsfDept.Cell(flexcpData, lngRow, lngCol)) = 0 Then
            vsfDept.Cell(flexcpData, lngRow, lngCol) = 1
            vsfDept.Cell(flexcpPicture, lngRow, lngCol) = imgCheck.Picture
            Call AddUseDept(Val(vsfDept.TextMatrix(lngRow, ctDtID)))
        ElseIf Val(vsfDept.Cell(flexcpData, lngRow, lngCol)) = 1 Then
            vsfDept.Cell(flexcpData, lngRow, lngCol) = 0
            vsfDept.Cell(flexcpPicture, lngRow, lngCol) = imgNoCheck.Picture
            Call DeleteUseDept(Val(vsfDept.TextMatrix(lngRow, ctDtID)))
        End If
        vsfDept.Cell(flexcpPictureAlignment, lngRow, lngCol) = flexPicAlignCenterCenter
        
        zlDatabase.SetPara "ԤԼ����", mstrUseDept, glngSys, 1292
    End If
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub vsfDevice_RowColChange()
    Dim lngRow As Long
    Dim lngDeviceID As Long
    
    On Error GoTo errHandle
    
    lngRow = vsfDevice.Row
    If lngRow = mlngDeviceRow Or lngRow < 1 Then Exit Sub
    
    mlngDeviceRow = lngRow
    Call ClearDeviceInfo
    
    lngDeviceID = Val(vsfDevice.TextMatrix(lngRow, ctID))
    If lngDeviceID = 0 Then Exit Sub
    Call RefreshDiagnosis(lngDeviceID)
    
    Call InitDeviceInfo(lngRow)

    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Sub InitDeviceInfo(lngRow As Long)
'����ѡ���豸��ʼ���豸��ϸ��Ϣ
    Dim strDevice As String
    Dim i As Long
    Dim lngDeptID As Long
    
    txtEqDevice.Text = vsfDevice.TextMatrix(lngRow, ct�豸����)
    txtNode.Text = vsfDevice.TextMatrix(lngRow, ct�豸˵��)
    
    strDevice = vsfDevice.TextMatrix(lngRow, ctӰ���豸)
    
    For i = 0 To cboImDevice.ListCount
        If UCase(strDevice) = UCase(cboImDevice.List(i)) Then
            cboImDevice.ListIndex = i
            Exit For
        End If
    Next
    
    lngDeptID = vsfDevice.TextMatrix(lngRow, ct����ID)
    For i = 0 To cboSchDept.ListCount
        If lngDeptID = cboSchDept.ItemData(i) Then
            cboSchDept.ListIndex = i
            Exit For
        End If
    Next i
End Sub


Private Sub vsfDiagnosis_RowColChange()
    Dim lngRow As Long

    On Error GoTo errHandle
    
    lngRow = vsfDiagnosis.Row
    
    If lngRow < 1 Then Exit Sub
    
    If mlngDiagnosisRow = lngRow Then Exit Sub
    mlngDiagnosisRow = lngRow
    
    With vsfDiagnosis
        Call ClearDgsInfo
    
        If Val(.TextMatrix(lngRow, ctDgID)) <= 0 Then Exit Sub
        
        txtDgsName.Text = .TextMatrix(lngRow, ct������Ŀ)
        txtTime.Text = .TextMatrix(lngRow, ct���ʱ��)
        txtAttention.Text = .TextMatrix(lngRow, ctע������)
    End With
    
    Exit Sub
errHandle:
    MsgBox err.Description, vbExclamation, "��ʾ"
    err.Clear
End Sub

Private Function GetString() As String
'��������Ŀ����Ϊһ���ַ���
    Dim i As Long
    Dim j As Long
    Dim strResult As String
    Dim strItem As String
    
    With vsfDiagnosis
        For i = 1 To .Rows - 1
            strItem = ""
            If Val(.TextMatrix(i, ctID)) > 0 And Len(.TextMatrix(i, ct�豸����)) > 0 Then
                For j = 0 To .Cols - 1
                    strItem = strItem & IIF(Len(strItem) = 0, "", "[-**-]") & .TextMatrix(i, j)
                Next
                strResult = strResult & IIF(Len(strResult) = 0, "", "[-%%-]") & strItem
            End If
        Next
    End With
    GetString = strResult
End Function

Private Sub ClearDeviceInfo()
'���ԤԼ�豸��Ϣ
    vsfDiagnosis.Rows = 1
    mlngDiagnosisRow = 0
    
    txtEqDevice.Text = ""
    txtNode.Text = ""
    
    Call ClearDgsInfo
End Sub

Private Sub ClearDgsInfo()
    txtDgsName.Text = ""
    txtAttention.Text = ""
    txtTime.Text = ""
End Sub

Private Sub SetEnabled(ByVal blnEnabled As Boolean)
    txtEqDevice.Enabled = blnEnabled
    txtNode.Enabled = blnEnabled
    cboImDevice.Enabled = blnEnabled
    cboSchDept.Enabled = blnEnabled
    cmdAddDevice.Enabled = blnEnabled
    cmdUpdateDevice.Enabled = blnEnabled
    cmdDeleteDevice.Enabled = blnEnabled
    txtAttention.Enabled = blnEnabled
    txtTime.Enabled = blnEnabled
    cmdAddDiagnosis.Enabled = blnEnabled
    cmdUpdateDiagnosis.Enabled = blnEnabled
    cmdDeleteDiagnosis.Enabled = blnEnabled
    cmdCopyDiagnosis.Enabled = blnEnabled
    tabSchPlanContent.Enabled = blnEnabled
    cmdSchPlanAdd.Enabled = blnEnabled
    cmdSchPlanUpdate.Enabled = blnEnabled
    cmdSchPlanDel.Enabled = blnEnabled
    cmdSchPlanCopy.Enabled = blnEnabled
    vsfScheduleDevice.Enabled = blnEnabled
    vsfSchedulePlan.Enabled = blnEnabled
    SchTimeTable.IsReadOnly = Not blnEnabled
    chkSchExecFee.Enabled = blnEnabled
    
    If blnEnabled Then
        vsfDept.BackColor = &H80000005
        vsfDevice.BackColor = &H80000005
        vsfDiagnosis.BackColor = &H80000005
        vsfScheduleDevice.BackColor = &H80000005
        vsfSchedulePlan.BackColor = &H80000005
    Else
        vsfDept.BackColor = &H8000000F
        vsfDevice.BackColor = &H8000000F
        vsfDiagnosis.BackColor = &H8000000F
        vsfScheduleDevice.BackColor = &H8000000F
        vsfSchedulePlan.BackColor = &H8000000F
    End If
    
    dtpRestDay.Enabled = blnEnabled
    chkWeekRest(0).Enabled = blnEnabled
    chkWeekRest(1).Enabled = blnEnabled
End Sub

Private Sub DeleteRestDay(ByVal strDate As String)
'ɾ����Ϣ��
    mstrSchRestDate = Replace(mstrSchRestDate, strDate, "")
    mstrSchRestDate = Replace(mstrSchRestDate, ",,", ",")
    If Len(mstrSchRestDate) > 0 Then
        If Mid(mstrSchRestDate, 1, 1) = "," Then mstrSchRestDate = Mid(mstrSchRestDate, 2)
        If Mid(mstrSchRestDate, Len(mstrSchRestDate), 1) = "," Then mstrSchRestDate = Mid(mstrSchRestDate, 1, Len(mstrSchRestDate) - 1)
    End If
End Sub

Private Sub AddRestDay(ByVal strDate As String)
'�����Ϣ��
    mstrSchRestDate = mstrSchRestDate & IIF(Len(mstrSchRestDate) > 0, ",", "") & strDate
End Sub

Private Sub DeleteUseDept(ByVal lngID As Long)
'ɾ�����ÿ���
    mstrUseDept = Replace(mstrUseDept, lngID, "")
    mstrUseDept = Replace(mstrUseDept, ";;", ";")
    If Len(mstrUseDept) > 0 Then
        If Mid(mstrSchRestDate, 1, 1) = ";" Then mstrUseDept = Mid(mstrUseDept, 2)
        If Mid(mstrUseDept, Len(mstrUseDept), 1) = ";" Then mstrUseDept = Mid(mstrUseDept, 1, Len(mstrUseDept) - 1)
    End If
End Sub

Private Sub AddUseDept(ByVal lngID As Long)
'��ӿ���
    mstrUseDept = mstrUseDept & IIF(Len(mstrUseDept) > 0, ";", "") & lngID
End Sub

Private Sub InitSchDept()
'��ʼ��ԤԼ����
    Dim strSql As String
    Dim rsTemp As Recordset
    
    On Error GoTo errH
    strSql = "Select a.Id, a.����, a.���� From ���ű� a, ��������˵�� b Where a.Id = b.����id And �������� = '���'"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ѯԤԼ����")
    
    If rsTemp.RecordCount <= 0 Then Exit Sub
    
    cboSchDept.Clear
    
    Do While Not rsTemp.EOF
        cboSchDept.AddItem rsTemp!����
        cboSchDept.ItemData(cboSchDept.ListCount - 1) = rsTemp!ID
        rsTemp.MoveNext
    Loop
    
    If cboSchDept.ListCount > 1 Then
        cboSchDept.ListIndex = 0
    Else
        cboSchDept.ListIndex = -1
    End If
    Exit Sub
errH:
    MsgBox err.Description, vbCritical, Me.Caption
End Sub

Private Sub RefreshRestDayCHK()
'------------------------------------------------
'���ܣ����ݱ��±�ѡ�е���Ϣ�գ����ġ�������Ϣ���͡�������Ϣ��ѡ���
'������
'���أ���
'------------------------------------------------
    Dim dtDay As Date
    Dim blnSundayAll As Boolean
    Dim blnSaturdayAll As Boolean
    
    On Error GoTo err
    
    dtDay = dtpRestDay.FirstVisibleDay
    blnSaturdayAll = True
    blnSundayAll = True
    
    Do While dtDay <= dtpRestDay.LastVisibleDay
        If Weekday(dtDay) = vbSaturday And InStr(mstrSchRestDate, Format(dtDay, "dd")) = 0 Then
            blnSaturdayAll = False
        End If
        
        If Weekday(dtDay) = vbSunday And InStr(mstrSchRestDate, Format(dtDay, "dd")) = 0 Then
            blnSundayAll = False
        End If
        dtDay = dtDay + 1
    Loop
    
    chkWeekRest(0).value = IIF(blnSaturdayAll = True, 1, 0)
    chkWeekRest(1).value = IIF(blnSundayAll = True, 1, 0)
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub LoadNoticeInfo()
'------------------------------------------------
'���ܣ�����ע������
'������
'���أ���
'------------------------------------------------
    Dim strSql As String
    Dim rsTemp As ADODB.Recordset
    
    On Error GoTo err
    
    strSql = "select distinct ע������ from Ӱ��ԤԼ��Ŀ"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSql, "��ѯԤԼ��Ŀע������")
    
    Me.lstAttentions.Clear
    
    If rsTemp.RecordCount > 0 Then
        Do While Not rsTemp.EOF
            If Len(NVL(rsTemp!ע������)) > 0 Then
                lstAttentions.AddItem NVL(rsTemp!ע������)
            End If
            rsTemp.MoveNext
        Loop
    End If
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
End Sub
