using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.Words
{
    internal partial class WordContext : UserControl
    {

        public class RichTextItem
        {
            public delegate void EventSelectChanged(object sender, EventArgs e, RichTextItem selItem);

            public event EventHandler OnHeadClick;
            public event EventHandler OnTextChanged;
            public event EventSelectChanged OnSelectChanged;

            public Control Parent { get; set; }
            public string Key { get; set; }
            public Panel BackGround { get; set; }
            public Button Head { get; set; }
            public RichTextBox Editor { get; set; }
            public Splitter Spliter { get; set; }

            public string Tag { get; set; }

            public List<RichTextItem> Items { get; set; }

            private Color _backColor = Color.Transparent;
            public Color BackColor
            {
                get { return _backColor; }
                set
                {
                    _backColor = value;
                    BackGround.BackColor = _backColor;
                }
            }


            private Color _headBgColor = Color.Transparent;
            public Color HeaderBgColor
            {
                get { return _headBgColor; }
                set
                {
                    _headBgColor = value;
                    Head.BackColor = _headBgColor;
                }
            }

            private bool _selected = false;
            public bool Selected
            {
                get
                {
                    return _selected;
                }
                set
                {
                    _selected = value;

                    if (_selected == false)
                    {
                        Head.BackColor = _headBgColor;
                        BackGround.BackColor = _backColor;
                    }
                    else
                    {
                        BackGround.BackColor = SelColor;
                        Head.BackColor = SelColor;
                    }
                }
            }

            public Color SelColor { get; set; }

            private void DoEnterProcess(object sender, EventArgs e)
            {
                foreach(RichTextItem rti in Items)
                {
                    rti.Selected = false;
                }

                _selected = true;
                BackGround.BackColor = SelColor;
                Head.BackColor = SelColor;


                OnSelectChanged?.Invoke(sender, e, this); 
            }

            public RichTextItem(Control parent, bool visible = false)
            {
                Key = Guid.NewGuid().ToString("N");

                Parent = parent;

                Spliter = new Splitter();
                Spliter.Visible = false;

                BackGround = new Panel();
                BackGround.Visible = false;

                Head = new Button();
                Head.Width = _headWidth;
                Head.Visible = false;

                Editor = new RichTextBox();
                Editor.Visible = false;
                Editor.HideSelection = false;

                BackGround.Name = Key;


                parent.Controls.Add(Spliter);
                Spliter.Cursor = Cursors.SizeNS;
                Spliter.Dock = DockStyle.Top;
                Spliter.BringToFront();

                parent.Controls.Add(BackGround);
                BackGround.BorderStyle = BorderStyle.FixedSingle;
                BackGround.BackColor = Color.Silver;
                BackGround.Dock = DockStyle.Top;
                BackGround.BringToFront();

                BackGround.Left = -10000;
                BackGround.Top = -10000;

                BackGround.Enter += DoEnterProcess;

                BackGround.Controls.Add(Head);
                Head.Dock = DockStyle.Left;

                Head.ImageAlign = ContentAlignment.MiddleLeft;
                Head.TextAlign = ContentAlignment.MiddleLeft;
                Head.TextImageRelation = TextImageRelation.ImageBeforeText;

                Head.Click += DoHeadClick;

                BackGround.Controls.Add(Editor);
                Editor.BorderStyle = BorderStyle.None;
                Editor.BringToFront();
                Editor.Dock = DockStyle.Fill;

                Editor.TextChanged += DoTextChanged;

                Editor.Visible = visible;
                Head.Visible = visible;
                                
                BackGround.Visible = visible;
                Spliter.Visible = visible;
            }

            private void DoHeadClick(object sender, EventArgs e)
            {
                OnHeadClick?.Invoke(sender, e);
            }

            private void DoTextChanged(object sender, EventArgs e)
            {
                OnTextChanged?.Invoke(sender, e);
            }

            public bool Visible
            {
                get { return BackGround.Visible; }
                set
                {
                    Editor.Visible = value;
                    Head.Visible = value;
                    
                    
                    BackGround.Visible = value;
                    if (Spliter.Tag == null) Spliter.Visible = value;
                }
            }

            public int Width
            {
                get { return BackGround.Width; }
                set { BackGround.Width = value; }
            }

            public int Height
            {
                get { return BackGround.Height; }
                set
                { 
                    BackGround.Height = value; 
                }
            }

            public DockStyle Dock
            {
                get { return BackGround.Dock; }
                set { BackGround.Dock = value; }
            }

            public string HeadCaption
            {
                get { return Head.Text; }
                set { Head.Text = value; }
            }

            public string Text
            {
                get { return Editor.Text; }
                set { Editor.Text = value; }
            }

            public string Rtf
            {
                get { return Editor.Rtf; }
                set { Editor.Rtf = value; }
            }

            public string SelText
            {
                get { return Editor.SelectedText; }
                set { Editor.SelectedText = value; }
            }


            public string SelRtf
            {
                get { return Editor.SelectedRtf; }
                set { Editor.SelectedRtf = value; }
            }

            public int SelStart
            {
                get { return Editor.SelectionStart; }
                set { Editor.SelectionStart = value; }
            }

            public int SelLength
            {
                get { return Editor.SelectionLength; }
                set { Editor.SelectionLength = value; }
            }

            private int _headWidth = 40;
            public int HeadWidth
            {
                get { return _headWidth; }
                set
                {
                    _headWidth = value;
                    Head.Width = _headWidth;
                }
            }

            public Image HeadImage
            {
                get { return Head.Image; }
                set { Head.Image = value; }
            }

            public ImageList ImageList
            {
                get { return Head.ImageList; }
                set { Head.ImageList = value; }
            }

            public int ImageIndex
            {
                get { return Head.ImageIndex; }
                set { Head.ImageIndex = value; }
            }

            public ContentAlignment ImageAlign
            {
                get { return Head.ImageAlign; }
                set { Head.ImageAlign = value; }
            }

            public bool DisableSpliter
            {
                get { return Spliter.Visible; }
                set
                {
                    Spliter.Visible = !value;
                    Spliter.Tag = (!value) ? null : "N";
                }
            }

            public Color HeaderForceColor
            {
                get { return Head.ForeColor; }
                set { Head.ForeColor = value; }
            }

            public void Remove()
            {
                BackGround.Controls.Remove(Editor);
                BackGround.Controls.Remove(Head);

                Parent.Controls.Remove(Spliter);
                Parent.Controls.Remove(BackGround);

            }
        }

        public event EventHandler OnHeadClick;
        public event EventHandler OnEditorChanged;

        private List<RichTextItem> _items = null;
        private ImageList _imageList = null;
        public WordContext()
        {
            InitializeComponent();

            _items = new List<RichTextItem>();
        }

        public List<RichTextItem> Items
        {
            get { return _items; }
        }

        public int ItemCount
        {
            get { return _items.Count; }
            set
            {
                base.Visible = false;

                ClearItem();

                for(int i = 0; i < value; i ++)
                {
                    RichTextItem newItem = CreateItem(true);

                    if (i == 0) newItem.DisableSpliter = true;

                    _items.Add(newItem);
                }

                Relayout();

                if (_items.Count > 0)
                {
                    _items[_items.Count - 1].Dock = DockStyle.Fill;
                }

                base.Visible = _visible;
            }
        }

        private Color _headerBgColor = Color.Transparent;
        public Color HeadBgColor
        {
            get { return _headerBgColor; }
            set
            {
                _headerBgColor = value;

                foreach (RichTextItem rti in _items)
                {
                    rti.HeaderBgColor = _headerBgColor;
                }
            }
        }

        private Color _headForceColor = Color.Black;
        public Color HeadForceColor
        {
            get { return _headForceColor; }
            set
            {
                _headForceColor = value;

                foreach (RichTextItem rti in _items)
                {
                    rti.HeaderForceColor = _headForceColor;
                }
            }
        }

        private Color _backColor = Color.Transparent;
        public Color ItemBackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;

                foreach (RichTextItem rti in _items)
                {
                    rti.BackColor = _backColor;
                }
            }
        }

        private Color _selColor = Color.Yellow;
        public Color SelColor
        {
            get { return _selColor; }
            set { _selColor = value; }
        }

        private int _headWidth = 40;
        public int HeadWidth
        {
            get { return _headWidth; }
            set
            {
                _headWidth = value;
                foreach (RichTextItem rti in _items)
                {
                    rti.HeadWidth = _headWidth;
                }
            }
        }

        private int _headImageIndex = -1;
        public int HeadImageIndex
        {
            get { return _headImageIndex; }
            set
            {
                _headImageIndex = value;
                foreach (RichTextItem rti in _items)
                {
                    rti.ImageIndex = _headImageIndex;
                }
            }
        }

        private ContentAlignment _headImageAlign = ContentAlignment.MiddleLeft;
        public ContentAlignment HeadImageAlign
        {
            get { return _headImageAlign; }
            set
            {
                _headImageAlign = value;
                foreach (RichTextItem rti in _items)
                {
                    rti.ImageAlign = _headImageAlign;
                }
            }
        }
        
        public ImageList ImageList
        {
            get { return _imageList; }
            set
            {
                _imageList = value;

                foreach(RichTextItem rti in _items)
                {
                    rti.ImageList = _imageList;
                }
            }
        }

        private bool _visible = true;
        public new bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                base.Visible = _visible;
            }
        }

        public RichTextItem CreateItem(bool visible = false)
        {
            RichTextItem newItem = new RichTextItem(this, visible);

            newItem.ImageList = _imageList;
            newItem.ImageAlign = _headImageAlign;
            //newItem.HeadCaption = caption;
            //newItem.ImageIndex = imageIndex;
            newItem.HeadWidth = _headWidth;
            newItem.SelColor = _selColor;
            newItem.BackColor = _backColor;
            newItem.HeaderBgColor = _headerBgColor;
            newItem.HeaderForceColor = _headForceColor;
            newItem.Items = _items;

            newItem.OnHeadClick += OnHeadClick;
            newItem.OnTextChanged += OnEditorChanged;

            return newItem;
        }

        public RichTextItem AddItem(string caption, string value, int imageIndex)
        { 

            foreach (RichTextItem rti in _items)
            {
                rti.Dock = DockStyle.Top;
            }

            RichTextItem newItem = CreateItem();

            if (_items.Count <= 0) newItem.DisableSpliter = true;

            newItem.HeadCaption = caption;
            newItem.Text = value;
            newItem.ImageIndex = imageIndex; 

            _items.Add(newItem);
             
            
            
            Relayout();

            newItem.Visible = true;

            _items[_items.Count - 1].Dock = DockStyle.Fill; 

            return newItem; 

        }

        public RichTextItem this[int index]
        {
            get { return _items[index]; }
        }

        public void RemoveAt(int index)
        {
            _items[index].Remove();
            _items.RemoveAt(index);
        }

        public void ClearItem()
        {
            for(int i = _items.Count - 1; i >= 0; i --)
            {
                _items[i].Remove();
            }

            _items.Clear();
        }

        public RichTextItem SelectedItem
        {
            get
            {
                foreach(RichTextItem rti in _items)
                {
                    if (rti.Selected) return rti;
                }
                return null;
            }
        }

        private void Relayout()
        {
            if (_items.Count <= 0) return;

            int avgHeight = this.Height / _items.Count;

            foreach (RichTextItem rti in _items)
            {
                rti.Height = avgHeight;
            }
        }
   
    }
}
