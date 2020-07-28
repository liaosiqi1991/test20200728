using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services; 
using zlMedimgSystem.Design;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Words
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(WordsControl), "Resources.word.ico")]
    public partial class WordsControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class WordProviderDataDefine
        {
            public const string SelWordContext = "当前选择词句内容";
        }

        static public class WordProviderActionDefine
        {
            public const string Action_LoadWord = "加载词句";
            public const string Action_RefreshWord = "刷新词句"; 
        }

        static public class WordProviderEventDefine
        {
            public const string WriteWord = "写入词句"; 
        }



        private string _applyId = "";
        private string _reportTemplateId = "";
        private string _reportFormatId = "";//格式ID为空时，则使用模板ID的词句
        private string _imageKind = "";     //影像类别

        private WordsModuleDesign _wordModuleDesign = null;

        private ReportWordsModel _rwm = null;


        public ReportWordsModel ReportWordsModel
        {
            get
            {
                if (_rwm == null) _rwm = new ReportWordsModel(_dbQuery);

                return _rwm;
            }
        }


        public WordsControl()
        {
            InitializeComponent();

            _wordModuleDesign = new WordsModuleDesign();

            _wordModuleDesign.ButWordLocateVisible = true;
            _wordModuleDesign.ButWordWriteVisible = true;

            _wordModuleDesign.ToolsDesign.Visible = true;

            _wordModuleDesign.ToolsDesign.Size = toolStrip1.Height;

            _wordModuleDesign.ToolsDesign.BackColor = toolStrip1.BackColor;
            _wordModuleDesign.ToolsDesign.ForceColor = toolStrip1.ForeColor;
        }



        protected override void InitBaseInfo()
        {
            _moduleName = "词句模块";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(WordProviderActionDefine.Action_LoadWord, "载入报告对应的词句信息，请求数据项如下：" + System.Environment.NewLine +
                                                                                "applyid,imagekind,templateid,formatid");

            _provideDataDesc.AddDataDescription(_moduleName, WordProviderDataDefine.SelWordContext, "");


            _designEvents.Add(WordProviderEventDefine.WriteWord, new EventActionReleation(WordProviderEventDefine.WriteWord, ActionType.atSysFixedEvent));
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _wordModuleDesign = JsonHelper.DeserializeObject<WordsModuleDesign>(customContext);

            LoadDesign();
        }

        public override string ShowCustomDesign()
        {
            using (frmWordDesign design = new frmWordDesign())
            {
                design.ShowDesign(_wordModuleDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_wordModuleDesign);

            LoadDesign();

            return _customDesignFmt;
        }


        private void LoadDesign()
        {
            if (_wordModuleDesign.ToolsDesign.Visible == false)
            {
                toolStrip1.Visible = false; 
                return;
            }

            if (_wordModuleDesign.ToolsDesign.Size > 0)
            { 
                toolStrip1.Height = _wordModuleDesign.ToolsDesign.Size;
            }

            toolStrip1.Visible = true;


            toolStrip1.BackColor = _wordModuleDesign.ToolsDesign.BackColor;
            toolStrip1.ForeColor = _wordModuleDesign.ToolsDesign.ForceColor;

            toolStripTextBox1.Visible = _wordModuleDesign.ButWordLocateVisible;
            tsbFind.Visible = _wordModuleDesign.ButWordLocateVisible;
            tsbWrite.Visible = _wordModuleDesign.ButWordWriteVisible;


            if (_wordModuleDesign.ToolsDesign.ToolsCfg != null)
            {
                InitUserTool(_wordModuleDesign.ToolsDesign);
            }
             

            ToolsHelper.SyncDesignEventsByButtons(_wordModuleDesign.ToolsDesign, _designEvents);
        }


        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                for (int i = toolStrip1.Items.Count - 1; i >= 0; i--)
                {
                    //先移除用户控件
                    if (toolStrip1.Items[i].Tag == null) continue;
                    toolStrip1.Items.RemoveAt(i);
                }

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStrip1.Items.Count <= 0) toolStrip1.Visible = false;

                    return;
                }

                ToolsHelper.ConfigButtons(toolStrip1, toolDesign, DoUserToolEvent_StripItem);

                if (this.DesignMode == false)
                {
                    toolStrip1.Visible = (toolStrip1.Items.Count <= 0) ? false : true;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoUserToolEvent_StripItem(object sender, EventArgs e)
        {
            ToolStripItem tsi = (sender as ToolStripItem);
            if (tsi == null) return;

            //没有对应的事件配置
            if (_designEvents.ContainsKey(tsi.Text) == false) return;

            EventActionReleation ea = _designEvents[tsi.Text];

            DoActions(ea, sender);
        }
         

        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        private void ClearData()
        {
            treeView1.Nodes.Clear();
            wordContext1.ClearItem();
        }


         
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case WordProviderActionDefine.Action_LoadWord:

                        _selWordDatas = null;
                        ClearData();

                        if (bizDatas == null) return false;
                         

                        string applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);

                        if (string.IsNullOrEmpty(applyId))
                        {
                            ClearData();

                            MessageBox.Show("未检索到对应的申请ID，请求数据项名称为 [" + bizDatas.DataName + "]。", "提示");
                            return false;
                        }

                        string imageKind = DataHelper.GetItemValueByImageKind(bizDatas[0]); 
                        if (string.IsNullOrEmpty(imageKind))
                        {
                            ClearData();

                            MessageBox.Show("未检索到对应的影像类别,请求数据项为 [" + bizDatas.DataName + "]。", "提示");
                            return false;
                        }


                        string templateId = DataHelper.GetItemValueByTemplateId(bizDatas[0]);

                        if (string.IsNullOrEmpty(templateId))
                        {
                            ClearData();

                            MessageBox.Show("未检索到对应的模板ID,请求数据项为 [" + bizDatas.DataName + "]。", "提示");
                            return false;
                        }

                        string formatId = DataHelper.GetItemValueByFormatId(bizDatas[0]);

                        _applyId = applyId;

                        LoadTemplateWord(imageKind, templateId, formatId);

                        break;

                    case WordProviderActionDefine.Action_RefreshWord://刷新词句
                        _selWordDatas = null;
                        ClearData();

                        if (string.IsNullOrEmpty(_applyId)) return true;
                        if (string.IsNullOrEmpty(_reportTemplateId)) return true;

                        LoadTemplateWord(_imageKind, _reportTemplateId, _reportFormatId);

                        break;
                                                              

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case WordProviderDataDefine.SelWordContext:
                    return true;
                     
                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case WordProviderDataDefine.SelWordContext://当前选择词句
                    return _selWordDatas;

                default:
                    return null;
            }
        }

        private void ClearWordContext()
        {
            wordContext1.ClearItem();
        }

        private DataTable _templateWords = null;
        private JReportTemplateSection _templateSection = null;
        private void LoadTemplateWord(string imageKind, string templateId, string formatId)
        {
            if (_imageKind != imageKind)
            {
                _imageKind = imageKind;

                BindWordClassData();
            }


            DataTable dtWordReleations = null;
            if (string.IsNullOrEmpty(formatId) == false )
            {
                //先查询格式对应的词句信息，如果格式没有设置词句关联，则查询对应模板的词句关联设置               
                if (_reportFormatId == formatId) return;

                dtWordReleations = ReportWordsModel.GetFormatWordClass(formatId); 
            }

            if (dtWordReleations == null)
            {
                if (_templateWords == null || _reportTemplateId != templateId)
                {
                    _templateWords = ReportWordsModel.GetTemplateWordClass(templateId);                    
                }

                dtWordReleations = _templateWords;
            }

            if (_reportTemplateId != templateId)
            {
                _templateSection = ReportWordsModel.GetTemplateSection(templateId);
            }


            _reportTemplateId = templateId;
            _reportFormatId = formatId;

             

            BindReleationWords(dtWordReleations);

            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes[0].Expand();
            }

        }

        private void BindReleationWords(DataTable wordReleations)
        {
            if (treeView1.Nodes.Count <= 0) return;

            List<TreeNode> checkNodes = GetCheckedNodes(treeView1.Nodes[0]);

            foreach (TreeNode tn in checkNodes)
            {
                SetDisableNodeStyle(tn);
            }


            ConfigCheckState(treeView1.Nodes[0], wordReleations);
        }

        private List<TreeNode> GetCheckedNodes(TreeNode tnParent)
        {
            List<TreeNode> result = new List<TreeNode>();

            if (tnParent.Checked) result.Add(tnParent);

            foreach (TreeNode tn in tnParent.Nodes)
            {
                if (tn.Nodes.Count > 0)
                {
                    List<TreeNode> checkNodes = GetCheckedNodes(tn);
                    result.AddRange(checkNodes);
                }
                else
                {
                    if (tn.Checked) result.Add(tn);
                }
            }

            return result;
        }


        private void SetDisableNodeStyle(TreeNode tn)
        {
            tn.Checked = false;
            tn.ForeColor = Color.Gray;

            //tn.NodeFont = new Font(treeView1.Font, FontStyle.Strikeout);

            tn.ImageIndex = 0;
            tn.SelectedImageIndex = 0;

            ClearWordInfoNode(tn);
        }

        private void ClearWordInfoNode(TreeNode tn)
        {
            for (int i = tn.Nodes.Count - 1; i >= 0; i--)
            {
                if (tn.Nodes[i].Nodes.Count > 0)
                {
                    ClearWordInfoNode(tn.Nodes[i]);
                }
                else
                {
                    if (tn.Nodes[i].ImageIndex == 1) tn.Nodes[i].Remove();
                }

            }
        }

        private void SetEnableNodeStyle(TreeNode tn)
        {
            tn.Checked = true;
            tn.ForeColor = Color.Black;

            //tn.NodeFont = null;

            tn.ImageIndex = 0;
            tn.SelectedImageIndex = 0;

            NewTmpWordInfoNode(tn);
        }

        private void NewTmpWordInfoNode(TreeNode tn)
        {
            ReportWordsClassData classData = tn.Tag as  ReportWordsClassData;

            string key = "TMP";
            if (classData != null)
            {
                key = key + "_" + classData.词句分类ID;
            }

            TreeNode tnWordInfo = tn.Nodes.Add(key, "TMP");

            tnWordInfo.ImageIndex = 1;
            tnWordInfo.SelectedImageIndex = 1;
                      
            tnWordInfo.Checked = true;
        }

        private void ConfigCheckState(TreeNode tnParent, DataTable wordReleations)
        {
            if (tnParent == null) return;

            ReportWordsClassData wordClass = tnParent.Tag as ReportWordsClassData;
            if (wordClass == null) return;

            if (wordReleations.Select("词句分类ID='" + wordClass.词句分类ID + "'").Length > 0)
            {
                SetEnableNodeStyle(tnParent);
            }
            else
            {
                SetDisableNodeStyle(tnParent);
            }

            foreach (TreeNode tn in tnParent.Nodes)
            {
                if (tn.Nodes.Count > 0)
                {
                    ConfigCheckState(tn, wordReleations);
                }
                else
                {
                    if (tn.Tag == null) continue;

                    wordClass = tn.Tag as ReportWordsClassData;
                    if (wordReleations.Select("词句分类ID='" + wordClass.词句分类ID + "'").Length > 0)
                    {
                        SetEnableNodeStyle(tn);
                    }
                    else
                    {
                        SetDisableNodeStyle(tn);
                    }
                }
            }
        }

        private void BindWordClassData()
        {
            treeView1.Nodes.Clear();

            DataTable dtClass = ReportWordsModel.GetWordsClass(_imageKind);
            if (dtClass.Rows.Count <= 0) return;

            DataRow[] drRoots = dtClass.Select("上级分类ID is null or 上级分类ID=''");


            foreach (DataRow drRoot in drRoots)
            {
                TreeNode rootNode = null;

                ReportWordsClassData classData = new ReportWordsClassData();
                classData.BindRowData(drRoot);

                rootNode = treeView1.Nodes.Add(classData.词句分类ID, classData.分类名称, 0);

                rootNode.SelectedImageIndex = 0;
                rootNode.Tag = classData;

                if (rootNode == null) continue;

                BindSubNode(rootNode, dtClass);
            }

            //treeView1.ExpandAll();
        }

        private void BindSubNode(TreeNode pNode, DataTable dtClass)
        {
            if (pNode == null || dtClass == null) return;

            ReportWordsClassData pClassData = pNode.Tag as ReportWordsClassData;
            DataRow[] drSubs = dtClass.Select("上级分类ID='" + pClassData.词句分类ID + "'");

            if (drSubs.Length <= 0) return;

            foreach (DataRow drCur in drSubs)
            {
                ReportWordsClassData subClassData = new ReportWordsClassData();
                subClassData.BindRowData(drCur);

                TreeNode tnSub = pNode.Nodes.Add(subClassData.词句分类ID, subClassData.分类名称, 0);
                tnSub.SelectedImageIndex = 0;
                tnSub.Tag = subClassData;

                BindSubNode(tnSub, dtClass);
            }
        }


        /// <summary>
        /// 绑定词句项目
        /// </summary>
        private void BindWordItem(TreeNode tnClass)
        {
            if (tnClass == null) return;

            ReportWordsClassData classData = tnClass.Tag as ReportWordsClassData;

            if (classData == null) return;

            TreeNode[] tmpNodes = tnClass.Nodes.Find("TMP_" + classData.词句分类ID, false);
            if (tmpNodes.Length <= 0) return;

            DataTable dtItem = ReportWordsModel.GetWordItemByClass(classData.词句分类ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ReportWordsInfoData itemData = new ReportWordsInfoData();
                itemData.BindRowData(dr);

                TreeNode tnItem = tnClass.Nodes.Add(itemData.词句ID, itemData.词句名称, 1);
                tnItem.SelectedImageIndex = 1;
                tnItem.Tag = itemData;
            }

            tnClass.Nodes.Remove(tmpNodes[0]);

        }
  

        private void sMenuNewWord_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    TreeListNode wordNode = null;

            //    if (trvWords.FocusedNode == null) return;

            //    wordNode = trvWords.FocusedNode;
            //    if (trvWords.FocusedNode.GetValue("类型").ToString() == "1")
            //    {
            //        wordNode = trvWords.FocusedNode.ParentNode;
            //    }

            //    JReportWords reportWord = new JReportWords();
            //    reportWord.ID = 0;
            //    reportWord.PID = Convert.ToInt32(wordNode.GetValue("ID"));

            //    frmWordEdit wordEdit = new frmWordEdit();
            //    wordEdit.Init(_dbHelper, _userData);

            //    wordEdit.EditWord(reportWord);

            //    if (wordEdit.IsOk == false) return;

            //    DataRow dr = ((DataTable)trvWords.DataSource).Rows.Add();
            //    dr["ID"] = wordEdit.ReportWord.ID;
            //    dr["上级ID"] = wordEdit.ReportWord.PID;
            //    dr["类型"] = 1;
            //    dr["名称"] = wordEdit.ReportWord.Name;
            //    dr["词句信息"] = JsonHelper.SerializeObject(wordEdit.ReportWord);

            //    //TreeListNode curNode = wordNode.Nodes.Add(dr);



            //    //curNode.StateImageIndex = 1;
            //    //curNode.ImageIndex = 1;

            //    //trvWords.Refresh();
            //    SetImageIndex(trvWords, null, 1, 0);

            //    //LoadWordContext(wordEdit.ReportWord);

            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag is ReportWordsClassData)
                {
                    BindWordItem(e.Node);
                }
                else
                {
                    ReportWordsInfoData wordData = e.Node.Tag as ReportWordsInfoData;

                    ReadWordContext(wordData);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ReadWordContext(ReportWordsInfoData wordData)
        { 
            if (wordData.词句信息 == null || wordData.词句信息.词句明细.Count != wordContext1.ItemCount)
            {
                wordContext1.ClearItem(); 
            }

            if (wordData == null)
            {
                MessageBox.Show("词句内容无效。", "提示");
                return;
            }


            if (wordData.词句信息.词句类型 == (int)ReportWordType.rwtFree)
            {

                wordContext1.ImageList = imageList1;
                wordContext1.HeadImageAlign = ContentAlignment.MiddleLeft;
                wordContext1.HeadWidth = 60;


                if (wordData.词句信息.词句明细.Count != wordContext1.ItemCount)
                {
                    wordContext1.ItemCount = wordData.词句信息.词句明细.Count;
                }

                int i = 0;
                foreach (JReportWordSection wordSection in wordData.词句信息.词句明细)
                {
                    string sectionName = wordSection.段落名称;
                    string displyName = wordSection.段落名称;

                    if (_templateSection != null)
                    {
                        int index = _templateSection.段落关联信息.FindIndex(T => T.报告段落名 == wordSection.段落名称);
                        if (index >= 0)
                        {
                            string sectionAlias = _templateSection.段落关联信息[index].段落显示名;

                            if (string.IsNullOrEmpty(sectionAlias) == false)
                            {
                                displyName = sectionAlias;
                            }
                        }
                    }

                    WordContext.RichTextItem rti = wordContext1[i];
                    rti.ImageIndex = 2;
                    rti.Tag = sectionName;
                    rti.HeadCaption = displyName;
                    rti.Text = wordSection.段落内容;

                    rti.Selected = false;

                    i = i + 1;
                }
 
            }
        }
                 
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Node == null) return;

                TreeNode expNode = e.Node;

                if (expNode.Tag is ReportWordsClassData)
                {
                    //读取下级分类中的词句
                    foreach (TreeNode tnSub in expNode.Nodes)
                    {
                        BindWordItem(tnSub);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void DoActions(EventActionReleation ea, object sender)
        {
            try
            {
                base.DoBindActions(ea, sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
                 
        private BizDataItems _selWordDatas = null;
        private void WordContext_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selWordDatas != null) _selWordDatas.Clear();

                //写入选择词句
                if (wordContext1.SelectedItem == null) return;

                string sectionName = wordContext1.SelectedItem.Tag;

 
                if (_selWordDatas == null) _selWordDatas = new BizDataItems();

                BizDataItem bi = new BizDataItem();
                bi.Add("sectionname", sectionName);
                if (string.IsNullOrEmpty(wordContext1.SelectedItem.SelText))
                {
                    bi.Add("text", wordContext1.SelectedItem.Text);
                    bi.Add("formattext", wordContext1.SelectedItem.Rtf);
                }
                else
                {
                    bi.Add("text", wordContext1.SelectedItem.SelText);
                    bi.Add("formattext", wordContext1.SelectedItem.SelRtf);
                }
                 
                _selWordDatas.Add(bi);

                DoActions(_designEvents[WordProviderEventDefine.WriteWord], sender);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //写入配套词句
                if (_selWordDatas != null) _selWordDatas.Clear();
                 
                if (treeView1.SelectedNode == null) return;

                if (treeView1.SelectedNode.Tag is ReportWordsClassData) return;

                ReportWordsInfoData wordData = treeView1.SelectedNode.Tag as ReportWordsInfoData;
                if (wordData == null)
                {
                    MessageBox.Show("无效词句内容数据。", "提示");
                    return;
                }
 

                if (_selWordDatas == null) _selWordDatas = new BizDataItems();

                if (wordData.词句信息.词句类型 == (int)ReportWordType.rwtFree)
                {
                    foreach (JReportWordSection wordSection in wordData.词句信息.词句明细)
                    {
                        BizDataItem bi = new BizDataItem();
                        bi.Add("sectionname", wordSection.段落名称);
                        bi.Add("text", wordSection.段落内容);
                        bi.Add("formattext", wordSection.段落格式);

                        _selWordDatas.Add(bi);
                    }
                }

                DoActions(_designEvents[WordProviderEventDefine.WriteWord], sender);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //写入修改后的配套词句
                if (_selWordDatas != null) _selWordDatas.Clear();

                if (treeView1.SelectedNode == null) return;

                if (treeView1.SelectedNode.Tag is ReportWordsClassData) return;

                ReportWordsInfoData wordData = treeView1.SelectedNode.Tag as ReportWordsInfoData;
                if (wordData == null)
                {
                    MessageBox.Show("无效词句内容数据。", "提示");
                    return;
                }

                if (_selWordDatas == null) _selWordDatas = new BizDataItems();

                if (wordData.词句信息.词句类型 == (int)ReportWordType.rwtFree)
                {
                    foreach (WordContext.RichTextItem rti in wordContext1.Items)
                    {
                        if (rti.Tag.ToString() == "共用词句") continue;

                        BizDataItem bi = new BizDataItem();
                        bi.Add("sectionname", rti.Tag.ToString());
                        bi.Add("text", rti.Text);
                        bi.Add("formattext", rti.Rtf);

                        _selWordDatas.Add(bi);
                    }
                }

                DoActions(_designEvents[WordProviderEventDefine.WriteWord], sender);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
