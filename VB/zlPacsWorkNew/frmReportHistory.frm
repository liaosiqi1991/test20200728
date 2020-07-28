VERSION 5.00
Object = "{945E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.DockingPane.9600.ocx"
Object = "{555E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.CommandBars.9600.ocx"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "richtx32.ocx"
Object = "{853AAF94-E49C-11D0-A303-0040C711066C}#4.3#0"; "DicomObjects.ocx"
Begin VB.Form frmReportHistory 
   Caption         =   "�����޶���ʷ"
   ClientHeight    =   6270
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   9735
   Icon            =   "frmReportHistory.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6270
   ScaleWidth      =   9735
   StartUpPosition =   1  '����������
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

Private mlngAdviceID As Long        'ҽ��ID
Private mlngPatientId As Long       '����ID
Private mlngCur����ID As Long       '����ID
Private mlngReportID As Long        '����ID
Private mlngMode As Long            '����鿴״̬��0-�޶�״̬��1-����״̬
Private mintReportCount As Integer  '��ʷ���������
Private mlngViewReportID As Long    '��ǰ�鿴�ı���ID
Private mlngViewAdviceID As Long    '��ǰ�鿴��ҽ��ID
Private mstrOffset As String        '��ǰ����ߵ�����
Private mblnMoved As Boolean        '�Ƿ�ת��
Private mdcmGlobal As New DicomGlobal    '����UIDRoot=1
Private mblnHaveReport As Boolean '���ڱ���ͼ
Private mblnHaveMark As Boolean '���ڱ��ͼ

Private mobjReport As zlRichEPR.cDockReport    '�������



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
'    'InitFaceScheme����LoadImg֮��
    Call InitFaceScheme
    
    Me.Show 0, frmParent
End Sub

Private Sub cbrMain_Execute(ByVal Control As XtremeCommandBars.ICommandBarControl)
    Select Case Control.ID
        Case conMenu_PacsReport_Mode_Orig                   'ԭʼ״̬
            If mlngMode <> 0 Then
                ShowModeOrig mlngViewReportID, mlngViewAdviceID
            End If
            mlngMode = 0
            Me.cbrMain.FindControl(, conMenu_PacsReport_Mode_Clear, , True).Checked = False
            Control.Checked = True
        Case conMenu_PacsReport_Mode_Clear                  '����״̬
            If mlngMode <> 1 Then
                ShowModeClear mlngViewReportID, mlngViewAdviceID
            End If
            mlngMode = 1
            Me.cbrMain.FindControl(, conMenu_PacsReport_Mode_Orig, , True).Checked = False
            Control.Checked = True
        Case conMenu_File_Preview                           '����Ԥ��
            If mlngViewReportID = 0 Then Exit Sub
            mobjReport.zlRefresh 0, 0
            mobjReport.zlRefresh mlngViewAdviceID, UserInfo.����ID
            mobjReport.zlExecuteCommandBars Control
        Case conMenu_File_Exit                              '   �˳�
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
    Dim lng����ID As Long
    Dim lng��ҳID As Long
    Dim intӤ�� As Integer
    Dim rsBaby As ADODB.Recordset
    
    If lngReportID = 0 Then Exit Sub
    
    strSeparator1 = mstrOffset & "==================================================" & vbCrLf
    strSeparator2 = mstrOffset & "-------------------" & vbCrLf
    
    strSQL = "Select a.����,a.����,b.����ʱ��,b.ҽ������,a.������,a.������,nvl(b.Ӥ��,0) as Ӥ��,a.�������� as ���ʱ��, " _
            & "b.����ID, nvl(b.��ҳID,0) as ��ҳID From Ӱ�����¼ a,����ҽ����¼ b Where a.ҽ��id = b.Id And b.Id = [1] "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngAdviceID)
    If rsTemp.EOF = True Then Exit Sub
    
    strTitle = mstrOffset & nvl(rsTemp!ҽ������) & vbCrLf
    
    lngStart = Len(rtxtReport.Text)
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = 0
    rtxtReport.SelText = strTitle
    
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = Len(strTitle)
    rtxtReport.SelFontName = "����"
    rtxtReport.SelFontSize = 16
    rtxtReport.SelBold = True
    rtxtReport.SelColor = vbBlue
    
    'Ӥ����������Ҫ������ʾ
    If rsTemp!Ӥ�� = 0 Then
        strWriter = vbCrLf & mstrOffset & "������" & nvl(rsTemp!����) & "      ���ţ�" & nvl(rsTemp!����) & vbCrLf _
               & mstrOffset & "�����ˣ�" & nvl(rsTemp!������) & "      ����ˣ�" & nvl(rsTemp!������) & vbCrLf _
               & mstrOffset & "����ʱ�䣺 " & nvl(rsTemp!����ʱ��) & "      ���ʱ�䣺" & nvl(rsTemp!���ʱ��) & vbCrLf
    Else
        lng����ID = rsTemp!����ID
        lng��ҳID = rsTemp!��ҳID
        intӤ�� = rsTemp!Ӥ��
        strSQL = "Select Decode(a.Ӥ������,Null,b.����||'֮��'||Trim(To_Char(a.���,'9')),a.Ӥ������) As Ӥ������,Ӥ���Ա�,����ʱ�� From ������������¼ a,������Ϣ b Where a.����id=[1] And a.��ҳid=[2] And a.����id=b.����id And a.���=[3]"
        Set rsBaby = zlDatabase.OpenSQLRecord(strSQL, "����Ӥ����Ϣ", lng����ID, lng��ҳID, intӤ��)
        
        strWriter = vbCrLf & mstrOffset & "������" & rsBaby!Ӥ������ & "      ���ţ�" & nvl(rsTemp!����) & vbCrLf _
               & mstrOffset & "�����ˣ�" & nvl(rsTemp!������) & "      ����ˣ�" & nvl(rsTemp!������) & vbCrLf _
               & mstrOffset & "����ʱ�䣺 " & nvl(rsTemp!����ʱ��) & "      ���ʱ�䣺" & nvl(rsTemp!���ʱ��) & vbCrLf
    
    End If
    '��ʾ������
    strWriter = strWriter
    
    lngStart = Len(rtxtReport.Text)
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = 0
    rtxtReport.SelText = strWriter
    
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = Len(strWriter)
    rtxtReport.SelFontName = "����"
    rtxtReport.SelFontSize = 14
    rtxtReport.SelBold = False
    rtxtReport.SelColor = vbBlue
    
    '��ʾ����
    lngStart = Len(rtxtReport.Text)
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = 0
    rtxtReport.SelText = strSeparator1
    
    rtxtReport.SelStart = lngStart
    rtxtReport.SelLength = Len(strSeparator1)
    rtxtReport.SelFontName = "����"
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
    Set mobjReport = New zlRichEPR.cDockReport      '���Ӳ�������
    
    Call RestoreWinState(Me, App.ProductName)
    
    Call InitCommandBars '��ʼ���˵�
    
    If mlngReportID = 0 Then    '��ǰ����û�б��棬ֱ����ʾ�����һ����ʷ����
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
    
    Unload mobjReport.zlGetForm        '���Ӳ�������
    '���洰��λ��
    Call SaveWinState(Me, App.ProductName)
    
    For i = 1 To dkpMain.PanesCount
        dkpMain.Panes(i).Handle = 0
    Next i
    dkpMain.CloseAll
    
    Set mdcmGlobal = Nothing
    Set mobjReport = Nothing
End Sub


Private Sub InitCommandBars()
    '���ܴ���������
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
        .IconsWithShadow = True '����VisualTheme����Ч
        .UseDisabledIcons = True
        .LargeIcons = True
        .SetIconSize True, 24, 24
    End With
    Me.cbrMain.EnableCustomization False
    Me.cbrMain.ActiveMenuBar.Visible = False
'    Me.cbrMain.ActiveMenuBar.EnableDocking 1 + xtpFlagStretched

'    Me.cbrMain.ActiveMenuBar.EnableDocking xtpFlagStretched + xtpFlagHideWrap
    
    '�ɼ�����������
    Set cbrToolBar = Me.cbrMain.Add("������ʷ", xtpBarLeft)
'    cbrToolBar.EnableDocking xtpFlagStretched
    cbrToolBar.ShowTextBelowIcons = False
    cbrToolBar.Closeable = False
    
    With cbrToolBar.Controls
        Set cbrControl = .Add(xtpControlButton, conMenu_PacsReport_Mode_Orig, "ԭʼ״̬")
        Set cbrControl = .Add(xtpControlButton, conMenu_PacsReport_Mode_Clear, "����״̬")
        cbrControl.Checked = True
        Set cbrControl = .Add(xtpControlButton, conMenu_File_Preview, "����Ԥ��")
        cbrControl.IconId = 102
        cbrControl.Style = xtpButtonIconAndCaption
        cbrControl.BeginGroup = True
        
        '������ʷ����Ĳ˵���ֻ������ʷ�����ʱ�򣬲���������˵�
        strSQL = "Select ����ID,ִ�п���ID From ����ҽ����¼  Where Id = [1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "", mlngAdviceID)
        If rsTemp.EOF = False Then
            mlngPatientId = nvl(rsTemp!����ID, 0)
            mlngCur����ID = nvl(rsTemp!ִ�п���ID, 0)
            
            strSQL = "Select c.Id As ҽ��id,c.����ʱ�� As ����ʱ��,c.ҽ������,b.����Id  From Ӱ�����¼ a,����ҽ������ b,����ҽ����¼ c" _
                    & " Where a.ҽ��id = c.Id And b.ҽ��ID= c.Id And c.����ID=[1] And c.���ID Is Null And c.ִ�п���ID  in " _
                    & " (Select ����ID From ������Ա Where ��ԱID =[2]) Order By ����ʱ�� Asc"
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "", mlngPatientId, UserInfo.ID)
            
            If rsTemp.RecordCount > 1 Or (mlngReportID = 0 And rsTemp.RecordCount = 1) Then
                Set cbrControl = .Add(xtpControlPopup, conMenu_PacsReport_History_Times, "������ʷ"): cbrControl.ID = conMenu_PacsReport_History_Times
                
                Do Until rsTemp.EOF
                   Set cbrPopControl = cbrControl.CommandBar.Controls.Add(xtpControlButton, conMenu_PacsReport_History_Times + rsTemp.AbsolutePosition, "��" & rsTemp.AbsolutePosition & "��(" & Format(rsTemp!����ʱ��, "yyyy-mm-dd") & ") " & rsTemp!ҽ������)
                   cbrPopControl.DescriptionText = rsTemp!ҽ��ID & "-" & rsTemp!����Id
                   rsTemp.MoveNext
                Loop
'                '�����ǰ���ڱ༭�ı��滹û�д����������ӵ�ǰ����Ĳ˵�
'                If mlngReportID = 0 Then
'                    Set cbrPopControl = cbrControl.CommandBar.Controls.Add(xtpControlButton, conMenu_PacsReport_History_Times + rsTemp.RecordCount + 1, "��ǰ����")
'                   cbrPopControl.DescriptionText = mlngAdviceID & "-0"
'                End If
                mintReportCount = rsTemp.RecordCount
            End If
        End If
        
        Set cbrControl = .Add(xtpControlButton, conMenu_File_Exit, "�˳�")
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
    Call ShowReportText(lngReportID, "�������")
    Call ShowReportText(lngReportID, "������")
    Call ShowReportText(lngReportID, "����")
    
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
    
    
    '��ȡ���������
    strSQL = "Select a.�����ı� As ����, b.��������, b.�����ı� As ����,b.��ʼ�� as �汾 From ���Ӳ������� a,���Ӳ������� b " & _
             " Where a.�ļ�id = [1] And a.�������� = 3 And a.Id = b.��ID And b.�������� = 2 and a.�����ı� =[2] order by b.��ʼ��  "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngReportID, strType)
    
    If rsTemp.EOF = False Then
        lngStart = Len(rtxtReport.Text)
        Select Case strType
            Case "�������"
                strText = strSeparator2 & mstrOffset & pReport_CheckViewName & strSeparator2
            Case "������"
                strText = vbCrLf & strSeparator2 & mstrOffset & pReport_ResultName & strSeparator2
            Case "����"
                strText = vbCrLf & strSeparator2 & mstrOffset & pReport_AdviceName & strSeparator2
        End Select
        
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = 0
        rtxtReport.SelText = strText
        
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = Len(strText)
        rtxtReport.SelFontName = "����"
        rtxtReport.SelFontSize = 14
        rtxtReport.SelColor = vbBlue
        rtxtReport.SelBold = True
    End If
    
    While Not rsTemp.EOF
        lngStart = Len(rtxtReport.Text)
        strText = strSeparator1 & mstrOffset & "�� " & nvl(rsTemp!�汾) & " �棺" & strSeparator1 & mstrOffset & nvl(rsTemp!����) & vbCrLf
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = 0
        rtxtReport.SelText = strText
        
        rtxtReport.SelStart = lngStart
        rtxtReport.SelLength = Len(strText)
        rtxtReport.SelFontName = "����"
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
    
    '��ȡ���������
    strSQL = "Select a.�����ı� As ����, b.��������, b.�����ı� As ����,b.��ʼ�� as �汾 From ���Ӳ������� a,���Ӳ������� b " & _
             " Where a.�ļ�id = [1] And a.�������� = 3 And a.Id = b.��ID And b.�������� = 2 and b.��ֹ��=0  "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngReportID)
    
    While Not rsTemp.EOF
        blnShow = False
        Select Case rsTemp!����
            Case "�������"
                strTitle = strSeparator2 & mstrOffset & pReport_CheckViewName & strSeparator2
                strText = vbCrLf & mstrOffset & nvl(rsTemp!����) & vbCrLf
                blnShow = True
            Case "������"
                strTitle = strSeparator2 & mstrOffset & pReport_ResultName & strSeparator2
                strText = vbCrLf & mstrOffset & nvl(rsTemp!����) & vbCrLf
                blnShow = True
            Case "����"
                strTitle = strSeparator2 & mstrOffset & pReport_AdviceName & strSeparator2
                strText = vbCrLf & mstrOffset & nvl(rsTemp!����) & vbCrLf
                blnShow = True
        End Select
        
        If blnShow = True Then
            lngStart = Len(rtxtReport.Text)
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = 0
            rtxtReport.SelText = strTitle
            
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = Len(strTitle)
            rtxtReport.SelFontName = "����"
            rtxtReport.SelFontSize = 14
            rtxtReport.SelColor = vbBlue
            rtxtReport.SelBold = True
            
            lngStart = Len(rtxtReport.Text)
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = 0
            rtxtReport.SelText = strText
            
            rtxtReport.SelStart = lngStart
            rtxtReport.SelLength = Len(strText)
            rtxtReport.SelFontName = "����"
            rtxtReport.SelFontSize = 14
            rtxtReport.SelColor = vbBlack
            rtxtReport.SelBold = False
        End If
        
        rsTemp.MoveNext
    Wend
    
    rtxtReport.SelStart = 0
    rtxtReport.SelLength = 0
    
    If Not blnShow Then
    'blnShow=true ˵�����ڱ�񣬲������Ӳ�������
        Call FillERPWord
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub FillERPWord()
'�����Ӳ�����ʽ������
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
    Call err.Raise(0, , "FillERPWord�쳣-" & err.Description)
    Resume
End Sub

Private Sub DoEPRReportFormat(ByRef rtfEPR As RichTextBox)
    '������Ӳ�����ʽ
On Error GoTo errH
    Dim i As Long
    Dim lngStart As Long
    Dim lngEnd As Long
    Dim blnContinu As Boolean
    Dim strNew As String
    Dim strOld As String
    Dim lngStartNext As Long ' һ����Ҫȥ�����ַ��Ŀ�ʼλ��
    Dim lngFlagPos As Long '"00000"��λ��
    
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
        'ȥ������ ES(00000007,0,0)�Ĳ��� �ؼ���  XXǰ��ض���һ���ո�
        lngStart = InStr(lngStartNext, strNew, " ")
        
        If lngStart > 0 Then
            lngStartNext = lngStart
        Else
            lngStartNext = Len(strNew) - 1
            blnContinu = False
        End If
        lngEnd = InStr(lngStart, strNew, ")")
        
        'ȥ���ӿո����һ���� ) ������
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
    If App.LogMode = 0 Then MsgBox "DoEPRReportFormat���Դ���" & err.Description
End Sub

Private Sub InitFaceScheme()
On Error GoTo errH
    '��ʼ���沼��
    Dim Pane1 As Pane, Pane2 As Pane, Pane3 As Pane
    
    Dim ingWReport As Integer
    Dim ingWImg As Integer
    Dim intHImg As Integer
    Dim ingHReport As Integer
 
    With dkpMain
        .Options.HideClient = False
        .Options.UseSplitterTracker = False 'ʵʱ�϶�
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
    Pane1.Title = "����ͼ"
    Pane1.Handle = picReportImage.hWnd
    Pane1.Options = PaneNoCloseable Or PaneNoHideable Or PaneNoFloatable

    Set Pane2 = dkpMain.CreatePane(2, ingWReport, intHImg, DockTopOf, Pane1)
    Pane2.Title = "���ͼ"
    Pane2.Handle = picMark.hWnd
    Pane2.Options = PaneNoCloseable Or PaneNoHideable Or PaneNoFloatable

    Set Pane3 = dkpMain.CreatePane(3, ingWReport, ingHReport, DockRightOf)
    Pane3.Title = "��������"
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
    Call err.Raise(0, , "���α����ʼ���沼���쳣-" & err.Description)
    Resume
End Sub


Private Sub LoadImg()
'���ر���ͼ�ͱ��ͼ
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

    ''''''''''''''step 1 ��ȡ���
    strSQL = "Select Id As ���Id From ���Ӳ�������" & vbNewLine & _
                " Where �ļ�id = [1] And �������� = 3 And Substr(��������, Instr(��������, ';', 1, 18) + 1, 1) = '2'" & vbNewLine & _
                " Order By �������"
    If mblnMoved = True Then
        strSQL = Replace(strSQL, "���Ӳ�������", "H���Ӳ�������")
    End If

    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "���������ж�ȡ", mlngReportID)
    
    Do While Not rsTemp.EOF
        Set cTable = New cEPRTable
    
        blnGetTable = cTable.GetTableFromDB(cprET_���������, mlngReportID, Val("" & rsTemp!���ID))

        If blnGetTable Then
            lngUbound = UBound(CTables) + 1
            ReDim Preserve CTables(lngUbound)

            Set CTables(lngUbound) = cTable
        End If
        
        Call rsTemp.MoveNext
    Loop
    '''''''''''''''''''step 2 ����ͼƬ
    
    '��ʼ����������
    Call ClearReportImages
     
    iRImageCount = 0
    For i = 1 To UBound(CTables)
    
        Set cTable = CTables(i)
        
        '����viewer
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

        '��¼ͼ���Ŀ�Ⱥ͸߶ȣ��ÿ�߱������ں�����ͼ�����в���
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
                '��ʾ���ͼ�ͱ���ͼ
                If cTable.Pictures(j).PictureType = EPRMarkedPicture And dcmMark.Images.Count = 0 Then

                    'ֻ�����һ�����ͼ
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
                    
                    '����InstanceUID
                    dcmImg.BorderWidth = 3
                    dcmImg.BorderColour = vbWhite
                    dcmReportImage(iRImageCount).CurrentIndex = 1
'                    mselReportImgIndex = 1
                    
                    mblnHaveReport = True
                End If
                'ɾ����ʱͼ��
                Kill strPicFile
            End If
        Next j
    Next i
    
    Call picReportImage_Resize
    Exit Sub
errH:
    Call err.Raise(0, , "���α����ȡͼ���쳣-" & err.Description)
    Resume
End Sub

Private Sub ClearReportImages()
    Dim i As Integer

    '��ʼ����������
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
    Dim rectH As Long, rectW As Long    'ͼ������ʹ�õ�������
    Dim picH As Long, picW As Long      'ͼ��ʵ�ʿ�ߣ���Ϊ����ʹ��
    Dim iCols As Integer, iRows As Integer
    Dim dImg As DicomImage
    
    If dcmReportImage.Count = 1 Then Exit Sub
    
    On Error Resume Next
    
    '���ȼ���ÿ��ͼ����ռ�õ������
    
    rectH = picReportImage.Height / (dcmReportImage.Count - 1)
    rectW = picReportImage.Width
    If rectH < 100 Or rectW < 100 Then Exit Sub
    
    For i = 1 To dcmReportImage.Count - 1
        '����ͼ�����������ͼ������ʵ��Ⱥ͸߶�
        picW = Val(Split(dcmReportImage(i).tag, "|")(0))
        picH = Val(Split(dcmReportImage(i).tag, "|")(1))
        
        dcmReportImage(i).Height = rectH - 100
        dcmReportImage(i).Width = rectW - 100
        
        dcmReportImage(i).Left = 0
        dcmReportImage(i).Top = rectH * (i - 1)
        
        dcmReportImage(i).Labels(1).Width = Abs(dcmReportImage(i).Width / Screen.TwipsPerPixelX - 2)
        dcmReportImage(i).Labels(1).Height = Abs(dcmReportImage(i).Height / Screen.TwipsPerPixelY - 1)

        '����ͼ����ʾ����
        ResizeRegion dcmReportImage(i).Images.Count, picW, picH, iRows, iCols
  
        dcmReportImage(i).MultiColumns = iCols
        dcmReportImage(i).MultiRows = iRows
    Next i
End Sub

Private Sub pictxt_Resize()
    On Error Resume Next
    Call rtxtReport.Move(0, 0, pictxt.Width, pictxt.Height - 550)
End Sub
