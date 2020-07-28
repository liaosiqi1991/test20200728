VERSION 5.00
Object = "{555E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.CommandBars.9600.ocx"
Object = "{853AAF94-E49C-11D0-A303-0040C711066C}#4.3#0"; "DicomObjects.ocx"
Object = "{84926CA3-2941-101C-816F-0E6013114B7F}#1.0#0"; "IMGSCAN.OCX"
Begin VB.Form frmPetitionCapture 
   Caption         =   "申请单图像"
   ClientHeight    =   8970
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   13380
   Icon            =   "frmPetitionCapture.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   8970
   ScaleWidth      =   13380
   StartUpPosition =   3  '窗口缺省
   Begin ScanLibCtl.ImgScan ImageScanner 
      Left            =   3360
      Top             =   0
      _Version        =   65536
      _ExtentX        =   661
      _ExtentY        =   661
      _StockProps     =   0
      StopScanBox     =   -1  'True
      FileType        =   3
      CompressionType =   0
      CompressionInfo =   0
      ScanTo          =   4
   End
   Begin VB.Frame fmeDcmViewer 
      BackColor       =   &H80000004&
      BorderStyle     =   0  'None
      Height          =   3735
      Left            =   5520
      TabIndex        =   4
      Top             =   240
      Width           =   4215
      Begin DicomObjects.DicomViewer dcmViewImg 
         Height          =   1575
         Left            =   240
         TabIndex        =   6
         Top             =   1560
         Visible         =   0   'False
         Width           =   2175
         _Version        =   262147
         _ExtentX        =   3836
         _ExtentY        =   2778
         _StockProps     =   35
         BackColor       =   -2147483640
         UseScrollBars   =   0   'False
         UseMouseWheel   =   -1  'True
      End
      Begin VB.PictureBox picTemp2 
         BackColor       =   &H80000007&
         BorderStyle     =   0  'None
         Height          =   1215
         Left            =   240
         ScaleHeight     =   1215
         ScaleWidth      =   1695
         TabIndex        =   5
         Top             =   120
         Visible         =   0   'False
         Width           =   1695
      End
      Begin VB.Label lab 
         AutoSize        =   -1  'True
         Caption         =   "未找到申请图像。"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   24
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   480
         TabIndex        =   11
         Top             =   3120
         Width           =   3840
      End
      Begin VB.Image img 
         Height          =   1785
         Left            =   1080
         Picture         =   "frmPetitionCapture.frx":058A
         Top             =   960
         Width           =   2505
      End
   End
   Begin VB.Frame fmeInfoCtrl 
      BackColor       =   &H80000004&
      BorderStyle     =   0  'None
      Height          =   3210
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2895
      Begin VB.Frame fmePatientInfo 
         Height          =   3015
         Left            =   120
         TabIndex        =   1
         Top             =   0
         Width           =   2685
         Begin VB.TextBox txtAppend 
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'None
            Height          =   1050
            Left            =   120
            Locked          =   -1  'True
            MultiLine       =   -1  'True
            ScrollBars      =   2  'Vertical
            TabIndex        =   17
            Text            =   "frmPetitionCapture.frx":24AC
            Top             =   1890
            Width           =   2460
         End
         Begin VB.Label labName 
            AutoSize        =   -1  'True
            Caption         =   "labName"
            BeginProperty Font 
               Name            =   "宋体"
               Size            =   9
               Charset         =   134
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   180
            Left            =   1080
            TabIndex        =   16
            Top             =   240
            Width           =   735
         End
         Begin VB.Label labNo 
            AutoSize        =   -1  'True
            Caption         =   "labNo"
            BeginProperty Font 
               Name            =   "宋体"
               Size            =   9
               Charset         =   134
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   180
            Left            =   1080
            TabIndex        =   15
            Top             =   570
            Width           =   525
         End
         Begin VB.Label labRoom 
            AutoSize        =   -1  'True
            Caption         =   "labRoom"
            BeginProperty Font 
               Name            =   "宋体"
               Size            =   9
               Charset         =   134
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   180
            Left            =   1080
            TabIndex        =   14
            Top             =   900
            Width           =   735
         End
         Begin VB.Label labSex 
            AutoSize        =   -1  'True
            Caption         =   "labSex"
            Height          =   180
            Left            =   1080
            TabIndex        =   13
            Top             =   1230
            Width           =   540
         End
         Begin VB.Label labAge 
            AutoSize        =   -1  'True
            Caption         =   "labAge"
            Height          =   180
            Left            =   1080
            TabIndex        =   12
            Top             =   1560
            Width           =   540
         End
         Begin VB.Label lblCheckNum 
            AutoSize        =   -1  'True
            Caption         =   "检 查 号"
            BeginProperty Font 
               Name            =   "宋体"
               Size            =   9
               Charset         =   134
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   180
            Left            =   120
            TabIndex        =   9
            Top             =   570
            Width           =   795
         End
         Begin VB.Label lblPatientAge 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "年    龄"
            Height          =   180
            Left            =   120
            TabIndex        =   8
            Top             =   1560
            Width           =   720
         End
         Begin VB.Label lblPatientDept 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "病人科室"
            BeginProperty Font 
               Name            =   "宋体"
               Size            =   9
               Charset         =   134
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   180
            Left            =   120
            TabIndex        =   7
            Top             =   900
            Width           =   780
         End
         Begin VB.Label lblPatientName 
            AutoSize        =   -1  'True
            Caption         =   "姓    名"
            BeginProperty Font 
               Name            =   "宋体"
               Size            =   9
               Charset         =   134
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   180
            Left            =   120
            TabIndex        =   3
            Top             =   240
            Width           =   810
         End
         Begin VB.Label lblPatientSex 
            AutoSize        =   -1  'True
            Caption         =   "性    别"
            Height          =   180
            Left            =   120
            TabIndex        =   2
            Top             =   1230
            Width           =   720
         End
      End
   End
   Begin DicomObjects.DicomViewer dcmMiniature 
      Height          =   4935
      Left            =   240
      TabIndex        =   10
      Top             =   3600
      Width           =   4050
      _Version        =   262147
      _ExtentX        =   7144
      _ExtentY        =   8705
      _StockProps     =   35
      BackColor       =   -2147483642
   End
   Begin XtremeCommandBars.CommandBars cbrMain 
      Left            =   2880
      Top             =   0
      _Version        =   589884
      _ExtentX        =   635
      _ExtentY        =   635
      _StockProps     =   0
   End
End
Attribute VB_Name = "frmPetitionCapture"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'点坐标类型
Private Type TPoint
  X As Integer
  Y As Integer
End Type

'视频驱动类型
Private Enum TVideoDriverType
  vdtWDM = 0
  vdtVFW = 1
  vdtTWAIN = 2
  '其他需要支持的驱动类型......
End Enum

Private mstrTempDirOfScan As String          '扫描的临时目录
Private mstrScanDeviceTempDir As String      '扫描设备临时目录
Private mstrBufferDir As String

Private mintScanImageIndex As Integer        '扫描图像索引
Private mintCurImgIndex As Integer           '当前被选中的图象索引


Private Const CONST_STR_DEFAULT_SCAN_FILE_TEMPLATE As String = "Scan"  '默认扫描文件临时存储路径
Private Const CONST_STR_DEFAULT_TEMP_SCAN_DIR_NAME As String = "\TempScan"  '默认扫描文件临时存储路径

Private mlngAdviceId As Long           '医嘱ID
Private mlngCurDeptId As Long          '当前科室ID
Private mstrPrivs As String            '当前权限

Private mstrSaveDeviceID As String      '存储设备的设备号
Private mstruFtpTag As TFtpConTag

Private mlngBaseX As Long               'dcmView中鼠标Down时的X坐标
Private mlngBaseY As Long               'dcmView中鼠标Down时的Y坐标
Private mMouseDownPoint As TPoint       '鼠标在DcmImage上按下时的位置
Private mblndcmViewImgDown As Boolean    '用于判断dcmView中鼠标是否被按下
Private mInitScrollPoint As TPoint      '开始拖动时的初始位置
Private mCorpSize As TPoint             '拖动后的相对偏移位置
Private mblnIsExamine As Boolean        '是否查看申请单
Public mblnIsLogin As Boolean           '是否是登录窗口的申请单按钮

'病人基本信息
Private mstrCheckNo As String           '检查号
Private mstrDeptName As String          '科室名称
Private mstrPatientName As String       '病人姓名
Private mstrPatientAge As String        '病人年龄
Private mstrPatientSex As String        '病人性别
Private mstrExamineMethod As String     '检查方法
Private mstrSpePosition As String       '标本部位

'菜单
Private Enum conMenus
    conMenu_Process_RRotate = 503
    conMenu_Process_LRotate = 504
    conMenu_Process_Magnify = 502
    conMenu_Process_Shrink = 513
    conMenu_Process_Restore = 8124
    conMenu_Process_ScamImg = 8101
    conMenu_Process_DeleteImg = 10001
    conMenu_Process_ScanSet = 815
    conMenu_Process_ChoiceEqu = 181
    conMenu_File_Exit = 191
End Enum
Private mblnImgProcess As Boolean       '是否在对选定图像进行放大等处理
Private mblnOperate As Boolean          '是否进行图像扫描等操作
Private mdcmTmpView As DicomViewer
Private mintImageType As Integer        '扫描图像格式

Public Event RefreshState(ByVal blnState As Long)             '刷新检查列表“申请单”的状态

Public Sub ShowPetitionCaptureWind(ByVal strPrivs As String, lngCurDeptId As Long, strDeptName As String, _
                                   strPatientName As String, strPatientAge As String, strPatientSex As String, _
                                   strExamineMethod As String, strSpePosition As String, blnIsExamine As Boolean, _
                                   blnIsLogin As Boolean, Optional lngAdviceId As Long = 0, Optional intState As Integer = 0, _
                                   Optional dcmTmpView As DicomViewer)
Dim rsTemp As ADODB.Recordset
Dim strSQL As String
On Error GoTo errH

    '设置模块变量
    mstrPrivs = strPrivs
    mlngAdviceId = lngAdviceId
    mblnIsExamine = IIf(intState = 0, blnIsExamine, True)
    mblnIsLogin = blnIsLogin
    mlngCurDeptId = lngCurDeptId
    Set mdcmTmpView = dcmTmpView
    
    '初始化科室级参数
    InitDeptPara mlngCurDeptId
    
    
    If FtpConnectTest(mstruFtpTag) = False Then
        MsgBox "FTP不能正常连接，请检查网络设置。", vbInformation, gstrSysName
        Exit Sub
    End If
    
    strSQL = "select 检查号 from 影像检查记录  where 医嘱id=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "取得检查号", lngAdviceId)
    
    If rsTemp.RecordCount > 0 Then
        mstrCheckNo = nvl(rsTemp!检查号)
    End If
    
    mstrDeptName = strDeptName
    mstrPatientName = strPatientName
    mstrPatientAge = strPatientAge
    mstrPatientSex = strPatientSex
    mstrExamineMethod = strExamineMethod
    mstrSpePosition = strSpePosition
    
    If Not mblnIsExamine Then mblnOperate = True
    
    '初始化病人信息
    Call InitLables
     
    Call Me.Show(1)
    
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub InitCommandBars()
    '功能创建工具条
    Dim cbrControl As CommandBarControl
    Dim cbrToolBar As CommandBar
    '-----------------------------------------------------
    CommandBarsGlobalSettings.App = App
    CommandBarsGlobalSettings.ResourceFile = CommandBarsGlobalSettings.OcxPath & "\XTPResourceZhCn.dll"
    CommandBarsGlobalSettings.ColorManager.SystemTheme = xtpSystemThemeAuto
    Me.cbrMain.VisualTheme = xtpThemeOffice2003
    Set Me.cbrMain.Icons = zlCommFun.GetPubIcons
    
    With Me.cbrMain.Options
        .ShowExpandButtonAlways = False
        .ToolBarAccelTips = True
        .AlwaysShowFullMenus = False
        .IconsWithShadow = True '放在VisualTheme后有效
        .UseDisabledIcons = True
        .LargeIcons = True
        .SetIconSize True, 32, 32
    End With
    
    Me.cbrMain.EnableCustomization False
    Me.cbrMain.ActiveMenuBar.Visible = False
    
    '图像操作工具栏定义
    Set cbrToolBar = Me.cbrMain.Add("图像操作栏", xtpBarLeft)
    cbrToolBar.EnableDocking xtpFlagStretched
    cbrToolBar.ShowTextBelowIcons = True '文本显示在图标下方
    cbrToolBar.Closeable = False
    
    With cbrToolBar.Controls
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_RRotate, "顺时"): cbrControl.ToolTipText = "顺时针旋转90°"
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_LRotate, "逆时"): cbrControl.ToolTipText = "逆时针旋转90°"
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_Magnify, "放大"): cbrControl.ToolTipText = "放大图像"
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_Shrink, "缩小"): cbrControl.ToolTipText = "缩小图像"
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_Restore, "恢复"): cbrControl.ToolTipText = "恢复图像到初始状态"
        
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_ScamImg, "扫描图像") '102
        cbrControl.BeginGroup = True
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_DeleteImg, "删除图像")
        Set cbrControl = .Add(xtpControlButton, conMenu_Process_ScanSet, "扫描设置") '181
        'Set cbrControl = .Add(xtpControlButton, conMenu_Process_ChoiceEqu, "选择设备")
        
        Set cbrControl = .Add(xtpControlButton, conMenu_File_Exit, "退出")
        cbrControl.BeginGroup = True
    End With
    
    For Each cbrControl In cbrToolBar.Controls
         cbrControl.Style = xtpButtonIconAndCaption
    Next
    
    cbrToolBar.Position = xtpBarTop
End Sub

Private Sub cbrMain_Execute(ByVal Control As XtremeCommandBars.ICommandBarControl)
    On Error GoTo errhandle
    
    Select Case Control.ID
        Case conMenu_Process_RRotate        '顺时
            Call subSetRotate(True)
            
        Case conMenu_Process_LRotate        '逆时
            Call subSetRotate(False)
            
        Case conMenu_Process_Magnify        '放大
            Call cmdMagnify_Click
            
        Case conMenu_Process_Shrink         '缩小
            Call cmdReduce_Click
        
        Case conMenu_Process_Restore        '恢复
            Call cmdReset_Click
        
        Case conMenu_Process_ScamImg        '扫描图像
            Call cmdScanImg_Click
        
        Case conMenu_Process_DeleteImg      '删除图像
            Call cmdDeleteImg_Click
        
        Case conMenu_Process_ScanSet        '扫描设置
            Call cmdScanSet_Click
        
'        Case conMenu_Process_ChoiceEqu      '选择设备
'            Call cmdChoiceEqu_Click
        
        Case conMenu_File_Exit              '退出
            Call Menu_File_Exit
            
    End Select
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cbrMain_Update(ByVal Control As XtremeCommandBars.ICommandBarControl)
    On Error GoTo errhandle
    
    Select Case Control.ID
        Case conMenu_Process_RRotate, conMenu_Process_LRotate, conMenu_Process_Magnify, conMenu_Process_Shrink, _
             conMenu_Process_Restore    '顺时,逆时,放大,缩小,恢复
            
            Control.Enabled = mblnImgProcess
        
        Case conMenu_Process_ScamImg, conMenu_Process_ScanSet
            '扫描图像,删除图像,扫描设置
            Control.Visible = mblnOperate
            Control.Enabled = mblnOperate
            
        Case conMenu_Process_DeleteImg
            Control.Visible = mblnOperate
            Control.Enabled = mblnOperate And Not mblnIsLogin
    End Select
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub Menu_File_Exit()
    Unload Me
End Sub

Private Sub subSetRotate(blnClockwise As Boolean)
'------------------------------------------------
'功能：dcmViewImg中图像的旋转
'参数：blnClockwise旋转的方向,True=顺时针旋转；False=逆时针旋转
'返回：无，直接处理dcmView中的图像
'------------------------------------------------
    If dcmViewImg.Images.Count > 0 Then
        Dim iRotateState As Integer
        
        iRotateState = dcmViewImg.Images(1).RotateState
        If blnClockwise = True Then
            iRotateState = iRotateState - 1
        Else
            iRotateState = iRotateState + 1
        End If
        If iRotateState = -1 Then iRotateState = 3
        iRotateState = iRotateState Mod 4
        dcmViewImg.Images(1).RotateState = iRotateState
    End If
End Sub

Private Sub cmdDeleteImg_Click()
On Error GoTo errhandle

    '删除方法
    If mblnIsLogin Then
        Call subDeleteDcmImage
    Else
        Call subDeleteFTPImage
    End If
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdScanImg_Click()
On Error GoTo errhandle
    
    Call ScanImages
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdScanSet_Click()
On Error GoTo errhandle
    '打开扫描设置窗口
    Call frmScanSetup.ShowParameterConfig(ImageScanner, Me)
    mintImageType = Val(GetSetting("ZLSOFT", "公共模块\" & App.ProductName & "\frmPetitionCapture", "扫描图像格式", 0))
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub ScanImages()
    Dim strScanFile As String
    
    '删除程序中临时存储的图像目录
    On Error GoTo continue
    If Dir(mstrTempDirOfScan, vbDirectory) <> "" Then
        Call mdlDir.DeleteFolder(mstrTempDirOfScan, , False)
    End If
continue:

    If Dir(mstrTempDirOfScan, vbDirectory) = "" Then
        Call MkDir(mstrTempDirOfScan)
    End If

    '删除twain设备临时存储的目录
    On Error GoTo continue1
    If Dir(mstrScanDeviceTempDir, vbDirectory) <> "" Then
        Call mdlDir.DeleteFolder(mstrScanDeviceTempDir, , False)
    End If
continue1:

    If Dir(mstrScanDeviceTempDir, vbDirectory) = "" Then
        Call MkDir(mstrScanDeviceTempDir)
    End If
    
    mintScanImageIndex = 0
  
    If Val(GetSetting("ZLSOFT", "公共模块\" & App.ProductName & "\frmPetitionCapture", "扫描驱动类型", 0)) = vdtWDM Then
        On Error GoTo errProcess
        
        strScanFile = mstrTempDirOfScan & "\" & CONST_STR_DEFAULT_SCAN_FILE_TEMPLATE & strScanFile & ".bmp"
    
        Call frmScanSetup.ShowScanWind(strScanFile, Me)
        
        Exit Sub
    End If

    '设置扫描后的文件数据类型
    ImageScanner.FileType = IIf(mintImageType = 0, BMP_Bitmap, JPG_File)
    ImageScanner.StopScanBox = True
    ImageScanner.ShowSetupBeforeScan = True
    ImageScanner.ScanTo = UseFileTemplateOnly
    '设置采集的模板文件
    ImageScanner.Image = mstrTempDirOfScan & "\" & CONST_STR_DEFAULT_SCAN_FILE_TEMPLATE


    If Not ImageScanner.ScannerAvailable Then
        ImageScanner.OpenScanner
    End If

    On Error GoTo errProcess
    Call ImageScanner.StartScan
    Call ImageScanner.StopScan
    Call ImageScanner.CloseScanner

    Exit Sub
errProcess:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub dcmMiniature_Click()
On Error GoTo errhandle
    If mintCurImgIndex = 0 Then Exit Sub
    
   '将选中的图像单独加载到dcmViewImg里去
    Call LoadViewImg
    
    mblnImgProcess = True

    Call cbrMain_Resize
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub LoadViewImg()
On Error GoTo errH
    Dim ImgTmpImage As New DicomImage
    
    dcmViewImg.Images.Clear
    Set ImgTmpImage = dcmMiniature.Images.Item(mintCurImgIndex)
    
    dcmViewImg.Images.Add ImgTmpImage.SubImage(0, 0, ImgTmpImage.SizeX, ImgTmpImage.SizeY, 1, ImgTmpImage.Frame)
    dcmViewImg.Visible = True
    Exit Sub
errH:
    MsgBox "LoadViewImg过程异常:" & err.Description, vbInformation, gstrSysName
End Sub

Private Sub dcmMiniature_OnDataChanged()
    On Error GoTo errhandle

    If dcmMiniature.Images.Count = 0 Then
        RaiseEvent RefreshState(False)
    ElseIf dcmMiniature.Images.Count > 0 Then
        RaiseEvent RefreshState(True)
    End If
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub dcmViewImg_MouseMove(Button As Integer, Shift As Integer, X As Long, Y As Long)
On Error Resume Next

    If mblndcmViewImgDown = True And Button = 1 And dcmViewImg.Images.Count > 0 Then
        dcmViewImg.Images(1).ScrollX = mInitScrollPoint.X - X
        dcmViewImg.Images(1).ScrollY = mInitScrollPoint.Y - Y

        dcmViewImg.Refresh
    End If
End Sub

Private Sub dcmViewImg_MouseDown(Button As Integer, Shift As Integer, X As Long, Y As Long)
On Error GoTo errhandle
    Dim intLabelType As Integer

    If Button = 1 And dcmViewImg.Images.Count > 0 Then
        mMouseDownPoint.X = dcmViewImg.Images(1).ActualScrollX
        mMouseDownPoint.Y = dcmViewImg.Images(1).ActualScrollY
          
        mInitScrollPoint.X = dcmViewImg.Images(1).ScrollX + X
        mInitScrollPoint.Y = dcmViewImg.Images(1).ScrollY + Y
        
        mblndcmViewImgDown = True
        
        '记录当前鼠标坐标
        mlngBaseX = X
        mlngBaseY = Y
    End If
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub dcmViewImg_MouseUp(Button As Integer, Shift As Integer, X As Long, Y As Long)
On Error GoTo errhandle

    If mblndcmViewImgDown = True And Button = 1 And dcmViewImg.Images.Count > 0 Then
        '计算图像漫游的偏移位置
        mCorpSize.X = mCorpSize.X + (dcmViewImg.Images(1).ActualScrollX - mMouseDownPoint.X)
        mCorpSize.Y = mCorpSize.Y + (dcmViewImg.Images(1).ActualScrollY - mMouseDownPoint.Y)
    End If
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub dcmViewImg_MouseWheel(ByVal Shift As Long, ByVal Delta As Integer, ByVal X As Long, ByVal Y As Long)
On Error GoTo errhandle
    '鼠标滚动事件 实现拖动
     Dim dblZoom As Double
    dblZoom = dcmViewImg.Images(1).ActualZoom
    dblZoom = dblZoom * (1 + Delta * 0.001)
    If dblZoom < 64 And dblZoom > 0.01 Then
        subCenterZoom dcmViewImg.Images(1), dcmViewImg, dblZoom, mCorpSize
    End If
    mlngBaseY = Y
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cmdMagnify_Click()
On Error GoTo errhandle
'按钮放大
Dim dblZoom As Double

    dblZoom = dcmViewImg.Images(1).ActualZoom
    dblZoom = dblZoom * (1 + 300 * 0.001)
    If dblZoom < 64 And dblZoom > 0.01 Then
        subCenterZoom dcmViewImg.Images(1), dcmViewImg, dblZoom, mCorpSize
    End If
    'mlngBaseY = y
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub cmdReduce_Click()
On Error GoTo errhandle
'按钮缩小
    Dim dblZoom As Double
    
    dblZoom = dcmViewImg.Images(1).ActualZoom
    dblZoom = dblZoom * (1 + (-240) * 0.001)
    If dblZoom < 64 And dblZoom > 0.01 Then
        subCenterZoom dcmViewImg.Images(1), dcmViewImg, dblZoom, mCorpSize
    End If
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub cmdReset_Click()
On Error GoTo errhandle
'重置按钮以及图像
    
    '初始化拖动后的相对偏移位置
    mCorpSize.X = 0
    mCorpSize.Y = 0
    
    '重置图像
    Call LoadViewImg
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub subCenterZoom(img As DicomImage, Viewer As DicomViewer, dblZoom As Double, corpSize As TPoint)
'------------------------------------------------
'功能：对图像进行缩放。以当前viewer中心点为缩放中心点。
'参数： img -- 进行缩放的图像
'       viewer －－ 图像所在的viewer
'       dblZoom －－图像新的缩放倍数
'------------------------------------------------
    img.Zoom = dblZoom
    img.StretchToFit = False

    img.ScrollX = (img.SizeX * img.ActualZoom - ScaleX(Viewer.Width, vbTwips, vbPixels) / Viewer.MultiColumns) / 2 + corpSize.X
    img.ScrollY = (img.SizeY * img.ActualZoom - ScaleY(Viewer.Height, vbTwips, vbPixels) / Viewer.MultiRows) / 2 + corpSize.Y
End Sub

Private Sub Form_Load()
'窗体加载事件

Dim strFolder As String
On Error GoTo errhandle
    Call RestoreWinState(Me, App.ProductName)
    
    Call InitCommandBars
    
    mstrTempDirOfScan = App.Path + CONST_STR_DEFAULT_TEMP_SCAN_DIR_NAME
    If Len(mstrTempDirOfScan) > 45 Then
        
        Dim pathlen As Long

        strFolder = String(256, 0)
        pathlen = GetTempPath(256, strFolder)
        If pathlen > 0 Then
            mstrTempDirOfScan = Left(strFolder, pathlen - 1) + CONST_STR_DEFAULT_TEMP_SCAN_DIR_NAME
        End If
    End If
    
    '根据参数判断 当前是查看申请单还是扫描申请单,如是查看则禁用四个操作按钮
    If mblnIsExamine Then mblnOperate = False
    
    '初始化隐藏 图像高级处理按钮
    mblnImgProcess = False
    
    '设置设备临时目录
    mstrScanDeviceTempDir = GetSetting("ZLSOFT", "公共模块\" & App.ProductName & "\frmPetitionCapture", "扫描临时目录", "C:\Documents and Settings\All Users\Application Data\Microsoft\WIA")
    
    mintImageType = Val(GetSetting("ZLSOFT", "公共模块\" & App.ProductName & "\frmPetitionCapture", "扫描图像格式", 0))

    '如果程序在磁盘的根目录则app.path为“x:\”
    mstrBufferDir = FormatFilePath(GetAppRootPath() & "\Apply\TmpImage\")
    
    '将已有图像加载到DcmViewer控件中显示
    Call GetPetitionImages(dcmMiniature, mlngAdviceId, 100)

    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Sub Form_Unload(Cancel As Integer)
On Error GoTo errhandle
    Call SaveWinState(Me, App.ProductName)

    '关闭窗口时 断开当前FTP连接
'    miNet.FuncFtpDisConnect
    Set mdcmTmpView = Nothing
    Exit Sub
errhandle:
    '断开FTP连接
'    miNet.FuncFtpDisConnect
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub InitLables()
'根据传入的值给病人基本信息lbl赋值
    labName.Caption = mstrPatientName
    labName.ToolTipText = mstrPatientName
    
    labNo.Caption = mstrCheckNo
    labNo.ToolTipText = mstrCheckNo
    
    labRoom.Caption = mstrDeptName
    labRoom.ToolTipText = mstrDeptName
    
    labSex.Caption = mstrPatientSex
    labSex.ToolTipText = mstrPatientSex
    
    labAge.Caption = mstrPatientAge
    labAge.ToolTipText = mstrPatientAge
    
    txtAppend = "检查部位:" & vbNewLine & "  " & mstrExamineMethod & vbNewLine & "检查内容:" & vbNewLine & "  " & mstrSpePosition
End Sub

Public Sub InitDeptPara(ByVal lngDeptId As Long)
'初始化科室级参数
    Dim rsTmp As New ADODB.Recordset
    Dim strFtpIp As String
    Dim strFTPUser As String
    Dim strFTPPwd As String
    Dim strFtpDir As String
    
On Error GoTo DBError
    mlngCurDeptId = lngDeptId
    
    '读取并检测存储设备号
    mstrSaveDeviceID = GetDeptPara(mlngCurDeptId, "申请单存储设备号")
    gstrSQL = "Select 设备号,设备名 From 影像设备目录 Where 类型=1 and 设备号=[1] and NVL(状态,0)=1"
    Set rsTmp = zlDatabase.OpenSQLRecord(gstrSQL, "得到设备号", mstrSaveDeviceID)
    If rsTmp.EOF Then
        MsgBox "申请单存储设备未定义或处于停用，请检查！", vbInformation, gstrSysName
        mstrSaveDeviceID = ""
        Exit Sub
    End If
    
    Call GetFtpDeviceWithDeviceNo(Me, mstrSaveDeviceID, strFtpDir, strFtpIp, strFTPUser, strFTPPwd)
    
    mstruFtpTag = FtpTagInstance(strFtpIp, strFTPUser, strFTPPwd, strFtpDir)
    
    Exit Sub
DBError:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub imageScanner_PageDone(ByVal PageNumber As Long)
On Error GoTo errhandle
      Dim strScanFile As String

      If mintScanImageIndex = -1 Then
        Exit Sub
      End If
    
      '计算扫描文件索引
      mintScanImageIndex = mintScanImageIndex + 1
    
      
      strScanFile = mintScanImageIndex
    
      '取得有效的扫描文件名称
      While Len(strScanFile) < 4
        strScanFile = "0" + strScanFile
      Wend
    
      strScanFile = mstrTempDirOfScan & "\" & CONST_STR_DEFAULT_SCAN_FILE_TEMPLATE & strScanFile & ".bmp"
    
      '保存扫描的图像
      Call subCaptureImg(True, strScanFile)

    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Sub subCaptureImg(ByVal RealTimeCap As Boolean, Optional ByVal strFileName As String = "", _
    Optional ByRef picCapture As StdPicture = Nothing, Optional ByVal blnIsAfterCapture As Boolean = False)
'------------------------------------------------
'功能: 扫描并存储图像
'参数：无
'返回：无，直接保存新采集的图像
'------------------------------------------------
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    If dcmMiniature.Images.Count > 9 Then
        MsgBoxD Me, "已经存在10张申请单，若想继续扫描，请先删除前面不需要的申请单。", vbInformation, gstrSysName
        Exit Sub
    End If

    If mblnIsLogin Then
        If funCaptureSingleImage(RealTimeCap, strFileName, picCapture) = False Then
            MsgBoxD Me, "图像加载失败。", vbInformation, gstrSysName
            Exit Sub
        End If
    Else
        If funCaptureSingleImage(RealTimeCap, strFileName, picCapture) = True Then
            '调用保存图像到服务器 方法
            Call subSaveImage(, mlngAdviceId)
        End If
    End If
    
    lab.Visible = False
    img.Visible = False
    
End Sub




Private Function funCaptureSingleImage(ByVal RealTimeCap As Boolean, _
    Optional ByVal strFileName As String = "", Optional ByRef picCapture As StdPicture = Nothing) As Boolean
'------------------------------------------------
'功能：将图像放入缩略图dcmMiniature中。
'参数：无
'返回：无，直接将新采集的图像放入dcmMiniature中
'------------------------------------------------

    Dim ImgTmpImage As New DicomImage

    On Error GoTo SaveFileError

    '扫描图像
    Call Clipboard.Clear

    If Not (picCapture Is Nothing) Then
        Set picTemp2.Picture = Nothing
        Set picTemp2.Picture = picCapture

    ElseIf Trim(strFileName) <> "" And Dir(strFileName) <> "" Then
        '使用dcmView显示的是图片，不需要再裁剪
        Set picTemp2.Picture = Nothing
        Set picTemp2.Picture = LoadPicture(strFileName)

    Else
        Set picTemp2.Picture = Nothing

    End If

    '将图像再次提交到剪切板
    If picTemp2.Picture Is Nothing Then
        funCaptureSingleImage = False
        Exit Function
    End If


    Call Clipboard.SetData(picTemp2.Picture, 2)
'    从剪切板取回图像
    Call ImgTmpImage.Paste

    Call Clipboard.Clear

    '将图像放入缩略图中
    Call subInsert2Mini(ImgTmpImage)

    funCaptureSingleImage = True

    Exit Function
SaveFileError:
    If ErrCenter() = 1 Then
        Resume
    End If

    Call SaveErrLog
End Function

Private Sub subInsert2Mini(img As DicomImage)
'------------------------------------------------
'功能：将图像添加到缩略图dcmMiniature中
'参数：img－－输入的图像
'返回：无，直接将图像添加到缩略图dcmMiniature中
'------------------------------------------------
    Dim iRows As Integer
    Dim iCols As Integer

    '计算缩略图的图像布局
    ResizeRegion dcmMiniature.Images.Count + 1, dcmMiniature.Width, dcmMiniature.Height, iRows, iCols

    dcmMiniature.MultiColumns = iCols
    dcmMiniature.MultiRows = iRows

    dcmMiniature.Images.Add img

    '处理缩略图中被选中的状态
    If mintCurImgIndex > 0 And mintCurImgIndex <= dcmMiniature.Images.Count Then
        dcmMiniature.Images(mintCurImgIndex).BorderColour = vbWhite
    End If


    With dcmMiniature.Images(dcmMiniature.Images.Count)
        .BorderWidth = 1
        .BorderStyle = 6
        .BorderColour = vbRed
    End With

    If Not mdcmTmpView Is Nothing Then
        mdcmTmpView.Images.Add img
    End If
    
    mintCurImgIndex = dcmMiniature.Images.Count
    Call dcmMiniature_Click
End Sub


Public Sub subSaveImage(Optional iEncode As Integer = 0, Optional lngAdviceId As Long, Optional dcmTmpView As DicomViewer = Nothing)
'------------------------------------------------
'功能：将最后一个缩略图保存到数据库中
'参数：iEncode－－压缩方式，1－Run-Length Encoding行程压缩；2－不处理，保持原图的压缩方式，其他－Lossless JPEG encoding JPEG无损压缩
'返回：无
'------------------------------------------------
    Dim rsTmp As New ADODB.Recordset
    Dim ImgTmp As New DicomImage
    
    Dim strReceived As String
    Dim strFileTitle As String       '图像文件开头
    Dim lngResult As Long         'FTP操作结果
'    Dim blnResult As Boolean
    Dim nowTime As Date
    Dim blnInTrans As Boolean       '在事物处理过程中
    Dim strRandom As String
    Dim lngImage As Long
    Dim strSQL As String
    Dim arrSQL() As String
    Dim arrImages() As String       '上传FTP成功的图片
    Dim i As Long
    
    On Error GoTo errhandle
    
    If Not dcmTmpView Is Nothing Then
        If dcmTmpView.Images.Count <= 0 Then Exit Sub
        lngImage = dcmTmpView.Images.Count
    Else
        If dcmMiniature.Images.Count <= 0 Then Exit Sub
        '读取最后一个缩略图
        Set ImgTmp = dcmMiniature.Images(dcmMiniature.Images.Count)
        lngImage = 1
    End If
    
 
    nowTime = zlDatabase.Currentdate
    strReceived = Format(nowTime, "yyyymmdd")
    
    '创建缓冲目录
    MkLocalDir mstrBufferDir & strReceived & "/" & lngAdviceId & "/"
    
    ReDim arrImages(0)
    ReDim arrSQL(0)
    For i = 1 To lngImage
        
        If Not dcmTmpView Is Nothing Then
            Set ImgTmp = dcmTmpView.Images(i)
        End If
        
        '得到随机数
        strRandom = CInt(Rnd * 100 + 1)
    
        nowTime = zlDatabase.Currentdate
        strFileTitle = Format(nowTime, "mmddhhmmss") & Format((Timer() * 1000) Mod 1000, "000")
    
        '保存图像到缓存目录  Lossless JPEG encoding JPEG无损压缩
        ImgTmp.WriteFile mstrBufferDir & strReceived & "/" & lngAdviceId & "/" & strFileTitle & lngAdviceId & strRandom, True
    
        'ImgTmp.FileExport mstrBufferDir & strReceived & "/" & lngAdviceID & "/" & strFileTitle & lngAdviceID & strRandom & ".jpg", "JPG", 80
    
        ImgTmp.tag = strFileTitle & lngAdviceId & strRandom '& ".jpg"
    
        '保存扫描单图像
        lngResult = FtpUpload(mstruFtpTag, _
                            strReceived & "/" & lngAdviceId & "/" & strFileTitle & lngAdviceId & strRandom, _
                            mstrBufferDir & strReceived & "/" & lngAdviceId & "/" & strFileTitle & lngAdviceId & strRandom, _
                            False)
        If lngResult = frAbort Then Exit Sub

        If lngResult = frNormal Then
            '上传FTP成功的申请单记录到数组，方便失败后删除
            ReDim Preserve arrImages(UBound(arrImages) + 1)
            arrImages(UBound(arrImages)) = strReceived & "/" & lngAdviceId & "/" & strFileTitle & lngAdviceId & strRandom
            
            '图像存储成功后，存储数据库信息
            strSQL = "ZL_影像申请单图像_INSERT ('" & lngAdviceId & "','" & strFileTitle & lngAdviceId & strRandom & "','" & strReceived & "/" & lngAdviceId & "','" & mstrSaveDeviceID & "','" & UserInfo.姓名 & "',sysdate)"
            
            ReDim Preserve arrSQL(UBound(arrSQL) + 1)
            arrSQL(UBound(arrSQL)) = strSQL
        End If
    Next
    
    
    '保存图像
    gcnOracle.BeginTrans
    
    blnInTrans = True
    For i = 1 To UBound(arrSQL)
        Call zlDatabase.ExecuteProcedure(CStr(arrSQL(i)), "保存图像")
    Next
    
    gcnOracle.CommitTrans
    
    blnInTrans = False
    
    '如果mblnIsLogin=true 那么说明这是在登记界面的保存图像，需要将该参数设置为false
    If mblnIsLogin Then
        mblnIsLogin = False
    End If
    
    Exit Sub
errhandle:
    If blnInTrans Then
        gcnOracle.RollbackTrans
        blnInTrans = False
    End If
    
    
    Call CancelImagesUp(arrImages)
    
    MsgBox "申请单图像保存失败。", vbInformation, gstrSysName
    
    If dcmTmpView Is Nothing Then
        dcmMiniature.Images.Remove (dcmMiniature.Images.Count)
    End If
End Sub

Private Sub CancelImagesUp(arrImages() As String)
    Dim i As Long
    
    For i = 1 To UBound(arrImages)
        Call FtpDelete(mstruFtpTag, arrImages(i), False, False)
    Next
End Sub


Public Sub GetPetitionImages(dcmViewer As DicomViewer, lngAdviceId As Long, _
Optional intGetImgNum As Integer = 0, Optional intShowImgNum As Integer = 0)
'------------------------------------------------
'功能：删除dcmViewer中的图像后，将读取的图像文件放入dcmViewer中
'参数： dcmViewer－－打开图像的DicomViewer
'       lngAdviceID －－ 医嘱ID
'       intGetImgNum －－本次读取的图像数量
'       intShowImgNum －－本次显示的图像数量
'返回：无，直接修改dcmViewer中显示的图像
'------------------------------------------------

    Dim strSQL As String
    Dim rsTmp As New ADODB.Recordset
    Dim curImage As DicomImage
    Dim iCols As Integer, iRows As Integer
    Dim objFile As New Scripting.FileSystemObject, strTmpFile As String
    Dim struFtpTag As TFtpConTag
    Dim strFTPUser As String              'FTP账号
    Dim strFtpPass As String              'FTP密码
    Dim strFtpDir As String               'FTP目录
    Dim strFtpIp As String                'FTP地址
    Dim strRequestName As String
    Dim strFirstDevNo As String
    Dim strNextDevNo As String
    Dim strTmpFolder As String
    Dim i As Long
    Dim lngResult As Long
    
    On Error GoTo DBError
    
    If mblnIsLogin Then
        If mdcmTmpView.Images.Count > 0 Then
            lab.Visible = False
            img.Visible = False
            ResizeRegion mdcmTmpView.Images.Count, dcmViewer.Width, dcmViewer.Height, iRows, iCols
            dcmViewer.MultiColumns = iCols
            dcmViewer.MultiRows = iRows
            
            For i = 1 To mdcmTmpView.Images.Count
                dcmViewer.Images.Add mdcmTmpView.Images(i)
                dcmViewer.Images(i).BorderWidth = 1
            Next
        
        End If
    Else
       strSQL = "select 申请单图像,扫描人,扫描时间,FTP路径,设备号 from 影像申请单图像 where 医嘱ID=[1] order by 设备号"
       Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "提取申请单图像信息", lngAdviceId)

        'dcmViewer.Images.Clear
        If rsTmp.RecordCount > 0 Then
            lab.Visible = False
            img.Visible = False
            ResizeRegion rsTmp.RecordCount, dcmViewer.Width, dcmViewer.Height, iRows, iCols

            dcmViewer.MultiColumns = iCols
            dcmViewer.MultiRows = iRows
            
            mstrBufferDir = FormatFilePath(GetAppRootPath & "\Apply\TmpImage\")
            
            strFirstDevNo = nvl(rsTmp("设备号"))
   
            Do While Not rsTmp.EOF
                If InStr(nvl(rsTmp("申请单图像")), ".") > 1 Then
                    '处理35.110以前的坑，以前申请单名称增加了jpg的后缀，然而ftp上却没有存储jpg文件
                    strRequestName = nvl(rsTmp("FTP路径")) & "/" & Mid(nvl(rsTmp("申请单图像")), 1, InStr(nvl(rsTmp("申请单图像")), ".") - 1)
                Else
                    strRequestName = nvl(rsTmp("FTP路径")) & "/" & nvl(rsTmp("申请单图像"))
                End If
                
                strTmpFolder = mstrBufferDir & objFile.GetParentFolderName(strRequestName)
                '创建本地目录
                If Not objFile.FolderExists(strTmpFolder) Then Call MkLocalDir(strTmpFolder)
            
                If strFirstDevNo <> strNextDevNo Then
                    strFirstDevNo = strNextDevNo
                    
                    Call GetFtpDeviceWithDeviceNo(Me, nvl(rsTmp("设备号")), strFtpDir, strFtpIp, strFTPUser, strFtpPass)
                    
                    struFtpTag = FtpTagInstance(strFtpIp, _
                                                strFTPUser, _
                                                strFtpPass, _
                                                objFile.GetParentFolderName(strFtpDir & strRequestName))
                End If
                
                strTmpFile = mstrBufferDir & strRequestName

                If Dir(strTmpFile) = vbNullString Then
                    '本地缓存图像不存在，则读取FTP图像
                    lngResult = FtpDownload(struFtpTag, objFile.GetFileName(strRequestName), strTmpFile, False)
                    If lngResult = frAbort Then Exit Sub
                    
                End If

                If Dir(strTmpFile) <> vbNullString Then
                        
                        Set curImage = dcmViewer.Images.ReadFile(strTmpFile)
                        curImage.tag = nvl(rsTmp("申请单图像"))
                        
                        With curImage
                            .BorderStyle = 6
                            .BorderWidth = 1
                            .BorderColour = vbWhite
                        End With

                    '取消自动剪影,因为DicomObjects控件本身对处理剪影有BUG，存在（0028，6100）时，会自动对图像进行剪影，
                    '导致晋煤的DSA图像不能正常显示
                    '虽然设置图像的mask=0 ,可以取消剪影，但是每次图像被添加到新的Dicomimages之后，自动又将mask设置成1了，
                    '这样在程序中无法很好的控制，因此直接去掉（0028，6100）这个属性。
                    If Not IsNull(curImage.Attributes(&H28, &H6100).value) Then
                        curImage.Attributes.Remove &H28, &H6100
                    End If
                End If

                rsTmp.MoveNext
                If Not rsTmp.EOF Then strNextDevNo = nvl(rsTmp("设备号"))
            Loop
        End If

    End If
    
    If dcmViewer.Images.Count > 0 Then
        dcmViewer.CurrentIndex = 1
        dcmViewer.Images(dcmViewer.Images.Count).BorderColour = vbRed
        
        mintCurImgIndex = dcmViewer.Images.Count
        Call dcmMiniature_Click
    Else
        lab.Visible = True
        img.Visible = True
        dcmViewImg.Visible = False
        dcmViewer.MultiColumns = 1
        dcmViewer.MultiRows = 1
    End If
        
    Exit Sub
DBError:
    If ErrCenter() = 1 Then
        Resume
    End If

    Call SaveErrLog
End Sub

Private Sub subDeleteFTPImage()
'------------------------------------------------
'功能：删除缩略图中被选中的图像，先从数据库中删除，然后从FTP中删除.
'参数：无
'返回：无，直接删除缩略图中最后一个图像
'------------------------------------------------
On Error GoTo errH
    Dim blnResult As Boolean
    Dim i As Integer, iRows As Integer, iCols As Integer
    
    If dcmMiniature.Images.Count > 0 And mintCurImgIndex > 0 And mintCurImgIndex <= dcmMiniature.Images.Count Then
        
        '从数据库和FTP中删除缩略图中被选中的图像
        blnResult = DelPetitionImg()
        
        If blnResult = True Then    '删除成功，则修改缩略图状态，并触发StateChanged事件
            '在缩略图中删除图像
            dcmMiniature.Images.Remove mintCurImgIndex
            
            If dcmMiniature.Images.Count = 0 Then
                '删除的时候只有一张图,删除完成后旋转等按钮调整为不可用，右边大图隐藏
                lab.Visible = True
                img.Visible = True
            
                mblnImgProcess = False
                mintCurImgIndex = 0
                dcmViewImg.Visible = False
            Else
                '删除时有多张图，删除完成后自动选中前一张图
                For i = mintCurImgIndex + 1 To dcmMiniature.Images.Count
                    Call dcmMiniature.Images.Move(i, i - 1)
                Next i
                
                '重新布局
                '计算缩略图的图像布局
                ResizeRegion dcmMiniature.Images.Count + 1, dcmMiniature.Width, dcmMiniature.Height, iRows, iCols
            
                dcmMiniature.MultiColumns = iCols
                dcmMiniature.MultiRows = iRows
    
                Call dcmMiniature.Refresh

                If mintCurImgIndex > 1 Then
                    mintCurImgIndex = mintCurImgIndex - 1
                Else
                    mintCurImgIndex = 1
                End If
                dcmMiniature.Images(mintCurImgIndex).BorderColour = vbRed

                Call dcmMiniature_Click
            End If
            
            
        
        End If
    End If
    Exit Sub
errH:
    MsgBoxD Me, "删除失败-" & err.Description, vbInformation, gstrSysName
End Sub

Private Sub subDeleteDcmImage()

'在缩略图中删除图像
        dcmMiniature.Images.Remove mintCurImgIndex
        
        If mintCurImgIndex > dcmMiniature.Images.Count Then
            mintCurImgIndex = dcmMiniature.Images.Count
        End If

        If mintCurImgIndex > 0 Then
            dcmMiniature.Images(mintCurImgIndex).BorderColour = vbRed
        End If
        

End Sub


Private Function DelPetitionImg() As Boolean
'------------------------------------------------
'功能：从数据库和FTP中删除图像，删除缩略图中被选中的图像
'参数：无
'返回：True－－删除成功，False－－删除失败

    Dim ImgTmp As New DicomImage
    Dim rsTmp As New ADODB.Recordset
    Dim strReportImage As String
    Dim varTmp As Variant
    Dim strResult As Long
    Dim strSQL As String
    Dim strFTPUser As String              'FTP账号
    Dim strFtpPass As String              'FTP密码
    Dim strFtpDir As String               'FTP目录
    Dim strFtpIp As String                'FTP地址
    Dim struFtpTag As TFtpConTag
    Dim lngResult As Long
    
    If dcmMiniature.Images.Count < mintCurImgIndex Then Exit Function
    Set ImgTmp = dcmMiniature.Images(mintCurImgIndex)
                
    On Error GoTo errHand
    
    strSQL = "select 扫描时间,设备号 from 影像申请单图像 where 医嘱ID=[1] and 申请单图像 = [2]"
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "提取申请单图像信息", mlngAdviceId, ImgTmp.tag)
    
    If rsTmp.EOF = True Then
        MsgBoxD Me, "没有找到可以删除的图像!", vbInformation, gstrSysName
        DelPetitionImg = False
        Exit Function
    End If
    
    Call GetFtpDeviceWithDeviceNo(Me, nvl(rsTmp("设备号")), strFtpDir, strFtpIp, strFTPUser, strFtpPass)
    
    struFtpTag = FtpTagInstance(strFtpIp, strFTPUser, strFtpPass, strFtpDir)
    

    gstrSQL = "ZL_影像申请单图像_DELETE(" & mlngAdviceId & ",'" & ImgTmp.tag & "')"

    zlDatabase.ExecuteProcedure gstrSQL, "影像图像删除"

    '删除图像文件
    lngResult = FtpDelete(struFtpTag, Format(nvl(rsTmp("扫描时间"), CStr(zlDatabase.Currentdate)), "yyyyMMdd") & "/" & _
                mlngAdviceId & "/" & ImgTmp.tag, False, False)
                
    DelPetitionImg = True
    Exit Function
errHand:
    '断开FTP连接
'    miNet.FuncFtpDisConnect
    If ErrCenter() = 1 Then
        Resume
    End If
    Call SaveErrLog
End Function


Private Sub dcmMiniature_MouseDown(Button As Integer, Shift As Integer, X As Long, Y As Long)
On Error GoTo errhandle
    Dim i As Integer
    Dim j As Integer

    If Button = 1 Then
        mCorpSize.X = 0
        mCorpSize.Y = 0
        
        '被选中图像显示红框
        i = dcmMiniature.ImageIndex(X, Y)
        If i <> 0 Then
        
            For j = 1 To dcmMiniature.Images.Count
                dcmMiniature.Images(j).BorderColour = vbWhite
            Next
            dcmMiniature.Images(i).BorderColour = vbRed
            mintCurImgIndex = i
            
        End If
    End If
    
    Exit Sub
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub cbrMain_Resize()
    Dim lngLeft As Long, lngTop As Long, lngRight As Long, lngBottom As Long
    Dim lngHeightdcmMiniature As Long
    
    On Error Resume Next
    
    cbrMain.GetClientRect lngLeft, lngTop, lngRight, lngBottom
    
    lngHeightdcmMiniature = Me.ScaleHeight - fmeInfoCtrl.Height - lngTop - 120

    Call fmeInfoCtrl.Move(0, lngTop, IIf(lngRight > 2800, 2800, lngRight), 3000)
    Call fmePatientInfo.Move(60, 0, fmeInfoCtrl.Width - 100, 3000)
    Call fmeDcmViewer.Move(fmeInfoCtrl.Width, lngTop, Me.ScaleWidth - fmeInfoCtrl.Left - fmeInfoCtrl.Width - 120, Me.ScaleHeight - lngTop - 60)
    Call dcmMiniature.Move(60, fmeInfoCtrl.Top + fmeInfoCtrl.Height + 60, fmeInfoCtrl.Width - 120, lngHeightdcmMiniature) 'LTWH
    Call dcmViewImg.Move(60, 60, fmeDcmViewer.Width - 120, fmeDcmViewer.Height - 60)
    
    Call lab.Move((fmeDcmViewer.Width - lab.Width) / 2, (fmeDcmViewer.Height - lab.Height) / 2)
    Call img.Move((fmeDcmViewer.Width - img.Width) / 2, lab.Top - img.Height - 120)
    
    
End Sub

