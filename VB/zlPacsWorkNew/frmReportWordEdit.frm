VERSION 5.00
Object = "{945E8FCC-830E-45CC-AF00-A012D5AE7451}#9.60#0"; "Codejock.DockingPane.9600.ocx"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form frmReportWordEdit 
   Caption         =   "����ʾ�༭"
   ClientHeight    =   6660
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   9720
   Icon            =   "frmReportWordEdit.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   ScaleHeight     =   6660
   ScaleWidth      =   9720
   StartUpPosition =   3  '����ȱʡ
   Begin VB.PictureBox picClientArea 
      Height          =   5415
      Left            =   120
      ScaleHeight     =   5355
      ScaleWidth      =   9315
      TabIndex        =   2
      Top             =   0
      Width           =   9375
      Begin VB.PictureBox picAdvice 
         AutoSize        =   -1  'True
         BorderStyle     =   0  'None
         Height          =   1575
         Left            =   120
         ScaleHeight     =   1575
         ScaleWidth      =   5655
         TabIndex        =   13
         Top             =   3600
         Width           =   5655
         Begin VB.VScrollBar vscroWordH3 
            Height          =   1215
            Left            =   5280
            Max             =   500
            TabIndex        =   17
            Top             =   240
            Value           =   200
            Width           =   250
         End
         Begin VB.PictureBox picContainer3 
            BorderStyle     =   0  'None
            Height          =   1095
            Left            =   120
            ScaleHeight     =   1095
            ScaleWidth      =   5295
            TabIndex        =   14
            Top             =   240
            Width           =   5295
            Begin VB.CheckBox chkSelect3 
               DownPicture     =   "frmReportWordEdit.frx":0CCA
               Height          =   400
               Index           =   0
               Left            =   480
               Picture         =   "frmReportWordEdit.frx":1C3C
               Style           =   1  'Graphical
               TabIndex        =   15
               Top             =   120
               Visible         =   0   'False
               Width           =   400
            End
            Begin RichTextLib.RichTextBox rtxtWord3 
               Height          =   495
               Index           =   0
               Left            =   960
               TabIndex        =   16
               TabStop         =   0   'False
               Top             =   120
               Visible         =   0   'False
               Width           =   3615
               _ExtentX        =   6376
               _ExtentY        =   873
               _Version        =   393217
               ScrollBars      =   2
               Appearance      =   0
               AutoVerbMenu    =   -1  'True
               TextRTF         =   $"frmReportWordEdit.frx":2BAE
            End
         End
      End
      Begin VB.PictureBox picResult 
         AutoSize        =   -1  'True
         BorderStyle     =   0  'None
         Height          =   1695
         Left            =   120
         ScaleHeight     =   1695
         ScaleWidth      =   5655
         TabIndex        =   8
         Top             =   1800
         Width           =   5655
         Begin VB.VScrollBar vscroWordH2 
            Height          =   1215
            Left            =   5280
            Max             =   500
            TabIndex        =   9
            Top             =   240
            Value           =   200
            Width           =   250
         End
         Begin VB.PictureBox picContainer2 
            BorderStyle     =   0  'None
            Height          =   975
            Left            =   120
            ScaleHeight     =   975
            ScaleWidth      =   5295
            TabIndex        =   10
            Top             =   240
            Width           =   5295
            Begin VB.CheckBox chkSelect2 
               DownPicture     =   "frmReportWordEdit.frx":2C4B
               Height          =   400
               Index           =   0
               Left            =   480
               Picture         =   "frmReportWordEdit.frx":3BBD
               Style           =   1  'Graphical
               TabIndex        =   11
               Top             =   120
               Visible         =   0   'False
               Width           =   400
            End
            Begin RichTextLib.RichTextBox rtxtWord2 
               Height          =   375
               Index           =   0
               Left            =   960
               TabIndex        =   12
               TabStop         =   0   'False
               Top             =   120
               Visible         =   0   'False
               Width           =   3615
               _ExtentX        =   6376
               _ExtentY        =   661
               _Version        =   393217
               ScrollBars      =   2
               Appearance      =   0
               AutoVerbMenu    =   -1  'True
               TextRTF         =   $"frmReportWordEdit.frx":4B2F
            End
         End
      End
      Begin VB.PictureBox picCheckView 
         AutoSize        =   -1  'True
         BorderStyle     =   0  'None
         Height          =   1575
         Left            =   120
         ScaleHeight     =   1575
         ScaleWidth      =   5655
         TabIndex        =   3
         Top             =   120
         Width           =   5655
         Begin VB.VScrollBar vscroWordH1 
            Height          =   1215
            Left            =   5280
            Max             =   500
            TabIndex        =   7
            Top             =   240
            Value           =   200
            Width           =   250
         End
         Begin VB.PictureBox picContainer1 
            BorderStyle     =   0  'None
            Height          =   975
            Left            =   120
            ScaleHeight     =   975
            ScaleWidth      =   5295
            TabIndex        =   4
            Top             =   240
            Width           =   5295
            Begin VB.CheckBox chkSelect1 
               DownPicture     =   "frmReportWordEdit.frx":4BCC
               Height          =   400
               Index           =   0
               Left            =   480
               Picture         =   "frmReportWordEdit.frx":5B3E
               Style           =   1  'Graphical
               TabIndex        =   5
               Top             =   120
               Visible         =   0   'False
               Width           =   400
            End
            Begin RichTextLib.RichTextBox rtxtWord1 
               Height          =   375
               Index           =   0
               Left            =   960
               TabIndex        =   6
               TabStop         =   0   'False
               Top             =   120
               Visible         =   0   'False
               Width           =   3615
               _ExtentX        =   6376
               _ExtentY        =   661
               _Version        =   393217
               ScrollBars      =   2
               Appearance      =   0
               AutoVerbMenu    =   -1  'True
               TextRTF         =   $"frmReportWordEdit.frx":6AB0
            End
         End
      End
      Begin XtremeDockingPane.DockingPane dkpMain 
         Left            =   6360
         Top             =   240
         _Version        =   589884
         _ExtentX        =   450
         _ExtentY        =   423
         _StockProps     =   0
      End
   End
   Begin VB.CommandButton cmdCancel 
      Caption         =   "ȡ��"
      Height          =   400
      Left            =   6360
      TabIndex        =   1
      Top             =   6000
      Width           =   1100
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "ȷ��"
      Height          =   400
      Left            =   2520
      TabIndex        =   0
      Top             =   6000
      Width           =   1100
   End
End
Attribute VB_Name = "frmReportWordEdit"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private mlngDeptId As Long
Private mlngWordID As Long
Private mstrWordContext As String
Private mstrCheckView As String
Private mstrResult As String
Private mstrAdvice As String
Private miType As Integer

Public Sub ZlShowMe(lngWordID As Long, frmParent As Object, iType As Integer, ByRef strCheckView As String, ByRef strResult As String, ByRef strAdvice As String)
    mlngWordID = lngWordID
    mstrWordContext = ""
    miType = iType
    
    Me.Show 1, frmParent
    
    strCheckView = mstrCheckView
    strResult = mstrResult
    strAdvice = mstrAdvice
End Sub

Public Sub zlShowMeEx(frmParent As Object, ByVal lngDeptId As Long, ByVal lngWordID As Long, _
    ByVal strWordContext As String, ByVal iType As Integer, _
    ByRef strCheckView As String, ByRef strResult As String, ByRef strAdvice As String)
    mlngDeptId = lngDeptId
    mlngWordID = lngWordID
    mstrWordContext = strWordContext
    miType = iType
    
    Me.Show 1, frmParent
    
    strCheckView = mstrCheckView
    strResult = mstrResult
    strAdvice = mstrAdvice
End Sub

Private Sub FillWords(lngWordID As Long)
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim blnNextLine As Boolean      '�Ƿ���һ�У�������������ؼ�
    Dim iFieldCount As Integer
    Dim iType As Integer        '0-������1-��ϣ�2-���
    Dim blnStartSegment As Boolean      '��ʼһ������
    
    '���ԭ�пؼ�
    Call ClearWordShow
    blnNextLine = True
    
    strSQL = "Select �ʾ�id,���д���,��������,�����ı�,����Ҫ��ID,�滻��,Ҫ������,Ҫ������,Ҫ�س���,Ҫ��С��," & _
             " Ҫ�ص�λ,Ҫ�ر�ʾ,Ҫ��ֵ��,������̬ From �����ʾ���� Where �ʾ�ID=[1] order by ���д��� "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, lngWordID)
    
    blnStartSegment = False
    
    On Error GoTo errhandle
    '����ÿһ�У���ʾ
    While rsTemp.EOF = False
        
        If blnNextLine = True Then
            blnNextLine = False
            
            '�ȶ�ȡ�����ı����жϵ�ǰ���ݵ�����
            If Left(nvl(rsTemp!�����ı�), 6) = "<<����>>" Then
                iType = 0
            ElseIf Left(nvl(rsTemp!�����ı�), 6) = "<<���>>" Then
                iType = 1
            ElseIf Left(nvl(rsTemp!�����ı�), 6) = "<<����>>" Then
                iType = 2
            Else
                iType = miType
            End If
            
            '������Ӧ���͵Ŀؼ�
            If iType = 0 Then           '������������Ŀؼ�
                iFieldCount = rtxtWord1.Count
                '������ť���ı���
                Load rtxtWord1(iFieldCount)
                rtxtWord1(iFieldCount).Visible = True
                Load chkSelect1(iFieldCount)
                chkSelect1(iFieldCount).Visible = True
                
                '�ڷ�λ��
                If iFieldCount = 1 Then
                    chkSelect1(iFieldCount).Top = 5
                Else
                    chkSelect1(iFieldCount).Top = rtxtWord1(iFieldCount - 1).Top + rtxtWord1(iFieldCount - 1).Height + 5
                End If
                chkSelect1(iFieldCount).Left = 150
                rtxtWord1(iFieldCount).Left = chkSelect1(iFieldCount).Left + chkSelect1(iFieldCount).Width + 150
                rtxtWord1(iFieldCount).Top = chkSelect1(iFieldCount).Top
                rtxtWord1(iFieldCount).Width = picContainer1.Width - rtxtWord1(iFieldCount).Left - 60
                rtxtWord1(iFieldCount).Height = 800
            ElseIf iType = 1 Then       '�����������Ŀؼ�
                iFieldCount = rtxtWord2.Count
                '������ť���ı���
                Load rtxtWord2(iFieldCount)
                rtxtWord2(iFieldCount).Visible = True
                Load chkSelect2(iFieldCount)
                chkSelect2(iFieldCount).Visible = True
                
                '�ڷ�λ��
                If iFieldCount = 1 Then
                    chkSelect2(iFieldCount).Top = 5
                Else
                    chkSelect2(iFieldCount).Top = rtxtWord2(iFieldCount - 1).Top + rtxtWord2(iFieldCount - 1).Height + 5
                End If
                chkSelect2(iFieldCount).Left = 150
                rtxtWord2(iFieldCount).Left = chkSelect2(iFieldCount).Left + chkSelect2(iFieldCount).Width + 150
                rtxtWord2(iFieldCount).Top = chkSelect2(iFieldCount).Top
                rtxtWord2(iFieldCount).Width = picContainer2.Width - rtxtWord2(iFieldCount).Left - 60
                rtxtWord2(iFieldCount).Height = 800
            ElseIf iType = 2 Then       '��������Ŀؼ�
                iFieldCount = rtxtWord3.Count
                '������ť���ı���
                Load rtxtWord3(iFieldCount)
                rtxtWord3(iFieldCount).Visible = True
                Load chkSelect3(iFieldCount)
                chkSelect3(iFieldCount).Visible = True
                
                '�ڷ�λ��
                If iFieldCount = 1 Then
                    chkSelect3(iFieldCount).Top = 5
                Else
                    chkSelect3(iFieldCount).Top = rtxtWord3(iFieldCount - 1).Top + rtxtWord3(iFieldCount - 1).Height + 5
                End If
                chkSelect3(iFieldCount).Left = 150
                rtxtWord3(iFieldCount).Left = chkSelect3(iFieldCount).Left + chkSelect3(iFieldCount).Width + 150
                rtxtWord3(iFieldCount).Top = chkSelect3(iFieldCount).Top
                rtxtWord3(iFieldCount).Width = picContainer3.Width - rtxtWord3(iFieldCount).Left - 60
                rtxtWord3(iFieldCount).Height = 800
            End If
        End If
        
        'д��rtxt�ؼ�
        If iType = 0 Then
            WriteIntoRTxt rtxtWord1(iFieldCount), Val(nvl(rsTemp!��������)), nvl(rsTemp!�����ı�), Val(nvl(rsTemp!Ҫ�ر�ʾ)), _
                    nvl(rsTemp!Ҫ�ص�λ), nvl(rsTemp!Ҫ��ֵ��), blnStartSegment, blnNextLine
        ElseIf iType = 1 Then
            WriteIntoRTxt rtxtWord2(iFieldCount), Val(nvl(rsTemp!��������)), nvl(rsTemp!�����ı�), Val(nvl(rsTemp!Ҫ�ر�ʾ)), _
                    nvl(rsTemp!Ҫ�ص�λ), nvl(rsTemp!Ҫ��ֵ��), blnStartSegment, blnNextLine
        ElseIf iType = 2 Then
            WriteIntoRTxt rtxtWord3(iFieldCount), Val(nvl(rsTemp!��������)), nvl(rsTemp!�����ı�), Val(nvl(rsTemp!Ҫ�ر�ʾ)), _
                    nvl(rsTemp!Ҫ�ص�λ), nvl(rsTemp!Ҫ��ֵ��), blnStartSegment, blnNextLine
        End If
        
        rsTemp.MoveNext
    Wend
    
    Exit Sub
errhandle:
    If ErrCenter = 1 Then Resume
    
    Call SaveErrLog
End Sub

Private Sub WriteIntoRTxt(ByRef rtxtWord As RichTextBox, int�������� As Integer, str�����ı� As String, _
                intҪ�ر�ʾ As Integer, strҪ�ص�λ As String, strҪ��ֵ�� As String, ByRef blnStartSegment As Boolean, ByRef blnNextLine As Boolean)

    If int�������� = 0 Then     '�������ı���ֱ�Ӽ�������
        If Trim(str�����ı�) <> "" And Trim(str�����ı�) <> vbCrLf Then
            
            '��������
            rtxtWord.SelStart = Len(rtxtWord.Text)
            rtxtWord.SelLength = 0
            rtxtWord.SelColor = vbBlack
            '������ִ�ǰ���б�����дλ�ñ�ʶ��ɾ���ñ�ʶ
            If Left(str�����ı�, 6) = "<<����>>" Or Left(str�����ı�, 6) = "<<���>>" _
                Or Left(str�����ı�, 6) = "<<����>>" Then
                rtxtWord.SelText = Right(str�����ı�, Len(str�����ı�) - 6)
            ElseIf UCase(Left(str�����ı�, 3)) = "<P>" Then
                '�ж��Ƿ�<P>��</P>��Χ��һ�������Ķ�
                If UCase(Right(str�����ı�, 4)) = "</P>" Then
                    rtxtWord.SelText = Mid(str�����ı�, 4, Len(str�����ı�) - 7)
                ElseIf UCase(Right(str�����ı�, 6)) = "</P>" & vbCrLf Then
                    rtxtWord.SelText = Mid(str�����ı�, 4, Len(str�����ı�) - 9)
                Else
                    rtxtWord.SelText = Right(str�����ı�, Len(str�����ı�) - 3)
                End If
                blnStartSegment = True
            ElseIf UCase(Right(str�����ı�, 4)) = "</P>" Then
                rtxtWord.SelText = Left(str�����ı�, Len(str�����ı�) - 4)
            ElseIf UCase(Right(str�����ı�, 6)) = "</P>" & vbCrLf Then
                rtxtWord.SelText = Left(str�����ı�, Len(str�����ı�) - 6)
            Else
                rtxtWord.SelText = str�����ı�
            End If
            
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
    Else        '��Ҫ�أ���Ҫ����
        If intҪ�ر�ʾ = 0 Then     '�ı�Ҫ�ؽ����ɿա� ��
            rtxtWord.SelStart = Len(rtxtWord.Text)
            rtxtWord.SelLength = 0
            rtxtWord.SelText = "  " & strҪ�ص�λ
            
            rtxtWord.SelStart = Len(rtxtWord.Text) - Len(strҪ�ص�λ)
            rtxtWord.SelLength = Len("  " & strҪ�ص�λ)
            rtxtWord.SelColor = vbBlue
        ElseIf intҪ�ر�ʾ = 1 Then     '����
            'Ŀǰû��ʹ�������ʽ
        ElseIf intҪ�ر�ʾ = 2 Then     '��ѡ
            rtxtWord.SelStart = Len(rtxtWord.Text)
            rtxtWord.SelLength = 0
            rtxtWord.SelText = "{{" & strҪ��ֵ�� & "}}" & strҪ�ص�λ
            
            rtxtWord.SelStart = Len(rtxtWord.Text) - Len("{{" & strҪ��ֵ�� & "}}" & strҪ�ص�λ)
            rtxtWord.SelLength = Len("{{" & strҪ��ֵ�� & "}}" & strҪ�ص�λ)
            rtxtWord.SelColor = vbBlue
        ElseIf intҪ�ر�ʾ = 3 Then     '��ѡ
            rtxtWord.SelStart = Len(rtxtWord.Text)
            rtxtWord.SelLength = 0
            rtxtWord.SelText = "{<" & strҪ��ֵ�� & ">}" & strҪ�ص�λ
            
            rtxtWord.SelStart = Len(rtxtWord.Text) - Len("{<" & strҪ��ֵ�� & ">}" & strҪ�ص�λ)
            rtxtWord.SelLength = Len("{<" & strҪ��ֵ�� & ">}" & strҪ�ص�λ)
            rtxtWord.SelColor = vbBlue
        End If
    End If
    
    '��������
    rtxtWord.SelStart = 0
    rtxtWord.SelLength = Len(rtxtWord.Text)
    rtxtWord.SelFontSize = 14
    rtxtWord.SelLength = 0
    
    ResizeRichTextBox rtxtWord
End Sub

Private Sub InitFaceScheme()
    '��ʼ���沼��
    Dim Pane1 As Pane, Pane2 As Pane, Pane3 As Pane
    With Me.dkpMain
        .CloseAll
        .Options.HideClient = True
        .Options.UseSplitterTracker = False 'ʵʱ�϶�
        .Options.ThemedFloatingFrames = True
        .Options.AlphaDockingContext = True
    End With
    
    If Trim(pReport_CheckViewName) = "" Then
        pReport_CheckViewName = GetDeptPara(mlngDeptId, "�����������", "�������")
    End If
    
    If Trim(pReport_ResultName) = "" Then
        pReport_ResultName = GetDeptPara(mlngDeptId, "����������", "������")
    End If
    
    If Trim(pReport_AdviceName) = "" Then
        pReport_AdviceName = GetDeptPara(mlngDeptId, "��������", "��Ͻ���")
    End If
    
    Set Pane1 = dkpMain.CreatePane(1, 0, 300, DockTopOf, Nothing)
    Pane1.Title = pReport_CheckViewName
    Pane1.Handle = picCheckView.hwnd
    Pane1.Options = PaneNoCloseable Or PaneNoFloatable Or PaneNoHideable
    
    Set Pane2 = dkpMain.CreatePane(2, 0, 150, DockBottomOf, Pane1)
    Pane2.Title = pReport_ResultName
    Pane2.Handle = picResult.hwnd
    Pane2.Options = PaneNoCloseable Or PaneNoFloatable Or PaneNoHideable
    
    Set Pane3 = dkpMain.CreatePane(3, 0, 80, DockBottomOf, Pane2)
    Pane3.Title = pReport_AdviceName
    Pane3.Handle = picAdvice.hwnd
    Pane3.Options = PaneNoCloseable Or PaneNoFloatable Or PaneNoHideable
    
End Sub

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdOk_Click()
    '��ѡ�е����ݣ���֯������
    Dim strCheckView As String
    Dim strResult As String
    Dim strAdvice As String
    
    Dim i As Integer
    
    strCheckView = ""
    strResult = ""
    strAdvice = ""
    
    For i = 1 To chkSelect1.Count - 1
        If chkSelect1(i).value = 1 Then
            If Right(rtxtWord1(i).Text, 2) = vbCrLf Then
                strCheckView = strCheckView & Left(rtxtWord1(i).Text, Len(rtxtWord1(i).Text) - 2)
            Else
                strCheckView = strCheckView & rtxtWord1(i).Text
            End If
        End If
    Next i
    
    For i = 1 To chkSelect2.Count - 1
        If chkSelect2(i).value = 1 Then
            If Right(rtxtWord2(i).Text, 2) = vbCrLf Then
                strResult = strResult & Left(rtxtWord2(i).Text, Len(rtxtWord2(i).Text) - 2)
            Else
                strResult = strResult & rtxtWord2(i).Text
            End If
        End If
    Next i
    
    For i = 1 To chkSelect3.Count - 1
        If chkSelect3(i).value = 1 Then
            If Right(rtxtWord3(i).Text, 2) = vbCrLf Then
                strAdvice = strAdvice & Left(rtxtWord3(i).Text, Len(rtxtWord3(i).Text) - 2)
            Else
                strAdvice = strAdvice & rtxtWord3(i).Text
            End If
        End If
    Next i
    
    mstrCheckView = strCheckView
    mstrResult = strResult
    mstrAdvice = strAdvice
    
    Unload Me
End Sub

Private Sub Form_Load()
    
    mstrCheckView = ""
    mstrResult = ""
    mstrAdvice = ""
    
    Call RestoreWinState(Me, App.ProductName)
    
    Call InitFaceScheme '��ʼ������
    
    If mstrWordContext = "" Then
        Call FillWords(mlngWordID)
    Else
        Call FillWordsEx(mlngWordID, mstrWordContext)
    End If
End Sub

Private Sub FillWordsEx(ByVal lngWordID As Long, ByVal strWordContext As String)
    Dim aryWordLines() As TWordLine
    Dim iType As Long
    Dim i As Long
    Dim iFieldCount As Long
    Dim strOutlineName As String
    Dim strSelOutlineName As String
    
    Dim blnHas���� As Boolean
    Dim blnHas��� As Boolean
    Dim blnHas���� As Boolean
    

    Call FormatWords(lngWordID, strWordContext, aryWordLines())

    '���ԭ�пؼ�
    Call ClearWordShow

    blnHas���� = False
    blnHas��� = False
    blnHas���� = False
    
'    otNone = 0
'    otDesc = 1      '����
'    otOpin = 2      '���   '������
'    otAdvi = 3      '����
    Select Case miType
        Case otDesc
            strSelOutlineName = "<<����>>"
        Case otOpin
            strSelOutlineName = "<<���>>"
        Case otAdvi
            strSelOutlineName = "<<����>>"
    End Select
    
    For i = 0 To UBound(aryWordLines)
        strOutlineName = aryWordLines(i).strOutlineName
        If strOutlineName = "" Then strOutlineName = strSelOutlineName
        
        If Trim(aryWordLines(i).strContext) <> "" Then
            Select Case strOutlineName
                Case "<<����>>" '������������Ŀؼ�
                        iFieldCount = rtxtWord1.Count
                        '������ť���ı���
                        Load rtxtWord1(iFieldCount)
                        rtxtWord1(iFieldCount).Visible = True
                        Load chkSelect1(iFieldCount)
                        chkSelect1(iFieldCount).Visible = True
        
                        '�ڷ�λ��
                        If iFieldCount = 1 Then
                            chkSelect1(iFieldCount).Top = 5
                        Else
                            chkSelect1(iFieldCount).Top = rtxtWord1(iFieldCount - 1).Top + rtxtWord1(iFieldCount - 1).Height + 5
                        End If
                        chkSelect1(iFieldCount).Left = 150
                        rtxtWord1(iFieldCount).Left = chkSelect1(iFieldCount).Left + chkSelect1(iFieldCount).Width + 150
                        rtxtWord1(iFieldCount).Top = chkSelect1(iFieldCount).Top
                        rtxtWord1(iFieldCount).Width = picContainer1.Width - rtxtWord1(iFieldCount).Left - 110
                        rtxtWord1(iFieldCount).Height = 800
        
                        rtxtWord1(iFieldCount).Text = aryWordLines(i).strContext
        
                        Call SetStyle(rtxtWord1(iFieldCount))
                        
                        blnHas���� = True
                Case "<<���>>" '�����������Ŀؼ�
                        iFieldCount = rtxtWord2.Count
                        '������ť���ı���
                        Load rtxtWord2(iFieldCount)
                        rtxtWord2(iFieldCount).Visible = True
                        Load chkSelect2(iFieldCount)
                        chkSelect2(iFieldCount).Visible = True
        
                        '�ڷ�λ��
                        If iFieldCount = 1 Then
                            chkSelect2(iFieldCount).Top = 5
                        Else
                            chkSelect2(iFieldCount).Top = rtxtWord2(iFieldCount - 1).Top + rtxtWord2(iFieldCount - 1).Height + 5
                        End If
                        chkSelect2(iFieldCount).Left = 150
                        rtxtWord2(iFieldCount).Left = chkSelect2(iFieldCount).Left + chkSelect2(iFieldCount).Width + 150
                        rtxtWord2(iFieldCount).Top = chkSelect2(iFieldCount).Top
                        rtxtWord2(iFieldCount).Width = picContainer2.Width - rtxtWord2(iFieldCount).Left - 110
                        rtxtWord2(iFieldCount).Height = 800
        
                        rtxtWord2(iFieldCount).Text = aryWordLines(i).strContext
        
                        Call SetStyle(rtxtWord2(iFieldCount))
                        
                        blnHas��� = True
                Case "<<����>>"
                        iFieldCount = rtxtWord3.Count
                        '������ť���ı���
                        Load rtxtWord3(iFieldCount)
                        rtxtWord3(iFieldCount).Visible = True
                        Load chkSelect3(iFieldCount)
                        chkSelect3(iFieldCount).Visible = True
        
                        '�ڷ�λ��
                        If iFieldCount = 1 Then
                            chkSelect3(iFieldCount).Top = 5
                        Else
                            chkSelect3(iFieldCount).Top = rtxtWord3(iFieldCount - 1).Top + rtxtWord3(iFieldCount - 1).Height + 5
                        End If
                        chkSelect3(iFieldCount).Left = 150
                        rtxtWord3(iFieldCount).Left = chkSelect3(iFieldCount).Left + chkSelect3(iFieldCount).Width + 150
                        rtxtWord3(iFieldCount).Top = chkSelect3(iFieldCount).Top
                        rtxtWord3(iFieldCount).Width = picContainer3.Width - rtxtWord3(iFieldCount).Left - 110
                        rtxtWord3(iFieldCount).Height = 800
        
                        rtxtWord3(iFieldCount).Text = aryWordLines(i).strContext
        
                        Call SetStyle(rtxtWord3(iFieldCount))
                        
                        blnHas���� = True
            End Select
        End If
    Next
    
    If blnHas���� = False Then dkpMain.Panes(1).Closed = True
    
    If blnHas��� = False Then dkpMain.Panes(2).Closed = True
 
    If blnHas���� = False Then dkpMain.Panes(3).Closed = True
    
End Sub

Private Sub SetStyle(rtxtWord As RichTextBox)
    Dim strCurContext As String
    Dim lngSIndex As Long
    Dim lngEIndex As Long
    Dim lngBaseIndex As Long
    
    '��������
    rtxtWord.SelStart = 0
    rtxtWord.SelLength = Len(rtxtWord.Text)
    rtxtWord.SelFontSize = 14
    rtxtWord.SelLength = 0
    
    rtxtWord.Parent.FontSize = 14
    
    '������ɫ
    strCurContext = rtxtWord.Text
    
    '����{{}}���
    lngBaseIndex = 0
    lngSIndex = InStr(strCurContext, "{{")
    lngEIndex = InStr(strCurContext, "}}")
    
    While lngSIndex < lngEIndex And lngSIndex > 0 And lngEIndex > 0
        lngBaseIndex = lngEIndex + 2
        
        rtxtWord.SelStart = lngSIndex - 1
        rtxtWord.SelLength = lngEIndex - lngSIndex + 2
        rtxtWord.SelColor = vbBlue
        
        lngSIndex = InStr(lngBaseIndex, strCurContext, "{{")
        lngEIndex = InStr(lngBaseIndex, strCurContext, "}}")
    Wend
    
    
    '����{<>}���
    lngBaseIndex = 0
    lngSIndex = InStr(strCurContext, "{<")
    lngEIndex = InStr(strCurContext, ">}")
    
    While lngSIndex < lngEIndex And lngSIndex > 0 And lngEIndex > 0
        lngBaseIndex = lngEIndex + 2
        
        rtxtWord.SelStart = lngSIndex - 1
        rtxtWord.SelLength = lngEIndex - lngSIndex + 2
        rtxtWord.SelColor = vbBlue
        
        lngSIndex = InStr(lngBaseIndex, strCurContext, "{<")
        lngEIndex = InStr(lngBaseIndex, strCurContext, ">}")
    Wend
    
    
    ResizeRichTextBox rtxtWord
End Sub

Private Sub Form_Resize()
On Error Resume Next
    '������ʾ�Ŀͻ�����
    Me.picClientArea.Left = 0
    Me.picClientArea.Top = 0
    Me.picClientArea.Width = Me.ScaleWidth
    Me.picClientArea.Height = Abs(Me.ScaleHeight - 800)
'
    Me.cmdOK.Left = Me.ScaleWidth / 4
    Me.cmdOK.Top = Me.ScaleHeight - 600

    Me.cmdCancel.Left = Me.ScaleWidth / 4 * 3 - Me.cmdCancel.Width
    Me.cmdCancel.Top = Me.cmdOK.Top
End Sub

Private Sub Form_Unload(Cancel As Integer)
    '���洰��λ��
    Call SaveWinState(Me, App.ProductName)
End Sub

Public Function ResizeRichTextBox(ByRef rtxtBox As RichTextBox) As Boolean           '�жϴ�ֱ�������Ŀɼ���
    Dim strSegment() As String
    Dim i As Integer
    Dim lngRows As Long
    Dim lngCharHeight As Long
    Dim lngDrawRow As Long
    Dim lngHeight As Long
    
    If Len(rtxtBox.Text) = 0 Then
        rtxtBox.Height = 800
    Else
        strSegment = Split(rtxtBox.Text & vbCrLf, vbCrLf)
        If rtxtBox.SelStart <= 0 Then rtxtBox.SelStart = 1
 
        Me.FontName = rtxtBox.SelFontName
        Me.FontSize = rtxtBox.SelFontSize
        
        lngCharHeight = TextHeight("a")
    
        lngHeight = (rtxtBox.GetLineFromChar(Len(rtxtBox.Text)) + 1) * (lngCharHeight + 120)
        
        If lngHeight < 800 Then lngHeight = 800
        
        rtxtBox.Height = lngHeight
    End If
End Function
 

Private Sub ClearWordShow()
    Dim i As Integer
    
    For i = 1 To rtxtWord1.Count - 1
        Unload rtxtWord1(i)
    Next i
    For i = 1 To chkSelect1.Count - 1
        Unload chkSelect1(i)
    Next i
    
    For i = 1 To rtxtWord2.Count - 1
        Unload rtxtWord2(i)
    Next i
    For i = 1 To chkSelect2.Count - 1
        Unload chkSelect2(i)
    Next i
    
    For i = 1 To rtxtWord3.Count - 1
        Unload rtxtWord3(i)
    Next i
    For i = 1 To chkSelect3.Count - 1
        Unload chkSelect3(i)
    Next i
End Sub

Private Sub ResizeWordContainer(picWordShow As PictureBox, vscroWordH As VScrollBar, picWordContainer As PictureBox, lngH As Long)
    
    '������������λ�ú͸߶�
    vscroWordH.Left = picWordShow.Width - vscroWordH.Width - 60
    vscroWordH.Top = 0
    vscroWordH.Height = picWordShow.Height - 40
    
    '�����ʾ�������λ�úͿ��
    picWordContainer.Left = 0
    picWordContainer.Top = 0
    picWordContainer.Width = Abs(picWordShow.Width - vscroWordH.Width)
    
    '�����ʾ������ĸ߶�
    
    If lngH < picWordShow.Height Then
        picWordContainer.Height = picWordShow.Height
        vscroWordH.Enabled = False
    Else
        picWordContainer.Height = lngH
        vscroWordH.Enabled = True
    End If
    
    '���ù������ķ���
    vscroWordH.Max = picWordContainer.Height / 1000
    vscroWordH.value = 0
End Sub

Private Sub picAdvice_Resize()
    Dim i As Integer
    Dim lngH As Long
    
    picContainer3.Left = 0
    picContainer3.Top = 0
    picContainer3.Width = Abs(picAdvice.Width - vscroWordH3.Width - 100)
    
    '����ÿһ��RichTextBox�Ŀ��
    For i = 1 To rtxtWord3.Count - 1
        rtxtWord3(i).Width = Abs(picContainer3.Width - rtxtWord3(i).Left - 60)
    Next i
    
    '���ڴʾ������ĸ߶�
    For i = 1 To rtxtWord3.Count - 1
        ResizeRichTextBox rtxtWord3(i)
        If i = 1 Then
            rtxtWord3(i).Top = 30
        Else
            rtxtWord3(i).Top = rtxtWord3(i - 1).Top + rtxtWord3(i - 1).Height + 5
        End If
        chkSelect3(i).Top = rtxtWord3(i).Top
    Next
    
    lngH = 0
    If rtxtWord3.Count > 1 Then
        lngH = rtxtWord3(rtxtWord3.Count - 1).Top + rtxtWord3(rtxtWord3.Count - 1).Height + 200
    End If
    
    Call ResizeWordContainer(picAdvice, vscroWordH3, picContainer3, lngH)
End Sub

Private Sub picCheckView_Resize()
On Error Resume Next
    Dim i As Integer
    Dim lngH As Long
    
    picContainer1.Left = 0
    picContainer1.Top = 0
    picContainer1.Width = Abs(picCheckView.Width - vscroWordH1.Width - 100)
    
    
    '����ÿһ��RichTextBox�Ŀ��
    For i = 1 To rtxtWord1.Count - 1
        rtxtWord1(i).Width = Abs(picContainer1.Width - rtxtWord1(i).Left - 60)
    Next i
    
    '���ڴʾ������ĸ߶�
    For i = 1 To rtxtWord1.Count - 1
        ResizeRichTextBox rtxtWord1(i)
        If i = 1 Then
            rtxtWord1(i).Top = 30
        Else
            rtxtWord1(i).Top = rtxtWord1(i - 1).Top + rtxtWord1(i - 1).Height + 5
            
        End If
        chkSelect1(i).Top = rtxtWord1(i).Top
    Next
    
    lngH = 0
    If rtxtWord1.Count > 1 Then
        lngH = rtxtWord1(rtxtWord1.Count - 1).Top + rtxtWord1(rtxtWord1.Count - 1).Height + 200
    End If
    
    Call ResizeWordContainer(picCheckView, vscroWordH1, picContainer1, lngH)
End Sub


Private Sub picResult_Resize()
On Error Resume Next
    Dim i As Integer
    Dim lngH As Long
    
    picContainer2.Left = 0
    picContainer2.Top = 0
    picContainer2.Width = Abs(picResult.Width - vscroWordH2.Width - 100)
    
    '����ÿһ��RichTextBox�Ŀ��
    For i = 1 To rtxtWord2.Count - 1
        rtxtWord2(i).Width = Abs(picContainer2.Width - rtxtWord2(i).Left - 60)
    Next i
    
    '���ڴʾ������ĸ߶�
    For i = 1 To rtxtWord2.Count - 1
        ResizeRichTextBox rtxtWord2(i)
        If i = 1 Then
            rtxtWord2(i).Top = 30
        Else
            rtxtWord2(i).Top = rtxtWord2(i - 1).Top + rtxtWord2(i - 1).Height + 5
        End If
        chkSelect2(i).Top = rtxtWord2(i).Top
    Next
    
    lngH = 0
    If rtxtWord2.Count > 1 Then
        lngH = rtxtWord2(rtxtWord2.Count - 1).Top + rtxtWord2(rtxtWord2.Count - 1).Height + 200
    End If
    
    Call ResizeWordContainer(picResult, vscroWordH2, picContainer2, lngH)
End Sub

Private Sub rtxtWord1_DblClick(Index As Integer)
On Error GoTo errhandle
    Call richTextBoxShowElements(rtxtWord1(Index))
Exit Sub
errhandle:
    MsgBoxD Me, err.Description, vbOKOnly, "��ʾ"
End Sub

Private Sub rtxtWord1_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
On Error Resume Next
    If KeyCode = 13 Or KeyCode = 8 Or KeyCode = 46 Then
        Call ResizeRichTextBox(rtxtWord1(Index))
    End If
End Sub

Private Sub rtxtWord2_DblClick(Index As Integer)
On Error GoTo errhandle
    Call richTextBoxShowElements(rtxtWord2(Index))
Exit Sub
errhandle:
    MsgBoxD Me, err.Description, vbOKOnly, "��ʾ"
End Sub

Private Sub rtxtWord2_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
On Error Resume Next
    If KeyCode = 13 Or KeyCode = 8 Or KeyCode = 46 Then
        Call ResizeRichTextBox(rtxtWord2(Index))
    End If
End Sub

Private Sub rtxtWord3_DblClick(Index As Integer)
On Error GoTo errhandle
    Call richTextBoxShowElements(rtxtWord3(Index))
Exit Sub
errhandle:
    MsgBoxD Me, err.Description, vbOKOnly, "��ʾ"
End Sub

Private Sub rtxtWord3_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
On Error Resume Next
    If KeyCode = 13 Or KeyCode = 8 Or KeyCode = 46 Then
        Call ResizeRichTextBox(rtxtWord3(Index))
    End If
End Sub

Private Sub vscroWordH1_Change()
    picContainer1.Top = -vscroWordH1.value * 1000
End Sub

Private Sub vscroWordH2_Change()
    picContainer2.Top = -vscroWordH2.value * 1000
End Sub

Private Sub vscroWordH3_Change()
    picContainer3.Top = -vscroWordH3.value * 1000
End Sub
