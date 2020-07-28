using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using DevExpress.XtraEditors;
using zlMedimgSystem.DataModel;
using System.IO;
using zlMedimgSystem.Services;
using zlMedimgSystem.BusinessBase;
using DevExpress.Utils.Drawing.Animation;

namespace zlMedimgSystem.BusinessBase.Controls
{

    public delegate void TileItemMouseEnter(TileItem mouseItem);

    [ToolboxBitmap(typeof(ImageView), "Resources.images.ico")]
    public partial class ImageView : UserControl
    {
     


        //**********************************************************************

        private int _imgViewCount = 8;


        public event TileItemClickEventHandler OnItemClick;
        public event TileItemClickEventHandler OnItemDblClick;
        public event TileItemClickEventHandler OnItemRightClick;
        public event TileItemMouseEnter OnItemMouseEnter;
        public event EventHandler OnItemMouseLeave;
        public event EventHandler OnViewerMouseLeave;

        public bool IsDesignModel = true;


        public int ViewCount
        {
            get { return _imgViewCount; }
            set { _imgViewCount = value; }
        }

        public ImageView()
        {
            InitializeComponent();
        }
                         
 

        delegate void DelegateAddError(string msg, TileImageInfo imgInfo);
        public void AddErrorImage(string msg, TileImageInfo imgInfo)
        {
            if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
            {
                DelegateAddError addErrProcess = new DelegateAddError(AddErrorImage);
                this.Invoke(addErrProcess, new object[] { msg, imgInfo });
            }
            else
            {
                TileItem ti = new TileItem();
                ti.ImageScaleMode = TileItemImageScaleMode.Stretch;
                ti.ItemSize = TileItemSize.Large;
                ti.Text = "";
                ti.Tag = imgInfo;

                TileItemElement tie = new TileItemElement();
                tie.Image = imageList2.Images[0];
                tie.ImageSize = new Size(24, 24);
                tie.ImageToTextAlignment = TileControlImageToTextAlignment.Left;
                tie.TextAlignment = TileItemContentAlignment.MiddleCenter;
                //tie.ImageAlignment = TileItemContentAlignment.Default;
                tie.Text = msg;

                ti.Elements.Add(tie);

                if (tileControl1.Groups.Count <= 0)
                {
                    TileGroup tg = new TileGroup();
                    tg.Text = "";

                    tileControl1.Groups.Add(tg);
                }

                tileControl1.Groups[0].Items.Insert(0, ti);
                //tileControl1.Groups[0].Items.Add(ti);
            }
        }

        public void Selected(int index)
        {
            if (tileControl1.Groups.Count <= 0) return;

            if (index < 0 || index >= tileControl1.Groups[0].Items.Count) return;

            tileControl1.SelectedItem = tileControl1.Groups[0].Items[index];
        }

        public void Selected(TileItem tileItem)
        {
            if (tileControl1.Groups.Count <= 0) return;
              
            tileControl1.SelectedItem = tileItem;
        }

        public void UpdateTileImage(TileItem tileItem, string imgFile)
        {
            if (tileItem == null)
            {
                tileItem = SelItem;
            }

            if (tileItem == null) return;

            tileItem.Image = ImageEx.LoadFile(imgFile);
        }

        public TileItem FindByImageId(string imageId)
        {
            if (tileControl1.Groups.Count <= 0) return null;

            foreach(TileItem tileItem in tileControl1.Groups[0].Items)
            {
                TileImageInfo imageInfo = tileItem.Tag as TileImageInfo;
                if (imageInfo == null) continue;

                if (imageInfo.MediaId == imageId) return tileItem;
            }

            return null;
        }

        delegate TileItem DelegateAddImage(TileImageInfo imgInfo);
        public TileItem AddImage(TileImageInfo imgInfo)
        {
            TileItem AddImageToTile(System.Drawing.Image img)
            {

                TileItem ti = new TileItem();
                ti.Image = img;
                ti.ImageScaleMode = TileItemImageScaleMode.Stretch;
                ti.ItemSize = TileItemSize.Large;
                ti.Text = "";
                ti.Tag = imgInfo;

                TileItemElement tie = new TileItemElement();
                tie.Image = imageList1.Images[0];
                tie.ImageSize = new Size(32, 32);
                tie.ImageAlignment = TileItemContentAlignment.TopRight;
                tie.Text = "";

                ti.Elements.Add(tie);

                if (imgInfo.IsKeyImage)
                {
                    TileItemElement tieKey = new TileItemElement();

                    tieKey.Image = imageList2.Images[1];
                    tieKey.Image.Tag = "lock";
                    tieKey.ImageSize = new Size(16, 16);
                    tieKey.ImageAlignment = TileItemContentAlignment.TopLeft;
                    tieKey.Text = "";

                    ti.Elements.Add(tieKey);

                }

                TileItemElement tieOrder = new TileItemElement();
                tieOrder.TextAlignment = TileItemContentAlignment.BottomLeft;
                tieOrder.Text = imgInfo.Order;


                ti.Elements.Add(tieOrder);

                if (tileControl1.Groups.Count <= 0)
                {
                    TileGroup tg = new TileGroup();
                    tg.Text = "";

                    tileControl1.Groups.Add(tg);
                }


                if (tileControl1.Groups[0].Items.Count >= _imgViewCount)
                {
                    tileControl1.Groups[0].Items.RemoveAt(0);
                }

                tileControl1.Groups[0].Items.Insert(0, ti);
                //tileControl1.Groups[0].Items.Add(ti);

                return ti;
            }

            if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
            {
                DelegateAddImage addImgProcess = new DelegateAddImage(AddImage);
                return this.Invoke(addImgProcess, new object[] { imgInfo }) as TileItem;
            }
            else
            {
                System.Drawing.Image img = null;
                //视频音频类型媒体加载判断处理
                if (imgInfo.MediaType == "视频")
                {
                    img = imageList3.Images[0];
                }
                else if (imgInfo.MediaType == "音频")
                {
                    img = imageList3.Images[1];
                }
                else
                {
                    img = ImageEx.LoadFile(imgInfo.File);
                }

                return AddImageToTile(img); 
            }
        }

        /// <summary>
        /// 设置关键标记
        /// </summary>
        /// <param name="ti"></param>
        public void SetLockTag(TileItem ti)
        {
            TileItemElement tie = new TileItemElement();

            tie.Image = imageList2.Images[1];
            tie.Image.Tag = "lock";
            tie.ImageSize = new Size(16, 16);
            tie.ImageAlignment = TileItemContentAlignment.TopLeft;
            tie.Text = "";
            tie.ImageBorder = TileItemElementImageBorderMode.None;


            ti.Elements.Add(tie);
        }

        /// <summary>
        /// 删除关键标记
        /// </summary>
        /// <param name="ti"></param>
        public void ClearLockTag(TileItem ti)
        {
            foreach (TileItemElement tie in ti.Elements)
            {
                if (tie.Image == null) continue;

                if (tie.Image.Tag != null && tie.Image.Tag.Equals("lock"))
                {
                    ti.Elements.Remove(tie);
                    return;
                }
            }
        }



        private int _lastLayoutCount = 0;
        private int _layoutArea = 0;
        public void RefreshImageRange()
        {
            int layoutCount = _imgViewCount;

            if (tileControl1.Groups.Count > 0 && tileControl1.Groups[0].Items.Count < _imgViewCount)
            {
                layoutCount = tileControl1.Groups[0].Items.Count;
            }

            if (_lastLayoutCount != layoutCount || _layoutArea != this.Width * this.Height)
            {
                
                AdjustImageLayout(layoutCount);

                _lastLayoutCount = layoutCount;
                _layoutArea = this.Width * this.Height;


            }
        }
 

        /// <summary>
        /// 计算图像布局
        /// </summary>
        /// <param name="imgCount"></param>
        private void AdjustImageLayout(int imgCount)
        {
            int vW = tileControl1.Width - 80;
            int vH = tileControl1.Height - 40;

            if (vW <= 20) vW = 40;
            if (vH <= 20) vH = 40;

            if (vW <= 0 || vH <= 0) return;

            int maxBase = imgCount / 2;
            int col = 0;
            int row = 0;
            int cArea = 0;
            int cW = 0;
            int cH = 0;
            int itemSize = 0;
            int cWidth = 0;
            int cHeight = 0;

            for (int i = 1; i <= maxBase + 1; i++)//行
            {
                for (int j = 1; j <= maxBase + 1; j++)//列
                {
                    if (i * j < imgCount) continue;

                    cW = vW / j;
                    cH = vH / i;

                    if (((cW > cH) ? cH : cW) * 2 > cArea && (((cW > cH) ? cH : cW) >= itemSize))
                    {
                        cArea = ((cW > cH) ? cH : cW) * 2;// cW * cH;
                        col = j;
                        row = i;

                        cWidth = cW;
                        cHeight = cH;

                        itemSize = (cW > cH) ? cH : cW;
                    }
                }
            }

            //补充最后两种形式
            //1*x
            cW = vW / imgCount;
            cH = vH / 1;

            if (((cW > cH) ? cH : cW) * 2 > cArea && (((cW > cH) ? cH : cW) >= itemSize))
            {
                cArea = ((cW > cH) ? cH : cW) * 2;// cW * cH;
                col = imgCount;
                row = 1;

                cWidth = cW;
                cHeight = cH;

                itemSize = (cW > cH) ? cH : cW;
            }

            //x*1
            cW = vW / 1;
            cH = vH / imgCount;

            if (((cW > cH) ? cH : cW) * 2 > cArea && (((cW > cH) ? cH : cW) >= itemSize))
            {
                cArea = ((cW > cH) ? cH : cW) * 2;// cW * cH;
                col = 1;
                row = imgCount;

                cWidth = cW;
                cHeight = cH;

                itemSize = (cW > cH) ? cH : cW;
            }

            //if (row == 1 && cWidth > cHeight && vH < cWidth)
            //{
            //    itemSize = vH;
            //}
            //else if (col == 1 && cWidth < cHeight && vW <= cHeight )
            //{
            //    itemSize = vW;
            //}

            if (itemSize != vW && (itemSize + 2) * col > vW)
            {
                itemSize = (vW / col) - 4;
            }

            if (itemSize != vH && (itemSize + 6) * row > vH)
            {
                itemSize = (vH / row) - 8;
            }

            tileControl1.ItemSize = itemSize / 2;

            tileControl1.ColumnCount = col * 2;

            tileControl1.Refresh();

        }


        private void ImageControl_Resize(object sender, EventArgs e)
        {
            try
            {
                RefreshImageRange();
            }
            catch { }

        }
 
 
        /// <summary>
        /// 当前选择的Item
        /// </summary>
        public TileItem SelItem
        {
            get { return tileControl1.SelectedItem; }
        }

        /// <summary>
        /// 当前勾选的Item
        /// </summary>
        public List<TileItem> CheckItems
        {
            get { return tileControl1.GetCheckedItems(); }
        }

        public TileItemCollection Items
        {
            get
            {
                if (tileControl1.Groups.Count <= 0) return null;

                return tileControl1.Groups[0].Items;
            }
        }

        public void Clear()
        {
            if (tileControl1.Groups.Count <= 0) return;

            //foreach(TileGroup tg in tileControl1.Groups)
            //{
            //    tg.Items.Clear();
            //}

            tileControl1.Groups.Clear();
        }

        public void ReleaseCursor()
        {
            System.Windows.Forms.Cursor.Clip = new Rectangle(0, 0, 0, 0);
        }

        private void tileControl1_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                OnItemClick?.Invoke(sender, e);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tileControl1_ItemDoubleClick(object sender, TileItemEventArgs e)
        {
            try
            {
                OnItemDblClick?.Invoke(sender, e);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tileControl1_RightItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                OnItemRightClick?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
         
        private void tileControl1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (IsDesignModel) return;

                int scrollWidth = 0;

                if (((DevExpress.XtraEditors.ITileControl)tileControl1).ScrollBar.Visible)
                {
                    scrollWidth = ((DevExpress.XtraEditors.ITileControl)tileControl1).ScrollBar.Width;
                }

                Rectangle lockRang = new Rectangle(2, 2,
                                            tileControl1.ClientSize.Width - scrollWidth - 2,
                                            tileControl1.ClientSize.Height - 2);




                if (e.X <= lockRang.X
                    || e.Y <= lockRang.Y
                    || e.X >= lockRang.Width
                    || e.Y >= lockRang.Height)
                {
                    OnViewerMouseLeave?.Invoke(sender, e);
                    System.Windows.Forms.Cursor.Clip = new Rectangle(0, 0, 0, 0);
                }
                else
                {

                    System.Windows.Forms.Cursor.Clip = tileControl1.RectangleToScreen(lockRang);
                }


                Rectangle itemRang;
                TileItem ti = GetMouseItem(new Point(e.X, e.Y), out itemRang);

                if (ti != null)
                {
                    System.Windows.Forms.Cursor.Clip = new Rectangle(0, 0, 0, 0);

                    OnItemMouseEnter?.Invoke(ti);

                    Rectangle screenRang = tileControl1.RectangleToScreen(lockRang);
                    Point screenCursor = Cursor.Position;

                    //重新进行锁定
                    if (screenCursor.X > screenRang.X
                        && screenCursor.Y > screenRang.Y
                        && screenCursor.X < screenRang.Right
                        && screenCursor.Y < screenRang.Bottom)
                    {
                        System.Windows.Forms.Cursor.Clip = tileControl1.RectangleToScreen(lockRang);
                    }
                }
                else
                {
                    OnItemMouseLeave?.Invoke(sender, e);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Cursor.Clip = new Rectangle(0, 0, 0, 0);
                MsgBox.ShowException(ex, this);
            }
        }


        private TileItem GetMouseItem(Point mousePoint, out Rectangle itemRange)
        {
            itemRange = new Rectangle(0, 0, 0, 0);

            if (tileControl1.Groups.Count <= 0) return null;

            foreach (TileGroup tg in tileControl1.Groups)
            {
                if (tg.Items.Count <= 0) continue;

                foreach (TileItem ti in tg.Items)
                {
                    if (ti.Elements.Count <= 0) continue;

                    Rectangle rang = ((IAnimatedItem)ti.Elements[0]).AnimationBounds;

                    if (mousePoint.X >= rang.X + 2
                        && mousePoint.X <= rang.Right - 2
                        && mousePoint.Y >= rang.Y + 2
                        && mousePoint.Y <= rang.Bottom - 2)
                    {
                        itemRange = rang;
                        return ti;
                    }
                }
            }

            return null;
        }

    }
}
