VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{555E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.CommandBars.9600.ocx"
Object = "{853AAF94-E49C-11D0-A303-0040C711066C}#4.3#0"; "DicomObjects.ocx"
Object = "*\A..\ZLIDKIND\zlIDKind.vbp"
Begin VB.Form frmPatholRIS 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "���Ǽ�"
   ClientHeight    =   8550
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   10515
   ControlBox      =   0   'False
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8550
   ScaleWidth      =   10515
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  '����������
   Begin DicomObjects.DicomViewer dcmTmpView 
      Height          =   255
      Left            =   1320
      TabIndex        =   82
      Top             =   7920
      Visible         =   0   'False
      Width           =   375
      _Version        =   262147
      _ExtentX        =   661
      _ExtentY        =   450
      _StockProps     =   35
      BackColor       =   -2147483639
   End
   Begin VB.CommandButton cmdPetitionCapture 
      Caption         =   "���뵥"
      BeginProperty Font 
         Name            =   "����"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   6315
      TabIndex        =   34
      ToolTipText     =   "����(F2)"
      Top             =   7920
      Width           =   1245
   End
   Begin VB.Frame framPatholInf 
      Height          =   735
      Left            =   0
      TabIndex        =   73
      Top             =   4800
      Width           =   10350
      Begin VB.ComboBox cbxStudyType 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   6375
         Style           =   2  'Dropdown List
         TabIndex        =   21
         Top             =   240
         Width           =   2655
      End
      Begin VB.TextBox txtPatholNum 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   1305
         TabIndex        =   20
         Top             =   240
         Width           =   2655
      End
      Begin VB.Label labStudyType 
         Caption         =   "�ű�����"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   5025
         TabIndex        =   75
         Top             =   270
         Width           =   1365
      End
      Begin VB.Label labPatholNum 
         Caption         =   "������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   240
         TabIndex        =   74
         Top             =   270
         Width           =   975
      End
   End
   Begin VB.Frame Frame2 
      Height          =   4455
      Left            =   0
      TabIndex        =   45
      Top             =   360
      Width           =   10350
      Begin VB.ComboBox cbo�������� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   8070
         Style           =   2  'Dropdown List
         TabIndex        =   13
         Top             =   2280
         Width           =   2070
      End
      Begin VB.CommandButton cmdSelectPinyinName 
         Caption         =   "��"
         Height          =   350
         Left            =   3080
         TabIndex        =   81
         Top             =   680
         Width           =   260
      End
      Begin VB.Frame framSongJian 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "����"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1455
         Left            =   120
         TabIndex        =   36
         Top             =   2880
         Width           =   10095
         Begin VB.TextBox txtOldBarCode 
            BeginProperty Font 
               Name            =   "����"
               Size            =   12
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Left            =   1200
            TabIndex        =   18
            Top             =   960
            Width           =   3285
         End
         Begin VB.ComboBox cboUnitName 
            BeginProperty Font 
               Name            =   "����"
               Size            =   12
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Left            =   1200
            TabIndex        =   14
            Text            =   "cboUnitName"
            Top             =   0
            Width           =   3285
         End
         Begin VB.TextBox txtOldStudyNo 
            BeginProperty Font 
               Name            =   "����"
               Size            =   12
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Left            =   6720
            TabIndex        =   17
            Top             =   480
            Width           =   3285
         End
         Begin VB.TextBox txtSendTag 
            Height          =   360
            Left            =   6720
            TabIndex        =   19
            Top             =   960
            Width           =   3285
         End
         Begin VB.TextBox txtSubmitDoctor 
            BeginProperty Font 
               Name            =   "����"
               Size            =   12
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Left            =   1200
            TabIndex        =   16
            Top             =   480
            Width           =   3285
         End
         Begin VB.TextBox txtFormDepart 
            BeginProperty Font 
               Name            =   "����"
               Size            =   12
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   360
            Left            =   6720
            TabIndex        =   15
            Top             =   0
            Width           =   3285
         End
         Begin VB.Label labOldBarCode 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "ԭ�����"
            BeginProperty Font 
               Name            =   "����"
               Size            =   14.25
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   0
            TabIndex        =   86
            Top             =   960
            Width           =   1140
         End
         Begin VB.Label labOldStudyNo 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "ԭ����"
            BeginProperty Font 
               Name            =   "����"
               Size            =   14.25
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   5400
            TabIndex        =   85
            Top             =   480
            Width           =   1140
         End
         Begin VB.Label lab��ע 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "��    ע"
            BeginProperty Font 
               Name            =   "����"
               Size            =   14.25
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   5400
            TabIndex        =   84
            Top             =   960
            Width           =   1170
         End
         Begin VB.Label labSendDoctor 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "�� �� ��"
            BeginProperty Font 
               Name            =   "����"
               Size            =   14.25
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   0
            TabIndex        =   78
            Top             =   480
            Width           =   1155
         End
         Begin VB.Label labSendRoom 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "�ͼ����"
            BeginProperty Font 
               Name            =   "����"
               Size            =   14.25
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   5400
            TabIndex        =   77
            Top             =   0
            Width           =   1140
         End
         Begin VB.Label labSendUnit 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "�ͼ쵥λ"
            BeginProperty Font 
               Name            =   "����"
               Size            =   14.25
               Charset         =   134
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   0
            TabIndex        =   76
            Top             =   0
            Width           =   1140
         End
      End
      Begin VB.TextBox txt���� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   8070
         MaxLength       =   20
         TabIndex        =   2
         Top             =   210
         Width           =   1155
      End
      Begin VB.ComboBox cboAge 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         ItemData        =   "frmPatholRIS.frx":0000
         Left            =   9255
         List            =   "frmPatholRIS.frx":000D
         Style           =   2  'Dropdown List
         TabIndex        =   3
         Top             =   210
         Width           =   885
      End
      Begin VB.TextBox txtҽ������ 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   1335
         MaxLength       =   1000
         MultiLine       =   -1  'True
         TabIndex        =   10
         Top             =   1470
         Width           =   4980
      End
      Begin VB.CommandButton cmdSel 
         Caption         =   "��"
         Height          =   360
         Left            =   6315
         TabIndex        =   32
         TabStop         =   0   'False
         ToolTipText     =   "ѡ����Ŀ(*)"
         Top             =   1455
         Width           =   300
      End
      Begin VB.TextBox Txt��λ���� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Left            =   1335
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   54
         Top             =   1905
         Width           =   5295
      End
      Begin VB.ComboBox cboҽ�� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   8070
         TabIndex        =   9
         Text            =   "cboҽ��"
         Top             =   1005
         Width           =   2070
      End
      Begin VB.ComboBox cbo�������� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         ItemData        =   "frmPatholRIS.frx":001D
         Left            =   4605
         List            =   "frmPatholRIS.frx":001F
         Style           =   2  'Dropdown List
         TabIndex        =   8
         Top             =   1040
         Width           =   2025
      End
      Begin VB.ComboBox cbo���� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   1335
         Style           =   2  'Dropdown List
         TabIndex        =   7
         Top             =   1050
         Width           =   2025
      End
      Begin VB.TextBox Txt����֤�� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   4605
         TabIndex        =   5
         Top             =   680
         Width           =   2025
      End
      Begin VB.TextBox Txt�绰 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   8070
         TabIndex        =   6
         Top             =   645
         Width           =   2070
      End
      Begin VB.TextBox TxtӢ���� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   1335
         TabIndex        =   4
         Top             =   680
         Width           =   1750
      End
      Begin VB.ComboBox cbo�Ա� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         IMEMode         =   3  'DISABLE
         ItemData        =   "frmPatholRIS.frx":0021
         Left            =   4605
         List            =   "frmPatholRIS.frx":002B
         Style           =   2  'Dropdown List
         TabIndex        =   1
         Top             =   240
         Width           =   2025
      End
      Begin MSComCtl2.DTPicker dtp 
         Height          =   360
         Index           =   0
         Left            =   8070
         TabIndex        =   11
         Top             =   1425
         Width           =   2070
         _ExtentX        =   3651
         _ExtentY        =   635
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         CalendarTitleBackColor=   -2147483643
         CustomFormat    =   "yyyy-MM-dd HH:mm"
         Format          =   98566147
         CurrentDate     =   38222
      End
      Begin MSComCtl2.DTPicker dtp 
         Height          =   375
         Index           =   1
         Left            =   8070
         TabIndex        =   12
         Top             =   1830
         Width           =   2070
         _ExtentX        =   3651
         _ExtentY        =   661
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         CustomFormat    =   "yyyy-MM-dd HH:mm"
         Format          =   98566147
         CurrentDate     =   38222
      End
      Begin zlIDKind.PatiIdentify PatiIdentify 
         Height          =   360
         Left            =   720
         TabIndex        =   0
         ToolTipText     =   """����Ϊ���￨�š���������ͷΪ����ID��������סԺ�š���*������š���.���Һŵ��š���/���շѵ��ݺ�"""
         Top             =   240
         Width           =   2625
         _ExtentX        =   4630
         _ExtentY        =   635
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         IDKindStr       =   $"frmPatholRIS.frx":0037
         BeginProperty IDKindFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         IDKindAppearance=   0
         ShowSortName    =   -1  'True
         ShowPropertySet =   -1  'True
         DefaultCardType =   "���￨"
         IDkindBorderStyle=   1
         IDKindWidth     =   600
         HiddenMoseRightKey=   0   'False
         BeginProperty CardNoShowFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   9
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         AllowAutoCommCard=   -1  'True
         AllowAutoICCard =   -1  'True
         AllowAutoIDCard =   -1  'True
         NotContainFastKey=   "F1;CTRL+F1;F12;CTRL+F12"
      End
      Begin VB.Label lab�������� 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   6840
         TabIndex        =   83
         Top             =   2280
         Width           =   1140
      End
      Begin VB.Label lbl 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "���ʱ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Index           =   0
         Left            =   6855
         TabIndex        =   72
         Top             =   1860
         Width           =   1140
      End
      Begin VB.Label Label4 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��   ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H8000000D&
         Height          =   285
         Left            =   6855
         TabIndex        =   58
         Top             =   270
         Width           =   1140
      End
      Begin VB.Label lbl 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "����ʱ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Index           =   6
         Left            =   6855
         TabIndex        =   57
         Top             =   1440
         Width           =   1140
      End
      Begin VB.Label Lbl��λ���� 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "���걾"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   45
         TabIndex        =   56
         Top             =   1905
         Width           =   1245
      End
      Begin VB.Label lblҽ������ 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "�����Ŀ"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H8000000D&
         Height          =   285
         Left            =   30
         TabIndex        =   55
         Top             =   1485
         Width           =   1245
      End
      Begin VB.Label Label8 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "����ҽ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   6855
         TabIndex        =   53
         Top             =   1035
         Width           =   1140
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "�������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   3390
         TabIndex        =   52
         Top             =   1080
         Width           =   1140
      End
      Begin VB.Label Label19 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "����״��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   45
         TabIndex        =   51
         Top             =   1095
         Width           =   1245
      End
      Begin VB.Label Label20 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��    ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   6855
         TabIndex        =   50
         Top             =   660
         Width           =   1140
      End
      Begin VB.Label Label16 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "����֤��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   3390
         TabIndex        =   49
         Top             =   720
         Width           =   1140
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Ӣ �� ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   45
         TabIndex        =   48
         Top             =   705
         Width           =   1245
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��   ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H8000000D&
         Height          =   285
         Left            =   3390
         TabIndex        =   47
         Top             =   315
         Width           =   1140
      End
      Begin VB.Label Label11 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H8000000D&
         Height          =   285
         Left            =   45
         TabIndex        =   46
         Top             =   270
         Width           =   600
      End
   End
   Begin VB.Frame Frame1 
      BorderStyle     =   0  'None
      Height          =   360
      Left            =   0
      TabIndex        =   37
      Top             =   0
      Width           =   10350
      Begin VB.CheckBox chk���� 
         Caption         =   "�������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H8000000D&
         Height          =   255
         Left            =   8655
         TabIndex        =   44
         Top             =   60
         Width           =   1620
      End
      Begin VB.TextBox txtBed 
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   7125
         TabIndex        =   41
         Top             =   75
         Width           =   1290
      End
      Begin VB.TextBox txtID 
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   4470
         Locked          =   -1  'True
         TabIndex        =   40
         Top             =   75
         Width           =   1725
      End
      Begin VB.TextBox txtPatientDept 
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   1365
         TabIndex        =   38
         Top             =   75
         Width           =   1590
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "�� ʶ ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   3225
         TabIndex        =   43
         Top             =   60
         Width           =   1155
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   6435
         TabIndex        =   42
         Top             =   60
         Width           =   570
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "���˿���"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   120
         TabIndex        =   39
         Top             =   60
         Width           =   1140
      End
   End
   Begin VB.CommandButton CmdOK 
      Caption         =   "ȷ��(&O)"
      BeginProperty Font 
         Name            =   "����"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   400
      Left            =   7710
      TabIndex        =   33
      ToolTipText     =   "����(F2)"
      Top             =   7920
      Width           =   1245
   End
   Begin VB.CommandButton CmdCancle 
      Cancel          =   -1  'True
      Caption         =   "ȡ��(&C)"
      BeginProperty Font 
         Name            =   "����"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   400
      Left            =   9075
      TabIndex        =   35
      Top             =   7920
      Width           =   1245
   End
   Begin VB.Frame frm������Ϣ 
      Height          =   2175
      Left            =   0
      TabIndex        =   59
      Top             =   5520
      Width           =   10350
      Begin VB.ComboBox cbo���ʽ 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   4650
         Style           =   2  'Dropdown List
         TabIndex        =   31
         Top             =   1770
         Width           =   1800
      End
      Begin VB.ComboBox cbo�ѱ� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         IMEMode         =   3  'DISABLE
         Left            =   1290
         Style           =   2  'Dropdown List
         TabIndex        =   30
         Top             =   1755
         Width           =   1800
      End
      Begin VB.TextBox txt�������� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   1290
         MaxLength       =   200
         MultiLine       =   -1  'True
         TabIndex        =   29
         Top             =   1365
         Width           =   8715
      End
      Begin VB.TextBox Txt��ϵ��ַ 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   1290
         TabIndex        =   28
         Top             =   990
         Width           =   8715
      End
      Begin VB.TextBox Txt�ʱ� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   8220
         TabIndex        =   27
         Top             =   630
         Width           =   1800
      End
      Begin VB.ComboBox cboְҵ 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   4900
         Style           =   2  'Dropdown List
         TabIndex        =   26
         Top             =   615
         Width           =   1800
      End
      Begin VB.ComboBox cbo���� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   1290
         Style           =   2  'Dropdown List
         TabIndex        =   25
         Top             =   600
         Width           =   2124
      End
      Begin VB.TextBox Txt���� 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   8220
         MaxLength       =   11
         TabIndex        =   24
         Top             =   255
         Width           =   1800
      End
      Begin VB.TextBox Txt���� 
         BackColor       =   &H8000000B&
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   4920
         MaxLength       =   11
         TabIndex        =   23
         Top             =   240
         Width           =   1785
      End
      Begin MSComCtl2.DTPicker dtp�������� 
         Height          =   330
         Left            =   1290
         TabIndex        =   22
         Top             =   240
         Width           =   2145
         _ExtentX        =   3784
         _ExtentY        =   582
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         CalendarTitleBackColor=   -2147483643
         CustomFormat    =   "yyyy-MM-dd"
         Format          =   98566147
         CurrentDate     =   38222
      End
      Begin VB.Label Label27 
         Caption         =   "KG"
         BeginProperty Font 
            Name            =   "����"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Left            =   10050
         TabIndex        =   80
         Top             =   315
         Width           =   225
      End
      Begin VB.Label Label26 
         Caption         =   "CM"
         BeginProperty Font 
            Name            =   "����"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Left            =   6720
         TabIndex        =   79
         Top             =   294
         Width           =   224
      End
      Begin VB.Label lblCash 
         BeginProperty Font 
            Name            =   "����"
            Size            =   12
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   8205
         TabIndex        =   71
         Top             =   1785
         Width           =   1800
      End
      Begin VB.Label Label12 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��    ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   7005
         TabIndex        =   70
         Top             =   1785
         Width           =   1170
      End
      Begin VB.Label Label13 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "���ʽ"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   3465
         TabIndex        =   69
         Top             =   1800
         Width           =   1140
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��    ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   60
         TabIndex        =   68
         Top             =   1800
         Width           =   1170
      End
      Begin VB.Label Label29 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   90
         TabIndex        =   67
         Top             =   1395
         Width           =   1140
      End
      Begin VB.Label Label22 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��ϵ��ַ"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   90
         TabIndex        =   66
         Top             =   1005
         Width           =   1140
      End
      Begin VB.Label Label21 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��   ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   7095
         TabIndex        =   65
         Top             =   645
         Width           =   1020
      End
      Begin VB.Label Label18 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "ְ   ҵ"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   280
         Left            =   3766
         TabIndex        =   64
         Top             =   644
         Width           =   1022
      End
      Begin VB.Label Label17 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��    ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   60
         TabIndex        =   63
         Top             =   645
         Width           =   1170
      End
      Begin VB.Label Label15 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��   ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   7095
         TabIndex        =   62
         Top             =   270
         Width           =   1020
      End
      Begin VB.Label Label14 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��   ��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   280
         Left            =   3752
         TabIndex        =   61
         Top             =   252
         Width           =   1022
      End
      Begin VB.Label Label25 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "��������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   90
         TabIndex        =   60
         Top             =   285
         Width           =   1140
      End
   End
   Begin XtremeCommandBars.CommandBars cbrMain 
      Left            =   3480
      Top             =   7920
      _Version        =   589884
      _ExtentX        =   635
      _ExtentY        =   635
      _StockProps     =   0
   End
End
Attribute VB_Name = "frmPatholRIS"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


'ģ�����----ע�������
Private mstrUnitName As String '�ͼ쵥λ
Private mstrExamineDoctor As String '��������
'ģ�����----�Դ�ֵ���ⲿ����
Public mstrPrivs As String          '�����ߵ�Ȩ��
Public mlngModul As Long            '��˭����
Public mlngAdviceId As Long         'ҽ��ID
Public mlngSendNo As Long           '���ͺ�
Public mintEditMode As Integer      '0���Ǽǡ�1���ǼǺ��޸ġ�2��������3���������޸�
Public mlngCurDeptId As Long        '��ǰ����ID
Public mstrTechnicRoom As String    '����ִ�м�
Public mblnOk As Boolean            '�����ȡ��

Public mintImgCount As Integer      '��ɨ��ͼ������

'ɨ�贰�����
Private frmPetitionCap As frmPetitionCapture

'����ģ�����------����ֵ�Ӳ�������ȡ��
Private mblnChangeNo As Boolean     '�ֹ���������
Private mblnLike As Boolean, mlngLike As Long    '����ģ������,��������
Private mBeforeDays As Integer      '��������
Private mlngGoOnReg As Long         '�����Ǽ� 0-������,1-����
Private mblnAutoPrint As Boolean    '�������Զ���ӡ���뵥
Private mlngUnicode As Long         '���߼��ű��ֲ���,1-���ּ��Ų��䣻0-������ˮ����
Private mlngUnicodeType As Long     '���ű��ֲ������,������� 0-����𲻱� 1-�����Ҳ���;
Private mblnChoosePrintFormat As Boolean
Private mlngBuildType As Long       '�������ɷ�ʽ,0-�������� 1-�����ҵ���
Private mblnRegToCheck As Boolean   '�Ǽ�ֱ�Ӽ��
Private mblnNoshowReagent As Boolean '����ʾ��Ӱ��
Private mblnNoshowAddons As Boolean '����ʾ��������
Private mintCheckInMode As Integer  '�Ǽ�ģʽ 1--����ģʽ��2--����ģʽ
Private mblnUseReferencePatient As Boolean     'ʹ�ù�������ģʽ
Private mintCapital As Integer      'ƴ������Сд
Private mblnUseSplitter As Boolean  'ƴ�����ָ���
Private mblnAllPatientIsOutside As Boolean '���еǼǲ��˱��Ϊ����
Private mblnNameColColorCfg As Boolean  '�Ƿ���ݲ�����������������ɫ
Private mblnIDCardDetect    As Boolean '����֤ʶ��

'����ģ�����------���������и�ֵ
Private mintSourceType As Integer   '������Դ 1-���� 2-סԺ 3-���� 4-���
Private mlngPatiId As Long, mlngPageID As Long  '����ID,��ҳID
'Private mstrItemType As String      'Ӱ�����
Private mlngClinicID As Long        '������ĿID
'Private mstrItemIDS As String       '�շ�ϸĿID
Private mInputType As Integer       '��ȡ���˷�ʽ��0-���￨ 1-����ID 2-סԺ�� 3-����� 4-�Һŵ� 5-�շѵ��ݺ� 6-���� 7-ҽ���� 8-����֤�� 9-IC����
Private mstrExtData  As String      '�Ǽǵ�������Ŀ��λ������ ���="��λ��1;������1,������2|��λ��2;������1,������2|...<vbTab>0-����/1-����/2-����"
Private mstrAppend As String        '���="��Ŀ��1<Split2>0/1(�����)<Split2>Ҫ��ID<Split2>����<Split1>..."
Private mstrOutNo As String         '�����
Private mstrCardNo As String        '���￨��
Private mstrCardPass As String      '����֤��
Private mstrChargeNo As String      '�շѵ���
Private mstrRegNo As String         '�Һŵ���
Private arrSQL() As Variant
Private mlngNextCheckNo As Long     '��¼���λ�ȡ������һ������
Private mlngPatholStationMoneyExeModle As Long   '�����ɼ��ķ���ִ��ģʽ 0-����ʱִ�У�1-���ʱִ�У�2-����ʱִ��

Private mobjSquareCard As Object    'һ��ͨ�������㲿��

Public mlngPatholSerialNum As Long
Public mstrPatholInitNum As String


Private mblnShowSentInfo As Boolean    '�Ƿ�������ʾ�ͼ���Ϣ
Private mStrOutSideCfg As String     '��Ժ����

Private mblnIsOutSideHosp As Boolean     '�Ƿ�����Ժ����
Private mblnIsPetitionScan As Boolean    '�Ƿ��������뵥ɨ��
Private mblnIsSamePatient As Boolean     '�Ƿ������ͬ����

Private mlngBaby As Long            '�Ƿ�Ӥ����0--����Ӥ����1-9��ʾӤ�����

Private mlngInsureCheckType As Long         'ҽ������������ 0-����飬 1-����ʾ��2-��ֹ
Private mobjInsure As Object

Private mfrmParent As Form          '������
Private mobjPublicPatient As Object

Private Sub SaveAdviceData()
'------------------------------------------------
'���ܣ�����ҽ��
'������ ��
'���أ���
'------------------------------------------------
    Dim str���ʱ�� As String
    Dim str����ʱ�� As String, curDate As String
    Dim strNO As String, lngAdviceId As Long, lngSendNo As Long
    Dim IntSeq As Integer   '����ҽ����¼.���
    Dim str��λ As String, str���� As String
    Dim i As Integer, j As Integer, strTmp���� As String, str��λ���� As String
    Dim lng��������ID As Long, lng����ID As Long, strDoctor As String
    Dim strִ�п���ID As String, lngTmpID As Long, arrAppend
    Dim rsTemp As ADODB.Recordset
    Dim lngMasSeq As Long   '����ҽ������.��¼��ţ���ҽ���е�
    Dim lngSonSeq As Long   '����ҽ������.��¼��ţ�����ҽ���еģ�Ҫ����
    

    On Error GoTo errHand
    
    curDate = zlStr.To_Date(zlDatabase.Currentdate)
    str���ʱ�� = zlStr.To_Date(dtp(1))
    str����ʱ�� = zlStr.To_Date(dtp(0))
    
    str��λ���� = Split(mstrExtData, Chr(9))(0)
    lng��������ID = Me.cbo��������.ItemData(Me.cbo��������.ListIndex)
    strDoctor = zlStr.NeedName(Me.cboҽ��.Text)
    strִ�п���ID = mlngCurDeptId
    
    '�²��ˣ�Ҫ���Ӳ�����Ϣ
    If mlngPatiId <= 0 Then
        '��ȡ�µĲ���ID
        mlngPatiId = zlDatabase.GetNextNo(1)
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = "zl_�ҺŲ��˲���_INSERT(1," & mlngPatiId & ",''," & _
            "'',''," & _
            "'" & Trim(PatiIdentify.Text) & "','" & zlStr.NeedName(cbo�Ա�.Text) & "','" & txt����.Text & IIf(cboAge.Visible, cboAge.Text, "") & "'," & _
            "'" & zlStr.NeedName(cbo�ѱ�.Text) & "','" & zlStr.NeedName(cbo���ʽ.Text) & "'," & _
            "'','" & zlStr.NeedName(cbo����.Text) & "','" & zlStr.NeedName(cbo����.Text) & "'," & _
            "'" & zlStr.NeedName(cboְҵ.Text) & "','" & zlCommFun.ToVarchar(Txt����֤��, 18) & "',''," & Val(Label22.tag) & ",'','','" & zlCommFun.ToVarchar(Txt��ϵ��ַ.Text, 50) & _
            "','" & zlCommFun.ToVarchar(Txt�绰, 20) & "','" & zlCommFun.ToVarchar(Txt�ʱ�, 6) & "'," & curDate & ",'','" & mstrRegNo & "'," & zlStr.To_Date(dtp��������.value) & ",NULL)"
    End If
    
    '����ҽ��������
    '�շѵ���Ϊ�գ���ȡ��һ���շѵ��ݺ�
    If mstrChargeNo = "" Then
        strNO = zlDatabase.GetNextNo(IIf(mintSourceType <> 2, 13, 14)) '����ȡ�շѵ��ݺ�,סԺȡ���ʵ��ݺ�
        lngMasSeq = 1
        lngSonSeq = 1
    Else    '���շѵ��ݺ�
        strNO = mstrChargeNo
        '���շѵ���,����NO��ȡ��ǰ������+1��ʼ,���ڲ���ҽ������,��ҽ�������������ٴεݼ�
        gstrSQL = "Select Max(��¼���) as ��� From ����ҽ������ Where No=[1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ��ǰNO������", CStr(mstrChargeNo))
        If rsTemp.EOF Then
            lngMasSeq = 1
            lngSonSeq = 1
        Else
            lngMasSeq = nvl(rsTemp!���, 0) + 1
            lngSonSeq = lngMasSeq
        End If
    End If
    
    lngAdviceId = zlDatabase.GetNextId("����ҽ����¼")
    lngSendNo = zlDatabase.GetNextNo(10) 'ҽ�����ͺ�
    
    '������ҽ��
    IntSeq = IntSeq + 1     '����ҽ����¼.��ţ�����
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    arrSQL(UBound(arrSQL)) = "ZL_����ҽ����¼_Insert(" & lngAdviceId & ",NULL," & _
                    IntSeq & "," & mintSourceType & "," & mlngPatiId & "," & IIf(mintSourceType = 2, mlngPageID, "NULL") & "," & mlngBaby & _
                    ",1,1,'D'," & mlngClinicID & ",NULL,NULL,NULL,1," & _
                    "'" & Me.txtҽ������ & "," & Decode(Txt��λ����.tag, 1, "����", 2, "����", "����") & "ִ��:" & _
                    get��λ����(mstrExtData) & "',Null,Null,'һ����',NULL,NULL,NULL,NULL,2," & _
                    strִ�п���ID & ",3," & chk����.value & "," & str���ʱ�� & "," & str���ʱ�� & "," & _
                    IIf(Val(Me.txtPatientDept.tag) = 0, lng��������ID, Val(Me.txtPatientDept.tag)) & "," & lng��������ID & _
                    ",'" & strDoctor & "'," & curDate & ",'" & mstrRegNo & "',Null,Null," & Txt��λ����.tag & ",NULL,NULL,'" & UserInfo.���� & "')"
    
    'ѭ����λ���������븽��ҽ��
    For i = 0 To UBound(Split(str��λ����, "|")) '��λ1;����1,����2,����3|��λn;����1,����2,����3---
        str��λ = Split(Split(str��λ����, "|")(i), ";")(0)
        strTmp���� = Split(Split(str��λ����, "|")(i), ";")(1)
        For j = 0 To UBound(Split(strTmp����, ","))
            IntSeq = IntSeq + 1     '����ҽ����¼.��ţ�����
            str���� = Split(strTmp����, ",")(j)
            lngTmpID = zlDatabase.GetNextId("����ҽ����¼")
            
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "ZL_����ҽ����¼_Insert(" & lngTmpID & "," & lngAdviceId & "," & _
                 IntSeq & "," & mintSourceType & "," & mlngPatiId & "," & IIf(mintSourceType = 2, mlngPageID, "NULL") & "," & mlngBaby & _
                 ",1,1,'D'," & mlngClinicID & ",NULL,NULL,NULL,1," & _
                 "'" & Replace(Me.txtҽ������, "'", "") & "',NULL," & _
                 "'" & str��λ & "','һ����',NULL,NULL,NULL,NULL,2," & _
                 strִ�п���ID & ",3," & chk����.value & "," & str���ʱ�� & "," & str���ʱ�� & "," & _
                 IIf(Val(Me.txtPatientDept.tag) = 0, lng��������ID, Val(Me.txtPatientDept.tag)) & "," & lng��������ID & _
                 ",'" & strDoctor & "'," & curDate & ",'" & mstrRegNo & "',Null,'" & str���� & "'," & Txt��λ����.tag & ",NULL,NULL,'" & UserInfo.���� & "')"
            
            '���͸���ҽ��
            '���շѵ��ݺŵ�Ϊ�ѼƷ�,�޵�Ϊδ�Ʒ�
            lngSonSeq = lngSonSeq + 1       '����ҽ������.��¼��ţ�����ҽ���еģ�Ҫ����
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            '����ҽ����ʱ�򣬲���д�״�ʱ���ĩ��ʱ�䣬������ʱ�����д
            arrSQL(UBound(arrSQL)) = "ZL_����ҽ������_Insert(" & _
                lngTmpID & "," & lngSendNo & "," & IIf(mintSourceType = 2, 2, 1) & ",'" & strNO & "'," & _
                lngSonSeq & ",1,NULL,NULL," & str����ʱ�� & ",0," & strִ�п���ID & "," & _
                IIf(mstrChargeNo = "", 0, 1) & ",0,Null,'" & UserInfo.��� & "','" & UserInfo.���� & "')"
        Next
    Next
    
    '������ҽ��
    ReDim Preserve arrSQL(UBound(arrSQL) + 1)
    '����ҽ����ʱ�򣬲���д�״�ʱ���ĩ��ʱ�䣬������ʱ�����д
    arrSQL(UBound(arrSQL)) = "ZL_����ҽ������_Insert(" & _
            lngAdviceId & "," & lngSendNo & "," & IIf(mintSourceType = 2, 2, 1) & ",'" & strNO & "'," & _
            lngMasSeq & ",1,NULL,NULL," & str����ʱ�� & ",0," & strִ�п���ID & "," & _
            IIf(mstrChargeNo = "", 0, 1) & ",1,Null,'" & UserInfo.��� & "','" & UserInfo.���� & "')"
    
    '���벡��ҽ������ '     ���="��Ŀ��1<Split2>0/1(�����)<Split2>Ҫ��ID<Split2>����<Split1>..."
    If mstrAppend <> "" Then
        arrAppend = Split(mstrAppend, "<Split1>")
        For i = 0 To UBound(arrAppend)
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_����ҽ������_Insert(" & lngAdviceId & _
                ",'" & Split(arrAppend(i), "<Split2>")(0) & "'," & Val(Split(arrAppend(i), "<Split2>")(1)) & "," & _
                i + 1 & "," & ZVal(Split(arrAppend(i), "<Split2>")(2)) & ",'" & Replace(Split(arrAppend(i), "<Split2>")(3), "'", "''") & "'" & _
                            IIf(i = 0, ",1", "") & ")"
        Next
    End If

    '���շѵ��ݺŵģ����÷��ü�¼��ҽ���Ĺ�����ϵ
    If mstrChargeNo <> "" Then
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = "zl_���˷��ü�¼_ҽ��('" & strNO & "',1," & lngAdviceId & ")"
    End If
    
    
    mlngAdviceId = lngAdviceId
    mlngSendNo = lngSendNo
    
    Exit Sub
errHand:
    If ErrCenter = 1 Then
        Resume
    End If
    Call SaveErrLog
End Sub


Private Sub cboAge_LostFocus()
    If Not CheckOldData(txt����, cboAge) Then Exit Sub
    If IsNumeric(txt����.Text) Then Call ReCalcBirthDay(txt����.Text, cboAge.Text)
End Sub


Private Function GetPatholNum(ByVal lngID As Long) As String
'���ݼ�����ͻ�ȡ������
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    GetPatholNum = ""
    
    strSQL = "select Zl_��������_��Ż�ȡ([1]) as ������� from dual"
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngID)
    
    If rsData.RecordCount <= 0 Then Exit Function
    
    mlngPatholSerialNum = Val(nvl(rsData!�������))
    
    strSQL = "select Zl_��������_����([1],[2]) as ������ from dual"
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngID, mlngPatholSerialNum)
    
    If rsData.RecordCount <= 0 Then Exit Function
    
    mstrPatholInitNum = nvl(rsData!������)
    
    GetPatholNum = mstrPatholInitNum
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Private Sub cboUnitName_Click()
    SaveSetting "ZLSOFT", "����ģ��\" & App.ProductName & "\" & Me.Name, "�ͼ쵥λ", zlStr.NeedName(cboUnitName.Text)
End Sub

Private Sub cbrMain_Execute(ByVal Control As XtremeCommandBars.ICommandBarControl)
On Error GoTo errhandle
    TxtӢ����.Text = Control.Caption
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cbxStudyType_Click()
On Error GoTo errhandle
    txtPatholNum.Text = GetPatholNum(Val(cbxStudyType.Text))
Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub


'��ҽ��ģ���У����ƹ����ļ�麯��
Public Function CheckAdviceInsure(ByVal int���� As Integer, ByVal bln���Ѷ��� As Boolean, ByVal lng����ID As Long, ByVal lng�������� As Long, _
   ByVal strIDs1 As String, ByVal strIDs2 As String, ByVal strҽ������ As String, Optional ByVal lng���˲���ID As Long) As String
'���ܣ�ҽ�������´�ҽ��ʱ��ҽ��¼��󣬶�ҽ���漰�ļƼ���Ŀ�ı��ն���������м��
'������strIDs1:ҩƷ���ĵ��շ�ϸĿID�ַ�����һ��ҽ�����磺��ù��+�����ǣ�:�շ�ϸĿID1,�շ�ϸĿID2,������
'      strIDs2 ������������Ŀ��������ĿID��һ��ҽ�����磺��Ѫ��Ŀ+��Ѫ;����:ִ�п����ַ��� ������ĿID1:ִ�п���1,������ĿID2:ִ�п���2,������
'      lng��������=1���=2סԺ
'      strҽ�����ݣ��û���ʾʱ��ʾ��ҽ������
'      bln���Ѷ���=False ��ʾ��ǰ��������飬=True �������
'���أ���ʾ��Ϣ
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String, i As Long
    
    If mlngInsureCheckType = 0 Or int���� = 0 Or Not bln���Ѷ��� Then Exit Function
    If mobjInsure.GetCapability(12, lng����ID, int����) Then Exit Function '12:support����������ҽ����Ŀ
    
    
    If strIDs1 = "" And strIDs2 = "" Then Exit Function
    
    If strIDs1 <> "" Then
        If Mid(strIDs1, 1, 1) = "," Then strIDs1 = Mid(strIDs1, 2)
        strSQL = "Select Column_Value as �շ���ĿID From Table(f_Num2list([1]))"
    End If
    If strIDs2 <> "" Then
        If Mid(strIDs2, 1, 1) = "," Then strIDs2 = Mid(strIDs2, 2)
        If strIDs1 <> "" Then strSQL = strSQL & " Union All "
        '����û�мӲ�λ������������Ҫ��Distinct
        strSQL = strSQL & "Select �շ���ĿID From (" & _
                "Select Distinct C.�շ���ĿID,C.���ÿ���id" & _
                " ,Max(Nvl(c.���ÿ���id, 0)) Over(Partition By c.������Ŀid, c.��鲿λ, c.��鷽��, c.��������) As Top" & _
                " From �����շѹ�ϵ C,Table(f_Num2list2([2])) D Where C.������ĿID=D.c1" & _
                "      And (C.���ÿ���ID is Null or C.���ÿ���ID = Nvl(D.c2,[4]) And C.������Դ = " & IIf(lng�������� = 1, 1, 2) & ")" & _
                " ) Where Nvl(���ÿ���id, 0) = Top"
    End If
    
    strSQL = "Select /*+ RULE */ Distinct C.����,B.�շ�ϸĿID" & _
        " From (" & strSQL & ") A,����֧����Ŀ B,�շ���ĿĿ¼ C" & _
        " Where A.�շ���ĿID=B.�շ�ϸĿID(+) And A.�շ���ĿID=C.ID" & _
        " And (C.վ��='" & gstrNodeNo & "' Or C.վ�� is Null)" & _
        " And B.����(+)=[3]"
    On Error GoTo errH
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "CheckAdviceInsure", strIDs1, strIDs2, int����, lng���˲���ID)
    strSQL = "": i = 0
    Do While Not rsTmp.EOF
        If IsNull(rsTmp!�շ�ϸĿID) Then
            If i = 8 Then
                strSQL = strSQL & vbCrLf & "�� ��"
                Exit Do
            End If
            strSQL = strSQL & vbCrLf & "��" & rsTmp!����
            i = i + 1
        End If
        rsTmp.MoveNext
    Loop
    If strSQL <> "" Then
        CheckAdviceInsure = "��ǰ������ҽ�����ˣ���ҽ�������¼Ƽ���Ŀû�����ö�Ӧ�ı�����Ŀ��" & vbCrLf & vbCrLf & _
            "ҽ�����ݣ�" & vbCrLf & strҽ������ & vbCrLf & vbCrLf & "�Ƽ���Ŀ��" & strSQL
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Private Function IDCardValid(objTxtCard As Object, ByVal strCardNo As String, _
  Optional ByVal strName As String, Optional ByVal strSex As String) As Long
On Error GoTo errH
    '0-������1-ȡ����'2-ʹ���Ѵ��ڵĻ���ID
    
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    Dim blnCancel As Boolean
    
    IDCardValid = 0
    
    'û����������֤Ψһʶ�����˳�����
    If Trim(Txt����֤��.Text) = "" Then Exit Function
    
    strSQL = "Select ����ID, ����,�Ա�,����,��������,���� From ������Ϣ Where ����֤��=[1]"
    
    If mlngPatiId = 0 Then
        '�²���
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "����֤��ѯ", strCardNo)
        
        'û����ͬ������֤���ߣ����Լ����Ǽ�
        If rsData.RecordCount <= 0 Then Exit Function
        
        If rsData.RecordCount = 1 Then
            '����һ����ͬ������֤��
            If MsgBoxD(Me, "�Ѵ�������֤��Ϊ " & Txt����֤��.Text & " �Ĳ��ˣ�������Ϣ���£�" & vbCrLf & _
                nvl(rsData!����) & "  " & nvl(rsData!�Ա�) & "  " & nvl(rsData!����) & vbCrLf & _
                "�Ƿ��Ի��� [" & nvl(rsData!����) & "] ���ݼ�������?", vbYesNo, "��ʾ��Ϣ") = vbYes Then
 
                strSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,A.����ʱ��,A.��Ժʱ��,a.�Ǽ�ʱ��,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "NVL(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID " & _
                " From ������Ϣ A where ����ID=[1]"
                
                Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ������Ϣ", nvl(rsData!����ID))
                
                If rsData.RecordCount > 0 Then
                    Call FindPatient(False, rsData)
                Else
                    IDCardValid = 1
                End If
            Else
                IDCardValid = 1 'ȡ���Ǽ�
            End If
        Else
            '���ڶ�����ͬ������֤��
            strSQL = "Select Zl_Custom_Patiids_Get([1], [2], [3], [4]) As IDs from dual"
            Set rsData = zlDatabase.OpenSQLRecord(strSQL, "����֤��ѯ", mlngModul, strCardNo, strName, strSex)
            
            'û��ʵ�ʵļ�¼���ݣ����Լ����Ǽ�
            If rsData.RecordCount > 0 Then
                If nvl(rsData!IDs) = "" Then
                    '���й�����ѯ����
                    strSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,A.����ʱ��,A.��Ժʱ��,a.�Ǽ�ʱ��,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                            "NVL(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                            "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                            "nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID " & _
                    " From ������Ϣ A where ����֤��=[1] Order By Nvl(����ʱ��,nvl(��Ժʱ��,�Ǽ�ʱ��)) Desc"
                    
                Else
                    '���ݷ���IDs���й�����ѯ����
                    strSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,A.����ʱ��,A.��Ժʱ��,a.�Ǽ�ʱ��,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                            "NVL(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                            "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                            "nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID " & _
                    " From ������Ϣ A,Table(f_num2list([1])) B  where A.����ID=B.Column_Value Order By Nvl(����ʱ��,nvl(��Ժʱ��,�Ǽ�ʱ��)) Desc"
                                    
                End If
                
                strSQL = "select RowNum as ID,����id,����,�Ա�,����,����ʱ��,��Ժʱ��,�Ǽ�ʱ��,��������,��ԴID,��ҳID,���˿���ID,��ǰ����ID,ҽ��,�����," & _
                            "סԺ��,���￨��, ����״̬,����֤��,��ǰ����,�ѱ�,ҽ�Ƹ��ʽ,����֤��,����,ְҵ,����״��,�绰,�ʱ�,��ַ,��ͬ��λID " & _
                            " From (" & strSQL & ")"
                    
                '����ѡ����
                Set rsData = zlDatabase.ShowSQLSelect(Me, strSQL, 0, "����ѡ��", False, "����ID", _
                                                "�Ѵ���������֤�� " & strCardNo & " ��ͬ�Ĳ�����Ϣ����ѡ���Ӧ������Ϣ�������롣", False, False, False, _
                                                objTxtCard.Left, objTxtCard.Top, objTxtCard.Height, blnCancel, True, False, strCardNo)
                If blnCancel = True Then
                    IDCardValid = 1 'ȡ���Ǽ�
                Else
                    If rsData.RecordCount > 0 Then
                        Call FindPatient(False, rsData)
                    Else
                        IDCardValid = 1
                    End If
                End If
            End If
        End If
    Else
        '��������²��ˣ�����ݻ��ߵ�����֤���һ���ID,
        If objTxtCard.Text <> objTxtCard.tag Then
            '�޸�����֤
            '�ж�����֤�����ݿ����Ƿ���ڣ�����Ѿ����ڣ��������޸�
            Set rsData = zlDatabase.OpenSQLRecord(strSQL, "����֤��ѯ", strCardNo)
            If rsData.RecordCount > 0 Then
                MsgBoxD Me, "�Ѵ�������֤��Ϊ " & strCardNo & " �Ĳ��ˣ�������Ϣ���£�" & vbCrLf & _
                    nvl(rsData!����) & "  " & nvl(rsData!�Ա�) & "  " & nvl(rsData!����) & vbCrLf & _
                    "���������ܼ�����", vbOKOnly, "��ʾ��Ϣ"
                IDCardValid = 1 'ȡ���Ǽ�
            End If
        End If
    End If
    
    If IDCardValid = 1 Then
        objTxtCard.SetFocus
        objTxtCard.SelStart = 0
        objTxtCard.SelLength = Len(objTxtCard.Text)
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Private Sub cmdOk_Click()
    Dim l As Long
    Dim blnTran As Boolean
    Dim rsTmp As New ADODB.Recordset
    Dim rsMother As New ADODB.Recordset
    Dim rsPatiInfo As New ADODB.Recordset
    Dim int��¼���� As Integer     '����ҽ������.��¼���ʣ�����ҽ���ļ�¼���ʣ�1-�շѼ�¼��2-���ʼ�¼
    Dim int������� As Integer     '����ҽ������.������ʣ������סԺҽ��վ����Ϊ�������ʱ��Ϊ1,��������������ʺ�סԺ���ʣ������Ķ���Ϊ��
    Dim str������� As String
    Dim lng���ͺ� As Long
    Dim str���ݺ� As String
    Dim strҽ��IDs As String
    Dim lngCurFromType As Long
    Dim strMsg As String
    Dim lngMsgResult As Long
    Dim intTag As Integer
    Dim lngResult As Long
    
    On Error GoTo errhandle
    
    arrSQL = Array()
    
    lngCurFromType = mintSourceType
    If mblnAllPatientIsOutside Then mintSourceType = 3
    
    '���û�м��Ǽ�Ȩ�ޣ���ֻ���޸Ĳ����źͼ������(����ϢΪ�����ڲ���Ϣ)
    If Not Frame2.Visible Then
        If Trim(txtPatholNum.Text) = "" Then
            If MsgBoxD(Me, "�����Ų���Ϊ�գ��Ƿ��Զ����ɲ����ţ�", vbYesNo, Me.Caption) = vbYes Then
                txtPatholNum.Text = GetPatholNum(Val(cbxStudyType.Text))
            End If
            txtPatholNum.SetFocus

            Exit Sub
        End If

        '����в����ţ��ŶԴ˼����Ϣ���и���
        If Not txtPatholNum.Enabled Then
            Call MsgBoxD(Me, "������Ϣ�������༭��", vbInformation, Me.Caption)

            Exit Sub
        End If

        ReDim Preserve arrSQL(UBound(arrSQL) + 1)

        arrSQL(UBound(arrSQL)) = "Zl_��������_�������(" & mlngAdviceId & ",'" & UCase(txtPatholNum.Text) & "'," & Val(cbxStudyType.Text) & ")"
        Call zlDatabase.ExecuteProcedure(CStr(arrSQL(UBound(arrSQL))), "���²�������")

        mblnOk = True

        If mstrPatholInitNum = UCase(Trim(txtPatholNum.Text)) Then
            '���²������
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)

            arrSQL(UBound(arrSQL)) = "ZL_��������_��Ÿ���(" & Val(cbxStudyType.Text) & "," & mlngPatholSerialNum & ")"
            Call zlDatabase.ExecuteProcedure(CStr(arrSQL(UBound(arrSQL))), Me.Caption)
        End If

        Unload Me
        Exit Sub
    End If
    
    If mblnIDCardDetect And Trim(Txt����֤��.Text) <> "" Then
        '����֤Ψһ��֤
        If IDCardValid(Txt����֤��, Txt����֤��.Text, PatiIdentify.Text, zlStr.NeedName(cbo�Ա�.Text)) = 1 Then Exit Sub
    End If
    
    '������������Ƿ�Ϸ������Ϸ����˳�
    If ValidData = False Then Exit Sub
    
     If framPatholInf.Visible Then
        If Trim(txtPatholNum.Text) = "" Then
            If MsgBoxD(Me, "�����Ų���Ϊ�գ��Ƿ��Զ����ɲ����ţ�", vbYesNo, Me.Caption) = vbYes Then
                txtPatholNum.Text = GetPatholNum(Val(cbxStudyType.Text))
            End If
            txtPatholNum.SetFocus

            Exit Sub
        End If
    End If
    
    '�Ǽ� �� �Ǽ���Ϊһ�����������ݿ�����������
    ' ����ǵǼǣ��򱣴�ҽ��
    If mintEditMode = 0 Then
    '        1)ҽ��������
    '        2)����ҽ�����½����ˣ��½�ҽ��������ҽ����
        If (lngCurFromType = 1 Or lngCurFromType = 2) And mlngInsureCheckType <> 0 Then
            'ֻ�д������סԺ��������ҽ�����˲Ž���ҽ��������
            gstrSQL = "select ���� from ������Ϣ Where ����ID = [1]"
            Set rsPatiInfo = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ����������Ϣ", mlngPatiId)
            
            'ҽ��������
            strMsg = CheckAdviceInsure(Val(nvl(rsPatiInfo!����)), True, mlngPatiId, mintSourceType, _
                                        "", mlngClinicID & ":" & mlngCurDeptId, "��ǰ��Ŀ")
                                        
            If strMsg <> "" Then
                If mlngInsureCheckType = 1 Then 'ֻ��ʾ
                    lngMsgResult = MsgBoxD(Me, strMsg & vbCrLf & vbCrLf & "Ҫ��������ҽ����", vbYesNo, "��ʾ��Ϣ")
                    If lngMsgResult = vbNo Then Exit Sub
                Else    '����
                    MsgBox strMsg & vbCrLf & vbCrLf & "���Ⱥ������Ա��ϵ����������ҽ�������������档", vbInformation, "��ʾ��Ϣ"
                    Exit Sub
                End If
            End If
        End If
        
        '��֯�½����ߺͱ���ҽ����SQL��䣬��ŵ� arrSQL �У�������²��ˣ���ȡ����ID
        Call SaveAdviceData
        
        '�����ͼ���Ϣ �Ǽ�
        If framSongJian.Visible Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_��������_�ͼ����(" & mlngAdviceId & ",'" & cboUnitName.Text & "','" & _
                                                     txtFormDepart.Text & "','" & txtSubmitDoctor.Text & "','" & txtOldStudyNo & "|" & txtOldBarCode & "|" & txtSendTag.Text & "')"
        End If
        
        '--------------------------ִ�й��̣�д������
        gcnOracle.BeginTrans
        blnTran = True
        For l = 0 To UBound(arrSQL)
            Call zlDatabase.ExecuteProcedure(CStr(arrSQL(l)), "���Ǽ�")
        Next
        gcnOracle.CommitTrans
        blnTran = False
        
        '���SQL������飬Ϊ����ĵǼǺ�ֱ�ӱ�����׼��
        arrSQL = Array()
    End If
    
    
    '�޸�Ӱ����Ĳ�����Ϣ��������
    '1�����ǵǼǣ���Ҫ�޸Ĳ��˵���Ϣ�����ﲡ�˵���Ϣ�Ƚ϶�
    'ʵ�������ǣ��ǼǺ��޸ģ��������������޸�
    If mintEditMode <> 0 Then
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = "zl_Ӱ������Ϣ_�޸�(" & mintSourceType & "," & mlngAdviceId & "," & mlngPatiId & "," & _
            "'" & Trim(PatiIdentify.Text) & "','" & zlStr.NeedName(cbo�Ա�.Text) & "','" & txt����.Text & cboAge.Text & "'," & _
            "'" & zlStr.NeedName(cbo�ѱ�.Text) & "','" & zlStr.NeedName(cbo���ʽ.Text) & "','" & zlStr.NeedName(cbo����.Text) & "'," & _
            "'" & zlStr.NeedName(cbo����.Text) & "','" & zlStr.NeedName(cboְҵ.Text) & "','" & zlCommFun.ToVarchar(Txt����֤��, 18) & "'," & _
            "'" & zlCommFun.ToVarchar(Txt��ϵ��ַ.Text, 50) & "','" & zlCommFun.ToVarchar(Txt�绰, 20) & "','" & zlCommFun.ToVarchar(Txt�ʱ�, 6) & _
            "'," & zlStr.To_Date(CDate(dtp��������.value)) & "," & mlngPageID & "," & mlngBaby & ")"
    End If
    
    If mintEditMode = 1 Then
        '�����ͼ���Ϣ  �ǼǺ��޸�
        If framSongJian.Visible Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_��������_�ͼ����(" & mlngAdviceId & ",'" & cboUnitName.Text & "','" & _
                                                     txtFormDepart.Text & "','" & txtSubmitDoctor.Text & "','" & txtOldStudyNo & "|" & txtOldBarCode & "|" & txtSendTag.Text & "')"
        End If
    End If
    '1������
    '2���Ǽǣ��ҵǼǺ�ֱ�Ӽ�顣��ʵҲ���Ǳ���
    If mintEditMode = 2 Or (mblnRegToCheck And mintEditMode = 0) Then
        
        '�������Լ�һ��ͨ�Ĵ���
        'ҵ���߼��ǣ�
        '1�������߼�û���շѵĲ��ܱ�������������С�δ�ɷѱ�����Ȩ�޵ģ�������û���շѵ�����±�����
        '   ��ˢ����Ϣ��ʱ���Ѿ����Ʊ�����ȷ����ť��
        '2���Թ�������������֧�֣�
        '       ������28--����һ��ͨ�����Ѽ���ʣ����ʱ�Ƿ���Ҫ��֤
        '       ������81--ִ�к��Զ����
        '       ������163--����һ��ͨ����Ŀִ��ǰ�������շѻ��ȼ������
        '3���ȴ�����Ҫһ��ͨ����ȷ�ϵģ�����������֮һ
        '       ��1����¼����=1
        '       ��2��ִ�к��Զ����=False����¼����=2���� ����Դ<>סԺ��  ���� ����Դ=סԺ��������ʡ���
        '   ���һ��ͨ����ȷ�ϳɹ�������Ա��������һ��ͨ����ȷ�ϲ��ɹ��������Ȩ�ޡ�δ�ɷѱ�������ʾ�Ƿ����������
        '4���ٴ���һ��ͨ���ü�����֤�ģ�ֻ�������˵ģ������ǣ�
        '       ��1����¼����=2��ִ�к��Զ����=True
        '       ��2����δ��˷���
        '
        gstrSQL = "Select A.��¼����,A.�������,A.���ͺ�,A.NO,B.������� from ����ҽ������ A,����ҽ����¼ B  where A.ҽ��ID=B.ID and  B.ID =[1]"
        Set rsTmp = zlDatabase.OpenSQLRecord(gstrSQL, "PACS�������Ҽ�¼����", mlngAdviceId)
        If rsTmp.EOF = False Then
            int��¼���� = nvl(rsTmp!��¼����, 0)
            int������� = nvl(rsTmp!�������, 0)
            str������� = nvl(rsTmp!�������)
            lng���ͺ� = rsTmp!���ͺ�
            str���ݺ� = nvl(rsTmp!no)
        End If
        
        gstrSQL = "select B.���ӱ�־ From ����ҽ����¼ A, ���˹Һż�¼ B Where A.�Һŵ�=B.No And A.ID=[1]"
        Set rsTmp = zlDatabase.OpenSQLRecord(gstrSQL, "��ѯ���ӱ�־", mlngAdviceId)
        
        If rsTmp.RecordCount > 0 Then intTag = Val(nvl(rsTmp!���ӱ�־, 0))
        
        lngResult = 0
        If intTag = 3 Then '�����ﲡ��
            lngResult = NewOut�շ�(mlngAdviceId)
        End If
            
        If lngResult = 1 Then
            Exit Sub
        ElseIf lngResult = 0 Then
            
            If int��¼���� = 1 Or _
                (gblnִ�к���� = False And int��¼���� = 2 And (mintSourceType <> 2 Or (mintSourceType = 2 And int������� = 1))) Then
                
                If Not ItemHaveCash(mintSourceType, False, mlngAdviceId, 0, lng���ͺ�, str�������, str���ݺ�, int��¼����, _
                    int�������, 0) Then
                    If gblnִ��ǰ�Ƚ��� Then
                        '����һ��ͨ,��Ŀִ��ǰ�������շѻ��ȼ������,�������ݺţ�����ҽ��ID��ȡ����δ�շѵ��ݻ�δ��˵ļ��ʵ�
                        '��ȡҽ��ID��
                        strҽ��IDs = mlngAdviceId
                        gstrSQL = "Select Id  from ����ҽ����¼ where ���ID = [1]"
                        Set rsTmp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡҽ��ID��", mlngAdviceId)
                        While rsTmp.EOF = False
                            strҽ��IDs = strҽ��IDs & "," & rsTmp!ID
                            rsTmp.MoveNext
                        Wend
                        
                        If mobjSquareCard.zlSquareAffirm(Me, mlngModul, mstrPrivs, mlngPatiId, 0, False, , , strҽ��IDs) = False Then
                            '����С�δ�ɷѱ�����Ȩ�ޣ�����ʾ�Ƿ�ȷ��δ�շѿ��Ա�����
                            If CheckPopedom(mstrPrivs, "δ�ɷѱ���") Then
                                If MsgBoxD(Me, "�ɷѲ��ɹ����ò��˻�����δ�շѵķ��ã��Ƿ����������", vbYesNo, "�ɷ�ʧ��") = vbNo Then
                                    Exit Sub
                                End If
                            Else
                                MsgBoxD Me, "�ɷѲ��ɹ����ò��˻�����δ�շѵķ��ã��޷����������顣", vbOKOnly, "�ɷ�ʧ��"
                                Exit Sub
                            End If
                        End If
                    Else
                        '����С�δ�ɷѱ�����Ȩ�ޣ�����ʾ�Ƿ�ȷ��δ�շѿ��Ա�����
                        If CheckPopedom(mstrPrivs, "δ�ɷѱ���") Then
                            If MsgBoxD(Me, "�ò��˻�����δ�շѵķ��ã��Ƿ����������", vbYesNo, "��ʾ��Ϣ") = vbNo Then
                                Exit Sub
                            End If
                        Else
                            MsgBoxD Me, "�ò��˻�����δ�շѵķ��ã����顣", vbOKOnly, "��ʾ��Ϣ"
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        
        If int��¼���� = 2 Then
            'ȡ�����˵�ǰ���۷��ã���ִ�к��Զ���˻��۵�����Чʱ��
            Dim curMoney As Currency, str��� As String, str����� As String
            curMoney = GetAdviceMoney(mlngAdviceId, mintSourceType, str���, str�����)
            '�����ò�Ϊ0ʱ������Ƿ�һ��ͨˢ�����Ƿ���Ҫ���˱���
            If curMoney <> 0 Then
                '���˱���
                If Not FinishBillingWarn(Me, ";" & GetPrivFunc(100, 1257) & ";", mlngPatiId, mlngPageID, Val(lblCash.tag), curMoney, str���, str�����) Then
                    Exit Sub
                End If
                
                '���⣺34856
                '����һ��ͨ����������֤
                '����28--����һ��ͨ���Ѽ���ʣ����ʱ�Ƿ���Ҫ��֤
                '����81--ִ�к��Զ����
                If curMoney > 0 And mintSourceType = 1 Then
                    If Not zlPatiIdentify(mlngModul, Me, mlngPatiId, curMoney) Then Exit Sub
                End If
            End If
        End If
        
        '��ʼ���
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        
        'Ӱ�����"DG"��ʾ����
        arrSQL(UBound(arrSQL)) = "ZL_Ӱ����_BEGIN(Null,Null," & mlngAdviceId & "," & mlngSendNo & ",'DG','" & _
            Trim(Me.PatiIdentify.Text) & "','" & Trim(TxtӢ����.Text) & "','" & zlStr.NeedName(cbo�Ա�.Text) & "','" & _
            txt����.Text & IIf(cboAge.Visible, cboAge.Text, "") & "'," & zlStr.To_Date(dtp��������.value) & ",'" & zlCommFun.ToVarchar(Txt����, 16) & "','" & _
            zlCommFun.ToVarchar(Txt����, 16) & "',Null,Null,Null,Null,Null,'" & txt��������.Text & "',Null," & mlngCurDeptId & ",'" & zlStr.NeedName(cbo��������.Text) & "')"
        
        '����Ӱ�����¼--ִ�й���Ϊ-�ѱ���������ʱ�������˵ķ���
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = "Zl_Ӱ����_State(" & mlngAdviceId & "," & mlngSendNo & ",2,NULL,'" & UserInfo.��� & "','" & UserInfo.���� & "'," & mlngCurDeptId & ")"
        
        
        '�����ڱ���ʱ����Ҫִ�з���
        If mlngPatholStationMoneyExeModle = 0 Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_Ӱ�����ִ��(" & mlngAdviceId & "," & mlngSendNo & ",2,NULL,'" & UserInfo.��� & "','" & UserInfo.���� & "'," & mlngCurDeptId & ")"
        End If
        
        '�������ֱ�ӱ���
        If framPatholInf.Visible Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_��������_�������(" & mlngAdviceId & ",'" & UCase(txtPatholNum.Text) & "'," & Val(cbxStudyType.Text) & ")"
            
            If mstrPatholInitNum = UCase(Trim(txtPatholNum.Text)) Then
                '���²������
                ReDim Preserve arrSQL(UBound(arrSQL) + 1)
                arrSQL(UBound(arrSQL)) = "ZL_��������_��Ÿ���(" & Val(cbxStudyType.Text) & "," & mlngPatholSerialNum & ")"
            End If
        End If
        
        
        '�����ͼ���Ϣ  ����
        If framSongJian.Visible Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_��������_�ͼ����(" & mlngAdviceId & ",'" & cboUnitName.Text & "','" & _
                                                     txtFormDepart.Text & "','" & txtSubmitDoctor.Text & "','" & txtOldStudyNo & "|" & txtOldBarCode & "|" & txtSendTag.Text & "')"
        End If
        
    End If   '������if
    
    
    
    '�������޸�
    If mintEditMode = 3 Then
        
        '�޸Ĳ�����Ϣ
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = "ZL_Ӱ�����¼_UPDATE(" & mlngAdviceId & ", " & mlngSendNo & ",Null,'" & _
            Trim(Me.PatiIdentify.Text) & "','" & Trim(TxtӢ����.Text) & "','" & zlStr.NeedName(cbo�Ա�.Text) & "','" & _
            txt����.Text & IIf(cboAge.Visible, cboAge.Text, "") & "'," & zlStr.To_Date(dtp��������.value) & ",'" & zlCommFun.ToVarchar(Txt����, 16) & "','" & _
            zlCommFun.ToVarchar(Txt����, 16) & "',Null,Null,Null,'" & txt��������.Text & "',Null," & zlStr.To_Date(dtp(1).value) & ",'" & zlStr.NeedName(cbo��������.Text) & "')"
            
          '�������ֱ�ӱ���
        If framPatholInf.Visible Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_��������_�������(" & mlngAdviceId & ",'" & UCase(txtPatholNum.Text) & "'," & Val(cbxStudyType.Text) & ")"

            If mstrPatholInitNum = UCase(Trim(txtPatholNum.Text)) Then
                '���²������
                ReDim Preserve arrSQL(UBound(arrSQL) + 1)
                arrSQL(UBound(arrSQL)) = "ZL_��������_��Ÿ���(" & Val(cbxStudyType.Text) & "," & mlngPatholSerialNum & ")"
            End If
        End If

        '�����ͼ���Ϣ �������޸�
        If framSongJian.Visible Then
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = "Zl_��������_�ͼ����(" & mlngAdviceId & ",'" & cboUnitName.Text & "','" & _
                                                     txtFormDepart.Text & "','" & txtSubmitDoctor.Text & "','" & txtOldStudyNo & "|" & txtOldBarCode & "|" & txtSendTag.Text & "')"
        End If
        
        
    End If
    
    '--------------------------ִ�й��̣�д������
    gcnOracle.BeginTrans
    blnTran = True
    For l = 0 To UBound(arrSQL)
        Call zlDatabase.ExecuteProcedure(CStr(arrSQL(l)), "д������")
    Next
    gcnOracle.CommitTrans
    blnTran = False
        
    '����,��ǼǺ�ֱ�Ӽ�飬 �ĺ�������
    If mintEditMode = 2 Or (mblnRegToCheck And mintEditMode = 0) Then
        '��ӡ���뵥
        AutoPrintApplication
    End If

    '�������뵥ͼ��   �ͷ� ����
    If mintEditMode = 0 Then
        If Not frmPetitionCap Is Nothing And dcmTmpView.Images.Count > 0 Then
            Call frmPetitionCap.subSaveImage(, mlngAdviceId, dcmTmpView)
            'ж��ɨ�����뵥�������
            Set frmPetitionCap = Nothing
            
            '�������뵥ͼ��󣬽�����գ�������������ʱ��һ����黹��ͼƬ
            dcmTmpView.Images.Clear
        End If
   End If

    mblnOk = True
    '����������Ǽǣ����Ҵ��ڵǼ�״̬���򲻹رմ��ڡ�
    If mlngGoOnReg = 1 And mintEditMode = 0 Then
        Call InitMvar(mblnNameColColorCfg)  '��ʼ��ģ�����
        InitEdit '��ʼ������
        Me.PatiIdentify.SetFocus
    Else
        '������ڱ���״̬,���ߵǼǺ�ֱ�ӱ����������Ƿ���ʾ��������
        If (mintEditMode = 2 Or (mblnRegToCheck And mintEditMode = 0)) And mblnUseReferencePatient = True Then
            frmReferencePatient.ZlShowMe mlngAdviceId, Trim(PatiIdentify.Text), Me, False, mlngCurDeptId
        End If
        
        Unload Me
    End If
    
    Exit Sub
errhandle:
    If blnTran Then gcnOracle.RollbackTrans
    If ErrCenter = 1 Then
        Resume
    End If
    Call SaveErrLog
    Unload Me
End Sub
Private Sub AutoPrintApplication()
'����:�����������Զ���ӡ���뵥
Dim rsTemp As ADODB.Recordset, strBillNo As String, strExseNo As String, intExseKind As Integer
    Dim i As Integer
    Dim strResult As String
    Dim strArry() As String
    Dim strSQL As String
On Error GoTo errHand

    If Not mblnAutoPrint Then Exit Sub
    strSQL = "select NO,��¼���� from ����ҽ������ where ҽ��ID=[1] and ���ͺ�=[2]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ȡNO", mlngAdviceId, mlngSendNo)
    If rsTemp.EOF Then Exit Sub
    strExseNo = rsTemp!no: intExseKind = rsTemp!��¼����
    
    strSQL = "Select B.ͨ��,B.ID, B.���" & vbNewLine & _
                "From ��������Ӧ�� A, �����ļ��б� B" & vbNewLine & _
                "Where A.������Ŀid =[1] And A.Ӧ�ó��� =[2] And A.�����ļ�id = B.ID And B.���� = 7"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ȡ���ݱ��", mlngClinicID, CLng(Decode(mintSourceType, 1, 1, 2, 2, 1)))
    
    strBillNo = "ZLCISBILL" & Format(rsTemp!���, "00000") & "-1"

    If rsTemp.EOF Then Exit Sub
    If Not mblnChoosePrintFormat Then
    'ԭ���ķ�ʽ
        ReportOpen gcnOracle, glngSys, strBillNo, Me, "NO=" & strExseNo, "����=" & intExseKind, "ҽ��ID=" & mlngAdviceId, 2
    Else
    '�µķ�ʽ
        '������ʽѡ����
        strResult = frmFormatChoose.ZLShow(strBillNo, Me)
        
        If strResult = "0" Then
            MsgBoxD Me, "û�и�ʽ���ܴ�ӡ", vbInformation, gstrSysName
        Else
            strArry = Split(strResult, ",")
            For i = 0 To UBound(strArry)
                ReportOpen gcnOracle, glngSys, strBillNo, Me, "NO=" & strExseNo, "����=" & intExseKind, "ҽ��ID=" & mlngAdviceId, "ReportFormat=" & Val(strArry(i)), 2
            Next
        End If
    End If
    Exit Sub
errHand:
    If ErrCenter = 1 Then
        Resume
    End If
    Call SaveErrLog
End Sub

Private Sub cmdPetitionCapture_Click()
On Error GoTo errHand
    
    If frmPetitionCap Is Nothing Then
        Set frmPetitionCap = New frmPetitionCapture
    End If

     '��ɨ�����뵥����
    Call frmPetitionCap.ShowPetitionCaptureWind(mstrPrivs, _
                                            mlngCurDeptId, _
                                            nvl(Mid(cbo��������.Text, InStr(cbo��������.Text, "-") + 1, Len(cbo��������.Text))), _
                                            nvl(Trim(PatiIdentify.Text)), _
                                            nvl(txt����.Text), _
                                            nvl(Mid(cbo�Ա�.Text, InStr(cbo�Ա�.Text, "-") + 1, Len(cbo�Ա�.Text))), _
                                            nvl(txtҽ������.Text), _
                                            nvl(Txt��λ����.Text), _
                                            Not CheckPopedom(mstrPrivs, "���Ǽ�"), _
                                            IIf(mintEditMode = 0, True, False), _
                                            IIf(mintEditMode = 0, 0, mlngAdviceId), , dcmTmpView)
    
    Exit Sub
errHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdSel_Click()
Dim rsTmp As ADODB.Recordset
    
    With txtҽ������
        .Text = ""
        Set rsTmp = SelectDiagItem() '��ȡ��Ŀ
        If rsTmp Is Nothing Then 'ȡ����������
            '�ָ�ԭֵ
            .Text = .tag
            zlControl.TxtSelAll txtҽ������
            .SetFocus
            Exit Sub
        Else
            If AdviceInput(rsTmp) Then '����ѡ����Ŀ���ò�λ������
                .tag = .Text
                
                Call LoadStudyType
            Else 'ȡ����λ������
                .Text = .tag
                zlControl.TxtSelAll txtҽ������
                .SetFocus
                Exit Sub
            End If
        End If
    End With
End Sub
Private Function SelectDiagItem() As ADODB.Recordset
'ѡ������Ŀ
    Dim objPoint As RECT
    gstrSQL = "Select Distinct A.ID,A.����,A.����,Nvl(A.���㵥λ,'��') as ���㵥λ,Nvl(A.�걾��λ,' ') as �걾��λ," & _
                "A.�������� As ��Ŀ����,A.��� As ���ID,A.ID As ������ĿID,Nvl(ִ��Ƶ��,0) As ִ��Ƶ��ID," & _
                "Nvl(���㷽ʽ,0) As ���㷽ʽID,Nvl(ִ�а���,0) As ִ�а���ID,Nvl(�Ƽ�����,0) As �Ƽ�����ID," & _
                "Nvl(ִ�п���,0) As ִ�п���ID,B.Ӱ�����" & _
              " From ������ĿĿ¼ A,Ӱ������Ŀ B,������Ŀ���� C,����ִ�п��� D" & _
              " Where A.ID=B.������ĿID AND A.ID=C.������ĿID And A.ID=D.������ĿID" & _
                    " And D.ִ�п���ID=" & mlngCurDeptId & _
                    " And (A.����ʱ��=To_Date('3000-01-01','YYYY-MM-DD') Or A.����ʱ�� IS NULL) " & _
                    " and (A.վ��='" & gstrNodeNo & "' Or A.վ�� is Null) " & _
                    " And A.������� IN(" & IIf(mintSourceType = 3, "1,2,4", mintSourceType) & ",3) And Nvl(A.����Ӧ��,0)=1 " & _
                    " And Nvl(A.�����Ա�,0) IN (" & IIf(cbo�Ա�.Text Like "*��*", "1,0)", "2,0)") & _
                    " And Nvl(A.ִ��Ƶ��,0) IN(0,1)" & _
                    " And (" & zlCommFun.GetLike("A", "����", txtҽ������) & _
                            " Or " & zlCommFun.GetLike("A", "����", txtҽ������) & _
                            " Or " & zlCommFun.GetLike("C", "����", txtҽ������) & ")"
    objPoint = zlControl.GetControlRect(txtҽ������.hwnd)
     Set SelectDiagItem = zlDatabase.ShowSelect(Me, gstrSQL, 0, "ѡ��������Ŀ", True, Me.txtҽ������.Text, "", True, True, True, objPoint.Left, objPoint.Top, Me.txtҽ������.Height, True, True, True)
End Function

Private Function AdviceInput(Optional rsInput As ADODB.Recordset = Nothing) As Boolean
'���ܣ����������������Ŀ(���������)����ȱʡ�Ĳ�λ������
'������rsInput=ѡ�񷵻صļ�¼��
'���أ�mstrExtData "��λ��1;������1,������2|��λ��2;������1,������2|...<vbTab>0-����/1-����/2-����"
    Dim rsTemp As ADODB.Recordset
    Dim t_Pati As TYPE_PatiInfoEx
    Dim blnOk As Boolean
    Dim strExtData As String, strAppend As String
    Dim lngHwnd As Long, int������� As Integer
    
    On Error GoTo errhandle
    
    If Not rsInput Is Nothing Then
        txtҽ������.Text = Replace(Replace(rsInput!����, ",", ""), "'", "") '��ʱ��ʾ
    End If
    
    With t_Pati
        .lng����ID = mlngPatiId
        If mintSourceType = 2 Then  'סԺ����д��ҳID
            .lng��ҳID = mlngPageID
        Else
            .str�Һŵ� = mstrRegNo
        End If
        .str�Ա� = zlStr.NeedName(cbo�Ա�.Text)
    End With
  
    lngHwnd = IIf(mintCheckInMode = 1, Me.Txt��λ����.hwnd, Me.Txt��ϵ��ַ.hwnd)
    int������� = IIf(mintSourceType <> 2, 1, 2)
    strExtData = ""
    strAppend = mstrAppend
        
    On Error Resume Next
    '�ӿڸ��죺int����û�д��룬�ִ���0��bytUseType��ǰû�д����ִ�0
    blnOk = frmAdviceEditEx.ShowMe(Me, lngHwnd, t_Pati, 0, 0, 0, 1, int�������, , , , rsInput!������Ŀid, strExtData, strAppend)
    If Not blnOk Or strExtData = "" Then Exit Function
    err.Clear
    On Error GoTo errhandle
    
    mstrExtData = strExtData        '���� "��λ��1;������1,������2|��λ��2;������1,������2|...<vbTab>0-����/1-����/2-����"
    mstrAppend = strAppend '     ���="��Ŀ��1<Split2>0/1(�����)<Split2>Ҫ��ID<Split2>����<Split1>..."
    mlngClinicID = rsInput!������Ŀid
 
    
    Txt��λ����.tag = Split(mstrExtData, Chr(9))(1) 'ִ�б��
    Txt��λ����.Text = Replace(get��λ����(mstrExtData), "),", ")" & vbCrLf)
    Txt��λ����.Text = Txt��λ����.Text & vbCrLf & get������Ŀ(mstrAppend)
    

'    mstrItemIDS = "" '���ܸı���Ŀ,���Ե��ȸ�0
'    gstrSQL = "select �շ���ĿID FROM �����շѹ�ϵ��Where ������Ŀid=[1]"
'    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ�շ�ϸĿID", CLng(mlngClinicID))
'    Do Until rsTemp.EOF
'        mstrItemIDS = mstrItemIDS & "," & rsTemp!�շ���ĿID
'        rsTemp.MoveNext
'    Loop
'    mstrItemIDS = Mid(mstrItemIDS, 2)

    AdviceInput = True
    
    Exit Function
errhandle:
    If ErrCenter() = 1 Then
    Resume
    End If
    Call SaveErrLog
End Function
Private Function get������Ŀ(ByVal strAppend As String) As String
Dim i As Integer, strReturn As String
    For i = 0 To UBound(Split(strAppend, "<Split1>"))
        strReturn = strReturn & Split(Split(strAppend, "<Split1>")(i), "<Split2>")(0) & ":" & Split(Split(strAppend, "<Split1>")(i), "<Split2>")(3) & vbCrLf
    Next
    get������Ŀ = strReturn
End Function
Private Function get��λ����(ByVal strExtData As String) As String
'��:��λ��1;������1,������2|��λ��2;������1,������2|...<vbTab>0-����/1-����/2-����
'��:��λ��1(������1,������2),��λ��2(������1,������2)-----
Dim i As Integer, strReturn As String, Arr��λ
    Arr��λ = Split(Split(strExtData, Chr(9))(0), "|")
    For i = 0 To UBound(Arr��λ)
        strReturn = strReturn & "," & Split(Arr��λ(i), ";")(0) & "(" & Split(Arr��λ(i), ";")(1) & ")"
    Next
    get��λ���� = Mid(strReturn, 2)
End Function

Private Sub cmdSelectPinyinName_Click()
    Dim i As Long
    Dim strPinyinName As String
    Dim objPopup As CommandBar
    Dim objControl As CommandBarControl
    
    On Error GoTo errhandle
    strPinyinName = GetPinyinName(PatiIdentify.Text, mintCapital, mblnUseSplitter)
    If strPinyinName = "" Then Exit Sub

    Set objPopup = cbrMain.Add("�Ҽ��˵�", xtpBarPopup)
    With objPopup.Controls
        For i = 0 To UBound(Split(strPinyinName, ","))
            Set objControl = .Add(xtpControlButton, i + 1, Split(strPinyinName, ",")(i))
        Next
    End With
    objPopup.ShowPopup
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub dtp��������_Change()
    txt����.Text = ReCalcOld(dtp��������.value, cboAge)
End Sub

Private Sub RefreshObjEnabled(Optional lngRegType As Long)
'mintEditMode '0���Ǽǡ�1���ǼǺ��޸ġ�2��������3���������޸�
'lngRegType  '1-�µǼǡ�2-��ȡ�Ǽǡ�3-���ƵǼ�
    Dim blnIsForceModify As Boolean
    
    Dim blnShowPatholNum As Boolean
    Dim blnShowOtherInf As Boolean
    Dim blnShowStandard As Boolean
    
    Dim strRegType As String
    Dim blnIsModifyInfo As Boolean
    
    'ȫ��״̬�µ�ͳһ����
    txtPatientDept.Enabled = False
    txtID.Enabled = False
    txtBed.Enabled = False
    Txt��λ����.Locked = True
    
    blnIsForceModify = CheckPopedom(mstrPrivs, "ǿ���޸�סԺ������Ϣ")
    
    'Ĭ��ֻ���������ߵĻ�����Ϣ�������޸�
    blnIsModifyInfo = IIf(mintSourceType = 3, True, False)
    
    If mblnIDCardDetect Then
        '���������豸��ֻ������֤Ϊ�յ����������������޸�
        blnIsModifyInfo = IIf(mintSourceType = 3 And Trim(Txt����֤��.Text) = "", True, False)
        blnIsForceModify = blnIsModifyInfo
    End If

    '������Ϣ��ֻ��mintSourceType = 3���������¿����޸�
    PatiIdentify.objTxtInput.Locked = Not blnIsModifyInfo
    
    cbo�Ա�.Enabled = blnIsModifyInfo
    cboAge.Enabled = blnIsModifyInfo
    dtp��������.Enabled = blnIsModifyInfo
    Call sutSetTxtEnable(txt����, blnIsModifyInfo)
    Call sutSetTxtEnable(Txt����֤��, blnIsModifyInfo)
    
    Call sutSetTxtEnable(Txt�绰, blnIsModifyInfo)
    Call sutSetTxtEnable(Txt�ʱ�, blnIsModifyInfo)
    Call sutSetTxtEnable(Txt��ϵ��ַ, blnIsModifyInfo)
    cbo����.Enabled = blnIsModifyInfo
    cboְҵ.Enabled = blnIsModifyInfo
    cbo����.Enabled = blnIsModifyInfo
    
    'û������������֤���ʱ�������ǿ���޸�����סԺ��ϢȨ�ޣ��������޸ĵ绰����ϵ��ַ����Ϣ
    If blnIsModifyInfo = False And blnIsForceModify Then
        Call sutSetTxtEnable(Txt�绰, blnIsForceModify)
        Call sutSetTxtEnable(Txt�ʱ�, blnIsForceModify)
        Call sutSetTxtEnable(Txt��ϵ��ַ, blnIsForceModify)
        cbo����.Enabled = blnIsForceModify
        cboְҵ.Enabled = blnIsForceModify
        cbo����.Enabled = blnIsForceModify
    End If

    cbo�ѱ�.Enabled = (mintSourceType = 3)
    cbo���ʽ.Enabled = (mintSourceType = 3)
    
    blnShowPatholNum = False
    blnShowStandard = True 'CheckPopedom(mstrPrivs, "���Ǽ�")
    blnShowOtherInf = blnShowStandard And (mintCheckInMode <> 1)
    
    Select Case mintEditMode
        Case 0          '0���Ǽ�
            If lngRegType = 1 Then
                strRegType = " �� �²��� ��"
            ElseIf lngRegType = 2 Then
                strRegType = " �� ��ȡ���� ��"
            ElseIf lngRegType = 3 Then
                strRegType = " �� ���Ʋ��� ��"
            End If
            
            Me.Caption = "���Ǽ�" & strRegType
            
            '�ǼǺ�ֱ�ӱ��� ����ʾ������
            blnShowPatholNum = mblnRegToCheck
            
            '�Ǽǵ�ʱ�����������޸�
            PatiIdentify.objTxtInput.Locked = False
            
            cmdSelectPinyinName.Enabled = False
            
            Call sutSetTxtEnable(TxtӢ����, True)
            Call sutSetTxtEnable(Txt����, mblnRegToCheck)
            Call sutSetTxtEnable(Txt����, mblnRegToCheck)
            Call sutSetTxtEnable(txt��������, mblnRegToCheck)
        Case 1          '1���ǼǺ��޸�
            Me.Caption = "�޸���Ϣ"
            
            dtp(0).Enabled = False
            dtp(1).Enabled = False
            cmdSel.Enabled = False
            chk����.Enabled = False: cbo��������.Enabled = False
            cboҽ��.Enabled = False
             
            cmdSelectPinyinName.Enabled = False
            Call sutSetTxtEnable(txtҽ������, False)
            Call sutSetTxtEnable(TxtӢ����, False)
            
            Call sutSetTxtEnable(Txt����, False)
            Call sutSetTxtEnable(Txt����, False)
            Call sutSetTxtEnable(txt��������, False)
        Case 2          '2������
            Me.Caption = "��鱨��"
            
            blnShowPatholNum = True
            
            cmdSelectPinyinName.Enabled = True
            cbo��������.Enabled = False: cboҽ��.Enabled = False
            chk����.Enabled = False
            dtp(0).Enabled = False
            dtp(1).Enabled = True
            cmdSel.Enabled = False
            
            Call sutSetTxtEnable(txtҽ������, False)
            
            Call sutSetTxtEnable(TxtӢ����, False)
            Call sutSetTxtEnable(txt��������, True)
            Call sutSetTxtEnable(Txt����, True)
        Case 3          '3���������޸�
            Me.Caption = "�޸���Ϣ"
            
            blnShowPatholNum = True
            
            cmdSelectPinyinName.Enabled = True
            dtp(0).Enabled = False
            dtp(1).Enabled = True
            cmdSel.Enabled = False
            chk����.Enabled = False
            cbo��������.Enabled = False
            cboҽ��.Enabled = False
            
            Call sutSetTxtEnable(txtҽ������, False)
            
            Call sutSetTxtEnable(TxtӢ����, False)
            Call sutSetTxtEnable(Txt����, True)
            Call sutSetTxtEnable(Txt����, True)
            Call sutSetTxtEnable(txt��������, True)
    End Select
    
    framSongJian.Visible = mblnShowSentInfo
    Frame2.Height = IIf(mblnShowSentInfo, 4455, 2765)

    '��ʾ�����ŵ��������
    '1.������ʱ����Ϊʹ�ñ걾���յĹ��ܣ���Ҫ�ڸô�������ʾ������
    '2.�޸Ĳ��������Ϣ��ʱ����Ҫ�ڸô�������ʾ������
    '3.�ǼǺ�ֱ�ӱ���
    framPatholInf.Visible = blnShowPatholNum
    
    If blnShowPatholNum Then
        framPatholInf.Top = Frame2.Top + Frame2.Height
        
        frm������Ϣ.Top = framPatholInf.Top + framPatholInf.Height
    Else
        frm������Ϣ.Top = Frame2.Top + Frame2.Height
    End If
    
    '�������ڸ߶�
    Me.Height = IIf(blnShowStandard, Frame2.Top + 240, 0) + _
                IIf(blnShowStandard, Frame2.Height + 120, 0) + _
                IIf(blnShowPatholNum, framPatholInf.Height + 120, 120) + _
                IIf(blnShowOtherInf, frm������Ϣ.Height, 0) + 120 + cmdOk.Height
                
                
    '������ťλ��
    cmdOk.Top = Me.ScaleHeight - cmdOk.Height - 120
    CmdCancle.Top = cmdOk.Top
    cmdPetitionCapture.Top = cmdOk.Top
    PatiIdentify.BackColor = Txt����֤��.BackColor
End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)
    If Chr(KeyAscii) = "'" Then KeyAscii = 0: Exit Sub
End Sub

Private Sub LoadStudyType()
    '����������
    On Error GoTo errH
    Dim i As Integer
    Dim strSQL As String
    Dim rsData As ADODB.Recordset

'    strSQL = "select ID,���� from �����������"
    strSQL = "select ID,���� from ����������� order by ID"
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ò����������")

    If rsData.RecordCount > 0 Then
        With cbxStudyType
        .Clear
            rsData.MoveFirst
            Do While Not rsData.EOF
                If nvl(rsData!����, "  ") <> "  " Then
                    .AddItem nvl(rsData!ID, 0) & "-" & rsData!����
                End If
                rsData.MoveNext
            Loop

        End With
    End If

    '������� ��Ϊ �ǼǺ�ֱ�ӱ��� �� �����Ǽ� ������ء�
    If mblnRegToCheck And mintEditMode = 0 Then
        strSQL = "select ִ�з��� from ������ĿĿ¼ where ��������='����' and ���� =[1]"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ü����Ŀ��Ӧ��ִ�з���", txtҽ������.Text)
    Else
        strSQL = "select ִ�з��� from ������ĿĿ¼ where ID= (select ������ĿID from ����ҽ����¼ where id=[1])"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "��ȡҽ���е�ִ�з���", mlngAdviceId)
    End If

    If rsData.RecordCount > 0 Then
        For i = 0 To cbxStudyType.ListCount - 1
            If Val(Mid(cbxStudyType.list(i), 1, InStr(cbxStudyType.list(i), "-") - 1)) = Val(nvl(rsData!ִ�з���)) Then
                cbxStudyType.ListIndex = i
                Exit Sub
            End If
            cbxStudyType.ListIndex = 0
        Next
    Else
        cbxStudyType.ListIndex = 0
    End If
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, gstrSysName
End Sub

Private Sub Form_Load()
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    '�ж��Ƿ���Ҫ��������֤ʶ��
    mblnIDCardDetect = IIf(Val(zlDatabase.GetPara(279, glngSys, , 0)) = 0, False, True) _
        Or IIf(Val(zlDatabase.GetPara(319, glngSys, , 0)) = 0, False, True)
    
    mblnShowSentInfo = Val(zlDatabase.GetPara("¼����Ժ��Ϣ", glngSys, mlngModul, 0)) '�Ƿ���ʾ�ͼ���Ϣ
    mStrOutSideCfg = zlDatabase.GetPara("��Ժ��λ�ṹ����", glngSys, mlngModul, "0") '�Ƿ���ʾ�ͼ���Ϣ
    
    mlngGoOnReg = Val(zlDatabase.GetPara("�����Ǽ�����", glngSys, mlngModul, 0)) '�����Ǽ�
    mblnRegToCheck = (Val(GetDeptPara(mlngCurDeptId, "�ǼǺ�ֱ�Ӽ��", 0)) = 1) '�ǼǺ�ֱ�Ӽ��
    mblnAutoPrint = Val(zlDatabase.GetPara("�������Զ���ӡ���뵥", glngSys, mlngModul, 0)) '�������Զ���ӡ���뵥
    mblnAllPatientIsOutside = IIf(Val(GetDeptPara(mlngCurDeptId, "���еǼǲ��˱��Ϊ����", 0)) = 0, False, True)
    mlngPatholStationMoneyExeModle = Val(zlDatabase.GetPara("��������ִ��ģʽ", glngSys, mlngModul, 0))
    
    mlngInsureCheckType = Val(zlDatabase.GetPara(59, glngSys))  '��ȡҽ������������
    If mlngInsureCheckType <> 0 Then
        Set mobjInsure = CreateObject("zl9Insure.clsInsure")
    End If
    
    '���������㲿��
    Set mobjSquareCard = CreateObject("zl9CardSquare.clsCardSquare")
    '��ʼ�������㲿��
    mobjSquareCard.zlInitComponents Me, mlngModul, glngSys, gstrDBUser, gcnOracle
    
    '��ʼ��PatiIdentify
    PatiIdentify.IDKindStr = "��|����|0|0|0|0|0|0|0|0|0;ҽ|ҽ����|0|0|0|0|0|0|0|0|0;��|��������֤|1|2|18|0|0||0|1|0;IC|IC��|1|3|8|0|0||0|1|0;��|�����|0|0|0|0|0|0|0|0|0;��|���￨|0|1|8|0|0||0|0|0;��|�Һŵ���|0|0|0|0|0|0|0|0|0;��|�շѵ��ݺ�|0|0|0|0|0|0|0|0|0"
    PatiIdentify.zlInit Me, glngSys, mlngModul, gcnOracle, gstrDBUser, mobjSquareCard, PatiIdentify.IDKindStr
    
    '��Ĭ��ֵ
    mlngUnicode = 0
'    mlngTypeSuit = 0
    mblnLike = False
    mlngLike = 0
    mblnChangeNo = False
    mBeforeDays = 2
'    If mintEditMode = 0 Then mlngBaby = 0        '����Ĭ��ֵ������Ӥ��,ֻ�еǼ�ģʽ������
    
    strSQL = "select ID ,����ID,������,����ֵ from Ӱ�����̲��� where ����ID = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mlngCurDeptId)
    
    While Not rsTemp.EOF
        Select Case rsTemp!������
            Case "���߼��ű��ֲ���"
                mlngUnicode = nvl(rsTemp!����ֵ, 0)
            Case "���ű��ֲ������"
                mlngUnicodeType = nvl(rsTemp!����ֵ, 0)
            Case "�������ɷ�ʽ"
                mlngBuildType = nvl(rsTemp!����ֵ, 0)
'            Case "ƥ�����ݿ���Ŀ"
'                mlngTypeSuit = Nvl(rsTemp!����ֵ, 0)
            Case "�Ǽ�ʱ����ģ����������"
                mblnLike = IIf(nvl(rsTemp!����ֵ, 0) <> 0, True, False)
                mlngLike = Abs(nvl(rsTemp!����ֵ, 0))
            Case "�ֹ���������"
                mblnChangeNo = nvl(rsTemp!����ֵ, 0) = 1
            Case "Ĭ�Ϲ�������"
                mBeforeDays = Abs(nvl(rsTemp!����ֵ, 2))
            Case "���������ظ�"
            Case "������������"
                mblnUseReferencePatient = nvl(rsTemp!����ֵ, 0) = 1
            Case "ƴ������Сд"
                mintCapital = nvl(rsTemp!����ֵ, 0)
            Case "ƴ�����ָ���"
                mblnUseSplitter = nvl(rsTemp!����ֵ, 0) = 0
        End Select
        rsTemp.MoveNext
    Wend
    
    '���벡���������
    Call LoadStudyType
    
    InitFaceScheme
    InitEdit  '��ʼ����������
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub
Public Sub InitMvar(ByVal setNameColor As Boolean)
    mintSourceType = 3
    mlngPatiId = 0
    mlngPageID = 0
    mlngBaby = 0
'    mstrItemType = ""
    mInputType = 6
    mstrChargeNo = ""
    mstrRegNo = ""
    mstrExtData = ""
    mlngClinicID = 0
'    mstrItemIDS = ""
    mstrAppend = ""
    mstrOutNo = 0
    mstrCardNo = ""
    mstrCardPass = ""
    mblnNameColColorCfg = setNameColor
End Sub

Private Function ReCalcBirth(ByVal strOld As String, ByVal str���䵥λ As String) As String
'����:������������䵥λ���㲡�˵ĳ�������,���䵥λΪ��ʱ,�������ռٶ�Ϊ1��1��,���䵥λΪ��ʱ,�������ڼٶ�Ϊ1��
'����:��������
    Dim strTmp As String, strFormat As String, lngDays As Long
    Dim curDate As Date
    
    curDate = zlDatabase.Currentdate
    
    strTmp = "____-__-__"
    If str���䵥λ = "" Then
        strFormat = "YYYY-MM-DD"
        If strOld Like "*��*��" Or strOld Like "*��*����" Then
            strFormat = "YYYY-MM-01"
            lngDays = 365 * Val(strOld) + 30 * Val(Mid(strOld, InStr(1, strOld, "��") + 1))
        ElseIf strOld Like "*��*��" Or strOld Like "*����*��" Then
            lngDays = 30 * Val(strOld) + Val(Mid(strOld, InStr(1, strOld, "��") + 1))
        ElseIf strOld Like "*��" Or IsNumeric(strOld) Then
            strFormat = "YYYY-01-01"
            lngDays = 365 * Val(strOld)
        ElseIf strOld Like "*��" Or strOld Like "*����" Then
            strFormat = "YYYY-MM-01"
            lngDays = 30 * Val(strOld)
        ElseIf strOld Like "*��" Then
            lngDays = Val(strOld)
        End If
        If lngDays <> 0 Then strTmp = Format(DateAdd("d", lngDays * -1, curDate), strFormat)
    ElseIf strOld <> "" Then
        Select Case str���䵥λ
            Case "��"
                If Val(strOld) > 200 Then lngDays = -1
            Case "��"
                If Val(strOld) > 2400 Then lngDays = -1
            Case "��"
                If Val(strOld) > 73000 Then lngDays = -1
        End Select
        
        If lngDays = 0 Then
            strTmp = Switch(str���䵥λ = "��", "yyyy", str���䵥λ = "��", "m", str���䵥λ = "��", "d")
            strTmp = Format(DateAdd(strTmp, Val(strOld) * -1, curDate), "YYYY-MM-DD")
            
            If str���䵥λ = "��" Then
                strTmp = Format(strTmp, "YYYY-01-01")
            ElseIf str���䵥λ = "��" Then
                strTmp = Format(strTmp, "YYYY-MM-01")
            End If
        End If
    End If
    If strTmp = "____-__-__" Then strTmp = Format(curDate, "YYYY-MM-DD")
    ReCalcBirth = strTmp
End Function
Function CheckOldData(ByRef txt���� As TextBox, ByRef cbo���䵥λ As ComboBox) As Boolean
'���ܣ������������ֵ����Ч��
'���أ�
    If Not IsNumeric(txt����.Text) Then CheckOldData = True: Exit Function
    
    Select Case cbo���䵥λ.Text
        Case "��"
            If Val(txt����.Text) > 200 Then
                MsgBox "���䲻�ܴ���200��!", vbInformation, gstrSysName
                If txt����.Enabled And txt����.Visible Then txt����.SetFocus
                CheckOldData = False: Exit Function
            End If
        Case "��"
            If Val(txt����.Text) > 2400 Then
                MsgBox "���䲻�ܴ���2400��!", vbInformation, gstrSysName
                If txt����.Enabled And txt����.Visible Then txt����.SetFocus
                CheckOldData = False: Exit Function
            End If
        Case "��"
            If Val(txt����.Text) > 73000 Then
                MsgBox "���䲻�ܴ���73000��!", vbInformation, gstrSysName
                If txt����.Enabled And txt����.Visible Then txt����.SetFocus
                CheckOldData = False: Exit Function
            End If
    End Select
    CheckOldData = True
End Function
Private Function ReCalcOld(ByVal DateBir As Date, ByRef cbo���䵥λ As ComboBox, _
    Optional ByVal lng����ID As Long, Optional ByVal RequestDate As Date) As String
'����:���ݳ����������¼��㲡�˵�����,�������䵥λ
'����:����,���䵥λ
    Dim rsTmp As ADODB.Recordset, strSQL As String
    Dim strTmp As String
 
 On Error GoTo errH
    
    If RequestDate = CDate("0") Then
        strSQL = "Select Zl_Age_Calc([1],[2]) old From Dual"
        
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, _
                                App.ProductName, _
                                lng����ID, _
                                IIf(DateBir = CDate("0"), Null, DateBir) _
                                )
    Else
        strSQL = "Select Zl_Age_Calc([1],[2], [3]) old From Dual"
        
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, _
                                App.ProductName, _
                                lng����ID, _
                                IIf(DateBir = CDate("0"), Null, DateBir), _
                                IIf(RequestDate = CDate("0"), Null, RequestDate) _
                                )
    End If
    
    If Not IsNull(rsTmp!old) Then
        If rsTmp!old Like "*��" Or rsTmp!old Like "*��" Or rsTmp!old Like "*��" Then
            strTmp = Mid(rsTmp!old, 1, Len(rsTmp!old) - 1)
            If IsNumeric(strTmp) Then
                Call zlControl.CboLocate(cbo���䵥λ, Mid(rsTmp!old, Len(rsTmp!old), 1))
            Else
                strTmp = rsTmp!old
                cbo���䵥λ.ListIndex = -1
            End If
        ElseIf rsTmp!old Like "*Сʱ" Or rsTmp!old Like "*����" Then
            strTmp = rsTmp!old
            cbo���䵥λ.ListIndex = -1
        Else
            strTmp = rsTmp!old
            If IsNumeric(strTmp) Then
                cbo���䵥λ.ListIndex = 0
            Else
                cbo���䵥λ.ListIndex = -1
            End If
        End If
    End If
    If cbo���䵥λ.ListIndex = -1 Then
        cbo���䵥λ.Visible = False
    Else
        If cbo���䵥λ.Visible = False Then cbo���䵥λ.Visible = True
    End If
    
    ReCalcOld = strTmp
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function
Private Function GetPatient(strCode As String, blnCard As Boolean) As ADODB.Recordset
'���ܣ���ȡ������Ϣ������ʾ�ò��˴��ڵ�ҽ��ʱ��
Dim strNO As String, strSeek As String
Dim objRect As RECT, blnCancel As Boolean
Dim lng�����ID As Long
Dim lng����ID As Long
Dim rsTemp As ADODB.Recordset
Dim strSQL As String

'mInputType  0-���￨ 1-����ID 2-סԺ�� 3-����� 4-�Һŵ� 5-�շѵ��ݺ� 6-���� 7-ҽ���� 8-����֤�� 9-IC����
    On Error GoTo errH

    mstrChargeNo = "": mstrRegNo = ""
    strSeek = strCode
    '�жϵ�ǰ����ģʽ
    Select Case PatiIdentify.IDKindIDX
        Case PatiIdentify.GetKindIndex(IDKind_ҽ����)
            mInputType = 7
            strSeek = strCode
        Case PatiIdentify.GetKindIndex(IDKind_����֤��)
            strSQL = "Select Zl_Custom_Patiids_Get([1], [2], [3]) As ID from dual"
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "����������Zl_Custom_Patiids_Get", mlngModul, strCode, "")
            
            If rsTemp.RecordCount > 0 Then
                If nvl(rsTemp!ID) <> "" Then
                    mInputType = 10
                    strSeek = rsTemp!ID
                    GoTo NextStep
                End If
            End If
                
            mInputType = 8
            strSeek = strCode
        Case PatiIdentify.GetKindIndex(IDKind_IC����)
            mInputType = 9
            strSeek = strCode
        Case PatiIdentify.GetKindIndex(IDKind_�����)
            mInputType = 3
            strSeek = Val(strCode)
        Case PatiIdentify.GetKindIndex(IDKind_סԺ��)
            mInputType = 2
            strSeek = Val(strCode)
        Case PatiIdentify.GetKindIndex(IDKind_�Һŵ�)
            mInputType = 4
            strSeek = strCode
        Case PatiIdentify.GetKindIndex(IDKind_�շѵ��ݺ�)
            mInputType = 5
            strSeek = strCode
        Case Else
             'ʹ��������ʱ�򣬾���ֱ��ˢ��������������ˢ���ķ���һ����
             If PatiIdentify.IDKindIDX = PatiIdentify.GetKindIndex(IDKind_����) Then
            '������������ʹ��Zl_Custom_Patiids_Get����ҵ�����IDֱ�Ӳ��ҡ�
                strSQL = "Select Zl_Custom_Patiids_Get([1], [2], [3]) As ID from dual"
                Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "����������Zl_Custom_Patiids_Get", mlngModul, "", strCode)
                
                If rsTemp.RecordCount > 0 Then
                    If nvl(rsTemp!ID) <> "" Then
                        mInputType = 10
                        strSeek = rsTemp!ID
                        GoTo NextStep
                    End If
                End If
            End If
            
            If PatiIdentify.IDKindIDX = PatiIdentify.GetKindIndex(IDKind_����) And blnCard = False And InStr(",1,2,3,4,5,6,7,8,9,0,", Left(strCode, 1)) <= 1 Then
                '�����������ǲ���ˢ����
                If Left(strCode, 1) = "-" And IsNumeric(Mid(strCode, 2)) Then    '����ID
                    mInputType = 1
                    strSeek = Mid(strCode, 2)
                ElseIf Left(strCode, 1) = "+" And IsNumeric(Mid(strCode, 2)) Then 'סԺ��
                    mInputType = 2
                    strSeek = Mid(strCode, 2)
                ElseIf Left(strCode, 1) = "*" And IsNumeric(Mid(strCode, 2)) Then '�����
                    mInputType = 3
                    strSeek = Mid(strCode, 2)
                ElseIf Left(strCode, 1) = "." Then '�Һŵ�
                    mInputType = 4
                    strSeek = Mid(strCode, 2)
                ElseIf Left(strCode, 1) = "/" Then '�շѵ��ݺ�
                    mInputType = 5
                    strSeek = Mid(strCode, 2)
                ElseIf Not IsNumeric(Mid(strCode, 2)) Then '��������
                    mInputType = 6
                    strSeek = strCode
                End If
            Else
                '������̬���ֵ�ҽ�ƿ�
                '�������ģ���ȡ��صĲ���ID
                '��������,��ȡ��صĲ���ID
                '����|�����|ˢ����־|�����ID|���ų���|ȱʡ��־(1-��ǰȱʡ;0-��ȱʡ)|
                '�Ƿ�����ʻ�(1-�����ʻ�;0-�������ʻ�)|��������(�ڼ�λ���ڼ�λ����,��Ϊ������)
                '��7λ��,��ֻ��������,��Ȼȡ������
                If PatiIdentify.IDKindIDX = PatiIdentify.GetKindIndex(IDKind_����) And blnCard Then
                    lng�����ID = Val(PatiIdentify.GetDefaultCardTypeID)
                Else
                    lng�����ID = Val(PatiIdentify.GetCurCard.�ӿ����)
                End If
                
                If lng�����ID <> 0 Then
                    If mobjSquareCard.zlGetPatiID(lng�����ID, strCode, False, lng����ID) = False Then
                        lng����ID = 0
                    End If
                Else
                    If mobjSquareCard.zlGetPatiID(IIf(PatiIdentify.GetCurCard.���� = "����", "���￨��", PatiIdentify.GetCurCard.����), strCode, False, lng����ID) = False Then
                        lng����ID = 0
                    End If
                End If
                '��ǲ��ҷ�ʽʹ�ò���ID
                mInputType = 1
                strSeek = lng����ID
            End If
    End Select
NextStep:
    '����ID ���� �Ա� ���� ��Դ ���˿��� ��ҳid ���˿���ID ҽ�� סԺ�� ����� ��ǰ����
    '    �ѱ� ҽ�Ƹ��ʽ ����֤�� ���� ְҵ ����״�� �绰 �ʱ� ��ַ
    If mInputType = 0 Then 'ˢ��
        gstrSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Decode(A.��ǰ����id,Null,Nvl(B.ִ�в���ID,0),A.��ǰ����id) As ���˿���ID,A.��ǰ����ID,B.ִ���� As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���" & _
                        " From ������Ϣ A,���˹Һż�¼ B Where A.���￨��=[1] And A.����ID=B.����ID(+) And A.�����=B.�����(+) and B.��¼����=1 and B.��¼״̬=1 and '%'='%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������

    ElseIf mInputType = 1 Then '����ID
         gstrSQL = "select ����id,����,�Ա�,����,��������,��ԴID,��ҳID,���˿���ID,��ǰ����ID,ҽ��,�����,סԺ��,���￨��,����״̬,����֤��,��ǰ����,�ѱ�" & _
                        ",ҽ�Ƹ��ʽ,����֤��,����,ְҵ,����״��,�绰,�ʱ�,��ַ,��ͬ��λID, �²���" & _
                    " From(Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Decode(A.��ǰ����id,Null,Nvl(B.ִ�в���ID,0),A.��ǰ����id) As ���˿���ID,A.��ǰ����ID,Nvl(B.ִ����,'') As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���,B.�Ǽ�ʱ��" & _
                  " From ������Ϣ A,���˹Һż�¼ B Where A.����ID=[2] And A.����ID=B.����ID(+) And A.�����=B.�����(+) and '%'='%' " & _
                  " order by B.�Ǽ�ʱ�� desc) where rownum=1" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    ElseIf mInputType = 2 Then 'סԺ��
        gstrSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Decode(A.��ǰ����id,Null,Nvl(B.��Ժ����ID,0),A.��ǰ����id) As ���˿���ID,A.��ǰ����ID,B.סԺҽʦ As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���" & _
                  " From ������Ϣ A,������ҳ B " & _
                  " Where A.סԺ��=[1] And A.����ID=B.����ID and A.��Ժʱ�� Is Null and '%'='%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    ElseIf mInputType = 3 Then '�����
        gstrSQL = "select ����id,����,�Ա�,����,��������,��ԴID,��ҳID,���˿���ID,��ǰ����ID,ҽ��,�����,סԺ��,���￨��,����״̬,����֤��,��ǰ����,�ѱ�" & _
                        ",ҽ�Ƹ��ʽ,����֤��,����,ְҵ,����״��,�绰,�ʱ�,��ַ,��ͬ��λID, �²���" & _
                    " From (Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Decode(A.��ǰ����id,Null,Nvl(B.ִ�в���ID,0),A.��ǰ����id) As ���˿���ID,A.��ǰ����ID,B.ִ���� As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,B.�Ǽ�ʱ��,A.��ͬ��λID, 0 as �²���" & _
                         " From ������Ϣ A,���˹Һż�¼ B Where A.�����=[1] And A.����ID=B.����ID(+) And A.�����=B.�����(+) and B.��¼����=1 and B.��¼״̬=1 Order By B.�Ǽ�ʱ�� Desc)" & _
                    " where Rownum=1 and '%'='%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
                    
    ElseIf mInputType = 4 Then '�Һŵ�
        strNO = zlCommFun.GetFullNO(strSeek, 12)
        PatiIdentify.Text = strNO
'        mstrRegNo = strNO
        gstrSQL = "Select Distinct A.����id, A.����, A.�Ա�, A.����, To_Char(A.��������, 'yyyy-mm-dd') ��������, Decode(Nvl(A.��Ժ, 0), 0, 1, 2) As ��Դid," & vbNewLine & _
                    "                A.��ҳid, Nvl(B.ִ�в���id, B.ת�����id) As ���˿���id, A.��ǰ����ID,B.ִ���� As ҽ��, Nvl(A.�����, B.�����) �����, A.סԺ��," & vbNewLine & _
                    "                A.���￨��, decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��, A.��ǰ����, A.�ѱ�, A.ҽ�Ƹ��ʽ, A.����֤��, A.����, A.ְҵ, A.����״��, Nvl(A.��ͥ�绰, A.��ϵ�˵绰) �绰," & vbNewLine & _
                    "                Nvl(A.��ͥ��ַ�ʱ�, A.��λ�ʱ�) �ʱ�, Nvl(A.��ͥ��ַ, A.������λ) ��ַ, A.��ͬ��λid, 0 as �²���" & vbNewLine & _
                    "From ������Ϣ A, ���˹Һż�¼ B" & vbNewLine & _
                    "Where B.NO = [3] And B.����id = A.����id and B.��¼����=1 and B.��¼״̬=1 and '%'='%'"  'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
                    
    ElseIf mInputType = 5 Then '�շѵ��ݺ�
        strNO = zlCommFun.GetFullNO(strSeek, 13)
        PatiIdentify.Text = strNO
        mstrChargeNo = strNO
        
        '������ü�¼��NO=���˹Һż�¼��NO������ʹ���շѵ��ݺ���ȡ���˵�ʱ��ͬʱ��¼�Һŵ���
        '���û�йҺŵ�Ϊ�գ���ͨ���շѵ��ݺ���ȡ���Ǽǵ����ﲡ�ˣ�������ҽ�����ݡ�
'        mstrRegNo = strNO
        
        gstrSQL = "Select Distinct Nvl(A.����id, 0) ����id, Nvl(A.����, B.����) ����, Nvl(A.�Ա�, B.�Ա�) �Ա�, Nvl(A.����, B.����) ����," & vbNewLine & _
                    "                To_Char(A.��������, 'yyyy-mm-dd') ��������, Decode(Nvl(A.��Ժ, 0), 0, 1, 2) As ��Դid, A.��ҳid," & vbNewLine & _
                    "                Nvl(B.��������id, B.���˿���id) As ���˿���id, A.��ǰ����ID,Nvl(B.������, B.ִ����) As ҽ��, Nvl(A.�����, B.��ʶ��) �����, A.סԺ��, A.���￨��, decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��," & vbNewLine & _
                    "                A.��ǰ����, A.�ѱ�, A.ҽ�Ƹ��ʽ, A.����֤��, A.����, A.ְҵ, A.����״��, Nvl(A.��ͥ�绰, A.��ϵ�˵绰) �绰, Nvl(A.��ͥ��ַ�ʱ�, A.��λ�ʱ�) �ʱ�," & vbNewLine & _
                    "                Nvl(A.��ͥ��ַ, A.������λ) ��ַ, A.��ͬ��λid, 0 as �²���" & vbNewLine & _
                    "From ������Ϣ A, ������ü�¼ B" & vbNewLine & _
                    "Where B.NO = [3] And Mod(B.��¼����,10) = 1 And B.��¼״̬ = 1 And Nvl(B.����״̬,0) <>1 And B.����id = A.����id(+) And '%' = '%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    ElseIf mInputType = 6 Then '��������
            gstrSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Nvl(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���" & _
                " From ������Ϣ A Where " & IIf(mblnLike = False, "A.����=[1]", IIf(mlngLike = 0, "instr(A.����,[1])>0", "A.�Ǽ�ʱ�� Between sysdate-" & mlngLike & " and sysdate and instr(A.����,[1])>0"))
    ElseIf mInputType = 7 Then 'ҽ����
        gstrSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Nvl(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���" & _
                  " From ������Ϣ A Where A.ҽ����=[1] and '%'='%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    ElseIf mInputType = 8 Then '����֤��
        gstrSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Nvl(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���" & _
                  " From ������Ϣ A Where A.����֤��=[1] and '%'='%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    ElseIf mInputType = 9 Then 'IC����
        gstrSQL = "Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Nvl(A.��ǰ����id,0) As ���˿���ID,A.��ǰ����ID,'' As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���" & _
                  " From ������Ϣ A Where A.IC����=[1] and '%'='%'" 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    ElseIf mInputType = 10 Then '  ","���ӵĶ������ID
        gstrSQL = "select ����id,����,�Ա�,����,��������,��ԴID,��ҳID,���˿���ID,��ǰ����ID,ҽ��,�����,סԺ��,���￨��,����״̬,����֤��,��ǰ����,�ѱ�" & _
                        ",ҽ�Ƹ��ʽ,����֤��,����,ְҵ,����״��,�绰,�ʱ�,��ַ,��ͬ��λID, �²���" & _
                    " From(Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Decode(A.��ǰ����id,Null,Nvl(B.ִ�в���ID,0),A.��ǰ����id) As ���˿���ID,A.��ǰ����ID,Nvl(B.ִ����,'') As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,Nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "Nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,Nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���,B.�Ǽ�ʱ��" & _
                  " From ������Ϣ A,���˹Һż�¼ B,Table(f_num2list([1])) C Where A.����ID=C.Column_Value And A.����ID=B.����ID(+) And A.�����=B.�����(+) and '%'='%' " & _
                  " order by B.�Ǽ�ʱ�� desc) " 'Ϊ���һ��Ҳ��������������%,%��ShowSQLSelect������
    End If


    gstrSQL = gstrSQL & " Union " & _
                "Select null ����ID,'�²���' ����,'δ֪' �Ա�,'' ����,null ��������,3 As ��ԴID,0 As ��ҳID," & _
                        "0 As ���˿���ID,0 As ��ǰ����ID,'' As ҽ��,null as �����,null as סԺ��,'' as ���￨��, '' as ����״̬,'' ����֤��,'' as ��ǰ����," & _
                        "'' as �ѱ�,'' as ҽ�Ƹ��ʽ,'' as ����֤��,'' as ����,'' as  ְҵ,'' as ����״��,'' �绰,'' �ʱ�,'' ��ַ,0 ��ͬ��λID, 1 as �²���" & _
             " From dual where '%'='%'"
    gstrSQL = "select RowNum as ID,����id,����,�Ա�,����,��������,��ԴID,��ҳID,���˿���ID,��ǰ����ID,ҽ��,�����," & _
                "סԺ��,���￨��,����״̬,����֤��,��ǰ����,�ѱ�,ҽ�Ƹ��ʽ,����֤��,����,ְҵ,����״��,�绰,�ʱ�,��ַ,��ͬ��λID" & _
                " From (" & gstrSQL & ") Order by �²��� asc, ����ID desc"
    objRect = zlControl.GetControlRect(PatiIdentify.hwnd)
    
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "�Ƿ������ͬ����", CStr(strSeek), Val(strSeek), strNO)
    mblnIsSamePatient = IIf(rsTemp.RecordCount > 1, True, False)
    
    If mInputType = 10 Then
        Set GetPatient = zlDatabase.ShowSQLSelect(Me, gstrSQL, 0, "�鲡����Ϣ", False, "����ID", "", False, False, True, objRect.Left, objRect.Top, PatiIdentify.Height, blnCancel, True, False, CStr(strSeek), strSeek, strNO)
    Else
        Set GetPatient = zlDatabase.ShowSQLSelect(Me, gstrSQL, 0, "�鲡����Ϣ", False, "����ID", "", False, False, True, objRect.Left, objRect.Top, PatiIdentify.Height, blnCancel, True, False, CStr(strSeek), Val(strSeek), strNO)
    End If
    Exit Function
    
errH:
    If ErrCenter() = 1 Then
        Resume
    End If
    Call SaveErrLog
End Function
Private Function GetDictData(strDict As String) As ADODB.Recordset
'���ܣ���ָ�����ֵ��ж�ȡ����
'������strDict=�ֵ��Ӧ�ı���
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String
    
    On Error GoTo errH
        
    strSQL = "Select ����,Nvl(����,'δ֪') as ����,Nvl(ȱʡ��־,0) as ȱʡ From " & strDict & " Order by ����"
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "��ȡ" & strDict)
    
    If Not rsTmp.EOF Then Set GetDictData = rsTmp
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function
Private Sub InitDoctors(ByVal lng����ID As Long)
'���ܣ���ȡ��ǰ���������а�����������Ա
On Error GoTo errH
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String, i As Long
    
    strSQL = "Select " & vbNewLine & _
                "Distinct b.id,b.����, Upper(b.����) As ����" & vbNewLine & _
                " From ������Ա a, ��Ա�� b, ��Ա����˵�� c" & vbNewLine & _
                " Where a.��Աid = b.Id And b.Id = c.��Աid And c.��Ա���� = 'ҽ��' And" & vbNewLine & _
                "      (b.����ʱ�� = To_Date('3000-01-01', 'YYYY-MM-DD') Or b.����ʱ�� Is Null) and a.����id = [1] " & vbNewLine & _
                " Order By ���� "
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lng����ID)
    cboҽ��.Clear
    If Not rsTmp.EOF Then
        Do Until rsTmp.EOF
            cboҽ��.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ID = UserInfo.ID Then cboҽ��.ListIndex = cboҽ��.NewIndex
            rsTmp.MoveNext
        Loop
        If cboҽ��.ListCount > 0 And cboҽ��.ListIndex = -1 Then cboҽ��.ListIndex = 0
        cboҽ��.Enabled = True
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub
Private Sub InitInput()
On Error GoTo errH
    Dim i As Integer, strInput As String
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    strSQL = "select ID ,����ID,����ֵ from Ӱ�����̲��� where ����ID = [1] and ������ = [2]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mlngCurDeptId, CStr("�������"))
    If Not rsTemp.EOF Then
        strInput = nvl(rsTemp!����ֵ)
    End If
    
    For i = 0 To UBound(Split(strInput, "|"))
        Select Case Split(strInput, "|")(i)
            Case "Ӣ����"
                TxtӢ����.TabStop = False
            Case "�Ա�"
                cbo�Ա�.TabStop = False
            Case "����"
                txt����.TabStop = False
                cboAge.TabStop = False
            Case "��������"
                dtp��������.TabStop = False
            Case "����"
                Txt����.TabStop = False
            Case "����"
                Txt����.TabStop = False
            Case "�ѱ�"
                cbo�ѱ�.TabStop = False
            Case "���ʽ"
                cbo���ʽ.TabStop = False
            Case "����֤��"
                Txt����֤��.TabStop = False
            Case "����"
                cbo����.TabStop = False
            Case "ְҵ"
                cboְҵ.TabStop = False
            Case "����"
                cbo����.TabStop = False
            Case "�绰"
                Txt�绰.TabStop = False
            Case "�ʱ�"
                Txt�ʱ�.TabStop = False
            Case "��ַ"
                Txt��ϵ��ַ.TabStop = False
'            Case "ִ�м�"
            Case "����"
                chk����.TabStop = False
            Case "����ʱ��"
                dtp(0).TabStop = False
        End Select
    Next
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
End Sub




Private Sub InitFaceScheme()
    '��ȡ����
    mblnNoshowReagent = Val(GetDeptPara(mlngCurDeptId, "��ʾ��Ӱ��", 1)) <> 1
    mblnNoshowAddons = Val(GetDeptPara(mlngCurDeptId, "��ʾ��������", 1)) <> 1
    mintCheckInMode = Val(zlDatabase.GetPara("�Ǽ�ģʽ", glngSys, mlngModul, 2))
    mblnChoosePrintFormat = (Val(zlDatabase.GetPara("������ӡǰѡ���ʽ", glngSys, mlngModul, 0)) = 1)
    
    mblnIsPetitionScan = IIf(Val(GetDeptPara(mlngCurDeptId, "�������뵥ɨ��", 1)) = 1, True, False)   '��ȡ�������뵥ɨ�����
    Me.cmdPetitionCapture.Visible = mblnIsPetitionScan
    
    If mintCheckInMode <> 1 Then mintCheckInMode = 2
    
    '��Ϊ������������Ӱ�����Ϸ���ʾ�������ȴ�����������
    If mblnNoshowAddons And Label29.Visible = True Then '����ʾ�������ߣ��Ҹ��������Ѿ�����ʾ����ر���ʾ��������
        Label29.Visible = False: txt��������.Visible = False: txt��������.Enabled = False
        '��������ؼ���λ��
        Label1.Top = Label1.Top - 400: cbo�ѱ�.Top = cbo�ѱ�.Top - 400
        Label13.Top = Label13.Top - 400: cbo���ʽ.Top = cbo���ʽ.Top - 400
        Label12.Top = Label12.Top - 400: lblCash.Top = lblCash.Top - 400
        frm������Ϣ.Height = frm������Ϣ.Height - 400
        cmdOk.Top = cmdOk.Top - 400: CmdCancle.Top = cmdOk.Top: cmdPetitionCapture.Top = cmdOk.Top
        Me.Height = Me.Height - 400
    End If
    
    If mintCheckInMode = 1 Then     '����ģʽ
        frm������Ϣ.Visible = False
        cmdOk.Top = cmdOk.Top - frm������Ϣ.Height: CmdCancle.Top = cmdOk.Top: cmdPetitionCapture.Top = cmdOk.Top
        Me.Height = Me.Height - frm������Ϣ.Height
    End If
    
End Sub


Private Sub InitEdit(Optional blnSaveName As Boolean)
    Dim strSQL As String, rsTmp As ADODB.Recordset, i As Integer
    Dim curDate As Date
    
    On Error GoTo DBError
    
    If Not blnSaveName Then
        PatiIdentify.Text = ""
    End If
    PatiIdentify.tag = ""
    TxtӢ����.Text = "":    TxtӢ����.tag = ""
    txt����.Text = "":      cboAge.Visible = True: txt����.tag = ""
    Txt����.Text = "":      Txt����.Text = ""
    Txt����֤��.Text = "":  Txt�绰.Text = ""
    Txt�ʱ�.Text = "":      Txt��ϵ��ַ = ""
    txtPatientDept.Text = "":  txtID.Text = ""
    txtBed.Text = ""
    txtҽ������.Text = "":  txtҽ������.tag = ""
    Txt��λ����.Text = "":  Txt��λ����.tag = ""
    cboAge.ListIndex = 0
    
    txtPatholNum.Text = ""
    
    mstrExamineDoctor = GetSetting("ZLSOFT", "����ģ��\" & App.ProductName & "\" & Me.Name, "��������", "")
    mstrUnitName = GetSetting("ZLSOFT", "����ģ��\" & App.ProductName & "\" & Me.Name, "�ͼ쵥λ", "")
'    txtPatholNum.Enabled = False
'    cbxStudyType.Enabled = False
    
    '���ݴ����ͼ���������жϸı䰴ť������
    If mintEditMode > 0 Then cmdPetitionCapture.Caption = IIf(mintImgCount = 0, "���뵥", "���뵥(" & mintImgCount & "��)")
    
    '�Ա�
    Set rsTmp = GetDictData("�Ա�")
    cbo�Ա�.Clear
    If Not rsTmp Is Nothing Then
        For i = 1 To rsTmp.RecordCount
            cbo�Ա�.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ȱʡ = 1 Then
                cbo�Ա�.ItemData(cbo�Ա�.NewIndex) = 1
                cbo�Ա�.ListIndex = cbo�Ա�.NewIndex
            End If
            rsTmp.MoveNext
        Next
    End If
    
    '�ѱ�
    Set rsTmp = GetDictData("�ѱ�")
    cbo�ѱ�.Clear
    If Not rsTmp Is Nothing Then
        Do Until rsTmp.EOF
            cbo�ѱ�.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ȱʡ = 1 Then
                cbo�ѱ�.ItemData(cbo�ѱ�.NewIndex) = 1
                cbo�ѱ�.ListIndex = cbo�ѱ�.NewIndex
            End If
            rsTmp.MoveNext
        Loop
    End If
    
    '���ʽ
    Set rsTmp = GetDictData("ҽ�Ƹ��ʽ")
    cbo���ʽ.Clear
    If Not rsTmp Is Nothing Then
        Do Until rsTmp.EOF
            cbo���ʽ.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ȱʡ = 1 Then
                cbo���ʽ.ItemData(cbo���ʽ.NewIndex) = 1
                cbo���ʽ.ListIndex = cbo���ʽ.NewIndex
            End If
            rsTmp.MoveNext
        Loop
    End If
    
    '����
    Set rsTmp = GetDictData("����")
    cbo����.Clear
    If Not rsTmp Is Nothing Then
        Do Until rsTmp.EOF
            cbo����.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ȱʡ = 1 Then
                cbo����.ItemData(cbo����.NewIndex) = 1
                cbo����.ListIndex = cbo����.NewIndex
            End If
            rsTmp.MoveNext
        Loop
    End If
    
    'ְҵ
    Set rsTmp = GetDictData("ְҵ")
    cboְҵ.Clear
    If Not rsTmp Is Nothing Then
        Do Until rsTmp.EOF
            cboְҵ.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ȱʡ = 1 Then
                cboְҵ.ItemData(cboְҵ.NewIndex) = 1
                cboְҵ.ListIndex = cboְҵ.NewIndex
            End If
            rsTmp.MoveNext
        Loop
    End If
    
    '����״��
    Set rsTmp = GetDictData("����״��")
    cbo����.Clear
    If Not rsTmp Is Nothing Then
        Do Until rsTmp.EOF
            cbo����.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ȱʡ = 1 Then
                cbo����.ItemData(cbo����.NewIndex) = 1
                cbo����.ListIndex = cbo����.NewIndex
            End If
            rsTmp.MoveNext
        Loop
    End If
    
    '��������
    strSQL = " Select Distinct A.ID,A.����,A.����,A.����" & _
                " From ���ű� A,��������˵�� B " & _
                " Where B.����ID = A.ID " & _
                " And (A.����ʱ��=TO_DATE('3000-01-01','YYYY-MM-DD') Or A.����ʱ�� is NULL) " & _
                " And (B.�������� IN('�ٴ�','���','���'))" & _
                " Order by A.����"
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption)
    cbo��������.Clear
    Do Until rsTmp.EOF
        cbo��������.AddItem rsTmp!���� & "-" & rsTmp!����
        cbo��������.ItemData(cbo��������.NewIndex) = rsTmp!ID
        If rsTmp!ID = mlngCurDeptId Then cbo��������.ListIndex = cbo��������.NewIndex
        rsTmp.MoveNext
    Loop
    If cbo��������.ListCount > 0 And Me.cbo��������.ListIndex = -1 Then cbo��������.ListIndex = 0
    
    curDate = zlDatabase.Currentdate
    
    dtp��������.value = Format(curDate, "yyyy-mm-dd")
    dtp(0).value = curDate
    dtp(1).value = Format(curDate, "yyyy-mm-dd HH:MM")

    InitInput '��꾭��λ��
    
    '�Ǽǵ��������Ҫ���ƿؼ��Ŀ�����
    If mintEditMode = 0 Then Call RefreshObjEnabled(1)
    
    '���ޱ걾����ģ�飬�Ҵ��ڱ���״̬���ߵǼǺ�ֱ�ӱ������ޱ걾����ģ��ʱ���Զ����ɲ�����
    If mintEditMode = 2 Or (mblnRegToCheck And mintEditMode = 0) Then
        '�Զ����ɲ�����
        txtPatholNum.Text = GetPatholNum(Val(cbxStudyType.Text))
    End If
    
    
    '��������Ժ��Ϣ������ͼ����
    If mblnShowSentInfo Then
        
        strSQL = "Select B.���� From ���ű� A , ���ű� B where  B.�ϼ�iD=A.Id and A.����=[1]"
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mStrOutSideCfg)
        cboUnitName.Clear
        
        If rsTmp.RecordCount > 0 Then
            While Not rsTmp.EOF
                cboUnitName.AddItem rsTmp!����
                
                rsTmp.MoveNext
            Wend
        End If
        
        If mintEditMode = 0 Then
            cboUnitName.Text = mstrUnitName
        End If
        
        
    End If
    
Exit Sub
DBError:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub LoadOldData(ByVal strOld As String, ByRef txt���� As TextBox, ByRef cbo���䵥λ As ComboBox)
'����:�����ݿ��б�������䰴�淶�ĸ�ʽ���ص�����,���淶��ԭ����ʾ
    Dim strTmp As String, lngIdx As Long
    
    If Trim(strOld) = "" Then Exit Sub
    
    lngIdx = -1
    strTmp = strOld
    If InStr(strOld, "��") > 0 Then
        If InStr(strOld, "��") = Len(strOld) Then
            strTmp = Mid(strOld, 1, InStr(strOld, "��") - 1)
            lngIdx = 0
        End If
    ElseIf InStr(strOld, "��") > 0 Then
        If InStr(strOld, "��") = Len(strOld) Then
            strTmp = Mid(strOld, 1, InStr(strOld, "��") - 1)
            lngIdx = 1
        End If
    ElseIf InStr(strOld, "��") > 0 Then
        If InStr(strOld, "��") = Len(strOld) Then
            strTmp = Mid(strOld, 1, InStr(strOld, "��") - 1)
            lngIdx = 2
        End If
    ElseIf IsNumeric(strOld) Then
        lngIdx = 0
    End If
    
    If strTmp = "" Then strTmp = 0
    txt����.Text = strTmp
    If cbo���䵥λ.ListCount > 0 Then Call zlControl.CboSetIndex(cbo���䵥λ.hwnd, lngIdx)
    If lngIdx = -1 Then
        cbo���䵥λ.Visible = False
    Else
        If cbo���䵥λ.Visible = False Then cbo���䵥λ.Visible = True
    End If
End Sub
Public Function CopyCheck(ByVal lngAdviceId As Long, ByVal lngSendNo As Long) As Boolean
'����:���ڸ��ƵǼǣ�ͬһ������ͬ��Ŀ����ͬ��λ
'���أ� True--���Ƴɹ���False--������Ϣ������

    Dim rsTemp As New ADODB.Recordset
    Dim rsBaby As ADODB.Recordset
    
    Dim curDate As Date
    Dim lngPatientID As Long
    Dim lngPageID As Long
    Dim strSQL As String

    On Error GoTo errHand
    CopyCheck = False
    
    gstrSQL = "SELECT Nvl(E.����,B.����) ����,Nvl(E.�Ա�,B.�Ա�) �Ա�,Nvl(E.����,B.����) ����,B.��������,B.�ѱ�,B.ҽ�Ƹ��ʽ,B.����֤��,B.����,B.ְҵ,Nvl(E.Ӣ����,'') Ӣ����,E.����,E.����" & _
                    ",B.����״��,Nvl(B.��ͥ�绰,B.��ϵ�˵绰) �绰,Nvl(B.��ͥ��ַ�ʱ�,B.��λ�ʱ�) �ʱ�,Nvl(B.��ͥ��ַ,B.������λ) ��ַ,B.��ͬ��λID,B.�����,B.���￨��,B.����֤��" & _
                    ",Nvl(D.����,'') AS ���˿���,A.���˿���ID,A.�Һŵ�,Decode(A.������Դ,2,H.סԺ��,I.�����) As ���˺�,Decode(H.סԺ��,NULL,NULL,B.��ǰ����) As ����" & _
                    ",F.����ʱ�� ����ʱ��,Nvl(C.����,0) ���Ҽ���,Nvl(C.����,'δ֪') AS ��������,A.����ʱ�� As ����ʱ��,A.����ҽ��,A.������־,F.�״�ʱ��,F.ִ�м�,E.����豸,A.ҽ������,E.����,E.��鼼ʦ" & _
                    ",DECODE(A.������Դ,2,2,1,1,4,4,3) AS ������Դ,Nvl(E.Ӱ�����,G.Ӱ�����) As Ӱ�����,B.����id,A.��ҳid, Nvl(A.Ӥ��,0) As Ӥ��,A.������ĿID,E.��������" & _
                " FROM ����ҽ������ F,����ҽ����¼ A, ������Ϣ B,���ű� C,���ű� D,Ӱ�����¼ E,Ӱ������Ŀ G,������ҳ H,���˹Һż�¼ I " & _
                " Where I.no(+)= A.�Һŵ� And A.����ID=H.����ID(+) And A.��ҳID=H.��ҳID(+) And F.ҽ��ID=[1] And F.���ͺ�=[2] AND F.ҽ��ID=A.ID" & _
                        " AND F.ҽ��ID=E.ҽ��ID(+) And F.���ͺ�=E.���ͺ�(+)  And A.����ID=B.����ID" & _
                        " And A.��������ID=C.ID And A.���˿���ID=D.ID And A.������ĿID=G.������ĿID(+)"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ������Ϣ", lngAdviceId, lngSendNo)

    If rsTemp.EOF Then
        '��鲡����Ϣ��������ԭ�������û�С�����ҽ�����ͼ�¼������ʾ����ҽ���ѱ����˻�����
        gstrSQL = "Select ҽ��ID From ����ҽ������ Where ҽ��ID =[1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "���ҽ��״̬", lngAdviceId)
        If rsTemp.EOF Then
            Call MsgBoxD(Me, "���μ��ҽ��û�з��ͼ�¼�������Ǹ�ҽ���Ѿ������˻��������ϣ���ˢ�º���ҽ��״̬��", vbInformation, gstrSysName)
        Else
            Call MsgBoxD(Me, "������Ϣ���������������Ա��ϵ��", vbInformation, gstrSysName)
        End If
        
        mblnOk = False
        cmdOk.Enabled = False
        Exit Function
    End If
    
    curDate = zlDatabase.Currentdate
    
    '�����Ӥ����Ӧ����ʾӤ������Ϣ
    mlngBaby = rsTemp!Ӥ��
    
    If mlngBaby = 0 Then
Normal:
        PatiIdentify.Text = nvl(rsTemp!����)
        Call SeekIndex(cbo�Ա�, nvl(rsTemp!�Ա�), True)
        
        If nvl(rsTemp!����) <> "" Then
            LoadOldData rsTemp!����, txt����, cboAge
        Else
            'û����������µĴ�����ʽ
            Call ReCalcOld(Format(nvl(rsTemp!��������, curDate), "yyyy-mm-dd hh:mm:ss"), _
                        cboAge, _
                        0, _
                        Format(curDate, "yyyy-mm-dd hh:mm:ss"))
        End If
 
        dtp��������.CustomFormat = "yyyy-MM-dd"
    
        If Trim(nvl(rsTemp!��������)) = "" Then
            Call ReCalcBirthDay(txt����.Text, cboAge.Text)
        Else
            '�жϳ��������Ƿ���һ�꣬����һ�갴�������Ӥ��
            If zlDatabase.Currentdate - CDate(rsTemp!��������) >= 366 Then
                dtp��������.value = Format(nvl(rsTemp!��������), "yyyy-mm-dd")
            Else
                dtp��������.CustomFormat = "yyyy-MM-dd HH:mm:ss"
                dtp��������.value = Format(nvl(rsTemp!��������), "yyyy-mm-dd hh:mm:ss")
            End If
        End If
        
        
    Else
        lngPageID = nvl(rsTemp!��ҳID, 0)
        
        strSQL = "Select A.����ʱ�� As ����ʱ��,Nvl(B.Ӥ������, A.���� || '֮��' || Trim(To_Char(B.���, '9'))) As Ӥ������, B.Ӥ���Ա�, B.����ʱ��" & vbNewLine & _
                 "  From ����ҽ����¼ A, ������������¼ B " & vbNewLine & _
                 "  Where a.����ID = b.����ID And b.��ҳid = [2] And b.��� = [3] And a.ID = [1]"

        Set rsBaby = zlDatabase.OpenSQLRecord(strSQL, "��ȡӤ����Ϣ", lngAdviceId, lngPageID, mlngBaby)
            
        If rsBaby.EOF Then
            GoTo Normal
        Else
            PatiIdentify.Text = nvl(rsBaby!Ӥ������)
            Call SeekIndex(cbo�Ա�, nvl(rsBaby!Ӥ���Ա�), True)

            If Trim(nvl(rsTemp!��������)) <> "" Then
                txt����.Text = ReCalcOld(Format(nvl(rsBaby!����ʱ��, curDate), "yyyy-mm-dd hh:mm:ss"), _
                                            cboAge, _
                                            0, _
                                            Format(curDate, "yyyy-mm-dd hh:mm:ss"))
            End If
            
            '�����Ӥ��������������Ҫ��ʾʱ����
            dtp��������.CustomFormat = "yyyy-MM-dd HH:mm"
            dtp��������.value = Format(nvl(rsBaby!����ʱ��), "yyyy-mm-dd hh:mm:ss")
        End If
    End If
    
    dtp(0).value = Format(curDate, "yyyy-mm-dd HH:MM")
    
    TxtӢ���� = Decode(nvl(rsTemp!Ӣ����), "", zlCommFun.mGetFullPY(PatiIdentify.Text, mintCapital, mblnUseSplitter), rsTemp!Ӣ����)
    
    If Trim(txt����) = "" Then txt���� = 0
    Txt���� = nvl(rsTemp!����): Txt���� = nvl(rsTemp!����)
    
    Call SeekIndex(cbo�ѱ�, nvl(rsTemp!�ѱ�), True)
    Call SeekIndex(cbo���ʽ, nvl(rsTemp!ҽ�Ƹ��ʽ), True)
    Txt����֤��.Text = nvl(rsTemp!����֤��)
    Txt����֤��.tag = nvl(rsTemp!����֤��)
    Call SeekIndex(cbo����, nvl(rsTemp!����), True)
    Call SeekIndex(cboְҵ, nvl(rsTemp!ְҵ), True)
    Call SeekIndex(cbo����, nvl(rsTemp!����״��), True)
    Txt�绰 = nvl(rsTemp!�绰): Txt�ʱ� = nvl(rsTemp!�ʱ�)
    Txt��ϵ��ַ = nvl(rsTemp!��ַ)
    Label22.tag = nvl(rsTemp!��ͬ��λID, 0)
    
    txtPatientDept.Text = nvl(rsTemp!���˿���)
    txtPatientDept.tag = nvl(rsTemp!���˿���ID, 0)
    txtID = nvl(rsTemp!���˺�): txtBed = nvl(rsTemp!����)
'    Call SeekIndex(cbo��������, Nvl(rsTemp!���Ҽ���), True, , True)
    Call SeekIndex(cbo��������, nvl(rsTemp!��������), True, , TNeedType.tNeedName)
    Call SeekIndex(cboҽ��, nvl(rsTemp!����ҽ��), True)
    '���Ҳ�������ҽ�����ҿ���ҽ����Ϊ�գ���ֱ����д����ҽ���ֶ�
    If nvl(rsTemp!����ҽ��) <> "" And cboҽ��.ListIndex = -1 Then
        cboҽ��.Text = nvl(rsTemp!����ҽ��)
    End If
    
    chk����.value = nvl(rsTemp!������־, 0)
    dtp(1).value = Format(curDate, "yyyy-mm-dd HH:MM")
    
    txt��������.Text = nvl(rsTemp!��������)
    'ҽ�����ݡ���������,����/����:��λ1(����1),��λ1(����2),��λ2(����1)---
    txtҽ������ = Split(Split(rsTemp!ҽ������, ":")(0), ",")(0)
    
    mstrOutNo = nvl(rsTemp!�����, 0)
    mstrCardNo = nvl(rsTemp!���￨��)
    mstrCardPass = nvl(rsTemp!����֤��)
    mintSourceType = rsTemp!������Դ
    mstrRegNo = nvl(rsTemp!�Һŵ�)
    
    If mblnAllPatientIsOutside Then mintSourceType = 3
    
    mlngPatiId = nvl(rsTemp!����ID, 0)
    mlngPageID = nvl(rsTemp!��ҳID, 0)
    mlngClinicID = nvl(rsTemp!������Ŀid)
    
    txtҽ������.TabIndex = 0
    
    '������֮�����ÿؼ��Ŀ�����
    Call RefreshObjEnabled(3)
    
    CopyCheck = True
    Exit Function
errHand:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function


Public Function RefreshPatiInfor(bln���� As Boolean) As Boolean
'����:���ڱ������޸�ʱˢ�²���
'bln����=True���Ǳ������򲿷���Ϣ����ֱ��ʹ��Ĭ����Ϣ
'bln����=False,���޸ģ�����ϢӦ��ȫ��ʹ�����ݿ��е���Ϣ

Dim rsTemp As New ADODB.Recordset
Dim rsSongJian As ADODB.Recordset
Dim strSQL As String
Dim rsBaby As New ADODB.Recordset
Dim lngPatientID As Long
Dim lngPageID As Long
Dim intChargeType As Integer    '����ҽ������.��¼����---1-�շѼ�¼��2-���ʼ�¼��
Dim intChargeState As ChargeState
Dim curDate As Date
Dim intTMP As Integer
Dim i As Integer
Dim strTmp As String


    On Error GoTo errHand
    
    RefreshPatiInfor = False
    
    curDate = zlDatabase.Currentdate
    
    gstrSQL = "SELECT I.���� as �ű�����,H.������,H.�������,Nvl(E.����,A.����) ����,Nvl(E.�Ա�,A.�Ա�) �Ա�,Nvl(E.����,A.����) ����,B.��������,B.��Ժʱ��,B.�ѱ�,B.ҽ�Ƹ��ʽ,B.����֤��,B.����,B.ְҵ,Nvl(E.Ӣ����,'') Ӣ����,E.����,E.����" & _
                    ",E.��������,B.����״��,Nvl(B.��ͥ�绰,B.��ϵ�˵绰) �绰,Nvl(B.��ͥ��ַ�ʱ�,B.��λ�ʱ�) �ʱ�,Nvl(B.��ͥ��ַ,B.������λ) ��ַ,B.��ͬ��λID,B.�����,B.���￨��,B.����֤��" & _
                    ",Nvl(D.����,'') AS ���˿���,A.���˿���ID,Decode(A.������Դ,2,J.סԺ��,K.�����) As ���˺�,Decode(J.סԺ��,NULL,NULL,B.��ǰ����) As ����,B.��ǰ����ID" & _
                    ",F.����ʱ�� ����ʱ��,Nvl(C.����,0) ���Ҽ���,Nvl(C.����,'δ֪') AS ��������,A.����ʱ�� As ����ʱ��,A.����ҽ��,A.������־,F.�״�ʱ��,F.ִ�м�,E.����豸,A.ҽ������,E.������,E.����,E.��鼼ʦ" & _
                    ",DECODE(A.������Դ,2,2,1,1,4,4,3) AS ������Դ,Nvl(E.Ӱ�����,G.Ӱ�����) As Ӱ�����,B.����id,A.��ҳid,A.������ĿID,E.��������,Nvl(A.Ӥ��, 0) As Ӥ��" & _
                    ",F.��¼���� " & _
                " FROM ����ҽ������ F,����ҽ����¼ A, ������Ϣ B,���ű� C,���ű� D,Ӱ�����¼ E,Ӱ������Ŀ G, ���������Ϣ H ,����������� I,������ҳ J,���˹Һż�¼ K  " & _
                " Where K.no(+)= A.�Һŵ� And A.����ID=J.����ID(+) And A.��ҳID=J.��ҳID(+) And F.ҽ��ID=[1] And F.���ͺ�=[2] AND F.ҽ��ID=A.ID And F.ҽ��ID=H.ҽ��ID(+) And H.�������ID=I.ID(+) " & _
                        " AND F.ҽ��ID=E.ҽ��ID(+) And F.���ͺ�=E.���ͺ�(+)  And A.����ID=B.����ID" & _
                        " And A.��������ID=C.ID And A.���˿���ID=D.ID And A.������ĿID=G.������ĿID(+)"

    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ������Ϣ", mlngAdviceId, mlngSendNo)

    If rsTemp.EOF Then
        '��鲡����Ϣ��������ԭ�������û�С�����ҽ�����ͼ�¼������ʾ����ҽ���ѱ����˻�����
        gstrSQL = "Select ҽ��ID From ����ҽ������ Where ҽ��ID =[1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "���ҽ��״̬", mlngAdviceId)
        If rsTemp.EOF Then
            Call MsgBoxD(Me, "���μ��ҽ��û�з��ͼ�¼�������Ǹ�ҽ���Ѿ������˻��������ϣ���ˢ�º���ҽ��״̬��", vbInformation, gstrSysName)
        Else
            Call MsgBoxD(Me, "������Ϣ���������������Ա��ϵ��", vbInformation, gstrSysName)
        End If
    
        mblnOk = False
        cmdOk.Enabled = False
        Exit Function
    End If
    
    '����Ӥ����Ϣ
    mlngBaby = rsTemp!Ӥ��
    If mlngBaby = 0 Then
Normal:
        PatiIdentify.Text = nvl(rsTemp!����)
        Call SeekIndex(cbo�Ա�, nvl(rsTemp!�Ա�), True)
        
        If bln���� Or mintEditMode = 1 Then
            If bln���� And IsNull(rsTemp!��������) Then
  
                intTMP = MsgBoxD(Me, "��������Ϊ�գ��Ƿ�����������㣿", vbYesNo, gstrSysName)
                
                If intTMP = vbYes Then
                    txt����.Text = nvl(rsTemp!����, "")
                    If txt����.Text = "" Then
                        MsgBoxD Me, "������ͳ����������ݣ����ܽ��б���������ϵ��Ӧ��Ա������", vbInformation, gstrSysName
                        RefreshPatiInfor = False
                        Exit Function
                    End If
                Else
                    MsgBoxD Me, "��������Ϊ�գ����ܽ��б���������ϵ��Ӧ��Ա������", vbInformation, gstrSysName
                    RefreshPatiInfor = False
                    Exit Function
                End If
            End If
        End If
        
        
        If nvl(rsTemp!����) <> "" Then
            LoadOldData rsTemp!����, txt����, cboAge
        Else
            'û����������µĴ�����ʽ
            Call ReCalcOld(Format(nvl(rsTemp!��������, curDate), "yyyy-mm-dd hh:mm:ss"), _
                        cboAge, _
                        0, _
                        Format(nvl(rsTemp!����ʱ��, curDate), "yyyy-mm-dd hh:mm:ss"))
        End If

 
        dtp��������.CustomFormat = "yyyy-MM-dd"
        
        If Trim(nvl(rsTemp!��������)) = "" Then
            Call ReCalcBirthDay(txt����.Text, cboAge.Text)
        Else
            '�жϳ��������Ƿ���һ�꣬����һ�갴�������Ӥ��
            If zlDatabase.Currentdate - CDate(rsTemp!��������) >= 366 Then
                dtp��������.value = Format(nvl(rsTemp!��������), "yyyy-mm-dd")
            Else
                dtp��������.CustomFormat = "yyyy-MM-dd HH:mm:ss"
                dtp��������.value = Format(nvl(rsTemp!��������), "yyyy-mm-dd hh:mm:ss")
            End If
        End If
    Else
        lngPatientID = rsTemp!����ID
        lngPageID = nvl(rsTemp!��ҳID, 0)

        strSQL = "Select A.����ʱ�� As ����ʱ��,Nvl(B.Ӥ������, A.���� || '֮��' || Trim(To_Char(B.���, '9'))) As Ӥ������, B.Ӥ���Ա�, B.����ʱ��, B.����ʱ�� " & vbNewLine & _
                 "  From ����ҽ����¼ A, ������������¼ B " & vbNewLine & _
                 "  Where a.����ID = b.����ID And b.��ҳid = [2] And b.��� = [3] And a.ID = [1]"

        Set rsBaby = zlDatabase.OpenSQLRecord(strSQL, "��ȡӤ����Ϣ", mlngAdviceId, lngPageID, mlngBaby)
        
        If rsBaby.EOF Then
            GoTo Normal
        Else
            PatiIdentify.Text = nvl(rsBaby!Ӥ������)
            Call SeekIndex(cbo�Ա�, nvl(rsBaby!Ӥ���Ա�), True)
            
            If bln���� Or mintEditMode = 1 Then
                If bln���� And IsNull(rsBaby!����ʱ��) Then
                    MsgBoxD Me, "Ӥ���޳����������ݣ����ܽ��б��������ܽ��б���������ϵ��Ӧ��Ա������", vbInformation, gstrSysName
                    RefreshPatiInfor = False
                    Exit Function
                End If
            End If
            
            If mintEditMode > 2 Then
                '����2�����Ǳ������޸�
                Call LoadOldData(nvl(rsTemp!����), txt����, cboAge)
            Else
                txt����.Text = ReCalcOld(Format(nvl(rsBaby!����ʱ��, curDate), "yyyy-mm-dd hh:mm:ss"), _
                                            cboAge, _
                                            0, _
                                            Format(nvl(rsBaby!����ʱ��, nvl(rsBaby!����ʱ��, curDate)), "yyyy-mm-dd hh:mm:ss"))
            End If
            
            '�����Ӥ��������������Ҫ��ʾʱ����
            dtp��������.CustomFormat = "yyyy-MM-dd HH:mm"

            dtp��������.value = Format(nvl(rsBaby!����ʱ��), "yyyy-mm-dd hh:mm:ss")
        End If
    End If
    
    lblCash.tag = nvl(rsTemp!��ǰ����ID)
    TxtӢ���� = Decode(nvl(rsTemp!Ӣ����), "", zlCommFun.mGetFullPY(PatiIdentify.Text, mintCapital, mblnUseSplitter), rsTemp!Ӣ����)
    If Trim(txt����) = "" Then txt���� = 0
    Txt���� = nvl(rsTemp!����): Txt���� = nvl(rsTemp!����)
    Call SeekIndex(cbo�ѱ�, nvl(rsTemp!�ѱ�), True)
    Call SeekIndex(cbo���ʽ, nvl(rsTemp!ҽ�Ƹ��ʽ), True)
    Txt����֤��.Text = nvl(rsTemp!����֤��)
    Txt����֤��.tag = nvl(rsTemp!����֤��)
    Call SeekIndex(cbo����, nvl(rsTemp!����), True)
    Call SeekIndex(cboְҵ, nvl(rsTemp!ְҵ), True)
    Call SeekIndex(cbo����, nvl(rsTemp!����״��), True)
    
    If Not bln���� Then Call SeekIndex(cbo��������, nvl(rsTemp!��������), True)
    Txt�绰 = nvl(rsTemp!�绰): Txt�ʱ� = nvl(rsTemp!�ʱ�)
    Txt��ϵ��ַ = nvl(rsTemp!��ַ)
    Label22.tag = nvl(rsTemp!��ͬ��λID, 0)

    If mintEditMode = 3 Then    'ֻ�б������޸�ʱ���Ŵ����ݿ��ȡ������
        For i = 0 To cbxStudyType.ListCount - 1
            If InStr(cbxStudyType.list(i), nvl(rsTemp!�ű�����)) > 0 Then
                cbxStudyType.ListIndex = i
                Exit For
            End If
            cbxStudyType.ListIndex = 0
        Next
        txtPatholNum.Text = nvl(rsTemp!������)
    End If
    
    If mblnShowSentInfo Then   '����ʾ�ͼ���Ϣʱ���Ŷ�ȡ�ͼ���Ϣ����
        '��������ʾ�ͼ���Ϣ������Զ�ȡ�ͼ���Ϣ
        strSQL = "select �ͼ쵥λ, �ͼ����,�ͼ���,��ע from �����ͼ���Ϣ where  ҽ��ID=[1] and �ͼ�����=to_date('1000/10/10 10:10:10','yyyy/mm/dd hh24:mi:ss')"
        Set rsSongJian = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mlngAdviceId)
        
        If rsSongJian.RecordCount > 0 Then
            
            Call SeekIndex(cboUnitName, nvl(rsSongJian!�ͼ쵥λ), False, , tNeedAll) '�ͼ쵥λ
            If cboUnitName.Text <> nvl(rsSongJian!�ͼ쵥λ) Then
                cboUnitName.AddItem nvl(rsSongJian!�ͼ쵥λ)
                Call SeekIndex(cboUnitName, nvl(rsSongJian!�ͼ쵥λ), False, , tNeedAll) '�ͼ쵥λ
            End If

            txtFormDepart.Text = nvl(rsSongJian!�ͼ����)
            txtSubmitDoctor.Text = nvl(rsSongJian!�ͼ���)

            strTmp = nvl(rsSongJian!��ע)
            If UBound(Split(strTmp, "|")) < 2 Then
                txtSendTag.Text = strTmp
            Else
                txtOldStudyNo.Text = Split(strTmp, "|")(0)
                txtOldBarCode.Text = Split(strTmp, "|")(1)
                txtSendTag.Text = Split(strTmp, "|")(2)
            End If
            
        End If
        
    End If

    
    txtPatientDept.Text = nvl(rsTemp!���˿���)
    txtPatientDept.tag = nvl(rsTemp!���˿���ID, 0)
    txtID = nvl(rsTemp!���˺�): txtBed = nvl(rsTemp!����)
    dtp(0).value = Format(rsTemp!����ʱ��, "yyyy-mm-dd HH:MM")
'    Call SeekIndex(cbo��������, Nvl(rsTemp!���Ҽ���), True, , True)
    Call SeekIndex(cbo��������, nvl(rsTemp!��������), True, , TNeedType.tNeedName)
    Call SeekIndex(cboҽ��, nvl(rsTemp!����ҽ��), True)
    '���Ҳ�������ҽ�����ҿ���ҽ����Ϊ�գ���ֱ����д����ҽ���ֶ�
    If nvl(rsTemp!����ҽ��) <> "" And cboҽ��.ListIndex = -1 Then
        cboҽ��.Text = nvl(rsTemp!����ҽ��)
    End If
    
    chk����.value = nvl(rsTemp!������־, 0)
    dtp(1).value = Format(curDate, "yyyy-mm-dd HH:MM")
    
    
    txt��������.Text = nvl(rsTemp!��������)
    'ҽ�����ݡ���������,����/����:��λ1(����1),��λ1(����2),��λ2(����1)---
    txtҽ������ = Split(Split(rsTemp!ҽ������, ":")(0), ",")(0)
    txtҽ������.tag = txtҽ������.Text
    If InStr(nvl(rsTemp!ҽ������, ""), ":") > 0 Then
        Txt��λ���� = Replace(Split(rsTemp!ҽ������, ":")(1), "),", ")" & vbCrLf)
    Else
        Txt��λ���� = nvl(rsTemp!ҽ������, "")
    End If
    
    mstrOutNo = nvl(rsTemp!�����, 0)
    mstrCardNo = nvl(rsTemp!���￨��)
    mstrCardPass = nvl(rsTemp!����֤��)
    mintSourceType = rsTemp!������Դ
    mlngPatiId = nvl(rsTemp!����ID, 0)
    mlngPageID = nvl(rsTemp!��ҳID, 0)
'    mstrItemType = Nvl(rsTemp!Ӱ�����)
    mlngClinicID = nvl(rsTemp!������Ŀid)
    
    intChargeType = nvl(rsTemp!��¼����, 1)
    
    gstrSQL = "Select ��Ŀ,���� From ����ҽ������ Where ҽ��ID=[1] Order By ����"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ���˸���", mlngAdviceId)
    Txt��λ���� = Txt��λ���� & vbCrLf
    Do Until rsTemp.EOF
        Txt��λ���� = Txt��λ���� & rsTemp!��Ŀ & ":" & nvl(rsTemp!����) & vbCrLf
        rsTemp.MoveNext
    Loop
    
    '���ݲ����������������ı�����ɫ
    If mblnNameColColorCfg Then
        If mintSourceType = 2 Then
            gstrSQL = "select �������� from ������ҳ where ����id=[1] and ��ҳid=[2]"
            Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ��������", mlngPatiId, mlngPageID)
        Else
            gstrSQL = "select �������� from ������Ϣ where ����id=[1]"
            Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ȡ��������", mlngPatiId)
        End If
        
        If rsTemp.RecordCount > 0 Then
            Call InitPatiComponent
            If Not mobjPublicPatient Is Nothing Then
                PatiIdentify.objTxtInput.ForeColor = mobjPublicPatient.GetPatiColor(nvl(rsTemp!��������))
            End If
        End If
    End If
    
    '����ʱ��"��"/"Ƿ"������£�������������������"δ�ɷѱ���"Ȩ�ޣ�"��"/"��"�����κ�����£���������������
    '"��"�������б�����Ŀǰ���ܲ�����ָ�״̬����Ҫ����֧�ֲַ�λִ��ʱ�Ż���֣�
    intChargeState = CheckChargeState(mlngAdviceId, mintSourceType)
    
    If intChargeState = ChargeState.δ�շ� Then
        lblCash.Caption = "δ��"
    ElseIf intChargeState = ChargeState.���շ� Then
        lblCash.Caption = "����"
    ElseIf intChargeState = ChargeState.�޷��� Then
        lblCash.Caption = "�޷�"
    ElseIf intChargeState = ChargeState.�Ѽ��� Then
        lblCash.Caption = "����"
    ElseIf intChargeState = ChargeState.���˷� Then
        lblCash.Caption = "�˷�"
    ElseIf intChargeState = ChargeState.������ Then
        lblCash.Caption = "����"
    ElseIf intChargeState = ChargeState.�ѵ��� Then
        lblCash.Caption = "��"
    Else
        lblCash.Caption = ""
    End If
    
    Call RefreshObjEnabled
    
    If bln���� And Not CheckPopedom(mstrPrivs, "δ�ɷѱ���") And mintSourceType <> 3 Then  '24361 ��Ȩ�޲��жϣ����еǼǲ����ƣ�����Ҳ�����ж�
        If lblCash.Caption = "����" Or lblCash.Caption = "�޷�" _
            Or (gblnִ�к���� And (intChargeState = ChargeState.�޷��� Or intChargeState = ChargeState.�Ѽ���)) _
            Or gblnִ��ǰ�Ƚ��� Then
            cmdOk.Enabled = True
        Else
            cmdOk.Enabled = False
        End If

        If cmdOk.Enabled = False Then
            Me.Caption = Me.Caption & "(��ǰ����δ�շѣ����ܱ���)"
        End If
    End If
    
    If lblCash.Caption = "�˷�" And bln���� Then
        cmdOk.Enabled = False
        Me.Caption = Me.Caption & "(��ǰ�������˷ѣ����ܱ���)"
    End If
    
    If lblCash.Caption = "����" And bln���� Then
        cmdOk.Enabled = False
        Me.Caption = Me.Caption & "(��ǰ���������ˣ����ܱ���)"
    End If
    
    RefreshPatiInfor = True
    Exit Function
errHand:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Private Sub CmdCancle_Click()
    mblnOk = IIf(mlngGoOnReg = 1, True, False)
    Unload Me
End Sub

Private Function ValidData() As Boolean
'------------------------------------------------
'���ܣ�����������ݵĺϷ���
'������ ��
'���أ�True--��������ϸ񣬿��Լ�����False --���������벻�ϸ���Ҫ�޸�����
'------------------------------------------------
    Dim rsTemp As ADODB.Recordset
    
    ValidData = False
    
    gstrSQL = "select ID ,����ID,����ֵ from Ӱ�����̲��� where ����ID = [1] and ������ = [2]"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, Me.Caption, mlngCurDeptId, CStr("��¼����"))
    If Not rsTemp.EOF Then
        If nvl(rsTemp!����ֵ) <> "" Then
            If InStr(rsTemp!����ֵ, "Ӣ����") > 0 And Trim(TxtӢ����) = "" And TxtӢ����.Enabled = True Then
                MsgBoxD Me, "��������Ӣ���������飡", vbInformation, gstrSysName: DoEvents
                TxtӢ����.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "�Ա�") > 0 And Trim(cbo�Ա�.Text) = "" And cbo�Ա�.Enabled = True Then
                MsgBoxD Me, "���������Ա����飡", vbInformation, gstrSysName: DoEvents
                cbo�Ա�.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "����") > 0 And Trim(txt����) = "" And txt����.Enabled = True Then
                MsgBoxD Me, "�����������䣬���飡", vbInformation, gstrSysName: DoEvents
                txt����.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "��������") > 0 And Trim(dtp��������.value) = "" And dtp��������.Enabled = True Then
                MsgBoxD Me, "��������������ڣ����飡", vbInformation, gstrSysName: DoEvents
                dtp��������.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "����") > 0 And Trim(Txt����) = "" And Txt����.Enabled = True Then
                MsgBoxD Me, "�����������ߣ����飡", vbInformation, gstrSysName: DoEvents
                Txt����.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "����") > 0 And Trim(Txt����) = "" And Txt����.Enabled = True Then
                MsgBoxD Me, "�����������أ����飡", vbInformation, gstrSysName: DoEvents
                Txt����.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "�ѱ�") > 0 And Trim(cbo�ѱ�.Text) = "" And cbo�ѱ�.Enabled = True Then
                MsgBoxD Me, "��������ѱ����飡", vbInformation, gstrSysName: DoEvents
                cbo�ѱ�.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "���ʽ") > 0 And Trim(cbo���ʽ.Text) = "" And cbo���ʽ.Enabled = True Then
                MsgBoxD Me, "�������븶�ʽ�����飡", vbInformation, gstrSysName: DoEvents
                cbo���ʽ.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "����֤��") > 0 And Trim(Txt����֤��) = "" And Txt����֤��.Enabled = True Then
                MsgBoxD Me, "������������֤�ţ����飡", vbInformation, gstrSysName: DoEvents
                Txt����֤��.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "����") > 0 And Trim(cbo����.Text) = "" And cbo����.Enabled = True Then
                MsgBoxD Me, "�����������壬���飡", vbInformation, gstrSysName: DoEvents
                cbo����.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "ְҵ") > 0 And Trim(cboְҵ.Text) = "" And cboְҵ.Enabled = True Then
                MsgBoxD Me, "��������ְҵ�����飡", vbInformation, gstrSysName: DoEvents
                cboְҵ.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "����") > 0 And Trim(cbo����.Text) = "" And cbo����.Enabled = True Then
                MsgBoxD Me, "����������������飡", vbInformation, gstrSysName: DoEvents
                cbo����.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "�绰") > 0 And Trim(Txt�绰) = "" And Txt�绰.Enabled = True Then
                MsgBoxD Me, "��������绰�����飡", vbInformation, gstrSysName: DoEvents
                Txt�绰.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "�ʱ�") > 0 And Trim(Txt�ʱ�) = "" And Txt�ʱ�.Enabled = True Then
                MsgBoxD Me, "���������ʱ࣬���飡", vbInformation, gstrSysName: DoEvents
                Txt�ʱ�.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "��ַ") > 0 And Trim(Txt��ϵ��ַ) = "" And Txt��ϵ��ַ.Enabled = True Then
                MsgBoxD Me, "����������ϵ��ַ�����飡", vbInformation, gstrSysName: DoEvents
                Txt��ϵ��ַ.SetFocus: Exit Function
            ElseIf InStr(rsTemp!����ֵ, "��������") > 0 And Trim(txt��������.Text) = "" And txt��������.Enabled = True Then
                MsgBoxD Me, "�������븽�����������飡", vbInformation, gstrSysName: DoEvents
                txt��������.SetFocus: Exit Function
            End If
        End If
    End If

    On Error Resume Next
    
    '�������������Ƿ���Ч
    If txt����.Enabled Then
        If mobjPublicPatient Is Nothing Then
            If MsgBoxD(Me, "δ��⵽����zlPublicPatient.dll����Чע����Ϣ�����ܶ��������Ч�Խ��м�飬�Ƿ������", vbYesNo + vbExclamation) = vbNo Then
                Exit Function
            End If
        Else
            If txt����.tag <> "" Then
                If Not mobjPublicPatient.CheckPatiAge( _
                                                    txt����.Text & IIf(cboAge.Visible, cboAge.Text, ""), _
                                                    dtp��������.value, 0, _
                                                    txt����.tag) Then Exit Function
            Else
                If Not mobjPublicPatient.CheckPatiAge( _
                                                    txt����.Text & IIf(cboAge.Visible, cboAge.Text, ""), _
                                                    dtp��������.value, 0, _
                                                    dtp(0).value) Then Exit Function
            End If
        End If
    End If
    
    '����������
    If dtp��������.value > zlDatabase.Currentdate Then
        MsgBoxD Me, "��ǰ�������ڴ��ڽ�������ڣ����������롣", vbInformation, gstrSysName: DoEvents
        Me.dtp��������.SetFocus: Exit Function
    End If
    
    If Len(Trim(Me.txtҽ������.tag)) = 0 Then
        MsgBoxD Me, "��������������Ŀ��", vbInformation, gstrSysName: DoEvents
        Me.txtҽ������.SetFocus: Exit Function
    End If
    If Me.cbo��������.ListIndex = -1 Then
        MsgBoxD Me, "��ָ��������ң�", vbInformation, gstrSysName: DoEvents
        Me.cbo��������.SetFocus: Exit Function
    End If
    If Len(Trim(Me.cboҽ��.Text)) = 0 Then
        MsgBoxD Me, "��ָ������ҽ����", vbInformation, gstrSysName: DoEvents
        Me.cboҽ��.SetFocus: Exit Function
    End If
    
    '����ţ�76509
'    If dtp(0).value > dtp(1).value Then
'        MsgBoxD Me, "����ʱ�䲻�ܴ��ڼ��ʱ�䣡", vbInformation, gstrSysName: DoEvents
'        Me.dtp(0).SetFocus: Exit Function
'    End If
    
    If Len(Trim(Me.PatiIdentify.Text)) = 0 And PatiIdentify.objTxtInput.Enabled Then
        MsgBoxD Me, "�����벡��������", vbInformation, gstrSysName: DoEvents
        Me.PatiIdentify.SetFocus
        Exit Function
    End If
    
    If Trim(TxtӢ����) = "" And TxtӢ����.TabStop And TxtӢ����.Enabled Then
        MsgBoxD Me, "Ӣ��������Ϊ�գ�", vbInformation, gstrSysName: DoEvents
        TxtӢ����.SetFocus
        Exit Function
    End If
    
    ValidData = True
End Function


Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    Select Case KeyCode
        Case vbKeyReturn
            zlCommFun.PressKey vbKeyTab
        Case vbKeyF2
            If mintEditMode <> 1 Then cmdOk_Click   '�ǼǺ��޸Ķ���F2
        Case vbKeyF4
            If mintEditMode = 1 Then cmdOk_Click   '������F4
    End Select
End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    SaveSetting "ZLSOFT", "����ģ��\" & App.ProductName & "\" & Me.Name, "��������", zlStr.NeedName(cbo��������.Text)
    
    Set mobjSquareCard = Nothing
    Set mobjPublicPatient = Nothing
    Set mobjInsure = Nothing
    Set mfrmParent = Nothing
    
    '�����жϵǼ�ʱɨ��� ���ȡ����ť ɨ�贰���ͷ�
    If Not frmPetitionCap Is Nothing Then
        frmPetitionCap.mblnIsLogin = False
        Call frmPetitionCap.Form_Unload(0)
        Set frmPetitionCap = Nothing
    End If
    
    
End Sub

Private Sub PatiIdentify_FindPatiArfter(ByVal objCard As zlIDKind.Card, ByVal blnCard As Boolean, ShowName As String, objHisPati As zlIDKind.PatiInfor, objCardData As zlIDKind.PatiInfor, strErrMsg As String, blnCancel As Boolean)
    'IDKind�ؼ��ڲ������Լ���ѯһ�Σ����ʹ�á��շѵ��ݺš��͡��Һŵ��š����ѯʧ�ܣ�
    '��ѯʧ�ܺ󣬻Ὣ�������Ϣ����text�������Ҫ������ǿ�ƽ�PACS��ѯ��������������ShowName
    ' �����ڿؼ��ڲ��Զ��޸���ʾ������
    
    If Not objHisPati Is Nothing Then
        If objHisPati.����ID > 0 Then
            Call FindPatient(blnCard, Nothing, objHisPati.����ID)
        End If
    End If
    
    ShowName = PatiIdentify.Text
    Call SendKeys("{tab}")
End Sub

Private Sub PatiIdentify_FindPatiBefore(ByVal objCard As zlIDKind.Card, blnCard As Boolean, strShowText As String, objCardData As zlIDKind.PatiInfor, blnFindPatied As Boolean, blnCancel As Boolean)
    Dim blnFinded As Boolean 'pacs�����Ĳ��Ҵ����ҵ��˲���
    
    blnFinded = False
    If mintEditMode = 0 Then blnFinded = FindPatient(blnCard)

    strShowText = PatiIdentify.Text
    If Not objCardData Is Nothing Then objCardData.���� = PatiIdentify.Text
    
    If blnFinded Then blnFindPatied = True
End Sub

Private Sub PatiIdentify_ItemClick(Index As Integer, objCard As zlIDKind.Card)
    '��Ҫ�����Ϣ,����ˢ����,���л�,���������ʾʧȥ����
    If PatiIdentify.Text <> "" Then PatiIdentify.Text = ""
    If PatiIdentify.objTxtInput.Enabled And PatiIdentify.Visible Then PatiIdentify.SetFocus
End Sub

Private Sub Txt�绰_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub


Private Sub txt����_Change()
    If Not IsNumeric(txt����.Text) And Trim(txt����.Text) <> "" Then
        cboAge.ListIndex = -1: cboAge.Visible = False
    ElseIf cboAge.Visible = False Then
        cboAge.Visible = True
    End If
End Sub

Private Sub txt����_GotFocus()
    zlControl.TxtSelAll txt����
End Sub

Private Sub txt����_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        If cboAge.Visible = False And IsNumeric(txt����.Text) Then
            Call txt����_Validate(False)
              cboAge.SetFocus
        End If
        If Not IsNumeric(txt����.Text) Then Call zlCommFun.PressKey(vbKeyTab)
    End If
End Sub

Private Sub txt����_KeyUp(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then Exit Sub
    If Not CheckOldData(txt����, cboAge) Then Exit Sub
    
    Call ReCalcBirthDay(txt����.Text, cboAge.Text)
End Sub

Public Function ReCalcBirthDay(ByVal strAge As String, ByVal strUnit As String) As String
'�������������������
    Dim sreDateOfBirth As String
    
    On Error GoTo errHand
    
    If Not mobjPublicPatient Is Nothing Then
        Call mobjPublicPatient.ReCalcBirthDay(strAge & IIf(strUnit = "", "", strUnit), sreDateOfBirth)
    End If
    
    If Trim(sreDateOfBirth) <> "" Then dtp��������.value = sreDateOfBirth
    
    Exit Function
errHand:
    If ErrCenter = 1 Then Resume
End Function

Private Sub txt����_Validate(Cancel As Boolean)
    If Not IsNumeric(txt����.Text) And Trim(txt����.Text) <> "" Then
        cboAge.ListIndex = -1: cboAge.Visible = False
    ElseIf cboAge.Visible = False Then
        cboAge.ListIndex = 0: cboAge.Visible = True
    End If
End Sub

Private Sub Txt����֤��_Change()
    'ֻ�еǼǵ�ʱ����ȡ�˲��ˣ����޸��������Ż������²���
    If mintEditMode = 0 And mlngPatiId <> 0 And Txt����֤��.Text <> "" Then
        MsgBoxD Me, "�����޸�����֤�󣬾���Ϊ�²��˴����ˡ�", vbOKOnly, "��ʾ��Ϣ"
        Call InitEdit(False)
        
        mlngPatiId = 0
    End If
End Sub

Private Sub Txt����_KeyPress(KeyAscii As Integer)
    If InStr("0123456789." & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
    Call TxtInputControl(Txt����, KeyAscii, 2)
End Sub

Private Sub Txt����_KeyPress(KeyAscii As Integer)
    If InStr("0123456789." & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
    Call TxtInputControl(Txt����, KeyAscii, 2)
End Sub

Private Function FindPatient(blnCard As Boolean, Optional rsSelPatient As Object = Nothing, Optional lngPatiID As Long = 0) As Boolean
On Error GoTo err
'lngPatiID �������0 �� rsSelPatient=nothing  ˵��ǿ��ʹ�ò���ID��ѯ���˲�����ʾ�����Ϣ������ؼ���
    Dim rsTmp As ADODB.Recordset
    Dim rsAge As ADODB.Recordset
    Dim lngAge As Long
    Dim curDate As Date
    Dim strSQL As String
                    
    FindPatient = False
    
    If rsSelPatient Is Nothing And lngPatiID = 0 Then
        Set rsTmp = GetPatient(PatiIdentify.Text, blnCard) '����������ȡ������Ϣ
        If Not rsTmp Is Nothing Then
            If rsTmp.RecordCount > 0 Then
                FindPatient = True
            End If
        End If
    ElseIf rsSelPatient Is Nothing And lngPatiID > 0 Then
        '�������ݲ���ID��ѯ.
        strSQL = "select ����id,����,�Ա�,����,��������,��ԴID,��ҳID,���˿���ID,��ǰ����ID,ҽ��,�����,סԺ��,���￨��,����״̬,����֤��,��ǰ����,�ѱ�" & _
                        ",ҽ�Ƹ��ʽ,����֤��,����,ְҵ,����״��,�绰,�ʱ�,��ַ,��ͬ��λID, �²���" & _
                    " From(Select distinct A.����id,A.����,A.�Ա�,A.����,to_char(A.��������,'yyyy-mm-dd') ��������,Decode(A.��ǰ����id,Null,1,2) As ��ԴID,A.��ҳID," & _
                        "Decode(A.��ǰ����id,Null,Nvl(B.ִ�в���ID,0),A.��ǰ����id) As ���˿���ID,A.��ǰ����ID,nvl(B.ִ����,'') As ҽ��,A.�����,A.סԺ��,A.���￨��,decode(A.����״̬,0,'����',1,'�ȴ�����',2,'���ھ���','')as ����״̬,A.����֤��,A.��ǰ����," & _
                        "A.�ѱ�,A.ҽ�Ƹ��ʽ,A.����֤��,A.����,A.ְҵ,A.����״��,nvl(A.��ͥ�绰,A.��ϵ�˵绰) �绰," & _
                        "nvl(A.��ͥ��ַ�ʱ�,A.��λ�ʱ�) �ʱ�,nvl(A.��ͥ��ַ,A.������λ) ��ַ,A.��ͬ��λID, 0 as �²���,B.�Ǽ�ʱ��" & _
                  " From ������Ϣ A,���˹Һż�¼ B Where A.����ID=[1] And A.����ID=B.����ID(+) And A.�����=B.�����(+) " & _
                  " order by B.�Ǽ�ʱ�� desc) where rownum=1"
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "���Ҳ���", lngPatiID)
    Else
        Set rsTmp = rsSelPatient
    End If
     
    txt����.tag = ""
    
    If Not rsTmp Is Nothing Then
        If Not rsTmp.EOF Then
            If nvl(rsTmp!����) <> "�²���" Then
                curDate = zlDatabase.Currentdate
                
                PatiIdentify.tag = Trim(nvl(rsTmp!����))
                PatiIdentify.Text = Trim(nvl(rsTmp!����))
                Call SeekIndex(cbo�Ա�, nvl(rsTmp!�Ա�), True)
                
                dtp��������.CustomFormat = "yyyy-MM-dd"
                
                If nvl(rsTmp!��������) <> "" Then
                    '�жϳ��������Ƿ���һ�꣬����һ�갴�������Ӥ��
                    If zlDatabase.Currentdate - CDate(rsTmp!��������) >= 366 Then
                        dtp��������.value = Format(nvl(rsTmp!��������), "yyyy-mm-dd")
                    Else
                        dtp��������.CustomFormat = "yyyy-MM-dd HH:mm:ss"
                        dtp��������.value = Format(nvl(rsTmp!��������), "yyyy-mm-dd hh:mm:ss")
                    End If
                Else
                    dtp��������.value = Format(nvl(rsTmp!��������, curDate), "yyyy-mm-dd")
                End If
                
                strSQL = ""
                Set rsAge = Nothing
                If Val(nvl(rsTmp!��ԴID, 0)) = 2 Then
                    'סԺ����������ȡ
                    strSQL = "select ����,��Ժ���� As ʱ�� from ������ҳ where ����ID=[1] and ��ҳID=[2] and rownum <=1"
                    Set rsAge = zlDatabase.OpenSQLRecord(strSQL, "��ȡ��������", Val(nvl(rsTmp!����ID)), Val(nvl(rsTmp!��ҳID)))
                Else
                    If Val(nvl(rsTmp!����״̬, 0)) <> 0 Then
                        '���ﻼ��������ȡ
                        strSQL = "select ����,�Ǽ�ʱ�� As ʱ�� from ���˹Һż�¼ where ����ID=[1] and �����=[2] and rownum <=1"
                        Set rsAge = zlDatabase.OpenSQLRecord(strSQL, "��ȡ��������", Val(nvl(rsTmp!����ID)), Val(nvl(rsTmp!�����)))
                    End If
                End If
                
                If Not rsAge Is Nothing Then
                    
                    If rsAge.RecordCount > 0 Then
                        LoadOldData nvl(rsAge!����), txt����, cboAge
                        txt����.tag = nvl(rsAge!ʱ��)
                    End If
                Else
                    '���ݵ�ǰ���ڼ�������
'                    txt����.Text = ReCalcOld(dtp��������.value, cboAge, 0, dtp(0).value) & cboAge.Text '���ϵ�λ����Ȼ�ֱ�����txt�����cboageʱ���Ὣ��λ�ĳ��꣬bugNo 89538
                    LoadOldData ReCalcOld(dtp��������.value, cboAge, 0, dtp(0).value) & IIf(cboAge.Visible, cboAge.Text, ""), txt����, cboAge
                End If
                
                If txt����.Text = "" Then
                    txt���� = 0
                    cboAge.Visible = True
                    cboAge.ListIndex = 0
                End If
                
                Call SeekIndex(cbo�ѱ�, nvl(rsTmp!�ѱ�, "��ͨ"))
                Call SeekIndex(cbo���ʽ, nvl(rsTmp!ҽ�Ƹ��ʽ, "�Է�ҽ��"))
                Txt����֤��.Text = nvl(rsTmp!����֤��)
                Txt����֤��.tag = nvl(rsTmp!����֤��)
                Call SeekIndex(cbo����, nvl(rsTmp!����, "����"))
                Call SeekIndex(cboְҵ, nvl(rsTmp!ְҵ, "����"))
                Call SeekIndex(cbo����, nvl(rsTmp!����״��, "δ��"))
                Txt�绰 = nvl(rsTmp!�绰)
                Txt�ʱ� = nvl(rsTmp!�ʱ�)
                Txt��ϵ��ַ = nvl(rsTmp!��ַ)
                Label22.tag = nvl(rsTmp!��ͬ��λID, 0)
                txtID = Decode(nvl(rsTmp!סԺ��), "", nvl(rsTmp!�����), nvl(rsTmp!סԺ��))
                txtBed = nvl(rsTmp!��ǰ����)
                
                If mInputType = 5 Then
                '���շѵ�����ȡ��Ϣʱ��Ҫ��ȡ������Һ�ҽ��
                    Call SeekIndex(cbo��������, getID_TO_����(nvl(rsTmp!���˿���ID), "���ű�"), True, , True)
                    Call SeekIndex(cboҽ��, nvl(rsTmp!ҽ��))
                End If
                mlngPatiId = nvl(rsTmp!����ID, 0)
                mintSourceType = nvl(rsTmp!��ԴID, 1)
                
                '���ڷ�סԺ���ˣ������������ﻹ������
                If mintSourceType <> 2 Then mintSourceType = getSourceType(rsTmp!����ID)
                
                mlngPageID = nvl(rsTmp!��ҳID, 0)
                mstrOutNo = nvl(rsTmp!�����, 0)
                mstrCardNo = nvl(rsTmp!���￨��)
                mstrCardPass = nvl(rsTmp!����֤��)
                
                '��ʾ���˿���
                txtPatientDept.Text = zlStr.NeedName(cbo��������)
                txtPatientDept.tag = nvl(rsTmp!���˿���ID)
                If cbo�Ա�.Enabled = True Then cbo�Ա�.SetFocus
                
                Call RefreshObjEnabled(2)
                
                '��ȡ������Ϣ��ɺ� �Զ����㲡�˳�������
                If IsNumeric(txt����.Text) And nvl(rsTmp!��������, "") = "" Then Call ReCalcBirthDay(txt����.Text, cboAge.Text)
                
                Exit Function
            Else
                If cbo�Ա�.Enabled = True And mblnIsSamePatient Then cbo�Ա�.SetFocus
            End If
        End If
    End If
    
    'û�鵽���µǼǲ�����
    Dim strTmp As String
    strTmp = Trim(PatiIdentify.Text)
    
'        InitEdit
    If PatiIdentify.IDKindIDX <> PatiIdentify.GetKindIndex(IDKind_����֤��) Then '����֤��ȡ������֤����������д��������Ϣ
        If PatiIdentify.Text <> strTmp Then PatiIdentify.Text = strTmp
        PatiIdentify.tag = Trim(PatiIdentify.Text)
        TxtӢ����.Text = zlCommFun.mGetFullPY(PatiIdentify.Text, mintCapital, mblnUseSplitter)
    End If
    mlngPatiId = 0
    mintSourceType = 3
    mlngPageID = 0
    
    'ˢ��������û����ȡ��������Ϣ����Ȼѡ��txt����
    If blnCard Then PatiIdentify.SetFocus

    Call RefreshObjEnabled(1)
    
    Exit Function
err:
    If ErrCenter() = 1 Then
    Resume
    End If
    Call SaveErrLog
End Function


Private Function getSourceType(ByVal lngPatiID As Long) As Integer
'����:��ȡ������Դ�͹Һŵ�
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    If mInputType = 4 Then
        getSourceType = 1
        Exit Function 'Ϊ�Һŵ�ʱ��ȷ��Ϊ���ﲡ��
    End If
    
    'ȱʡΪ��Ժ����
    getSourceType = 3
    
    strSQL = "select NO from ���˹Һż�¼ where ����ID=[1] and ִ��״̬<>-1 And ִ��״̬<>1 order by �Ǽ�ʱ�� desc"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ȡ������Դ�͹Һŵ�", lngPatiID)
    
    If rsTemp.RecordCount > 0 Then
        getSourceType = 1
        mstrRegNo = nvl(rsTemp!no)
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Private Sub txtҽ������_KeyPress(KeyAscii As Integer)
Dim rsTmp As ADODB.Recordset
    If KeyAscii = vbKeyReturn Then
        KeyAscii = 0
        With txtҽ������
            If .Text = "" Then Call cmdSel_Click
            If Trim(.Text) = .tag Then Exit Sub
            
            Set rsTmp = SelectDiagItem() '��ȡ��Ŀ
            If rsTmp Is Nothing Then 'ȡ����������
                '�ָ�ԭֵ
                .Text = .tag
                zlControl.TxtSelAll txtҽ������
                .SetFocus
                Exit Sub
            Else
                If AdviceInput(rsTmp) Then '����ѡ����Ŀ���ò�λ������
                    .tag = .Text
                Else 'ȡ����λ������
                    .Text = .tag
                    zlControl.TxtSelAll txtҽ������
                    .SetFocus
                    Exit Sub
                End If
            End If
        End With
    End If
End Sub

Private Sub txtҽ������_Validate(Cancel As Boolean)
    '�ָ���Ϊ�ĸı�,�س�ʱ��ֵ
    If txtҽ������.Text <> txtҽ������.tag Then
        txtҽ������.Text = txtҽ������.tag
    End If
End Sub

Private Sub TxtӢ����_LostFocus()
    zlControl.TxtSelAll TxtӢ����
End Sub

Private Sub Txt�ʱ�_KeyPress(KeyAscii As Integer)
    If InStr("0123456789" & Chr(8), Chr(KeyAscii)) = 0 Then KeyAscii = 0
End Sub
Private Sub cbo��������_Click()
    '�ж�ѡ����� �Ƿ�����Ժ����
    mblnIsOutSideHosp = IIf(InStr(cbo��������.Text, "��Ժ") > 0, True, False)
    
    If cbo��������.ListIndex > -1 Then InitDoctors cbo��������.ItemData(cbo��������.ListIndex)
End Sub
Private Sub PatiIdentify_LostFocus()
    TxtӢ����.Text = zlCommFun.mGetFullPY(PatiIdentify.Text, mintCapital, mblnUseSplitter)
    
    Call zlCommFun.OpenIme
End Sub

Private Sub txtҽ������_GotFocus()
    Call zlControl.TxtSelAll(txtҽ������)
End Sub

Private Sub Txt��ϵ��ַ_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub Txt��ϵ��ַ_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Private Sub PatiIdentify_Change()
    'ֻ�еǼǵ�ʱ����ȡ�˲��ˣ����޸��������Ż������²���
    If mintEditMode = 0 And mlngPatiId <> 0 And PatiIdentify.Text <> "" Then
        MsgBoxD Me, "�����޸������󣬾���Ϊ�²��˴����ˡ�", vbOKOnly, "��ʾ��Ϣ"
        
        If mblnIDCardDetect Then Txt����֤��.Text = ""
        
        Call InitEdit(True)
        mlngPatiId = 0
        Call FindPatient(False)
    End If
End Sub

Private Sub PatiIdentify_GotFocus()
    Call zlCommFun.OpenIme(gstrIme <> "���Զ�����")
End Sub

Private Sub PatiIdentify_Click(objCard As zlIDKind.Card)
    Dim lng�����ID As Long
    Dim strExpand As String
    Dim strOutCardNO As String
    Dim strOutPatiInfoXML As String
    
    lng�����ID = Val(PatiIdentify.GetCurCard.�ӿ����)

    If lng�����ID = 0 Then Exit Sub
    If mobjSquareCard.zlReadCard(Me, mlngModul, lng�����ID, True, strExpand, strOutCardNO, strOutPatiInfoXML) = False Then
        Exit Sub
    End If
    PatiIdentify.Text = strOutCardNO
    If PatiIdentify.Text <> "" Then
        Call FindPatient(False)
    End If
End Sub

Private Sub PatiIdentify_Validate(Cancel As Boolean)
    Select Case PatiIdentify.IDKindIDX
        Case PatiIdentify.GetKindIndex(IDKind_IC����)
            PatiIdentify.objTxtInput.ToolTipText = "IC��ʶ��"
        Case PatiIdentify.GetKindIndex(IDKind_����)
            PatiIdentify.objTxtInput.ToolTipText = "����Ϊ���￨�š���������ͷΪ����ID��������סԺ�š���*������š���.���Һŵ��š���/���շѵ��ݺ�"
        Case PatiIdentify.GetKindIndex(IDKind_ҽ����)
            PatiIdentify.objTxtInput.ToolTipText = "��¼��ҽ����"
        Case PatiIdentify.GetKindIndex(IDKind_����֤��)
            PatiIdentify.objTxtInput.ToolTipText = "�뽫����֤���ڶ�������"
    End Select
End Sub



Private Sub cbo�ѱ�_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cbo�ѱ�.hwnd, zlControl.CboMatchIndex(cbo�ѱ�.hwnd, KeyAscii))
End Sub

Private Sub cbo���ʽ_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cbo���ʽ.hwnd, zlControl.CboMatchIndex(cbo���ʽ.hwnd, KeyAscii))
End Sub

Private Sub cbo����_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cbo����.hwnd, zlControl.CboMatchIndex(cbo����.hwnd, KeyAscii))
End Sub

Private Sub cbo��������_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cbo��������.hwnd, zlControl.CboMatchIndex(cbo��������.hwnd, KeyAscii))
    
    If KeyAscii = vbKeyReturn Then
        Call cbo��������_Click
    End If
End Sub

Private Sub cbo����_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cbo����.hwnd, zlControl.CboMatchIndex(cbo����.hwnd, KeyAscii))
End Sub

Private Sub cbo�Ա�_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cbo�Ա�.hwnd, zlControl.CboMatchIndex(cbo�Ա�.hwnd, KeyAscii))
End Sub
Private Sub cboҽ��_KeyPress(KeyAscii As Integer)
    '�����������ѡ����� ��Ժ���ң���ô����ҽ���ļ�����ҹ��ܣ�����ҽ������������¼��
    If Not mblnIsOutSideHosp Then
        Call zlControl.CboSetIndex(cboҽ��.hwnd, zlControl.CboMatchIndex(cboҽ��.hwnd, KeyAscii))
    End If
End Sub

Private Sub cboְҵ_KeyPress(KeyAscii As Integer)
    Call zlControl.CboSetIndex(cboְҵ.hwnd, zlControl.CboMatchIndex(cboְҵ.hwnd, KeyAscii))
End Sub

Private Sub InitPatiComponent()
On Error GoTo errhandle
    Set mobjPublicPatient = VBA.Interaction.GetObject("", "zlPublicPatient.clsPublicPatient")
    If mobjPublicPatient Is Nothing Then
        Set mobjPublicPatient = CreateObject("zlPublicPatient.clsPublicPatient")
    End If
    If Not mobjPublicPatient Is Nothing Then Call mobjPublicPatient.zlInitCommon(gcnOracle, glngSys)
    
Exit Sub
errhandle:
    Set mobjPublicPatient = Nothing
End Sub

Public Function ZlShowMe(frmParent As Form, ByVal strDefaultPatientType As String, ByVal blnIsBigFont As Boolean) As Boolean
On Error GoTo errH
    Dim rsTmp As ADODB.Recordset
    Dim strSQL As String
    Dim lngRowIndex As Long
    Dim objStudyInfo As clsStudyInfo
    
    Set mfrmParent = frmParent
    
    Call InitPatiComponent
    
    Call ConfigPopedomFace
    
    strSQL = "Select Distinct b.id,b.����, Upper(b.����) As ����" & vbNewLine & _
                " From ������Ա a, ��Ա�� b " & vbNewLine & _
                " Where a.��Աid = b.Id And " & vbNewLine & _
                " (b.����ʱ�� = To_Date('3000-01-01', 'YYYY-MM-DD') Or b.����ʱ�� Is Null) and a.����id = [1] " & vbNewLine & _
                " Order By ���� Desc"
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mlngCurDeptId)

    If Not IsNull(rsTmp) Then
        '���ش�������
        cbo��������.Clear
        cbo��������.Enabled = True
        Do Until rsTmp.EOF
            cbo��������.AddItem rsTmp!���� & "-" & rsTmp!����
            If rsTmp!ID = UserInfo.ID Then cbo��������.ListIndex = cbo��������.NewIndex
            rsTmp.MoveNext
        Loop

        Call SeekIndex(cbo��������, mstrExamineDoctor, True)

        If gblUsePacsQuery Then
            Set objStudyInfo = mfrmParent.StudyInfo
                
            If objStudyInfo.strStuStateDesc = "�ѱ���" Or _
               objStudyInfo.strStuStateDesc = "�Ѽ��" Or _
               (objStudyInfo.strStuStateDesc = "�ѵǼ�" And mintEditMode = 2) Then
               cbo��������.Enabled = True
            Else
                cbo��������.Enabled = False
            End If
        Else
            If mfrmParent.ufgStudyList.DataGrid.Rows > 1 Then
                lngRowIndex = mfrmParent.ufgStudyList.FindRowIndex(mlngAdviceId, "ҽ��ID", True)
                If lngRowIndex > 0 Then
                    If mfrmParent.ufgStudyList.Text(lngRowIndex, "������") = "�ѱ���" Or _
                    mfrmParent.ufgStudyList.Text(lngRowIndex, "������") = "�Ѽ��" Or _
                    (mfrmParent.ufgStudyList.Text(lngRowIndex, "������") = "�ѵǼ�" And mintEditMode = 2) Then
                        cbo��������.Enabled = True
                    Else
                        cbo��������.Enabled = False
                    End If
                Else
                    cbo��������.Enabled = False
                End If
            Else
                cbo��������.Enabled = False
            End If
        End If
    End If
    
    Call SetFontSize(blnIsBigFont)
    
    Me.Show 1, mfrmParent
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Private Sub cboҽ��_DropDown()
On Error GoTo errhandle
    Call SendMessage(cboҽ��.hwnd, &H160, 300, 0)
errhandle:
End Sub

Private Sub SetFontSize(ByVal blnIsBigFont As Boolean)
    Dim objControl As Object
    Dim lngLabFontSize As Long
    Dim lngTxtFontSize As Long
    
    lngLabFontSize = IIf(blnIsBigFont, 14, 12)
    lngTxtFontSize = IIf(blnIsBigFont, 12, 10.5)
    
    Label3.FontSize = lngLabFontSize
    Label6.FontSize = lngLabFontSize
    Label7.FontSize = lngLabFontSize
    
    Label11.FontSize = lngLabFontSize
    Label5.FontSize = lngLabFontSize
    Label4.FontSize = lngLabFontSize
    
    Label10.FontSize = lngLabFontSize
    Label6.FontSize = lngLabFontSize
    Label20.FontSize = lngLabFontSize
    
    Label19.FontSize = lngLabFontSize
    Label2.FontSize = lngLabFontSize
    
    lblҽ������.FontSize = lngLabFontSize
    Label8.FontSize = lngLabFontSize
    Lbl��λ����.FontSize = lngLabFontSize
    
    lbl(6).FontSize = lngLabFontSize
    lbl(0).FontSize = lngLabFontSize
    labSendRoom.FontSize = lngLabFontSize
    labSendDoctor.FontSize = lngLabFontSize
    labSendUnit.FontSize = lngLabFontSize
    labOldStudyNo.FontSize = lngLabFontSize
    labPatholNum.FontSize = lngLabFontSize
    labStudyType.FontSize = lngLabFontSize
    labOldBarCode.FontSize = lngLabFontSize
    lab��ע.FontSize = lngLabFontSize
    
    Label25.FontSize = lngLabFontSize
    Label14.FontSize = lngLabFontSize
    Label15.FontSize = lngLabFontSize
    
    
    Label17.FontSize = lngLabFontSize
    Label18.FontSize = lngLabFontSize
    Label21.FontSize = lngLabFontSize
    
    Label22.FontSize = lngLabFontSize
    Label29.FontSize = lngLabFontSize
    
    Label16.FontSize = lngLabFontSize
    
    Label1.FontSize = lngLabFontSize
    Label13.FontSize = lngLabFontSize
    Label12.FontSize = lngLabFontSize
    
    
    
    Lab��������.FontSize = lngLabFontSize
    cbo��������.FontSize = lngLabFontSize
    
    chk����.FontSize = lngLabFontSize
    
    
    txtPatientDept.FontSize = lngTxtFontSize
    txtID.FontSize = lngTxtFontSize
    txtBed.FontSize = lngTxtFontSize
    lblCash.FontSize = lngTxtFontSize
    
    For Each objControl In Me.Controls
        If TypeName(objControl) = "TextBox" Then
            objControl.FontSize = lngTxtFontSize
        End If
        
        If TypeName(objControl) = "ComboBox" Then
            objControl.FontSize = lngTxtFontSize
        End If
        
        If TypeName(objControl) = "DTPicker" Then
            objControl.Font.Size = lngTxtFontSize
        End If
    Next
    
    CmdCancle.FontSize = lngTxtFontSize
    cmdOk.FontSize = lngTxtFontSize
    cmdPetitionCapture.FontSize = lngTxtFontSize
End Sub


Private Sub ConfigPopedomFace()
'����Ȩ�޽���
    Dim blnEnregPopedom As Boolean
    Dim i As Long
    
    '���û�еǼ�Ȩ�ޣ���ֻ�����Բ������ڲ�����Ϣ�����޸�
    blnEnregPopedom = True ' CheckPopedom(mstrPrivs, "���Ǽ�")
    
    Frame1.Enabled = blnEnregPopedom
    Frame2.Visible = blnEnregPopedom
    
    If Not blnEnregPopedom Then
        '�޼��Ǽ�Ȩ�ޣ������ڱ�����Բ����Ž����޸�
        txtPatholNum.Enabled = IIf(mintEditMode = 3, True, False)
        cbxStudyType.Enabled = IIf(mintEditMode = 3, True, False)
    End If
    
    frm������Ϣ.Visible = blnEnregPopedom And Not (mintCheckInMode = 1) 'mintCheckInMode=1��ʾ����ģʽ
    
    If Not blnEnregPopedom Then
        framPatholInf.Top = Frame1.Top + Frame1.Height + 240
        
        cmdOk.Top = framPatholInf.Top + framPatholInf.Height + 240
        CmdCancle.Top = cmdOk.Top
        
        cmdPetitionCapture.Top = cmdOk.Top
        
        Me.Height = Frame1.Height + framPatholInf.Height + cmdOk.Height + 1080
        
        For i = 0 To Me.Controls.Count - 1
            If UCase(Me.Controls(i).Name) <> UCase("txtPatholNum") And UCase(Me.Controls(i).Name) <> UCase("cbxStudyType") Then
                On Error Resume Next
                Me.Controls(i).BackColor = Me.BackColor
            End If
        Next i
    End If
    
End Sub


Private Sub sutSetTxtEnable(thisBox As TextBox, blnEnable As Boolean)
    thisBox.Enabled = blnEnable
    If blnEnable = True Then
        thisBox.BackColor = vbWhite
    Else
        thisBox.BackColor = &H8000000B
    End If
End Sub