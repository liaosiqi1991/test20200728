VERSION 5.00
Object = "{BEEECC20-4D5F-4F8B-BFDC-5D9B6FBDE09D}#1.0#0"; "vsflex8.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmDocPrintPatiList 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "选择病人"
   ClientHeight    =   6780
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   8580
   ControlBox      =   0   'False
   DrawWidth       =   4684
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6780
   ScaleWidth      =   8580
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  '所有者中心
   Begin VB.CommandButton cmdAllNoPrint 
      Caption         =   "全选未打印"
      Height          =   375
      Left            =   7320
      TabIndex        =   16
      Top             =   5160
      Width           =   1095
   End
   Begin VB.Frame frmNo 
      Caption         =   "检查号查询（设置后不使用时间范围）"
      Height          =   1455
      Left            =   3480
      TabIndex        =   11
      Top             =   4680
      Width           =   3615
      Begin VB.TextBox txtCheckNoEnd 
         Height          =   300
         Left            =   1200
         TabIndex        =   13
         Text            =   "Text2"
         Top             =   960
         Width           =   1935
      End
      Begin VB.TextBox txtCheckNoStart 
         Height          =   300
         Left            =   1200
         TabIndex        =   12
         Text            =   "Text1"
         Top             =   480
         Width           =   1935
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         Caption         =   "结束号码"
         Height          =   180
         Left            =   240
         TabIndex        =   15
         Top             =   1020
         Width           =   720
      End
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         Caption         =   "开始号码"
         Height          =   180
         Left            =   240
         TabIndex        =   14
         Top             =   525
         Width           =   720
      End
   End
   Begin VB.ComboBox cboDep 
      Height          =   300
      Left            =   1080
      Style           =   2  'Dropdown List
      TabIndex        =   10
      Top             =   5760
      Width           =   1995
   End
   Begin VB.CommandButton cmdFind 
      Caption         =   "查找数据(&F)"
      Height          =   350
      Left            =   120
      TabIndex        =   8
      Top             =   6240
      Width           =   1245
   End
   Begin MSComCtl2.DTPicker dtpEnd 
      Height          =   300
      Left            =   1080
      TabIndex        =   7
      Top             =   5200
      Width           =   1995
      _ExtentX        =   3519
      _ExtentY        =   529
      _Version        =   393216
      Format          =   109707265
      CurrentDate     =   43511
   End
   Begin MSComCtl2.DTPicker dtpStart 
      Height          =   300
      Left            =   1080
      TabIndex        =   6
      Top             =   4700
      Width           =   1995
      _ExtentX        =   3519
      _ExtentY        =   529
      _Version        =   393216
      Format          =   109707265
      CurrentDate     =   43511
   End
   Begin VB.CheckBox chkChoose 
      Caption         =   "全选(&A)"
      Height          =   350
      Left            =   7320
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   4680
      Width           =   1125
   End
   Begin VB.CommandButton cmdCancel 
      Cancel          =   -1  'True
      Caption         =   "取消(&C)"
      Height          =   350
      Left            =   7320
      TabIndex        =   1
      Top             =   6240
      Width           =   1125
   End
   Begin VB.CommandButton cmdOk 
      Caption         =   "确定(&O)"
      Height          =   350
      Left            =   6000
      TabIndex        =   0
      Top             =   6240
      Width           =   1125
   End
   Begin VSFlex8Ctl.VSFlexGrid vsfList 
      Height          =   4455
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   8295
      _cx             =   14631
      _cy             =   7858
      Appearance      =   1
      BorderStyle     =   1
      Enabled         =   -1  'True
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MousePointer    =   0
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      BackColorFixed  =   -2147483633
      ForeColorFixed  =   -2147483630
      BackColorSel    =   -2147483635
      ForeColorSel    =   0
      BackColorBkg    =   -2147483636
      BackColorAlternate=   -2147483643
      GridColor       =   -2147483633
      GridColorFixed  =   -2147483632
      TreeColor       =   -2147483632
      FloodColor      =   192
      SheetBorder     =   -2147483642
      FocusRect       =   1
      HighLight       =   1
      AllowSelection  =   -1  'True
      AllowBigSelection=   -1  'True
      AllowUserResizing=   1
      SelectionMode   =   1
      GridLines       =   1
      GridLinesFixed  =   2
      GridLineWidth   =   1
      Rows            =   50
      Cols            =   10
      FixedRows       =   1
      FixedCols       =   1
      RowHeightMin    =   0
      RowHeightMax    =   0
      ColWidthMin     =   0
      ColWidthMax     =   0
      ExtendLastCol   =   0   'False
      FormatString    =   ""
      ScrollTrack     =   0   'False
      ScrollBars      =   3
      ScrollTips      =   0   'False
      MergeCells      =   0
      MergeCompare    =   0
      AutoResize      =   -1  'True
      AutoSizeMode    =   0
      AutoSearch      =   0
      AutoSearchDelay =   2
      MultiTotals     =   -1  'True
      SubtotalPosition=   1
      OutlineBar      =   0
      OutlineCol      =   0
      Ellipsis        =   0
      ExplorerBar     =   0
      PicturesOver    =   0   'False
      FillStyle       =   0
      RightToLeft     =   0   'False
      PictureType     =   0
      TabBehavior     =   0
      OwnerDraw       =   0
      Editable        =   2
      ShowComboButton =   1
      WordWrap        =   0   'False
      TextStyle       =   0
      TextStyleFixed  =   0
      OleDragMode     =   0
      OleDropMode     =   0
      DataMode        =   0
      VirtualData     =   -1  'True
      DataMember      =   ""
      ComboSearch     =   3
      AutoSizeMouse   =   -1  'True
      FrozenRows      =   0
      FrozenCols      =   0
      AllowUserFreezing=   0
      BackColorFrozen =   0
      ForeColorFrozen =   0
      WallPaperAlignment=   9
      AccessibleName  =   ""
      AccessibleDescription=   ""
      AccessibleValue =   ""
      AccessibleRole  =   24
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "执行科室"
      Height          =   180
      Left            =   120
      TabIndex        =   9
      Top             =   5760
      Width           =   720
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "结束日期"
      Height          =   180
      Left            =   120
      TabIndex        =   5
      Top             =   5280
      Width           =   720
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "开始日期"
      Height          =   180
      Left            =   120
      TabIndex        =   4
      Top             =   4760
      Width           =   720
   End
End
Attribute VB_Name = "frmDocPrintPatiList"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private mstrReturn As String
Private mblUseCheckNo As Boolean
Private mlngModule As Long
Private mlngDepID As Long

Public Function Showfrm(frmParent As Form, ByVal dtStart As Date, ByVal dtEnd As Date, ByVal lngModule As Long, ByVal lngDepID As Long) As String
'参数：vsList病人列表，blnCanPrint 平诊报告需要审核才能打印
    Dim i As Integer
    
    mstrReturn = ""
    
    dtpStart.value = dtStart
    dtpEnd.value = dtEnd
    mlngModule = lngModule
    mlngDepID = lngDepID
    
    
    If mlngModule = G_LNG_PATHSTATION_MODULE Then
        frmNo.Caption = "病理号查询（设置后不使用时间范围）"
    Else
        frmNo.Caption = "检查号查询（设置后不使用时间范围）"
    End If
    
    For i = 0 To cboDep.ListCount - 1
        If cboDep.ItemData(i) = mlngDepID Then
            cboDep.ListIndex = i
            Exit For
        End If
    Next
    
    Call InitReleationList
    Call LoadListDate
    
    Me.Show 1, frmParent
    Showfrm = mstrReturn
End Function


Private Sub InitReleationList()
'初始化关联列表

    With vsfList
        .FixedCols = 0
        .FixedRows = 1
        
        .GridLines = flexGridFlat
        .BackColorBkg = .BackColor
        .SheetBorder = .BackColor
        .ExtendLastCol = True
        .Redraw = flexRDBuffered
        .OutlineCol = 1
        .OutlineBar = flexOutlineBarCompleteLeaf
        .Ellipsis = flexEllipsisEnd
        
        .AllowSelection = False
        .HighLight = flexHighlightAlways
        .ScrollTrack = True
        .SelectionMode = flexSelectionByRow
    End With
End Sub

Private Sub chkChoose_Click()
On Error GoTo errH
    Dim i As Integer
    Dim intCol As Integer
    
    intCol = vsfList.ColIndex("打印选择")
    
    If chkChoose.value = 1 Then
        chkChoose.Caption = "全清(&D)"
        For i = 1 To vsfList.Rows - 1
            vsfList.Cell(flexcpChecked, i, intCol) = 1
        Next
    Else
        chkChoose.Caption = "全选(&A)"
        For i = 1 To vsfList.Rows - 1
            vsfList.Cell(flexcpChecked, i, intCol) = 2
        Next
    End If
    Exit Sub
errH:
     MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

Private Sub cmdAllNoPrint_Click()
On Error GoTo errH
    Dim i As Integer
    Dim intColPrint As Integer
    Dim intColName As Integer
    
    intColPrint = vsfList.ColIndex("打印状态")
    intColName = vsfList.ColIndex("打印选择")

    For i = 1 To vsfList.Rows - 1
        If Len(Trim(vsfList.TextMatrix(i, intColPrint))) = 0 And Val(vsfList.TextMatrix(i, intColName)) = 0 Then vsfList.Cell(flexcpChecked, i, intColName) = 1
    Next
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdOk_Click()
    '组织返回值，返回值由"医嘱ID（报告文档编辑器:报告ID）-编辑器类型-执行科室ID-是否转储|医嘱ID（报告文档编辑器:报告ID）-编辑器类型-执行科室ID-是否转储|..."组成
    Dim i As Long

    mstrReturn = ""
    For i = 1 To vsfList.Rows - 1
        If vsfList.Cell(flexcpChecked, i, vsfList.ColIndex("打印选择")) = 1 Then
            If vsfList.Cell(flexcpText, i, vsfList.ColIndex("PACS报告")) = 2 Then
                mstrReturn = mstrReturn & "|" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("文档ID")) & "-"
            Else
                mstrReturn = mstrReturn & "|" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("医嘱ID")) & "-"
            End If
            mstrReturn = mstrReturn & vsfList.Cell(flexcpText, i, vsfList.ColIndex("PACS报告")) & "-" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("执行科室ID")) & "-" & vsfList.Cell(flexcpText, i, vsfList.ColIndex("是否转存"))
        End If
    Next

    mstrReturn = Mid(mstrReturn, 2)
    Unload Me
End Sub

Private Sub cmdFind_Click()
    Call LoadListDate
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyF2 Then
        cmdOk_Click
    End If
End Sub

Private Sub Form_Load()
    txtCheckNoStart = ""
    txtCheckNoEnd = ""
    Call InitcboDep
End Sub

Private Sub vsfList_BeforeEdit(ByVal Row As Long, ByVal Col As Long, Cancel As Boolean)
    If Col <> 1 Then Cancel = True
End Sub

Private Sub LoadListDate()
'显示列表数据
On Error GoTo errH
    Dim dtStart As Date
    Dim dtEnd As Date
    Dim strSQL As String, strSQLMoved As String
    Dim rsTmp As Recordset
    Dim intColdepID As Integer
    Dim intType As ReportType
    Dim blnCanPrint As Boolean
    Dim strTmp As String
    Dim iCount As Integer
    Dim i As Integer, j As Integer
    Dim strSQLCheckNoOrDate As String
    Dim strSQLDeptID As String
    Dim strMoved As String
    Dim lngDeptId As Long
    
    '''病理站SQL补充
    Dim strSQLPatholCOL As String
    Dim strSQLPatholTABLE As String
    Dim strSQLPatholFILTER As String
    
    lngDeptId = 0
    strSQLDeptID = ""
    strSQLCheckNoOrDate = ""
    If valInput() = False Then Exit Sub
    If mblUseCheckNo Then
        If mlngModule = G_LNG_PATHSTATION_MODULE Then
            strSQLCheckNoOrDate = " And I.病理号 Between [3] And [4] "
        Else
            strSQLCheckNoOrDate = " And D.检查号 Between [3] And [4] "
        End If
    Else
        strSQLCheckNoOrDate = " And A.开嘱时间 Between [1] and [2]  "
    End If
        
    If (cboDep.Text) <> "全部科室" And cboDep.ListIndex > -1 Then
        strSQLDeptID = " And A.执行科室ID=[5] "
        lngDeptId = cboDep.ItemData(cboDep.ListIndex)
    End If
    
    vsfList.Clear
    blnCanPrint = GetDeptPara(UserInfo.部门ID, "平诊需审核才能打报告") = "1"
    dtStart = dtpStart.value
    dtEnd = dtpEnd.value
    
    
   strMoved = " 0 as 是否转存 "
   
    If mlngModule = G_LNG_PATHSTATION_MODULE Then
        strSQLPatholCOL = "I.病理号 as 病理号,"
        strSQLPatholTABLE = ",病理检查信息 I "
        strSQLPatholFILTER = "And A.ID=I.医嘱ID(+)"
    Else
        strSQLPatholCOL = " '' as 病理号,"
        strSQLPatholTABLE = ""
        strSQLPatholFILTER = ""
    End If
    
    If blnCanPrint Then
    '如果参数=true 老版报告增加逻辑：紧急医嘱有报告人，其他报告需要已审核
      strSQL = "SELECT A.ID as 医嘱ID," & strSQLPatholCOL & "'' as 打印选择,decode(Nvl(A.婴儿, 0), 0, A.姓名, Decode(G.婴儿姓名, null, A.姓名 || '之子' || G.序号, G.婴儿姓名)) as 姓名," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, A.性别, G.婴儿性别 ) as 性别," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, nvl(D.年龄,A.年龄), decode(D.年龄, null, decode(G.死亡时间, null,Zl_Age_Calc(0, G.出生时间, A.开嘱时间), Zl_Age_Calc(0, G.出生时间, G.死亡时间)), D.年龄)) as 年龄," & vbNewLine & _
        "decode(nvl(A.病人来源,0),1,'门',2,'住',4,'体','外') as 来源," & vbNewLine & _
        "D.检查号," & vbNewLine & _
        "A.医嘱内容 as 内容,A.执行科室ID,H.名称 as 执行科室,'' as 部位,decode(nvl(D.报告打印,0),0,'','√') as 打印状态 ,'' as PACS报告,'' as 报告文档名称,'' As 文档ID, " & strMoved & vbNewLine & _
        "from 病人医嘱记录 A,病人医嘱发送 B,影像检查记录 D,病人医嘱报告 E,病人新生儿记录 G,部门表 H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=E.医嘱ID " & strSQLPatholFILTER & " And A.ID=D.医嘱ID  And A.ID=B.医嘱ID And B.执行过程 In(4,5,6)" & vbNewLine & _
        "And A.执行科室ID=H.ID And A.病人ID=G.病人ID(+) And A.主页ID=G.主页ID(+) And A.婴儿=G.序号(+) And E.检查报告ID is null  And a.相关id is null" & vbNewLine & _
        "And (A.紧急标志<>1 And D.复核人 is not null) " & strSQLCheckNoOrDate & strSQLDeptID & vbNewLine & _
        "union all" & vbNewLine & _
        "SELECT A.ID as 医嘱ID," & strSQLPatholCOL & "'' as 打印选择,decode(Nvl(A.婴儿, 0), 0, A.姓名, Decode(G.婴儿姓名, null, A.姓名 || '之子' || G.序号, G.婴儿姓名)) as 姓名," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, A.性别, G.婴儿性别 ) as 性别," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, nvl(D.年龄,A.年龄), decode(D.年龄, null, decode(G.死亡时间, null,Zl_Age_Calc(0, G.出生时间, A.开嘱时间), Zl_Age_Calc(0, G.出生时间, G.死亡时间)), D.年龄)) as 年龄," & vbNewLine & _
        "decode(nvl(A.病人来源,0),1,'门',2,'住',4,'体','外') as 来源," & vbNewLine & _
        "D.检查号," & vbNewLine & _
        "A.医嘱内容 as 内容,A.执行科室ID,H.名称 as 执行科室,'' as 部位,decode(nvl(E.报告打印,0),0,'','√') as 打印状态,'2' as PACS报告,E.文档标题 as 报告文档名称,RawToHex(E.ID) As 文档ID, " & strMoved & vbNewLine & _
        "from 病人医嘱记录 A,影像检查记录 D,影像报告记录 E,病人医嘱报告 F,病人新生儿记录 G,部门表 H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=F.医嘱ID " & strSQLPatholFILTER & " And A.ID=D.医嘱ID  And E.ID= F.检查报告ID" & vbNewLine & _
        "And A.执行科室ID=H.ID And A.病人ID=G.病人ID(+) And A.主页ID=G.主页ID(+) And A.婴儿=G.序号(+)  And F.检查报告ID is not null" & vbNewLine & _
        "And E.报告状态 In(2,3,4) " & strSQLCheckNoOrDate & strSQLDeptID

    Else
        strSQL = "SELECT A.ID as 医嘱ID," & strSQLPatholCOL & "'' as 打印选择,decode(Nvl(A.婴儿, 0), 0, A.姓名, Decode(G.婴儿姓名, null, A.姓名 || '之子' || G.序号, G.婴儿姓名)) as 姓名," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, A.性别, G.婴儿性别 ) as 性别," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, nvl(D.年龄,A.年龄), decode(D.年龄, null, decode(G.死亡时间, null,Zl_Age_Calc(0, G.出生时间, A.开嘱时间), Zl_Age_Calc(0, G.出生时间, G.死亡时间)), D.年龄)) as 年龄," & vbNewLine & _
        "decode(nvl(A.病人来源,0),1,'门',2,'住',4,'体','外') as 来源," & vbNewLine & _
        "D.检查号," & vbNewLine & _
        "A.医嘱内容 as 内容,A.执行科室ID,H.名称 as 执行科室,'' as 部位,decode(nvl(D.报告打印,0),0,'','√') as 打印状态 ,'' as PACS报告,'' as 报告文档名称,'' As 文档ID, " & strMoved & vbNewLine & _
        "from 病人医嘱记录 A,病人医嘱发送 B,影像检查记录 D,病人医嘱报告 E,病人新生儿记录 G,部门表 H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=E.医嘱ID " & strSQLPatholFILTER & "And A.ID=D.医嘱ID  And A.ID=B.医嘱ID And B.执行过程 In(4,5,6)" & vbNewLine & _
        "And A.执行科室ID=H.ID And A.病人ID=G.病人ID(+) And A.主页ID=G.主页ID(+) And A.婴儿=G.序号(+) And E.检查报告ID is null  " & vbNewLine & _
        "And a.相关id is null " & strSQLCheckNoOrDate & strSQLDeptID & vbNewLine & _
        "union all" & vbNewLine & _
        "SELECT A.ID as 医嘱ID," & strSQLPatholCOL & "'' as 打印选择,decode(Nvl(A.婴儿, 0), 0, A.姓名, Decode(G.婴儿姓名, null, A.姓名 || '之子' || G.序号, G.婴儿姓名)) as 姓名," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, A.性别, G.婴儿性别 ) as 性别," & vbNewLine & _
        "decode(Nvl(A.婴儿, 0), 0, nvl(D.年龄,A.年龄), decode(D.年龄, null, decode(G.死亡时间, null,Zl_Age_Calc(0, G.出生时间, A.开嘱时间), Zl_Age_Calc(0, G.出生时间, G.死亡时间)), D.年龄)) as 年龄," & vbNewLine & _
        "decode(nvl(A.病人来源,0),1,'门',2,'住',4,'体','外') as 来源," & vbNewLine & _
        "D.检查号," & vbNewLine & _
        "A.医嘱内容 as 内容,A.执行科室ID,H.名称 as 执行科室,'' as 部位,decode(nvl(E.报告打印,0),0,'','√') as 打印状态,'2' as PACS报告,E.文档标题 as 报告文档名称,RawToHex(E.ID) As 文档ID, " & strMoved & vbNewLine & _
        "from 病人医嘱记录 A,影像检查记录 D,影像报告记录 E,病人医嘱报告 F,病人新生儿记录 G,部门表 H" & strSQLPatholTABLE & vbNewLine & _
        "where A.Id=F.医嘱ID " & strSQLPatholFILTER & " And A.ID=D.医嘱ID  And E.ID= F.检查报告ID" & vbNewLine & _
        "And A.执行科室ID=H.ID And A.病人ID=G.病人ID(+) And A.主页ID=G.主页ID(+) And A.婴儿=G.序号(+)  And F.检查报告ID is not null" & vbNewLine & _
        "And E.报告状态 In(2,3,4) " & strSQLCheckNoOrDate & strSQLDeptID
    End If

    If MovedByDate(dtStart) Then
        strSQLMoved = Replace(strSQL, strMoved, " 1 as 是否转存 ")
        strSQLMoved = Replace(strSQL, "影像检查记录", " 1 as 是否转存 ")
        strSQLMoved = Replace(strSQL, "病人医嘱记录", " 1 as 是否转存 ")
        strSQLMoved = Replace(strSQL, "病人医嘱发送", " 1 as 是否转存 ")
        strSQLMoved = Replace(strSQL, "影像报告记录", " 1 as 是否转存 ")
        strSQL = strSQL & " union all " & strSQLMoved
    End If
                
    Set rsTmp = zlDatabase.OpenSQLRecord(strSQL, "批量打印数据获取", dtStart, dtEnd, txtCheckNoStart.Text, txtCheckNoEnd.Text, lngDeptId)
    
    Set vsfList.DataSource = rsTmp
    
    '列表格式修改
    
    vsfList.ColPosition(vsfList.ColIndex("打印选择")) = 1
    vsfList.ColPosition(vsfList.ColIndex("打印状态")) = 2
    vsfList.ColPosition(vsfList.ColIndex("检查号")) = 3
    vsfList.ColPosition(vsfList.ColIndex("病理号")) = 4
    vsfList.ColPosition(vsfList.ColIndex("姓名")) = 5
    vsfList.ColPosition(vsfList.ColIndex("性别")) = 6
    vsfList.ColPosition(vsfList.ColIndex("年龄")) = 7
    vsfList.ColPosition(vsfList.ColIndex("内容")) = 8
    
    vsfList.ColDataType(vsfList.ColIndex("打印选择")) = flexDTBoolean
    vsfList.ColHidden(vsfList.ColIndex("是否转存")) = True
    vsfList.ColHidden(vsfList.ColIndex("文档ID")) = True
    vsfList.ColHidden(vsfList.ColIndex("PACS报告")) = True
    vsfList.ColHidden(vsfList.ColIndex("执行科室ID")) = True
    vsfList.ColHidden(vsfList.ColIndex("医嘱ID")) = True
    'Pacs报告列内容靠右显示TODO
    
    vsfList.ColHidden(vsfList.ColIndex("病理号")) = Not (mlngModule = G_LNG_PATHSTATION_MODULE)
    vsfList.ColHidden(vsfList.ColIndex("检查号")) = (mlngModule = G_LNG_PATHSTATION_MODULE)
    
    If rsTmp.EOF Then
        Me.Caption = "未查询到符合条件的报告"
        Exit Sub
    End If
    
    intColdepID = vsfList.ColIndex("执行科室ID")
    
    
    With vsfList
        For i = 1 To rsTmp.RecordCount
            intType = GetDeptPara(.Cell(flexcpText, i, intColdepID), "报告编辑器", 0)
            
            If intType = PACS报告编辑器 Then
                .Cell(flexcpText, i, .ColIndex("PACS报告")) = 1
            ElseIf intType = 电子病历编辑器 Then
                .Cell(flexcpText, i, .ColIndex("PACS报告")) = 0
            End If
            
            strTmp = .Cell(flexcpText, i, .ColIndex("内容"))
            If InStr(strTmp, ":") > 0 Then
                .Cell(flexcpText, i, .ColIndex("内容")) = Split(strTmp, ":")(0)
                .Cell(flexcpText, i, .ColIndex("部位")) = Split(strTmp, ":")(1)
            End If
            
        Next
    End With
    
    Me.Caption = "选择需要打印的报告，列表中报告总数为：" & rsTmp.RecordCount
    
    '自动列宽
    vsfList.AutoSize 0, vsfList.Cols - 1
    '内容靠左
    If vsfList.Rows > 1 Then vsfList.Cell(flexcpAlignment, 1, 1, vsfList.Rows - 1, vsfList.Cols - 1) = flexAlignLeftCenter
    
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

Private Function valInput() As Boolean
'输入数据验证
'目前只验证检查号
'valInput 是否验证通过
'mblUseCheckNo ：是否使用检查号范围
    valInput = True
    
    If Len(txtCheckNoStart) <> 0 And Len(txtCheckNoEnd) <> 0 Then
        mblUseCheckNo = True
        Exit Function
    End If
    
    If Len(txtCheckNoStart) > 0 And Len(txtCheckNoEnd) = 0 Then
        MsgBox "请输入结束号码"
        valInput = False
    End If
    
    If Len(txtCheckNoEnd) > 0 And Len(txtCheckNoStart) = 0 Then
        MsgBox "请输入开始号码"
        valInput = False
    End If
    mblUseCheckNo = False
End Function

Private Sub InitcboDep()
'初始化科室
On Error GoTo errH
    Dim strFrom As String
    Dim strSQL As String
    Dim rsData As Recordset
    
    cboDep.Clear
    cboDep.AddItem ("全部科室")
    cboDep.ItemData(cboDep.ListCount - 1) = 0
    
    strFrom = "1,2,3"
    strSQL = " Select Distinct A.ID,A.编码,A.名称" & _
        " From 部门表 A,部门性质说明 B " & _
        " Where B.部门ID = A.ID " & _
        " And (A.撤档时间=TO_DATE('3000-01-01','YYYY-MM-DD') Or A.撤档时间 is NULL) " & _
        " And (A.站点='" & gstrNodeNo & "' Or A.站点 is Null ) " & _
        " And instr([1],','||B.服务对象||',')> 0 And B.工作性质 IN('检查')" & _
        " Order by A.编码"
        
    Set rsData = zlDatabase.OpenSQLRecord(strSQL, Me.Caption, CStr("," & strFrom & ","))
    
    If rsData.RecordCount <= 0 Then Exit Sub

    While Not rsData.EOF
        cboDep.AddItem (rsData!名称 & "")
        cboDep.ItemData(cboDep.ListCount - 1) = rsData!ID
        rsData.MoveNext
    Wend
    
    Exit Sub
errH:
    MsgBoxD Me, err.Description, vbInformation, Me.Caption
End Sub

