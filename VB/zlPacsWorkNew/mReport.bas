Attribute VB_Name = "mReport"
Option Explicit

Public pReport_CheckViewName As String
Public pReport_ResultName As String
Public pReport_AdviceName As String

Public preWinProc As Long
Public fReport As frmReportWord
Public fReportElement As frmReportElement
Public glngEelmentWinProc As Long

Public Const ReportViewType_检查所见 = "检查所见"
Public Const ReportViewType_诊断意见 = "诊断意见"
Public Const ReportViewType_建议 = "建议"
Public Const ReportViewType_病理诊断 = "病理诊断"
Public Const ReportViewType_活检部位 = "活检部位"

Public Type TWordLine
    lngWordID As Long
    strOutlineName As String
    strContext As String
End Type

Public Type TPreDefKey   '保留关键字
    KeyStart As String
    KeyEnd As String
End Type


'签名状态
Public Enum TReportSignLevel
    cprSL_空白 = 0              '未签名
    cprSL_经治 = 1              '经治医师签名
    cprSL_主治 = 2              '主治医师签名
    cprSL_主任 = 3              '主任医师签名
    cprSL_正高 = 4              '正高：签名级别不包含，只表示人员居右正高职称，以便区别副主任医师
End Enum


Public gobjRichEPR As zlRichEPR.cRichEPR
Public gobjReport As zlRichEPR.cDockReport
Public gobjEmr As Object    '电子病历


'################################################################################################################
'## 功能：  将指定的文件保存到指定记录的LOB字段中
'##
'## 参数：  Action      :操作类型（用以区别是操作哪个表）
'##         KeyWord     :确定数据记录的关键字，复合关键字以逗号分隔(仅5-电子病历格式为复合)
'##         strFile     :用户指定存放的文件名；不指定时，取当前路径产生文件名
'##
'## 返回：  成功返回True，失败返回False
'##
'## 说明：  Action取值说明：
'##         0-病历标记图形；1-病历文件格式；2-病历文件图形；3-病历范文格式；4-病历范文图形；5-电子病历格式；6-电子病历图形；
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
        '看是否关键字，若为关键字，必须是隐藏且受保护的。
        If ProtectAndHide(strReport, i - 1, i) = False Then
            i = i + 1
            GoTo LL1
        End If
        '已经找到起始关键字，往后查找字符，并替换这些字符
        j = i + 16
        lngES = j
        '查找结束关键字
        sTMP = strKeyType & "E(" & Format(lngKey, "00000000")
LL2:
        j = InStr(j, strReport, sTMP)
        If j <> 0 Then
            '看是否关键字，若为关键字，必须是隐藏且受保护的。
            If ProtectAndHide(strReport, j - 1, j) = False Then
                j = j + 1
                GoTo LL2
            End If
            lngEE = j - 1
            '已经找到结束关键字，说明中间就是需要替换的要素
            
            '过滤掉控制符号，\cfN,\highlightN,\v0
            If getElementPos(strReport, lngES, lLength, lngEE, lulWave, lulNone) = True Then
                strNewReport = strReport
                '先处理下划波浪，删除下划波浪的两个标记
                If lulWave <> 0 And lulNone <> 0 Then
                    strNewReport = Left(strNewReport, lulNone) & Right(strNewReport, Len(strNewReport) - lulNone - 7)
                End If
                '再处理要素内容，替换要素内容
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
    '将中文字符串转换为ASC串（包括英文一起）
    '先将特殊字符进行转义：
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
'    lulWave   '下划波浪标记\ulwave的开始位置
'    lulNone    '关闭所有下划线标记\ulnone的开始位置
    '查找从lStart开始的，元素内容文本的开始位置和长度
    '查找和定位元素中的下划波浪标记\ulwave 和 关闭所有下划线标记\ulnone
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
        If strChar = "\" Then       '上一个控制字符结束，下一个控制字符，或者是文本的开始
            strNextChar = Mid(strReport, lIndex + 1, 1)
            If strNextChar = "'" Or strNextChar = "{" Or strNextChar = "}" Or strNextChar = "\" Then     '文本的开始
                '往后找第一个控制符
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
                            blnInWord = False   '退出内容循环
                        End If
                    End If
                Wend
            Else    '控制字符的开始
                '往后读取一直到控制字符结束
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
                    blnSearch = False   '退出查找元素的循环
                End If
            End If
        ElseIf strChar = " " Then   '正文开始，而且正文的字符是英文，不是中文
            '往后找第一个控制符
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
                        blnInWord = False   '退出内容循环
                    End If
                End If
            Wend
            
        Else        '在不是正确的RTF文件，返回查找错误
            getElementPos = False
            Exit Function
        End If
    Wend
    lLength = lWordEnd - lStart
    If lWordEnd = 0 Then  '说明是查到要素结束了，才退出的，没有查找到内容文本
        getElementPos = False
    Else
        getElementPos = True
    End If
End Function


Private Function ProtectAndHide(ByRef strReport As String, ByVal lStart As Long, ByVal lEnd As Long) As Boolean
    Dim lOnPos As Long
    Dim lOffPos As Long
    
    '往前找隐藏和保护开始标记，\v和\protect
    lOnPos = InStrRev(strReport, "\v", lStart, vbTextCompare)
    lOffPos = InStrRev(strReport, "\v0", lStart, vbTextCompare)
    If lOnPos > lOffPos And lOnPos <> 0 Then
        '查找后面的隐藏标记
        lOnPos = InStr(lEnd, strReport, "\v", vbTextCompare)
        lOffPos = InStr(lEnd, strReport, "\v0", vbTextCompare)
        If lOffPos <= lOnPos And lOffPos <> 0 Then
            '查找前面的保护标记
            lOnPos = InStrRev(strReport, "\protect", lStart, vbTextCompare)
            lOffPos = InStrRev(strReport, "\protect0", lStart, vbTextCompare)
            If lOnPos > lOffPos And lOnPos <> 0 Then
                '查找后面的保护标记
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
'获取报告签名信息
    Dim RS As New ADODB.Recordset
    Dim strSQL As String
    Dim arySignPro() As String
    
On Error GoTo errhandle
    strSQL = "Select ID, 父id, 文件id, 对象标记, 对象序号, 对象属性, 内容文本, 要素值域, 要素名称, 要素表示, 要素单位, 输入形态, 开始版, 终止版" & vbNewLine & _
                "From 电子病历内容" & vbNewLine & _
                "Where 对象类型 = 8 And ID = [1]"

    Set RS = zlDatabase.OpenSQLRecord(strSQL, "查询报告签名", lngID)
    If Not RS.EOF Then
        signInfo.Key = nvl(RS("对象标记"), 0)
        
        signInfo.ID = RS("ID")
        signInfo.文件ID = nvl(RS("文件ID"), 0)
        signInfo.父ID = nvl(RS("父ID"), 0)
        signInfo.对象序号 = nvl(RS("对象序号"), 0)
        signInfo.姓名 = Split(nvl(RS("内容文本"), ";"), ";")(0)
        signInfo.签名信息 = nvl(RS("要素值域"))
        signInfo.前置文字 = nvl(RS("要素名称"))
        signInfo.签名级别 = nvl(RS("要素表示"))
        signInfo.对象属性 = nvl(RS("对象属性"))
        signInfo.开始版 = nvl(RS("开始版"), 1)
        signInfo.终止版 = nvl(RS("终止版"), 0)
        signInfo.时间戳 = nvl(RS("要素单位"))
        signInfo.签名图片 = nvl(RS("输入形态"), 0) = 1
        
        If UBound(Split(nvl(RS!内容文本), ";")) > 0 Then
            signInfo.签名人ID = Val(Split(nvl(RS("内容文本")), ";")(1))
        End If
        
        arySignPro = Split(signInfo.对象属性 & ";;;;;;;", ";")
        
        signInfo.签名方式 = Val(arySignPro(0))
        signInfo.签名规则 = Val(arySignPro(1))
        signInfo.证书ID = Val(arySignPro(2))
        signInfo.显示手签 = (Val(arySignPro(3)) = 1)
        signInfo.签名时间 = Format(arySignPro(4), "yyyy-mm-dd hh:mm:ss")
        signInfo.显示时间 = arySignPro(5)
        signInfo.签名要素 = CStr(arySignPro(6))
        signInfo.时间戳信息 = CStr(arySignPro(7))
        
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
   
   '如果是RTF格式 则清除格式 只保留文字内容
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

Public Sub FormatWords(ByVal lngWordID As Long, ByVal str内容文本 As String, aryWordLines() As TWordLine)
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
    
    
    strCurContext = str内容文本
    
    '优先处理<P>...</P>标记
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
            '判断是否存在提纲
            strCurOutlineName = ""
            
            If InStr(strPContext, "<<所见>>") > 0 Then
                strCurOutlineName = "<<所见>>"
            End If
            
            If strCurOutlineName = "" And InStr(strPContext, "<<诊断>>") > 0 Then
                strCurOutlineName = "<<诊断>>"
            End If
            
            If strCurOutlineName = "" And InStr(strPContext, "<<建议>>") > 0 Then
                strCurOutlineName = "<<建议>>"
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
    If InStr(strCurContext, "<<所见>>") > 0 Then
        strCurOutlineName = "<<所见>>"
    End If
    
    If strCurOutlineName = "" And InStr(strCurContext, "<<诊断>>") > 0 Then
        strCurOutlineName = "<<诊断>>"
    End If
    
    If strCurOutlineName = "" And InStr(strCurContext, "<<建议>>") > 0 Then
        strCurOutlineName = "<<建议>>"
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
'## 功能：  在压缩文件相同目录释放产生解压文件
'## 参数：  strZipFile     :压缩文件
'## 返回：  解压文件名，失败则返回零长度""
'################################################################################################################
Public Function zlFileUnzip(ByVal strZipFile As String) As String
    Dim strZipPath As String
    Dim objFSO As Scripting.FileSystemObject     'FSO对象
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
'## 功能：  将文件压缩为新文件放到相同目录中
'## 参数：  strFile     :原始文件
'## 返回：  压缩文件名，失败则返回零长度""
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


' 从电子病历中复制过来的一些过程
'################################################################################################################
'## 功能：  将指定的LOB字段复制为临时文件
'##
'## 参数：  Action      :操作类型（用以区别是操作哪个表）
'##         KeyWord     :确定数据记录的关键字，复合关键字以逗号分隔(仅5-电子病历格式为复合)
'##         strFile     :用户指定存放的文件名；不指定时，取当前路径产生文件名
'##
'## 返回：  存放内容的文件名，失败则返回零长度""
'##
'## 说明：  Action取值说明：
'##         0-病历标记图形；1-病历文件格式；2-病历文件图形；3-病历范文格式；4-病历范文图形；5-电子病历格式；6-电子病历图形；
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
    
    gstrSQL = "Select Zl_Lob_Read(" & Action & ",'" & KeyWord & "'," & "[1]) as 片段 From Dual"
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
'## 功能：  判断指定用户是否是主任医师
'##
'## 参数：  lngUserID       ：用户ID
'##         strUserName     ：用户名
'##         lngPatiID       ：病人ID
'##         lngPatiPageID   ：主页ID
'##
'## 说明：  根据“人员表”中的“聘任技术职务”字段确定医生技术级别（住院医师、主治医师、主任医师）
'##         ＋病人变动记录中的医生级别，从而确定审核级别
'################################################################################################################
Public Function GetUserSignLevel(lngUserId As Long, Optional strUserName As String, _
    Optional lngPatiID As Long, Optional lngPatiPageID As Long) As EPRSignLevelEnum
    Dim RS As New ADODB.Recordset, lngR As Long, lngLevel1 As Long, lngLevel2 As Long
    Dim strUserFunc As String
    
    err = 0: On Error GoTo errHand
    If lngUserId = UserInfo.ID Then
        '当前用户时，不做限制
    Else
        gstrSQL = "Select p.用户名 From 上机人员表 P Where p.人员id = [1]"
        Set RS = zlDatabase.OpenSQLRecord(gstrSQL, "mReport", lngUserId)
        If RS.RecordCount <= 0 Then GetUserSignLevel = cprSL_空白: Exit Function
        
        strUserFunc = GetPrivFuncByUser(glngSys, 1070, nvl(RS!用户名))
        If InStr(";" & strUserFunc & ";", ";签名权;") = 0 Then
            GetUserSignLevel = cprSL_空白: Exit Function
        End If
    End If
    
    gstrSQL = "select 聘任技术职务 from 人员表 p where ID=[1]"
    Set RS = zlDatabase.OpenSQLRecord(gstrSQL, "mRichEPR", lngUserId)
    If Not RS.EOF Then
        lngR = nvl(RS("聘任技术职务"), 0)
    End If
    Select Case lngR    '1 正高  2 副高  3 中级  4 助理/师级  5 员/士  9 待聘
    Case 1: lngLevel1 = cprSL_正高
    Case 2: lngLevel1 = cprSL_主任
    Case 3: lngLevel1 = cprSL_主治
    Case Else: lngLevel1 = cprSL_经治
    End Select
    RS.Close
    
    If lngPatiID > 0 Then
        gstrSQL = "Select 经治医师, 主治医师, 主任医师 " & _
            " From 病人变动记录 " & _
            " Where 病人ID = [1] And 主页ID = [2] And (终止时间 Is Null Or 终止原因 = 1) " & _
            "       And 开始时间 Is Not Null And Nvl(附加床位, 0) = 0"
        Set RS = zlDatabase.OpenSQLRecord(gstrSQL, "cEPRDocument", lngPatiID, lngPatiPageID)
        If RS.EOF Then
            lngLevel2 = cprSL_经治
        Else
            If RS.Fields("主任医师") = IIf(strUserName = "", UserInfo.姓名, strUserName) Then
                lngLevel2 = cprSL_主任
            ElseIf RS.Fields("主治医师") = IIf(strUserName = "", UserInfo.姓名, strUserName) Then
                lngLevel2 = cprSL_主治
            Else
                lngLevel2 = cprSL_经治
            End If
        End If
    End If
    GetUserSignLevel = IIf(lngLevel1 >= lngLevel2, lngLevel1, lngLevel2)
    Exit Function

errHand:
    GetUserSignLevel = cprSL_空白
End Function

'################################################################################################################
'## 功能：  搜索整个文本给出指定关键字区域的定位信息
'##
'## 参数：  edtThis         :   IN  ，编辑控件
'##         strKeyType      :   IN  ，给定关键字名称。取值为："O"、"P"、"T"、"E"、"U"
'##         lngKey           :   IN  ，给定欲查找的关键字ID号。
'##         lngKSS、lngKSE  :   OUT ，分别表示起始关键字的开始位置和结束位置；
'##         lngKES、lngKEE  :   OUT ，分别表示终止关键字的开始位置和结束位置；
'##         blnNeeded:      :   OUT ，是否是保留对象
'##
'## 返回：  如果找到该关键字具体位置，则返回True，否则返回False
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
    Dim sText As String     '尽量少用.Text属性，因此用一个字符串变量来减少时间开支！
    
    sTMP = strKeyType & "S(" & Format(lngKey, "00000000")
    With edtThis
        sText = .Text   '只读取.Text属性1次！！！
        i = 1
LL1:
        i = InStr(i, sText, sTMP)
        If i <> 0 Then
            '看是否是关键字
            If .TOM.TextDocument.range(i - 1, i).Font.hidden = False Then   '若为关键字，必须是隐藏且受保护的。
                i = i + 1
                GoTo LL1
            End If
            '已找到起始关键字
            
            '查找结束关键字
            j = i + 16
LL2:
            sTMP = strKeyType & "E(" & Format(lngKey, "00000000")
            j = InStr(j, sText, sTMP)
            If j <> 0 Then
                '看是否是关键字
                If .TOM.TextDocument.range(j - 1, j).Font.hidden = False Then
                    j = j + 1
                    GoTo LL2
                End If
                '找到结束关键字
                strKeyType = strKeyType
                lngKSS = i - 1 '转换为0开始的坐标位置。
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
'##  预定义内嵌关键字初始化
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
'## 功能：  判断给定位置是否在任何一个关键字对之间，如果是，给出关键字相关位置和ID号
'##
'## 参数：  edtThis         :   IN  ，编辑控件
'##         lngCurPosition  :   OUT ，指定的当前位置
'##         strKeyType      :   OUT ，给定关键字名称。取值为："O"、"P"、"T"、"E"、"U"
'##         lngKey          :   OUT ，给定欲查找的关键字Key。
'##         lngKSS、lngKSE  :   OUT ，分别表示起始关键字的开始位置和结束位置；
'##         lngKES、lngKEE  :   OUT ，分别表示终止关键字的开始位置和结束位置；
'##         blnNeeded:      :   OUT ，是否是保留对象
'##
'## 返回：  如果包含于某个关键字对之间，则返回True，否则返回False
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
    

    '基本方法：使用 Instr() 和 InstrRev() 进行查找！
    Dim n As Long, i As Long, j As Long, k As Long
    Dim lFirst As Long
    Dim sText As String     '尽量少用.Text属性，因此用一个字符串变量来减少时间开支！
    Dim aryPreDefKey() As TPreDefKey
    
    strKeyType = ""
    lngKSS = 0
    lngKSE = 0
    lngKES = 0
    lngKEE = 0
    lngKey = 0
    blnNeeded = False

    With edtThis
        sText = .Text   '只读取.Text属性1次！！！
        aryPreDefKey = GetPreDefinedKeys()
        
        For n = 1 To UBound(aryPreDefKey)     '共 5 对保留关键字
            '看是否是关键字
            i = IIf(lngCurPosition = 0, 1, lngCurPosition)
LL1:
            i = InStr(i, sText, aryPreDefKey(n).KeyEnd)    '先向后搜索结尾关键字
            If i <> 0 Then
                If .range(i - 1, i).Font.hidden = False Then   '若为关键字，必须是隐藏且受保护的。
                    i = i + 1
                    GoTo LL1
                End If
                j = IIf(lngCurPosition = 0, 1, lngCurPosition)
LL2:
                j = InStr(j, sText, aryPreDefKey(n).KeyStart) '若找到结尾关键字，再找同名的开始关键字
                If j <> 0 Then
                    If .range(j - 1, j).Font.hidden = False Then
                        j = j + 1
                        GoTo LL2
                    End If
                End If
                If (j = 0) Or (j > 0 And i < j) Then '即在关键字对之间
                    k = lngCurPosition
LL3:
                    k = InStrRev(sText, aryPreDefKey(n).KeyStart, k, vbTextCompare)    '找匹配的开始关键字
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
    '功能： 插入指定级别签名到Editor中
    '参数： edtThis         :当前的编辑器控件
    '       lngStartPos     :当前位置
    '       blnForceInsert  :是否强制插入，在修改要素时如果前后都保护，这时需要强制插入
    '返回：
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
    
    '如果签名内容为空，也退出
    If Trim(signInfo.姓名) = "" Then Exit Function
    
    '形成签名显示内容
    strTmp = Format(signInfo.Key, "00000000") & ",0,0)"
    strtext = signInfo.前置文字 & signInfo.姓名 & IIf(signInfo.显示手签, "，手签：_____________", "")
    strtext = strtext & IIf(Trim(signInfo.显示时间) = "", "", "，" & Format(signInfo.签名时间, signInfo.显示时间))
    lngLen = Len(strtext)
    
    '如果没有对应的签名要素，则签到当前光标位置处
    '------------------------------------------------------------------------------------------------------------------
    If lngStartPos = -1 Then lngStartPos = edtThis.Selection.StartPos
    
    bInKeys = IsBetweenAnyKeys(edtThis, lngStartPos + 1, sType, lSS, lSE, lES, lEE, lKey, bNeeded)
    
    '保证不能插入关键字内部
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
        '删除线
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.Strikethrough = (signInfo.终止版 > 0)
        '下划线
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.Underline = IIf(signInfo.姓名 = "", 8, cprNone)
        '前景色
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.ForeColor = GetCharColor(signInfo.开始版, signInfo.终止版 + 1)
        '背景色
        .range(lngStartPos + 16, lngStartPos + 16 + lngLen).Font.BackColor = &HD5FEFF
        .range(lngStartPos + 16 + lngLen, lngStartPos + 32 + lngLen).Font.hidden = True
        lngStartPos = lngStartPos + 32 + lngLen

        If signInfo.签名要素 <> "" Then '有签名要素时光标定位到要素这后，因为要素被隐藏
            lngStartPos = lngStartPos + 32 + lngLen
        End If

        .range(lngStartPos, lngStartPos).Selected
        
        .ForceEdit = blnForce
        .UnFreeze
    End With

    InsertIntoEditor = True
End Function

'################################################################################################################
'## 功能：  从编辑器中删除签名组
'##
'## 参数：  edtThis         :当前的编辑器控件
'################################################################################################################
Public Function DeleteFromEditor(ByRef edtThis As Object, signInfo As TReportSignInfo) As Boolean
    '保存诊治要素编辑结果
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

Private Function GetCharColor(ByVal lng开始版 As Long, ByVal lng终止版 As Long) As OLE_COLOR
    '根据开始版、终止版获取最终字符颜色
    Dim R As Long, g As Long, b As Long
    R = 255
    g = GetColorVectorG(lng开始版)
    b = GetColorVectorB(lng终止版)
    If g = 0 And b = 0 Then
        GetCharColor = vbBlack
    Else
        GetCharColor = RGB(R, g, b)
    End If
End Function


Private Function GetColorVectorG(ByVal lngVersion As Long) As Long
    '根据版本获取RGB颜色中的G颜色分量值
    Select Case lngVersion
    Case 0
        GetColorVectorG = 0     '未开始
    Case 1
        GetColorVectorG = 0     '第一版还不能修订！
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
    '根据版本获取RGB颜色中的B颜色分量值
    Select Case lngVersion
    Case 0
        GetColorVectorB = 0     '未终止
    Case 1
        GetColorVectorB = 0     '第一版还不能修订！
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
    
    '判断当前选中内容是否要素
    If rText.SelColor = vbBlue Then
        miESingleS = InStrRev(rText.Text, "{{", lngStart) 'vbTextCompare  win7 64位增加此参数后，不能有效返回
        miEMultiS = InStrRev(rText.Text, "{<", lngStart) 'vbTextCompare
        If miESingleS > miEMultiS Then  '当前最接近光标的是单选要素
            miESingleE = InStr(lngStart, rText.Text, "}}") 'vbTextCompare
            miESingleE = miESingleE + 1
            If miESingleE > miESingleS Then
                '是单选要素
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
        ElseIf miEMultiS > miESingleS Then  '当前最接近的是多选要素
            miEMultiE = InStr(lngStart, rText.Text, ">}") 'vbTextCompare
            miEMultiE = miEMultiE + 1
            If miEMultiE > miEMultiS Then
                '是多选要素
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
        Else    '两个要素的位置相等，说明都等于0，当前什么要素都没有
        
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
'功能：获得当前用户的词句管理的权限
'返回：词句管理权限数值
'******************************************************************************************************************
    Dim intWordPower As Integer
    Dim strPrivs As String
    
    strPrivs = ";" & GetPrivFunc(glngSys, 1070) & ";"
    If InStr(1, strPrivs, ";全院病历词句;") <> 0 Then
        intWordPower = 0
    ElseIf InStr(1, strPrivs, ";科室病历词句;") <> 0 Then
        intWordPower = 1
    ElseIf InStr(1, strPrivs, ";个人病历词句;") <> 0 Then
        intWordPower = 2
    Else
        intWordPower = -1
    End If
    zlGetWordPower = intWordPower
End Function

Public Function zlDefaultWordCode(lngClassID As Long) As String
'功能：设置词句示范的默认编号
'参数： lngClassID --- 词句分类ID

    Dim strSQL As String
    Dim rsTemp As New ADODB.Recordset
    
    strSQL = "Select LPad(Nvl(To_Number(Max(编号)), 0) + 1, Nvl(Max(Length(编号)), 5), '0') As 编码" & vbNewLine & _
            "From 病历词句示范" & vbNewLine & _
            "Where 分类id = [1]"
    err = 0: On Error Resume Next
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取词句编号", lngClassID)
    zlDefaultWordCode = rsTemp.Fields(0).value
    
    Exit Function
errHand:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetSignSourceString(int提取类型 As Integer, lngReportID As Long, int签名版本 As Integer, blnMoved As Boolean, _
    thisSign As cEPRSign, strSourceOut As String, ByVal strImg64 As String, Optional ByVal lngAdviceId As Long = 0) As Integer
'------------------------------------------------
'功能：获取用于电子签名，签名验证的报告源文内容
'参数： int提取类型 -- 1、签名时提取源文；2、签名验证时提取源文
'       lngReportID -- 报告ID，电子病历记录ID
'       int签名版本 -- 本次签名/验证签名提取源文的版本号
'       blnMoved --- 报告数据是否已经转储
'       thisSign --- 签名对象，签名的时候传入此对象，验证签名的时候传入nothing
'       strSourceOut -- 【返回】签名源文
'返回： 签名/验证签名的源文生成规则
'-----------------------------------------------
    Dim intRule As Integer
    Dim lng签名ID  As Long                  '签名所在的行的ID
    Dim strSQL As String
    Dim rs病历记录 As ADODB.Recordset
    Dim rs病历内容 As ADODB.Recordset
    Dim rs签名记录 As ADODB.Recordset
    Dim str签名时间 As String
    Dim arr对象属性() As String
    Dim strSignName As String
    Dim strSignImgBase64 As String
    
    '源文提取规则：
    'intRule = 1时，提取 ID，病人ID，婴儿，创建人，创建时间，医生姓名，签名级别，签名时间,检查所见，诊断意见，建议
    '验证签名的时候，医生姓名，签名级别，签名时间从签名记录中获取，分别是医生姓名= “内容文本”，签名级别=“要素表示”，签名时间 =“对象属性（5）”
    '签名的时候，医生姓名，签名级别，签名时间 从签名对象中获取
    On Error GoTo err
    
    If lngReportID = 0 Or int签名版本 = 0 Then Exit Function
    
    
    '初始化默认值
    intRule = 1
    strSourceOut = ""
    
    '根据int提取类型 来判断是签名还是验证签名，分别从对应的地方提取数据
    '从电子病历记录中提取报告源文的基本信息
    strSQL = "Select ID,病人ID,婴儿,创建人,创建时间 From 电子病历记录 Where Id = [1]"
    Set rs病历记录 = zlDatabase.OpenSQLRecord(strSQL, "提取报告源文基本信息", lngReportID)
    If rs病历记录.RecordCount = 0 Then
        Exit Function
    End If
    
    '从电子病历内容中提取报告源文的内容信息
    strSQL = "Select a.内容文本 As 标题, b.对象属性, b.内容文本 As 正文,b.开始版 as 版本 From 电子病历内容 a,电子病历内容 b " & _
             " Where a.文件id = [1] And a.对象类型 = 3 And a.Id = b.父ID And b.对象类型 = 2 and b.开始版 = [2]  "
    Set rs病历内容 = zlDatabase.OpenSQLRecord(strSQL, "提取报告源文内容信息", lngReportID, int签名版本)
    If rs病历内容.RecordCount = 0 Then
        Exit Function
    End If
    
    If int提取类型 = 1 Then
        '签名，检查签名对象是否存在
        If thisSign Is Nothing Then
            Exit Function
        End If
    Else
        '验证签名，从签名记录中提取医生姓名，签名级别，签名时间信息,签名规则
        strSQL = "Select 内容文本 as 医生姓名 ,要素表示  as 签名级别 ,对象属性 From 电子病历内容 Where 文件ID = [1] And 对象类型 = 8 and 开始版 =[2] "
        Set rs签名记录 = zlDatabase.OpenSQLRecord(strSQL, "提取最后报告源文签名信息", lngReportID, int签名版本)
        If rs签名记录.RecordCount = 0 Then
            Exit Function
        End If
        
        '提取格式化的签名时间，签名规则
        arr对象属性 = Split(rs签名记录!对象属性, ";")
        If UBound(arr对象属性) >= 5 Then
            intRule = Val(arr对象属性(1))
            str签名时间 = Format(arr对象属性(4), "yyyy-MM-dd HH:mm:ss")
        End If
        If intRule = 0 Then Exit Function
    End If
    
    '根据规则组织报告源文： ID，病人ID，婴儿，创建人，创建时间，医生姓名，签名级别，签名时间,检查所见，诊断意见，建议
    If intRule = 1 Then
        '源文基本信息
        strSourceOut = rs病历记录!ID
        strSourceOut = strSourceOut & vbTab & nvl(rs病历记录!病人ID)
        strSourceOut = strSourceOut & vbTab & nvl(rs病历记录!婴儿)
        strSourceOut = strSourceOut & vbTab & nvl(rs病历记录!创建人)
        strSourceOut = strSourceOut & vbTab & nvl(rs病历记录!创建时间)
        
        '源文签名信息
        If int提取类型 = 1 Then
            '签名，从签名对象提取
            strSourceOut = strSourceOut & vbTab & thisSign.姓名
            strSourceOut = strSourceOut & vbTab & thisSign.签名级别
            strSourceOut = strSourceOut & vbTab & Format(thisSign.签名时间, "yyyy-MM-dd HH:mm:ss")
        Else
            '验证签名，从数据库签名记录提取
            strSignName = nvl(rs签名记录!医生姓名)
            If InStr(strSignName, M_STR_TAG_SIGNWITHIMG) > 0 Then
                strSignImgBase64 = Split(strSignName, M_STR_TAG_SIGNWITHIMG)(1)
                strSignName = Split(strSignName, M_STR_TAG_SIGNWITHIMG)(0)
            End If
 
            strSourceOut = strSourceOut & vbTab & strSignName
            strSourceOut = strSourceOut & vbTab & nvl(rs签名记录!签名级别)
            strSourceOut = strSourceOut & vbTab & str签名时间
        End If
        
        '源文报告内容
        rs病历内容.Filter = "标题 ='" & ReportViewType_检查所见 & "'"
        If rs病历内容.RecordCount = 0 Then
            strSourceOut = strSourceOut & vbTab
        Else
            strSourceOut = strSourceOut & vbTab & nvl(rs病历内容!正文)
        End If
        
        rs病历内容.Filter = "标题 ='" & ReportViewType_诊断意见 & "'"
        If rs病历内容.RecordCount = 0 Then
            strSourceOut = strSourceOut & vbTab
        Else
            strSourceOut = strSourceOut & vbTab & nvl(rs病历内容!正文)
        End If
        
        rs病历内容.Filter = "标题 ='" & ReportViewType_建议 & "'"
        If rs病历内容.RecordCount = 0 Then
            strSourceOut = strSourceOut & vbTab
        Else
            strSourceOut = strSourceOut & vbTab & nvl(rs病历内容!正文)
        End If
        
        '源文签名图像信息
        If gblUseImgSignValid Then
            If int提取类型 = 1 Then
                '从过程参数获取
                strSourceOut = strSourceOut & vbTab & strImg64
            Else
                '从数据库签名记录提取
                strSignImgBase64 = ImgFileNamesToBase64(strSignImgBase64, lngAdviceId)
                If gblnUseValidLog Then
                    Call WriteLog("签名验证Base64数据：" & vbLf & strSignImgBase64)
                End If
                If InStr("errN", strSignImgBase64) > 0 Then
                    Call SaveSetting("ZLSOFT", "公共模块\ZL9PACSWork", "图像签名错误信息", Mid(strSignImgBase64, 1, 20))
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
    '返回并保存原来默认的窗口过程指针
    If App.LogMode <> 0 Then
        '用自定义程序代替原来的window程序
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
''功能：元素写入窗口的windows消息处理程序，专门处理鼠标滚轮 消息
''参数：
''返回：
''------------------------------------------------
    Dim pt As POINTAPI
    Dim wzDelta As Integer
    
    On Error Resume Next
    
    wzDelta = OS.HIWORD(wParam)
    
    Select Case Msg
        Case WM_MOUSEWHEEL
            If Sgn(wzDelta) = 1 Then    '鼠标上滚
                Call fReportElement.subMouseWheel(1)
            Else                        '鼠标下滚
                Call fReportElement.subMouseWheel(2)
            End If
    End Select
    
    '调用原来的窗口过程
    ElementWindowProc = CallWindowProc(glngEelmentWinProc, hwnd, Msg, wParam, lParam)
End Function

Private Function ImgFileNamesToBase64(ByVal strImgFileNames As String, ByVal lngAdviceId As Long) As String
'将"文件名_1;文件名_2;文件名_3"转化为"base64_1;banse64_2;base64_3"的形式
On Error GoTo errH
    Dim objFile As New Scripting.FileSystemObject
    
    Dim strBase64 As String
    
    Dim strSQL As String
    Dim rsTemp As Recordset
    Dim strLocalDir As String
    Dim strImgName() As String
    Dim i As Integer, lngResult As Long
    Dim strPathTmp As String
    Dim blnIsMark As Boolean '是否标记图
    Dim strFtpDir As String
    Dim strLocalPath As String
    Dim strSaveDeviceID As String
    Dim strFTPDirUrl As String, strFtpIp As String, strFTPUser As String, strFTPPwd As String, struFtpTag As TFtpConTag
    Dim strPathCheck As String
    Dim strNewDirectory As String
    
    If gblnUseValidLog Then
        Call WriteLog("验证签名图像文件名称：" & vbLf & strImgFileNames)
    End If
    
    strSQL = "Select 位置一,位置二,检查UID,接收日期 From 影像检查记录 Where 检查UID is not null And 医嘱ID = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "hehe", lngAdviceId)
    
    If rsTemp.RecordCount > 0 Then
        strLocalDir = App.Path & "\TmpImage\" & Format(nvl(rsTemp!接收日期), "yyyyMMdd") & "\" & nvl(rsTemp!检查UID) & "\"
         strSaveDeviceID = nvl(rsTemp!位置一)
        If strSaveDeviceID = "" Then
            strSaveDeviceID = nvl(rsTemp!位置二)
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
        '判断文件是否存在，若存在，转化为base64
        '若不存在 从FTP下载然后转化为base64，若下载失败。最终也没办法验证签名
        
        If objFile.FileExists(strPathTmp) Then
            If strBase64 <> "" Then strBase64 = strBase64 & ";"
            
            strBase64 = strBase64 & zlStr.EncodeBase64_File(strPathTmp)
        Else
            '从FTP下载文件
            If blnIsMark Then
                strFtpDir = "MarkImages/"
                strPathCheck = App.Path & "\TmpImage\MarkImages"
                strLocalPath = strPathCheck & "\" & strImgName(i)
            Else
                strFtpDir = Format(nvl(rsTemp!接收日期), "yyyyMMdd") & "/" & nvl(rsTemp!检查UID)
                strPathCheck = App.Path & "\TmpImage\" & Format(nvl(rsTemp!接收日期), "yyyyMMdd") & "\" & nvl(rsTemp!检查UID)
                strLocalPath = strPathCheck & "\" & strImgName(i)
            End If
            
            '如果没有目录，则创建目录
            If Dir(strPathCheck, vbDirectory) = "" Then
                strNewDirectory = App.Path & "\TmpImage"
                If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                
                If blnIsMark Then
                    strNewDirectory = strNewDirectory & "\MarkImages"
                    If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                Else
                    strNewDirectory = strNewDirectory & "\" & Format(nvl(rsTemp!接收日期), "yyyyMMdd")
                    If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                    
                    strNewDirectory = strNewDirectory & "\" & nvl(rsTemp!检查UID)
                    If Not DirExists(strNewDirectory) Then MkDir strNewDirectory
                End If
            End If
            
            If strSaveDeviceID <> "" Then
                Call GetFtpDeviceWithDeviceNo(Nothing, strSaveDeviceID, strFTPDirUrl, strFtpIp, strFTPUser, strFTPPwd)
    
                struFtpTag = FtpTagInstance(strFtpIp, strFTPUser, strFTPPwd, strFTPDirUrl & strFtpDir)
            Else
                '终止
                ImgFileNamesToBase64 = "errN1:缺少FTP位置信息,无法继续验证"
                Exit Function
            End If
            
            lngResult = FtpDownload(struFtpTag, strImgName(i), strLocalPath, False)
            
            If lngResult = frAbort Then
                '终止
                ImgFileNamesToBase64 = "errN2:FTP下载失败"
                Exit Function
            End If
            
            If strBase64 <> "" Then strBase64 = strBase64 & ";"
            strBase64 = strBase64 & zlStr.EncodeBase64_File(strPathTmp)
        End If
    Next
    
    ImgFileNamesToBase64 = strBase64
    Exit Function
errH:
    '终止
    ImgFileNamesToBase64 = "errN3:" & err.Description
    Call err.Raise(0, , "根据文件名称产生base64数据异常-" & err.Description)
    Resume
End Function


Public Function GetReportImgPath(ByVal lngAdviceId As Long, ByVal blnIsMoved As Boolean) As String
'获取报告图路径
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    GetReportImgPath = ""
    
    strSQL = "select to_Char(a.接收日期,'YYYYMMDD') as 接收日期,a.检查号,a.检查UID,to_Char(b.报到时间,'YYYYMMDD') as 报到时间 " & _
            " From 影像检查记录 a, 病人医嘱发送 b " & _
            " where a.医嘱ID=b.医嘱ID and a.发送号=b.发送号 and a.医嘱ID=[1]"
            
    If blnIsMoved Then
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
        strSQL = Replace(strSQL, "病人医嘱发送", "H病人医嘱发送")
    End If
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "查询影像接收信息", lngAdviceId)
     
    If rsTemp.RecordCount <= 0 Then Exit Function
     
    If nvl(rsTemp!检查UID) = "" Or nvl(rsTemp!接收日期) = "" Then
        GetReportImgPath = FormatFilePath(SysRootPath & "\Apply\TmpImage\" & nvl(rsTemp!报到时间) & "(RLATIMG)\" & lngAdviceId & "\")
    Else
        GetReportImgPath = FormatFilePath(SysRootPath & "\Apply\TmpImage\" & nvl(rsTemp!接收日期) & "\" & nvl(rsTemp!检查UID) & "\")
    End If
End Function


Public Sub SetWordStyle(rtxtWord As RichTextBox, Optional ByVal lngFontSize As Single = 0)
    Dim strCurContext As String
    Dim lngSIndex As Long
    Dim lngEIndex As Long
    Dim lngBaseIndex As Long
    
    '重设字体
    If lngFontSize <> 0 Then rtxtWord.SelFontSize = lngFontSize
    
    strCurContext = rtxtWord.Text
    
    '处理{{}}标记
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
    
    
    '处理{<>}标记
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
