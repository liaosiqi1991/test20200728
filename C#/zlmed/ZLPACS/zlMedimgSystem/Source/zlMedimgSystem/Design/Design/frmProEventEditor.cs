using System;
using System.Collections.Generic;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Design
{
    public partial class frmProEventEditor : Form
    {
        public class BindItem
        {
            public string Caption { get; set; }
            public string Description { get; set; } 

            public BindItem()
            {

            }

            public BindItem(string caption, string desc)
            {
                Caption = caption;
                Description = desc;
            }
        }




        private Control _designParent;
        private ISysDesign _bizMain = null;
        private ISysDesign _instance;
         
        private Dictionary<string, EventActionReleation> _events = null;


        private bool _isLoading = false;

        //private Dictionary<string, ISysDesign> _modules = null;
        private CoordinationBizModules _modules = null;
        protected frmProEventEditor()
        {
            InitializeComponent();

            //_modules = new Dictionary<string, ISysDesign>();
        }

        public frmProEventEditor(Control designParent, ISysDesign instance, object value)
            : this()
        {
            _designParent = designParent;
            _bizMain = designParent as ISysDesign;
            _instance = instance as ISysDesign;

            _events = (Dictionary<string, EventActionReleation>)_instance.DesignEvents;
        }

        public Dictionary<string, EventActionReleation> DesignEvents
        {
            get { return _events; }
        }

        private void InitEvnetActionList()
        {
            listEventActions.Clear();
            listEventActions.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();

            columnDefault = new ColumnHeader();
            columnDefault.Text = "执行模块";
            columnDefault.Name = "执行模块";
            columnDefault.Width = 100;
            listEventActions.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "模块所在窗体";
            columnDefault.Name = "模块所在窗体";
            columnDefault.Width = 100;
            listEventActions.Columns.Add(columnDefault); 

            columnDefault = new ColumnHeader();
            columnDefault.Text = "执行事务";
            columnDefault.Name = "执行事务";
            columnDefault.Width = 100;
            listEventActions.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "请求数据项";
            columnDefault.Name = "请求数据项";
            columnDefault.Width = 160;
            listEventActions.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "数据所在窗体";
            columnDefault.Name = "数据所在窗体";
            columnDefault.Width = 100;
            listEventActions.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "执行标记";
            columnDefault.Name = "执行标记";
            columnDefault.Width = 200;
            listEventActions.Columns.Add(columnDefault);


            listEventActions.View = View.Details;
        }

        private void LoadCfg()
        {
            listEventActions.Items.Clear();
            lvEvent.Items.Clear();
            listModule.Items.Clear();
            lvEvent.Columns.Clear();
            listModule.Columns.Clear();

            cbxDataType.Items.Clear();
            cbxModuleType.Items.Clear();
            cbxDataType.Items.Clear();
            cbxModuleAction.Items.Clear();
            
            cbxDataName.DisplayMember = "Caption";
            cbxDataName.ValueMember = "Description";
             
            lvEvent.Columns.Add("事件名称", lvEvent.Width - 40);              
            listModule.Columns.Add("模块名称", listModule.Width - 40);

            InitEvnetActionList();

            LoadDesignModuleEvent(); 

            LoadModuleNameAndData();

            LoadModuleActions();
            
            LoadModuleData();
        }

        /// <summary>
        /// 编辑属性值
        /// </summary>
        /// <param name="designParent"></param>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object EditValue(Control designParent, ISysDesign instance, object value)
        {
            using (frmProEventEditor form = new frmProEventEditor(designParent, instance, value))
            {
                form.ShowDialog(designParent);
                
                return DictionaryJsonHelper.SerializeDictionaryToJsonString<string, EventActionReleation>(form.DesignEvents);// JsonConvert.SerializeObject(form.DesignEvents);
            }
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            if (Owner != null) this.Icon = Owner.Icon;

            _isLoading = true;
            try
            {
                LoadCfg();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void cbxModuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoading) return;

                LoadModuleActions();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 载入模块事件
        /// </summary>
        private void LoadDesignModuleEvent()
        {
            lvEvent.Items.Clear();

            foreach (string eventName in _events.Keys)
            {
                lvEvent.Items.Add(eventName, 0);
            }

            lvEvent.View = View.Details;

            if (lvEvent.Items.Count > 0) lvEvent.Items[0].Selected = true;
        }

        /// <summary>
        /// 载入模块名称
        /// </summary>
        private void LoadModuleNameAndData()
        {
            cbxDataName.Items.Clear();
            cbxModuleType.Items.Clear();
            cbxDataType.Items.Clear();
            listModule.Items.Clear();
             

            if (this.DesignMode)
            {
                //ide设计模式下的处理
                if (_modules == null) _modules = new CoordinationBizModules();
                List<Control> ctls = DesignHelper.GetDesignControls(_designParent);

                foreach (Control ctl in ctls)
                {
                    ISysDesign dc = ctl as ISysDesign;
                    if (dc != null)
                    {
                        if (_modules.ContainsKey(dc.ModuleName) == false)
                        {
                            _modules.Add(dc.ModuleName, dc);
                        }
                        else
                        {
                            MessageBox.Show("模块 [" + dc.ModuleName + "] 实例已经存在，不能重复添加", "提示");
                        }
                    }
                }            
            }
            else
            {
                _modules = _instance.RelateModules;
            }

            if (_modules == null) return;
            if (_modules.Count <= 0 && _modules.ParentWindowBizModules == null) return;

            cbxModuleType.Items.Add("当前窗体模块");
            cbxDataType.Items.Add("当前窗体模块");
             

            if (_modules.ParentWindowBizModules != null)
            {
                cbxModuleType.Items.Add("父级窗体模块");
                cbxDataType.Items.Add("父级窗体模块"); 
            }

            cbxModuleType.SelectedIndex = 0;
            cbxDataType.SelectedIndex = 0;


        }

        /// <summary>
        /// 载入模块事务
        /// </summary>
        private void LoadModuleActions()
        {
            cbxModuleAction.Items.Clear();

            if (listModule.SelectedItems.Count <= 0) return;

            ISysDesign selDc = null;
            if (cbxModuleType.SelectedIndex > 0)
            {
                selDc = _modules.ParentWindowBizModules[listModule.SelectedItems[0].Text];
            }
            else
            {
                selDc = _modules[listModule.SelectedItems[0].Text];
            }

            
            if (selDc == null) return;

            cbxModuleAction.DisplayMember = "Key";

            foreach (var act in selDc.ProvideActions)
            {
                cbxModuleAction.Items.Add(act);
            }


            if (cbxModuleAction.Items.Count <= 0) return;

            cbxModuleAction.SelectedIndex = 0;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvEvent.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要配置的事件。", "提示");
                    return;
                }

                if (listModule.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要执行的模块。", "提示");
                    return;
                }

                string actionName = listModule.SelectedItems[0].Text + "." + cbxModuleAction.Text;

                bool isParentWindow = (cbxModuleType.SelectedIndex <= 0) ? false : true;
                bool isParentModuleData = (cbxDataType.SelectedIndex <= 0) ? false : true;


                //模块事件  
                string eventName = lvEvent.SelectedItems[0].Text;

                eventName = eventName.Replace("自定按钮： ", "");

                if (_events.ContainsKey(eventName) == false)
                {
                    _events.Add(eventName, new EventActionReleation(eventName, ActionType.atSysFixedEvent, eventName));
                }

                ActionItem aiNew = new ActionItem(cbxModuleAction.Text, txtTag.Text, cbxDataName.Text, isParentWindow, isParentModuleData);
                _events[eventName].Actions.Add(actionName, aiNew);

                listEventActions.Items.Add(new ListViewItem(new string[] {listModule.SelectedItems[0].Text, cbxModuleType.Text, cbxModuleAction.Text,
                                                            cbxDataName.Text, cbxDataType.Text, txtTag.Text }, 0));

                listEventActions.Tag = aiNew;
                //listEventActions.Items.Add(actionName + "  (执行标记：" + txtTag.Text + "   请求数据：" + cbxDataName.Text + ")");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listEventActions.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的项目。", "提示");
                    return;
                }

                string eventName = lvEvent.SelectedItems[0].Text;

                string delAction = listEventActions.SelectedItems[0].Text + "." + listEventActions.SelectedItems[0].SubItems[2].Text;
                //delAction = delAction.Substring(0, delAction.IndexOf("  ("));

                _events[eventName].Actions.Remove(delAction);

                int delIndex = listEventActions.SelectedItems[0].Index;
                listEventActions.Items.RemoveAt(delIndex);

                if (delIndex < listEventActions.Items.Count)
                {
                    listEventActions.Items[delIndex].Selected = true;
                }
                else
                {
                    if (delIndex != 0) listEventActions.Items[delIndex - 1].Selected = true;
                }


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxModuleAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoading) return;

                textDesc.Text = ((KeyValuePair<string, string>)cbxModuleAction.SelectedItem).Value;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
           
        private void cbxDataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDataDescription.Text = "";

                if (cbxDataName.SelectedItem == null) return;

                txtDataDescription.Text = (cbxDataName.SelectedItem as BindItem).Description;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxDataName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDataDescription.Text = "";
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lvEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (_isLoading) return;
                if (lvEvent.SelectedItems.Count <= 0) return;

                listEventActions.Items.Clear();                 

                string eventName = lvEvent.SelectedItems[0].Text; 

                if (_events.ContainsKey(eventName) == false) return;

                EventActionReleation ea = _events[eventName];
                if (ea == null) return;

                foreach (KeyValuePair<string, ActionItem> act in ea.Actions)
                {
                    string exeModuleName = "当前窗体模块";
                    if (act.Value.IsParentModule)
                    {
                        exeModuleName = "父级窗体模块";
                    }

                    string dataModuleName = "当前窗体模块";
                    if (act.Value.IsParentModuleData)
                    {
                        dataModuleName = "父级窗体模块";
                    }

                    ListViewItem lvi = listEventActions.Items.Add(new ListViewItem(new string[] {act.Key.Split('.')[0],  exeModuleName, act.Value.ActName,
                                                            act.Value.RequestDataName, dataModuleName, act.Value.ActTag }, 0));

                    lvi.Tag = act.Value;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listModule.Items.Clear();
                if (cbxModuleType.SelectedIndex == 0)
                {
                    foreach (ISysDesign dc in _modules.Values)
                    {
                        listModule.Items.Add(dc.ModuleName, 1);
                    }
                }
                else
                {
                    foreach (ISysDesign dc in _modules.ParentWindowBizModules.Values)
                    {
                        listModule.Items.Add(dc.ModuleName, 1);
                    }
                }

                listModule.View = View.Details;

                if (listModule.Items.Count > 0) listModule.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoading) return;

                LoadModuleActions();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadModuleData()
        {

            cbxDataName.Items.Clear();

            if (cbxDataType.Items.Count <= 0) return;

            if (cbxDataType.SelectedIndex <= 0)
            {

                foreach (ISysDesign dc in _modules.Values)
                {
                    //载入模块提供的数据项名称
                    foreach (KeyValuePair<string, string> dn in dc.ProvideDatas)
                    {
                        BindItem bi = new BindItem(dn.Key, dn.Value);

                        cbxDataName.Items.Add(bi);
                    }
                }
            }
            else
            {
                foreach (ISysDesign dc in _modules.ParentWindowBizModules.Values)
                {
                    //载入模块提供的数据项名称
                    foreach (KeyValuePair<string, string> dn in dc.ProvideDatas)
                    {
                        BindItem bi = new BindItem(dn.Key, dn.Value);

                        cbxDataName.Items.Add(bi);
                    }
                }
            }
        }

        private void cbxDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadModuleData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lvEvent_Resize(object sender, EventArgs e)
        {
            try
            {
                lvEvent.Columns[0].Width = lvEvent.Width - 40;
            }
            catch { }
        }

        private void listModule_Resize(object sender, EventArgs e)
        {
            try
            {
                listModule.Columns[0].Width = listModule.Width - 40;
            }
            catch { }
        }

        private void listEventActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listEventActions.SelectedItems.Count <= 0) return;

                ActionItem ai = listEventActions.SelectedItems[0].Tag as ActionItem;

                string exeModuleName = listEventActions.SelectedItems[0].Text;
                
                foreach(ListViewItem lvi in listModule.Items)
                {
                    if (lvi.Text == exeModuleName)
                    {
                        lvi.Selected = true;
                        break;
                    }
                }

                cbxModuleAction.Text = ai.ActName;
                cbxDataName.Text = ai.RequestDataName;

                cbxDataType.Text = (ai.IsParentModuleData) ? "父级窗体模块" : "当前窗体模块";

                txtTag.Text = ai.ActTag;

                //listEventActions.Items.Add(new ListViewItem(new string[] {act.Key.Split('.')[0],  exeModuleName, act.Value.ActName,
                //                                            act.Value.RequestDataName, dataModuleName, act.Value.ActTag }, 0));

                //listEventActions.Tag = act.Value;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (listEventActions.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要修改的事务项。", "提示");
                    return;
                }

                ListViewItem lvi = listEventActions.SelectedItems[0];

                lvi.SubItems[2].Text = cbxModuleAction.Text;
                lvi.SubItems[3].Text = cbxDataName.Text;

                string dataModuleName = "当前窗体模块";
                if (cbxDataType.SelectedIndex > 0)
                {
                    dataModuleName = "父级窗体模块";
                }

                lvi.SubItems[4].Text = dataModuleName;
                lvi.SubItems[5].Text = txtTag.Text;

                ActionItem ai = lvi.Tag as ActionItem;

                ai.ActName = cbxModuleAction.Text;
                ai.ActTag = txtTag.Text;
                ai.RequestDataName = cbxDataName.Text;
                ai.IsParentModuleData = (cbxDataType.SelectedIndex > 0) ? true : false;

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
