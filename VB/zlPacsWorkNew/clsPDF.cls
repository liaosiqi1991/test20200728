VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsPDF"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'######################################################################################################################
'ģ�����ƣ�clsPDF
'ģ��˵�������Ϊָ����PDF�ļ�
'ģ�����ݣ�
'
'######################################################################################################################

'ע����ؼ��ָ�����
Private Enum REGRoot
    HKEY_CLASSES_ROOT = &H80000000
    HKEY_CURRENT_USER = &H80000001
    HKEY_LOCaL_MaCHINE = &H80000002
    HKEY_USERS = &H80000003
    HKEY_PERFORMANCE_DATA = &H80000004
    HKEY_CURRENT_CONFIG = &H80000005
End Enum

'ע�����������
Private Enum REGValueType
    REG_SZ = 1 'Unicode���ս��ַ���
    REG_EXPAND_SZ = 2 'Unicode���ս��ַ���
    REG_BINARY = 3 '��������ֵ
    REG_DWORD = 4 '32-bit ����
    REG_DWORD_BIG_ENDIAN = 5
    REG_LINK = 6
    REG_MULTI_SZ = 7 ' ��������ֵ��
End Enum

'ע���ѡ��
Private Const REaD_CONTROL = &H20000
Private Const KEY_QUERY_VaLUE = &H1
Private Const KEY_SET_VaLUE = &H2
Private Const KEY_CREaTE_Sub_KEY = &H4
Private Const KEY_ENUMERaTE_Sub_KEYS = &H8
Private Const KEY_NOTIFY = &H10
Private Const KEY_CREaTE_LINK = &H20
Private Const KEY_READ = KEY_QUERY_VaLUE + KEY_ENUMERaTE_Sub_KEYS + KEY_NOTIFY + REaD_CONTROL
Private Const KEY_WRITE = KEY_SET_VaLUE + KEY_CREaTE_Sub_KEY + REaD_CONTROL
Private Const KEY_EXECUTE = KEY_READ
Private Const KEY_aLL_aCCESS = KEY_QUERY_VaLUE + KEY_SET_VaLUE + KEY_CREaTE_Sub_KEY + KEY_ENUMERaTE_Sub_KEYS + KEY_NOTIFY + KEY_CREaTE_LINK + REaD_CONTROL

'��������ֵ
Private Const ERROR_SUCCESS = 0
Private Const ERROR_BADKEY = 2
Private Const ERROR_ACCESS_DENIED = 8

Private Declare Function RegOpenKeyEx Lib "advapi32.dll" Alias "RegOpenKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal ulOptions As Long, ByVal samDesired As Long, phkResult As Long) As Long
Private Declare Function RegQueryValueEx_BINARY Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpvalueName As String, ByVal lpReserved As Long, lpType As Long, lpData As Any, lpcbData As Long) As Long
Private Declare Function RegSetValueEx_BINARY Lib "advapi32.dll" Alias "RegSetValueExA" (ByVal hKey As Long, ByVal lpvalueName As String, ByVal reserved As Long, ByVal dwType As Long, lpData As Any, ByVal cbData As Long) As Long
Private Declare Function RegDeleteValue Lib "advapi32.dll" Alias "RegDeleteValueA" (ByVal hKey As Long, ByVal lpvalueName As String) As Long
Private Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hKey As Long) As Long
Private Declare Function GetTempPath Lib "kernel32" Alias "GetTempPathA" (ByVal nBufferLength As Long, ByVal lpBuffer As String) As Long
Private Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Long, ByVal lpProcName As String) As Long
Private Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Long
Private Declare Function GetCurrentProcess Lib "kernel32" () As Long
Private Declare Function IsWow64Process Lib "kernel32" (ByVal hProc As Long, bWow64Process As Boolean) As Long
     
Private mblnReset As Boolean
Private marrReset() As Byte
Private mstrError As String
Private mblnAllow As Boolean

'######################################################################################################################
'����
Public Function PDFInitialize() As Boolean
    '******************************************************************************************************************
    '���ܣ���ʼ�����������Ƿ�����������PDF
    '���أ�����True��ʾ���������PDF�ļ���False��ʾ�����������PDF�ļ�
    '******************************************************************************************************************
    Dim strPDFFile As String
    Dim strPath As String * 255
    
    On Error GoTo errHand
    
    mblnAllow = False
       
    '�޸�ע�����Ϣ
    '------------------------------------------------------------------------------------------------------------------
    Call GetTempPath(255, strPath)
    strPDFFile = Trim(Left(strPath, InStr(strPath, Chr(0)) - 1)) & "Demo.pdf"
    If Dir(strPDFFile) <> "" Then
        Kill strPDFFile
        DoEvents
    End If
    
    If ModifyRegist(strPDFFile, False, False, False, "", "") = False Then Exit Function
    
    If CheckFoxitPDF() = False Then Exit Function
    'ģ�����
    '------------------------------------------------------------------------------------------------------------------
    If OutputDemo() = False Then Exit Function
        
    PDFInitialize = True
    
    mblnAllow = True
    
    Exit Function
    '------------------------------------------------------------------------------------------------------------------
errHand:
    mstrError = err.Description
End Function

Public Function PDFFile(ByVal strPDFFile As String, _
                        Optional ByVal blnCopyable As Boolean = False, _
                        Optional ByVal blnEditable As Boolean = False, _
                        Optional ByVal blnPrintable As Boolean = False, _
                        Optional ByVal strPassWord As String = "", _
                        Optional ByVal strAttachs As String = "") As Boolean
    '******************************************************************************************************************
    '���ܣ��������PDF�ļ��Ļ���
    '������strPDFFile=����ļ����������ļ�·�����ļ���չ��
    '                 �ļ�·��������ڣ��һ��Զ�����ͬ���ļ�
    '                 ���δָ�����򵯳��ļ�����Ի���
    '      blnCopyable=�����PDF�ļ��Ƿ�������������
    '      blnEditable=�����PDF�ļ��Ƿ������༭����
    '      blnPrintable=�����PDF�ļ��Ƿ�������ӡ���
    '      strPassword=�Ƿ�Ҫ����������
    '      strAttachs=Ҫ�ӵ�PDF�еĸ����ļ���(����·��),�����"|"�ָ�
    '���أ�
    'ע�⣺�ú�����Ҫ��Printer���κδ�ӡ����֮ǰ����(����API��ʽ����)
    '******************************************************************************************************************
        
    On Error GoTo errHand
    
    If mblnAllow = False Then Exit Function
            
    '�޸�ע�����Ϣ
    '------------------------------------------------------------------------------------------------------------------
    If strPDFFile = "" Then
        mstrError = "δָ��PDF�ļ����ƣ��������PDF��"
        Exit Function
    End If
    
    PDFFile = ModifyRegist(strPDFFile, blnCopyable, blnEditable, blnPrintable, strPassWord, strAttachs)
    
    Exit Function
    '------------------------------------------------------------------------------------------------------------------
errHand:
    mstrError = err.Description
End Function

Public Function GetLastError() As String
    GetLastError = mstrError
End Function

'######################################################################################################################
'˽��
Private Function Is64bit() As Boolean
    '******************************************************************************************************************
    '���ܣ�
    '���أ�
    '******************************************************************************************************************
    Dim Handle As Long
    Dim bolFunc As Boolean
        
    bolFunc = False
    Handle = GetProcAddress(GetModuleHandle("kernel32"), "IsWow64Process")
    If Handle > 0 Then
        IsWow64Process GetCurrentProcess(), bolFunc
    End If
    Is64bit = bolFunc
End Function

Private Function CheckFoxitPDF() As Boolean
    '******************************************************************************************************************
    '���ܣ�
    '���أ�
    '******************************************************************************************************************
    
    Dim intLoop As Integer
    
    CheckFoxitPDF = False
    '����Ƿ����Foxit��ӡ��
    For intLoop = 0 To Printers.Count - 1
        
        If UCase(Printers(intLoop).DeviceName) = UCase("Foxit Reader PDF Printer") Then
            Set Printer = Printers(intLoop)
            Exit For
        End If
    Next
    
    If intLoop >= Printers.Count Then
        CheckFoxitPDF = False
        Exit Function
    End If
    CheckFoxitPDF = True

End Function

Private Function ModifyRegist(ByVal strPDFFile As String, Optional ByVal blnCopyable As Boolean, Optional ByVal blnEditable As Boolean, Optional ByVal blnPrintable As Boolean, Optional ByVal strPassWord As String, Optional ByVal strAttachs As String) As Boolean
    '******************************************************************************************************************
    '���ܣ�ָ��TinyPDF��ӡ���������
    '������strPDFFile=����ļ����������ļ�·�����ļ���չ��
    '                 �ļ�·��������ڣ��һ��Զ�����ͬ���ļ�
    '                 ���δָ�����򵯳��ļ�����Ի���
    '      blnCopyable=�����PDF�ļ��Ƿ�������������
    '      blnEditable=�����PDF�ļ��Ƿ������༭����
    '      blnPrintable=�����PDF�ļ��Ƿ�������ӡ���
    '      strPassword=�Ƿ�Ҫ����������
    '      strAttachs=Ҫ�ӵ�PDF�еĸ����ļ���(����·��),�����"|"�ָ�
    'ע�⣺�ú�����Ҫ��Printer���κδ�ӡ����֮ǰ����(����API��ʽ����)
    '******************************************************************************************************************
    Dim arrData() As Byte
    Dim intSect As Integer, intAdr As Integer
    Dim intTag As Integer, strFile As String
    Dim i As Integer, j As Integer
    Dim strWord As String
    Dim strRegister(92) As String
    Dim aryRegister As Variant
    Dim intLoop As Integer
            
            
    '��ȡ����
    GetRegValueBinary HKEY_CURRENT_USER, "Printers\DevModePerUser", "TinyPDF", arrData
    
    On Error Resume Next
    err = 0
    i = UBound(arrData)
    If err <> 0 Then i = -1
    On Error GoTo errHand
    
    If i = -1 Then
        '��ע���

        strRegister(0) = "84,0,105,0,110,0,121,0,80,0,68,0,70,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(1) = "0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,4,220,0,236,16,19,78,1,0,1,0,9,0,0,0,0,0,100,0,1,0,15,0,88,2,2,0,1,0,0,0,3,0,0"
        strRegister(2) = "0,65,117,116,111,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(3) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(4) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,63,0,0,0,1,0,0,0,3,0,0,0,44,1,0,0,194,1,0,0,2,80,0,0,3,0,0"
        strRegister(5) = "0,44,1,0,0,194,1,0,0,2,80,0,0,3,0,0,0,176,4,0,0,8,7,0,0,2,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,100,0,0,0,2,0,0,0,6"
        strRegister(6) = "0,0,0,1,3,0,0,26,1,0,0,44,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(7) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1"
        strRegister(8) = "0,0,0,0,0,0,0,70,1,0,0,72,1,0,0,0,0,0,0,74,1,0,0,76,1,0,0,78,1,0,0,80,1,0,0,82,1,0,0,84,1,0,0,86,1,0,0,88,1,0"
        strRegister(9) = "0,90,1,0,0,0,0,0,0,0,0,65,0,114,0,105,0,97,0,108,0,0,0,65,0,114,0,105,0,97,0,108,0,32,0,78,0,97,0,114,0,114,0,111,0,119,0,0,0,65"
        strRegister(10) = "0,114,0,105,0,97,0,108,0,32,0,85,0,110,0,105,0,99,0,111,0,100,0,101,0,32,0,77,0,83,0,0,0,67,0,101,0,110,0,116,0,117,0,114,0,121,0,32,0,71"
        strRegister(11) = "0,111,0,116,0,104,0,105,0,99,0,0,0,67,0,111,0,117,0,114,0,105,0,101,0,114,0,32,0,78,0,101,0,119,0,0,0,71,0,101,0,111,0,114,0,103,0,105,0,97"
        strRegister(12) = "0,0,0,73,0,109,0,112,0,97,0,99,0,116,0,0,0,76,0,117,0,99,0,105,0,100,0,97,0,32,0,67,0,111,0,110,0,115,0,111,0,108,0,101,0,0,0,84,0,97"
        strRegister(13) = "0,104,0,111,0,109,0,97,0,0,0,84,0,105,0,109,0,101,0,115,0,32,0,78,0,101,0,119,0,32,0,82,0,111,0,109,0,97,0,110,0,0,0,84,0,114,0,101,0,98"
        strRegister(14) = "0,117,0,99,0,104,0,101,0,116,0,32,0,77,0,83,0,0,0,86,0,101,0,114,0,100,0,97,0,110,0,97,0,0,0,0,0,115,82,71,66,32,73,69,67,54,49,57,54,54"
        strRegister(15) = "45,50,46,49,0,85,46,83,46,32,87,101,98,32,67,111,97,116,101,100,32,40,83,87,79,80,41,32,118,50,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(16) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(17) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(18) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(19) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(20) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(21) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(22) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(23) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(24) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(25) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(26) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(27) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(28) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(29) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(30) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(31) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(32) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(33) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(34) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(35) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(36) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(37) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(38) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(39) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(40) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(41) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(42) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(43) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(44) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(45) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(46) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(47) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(48) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(49) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(50) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(51) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(52) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(53) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(54) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(55) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(56) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(57) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(58) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(59) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(60) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(61) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(62) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(63) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(64) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(65) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(66) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(67) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(68) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(69) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(70) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(71) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(72) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(73) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(74) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(75) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(76) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(77) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(78) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(79) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(80) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(81) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(82) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(83) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(84) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(85) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(86) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(87) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(88) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(89) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(90) = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        strRegister(91) = "0"
        
        For i = 0 To 91
            aryRegister = Split(strRegister(i), ",")
            
            For j = 0 To UBound(aryRegister)
                ReDim Preserve arrData(intLoop)
                arrData(intLoop) = Val(aryRegister(j))
                intLoop = intLoop + 1
            Next
            
        Next
    End If
    
    If Not mblnReset Then
        marrReset = arrData
        mblnReset = True
    End If

    '��������
    arrData(Val("&H00E0")) = &H0 'ҳ�߾�
    arrData(Val("&H00E1")) = &H0 'ҳ�߾�
    arrData(Val("&H00E4")) = &H0 '���Զ���
    arrData(Val("&H011C")) = &H1 'Ƕ����������
    arrData(Val("&H0130")) = &H0 'RGB��ɫ(sRGB������)
    
    If strPassWord <> "" Then
        arrData(Val("&H013C")) = &H1 '���û�����
        For i = 1 To Len(strPassWord)
            arrData(Val("&H0140") + i - 1) = Asc(Mid(strPassWord, i, 1))
        Next
        arrData(Val("&H0140") + i - 1) = &H0
    Else
        arrData(Val("&H013C")) = &H0 '���û�����
        arrData(Val("&H0140")) = &H0
    End If
    
    arrData(Val("&H0164")) = &H1 '���а�ȫ����
    arrData(Val("&H0168")) = &H0  '��ȫ��������Ϊ��
    If blnPrintable Then
        arrData(Val("&H0189")) = &H2  '�����߷ֱ��ʴ�ӡ
    Else
        arrData(Val("&H0189")) = &H0  '��������ӡ
    End If
    If blnEditable Then
        arrData(Val("&H018A")) = &H4  '����ȡҳ��֮����κ�����
    Else
        arrData(Val("&H018A")) = &H0  '����������
    End If
    If blnCopyable Then
        arrData(Val("&H018C")) = &H1  '������������
    Else
        arrData(Val("&H018C")) = &H0  '����������
    End If
    arrData(Val("&H0190")) = &H1  '����������ʱ��������Ļ�Ķ����豸�Ӿ�����ط����ı�
    If strPDFFile <> "" Then
        arrData(Val("&H0194")) = &H2  'ָ���ļ����(����·��)
    Else
        arrData(Val("&H0194")) = &H0  '��ʾ���
    End If
    arrData(Val("&H01A0")) = &H1  'ֱ�Ӹ����ļ�
    
    '���ݶΣ�����ļ��������ļ�
    arrData(Val("&H01C8")) = &H0
    arrData(Val("&H01C8") + 1) = &H0
    intAdr = Val("&H01CA")
    intSect = 1 '���ݶ����
    intTag = 1 '1-��������,2-�������
    Do While intAdr <= 4552
        If intSect = 1 Or intSect = 2 Then 'Ƕ��/��Ƕ�������
            If arrData(intAdr) = 0 And arrData(intAdr + 1) = 0 Then
                If intTag = 1 Then
                    intTag = 2
                ElseIf intTag = 2 Then
                    intTag = 1
                    intSect = intSect + 1
                End If
            Else
                intTag = 1
            End If
            intAdr = intAdr + 2
        ElseIf intSect = 3 Then '�м�����
            If arrData(intAdr) = 0 Then
                intAdr = intAdr + 1
            Else
                intSect = intSect + 1
            End If
        ElseIf intSect = 4 Or intSect = 5 Then 'RGB/CMYK�����ļ���
            If arrData(intAdr) = 0 Then
                intSect = intSect + 1
            End If
            intAdr = intAdr + 1
        ElseIf intSect = 6 Then '���Ŀ¼��
            strWord = Hex(intAdr - Val("&H01C8"))
            strWord = String(4 - Len(strWord), "0") & strWord
            arrData(Val("&H0198")) = Val("&H" & Right(strWord, 2)) '��λ�ֽ�
            arrData(Val("&H0198") + 1) = Val("&H" & Left(strWord, 2)) '��λ�ֽ�
            
            arrData(intAdr) = 0
            arrData(intAdr + 1) = 0
            intAdr = intAdr + 2
            intSect = intSect + 1
        ElseIf intSect = 7 Then '����ļ���
            strWord = Hex(intAdr - Val("&H01C8"))
            strWord = String(4 - Len(strWord), "0") & strWord
            arrData(Val("&H019C")) = Val("&H" & Right(strWord, 2)) '��λ�ֽ�
            arrData(Val("&H019C") + 1) = Val("&H" & Left(strWord, 2)) '��λ�ֽ�
            
            If strPDFFile = "" Then
                arrData(intAdr) = 0
                arrData(intAdr + 1) = 0
                intAdr = intAdr + 2
            Else
                For i = 1 To Len(strPDFFile)
                    strWord = Hex(AscW(Mid(strPDFFile, i, 1)))
                    If Len(strWord) = 2 Then
                        strWord = "00" & strWord
                    End If
                    
                    arrData(intAdr + i * 2 - 2) = Val("&H" & Right(strWord, 2)) '��λUnicode
                    arrData(intAdr + i * 2 - 1) = Val("&H" & Left(strWord, 2)) '��λUnicode
                Next
                intAdr = intAdr + Len(strPDFFile) * 2
                
                arrData(intAdr) = 0
                arrData(intAdr + 1) = 0
                intAdr = intAdr + 2
            End If
            intSect = intSect + 1
        ElseIf intSect = 8 Then '�м�����
            strWord = Hex(intAdr - Val("&H01C8"))
            strWord = String(4 - Len(strWord), "0") & strWord
            arrData(Val("&H01A4")) = Val("&H" & Right(strWord, 2)) '��λ�ֽ�
            arrData(Val("&H01A4") + 1) = Val("&H" & Left(strWord, 2)) '��λ�ֽ�
            
            For i = 1 To 16
                arrData(intAdr + i - 1) = 0
            Next
            intAdr = intAdr + 16
            intSect = intSect + 1
        ElseIf intSect = 9 Then '�����ļ�
            'Ŀǰ�������ü��ظ����ᵼ�����ɵ�PDF�򿪳���
            If strAttachs = "" Then
                arrData(intAdr) = 0
                arrData(intAdr + 1) = 0
                intAdr = intAdr + 2
            Else
                For i = 0 To UBound(Split(strAttachs, "|"))
                    strFile = Split(strAttachs, "|")(i)
                    For j = 1 To Len(strFile)
                        strWord = Hex(AscW(Mid(strFile, j, 1)))
                        If Len(strWord) = 2 Then
                            strWord = "00" & strWord
                        End If
                        
                        arrData(intAdr + j * 2 - 2) = Val("&H" & Right(strWord, 2)) '��λUnicode
                        arrData(intAdr + j * 2 - 1) = Val("&H" & Left(strWord, 2)) '��λUnicode
                    Next
                    intAdr = intAdr + Len(strFile) * 2
                    
                    arrData(intAdr) = 0
                    arrData(intAdr + 1) = 0
                    intAdr = intAdr + 2
                Next
            End If
            '�����˳�
            Exit Do
        End If
    Loop
    
    For i = Val("&H01A8") To Val("&H01C4") Step 4
        strWord = Hex(arrData(Val("&H01A4")) + arrData(Val("&H01A4") + 1) * 256 + (i - Val("&H01A8")) / 2 + 2)
        strWord = String(4 - Len(strWord), "0") & strWord
        
        arrData(i) = Val("&H" & Right(strWord, 2)) '��λ�ֽ�
        arrData(i + 1) = Val("&H" & Left(strWord, 2)) '��λ�ֽ�
        arrData(i + 2) = 0
        arrData(i + 3) = 0
    Next
    
    '��������
    SetRegValueBinary HKEY_CURRENT_USER, "Printers\DevModePerUser", "TinyPDF", arrData
    SetRegValueBinary HKEY_CURRENT_USER, "Printers\DevModes2", "TinyPDF", arrData
    
    ModifyRegist = True
    
    Exit Function
errHand:
    mstrError = err.Description
End Function

Private Function OutputDemo() As Boolean
    '******************************************************************************************************************
    '���ܣ�
    '������
    '���أ�
    '˵����
    '******************************************************************************************************************
    On Error GoTo errHand
    
    Call OutPut(Printer)
        
    OutputDemo = True
    Exit Function
errHand:
    mstrError = err.Description
    Printer.EndDoc
End Function

Private Sub OutPut(objOut As Object)
    '------
    objOut.Font.Name = "����"
    objOut.Font.Size = 18
    objOut.ForeColor = vbRed
    objOut.CurrentY = 300
    objOut.CurrentX = (objOut.ScaleWidth - objOut.TextWidth("PDF�ļ����ɲ���ʾ��")) / 2
    objOut.Print "PDF�ļ����ɲ���ʾ��"
    
    '------
    objOut.DrawWidth = 2 '�߿��ڴ�ӡ�����������Ǻ�����
    objOut.Line (100, 800)-(objOut.ScaleWidth - 100, 800), vbBlue
    
    '------
    objOut.Font.Name = "����"
    objOut.Font.Size = 12
    objOut.ForeColor = vbBlack
    objOut.CurrentX = 300
    objOut.CurrentY = 1000 + 100
    objOut.Print "��ϲ��"
    
    objOut.CurrentX = 300
    objOut.Print "��������Զ�ȡ�����Ϣ����˵���ڱ����Ͽ�������PDF�ļ���"
    objOut.EndDoc
    
End Sub

Private Sub ResetPDF()
    '******************************************************************************************************************
    '���ܣ�����TinyPDF��ӡ�������������
    '˵�����ú����ڴ�ӡ�����ɺ����
    '******************************************************************************************************************
    If mblnReset Then
        SetRegValueBinary HKEY_CURRENT_USER, "Printers\DevModePerUser", "TinyPDF", marrReset
        SetRegValueBinary HKEY_CURRENT_USER, "Printers\DevModes2", "TinyPDF", marrReset
        Erase marrReset
        mblnReset = False
    Else
        DeleteRegValue HKEY_CURRENT_USER, "Printers\DevModePerUser", "TinyPDF"
        DeleteRegValue HKEY_CURRENT_USER, "Printers\DevModes2", "TinyPDF"
    End If
End Sub

'######################################################################################################################
Private Function GetRegValueBinary(ByVal hKey As REGRoot, ByVal strSubKey As String, ByVal strValueName As String, arrData() As Byte) As Boolean
    '���ܣ���ȡע�����ָ��λ�õĶ�����ֵ
    Dim lngKey As Long, lngReturn As Long
    Dim lngLength As Long

    lngReturn = RegOpenKeyEx(hKey, strSubKey, 0, KEY_QUERY_VaLUE, lngKey)
    If lngReturn <> ERROR_SUCCESS Then
        Exit Function
    End If

    lngReturn = RegQueryValueEx_BINARY(lngKey, strValueName, 0, REG_BINARY, ByVal 0, lngLength)
    If lngReturn <> ERROR_SUCCESS Then
        RegCloseKey lngKey
        Exit Function
    End If

    ReDim arrData(lngLength - 1)
    lngReturn = RegQueryValueEx_BINARY(lngKey, strValueName, 0, REG_BINARY, arrData(0), lngLength)
    If lngReturn <> ERROR_SUCCESS Then
        RegCloseKey lngKey
        Exit Function
    End If

    RegCloseKey lngKey
    GetRegValueBinary = True
End Function

Private Function SetRegValueBinary(ByVal hKey As REGRoot, ByVal strSubKey As String, ByVal strValueName As String, arrData() As Byte) As Boolean
    '******************************************************************************************************************
    '���ܣ�����ע�����ָ��λ�õĶ�����ֵ
    '˵����
    '  1.��ע��������ʱ���Զ�����
    '  2.���ע��������������ͻ��Ϊ����������
    '******************************************************************************************************************
    Dim lngKey As Long, lngReturn As Long

    lngReturn = RegOpenKeyEx(hKey, strSubKey, 0, KEY_SET_VaLUE, lngKey)
    If lngReturn <> ERROR_SUCCESS Then
        Exit Function
    End If

    lngReturn = RegSetValueEx_BINARY(lngKey, strValueName, 0, REG_BINARY, arrData(0), UBound(arrData) + 1)
    If lngReturn <> ERROR_SUCCESS Then
        RegCloseKey lngKey
        Exit Function
    End If

    RegCloseKey lngKey
    SetRegValueBinary = True
End Function

Private Function DeleteRegValue(ByVal hKey As REGRoot, ByVal strSubKey As String, ByVal strValueName As String) As Boolean
    '���ܣ�ɾ��ע�����ָ��λ�õ���Ŀ
    Dim lngLength As Long, lngReturn As Long
    Dim lngKey As Long, lngType As Long


    lngReturn = RegOpenKeyEx(hKey, strSubKey, 0, KEY_SET_VaLUE, lngKey)
    If lngReturn <> ERROR_SUCCESS Then
        Exit Function
    End If

    lngReturn = RegDeleteValue(lngKey, strValueName)
    If lngReturn <> ERROR_SUCCESS Then
        RegCloseKey lngKey
        Exit Function
    End If

    RegCloseKey lngKey
    DeleteRegValue = True
End Function

