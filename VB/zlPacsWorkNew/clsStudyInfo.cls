VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsStudyInfo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public lngPatId As Long                 '1 ����ID
Public lngPageID As Long                  '2 ��ҳID
Public lngAdviceId As Long                '3 ҽ��ID
Public lngSendNo As Long                  '4 ���ͺ�
Public strPatientName As String           '5 ��������
Public strPatientSex As String
Public strPatientAge As String
Public strNO As String
Public lngRecordKind As Long
Public lngClinicId As Long   '������ĿID
Public blnIsPrinted As Boolean           '�Ѿ���ӡ��

Public lngPatDept As Long                 '6 ������������
Public strRegNo As String                 '7 �Һŵ�
'Public lngRegId As Long                   '8 �Һ�id
Public blnMoved As Boolean                 '9 �Ƿ�ת��
Public intState As Integer                '10 ���״̬
Public intStep As Integer                 '11 ������
Public lngUnit As Long                    '12 ����ID
Public strStudyUID As String              '13 ���UID
Public blnCanPrint As Boolean             '14 �Ƿ��ܹ���ӡ
Public blnIsInsidePatient As Boolean      '15 �Ƿ������סԺ����
Public lngExeDepartmentId As Long         '16 ִ�в���ID
Public strDoDoctor As String              '17 ��鼼ʦ
Public strExeRoom As String               '18 ִ�м�
Public lngPatientFrom As Long             '19 ������Դ
Public strStudyNum As String              '20 ����
'Public strBedNum As String                '21 ����
Public strMarkNum As String               '22 ��־��
Public lngBaby As Long                    '23 Ӥ��
Public blnInfancy As Boolean                     '��������С��һ��Ҳ��Ӥ��(pacsҵ��ר��)
Public strReportDoctor As String          '25 ������
Public strReportOperation As String       '26 �������
Public lngLinkId As Long                  '27 ����ID
Public strImgType As String               '28 Ӱ�����
Public intImageLocation As Integer        '29 PACSӰ�����ڵ�λ�ã�0������PACS��1������PACS
'Public strPatientType As String           '30 ��������
Public intFilmGiveOut As Integer          '��Ƭ����
Public intReportGiveOut As Integer        '���淢��
Public intDangerState As Integer          'Σ��״̬
Public intEmergentTag As Integer          '����״̬
Public intGreenChannel As Integer         '��ɫͨ��
Public strAdviceContext As String             'ҽ������
Public strAdviceDepartAndMethod As String     '��λ����
Public strStuStateDesc As String          '���״̬����
Public blnIsTechincalSure As Boolean      '�Ƿ�ʦȷ��
Public lngMoneyState As Long            '����״̬����
Public blnIsReported As Boolean           '�Ѿ��б���
Public blnIsInfectious As Boolean             '�Ƿ�Ⱦ��  LSQ������

Public strReportQuality As String   '��������
Public strImageQuality As String   'Ӱ������
Public strFollowUpDescribe As String '�������
Public intPathoType As Integer '����������
Public intPositive As Integer '�������
Public strAccord As String '�������
Public strIIDNumber As String '����֤��
Public strCollectionInfo As String '�ղ���Ϣ
Public lngReportType As Long    '����༭�����ͣ�����ʵ��ִ�п��ҽ��й�����1-pacs����༭����2-�����༭����3-���ܱ༭��
Public lngReportEditState As Long   '����ɱ༭״̬
Public dtFirstTime As Date          '�״�ʱ��

Public dtRefreshDate As Date '�ϴ�ˢ�¼����Ϣʱ��


Public Function IsEquals(objStudyInfo As clsStudyInfo) As Boolean
    IsEquals = False
    
    With objStudyInfo
        If .blnCanPrint <> blnCanPrint Then Exit Function
        If .blnInfancy <> blnInfancy Then Exit Function
        
        If .blnIsInfectious <> blnIsInfectious Then Exit Function
        If .blnIsInsidePatient <> blnIsInsidePatient Then Exit Function
'        If .blnIsReported <> blnIsReported Then Exit Function
        If .blnIsTechincalSure <> blnIsTechincalSure Then Exit Function
        If .blnMoved <> blnMoved Then Exit Function
'        If .dtRefreshDate <> dtRefreshDate Then Exit Function
        If .intDangerState <> intDangerState Then Exit Function
        If .intEmergentTag <> intEmergentTag Then Exit Function
'        If .intFilmGiveOut <> intFilmGiveOut Then Exit Function
        If .intGreenChannel <> intGreenChannel Then Exit Function
'        If .intImageLocation <> intImageLocation Then Exit Function
        If .intPathoType <> intPathoType Then Exit Function
        If .intPositive <> intPositive Then Exit Function
'        If .intReportGiveOut <> intReportGiveOut Then Exit Function
        If .intState <> intState Then Exit Function
        If .intStep <> intStep Then Exit Function
        If .lngAdviceId <> lngAdviceId Then Exit Function
        If .lngBaby <> lngBaby Then Exit Function
        If .lngExeDepartmentId <> lngExeDepartmentId Then Exit Function
        If .lngLinkId <> lngLinkId Then Exit Function
        If .lngMoneyState <> lngMoneyState Then Exit Function
        If .lngPageID <> lngPageID Then Exit Function
        If .lngPatDept <> lngPatDept Then Exit Function
        If .lngPatId <> lngPatId Then Exit Function
        If .lngPatientFrom <> lngPatientFrom Then Exit Function
'        If .lngRecordKind <> lngRecordKind Then Exit Function
'        If .lngReportType <> lngReportType Then Exit Function
        If .lngSendNo <> lngSendNo Then Exit Function
        If .lngUnit <> lngUnit Then Exit Function
'        If .strAccord <> strAccord Then Exit Function
        If .strAdviceContext <> strAdviceContext Then Exit Function
'        If .strAdviceDepartAndMethod <> strAdviceDepartAndMethod Then Exit Function
'        If .strCollectionInfo <> strCollectionInfo Then Exit Function
        If .strDoDoctor <> strDoDoctor Then Exit Function
        If .strExeRoom <> strExeRoom Then Exit Function
'        If .strFollowUpDescribe <> strFollowUpDescribe Then Exit Function
        If .strIIDNumber <> strIIDNumber Then Exit Function
'        If .strImageQuality <> strImageQuality Then Exit Function
        If .strImgType <> strImgType Then Exit Function
        If .strMarkNum <> strMarkNum Then Exit Function
        If .strNO <> strNO Then Exit Function
        If .strPatientAge <> strPatientAge Then Exit Function
        If .strPatientName <> strPatientName Then Exit Function
        If .strPatientSex <> strPatientSex Then Exit Function
        If .strRegNo <> strRegNo Then Exit Function
'        If .strReportDoctor <> strReportDoctor Then Exit Function
'        If .strReportOperation <> strReportOperation Then Exit Function
'        If .strReportQuality <> strReportQuality Then Exit Function
        If .strStudyNum <> strStudyNum Then Exit Function
        If .strStudyUID <> strStudyUID Then Exit Function
        If .dtFirstTime <> dtFirstTime Then Exit Function
'        If .strStuStateDesc <> strStuStateDesc Then Exit Function
    End With
    
    IsEquals = True
End Function