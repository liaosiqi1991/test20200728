VERSION 5.00
Object = "{0E59F1D2-1FBE-11D0-8FF2-00A0D10038BC}#1.0#0"; "msscript.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmCustomQueryCall 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "�Զ����ѯ"
   ClientHeight    =   5295
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   5805
   BeginProperty Font 
      Name            =   "Tahoma"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmCustomQueryCall.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5295
   ScaleWidth      =   5805
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  '����������
   Begin MSScriptControlCtl.ScriptControl sctExecute 
      Left            =   855
      Top             =   3210
      _ExtentX        =   1005
      _ExtentY        =   1005
   End
   Begin MSComCtl2.DTPicker dtpObj 
      Height          =   330
      Index           =   0
      Left            =   1965
      TabIndex        =   6
      Top             =   1080
      Visible         =   0   'False
      Width           =   3135
      _ExtentX        =   5530
      _ExtentY        =   582
      _Version        =   393216
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "����"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Format          =   147652609
      CurrentDate     =   41297
   End
   Begin VB.TextBox txtObj 
      BeginProperty Font 
         Name            =   "����"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      Index           =   0
      Left            =   1950
      TabIndex        =   5
      Top             =   1485
      Visible         =   0   'False
      Width           =   3135
   End
   Begin VB.ComboBox cbxObj 
      BeginProperty Font 
         Name            =   "����"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Index           =   0
      Left            =   1965
      TabIndex        =   4
      Text            =   "cbxObj"
      Top             =   1920
      Visible         =   0   'False
      Width           =   3135
   End
   Begin VB.ListBox lstObj 
      BeginProperty Font 
         Name            =   "����"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1410
      Index           =   0
      ItemData        =   "frmCustomQueryCall.frx":000C
      Left            =   1980
      List            =   "frmCustomQueryCall.frx":000E
      Style           =   1  'Checkbox
      TabIndex        =   3
      Top             =   2310
      Visible         =   0   'False
      Width           =   3135
   End
   Begin VB.Frame framButton 
      Height          =   780
      Left            =   -45
      TabIndex        =   0
      Top             =   4620
      Width           =   5895
      Begin VB.CommandButton cmdCancel 
         Cancel          =   -1  'True
         Caption         =   "ȡ ��(&C)"
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   4410
         TabIndex        =   2
         Top             =   240
         Width           =   1185
      End
      Begin VB.CommandButton cmdSure 
         Caption         =   "ȷ ��(&S)"
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   3045
         TabIndex        =   1
         Top             =   240
         Width           =   1185
      End
   End
   Begin VB.Image imgQuery 
      Height          =   720
      Left            =   105
      Picture         =   "frmCustomQueryCall.frx":0010
      Stretch         =   -1  'True
      Top             =   135
      Width           =   720
   End
   Begin VB.Label labMemo 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Height          =   630
      Left            =   870
      TabIndex        =   9
      Top             =   165
      Width           =   4650
   End
   Begin VB.Shape shpBack 
      BorderStyle     =   0  'Transparent
      FillColor       =   &H00CEFFFA&
      FillStyle       =   0  'Solid
      Height          =   840
      Left            =   75
      Shape           =   4  'Rounded Rectangle
      Top             =   60
      Width           =   5670
   End
   Begin VB.Label labError 
      Alignment       =   2  'Center
      Caption         =   "û����Ҫ¼�����Ŀ��"
      BeginProperty Font 
         Name            =   "����"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   1425
      TabIndex        =   8
      Top             =   2325
      Visible         =   0   'False
      Width           =   3435
   End
   Begin VB.Label labObj 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "����ռλ:"
      BeginProperty Font 
         Name            =   "����"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Index           =   0
      Left            =   615
      TabIndex        =   7
      Top             =   1140
      Visible         =   0   'False
      Width           =   885
   End
End
Attribute VB_Name = "frmCustomQueryCall"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public mlngSchemeId As Long            '��ѯ����ID
Public mlngDepartId As Long            '��ǰ����ID
Public mlngModule As Long              '��ǰģ����
Public mstrReturnQuery As String       '��ȷ������ť���º󣬷��صĲ�ѯsql
Public mstrPars As Variant

Private mobjLastControl As Object       '����¼�����ʱ���������һ�δ�����¼�����
Private mstrInputProTotal As String     '�����ܵ���Ҫ¼�����Ŀ
Private mrsCfgData As ADODB.Recordset   '��ѯ�������õ�����
Private mobjReg As Scripting.Dictionary  '����¼�����ֵ�ı������������Ŀؼ�


Private mstrSchemeQuerySql As String
Public mintEnabledRules As Integer      '�Ƿ������˹���1-�����˹���,0-û�����ù����ѯ


Public Function ShowCustomQuery(ByVal lngSchemeId As String, ByVal lngDepartId As Long, _
    ByVal lngModule As Long, ByRef strPars As Variant, objOwner As Object) As String
    
    ShowCustomQuery = ""
        
    Me.mlngSchemeId = lngSchemeId
    Me.mlngDepartId = lngDepartId
    Me.mlngModule = lngModule
    
    Call Me.Show(1, objOwner)
    
    strPars = Me.mstrPars
    ShowCustomQuery = Me.mstrReturnQuery
End Function


Private Sub cbxObj_Change(Index As Integer)
'����������ֵ���û��ı����Ҫ���������ݼ���
On Error GoTo errHandle
    Call ControlValChange(cbxObj, Index)
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub cmdCancel_Click()
On Error GoTo errHandle
    mstrReturnQuery = ""
    
    Unload Me
    
    Exit Sub
errHandle:
End Sub

Private Sub cmdSure_Click()
On Error GoTo errHandle
    Dim strSQL As String
    Dim varValues As Variant
    
    If Trim(mstrSchemeQuerySql) = "" Then
        MsgBoxD Me, "��Ч�Ĳ�ѯ���������ܼ���ִ�С�", vbOKOnly, Me.Caption
        Exit Sub
    End If

    strSQL = mstrSchemeQuerySql
    Call InitQuerySqlAndPars(strSQL, varValues)
    
    mstrReturnQuery = strSQL
    mstrPars = varValues
    
    Unload Me
Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Public Sub GetQuerySqlAndPars(ByVal lngSchemeId As Long, ByRef strQuerySql As String, ByRef varParameters As Variant)
    Dim varValues As Variant
    Dim strReturn As String
    Dim rsData As ADODB.Recordset
    
    mintEnabledRules = 0
    
    Set rsData = GetSchemeData(lngSchemeId)
    
    If rsData Is Nothing Then Exit Sub
    
    If rsData.RecordCount <= 0 Then
        Call MsgBoxD(Me, "δ�ҵ�������Ϣ��������ɶ�Ӧ��ѯ��", vbOKOnly, Me.Caption)
        Exit Sub
    End If
    
    strReturn = nvl(rsData!��ѯ���)
    mintEnabledRules = Val(nvl(rsData!�Ƿ����ù���))
    
    Call InitQuerySqlAndPars(strReturn, varValues)
    
    strQuerySql = strReturn
    varParameters = varValues
End Sub

Private Function GetSchemeData(ByVal lngSchemeId As Long) As ADODB.Recordset
On Error GoTo errHandle
    Dim strSQL As String
    
    strSQL = "select ��ѯ���,����˵��,�Ƿ����ù��� from Ӱ���ѯ���� where id=[1]"
    Set GetSchemeData = zlDatabase.OpenSQLRecord(strSQL, "��ѯ������Ϣ", lngSchemeId)
Exit Function
errHandle:
    Set GetSchemeData = Nothing
End Function

Private Function GetQueryWhereForAdvice(ByVal strSourceSql As String) As String
    Dim strSQL As String
    Dim lngIndex As Long, lngStartIndex As Long, lngEndIndex As Long
    Dim strTmp As String
    Dim lngTmp As Long
    
    GetQueryWhereForAdvice = ""
    
    strSQL = UCase(strSourceSql)
    strSQL = Mid(strSQL, 1, InStr(strSQL, "FROM") - 1)
    
    '�ж�ҽ��ID�Ƿ����,��������ڣ���ֱ�Ӽ���ID�ֶ�
    lngIndex = InStr(strSQL, "ҽ��ID")
    If lngIndex <= 0 Then
        lngIndex = InStr(strSQL, "ID")
        If lngIndex > 0 Then lngIndex = lngIndex + Len("ID")
    Else
        lngIndex = lngIndex + Len("ҽ��ID")
    End If
    
    If lngIndex <= 0 Then
        '����ʶ��Ĳ�ѯ���
        Exit Function
    End If
    

    strSQL = Mid(strSQL, 1, lngIndex - 1)
    strSQL = Replace(strSQL, "DISTINCT", "")
    
    '�ж��Ƿ��ж��ţ���ѯ���ʹ�ö��ŷָ�����ѯ�ֶ�
    lngStartIndex = InStrRev(strSQL, ",")
    If lngStartIndex <= 0 Then
        lngStartIndex = InStrRev(strSQL, "/")
        If lngStartIndex <= 0 Then
            lngStartIndex = InStrRev(strSQL, " ")
        End If
    End If
    
    If lngStartIndex <= 0 Then
        '����ʶ��Ĳ�ѯ���
        Exit Function
    End If
    
    'strSql�Ľ�������� a.ҽ��ID�� a.Id as ҽ��ID��ҽ��ID
    strSQL = Mid(strSQL, lngStartIndex + 1, 4000)
    
    strTmp = Right(Replace(strSQL, " ", ""), 2)
    If strTmp = "AS" Then
        GetQueryWhereForAdvice = Mid(strSQL, 1, InStr(strSQL, "AS") - 1)
    Else
        GetQueryWhereForAdvice = Mid(strSQL, 1, 100)
    End If
    
End Function

Public Function GetQuerySqlForAdvice(ByVal strSourceSql As String) As String
    Dim strSQL As String
    Dim strPars(21) As String
    Dim i As Long
    Dim strCurPar As String
    Dim strField As String
    Dim strAdviceFilter As String
    Dim lstSelectFrom As New Scripting.Dictionary
    Dim lngSelectIndex As Long, lngFromIndex As Long
    Dim strTemp As String
    Dim lngSelectCount As Long
    Dim dicKey As Variant
        
    
    strSQL = strSourceSql
    GetQuerySqlForAdvice = ""
    
    strAdviceFilter = GetQueryWhereForAdvice(strSourceSql)
    If Trim(strAdviceFilter) = "" Then Exit Function
    
    If Not GetParameterNames(strSQL, strPars()) Then
        GetQuerySqlForAdvice = strSourceSql & " And " & strAdviceFilter & "=[21]"

        Exit Function
    End If
    
    lngSelectIndex = InStr(UCase(strSQL), "SELECT")
    lngFromIndex = InStr(UCase(strSQL), "FROM")
    lngSelectCount = 1
    
    '������select...from�����ȡ������������潫select�еĲ�ѯ�ֶα��滻Ϊ1
    While lngSelectIndex > 0 And lngFromIndex > 0
        
        strTemp = Mid(strSQL, lngSelectIndex, lngFromIndex + Len("FROM"))
        strSQL = Replace(strSQL, strTemp, "<@" & lngSelectCount & "@>")
        
        Call lstSelectFrom.Add("<@" & lngSelectCount & "@>", strTemp)
        
        lngSelectIndex = InStr(UCase(strSQL), "SELECT")
        lngFromIndex = InStr(UCase(strSQL), "FROM")
        
        lngSelectCount = lngSelectCount + 1
    Wend
    
    '��ʽ��sql��ѯ��䣬�������Ͳ�ѯֵ����
    For i = 1 To 20
        strCurPar = strPars(i)
        
        If strCurPar <> "" Then
            strField = GetParameterField(strCurPar, strSQL)
            If strField <> "" Then
                strSQL = Replace(strSQL, strCurPar, 1)
                strSQL = Replace(strSQL, strField, 1)
            Else
                strSQL = Replace(strSQL, strCurPar, "[" & i & "]")
            End If
            
        End If
    Next i
    
    '�ָ�select ... from ���
    For Each dicKey In lstSelectFrom.Keys
        strSQL = Replace(strSQL, dicKey, lstSelectFrom(dicKey))
    Next
        
    
    GetQuerySqlForAdvice = strSQL & " And " & strAdviceFilter & "=[21]"
    
End Function

Private Sub InitQuerySqlAndPars(ByRef strQuerySql As String, ByRef varParameters As Variant)
    Dim strSQL As String
    Dim strPars(21) As String
    Dim varValues(21) As Variant
    Dim i As Long
    Dim strCurPar As String
    Dim strField As String
    Dim lstSelectFrom As New Scripting.Dictionary
    Dim lngSelectIndex As Long, lngFromIndex As Long
    Dim strTemp As String
    Dim lngSelectCount As Long
    Dim dicKey As Variant
    
    
    strSQL = strQuerySql
    
    If Not GetParameterNames(strSQL, strPars()) Then
        strQuerySql = strSQL
        varParameters = strPars()
        
        Exit Sub
    End If
    
    lngSelectIndex = InStr(UCase(strSQL), "SELECT")
    lngFromIndex = InStr(UCase(strSQL), "FROM")
    lngSelectCount = 1
    
    '������select...from�����ȡ������������潫select�еĲ�ѯ�ֶα��滻Ϊ1
    While lngSelectIndex > 0 And lngFromIndex > 0
        
        strTemp = Mid(strSQL, lngSelectIndex, lngFromIndex + Len("FROM"))
        strSQL = Replace(strSQL, strTemp, "<@" & lngSelectCount & "@>")
        
        Call lstSelectFrom.Add("<@" & lngSelectCount & "@>", strTemp)
        
        lngSelectIndex = InStr(UCase(strSQL), "SELECT")
        lngFromIndex = InStr(UCase(strSQL), "FROM")
        
        lngSelectCount = lngSelectCount + 1
    Wend
    
    '��ʽ��sql��ѯ��䣬�������Ͳ�ѯֵ����
    For i = 1 To 20
        strCurPar = strPars(i)
        varValues(i) = GetParameterValue(strCurPar)
        
        If strCurPar <> "" Then
            If Trim(varValues(i)) = "" Then    '���¼�������Ϊ�գ���ʹ�ø�����
                strField = GetParameterField(strCurPar, strSQL)
                If strField <> "" Then
                    strSQL = Replace(strSQL, strCurPar, 1)
                    strSQL = Replace(strSQL, strField, 1)
                Else
                    strSQL = Replace(strSQL, strCurPar, "[" & i & "]")
                End If
            Else
                strSQL = Replace(strSQL, strCurPar, "[" & i & "]")
            End If
            
        End If
    Next i
    
    '�ָ�select ... from ���
    For Each dicKey In lstSelectFrom.Keys
        strSQL = Replace(strSQL, dicKey, lstSelectFrom(dicKey))
    Next
    
    strQuerySql = strSQL
    varParameters = varValues()
End Sub

Private Function GetParameterField(ByVal strParameter As String, ByVal strSQL As String) As String
'��ȡ�����ڲ�ѯ����ж�Ӧʹ�õ��ֶ�����
    Dim strTemp As String
    Dim lngParIndex As Long
    Dim lngFieldIndex As Long
    Dim lngBetweenIndex As Long
    Dim strPrefix As String
    Dim strBetween As String
    
    GetParameterField = ""
    
    '��strSql = "select id from tab a where a.test = [par1] "
    lngParIndex = InStr(strSQL, strParameter)
    If lngParIndex <= 0 Then Exit Function
    
    
    'ִ�к�ȡ�õ�strsql���ֽ�Ϊ��select id from tab a where a.test = ��
    strTemp = Mid(strSQL, 1, lngParIndex - 1)
    
    
    lngFieldIndex = InStrRev(strTemp, ".")
    
    '�ж��ֶ������֮���Ƿ������غ��������£�
    'select id from tab a where a.pid is null and insert([par1], a.Field) > 0
    If InStr(lngFieldIndex, UCase(strTemp), "INSTR(") > 0 Then
        '��ȡinsert���ֵ��ֶ�......
        Exit Function
    ElseIf InStr(lngFieldIndex, UCase(strTemp), "DECODE(") > 0 Then
        '��ȡdecode���ֵ��ֶ�......
        Exit Function
    Else
    
        strPrefix = strTemp
    
        'ִ�к�ȡ�õ�strsql���ֽ�Ϊ��test = ��
        strTemp = Trim(Mid(strTemp, lngFieldIndex + 1, 100))
        
        '�������between��䣬��between ��and�����ֱֵ������Ϊ1
        lngBetweenIndex = InStr(UCase(strTemp), "BETWEEN")
        If lngBetweenIndex > 0 Then
            strBetween = Mid(strTemp, lngBetweenIndex + Len("BETWEEN"))
            If InStr(UCase(strBetween), "AND") > 0 Then
                GetParameterField = "[671EABDC7BAB4D9896312E7B28636F37]"
                Exit Function
            End If
        End If
                
        strPrefix = Mid(strPrefix, 1, lngFieldIndex - 1)
        strPrefix = Trim(Mid(strPrefix, InStrRev(strPrefix, " "), 100))
        
        
        '�������ִ�к󣬽�ȡ���ֶ���
        
        lngFieldIndex = InStr(strTemp, " ")
        
        If lngFieldIndex > 0 Then
            strTemp = Mid(strTemp, 1, lngFieldIndex - 1)
        Else
            strTemp = Mid(strTemp, 1, Len(strTemp) - 1)
        End If
    End If
    
    GetParameterField = strPrefix & "." & strTemp
End Function

Private Sub Form_Unload(Cancel As Integer)
    Dim objFree As Object
    
    For Each objFree In txtObj
        If Not objFree Is Nothing Then
            If objFree.Index <> 0 Then Unload objFree
        End If
    Next
    
    For Each objFree In cbxObj
        If Not objFree Is Nothing Then
            If objFree.Index <> 0 Then Unload objFree
        End If
    Next
    
    For Each objFree In dtpObj
        If Not objFree Is Nothing Then
            If objFree.Index <> 0 Then Unload objFree
        End If
    Next
    
    For Each objFree In lstObj
        If Not objFree Is Nothing Then
            If objFree.Index <> 0 Then Unload objFree
        End If
    Next
    
    Set mobjReg = Nothing
    Set mobjLastControl = Nothing
    Set mrsCfgData = Nothing
    
    Call sctExecute.Reset
End Sub

Private Sub cbxObj_Click(Index As Integer)
'����������ֵ���û��ı����Ҫ���������ݼ���
On Error GoTo errHandle
    Call ControlValChange(cbxObj, Index)
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub dtpObj_Change(Index As Integer)
'���ڿ�����ֵ���û��ı����Ҫ���������ݼ���
On Error GoTo errHandle
    Call ControlValChange(dtpObj, Index)
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub lstObj_Click(Index As Integer)
'��ѡ������ֵ���û��ı����Ҫ���������ݼ���
On Error GoTo errHandle
    Call ControlValChange(lstObj, Index)
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub txtObj_Change(Index As Integer)
'�ı�������ֵ���û��ı����Ҫ���������ݼ���
On Error GoTo errHandle
    Dim i As Long
    Dim strCurControlName As String
    Dim strKey As Variant
    
    Call ControlValChange(txtObj, Index)
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub

Private Sub ControlValChange(objControl As Object, ByVal intIndex As Integer)
'�ؼ�����ֵ���û��ı����Ҫ���������ݼ���
On Error GoTo errHandle
    Dim strCurControlName As String
    Dim strKey As Variant
    
    If Not objControl(intIndex).Visible Then Exit Sub
    
    strCurControlName = objControl(intIndex).tag
    
    For Each strKey In mobjReg.Keys
        If InStr(strKey, strCurControlName) > 0 Then
            Call UpdateInputData(mobjReg(strKey).tag)
        End If
    Next
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub


Private Sub Form_Load()
On Error GoTo errHandle
    Dim rsData As ADODB.Recordset
    Dim strSQL As String
    
    mstrReturnQuery = ""
    mstrInputProTotal = ""
    mstrSchemeQuerySql = ""
    mintEnabledRules = 0
    
    Set mobjLastControl = Nothing
    Set mrsCfgData = Nothing
    
    Set rsData = GetSchemeData(mlngSchemeId)
    
    If rsData Is Nothing Then Exit Sub
    
    If rsData.RecordCount <= 0 Then
        Call MsgBoxD(Me, "δ�ҵ�������Ϣ��������ɽ�����ء�", vbOKOnly, Me.Caption)
        Exit Sub
    End If
    
    mstrSchemeQuerySql = nvl(rsData!��ѯ���)
    mintEnabledRules = Val(nvl(rsData!�Ƿ����ù���))
    
    labMemo.Caption = "˵����" & nvl(rsData!����˵��) 'IIf(Trim(Nvl(rsData!����˵��)) <> "", "˵����" & Nvl(rsData!����˵��), "")
    
    
    
    Set mobjReg = New Scripting.Dictionary
    
        
    Call ConfigFaceInput
    
    Call sctExecute.AddObject("Me", Me, True)
    
    Call LoadInputData
    
    Exit Sub
errHandle:
    If ErrCenter() = 1 Then Resume
End Sub


Private Sub LoadInputData()
'���ؿ�ѡ¼������
On Error GoTo errH
    Dim i As Long
    Dim strDataFrom As String
    Dim strParameters(20) As String
    Dim blnHasInputPar As Boolean
    Dim blnHasPar As Boolean
    Dim rsTemp As ADODB.Recordset
    Dim lngObjOrder As Long
    Dim lngInputType As Long
    Dim strDefaultValue As String
    Dim objInputControl As Object
    Dim strParValues(20) As Variant
    Dim strParField As String
    
    
    If mrsCfgData Is Nothing Then Exit Sub
    If mrsCfgData.RecordCount <= 0 Then Exit Sub
    
    mrsCfgData.MoveFirst
    
    While Not mrsCfgData.EOF
        strDataFrom = nvl(mrsCfgData!������Դ)
        lngObjOrder = Val(nvl(mrsCfgData!¼��˳��))
        strDefaultValue = GetParameterValue(nvl(mrsCfgData!Ĭ��ֵ))
        lngInputType = Val(nvl(mrsCfgData!¼������))
        
        If strDataFrom <> "" Then
            '��ȡ��sqlԴ���������в�������
            blnHasPar = GetParameterNames(strDataFrom, strParameters)
            
            For i = 1 To 20
                strParValues(i) = GetParameterValue(strParameters(i))
                If strParameters(i) <> "" Then
                    If Trim(strParValues(i)) = "" Then    '���¼�������Ϊ�գ���ʹ�ø�����
                        strParField = GetParameterField(strParameters(i), strDataFrom)
                        If strParField <> "" Then
'                            strDataFrom = Replace(strDataFrom, strParameters(i), strParField)
                            strDataFrom = Replace(strDataFrom, strParameters(i), 1)
                            strDataFrom = Replace(strDataFrom, strParField, 1)
                        Else
                            strDataFrom = Replace(strDataFrom, strParameters(i), "[" & i & "]")
                        End If
                    Else
                        strDataFrom = Replace(strDataFrom, strParameters(i), "[" & i & "]")
                    End If
                End If
            Next i
            
            Set rsTemp = zlDatabase.OpenSQLRecord(strDataFrom, "���ÿ�¼����", strParValues(1), strParValues(2), strParValues(3), _
                                    strParValues(4), strParValues(5), strParValues(6), strParValues(7), strParValues(8), _
                                    strParValues(9), strParValues(10), strParValues(11), strParValues(12), strParValues(13), _
                                    strParValues(14), strParValues(15), strParValues(16), strParValues(17), strParValues(18), _
                                    strParValues(19), strParValues(20))
            
            If rsTemp.RecordCount > 0 Then
                Select Case lngInputType
                
                    Case 0
                        '��ȡ�ı�����ʾ������
                        Call SetControlValue(lngInputType, lngObjOrder, rsTemp(0).value)
                        
                        If strDefaultValue <> "" Then
                            Call SetControlValue(lngInputType, lngObjOrder, strDefaultValue)
                        End If
                    Case 1, 2, 3
                        '��ȡ���ڿ���ʾ������
                        Call SetControlValue(lngInputType, lngObjOrder, rsTemp(0).value)
                        
                        If strDefaultValue <> "" Then
                            Call SetControlValue(lngInputType, lngObjOrder, strDefaultValue)
                        End If
                    Case 4
                        '��ȡ��������ʾ������
                        cbxObj(lngObjOrder).Clear
                        
                        While Not rsTemp.EOF
                            cbxObj(lngObjOrder).AddItem rsTemp(0).value
                            rsTemp.MoveNext
                        Wend
                        
                        If strDefaultValue <> "" Then
                            Call SetControlValue(lngInputType, lngObjOrder, strDefaultValue)
                        Else
                            cbxObj(lngObjOrder).ListIndex = 0
                        End If
                    Case 5
                        '��ȡ�ɶ�ѡ�б�����ʾ������
                        lstObj(lngObjOrder).Clear
                        
                        While Not rsTemp.EOF
                            lstObj(lngObjOrder).AddItem rsTemp(0).value
                            
                            If InStr(strDefaultValue, rsTemp(0).value) > 0 Then
                                lstObj(lngObjOrder).Selected(lstObj(lngObjOrder).ListCount - 1) = True
                            End If
                            
                            rsTemp.MoveNext
                        Wend
                End Select
            End If
            
            'ע����Ҫ�����ı��¼��ؼ�
            For i = 1 To 20
                If InStr(mstrInputProTotal, strParameters(i)) > 0 And strParameters(i) <> "" Then
                    '����¼��ֵ�ı����Ҫ��Ӧ�ı�Ŀؼ�
                    Select Case lngInputType

                        Case 0
                            Set objInputControl = txtObj(lngObjOrder)
                        Case 1, 2, 3
                            Set objInputControl = dtpObj(lngObjOrder)
                        Case 4
                            Set objInputControl = cbxObj(lngObjOrder)
                        Case 5
                            Set objInputControl = lstObj(lngObjOrder)
                    End Select

                    Call mobjReg.Add(strParameters(i) & lngObjOrder, objInputControl)
                End If
            Next i
        Else
            '�ж��Ƿ�������Ĭ��ֵ�����������Ĭ��ֵ������Ҫ����Ĭ��ֵ
            If strDefaultValue <> "" Then
                Call SetControlValue(lngInputType, lngObjOrder, strDefaultValue)
            End If
        End If
        
        mrsCfgData.MoveNext
    Wend
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Sub UpdateInputData(ByVal strInputName As String)
'����¼��������ʾ
On Error GoTo errH
    Dim rsTemp As ADODB.Recordset
    Dim strTemp As String
    Dim lngInputType As Long
    Dim lngInputOrder As Long
    Dim strSqlFrom As String
    Dim strParameters(20) As String
    Dim i As Long
    Dim strParValue(20) As Variant
    Dim strField As String
    
    
    If mrsCfgData Is Nothing Then Exit Sub
    If mrsCfgData.RecordCount <= 0 Then Exit Sub
    
    strTemp = Replace(strInputName, "[", "")
    strTemp = Replace(strTemp, "]", "")
    
    '���˳���¼����Ŀ��Ӧ��������Ϣ
    mrsCfgData.Filter = "¼����Ŀ='" & strTemp & "'"
    
    If mrsCfgData.RecordCount <= 0 Then Exit Sub
    
    lngInputType = Val(nvl(mrsCfgData!¼������))
    lngInputOrder = Val(nvl(mrsCfgData!¼��˳��))
    strSqlFrom = nvl(mrsCfgData!������Դ)
    
    If strSqlFrom = "" Then Exit Sub
    
    '��ȡ��sqlԴ���������в�������
    Call GetParameterNames(strSqlFrom, strParameters)
    
    For i = 1 To 20
        strParValue(i) = GetParameterValue(strParameters(i))
        If strParameters(i) <> "" Then
            If Trim(strParValue(i)) = "" Then '���¼�������Ϊ�գ���ʹ�ø�����
                strField = GetParameterField(strParameters(i), strSqlFrom)
                If strField <> "" Then
'                    strSqlFrom = Replace(strSqlFrom, strParameters(i), strField)
                    strSqlFrom = Replace(strSqlFrom, strParameters(i), 1)
                    strSqlFrom = Replace(strSqlFrom, strField, 1)
                Else
                    strSqlFrom = Replace(strSqlFrom, strParameters(i), "[" & i & "]")
                End If
            Else
                strSqlFrom = Replace(strSqlFrom, strParameters(i), "[" & i & "]")
            End If
        End If
    Next i
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSqlFrom, "���ÿ�¼����", strParValue(1), strParValue(2), strParValue(3), _
                            strParValue(4), strParValue(5), strParValue(6), strParValue(7), strParValue(8), _
                            strParValue(9), strParValue(10), strParValue(11), strParValue(12), strParValue(13), _
                            strParValue(14), strParValue(15), strParValue(16), strParValue(17), strParValue(18), _
                            strParValue(19), strParValue(20))
                
    
    Select Case lngInputType
    
        Case 0
            If rsTemp.RecordCount <= 0 Then Exit Sub
            Call SetControlValue(lngInputType, lngInputOrder, rsTemp(0).value)
            
        Case 1, 2, 3
            If rsTemp.RecordCount <= 0 Then Exit Sub
            Call SetControlValue(lngInputType, lngInputOrder, rsTemp(0).value)
            
        Case 4
            cbxObj(lngInputOrder).Clear
            If rsTemp.RecordCount <= 0 Then Exit Sub
            
            While Not rsTemp.EOF
                cbxObj(lngInputOrder).AddItem rsTemp(0).value
                rsTemp.MoveNext
            Wend
            
            If cbxObj(lngInputOrder).ListCount > 0 Then cbxObj(lngInputOrder).ListIndex = 0
        Case 5
            lstObj(lngInputOrder).Clear
            If rsTemp.RecordCount <= 0 Then Exit Sub
            
            While Not rsTemp.EOF
                lstObj(lngInputOrder).AddItem rsTemp(0).value
                rsTemp.MoveNext
            Wend
    End Select
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Sub SetControlValue(ByVal lngInputType As Long, ByVal lngObjOrder As Long, ByVal strValue As String)
'�Կؼ����ı�����value���Ը�ֵ
On Error Resume Next
    Dim i As Long
    
    Select Case lngInputType
        Case 0
            txtObj(lngObjOrder).Text = strValue
        Case 1, 2, 3
            dtpObj(lngObjOrder).value = strValue
        Case 4
            cbxObj(lngObjOrder).Text = strValue
        Case 5
            For i = 0 To lstObj(lngObjOrder).ListCount - 1
                If lstObj(lngObjOrder).list(i) = strValue Then
                    lstObj(lngObjOrder).Selected(i) = True
                End If
            Next i
    End Select
End Sub


Private Function GetParameterNames(ByVal strSqlFrom As String, ByRef strParameters() As String) As Boolean
'�ж�����Դsql����Ƿ��������
    Dim strTemp As String
    Dim lngStart As Long, lngEnd As Long
    Dim lngParCount As Long
    
    strTemp = strSqlFrom
    lngStart = InStr(strTemp, "[")
    lngEnd = InStr(strTemp, "]")
    
    GetParameterNames = False
'    blnHasInputPar = False
    
    If lngStart <= 0 Or lngEnd <= 0 Then Exit Function
    
    lngParCount = 0
    
    'ѭ����ȡ���еĲ�������
    While lngStart > 0 And lngEnd > 0
        
        lngParCount = lngParCount + 1
        
        strTemp = Mid(strTemp, lngStart, 1024)
        lngEnd = InStr(strTemp, "]")
        
        strParameters(lngParCount) = Mid(strTemp, 1, lngEnd)
        
'        If InStr(mstrInputProTotal, strParameters(lngParCount)) > 0 Then
'            blnHasInputPar = True
'        End If
        
        strTemp = Mid(strTemp, lngEnd + 1, 1024)
        
        lngStart = InStr(strTemp, "[")
        lngEnd = InStr(strTemp, "]")
    Wend
       
    GetParameterNames = IIf(lngParCount > 0, True, False)
End Function


Private Sub ConfigFaceInput()
'���ý���¼��
On Error GoTo errH
    
    Dim strSQL As String
    
    strSQL = "select ¼����Ŀ,¼������,¼��˳��,Ĭ��ֵ,������Դ from Ӱ���ѯ���� where ����Id=[1] order by ¼��˳��"
    
    Set mrsCfgData = zlDatabase.OpenSQLRecord(strSQL, "��ȡ��ѯ����", mlngSchemeId)
    If mrsCfgData.RecordCount <= 0 Then Exit Sub
    
    While Not mrsCfgData.EOF
        If mstrInputProTotal <> "" Then mstrInputProTotal = mstrInputProTotal & ","
        mstrInputProTotal = mstrInputProTotal & "[" & nvl(mrsCfgData!¼����Ŀ) & "]"
        
'        Call CreateInputControl(Nvl(mrsCfgData!¼����Ŀ), Val(Nvl(mrsCfgData!¼������)), GetParameterValue(Nvl(mrsCfgData!Ĭ��ֵ)), Val(Nvl(mrsCfgData!¼��˳��)))
        Call CreateInputControl(nvl(mrsCfgData!¼����Ŀ), Val(nvl(mrsCfgData!¼������)), "", Val(nvl(mrsCfgData!¼��˳��)))
        mrsCfgData.MoveNext
    Wend
    
    
    If Not mobjLastControl Is Nothing Then
        framButton.Left = -45
        framButton.Width = Me.ScaleWidth + 90
    
        framButton.Top = mobjLastControl.Top + mobjLastControl.Height + 120 + 45
        Me.Height = framButton.Top + framButton.Height + 400 - 45
        
        labError.Visible = False
    Else
        labError.Visible = True
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Private Function GetParameterValue(ByVal strParameterName As String) As Variant
    Dim j As Long
    Dim objInputCon As Object

    GetParameterValue = ""
        
    If strParameterName = "" Then Exit Function
    If Not IsParameterFormat(strParameterName) Then
        '������ǲ�����ʽ���������ֱ����Ĭ��ֵ���ô��������ֵ������Ĭ��ֵ���õ��ǡ�2012-03-05������û�в��á�[��ǰʱ��]����ʽ
        GetParameterValue = strParameterName
        Exit Function
    End If
    
    Select Case strParameterName
        Case "[��ǰ����]"
            GetParameterValue = date
            Exit Function
        Case "[��ǰʱ��]"
            GetParameterValue = Now
            Exit Function
        Case "[��ǰ�û�ID]"
            GetParameterValue = UserInfo.ID
            Exit Function
        Case "[��ǰ����ID]"
            If mlngDepartId <= 0 Then
                GetParameterValue = ""
            Else
                GetParameterValue = mlngDepartId
            End If
            Exit Function
        Case "[��ǰϵͳ���]"
            GetParameterValue = glngSys
            Exit Function
        Case "[��ǰģ����]"
            GetParameterValue = mlngModule
            Exit Function
        Case Else
            '��ȡ�ı����Ӧ��ֵ
           For Each objInputCon In txtObj
               If Not objInputCon Is Nothing Then
                   If objInputCon.tag = strParameterName And objInputCon.Index <> 0 Then
                       GetParameterValue = objInputCon.Text
                       Exit Function
                   End If
               End If
           Next
           
           '��ȡ���ڿ��Ӧ��ֵ
           For Each objInputCon In dtpObj
               If Not objInputCon Is Nothing Then
                   If objInputCon.tag = strParameterName And objInputCon.Index <> 0 Then
                       GetParameterValue = objInputCon.value
                       Exit Function
                   End If
               End If
           Next
           
           
           '��ȡ�������ֵ
           For Each objInputCon In cbxObj
               If Not objInputCon Is Nothing Then
                   If objInputCon.tag = strParameterName And objInputCon.Index <> 0 Then
                       GetParameterValue = objInputCon.Text
                       Exit Function
                   End If
               End If
           Next
           
           '��ȡ�ɶ�ѡ�б����ֵ
           For Each objInputCon In lstObj
               If Not objInputCon Is Nothing Then
                   If objInputCon.tag = strParameterName And objInputCon.Index <> 0 Then
                       For j = 0 To objInputCon.ListCount - 1
                           If objInputCon.Selected(j) Then
                               If GetParameterValue <> "" Then GetParameterValue = GetParameterValue & ","
                               GetParameterValue = GetParameterValue & objInputCon.list(j)
                           End If
                       Next j
                       
                       Exit Function
                   End If
               End If
           Next
    End Select
    
    '��ǰ��Ĵ����У�����ҵ���Ӧ�Ĳ������ͻ�ֱ�ӽ�ֵ���Ǻ��������أ����ִ�е����˵��û���ҵ���Ӧ���������������Զ���ű��硰[now-1]��
    
    'ִ�нű�����
    GetParameterValue = RunScripting(strParameterName)
End Function

Private Function RunScripting(ByVal strScript As String) As String
'ִ��vbs�ű�
    Dim strFormatScript As String

    strFormatScript = Replace(Replace(strScript, "[", ""), "]", "")

On Error GoTo errHandle
    RunScripting = sctExecute.Eval(strFormatScript)
    Exit Function
errHandle:
    strFormatScript = "function return()" & vbCrLf & strFormatScript & " end function"
    Call sctExecute.AddCode(strFormatScript)
    
    RunScripting = sctExecute.Run("return")
End Function


Private Function IsParameterFormat(ByVal strData As String) As Boolean
'�ж������Ƿ�Ϊ��������
    IsParameterFormat = False
    
    If strData = "" Then Exit Function
    If Left(strData, 1) <> "[" Or Right(strData, 1) <> "]" Then Exit Function
    
    IsParameterFormat = True
End Function

Private Sub CreateInputControl(ByVal strName As String, ByVal lngInputType As Long, _
    ByVal strDefault As String, ByVal lngOrder As Long)
'����¼�����
    
    Select Case lngInputType
        Case 0
            '�����ı������
            Load txtObj(lngOrder)
            
'            Call SetControlValue(lngInputType, lngOrder, strDefault)
            txtObj(lngOrder).tag = "[" & strName & "]"
            
            txtObj(lngOrder).Left = 1950
            
            If mobjLastControl Is Nothing Then
                txtObj(lngOrder).Top = 1080 '315
            Else
                txtObj(lngOrder).Top = mobjLastControl.Top + mobjLastControl.Height + 120
            End If
            
            Set mobjLastControl = txtObj(lngOrder)
            
        Case 1, 2, 3
            '�������ڿ����
            Load dtpObj(lngOrder)
                        
            dtpObj(lngOrder).Format = dtpCustom
            dtpObj(lngOrder).CustomFormat = IIf(lngInputType = 1, "yyyy-MM-dd", IIf(lngInputType = 2, "HH:mm", "yyyy-MM-dd HH:mm"))
            
'            Call SetControlValue(lngInputType, lngOrder, strDefault)
            dtpObj(lngOrder).tag = "[" & strName & "]"
            
            dtpObj(lngOrder).Left = 1950
            
            If mobjLastControl Is Nothing Then
                dtpObj(lngOrder).Top = 1080 '315
            Else
                dtpObj(lngOrder).Top = mobjLastControl.Top + mobjLastControl.Height + 120
            End If
            
            Set mobjLastControl = dtpObj(lngOrder)
            
        Case 4
            '����������
            Load cbxObj(lngOrder)
            
'            Call SetControlValue(lngInputType, lngOrder, strDefault)
            cbxObj(lngOrder).tag = "[" & strName & "]"
            
            cbxObj(lngOrder).Left = 1950
            
            If mobjLastControl Is Nothing Then
                cbxObj(lngOrder).Top = 1080 '315
            Else
                cbxObj(lngOrder).Top = mobjLastControl.Top + mobjLastControl.Height + 120
            End If
            
            Set mobjLastControl = cbxObj(lngOrder)
        Case 5
            '�����ɶ�ѡ���б���
            Load lstObj(lngOrder)
            
            lstObj(lngOrder).tag = "[" & strName & "]"
            
            lstObj(lngOrder).Left = 1950
            
            If mobjLastControl Is Nothing Then
                lstObj(lngOrder).Top = 1080 '315
            Else
                lstObj(lngOrder).Top = mobjLastControl.Top + mobjLastControl.Height + 120
            End If
            
            Set mobjLastControl = lstObj(lngOrder)
    End Select
    
    mobjLastControl.Visible = True
    
    '����Label����
    Load labObj(lngOrder)
    
    labObj(lngOrder).Caption = strName
    labObj(lngOrder).Left = mobjLastControl.Left - labObj(lngOrder).Width - 120
    labObj(lngOrder).Top = mobjLastControl.Top + 60
    labObj(lngOrder).Visible = True
End Sub

