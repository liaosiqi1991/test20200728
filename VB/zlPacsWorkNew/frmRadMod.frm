VERSION 5.00
Begin VB.Form frmRadMod 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Ӱ����Ŀ�޸�"
   ClientHeight    =   4080
   ClientLeft      =   2760
   ClientTop       =   3750
   ClientWidth     =   6150
   Icon            =   "frmRadMod.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4080
   ScaleWidth      =   6150
   StartUpPosition =   1  '����������
   Begin VB.CommandButton cmdCanc 
      Caption         =   "ȡ��(&C)"
      Height          =   350
      Left            =   4890
      TabIndex        =   15
      Top             =   3615
      Width           =   1100
   End
   Begin VB.CommandButton cmd���� 
      Caption         =   "����(&H)"
      Height          =   350
      Left            =   195
      Picture         =   "frmRadMod.frx":058A
      TabIndex        =   14
      TabStop         =   0   'False
      Top             =   3615
      Width           =   1100
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "ȷ��(&O)"
      Height          =   350
      Left            =   3750
      TabIndex        =   13
      Top             =   3615
      Width           =   1100
   End
   Begin VB.TextBox txtͼ�� 
      Height          =   300
      Left            =   4425
      MaxLength       =   1
      TabIndex        =   12
      Top             =   2235
      Visible         =   0   'False
      Width           =   780
   End
   Begin VB.Frame fraLine 
      Height          =   30
      Index           =   1
      Left            =   -45
      TabIndex        =   11
      Top             =   3495
      Width           =   6210
   End
   Begin VB.TextBox txt׼�� 
      Height          =   300
      Left            =   1620
      MaxLength       =   100
      TabIndex        =   10
      Top             =   3045
      Visible         =   0   'False
      Width           =   4230
   End
   Begin VB.ComboBox cbo��Ƭ 
      Height          =   300
      Left            =   1620
      Style           =   2  'Dropdown List
      TabIndex        =   9
      Top             =   2670
      Width           =   2055
   End
   Begin VB.ComboBox cbo���� 
      Height          =   300
      Left            =   1620
      Style           =   2  'Dropdown List
      TabIndex        =   8
      Top             =   2295
      Width           =   2055
   End
   Begin VB.ComboBox cbo��� 
      Height          =   300
      Left            =   1620
      Style           =   2  'Dropdown List
      TabIndex        =   3
      Top             =   1935
      Width           =   2055
   End
   Begin VB.Frame fraLine 
      Height          =   30
      Index           =   0
      Left            =   -30
      TabIndex        =   1
      Top             =   510
      Width           =   6210
   End
   Begin VB.Label lblPartUnit 
      AutoSize        =   -1  'True
      Caption         =   "��λ:     ���㵥λ:"
      Height          =   180
      Left            =   810
      TabIndex        =   19
      Top             =   1245
      Width           =   1710
   End
   Begin VB.Label lblCodeName 
      AutoSize        =   -1  'True
      Caption         =   "����:     ����:"
      Height          =   180
      Left            =   810
      TabIndex        =   18
      Top             =   945
      Width           =   1350
   End
   Begin VB.Label lblBaseInfo 
      AutoSize        =   -1  'True
      Caption         =   "��Ŀ������Ϣ��"
      Height          =   180
      Left            =   630
      TabIndex        =   17
      Top             =   675
      Width           =   1260
   End
   Begin VB.Label lblExtendInfo 
      AutoSize        =   -1  'True
      Caption         =   "Ӱ���鲹����Ϣ��"
      Height          =   180
      Left            =   630
      TabIndex        =   16
      Top             =   1650
      Width           =   1620
   End
   Begin VB.Label lblͼ�� 
      AutoSize        =   -1  'True
      Caption         =   "�������ͼ����Ŀ"
      Height          =   180
      Left            =   4410
      TabIndex        =   7
      Top             =   1995
      Visible         =   0   'False
      Width           =   1440
   End
   Begin VB.Label lbl׼�� 
      AutoSize        =   -1  'True
      Caption         =   "���׼��"
      Height          =   180
      Left            =   810
      TabIndex        =   6
      Top             =   3105
      Visible         =   0   'False
      Width           =   720
   End
   Begin VB.Label lbl��Ƭ 
      AutoSize        =   -1  'True
      Caption         =   "�ɷ���Ƭ"
      Height          =   180
      Left            =   810
      TabIndex        =   5
      Top             =   2730
      Width           =   720
   End
   Begin VB.Label lbl���� 
      AutoSize        =   -1  'True
      Caption         =   "���в���"
      Height          =   180
      Left            =   810
      TabIndex        =   4
      Top             =   2370
      Width           =   720
   End
   Begin VB.Label lbl��� 
      AutoSize        =   -1  'True
      Caption         =   "Ӱ�����"
      Height          =   180
      Left            =   810
      TabIndex        =   2
      Top             =   1995
      Width           =   720
   End
   Begin VB.Image imgNote 
      Height          =   480
      Left            =   60
      Picture         =   "frmRadMod.frx":06D4
      Top             =   15
      Width           =   480
   End
   Begin VB.Label lblnote 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "    ֻ���޸�Ӱ������Ŀ�Ĳ�����Ϣ�����޸���Ŀ���������Ϣ����������Ŀ�����н��С�"
      ForeColor       =   &H80000008&
      Height          =   360
      Left            =   630
      TabIndex        =   0
      Top             =   90
      Width           =   5325
   End
End
Attribute VB_Name = "frmRadMod"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private mrsTemp As New ADODB.Recordset

Private maryTemp() As String
Private mintCount As Integer

Public Event OnRadUpdate(ByVal lngProId As Long)

Private Sub cbo����_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then Call zlCommFun.PressKey(vbKeyTab)
End Sub

Private Sub cbo��Ƭ_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then Call zlCommFun.PressKey(vbKeyTab)
End Sub

Private Sub cbo���_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then Call zlCommFun.PressKey(vbKeyTab)
End Sub

Private Sub cmdCanc_Click()
    Unload Me
End Sub

Private Sub CmdOK_Click()
    Dim strDescribe As String
    

    strDescribe = "'" & Split(Me.cbo���.Text, "-")(0) & "'"
    strDescribe = strDescribe & "," & Left(Me.cbo����.Text, 1)
    strDescribe = strDescribe & "," & Left(Me.cbo��Ƭ.Text, 1)
    strDescribe = strDescribe & ",'" & Trim(Me.txt׼��.Text) & "'"
    strDescribe = strDescribe & "," & Val(Me.txtͼ��.Text)
    
    gstrSQL = "zl_Ӱ������Ŀ_Update(" & Me.lblBaseInfo.tag & "," & strDescribe & ")"
    err = 0: On Error GoTo errHand
    
    Call gcnOracle.BeginTrans
    
    zlDatabase.ExecuteProcedure gstrSQL, Me.Caption
    
    RaiseEvent OnRadUpdate(Me.lblBaseInfo.tag)
    
    Call gcnOracle.CommitTrans
    
    Unload Me
    Exit Sub

errHand:
    Call gcnOracle.RollbackTrans
    
    If ErrCenter() = 1 Then Resume Next
    Call SaveErrLog
End Sub

Private Sub cmd����_Click()
    ShowHelp App.ProductName, Me.hWnd, Me.Name
End Sub

Private Sub Form_Activate()
    gstrSQL = "Select I.ID,I.����, I.����,I.�걾��λ, I.���㵥λ,R.���в���,R.�ɷ���Ƭ,R.����ͼ��,R.���׼��" & _
            "  From ������ĿĿ¼ I, Ӱ������Ŀ R" & _
            " Where I.ID = R.������Ŀid And I.ID=[1] "
    err = 0: On Error GoTo errHand
    
    Set mrsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ѯ������Ŀ", CLng(Me.lblBaseInfo.tag))
    
    With mrsTemp
        If .RecordCount = 0 Then MsgBoxD Me, "�����޸ĵ�ͬʱ������Ŀ�Ѿ���ɾ����", vbInformation, gstrSysName: Unload Me: Exit Sub
        Me.lblCodeName.Caption = "����:" & !���� & "    ����:" & !����
        Me.lblPartUnit.Caption = "��λ:" & IIf(IsNull(!�걾��λ), "", !�걾��λ) & "    ���㵥λ:" & IIf(IsNull(!���㵥λ), "", !���㵥λ)
        Me.cbo����.ListIndex = IIf(IsNull(!���в���), 0, !���в���)
        Me.cbo��Ƭ.ListIndex = IIf(IsNull(!�ɷ���Ƭ), 0, !�ɷ���Ƭ)
        Me.txtͼ��.Text = IIf(IsNull(!����ͼ��), 0, !����ͼ��)
        Me.txt׼��.Text = IIf(IsNull(!���׼��), "", !���׼��)
    End With
    Exit Sub

errHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub Form_Load()
    gstrSQL = "Select ����,���� From Ӱ������� Order By ����"
    err = 0: On Error GoTo errHand
    
    Set mrsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "��ѯӰ�������")
    With mrsTemp
        Me.cbo���.Clear
        Do While Not .EOF
            Me.cbo���.AddItem !���� & "-" & !����
            If !���� = Mid(frmRadLists.lvwKind.SelectedItem.Key, 2) Then
                Me.cbo���.ListIndex = Me.cbo���.NewIndex
            End If
            .MoveNext
        Loop
    End With
        
    maryTemp = Split("0-������;1-����;2-ѡ�����", ";")
    For mintCount = LBound(maryTemp) To UBound(maryTemp)
        Me.cbo����.AddItem maryTemp(mintCount)
    Next
    Me.cbo����.ListIndex = 0
    
    maryTemp = Split("0-������;1-����;2-ѡ�񷢷�", ";")
    For mintCount = LBound(maryTemp) To UBound(maryTemp)
        Me.cbo��Ƭ.AddItem maryTemp(mintCount)
    Next
    Me.cbo��Ƭ.ListIndex = 0
    Exit Sub

errHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Set mrsTemp = Nothing
End Sub

Private Sub txtͼ��_GotFocus()
    Me.txtͼ��.SelStart = 0: Me.txtͼ��.SelLength = 100
End Sub

Private Sub txtͼ��_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
    Case vbKeyBack, vbKeyEscape, 3, 22
        Exit Sub
    Case vbKeyReturn
        Call zlCommFun.PressKey(vbKeyTab): Exit Sub
    Case Else
        KeyAscii = Asc(UCase(Chr(KeyAscii)))
        If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then Exit Sub
    End Select
    KeyAscii = 0
End Sub

Private Sub txt׼��_GotFocus()
    Me.txt׼��.SelStart = 0: Me.txt׼��.SelLength = Me.txt׼��.MaxLength
    Call zlCommFun.OpenIme(True)
End Sub

Private Sub txt׼��_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then Call zlCommFun.PressKey(vbKeyTab): Exit Sub
    If InStr(" ^&`'""", Chr(KeyAscii)) > 0 Then KeyAscii = 0
End Sub

Private Sub txt׼��_LostFocus()
    Call zlCommFun.OpenIme(False)
End Sub
