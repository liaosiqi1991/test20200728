VERSION 5.00
Begin VB.Form frmReportES 
   BorderStyle     =   0  'None
   Caption         =   "�ھ�����"
   ClientHeight    =   2520
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   7410
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   2520
   ScaleWidth      =   7410
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  '����ȱʡ
   Begin VB.Frame frmESItem 
      BorderStyle     =   0  'None
      Height          =   1905
      Left            =   120
      TabIndex        =   5
      Top             =   240
      Width           =   7095
      Begin VB.TextBox txt���� 
         Height          =   350
         Left            =   840
         TabIndex        =   15
         Top             =   0
         Width           =   6015
      End
      Begin VB.TextBox txtPathologyNo 
         Height          =   350
         Left            =   840
         TabIndex        =   12
         Top             =   690
         Width           =   1605
      End
      Begin VB.TextBox txtPathologyDiag 
         Height          =   735
         Left            =   840
         MultiLine       =   -1  'True
         TabIndex        =   11
         Top             =   1065
         Width           =   6015
      End
      Begin VB.TextBox txtHBsAg 
         Height          =   350
         Left            =   5280
         TabIndex        =   4
         Top             =   345
         Width           =   1575
      End
      Begin VB.TextBox txtHP���� 
         Height          =   350
         Left            =   3480
         TabIndex        =   2
         Top             =   345
         Width           =   975
      End
      Begin VB.TextBox txtϸ��ˢ 
         Height          =   350
         Left            =   5280
         TabIndex        =   3
         Top             =   690
         Width           =   1575
      End
      Begin VB.TextBox txt������ 
         Height          =   350
         Left            =   3480
         TabIndex        =   1
         Top             =   690
         Width           =   975
      End
      Begin VB.TextBox txt��첿λ 
         Height          =   350
         Left            =   840
         TabIndex        =   0
         Top             =   345
         Width           =   1605
      End
      Begin VB.Label Label8 
         Caption         =   "���ߣ�"
         Height          =   195
         Left            =   0
         TabIndex        =   16
         Top             =   75
         Width           =   975
      End
      Begin VB.Label Label7 
         Caption         =   "������ţ�"
         Height          =   255
         Left            =   0
         TabIndex        =   14
         Top             =   735
         Width           =   975
      End
      Begin VB.Label lbl������� 
         Caption         =   "������ϣ�"
         Height          =   615
         Left            =   0
         TabIndex        =   13
         Top             =   1080
         Width           =   975
      End
      Begin VB.Label Label5 
         Caption         =   "HBsAg��"
         Height          =   195
         Left            =   4560
         TabIndex        =   10
         Top             =   435
         Width           =   615
      End
      Begin VB.Label Label4 
         Caption         =   "ϸ��ˢ��"
         Height          =   195
         Left            =   4560
         TabIndex        =   9
         Top             =   765
         Width           =   735
      End
      Begin VB.Label Label3 
         Caption         =   "HP���飺"
         Height          =   195
         Left            =   2520
         TabIndex        =   8
         Top             =   435
         Width           =   735
      End
      Begin VB.Label Label2 
         Caption         =   "��������"
         Height          =   195
         Left            =   2520
         TabIndex        =   7
         Top             =   765
         Width           =   975
      End
      Begin VB.Label lbl��첿λ 
         Caption         =   "��첿λ��"
         Height          =   195
         Left            =   0
         TabIndex        =   6
         Top             =   435
         Width           =   975
      End
   End
End
Attribute VB_Name = "frmReportES"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private mblnSingleWindow As Boolean     '�Ƿ�ʹ�ö���������ʾ����༭����True-����������ʾ��False-Ƕ��ʽ��ʾ
Private mlngAdviceID As Long    'ҽ��ID
Private mintEditType As Integer '����״̬ 0 ������1��д��2 �޶�
Private mReportID As Long       '����ID
Private mblnCheckModity As Boolean      '�Ƿ��������ݱ仯��¼
Private mblnEditable As Boolean         '�Ƿ���Ա༭����
Private mblnMoved As Boolean            '�Ƿ��Ѿ�ת��

'�ھ�ר�Ʊ���Ҫ��
Private Const Report_Element_������� = "�������"
Private Const Report_Element_������� = "�������"
Private Const Report_Element_��첿λ = "��첿λ"
Private Const Report_Element_������ = "������"
Private Const Report_Element_ϸ��ˢ = "ϸ��ˢ"
Private Const Report_Element_HP���� = "HP����"
Private Const Report_Element_HBsAg = "HBsAg"
Private Const Report_Element_���� = "����"

Public pModified As Boolean     '��¼�Ƿ����޸�

Private mfrmParentReport As frmReport

Public Sub zlRefresh(frmParentReport As frmReport, ByVal lngAdviceID As Long, ReportID As Long, _
    blnSingleWindow As Boolean, blnEditable As Boolean, ByVal blnMoved As Boolean)
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    mlngAdviceID = lngAdviceID
    mReportID = ReportID
    mblnSingleWindow = blnSingleWindow
    mblnEditable = blnEditable
    mblnMoved = blnMoved
    Set mfrmParentReport = frmParentReport
    
    txtPathologyNo.Text = ""
    txtPathologyDiag.Text = ""
    txt��첿λ.Text = ""
    txt������.Text = ""
    txtϸ��ˢ.Text = ""
    txtHP����.Text = ""
    txtHBsAg.Text = ""
    txt����.Text = ""
    
    mblnCheckModity = False     'ֹͣ���ݱ仯��¼
    pModified = False

    strSQL = "Select �����ı�,Ҫ������ From ���Ӳ������� Where �ļ�ID=[1] And ��������=4 And ��ֹ��=0 And �滻��=0"
    If mblnMoved = True Then
        strSQL = Replace(strSQL, "���Ӳ�������", "H���Ӳ�������")
    End If
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, mReportID)
    
    While rsTemp.EOF = False
        Select Case nvl(rsTemp!Ҫ������)
            Case Report_Element_�������
                txtPathologyNo.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_�������
                txtPathologyDiag.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_��첿λ
                txt��첿λ.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_������
                txt������.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_ϸ��ˢ
                txtϸ��ˢ.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_HP����
                txtHP����.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_HBsAg
                txtHBsAg.Text = nvl(rsTemp!�����ı�)
            Case Report_Element_����
                txt����.Text = nvl(rsTemp!�����ı�)
        End Select
        rsTemp.MoveNext
    Wend
    
    '���ý���ؼ��Ƿ���Ա༭
    frmESItem.Enabled = mblnEditable
'    frmPathology.Enabled = mblnEditable
    
    mblnCheckModity = True     '�������ݱ仯��¼
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Function getElementString() As String
    Dim strElements As String
    
    strElements = SPLITER_REPORT & Report_Element_������� & SPLITER_ELEMENT & txtPathologyNo.Text & SPLITER_REPORT & _
                Report_Element_������� & SPLITER_ELEMENT & txtPathologyDiag.Text & SPLITER_REPORT & _
                Report_Element_��첿λ & SPLITER_ELEMENT & txt��첿λ.Text & SPLITER_REPORT & _
                Report_Element_������ & SPLITER_ELEMENT & Val(txt������.Text) & SPLITER_REPORT & _
                Report_Element_ϸ��ˢ & SPLITER_ELEMENT & txtϸ��ˢ.Text & SPLITER_REPORT & _
                Report_Element_HP���� & SPLITER_ELEMENT & txtHP����.Text & SPLITER_REPORT & _
                Report_Element_HBsAg & SPLITER_ELEMENT & txtHBsAg.Text & SPLITER_REPORT & _
                Report_Element_���� & SPLITER_ELEMENT & txt����.Text
    getElementString = strElements
End Function

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    Select Case KeyCode
        Case vbKeyReturn
            zlCommFun.PressKey vbKeyTab
    End Select
End Sub

Private Sub Form_Resize()
    Dim lngTemp As Long
    
    frmESItem.Left = 0
    frmESItem.Top = 0
    frmESItem.Width = Me.ScaleWidth

End Sub

Private Sub Form_Unload(Cancel As Integer)
    Dim strRegPath As String
    
    Set mfrmParentReport = Nothing
    
    If mblnSingleWindow = True Then
        strRegPath = "����ģ��\" & App.ProductName & "\frmReport\SingleWindow"
    Else
        strRegPath = "����ģ��\" & App.ProductName & "\frmReport"
    End If

    SaveSetting "ZLSOFT", strRegPath, "CY22", Me.Height
End Sub

Private Sub frmPathology_DragDrop(Source As Control, X As Single, Y As Single)

End Sub

Private Sub lbl�������_DblClick()
    On Error GoTo err
    If Not mfrmParentReport Is Nothing Then
       Call mfrmParentReport.WordItemClick(ReportViewType_�������, ReportViewType_�������, txtPathologyDiag.Text)
    End If
err:
    
End Sub

Private Sub lbl��첿λ_DblClick()
    On Error GoTo err
    If Not mfrmParentReport Is Nothing Then
        Call mfrmParentReport.WordItemClick(ReportViewType_��첿λ, ReportViewType_��첿λ, txt��첿λ.Text)
    End If
err:
End Sub

Private Sub txtHBsAg_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txtHBsAg_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txtHBsAg_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Private Sub txtHP����_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txtPathologyDiag_Change()
     If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txtPathologyDiag_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txtPathologyDiag_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Private Sub txtPathologyNo_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txtPathologyNo_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txtPathologyNo_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Private Sub txt��첿λ_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txt��첿λ_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txt��첿λ_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Private Sub txt������_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txtϸ��ˢ_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txtϸ��ˢ_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txtϸ��ˢ_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Private Sub txt����_Change()
    If mblnCheckModity = True Then
        pModified = True
    End If
End Sub

Private Sub txt����_GotFocus()
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txt����_LostFocus()
    Call zlCommFun.OpenIme
End Sub

Public Sub zlWriteWord(strWord As String, strReportViewType As String)
    If strReportViewType = ReportViewType_������� Then
        txtPathologyDiag.Text = txtPathologyDiag.Text & strWord
    ElseIf strReportViewType = ReportViewType_��첿λ Then
        txt��첿λ.Text = txt��첿λ.Text & strWord
    End If
End Sub