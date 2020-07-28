Attribute VB_Name = "mReport"
Option Explicit

Public pReport_CheckViewName As String
Public pReport_ResultName As String
Public pReport_AdviceName As String

Public preWinProc As Long
Public fReport As frmReportWord
Public fReportElement As frmReportElement
Public glngEelmentWinProc As Long

Public Const ReportViewType_������� = "�������"
Public Const ReportViewType_������ = "������"
Public Const ReportViewType_���� = "����"
Public Const ReportViewType_������� = "�������"
Public Const ReportViewType_��첿λ = "��첿λ"

Public Type TWordLine
    lngWordID As Long
    strOutlineName As String
    strContext As String
End Type

Public Type TPreDefKey   '�����ؼ���
    KeyStart As String
    KeyEnd As String
End Type


'ǩ��״̬
Public Enum TReportSignLevel
    cprSL_�հ� = 0              'δǩ��
    cprSL_���� = 1              '����ҽʦǩ��
    cprSL_���� = 2              '����ҽʦǩ��
    cprSL_���� = 3              '����ҽʦǩ��
    cprSL_���� = 4              '���ߣ�ǩ�����𲻰�����ֻ��ʾ��Ա��������ְ�ƣ��Ա���������ҽʦ
End Enum


Public gobjRichEPR As zlRichEPR.cRichEPR
Public gobjReport As zlRichEPR.cDockReport
Public gobjEmr As Object    '���Ӳ���


'################################################################################################################
'## ���ܣ�  ��ָ�����ļ����浽ָ����¼��LOB�ֶ���
'##
'## ������  Action      :�������ͣ����������ǲ����ĸ���
'##         KeyWord     :ȷ�����ݼ�¼�Ĺؼ��֣����Ϲؼ����Զ��ŷָ�(��5-���Ӳ�����ʽΪ����)
'##         strFile     :�û�ָ����ŵ��ļ�������ָ��ʱ��ȡ��ǰ·�������ļ���
'##
'## ���أ�  �ɹ�����True��ʧ�ܷ���False
'##
'## ˵����  Actionȡֵ˵����
'##         0-�������ͼ�Σ�1-�����ļ���ʽ��2-�����ļ�ͼ�Σ�3-�������ĸ�ʽ��4-��������ͼ�Σ�5-���Ӳ�����ʽ��6-���Ӳ���ͼ�Σ�
'################################################################################################################
Public Function zlSaveLob(ByVal Action As Long, ByVal KeyWord As String, _
    ByVal strFile As String, ByRef arrSQL() As String) As Boolean
    Dim conChunkSize As Integer
    Dim lngFileSize As Long, lngCurSize As Long, lngModSize As Long
    Dim lngBlocks As Long, lngFileNum As Long
    Dim lngCount As Long, lngBound As Long
    Dim strSQL As String
    Dim aryChunk() As Byte, aryHex() As String, strtext As String
    
    lngFileNum = FreeFile
    Open strFile For Binary Access Read As lngFileNum
    lngFileSize = LOF(lngFileNum)
    
    err = 0: On Error GoTo errHand
    
    conChunkSize = 2000
    lngModSize = lngFileSize Mod conChunkSize
    lngBlocks = lngFileSize \ conChunkSize - IIf(lngModSize = 0, 1, 0)
    For lngCount = 0 To lngBlocks
        If lngCount = lngFileSize \ conChunkSize Then
            lngCurSize = lngModSize
        Else
            lngCurSize = conChunkSize
        End If
        
        ReDim aryChunk(lngCurSize - 1) As Byte
        ReDim aryHex(lngCurSize - 1) As String
        Get lngFileNum, , aryChunk()
        For lngBound = LBound(aryChunk) To UBound(aryChunk)
            aryHex(lngBound) = Hex(aryChunk(lngBound))
            If Len(aryHex(lngBound)) = 1 Then aryHex(lngBound) = "0" & aryHex(lngBound)
        Next
        
        strtext = Join(aryHex, "")
        strSQL = "Zl_Lob_Append(" & Action & ",'" & KeyWord & "','" & strtext & "'," & IIf(lngCount = 0, 1, 0) & ")"
        
        ReDim Preserve arrSQL(UBound(arrSQL) + 1)
        arrSQL(UBound(arrSQL)) = strSQL
        
'        Call zlDatabase.ExecuteProcedure(strSql, "zlBlobSave")
    Next
    Close lngFileNum
    zlSaveLob = True
    Exit Function

errHand:
    Close lngFileNum
    zlSaveLob = False
End Function


Public Sub PreviewRichReport(objNotify As IEventNotify, _
    ByVal lngModuleNo As Long, ByVal lngDeptId As String, ByVal strPrivs As String, _
    objStudyInfo As clsStudyInfo)
    
    Dim objRichReport As frmRichReportV2
    
    Set objRichReport = New frmRichReportV2
    
    objRichReport.zlInit objNotify, lngModuleNo, lngDeptId, strPrivs
    objRichReport.zlRefresh objStudyInfo.lngAdviceId, objStudyInfo.blnMoved, True
    
    objRichReport.Show 0, objNotify.Owner
    
End Sub

Public Function UpdateReportElement(strReport As String, strKeyType As String, lngKey As Long, strElement As String) As Boolean
    Dim sTMP As String
    Dim i As Long
    Dim j As Long
    Dim lLength As Long
    Dim strNewReport As String
    Dim lngES As Long
    Dim lngEE As Long
    Dim strChar As String
    Dim lulWave As Long
    Dim lulNone As Long
    
    sTMP = strKeyType & "S(" & Format(lngKey, "00000000")
    i = 1
LL1:
    i = InStr(i, strReport, sTMP)
    If i <> 0 Then
        '���Ƿ�ؼ��֣���Ϊ�ؼ��֣��������������ܱ����ġ�
        If ProtectAndHide(strReport, i - 1, i) = False Then
            i = i + 1
            GoTo LL1
        End If
        '�Ѿ��ҵ���ʼ�ؼ��֣���������ַ������滻��Щ�ַ�
        j = i + 16
        lngES = j
        '���ҽ����ؼ���
        sTMP = strKeyType & "E(" & Format(lngKey, "00000000")
LL2:
        j = InStr(j, strReport, sTMP)
        If j <> 0 Then
            '���Ƿ�ؼ��֣���Ϊ�ؼ��֣��������������ܱ����ġ�
            If ProtectAndHide(strReport, j - 1, j) = False Then
                j = j + 1
                GoTo LL2
            End If
            lngEE = j - 1
            '�Ѿ��ҵ������ؼ��֣�˵���м������Ҫ�滻��Ҫ��
            
            '���˵����Ʒ��ţ�\cfN,\highlightN,\v0
            If getElementPos(strReport, lngES, lLength, lngEE, lulWave, lulNone) = True Then
                strNewReport = strReport
                '�ȴ����»����ˣ�ɾ���»����˵��������
                If lulWave <> 0 And lulNone <> 0 Then
                    strNewReport = Left(strNewReport, lulNone) & Right(strNewReport, Len(strNewReport) - lulNone - 7)
                End If
                '�ٴ���Ҫ�����ݣ��滻Ҫ������
                strChar = Mid(strElement, 1, 1)
                If (strChar >= "A" And strChar <= "Z") Or (strChar >= "a" And strChar <= "z") Or IsNumeric(strChar) Or strChar = " " Then
                    strNewReport = Left(strNewReport, lngES) & " " & StrToASC(strElement) & Right(strNewReport, Len(strNewReport) - lngES - lLength)
                Else
                    strNewReport = Left(strNewReport, lngES) & StrToASC(strElement) & Right(strNewReport, Len(strNewReport) - lngES - lLength)
                End If
                If lulWave <> 0 And lulNone <> 0 Then
                    strNewReport = Left(strNewReport, lulWave) & Right(strNewReport, Len(strNewReport) - lulWave - 7)
                End If
                strReport = strNewReport
                UpdateReportElement = True
            End If
        End If
    End If
End Function

Private Function StrToASC(ByVal strIn As String) As String
    '�������ַ���ת��ΪASC��������Ӣ��һ��
    '�Ƚ������ַ�����ת�壺
    strIn = Replace(strIn, Chr(9), "\TAB ")
    strIn = Replace(strIn, Chr(13) + Chr(10), "\par ")
    Dim i As Long, s As String, lsChar As String, lsPart1 As String, lsPart2 As String
    Dim lsCharHex As String
    For i = 1 To Len(strIn)
        lsChar = Mid(strIn, i, 1)
        If lsChar = "?" Then
            lsCharHex = LCase(Hex(Asc(lsChar)))
            If Len(lsCharHex) = 4 Then
                lsCharHex = "\'" + Mid(lsCharHex, 1, 2) + "\'" + Mid(lsCharHex, 3, 2)
            Else
                lsCharHex = lsChar
            End If
            s = s + lsCharHex
        Else
            lsCharHex = LCase(Hex(Asc(lsChar)))
            If Len(lsCharHex) = 4 Then
                lsCharHex = "\'" + Mid(lsCharHex, 1, 2) + "\'" + Mid(lsCharHex, 3, 2)
            Else
                lsCharHex = lsChar
            End If
            s = s + lsCharHex
        End If
    Next
    StrToASC = s
End Function



Private Function getElementPos(ByVal strReport As String, ByRef lStart As Long, ByRef lLength As Long, _
    ByVal lEnd As Long, ByRef lulWave As Long, ByRef lulNone As Long) As Boolean
'    lulWave   '�»����˱��\ulwave�Ŀ�ʼλ��
'    lulNone    '�ر������»��߱��\ulnone�Ŀ�ʼλ��
    '���Ҵ�lStart��ʼ�ģ�Ԫ�������ı��Ŀ�ʼλ�úͳ���
    '���ҺͶ�λԪ���е��»����˱��\ulwave �� �ر������»��߱��\ulnone
    Dim lIndex As Long
    Dim lWordEnd As Long
    Dim blnSearch As Boolean
    Dim strChar As String
    Dim strNextChar As String
    Dim blnInWord As Boolean
    Dim strTemp As String
    
    lIndex = lStart
    blnSearch = True
    blnInWord = True
    
    While (blnSearch And lIndex < lEnd)
        strChar = Mid(strReport, lIndex, 1)
        If strChar = "\" Then       '��һ�������ַ���������һ�������ַ����������ı��Ŀ�ʼ
            strNextChar = Mid(strReport, lIndex + 1, 1)
            If strNextChar = "'" Or strNextChar = "{" Or strNextChar = "}" Or strNextChar = "\" Then     '�ı��Ŀ�ʼ
                '�����ҵ�һ�����Ʒ�
                blnInWord = True
                lStart = lIndex - 1
                While (blnInWord And lIndex <= lEnd)
                    lIndex = lIndex + 1
                    strChar = Mid(strReport, lIndex, 1)
                    If strChar = "\" Then
                        strNextChar = Mid(strReport, lIndex + 1, 1)
                        If strNextChar = "'" Or strNextChar = "{" Or strNextChar = "}" Or strNextChar = "\" Then
                            lIndex = lIndex + 1
                        Else
                            lWordEnd = lIndex - 1
                            blnInWord = False   '�˳�����ѭ��
                        End If
                    End If
                Wend
            Else    '�����ַ��Ŀ�ʼ
                '�����ȡһֱ�������ַ�����
                strTemp = Mid(strReport, lIndex, 1)
                lIndex = lIndex + 1
                While (Mid(strReport, lIndex, 1) <> "\" And Mid(strReport, lIndex, 1) <> " ")
                    strTemp = strTemp & Mid(strReport, lIndex, 1)
                    lIndex = lIndex + 1
                Wend
                If strTemp = "\ulwave" Then
                    lulWave = lIndex - 8
                ElseIf strTemp = "\ulnone" Then
                    lulNone = lIndex - 8
                    blnSearch = False   '�˳�����Ԫ�ص�ѭ��
                End If
            End If
        ElseIf strChar = " " Then   '���Ŀ�ʼ���������ĵ��ַ���Ӣ�ģ���������
            '�����ҵ�һ�����Ʒ�
            blnInWord = True
            lStart = lIndex - 1
            While (blnInWord And lIndex <= lEnd)
                lIndex = lIndex + 1
                strChar = Mid(strReport, lIndex, 1)
                If strChar = "\" Then
                    strNextChar = Mid(strReport, lIndex + 1, 1)
                    If strNextChar = "'" Or strNextChar = "{" Or strNextChar = "}" Or strNextChar = "\" Then
                        lIndex = lIndex + 1
                    Else
                        lWordEnd = lIndex - 1
                        blnInWord = False   '�˳�����ѭ��
                    End If
                End If
            Wend
            
        Else        '�ڲ�����ȷ��RTF�ļ������ز��Ҵ���
            getElementPos = False
            Exit Function
        End If
    Wend
    lLength = lWordEnd - lStart
    If lWordEnd = 0 Then  '˵���ǲ鵽Ҫ�ؽ����ˣ����˳��ģ�û�в��ҵ������ı�
        getElementPos = False
    Else
        getElementPos = True
    End If
End Function


Private Function ProtectAndHide(ByRef strReport As String, ByVal lStart As Long, ByVal lEnd As Long) As Boolean
    Dim lOnPos As Long
    Dim lOffPos As Long
    
    '��ǰ�����غͱ�����ʼ��ǣ�\v��\protect
    lOnPos = InStrRev(strReport, "\v", lStart, vbTextCompare)
    lOffPos = InStrRev(strReport, "\v0", lStart, vbTextCompare)
    If lOnPos > lOffPos And lOnPos <> 0 Then
        '���Һ�������ر��
        lOnPos = InStr(lEnd, strReport, "\v", vbTextCompare)
        lOffPos = InStr(lEnd, strReport, "\v0", vbTextCompare)
        If lOffPos <= lOnPos And lOffPos <> 0 Then
            '����ǰ��ı������
            lOnPos = InStrRev(strReport, "\protect", lStart, vbTextCompare)
            lOffPos = InStrRev(strReport, "\protect0", lStart, vbTextCompare)
            If lOnPos > lOffPos And lOnPos <> 0 Then
                '���Һ���ı������
                lOnPos = InStr(lEnd, strReport, "\protect", vbTextCompare)
                lOffPos = InStr(lEnd, strReport, "\protect0", vbTextCompare)
                If lOffPos <= lOnPos And lOffPos <> 0 Then
                    ProtectAndHide = True
                End If
            End If
        End If
    End If
End Function


Public Function GetReportSignInfo(ByVal lngID As Double, ByRef signInfo As TReportSignInfo) As Boolean
'��ȡ����ǩ����Ϣ
    Dim RS As New ADODB.Recordset
    Dim strSQL As String
    Dim arySignPro() As String
    
On Error GoTo errhandle
    strSQL = "Select ID, ��id, �ļ�id, ������, �������, ��������, �����ı�, Ҫ��ֵ��, Ҫ������, Ҫ�ر�ʾ, Ҫ�ص�λ, ������̬, ��ʼ��, ��ֹ��" & vbNewLine & _
                "From ���Ӳ�������" & vbNewLine & _
                "Where �������� = 8 And ID = [1]"

    Set RS = zlDatabase.OpenSQLRecord(strSQL, "��ѯ����ǩ��", lngID)
    If Not RS.EOF Then
        signInfo.Key = nvl(RS("������"), 0)
        
        signInfo.ID = RS("ID")
        signInfo.�ļ�ID = nvl(RS("�ļ�ID"), 0)
        signInfo.��ID = nvl(RS("��ID"), 0)
        signInfo.������� = nvl(RS("�������"), 0)
        signInfo.���� = Split(nvl(RS("�����ı�"), ";"), ";")(0)
        signInfo.ǩ����Ϣ = nvl(RS("Ҫ��ֵ��"))
        signInfo.ǰ������ = nvl(RS("Ҫ������"))
        signInfo.ǩ������ = nvl(RS("Ҫ�ر�ʾ"))
        signInfo.�������� = nvl(RS("��������"))
        signInfo.��ʼ�� = nvl(RS("��ʼ��"), 1)
        signInfo.��ֹ�� = nvl(RS("��ֹ��"), 0)
        signInfo.ʱ��� = nvl(RS("Ҫ�ص�λ"))
        signInfo.ǩ��ͼƬ = nvl(RS("������̬"), 0) = 1
        
        If UBound(Split(nvl(RS!�����ı�), ";")) > 0 Then
            signInfo.ǩ����ID = Val(Split(nvl(RS("�����ı�")), ";")(1))
        End If
        
        arySignPro = Split(signInfo.�������� & ";;;;;;;", ";")
        
        signInfo.ǩ����ʽ = Val(arySignPro(0))
        signInfo.ǩ������ = Val(arySignPro(1))
        signInfo.֤��ID = Val(arySignPro(2))
        signInfo.��ʾ��ǩ = (Val(arySignPro(3)) = 1)
        signInfo.ǩ��ʱ�� = Format(arySignPro(4), "yyyy-mm-dd hh:mm:ss")
        signInfo.��ʾʱ�� = arySignPro(5)
        signInfo.ǩ��Ҫ�� = CStr(arySignPro(6))
        signInfo.ʱ�����Ϣ = CStr(arySignPro(7))
        
        GetReportSignInfo = True
    Else
        GetReportSignInfo = False
    End If
Exit Function
errhandle:
    GetReportSignInfo = False
    
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function



Public Sub ClipbrdFormat()
On Error Resume Next
   Dim strTmp As String
   
   '�����RTF��ʽ �������ʽ ֻ������������
   If Clipboard.GetFormat(vbCFRTF) Then
       strTmp = Clipboard.GetText
       Clipboard.Clear
       Call Clipboard.SetText(strTmp)
   End If
End Sub
 
Public Function GetReportImagePro(ByVal strPros As String, ByVal strProName As String) As String
    Dim T As Variant, i As Long
    
    T = Split(strPros & ";;;;;;;;;;;;;;;;;;;;", ";")
    
    GetReportImagePro = ""
    
    If UBound(T) > 0 Then
        Select Case UCase(strProName)
            Case "PICTURETYPE"
                GetReportImagePro = CLng(T(0))
            Case "ROW"
                GetReportImagePro = IIf(T(1) = "", 0, T(1))
            Case "COL"
                GetReportImagePro = IIf(T(2) = "", 0, T(2))
            Case "LEFT"
                GetReportImagePro = IIf(T(3) = "", 0, T(3))
            Case "TOP"
                GetReportImagePro = IIf(T(4) = "", 0, T(4))
            Case "WIDTH"
                GetReportImagePro = IIf(T(5) = "", 0, T(5))
            Case "HEIGHT"
                GetReportImagePro = IIf(T(6) = "", 0, T(6))
            Case "ORIGWIDTH"
                GetReportImagePro = IIf(T(7) = "", 0, T(7))
            Case "ORIGHEIGHT"
                GetReportImagePro = IIf(T(8) = "", 0, T(8))
            Case "ZOOMFACTOR"
                GetReportImagePro = IIf(T(9) = "", 0, T(9))
            Case "ZORDER"
                GetReportImagePro = IIf(T(10) = "", 0, T(10))
            Case "PICNAME"
                GetReportImagePro = T(11)
            Case "ADVICEID"
                GetReportImagePro = T(12)
        End Select
    End If
     
End Function

Public Sub FormatWords(ByVal lngWordID As Long, ByVal str�����ı� As String, aryWordLines() As TWordLine)
    Dim strCurContext As String
    Dim aryParsh() As String
    Dim aryLines() As String
    Dim arySplitOutlines() As String
    Dim lngPStart As Long
    Dim lngPEnd As Long
    Dim lngBound As Long
    Dim strPContext As String
    Dim strCurOutlineName As String
    Dim i As Long
    
    
    strCurContext = str�����ı�
    
    '���ȴ���<P>...</P>���
    lngPStart = InStr(strCurContext, "<P>")
    lngPEnd = InStr(strCurContext, "</P>")
    
    ReDim aryParsh(0)
    ReDim aryWordLines(0)
    
    While lngPStart < lngPEnd And lngPStart > 0 And lngPEnd > 0
        strPContext = Mid(strCurContext, lngPStart, lngPEnd + 5)
        
        lngBound = UBound(aryParsh) + 1
        ReDim Preserve aryParsh(lngBound)
        aryParsh(lngBound) = strPContext
        
        strCurContext = Replace(strCurContext, strPContext, "[@_P" & lngBound & "*]")
        
        lngPStart = InStr(strCurContext, "<P>")
        lngPEnd = InStr(strCurContext, "</P>")
    Wend
    
    aryLines = Split(strCurContext & vbCrLf, vbCrLf)
    For i = 0 To UBound(aryLines)
        strPContext = aryLines(i)
        If Trim(strPContext) <> "" Then
            '�ж��Ƿ�������
            strCurOutlineName = ""
            
            If InStr(strPContext, "<<����>>") > 0 Then
                strCurOutlineName = "<<����>>"
            End If
            
            If strCurOutlineName = "" And InStr(strPContext, "<<���>>") > 0 Then
                strCurOutlineName = "<<���>>"
            End If
            
            If strCurOutlineName = "" And InStr(strPContext, "<<����>>") > 0 Then
                strCurOutlineName = "<<����>>"
            End If
            
            If strCurOutlineName <> "" Then
                arySplitOutlines = Split(strPContext, strCurOutlineName)
                
                If Trim(arySplitOutlines(0)) <> "" Then
                    Call FormatSubOutline(lngWordID, arySplitOutlines(0), "", aryParsh, aryWordLines)
                End If
                
                If Trim(arySplitOutlines(1)) <> "" Then
                    Call FormatSubOutline(lngWordID, arySplitOutlines(1), strCurOutlineName, aryParsh, aryWordLines)
                End If
            Else
                
                lngBound = UBound(aryWordLines) + 1
                ReDim Preserve aryWordLines(lngBound)
                
                aryWordLines(lngBound).lngWordID = lngWordID
                aryWordLines(lngBound).strOutlineName = ""
                aryWordLines(lngBound).strContext = RestorePContext(strPContext, aryParsh)
            End If
        End If
    Next
End Sub

Private Sub FormatSubOutline(ByVal lngWordID As String, ByVal strSource As String, ByVal strOutlineName As String, _
            aryParsh() As String, aryWordLines() As TWordLine)
    Dim strCurContext As String
    Dim strCurOutlineName As String
    Dim lngBound As Long
    Dim arySplitOutlines() As String
    
    strCurContext = strSource
    
    strCurOutlineName = ""
    If InStr(strCurContext, "<<����>>") > 0 Then
        strCurOutlineName = "<<����>>"
    End If
    
    If strCurOutlineName = "" And InStr(strCurContext, "<<���>>") > 0 Then
        strCurOutlineName = "<<���>>"
    End If
    
    If strCurOutlineName = "" And InStr(strCurContext, "<<����>>") > 0 Then
        strCurOutlineName = "<<����>>"
    End If
    
    If strCurOutlineName <> "" Then
        arySplitOutlines = Split(strCurContext, strCurOutlineName)
        
        If Trim(arySplitOutlines(0)) <> "" Then
            Call FormatSubOutline(lngWordID, arySplitOutlines(0), strOutlineName, aryParsh, aryWordLines)
        End If
        
        If Trim(arySplitOutlines(1)) <> "" Then
            Call FormatSubOutline(lngWordID, arySplitOutlines(1), strCurOutlineName, aryParsh, aryWordLines)
        End If
    Else
        lngBound = UBound(aryWordLines) + 1
        ReDim Preserve aryWordLines(lngBound)
        
        aryWordLines(lngBound).lngWordID = lngWordID
        aryWordLines(lngBound).strOutlineName = strOutlineName
        aryWordLines(lngBound).strContext = RestorePContext(strCurContext, aryParsh)
    End If
End Sub

Private Function RestorePContext(ByVal strSource As String, aryParsh() As String) As String
    Dim i As Long
    
    RestorePContext = strSource
    
    For i = 1 To UBound(aryParsh)
        RestorePContext = Replace(RestorePContext, "[@_P" & i & "*]", aryParsh(i))
    Next i
    
    RestorePContext = Replace(Replace(RestorePContext, "<P>", ""), "</P>", "")
End Function


'################################################################################################################
'## ���ܣ�  ��ѹ���ļ���ͬĿ¼�ͷŲ�����ѹ�ļ�
'## ������  strZipFile     :ѹ���ļ�
'## ���أ�  ��ѹ�ļ�����ʧ���򷵻��㳤��""
'################################################################################################################
Public Function zlFileUnzip(ByVal strZipFile As String) As String
    Dim strZipPath As String
    Dim objFSO As Scripting.FileSystemObject     'FSO����
    Dim clsUnzip As cUnzip
    
    Set objFSO = New Scripting.FileSystemObject
    Set clsUnzip = New cUnzip
    
    If strZipFile = "" Then Exit Function
    If Dir(strZipFile) = "" Then zlFileUnzip = "": Exit Function
    strZipPath = Left(strZipFile, Len(strZipFile) - Len(Dir(strZipFile)))
    With clsUnzip
        If objFSO.FileExists(strZipPath & "TMP.RTF") Then Call RemoveFile(strZipPath & "TMP.RTF")
    
        .ZipFile = strZipFile
        .UnzipFolder = strZipPath
        .Unzip
    End With
    If Dir(strZipPath & "TMP.RTF") <> "" Then
        zlFileUnzip = strZipPath & "TMP.RTF"
    Else
        zlFileUnzip = ""
    End If
End Function

'################################################################################################################
'## ���ܣ�  ���ļ�ѹ��Ϊ���ļ��ŵ���ͬĿ¼��
'## ������  strFile     :ԭʼ�ļ�
'## ���أ�  ѹ���ļ�����ʧ���򷵻��㳤��""
'################################################################################################################
Public Function zlFileZip(ByVal strFile As String) As String
    Dim strZipFile As String, lngCount As Long
    Dim clsZip As cZip
    
    Set clsZip = New cZip
    If strFile = "" Then Exit Function
    If Dir(strFile) = "" Then zlFileZip = "": Exit Function
    
    lngCount = 0
    Do While True
        strZipFile = Left(strFile, Len(strFile) - Len(Dir(strFile))) & "ZLZIP" & lngCount & ".ZIP"
        If Dir(strZipFile) = "" Then Exit Do
        lngCount = lngCount + 1
    Loop
    
    With clsZip
        .Encrypt = False: .AddComment = False
        .ZipFile = strZipFile
        .StoreFolderNames = False
        .RecurseSubDirs = False
        .ClearFileSpecs
        .AddFileSpec strFile
        .Zip
        If (.Success) Then
            zlFileZip = .ZipFile
        Else
            zlFileZip = ""
        End If
    End With
End Function


' �ӵ��Ӳ����и��ƹ�����һЩ����
'################################################################################################################
'## ���ܣ�  ��ָ����LOB�ֶθ���Ϊ��ʱ�ļ�
'##
'## ������  Action      :�������ͣ����������ǲ����ĸ���
'##         KeyWord     :ȷ�����ݼ�¼�Ĺؼ��֣����Ϲؼ����Զ��ŷָ�(��5-���Ӳ�����ʽΪ����)
'##         strFile     :�û�ָ����ŵ��ļ�������ָ��ʱ��ȡ��ǰ·�������ļ���
'##
'## ���أ�  ������ݵ��ļ�����ʧ���򷵻��㳤��""
'##
'## ˵����  Actionȡֵ˵����
'##         0-�������ͼ�Σ�1-�����ļ���ʽ��2-�����ļ�ͼ�Σ�3-�������ĸ�ʽ��4-��������ͼ�Σ�5-���Ӳ�����ʽ��6-���Ӳ���ͼ�Σ�
'################################################################################################################
Public Function zlBlobRead(ByVal Action As Long, ByVal KeyWord As String, Optional ByRef strFile As String) As String
    
    Const conChunkSize As Integer = 10240
    Dim lngFileNum As Long, lngCount As Long, lngBound As Long
    Dim aryChunk() As Byte, strtext As String
    Dim rsLob As New ADODB.Recordset
    
    err = 0: On Error GoTo errHand
    
    lngFileNum = FreeFile
    If strFile = "" Then
        lngCount = 0
        Do While True
            strFile = App.Path & "\zlBlobFile" & CStr(lngCount) & ".tmp"
            If Len(Dir(strFile)) = 0 Then Exit Do
            lngCount = lngCount + 1
        Loop
    End If
    Open strFile For Binary As lngFileNum
    
    gstrSQL = "Select Zl_Lob_Read(" & Action & ",'" & KeyWord & "'," & "[1]) as Ƭ�� From Dual"
    lngCount = 0
    Do
        Set rsLob = zlDatabase.OpenSQLRecord(gstrSQL, "zlBlobRead", lngCount)
        If rsLob.EOF Then Exit Do
        If IsNull(rsLob.Fields(0).value) Then Exit Do
        strtext = rsLob.Fields(0).value
        
        ReDim aryChunk(Len(strtext) / 2 - 1) As Byte
        For lngBound = LBound(aryChunk) To UBound(aryChunk)
            aryChunk(lngBound) = CByte("&H" & Mid(strtext, lngBound * 2 + 1, 2))
        Next
        
        Put lngFileNum, , aryChunk()
        lngCount = lngCount + 1
    Loop
    Close lngFileNum
    If lngCount = 0 Then Kill strFile: strFile = ""
    zlBlobRead = strFile
    Exit Function

errHand:
    Close lngFileNum
    Kill strFile: zlBlobRead = ""
End Function

'################################################################################################################
'## ���ܣ�  �ж�ָ���û��Ƿ�������ҽʦ
'##
'## ������  lngUserID       ���û�ID
'##         strUserName     ���û���
'##         lngPatiID       ������ID
'##         lngPatiPageID   ����ҳID
'##
'## ˵����  ���ݡ���Ա���еġ�Ƹ�μ���ְ���ֶ�ȷ��ҽ����������סԺҽʦ������ҽʦ������ҽʦ��
'##         �����˱䶯��¼�е�ҽ�����𣬴Ӷ�ȷ����˼���
'################################################################################################################
Public Function GetUserSignLevel(lngUserId As Long, Optional strUserName As String, _
    Optional lngPatiID As Long, Optional lngPatiPageID As Long) As EPRSignLevelEnum
    Dim RS As New ADODB.Recordset, lngR As Long, lngLevel1 As Long, lngLevel2 As Long
    Dim strUserFunc As String
    
    err = 0: On Error GoTo errHand
    If lngUserId = UserInfo.ID Then
        '��ǰ�û�ʱ����������
    Else
        gstrSQL = "Select p.�û��� From �ϻ���Ա�� P Where p.��Աid = [1]"
        Set RS = zlDatabase.OpenSQLRecord(gstrSQL, "mReport", lngUserId)
        If RS.RecordCount <= 0 Then GetUserSignLevel = cprSL_�հ�: Exit Function
        
        strUserFunc = GetPrivFuncByUser(glngSys, 1070, nvl(RS!�û���))
        If InStr(";" & strUserFunc & ";", ";ǩ��Ȩ;") = 0 Then
            GetUserSignLevel = cprSL_�հ�: Exit Function
        End If
    End If
    
    gstrSQL = "select Ƹ�μ���ְ�� from ��Ա�� p where ID=[1]"
    Set RS = zlDatabase.OpenSQLRecord(gstrSQL, "mRichEPR", lngUserId)
    If Not RS.EOF Then
        lngR = nvl(RS("Ƹ�μ���ְ��"), 0)
    End If
    Select Case lngR    '1 ����  2 ����  3 �м�  4 ����/ʦ��  5 Ա/ʿ  9 ��Ƹ
    Case 1: lngLevel1 = cprSL_����
    Case 2: lngLevel1 = cprSL_����
    Case 3: lngLevel1 = cprSL_����
    Case Else: lngLevel1 = cprSL_����
    End Select
    RS.Close
    
    If lngPatiID > 0 Then
        gstrSQL = "Select ����ҽʦ, ����ҽʦ, ����ҽʦ " & _
            " From ���˱䶯��¼ " & _
            " Where ����ID = [1] And ��ҳID = [2] And (��ֹʱ�� Is Null Or ��ֹԭ�� = 1) " & _
            "       And ��ʼʱ�� Is Not Null And Nvl(���Ӵ�λ, 0) = 0"
        Set RS = zlDatabase.OpenSQLRecord(gstrSQL, "cEPRDocument", lngPatiID, lngPatiPageID)
        If RS.EOF Then
            lngLevel2 = cprSL_����
        Else
            If RS.Fields("����ҽʦ") = IIf(strUserName = "", UserInfo.����, strUserName) Then
                lngLevel2 = cprSL_����
            ElseIf RS.Fields("����ҽʦ") = IIf(strUserName = "", UserInfo.����, strUserName) Then
                lngLevel2 = cprSL_����
            Else
                lngLevel2 = cprSL_����
            End If
        End If
    End If
    GetUserSignLevel = IIf(lngLevel1 >= lngLevel2, lngLevel1, lngLevel2)
    Exit Function

errHand:
    GetUserSignLevel = cprSL_�հ�
End Function

'################################################################################################################
'## ���ܣ�  ���������ı�����ָ���ؼ�������Ķ�λ��Ϣ
'##
'## ������  edtThis         :   IN  ���༭�ؼ�
'##         strKeyType      :   IN  �������ؼ������ơ�ȡֵΪ��"O"��"P"��"T"��"E"��"U"
'##         lngKey           :   IN  �����������ҵĹؼ���ID�š�
'##         lngKSS��lngKSE  :   OUT ���ֱ��ʾ��ʼ�ؼ��ֵĿ�ʼλ�úͽ���λ�ã�
'##         lngKES��lngKEE  :   OUT ���ֱ��ʾ��ֹ�ؼ��ֵĿ�ʼλ�úͽ���λ�ã�
'##         blnNeeded:      :   OUT ���Ƿ��Ǳ�������
'##
'## ���أ�  ����ҵ��ùؼ��־���λ�ã��򷵻�True�����򷵻�False
'################################################################################################################
Public Function FindKey(ByRef edtThis As Object, _
        ByRef strKeyType As String, _
        ByRef lngKey As Long, _
        ByRef lngKSS As Long, _
        ByRef lngKSE As Long, _
        ByRef lngKES As Long, _
        ByRef lngKEE As Long, _
        ByRef blnNeeded As Boolean) As Boolean
        
    Dim i As Long, j As Long
    Dim sTMP As String
    Dim sText As String     '��������.Text���ԣ������һ���ַ�������������ʱ�俪֧��
    
    sTMP = strKeyType & "S(" & Format(lngKey, "00000000")
    With edtThis
        sText = .Text   'ֻ��ȡ.Text����1�Σ�����
        i = 1
LL1:
        i = InStr(i, sText, sTMP)
        If i <> 0 Then
            '���Ƿ��ǹؼ���
            If .TOM.TextDocument.range(i - 1, i).Font.hidden = False Then   '��Ϊ�ؼ��֣��������������ܱ����ġ�
                i = i + 1
                GoTo LL1
            End If
            '���ҵ���ʼ�ؼ���
            
            '���ҽ����ؼ���
            j = i + 16
LL2:
            sTMP = strKeyType & "E(" & Format(lngKey, "00000000")
            j = InStr(j, sText, sTMP)
            If j <> 0 Then
                '���Ƿ��ǹؼ���
                If .TOM.TextDocument.range(j - 1, j).Font.hidden = False Then
                    j = j + 1
                    GoTo LL2
                End If
                '�ҵ������ؼ���
                strKeyType = strKeyType
                lngKSS = i - 1 'ת��Ϊ0��ʼ������λ�á�
                lngKSE = i + 15
                lngKES = j - 1
                lngKEE = j + 15
                blnNeeded = -Val(.TOM.TextDocument.range(i + 11, i + 12))
                FindKey = True
            End If
        End If
    End With
End Function


'################################################################################################################
'##  Ԥ������Ƕ�ؼ��ֳ�ʼ��
'################################################################################################################
Private Function GetPreDefinedKeys() As TPreDefKey()
    Dim aryPreDefKey(1 To 6) As TPreDefKey
    
    aryPreDefKey(1).KeyStart = "OS"
    aryPreDefKey(1).KeyEnd = "OE"
    aryPreDefKey(2).KeyStart = "PS"
    aryPreDefKey(2).KeyEnd = "PE"
    aryPreDefKey(3).KeyStart = "ES"
    aryPreDefKey(3).KeyEnd = "EE"
    aryPreDefKey(4).KeyStart = "TS"
    aryPreDefKey(4).KeyEnd = "TE"
    aryPreDefKey(5).KeyStart = "SS"
    aryPreDefKey(5).KeyEnd = "SE"
    aryPreDefKey(6).KeyStart = "DS"
    aryPreDefKey(6).KeyEnd = "DE"
    
    GetPreDefinedKeys = aryPreDefKey
End Function


'################################################################################################################
'## ���ܣ�  �жϸ���λ���Ƿ����κ�һ���ؼ��ֶ�֮�䣬����ǣ������ؼ������λ�ú�ID��
'##
'## ������  edtThis         :   IN  ���༭�ؼ�
'##         lngCurPosition  :   OUT ��ָ���ĵ�ǰλ��
'##         strKeyType      :   OUT �������ؼ������ơ�ȡֵΪ��"O"��"P"��"T"��"E"��"U"
'##         lngKey          :   OUT �����������ҵĹؼ���Key��
'##         lngKSS��lngKSE  :   OUT ���ֱ��ʾ��ʼ�ؼ��ֵĿ�ʼλ�úͽ���λ�ã�
'##         lngKES��lngKEE  :   OUT ���ֱ��ʾ��ֹ�ؼ��ֵĿ�ʼλ�úͽ���λ�ã�
'##         blnNeeded:      :   OUT ���Ƿ��Ǳ�������
'##
'## ���أ�  ���������ĳ���ؼ��ֶ�֮�䣬�򷵻�True�����򷵻�False
'################################################################################################################
Private Function IsBetweenAnyKeys(ByRef edtThis As Object, _
    ByRef lngCurPosition As Long, _
    ByRef strKeyType As String, _
    ByRef lngKSS As Long, _
    ByRef lngKSE As Long, _
    ByRef lngKES As Long, _
    ByRef lngKEE As Long, _
    ByRef lngKey As Long, _
    ByRef blnNeeded As Boolean) As Boolean
    

    '����������ʹ�� Instr() �� InstrRev() ���в��ң�
    Dim n As Long, i As Long, j As Long, k As Long
    Dim lFirst As Long
    Dim sText As String     '��������.Text���ԣ������һ���ַ�������������ʱ�俪֧��
    Dim aryPreDefKey() As TPreDefKey
    
    strKeyType = ""
    lngKSS = 0
    lngKSE = 0
    lngKES = 0
    lngKEE = 0
    lngKey = 0
    blnNeeded = False

    With edtThis
        sText = .Text   'ֻ��ȡ.Text����1�Σ�����
        aryPreDefKey = GetPreDefinedKeys()
        
        For n = 1 To UBound(aryPreDefKey)     '�� 5 �Ա����ؼ���
            '���Ƿ��ǹؼ���
            i = IIf(lngCurPosition = 0, 1, lngCurPosition)
LL1:
            i = InStr(i, sText, aryPreDefKey(n).KeyEnd)    '�����������β�ؼ���
            If i <> 0 Then
                If .range(i - 1, i).Font.hidden = False Then   '��Ϊ�ؼ��֣��������������ܱ����ġ�
                    i = i + 1
                    GoTo LL1
                End If
                j = IIf(lngCurPosition = 0, 1, lngCurPosition)
LL2:
                j = InStr(j, sText, aryPreDefKey(n).KeyStart) '���ҵ���β�ؼ��֣�����ͬ���Ŀ�ʼ�ؼ���
                If j <> 0 Then
                    If .range(j - 1, j).Font.hidden = False Then
                        j = j + 1
                        GoTo LL2
                    End If
                End If
                If (j = 0) Or (j > 0 And i < j) Then '���ڹؼ��ֶ�֮��
                    k = lngCurPosition
LL3:
                    k = InStrRev(sText, aryPreDefKey(n).KeyStart, k, vbTextCompare)    '��ƥ��Ŀ�ʼ�ؼ���
                    If k <> 0 Then
                        If .range(k - 1, k).Font.hidden = False Then
                            k = k - 1
                            GoTo LL3
                        End If
                        strKeyType = Left(aryPreDefKey(n).KeyStart, 1)
                        lngKSS = k - 1
                        lngKSE = k + 15
                        lngKES = i - 1
                        lngKEE = i + 15
                        lngKey = Val(.range(k + 2, k + 10))
                        blnNeeded = -Val(.range(k + 11, k + 12))
                        IsBetweenAnyKeys = True
                        Exit For
                    End If
                End If
            End If
        Next n
    End With
End Function

Public Function InsertIntoEditor(ByRef edtThis As Object, signInfo As TReportSignInfo, _
    Optional ByVal lngStartPos As Long = -1, Optional ByVal blnForceInsert As Boolean = False) As Boolean
    '******************************************************************************************************************
    '���ܣ� ����ָ������ǩ����Editor��
    '������ edtThis         :��ǰ�ı༭���ؼ�
    '       lngStartPos     :��ǰλ��
    '       blnForceInsert  :�Ƿ�ǿ�Ʋ��룬���޸�Ҫ��ʱ���ǰ�󶼱�������ʱ��Ҫǿ�Ʋ���
    '���أ�
    '******************************************************************************************************************
    
    Dim sType As String, lSS As Long, lSE As Long, lES As Long, lEE As Long, lKey As Long, bInKeys As Boolean, bNeeded As Boolean
    Dim blnForce As Boolean
    Dim lngLen As Long
    Dim strTmp As String
    Dim strtext As String
    Dim intLoop As Integer
    Dim lESS As Long, lESE As Long, lEES As Long, lEEE As Long
    Dim blnNeeded As Boolean
    Dim blnFinded As Boolean
    
    '���ǩ������Ϊ�գ�Ҳ�˳�
    If Trim(signInfo.����) = "" Then Exit Function
    
    '�γ�ǩ����ʾ����
    strTmp = Format(signInfo.Key, "00000000") & ",0,0)"
    strtext = signInfo.ǰ������ & signInfo.���� & IIf(signInfo.��ʾ��ǩ, "����ǩ��_____________", "")
    strtext = strtext & IIf(Trim(signInfo.��ʾʱ��) = "", "", "��" & Format(signInfo.ǩ��ʱ��, signInfo.��ʾʱ��))
    lngLen = Len(strtext)
    
    '���û�ж�Ӧ��ǩ��Ҫ�أ���ǩ����ǰ���λ�ô�
    '------------------------------------------------------------------------------------------------------------------
    If lngStartPos = -1 Then lngStartPos = edtThis.Selection.StartPos
    
    bInKeys = IsBetweenAnyKeys(edtThis, lngStartPos + 1, sType, lSS, lSE, lES, lEE, lKey, bNeeded)
    
    '��֤���ܲ���ؼ����ڲ�
    If bInKeys Then
        InsertIntoEditor = False
        Exit Function
    End If
        
    If blnForceInsert = False _
        And edtThis.range(lngStartPos, lngStartPos).Font.ForeColor = &H662200 _
        And edtThis.range(lngStartPos, lngStartPos).Font.Protected Then
        Exit Function
    End If
    
    With edtThis
        .Freeze
        
        blnForce = .ForceEdit
        
        .ForceEdit = True
        
        .range(lngStartPos, lngStartPos).Font.Protected = False
        .range(lngStartPos, lngStartPos).Font.hidden = False
        
        .range(lngStartPos, lngStartPos).Text = "SS(" & strTmp & strtext & "SE(" & strTmp
            
        .range(lngStartPos, lngStartPos + 32 + lngLen).Font.Protected = True
        .range(lngStartPos, lngStartPos + 16).Font.hidden = True
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.hidden = False
        'ɾ����
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.Strikethrough = (signInfo.��ֹ�� > 0)
        '�»���
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.Underline = IIf(signInfo.���� = "", 8, cprNone)
        'ǰ��ɫ
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.ForeColor = GetCharColor(signInfo.��ʼ��, signInfo.��ֹ�� + 1)
        '����ɫ
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.BackColor = &HD5FEFF
        .range(lngStartPos + 16 + lngLen, lngStartPos + 32 + lngLen).Font.hidden = True
        lngStartPos = lngStartPos + 32 + lngLen

        If signInfo.ǩ��Ҫ�� <> "" Then '��ǩ��Ҫ��ʱ��궨λ��Ҫ�������ΪҪ�ر�����
            lngStartPos = lngStartPos + 32 + lngLen
        End If

        .range(lngStartPos, lngStartPos).Selected
        
        .ForceEdit = blnForce
        .UnFreeze
    End With

    InsertIntoEditor = True
End Function

'################################################################################################################
'## ���ܣ�  �ӱ༭����ɾ��ǩ����
'##
'## ������  edtThis         :��ǰ�ı༭���ؼ�
'################################################################################################################
Public Function DeleteFromEditor(ByRef edtThis As Object, signInfo As TReportSignInfo) As Boolean
    '��������Ҫ�ر༭���
    Dim strTmp As String, lngKey As Long, blnForce As Boolean
    Dim lKSS As Long, lKSE As Long, lKES As Long, lKEE As Long, lKey As Long
    Dim bFinded As Boolean, sKeyType As String, bNeeded As Boolean

    bFinded = FindKey(edtThis, "S", Val(signInfo.Key), lKSS, lKSE, lKES, lKEE, bNeeded)
    If bFinded Then
        
        With edtThis
            .Freeze
            blnForce = .ForceEdit
            .ForceEdit = True
            
            .range(lKSS, lKEE) = ""
            
            .ForceEdit = blnForce
            .UnFreeze
        End With
                    
        DeleteFromEditor = True
    Else
        DeleteFromEditor = False
    End If
End Function

Private Function GetCharColor(ByVal lng��ʼ�� As Long, ByVal lng��ֹ�� As Long) As OLE_COLOR
    '���ݿ�ʼ�桢��ֹ���ȡ�����ַ���ɫ
    Dim R As Long, g As Long, b As Long
    R = 255
    g = GetColorVectorG(lng��ʼ��)
    b = GetColorVectorB(lng��ֹ��)
    If g = 0 And b = 0 Then
        GetCharColor = vbBlack
    Else
        GetCharColor = RGB(R, g, b)
    End If
End Function


Private Function GetColorVectorG(ByVal lngVersion As Long) As Long
    '���ݰ汾��ȡRGB��ɫ�е�G��ɫ����ֵ
    Select Case lngVersion
    Case 0
        GetColorVectorG = 0     'δ��ʼ
    Case 1
        GetColorVectorG = 0     '��һ�滹�����޶���
    Case 2
        GetColorVectorG = 10
    Case 3
        GetColorVectorG = 90
    Case 4
        GetColorVectorG = 140
    Case 5
        GetColorVectorG = 145
    Case 6
        GetColorVectorG = 150
    Case 7
        GetColorVectorG = 155
    Case 8
        GetColorVectorG = 160
    Case 9
        GetColorVectorG = 165
    Case 10
        GetColorVectorG = 170
    Case 11
        GetColorVectorG = 175
    Case 12
        GetColorVectorG = 180
    Case 13
        GetColorVectorG = 185
    Case 14
        GetColorVectorG = 190
    Case 15
        GetColorVectorG = 195
    Case 16
        GetColorVectorG = 200
    Case 17
        GetColorVectorG = 205
    End Select
End Function


Private Function GetColorVectorB(ByVal lngVersion As Long) As Long
    '���ݰ汾��ȡRGB��ɫ�е�B��ɫ����ֵ
    Select Case lngVersion
    Case 0
        GetColorVectorB = 0     'δ��ֹ
    Case 1
        GetColorVectorB = 0     '��һ�滹�����޶���
    Case 2
        GetColorVectorB = 10
    Case 3
        GetColorVectorB = 15
    Case 4
        GetColorVectorB = 20
    Case 5
        GetColorVectorB = 25
    Case 6
        GetColorVectorB = 30
    Case 7
        GetColorVectorB = 35
    Case 8
        GetColorVectorB = 40
    Case 9
        GetColorVectorB = 45
    Case 10
        GetColorVectorB = 50
    Case 11
        GetColorVectorB = 55
    Case 12
        GetColorVectorB = 60
    Case 13
        GetColorVectorB = 65
    Case 14
        GetColorVectorB = 70
    Case 15
        GetColorVectorB = 75
    Case 16
        GetColorVectorB = 80
    Case 17
        GetColorVectorB = 85
    End Select
End Function

Public Sub richTextBoxShowElements(rText As RichTextBox, Optional Owner As Object = Nothing)
    Dim strSel As String
    Dim miESingleS As Integer
    Dim miESingleE As Integer
    Dim miEMultiS As Integer
    Dim miEMultiE As Integer
    Dim objElementWindow As frmReportElement
    Dim lngStart As Long
    
    lngStart = rText.SelStart
    
    '�жϵ�ǰѡ�������Ƿ�Ҫ��
    If rText.SelColor = vbBlue Then
        miESingleS = InStrRev(rText.Text, "{{", lngStart) 'vbTextCompare  win7 64λ���Ӵ˲����󣬲�����Ч����
        miEMultiS = InStrRev(rText.Text, "{<", lngStart) 'vbTextCompare
        If miESingleS > miEMultiS Then  '��ǰ��ӽ������ǵ�ѡҪ��
            miESingleE = InStr(lngStart, rText.Text, "}}") 'vbTextCompare
            miESingleE = miESingleE + 1
            If miESingleE > miESingleS Then
                '�ǵ�ѡҪ��
                strSel = Left(rText.Text, miESingleE)
                strSel = Right(strSel, miESingleE - miESingleS + 1)
                
'                rText.SelStart = 0
'                rText.SelLength = 0
'                rText.SelText = ""
 
                Set objElementWindow = New frmReportElement
                If objElementWindow.ShowElement(strSel, 0, Owner) = False Then Exit Sub
                
                rText.SelStart = miESingleS - 1
                rText.SelLength = miESingleE - miESingleS + 1
                rText.SelText = objElementWindow.strReturnElement
 
                
                rText.SelStart = (miESingleS - 1) + Len(objElementWindow.strReturnElement)
                
            End If
        ElseIf miEMultiS > miESingleS Then  '��ǰ��ӽ����Ƕ�ѡҪ��
            miEMultiE = InStr(lngStart, rText.Text, ">}") 'vbTextCompare
            miEMultiE = miEMultiE + 1
            If miEMultiE > miEMultiS Then
                '�Ƕ�ѡҪ��
                strSel = Left(rText.Text, miEMultiE)
                strSel = Right(strSel, miEMultiE - miEMultiS + 1)
                
                Set objElementWindow = New frmReportElement
                If objElementWindow.ShowElement(strSel, 1, Owner) = False Then Exit Sub
                
                rText.SelStart = miEMultiS - 1
                rText.SelLength = miEMultiE - miEMultiS + 1
                rText.SelText = objElementWindow.strReturnElement
                
'                rText.SelStart = 0 'rText.SelStart + rText.SelLength
'                rText.SelLength = 0
            End If
        Else    '����Ҫ�ص�λ����ȣ�˵��������0����ǰʲôҪ�ض�û��
        
        End If
    End If
    
    Set objElementWindow = Nothing
End Sub

Public Function Wndproc(ByVal hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Dim pt As POINTL
    Dim wzDelta, wKeys As Integer
    On Error Resume Next
    wzDelta = OS.HIWORD(wParam)
    wKeys = OS.LOWORD(wParam)
    Select Case Msg
        Case WM_MOUSEWHEEL
            If fReport.picWordShow.Visible = False Or fReport.vscroWordH.Enabled = False Then Exit Function
            
            If Sgn(wzDelta) = 1 Then
                If fReport.vscroWordH.value - 1 < 0 Then
                    fReport.vscroWordH.value = 0
                Else
                    fReport.vscroWordH.value = fReport.vscroWordH.value - 1
                End If
            Else
                If fReport.vscroWordH.value + 1 > fReport.vscroWordH.Max Then
                    fReport.vscroWordH.value = fReport.vscroWordH.Max
                Else
                    fReport.vscroWordH.value = fReport.vscroWordH.value + 1
                End If
            End If
    End Select
    Wndproc = CallWindowProc(preWinProc, hwnd, Msg, wParam, lParam)
End Function

Public Function zlGetWordPower() As Integer
'******************************************************************************************************************
'���ܣ���õ�ǰ�û��Ĵʾ�����Ȩ��
'���أ��ʾ����Ȩ����ֵ
'******************************************************************************************************************
    Dim intWordPower As Integer
    Dim strPrivs As String
    
    strPrivs = ";" & GetPrivFunc(glngSys, 1070) & ";"
    If InStr(1, strPrivs, ";ȫԺ�����ʾ�;") <> 0 Then
        intWordPower = 0
    ElseIf InStr(1, strPrivs, ";���Ҳ����ʾ�;") <> 0 Then
        intWordPower = 1
    ElseIf InStr(1, strPrivs, ";���˲����ʾ�;") <> 0 Then
        intWordPower = 2
    Else
        intWordPower = -1
    End If
    zlGetWordPower = intWordPower
End Function

Public Function zlDefaultWordCode(lngClassID As Long) As String
'���ܣ����ôʾ�ʾ����Ĭ�ϱ��
'������ lngClassID --- �ʾ����ID

    Dim strSQL As String
    Dim rsTemp As New ADODB.Recordset
    
    strSQL = "Select LPad(Nvl(To_Number(Max(���)), 0) + 1, Nvl(Max(Length(���)), 5), '0') As ����" & vbNewLine & _
            "From �����ʾ�ʾ��" & vbNewLine & _
            "Where ����id = [1]"
    err = 0: On Error Resume Next
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ȡ�ʾ���", lngClassID)
    zlDefaultWordCode = rsTemp.Fields(0).value
    
    Exit Function
errHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetSignSourceString(int��ȡ���� As Integer, lngReportID As Long, intǩ���汾 As Integer, blnMoved As Boolean, _
    thisSign As cEPRSign, strSourceOut As String, ByVal strImg64 As String, Optional ByVal lngAdviceId As Long = 0) As Integer
'------------------------------------------------
'���ܣ���ȡ���ڵ���ǩ����ǩ����֤�ı���Դ������
'������ int��ȡ���� -- 1��ǩ��ʱ��ȡԴ�ģ�2��ǩ����֤ʱ��ȡԴ��
'       lngReportID -- ����ID�����Ӳ�����¼ID
'       intǩ���汾 -- ����ǩ��/��֤ǩ����ȡԴ�ĵİ汾��
'       blnMoved --- ���������Ƿ��Ѿ�ת��
'       thisSign --- ǩ������ǩ����ʱ����˶�����֤ǩ����ʱ����nothing
'       strSourceOut -- �����ء�ǩ��Դ��
'���أ� ǩ��/��֤ǩ����Դ�����ɹ���
'-----------------------------------------------
    Dim intRule As Integer
    Dim lngǩ��ID  As Long                  'ǩ�����ڵ��е�ID
    Dim strSQL As String
    Dim rs������¼ As ADODB.Recordset
    Dim rs�������� As ADODB.Recordset
    Dim rsǩ����¼ As ADODB.Recordset
    Dim strǩ��ʱ�� As String
    Dim arr��������() As String
    Dim strSignName As String
    Dim strSignImgBase64 As String
    
    'Դ����ȡ����
    'intRule = 1ʱ����ȡ ID������ID��Ӥ���������ˣ�����ʱ�䣬ҽ��������ǩ������ǩ��ʱ��,���������������������
    '��֤ǩ����ʱ��ҽ��������ǩ������ǩ��ʱ���ǩ����¼�л�ȡ���ֱ���ҽ������= �������ı�����ǩ������=��Ҫ�ر�ʾ����ǩ��ʱ�� =���������ԣ�5����
    'ǩ����ʱ��ҽ��������ǩ������ǩ��ʱ�� ��ǩ�������л�ȡ
    On Error GoTo err
    
    If lngReportID = 0 Or intǩ���汾 = 0 Then Exit Function
    
    
    '��ʼ��Ĭ��ֵ
    intRule = 1
    strSourceOut = ""
    
    '����int��ȡ���� ���ж���ǩ��������֤ǩ�����ֱ�Ӷ�Ӧ�ĵط���ȡ����
    '�ӵ��Ӳ�����¼����ȡ����Դ�ĵĻ�����Ϣ
    strSQL = "Select ID,����ID,Ӥ��,������,����ʱ�� From ���Ӳ�����¼ Where Id = [1]"
    Set rs������¼ = zlDatabase.OpenSQLRecord(strSQL, "��ȡ����Դ�Ļ�����Ϣ", lngReportID)
    If rs������¼.RecordCount = 0 Then
        Exit Function
    End If
    
    '�ӵ��Ӳ�����������ȡ����Դ�ĵ�������Ϣ
    strSQL = "Select a.�����ı� As ����, b.��������, b.�����ı� As ����,b.��ʼ�� as �汾 From ���Ӳ������� a,���Ӳ������� b " & _
             " Where a.�ļ�id = [1] And a.�������� = 3 And a.Id = b.��ID And b.�������� = 2 and b.��ʼ�� = [2]  "
    Set rs�������� = zlDatabase.OpenSQLRecord(strSQL, "��ȡ����Դ��������Ϣ", lngReportID, intǩ���汾)
    If rs��������.RecordCount = 0 Then
        Exit Function
    End If
    
    If int��ȡ���� = 1 Then
        'ǩ�������ǩ�������Ƿ����
        If thisSign Is Nothing Then
            Exit Function
        End If
    Else
        '��֤ǩ������ǩ����¼����ȡҽ��������ǩ������ǩ��ʱ����Ϣ,ǩ������
        strSQL = "Select �����ı� as ҽ������ ,Ҫ�ر�ʾ  as ǩ������ ,�������� From ���Ӳ������� Where �ļ�ID = [1] And �������� = 8 and ��ʼ�� =[2] "
        Set rsǩ����¼ = zlDatabase.OpenSQLRecord(strSQL, "��ȡ��󱨸�Դ��ǩ����Ϣ", lngReportID, intǩ���汾)
        If rsǩ����¼.RecordCount = 0 Then
            Exit Function
        End If
        
        '��ȡ��ʽ����ǩ��ʱ�䣬ǩ������
        arr�������� = Split(rsǩ����¼!��������, ";")
        If UBound(arr��������) >= 5 Then
            intRule = Val(arr��������(1))
            strǩ��ʱ�� = Format(arr��������(4), "yyyy-MM-dd HH:mm:ss")
        End If
        If intRule = 0 Then Exit Function
    End If
    
    '���ݹ�����֯����Դ�ģ� ID������ID��Ӥ���������ˣ�����ʱ�䣬ҽ��������ǩ������ǩ��ʱ��,���������������������
    If intRule = 1 Then
        'Դ�Ļ�����Ϣ
        strSourceOut = rs������¼!ID
        strSourceOut = strSourceOut & vbTab & nvl(rs������¼!����ID)
        strSourceOut = strSourceOut & vbTab & nvl(rs������¼!Ӥ��)
        strSourceOut = strSourceOut & vbTab & nvl(rs������¼!������)
        strSourceOut = strSourceOut & vbTab & nvl(rs������¼!����ʱ��)
        
        'Դ��ǩ����Ϣ
        If int��ȡ���� = 1 Then
            'ǩ������ǩ��������ȡ
            strSourceOut = strSourceOut & vbTab & thisSign.����
            strSourceOut = strSourceOut & vbTab & thisSign.ǩ������
            strSourceOut = strSourceOut & vbTab & Format(thisSign.ǩ��ʱ��, "yyyy-MM-dd HH:mm:ss")
        Else
            '��֤ǩ���������ݿ�ǩ����¼��ȡ
            strSignName = nvl(rsǩ����¼!ҽ������)
            If InStr(strSignName, M_STR_TAG_SIGNWITHIMG) > 0 Then
                strSignImgBase64 = Split(strSignName, M_STR_TAG_SIGNWITHIMG)(1)
                strSignName = Split(strSignName, M_STR_TAG_SIGNWITHIMG)(0)
            End If
 
            strSourceOut = strSourceOut & vbTab & strSignName
            strSourceOut = strSourceOut & vbTab & nvl(rsǩ����¼!ǩ������)
            strSourceOut = strSourceOut & vbTab & strǩ��ʱ��
        End If
        
        'Դ�ı�������
        rs��������.Filter = "���� ='" & ReportViewType_������� & "'"
        If rs��������.RecordCount = 0 Then
            strSourceOut = strSourceOut & vbTab
        Else
            strSourceOut = strSourceOut & vbTab & nvl(rs��������!����)
        End If
        
        rs��������.Filter = "���� ='" & ReportViewType_������ & "'"
        If rs��������.RecordCount = 0 Then
            strSourceOut = strSourceOut & vbTab
        Else
            strSourceOut = strSourceOut & vbTab & nvl(rs��������!����)
        End If
        
        rs��������.Filter = "���� ='" & ReportViewType_���� & "'"
        If rs��������.RecordCount = 0 Then
            strSourceOut = strSourceOut & vbTab
        Else
            strSourceOut = strSourceOut & vbTab & nvl(rs��������!����)
        End If
        
        'Դ��ǩ��ͼ����Ϣ
        If gblUseImgSignValid Then
            If int��ȡ���� = 1 Then
                '�ӹ��̲�����ȡ
                strSourceOut = strSourceOut & vbTab & strImg64
            Else
                '�����ݿ�ǩ����¼��ȡ
                strSignImgBase64 = ImgFileNamesToBase64(strSignImgBase64, lngAdviceId)
                If gblnUseValidLog Then
                    Call WriteLog("ǩ����֤Base64���ݣ�" & vbLf & strSignImgBase64)
                End If
                If InStr("errN", strSignImgBase64) > 0 Then
                    Call SaveSetting("ZLSOFT", "����ģ��\ZL9PACSWork", "ͼ��ǩ��������Ϣ", Mid(strSignImgBase64, 1, 20))
                End If
                strSourceOut = strSourceOut & vbTab & strSignImgBase64
            End If
        End If
    End If
    
    GetSignSourceString = intRule
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function ElementHook(ByVal hwnd As Long) As Long
    '���ز�����ԭ��Ĭ�ϵĴ��ڹ���ָ��
    If App.LogMode <> 0 Then
        '���Զ���������ԭ����window����
        ElementHook = SetWindowLong(hwnd, GWL_WNDPROC, AddressOf ElementWindowProc)
    End If
End Function

Public Sub ElementUnhook(ByVal hwnd As Long, ByVal lpWndProc As Long)
  Dim temp As Long
  
    If App.LogMode <> 0 Then
        temp = SetWindowLong(hwnd, GWL_WNDPROC, lpWndProc)
    End If
End Sub

Public Function ElementWindowProc(ByVal hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
''------------------------------------------------
''���ܣ�Ԫ��д�봰�ڵ�windows��Ϣ�������ר�Ŵ��������� ��Ϣ
''������
''���أ�
''------------------------------------------------
    Dim pt As POINTAPI
    Dim wzDelta As Integer
    
    On Error Resume Next
    
    wzDelta = OS.HIWORD(wParam)
    
    Select Case Msg
        Case WM_MOUSEWHEEL
            If Sgn(wzDelta) = 1 Then    '����Ϲ�
                Call fReportElement.subMouseWheel(1)
            Else                        '����¹�
                Call fReportElement.subMouseWheel(2)
            End If
    End Select
    
    '����ԭ���Ĵ��ڹ���
    ElementWindowProc = CallWindowProc(glngEelmentWinProc, hwnd, Msg, wParam, lParam)
End Function

Private Function ImgFileNamesToBase64(ByVal strImgFileNames As String, ByVal lngAdviceId As Long) As String
'��"�ļ���_1;�ļ���_2;�ļ���_3"ת��Ϊ"base64_1;banse64_2;base64_3"����ʽ
On Error GoTo errH
    Dim objFile As New Scripting.FileSystemObject
    
    Dim strBase64 As String
    
    Dim strSQL As String
    Dim rsTemp As Recordset
    Dim strLocalDir As String
    Dim strImgName() As String
    Dim i As Integer, lngResult As Long
    Dim strPathTmp As String
    Dim blnIsMark As Boolean '�Ƿ���ͼ
    Dim strFtpDir As String
    Dim strLocalPath As String
    Dim strSaveDeviceID As String
    Dim strFTPDirUrl As String, strFtpIp As String, strFTPUser As String, strFTPPwd As String, struFtpTag As TFtpConTag
    Dim strPathCheck As String
    Dim strNewDirectory As String
    
    If gblnUseValidLog Then
        Call WriteLog("��֤ǩ��ͼ���ļ����ƣ�" & vbLf & strImgFileNames)
    End If
    
    strSQL = "Select λ��һ,λ�ö�,���UID,�������� From Ӱ�����¼ Where ���UID is not null And ҽ��ID = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "hehe", lngAdviceId)
    
    If rsTemp.RecordCount > 0 Then
        strLocalDir = App.Path & "\TmpImage\" & Format(nvl(rsTemp!��������), "yyyyMMdd") & "\" & nvl(rsTemp!���UID) & "\"
         strSaveDeviceID = nvl(rsTemp!λ��һ)
        If strSaveDeviceID = "" Then
            strSaveDeviceID = nvl(rsTemp!λ�ö�)
        End If
    End If
    
    strImgName = Split(strImgFileNames, ";")
    For i = 0 To UBound(strImgName)
        
        If InStr(strImgName(i), "jpg") < 1 Then
            strPathTmp = App.Path & "\TmpImage\MarkImages\" & strImgName(i)
            blnIsMark = True
        Else
            blnIsMark = False
            strPathTmp = strLocalDir & strImgName(i)
        End If
        '�ж��ļ��Ƿ���ڣ������ڣ�ת��Ϊbase64
        '�������� ��FTP����Ȼ��ת��Ϊbase64��������ʧ�ܡ�����Ҳû�취��֤ǩ��
        
        If objFile.FileExists(strPathTmp) Then
            If strBase64 <> "" Then strBase64 = strBase64 & ";"
            
            strBase64 = strBase64 & zlStr.EncodeBase64_File(strPathTmp)
        Else
            '��FTP�����ļ�
            If blnIsMark Then
                strFtpDir = "MarkImages/"
                strPathCheck = App.Path & "\TmpImage\MarkImages"
                strLocalPath = strPathCheck & "\" & strImgName(i)
            Else
                strFtpDir = Format(nvl(rsTemp!��������), "yyyyMMdd") & "/" & nvl(rsTemp!���UID)
                strPathCheck = App.Path & "\TmpImage\" & Format(nvl(rsTemp!��������), "yyyyMMdd") & "\" & nvl(rsTemp!���UID)
                strLocalPath = strPathCheck & "\" & strImgName(i)
            End If
            
            '���û��Ŀ¼���򴴽�Ŀ¼
            If Dir(strPathCheck, vbDirectory) = "" Then
                strNewDirectory = App.Path & "\TmpImage"
                If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                
                If blnIsMark Then
                    strNewDirectory = strNewDirectory & "\MarkImages"
                    If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                Else
                    strNewDirectory = strNewDirectory & "\" & Format(nvl(rsTemp!��������), "yyyyMMdd")
                    If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                    
                    strNewDirectory = strNewDirectory & "\" & nvl(rsTemp!���UID)
                    If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                End If
            End If
            
            If strSaveDeviceID <> "" Then
                Call GetFtpDeviceWithDeviceNo(Nothing, strSaveDeviceID, strFTPDirUrl, strFtpIp, strFTPUser, strFTPPwd)
    
                struFtpTag = FtpTagInstance(strFtpIp, strFTPUser, strFTPPwd, strFTPDirUrl & strFtpDir)
            Else
                '��ֹ
                ImgFileNamesToBase64 = "errN1:ȱ��FTPλ����Ϣ,�޷�������֤"
                Exit Function
            End If
            
            lngResult = FtpDownload(struFtpTag, strImgName(i), strLocalPath, False)
            
            If lngResult = frAbort Then
                '��ֹ
                ImgFileNamesToBase64 = "errN2:FTP����ʧ��"
                Exit Function
            End If
            
            If strBase64 <> "" Then strBase64 = strBase64 & ";"
            strBase64 = strBase64 & zlStr.EncodeBase64_File(strPathTmp)
        End If
    Next
    
    ImgFileNamesToBase64 = strBase64
    Exit Function
errH:
    '��ֹ
    ImgFileNamesToBase64 = "errN3:" & err.Description
    Call err.Raise(0, , "�����ļ����Ʋ���base64�����쳣-" & err.Description)
    Resume
End Function


Public Function GetReportImgPath(ByVal lngAdviceId As Long, ByVal blnIsMoved As Boolean) As String
'��ȡ����ͼ·��
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    GetReportImgPath = ""
    
    strSQL = "select to_Char(a.��������,'YYYYMMDD') as ��������,a.����,a.���UID,to_Char(b.����ʱ��,'YYYYMMDD') as ����ʱ�� " & _
            " From Ӱ�����¼ a, ����ҽ������ b " & _
            " where a.ҽ��ID=b.ҽ��ID and a.���ͺ�=b.���ͺ� and a.ҽ��ID=[1]"
            
    If blnIsMoved Then
        strSQL = Replace(strSQL, "Ӱ�����¼", "HӰ�����¼")
        strSQL = Replace(strSQL, "����ҽ������", "H����ҽ������")
    End If
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "��ѯӰ�������Ϣ", lngAdviceId)
     
    If rsTemp.RecordCount <= 0 Then Exit Function
     
    If nvl(rsTemp!���UID) = "" Or nvl(rsTemp!��������) = "" Then
        GetReportImgPath = FormatFilePath(SysRootPath & "\Apply\TmpImage\" & nvl(rsTemp!����ʱ��) & "(RLATIMG)\" & lngAdviceId & "\")
    Else
        GetReportImgPath = FormatFilePath(SysRootPath & "\Apply\TmpImage\" & nvl(rsTemp!��������) & "\" & nvl(rsTemp!���UID) & "\")
    End If
End Function


Public Sub SetWordStyle(rtxtWord As RichTextBox, Optional ByVal lngFontSize As Single = 0)
    Dim strCurContext As String
    Dim lngSIndex As Long
    Dim lngEIndex As Long
    Dim lngBaseIndex As Long
    
    '��������
    If lngFontSize <> 0 Then rtxtWord.SelFontSize = lngFontSize
    
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
End Sub
