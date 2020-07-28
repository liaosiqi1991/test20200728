Attribute VB_Name = "mdlPACSWork"
Option Explicit

Private Declare Function GetSpecialFolderPath Lib "shell32.dll" Alias "SHGetSpecialFolderPathA" (ByVal hwnd As Long, ByVal pszPath As String, ByVal csidl As Long, ByVal fCreate As Long) As Long
Private Const CSIDL_APPDATA As Long = &H1A                          '（用户）\应用程序的数据

Public Const M_STR_TAG_SIGNWITHIMG As String = "[REPORT_IMG_FILE]"
Public Const M_STR_PDF_NOPRINTER As String = "<PDFERR>"

Public Const C_QUERY_刷新 = "刷新"
Public Const C_QUERY_查找 = "查找"
Public Const C_QUERY_数据检索 = "数据检索"
Public Const C_QUERY_更多过滤 = "更多过滤"
Public Const C_QUERY_首次刷新 = "首次刷新"


'模块标签名称常量
Public Const C_TAB_NAME_影像图像 As String = "影像图像"
Public Const C_TAB_NAME_影像采集 As String = "影像采集"
Public Const C_TAB_NAME_检查报告 As String = "检查报告"
Public Const C_TAB_NAME_医嘱记录 As String = "医嘱记录"
Public Const C_TAB_NAME_费用记录 As String = "费用记录"
Public Const C_TAB_NAME_病历记录 As String = "病历记录"
Public Const C_TAB_NAME_电子病历 As String = "电子病历"

Public Const C_TAB_NAME_标本核收 As String = "标本核收"
Public Const C_TAB_NAME_病理取材 As String = "病理取材"
Public Const C_TAB_NAME_病理制片 As String = "病理制片"
Public Const C_TAB_NAME_病理特检 As String = "病理特检"
Public Const C_TAB_NAME_过程报告 As String = "过程报告"

Public Const C_TAB_NAME_排队叫号 As String = "排队叫号"

Public Const C_WORKMODULE_NAME_影像图像 As String = "影像图像"
Public Const C_WORKMODULE_NAME_影像采集 As String = "影像采集"
Public Const C_WORKMODULE_NAME_门诊医嘱 As String = "门诊医嘱"
Public Const C_WORKMODULE_NAME_住院医嘱 As String = "住院医嘱"
Public Const C_WORKMODULE_NAME_门诊病历 As String = "门诊病历"
Public Const C_WORKMODULE_NAME_住院病历 As String = "住院病历"
Public Const C_WORKMODULE_NAME_电子病历 As String = "电子病历"
Public Const C_WORKMODULE_NAME_费用记录 As String = "费用记录"
Public Const C_WORKMODULE_NAME_老版报告 As String = "老版报告"
Public Const C_WORKMODULE_NAME_病历报告 As String = "病历报告"
Public Const C_WORKMODULE_NAME_智能报告 As String = "智能报告"
Public Const C_WORKMODULE_NAME_标本核收 As String = "标本核收"
Public Const C_WORKMODULE_NAME_病理取材 As String = "病理取材"
Public Const C_WORKMODULE_NAME_病理制片 As String = "病理制片"
Public Const C_WORKMODULE_NAME_病理特检 As String = "病理特检"
Public Const C_WORKMODULE_NAME_过程报告 As String = "过程报告"
Public Const C_WORKMODULE_NAME_排队叫号 As String = "排队叫号"

'工作站工具栏字体常量
Public gbytFontSize As Byte '工作站字体大小
Public Const C_INT_FONTSISE_SMALL = 9
Public Const C_INT_FONTSISE_MEDIUM = 12
Public Const C_INT_FONTSISE_BIG = 15

Public Const C_COLOR_LISTCOL0 As Long = -2147483633 ' 列表序号列颜色

'插件自动执行相关
Public Const C_STR_INTERFACE_0 = "不自动执行"
Public Const C_STR_INTERFACE_1 = "登记后"
Public Const C_STR_INTERFACE_2 = "报到后"
Public Const C_STR_INTERFACE_3 = "采图后"
Public Const C_STR_INTERFACE_4 = "报告保存后"
Public Const C_STR_INTERFACE_5 = "报告签名后"
Public Const C_STR_INTERFACE_6 = "报告审核后"
Public Const C_STR_INTERFACE_7 = "检查完成后"
Public Const C_STR_INTERFACE_11 = "取消登记时"
Public Const C_STR_INTERFACE_12 = "取消报到时"
Public Const C_STR_INTERFACE_13 = "删除图像时"
Public Const C_STR_INTERFACE_14 = "取消报告时"
Public Const C_STR_INTERFACE_15 = "取消签名时"
Public Const C_STR_INTERFACE_16 = "取消审核时"
Public Const C_STR_INTERFACE_17 = "取消完成时"
Public Const C_STR_INTERFACE_21 = "检查切换后"
Public Const C_STR_INTERFACE_22 = "报告驳回后"

Public Enum emPDFConvert
    不转换 = 0
    要转换 = 1
    只转换 = 2
End Enum

Public Enum emPDFState
'Null-未处理，1-成功，-1：输出失败，-2：上传失败
    未处理 = 0
    成功 = 1
    输出失败 = -1
    上传失败 = -2
End Enum

Public Enum EPlugInState
    未测试 = 0
    通过 = 1
    未通过 = 2
End Enum


Public Enum EInterfaceExeTime
    不自动执行 = 0
    登记后 = 1
    报到后 = 2
    采图后 = 3
    报告保存后 = 4
    报告签名后 = 5
    报告审核后 = 6
    检查完成后 = 7
    取消登记时 = 11
    取消报到时 = 12
    删除图像时 = 13
    取消报告时 = 14
    取消签名时 = 15
    取消审核时 = 16
    取消完成时 = 17
    检查切换后 = 21
    报告驳回后 = 22
End Enum

Public Enum EInterfaceExeTimeV2
    不自动执行 = 0
    检查登记 = 1
    检查报到 = 2
    图像采集 = 3
    报告保存 = 4
    报告签名 = 5
    报告审核 = 6
    检查完成 = 7
    取消登记 = 11
    取消报到 = 12
    删除图像 = 13
    删除报告 = 14
    报告回退 = 15
    取消完成 = 17
    报告驳回 = 22
    
    菜单执行 = 100
End Enum

'模块号常量定义
Public Const G_LNG_XWPACSVIEW_MODULE As Long = 1288     'XWPACS编号
Public Const G_LNG_PACSSTATION_MODULE As Long = 1290    '影像医技系统编号
Public Const G_LNG_VIDEOSTATION_MODULE As Long = 1291   '影像采集系统编号
Public Const G_LNG_PATHSTATION_MODULE As Long = 1294    '影像病理系统编号


Public Const G_STR_REG_PATH_PUBLIC As String = "公共模块\zl9PacsCapture"
Public Const G_STR_REG_PATH_PRIVATE As String = "私有模块\zl9PacsCapture\"

Public Const ImgTag = 0   '图像标记
Public Const MULFRAMETAG = 1 '多侦图
Public Const VIDEOTAG = 2 '视频标记
Public Const AUDIOTAG = 3 '音频标记
Public Const JPGTAG = 4
Public Const BMPTAG = 5


Public Enum SyncDataType
    rsDataAndrsShow = 0  '同步mrsdata和mrsdatashow
    rsShow = 1 '同步rsdataShow
    NoSync = 2 '都不同步
End Enum

Public Type TInterface
    intID As Integer
    strVBS As String
    intType As Integer '类型 预留
    intExeTime As Integer '执行时机
    strName As String '插件信息： [程序名:功能名]
End Type

Public Type TFtpDeviceInf
    strIID  As String
    strDeviceId As String
    strFtpIp As String
    strFTPUser As String
    strFTPPwd As String
    strFtpDir As String
    strFtpVirtualURL As String
End Type

'采集模块触发的事件类型
Public Enum TVideoEventType
    vetDelAllImg = 0        '删除所有图像
    vetGetImg = 1           '获取图像

    vetLockStudy = 2        '锁定检查
    vetUnLockStudy = 3      '解锁检查

    vetCaptureFirstImg = 4  '采集第一幅图像
    vetUpdateImg = 5        '更新图像
    
    vetAfterUpdateImg = 6   '更新后台图像
    
    vetImportImage = 7      '导入图像
    vetExportImage = 8      '导出图像
        
    vetUseAfterImage = 9
    vetNotUseAfterImage = 10
        
    vetImgCaped = 11
    vetImgDeled = 12
    
    vetAddReportImg = 13    '加入报告图
End Enum

Public Enum ChargeState
    未收费
    已收费
    无费用
    已记账
    已补缴
    已退费
    已销账
    已调整
End Enum

'编辑器类型
Public Enum ReportType
    电子病历编辑器 = 0
    PACS报告编辑器
    报告文档编辑器
End Enum


'ZLHIS_CIS_017(患者检查申请)
Public Const G_STR_MSG_ZLHIS_CIS_017 As String = "ZLHIS_CIS_017"

'ZLHIS_PACS_024(患者医嘱撤销)
Public Const G_STR_MSG_ZLHIS_CIS_024 As String = "ZLHIS_CIS_024"

'ZLHIS_CIS_005(医技安排执行完成)
Public Const G_STR_MSG_ZLHIS_CIS_005 As String = "ZLHIS_CIS_005"

'ZLHIS_PACS_001(检查报告完成)
Public Const G_STR_MSG_ZLHIS_PACS_001 As String = "ZLHIS_PACS_001"
      
'ZLHIS_PACS_002(检查状态同步)
Public Const G_STR_MSG_ZLHIS_PACS_002 As String = "ZLHIS_PACS_002"

'ZLHIS_PACS_003(检查状态回退)
Public Const G_STR_MSG_ZLHIS_PACS_003 As String = "ZLHIS_PACS_003"

'ZLHIS_PACS_004(检查报告撤销)
Public Const G_STR_MSG_ZLHIS_PACS_004 As String = "ZLHIS_PACS_004"

'ZLHIS_PACS_005(检查危急值通知)
Public Const G_STR_MSG_ZLHIS_PACS_005 As String = "ZLHIS_PACS_005"

'门诊患者划价单据
Public Const G_STR_MSG_ZLHIS_CHARGE_003 As String = "ZLHIS_CHARGE_003"

'危急值阅读通知
Public Const G_STR_MSG_ZLHIS_CIS_025 As String = "ZLHIS_CIS_025"
        
Public gobjMsgCenter As clsPacsMsgProcess
Public gobjRegister As Object
Public gstrUserPswd As String
Public gstrUserName As String
Public gstrServerName As String
Public gcnOracle As ADODB.Connection        '公共数据库连接，特别注意：不能设置为新的实例
Public gstrPrivs As String                   '当前用户具有的当前模块的功能
Public gstrSysName As String                '系统名称
Public glngModul As Long
Public glngSys As Long
Public gstrIme As String                    '是否自动开启输入法
Public gstrDBUser As String                 '当前数据库用户
Public gstrInputPwd As String
Public gobjEvent As Object

Public gstrUnitName As String '用户单位名称
Public gfrmMain As Object
Public glngMainHwnd As Long
Public gstrSQL As String
Public glngTXTProc As Long
Public gbln加班加价 As Boolean
Public grsDuty As ADODB.Recordset '存放医生职务
Public grsSysPars As ADODB.Recordset

'系统参数
Public gbytDec As Byte '费用金额的小数点位数
Public gstrDec As String '按小数位数计算的格式化串,如"0.0000"

Public gobjKernel As New zlCISKernel.clsCISKernel '医嘱对像

Public gbytCardLen As Byte '就诊卡号长度
Public gblnCardHide As Boolean '就诊卡号密文显示
Public gstrCardMask As String  '就诊卡允许的字母前缀:AA|BB|CC...
Public gint挂号天数 As Integer '挂号单有效天数

'Public glng消费验证 As Long '门诊一卡通消费减少剩余款额时是否需要验证
Public gbln执行前先结算 As Boolean '门诊一卡通,项目执行前必须先收费或先记帐审核
Public gbln执行后审核 As Boolean    '执行后自动审核划价单
Public gobjESign As Object                  '电子签名接口部件

'检查预约
Public gblnIsSchedule As Boolean                '全院启用预约 参数
Public gblnIsScheduleByDept As Boolean          '按科室启用预约 参数
Public grsScheduleEnables As ADODB.Recordset    '按科室启用预约的具体配置
    
'列表颜色配置
Public gdblColor已登记 As Double
Public gdblColor已报到 As Double
Public gdblColor已检查 As Double
Public gdblColor已报告 As Double
Public gdblColor已完成 As Double
Public gdblColor已审核 As Double
Public gdblColor处理中 As Double
Public gdblColor报告中 As Double
Public gdblColor审核中 As Double
Public gdblColor已拒绝 As Double
Public gdblColor已驳回 As Double


Public gConnectedShardDir() As String   '已经连接过的共享目录的设备号数组

'---------------------------设备数量控制，注册-------------------------------
Public Const LOGIN_TYPE_视频设备 As String = "影像视频设备数量"
Public Const LOGIN_TYPE_胶片打印机 As String = "影像胶片打印机数量"
Public Const LOGIN_TYPE_DICOM设备 As String = "影像DICOM设备数量"
Public gint视频设备数量 As Integer
Public gint胶片打印机数量 As Integer
Public gintDICOM设备数量 As Integer


Public mrsDeptParas As ADODB.Recordset '本科参数表缓存
'-----------------------------------------------------------
Public Type TYPE_USER_INFO
    ID As Long
    部门ID As Long
    编号 As String
    姓名 As String
    简码 As String
    用户名 As String
End Type
Public UserInfo As TYPE_USER_INFO


''''''''''''''''''''''''''''''''''''''图像预下载'''''''''''''''''''''''''''''''''''''
'保存消息内容的结构
Public Type TGetImgMsg
    strSubDir As String          '图像所在的子目录
    strDestMainDir As String            '复制图像的目的目录，本机目录
    strIP As String                 '图像服务器的IP地址
    strFtpDir As String             'FTP目录
    strFTPUser As String            'FTP用户名
    strFTPPswd As String            'FTP密码
    strSDDir As String              '共享目录名称
    strSDUser As String             '共享目录用户名
    strSDPswd As String             '共享目录密码
    blnEnable As Boolean            '本消息可用
End Type

'-------------------------一卡通的相关内容--------------------------------------
Public Const IDKind_姓名 = "姓名"
Public Const IDKind_医保号 = "医保号"
Public Const IDKind_身份证号 = "身份证号"
Public Const IDKind_IC卡号 = "IC卡号"
Public Const IDKind_门诊号 = "门诊号"
Public Const IDKind_住院号 = "住院号"
Public Const IDKind_挂号单 = "挂号单号"
Public Const IDKind_收费单据号 = "收费单据号"
Public Const IDKindItem_卡类别ID = "卡类别ID"
Public Const IDKindItem_卡号长度 = "卡号长度"

'定义一个卡结算部件的类，保存其中相关的内容
Public Type TSquardCard
    int医疗卡长度 As Integer
    lng卡类别ID As Long
    lng缺省卡类别ID As Long
    bln缺省卡号密文 As Boolean
    int缺省卡号长度  As Integer
    bln卡号密文 As Boolean
End Type

'图像标注
Public Const m_LabelTag_Circle = "NumberCircle"
Public Const m_LabelTag_Back = "NumberBak"
Public Const m_LabelTag_Number = "Number"
Public glngColor(10) As Long             '标记图中圆形编号使用的9个颜色

Public Function IsUseClearType() As Boolean
    Dim lngCurType As Long

    Call SystemParametersInfo(SPI_GETFONTSMOOTHINGTYPE, 0, lngCurType, 0)
    IsUseClearType = IIf(lngCurType = FE_FONTSMOOTHINGCLEARTYPE, True, False)
   
End Function


Public Function IsContainDept(ByVal lngUserId As Long, ByVal lngDeptId As Long) As Boolean
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    
    strSQL = "Select 1 from 部门人员 where 部门ID=[1] and 人员ID=[2]"
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "查询部门人员", lngDeptId, lngUserId)

    IsContainDept = IIf(rsData.RecordCount > 0, True, False)
End Function

'*********************************************************************************************************************
'
'菜单相关处理过程
'
'*********************************************************************************************************************


'查询快捷键配置
Public Sub BindMenuShortcut(ByVal strProjectName As String, ByVal lngModule As Long, objMenu As Object)
On Error GoTo errH
    Dim strSQL As String
    Dim rsShoftcutCfg As ADODB.Recordset
    Dim objMain As Object

    strSQL = "select a.id, nvl(b.控制键, a.控制键) as 控制键, nvl(b.字符键, a.字符键) as 字符键, " & _
             "decode(nvl(b.快捷功能ID,''),'',a.组合名,b.组合名) as 组合名, a.菜单ID " & _
             "from 快捷功能信息 a, (select 快捷功能ID, 控制键, 字符键, 组合名 from 快捷功能关联 where 用户id=[1] )b " & _
             "where a.id=b.快捷功能ID(+) and a.项目=[2] and a.模块号=[3]"

    Set rsShoftcutCfg = zlDatabase.OpenSQLRecord(strSQL, "绑定菜单快捷键", UserInfo.ID, UCase(strProjectName), lngModule)
    
    Set objMain = objMenu
    
    Call RecursionBindMenu(objMain, objMenu.ActiveMenuBar, rsShoftcutCfg)
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


'绑定菜单快捷方式(递归调用绑定快捷菜单)
Private Sub RecursionBindMenu(cbrMain As Object, objMenu As Object, rsShoftcutCfg As ADODB.Recordset)
    Dim i As Long
    
    If objMenu Is Nothing Then Exit Sub
    If objMenu.Controls.Count <= 0 Then Exit Sub
    
    For i = 1 To objMenu.Controls.Count
        Call BindMenuItemShortcut(cbrMain, objMenu.Controls.Item(i), rsShoftcutCfg)

        If objMenu.Controls.Item(i).type = xtpControlPopup Or objMenu.Controls.Item(i).type = xtpControlButtonPopup Then
            If objMenu.Controls.Item(i).CommandBar.Controls.Count > 0 Then
                Call RecursionBindMenu(cbrMain, objMenu.Controls.Item(i).CommandBar, rsShoftcutCfg)
            End If
        End If
    Next i
End Sub

'绑定单个菜单的快捷方式
Private Sub BindMenuItemShortcut(cbrMain As Object, cbrControl As Object, rsShoftcutCfg As ADODB.Recordset)
    If rsShoftcutCfg Is Nothing Then Exit Sub
    
    Dim lngFuncKey As Long
    Dim lngCharKey As Long
    Dim lngCommandKey As Long
    
    Dim strKeyAlias As String

    rsShoftcutCfg.Filter = "菜单ID=" & cbrControl.ID
    
    If rsShoftcutCfg.RecordCount > 0 Then
        lngFuncKey = Val(NVL(rsShoftcutCfg!控制键))
        lngCharKey = Val(NVL(rsShoftcutCfg!字符键))
        strKeyAlias = NVL(rsShoftcutCfg!组合名)

        'F8固定为快捷键采集使用
        If lngFuncKey = vbKeyF8 Or lngCharKey = vbKeyF8 Then Exit Sub
        
        If (lngFuncKey <> 0 Or lngCharKey <> 0) And InStr(strKeyAlias, "MENU") <= 0 Then
            lngCommandKey = 0
 
            If (lngFuncKey And vbCtrlMask) <> 0 Then
                lngCommandKey = lngCommandKey + FCONTROL
            End If
    
            If (lngFuncKey And vbShiftMask) <> 0 Then
                lngCommandKey = lngCommandKey + FSHIFT
            End If
    
            If (lngFuncKey And vbAltMask) <> 0 Then
                lngCommandKey = lngCommandKey + FALT
            End If
            
            '绑定菜单快捷键
            Call cbrMain.KeyBindings.Add(lngCommandKey, lngCharKey, cbrControl.ID)
            
        ElseIf InStr(strKeyAlias, "MENU") > 0 Then
            If InStr(cbrControl.Caption, "(&") <= 0 Then
                cbrControl.Caption = cbrControl.Caption & "(&" & Replace(strKeyAlias, "MENU+", "") & ")"
            End If
        End If
    End If
    
End Sub



Public Sub CreateViewAndHelpMenu(objViewMenu As Object, objHelpMenu As Object, _
    Optional ByVal strMenuTag As String = "")
    
    Dim cbrControl As CommandBarControl
    Dim cbrMenuBar As CommandBarPopup
    Dim cbrPopControl As CommandBarControl
    
    
    'Begin----------------------查看菜单--------------------------------------
    If Not (objViewMenu Is Nothing) Then
        Set cbrMenuBar = objViewMenu
        
        With cbrMenuBar.CommandBar
            Set cbrControl = .Controls.Add(xtpControlButtonPopup, conMenu_View_ToolBar, "工具栏(T)")
                cbrControl.Category = strMenuTag
                cbrControl.iconid = 1
            
                With cbrControl.CommandBar '二级菜单
                    Set cbrPopControl = .Controls.Add(xtpControlButton, conMenu_View_ToolBar_Button, "标准按钮(0)")
                        cbrPopControl.Checked = True
                        cbrPopControl.Category = strMenuTag
                        cbrPopControl.iconid = 1
                        
                    Set cbrPopControl = .Controls.Add(xtpControlButton, conMenu_View_ToolBar_Text, "文本标签(1)")
                        cbrPopControl.Checked = True
                        cbrPopControl.Category = strMenuTag
                        cbrPopControl.iconid = 1
                End With
            Set cbrControl = .Controls.Add(xtpControlButton, conMenu_View_StatusBar, "状态栏(S)")
                cbrControl.Checked = True
                        cbrPopControl.Category = strMenuTag
                        cbrPopControl.iconid = 1
        End With
    End If

    'Begin----------------------帮助菜单--------------------------------------默认可见
    If Not (objHelpMenu Is Nothing) Then
        Set cbrMenuBar = objHelpMenu
        
        With cbrMenuBar.CommandBar
            Set cbrControl = .Controls.Add(xtpControlButton, conMenu_Help_Help, "帮助主题(M)")
                cbrControl.Category = strMenuTag
                cbrControl.iconid = 901
                
            Set cbrControl = .Controls.Add(xtpControlButtonPopup, conMenu_Help_Web, "WEB上的中联(W)")
                cbrControl.Category = strMenuTag
                cbrControl.iconid = 1
                
                With cbrControl.CommandBar
                    Set cbrPopControl = .Controls.Add(xtpControlButton, conMenu_Help_Web_Forum, "中联论坛(0)")
                        cbrPopControl.Category = strMenuTag
                        cbrPopControl.iconid = 1
                        
                    Set cbrPopControl = .Controls.Add(xtpControlButton, conMenu_Help_Web_Home, "中联主页(1)")
                        cbrPopControl.Category = strMenuTag
                        cbrPopControl.iconid = 1
                        
                    Set cbrPopControl = .Controls.Add(xtpControlButton, conMenu_Help_Web_Mail, "发送反馈(2)")
                        cbrPopControl.Category = strMenuTag
                        cbrPopControl.iconid = 9022
                End With
                
            Set cbrControl = .Controls.Add(xtpControlButton, conMenu_Help_About, "关于…(A)")
                cbrControl.Category = strMenuTag
                cbrControl.iconid = 1
        End With
    End If
End Sub

'*********************************************************************************************************************


Public Sub SendMsgToMainWindow(objParameter As Object, _
    ByVal lngWorkType As TWorkEventType, ByVal lngAdviceId As Long, Optional other As Variant = "")
'发送消息到主窗口单元
    Dim objNotify As IEventNotify
    
    If gobjEvent Is Nothing Then Exit Sub
     
    If TypeOf gobjEvent Is IEventNotify Then
        Set objNotify = gobjEvent
        Call objNotify.Broadcast(BM_PATHOL_EVENT_BASE + lngWorkType, , lngAdviceId, other)
    Else
        Call gobjEvent.DoWork(objParameter, lngWorkType, lngAdviceId, other)
    End If
End Sub


Public Sub ReadStudyListColor(ByVal lngDeptId As Long)

    gdblColor报告中 = GetStudyListColor(lngDeptId, "报告中")
    If gdblColor报告中 < 0 Then
        gdblColor报告中 = ColorConstants.vbWhite
    End If
    gdblColor报告中 = GetColor(gdblColor报告中)
    
    gdblColor处理中 = GetStudyListColor(lngDeptId, "处理中")
    If gdblColor处理中 < 0 Then
        gdblColor处理中 = ColorConstants.vbWhite
    End If
    gdblColor处理中 = GetColor(gdblColor处理中)
    
    gdblColor审核中 = GetStudyListColor(lngDeptId, "审核中")
    If gdblColor审核中 < 0 Then
        gdblColor审核中 = ColorConstants.vbWhite
    End If
    gdblColor审核中 = GetColor(gdblColor审核中)
    
    gdblColor已报到 = GetStudyListColor(lngDeptId, "已报到")
    If gdblColor已报到 < 0 Then
        gdblColor已报到 = ColorConstants.vbWhite
    End If
    gdblColor已报到 = GetColor(gdblColor已报到)
    
    gdblColor已登记 = GetStudyListColor(lngDeptId, "已登记")
    If gdblColor已登记 < 0 Then
        gdblColor已登记 = ColorConstants.vbWhite
    End If
    gdblColor已登记 = GetColor(gdblColor已登记)
    
    gdblColor已检查 = GetStudyListColor(lngDeptId, "已检查")
    If gdblColor已检查 < 0 Then
        gdblColor已检查 = ColorConstants.vbWhite
    End If
    gdblColor已检查 = GetColor(gdblColor已检查)
    
    gdblColor已审核 = GetStudyListColor(lngDeptId, "已审核")
    If gdblColor已审核 < 0 Then
        gdblColor已审核 = ColorConstants.vbWhite
    End If
    gdblColor已审核 = GetColor(gdblColor已审核)
    
    gdblColor已完成 = GetStudyListColor(lngDeptId, "已完成")
    If gdblColor已完成 < 0 Then
        gdblColor已完成 = ColorConstants.vbGreen
    End If
    gdblColor已完成 = GetColor(gdblColor已完成)
    
    gdblColor已报告 = GetStudyListColor(lngDeptId, "已报告")
    If gdblColor已报告 < 0 Then
        gdblColor已报告 = ColorConstants.vbWhite
    End If
    gdblColor已报告 = GetColor(gdblColor已报告)
    
    gdblColor已拒绝 = GetStudyListColor(lngDeptId, "已拒绝")
    If gdblColor已拒绝 < 0 Then
        gdblColor已拒绝 = ColorConstants.vbRed
    End If
    gdblColor已拒绝 = GetColor(gdblColor已拒绝)
    
    gdblColor已驳回 = GetStudyListColor(lngDeptId, "已驳回")
    If gdblColor已驳回 < 0 Then
        gdblColor已驳回 = ColorConstants.vbYellow
    End If
    gdblColor已驳回 = GetColor(gdblColor已驳回)
End Sub

Private Function GetColor(ByVal lngColor As Long) As Long
    Dim lngR As Long, lngG As Long, lngB As Long
    Dim lngMaxVal As Long
    
    GetColor = 0
    lngMaxVal = 225
    
    lngR = lngColor Mod 256
    lngG = (Fix(lngColor \ 256)) Mod 256
    lngB = Fix(lngColor \ 256 \ 256)
    
    If lngR = 255 And lngG = 255 And lngB = 255 Then Exit Function
    
    If lngR > lngMaxVal Then lngR = lngMaxVal
    If lngG > lngMaxVal Then lngG = lngMaxVal
    If lngB > lngMaxVal Then lngB = lngMaxVal
    
    GetColor = RGB(lngR, lngG, lngB)
End Function

Public Function GetUserInfo() As Boolean
'功能：获取登陆用户信息
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String
    
    Set rsTmp = zlDatabase.GetUserInfo
    
    UserInfo.用户名 = gstrDBUser
    UserInfo.姓名 = gstrDBUser
    If Not rsTmp.EOF Then
        UserInfo.ID = rsTmp!ID
        UserInfo.编号 = rsTmp!编号
        UserInfo.部门ID = IIf(IsNull(rsTmp!部门ID), 0, rsTmp!部门ID)
        UserInfo.简码 = IIf(IsNull(rsTmp!简码), "", rsTmp!简码)
        UserInfo.姓名 = IIf(IsNull(rsTmp!姓名), "", rsTmp!姓名)
        UserInfo.用户名 = IIf(IsNull(rsTmp!用户名), "", rsTmp!用户名)
        GetUserInfo = True
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetUser科室IDs(Optional ByVal bln病区 As Boolean) As String
'功能：获取操作员所属的科室(本身所在科室+所属病区包含的科室),可能有多个
'参数：是否取所属病区下的科室
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String, i As Long
    
    strSQL = "Select 部门ID From 部门人员 Where 人员ID=[1]"
    If bln病区 Then
        strSQL = strSQL & " Union" & _
            " Select Distinct B.科室ID From 部门人员 A,床位状况记录 B" & _
            " Where A.部门ID=B.病区ID And A.人员ID=[1]"
    End If
    
    On Error GoTo errH
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "mdlCISWork", UserInfo.ID)
    For i = 1 To rsTmp.RecordCount
        GetUser科室IDs = GetUser科室IDs & "," & rsTmp!部门ID
        rsTmp.MoveNext
    Next
    GetUser科室IDs = Mid(GetUser科室IDs, 2)
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

'取得检查列表指定的配置颜色
Public Function GetStudyListColor(ByVal lngDeptId As Long, ByVal strParameterName As String) As Double
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim lngTemp As Long
             
    On Error GoTo err
        
    strSQL = "select ID ,科室ID,参数名,参数值 from 影像流程参数 where 科室ID = [1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "取得检查列表颜色", lngDeptId)
        
    GetStudyListColor = -1
    
    While Not rsTemp.EOF
        If rsTemp!参数名 = strParameterName Then
          GetStudyListColor = Val(rsTemp!参数值)
          Exit Function
        End If
        rsTemp.MoveNext
    Wend
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function getID_TO_名称(ByVal lngID As Long, ByVal strDict As String) As String
Dim rsTemp As ADODB.Recordset
    On Error GoTo errhandle
    gstrSQL = "select 名称 FROM " & strDict & " WHERE ID=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "通过编码提取ID", lngID)
    If Not rsTemp.EOF Then
        getID_TO_名称 = NVL(rsTemp!名称)
    End If
    Exit Function
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Function getID_TO_编码(ByVal lngID As Long, ByVal strDict As String) As String
Dim rsTemp As ADODB.Recordset
    On Error GoTo errhandle
    gstrSQL = "select 编码 FROM " & strDict & " WHERE ID=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "通过ID提取编码", lngID)
    If Not rsTemp.EOF Then
        getID_TO_编码 = NVL(rsTemp!编码)
    End If
    Exit Function
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Function getID_TO_简码(ByVal lngID As Long, ByVal strDict As String) As String
Dim rsTemp As ADODB.Recordset
    On Error GoTo errhandle
    gstrSQL = "select 简码 FROM " & strDict & " WHERE ID=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "通过ID提取编码", lngID)
    If Not rsTemp.EOF Then
        getID_TO_简码 = NVL(rsTemp!简码)
    End If
    Exit Function
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Sub RemoveCheckImages(ByVal lng医嘱ID As Long, ByVal lng发送号 As Long)
    '删除指定医嘱的检查影像
    Dim strSQL As String, rsTmp As New ADODB.Recordset
    
    Dim struFtpTag As TFtpConTag
    Dim strDeviceNo As String
    On Error GoTo ProcError
    '先删除图像
    strSQL = "select a.IP地址, a.FTP目录, a.FTP用户名, a.FTP密码, a.医嘱ID, a.发送号, a.检查UID, a.位置, a.接收日期 ,a.设备号 ,c.图像UID" & _
             " from (select IP地址, FTP目录, FTP用户名, FTP密码, 医嘱ID, 发送号, 检查UID, 位置一 as 位置, 接收日期, a.设备号 " & _
             "       from 影像设备目录 a, 影像检查记录 b " & _
             "       Where a.设备号 = B.位置一 " & _
             "       Union All " & _
             "       select IP地址, FTP目录, FTP用户名, FTP密码, 医嘱ID, 发送号, 检查UID, 位置二 as 位置, 接收日期, a.设备号" & _
             "       from 影像设备目录 a, 影像检查记录 b " & _
             "       Where a.设备号 = B.位置二 " & _
             "       Union All " & _
             "       select IP地址, FTP目录, FTP用户名, FTP密码, 医嘱ID, 发送号, 检查UID, 位置三 as 位置, 接收日期, a.设备号 " & _
             "       from 影像设备目录 a, 影像检查记录 b " & _
             "       Where a.设备号 = B.位置三 " & _
             "       ) a , 影像检查序列 b , 影像检查图象 c " & _
             " Where a.检查uid = B.检查uid " & _
             " and b.序列uid = c.序列uid " & _
             " and a.医嘱ID = [1] And 发送号 = [2] "
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "查图", lng医嘱ID, lng发送号)
    
    Do Until rsTmp.EOF
        If strDeviceNo <> NVL(rsTmp("设备号")) Then
            strDeviceNo = NVL(rsTmp("设备号"))
            struFtpTag = FtpTagInstance(NVL(rsTmp("IP地址")), _
                                        NVL(rsTmp("FTP用户名")), _
                                        NVL(rsTmp("FTP密码")), _
                                        IIf(IsNull(rsTmp("FTP目录")), "", rsTmp("FTP目录") & "/") & Format(rsTmp("接收日期"), "YYYYMMDD") & "/" & rsTmp("检查UID"))
        End If
        
        FtpDelete struFtpTag, rsTmp("图像UID"), False, False
        
        rsTmp.MoveNext
    Loop
    
    strDeviceNo = ""

    Exit Sub
ProcError:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Function MovedByDate(ByVal vDate As Date) As Boolean
'功能：判断指定日期之前的是否可能已经执行了数据转出,根据指定的日期、组号、系统判断指定日期的数据是否已转出到后备数据表中
'参数：vDate=时间点或时间段的开始时间

    MovedByDate = zlDatabase.DateMoved(CStr(vDate), 1, glngSys)
    
End Function

Public Function CheckOneDuty(ByVal str医嘱 As String, ByVal str职务 As String, ByVal str医生 As String, ByVal bln医保 As Boolean) As String
'功能：检查当前指定药品处方职务是否符合
'参数：str医嘱=药品医嘱提示内容
'      str职务=药品处方职务
'      str医生=开嘱医生
'      bln医保=是否公费或医保病人
'      grsDuty=记录医生职务缓存
'返回：职务不满足的提示信息，如果满足则返回空。
    Const STR_职务 = "正高,副高,中级,助理/师级,员/士,,,,待聘"
    Dim rsTmp As ADODB.Recordset
    Dim strSQL As String, strMsg As String
    Dim int职务A As Integer, int职务B As Integer
    
    If Len(str职务) <> 2 Or str医生 = "" Then Exit Function
    
    '取药品处方职务
    If bln医保 Then
        int职务B = Val(Right(str职务, 1))
    Else
        int职务B = Val(Left(str职务, 1))
    End If
    If int职务B = 0 Then Exit Function '不限制
    
    '取医生职务
    If grsDuty Is Nothing Then
        Set grsDuty = New ADODB.Recordset
        grsDuty.Fields.Append "医生", adVarChar, 50
        grsDuty.Fields.Append "职务", adInteger
        grsDuty.CursorLocation = adUseClient
        grsDuty.LockType = adLockOptimistic
        grsDuty.CursorType = adOpenStatic
        grsDuty.Open
        Set grsDuty.ActiveConnection = Nothing
    End If
    grsDuty.Filter = "医生='" & str医生 & "'"
    If grsDuty.EOF Then
        On Error GoTo errH
        strSQL = "Select 姓名,Nvl(聘任技术职务,0) as 职务 From 人员表 Where 姓名=[1]"
        'Set rsTmp = New ADODB.Recordset
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "mdlCISWork", str医生)
        On Error GoTo 0
        If Not rsTmp.EOF Then
            grsDuty.AddNew
            grsDuty!医生 = rsTmp!姓名
            grsDuty!职务 = rsTmp!职务
            grsDuty.Update
        End If
    End If
    If Not grsDuty.EOF Then
        int职务A = grsDuty!职务
    End If
        
    '检查职务要求
    If int职务A = 0 Then
        '医生未设置职务的情况
        strMsg = """" & str医嘱 & """要求的处方职务不满足：" & vbCrLf & vbCrLf & IIf(bln医保, "对医保或公费病人,", "") & _
            "该药品要求职务至少为""" & Split(STR_职务, ",")(int职务B - 1) & """才能下达,而医生""" & str医生 & """未设置职务。"
    ElseIf int职务B < int职务A Then
        '数值越小职务越高
        strMsg = """" & str医嘱 & """要求的处方职务不满足：" & vbCrLf & vbCrLf & IIf(bln医保, "对医保或公费病人,", "") & _
            "该药品要求职务至少为""" & Split(STR_职务, ",")(int职务B - 1) & """才能下达,而医生""" & str医生 & """的职务为""" & Split(STR_职务, ",")(int职务A - 1) & """。"
    End If
    CheckOneDuty = strMsg
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetFullNO(ByVal strNO As String, ByVal intNum As Integer) As String
'功能：由用户输入的部份单号，返回全部的单号。
'参数：intNum=项目序号,为0时固定按年产生
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String, intType As Integer
    Dim dtCurDate As Date
    Dim strMaxNo As String
    
    On Error GoTo errH
    
    If Len(strNO) >= 8 Then
        GetFullNO = Right(strNO, 8)
        Exit Function
    ElseIf Len(strNO) = 7 Then
        GetFullNO = PreFixNO & strNO
        Exit Function
    End If

    GetFullNO = strNO
    
    strSQL = "Select 编号规则,Sysdate as 日期,最大号码 From 号码控制表 Where 项目序号=[1]"
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, App.ProductName, intNum)
    dtCurDate = date
    If Not rsTmp.EOF Then
        intType = NVL(rsTmp!编号规则, 0)
        dtCurDate = rsTmp!日期
        strMaxNo = NVL(rsTmp!最大号码)
    End If

    If strMaxNo = "" Then
        strMaxNo = PreFixNO & "0000001"
    End If
    
    If intType = 1 Then
        '按日编号
        strSQL = Format(CDate("1992-" & Format(rsTmp!日期, "MM-dd")) - CDate("1992-01-01") + 1, "000")
        GetFullNO = PreFixNO & strSQL & Format(Right(strNO, 4), "0000")
    Else
        '按年编号,取最大号码的前两位
        GetFullNO = Left(strMaxNo, 2) & Format(Right(strNO, 6), "000000")
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function zlPatiIdentify(ByVal lngModuleNo As Long, ByVal objOwner As Object, _
    ByVal lngPatiendId As Long, ByVal curMoney As Currency) As Boolean
    Dim objDockExpense As Object
    
    zlPatiIdentify = False
    
    Set objDockExpense = DynamicCreate("zlPublicExpense.clsPublicExpense", "费用公共")
    If objDockExpense Is Nothing Then Exit Function
    
    Call objDockExpense.zlInitCommon(glngSys, gcnOracle, gstrDBUser)
    zlPatiIdentify = objDockExpense.zlPatiIdentify(lngModuleNo, objOwner, lngPatiendId, curMoney)
    
    Set objDockExpense = Nothing
End Function

Public Function InitSysPar() As Boolean
'初始化全局参数
    Dim strValue As String
    On Error Resume Next
    
    gstrSysName = GetSetting("ZLSOFT", "注册信息", "gstrSysName", "")
    strValue = zlDatabase.GetPara("输入法")
    gstrIme = IIf(strValue = "", "不自动开启", strValue)
    
        '费用金额小数点位数
    gbytDec = Val(zlDatabase.GetPara(9, glngSys, , 2))
    gstrDec = "0." & String(gbytDec, "0")
    
    '执行后自动审核
    '在35版本中已经删除了该参数，使用该参数的程序，按照参数值为1或true的方式进行处理
    gbln执行后审核 = True ' Val(zlDatabase.GetPara(81, glngSys)) <> 0
    
'    '一卡通消费验证
'    glng消费验证 = Val(Split(zlDatabase.GetPara(28, glngSys), "|")(0))
    
    '门诊一卡通,项目执行前必须先收费或先记帐审核
    gbln执行前先结算 = Val(zlDatabase.GetPara(163, glngSys)) <> 0
    
    If Not GetUserInfo Then
        MsgBox "当前用户未设置对应的人员信息,请与系统管理员联系,先到用户授权管理中设置！", vbInformation, gstrSysName
        Exit Function
    End If

    gstrUnitName = GetUnitName
    
    '设置默认颜色
    glngColor(1) = RGB(186, 186, 186)
    glngColor(2) = RGB(255, 215, 0)
    glngColor(3) = RGB(255, 0, 255)
    glngColor(4) = RGB(255, 0, 130)
    glngColor(5) = RGB(0, 255, 0)
    glngColor(6) = RGB(130, 255, 255)
    glngColor(7) = RGB(255, 255, 0)
    glngColor(8) = RGB(0, 0, 255)
    glngColor(9) = RGB(0, 160, 0)
    
    '检查预约
    gblnIsSchedule = Val(zlDatabase.GetPara("全院启用预约", glngSys, 1292, 0))
    gblnIsScheduleByDept = Val(zlDatabase.GetPara("分科室启用预约", glngSys, 1292, 0))
    
    InitSysPar = True
End Function

Public Sub MkLocalDir(ByVal strDir As String)
'------------------------------------------------
'功能：创建本地目录
'参数： strDir－－本地目录
'返回：无
'------------------------------------------------
    Dim objFile As New Scripting.FileSystemObject
    Dim aNestDirs() As String, i As Integer
    Dim strPath As String
    On Error Resume Next
    
    '读取全部需要创建的目录信息
    ReDim Preserve aNestDirs(0)
    aNestDirs(0) = strDir
    
    strPath = objFile.GetParentFolderName(strDir)
    Do While Len(strPath) > 0
        ReDim Preserve aNestDirs(UBound(aNestDirs) + 1)
        aNestDirs(UBound(aNestDirs)) = strPath
        strPath = objFile.GetParentFolderName(strPath)
    Loop
    '创建全部目录
    For i = UBound(aNestDirs) To 0 Step -1
        MkDir aNestDirs(i)
    Next
End Sub


Public Sub ClearCacheFolder(ByVal strCacheFolder As String)
'------------------------------------------------
'功能：当指定目录的大小达到一定百分比时，清空该目录
'参数： strCacheFolder--需要检查是否清空的目录
'返回：无
'------------------------------------------------
    Dim objFile As New Scripting.FileSystemObject
    Dim objCurFolder As Scripting.Folder, objCurFile As Scripting.File, objFiles As Scripting.Files
    Dim strDriver As String
    
    On Error Resume Next
    strDriver = objFile.GetDriveName(strCacheFolder)
    Set objCurFolder = objFile.GetFolder(strCacheFolder)
    If objCurFolder.Size / objFile.GetDrive(strDriver).FreeSpace > 0.2 Then
        zl9comlib.zlCommFun.ShowFlash "正清空图像缓冲目录，请等待！", gfrmMain
        objCurFolder.Delete True
        zl9comlib.zlCommFun.StopFlash
    End If
End Sub

Public Function GetTrayHeight() As Long
    '------------------------------------------------------------------------------------------------------------------
    '功能:获取任务栏的高度
    '------------------------------------------------------------------------------------------------------------------
    Dim lngHwd As Long
    Dim objRect As RECT
    
    On Error Resume Next
    
    lngHwd = FindWindow("shell_traywnd", "")
    objRect = zlControl.GetControlRect(lngHwd)

    GetTrayHeight = Screen.TwipsPerPixelX * (objRect.Bottom - objRect.Top)
    
    If GetTrayHeight < 0 Then GetTrayHeight = 0
    
End Function

Public Sub ResizeRegion(ByVal ImageCount As Integer, ByVal RegionWidth As Long, _
    ByVal RegionHeight As Long, Rows As Integer, Cols As Integer)
'-----------------------------------------------------------------------------
'功能：根据输入的图像数量，图像区域的宽度和高度，返回最佳的图像排列行数和列数
'参数： ImageCount－－图像数量
'       RegionWidth--图像显示区域的宽度
'       RegionHeight--图像显示区域的高度
'       Rows－－[返回]最佳行数
'       Cols－－[返回]最佳列数
'返回：返回最佳行数Rows，最佳列数Cols
'-----------------------------------------------------------------------------
    Dim iCols As Integer, iRows As Integer
    Dim iBase As Integer, blnDoLoop As Integer
    Dim lngFreeCount As Long
    
    If RegionHeight = 0 Then RegionHeight = 1
    If RegionWidth = 0 Then RegionWidth = 1
    
    On Error GoTo err
    iCols = CInt(Sqr(ImageCount * RegionWidth / RegionHeight))
    iRows = CInt(Sqr(ImageCount * RegionHeight / RegionWidth))

    If iRows < 1 Then iRows = 1
    If iCols < 1 Then iCols = 1
    
    '当图像格式为如下等形式时，需要对行列进行修正
    
    '格式1：
    '图1  图2  图3  图4
    '图5  图6  图7  图8
    '空1  空2  空3  空4
    
    '格式2：
    '图1  图2  图3  图4
    '图5  图6  图7  图8
    '图9  空1  空2  空3
    
    lngFreeCount = iRows * iCols - ImageCount
    Do While lngFreeCount >= iCols Or lngFreeCount >= iRows
        If lngFreeCount >= iCols Then
            iRows = iRows - 1
        Else
            iCols = iCols - 1
        End If
        
        lngFreeCount = iRows * iCols - ImageCount
    Loop
    
    If iRows < 1 Then iRows = 1
    If iCols < 1 Then iCols = 1
    
    Do While iRows * iCols < ImageCount
        If RegionWidth / iCols > RegionHeight > iRows Then
            iCols = iCols + 1
        Else
            iRows = iRows + 1
        End If
    Loop
    
    '再次修正行列数
    lngFreeCount = iRows * iCols - ImageCount
    Do While lngFreeCount >= iCols Or lngFreeCount >= iRows
        If lngFreeCount >= iCols Then
            iRows = iRows - 1
        Else
            iCols = iCols - 1
        End If
        
        lngFreeCount = iRows * iCols - ImageCount
    Loop
    
    Rows = iRows: Cols = iCols
    
err:
End Sub


Public Function funGetStudyUID(ByVal strOldStudyUID As String) As String
'-----------------------------------------------------------------------------
'功能:查询数据库，判断当前图像的检查UID是否已经存在于正常表和临时表中，
'     如果存在，则在检查UID后面增加后缀，不存在则直接返回输入的检查UID
'修改人:黄捷
'修改日期:2007-1-27
'-----------------------------------------------------------------------------
    '
On Error GoTo errH
    Dim rsMatch As New ADODB.Recordset
    
    funGetStudyUID = strOldStudyUID
    gstrSQL = "select 检查UID from 影像检查记录 where 检查UID = [1]" & _
              " Union All Select 检查UID from 影像临时记录 where 检查UID = [1]"
    Set rsMatch = zlDatabase.OpenSQLRecord(gstrSQL, "PACS图像保存", strOldStudyUID)
    If Not rsMatch.EOF Then
        '创建一个新的检查UID
        gstrSQL = "Select 影像检查UID序号_ID.Nextval From Dual"
        Set rsMatch = zlDatabase.OpenSQLRecord(gstrSQL, "PACS图像保存")
        If Len(strOldStudyUID) <= 55 Then
            funGetStudyUID = strOldStudyUID & ".A" & rsMatch(0)
        Else
            funGetStudyUID = Left(strOldStudyUID, 55) & ".A" & rsMatch(0)
        End If
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Function GetImageAttribute(objAttr As DicomAttributes, ByVal AttrName As String) As Variant
'-----------------------------------------------------------------------------
'功能:提取DICOM属性集中的指定属性值
'修改人:黄捷
'修改日期:2007-2-6
'-----------------------------------------------------------------------------
    Dim AttrTag() As String
    
    GetImageAttribute = ""
    AttrTag = Split(AttrName, ":")
    If objAttr("&h" & AttrTag(0), "&h" & AttrTag(1)).Exists Then
        GetImageAttribute = NVL(objAttr("&h" & AttrTag(0), "&h" & AttrTag(1)).value)
    End If
End Function

Public Function SetDeptPara(ByVal lngDeptId As Long, ByVal varPara As String, ByVal strValue As String) As Boolean
'功能：设置指定的参数值
'参数：lngDept=科室ID
'      varPara=参数名
'      strValue=参数名值
'返回：设置是否成功
    Dim strSQL As String
    
    On Error GoTo errH
        
    strSQL = "ZL_影像流程参数_UPDATE(" & lngDeptId & ",'" & varPara & "','" & strValue & "')"
    Call zlDatabase.ExecuteProcedure(strSQL, "SetPara")
    
    '设置成功后清除缓存
    Set mrsDeptParas = Nothing
    
    SetDeptPara = True
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetDeptPara(ByVal lngDeptId As Long, ByVal varPara As String, Optional ByVal strDefault As String, Optional ByVal blnNotCache As Boolean) As String
'功能：读取指定的参数值
'参数：lngDept=科室ID
'      varPara=参数名
'      strDefault=当数据库中没有该参数时使用的缺省值(注意不是为空时)
'      blnNotCache=是否不从缓存中读取
'返回：参数值，字符串形式
    Dim rsTmp As ADODB.Recordset
    Dim strSQL As String, blnNew As Boolean
    
    On Error GoTo errH
    
    If blnNotCache Then
        Set rsTmp = New ADODB.Recordset
        strSQL = "Select 参数值 from 影像流程参数 where 科室ID = [1] and 参数名=[2]"
        Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "读取参数", lngDeptId, varPara)
        
        If Not rsTmp.EOF Then
            GetDeptPara = NVL(rsTmp!参数值)
        Else
            GetDeptPara = strDefault
        End If
    Else
        '第一次加载参数缓存
        If mrsDeptParas Is Nothing Then
            blnNew = True
        ElseIf mrsDeptParas.State = 0 Then
            blnNew = True
        End If
        If blnNew Then
            strSQL = "Select 参数值,参数名,科室ID from 影像流程参数"
            Set mrsDeptParas = New ADODB.Recordset
            Set mrsDeptParas = zlDatabase.OpenSQLRecord(strSQL, "读取参数")
        End If
        
        '根据缓存读取参数值
        mrsDeptParas.Filter = "参数名='" & CStr(varPara) & "' AND 科室ID=" & lngDeptId
        If Not mrsDeptParas.EOF Then
            GetDeptPara = NVL(mrsDeptParas!参数值)
        Else
            GetDeptPara = strDefault
        End If
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetIsValidOfStorageDevice(ByVal lngDeptId As Long) As Boolean
'初始化科室级参数
    Dim rsTmp As New ADODB.Recordset
    Dim strSaveDeviceID As String
    
    On Error GoTo DBError
    
    '读取并检测存储设备号
    strSaveDeviceID = GetDeptPara(lngDeptId, "存储设备号")
    
    gstrSQL = "Select 设备号,设备名 From 影像设备目录 Where 类型=1 and 设备号=[1] and NVL(状态,0)=1"
    Set rsTmp = zlDatabase.OpenSQLRecord(gstrSQL, "获取存储设备信息", strSaveDeviceID)
    
    
    GetIsValidOfStorageDevice = Not rsTmp.EOF
    
    Exit Function
DBError:
    GetIsValidOfStorageDevice = False
    
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function


Public Sub GetAllImages(frmParent As Form, dcmViewer As DicomViewer, blnMoved As Boolean, intSearchType As Integer, _
    Optional lngAdviceId As Long, Optional strSeriesUID As String, Optional intGetImgNum As Integer = 0, _
    Optional intShowImgNum As Integer = 0, Optional blnTempDB As Boolean = False, _
    Optional strStudyUID As String = "", Optional strImageUID As String = "")
'------------------------------------------------
'功能：删除dcmViewer中的图像后，将读取的图像文件放入dcmViewer中
'参数： frmParent -- 父窗体
'       dcmViewer－－打开图像的DicomViewer
'       blnMoved －－ 是否被转储了
'       intSearchType －－检索类型,只对正式表查询有效  1－按照医嘱ID和发送号查，2－按照序列UID查，3 - 按照图像UID查
'       lngAdviceID －－ 医嘱ID
'       strSeriesUID －－ 序列UID
'       intGetImgNum －－本次读取的图像数量
'       intShowImgNum －－本次显示的图像数量
'       blnTempDB - - 是否从临时表中提取图像
'       strStudyUID - - 检查UID,只有从临时表查找的时候，才使用这个参数
'       strImageUID - - 图像UID，只有从正式表查找的时候，才使用这个参数
'返回：无，直接修改dcmViewer中显示的图像
'------------------------------------------------
    
    Dim strSQL As String
    Dim rsTmp As New ADODB.Recordset
    Dim curImage As DicomImage, i As Integer
    Dim iCols As Integer, iRows As Integer
    Dim objFile As New Scripting.FileSystemObject, strTmpFile As String
    
    Dim strucFtpTag As TFtpConTag
    Dim lngResult As Long
    
    Dim strCachePath As String
    Dim iCurrentIndex As Integer
    Dim dcmTag As clsImageTagInf
    
    
    On Error GoTo DBError
    If blnTempDB = False Then       '从正式图像库中查找图像
        strSQL = "Select A.图像号,D.FTP用户名 As User1,D.FTP密码 As Pwd1," & _
            "D.IP地址 As Host1,'/'||D.Ftp目录||'/' As Root1," & _
            "Decode(C.接收日期,Null,'',to_Char(C.接收日期,'YYYYMMDD')||'/')" & _
            "||C.检查UID||'/'||A.图像UID As URL,d.设备号 as 设备号1, " & _
            "E.FTP用户名 As User2,E.FTP密码 As Pwd2," & _
            "E.IP地址 As Host2,'/'||E.Ftp目录||'/' As Root2," & _
            "e.设备号 as 设备号2, A.图像UID,C.检查UID,B.序列UID,A.动态图,A.编码名称,A.采集时间, A.录制长度 " & _
            "From 影像检查图象 A,影像检查序列 B,影像检查记录 C,影像设备目录 D,影像设备目录 E " & _
            "Where A.序列UID=B.序列UID And B.检查UID=C.检查UID And C.位置一=D.设备号(+) And C.位置二=E.设备号(+) "
        If blnMoved Then
            strSQL = Replace(strSQL, "影像检查图象", "H影像检查图象")
            strSQL = Replace(strSQL, "影像检查序列", "H影像检查序列")
            strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
        End If
        If intShowImgNum <> 0 Then
            strSQL = strSQL & " And Rownum<=[2] "
        End If
        
        If intSearchType = 1 Then       '1－按照医嘱ID和发送号查
            strSQL = strSQL & "And C.医嘱ID=[1] Order By A.图像号"
            Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "读取图像", lngAdviceId, intGetImgNum)
        ElseIf intSearchType = 2 Then   '2－按照序列UID查
            strSQL = strSQL & "And A.序列UID= [1] Order By A.图像号"
            Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "读取图像", strSeriesUID, intGetImgNum)
        ElseIf intSearchType = 3 Then   '3 - 按照图像UID查
            strSQL = strSQL & "And A.图像UID = [1] "
            Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "读取图像", strImageUID, intGetImgNum)
        End If
        
    Else                '从临时表中查找图像
        
        strSQL = "Select c.图像号,d.FTP用户名 As User1, d.FTP密码 As Pwd1, d.Ip地址 As Host1," _
                & "'/' || d.Ftp目录 || '/' As Root1," _
                & " Decode(a.接收日期, Null, '', To_Char(a.接收日期, 'YYYYMMDD') || '/') || a.检查uid || '/' || c.图像uid As URL," _
                & " d.设备号 As 设备号1,C.图像UID,a.检查UID,b.序列UID,d.FTP用户名 As User2, d.FTP密码 As Pwd2, " _
                & " d.Ip地址 As Host2, '/' || d.Ftp目录 || '/' As Root2, " _
                & " d.设备号 As 设备号2,C.动态图,C.编码名称, C.采集时间, C.录制长度 " _
                & " From 影像临时记录 a,影像临时序列 b,影像临时图象 c ,影像设备目录 d " _
                & " Where a.检查UID=b.检查UID And b.序列UID = c.序列UID And a.位置一 = d.设备号 "
                
        If strStudyUID <> "" Then   '按照检查uid查找
            strSQL = strSQL & "And a.检查UID=[1] and Rownum<=[2] Order By c.图像号  "
            Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "读取图像", strStudyUID, CLng(6))
        Else        '按照序列UID查找
            strSQL = strSQL & "And b.序列UID=[1] and Rownum<=[2] Order By c.图像号  "
            Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "读取图像", strSeriesUID, CLng(6))
        End If
    End If
    
        dcmViewer.Images.Clear
        If rsTmp.RecordCount > 0 Then
            If intShowImgNum = 0 Or intShowImgNum >= rsTmp.RecordCount Then
                ResizeRegion rsTmp.RecordCount, dcmViewer.Width, dcmViewer.Height, iRows, iCols
            Else
                ResizeRegion intShowImgNum, dcmViewer.Width, dcmViewer.Height, iRows, iCols
            End If
            dcmViewer.MultiColumns = iCols
            dcmViewer.MultiRows = iRows
            
            '创建本地目录
            strCachePath = IIf(Len(App.Path) > 3, App.Path & "\TmpImage\", App.Path & "TmpImage\")
            MkLocalDir strCachePath & objFile.GetParentFolderName(NVL(rsTmp("URL")))
            
            Do While Not rsTmp.EOF
                
                strTmpFile = strCachePath & NVL(rsTmp("URL"))
                If NVL(rsTmp("动态图"), ImgTag) = VIDEOTAG Then
                    strTmpFile = IIf(Len(App.Path) > 3, App.Path & "\..\附加文件\Avi.bmp", App.Path & "..\附加文件\Avi.bmp")
                ElseIf NVL(rsTmp("动态图"), ImgTag) = AUDIOTAG Then
                    strTmpFile = IIf(Len(App.Path) > 3, App.Path & "\..\附加文件\wav.bmp", App.Path & "..\附加文件\wav.bmp")
                End If
                
                If Dir(strTmpFile) = vbNullString Then
                    '本地缓存图像不存在，则读取FTP图像
                    
                    strucFtpTag = FtpTagInstance(NVL(rsTmp("Host1")), _
                                                NVL(rsTmp("User1")), _
                                                NVL(rsTmp("Pwd1")), _
                                                objFile.GetParentFolderName(NVL(rsTmp("Root1")) & rsTmp("URL")))
                                                
                    If Trim(strucFtpTag.Ip) = "" Then
                        strucFtpTag = FtpTagInstance(NVL(rsTmp("Host2")), _
                                                    NVL(rsTmp("User2")), _
                                                    NVL(rsTmp("Pwd2")), _
                                                    objFile.GetParentFolderName(NVL(rsTmp("Root2")) & rsTmp("URL")))
                    End If
                    
                    lngResult = FtpDownload(strucFtpTag, objFile.GetFileName(rsTmp("URL")), strTmpFile, False)
                                                
                    If lngResult = frAbort Then Exit Sub
                                           
                End If
      
                If Dir(strTmpFile) <> vbNullString Then
                    
                
                    
                    If NVL(rsTmp("动态图"), ImgTag) <> VIDEOTAG And NVL(rsTmp("动态图"), ImgTag) <> AUDIOTAG Then
                        Set curImage = dcmViewer.Images.ReadFile(strTmpFile)
                        
    
                        Set dcmTag = New clsImageTagInf
                        dcmTag.tag = NVL(rsTmp("动态图"), ImgTag)
                        
                        
                        Set curImage.tag = dcmTag
                        
                        With curImage
                            .BorderStyle = 6
                            .BorderWidth = 1
                            .BorderColour = vbWhite
                        End With
                    Else
                        Set curImage = New DicomImage
                        
                        On Error GoTo continue
                            Call curImage.FileImport(strTmpFile, "DIB/BMP")
continue:
                        
                        Set dcmTag = New clsImageTagInf
                        dcmTag.tag = NVL(rsTmp("动态图"), VIDEOTAG)
                        dcmTag.EncoderName = NVL(rsTmp("编码名称"), "")
                        dcmTag.CaptureTime = NVL(rsTmp("采集时间"))
                        
                        If NVL(rsTmp("动态图"), VIDEOTAG) = VIDEOTAG Then
                            dcmTag.videoFile = strCachePath & NVL(rsTmp("URL")) & ".avi"
                        Else
                            dcmTag.videoFile = strCachePath & NVL(rsTmp("URL")) & ".wav"
                        End If
                        
                        dcmTag.RecordTimeLen = Val(NVL(rsTmp("录制长度"), "0"))
                        
'                        '如果是视频录像文件，则在播放时进行下载
'                        If Trim(dcmTag.VideoFile) <> "" And Dir(dcmTag.VideoFile) <> "" Then
'                            Name dcmTag.VideoFile As dcmTag.VideoFile & ".avi"
'                        End If
                        
                        Set curImage.tag = dcmTag
                        
                        curImage.InstanceUID = NVL(rsTmp("图像UID"))
                        curImage.SeriesUID = NVL(rsTmp("序列UID"))
                        curImage.StudyUID = NVL(rsTmp("检查UID"))
                        
                        
                        
                        Call AddVideoLabelToDicomImage(curImage, _
                            IIf(dcmTag.tag = VIDEOTAG, "录像时间：", "录音时间：") & NVL(rsTmp("采集时间")), _
                            IIf(dcmTag.tag = VIDEOTAG, "录像长度：", "录音长度：") & NVL(rsTmp("录制长度"), "0") & " 秒", _
                            "编码名称：" & NVL(rsTmp("编码名称")))
                        
                        With curImage
                            .BorderStyle = 6
                            .BorderWidth = 1
                            .BorderColour = vbWhite
                        End With
                        
                        Call dcmViewer.Images.Add(curImage)
                    End If
                    
                    
                    '取消自动剪影,因为DicomObjects控件本身对处理剪影有BUG，存在（0028，6100）时，会自动对图像进行剪影，
                    '导致晋煤的DSA图像不能正常显示
                    '虽然设置图像的mask=0 ,可以取消剪影，但是每次图像被添加到新的Dicomimages之后，自动又将mask设置成1了，
                    '这样在程序中无法很好的控制，因此直接去掉（0028，6100）这个属性。
                    If Not IsNull(curImage.Attributes(&H28, &H6100).value) Then
                        curImage.Attributes.Remove &H28, &H6100
                    End If
                End If
                
                rsTmp.MoveNext
            Loop
            If dcmViewer.Images.Count > 0 Then
                dcmViewer.CurrentIndex = 1
                dcmViewer.Images(1).BorderColour = vbRed
            End If
        Else
            dcmViewer.MultiColumns = 1
            dcmViewer.MultiRows = 1
        End If
'    Inet1.FuncFtpDisConnect
'    Inet2.FuncFtpDisConnect
    Exit Sub
DBError:
'    Inet1.FuncFtpDisConnect
'    Inet2.FuncFtpDisConnect
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Public Sub AddVideoLabelToDicomImage(dcmImage As DicomImage, ByVal strCaptureTimeText As String, _
    ByVal strTimeLenText As String, ByVal strEncoderName As String)
    '功能:添加label
    '参数:dcmImage：dicom图像
    '     strCaption： label文本
    Dim labCaption As New DicomLabel
    
    labCaption.LabelType = doLabelText
    '不显示编码器的名称
    labCaption.Text = strCaptureTimeText & vbCrLf & strTimeLenText '& vbCrLf & strEncoderName
    labCaption.Font.Bold = True
    labCaption.Font.Name = "宋体"
    labCaption.Font.Size = 10
    labCaption.ForeColour = vbYellow
    labCaption.AutoSize = False

    
    labCaption.Left = 0
    labCaption.Top = 0
    
    Call dcmImage.Labels.Add(labCaption)
End Sub

Public Function GetFtpDeviceWithDeviceNo(frmParent As Form, _
                                    strSaveDeviceID As String, _
                                    ByRef strDirURL As String, _
                                    ByRef strIP As String, _
                                    ByRef strUser As String, _
                                    ByRef strPwd As String) As Boolean
'------------------------------------------------
'功能：从数据库中读取制定存储设备ID的FTP访问参数
'参数： frmParent  -- 父窗体
'       strSaveDeviceID －－存储设备ID
'       strDirURL－－[OUT] FTP目录
'       strIp －－[OUT] IP地址
'       strUser －－ [OUT]用户名
'       strPwd －－[OUT]用户名
'返回：True－－获取成功，False－－获取失败
'-----------------------------------------------
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    GetFtpDeviceWithDeviceNo = False
    
    '检查存储设备是否存在
    strSQL = "Select '/'||Decode(Ftp目录,Null,'',Ftp目录||'/') As URL,FTP用户名,FTP密码,IP地址 " & _
        "From 影像设备目录 " & "Where 设备号=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, App.ProductName, strSaveDeviceID)
    
     '没有存储设备时退出
    If rsTemp.EOF = True Then
        MsgBoxD frmParent, "没有找到存储设备,请重新选择存储设备!", vbInformation, gstrSysName
        Exit Function
    End If
    
    strDirURL = NVL(rsTemp("URL"))
    strIP = NVL(rsTemp("IP地址"))
    strUser = NVL(rsTemp("FTP用户名"))
    strPwd = NVL(rsTemp("FTP密码"))
    
    GetFtpDeviceWithDeviceNo = True
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


'
Public Function GetFtpDeviceWithStudy(ByVal lngModuleNo As Long, _
    ByVal lngAdviceId As Long, ByVal strNewStudyUID As String, _
    ByRef ftpInfo As TFtpDeviceInf) As Boolean
'获取新的存储设备信息，如果设备存储信息部存在，则需要进行增加
'如果是取消关联，则使用strNewStudyUID将不能从数据库中查找到对应的数据
'strDeviceNum:设备号
'strFtpIp: ftp地址
'strFtpUrl: ftp目录
'strVirtualPath: ftp虚拟存储路径
'strFtpUser: ftp用户名
'strFtpPwd: ftp密码
On Error GoTo errH
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    Dim rsTemp As ADODB.Recordset
    Dim blnIsGetNewDevice As Boolean
    Dim lngDeptId As Long
    Dim curDate As Date

    ftpInfo.strDeviceId = ""
    ftpInfo.strFtpIp = ""
    ftpInfo.strFtpDir = ""
    ftpInfo.strFtpVirtualURL = ""
    ftpInfo.strFTPUser = ""
    ftpInfo.strFTPPwd = ""
    

    GetFtpDeviceWithStudy = False

    strSQL = "Select C.医嘱ID, C.检查UID, C.执行科室ID, C.位置一,C.位置二,C.位置三,C.接收日期," & _
        "D.IP地址 As Host,D.FTP用户名 As FtpUser,D.FTP密码 As FtpPwd," & _
        "'/' || D.Ftp目录 || '/' As Root," & _
        "Decode(C.接收日期,Null,'',to_Char(C.接收日期,'YYYYMMDD') || '/') || C.检查UID As URL " & _
        "From 影像检查记录 C,影像设备目录 D " & _
        "Where Decode(C.位置一,Null,C.位置二,C.位置一)=D.设备号(+)" & _
        "And C.医嘱ID= [1]"

    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "查询检查对应FTP信息", lngAdviceId)
    If rsData.RecordCount <= 0 Then
        '从历史库中查询数据
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "查询检查对应FTP信息", lngAdviceId)
    End If

    If rsData.RecordCount <= 0 Then
        MsgBox "存储设备获取失败，未能找到医嘱 [" & lngAdviceId & "] 对应的详细信息。", vbInformation, "提示"
        Exit Function
    End If

    blnIsGetNewDevice = False
    If UCase(NVL(rsData!检查UID)) <> UCase(strNewStudyUID) _
        Or NVL(rsData!Host) = "" _
        Or NVL(rsData!接收日期) = "" Then
        blnIsGetNewDevice = True
    End If

    If blnIsGetNewDevice = False Then
        '如果执行到这里，说明是执行图像关联,需要判断当前检查的存储设备是否有效，如果无效需生成新的存储设备
        ftpInfo.strDeviceId = NVL(rsData!位置一)
        ftpInfo.strFtpIp = NVL(rsData!Host)
        ftpInfo.strFtpDir = NVL(rsData!Root)
        ftpInfo.strFTPUser = NVL(rsData!FtpUser)
        ftpInfo.strFTPPwd = NVL(rsData!FtpPwd)
        ftpInfo.strFtpVirtualURL = ftpInfo.strFtpDir & NVL(rsData!Url)
    Else
        '生成新的检查UID和存储设备,如果执行到这里，说明是取消关联
        If lngModuleNo = 1290 Then
            '查询医技工作站中，检查所对应的存储设备
            strSQL = "select c.参数值 from 影像检查记录 a, 影像Dicom服务对 b, 影像DICOM服务参数 c" & _
                    " where a.检查设备=b.设备号 and b.服务ID=c.服务ID " & _
                    " and b.服务功能='图像接收' and c.参数名称='存储设备' and a.医嘱ID=[1]"

            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "查询检查对应存储设备", lngAdviceId)

            If rsTemp.RecordCount <= 0 Then
                MsgBox "未找到图像存储设备,请确认当前检查对应执行间设备是否有效。", vbInformation, "提示"
                Exit Function
            End If

            ftpInfo.strDeviceId = NVL(rsTemp!参数值)
        Else
            lngDeptId = Val(NVL(rsData!执行科室ID))

            '查询非医技工作站中的图像存储设备
            ftpInfo.strDeviceId = GetDeptPara(lngDeptId, "存储设备号")

            If Val(ftpInfo.strDeviceId) <= 0 Then
                MsgBox "未找到图像存储设备,请确认视频采集存储设备配置是否正确。", vbInformation, "提示"
                Exit Function
            End If
        End If

        strSQL = "Select 设备号,设备名,'/'||Decode(Ftp目录,Null,'',Ftp目录||'/') As Root,FTP用户名,FTP密码,IP地址 " & _
                    " From 影像设备目录 Where 设备号=[1] and 类型=1 and NVL(状态,0)=1"

        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "查询FTP设备信息", ftpInfo.strDeviceId)

        '如果存储设备停用，则直接退出
        If rsTemp.RecordCount <= 0 Then
            MsgBox "未找到存储设备,请确认设备号为 [" & ftpInfo.strDeviceId & "] 的设备是否启用。", vbInformation, "提示"
            Exit Function
        End If

        ftpInfo.strFtpIp = NVL(rsTemp("IP地址"))
        ftpInfo.strFtpDir = NVL(rsTemp("Root"))
        ftpInfo.strFTPUser = NVL(rsTemp("FTP用户名"))
        ftpInfo.strFTPPwd = NVL(rsTemp("FTP密码"))

        ftpInfo.strFtpDir = IIf(ftpInfo.strFtpDir = "/", "//", ftpInfo.strFtpDir)

        curDate = zlDatabase.Currentdate
        ftpInfo.strFtpVirtualURL = ftpInfo.strFtpDir & Format(curDate, "YYYYMMDD") & "/" & strNewStudyUID
    End If
    
    GetFtpDeviceWithStudy = True
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function Open3DViewer(lngAdviceId As Long, objParent As Object, Optional ByVal blnMoved As Boolean = False) As Long
'功能：3D观片
'参数：
'   lngAdviceId---医嘱ID
    
    On Error GoTo DBError
    
    If lngAdviceId > 0 Then
        Open3DViewer = XWShow3DImage(lngAdviceId, objParent)
    Else
        If gblnXWLog = True Then
            Call WriteCommLog("Open3DViewer", "调用XWShow3DImage接口", "医嘱ID为空")
        End If
    End If
    
    Exit Function
DBError:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Sub OpenLatestImage(Owner As Object, objPacsCore As Object, _
    ByVal objBaseInfo As clsStudyInfo, ByVal lngReleationDays As Long, _
    Optional ByVal blnLocalizerBackward As Boolean = False)
'打开满足条件的最近一次图像，如果没有满足条件的最近一次图像，显示检查列表给用户选择
On Error GoTo errH
    Dim strSQL As String
    Dim rsTemp As Recordset
    Dim dtStudy As Date
    Dim lngOrderID As Long
    Dim rsReturn As Records
    Dim blnCancel As Boolean
    
    lngOrderID = 0
     
    
    '打开相同科室下，最近影像类别相同的检查，主要针对同一患者不同医嘱相同类别的不同部位在同一设备上做检查的情况
    strSQL = "Select Distinct ID,检查号,姓名,性别,年龄,影像类别,医嘱内容,检查UID,位置一,位置二 from (" & vbCrLf & _
            " select b.医嘱ID as id, b.检查号,b.姓名,b.性别,b.年龄,b.影像类别, a.医嘱内容, b.检查uid,b.位置一,b.位置二 " & _
            " from 病人医嘱记录 a, 影像检查记录 b" & vbCrLf & _
            " Where a.ID = b.医嘱ID And a.病人ID = [1] And b.执行科室id = [3]" & vbCrLf & _
            "       and b.接收日期 between [4] and [5] " & vbCrLf & _
            "       and b.检查UID is not null and b.医嘱ID<>[6] and b.影像类别=[7] " & vbCrLf & _
            " Union All " & vbCrLf & _
            " select a.医嘱ID as id, a.检查号,a.姓名,a.性别,a.年龄,a.影像类别, b.医嘱内容,a.检查uid,a.位置一,a.位置二 " & _
            " from 影像检查记录 a , 病人医嘱记录 b " & vbCrLf & _
            " Where a.医嘱ID=b.Id and a.关联id = [2] And a.执行科室id = [3]" & vbCrLf & _
            "       and a.接收日期 between [4] and [5] " & vbCrLf & vbCrLf & _
            "       and a.检查UID is not null and a.医嘱ID<>[6] and a.影像类别=[7] " & vbCrLf & _
            " )"
             
    dtStudy = CDate(Format(NVL(objBaseInfo.dtFirstTime, 0), "yyyy-mm-dd 00:00"))
    
    
    Set rsTemp = zlDatabase.ShowSQLSelect(Owner, strSQL, 0, "关联影像检查", True, "ID", "请选择需要关联查看的图像...", False, False, False, _
                                    Screen.Width / 2 - 3000, Screen.Height / 2 - 2000, 2000, blnCancel, True, False, _
                                    objBaseInfo.lngPatId, objBaseInfo.lngLinkId, objBaseInfo.lngExeDepartmentId, _
                                    CDate(Format(dtStudy - lngReleationDays, "yyyy-mm-dd 00:00:00")), _
                                    CDate(Format(dtStudy + lngReleationDays, "yyyy-mm-dd 23:59:59")), _
                                    objBaseInfo.lngAdviceId, objBaseInfo.strImgType)
                                        
    If blnCancel Then Exit Sub
    If rsTemp Is Nothing Then
        MsgBoxD MainForm, "未找到可用于观片的图像信息。", vbOKOnly, "提示"
        Exit Sub
    Else
        If rsTemp.RecordCount <= 0 Then Exit Sub
    End If
    
    lngOrderID = NVL(rsTemp!ID)
    
'    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "查询关联检查数据", _
'                            objBaseInfo.lngPatId, objBaseInfo.lngLinkId, objBaseInfo.lngExeDepartmentId, _
'                            CDate(Format(dtStudy - lngReleationDays, "yyyy-mm-dd 00:00:00")), _
'                            CDate(Format(dtStudy + lngReleationDays, "yyyy-mm-dd 23:59:59")), _
'                            objBaseInfo.lngAdviceId, objBaseInfo.strImgType)
'
'
'
'    If rsTemp.RecordCount <= 0 Then
'        MsgBoxD MainForm, "未找到可用于观片的图像信息。", vbOKOnly, "提示"
'        Exit Sub
'    End If
    
'    If rsTemp.RecordCount = 1 Then
'        If MsgBoxD(MainForm, "当前检查中未发现相关图像，是否从如下的最近检查提取?" & vbCrLf & _
'                                "    检查号：" & nvl(rsTemp!检查号) & vbCrLf & _
'                                "    姓名：" & nvl(rsTemp!姓名) & vbCrLf & _
'                                "    性别：" & nvl(rsTemp!性别) & vbCrLf & _
'                                "    年龄：" & nvl(rsTemp!年龄) & vbCrLf & _
'                                "    " & nvl(rsTemp!医嘱内容), vbYesNo, "提示") = vbNo Then
'            Exit Sub
'        End If
'
'        lngOrderID = Val(nvl(rsTemp!医嘱ID))
'    Else
'        If MsgBoxD(MainForm, "当前检查中未发现相关图像，是否从最近的 [" & rsTemp.RecordCount & "] 条相关检查中提取图像？", vbYesNo, "提示") = vbNo Then
'            Exit Sub
'        End If
'
'
'        If FS.ShowRecSelect(Owner, Owner, rsTemp, rsReturn, True, "医嘱ID,位置一,位置二,检查UID") Then
'            lngOrderID = Val(nvl(rsReturn!医嘱ID))
'        End If
'    End If

    If lngOrderID <> 0 Then
        OpenViewer 1, objPacsCore, lngOrderID, False, Owner, "", objBaseInfo.blnMoved, blnLocalizerBackward
    End If
    
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Function OpenViewer(ByVal lngViewerType As Long, ByRef objPacsCore As Object, ByVal lngAdviceId As Long, _
        blnAddImage As Boolean, objParent As Object, Optional ByVal strSerials As String = "", _
        Optional ByVal blnMoved As Boolean = False, Optional ByVal blnLocalizerBackward As Boolean = False, _
        Optional ByVal intImageInterval As Integer = 0, Optional ByVal strImageString As String = "") As Boolean
'------------------------------------------------
'功能：根据传入的医嘱ID和发送号，打开objPacsCore指向的观片站
'参数：
'       lngViewerType -- 展现图像的Viewer类型；1-放射科专用Viewer；2-临床浏览用Viewer
'       objPacsCore －－观片站对象
'       lngAdviceID －－医嘱ID
'       blnAddImage--True 在原有图像基础上增加当前图像；False删除原有图像，打开当前图像
'       objParent -- 父窗体
'       strSerials－－可选，序列UID名称串，用逗号分隔，如果不输入，则选择全部序列
'       blnMoved－－可选，是否被转储
'       blnLocalizerBackward--可选，定位像后置,跟strImageString互斥
'       intImageInterval ---可选，打开图像的间隔，比如5，表示每5个图打开一个图,跟strImageString互斥
'       strImageString --- 可选，每个序列中需要打开的图象号组合，跟intImageInterval和blnLocalizerBackward互斥，
'                           以strImageString为主
'                           规则是“序列UID1|1-3;5-27;33-100+序列UID2|全部”,全部表示打开全部图象
'返回：图像文件名串数组
'------------------------------------------------
    Dim strSQL As String
    Dim rsTmp As New ADODB.Recordset
    Dim strFTPHost As String, strFtpPath As String, strFTPUser As String, strFTPPswd As String
    Dim strSDPath As String, strSDUser As String, strSDPwd As String
    Dim strDeviceNo As String
    Dim i As Integer
    Dim blnConnectDS As Boolean         '是否连接当前的共享目录
    Dim oneMessage As TGetImgMsg        '预取图像的消息结构
    Dim intImageLocation As Integer
    Dim strXWViewerFilter As String
    Dim strStudyUID As String
    
    On Error GoTo DBError
    
    '查询图像在新网PACS或者是中联PACS
    strSQL = "Select 检查UID,图像位置,影像类别 from 影像检查记录 where 医嘱ID =[1]"
    
    If blnMoved Then
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
    End If
    
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "查询图像所在的位置", lngAdviceId)
    
    If rsTmp.RecordCount <> 0 Then
        intImageLocation = NVL(rsTmp!图像位置, 0)
        strStudyUID = NVL(rsTmp!检查UID, "")
    Else
        intImageLocation = 1    '查不到数据，说明使用了新网的RIS
    End If
    
    '图像在新网数据库，调用新网DLL显示图像
    If intImageLocation = 1 Or intImageLocation = 2 Then
        strXWViewerFilter = lngAdviceId & IIf(strSerials <> "", "[;]" & strSerials, "")
        
        If gblnXWLog = True Then
            Call WriteCommLog("OpenViewer", "调用XWShowImage接口", "查询过滤参数为：" & strXWViewerFilter & "，图像位置为：" & intImageLocation)
        End If
        
        '打开新网的ADViewer或者WEB Viewer
        Call XWShowImage(lngViewerType, strXWViewerFilter, lngAdviceId, IIf(strSerials <> "", glngSeriesSchemeNo, glngStudySchemeNo))
        
        OpenViewer = True
        
        '如果图像保存在云平台，则提示用户需要等待，并且触发PACS图像下载
        If intImageLocation = 2 Then
            Call XWDownLoadImage(strStudyUID)
        End If
        
        Exit Function
    End If
    
    '判断是否启用了新版pacs观片，如果使用了新版观片，则用新版观片打开中联的图像
    If gblnUseXinWangView = True Then
        Call OpenViewerWithInXWPacs(lngAdviceId, NVL(rsTmp!影像类别), blnMoved)
        
        OpenViewer = True
        Exit Function
    End If
    
    
    '图像在中联数据库，调用中联zl9PacsCore显示图像
    strFTPHost = ""
           
    '查找需要打开的所有图象信息
    strSQL = "Select D.IP地址 As Host1,d.设备号 as 设备号1," & _
        "Decode(C.接收日期,Null,'',to_Char(C.接收日期,'YYYYMMDD')||'/')" & _
        "||C.检查UID||'/' As Path,E.IP地址 As Host2,e.设备号 as 设备号2, " & _
        "D.共享目录 AS 共享目录1, E.共享目录 AS 共享目录2,D.共享目录用户名 as 共享目录用户名1, " & _
        "E.共享目录用户名 AS 共享目录用户名2,D.共享目录密码 AS 共享目录密码1,E.共享目录密码 AS 共享目录密码2, " & _
        "D.FTP目录 as FTP目录1, E.FTP目录 as FTP目录2,D.FTP用户名 as FTP用户名1, E.FTP用户名 AS FTP用户名2,  " & _
        "D.FTP密码 as FTP密码1, E.FTP密码 AS FTP密码2 " & _
        "From 影像检查记录 C,影像设备目录 D,影像设备目录 E " & _
        "Where C.位置一=D.设备号(+) And C.位置二=E.设备号(+) And C.医嘱ID=[1] "
    
    '如果有转储标志，则读取转储的历史表
    If blnMoved Then
        strSQL = Replace(strSQL, "影像检查图象", "H影像检查图象")
        strSQL = Replace(strSQL, "影像检查序列", "H影像检查序列")
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
    End If
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "获取共享目录信息", lngAdviceId)
    
    If rsTmp.RecordCount > 0 Then
        '创建本地的缓存目录，需要在调用观片站之前先创建这个目录，观片站中只是下载，不创建本地缓存目录
        MkLocalDir App.Path & "\TmpImage\" & rsTmp("Path")
        
        '读取FTP参数，包括用户名，密码，IP地址等
        If rsTmp("设备号1") <> "" Then
            strDeviceNo = rsTmp("设备号1")
            strFTPHost = rsTmp("Host1")
            strFtpPath = NVL(rsTmp("FTP目录1"))
            strFTPUser = NVL(rsTmp("FTP用户名1"))
            strFTPPswd = NVL(rsTmp("FTP密码1"))
            strSDPath = NVL(rsTmp("共享目录1"))
            strSDUser = NVL(rsTmp("共享目录用户名1"))
            strSDPwd = NVL(rsTmp("共享目录密码1"))
        ElseIf NVL(rsTmp("设备号2")) <> "" Then
            strDeviceNo = rsTmp("设备号2")
            strFTPHost = rsTmp("Host2")
            strFtpPath = NVL(rsTmp("FTP目录2"))
            strFTPUser = NVL(rsTmp("FTP用户名2"))
            strFTPPswd = NVL(rsTmp("FTP密码2"))
            strSDPath = NVL(rsTmp("共享目录2"))
            strSDUser = NVL(rsTmp("共享目录用户名2"))
            strSDPwd = NVL(rsTmp("共享目录密码2"))
        End If
        
        '判断共享目录是否已经连接，如果没有连接，则进行连接
        blnConnectDS = True
        For i = 1 To UBound(gConnectedShardDir)
            If gConnectedShardDir(i) = strDeviceNo Then
                blnConnectDS = False
                Exit For
            End If
        Next i
        If blnConnectDS = True And strSDPath <> "" Then
            If funcConnectShardDir(objParent, "\\" & strFTPHost & "\" & strSDPath, strSDUser, strSDPwd) = 0 Then
                ReDim Preserve gConnectedShardDir(UBound(gConnectedShardDir) + 1) As String
                gConnectedShardDir(UBound(gConnectedShardDir)) = strDeviceNo
            End If
        End If
        
        '打开观片站
        If objPacsCore Is Nothing Then
            Exit Function
        Else
            objPacsCore.CallOpenViewer strImageString, lngAdviceId, objParent, gcnOracle, blnMoved, blnAddImage, intImageInterval, glngSys
        End If
        
        '先打开观片站，再预取
        oneMessage.strSubDir = rsTmp("Path")
        oneMessage.strDestMainDir = App.Path & "\TmpImage\"
        oneMessage.strIP = strFTPHost
        oneMessage.strFtpDir = strFtpPath
        oneMessage.strFTPUser = strFTPUser
        oneMessage.strFTPPswd = strFTPPswd
        oneMessage.strSDDir = strSDPath
        oneMessage.strSDUser = strSDUser
        oneMessage.strSDPswd = strSDPwd
        
        Call funPreDownLoadImages(oneMessage)
        
    Else    '没有查找到图象记录，则关闭原来已经打开的观片窗口
        If Not objPacsCore Is Nothing Then objPacsCore.Closefrom
    End If
    
    OpenViewer = True
    Exit Function
DBError:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Function GetStudyImageData(ByVal lngAdviceId As Long, ByVal blnMoved As Boolean) As ADODB.Recordset
'获取检查图像数据
On Error GoTo errH
    Dim strSQL As String
        
    strSQL = "Select rownum as 顺序号, A.图像号,D.FTP用户名 As User1,D.FTP密码 As Pwd1," & _
        "D.IP地址 As Host1,'/'||D.Ftp目录||'/' As Root1," & _
        "Decode(C.接收日期,Null,'',to_Char(C.接收日期,'YYYYMMDD')||'/')" & _
        "||C.检查UID||'/'||A.图像UID As URL,d.设备号 as 设备号1, " & _
        "E.FTP用户名 As User2,E.FTP密码 As Pwd2," & _
        "E.IP地址 As Host2,'/'||E.Ftp目录||'/' As Root2," & _
        "e.设备号 as 设备号2, A.图像UID,C.检查UID,B.序列UID,A.动态图,A.编码名称,A.采集时间, A.录制长度 " & _
        "From 影像检查图象 A,影像检查序列 B,影像检查记录 C,影像设备目录 D,影像设备目录 E " & _
        "Where A.序列UID=B.序列UID And B.检查UID=C.检查UID And C.位置一=D.设备号(+) And C.位置二=E.设备号(+) and c.医嘱ID=[1] "
        

    If blnMoved Then
        strSQL = Replace(strSQL, "影像检查图象", "H影像检查图象")
        strSQL = Replace(strSQL, "影像检查序列", "H影像检查序列")
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
    End If
    
    Set GetStudyImageData = zlDatabase.OpenSQLRecord(strSQL, "查询图像信息", lngAdviceId)
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Function OpenViewerWithInXWPacs(ByVal lngAdviceId As Long, ByVal strModalityType As String, ByVal blnMoved As Boolean)
'在新版pacs中打开中联PACS的图片观片，如果是老版本的数据，且使用了新网观片系统，则直接传递远程目录文件名
    Dim rsTemp As ADODB.Recordset

    Dim strFtpURL As String
    Dim strImages As String
    
    Set rsTemp = GetStudyImageData(lngAdviceId, blnMoved)
    
    strImages = ""

    While Not rsTemp.EOF
        If NVL(rsTemp!设备号1) <> "" Then
            strFtpURL = "\\" & NVL(rsTemp!Host1) & "\" & gstrImageShareDir & NVL(rsTemp!Root1) & NVL(rsTemp!Url)
        Else
            strFtpURL = "\\" & NVL(rsTemp!Host2) & "\" & gstrImageShareDir & NVL(rsTemp!Root2) & NVL(rsTemp!Url)
        End If
        
        If strImages <> "" Then strImages = strImages & "[;]"
        
        strFtpURL = Replace(strFtpURL, "//", "/")
        strImages = strImages & Replace(strFtpURL, "/", "\")
        
        rsTemp.MoveNext
    Wend

    
    '打开远程目录文件进行对比观片
    Call OEMViewOpen(0, strImages, 0, strModalityType)
End Function

Public Function CheckChargeState(ByVal lng医嘱ID As Long, ByVal lng来源 As Long) As ChargeState
'功能： 判断当前的医嘱是否收费
'参数： lng医嘱ID --医嘱ID
'       lng来源 -- 病人来源

'一条医嘱会有多部位的子医嘱
On Error GoTo errH
    Dim rsData As New ADODB.Recordset, rsTemp As ADODB.Recordset, rsClone As ADODB.Recordset
    Dim strTable As String
    Dim lngTempCharged As ChargeState
    
    lngTempCharged = ChargeState.无费用

    gstrSQL = "Select B.病人来源, A.NO,B.id as 医嘱ID,B.相关ID, A.计费状态, A.记录性质,D.结算模式" & vbNewLine & _
                "From 病人医嘱发送 A, 病人医嘱记录 B,  病人信息 D" & vbNewLine & _
                "Where A.医嘱Id=B.ID And B.病人ID=D.病人ID And (B.id = [1] or B.相关Id=[1]) "
                
    Set rsData = zlDatabase.OpenSQLRecord(gstrSQL, "是否收费", lng医嘱ID)
    
    rsData.Filter = "相关ID=NULL"
    
    If NVL(rsData!记录性质, 2) = 2 Then '记账
        If NVL(rsData!计费状态, -1) = -1 Or NVL(rsData!计费状态, -1) = 0 Then   '无
            lngTempCharged = ChargeState.无费用
        Else
            If NVL(rsData!计费状态, -1) = 1 Then                                '记
                lngTempCharged = ChargeState.已记账
            ElseIf NVL(rsData!计费状态, -1) = 2 Then                            '调
                lngTempCharged = ChargeState.已调整
            ElseIf NVL(rsData!计费状态, -1) = 4 Then                            '销
                lngTempCharged = ChargeState.已销账
            End If
        End If
    Else                                '收费
        If NVL(rsData!计费状态, -1) = -1 Or NVL(rsData!计费状态, -1) = 0 Then   '无
            lngTempCharged = ChargeState.无费用
        Else
            If NVL(rsData!计费状态, -1) = 1 Then                                '欠
                lngTempCharged = ChargeState.未收费
            ElseIf NVL(rsData!计费状态, -1) = 2 Then                            '调
                lngTempCharged = ChargeState.已调整
            ElseIf NVL(rsData!计费状态, -1) = 3 Then                            '收
                lngTempCharged = ChargeState.已收费
            ElseIf NVL(rsData!计费状态, -1) = 4 Then                            '退
                lngTempCharged = ChargeState.已退费
            End If
        End If
    End If
    
    CheckChargeState = lngTempCharged
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function CheckConcurrentReport(frmParent As Form, ByVal lngOrderID As Long, Optional blnSilence As Boolean = False) As Boolean
'------------------------------------------------
'功能：检查当前病人是否有医生正在操作报告
'参数： frmParent  -- 父窗体
'       lngOrderID －－医嘱ID
'       blnSilence--True 不出现并发提示；False 并发时弹出提示信息
'返回：True-无人操作此报告；False--有人正在操作此报告
'------------------------------------------------

Dim rsTemp As ADODB.Recordset
    
    On Error GoTo errhandle
    CheckConcurrentReport = True
    gstrSQL = "Select 报告操作 From 影像检查记录 Where 医嘱ID=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "读取记录", lngOrderID)
    
    If Not rsTemp Is Nothing Then
        If Not rsTemp.EOF Then
            If NVL(rsTemp!报告操作) <> "" And NVL(rsTemp!报告操作) <> UserInfo.姓名 Then
                If blnSilence = False Then
                    MsgBoxD frmParent, "当前病人的报告正在被 " & NVL(rsTemp!报告操作) & " 操作，请稍后再试。", vbInformation, "提示"
                End If
                CheckConcurrentReport = False
            End If
        End If
    End If
    Exit Function
    
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Sub UpdateReporter(ByVal lngOrderID As Long, ByVal Reporter As String)
    On Error GoTo errhandle
    
    gstrSQL = "ZL_影像报告操作_Update(" & lngOrderID & ",'" & Reporter & "')"
    zlDatabase.ExecuteProcedure gstrSQL, "更新操作者"
    Exit Sub
    
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Sub



Public Function LockReportEditor(ByVal lngAdviceId As Long, Optional ByRef strErrMsg As String) As Boolean
'锁定编辑人
    '使用全局临时表进行并发处理
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
On Error GoTo errhandle
    
    LockReportEditor = False
    
    strSQL = "select 报告操作 from 影像检查记录 where 医嘱ID=[1]"
    
    
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "查询报告操作人", lngAdviceId)
    If rsData.RecordCount > 0 Then
        '已被锁定，判断锁定人是否相同
        If NVL(rsData!报告操作) = UserInfo.姓名 Then
            LockReportEditor = True
        Else
            strErrMsg = "报告已被 [" & NVL(rsData!报告操作) & "] 编辑锁定."
        End If
        
        Exit Function
    End If
        
        
    '没有锁定，则进行锁定操作
    Call UpdateReporter(lngAdviceId, UserInfo.姓名)
     
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "查询报告操作人", lngAdviceId)
    If rsData.RecordCount <= 0 Then
        '锁定失败
        strErrMsg = "报告锁定失败."
        Exit Function
    End If
    
    If NVL(rsData!报告操作) = UserInfo.姓名 Then
        LockReportEditor = True
    Else
        strErrMsg = "报告锁定失败,已被 [" & NVL(rsData!报告操作) & "] 编辑锁定."
    End If
    
Exit Function
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Sub UnlockReportEditor(ByVal lngAdviceId As Long)
'解除编辑人
    Call UpdateReporter(lngAdviceId, "")
End Sub


Public Function bln存在未审划价单(ByVal lng医嘱ID As Long, ByVal lng来源 As Long) As Boolean
    Dim rsTemp As ADODB.Recordset
    Dim strFeeTable As String
    Dim strFilter As String
    
    '住院病人查住院费用记录，门诊、外诊等病人查门诊费用记录
    If lng来源 = 2 Then
        strFeeTable = "住院费用记录"
        strFilter = " A.记录性质"
    Else
        strFeeTable = "门诊费用记录"
        strFilter = " decode(A.记录性质,1,1,11,1,A.记录性质)"
    End If

    On Error GoTo errhandle
    gstrSQL = "Select /*+ RULE */ A.ID" & vbNewLine & _
            "From " & strFeeTable & " A" & vbNewLine & _
            "Where A.医嘱序号 + 0 In (Select ID From 病人医嘱记录 Where ID = [1] Or 相关id = [1]) And (" & strFilter & ", A.NO) In" & vbNewLine & _
            "      (Select 记录性质, NO" & vbNewLine & _
            "       From 病人医嘱附费" & vbNewLine & _
            "       Where 医嘱id In (Select ID From 病人医嘱记录 Where ID = [1] Or 相关id = [1])" & vbNewLine & _
            "       Union All" & vbNewLine & _
            "       Select 记录性质, NO" & vbNewLine & _
            "       From 病人医嘱发送" & vbNewLine & _
            "       Where 医嘱id In (Select ID From 病人医嘱记录 Where ID = [1] Or 相关id = [1])" & vbNewLine & _
            "       ) And A.记帐费用 = 1 And A.记录状态 = 0"

    Set rsTemp = zlDatabase.OpenSQLRecord(gstrSQL, "提取未审划价单", lng医嘱ID)
    If rsTemp.EOF Then
        Exit Function
    Else
        bln存在未审划价单 = True
    End If
    Exit Function
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Function bln病人在院(ByVal lng病人ID As Long, ByVal lng主页ID As Long) As Boolean
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    On Error GoTo errhandle
    
    strSQL = "SELECT to_char(出院日期,'YYYY-MM-DD HH24:MI:SS') as 出院日期 from 病案主页 where 病人ID=[1] AND 主页ID=[2]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取出院时间", lng病人ID, lng主页ID)
    If rsTemp.EOF Then
        Exit Function
    Else
        If NVL(rsTemp!出院日期) = "" Then
            bln病人在院 = True
        End If
    End If
    Exit Function
errhandle:
    If ErrCenter = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetRptImages(ByRef RptViewer As DicomViewer, ByVal lngOrderID As Long, ByVal blnMoved As Boolean)
'------------------------------------------------
'功能：获取报告图像到本地，并刷新显示
'参数： RptViewer －－显示图像的控件
'       lngOrderID -- 医嘱ID
'       blnMoved -- 是否转储
'返回：无，直接往RptViewer 中加入图像
'------------------------------------------------
    Dim objFileSystem As New Scripting.FileSystemObject
    Dim strSQL As String, rsTemp As New ADODB.Recordset
    Dim aryFiles() As String    '报告图像数组
    Dim strFiles As String      '按分号分隔的成功下载的文件
    Dim aryRptFileName() As String    '报告文件名数组
    
    Dim struFtpTag As TFtpConTag
    Dim strVirtualPath As String
    Dim strLocalPath As String
    Dim intCount As Integer
    Dim curImage As DicomImage
    Dim lngResult As Long
    
    '先清空RptViewer 中的图像
    RptViewer.Images.Clear
    
    '检查本地缓存图像的根目录是否存在，如果不存在则创建本地根目录，如果创建失败，则直接退出程序
    If objFileSystem.FolderExists(App.Path & "\TmpImage\") = False Then objFileSystem.CreateFolder App.Path & "\TmpImage\"
    If objFileSystem.FolderExists(App.Path & "\TmpImage\") = False Then GetRptImages = False: Exit Function
    
    '从数据库读取图像来源信息
    err = 0: On Error Resume Next
    
    strSQL = "Select To_Char(L.接收日期, 'yyyymmdd') As 子目录, L.检查uid, L.报告图象, A1.Ftp目录 As Root1, A1.Ip地址 As Ip1," & vbNewLine & _
            "       A1.FTP用户名 As Usr1, A1.FTP密码 As Pwd1, A2.Ftp目录 As Root2, A2.Ip地址 As Ip2, A2.FTP用户名 As Usr2, A2.FTP密码 As Pwd2" & vbNewLine & _
            "From 影像检查记录 L, 影像设备目录 A1, 影像设备目录 A2" & vbNewLine & _
            "Where L.位置一 = A1.设备号(+) And L.位置二 = A2.设备号(+) And L.医嘱id = [1]"
            
    If blnMoved = True Then
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
    End If
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取报告图像", lngOrderID)
    If rsTemp.RecordCount <= 0 Then GetRptImages = False: Exit Function
    
    aryFiles = Split("" & rsTemp!报告图象, ";")
    aryRptFileName = Split("" & rsTemp!报告图象, ";")
    
    If UBound(aryFiles) < 0 Then GetRptImages = False: Exit Function
        
    '检查本机缓存中本次检查的目录是否存在，如果不存在则创建本地存储目录，如果创建失败，则退出程序
    err = 0: On Error Resume Next
    
    strLocalPath = App.Path & "\TmpImage\" & rsTemp!子目录
    If objFileSystem.FolderExists(strLocalPath) = False Then objFileSystem.CreateFolder strLocalPath
    If objFileSystem.FolderExists(strLocalPath) = False Then GetRptImages = False: Exit Function
    
    strLocalPath = strLocalPath & "\" & rsTemp!检查UID
    If objFileSystem.FolderExists(strLocalPath) = False Then objFileSystem.CreateFolder strLocalPath
    If objFileSystem.FolderExists(strLocalPath) = False Then GetRptImages = False: Exit Function
        
    strFiles = ""
    '检查本地缓存图像是否存在，如果存在，则不从FTP下载，而直接读取本机缓存图像
    For intCount = 0 To UBound(aryFiles)
        '如果文件存在，则不需要下载，设置标记
        If Dir(strLocalPath & "\" & Trim(aryFiles(intCount))) <> "" Then
            strFiles = strFiles & ";" & strLocalPath & "\" & Trim(aryFiles(intCount))
            aryFiles(intCount) = ""
        End If
    Next intCount
    
    If strFiles <> "" Then
        If Left(strFiles, 1) = ";" Then strFiles = Mid(strFiles, 2)
    End If
    
    '如果本次存在的文件数量跟需要打开的文件数量不一致，则从FTP下载本机不存在的图像
    If UBound(Split(strFiles, ";")) <> UBound(aryFiles) Then
        '首先从设备1下载图像
        strVirtualPath = NVL(rsTemp!Root1) & "/" & NVL(rsTemp!子目录) & "/" & NVL(rsTemp!检查UID)
        struFtpTag = FtpTagInstance(NVL(rsTemp!Ip1), NVL(rsTemp!Usr1), NVL(rsTemp!Pwd1), strVirtualPath)
        
        If Trim(struFtpTag.Ip) = "" Then
            strVirtualPath = NVL(rsTemp!Root2) & "/" & NVL(rsTemp!子目录) & "/" & NVL(rsTemp!检查UID)
            struFtpTag = FtpTagInstance(NVL(rsTemp!Ip2), NVL(rsTemp!Usr2), NVL(rsTemp!Pwd2), strVirtualPath)
        End If
        
        For intCount = 0 To UBound(aryFiles)
            If aryFiles(intCount) <> "" Then
                lngResult = FtpDownload(struFtpTag, Trim(aryFiles(intCount)), strLocalPath & "\" & Trim(aryFiles(intCount)), False)
                If lngResult = frAbort Then Exit Function
                
                strFiles = strFiles & ";" & strLocalPath & "\" & Trim(aryFiles(intCount))
            End If
        Next intCount
        
        If strFiles <> "" Then
            If Left(strFiles, 1) = ";" Then strFiles = Mid(strFiles, 2)
        End If
    End If
    
    '将获得的文件装入
    Dim iRows As Integer, iCols As Integer
    aryFiles = Split(strFiles, ";")
    With RptViewer
        For intCount = 0 To UBound(aryFiles)
            Set curImage = New DicomImage
            Call ImportImgToDicom(curImage, aryFiles(intCount))
            
            curImage.BorderWidth = 3: curImage.BorderColour = vbWhite
            curImage.tag = aryRptFileName(intCount)
            .Images.Add curImage
        Next
        If UBound(aryFiles) >= 0 Then
            .CurrentIndex = 1
            .Images(.CurrentIndex).BorderColour = vbBlue
        End If
        If .Images.Count > 0 Then
            ResizeRegion .Images.Count, .Width, .Height, iRows, iCols
            .MultiColumns = iCols: .MultiRows = iRows
        Else
            '暂无内容
        End If
    End With
    
    GetRptImages = True: Exit Function

errHand:
'    cFtpNet.FuncFtpDisConnect
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Private Sub ImportImgToDicom(objDcmImage As DicomImage, ByVal strImgFile As String)
On Error GoTo errhandle
    Dim objTmp As StdPicture
    Dim objFs As New FileSystemObject
    
    Set objTmp = LoadPicture(strImgFile)
    
    Call objDcmImage.FileImport(strImgFile, "JPG")
Exit Sub
errhandle:
    Call objFs.DeleteFile(strImgFile, True)
End Sub

Public Sub PromptResult(lngOrderID As Long, lngModul As Long, frmParent As Form, lngCur科室ID As Long, strResultInput As String, Optional strDocId As String = "")
    Dim strResult As String
    Dim strSQL As String
    Dim objMsgCenter As New clsPacsMsgProcess
On Error GoTo errH
    strResult = frmResult.zlGetResult(frmParent, lngModul, lngOrderID, lngCur科室ID, strResultInput)   '提示输入阴阳性和影像质量
    
    If strResult = "" Then Exit Sub
    
    If InStr(strResultInput, "危急状态") > 0 Then
        If Split(strResult, "-")(0) = 2 Then     '危急值
            strSQL = "zl_影像检查_危急更新(" & lngOrderID & ",1)"
            
            Call objMsgCenter.OpenMsgCenter(lngModul, lngCur科室ID, gstrPrivs)
            Call objMsgCenter.Send_Msg_Critical(lngOrderID)
        ElseIf Split(strResult, "-")(0) = 1 Then
            strSQL = "zl_影像检查_危急更新(" & lngOrderID & ",0)"
        Else
            strSQL = "zl_影像检查_危急更新(" & lngOrderID & ",'')"
        End If
        zlDatabase.ExecuteProcedure strSQL, "标记危急值"
    End If
    
    If InStr(strResultInput, "结果阳性") > 0 Then
        If Split(strResult, "-")(1) = 1 Then    '阴阳性
            strSQL = "ZL_影像检查_结果(" & lngOrderID & ",1)"
        ElseIf Split(strResult, "-")(1) = 2 Then
            strSQL = "ZL_影像检查_结果(" & lngOrderID & ",0)"
        Else
            strSQL = "ZL_影像检查_结果(" & lngOrderID & ",'')"
        End If
        zlDatabase.ExecuteProcedure strSQL, "标记阴阳性"
    End If
    
    If lngModul = 1290 Then         '影像医技站才记录影像质量
        If InStr(strResultInput, "影像质量") > 0 Then
            Select Case Split(strResult, "-")(2)
                Case 1
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",1)"
                Case 2
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",2)"
                Case 3
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",3)"
                Case 4
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",4)"
                Case Else
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",'')"
            End Select
            zlDatabase.ExecuteProcedure strSQL, "影像质量"
        End If
    End If
    
    '记录报告质量
    If InStr(strResultInput, "报告质量") > 0 Then
        If Split(strResult, "-")(3) <> "" Then
            Select Case Split(strResult, "-")(3)
                Case 1
                    strSQL = "Zl_报告质量_Update(" & lngOrderID & ",1)"
                Case 2
                    strSQL = "Zl_报告质量_Update(" & lngOrderID & ",2)"
                Case 3
                    strSQL = "Zl_报告质量_Update(" & lngOrderID & ",3)"
                Case 4
                    strSQL = "Zl_报告质量_Update(" & lngOrderID & ",4)"
                Case Else
                    strSQL = "Zl_报告质量_Update(" & lngOrderID & ",'')"
            End Select
            zlDatabase.ExecuteProcedure strSQL, "报告质量"
        End If
    End If
    
    If lngModul <> 1294 Then    '除病理外，需记录诊断符合情况
        If InStr(strResultInput, "符合情况") > 0 Then
            If Split(strResult, "-")(4) = 1 Then    '符合情况
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'符合')"
            ElseIf Split(strResult, "-")(4) = 2 Then
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'基本符合')"
            ElseIf Split(strResult, "-")(4) = 3 Then
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'不符合')"
            Else
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'')"
            End If
            zlDatabase.ExecuteProcedure strSQL, "符合情况"
        End If
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Public Sub PromptResultRich(lngOrderID As Long, strDocId As String, lngModul As Long, frmParent As Form, lngCur科室ID As Long, strResultInput As String)
    Dim strResult As String
    Dim strSQL As String
    Dim objRichReport As New clsRichReport
    Dim objMsgCenter As New clsPacsMsgProcess
On Error GoTo errH
    strResult = frmResult.zlGetResult(frmParent, lngModul, strDocId, lngCur科室ID, strResultInput)
    
    If strResult = "" Then Exit Sub
    
    objRichReport.CreatePacsInterface
    
    If InStr(strResultInput, "危急状态") > 0 Then
        If Split(strResult, "-")(0) = 2 Then     '危急值
            strSQL = "zl_影像检查_危急更新(" & lngOrderID & ",1)"
            
            Call objMsgCenter.OpenMsgCenter(lngModul, lngCur科室ID, gstrPrivs)
            Call objMsgCenter.Send_Msg_Critical(lngOrderID)
        ElseIf Split(strResult, "-")(0) = 1 Then
            strSQL = "zl_影像检查_危急更新(" & lngOrderID & ",0)"
        Else
            strSQL = "zl_影像检查_危急更新(" & lngOrderID & ",'')"
        End If
        zlDatabase.ExecuteProcedure strSQL, "标记危急值"
    End If
    
    If InStr(strResultInput, "结果阳性") > 0 Then
        If Split(strResult, "-")(1) = 1 Then    '阴阳性
            Call objRichReport.EvaluatResult(strDocId, "1")
        ElseIf Split(strResult, "-")(1) = 2 Then
            Call objRichReport.EvaluatResult(strDocId, "0")
        Else
            Call objRichReport.EvaluatResult(strDocId, "0")
        End If
    End If
    
    If lngModul = 1290 Then         '影像医技站才记录影像质量
        If InStr(strResultInput, "影像质量") > 0 Then
            Select Case Split(strResult, "-")(2)
                Case 1
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",1)"
                Case 2
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",2)"
                Case 3
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",3)"
                Case 4
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",4)"
                Case Else
                    strSQL = "Zl_影像质量_Update(" & lngOrderID & ",'')"
            End Select
            zlDatabase.ExecuteProcedure strSQL, "影像质量"
        End If
    End If
    
    '记录报告质量
    If InStr(strResultInput, "报告质量") > 0 Then
        If Split(strResult, "-")(3) <> "" Then
            Select Case Split(strResult, "-")(3)
                Case 1
                    Call objRichReport.EvaluatReportQuality(strDocId, "1")
                Case 2
                    Call objRichReport.EvaluatReportQuality(strDocId, "2")
                Case 3
                    Call objRichReport.EvaluatReportQuality(strDocId, "3")
                Case 4
                    Call objRichReport.EvaluatReportQuality(strDocId, "4")
                Case Else
                    Call objRichReport.EvaluatReportQuality(strDocId, "0")
            End Select
        End If
    End If
    
    If lngModul <> 1294 Then    '除病理外，需记录诊断符合情况
        If InStr(strResultInput, "符合情况") > 0 Then
            If Split(strResult, "-")(4) = 1 Then    '符合情况
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'符合')"
            ElseIf Split(strResult, "-")(4) = 2 Then
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'基本符合')"
            ElseIf Split(strResult, "-")(4) = 3 Then
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'不符合')"
            Else
                strSQL = "Zl_符合情况_Update(" & lngOrderID & ",'')"
            End If
            zlDatabase.ExecuteProcedure strSQL, "符合情况"
        End If
    End If
    Exit Sub
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub


Public Function BillingWarn(frmParent As Object, ByVal strPrivs As String, _
    rsWarn As ADODB.Recordset, ByVal str姓名 As String, ByVal cur剩余款额 As Currency, _
    ByVal cur当日金额 As Currency, ByVal cur记帐金额 As Currency, ByVal cur担保金额 As Currency, _
    ByVal str收费类别 As String, ByVal str类别名称 As String, str已报类别 As String, _
    intWarn As Integer, Optional ByVal bln划价 As Boolean) As Integer
'功能:对病人记帐进行报警提示
'参数:rsWarn=包含报警参数设置的记录集(该病人病区,并区分好了医保)
'     str收费类别=当前要检查的类别,用于分类报警
'     str类别名称=类别名称,用于提示
'     bln划价=生成划价费用时的报警，类似具有欠费强制记帐权限时的处理
'     intWarn=是否显示询问性的提示,-1=要显示,0=缺省为否,1-缺省为是
'返回:str已报类别="CDE":具体在本次报警的一组类别,"-"为所有类别。该返回用于处理重复报警
'     intWarn=本次询问性提示中的选择结果,0=为否,1-为是
'     0;没有报警,继续
'     1:报警提示后用户选择继续
'     2:报警提示后用户选择中断
'     3:报警提示必须中断
'     4:欠费强制记帐报警,继续
    Dim bln已报警 As Boolean, byt标志 As Byte
    Dim byt方式 As Byte, byt已报方式 As Byte
    Dim arrTmp As Variant, vMsg As VbMsgBoxResult
    Dim str担保 As String, i As Long
    
    BillingWarn = 0
    
    '报警参数检查:NULL是没有设置,0是设置了的
    If rsWarn.State = 0 Then Exit Function
    If rsWarn.EOF Then Exit Function
    If IsNull(rsWarn!报警值) Then Exit Function
    
    '对应类别定位有效报警设置
    If Not IsNull(rsWarn!报警标志1) Then
        If rsWarn!报警标志1 = "-" Or InStr(rsWarn!报警标志1, str收费类别) > 0 Then byt标志 = 1
        If rsWarn!报警标志1 = "-" Then str类别名称 = "" '所有类别时,不必提示具体的类别
    End If
    If byt标志 = 0 And Not IsNull(rsWarn!报警标志2) Then
        If rsWarn!报警标志2 = "-" Or InStr(rsWarn!报警标志2, str收费类别) > 0 Then byt标志 = 2
        If rsWarn!报警标志2 = "-" Then str类别名称 = "" '所有类别时,不必提示具体的类别
    End If
    If byt标志 = 0 And Not IsNull(rsWarn!报警标志3) Then
        If rsWarn!报警标志3 = "-" Or InStr(rsWarn!报警标志3, str收费类别) > 0 Then byt标志 = 3
        If rsWarn!报警标志3 = "-" Then str类别名称 = "" '所有类别时,不必提示具体的类别
    End If
    If byt标志 = 0 Then Exit Function '无有效设置
    
    '报警标志2实际上是两种判断①②,其它只有一种判断①
    '这种处理的前提是一种类别只能属于一种报警方式(报警参数设置时)
    '示例："-" 或 ",ABC,567,DEF"
    '报警标志2示例："-①" 或 ",ABC②,567①,DEF①"
    bln已报警 = InStr(str已报类别, str收费类别) > 0 Or str已报类别 Like "-*"
    
    If bln已报警 Then '当intWarn = -1时,也可强行再报警
        If byt标志 = 2 Then
            If str已报类别 Like "-*" Then
                byt已报方式 = IIf(Right(str已报类别, 1) = "②", 2, 1)
            Else
                arrTmp = Split(str已报类别, ",")
                For i = 0 To UBound(arrTmp)
                    If InStr(arrTmp(i), str收费类别) > 0 Then
                        byt已报方式 = IIf(Right(arrTmp(i), 1) = "②", 2, 1)
                        'Exit For '取消说明见住院记帐模块
                    End If
                Next
            End If
        Else
            Exit Function
        End If
    End If
    
    If str类别名称 <> "" Then str类别名称 = """" & str类别名称 & """费用"
    str担保 = IIf(cur担保金额 = 0, "", "(含担保额:" & Format(cur担保金额, "0.00") & ")")
    cur剩余款额 = cur剩余款额 + cur担保金额 - cur记帐金额
    cur当日金额 = cur当日金额 + cur记帐金额
        
    '---------------------------------------------------------------------
    If rsWarn!报警方法 = 1 Then  '累计费用报警(低于)
        Select Case byt标志
            Case 1 '低于报警值(包括预交款耗尽)提示询问记帐
                If cur剩余款额 < rsWarn!报警值 Then
                    If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当前剩余款" & str担保 & ":" & Format(cur剩余款额, "0.00") & ",低于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & ",允许该病人记帐吗？", frmParent)
                            If vMsg = vbNo Or vMsg = vbCancel Then
                                If vMsg = vbCancel Then intWarn = 0
                                BillingWarn = 2
                            ElseIf vMsg = vbYes Or vMsg = vbIgnore Then
                                If vMsg = vbIgnore Then intWarn = 1
                                BillingWarn = 1
                            End If
                        Else
                            If intWarn = 0 Then
                                BillingWarn = 2
                            ElseIf intWarn = 1 Then
                                BillingWarn = 1
                            End If
                        End If
                    Else
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当前剩余款" & str担保 & ":" & Format(cur剩余款额, "0.00") & " 低于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & "。", frmParent, True)
                            If vMsg = vbIgnore Then intWarn = 1
                        End If
                        BillingWarn = 4
                    End If
                End If
            Case 2 '低于报警值提示询问记帐,预交款耗尽时禁止记帐
                If Not bln已报警 Then
                    If cur剩余款额 < 0 Then
                        byt方式 = 2
                        If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                            If intWarn = -1 Then
                                vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当前剩余款" & str担保 & "已经耗尽," & str类别名称 & "禁止记帐。", frmParent, True)
                                If vMsg = vbIgnore Then intWarn = 1
                            End If
                            BillingWarn = 3
                        Else
                            If intWarn = -1 Then
                                vMsg = frmMsgBox.ShowMsgBox(str类别名称 & IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当前剩余款" & str担保 & "已经耗尽。", frmParent, True)
                                If vMsg = vbIgnore Then intWarn = 1
                            End If
                            BillingWarn = 4
                        End If
                    ElseIf cur剩余款额 < rsWarn!报警值 Then
                        byt方式 = 1
                        If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                            If intWarn = -1 Then
                                vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当前剩余款" & str担保 & ":" & Format(cur剩余款额, "0.00") & ",低于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & ",允许该病人记帐吗？", frmParent)
                                If vMsg = vbNo Or vMsg = vbCancel Then
                                    If vMsg = vbCancel Then intWarn = 0
                                    BillingWarn = 2
                                ElseIf vMsg = vbYes Or vMsg = vbIgnore Then
                                    If vMsg = vbIgnore Then intWarn = 1
                                    BillingWarn = 1
                                End If
                            Else
                                If intWarn = 0 Then
                                    BillingWarn = 2
                                ElseIf intWarn = 1 Then
                                    BillingWarn = 1
                                End If
                            End If
                        Else
                            If intWarn = -1 Then
                                vMsg = frmMsgBox.ShowMsgBox(IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当前剩余款" & str担保 & ":" & Format(cur剩余款额, "0.00") & ",低于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & "。", frmParent, True)
                                If vMsg = vbIgnore Then intWarn = 1
                            End If
                            BillingWarn = 4
                        End If
                    End If
                Else
                    '上次已报警并选择继续或强制继续
                    If byt已报方式 = 1 Then
                        '上次低于报警值并选择继续或强制继续,不再处理低于的情况,但还需要判断预交款是否耗尽
                        If cur剩余款额 < 0 Then
                            byt方式 = 2
                            If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                                If intWarn = -1 Then
                                    vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当前剩余款" & str担保 & "已经耗尽," & str类别名称 & "禁止记帐。", frmParent, True)
                                    If vMsg = vbIgnore Then intWarn = 1
                                End If
                                BillingWarn = 3
                            Else
                                If intWarn = -1 Then
                                    vMsg = frmMsgBox.ShowMsgBox(str类别名称 & IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当前剩余款" & str担保 & "已经耗尽。", frmParent, True)
                                    If vMsg = vbIgnore Then intWarn = 1
                                End If
                                BillingWarn = 4
                            End If
                        End If
                    ElseIf byt已报方式 = 2 Then
                        '上次预交款已经耗尽并强制继续,不再处理
                        Exit Function
                    End If
                End If
            Case 3 '低于报警值禁止记帐
                If cur剩余款额 < rsWarn!报警值 Then
                    If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当前剩余款" & str担保 & ":" & Format(cur剩余款额, "0.00") & ",低于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & ",禁止记帐。", frmParent, True)
                            If vMsg = vbIgnore Then intWarn = 1
                        End If
                        BillingWarn = 3
                    Else
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当前剩余款" & str担保 & ":" & Format(cur剩余款额, "0.00") & ",低于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & "。", frmParent, True)
                            If vMsg = vbIgnore Then intWarn = 1
                        End If
                        BillingWarn = 4
                    End If
                End If
        End Select
    ElseIf rsWarn!报警方法 = 2 Then  '每日费用报警(高于)
        Select Case byt标志
            Case 1 '高于报警值提示询问记帐
                If cur当日金额 > rsWarn!报警值 Then
                    If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当日费用:" & Format(cur当日金额, gstrDec) & ",高于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & ",允许该病人记帐吗？", frmParent)
                            If vMsg = vbNo Or vMsg = vbCancel Then
                                If vMsg = vbCancel Then intWarn = 0
                                BillingWarn = 2
                            ElseIf vMsg = vbYes Or vMsg = vbIgnore Then
                                If vMsg = vbIgnore Then intWarn = 1
                                BillingWarn = 1
                            End If
                        Else
                            If intWarn = 0 Then
                                BillingWarn = 2
                            ElseIf intWarn = 1 Then
                                BillingWarn = 1
                            End If
                        End If
                    Else
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当日费用:" & Format(cur当日金额, gstrDec) & ",高于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & "。", frmParent, True)
                            If vMsg = vbIgnore Then intWarn = 1
                        End If
                        BillingWarn = 4
                    End If
                End If
            Case 3 '高于报警值禁止记帐
                If cur当日金额 > rsWarn!报警值 Then
                    If Not (InStr(";" & strPrivs & ";", ";欠费强制记帐;") > 0 Or bln划价) Then
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(str姓名 & " 当日费用:" & Format(cur当日金额, gstrDec) & ",高于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & ",禁止记帐。", frmParent, True)
                            If vMsg = vbIgnore Then intWarn = 1
                        End If
                        BillingWarn = 3
                    Else
                        If intWarn = -1 Then
                            vMsg = frmMsgBox.ShowMsgBox(IIf(bln划价, "", "欠费强制记帐") & "提醒:" & vbCrLf & vbCrLf & str姓名 & " 当日费用:" & Format(cur当日金额, gstrDec) & ",高于" & str类别名称 & "报警值:" & Format(rsWarn!报警值, "0.00") & "。", frmParent, True)
                            If vMsg = vbIgnore Then intWarn = 1
                        End If
                        BillingWarn = 4
                    End If
                End If
        End Select
    End If
    
    '对于继续类的操作,返回已报警类别
    If BillingWarn = 1 Or BillingWarn = 4 Then
        If byt标志 = 1 Then
            If rsWarn!报警标志1 = "-" Then
                str已报类别 = "-"
            Else
                str已报类别 = str已报类别 & "," & rsWarn!报警标志1
            End If
        ElseIf byt标志 = 2 Then
            If rsWarn!报警标志2 = "-" Then
                str已报类别 = "-"
            Else
                str已报类别 = str已报类别 & "," & rsWarn!报警标志2
            End If
            '附加标注以判断已报警的具体方式
            str已报类别 = str已报类别 & IIf(byt方式 = 2, "②", "①")
        ElseIf byt标志 = 3 Then
            If rsWarn!报警标志3 = "-" Then
                str已报类别 = "-"
            Else
                str已报类别 = str已报类别 & "," & rsWarn!报警标志3
            End If
        End If
    End If
End Function

Public Function FinishBillingWarn(ByVal frmParent As Object, ByVal strPrivs As String, ByVal lng病人ID As Long, _
    ByVal lng主页ID As Long, ByVal lng病区ID As Long, ByVal cur金额 As Currency, ByVal str类别 As String, ByVal str类别名 As String) As Boolean
'功能：当执行完成有自动审核的费用时，对病人费用进行记帐报警。
'参数：str类别="CDE..."，报警金额涉及到的收费类别
'      str类别名="检查,检验,..."，对应的类别名用于提示
    Dim rsPati As ADODB.Recordset
    Dim rsWarn As ADODB.Recordset
    Dim strWarn As String, intWarn As Integer
    Dim strSQL As String, intR As Integer, i As Long
    Dim cur当日 As Currency
    
    On Error GoTo errH
    
    If lng主页ID <> 0 Then
        '住院病人报警
        strSQL = _
            " Select 病人ID,预交余额,费用余额,0 as 预结费用 From 病人余额 Where 性质=1 And 病人ID=[1]" & _
            " Union ALL" & _
            " Select A.病人ID,0,0,Sum(金额) From 保险模拟结算 A,病案主页 B" & _
            " Where A.病人ID=B.病人ID And A.主页ID=B.主页ID And B.险类 Is Not Null And A.病人ID=[1] And A.主页ID=[2] Group by A.病人ID"
        strSQL = "Select 病人ID,Nvl(Sum(预交余额),0)-Nvl(Sum(费用余额),0)+Nvl(Sum(预结费用),0) as 剩余款 From (" & strSQL & ") Group by 病人ID"
        
        strSQL = "Select A.姓名,zl_PatiWarnScheme(A.病人ID,B.主页ID) as 适用病人,C.剩余款," & _
            " Decode(A.担保额,Null,Null,zl_PatientSurety(A.病人ID,B.主页ID)) as 担保额" & _
            " From 病人信息 A,病案主页 B,(" & strSQL & ") C" & _
            " Where A.病人ID=B.病人ID And A.病人ID=C.病人ID(+)" & _
            " And A.病人ID=[1] And B.主页ID=[2]"
        Set rsPati = zlDatabase.OpenSQLRecord(strSQL, "FinishBillingWarn", lng病人ID, lng主页ID)
    Else
        '其他按门诊报警
        strSQL = "Select 病人ID,预交余额,费用余额 From 病人余额 Where 性质=1 And 病人ID=[1]"
        strSQL = "Select A.姓名,zl_PatiWarnScheme(A.病人ID) as 适用病人,A.担保额," & _
            " Nvl(B.预交余额,0)-Nvl(B.费用余额,0)as 剩余款" & _
            " From 病人信息 A,(" & strSQL & ") B,医保病人关联表 D,医保病人档案 E" & _
            " Where A.病人ID=B.病人ID(+) And A.病人id = D.病人id(+) And A.险类=D.险类(+)" & _
            " And D.险类=E.险类(+) And D.中心=E.中心(+) And D.医保号=E.医保号(+) And D.标志(+)=1" & _
            " And A.病人ID=[1]"
        Set rsPati = zlDatabase.OpenSQLRecord(strSQL, "FinishBillingWarn", lng病人ID)
    End If
    
    intWarn = -1 '记帐报警时缺省要提示
    '执行报警:门诊病人病区ID=0
    strSQL = "Select Nvl(报警方法,1) as 报警方法,报警值,报警标志1,报警标志2,报警标志3 From 记帐报警线 Where Nvl(病区ID,0)=[1] And 适用病人=[2]"
    Set rsWarn = zlDatabase.OpenSQLRecord(strSQL, "FinishBillingWarn", lng病区ID, CStr(NVL(rsPati!适用病人)))
    If Not rsWarn.EOF Then
        If rsWarn!报警方法 = 2 Then cur当日 = GetPatiDayMoney(lng病人ID)
        str类别名 = Mid(str类别名, 2)
        For i = 1 To Len(str类别)
            intR = BillingWarn(frmParent, strPrivs, rsWarn, NVL(rsPati!姓名), NVL(rsPati!剩余款, 0), cur当日, cur金额, NVL(rsPati!担保额, 0), Mid(str类别, i, 1), Split(str类别名, ",")(i - 1), strWarn, intWarn)
            If InStr(",2,3,", intR) > 0 Then Exit Function
        Next
    End If
    
    FinishBillingWarn = True
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function ItemHaveCash(ByVal int病人来源 As Integer, ByVal bln单独执行 As Boolean, ByVal lng医嘱ID As Long, ByVal lng相关ID As Long, _
    ByVal lng发送号 As Long, ByVal str类别 As String, ByVal str单据号 As String, ByVal int记录性质 As Integer, ByVal int门诊记帐 As Integer, ByVal int方式 As Integer, _
    Optional ByVal blnMove As Boolean, Optional ByVal dat发送时间 As Date, Optional ByRef str医嘱IDs As String, Optional ByRef strNOs As String, Optional ByRef blnIsAbnormal As Boolean) As Boolean
'功能：判断当前的执行医嘱是否已收费或记帐划价单是否已审核
'参数： int病人来源 -- 1-门诊,2-住院
'       bln单独执行 -- True = 单独执行；False = 整个医嘱全部执行
'       lng医嘱ID -- 医嘱ID
'       lng相关ID -- 相关ID
'       lng发送号 -- 发送号
'       str类别=诊疗类别，用于从一组医嘱中区分分开执行的内容
'       str单据号 -- 单据号
'       int记录性质 -- 记录性质
'       int门诊记帐 -- 门诊记帐，1=住院发送到门诊记帐
'       int方式 --  0-检查是否存在未收费记录
'                   1-检查是否存在已收费记录
'       blnMove -- 是否转储
'       dat发送时间 -- 发送时间
'       str医嘱IDs -- 【返回参数】，该医嘱及相关的医嘱ID
'       strNOs -- 【返回参数】，医嘱发送的单据号和补的附费中的单据号
'       blnIsAbnormal -- 【返回参数】，是否异常单据
'      返回：True--已收费；False--未收费；
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String, strTab As String
    
    If int病人来源 = 2 And int记录性质 = 2 And int门诊记帐 = 0 Then
        strTab = "住院费用记录"
    Else
        strTab = "门诊费用记录"
    End If
    
    ItemHaveCash = True
    str医嘱IDs = ""
    strNOs = ""
    
    '对应的费用中是否存在未收费[或已作废]的内容
    '和清单只显示已收费不同：
    '1.检查了医嘱附费(不加记录性质的条件，因为可能补收费单或记帐单)
    '2.记帐划价也显示为未收(清单需要先显出来执行后审核)
    '3.按NO对应到相关医嘱的费用检查(清单是按显示的医嘱ID)
    strSQL = _
        " Select A.记录状态,Nvl(B.相关ID,B.ID) as 医嘱ID,B.诊疗类别,A.执行状态,A.NO" & IIf(strTab = "住院费用记录", ",0 as 费用状态", ",NVL(A.费用状态,0) as 费用状态") & _
        " From " & strTab & " A,病人医嘱记录 B" & _
        " Where A.NO=[4] And A.记录状态 IN(0,1,3) And A.医嘱序号+0=B.ID And MOD(A.记录性质,10)=[5] " & IIf(bln单独执行, " And B.ID=[2]", "") & _
        " Union ALL " & _
        " Select B.记录状态,Nvl(C.相关ID,C.ID) as 医嘱ID,C.诊疗类别,B.执行状态,A.NO" & IIf(strTab = "住院费用记录", ",0 as 费用状态", ",NVL(b.费用状态,0) as 费用状态") & _
        " From 病人医嘱记录 C," & strTab & " B,病人医嘱附费 A" & _
        " Where A.NO=B.NO And A.记录性质=MOD(B.记录性质,10) And A.医嘱ID=B.医嘱序号+0" & IIf(bln单独执行, " And A.医嘱ID=[2]", _
            " And A.医嘱ID IN (Select ID From 病人医嘱记录 Where (ID=[1] Or 相关ID=[1]) And 诊疗类别=[6])") & _
        " And A.发送号=[3] And B.记录状态 IN(0,1,3) And A.医嘱ID=C.ID And A.记录性质=[5] "
    If blnMove Then
        strSQL = Replace(strSQL, "病人医嘱记录", "H病人医嘱记录")
        strSQL = Replace(strSQL, "病人医嘱附费", "H病人医嘱附费")
        strSQL = Replace(strSQL, strTab, "H" & strTab)
    ElseIf zlDatabase.DateMoved(dat发送时间) Then
        strSQL = strSQL & " Union ALL " & Replace(strSQL, strTab, "H" & strTab)
    End If
    
    On Error GoTo errH
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "ItemHaveCash", IIf(lng相关ID <> 0, lng相关ID, lng医嘱ID), lng医嘱ID, lng发送号, str单据号, int记录性质, str类别)
    If Not rsTmp.EOF Then
        If int方式 = 0 Then
            rsTmp.Filter = "医嘱ID=" & IIf(lng相关ID <> 0, lng相关ID, lng医嘱ID) & " And 诊疗类别='" & str类别 & "' And 费用状态=1"
            If Not rsTmp.EOF Then
                blnIsAbnormal = True
                ItemHaveCash = False
            Else
                rsTmp.Filter = "医嘱ID=" & IIf(lng相关ID <> 0, lng相关ID, lng医嘱ID) & " And 诊疗类别='" & str类别 & "' And 记录状态=0"
                If Not rsTmp.EOF Then ItemHaveCash = False
            End If
            
            While Not rsTmp.EOF
                If InStr("," & str医嘱IDs & ",", "," & rsTmp!医嘱ID & ",") = 0 Then
                    str医嘱IDs = str医嘱IDs & "," & rsTmp!医嘱ID
                End If
                If InStr("," & strNOs & ",", "," & rsTmp!no & ",") = 0 Then
                    strNOs = strNOs & "," & rsTmp!no
                End If
                rsTmp.MoveNext
            Wend
                
            strNOs = Mid(strNOs, 2)
            str医嘱IDs = Mid(str医嘱IDs, 2)
        ElseIf int方式 = 1 Then
            rsTmp.Filter = "医嘱ID=" & IIf(lng相关ID <> 0, lng相关ID, lng医嘱ID) & " And 诊疗类别='" & str类别 & "' And 记录状态<>1 And 费用状态<>1"
            If Not rsTmp.EOF Then ItemHaveCash = False
        End If
    ElseIf int方式 = 1 Then
        ItemHaveCash = False
    End If
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Function GetNullAdviceInf() As clsStudyInfo
    Dim ObjClsStudyInfo As New clsStudyInfo

    With ObjClsStudyInfo
        .lngPatId = 0
        .strPatientName = ""
        .lngPatDept = 0
        .lngAdviceId = 0
        .lngUnit = 0
        .lngSendNo = 0
        .strStudyUID = ""
        .blnCanPrint = False
        .blnIsInsidePatient = False
        .blnMoved = False
        .intState = -1
        .intStep = -1
        .strRegNo = ""
'        .lngRegId = 0
        .lngExeDepartmentId = 0
'        .strExeRoom = ""
        .lngPatientFrom = 0
        .strDoDoctor = ""
        .strStudyNum = ""
'        .strBedNum = ""
        .strMarkNum = ""
        .lngBaby = 0
        .strPatientSex = ""
        .strPatientAge = ""
        .strNO = ""
'        .lngRecordKind = 0
        .intFilmGiveOut = 0
        .intReportGiveOut = 0
        .strAdviceContext = ""
        .strAdviceDepartAndMethod = ""
        .strStuStateDesc = ""
        .blnIsTechincalSure = False
        .intDangerState = 0
        .intEmergentTag = 0
        .intGreenChannel = 0
        .blnInfancy = False
        .dtFirstTime = CDate(0)
        .lngReportType = 0
    End With
    
    Set GetNullAdviceInf = ObjClsStudyInfo
End Function


Public Function GetAdviceMoney(ByVal lngAdviceId As Long, ByVal lng来源 As Long, str类别 As String, str类别名 As String) As Currency
'功能：根据指定的医嘱ID，获取医嘱对应未审核的记帐费用合计
'参数：lngAdviceID,strSendNo
'返回：str类别,str类别名=用于报警提示

    Dim rsTmp As New ADODB.Recordset
    Dim curMoney As Currency
    Dim strFeeTable As String
    Dim strFilter As String
    
    str类别 = "": str类别名 = ""
    
    On Error GoTo errH
    
    '需要根据系统参数判断，81号参数是"执行后自动审核划价单"
    If gbln执行后审核 = False Then Exit Function
    
    '住院病人查住院费用记录，门诊、外诊等病人查门诊费用记录
    If lng来源 = 2 Then
        strFeeTable = "住院费用记录"
        strFilter = " A.记录性质"
    Else
        strFeeTable = "门诊费用记录"
        strFilter = " decode(A.记录性质,1,1,11,1,A.记录性质)"
    End If
    
    gstrSQL = "Select /*+ RULE */" & vbNewLine & _
                " B.编码, B.名称, Sum(A.实收金额) As 金额" & vbNewLine & _
                "From " & strFeeTable & " A, 收费项目类别 B" & vbNewLine & _
                "Where A.医嘱序号 + 0 In (Select ID From 病人医嘱记录 Where ID = [1] Or 相关id = [1]) And" & vbNewLine & _
                "      (" & strFilter & ", A.NO) In" & vbNewLine & _
                "      ( Select 记录性质, NO" & vbNewLine & _
                "        From 病人医嘱附费" & vbNewLine & _
                "        Where 医嘱id In (Select ID From 病人医嘱记录 Where ID = [1] Or 相关id = [1])" & vbNewLine & _
                "        Union All" & vbNewLine & _
                "        Select 记录性质, NO" & vbNewLine & _
                "        From 病人医嘱发送" & vbNewLine & _
                "        Where 医嘱id In (Select ID From 病人医嘱记录 Where ID = [1] Or 相关id = [1] )" & vbNewLine & _
                "       ) And A.记帐费用 = 1 And A.记录状态 = 0 And A.收费类别 = B.编码 " & vbNewLine & _
                "Group By B.编码, B.名称"
                
    Set rsTmp = zlDatabase.OpenSQLRecord(gstrSQL, "GetAdviceMoney", lngAdviceId)
    
    curMoney = 0
    Do While Not rsTmp.EOF
        curMoney = curMoney + NVL(rsTmp!金额, 0)
        str类别 = str类别 & rsTmp!编码
        str类别名 = str类别名 & "," & rsTmp!名称
        rsTmp.MoveNext
    Loop
    
    str类别名 = Mid(str类别名, 2)
    GetAdviceMoney = curMoney
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetPinyinName(ByVal strPatiName As String, ByVal intCapital As Integer, ByVal blnUseSplitter As Boolean) As String
'功能：根据数据字典中的配置，获取姓名对应的拼音名
'strPatiName:病人姓名
    Dim strTempName As String
    Dim strSQL As String
    Dim rsReccord As ADODB.Recordset
    
On Error GoTo errhandle
    If strPatiName = "" Then Exit Function
    
    If blnUseSplitter Then
        strSQL = "select Zlpinyincode([1],[2],[3],[4]) as 拼音名 from dual"
        Set rsReccord = zlDatabase.OpenSQLRecord(strSQL, "提取拼音", strPatiName, 1, 1, " ")
    Else
        strSQL = "select Zlpinyincode([1],[2],[3]) as 拼音名 from dual"
        Set rsReccord = zlDatabase.OpenSQLRecord(strSQL, "提取拼音", strPatiName, 1, 1)
    End If
    
    If rsReccord.RecordCount > 0 Then
        strTempName = NVL(rsReccord!拼音名)
    End If
    
    If intCapital = 0 Then
        GetPinyinName = UCase(Trim(strTempName))
    ElseIf intCapital = 1 Then
        GetPinyinName = LCase(Trim(strTempName))
    Else
        GetPinyinName = Trim(strTempName)
    End If
    
    Exit Function
errhandle:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function GetPatiDayMoney(lng病人ID As Long) As Currency
'功能：获取指定病人当天发生的费用总额
    Dim rsTmp As New ADODB.Recordset
    Dim strSQL As String
    
    On Error GoTo errH
    
    strSQL = "Select zl_PatiDayCharge([1]) as 金额 From Dual"
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "mdlCISKernel", lng病人ID)
    If Not rsTmp.EOF Then GetPatiDayMoney = NVL(rsTmp!金额, 0)
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function funcConnectShardDir(frmParent As Form, strShareRemoteDir As String, strUserName As String, _
    strPassWord As String) As Long
'------------------------------------------------
'功能：创建网络资源
'参数： frmParent  -- 父窗体
'       strShareRemoteDir -- 共享目录
'       strUserName -- 共享目录用户名
'       strPassWord -- 共享目录密码
'返回：无，连接共享目录
'------------------------------------------------
    
    Dim NetR As NETRESOURCE
    Dim lngResult As Long
    
    NetR.dwType = RESOURCETYPE_ANY
    NetR.lpLocalName = vbNullString
    NetR.lpRemoteName = strShareRemoteDir
    NetR.lpProvider = vbNullString
    lngResult = WNetAddConnection2(NetR, strPassWord, strUserName, 0)
    
    If lngResult <> 0 Then
        MsgBoxD frmParent, "网络连接失败，请检查网络设置是否正确！", vbInformation, gstrSysName
    End If
    funcConnectShardDir = lngResult
End Function

Public Function bln费用未审核出院(ByVal lng病人ID As Long, ByVal lng主页ID As Long, ByVal lng医嘱ID As Long, ByVal lng来源 As Long) As Boolean
'------------------------------------------------
'功能：判断病人是否已出院，且有记账费用未审核
'参数： lng病人ID  -- 病人ID
'       lng主页ID -- 主页ID
'       lng医嘱ID -- 医嘱ID
'       lng来源 -- 病人来源
'返回：True -- 患者已出院且有未审核费用；False --其他
'------------------------------------------------
'需要根据系统参数判断，81号参数是"执行后自动审核划价单"
    
    bln费用未审核出院 = False
    
    If gbln执行后审核 = True Then
        If Not bln病人在院(lng病人ID, lng主页ID) And bln存在未审划价单(lng医嘱ID, lng来源) Then
            bln费用未审核出院 = True
        End If
    End If
End Function

Public Function bln未缴费用(lngOrderID As Long) As Boolean
'------------------------------------------------
'功能：判断检查医嘱是否有未交的费用
'参数： lngOrderID  -- 医嘱ID
'返回：True -- 未收费；False --已收费
'------------------------------------------------
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim intSourceType As Integer
    Dim lngSendNo As Long
    Dim str诊疗类别 As String
    Dim str单据号 As String
    Dim int记录性质 As Integer
    Dim int门诊记帐  As Integer
    
    On Error GoTo err
    
    bln未缴费用 = False
    
    strSQL = "Select A.记录性质,A.门诊记帐,A.发送号,A.NO,B.诊疗类别,B.病人来源 from 病人医嘱发送 A,病人医嘱记录 B  where A.医嘱ID=B.ID and  B.ID =[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "bln未缴费用", lngOrderID)
    If rsTemp.EOF = False Then
        int记录性质 = NVL(rsTemp!记录性质, 0)
        int门诊记帐 = NVL(rsTemp!门诊记帐, 0)
        str诊疗类别 = NVL(rsTemp!诊疗类别)
        lngSendNo = rsTemp!发送号
        str单据号 = NVL(rsTemp!no)
        intSourceType = NVL(rsTemp!病人来源)
        
        bln未缴费用 = Not ItemHaveCash(intSourceType, False, lngOrderID, 0, lngSendNo, str诊疗类别, str单据号, int记录性质, int门诊记帐, 0)
    End If
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function AssembleImage(AssembleViewer As DicomImages, ByVal intRows As Integer, ByVal intCols As Integer, _
    ByVal lngHeight As Long, ByVal lngWidth As Long) As DicomImage

'组合viewer中的显示的所有图像成一个图像

    Dim Image As New DicomImage '新图像
    Dim imgs As New DicomImages '临时存储屏幕采集的图像集
    Dim intWidth As Integer     '新图像的宽度
    Dim intHeight As Integer    '新图像的高度
    Dim Simg As New DicomImage
    Dim sZoom As Single
    Dim intImgRectWidth As Integer  '单张图像可占用的区域宽度
    Dim intImgRectHeight As Integer '单张图像可占用的区域高度
    Dim i As Integer
    Dim intMaxWidth As Integer      '拼接后图像的最大宽度
    Dim intMaxHeight As Integer     '拼接后图像的最大高度
    Dim intBorder As Integer        '图像之间的边距
    Dim intOffsetX As Integer       '拼接时X方向的位移
    Dim intOffsetY As Integer       '拼接时Y方向的位移
    Dim lngWhiteX As Long           '将图象底色改成白色的X宽度
    Dim lngWhiteY As Long           '将图象底色改成白色的Y高度
    Dim iPlane As Integer
    Dim dblZoom As Double
    Dim iMax As Integer
    
    If AssembleViewer.Count <= 0 Then
        '返回一个黑图**************
        Exit Function
    End If

    On Error GoTo err
    '计算新图像的宽度和高度

    '新图像的宽度和高度不能够大于intMaxWidth×intMaxHeight（宽度×高度）
    intMaxWidth = 3073
    intMaxHeight = 3073
    intBorder = 10

    intImgRectWidth = 0
    intImgRectHeight = 0

    '估算新图像的宽度和高度

    '使用原图像的宽度和高度和，并用Viewer的比例来修正。

    '估算图像的新宽高
    For i = 1 To AssembleViewer.Count
        If intImgRectWidth < AssembleViewer(i).SizeX Then intImgRectWidth = AssembleViewer(i).SizeX
        If intImgRectHeight < AssembleViewer(i).SizeY Then intImgRectHeight = AssembleViewer(i).SizeY
    Next i
    
    
    If AssembleViewer.Count = 1 Then
        If intImgRectWidth >= intMaxWidth Or intImgRectHeight >= intMaxHeight Then
            iMax = intMaxWidth
        Else
            iMax = IIf(intImgRectWidth > intImgRectHeight, intImgRectWidth, intImgRectHeight)
        End If
    ElseIf AssembleViewer.Count <= 4 Then
        If intImgRectWidth >= 2048 Or intImgRectHeight >= 2048 Then
            iMax = IIf(intImgRectWidth > intImgRectHeight, intImgRectWidth, intImgRectHeight) / 2
        Else
            iMax = IIf(intImgRectWidth > intImgRectHeight, intImgRectWidth, intImgRectHeight) / 1.5
        End If
    Else
        iMax = IIf(intImgRectWidth > intImgRectHeight, intImgRectWidth, intImgRectHeight) / 3
    End If
    
    If iMax < 512 Then iMax = 512
    
    '计算横向和纵向图像数量
    intWidth = intImgRectWidth * intCols
    intHeight = intImgRectHeight * intRows
    
    '修正图像的宽高，不能大于最大值
    '如果大于intMaxWidth×intMaxHeight则，按照图像总长宽比，使用小于等于intMaxWidth×intMaxHeight作为新宽高,
    If intWidth > intMaxWidth Or intHeight > intMaxHeight Then
        If intHeight / intWidth > intMaxHeight / intMaxWidth Then
            intWidth = intWidth / intHeight * intMaxHeight
            intHeight = intMaxHeight
        Else
            intHeight = intHeight / intWidth * intMaxWidth
            intWidth = intMaxWidth
        End If
    End If
    
    '采集图像
    '将图像采集到临时图像集
    For i = 1 To AssembleViewer.Count
        '计算缩放比例 hj修改,解决多图合并时，放大的图象无法真正放大的问题
        sZoom = intImgRectHeight / AssembleViewer(i).SizeY
        If sZoom > intImgRectWidth / AssembleViewer(i).SizeX Then
            sZoom = intImgRectWidth / AssembleViewer(i).SizeX
        End If
        
        AssembleViewer(i).StretchToFit = False
        AssembleViewer(i).Zoom = sZoom
        '采集图像
        Set Simg = AssembleViewer(i).PrinterImage(8, 3, True, sZoom, 0, AssembleViewer(i).SizeX, 0, AssembleViewer(i).SizeY)
        imgs.Add Simg
    Next i

    '精确计算新图像的宽度和高度
    intImgRectWidth = 0
    intImgRectHeight = 0
    
    '控制图象的分辨率在500*500之内
    Dim imgsTmp As New DicomImages
    For i = 1 To imgs.Count
        
        iPlane = 1
        If Not IsNull(imgs(i).Attributes(&H28, &H4).value) And imgs(i).Attributes(&H28, &H4).Exists Then
            If imgs(i).Attributes(&H28, &H4).value = "RGB" Then
                iPlane = 3
            End If
        End If
        
        '根据imax计算缩放比率
        If imgs(i).SizeX > iMax Or imgs(i).SizeY > iMax Then
            dblZoom = iMax / imgs(i).SizeX
            If dblZoom > iMax / imgs(i).SizeY Then dblZoom = iMax / imgs(i).SizeY
        Else
            dblZoom = 1
        End If
        
        imgsTmp.Add imgs(i).PrinterImage(8, iPlane, True, dblZoom, 0, imgs(i).SizeX, 0, imgs(i).SizeY)
    Next
    
    Set imgs = imgsTmp

    For i = 1 To imgs.Count
        If intImgRectWidth < imgs(i).SizeX Then intImgRectWidth = imgs(i).SizeX
        If intImgRectHeight < imgs(i).SizeY Then intImgRectHeight = imgs(i).SizeY
        imgs(i).Attributes.Add &H8, &H16, "doSOP_SecondaryCapture"
    Next i
    intImgRectWidth = intImgRectWidth + intBorder
    intImgRectHeight = intImgRectHeight + intBorder
    intWidth = intImgRectWidth * intCols
    intHeight = intImgRectHeight * intRows

    '创建新图像
    Image.Name = "print"
    Image.PatientID = "print001"
    
    Image.Attributes.Add &H8, &H16, doSOP_SecondaryCapture
    Image.Attributes.Add &H28, &H2, 3 ' samples/pixel
    Image.Attributes.Add &H28, &H4, "RGB" ' photometric interpreation  'CT都是MONOCHROME2,CR都是MONOCHROME1？
    Image.Attributes.Add &H28, &H10, intHeight  'x,Rows
    Image.Attributes.Add &H28, &H11, intWidth 'Y,Columns
    Image.Attributes.Add &H28, &H100, 8 'bits allocated
    Image.Attributes.Add &H28, &H101, 8 ' bits stored
    Image.Attributes.Add &H28, &H102, 7 ' high bit
    ReDim pix(intWidth * 3, intHeight * 3) As Byte
    For lngWhiteX = 0 To intWidth * 3
        For lngWhiteY = 0 To intHeight * 3
            pix(lngWhiteX, lngWhiteY) = 255
        Next lngWhiteY
    Next lngWhiteX
    Image.Attributes.Add &H7FE0, &H10, pix

    '拼接新图像
    For i = 1 To imgs.Count
        '计算图像内位移
        intOffsetX = (intImgRectWidth - imgs(i).SizeX - intBorder) / 2
        intOffsetY = (intImgRectHeight - imgs(i).SizeY - intBorder) / 2
        Image.Blt imgs(i), 0, 0, ((i - 1) Mod intCols) * intImgRectWidth + intOffsetX, ((i - 1) \ intCols) * intImgRectHeight + intOffsetY, imgs(i).SizeX, imgs(i).SizeY, 1, 1, 1, False
    Next i

    Set AssembleImage = Image
    Exit Function
err:
End Function

Public Function FunLogIn(frmParent As Form, str类型 As String) As String
'功能：对程序进行注册，如果注册成功，则返回注册时间
'参数： frmParent ---父窗体
'       str类型 ---'在注册码中使用的类型名称
'返回值：注册成功注册日期；注册失败返回空

    Dim intNum As Integer
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim strIP地址 As String         '需要注册的IP地址
    
    On Error GoTo err
    
    strIP地址 = OS.Ip
    
    '从注册码中提取授权的数量，-1--无限制；0--禁止；X（X>0）--按照数量控制
    intNum = gint视频设备数量
    
    'intNUM >0 ,则调用过程注册程序
    If intNum > 0 Then  '按数量限制
        strSQL = "Zl_影像操作记录_Update('" & strIP地址 & "','" & str类型 & "'," & intNum & ")"
        zlDatabase.ExecuteProcedure strSQL, "注册" & str类型
        '检查注册是否成功
        strSQL = "Select 启动时间,IP地址 from 影像操作记录 where  类型=[1]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取启动时间", str类型)
        
        If rsTemp.RecordCount <= intNum Then
            rsTemp.Filter = "IP地址='" & strIP地址 & "'"
            If rsTemp.RecordCount = 1 Then  '注册成功
                FunLogIn = rsTemp!启动时间
                Exit Function
            End If
        End If
    ElseIf intNum = -1 Then     '无限制
        FunLogIn = Now
        Exit Function
    Else    '=0，或者其他值，禁止，不做任何处理，后面有提示
    
    End If
    
    '注册失败，可能是两个原因：
    '1、注册的数量超过了许可的数量，无法注册IP地址
    '2、直接通过SQL向表中添加了IP地址，导致表中的记录总数量超过了许可的数量
    Call MsgBoxD(frmParent, "打开的" & str类型 & "超过您购买的总数量（" & intNum & "）。请向软件供应商联系。", vbOKOnly, gstrSysName)
    FunLogIn = ""
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function FunCheckRegInfo(frmParent As Form) As Boolean
'功能：检查是否存在注册的ip地址且启用了视频源
On Error GoTo errhandle
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim strIP地址 As String         '需要注册的IP地址
    
    FunCheckRegInfo = False
    
    strIP地址 = OS.Ip
    
    strSQL = "select 工作站 from zltools.zlclients where ip=[1] and 启用视频源=1"
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取注册信息", strIP地址)
    
    If rsTemp.EOF = False Then FunCheckRegInfo = True
    
Exit Function
errhandle:
End Function

Public Function FunCheckIp(frmParent As Form, str类型 As String) As Boolean
'功能：检查是否存在注册的ip地址
On Error GoTo errhandle
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim strIP地址 As String         '需要注册的IP地址
    
    FunCheckIp = False
    
    strIP地址 = OS.Ip
    
    strSQL = "Select 启动时间 from 影像操作记录 where 类型=[2] and IP地址=[1] "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取启动时间", strIP地址, str类型)
    
    If rsTemp.EOF = False Then FunCheckIp = True
    
Exit Function
errhandle:
End Function


Public Function FunLogOut(frmParent As Form, str类型 As String, str启动时间 As String) As Boolean
'功能：退出程序的时候，检查程序是否合法注册过，避免有人通过触发器等手段定时删除“影像操作记录”表中的记录。
'参数： frmParent ---父窗体
'       str类型 ---'在注册码中使用的类型名称
'       str启动时间 --- 注册工作站时返回的时间
'返回值：合法注册True；非法启动的False
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim strIP地址 As String         '需要注册的IP地址
    Dim intNum As Integer
    
    On Error GoTo err
    strIP地址 = OS.Ip
    
    '启动时间为空，表示注册失败，没有正常启动，因此退出的时候不再检测数据库
    If str启动时间 = "" Then
        FunLogOut = True
        Exit Function
    End If
    
    '从注册码中提取授权的数量，-1--无限制；0--禁止；X（X>0）--按照数量控制
    intNum = gint视频设备数量
    
    If intNum > 0 Then '按照数量控制
        strSQL = "Select 启动时间 from 影像操作记录 where IP地址=[1] and 类型=[2]"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取启动时间", strIP地址, str类型)
        If rsTemp.EOF = False Then
            FunLogOut = True
        Else
            '对比启动时间和数据库的时间，如果不是同一天，说明是前一天开启程序后注册信息被删除了，
            '这种情况认为是合法注册
            strSQL = "Select sysdate from dual"
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取数据库时间")
            If Format(rsTemp!sysdate, "yyyy-mm-dd") <> Format(str启动时间, "yyyy-mm-dd") Then
                FunLogOut = True
            Else
                FunLogOut = False
            End If
        End If
    ElseIf intNum = -1 Then     '无限制
        FunLogOut = True
    Else    '=0，或者其他值，禁止
    
    End If
    If FunLogOut = False Then
        Call MsgBoxD(frmParent, "打开的" & str类型 & "超过您购买的总数量（" & intNum & "）。请向软件供应商联系。", vbOKOnly, gstrSysName)
    End If
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function getLicenseCount(strLicenseName As String) As Integer
'读取授权的数量
'参数： strLicenseName --- 授权名称
    Dim strLiceseCount As String
    
    On Error GoTo err
    
    strLiceseCount = zl9comlib.zlRegInfo(strLicenseName)
    If strLiceseCount = "" Then '无限制
        getLicenseCount = -1
    ElseIf Val(strLiceseCount) > 0 Then '按照数量限制
        getLicenseCount = Val(strLiceseCount)
    Else '禁止
        getLicenseCount = 0
    End If
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function getStudyStateRich(ByVal lngOrderID As Long, ByVal strDocId As String, Optional ByVal blnIsCancelComplete As Boolean = False, Optional ByRef blnAllReportFinished As Boolean = False, _
                            Optional ByRef lngSendNo As Long, Optional ByRef bln保存结果阳性 As Boolean, Optional ByRef blnCriticalValues As Boolean, _
                            Optional ByRef blnImageQuality As Boolean, Optional ByRef blnReportQuality As Boolean, Optional ByRef blnConformDetermine As Boolean) As Integer
'------------------------------------------------
'功能：检查报告的签名情况，确定本报告进行的程度。
'参数： lngOrderID -- 医嘱ID
'       strDocId -- 报告ID
'       blnIsCancelComplete -- 可选，是否是执行的取消完成操作
'       blnAllReportFinished -- 可选，返回参数
'       lngSendNO -- 可选，返回参数
'       bln保存结果阳性 -- 可选，返回参数
'       blnCriticalValues -- 可选，返回参数
'       blnImageQuality -- 可选，返回参数
'       blnReportQuality -- 可选，返回参数
'       blnConformDetermine -- 可选，返回参数
'返回：1--已登记；2--已报到；3--已检查；4--已报告；5--已审核；6--已完成；-1--已驳回
'------------------------------------------------

    Dim i As Integer
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim intFinishReport As Integer
    Dim intReportCount As Integer
    Dim blnIsReject As Boolean

    On Error GoTo err
    
    strSQL = "Select c.执行过程,d.医嘱id As 影像医嘱ID,e.医嘱id As 报告医嘱ID,c.发送号,d.检查uid,d.影像质量,d.符合情况,d.危急状态,e.报告质量," & _
             "e.id,e.创建人, e.最后编辑人 As 保存人,e.最后编辑时间 As 完成时间,e.最后审核人, e.结果阳性, e.报告状态,e.id as 报告ID " & _
             "From 病人医嘱发送 c, 影像检查记录 d, 影像报告记录 e " & _
             "Where e.医嘱id = [1] And d.医嘱id(+) = c.医嘱id And e.医嘱id(+) = c.医嘱id"
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取是否签名", lngOrderID)
    
    '如果查询没有结果，及没有报告
    If rsTemp.EOF = True Then
        strSQL = "Select a.检查uid, a.发送号, b.执行过程 From 影像检查记录 a, 病人医嘱发送 b Where a.医嘱ID = [1] and a.医嘱ID = b.医嘱ID"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取是否签名", lngOrderID)
        
        If Not rsTemp.EOF Then
            If NVL(rsTemp!检查UID) = "" Then
                getStudyStateRich = 2
            Else
                getStudyStateRich = 3
            End If
            
            lngSendNo = NVL(rsTemp!发送号, 0)
            
            '对于类似需要立即转院的病人，可能来不及完成报告就需完成整个检查，这时执行过程为6仍可能存在未完成的报告
            If NVL(rsTemp!执行过程, 0) = 6 And Not blnIsCancelComplete Then
                getStudyStateRich = 6
            End If
        Else
            getStudyStateRich = 1
        End If
         
        Exit Function
    End If
    
    rsTemp.Filter = "报告ID='" & strDocId & "'"
    
    If rsTemp.RecordCount > 0 Then
        lngSendNo = NVL(rsTemp!发送号, 0)
        bln保存结果阳性 = Not IsNull(rsTemp!结果阳性)
        blnCriticalValues = Not IsNull(rsTemp!危急状态)
        blnImageQuality = Not IsNull(rsTemp!影像质量)
        blnReportQuality = Not IsNull(rsTemp!报告质量)
        blnConformDetermine = Not IsNull(rsTemp!符合情况)
    End If
    
    rsTemp.Filter = ""
    
    '对于需要立即转院的病人，可能来不及完成报告就需完成整个检查，这时执行过程为6仍可能存在未完成的报告
    If NVL(rsTemp!执行过程, 0) = 6 And Not blnIsCancelComplete Then
        getStudyStateRich = 6
        Exit Function
    End If
    
    strSQL = "Select 报告状态 From 影像报告记录 Where 医嘱ID=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "", lngOrderID)
    
    intReportCount = rsTemp.RecordCount
    
    For i = 0 To rsTemp.RecordCount - 1
        If NVL(rsTemp!报告状态) = 3 Or NVL(rsTemp!报告状态) = 4 Then '已审核或终审
            intFinishReport = intFinishReport + 1
        End If
        '记录是否有报告被驳回
        If NVL(rsTemp!报告状态) = 6 Or NVL(rsTemp!报告状态) = 5 Then blnIsReject = True
        rsTemp.MoveNext
    Next
    
    If intFinishReport = rsTemp.RecordCount Then blnAllReportFinished = True    '所有报告都已审核或终审
    
    rsTemp.Filter = "报告状态 = 4"  '已终审的报告
    If intReportCount = rsTemp.RecordCount Then '所有报告都已终审
        getStudyStateRich = 5
    Else
        getStudyStateRich = 4
    End If
    
    If blnIsReject = True Then getStudyStateRich = -1
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function getStudyState(ByVal lngOrderID As Long, Optional ByVal blnIsCancelComplete As Boolean = False, Optional ByRef lngSendNo As Long, _
                            Optional ByRef str创建人 As String, Optional ByRef str签名 As String, Optional ByRef str保存人 As String, _
                            Optional ByRef bln保存结果阳性 As Boolean, Optional ByRef blnCriticalValues As Boolean, Optional ByRef blnImageQuality As Boolean, _
                            Optional ByRef blnReportQuality As Boolean, Optional ByRef blnConformDetermine As Boolean) As Integer
'检查报告的签名情况，确定本次检查进行的程度。
'参数： lngOrderID [IN] --- 医嘱id
'       lngSendNo [OUT] --- 返回，发送号
'       str创建人 [OUT] --- 返回，报告的创建人
'       str签名   [OUT] --- 返回，报告的最后签名
'       str保存人 [OUT] --- 返回，报告的最后保存人
'       bln保存结果阳性[OUT]--- 返回，结果阳性是否已经输入,True-已输入，False-未输入
'blnIsCancelComplete:是否是执行的取消完成操作
'返回值：1--已登记；2--已报到；3--已检查；4--已报告；5--已审核；6--已完成
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim rsSign As ADODB.Recordset
    
    On Error GoTo err
    
    strSQL = "Select d.医嘱id As 影像医嘱ID,e.医嘱id As 报告医嘱ID,c.发送号,d.检查uid,d.影像质量,d.符合情况,d.危急状态,d.报告质量, " _
             & " e.病历id,e.创建人, e.保存人, e.签名级别, e.完成时间, e.最后版本,c.结果阳性,c.执行过程 " _
             & " From 病人医嘱发送 c, 影像检查记录 d, " _
             & " (Select a.医嘱id,a.病历id,b.创建人, b.保存人, b.签名级别, b.完成时间, b.最后版本 " _
             & "  From 病人医嘱报告 a, 电子病历记录 b Where a.医嘱id = [1] And a.病历id = b.Id) e " _
             & " Where c.医嘱id = [1] And d.医嘱id(+) = c.医嘱id And e.医嘱id(+) = c.医嘱id "
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "提取是否签名", CLng(lngOrderID))
    
    '如果查询没有结果，就退出
    If rsTemp.EOF = True Then Exit Function
    
    lngSendNo = rsTemp!发送号
    str创建人 = NVL(rsTemp!创建人)
    str保存人 = NVL(rsTemp!保存人)
    bln保存结果阳性 = Not IsNull(rsTemp!结果阳性)
    blnCriticalValues = Not IsNull(rsTemp!危急状态)
    blnImageQuality = Not IsNull(rsTemp!影像质量)
    blnReportQuality = Not IsNull(rsTemp!报告质量)
    blnConformDetermine = Not IsNull(rsTemp!符合情况)
    
    '如果影像医嘱ID为空，则过程=1,已登记
    '如果报告医嘱ID为空，且 检查UID为空，则过程=2，已报到
    '如果报告医嘱ID为空，检查UID不为空，则过程=3，已检查
    '其他检查签名和报告完成情况，确定过程为2,3,4，5，已报到,已检查,已报告，已审核
    '对于需要立即转院的病人，可能来不及完成报告就需完成整个检查，这时执行过程为6仍可能存在未完成的报告
    If NVL(rsTemp!执行过程, 0) = 6 And Not blnIsCancelComplete Then
        getStudyState = 6
        Exit Function
    End If
    
    If NVL(rsTemp!影像医嘱ID) = "" Then     '过程=1,已登记
        getStudyState = 1
    ElseIf NVL(rsTemp!报告医嘱ID) = "" And NVL(rsTemp!检查UID) = "" Then    '过程=2，已报到
        getStudyState = 2
    ElseIf NVL(rsTemp!报告医嘱ID) = "" And NVL(rsTemp!检查UID) <> "" Then    '过程=3，已检查
        getStudyState = 3
    Else    '检查签名和报告完成情况,确定过程为2,3,4，5，已报到,已检查,已报告，已审核
        If NVL(rsTemp!完成时间) = "" And rsTemp!最后版本 = 1 Then
            '未签名保存 或最后一次医师退签，执行过程有图像为已检查，无图像为已报到
            getStudyState = IIf(NVL(rsTemp!检查UID) = "", 2, 3)
        Else
            '判断当前报告的签名情况，如果“电子病历内容”中有大于1的签名，则属于已审核。
            If rsTemp!签名级别 > 1 Then '已审核
                getStudyState = 5
                '已审核的情况，需要返回签名人。回退内容的情况，保存人不一定是签名人，因此要查找最后一个签名人
                strSQL = "Select 要素表示 As 签名级别,内容文本 as 签名  From 电子病历内容 Where 文件ID=[1] " _
                        & " And 对象类型= 8 And 开始版 = [2] "
                Set rsSign = zlDatabase.OpenSQLRecord(strSQL, "提取签名级别", CLng(rsTemp!病历Id), CLng(rsTemp!最后版本))
                
                If rsSign.EOF = False Then
                    str签名 = NVL(rsSign!签名)
                    
                    If InStr(str签名, M_STR_TAG_SIGNWITHIMG) > 0 Then
                        str签名 = Mid(str签名, 1, InStr(str签名, M_STR_TAG_SIGNWITHIMG) - 1)
                    Else
                        str签名 = str签名
                    End If
            
                    str签名 = Split(str签名, ";")(0)
                End If
            Else
                '以下情况：（1）回退签名，但是没有回退内容；（2）修订模式下保存报告，但没有签名。
                '会出现这样的查询结果：rsTemp!签名级别 = 0 And rsTemp!最后版本 > 1
                '出现了回退，或者修订，但是没有签名的情况，报告应该处于“报告中”的状态。
                getStudyState = 4
            End If
        End If
    End If
    
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Private Function hibyte(ByVal wParam As Integer)
    hibyte = wParam \ &H100 And &HFF&
End Function

Private Function lobyte(ByVal wParam As Integer)
    lobyte = wParam And &HFF&
End Function

Private Function funPreDownLoadImages(thisMsg As TGetImgMsg) As Boolean
'------------------------------------------------
'功能：后台下载图像
'参数： thisMsg  -- 要下载的图像信息
'返回：True -- 成功； False -- 失败
'------------------------------------------------
    Dim lngWinHandle As Long        '需要接收消息的“中联图像下载”程序的窗口句柄
    Dim strMsg As String
    Dim wParam As Long
    Dim lResult As Long
    Dim strTemp As String
    Dim buf(1 To 1024) As Byte
    Dim dss As COPYDATASTRUCT
    
    On Error Resume Next
    
    '组织消息
    strMsg = thisMsg.strSubDir & "||" & thisMsg.strDestMainDir & "||" & thisMsg.strIP & "||" _
            & thisMsg.strFtpDir & "||" & thisMsg.strFTPUser & "||" & thisMsg.strFTPPswd & "||" _
            & thisMsg.strSDDir & "||" & thisMsg.strSDUser & "||" & thisMsg.strSDPswd
    
    '发送COPYDATA消息
    
    On Error GoTo err
    
    '使用BUF，或者使用lstrcpy函数都可以正常发送字符消息
   '消息定义：wParam = 123，dss中dwData = 3
    wParam = 123
   
    Call CopyMemory(buf(1), ByVal strMsg, LenB(StrConv(strMsg, vbFromUnicode)))
    dss.dwData = 3               '这个消息不用，3只是双方定义的一个标记而已
    dss.cbData = LenB(StrConv(strMsg, vbFromUnicode)) + 1
    
    dss.lpData = VarPtr(buf(1))                    '使用buf发送，可以控制消息在1024之内
'    dss.lpData = lstrcpy(strMsg, strMsg)            '这个方法发送的消息，也是正确的。
    
    
    '启动图像下载窗口
    Shell App.Path & "\zlGetImage.exe"
        
    '加载窗体的时候，查找图像下载程序
    lngWinHandle = FindWindow(vbNullString, "中联图像下载")
    
    lResult = SendMessage(lngWinHandle, WM_COPYDATA, wParam, dss)
    
    funPreDownLoadImages = True
    Exit Function
err:
    '暂不处理
End Function

Public Function DynamicCreate(ByVal strclass As String, ByVal strCaption As String) As Object
'动态创建对象
    On Error Resume Next
    Set DynamicCreate = CreateObject(strclass)
   
    If err <> 0 Then
        MsgBox strCaption & "组件创建失败，请联系管理员检查是否正确安装!", vbInformation, gstrSysName
        Set DynamicCreate = Nothing
    End If
    err.Clear
End Function

Public Function CreateStudyUid(ByVal strUid As String) As String
'创建检查UID
On Error GoTo errH
    Dim rsData As New ADODB.Recordset
    Dim strSQL As String
    Dim strNewStudyUID As String
    
    strNewStudyUID = strUid 'M_STR_STUDY_UID & "." & Format(Now, "yymmddhhmmss") & "." & Fix(Rnd(1000) * 1000)

    strSQL = "select 检查UID from 影像检查记录 where 检查UID = [1]" & _
              " Union All Select 检查UID from 影像临时记录 where 检查UID = [1]"
              
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "PACS图像保存", strNewStudyUID)
    
    If rsData.RecordCount > 0 Then
        '创建一个新的检查UID
        strSQL = "Select 影像检查UID序号_ID.Nextval From Dual"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "PACS图像保存")
        
        If Len(strNewStudyUID) <= 55 Then
            strNewStudyUID = strNewStudyUID & ".A" & rsData(0)
        Else
            strNewStudyUID = Left(strNewStudyUID, 55) & ".A" & rsData(0)
        End If
    End If
    
    CreateStudyUid = strNewStudyUID
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function


Public Function CreateSeriesUid(ByVal strUid As String) As String
'创建序列UID
On Error GoTo errH
    Dim rsData As New ADODB.Recordset
    Dim strSQL As String
    Dim strNewSeriesUid As String
    
    strNewSeriesUid = strUid 'M_STR_SERIES_UID & "." & Format(Now, "yymmddhhmmss") & "." & Fix(Rnd(1000) * 1000)
    
    strSQL = "select 序列UID from 影像检查序列 where 序列UID = [1]" & _
              " Union All Select 序列UID from 影像临时序列 where 序列UID = [1]"
              
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, "PACS图像保存", strNewSeriesUid)
    
    If rsData.RecordCount > 0 Then
        '创建一个新的检查UID
        strSQL = "Select 影像检查UID序号_ID.Nextval From Dual"
        Set rsData = zlDatabase.OpenSQLRecord(strSQL, "PACS图像保存")
        
        If Len(strNewSeriesUid) <= 55 Then
            strNewSeriesUid = strNewSeriesUid & ".A" & rsData(0)
        Else
            strNewSeriesUid = Left(strNewSeriesUid, 55) & ".A" & rsData(0)
        End If
    End If
    
    CreateSeriesUid = strNewSeriesUid
    Exit Function
errH:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Function

Public Function DeleteImages(frmParent As Form, intType As Integer, strImageUID As String, _
    strSeriesUID As String) As Boolean
'------------------------------------------------
'功能：删除FTP中的一个图像或者一个序列
'参数： frmParent -- 主窗体
'       intType -- 删除图像的类型，1-删除图像；2-删除序列
'       strImageUID -- 要删除图像的UID，intType=1时，需要有值
'       strSeriesUID - 要删除序列UID，intType=2时，需要有值
'返回：True -- 成功； False -- 失败
'------------------------------------------------
    '如果是删除一个图像，同时删除同名报告图，调用过程 ZL_影像图象_DELETE
    '如果是删除一个序列的图像，同时删除同名的报告图
    
    Dim struFtpTag As TFtpConTag
    Dim lngResult As Long
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim arrTmp() As String
    Dim strReportImage As String
    Dim intDeviceUsed As Integer
    Dim i As Integer
    Dim strRoot As String
    
    On Error GoTo err
    If intType = 1 And strImageUID = "" Then Exit Function
    If intType = 2 And strSeriesUID = "" Then Exit Function
    
    If intType = 1 Then         '删除图像
        strSQL = "Select a.医嘱ID,a.发送号,c.图像UID,a.报告图象, " & _
            " Decode(a.接收日期,Null,'',to_Char(a.接收日期,'YYYYMMDD')||'/')||a.检查UID As 图像目录, " & _
            "D.FTP用户名 As User1,D.FTP密码 As Pwd1,D.IP地址 As Host1,'/'||D.Ftp目录||'/' As Root1,d.设备号 as 设备号1," & _
            "E.FTP用户名 As User2,E.FTP密码 As Pwd2,E.IP地址 As Host2,'/'||E.Ftp目录||'/' As Root2,e.设备号 as 设备号2 " & _
            "From 影像检查记录 a,影像检查序列 b,影像检查图象 c,影像设备目录 D,影像设备目录 E " & _
            "Where a.检查UID=b.检查UID And b.序列UID=c.序列UID And c.图像UID = [1] " & _
            "And a.位置一=D.设备号(+) And a.位置二=E.设备号(+)"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "PACS删除图像", strImageUID)
    ElseIf intType = 2 Then
        strSQL = "Select a.医嘱ID,a.发送号,c.图像UID, " & _
            " Decode(a.接收日期,Null,'',to_Char(a.接收日期,'YYYYMMDD')||'/')||a.检查UID As 图像目录, " & _
            "D.FTP用户名 As User1,D.FTP密码 As Pwd1,D.IP地址 As Host1,'/'||D.Ftp目录||'/' As Root1,d.设备号 as 设备号1," & _
            "E.FTP用户名 As User2,E.FTP密码 As Pwd2,E.IP地址 As Host2,'/'||E.Ftp目录||'/' As Root2,e.设备号 as 设备号2 " & _
            "From 影像检查记录 a,影像检查序列 b,影像检查图象 c,影像设备目录 D,影像设备目录 E " & _
            "Where a.检查UID=b.检查UID And b.序列UID=c.序列UID And b.序列UID = [1] " & _
            "And a.位置一=D.设备号(+) And a.位置二=E.设备号(+)"
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "PACS删除序列", strSeriesUID)
    End If
    
    If rsTemp.EOF = True Then
        MsgBoxD frmParent, "没有找到可以删除的图像!", vbInformation, gstrSysName
        DeleteImages = False
        Exit Function
    End If
     
        
    struFtpTag = FtpTagInstance(NVL(rsTemp!Host1), _
                                NVL(rsTemp!User1), _
                                NVL(rsTemp!Pwd1), _
                                NVL(rsTemp!Root1) & NVL(rsTemp!图像目录))
                                
    If Trim(struFtpTag.Ip) = "" Then
        struFtpTag = FtpTagInstance(NVL(rsTemp!Host2), _
                                    NVL(rsTemp!User2), _
                                    NVL(rsTemp!Pwd2), _
                                    NVL(rsTemp!Root2) & NVL(rsTemp!图像目录))
    End If
    
    If intType = 1 Then
        '如果是删除单个图像，则删除同名报告图
        If Not IsNull(rsTemp("报告图象")) Then
            arrTmp = Split(rsTemp("报告图象"), ";")
            For i = 0 To UBound(arrTmp)
                If Trim(arrTmp(i)) <> strImageUID & ".jpg" Then
                    strReportImage = strReportImage & ";" & arrTmp(i)
                End If
            Next
            strReportImage = Mid(strReportImage, 2)
        End If
        
        strSQL = "ZL_影像图象_DELETE(" & rsTemp("医嘱ID") & "," & rsTemp("发送号") & ",'" & strImageUID & "','" & strReportImage & "')"
        zlDatabase.ExecuteProcedure strSQL, "影像图像删除"
        
        '删除图像文件
        FtpDelete struFtpTag, strImageUID, False
        FtpDelete struFtpTag, strImageUID & ".jpg", False, False
    ElseIf intType = 2 Then
        '先删除图像文件,同时删除同名的报告图
        rsTemp.MoveFirst
        While Not rsTemp.EOF
            FtpDelete struFtpTag, rsTemp!图像UID, False
            FtpDelete struFtpTag, rsTemp!图像UID & ".jpg", False, False
            rsTemp.MoveNext
        Wend
        
        '如果是删除序列，则直接删除序列中的图像
        rsTemp.MoveFirst
        strSQL = "Zl_影像序列_Delete(" & rsTemp("医嘱ID") & ",'" & strSeriesUID & "')"
        zlDatabase.ExecuteProcedure strSQL, "影像序列删除"
    End If
    
    DeleteImages = True
    Exit Function
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
    
End Function


Public Function GetDataToLocal(ByVal strSQL As String, ByVal strTitle As String, ParamArray arrInput() As Variant) As ADODB.Recordset
'功能：通过Command对象打开带参数SQL的记录集
'参数：strSQL=条件中包含参数的SQL语句,参数形式为"[x]"
'             x>=1为自定义参数号,"[]"之间不能有空格
'             同一个参数可多处使用,程序自动换为ADO支持的"?"号形式
'             实际使用的参数号可不连续,但传入的参数值必须连续(如SQL组合时不一定要用到的参数)
'      arrInput=不定个数的参数值,按参数号顺序依次传入,必须是明确类型
'               因为使用绑定变量,对带"'"的字符参数,不需要使用"''"形式。
'      strTitle=用于SQLTest识别的调用窗体/模块标题
'返回：记录集，CursorLocation=adUseClient,LockType=adLockReadOnly,CursorType=adOpenStatic
'举例：
'SQL语句为="Select 姓名 From 病人信息 Where (病人ID=[3] Or 门诊号=[3] Or 姓名 Like [4]) And 性别=[5] And 登记时间 Between [1] And [2] And 险类 IN([6],[7])"
'调用方式为：Set rsPati=OpenSQLRecord(strSQL, Me.Caption, CDate(Format(rsMove!转出日期,"yyyy-MM-dd")),dtp时间.Value, lng病人ID, "张%", "男", 20, 21)
    Dim cmdData As New ADODB.Command
    Dim rsData As New ADODB.Recordset
    Dim strPar As String, arrPar As Variant
    Dim lngLeft As Long, lngRight As Long
    Dim strSeq As String, intMax As Integer, i As Integer
    Dim strLog As String, varValue As Variant
    
    '分析自定的[x]参数
    lngLeft = InStr(1, strSQL, "[")
    Do While lngLeft > 0
        lngRight = InStr(lngLeft + 1, strSQL, "]")
        If lngRight = 0 Then Exit Do
        '可能是正常的"[编码]名称"
        strSeq = Mid(strSQL, lngLeft + 1, lngRight - lngLeft - 1)
        If IsNumeric(strSeq) Then
            i = CInt(strSeq)
            strPar = strPar & "," & i
            If i > intMax Then intMax = i
        End If
        
        lngLeft = InStr(lngRight + 1, strSQL, "[")
    Loop

    '替换为"?"参数
    strLog = strSQL
    For i = 1 To intMax
        strSQL = Replace(strSQL, "[" & i & "]", "?")
        
        '产生用于SQL跟踪的语句
        varValue = arrInput(i - 1)
        Select Case TypeName(varValue)
        Case "Byte", "Integer", "Long", "Single", "Double", "Currency" '数字
            strLog = Replace(strLog, "[" & i & "]", varValue)
        Case "String" '字符
            strLog = Replace(strLog, "[" & i & "]", "'" & Replace(varValue, "'", "''") & "'")
        Case "Date" '日期
            strLog = Replace(strLog, "[" & i & "]", "To_Date('" & Format(varValue, "yyyy-MM-dd HH:mm:ss") & "','YYYY-MM-DD HH24:MI:SS')")
        End Select
    Next

    '清除原有参数:不然不能重复执行
'    cmdData.CommandText = "" '不为空有时清除参数出错
'    Do While cmdData.Parameters.Count > 0
'        cmdData.Parameters.Delete 0
'    Loop
    
    '创建新的参数
    lngLeft = 0: lngRight = 0
    arrPar = Split(Mid(strPar, 2), ",")
    For i = 0 To UBound(arrPar)
        varValue = arrInput((arrPar(i) - 1))
        Select Case TypeName(varValue)
        Case "Byte", "Integer", "Long", "Single", "Double", "Currency" '数字
            cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adVarNumeric, adParamInput, 30, varValue)
        Case "String" '字符
            intMax = LenB(StrConv(varValue, vbFromUnicode))
            If intMax <= 2000 Then
                intMax = IIf(intMax <= 200, 200, 2000)
                cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adVarChar, adParamInput, intMax, varValue)
            Else
                If intMax < 4000 Then intMax = 4000
                cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adLongVarChar, adParamInput, intMax, varValue)
            End If
        Case "Date" '日期
            cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adDBTimeStamp, adParamInput, , varValue)
        Case "Variant()" '数组
            '这种方式可用于一些IN子句或Union语句
            '表示同一个参数的多个值,参数号不可与其它数组的参数号交叉,且要保证数组的值个数够用
            If arrPar(i) <> lngRight Then lngLeft = 0
            lngRight = arrPar(i)
            Select Case TypeName(varValue(lngLeft))
            Case "Byte", "Integer", "Long", "Single", "Double", "Currency" '数字
                cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i & "_" & lngLeft, adVarNumeric, adParamInput, 30, varValue(lngLeft))
                strLog = Replace(strLog, "[" & lngRight & "]", varValue(lngLeft), 1, 1)
            Case "String" '字符
                intMax = LenB(StrConv(varValue(lngLeft), vbFromUnicode))
                If intMax <= 2000 Then
                    intMax = IIf(intMax <= 200, 200, 2000)
                    cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i & "_" & lngLeft, adVarChar, adParamInput, intMax, varValue(lngLeft))
                Else
                    If intMax < 4000 Then intMax = 4000
                    cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i & "_" & lngLeft, adLongVarChar, adParamInput, intMax, varValue(lngLeft))
                End If
                
                strLog = Replace(strLog, "[" & lngRight & "]", "'" & Replace(varValue(lngLeft), "'", "''") & "'", 1, 1)
            Case "Date" '日期
                cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i & "_" & lngLeft, adDBTimeStamp, adParamInput, , varValue(lngLeft))
                strLog = Replace(strLog, "[" & lngRight & "]", "To_Date('" & Format(varValue(lngLeft), "yyyy-MM-dd HH:mm:ss") & "','YYYY-MM-DD HH24:MI:SS')", 1, 1)
            End Select
            lngLeft = lngLeft + 1 '该参数在数组中用到第几个值了
        End Select
    Next

    '执行返回记录集
    'If cmdData.ActiveConnection Is Nothing Then
        Set cmdData.ActiveConnection = gcnOracle '这句比较慢(这句执行1000次约0.5x秒)
    'End If
    cmdData.CommandText = strSQL
    
    Call SQLTest(App.ProductName, strTitle, strLog)
    
    Set rsData.ActiveConnection = gcnOracle
    
    rsData.CursorLocation = adUseClient
    rsData.CursorType = adOpenDynamic
    rsData.LockType = adLockOptimistic
    
    rsData.Open cmdData
    
    Set rsData.ActiveConnection = Nothing
    
    Set GetDataToLocal = rsData
    
    Call SQLTest
End Function


Public Sub GetDeptStorageDevice(frmParent As Object, ByVal lngAdviceId As Long, ByVal strNewStudyUID As String, _
    ByVal lngCurDeptId As Long, ByVal lngModule As Long, ByVal blnMoved As Boolean, _
    ByRef strDeviceNo As String, ByRef strFtpIp As String, _
    ByRef strFtpURL As String, ByRef strVirtualPath As String, _
    ByRef strFTPUser As String, ByRef strFTPPwd As String)
'------------------------------------------------------------------------------------------
'获取新的存储设备信息，如果设备存储信息部存在，则需要进行增加
'如果是取消关联，则使用strNewStudyUID将不能从数据库中查找到对应的数据
'参数： frmParent ---【IN】：父窗体
'       lngAdviceID---【IN】：医嘱ID
'       strNewStudyUID---【IN】：检查UID
'       lngCurDeptId ---【IN】：当前科室ID
'       lngModule---【IN】：模块号
'       blnMoved ---【IN】：是否转储
'       strDeviceNO---【OUT】：设备号
'       strFtpIp---【OUT】：ftp地址
'       strFtpUrl---【OUT】：ftp目录
'       strVirtualPath---【OUT】：ftp虚拟存储路径
'       strFtpUser---【OUT】： ftp用户名
'       strFtpPwd---【OUT】：ftp密码
'------------------------------------------------------------------------------------------
    Dim strSQL As String
    Dim rsData As ADODB.Recordset
    Dim rsTemp As ADODB.Recordset
    Dim blnIsGetNewDevice As Boolean
    Dim objDestFtp As New clsFtp
    Dim curDate As Date
    Dim strDate As String
    
    strFtpIp = ""
    strFtpURL = ""
    strFTPUser = ""
    strFTPPwd = ""
    strDeviceNo = ""
    
    strSQL = "Select D.FTP用户名 As FtpUser,D.FTP密码 As FtpPwd,C.位置一,C.位置二,C.位置三,C.接收日期," & _
        "D.IP地址 As Host," & _
        "'/'||D.Ftp目录||'/' As Root,Decode(C.接收日期,Null,'',to_Char(C.接收日期,'YYYYMMDD')||'/')" & _
        "||C.检查UID As URL " & _
        "From 影像检查记录 C,影像设备目录 D " & _
        "Where Decode(C.位置一,Null,C.位置二,C.位置一)=D.设备号(+)" & _
        "And C.检查UID= [1] Union All " & _
        "Select D.FTP用户名 As FtpUser,D.FTP密码 As FtpPwd,C.位置一,C.位置二,C.位置三,C.接收日期," & _
        "D.IP地址 As Host," & _
        "'/'||D.Ftp目录||'/' As Root,Decode(C.接收日期,Null,'',to_Char(C.接收日期,'YYYYMMDD')||'/')" & _
        "||C.检查UID As URL " & _
        "From 影像临时记录 C,影像设备目录 D " & _
        "Where Decode(C.位置一,Null,C.位置二,C.位置一)=D.设备号(+)" & _
        "And C.检查UID= [1]"
        
    If blnMoved Then
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
    End If
        
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, gstrSysName, strNewStudyUID)
    
    blnIsGetNewDevice = False
    
    If rsData.RecordCount <= 0 Then
        blnIsGetNewDevice = True
    Else
        '如果执行到这里，说明是执行图像关联,需要判断当前检查的存储设备是否有效，如果无效需生成新的存储设备
        If Trim(rsData!接收日期) = "" Or (lngModule = G_LNG_PACSSTATION_MODULE And NVL(rsData!位置一) = "") Then
            blnIsGetNewDevice = True
            strDate = NVL(rsData!接收日期)
        Else
            strDeviceNo = NVL(rsData!位置一)
            strFtpIp = NVL(rsData!Host)
            strFtpURL = NVL(rsData!Root)
            strFTPUser = NVL(rsData!FtpUser)
            strFTPPwd = NVL(rsData!FtpPwd)
            strVirtualPath = strFtpURL & NVL(rsData!Url)
        End If
    End If
    
    
    If blnIsGetNewDevice Then
        '生成新的检查UID和存储设备,如果执行到这里，说明是取消关联
        
        If lngModule = 1290 Then
            '查询医技工作站中，检查所对应的存储设备
            strSQL = "select d.参数值 " & _
                        " from 医技执行房间 a, 病人医嘱发送 b, 影像DICOM服务对 c, 影像DICOM服务参数 d " & _
                        " Where a.科室ID = b.执行部门id And a.执行间 = b.执行间 And a.检查设备 = c.设备号 " & _
                        " and c.服务功能='图像接收' and c.服务ID=d.服务ID and d.参数名称='存储设备' and b.医嘱id=[1]"
                        
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, gstrSysName, lngAdviceId)
            
            If rsTemp.RecordCount <= 0 Then
                MsgBoxD frmParent, "未找到图像存储设备,请确认当前检查所用设备是否在影像设备目录的服务配置中配置了图像存储。", vbInformation, gstrSysName
                Exit Sub
            End If
            
            strDeviceNo = NVL(rsTemp!参数值)
        Else
            '查询非医技工作站中的图像存储设备
            strDeviceNo = GetDeptPara(lngCurDeptId, "存储设备号")
            
            If Val(strDeviceNo) <= 0 Then
                MsgBoxD frmParent, "未找到图像存储设备,请确认在影像流程管理中是否对该科室配置了图像采集存储设备。", vbInformation, gstrSysName
                Exit Sub
            End If
        End If
        
        
        strSQL = "Select 设备号,设备名,'/'||Decode(Ftp目录,Null,'',Ftp目录||'/') As URL,FTP用户名,FTP密码,IP地址 " & _
                    " From 影像设备目录 Where 类型=1 and 设备号=[1] and NVL(状态,0)=1"
                    
        Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, gstrSysName, strDeviceNo)
        
        '如果存储设备停用，则直接退出
        If rsTemp.RecordCount <= 0 Then
            MsgBoxD frmParent, "未找到存储设备,请确认设备号为 [" & strDeviceNo & "] 的设备是否启用。", vbInformation, gstrSysName
            Exit Sub
        End If

        strFtpURL = NVL(rsTemp("URL"))
        strFtpIp = NVL(rsTemp("IP地址"))
        strFTPUser = NVL(rsTemp("FTP用户名"))
        strFTPPwd = NVL(rsTemp("FTP密码"))
        
        strFtpURL = IIf(strFtpURL = "/", "//", strFtpURL)
        
        On Error GoTo errhandle
        
        objDestFtp.FuncFtpConnect strFtpIp, strFTPUser, strFTPPwd
        
        If lngModule = G_LNG_PACSSTATION_MODULE Then
            strDate = Format(strDate, "YYYYMMDD")
        Else
            curDate = zlDatabase.Currentdate
            strDate = Format(curDate, "YYYYMMDD")
        End If
        
        strVirtualPath = strFtpURL & strDate & "/" & strNewStudyUID
        '创建FTP目录
        objDestFtp.FuncFtpMkDir strFtpURL, strDate & "/" & strNewStudyUID
            
        Call objDestFtp.FuncFtpDisConnect
    End If
    
    Exit Sub
    
errhandle:
        Call objDestFtp.FuncFtpDisConnect
End Sub



Private Function OraDataOpen(ByVal strServerName As String, ByVal strUserName As String, ByVal strUserPwd As String) As Boolean
    '------------------------------------------------
    '功能： 打开指定的数据库
    '参数：
    '   strServerName：主机字符串
    '   strUserName：用户名
    '   strUserPwd：密码
    '返回： 数据库打开成功，返回true；失败，返回false
    '------------------------------------------------
    Dim strSQL As String
    Dim strError As String
    
    On Error Resume Next
    err = 0
    DoEvents
    With gcnOracle
        If .State = adStateOpen Then .Close
        .Provider = "MSDataShape"
        .Open "Driver={Microsoft ODBC for Oracle};Server=" & strServerName, strUserName, strUserPwd
        If err <> 0 Then
            '保存错误信息
            strError = err.Description
            If InStr(strError, "自动化错误") > 0 Then
                MsgBox "连接串无法创建，请检查数据访问部件是否正常安装。", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-12154") > 0 Then
                MsgBox "无法分析服务器名，" & vbCrLf & "请检查在Oracle配置中是否存在该本地网络服务名（主机字符串）。", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-12541") > 0 Then
                MsgBox "无法连接，请检查服务器上的Oracle监听器服务是否启动。", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-01033") > 0 Then
                MsgBox "ORACLE正在初始化或在关闭，请稍候再试。", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-01034") > 0 Then
                MsgBox "ORACLE不可用，请检查服务或数据库实例是否启动。", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-02391") > 0 Then
                MsgBox "用户" & UCase(strUserName) & "已经登录，不允许重复登录(已达到系统所允许的最大登录数)。", vbExclamation, gstrSysName
            ElseIf InStr(strError, "ORA-01017") > 0 Then
                MsgBox "由于用户、口令或服务器指定错误，无法登录。", vbInformation, gstrSysName
            ElseIf InStr(strError, "ORA-28000") > 0 Then
                MsgBox "由于用户已经被禁用，无法登录。", vbInformation, gstrSysName
            Else
                MsgBox strError, vbInformation, gstrSysName
            End If
            
            OraDataOpen = False
            Exit Function
        End If
    End With
    
    err = 0
    On Error GoTo errHand
    
    gstrDBUser = UCase(strUserName)
    SetDbUser gstrDBUser
    
    OraDataOpen = True
    Exit Function
    
errHand:
    If ErrCenter() = 1 Then Resume
    OraDataOpen = False
    err = 0
End Function


Public Sub WriteCommLog(logSubName As String, logTitle As String, logDesc As String)
'------------------------------------------------
'功能：记录通讯日志
'参数： logSubName  --  产生日志的函数名
'       logTitle   -- 日志名称
'       logDesc   --  日志内容
'返回：无
'------------------------------------------------
    Dim strLog As String
    
    strLog = Now() & " 标题： " & logTitle & vbCrLf & "      函数： " & logSubName & vbCrLf & "     日志内容：" & logDesc & vbCrLf

    LogWrite "PACS主要功能调试日志", glngModul, logTitle, strLog

End Sub

'函数:WritTextFile
'参数:FileName 目标文件名.WritStr 写到目标的字符串.
'返回值:成功 T.失败  F
Public Function WritTextFile(ByVal strFileName As String, ByVal strWritStr As String) As Boolean
    Dim FileID As Long, ConTents As String
    Dim a As Long, b As Long
    Dim objFSO As New Scripting.FileSystemObject
    
    On Error Resume Next
    
    If objFSO.FileExists(strFileName) Then objFSO.DeleteFile (strFileName)
    
    FileID = FreeFile
    Open strFileName For Append As #FileID
         Print #FileID, strWritStr
    Close #FileID
    
    WritTextFile = (err.Number = 0)
    err.Clear
End Function


Public Function CheckPopedom(ByVal strPrivs As String, ByVal strPopedom As String) As Boolean
'检查权限
    Dim strCurPrivs As String
    
    strCurPrivs = ";" & strPrivs & ";"
    
    CheckPopedom = InStr(1, UCase(strCurPrivs), UCase(";" & strPopedom & ";")) > 0
    
    If CheckPopedom = False Then
        '调试模式下具备所有权限
'        CheckPopedom = IIf(App.LogMode = 0, True, CheckPopedom) 'App.LogMode = 0表示源码环境
    End If
End Function


Public Function InitRegister() As Boolean
    If gobjRegister Is Nothing Then
        On Error Resume Next
        Set gobjRegister = CreateObject("zlRegister.clsRegister")
        err.Clear
        
        If gobjRegister Is Nothing Then
            MsgBox "创建zlRegister部件对象失败,请检查文件是否存在并且正确注册。", vbExclamation, gstrSysName
            Exit Function
        End If
    End If
    
    SaveSetting "ZLSOFT", "公共全局", "授权控制程序", "ZL9PACSWORK"
    
    gstrUserName = gobjRegister.GetUserName
    
    '如果是源代码启动，则直接设置密码为HIS
    If App.LogMode = 0 Then
        gstrUserPswd = "HIS"
    Else
        gstrUserPswd = gobjRegister.GetPassword(App.hInstance)
    End If
    
    gstrServerName = gobjRegister.GetServerName
    
    InitRegister = True
End Function

Public Function GetNewLabel(lType As Integer, lLeft As Integer, lTop As Integer, lWidth As Integer, lHeight As Integer) As DicomLabel
'------------------------------------------------
'功能：生成一个LABEL对象，并对其做初始化。
'参数：lType--标注的类型；lLeft--标注的Left值；lTop--标注的Top值；lWidth--标注的Width值；lHeight--标注的Height值。
'返回：新生成的标注。
'------------------------------------------------
    Dim l As New DicomLabel
    l.LabelType = lType
    l.ImageTied = True
    l.Left = lLeft
    l.Top = lTop
    l.Width = lWidth
    l.Height = lHeight
    l.Margin = 0
    l.AutoSize = True
    l.FontSize = 10
    l.LineWidth = 1
    'l.ForeColour = vbBlack
    l.XOR = True
    
    Set GetNewLabel = l
End Function

Public Sub subLabelCopyRebuild(Simg As DicomImage, oImg As DicomImage)
'------------------------------------------------
'功能：重建图像的标注关联关系
'参数：sImg--源图像；oImg--目标图像
'返回：无
'------------------------------------------------
    Dim l As DicomLabel
    For Each l In oImg.Labels
        If Not l.TagObject Is Nothing Then
            If Simg.Labels.IndexOf(l.TagObject) <> 0 Then
                Set l.TagObject = oImg.Labels(Simg.Labels.IndexOf(l.TagObject))
            End If
        End If
    Next
End Sub

Public Function NewOut收费(ByVal lng医嘱ID As Long) As Long
'功能：判断新门诊病人是否收费，调用新门诊系统的服务
'返回：0-走以前逻辑，1-提示并禁止，2-成功验证通过
    Dim strJsIn As String
    Dim strJsOut As String
    Dim strErr As String
    Dim int已收费 As Integer
    Dim blnTmp As Boolean
    
    NewOut收费 = 0 '默认为0-以前逻辑
    
    strJsIn = "{""input"":{""head"":{""bizno"":""RJ001"",""sysno"":""ZLDAYROOM"",""time"":"""",""action_no"":"""",""tarno"":""03""},""apply_id"":" & lng医嘱ID & "}}"
    blnTmp = Sys.NewSystemSvr("新门诊系统", "判断医嘱是否收费", strJsIn, strJsOut, strErr)

    If strErr <> "" Then
        MsgBox strErr, vbInformation, gstrSysName
        NewOut收费 = 1
        Exit Function
    End If
    
    If blnTmp Then
        If strJsOut <> "" Then
            If Val(zlStr.JSONParse("result", strJsOut) & "") <> 1 Then
                MsgBox zlStr.JSONParse("errmsg", strJsOut) & "", vbInformation, gstrSysName
                NewOut收费 = 1
                Exit Function
            End If
            int已收费 = Val(zlStr.JSONParse("kacnt_sign", strJsOut) & "")
        End If
        If int已收费 <> 1 Then
            MsgBox "该病人还存在未收费的费用，请检查。", vbInformation, gstrSysName
            NewOut收费 = 1
            Exit Function
        Else
            NewOut收费 = 2
        End If
    End If
End Function


Private Sub ConfigCommandConnection(ByRef cmdData As ADODB.Command, Optional ByVal strTitle As String = "")
On Error Resume Next
    Do While True
        Set cmdData.ActiveConnection = gcnOracle '这句比较慢(这句执行1000次约0.5x秒)
        If err.Number <> 0 Then
            If MsgBox("数据服务连接异常，是否重试？" & vbCrLf & _
                        "错误原因：" & err.Description & vbCrLf & _
                        "错误源：" & err.Source, vbYesNo, IIf(Len(strTitle) > 0, strTitle, "警告")) = vbYes Then
                gcnOracle.Close
                gcnOracle.Open
                
                err.Clear
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    Loop
End Sub

Public Function GetParNos(ByRef strContext As String, ByRef aryParNo() As Long) As Boolean
'是否包含参数
'aryParNo,存储对应的参数号
    Dim lngStartIndex As Long
    Dim lngEndEndex As Long
    Dim lngUbound As Long
    Dim lngCurParNo As Long
    
    Dim strTmp As String
    
    GetParNos = False
    ReDim aryParNo(0)
    
    lngStartIndex = InStr(strContext, "[")
    
    If lngStartIndex <= 0 Then Exit Function
    
    lngEndEndex = InStr(lngStartIndex, strContext, "]")
    If lngEndEndex <= 0 Then Exit Function
    
    '返回项目中包含的参数号
    While lngStartIndex > 0 And lngEndEndex > lngStartIndex
        strTmp = Mid$(strContext, lngStartIndex + 1, lngEndEndex - lngStartIndex - 1)
        lngCurParNo = Val(strTmp)
        
        If lngCurParNo > 0 Then
            lngUbound = UBound(aryParNo) + 1
            ReDim Preserve aryParNo(lngUbound)
            
            aryParNo(lngUbound) = lngCurParNo
        End If
        
        lngStartIndex = InStr(lngEndEndex, strContext, "[")
        If lngStartIndex > 0 Then lngEndEndex = InStr(lngStartIndex, strContext, "]")
    Wend
    
    If lngUbound <= 0 Then Exit Function
    
    GetParNos = True
End Function

Public Function ExecuteCore(ByVal strSQL As String, _
    ByVal strTitle As String, arrInput() As Variant, _
    Optional ByVal blnIsStore = False, Optional ByVal blnStart0 As Boolean = True) As ADODB.Recordset
'功能：通过Command对象打开带参数SQL的记录集
    Dim cmdData As New ADODB.Command
    Dim rsData As New ADODB.Recordset
    Dim arrPar() As Long
    Dim intMax As Integer
    Dim i As Integer
    Dim lngParCount As Long
    Dim varValue As Variant
    
    Dim strprovider As String
    Dim lngtmpIndex As Long
    Dim strTmp As String

    '分析自定的[x]参数
    Call GetParNos(strSQL, arrPar)

    '替换为"?"参数
    lngParCount = UBound(arrPar)
    
    For i = 1 To lngParCount
        strSQL = Replace(strSQL, "[" & arrPar(i) & "]", "?")
        varValue = arrInput(IIf(blnStart0, arrPar(i), arrPar(i) - 1))
        
        Select Case TypeName(varValue)
        Case "Byte", "Integer", "Long", "Single", "Double", "Currency", "Decimal" '数字
            cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adVarNumeric, adParamInput, 30, varValue)
        Case "String" '字符
            intMax = LenB(StrConv(varValue, vbFromUnicode))
            If intMax <= 2000 Then
                intMax = IIf(intMax <= 200, 200, 2000)
                cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adVarChar, adParamInput, intMax, varValue)
            Else
                If intMax < 4000 Then intMax = 4000
                cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adLongVarChar, adParamInput, intMax, varValue)
            End If
        Case "Date" '日期
            cmdData.Parameters.Append cmdData.CreateParameter("PAR" & i, adDBTimeStamp, adParamInput, , varValue)
        End Select
    Next i

    Call ConfigCommandConnection(cmdData, strTitle)
    If cmdData.ActiveConnection Is Nothing Then Exit Function
    
    strprovider = UCase(cmdData.ActiveConnection.Provider)
    strTmp = strSQL
    strTmp = Trim(strTmp)
    strTmp = Mid(strTmp, 1, 15)
    strTmp = UCase(strTmp)
    
    If InStr(strprovider, "MSDATASHAPE") > 0 And InStr(strTmp, "SELECT") > 0 Then
        lngtmpIndex = InStr(strTmp, "SELECT * FROM (")
        
        If lngtmpIndex >= 1 And lngtmpIndex <= 2 Then
            cmdData.CommandText = strSQL
        Else
            cmdData.CommandText = "SELECT * FROM (" + strSQL + ")"
        End If
    Else
        cmdData.CommandText = strSQL
    End If

    If blnIsStore Then
        Call cmdData.Execute
        
        Set ExecuteCore = Nothing
    Else
        rsData.CursorLocation = adUseClient
        rsData.CursorType = adOpenDynamic
        rsData.LockType = adLockOptimistic
        
        rsData.Open cmdData
        
        Set rsData.ActiveConnection = Nothing
        Set ExecuteCore = rsData
    End If
 
End Function

Public Function GetMovedState(ByVal lngRow As Long, ByRef objList As VSFlexGrid) As Integer
'功能：根据list rowdata信息 获取是否转存的信息
'If vsfList.Cell(flexcpData, lngRow) = Empty Then vsfList.Cell(flexcpData, lngRow) = intValue
' 0 未知  1 未转出   2 已转出
On Error GoTo errH
    GetMovedState = 0
    
    If objList.Cell(flexcpData, lngRow) = Empty Then
        GetMovedState = 0
    Else
        GetMovedState = objList.Cell(flexcpData, lngRow)
    End If
    
    Exit Function
errH:
End Function

Public Function GetExtraWidth(ByVal strName As String) As Integer
'功能：如果strName包含 时间或者如期，返回1200  否则返回0 如果=“姓名” 返回800  用于扩展列头宽度
On Error GoTo errH
    GetExtraWidth = 0
    
    If InStr(strName, "时间") > 0 Or InStr(strName, "日期") Then
        GetExtraWidth = 1200
    End If
    
    If strName = "姓名" Then
        GetExtraWidth = 800
    End If
    
    Exit Function
errH:
End Function

Public Sub IsSchedule(ByVal lngCur科室ID As Long, ByVal lngOrderID As Long, ByVal lngClinicId As Long, _
    ByRef blnIsScheduleDept As Boolean, ByRef blnIsScheduleOrder As Boolean)
'------------------------------------------------
'功能：判断是否使用预约功能
'参数： lngCur科室ID -- 当前科室ID
'       lngOrderID -- 医嘱ID
'       lngClinicID -- 诊疗项目ID，如果不为0，则使用诊疗项目ID而不是用医嘱ID查询
'       blnIsScheduleDept -- 【返回参数】，科室是否启用预约
'       blnIsScheduleOrder -- 【返回参数】，检查项目是否启用预约
'返回：无
'------------------------------------------------
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    Dim rsSch As ADODB.Recordset
    
    On Error GoTo err
    
    blnIsScheduleDept = False
    blnIsScheduleOrder = False
        
    '如果没有预约权限，则直接退出...
    If gblnIsSchedule = True Then
        '全院启用预约
        blnIsScheduleDept = True
        blnIsScheduleOrder = True
    ElseIf gblnIsScheduleByDept = True Then
        '按科室启用预约
        Set rsSch = GetScheduleEnables
        If rsSch.RecordCount = 0 Then
            '查询不到具体记录，表示没有设置预约科室，不需要预约
            Exit Sub
        End If
        
        rsSch.Filter = "检查科室id = " & lngCur科室ID
        If rsSch.RecordCount = 0 Then
            '这个检查科室不用预约，医嘱全都不预约
            Exit Sub
        Else
            '当前科室启用预约，再查询当前设备是否启用预约
            blnIsScheduleDept = True
            blnIsScheduleOrder = True
        End If
    End If
    
    If blnIsScheduleOrder = True Then
        If lngClinicId = 0 Then
            strSQL = "select count(a.id) count from 影像预约项目 a, 病人医嘱记录 b,影像预约设备 c " _
                    & " where a.诊疗项目id = b.诊疗项目id and a.预约设备id = c.id and c.是否启用=1 " _
                    & " and c.科室id =[2]  and b.id=[1]"
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "是否启用检查预约", lngOrderID, lngCur科室ID)
        Else
            strSQL = "Select Count(a.id) Count From 影像预约项目 A,  影像预约设备 b " _
                    & " Where a.诊疗项目id = [1] And a.预约设备id = b.ID And b.是否启用 = 1 " _
                    & " and b.科室id = [2]"
            Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "是否启用检查预约", lngClinicId, lngCur科室ID)
        End If
        If rsTemp!Count <> 0 Then
            blnIsScheduleOrder = True
        Else
            blnIsScheduleOrder = False
        End If
    End If
    
    Exit Sub
err:
    If ErrCenter() = 1 Then Resume
    Call SaveErrLog
End Sub

Private Function GetScheduleEnables() As ADODB.Recordset
'-----------------------------------------------------------
'功能:获取系统的预约分科室启用设置
'入参:  无
'返回:预约启用设置数据集
'-----------------------------------------------------------
    Dim strSQL As String
    
    On Error GoTo err
    
    If grsScheduleEnables Is Nothing Then
        strSQL = "select A.ID,A.检查科室ID,A.场合,A.预约科室ID,A.是否必须预约 from 影像预约启用控制 A"
        Set grsScheduleEnables = zlDatabase.OpenSQLRecord(strSQL, "获取预约启用参数")
    End If
    
    grsScheduleEnables.Filter = ""
    Set GetScheduleEnables = grsScheduleEnables
    
    Exit Function
err:
    If ErrCenter() = 1 Then
        Resume
    End If
    Call SaveErrLog
End Function

Private Function IsBabyByDate(ByVal strBirthDate As Date) As Boolean
'根据出生日期判断年龄是否小于一岁
On Error GoTo errH
    IsBabyByDate = False
    If IsDate(strBirthDate) Then
        If DateAdd("d", -365, zlDatabase.Currentdate) < strBirthDate Then
            IsBabyByDate = True
        End If
    End If
    Exit Function
errH:
    IsBabyByDate = False
End Function

Private Function IsBabyByAge(ByVal strAge As String) As Boolean
'根据年龄判断年龄是否小于一岁
On Error GoTo errH
    If strAge <> "" Then
        Dim lngDays As Long
    
        If strAge Like "*岁*月" Or strAge Like "*岁*个月" Then
            lngDays = 365 * Val(strAge) + 30 * Val(Mid(strAge, InStr(1, strAge, "岁") + 1))
        ElseIf strAge Like "*月*天" Or strAge Like "*个月*天" Then
            lngDays = 30 * Val(strAge) + Val(Mid(strAge, InStr(1, strAge, "月") + 1))
        ElseIf strAge Like "*岁" Or IsNumeric(strAge) Then
            lngDays = 365 * Val(strAge)
        ElseIf strAge Like "*月" Or strAge Like "*个月" Then
            lngDays = 30 * Val(strAge)
        ElseIf strAge Like "*天" Then
            lngDays = Val(strAge)
        End If
    
        IsBabyByAge = lngDays < 365
    Else
        IsBabyByAge = False
    End If
    Exit Function
errH:
    IsBabyByAge = False
End Function


Public Function zlGetStudyAdvice(ByVal lngAdviceId As Long) As clsStudyInfo
''根据医嘱ID获取基本信息，保存在检查列表Cell flexcpData中，如果已经有内容，则不需要进行查询
'同时需要重新刷新列表中该行
'intmovedState 相应lngAdviceID 转存状态  0：未知    1：未转出   2：已经转出
On Error GoTo errH
    Dim strSQL As String, strSqlTmp As String
    Dim rsTemp As ADODB.Recordset
    Dim strSqlMore As String
    Dim rsTempMore As ADODB.Recordset  'rsTemp 下获得的Recordset
    Dim rsTempAge As ADODB.Recordset
    Dim objStudyInfo As New clsStudyInfo
    Dim strTmp As String
    Dim dtStart As Date
    Dim dtEnd As Date
    Dim blSubMoved As Boolean  '是否转出，决定“获取基本检查信息”后面的查询是否查询历史表
    Dim dtAgePar As Date
    Dim dtPatientBirthDay As Date
    Dim strSqlPathol As String
    Dim rsPathol As ADODB.Recordset
    
    Set zlGetStudyAdvice = Nothing
    
    '未知是否转存，首先判断非历史表
    strSqlTmp = "select 1 from 病人医嘱记录 where Id=[1]"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSqlTmp, "获取基本检查信息", lngAdviceId)
    
    blSubMoved = IIf(rsTemp.RecordCount <= 0, True, False)
    
     
    strSQL = "Select A.姓名, A.病人id, A.主页id,A.性别,A.年龄,A.病人来源,A.病人科室id,A.挂号单,Nvl(A.婴儿, 0) 婴儿,A.紧急标志,A.医嘱内容,A.执行科室ID, " & vbNewLine & _
            " B.检查uid,NVL(F.病理号,B.检查号) as 检查号,B.检查技师,B.关联ID,B.图像位置,B.报告人,B.复核人,B.报告操作,B.绿色通道,B.影像类别,B.发放胶片,B.报告发放,B.报告质量,B.影像质量,B.随访描述,B.符合情况,B.危急状态, " & vbNewLine & _
            " D.首次时间,D.发送号,D.NO,D.记录性质,D.执行状态,D.执行过程,D.执行间,D.结果阳性,E.住院号,E.门诊号,E.身份证号,E.出生日期,E.当前病区ID,0 as 转出 " & vbNewLine & _
            " From 病人医嘱记录 A, 影像检查记录 B, 病人医嘱发送 D,病人信息 E, 病理检查信息 F " & vbNewLine & _
            " Where A.ID = B.医嘱id(+)  And A.ID = D.医嘱id and A.病人ID=E.病人ID  and A.Id=F.医嘱ID(+) and A.ID = [1]"
 
 
'    strSqlPathol = "select 病理号 from 病理检查信息 where 医嘱ID=[1]"
    
    If blSubMoved Then
        strSQL = Replace(strSQL, "病人医嘱记录", "H病人医嘱记录")
        strSQL = Replace(strSQL, "病人医嘱发送", "H病人医嘱发送")
        strSQL = Replace(strSQL, "影像检查记录", "H影像检查记录")
        strSQL = Replace(strSQL, "病理检查信息", "H病理检查信息")
        
'        strSqlPathol = Replace(strSqlPathol, "病理检查信息", "H病理检查信息")
        
        strSQL = Replace(strSQL, "0 as 转出", "1 as 转出")
    End If
    
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, "获取基本检查信息", lngAdviceId)
'    Set rsPathol = zlDatabase.OpenSQLRecord(strSqlPathol, "获取基本检查信息", lngAdviceId)
    
    If Not rsTemp.EOF Then
        With objStudyInfo
            .lngAdviceId = lngAdviceId
            .lngPatId = Val(NVL(rsTemp!病人ID))
            .strPatientName = rsTemp!姓名
            .strPatientSex = NVL(rsTemp!性别)
            .strPatientAge = NVL(rsTemp!年龄)
            .lngPatientFrom = Val(NVL(rsTemp!病人来源, 3))
            
'            If rsPathol.RecordCount > 0 Then
'                .strStudyNum = nvl(rsPathol!病理号)
'            Else
                .strStudyNum = NVL(rsTemp!检查号)
'            End If
            
            .lngBaby = Val(NVL(rsTemp!婴儿))
            .lngPageID = Val(NVL(rsTemp!主页ID))
            .lngUnit = Val(NVL(rsTemp!当前病区ID))
            
            If .lngBaby <> 0 Then
                strSQL = "Select A.开嘱时间,Nvl(B.婴儿姓名, A.姓名 || '之子' || Trim(To_Char(B.序号, '9'))) As 婴儿姓名, B.婴儿性别, B.出生时间, B.死亡时间" & vbNewLine & _
                             "  From 病人医嘱记录 A, 病人新生儿记录 B " & vbNewLine & _
                             "  Where a.病人ID = b.病人ID And b.主页id = [2] And b.序号 = [3] And a.ID = [1]"
                        
                If blSubMoved Then
                    strSQL = Replace(strSQL, "病人医嘱记录", "H病人医嘱记录")
                    strSQL = Replace(strSQL, "病人新生儿记录", "H病人新生儿记录")
                End If
                
                Set rsTempMore = zlDatabase.OpenSQLRecord(strSQL, "提取婴儿信息", lngAdviceId, .lngPageID, .lngBaby)
                
                If Not rsTempMore.EOF Then
                    .strPatientName = rsTempMore!婴儿姓名
                    .strPatientSex = NVL(rsTempMore!婴儿性别)
                    
                    strSqlMore = "Select Zl_Age_Calc(0,[1],[2]) Age From Dual"
                    
                    If NVL(rsTempMore!死亡时间) <> "" Then
                        dtAgePar = NVL(rsTempMore!死亡时间)
                    Else
                        dtAgePar = NVL(rsTempMore!开嘱时间)
                    End If
                    
                    Set rsTempAge = zlDatabase.OpenSQLRecord(strSqlMore, "计算年龄", NVL(rsTempMore!出生时间), dtAgePar)
                    If rsTempAge.RecordCount > 0 Then
                        .strPatientAge = NVL(rsTempAge!Age)
                        
                        .blnInfancy = IsBabyByAge(.strPatientAge)
                    Else
                        .strPatientAge = NVL(rsTempMore!出生时间)
                        
                        .blnInfancy = IsBabyByDate(.strPatientAge)
                    End If
                End If
            Else
'                有独立身份需要根据出生日期判断是否婴儿
'                若没有出生日期，则根据年龄判断是否婴儿
'                若病人信息没有年龄，则判断为不是婴儿
                dtPatientBirthDay = NVL(rsTemp!出生日期, Empty)
                If dtPatientBirthDay = Empty Then
                    .blnInfancy = IsBabyByAge(.strPatientAge)
                Else
                    .blnInfancy = IsBabyByDate(dtPatientBirthDay)
                End If
            End If
            
            .lngLinkId = Val(NVL(rsTemp!关联ID))
            .intState = Val(rsTemp!执行状态)
            
            .blnIsTechincalSure = IIf(NVL(rsTemp!检查技师) <> "", True, False)
            .strDoDoctor = NVL(rsTemp!检查技师)
            .blnIsReported = (InStr("已报告,已审核,已完成,报告中,审核中", .strStuStateDesc) > 0)
            .lngPatDept = Val(NVL(rsTemp!病人科室ID))
            
            .strRegNo = NVL(rsTemp!挂号单)
            .blnIsInsidePatient = (.lngPatientFrom = 1) Or (.lngPatientFrom = 2)
            .strStudyUID = NVL(rsTemp!检查UID)
            .intImageLocation = Val(NVL(rsTemp!图像位置))
            .strImgType = NVL(rsTemp!影像类别)
            .strReportDoctor = NVL(rsTemp!报告人)
            .strReportOperation = NVL(rsTemp!报告操作)
            .intEmergentTag = Val(NVL(rsTemp!紧急标志))
            .intGreenChannel = Val(NVL(rsTemp!绿色通道))
            .intFilmGiveOut = Val(NVL(rsTemp!发放胶片))
            .intReportGiveOut = Val(NVL(rsTemp!报告发放))
            .strFollowUpDescribe = NVL(rsTemp!随访描述)
            .strImageQuality = NVL(rsTemp!影像质量)
            .strReportQuality = NVL(rsTemp!报告质量)
            .strAccord = NVL(rsTemp!符合情况)
            .intDangerState = Val(NVL(rsTemp!危急状态))
            .lngExeDepartmentId = Val(NVL(rsTemp!执行科室ID))
            .dtFirstTime = NVL(rsTemp!首次时间)
             
            .blnCanPrint = GetDeptPara(.lngExeDepartmentId, "平诊需审核才能打报告") = "1"
            .blnCanPrint = IIf(.blnCanPrint, IIf(.intEmergentTag, NVL(rsTemp!报告人) <> "", NVL(rsTemp!复核人) <> ""), True)
            
            .lngSendNo = Val(NVL(rsTemp!发送号))
            .blnMoved = NVL(rsTemp!转出, False)
            .intStep = Val(NVL(rsTemp!执行过程))
            .strExeRoom = NVL(rsTemp!执行间)
            .strNO = NVL(rsTemp!no)
            .lngRecordKind = Val(NVL(rsTemp!记录性质))
            .intPositive = Val(NVL(rsTemp!结果阳性))
            
            .strMarkNum = IIf(.lngPatientFrom = 1, Val(NVL(rsTemp!门诊号, -1)), IIf(.lngPatientFrom = 2, Val(NVL(rsTemp!住院号, -1)), 0))
            .strIIDNumber = NVL(rsTemp!身份证号)
            
            If UBound(Split(NVL(rsTemp!医嘱内容), ":")) > 0 Then
                .strAdviceContext = Split(NVL(rsTemp!医嘱内容), ":")(0)
                .strAdviceDepartAndMethod = Split(NVL(rsTemp!医嘱内容), ":")(1)
            Else
                .strAdviceContext = NVL(rsTemp!医嘱内容)
                .strAdviceDepartAndMethod = ""
            End If
            
            .dtRefreshDate = Now
            .strCollectionInfo = ""
            .lngMoneyState = -1
            .intPathoType = 0
            .strStuStateDesc = ""
        End With

         Set zlGetStudyAdvice = objStudyInfo
    End If

    Exit Function
errH:
    Set zlGetStudyAdvice = Nothing
End Function

Public Function RefeshSchRestDay(lngOrderID As Long, lngSchDeviceID As Long, dtDate As Date) As String
'------------------------------------------------
'功能：循环当前月历，获取所有不能预约的日子，都算是休息日
'参数：
'       lngOrderID -- 医嘱ID
'       lngSchDeviceID -- 预约设备ID
'       dtDate -- 当月的最后一天
'返回：RefeshRestDay -- 当月休息日串，用逗号连接
'------------------------------------------------
    Dim strSQL As String
    Dim rsTemp As Recordset
    Dim i As Integer
    Dim intDays As Integer
    Dim strSchRestDate As String
    
    On Error GoTo errH
    
    intDays = Val(Format(dtDate, "dd"))
    dtDate = Format(dtDate, "YYYY-MM") & "-01"
    
    For i = 1 To intDays
        
        If DateCanSch(lngOrderID, dtDate, lngSchDeviceID) = False Then
            strSchRestDate = strSchRestDate & "," & dtDate
        End If
        
        dtDate = dtDate + 1
    Next i
    
    If strSchRestDate <> "" Then
        strSchRestDate = Mid(strSchRestDate, 2)
    End If
    
    RefeshSchRestDay = strSchRestDate
    
    Exit Function
errH:
    If ErrCenter() = 1 Then
        Resume
    End If
    Call SaveErrLog
End Function

Private Function DateCanSch(lngOrderID As Long, dtDate As Date, Optional lngDeviceID As Long = 0) As Boolean
'-----------------------------------------------------------
'功能:判断指定日期是否可以预约
'入参:  lngOrderID -- 医嘱ID
'       dtDate -- 日期
'       lngSchDeviceID -- 预约设备ID，如果不指定设备，传0
'返回: True -- 可预约；False -- 不可预约
'-----------------------------------------------------------
    Dim strOutXML As String
    Dim objXML As Object  'zl9ComLib.clsXML
    Dim strSchDate As String
    
    On Error GoTo err
    
    DateCanSch = False
    
    '如果小于今天，直接返回False不可预约
    If Format(Now, "YYYY-MM-DD") > Format(dtDate, "YYYY-MM-DD") Then
        Exit Function
    End If
    
    If GetSchDate(lngOrderID, dtDate, strOutXML, lngDeviceID) = True Then
        Set objXML = CreateObject("zl9ComLib.clsXML")
        Call objXML.OpenXMLDocument(strOutXML)
        Call objXML.GetSingleNodeValue("SCHBEGINTIME", strSchDate)
        
        If Format(strSchDate, "YYYY-MM-DD") = Format(dtDate, "YYYY-MM-DD") Then
            DateCanSch = True
        End If
    End If
    
    Exit Function
err:
    If ErrCenter() = 1 Then
        Resume
    End If
End Function

Private Function GetSchDate(ByVal lngOrderID As Long, ByVal dtDate As Date, _
    ByRef strOutXML As String, Optional lngShcDeviceID As Long = 0) As Boolean
'-----------------------------------------------------------
'功能:根据输入日期，确定最近的预约日期
'入参:  lngOrderID -- 医嘱ID
'       dtDate --需要切换的日期
'       strOutXML -- 【出参】查询返回值
'       lngShcDeviceID -- 预约设备ID，如果不指定预约设备，传0
'返回: True -- 成功；False -- 失败
'-----------------------------------------------------------
    Dim strInXML As String
    Dim strSQL As String
    Dim rsTemp As ADODB.Recordset
    
    On Error GoTo err
    
    '查询最近的可预约设备和时间
    If lngShcDeviceID = 0 Then
        strInXML = "<IN><ADVICEID>" & lngOrderID & "</ADVICEID>" & _
            "<BEGINTIME>" & dtDate & "</BEGINTIME></IN>"
    Else
        strInXML = "<IN><ADVICEID>" & lngOrderID & "</ADVICEID>" & _
            "<BEGINTIME>" & dtDate & "</BEGINTIME><MACHINEID>" & _
            lngShcDeviceID & "</MACHINEID></IN>"
    End If
        
'    strOutXML = zlDatabase.CallProcedure("zl_影像预约_GetScheduleTimes", "提取预约时间段", strInXML, Empty)
    strOutXML = "2"
    Call zlDatabase.ExecuteProcedureEx("zl_影像预约_GetScheduleTimes('" & strInXML & "','')", "提取预约时间段", strOutXML)
    
    If strOutXML = "" Then
        GetSchDate = False
        Exit Function
    End If
    
    GetSchDate = True
    Exit Function
err:
    If ErrCenter() = 1 Then
        Resume
    End If
    Call SaveErrLog
End Function

Public Function CreateReportPDF(ByVal objParent As Object, ByVal cnOracle As ADODB.Connection, ByVal lngDocID As Long) As Boolean
'******************************************************************************************************************
'功能：
'参数：
'返回：
'说明：
'******************************************************************************************************************
Dim strOutputFile As String
Dim objRichEpr As Object
Dim objDockAduits As Object
Dim objPDF As clsPDF

'------------------------------------------------------------------------------------------------------------------
           
    If objRichEpr Is Nothing Then
        Set objRichEpr = CreateObject("zlRichEPR.cRichEPR")
        Call objRichEpr.InitRichEPR(cnOracle, objParent, 100, False)
    End If
    If objDockAduits Is Nothing Then Set objDockAduits = CreateObject("zlRichEPR.clsDockAduits")
    
    Set objPDF = New clsPDF
    
    Call objDockAduits.zlPrintDocument(4, 2, lngDocID, "Foxit Reader PDF Printer")

    Set objDockAduits = Nothing
    Set objRichEpr = Nothing
    Set objPDF = Nothing
            
End Function

Public Function FtpUploadPDF(ByVal strLocPath As String, ByVal strFTPFileName As String, ByVal lngDocID As Long, ByVal strPDFFTPdevice As String, ByRef objForm As Object) As Boolean
'strFileName：FTP上传文件名称
'报表方式本地文件:
'EPR方式本地文件:

'处理方式：
'1 判断本地PDF文件是否存在
'2 判断FTP是否正确上传
On Error GoTo errH
    Dim objFile As New Scripting.FileSystemObject

    Dim strFTPDirUrl As String, strFtpIp As String, strFTPUser As String, strFTPPwd As String
    Dim lngResult As Long
    Dim objFtp As New clsFtp
    Dim strVp As String
    Dim intTMP As Integer
    
    intTMP = 1
    If strLocPath = "" Then
        Call SetPDFState(lngDocID, emPDFState.输出失败)
        Exit Function
    End If
    
    If Dir(strLocPath) = "" Then
        Call SetPDFState(lngDocID, emPDFState.输出失败)
        Exit Function
    End If
    
    If strPDFFTPdevice = M_STR_PDF_NOPRINTER Then
        Call SetPDFState(lngDocID, emPDFState.输出失败)
        Exit Function
    End If
    
    Set objFtp = New clsFtp
'    Call GetFtpDeviceWithDeviceNo(objForm, strPDFFTPdevice, strFTPDirUrl, strFtpIp, strFTPUser, strFTPPwd)
    Call GetFtpDeviceWithDeviceNo(Nothing, strPDFFTPdevice, strFTPDirUrl, strFtpIp, strFTPUser, strFTPPwd)
    Call objFtp.FuncFtpConnect(strFtpIp, strFTPUser, strFTPPwd)
    
    strVp = objFile.GetParentFolderName(Replace(strFTPDirUrl & "/" & strFTPFileName, "//", "/"))
    
    lngResult = objFtp.FuncUploadFile(strVp, strLocPath, strFTPFileName)
    If lngResult <> 0 Then
    
        If MsgBoxD(objForm, "PDF报告上传到FTP失败，请联系技术人员处理。" & vbNewLine & "失败的病历ID:" & Mid(strFTPFileName, 1, InStr(strFTPFileName, ".") - 1) & vbNewLine & "是否尝试重新上传？", vbYesNo, gstrSysName) = vbYes Then
            Call objFtp.FuncFtpDisConnect
            Call FtpUploadPDF(strLocPath, strFTPFileName, lngDocID, strPDFFTPdevice, objForm)
        Else
            FtpUploadPDF = False
            Call SetPDFState(lngDocID, emPDFState.上传失败)
        End If
    Else
        intTMP = 2
        Call objFile.DeleteFile(strLocPath, True)
        FtpUploadPDF = True
        Call SetPDFState(lngDocID, emPDFState.成功)
    End If
    
    Call objFtp.FuncFtpDisConnect
    Exit Function:
errH:
    If intTMP = 1 Then Call SetPDFState(lngDocID, emPDFState.上传失败)
    FtpUploadPDF = False
    Call objFtp.FuncFtpDisConnect
    err.Raise err.Number, err.Source, err.Description, err.HelpFile, err.HelpContext
'    Resume
    If 1 = 2 Then
        Resume
    End If
End Function

Public Sub CreateReportPDFAndUpLoad(ByVal lngAdviceId As Long, ByRef objFrom As Object, ByVal strPDFFTPdevice As String)
On Error GoTo errH
    Dim strPath As String
    Dim strFile As String
    Dim lngDocID As Long
    Dim strSQL As String
    Dim rsTemp As Recordset
    Dim objFSO As Scripting.FileSystemObject     'FSO对象
    Dim strDate As String

    
    If objFrom Is Nothing Then Exit Sub
    Set objFSO = New Scripting.FileSystemObject
    
    strSQL = "SELECT a.病历ID,To_Char(B.创建时间, 'yyyyMMdd') as 创建时间 FROM  病人医嘱报告 a,电子病历记录 B WHERE 医嘱ID=[1] And A.病历ID=B.ID"
    Set rsTemp = zlDatabase.OpenSQLRecord(strSQL, objFrom.Caption, lngAdviceId)
    
    If rsTemp.RecordCount = 0 Then Exit Sub
    lngDocID = rsTemp!病历Id
    strDate = rsTemp!创建时间
    
    If strPDFFTPdevice = M_STR_PDF_NOPRINTER Then
        Call SetPDFState(lngDocID, emPDFState.输出失败)
        Exit Sub
    End If
    
    strPath = GetPDFPath(objFrom)
    If strPath = "" Then
        Call SetPDFState(lngDocID, emPDFState.输出失败)
        MsgBoxD objFrom, "PDF转换功能配置存在问题，请在控制面板-设备打印机-打印首选项中设置输出目录，注意输出目录应该是空目录并且不会作为其他用途。" & strPath, vbExclamation, gstrSysName
        Exit Sub
    End If
    Call CreateReportPDF(objFrom, gcnOracle, lngDocID)
    Call gobjRichEPR.InitRichEPR(gcnOracle, gfrmMain, glngSys, False)
    
    
    '先根据系统配置获取foxit PDF 保存位置，确认
    strFile = GetFileName(strPath)
    If strFile = "" Then
        Call SetPDFState(lngDocID, emPDFState.输出失败)
        Exit Sub
    End If
    '统一移动到路径 App.Path & "\TmpImage\PDF\"
    Call objFSO.CopyFile(strFile, App.Path & "\TmpImage\PDF\" & lngDocID & ".PDF", True)
    Call objFSO.DeleteFile(strFile, True)
    
    strFile = App.Path & "\TmpImage\PDF\" & lngDocID & ".PDF"

    Call FtpUploadPDF(strFile, lngDocID & ".PDF", lngDocID, strPDFFTPdevice, objFrom)
    Exit Sub
errH:
     err.Raise err.Number, err.Source, err.Description, err.HelpFile, err.HelpContext
End Sub

Private Function GetPDFPath(ByRef objFrom As Object) As String
'获取foxit打印位置
'GetPDFPath 返回完整路径，如果失败，弹出提示
On Error GoTo errH
    Dim strPath As String
    Dim strTemp As String
    Dim lngRetrun As Long
    Dim objFSO As Scripting.FileSystemObject     'FSO对象

    Dim objText As TextStream
    Dim strValue As String
    Dim strPath2 As String
    Dim blnFind As Boolean

    blnFind = False

    Set objFSO = New Scripting.FileSystemObject
    strTemp = String(200, " ")
    lngRetrun = GetSpecialFolderPath(0, strTemp, CSIDL_APPDATA, False)
    strPath = Left(strTemp, InStr(strTemp, Chr(0)) - 1)
    strPath = strPath & "\Foxit Software\Foxit PDF Creator"

    If objFSO.FolderExists(strPath) = False Then
        MsgBoxD objFrom, "未找到Foxit Reader PDF打印机配置文件,请重新安装foxit 6,请联系技术部门处理。" & strPath, vbExclamation, gstrSysName
        Exit Function
    End If

    strPath2 = strPath & "\FoxitReaderPrinterProfile.xml"
    If objFSO.FileExists(strPath2) = True Then
        blnFind = True
        strPath = strPath & "\FoxitReaderPrinterProfile.xml"
    End If

    If Not blnFind Then
        strPath = strPath & "\FoxitPrinterProfile.xml"
        If objFSO.FileExists(strPath) = False Then
            MsgBoxD objFrom, "未找到Foxit Reader PDF打印机配置文件,请在控制面板-设备打印机-打印首选项中设置输出目录,注意输出目录应该是空目录并且不会作为其他用途。", vbExclamation, gstrSysName
            Exit Function
        End If
    End If

    Set objText = objFSO.OpenTextFile(strPath, ForReading, False, TristateUseDefault)
    While Not objText.AtEndOfLine
        strValue = strValue & objText.ReadLine
    Wend
    objText.Close

    If InStr(strValue, "Overwrite") < 1 Or InStr(strValue, "General Folder=") < 1 Then
        Exit Function
    End If

    strValue = Split(strValue, "Overwrite")(0)
    strValue = Split(strValue, "General Folder=")(1)
    strValue = Replace(strValue, """", "")
    strValue = Trim(strValue)
    GetPDFPath = strValue

    
    Exit Function
errH:
    err.Raise err.Number, err.Source, err.Description, err.HelpFile, err.HelpContext
End Function

Private Function GetFileName(ByVal strPath As String) As String
On Error GoTo errH
    Dim objFSO As Scripting.FileSystemObject     'FSO对象
    Dim strFileName As String
    Dim objFile As File
    Dim strFileTmp As String
    
    Set objFSO = New FileSystemObject
    strFileName = ""
    
    For Each objFile In objFSO.GetFolder(strPath).Files
        strFileName = objFile.Path

        If Len(strFileName) > 4 Then
            strFileTmp = UCase(strFileName)
            strFileTmp = Mid(strFileTmp, Len(strFileTmp) - 3)
            If strFileTmp = ".PDF" Then Exit For
        End If
    
    Next
    GetFileName = strFileName
    Exit Function
errH:
    err.Raise err.Number, err.Source, err.Description, err.HelpFile, err.HelpContext
End Function

Public Sub SetPDFState(ByVal lngID As Long, ByVal intState As Integer)
'Null-未处理，1-成功，-1：输出失败，-2：上传失败
On Error GoTo errH
    Dim strSQL As String
    
    strSQL = "Zl_PACS报告PDF转换状态_Update(" & lngID & "," & intState & ")"
    Call zlDatabase.ExecuteProcedure(strSQL, "PDF转换状态更新")
    Exit Sub
errH:
    If ErrCenter() = 1 Then
        Resume
    End If
    Call SaveErrLog
End Sub



