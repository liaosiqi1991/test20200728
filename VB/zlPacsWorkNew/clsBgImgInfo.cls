VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsBgImgInfo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'ͼ������
Public Enum TImageCommand
    icReadly = 0      '��ȡ��ʾ
    icDownload = 1    '��������
    icUpLoad = 2      '�ϴ�����
End Enum

'ͼ���ʽ
Public Enum TImageFmt
    ifDcm = 0
    ifBmp = 1
    ifJpg = 2
    ifAvi = 3
    ifWav = 4
End Enum

'״̬ͼ����
Public Enum TStateImageType
    sitNul = 0
    sitDown = 1
    sitAvi = 2
    sitWav = 3
    sitErr = 4
End Enum

'����״̬
Public Enum TLoadState
    lsNone = 0  'Ĭ�ϣ�û�н����κβ���
    lsMedia = 1     '�Ƕ�ý���ļ�
    lsLocal = 2     '�Ѵ��ڱ����ļ�
    lsSent = 3      '�ѷ��ʹ�������
    lsError = 4     '�����쳣
    lsRedo = 5      '����
End Enum
 
Public Key As String           '�ؼ��֣���ͼ��UID
Public PatientName  As String   '��������
Public AdviceId As Long         'ҽ��ID
Public StudyUID As String       '���UID
Public RecFmtDate As String     '�������� �Ѹ�ʽ��  YYYYMMDD
Public AdviceDes As String      'ҽ������

Public Filename As String      '�ļ�����
Public FilePath As String      '�ļ�·��

Public DeviceNo As Long         '�豸��
Public FtpIp As String             'IP
Public FtpPort As Long             '�˿�
Public FtpUser As String           'User
Public FtpPwd As String            '����
Public FtpVirtualPath As String    '����Ŀ¼
Public FtpShareDir As String
Public FtpShareUser As String
Public FtpSharePwd As String

Public BakDeviceNo As Long          '�����豸��
Public BakIp As String             '����FTPIP
Public BakPort As Long             '����FTP�˿�
Public BakUser As String           '����FTPUser
Public BakPwd As String            '����FTP����
Public BakVirtualPath As String    '��������Ŀ¼

Public FtpFile As String        'Ftp�ļ�

Public SeriesNoTag As String
Public ImageOrder As Long       '�������
Public DrawHint As String       '������ʾ�ı�
Public ImgTag As String
Public ImgCommand As TImageCommand 'ͼ������
Public IsBackGround As Boolean  '�Ƿ�ʹ�ú�̨���䷽ʽ

'Public EncoderName As String   '��������
'Public RecordTime As String    '¼��ʱ��
'Public RecordLen As Long       '¼�Ƴ���
Public Format As TImageFmt      '��ʽ
Public LoadState As TLoadState  'ͼ�����״̬
Public IsReset As Boolean       'Ϊtrue��ʾ��������

Public StartTime As Date        '��ʼ����ʱ��
Public EndTime As Date          '��������ʱ��

Public ErrorInfo As String      '������Ϣ
Public Redo As Long             '���Դ���
Public IsReDrawed As Boolean    '�Ƿ��Ѿ��ػ�

Public JpgConvert As Boolean    '�Ƿ����JPGת��
Public IsCompress As Boolean    '�Ƿ����ѹ������

Public IsCreateCmdFile As Boolean   '�Ƿ��Ѿ������������ļ�


Public Function CopyNew() As clsBgImgInfo
    Dim objCurBgImgInfo As New clsBgImgInfo
    
    With objCurBgImgInfo
        .Key = Key
        .PatientName = PatientName
        .AdviceId = AdviceId
        .AdviceDes = AdviceDes
        .StudyUID = StudyUID
    
        .Filename = Filename
        .FilePath = FilePath
    
        .FtpIp = FtpIp
        .FtpPort = FtpPort
        .FtpUser = FtpUser
        .FtpPwd = FtpPwd
        .FtpVirtualPath = FtpVirtualPath
        .FtpShareDir = FtpShareDir
        .FtpShareUser = FtpShareUser
        .FtpSharePwd = FtpSharePwd
        
        .BakIp = BakIp
        .BakPort = BakPort
        .BakUser = BakUser
        .BakPwd = BakPwd
        .BakVirtualPath = BakVirtualPath
    
        .FtpFile = FtpFile
    
        .SeriesNoTag = SeriesNoTag
        .ImageOrder = ImageOrder
        .DrawHint = DrawHint
        .ImgTag = ImgTag
        .ImgCommand = ImgCommand
        .IsBackGround = IsBackGround
     
        .Format = Format
        .LoadState = LoadState
        .IsReset = IsReset
    
        .StartTime = StartTime
        .EndTime = EndTime
    
        .ErrorInfo = ErrorInfo
        .Redo = Redo
        .IsReDrawed = IsReDrawed
        
        .JpgConvert = JpgConvert
        .IsCompress = IsCompress
    End With
    
    Set CopyNew = objCurBgImgInfo
End Function






