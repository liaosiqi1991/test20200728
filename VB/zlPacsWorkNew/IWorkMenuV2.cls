VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "IWorkMenuV2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Function zlBaseMenuID() As Long

End Function

Public Function zlExecuteCmd(ByVal lngCmdType As Long)
'ִ�в˵�����

End Function

Public Function zlIsModuleMenu(ByVal strModuleName As String, objControlMenu As XtremeCommandBars.ICommandBarControl) As Boolean
'�жϲ˵��Ƿ����ڸ�ģ��˵�

End Function


Public Sub zlCreateMenu(ByVal strModuleName As String, objMenuBar As Object)
'����Ӱ���¼��Ӧ�Ĳ˵�
'objMenuBarΪCommandBars�Ĳ˵�����

End Sub


Public Sub zlCreateToolBar(ByVal strModuleName As String, objToolBar As Object)
'����������

End Sub


Public Sub zlClearMenu(ByVal strModuleName As String)
'����������Ĳ˵�

End Sub


Public Sub zlClearToolBar(ByVal strModuleName As String)
'��������Ĺ�����

End Sub


Public Sub zlExecuteMenu(ByVal strModuleName As String, ByVal lngMenuId As Long)
'���ݲ˵�IDִ�ж�Ӧ����

End Sub


Public Sub zlUpdateMenu(ByVal strModuleName As String, Control As XtremeCommandBars.ICommandBarControl)
'���²˵�

End Sub


Public Sub zlPopupMenu(ByVal strModuleName As String, objPopup As XtremeCommandBars.ICommandBar)
'�����Ҽ��˵�

End Sub


Public Sub zlRefreshSubMenu(ByVal strModuleName As String, objCommandBar As Object)
'ˢ�µ������Ӳ˵�
'objCommandBarΪѡ�е�ĳ���˵�����

End Sub




