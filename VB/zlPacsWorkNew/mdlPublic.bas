Attribute VB_Name = "mdlPublic"
Option Explicit

Public lngTXTProc As Long '����Ĭ�ϵ���Ϣ�����ĵ�ַ
Public glngOld As Long, glngFormW As Long, glngFormH As Long

Public Enum TNeedType
    tNeedName = 0
    tNeedNo = 1
    tNeedAll = 2
End Enum

Public Modifiers As Long, uVirtKey As Long, idHotKey As Long

Public Enum Enum_Inside_Program
    p���ﲡ������ = 1250
    pסԺ�������� = 1251
    p����ҽ���´� = 1252
    pסԺҽ���´� = 1253
    pסԺҽ������ = 1254
    p�����¼���� = 1255
    p�����¼���� = 1256
    pҽ�����ѹ��� = 1257
    p���Ʊ������ = 1258
    p������ϲο� = 1270
    pҩƷ���Ʋο� = 1271
    p���˲������� = 1273
    p������Ӳ��� = 2251
    pסԺ���Ӳ��� = 2252
End Enum

Public gcolPrivs As Collection              '��¼�ڲ�ģ���Ȩ��
'DICOMͼ�����
Public Const ATTR_������� As String = "8:20"
Public Const ATTR_���ʱ�� As String = "8:30"
Public Const ATTR_Ӱ����� As String = "8:60"
Public Const ATTR_����豸 As String = "8:1090"

Public Const C_FUNC_STR_���� As String = "����"
Public Const C_FUNC_STR_��д���� As String = "��д"
Public Const C_FUNC_STR_��Ƭ As String = "��Ƭ"
Public Const C_FUNC_STR_��� As String = "���"
Public Const C_FUNC_STR_�鿴������Ϣ As String = "�鿴��Ϣ"
Public Const C_LAYOUT_LISTLEFT As Integer = 30

'�������ݷָ���
Public Const SPLITER_REPORT = "[[@]]"
Public Const SPLITER_ELEMENT = "[[;]]"
'���洰��
Public Const Report_Form_frmReportES  As String = "�ھ�������Ϣ"
Public Const Report_Form_frmReportPathology As String = "������Һ��������Ϣ"
Public Const Report_Form_frmReportUS As String = "B�����������Ϣ"
Public Const Report_Form_frmReportCustom As String = "�Զ���ר�Ʊ���"

'Public gobjLogFile As clsLogFile
Public gblnUseDebugLog As Boolean
Public gblUsePacsQuery As Boolean
Public gblnUsePacsV2 As Boolean
Public gblUseImgSignValid As Boolean '�Ƿ�����ǩ��ͼ����֤
Public gblnUseValidLog As Boolean



'�����ı�������ֵ
Public Sub TxtInputControl(ByRef TxtBox As TextBox, ByRef KeyAscii As Integer, ByVal intDecimalPointNum As Integer)
'txtBox���ı���ؼ�
'intDecimalPointNum��С����λ��
'KeyAscii:�����ASC

    If Chr(KeyAscii) = "." Then
        If InStr(TxtBox.Text, ".") > 0 Then KeyAscii = 0
    End If
    
    If InStr(TxtBox.Text, ".") > 0 And KeyAscii <> 8 Then
        If Len(Mid(TxtBox.Text, InStr(TxtBox.Text, ".") + 1)) >= intDecimalPointNum Then KeyAscii = 0
    End If
End Sub


'��ȡ�������Ӧ������
Public Function GetKeyAliasEx(ByVal lngVirtualKey As Long) As String
    GetKeyAliasEx = ""
    
    If lngVirtualKey >= 59 And lngVirtualKey <= 68 Then
        GetKeyAliasEx = "F" & (lngVirtualKey - 58)
    End If
    
    If lngVirtualKey >= 87 And lngVirtualKey <= 88 Then
        GetKeyAliasEx = "F" & (lngVirtualKey - 76)
    End If
End Function

'ȡ����ϼ�����
Public Function GetKeyAlias(ByVal KeyCode As Integer, ByVal Shift As Integer) As String

    Dim strShift As String
    Dim strTemp As String
    Dim lngVkState As Long
    
    lngVkState = (Shift And vbCtrlMask) Or GetAsyncKeyState(VK_CONTROL)
    strShift = IIf(lngVkState <> 0, "CTRL", "")
    
    lngVkState = (Shift And vbShiftMask) Or GetAsyncKeyState(VK_SHIFT)
    strTemp = IIf(lngVkState <> 0, "SHIFT", "")
    If strTemp <> "" Then
        If strShift <> "" Then strShift = strShift & "+"
        strShift = strShift & strTemp
    End If
    
    lngVkState = (Shift And vbAltMask) Or GetAsyncKeyState(VK_MENU)
    strTemp = IIf(lngVkState <> 0, "ALT", "")
    If strTemp <> "" Then
        If strShift <> "" Then strShift = strShift & "+"
        strShift = strShift & strTemp
    End If
            
             
    strTemp = ""
    If KeyCode >= 48 And KeyCode <= 90 Then
        strTemp = Chr(KeyCode)
        
        If strShift = "" Then strShift = "MENU"
    End If
    
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        strTemp = "F" & (KeyCode - 111)
    End If
    
    Select Case KeyCode
        Case vbKeySpace
            strTemp = "SPACE"
    End Select
    
    
    If strTemp <> "" Then
        If strShift <> "" Then strShift = strShift & "+"
        strShift = strShift & strTemp
    End If
    
    GetKeyAlias = strShift
                
End Function

Public Sub WriteLog(ByVal strLog As String)
'д����־
'    '���δ���õ�����־����ֱ���˳�
'    If Not gblnUseDebugLog Then Exit Sub
'
'    '��ʼ����־����
'    If gobjLogFile Is Nothing Then
'        Set gobjLogFile = New clsLogFile
'    End If
'
'    If gobjLogFile.OpenLog() Then
'        Call gobjLogFile.WriteLog(strLog)
'        Call gobjLogFile.CloseLog
'    End If
    LogWrite "PACS��Ҫ���ܵ�����־", glngModul, "ģ��������̸���", strLog
End Sub

Public Sub OutputDebug(ByVal strMethob As String, objErr As ErrObject)
    OutputDebugString "[" & App.ProductName & "]" & strMethob & "��" & objErr.Description
End Sub


Public Sub RaiseErr(objErr As ErrObject)
    Call err.Raise(objErr.Number, objErr.Source, objErr.Description, objErr.HelpFile, objErr.HelpContext)
End Sub

Public Function GetColNum(listTemp As Object, strHead As String) As Integer
    Dim i As Integer
    Select Case UCase(TypeName(listTemp))
        Case UCase("ReportControl")
            For i = 0 To listTemp.Columns.Count - 1
                If listTemp.Columns.Column(i).Caption = strHead Then GetColNum = listTemp.Columns.Column(i).ItemIndex: Exit Function
            Next
        Case UCase("ListView")
            For i = 1 To listTemp.ColumnHeaders.Count
                If listTemp.ColumnHeaders(i).Text = strHead Then GetColNum = i: Exit Function
            Next
        Case UCase("MSHFlexGrid") '�������ʹ�������δ�õ�
        Case UCase("BillEdit")
        Case UCase("VSFlexGrid")
            For i = 0 To listTemp.Cols - 1
                If listTemp.TextMatrix(0, i) = strHead Then GetColNum = i: Exit Function
            Next
        Case UCase("BillEdit")
        Case UCase("DataGrid")
    End Select
End Function

Public Sub SeekIndex(objCbo As Object, ByVal strtext As String, Optional blnEvent As Boolean, Optional blnPreserve As Boolean = False, Optional intIsSearchNo As TNeedType = tNeedName)
'���ܣ���ComboBox�в��Ҳ���λ
'������blnEvent=��λʱ�Ƿ񴥷�Click�¼�
      'blnPreserve--����Ҳ���ƥ����Ŀ���򱣳�ԭ����Ŀ
      'intIsSearchNo -- 0:ͨ�����붨λ,1:ͨ�����ֶ�λ,2:�ù���������ֶ�λ
'˵����δ�ܶ�λʱ,����ListIndex=-1
'       Cbo.SeekIndex���ܱȽϼ򵥣�����index��ᴥ���¼������ʺ�ʹ��
    Dim i As Long

    For i = 0 To objCbo.ListCount - 1
        If IIf(Abs(intIsSearchNo) = tNeedAll, objCbo.list(i), IIf(Abs(intIsSearchNo) = tNeedNo, zlStr.NeedCode(objCbo.list(i)), zlStr.NeedName(objCbo.list(i)))) = strtext Then
            If blnEvent Then
                objCbo.ListIndex = i
            Else
                Call zlControl.CboSetIndex(objCbo.hwnd, i)
            End If
            Exit Sub
        End If
    Next
    
    If blnPreserve = True Then
        If blnEvent = False Then
            Call zlControl.CboSetIndex(objCbo.hwnd, objCbo.ListIndex)
        End If
    Else
        If blnEvent Then
            objCbo.ListIndex = -1
        Else
            Call zlControl.CboSetIndex(objCbo.hwnd, -1)
        End If
    End If
    
End Sub

Public Function PreFixNO(Optional curDate As Date = #1/1/1900#) As String
'���ܣ����ش�д�ĵ��ݺ���ǰ׺
    If curDate = #1/1/1900# Then
        PreFixNO = CStr(CInt(Format(zlDatabase.Currentdate, "YYYY")) - 1990)
    Else
        PreFixNO = CStr(CInt(Format(curDate, "YYYY")) - 1990)
    End If
    PreFixNO = IIf(CInt(PreFixNO) < 10, PreFixNO, Chr(55 + CInt(PreFixNO)))
End Function

Public Function GetInsidePrivs(ByVal lngProg As Enum_Inside_Program, Optional ByVal blnLoad As Boolean) As String
'���ܣ���ȡָ���ڲ�ģ���������е�Ȩ��
'������blnLoad=�Ƿ�̶����¶�ȡȨ��(���ڹ���ģ���ʼ��ʱ,�����û�ͨ��ע���ķ�ʽ�л���)
    Dim strPrivs As String
    
    If gcolPrivs Is Nothing Then
        Set gcolPrivs = New Collection
    End If
    
    On Error Resume Next
    strPrivs = gcolPrivs("_" & lngProg)
    If err.Number = 0 Then
        If blnLoad Then
            gcolPrivs.Remove "_" & lngProg
        End If
    Else
        err.Clear: On Error GoTo 0
        blnLoad = True
    End If
    
    If blnLoad Then
        strPrivs = GetPrivFunc(glngSys, lngProg)
        gcolPrivs.Add strPrivs, "_" & lngProg
    End If
    GetInsidePrivs = IIf(strPrivs <> "", ";" & strPrivs & ";", "")
End Function

Public Function TranPasswd(strOld As String) As String
    '------------------------------------------------
    '���ܣ� ����ת������
    '������
    '   strOld��ԭ����
    '���أ� �������ɵ�����
    '------------------------------------------------
    Dim intDo As Integer
    Dim strPass As String, strReturn As String, strSource As String, strTarget As String
    
    strPass = "WriteByZybZL"
    strReturn = ""
    
    For intDo = 1 To 12
        strSource = Mid(strOld, intDo, 1)
        strTarget = Mid(strPass, intDo, 1)
        strReturn = strReturn & Chr(Asc(strSource) Xor Asc(strTarget))
    Next
    TranPasswd = strReturn
End Function


Public Sub SetWindowStyle(ByVal lngHandle As Long, Optional ByVal blnIsChild As Boolean = True)
'����ʹ��zlControl.FormSetCaption���棬zlControl.FormSetCaption�л������˴���λ�ã��ᵼ��Ƕ��ʽ�����λ�øı�
    Dim lngWindowStyle As Long
    
    lngWindowStyle = GetWindowLong(lngHandle, GWL_STYLE)
    
'    If (lngWindowStyle And WS_CHILD) = WS_CHILD Then Exit Sub
    
    lngWindowStyle = lngWindowStyle And Not (WS_SYSMENU Or WS_CAPTION Or WS_MAXIMIZEBOX Or WS_MINIMIZEBOX Or WS_THICKFRAME)

    If blnIsChild Then
        Call SetWindowLong(lngHandle, GWL_STYLE, lngWindowStyle Or WS_CHILD) '  --WS_CHILD
    Else
        Call SetWindowLong(lngHandle, GWL_STYLE, lngWindowStyle) 'Or WS_CHILD  --WS_CHILD �ᵼ��Activate�¼�ʧЧ
    End If
End Sub




Public Function GetProFmt(ByVal strProName As String, ByVal strProValue As String) As String
    GetProFmt = strProName & ":" & strProValue & ";"
End Function

Public Function GetPros(ByVal strLayout As String, ByVal strKey As String) As String
    Dim lngKeyIndex As Long
    Dim strPros As String
    
    GetPros = ""
    If Len(strLayout) <= 0 Then Exit Function
    
    lngKeyIndex = InStr(strLayout, "[KEY=" & strKey & "@")
    If lngKeyIndex > 0 Then
        strPros = Mid(strLayout, lngKeyIndex + Len(strKey) + 6, 2048)
        strPros = Mid(strPros, 1, InStr(strPros, "]") - 1)
    Else
        strPros = strLayout
    End If
    
    GetPros = strPros
End Function

Public Function GetProValue(ByVal strPros As String, ByVal strProName As String) As String
'��ȡ����ֵ
    Dim lngKeyIndex As Long
    Dim strPro As String
    
    strPro = ""
    lngKeyIndex = InStr(strPros, strProName & ":")
    If lngKeyIndex > 0 Then
        strPro = Mid(strPros, lngKeyIndex + Len(strProName) + 1, 2048)
        strPro = Mid(strPro, 1, InStr(strPro, ";") - 1)
    End If
    
    GetProValue = strPro
End Function


