VERSION 5.00
Object = "{945E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.DockingPane.9600.ocx"
Object = "{555E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.CommandBars.9600.ocx"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "richtx32.ocx"
Object = "{853AAF94-E49C-11D0-A303-0040C711066C}#4.3#0"; "DicomObjects.ocx"
Begin VB.Form frmReportHistory 
   Caption         =   "报告修订历史"
   ClientHeight    =   6270
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   9735
   Icon            =   "frmReportHistory.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6270
   ScaleWidth      =   9735
   StartUpPosition =   1  '所有者中心
   Begin VB.PictureBox picMain 
      BorderStyle     =   0  'None
      Height          =   5535
      Left            =   1080
      ScaleHeight     =   5535
      ScaleWidth      =   7935
      TabIndex        =   0
      Top             =   480
      Width           =   7935
      Begin VB.PictureBox picReportImage 
         Height          =   2055
         Left            =   480
         ScaleHeight     =   1995
         ScaleWidth      =   2715
         TabIndex        =   5
         Top             =   480
         Width           =   2775
         Begin DicomObjects.DicomViewer dcmReportImage 
            Height          =   1695
            Index           =   0
            Left            =   240
            TabIndex        =   6
            Top             =   120
            Visible         =   0   'False
            Width           =   1935
            _Version        =   262147
            _ExtentX        =   3413
            _ExtentY        =   2990
            _StockProps     =   35
            UseScrollBars   =   0   'False
         End
      End
      Begin VB.PictureBox picMark 
         Height          =   1815
         Left            =   480
         ScaleHeight     =   1755
         ScaleWidth      =   2835
         TabIndex        =   3
         Top             =   3120
         Width           =   2895
         Begin DicomObjects.DicomViewer dcmMark 
            Height          =   975
            Left            =   240
            TabIndex        =   4
            Top             =   240
            Width           =   1695
            _Version        =   262147
            _ExtentX        =   2990
            _ExtentY        =   1720
            _StockProps     =   35
            BackColor       =   -2147483629
            UseScrollBars   =   0   'False
         End
      End
      Begin VB.PictureBox pictxt 
         Height          =   4095
         Left            =   4200
         ScaleHeight     =   4035
         ScaleWidth      =   3435
         TabIndex        =   1
         Top             =   720
         Width           =   3495
         Begin RichTextLib.RichTextBox rtxtReport 
            Height          =   2415
            Left            =   0
            TabIndex        =   2
            Top             =   240
            Width           =   3855
            _ExtentX        =   6800
            _ExtentY        =   4260
            _Version        =   393217
            ReadOnly        =   -1  'True
            ScrollBars      =   2
            TextRTF         =   $"frmReportHistory.frx":0CCA
         End
      End
      Begin XtremeDockingPane.DockingPane dkpMain 
         Left            =   0
         Top             =   0
         _Version        =   589884
         _ExtentX        =   450
         _ExtentY        =   423
         _StockProps     =   0
      End
   End
   Begin XtremeCommandBars.CommandBars cbrMain 
      Left            =   360
      Top             =   0
      _Version        =   589884
      _ExtentX        =   635
      _ExtentY        =   635
      _StockProps     =   0
   End
End
Attribute VB_Name = "frmReportHistory"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private mlngAdviceID As Long        '医嘱ID
Private mlngPatientId As Long       '病人ID
Private mlngCur科室ID As Long       '科室ID
Private mlngReportID As Long        '报告ID
Private mlngMode As Long            '报告查看状态，0-修订状态，1-最终状态
Private mintReportCount As Integer  '历史报告的总数
Private mlngViewReportID As Long    '当前查看的报告ID
Private mlngViewAdviceID As Long    '当前查看的医嘱ID
Private mstrOffset As String        '当前行左边的缩进
Private mblnMoved As Boolean        '是否被转储
Private mdcmGlobal As New DicomGlobal    '定义UIDRoot=1
Private mblnHaveReport As Boolean '存在报告图
Private mblnHaveMark As Boolean '存在标记图

Private mobjReport As zlRichEPR.cDockReport    '报告对象



Public Sub zlShowMe(frmParent As Object, lngAdviceID As Long, lngReportID As Long, Optional blnMoved As Boolean = False)
    mlngReportID = 0
    mblnHaveReport = False
    mblnHaveMark = False
    
    mlngAdviceID = lngAdviceID
    mlngReportID = lngReportID
    mlngViewReportID = mlngReportID
    mlngViewAdviceID = mlngAdviceID
    
    mblnMoved = blnMoved
    
    Call LoadImg
'    'InitFaceScheme放在LoadImg之后
    Call InitFaceScheme
    
    Me.Show 0, frmParent
End Sub

Private Sub cbrMain_Execute(ByVal Control As XtremeCommandBars.ICommandBarControl)
    Select Case Control.ID
        Case conMenu_PacsReport_Mode_Orig                   '原始状态
            If mlngMode <> 0 Then
                ShowModeOrig mlngViewReportID, mlngViewAdviceID
            End If
            mlngMode = 0
            Me.cbrMain.FindControl(, conMenu_PacsReport_Mode_Clear, , True).Checked = False
            Control.Checked = True
        Case conMenu_PacsReport_Mode_Clear                  '最终状态
            If mlngMode <> 1 Then
                ShowModeClear mlngViewReportID, mlngViewAdviceID
            End If
            mlngMode = 1
            Me.cbrMain.FindControl(, conMenu_PacsReport_Mode_Orig, , True).Checked = False
            Control.Checked = True
        Case conMenu_File_Preview                           '报告预览
            If mlngViewReportID = 0 Then Exit Sub
            mobjReport.zlRefresh 0, 0
            mobjReport.zlRefresh mlngViewAdviceID, UserInfo.部门ID
            mobjReport.zlExecuteCommandBars Control
        Case conMenu_File_Exit                              '   退出
                Unload Me
        Case Else
            ShowHistory Control.ID
    End Select
End Sub

Private Sub cbrMain_Resize()
    Dim iLeft As Long, iTop As Long, iRight As Long, iBottom As Long
    cbrMain.GetClientRect iLeft, iTop, iRight, iBottom
'    rtxtReport.Left = iLeft
'    rtxtReport.Top = iTop
'    rtxtReport.Width = Abs(iRight - iLeft)
'    rtxtReport.Height = Abs(iBottom - iTop)
End Sub

Private Sub ShowHistory(iIndex As Integer)
    Dim lngReportID As Long
    Dim lngAdviceID As Long
    Dim strTemp As String
    
    If iIndex > conMenu_PacsReport_History_Times And iIndex <= conMenu_PacsReport_History_Times + mintReportCount Then
        strTemp = Me.cbrMain.FindControl(, iIndex, , True).DescriptionText
        If InStr(strTemp, "-") <> 0 Then
            lngReportID = Val(Split(strTemp, "-")(1))
            lngAdviceID = Val(Split(strTemp, "-")(0))
            mlngViewReportID = lngReportID
            mlngViewAdviceID = lngAdviceID
            If mlngMode = 0 Then
                Call ShowModeOrig(mlngViewReportID, mlngViewAdviceID)
            ElseIf mlngMode = 1 Then
                Call ShowModeClear(mlngViewReportID, mlngViewAdviceID)
            End If
        End If
    End If
End Sub

Private Sub ShowTitle(lngReportID As Long, lngAdviceID As Long)
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim strSeparator1 As String
    Dim strSeparator2 As String
    Dim lngStart As Long
    Dim strTitle As String
    Dim strWriter As String
    Dim lng病人ID As Long
    Dim lng主页ID As Long
    Dim int婴儿 As Integer
    Dim rsBaby As ADODB.Recordset
    
    If lngReportID = 0 Then Exit Sub
    
    strSeparator1 = mstrOffset & "==================================================" & vbCrLf
    strSeparator2 = mstrOffset & "-------------------" & vbCrLf
    
    strSQL = "Select a.姓名,a.检查号,b.开嘱时间,b.医嘱内容,a.报告人,a.复核人,nvl(b.婴儿,0) as 婴儿,a.接收日期 as 检查时间, " _
            & "b.病人ID, nvl(b.主页ID,0) as 主页ID From 影像检查记录 a,病人医嘱记录 b Where a.医嘱id = b.Id And b.Id = [1] "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngAdviceID)
    If rsTemp.EOF = True Then Exit Sub
    
    strTitle = mstrOffset & nvl(rsTemp!医嘱内容) & vbCrLf
    
    lngStart = Len(rtxtReport.Text)
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = 0
    rtxtReport.SelText = strTitle
    
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = Len(strTitle)
    rtxtReport.SelFontName = "宋体"
    rtxtReport.SelFontSize = 16
    rtxtReport.SelBold = True
    rtxtReport.SelColor = vbBlue
    
    '婴儿的姓名需要特殊显示
    If rsTemp!婴儿 = 0 Then
        strWriter = vbCrLf & mstrOffset & "姓名：" & nvl(rsTemp!姓名) & "      检查号：" & nvl(rsTemp!检查号) & vbCrLf _
               & mstrOffset & "报告人：" & nvl(rsTemp!报告人) & "      审核人：" & nvl(rsTemp!复核人) & vbCrLf _
               & mstrOffset & "开嘱时间： " & nvl(rsTemp!开嘱时间) & "      检查时间：" & nvl(rsTemp!检查时间) & vbCrLf
    Else
        lng病人ID = rsTemp!病人ID
        lng主页ID = rsTemp!主页ID
        int婴儿 = rsTemp!婴儿
        strSQL = "Select Decode(a.婴儿姓名,Null,b.姓名||'之子'||Trim(To_Char(a.序号,'9')),a.婴儿姓名) As 婴儿姓名,婴儿性别,出生时间 From 病人新生儿记录 a,病人信息 b Where a.病人id=[1] And a.主页id=[2] And a.病人id=b.病人id And a.序号=[3]"
        Set rsBaby = zlDatabase.OpenSQLRecord(strSQL, "查找婴儿信息", lng病人ID, lng主页ID, int婴儿)
        
        strWriter = vbCrLf & mstrOffset & "姓名：" & rsBaby!婴儿姓名 & "      检查号：" & nvl(rsTemp!检查号) & vbCrLf _
               & mstrOffset & "报告人：" & nvl(rsTemp!报告人) & "      审核人：" & nvl(rsTemp!复核人) & vbCrLf _
               & mstrOffset & "开嘱时间： " & nvl(rsTemp!开嘱时间) & "      检查时间：" & nvl(rsTemp!检查时间) & vbCrLf
    
    End If
    '显示创建人
    strWriter = strWriter
    
    lngStart = Len(rtxtReport.Text)
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = 0
    rtxtReport.SelText = strWriter
    
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = Len(strWriter)
    rtxtReport.SelFontName = "宋体"
    rtxtReport.SelFontSize = 14
    rtxtReport.SelBold = False
    rtxtReport.SelColor = vbBlue
    
    '显示横线
    lngStart = Len(rtxtReport.Text)
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = 0
    rtxtReport.SelText = strSeparator1
    
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = Len(strSeparator1)
    rtxtReport.SelFontName = "宋体"
    rtxtReport.SelFontSize = 14
    rtxtReport.SelBold = False
    rtxtReport.SelColor = vbBlack
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub Form_Load()
    
    mlngMode = 1
    mintReportCount = 0
    mstrOffset = "  "
    mdcmGlobal.RegString("UIDRoot") = "1"
    Set mobjReport = New zlRichEPR.cDockReport      '电子病历报告
    
    Call RestoreWinState(Me, App.ProductName)
    
    Call InitCommandBars '初始化菜单
    
    If mlngReportID = 0 Then    '当前报告没有保存，直接显示最近的一次历史报告
        If mintReportCount >= 1 Then
            ShowHistory conMenu_PacsReport_History_Times + mintReportCount
        End If
    Else
        ShowModeClear mlngViewReportID, mlngViewAdviceID
    End If
End Sub

Private Sub Form_Resize()
On Error Resume Next
    Call picMain.Move(0, Me.Height - Me.ScaleHeight, Me.ScaleWidth, Me.ScaleHeight)
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Dim i As Integer
    
    Unload mobjReport.zlGetForm        '电子病历报告
    '保存窗体位置
    Call SaveWinState(Me, App.ProductName)
    
    For i = 1 To dkpMain.PanesCount
        dkpMain.Panes(i).Handle = 0
    Next i
    dkpMain.CloseAll
    
    Set mdcmGlobal = Nothing
    Set mobjReport = Nothing
End Sub


Private Sub InitCommandBars()
    '功能创建工具条
On Error GoTo errH
    Dim cbrControl As CommandBarControl
    Dim cbrToolBar As CommandBar
    Dim cbrPopControl As CommandBarControl
    Dim strSQL  As String
    Dim strSQLBak As String
    Dim rsTemp As ADODB.Recordset
    
    '-----------------------------------------------------
    CommandBarsGlobalSettings.App = App
    CommandBarsGlobalSettings.ResourceFile = CommandBarsGlobalSettings.OcxPath & "\XTPResourceZhCn.dll"
    CommandBarsGlobalSettings.ColorManager.SystemTheme = xtpSystemThemeAuto
    Me.cbrMain.VisualTheme = xtpThemeOffice2003
    Set Me.cbrMain.Icons = zlCommFun.GetPubIcons
    
    With Me.cbrMain.Options
        .ShowExpandButtonAlways = False
        .ToolBarAccelTips = True
        .AlwaysShowFullMenus = True
        .IconsWithShadow = True '放在VisualTheme后有效
        .UseDisabledIcons = True
        .LargeIcons = True
        .SetIconSize True, 24, 24
    End With
    Me.cbrMain.EnableCustomization False
    Me.cbrMain.ActiveMenuBar.Visible = False
'    Me.cbrMain.ActiveMenuBar.EnableDocking 1 + xtpFlagStretched

'    Me.cbrMain.ActiveMenuBar.EnableDocking xtpFlagStretched + xtpFlagHideWrap
    
    '采集工具栏定义
    Set cbrToolBar = Me.cbrMain.Add("报告历史", xtpBarLeft)
'    cbrToolBar.EnableDocking xtpFlagStretched
    cbrToolBar.ShowTextBelowIcons = False
    cbrToolBar.Closeable = False
    
    With cbrToolBar.Controls
        Set cbrControl = .Add(xtpControlButton, conMenu_PacsReport_Mode_Orig, "原始状态")
        Set cbrControl = .Add(xtpControlButton, conMenu_PacsReport_Mode_Clear, "最终状态")
        cbrControl.Checked = True
        Set cbrControl = .Add(xtpControlButton, conMenu_File_Preview, "报告预览")
        cbrControl.IconId = 102
        cbrControl.Style = xtpButtonIconAndCaption
        cbrControl.BeginGroup = True
        
        '增加历史报告的菜单，只有有历史报告的时候，才增加这个菜单
        strSQL = "Select 病人ID,执行科室ID From 病人医嘱记录  Where Id = [1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "", mlngAdviceID)
        If rsTemp.EOF = False Then
            mlngPatientId = nvl(rsTemp!病人ID, 0)
            mlngCur科室ID = nvl(rsTemp!执行科室ID, 0)
            
            strSQL = "Select c.Id As 医嘱id,c.开嘱时间 As 开嘱时间,c.医嘱内容,b.病历Id  From 影像检查记录 a,病人医嘱报告 b,病人医嘱记录 c" _
                    & " Where a.医嘱id = c.Id And b.医嘱ID= c.Id And c.病人ID=[1] And c.相关ID Is Null And c.执行科室ID  in " _
                    & " (Select 部门ID From 部门人员 Where 人员ID =[2]) Order By 开嘱时间 Asc"
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "", mlngPatientId, UserInfo.ID)
            
            If rsTemp.RecordCount > 1 Or (mlngReportID = 0 And rsTemp.RecordCount = 1) Then
                Set cbrControl = .Add(xtpControlPopup, conMenu_PacsReport_History_Times, "报告历史"): cbrControl.ID = conMenu_PacsReport_History_Times
                
                Do Until rsTemp.EOF
                   Set cbrPopControl = cbrControl.CommandBar.Controls.Add(xtpControlButton, conMenu_PacsReport_History_Times + rsTemp.AbsolutePosition, "第" & rsTemp.AbsolutePosition & "次(" & Format(rsTemp!开嘱时间, "yyyy-mm-dd") & ") " & rsTemp!医嘱内容)
                   cbrPopControl.DescriptionText = rsTemp!医嘱ID & "-" & rsTemp!病历Id
                   rsTemp.MoveNext
                Loop
'                '如果当前正在编辑的报告还没有创建，则增加当前报告的菜单
'                If mlngReportID = 0 Then
'                    Set cbrPopControl = cbrControl.CommandBar.Controls.Add(xtpControlButton, conMenu_PacsReport_History_Times + rsTemp.RecordCount + 1, "当前报告")
'                   cbrPopControl.DescriptionText = mlngAdviceID & "-0"
'                End If
                mintReportCount = rsTemp.RecordCount
            End If
        End If
        
        Set cbrControl = .Add(xtpControlButton, conMenu_File_Exit, "退出")
        cbrControl.Style = xtpButtonIconAndCaption
      
    End With
    cbrToolBar.Position = xtpBarTop
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Sub ShowModeOrig(lngReportID As Long, lngAdviceID As Long)
    
    rtxtReport.Text = ""
    Call ShowTitle(lngReportID, lngAdviceID)
    Call ShowReportText(lngReportID, "检查所见")
    Call ShowReportText(lngReportID, "诊断意见")
    Call ShowReportText(lngReportID, "建议")
    
    rtxtReport.SelStart = 0
    rtxtReport.SelLength = 0
End Sub

Private Sub ShowReportText(lngReportID As Long, strType As String)
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim lngStart As Long
    Dim strText As String
    Dim strSeparator2 As String
    Dim strSeparator1 As String
    
    strSeparator1 = vbCrLf & mstrOffset & "-------" & vbCrLf
    strSeparator2 = vbCrLf ' & mstrOffset & "------------" & vbCrLf
    
    
    '读取报告的内容
    strSQL = "Select a.内容文本 As 标题, b.对象属性, b.内容文本 As 正文,b.开始版 as 版本 From 电子病历内容 a,电子病历内容 b " & _
             " Where a.文件id = [1] And a.对象类型 = 3 And a.Id = b.父ID And b.对象类型 = 2 and a.内容文本 =[2] order by b.开始版  "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngReportID, strType)
    
    If rsTemp.EOF = False Then
        lngStart = Len(rtxtReport.Text)
        Select Case strType
            Case "检查所见"
                strText = strSeparator2 & mstrOffset & pReport_CheckViewName & strSeparator2
            Case "诊断意见"
                strText = vbCrLf & strSeparator2 & mstrOffset & pReport_ResultName & strSeparator2
            Case "建议"
                strText = vbCrLf & strSeparator2 & mstrOffset & pReport_AdviceName & strSeparator2
        End Select
        
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = 0
        rtxtReport.SelText = strText
        
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = Len(strText)
        rtxtReport.SelFontName = "宋体"
        rtxtReport.SelFontSize = 14
        rtxtReport.SelColor = vbBlue
        rtxtReport.SelBold = True
    End If
    
    While Not rsTemp.EOF
        lngStart = Len(rtxtReport.Text)
        strText = strSeparator1 & mstrOffset & "第 " & nvl(rsTemp!版本) & " 版：" & strSeparator1 & mstrOffset & nvl(rsTemp!正文) & vbCrLf
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = 0
        rtxtReport.SelText = strText
        
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = Len(strText)
        rtxtReport.SelFontName = "宋体"
        rtxtReport.SelFontSize = 14
        rtxtReport.SelColor = vbBlack
        rtxtReport.SelBold = False
        
        rsTemp.MoveNext
    Wend
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Sub ShowModeClear(lngReportID As Long, lngAdviceID As Long)
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim lngStart As Long
    Dim strText As String
    Dim strTitle As String
    Dim strSeparator2 As String
    Dim blnShow As Boolean
    
    strSeparator2 = vbCrLf 'vbCrLf & mstrOffset & "------------" & vbCrLf
    rtxtReport.Text = ""
    
    Call ShowTitle(lngReportID, lngAdviceID)
    
    '读取报告的内容
    strSQL = "Select a.内容文本 As 标题, b.对象属性, b.内容文本 As 正文,b.开始版 as 版本 From 电子病历内容 a,电子病历内容 b " & _
             " Where a.文件id = [1] And a.对象类型 = 3 And a.Id = b.父ID And b.对象类型 = 2 and b.终止版=0  "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngReportID)
    
    While Not rsTemp.EOF
        blnShow = False
        Select Case rsTemp!标题
            Case "检查所见"
                strTitle = strSeparator2 & mstrOffset & pReport_CheckViewName & strSeparator2
                strText = vbCrLf & mstrOffset & nvl(rsTemp!正文) & vbCrLf
                blnShow = True
            Case "诊断意见"
                strTitle = strSeparator2 & mstrOffset & pReport_ResultName & strSeparator2
                strText = vbCrLf & mstrOffset & nvl(rsTemp!正文) & vbCrLf
                blnShow = True
            Case "建议"
                strTitle = strSeparator2 & mstrOffset & pReport_AdviceName & strSeparator2
                strText = vbCrLf & mstrOffset & nvl(rsTemp!正文) & vbCrLf
                blnShow = True
        End Select
        
        If blnShow = True Then
            lngStart = Len(rtxtReport.Text)
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = 0
            rtxtReport.SelText = strTitle
            
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = Len(strTitle)
            rtxtReport.SelFontName = "宋体"
            rtxtReport.SelFontSize = 14
            rtxtReport.SelColor = vbBlue
            rtxtReport.SelBold = True
            
            lngStart = Len(rtxtReport.Text)
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = 0
            rtxtReport.SelText = strText
            
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = Len(strText)
            rtxtReport.SelFontName = "宋体"
            rtxtReport.SelFontSize = 14
            rtxtReport.SelColor = vbBlack
            rtxtReport.SelBold = False
        End If
        
        rsTemp.MoveNext
    Wend
    
    rtxtReport.SelStart = 0
    rtxtReport.SelLength = 0
    
    If Not blnShow Then
    'blnShow=true 说明存在表格，不填充电子病历内容
        Call FillERPWord
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub FillERPWord()
'填充电子病历格式的内容
On Error GoTo errH
    Dim strZipFile As String
    Dim strReportFormatFile As String
    Dim strTemp As String
    Dim strtxtRtf As String
    Dim strrtxt As String
    Dim strrtxtAppend As String
    
    strtxtRtf = rtxtReport.TextRTF
    strrtxt = rtxtReport.Text

    strReportFormatFile = ""

    strZipFile = zlBlobRead(5, mlngReportID, strReportFormatFile)
    strTemp = zlFileUnzip(strZipFile)
    rtxtReport.Filename = strTemp

    Call DoEPRReportFormat(rtxtReport)
    strrtxt = rtxtReport.Text

    rtxtReport.TextRTF = strtxtRtf
    strrtxtAppend = rtxtReport.Text

    rtxtReport.Text = strrtxtAppend & vbCrLf & "  " & strrtxt

    Kill strZipFile
    
    Exit Sub
errH:
    Kill strZipFile
    Call err.Raise(0, , "FillERPWord异常-" & err.Description)
    Resume
End Sub

Private Sub DoEPRReportFormat(ByRef rtfEPR As RichTextBox)
    '处理电子病历格式
On Error GoTo errH
    Dim i As Long
    Dim lngStart As Long
    Dim lngEnd As Long
    Dim blnContinu As Boolean
    Dim strNew As String
    Dim strOld As String
    Dim lngStartNext As Long ' 一组需要去掉的字符的开始位置
    Dim lngFlagPos As Long '"00000"的位置
    
    strOld = rtfEPR.TextRTF
    strNew = strOld
    blnContinu = True
    
    lngFlagPos = InStr(1, strNew, "(00000")
    If lngFlagPos > 4 Then
        lngStartNext = lngFlagPos - 4
    Else
        blnContinu = False
    End If
    
    While blnContinu
        '去掉形如 ES(00000007,0,0)的部分 关键点  XX前面必定有一个空格
        lngStart = InStr(lngStartNext, strNew, " ")
        
        If lngStart > 0 Then
            lngStartNext = lngStart
        Else
            lngStartNext = Len(strNew) - 1
            blnContinu = False
        End If
        lngEnd = InStr(lngStart, strNew, ")")
        
        '去掉从空格后面一个到 ) 的内容
        If lngStart > 0 And lngEnd > 0 And lngEnd - lngStart > 0 And lngEnd - lngStart < 20 Then
            strNew = Mid(strNew, 1, lngStart) & Mid(strNew, lngEnd + 1)
        Else
            lngFlagPos = InStr(lngFlagPos + 10, strNew, "(00000")
            If lngFlagPos < 4 Then
                blnContinu = False
            Else
                lngStartNext = lngFlagPos - 4
            End If
        End If
    Wend

    strNew = Replace(strNew, "\par ", "\par   ")
    rtfEPR.Text = ""
    rtfEPR.TextRTF = strNew
    Exit Sub
errH:
    rtfEPR.TextRTF = strOld
    If App.LogMode = 0 Then MsgBox "DoEPRReportFormat调试错误" & err.Description
End Sub

Private Sub InitFaceScheme()
On Error GoTo errH
    '初始界面布局
    Dim Pane1 As Pane, Pane2 As Pane, Pane3 As Pane
    
    Dim ingWReport As Integer
    Dim ingWImg As Integer
    Dim intHImg As Integer
    Dim ingHReport As Integer
 
    With dkpMain
        .Options.HideClient = False
        .Options.UseSplitterTracker = False '实时拖动
        .Options.ThemedFloatingFrames = True
        .Options.AlphaDockingContext = True
        .TabPaintManager.Position = xtpTabPositionTop
    End With
    
    ingHReport = (Me.ScaleHeight / Screen.TwipsPerPixelY)
    intHImg = (Me.ScaleHeight / Screen.TwipsPerPixelY * 0.5)
    If Not mblnHaveReport And Not mblnHaveMark Then
        ingWReport = Me.ScaleWidth / Screen.TwipsPerPixelX
        ingWImg = 0
    Else
        ingWReport = (Me.ScaleWidth / Screen.TwipsPerPixelX) * 0.7
        ingWImg = (Me.ScaleWidth / Screen.TwipsPerPixelX) * 0.3
    End If
    
    Set Pane1 = dkpMain.CreatePane(1, ingWReport, intHImg, DockTopOf)
    Pane1.Title = "报告图"
    Pane1.Handle = picReportImage.hWnd
    Pane1.Options = PaneNoCloseable Or PaneNoHideable Or PaneNoFloatable

    Set Pane2 = dkpMain.CreatePane(2, ingWReport, intHImg, DockTopOf, Pane1)
    Pane2.Title = "标记图"
    Pane2.Handle = picMark.hWnd
    Pane2.Options = PaneNoCloseable Or PaneNoHideable Or PaneNoFloatable

    Set Pane3 = dkpMain.CreatePane(3, ingWReport, ingHReport, DockRightOf)
    Pane3.Title = "报告内容"
    Pane3.Handle = pictxt.hWnd
    Pane3.Options = PaneNoCloseable Or PaneNoHideable Or PaneNoFloatable
    

    If Not mblnHaveReport And Not mblnHaveMark Then
        Pane1.Close
        Pane2.Close
    ElseIf Not mblnHaveReport And mblnHaveMark Then
        Pane1.Close
    ElseIf mblnHaveReport And Not mblnHaveMark Then
        Pane2.Close
    Else
    End If

    Exit Sub
errH:
    Call err.Raise(0, , "历次报告初始界面布局异常-" & err.Description)
    Resume
End Sub


Private Sub LoadImg()
'加载报告图和标记图
On Error GoTo errH
    Dim CTables() As cEPRTable
    Dim cTable As cEPRTable
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim lngUbound As Long
    Dim blnGetTable As Boolean
    Dim iRImageCount As Integer
    Dim strPicFile As String
    Dim objFile As New Scripting.FileSystemObject
    Dim i As Integer, j As Integer
    Dim oPicture As StdPicture
    Dim dcmImg As DicomImage
    
    If mlngReportID = 0 Then Exit Sub
    ReDim Preserve CTables(0)

    ''''''''''''''step 1 获取表格
    strSQL = "Select Id As 表格Id From 电子病历内容" & vbNewLine & _
                " Where 文件id = [1] And 对象类型 = 3 And Substr(对象属性, Instr(对象属性, ';', 1, 18) + 1, 1) = '2'" & vbNewLine & _
                " Order By 对象序号"
    If mblnMoved = True Then
        strSQL = Replace(strSQL, "电子病历内容", "H电子病历内容")
    End If

    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "报告内容中读取", mlngReportID)
    
    Do While Not rsTemp.EOF
        Set cTable = New cEPRTable
    
        blnGetTable = cTable.GetTableFromDB(cprET_单病历审核, mlngReportID, Val("" & rsTemp!表格ID))

        If blnGetTable Then
            lngUbound = UBound(CTables) + 1
            ReDim Preserve CTables(lngUbound)

            Set CTables(lngUbound) = cTable
        End If
        
        Call rsTemp.MoveNext
    Loop
    '''''''''''''''''''step 2 加载图片
    
    '初始化各个对象
    Call ClearReportImages
     
    iRImageCount = 0
    For i = 1 To UBound(CTables)
    
        Set cTable = CTables(i)
        
        '创建viewer
        iRImageCount = iRImageCount + 1
        Load dcmReportImage(iRImageCount)
        
        dcmReportImage(iRImageCount).BorderStyle = 1
        dcmReportImage(iRImageCount).Labels.AddNew
        dcmReportImage(iRImageCount).Labels(dcmReportImage(iRImageCount).Labels.Count).LabelType = doLabelRectangle
        dcmReportImage(iRImageCount).Labels(dcmReportImage(iRImageCount).Labels.Count).Left = 1
        dcmReportImage(iRImageCount).Labels(dcmReportImage(iRImageCount).Labels.Count).Top = 1
        dcmReportImage(iRImageCount).Labels(dcmReportImage(iRImageCount).Labels.Count).LineWidth = 2
        dcmReportImage(iRImageCount).Labels(dcmReportImage(iRImageCount).Labels.Count).ForeColour = vbWhite
        
        dcmReportImage(iRImageCount).Visible = True

        '记录图像框的宽度和高度，该宽高比例用于后续对图像行列布局
        If cTable.ExtendTag <> "" Then
            If Val(Split(cTable.ExtendTag, "|")(0)) = 0 Then
                dcmReportImage(iRImageCount).tag = cTable.Width & "|" & cTable.Height
            Else
                dcmReportImage(iRImageCount).tag = (cTable.Width - Val(Split(cTable.ExtendTag, "|")(1)) - 30) & "|" & cTable.Height
            End If
        Else
            dcmReportImage(iRImageCount).tag = cTable.Width & "|" & cTable.Height
        End If
        
        For j = 1 To cTable.Pictures.Count
            strPicFile = App.Path & "\PACSPic" & j & ".JPG"
            If objFile.FileExists(strPicFile) Then objFile.DeleteFile strPicFile, True

            Set oPicture = cTable.Pictures(j).OrigPic
            SavePicture oPicture, strPicFile
            If objFile.FileExists(strPicFile) Then
                '显示标记图和报告图
                If cTable.Pictures(j).PictureType = EPRMarkedPicture And dcmMark.Images.Count = 0 Then

                    '只处理第一个标记图
                    dcmMark.Images.AddNew
                    
                    dcmMark.Images(1).FileImport strPicFile, "BMP"
                    dcmMark.Images(1).tag = cTable.Pictures(j).ID
                    mblnHaveMark = True
                Else
        
                    dcmReportImage(iRImageCount).Images.AddNew
                    Set dcmImg = dcmReportImage(iRImageCount).Images(dcmReportImage(iRImageCount).Images.Count)
                    dcmImg.FileImport strPicFile, "BMP"
                          
                    If cTable.Pictures(j).PicName = "" Then
                        dcmImg.tag = mdcmGlobal.NewUID & ".jpg"
                    Else
                        dcmImg.tag = cTable.Pictures(j).PicName
                    End If
                    
                    '设置InstanceUID
                    dcmImg.BorderWidth = 3
                    dcmImg.BorderColour = vbWhite
                    dcmReportImage(iRImageCount).CurrentIndex = 1
'                    mselReportImgIndex = 1
                    
                    mblnHaveReport = True
                End If
                '删除临时图像
                Kill strPicFile
            End If
        Next j
    Next i
    
    Call picReportImage_Resize
    Exit Sub
errH:
    Call err.Raise(0, , "历次报告读取图像异常-" & err.Description)
    Resume
End Sub

Private Sub ClearReportImages()
    Dim i As Integer

    '初始化各个对象
    For i = 1 To dcmReportImage.Count - 1
        Unload dcmReportImage(i)
    Next i
    dcmMark.Images.Clear
End Sub

Private Sub picMain_Resize()
    Call picMark_Resize
    Call picReportImage_Resize
    Call pictxt_Resize
End Sub

Private Sub picMark_Resize()
On Error Resume Next
    
    Call dcmMark.Move(0, 0, picMark.ScaleWidth, picMark.ScaleHeight - 50)
End Sub

Private Sub picReportImage_Resize()
    Dim i As Integer
    Dim rectH As Long, rectW As Long    '图象框可以使用的区域宽高
    Dim picH As Long, picW As Long      '图像实际宽高，作为比例使用
    Dim iCols As Integer, iRows As Integer
    Dim dImg As DicomImage
    
    If dcmReportImage.Count = 1 Then Exit Sub
    
    On Error Resume Next
    
    '首先计算每个图象框可占用的最大宽高
    
    rectH = picReportImage.Height / (dcmReportImage.Count - 1)
    rectW = picReportImage.Width
    If rectH < 100 Or rectW < 100 Then Exit Sub
    
    For i = 1 To dcmReportImage.Count - 1
        '按照图像比例，计算图象框的真实宽度和高度
        picW = Val(Split(dcmReportImage(i).tag, "|")(0))
        picH = Val(Split(dcmReportImage(i).tag, "|")(1))
        
        dcmReportImage(i).Height = rectH - 100
        dcmReportImage(i).Width = rectW - 100
        
        dcmReportImage(i).Left = 0
        dcmReportImage(i).Top = rectH * (i - 1)
        
        dcmReportImage(i).Labels(1).Width = Abs(dcmReportImage(i).Width / Screen.TwipsPerPixelX - 2)
        dcmReportImage(i).Labels(1).Height = Abs(dcmReportImage(i).Height / Screen.TwipsPerPixelY - 1)

        '调整图像显示布局
        ResizeRegion dcmReportImage(i).Images.Count, picW, picH, iRows, iCols
  
        dcmReportImage(i).MultiColumns = iCols
        dcmReportImage(i).MultiRows = iRows
    Next i
End Sub

Private Sub pictxt_Resize()
    On Error Resume Next
    Call rtxtReport.Move(0, 0, pictxt.Width, pictxt.Height - 550)
End Sub
