using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.Design
{
    [ToolboxItem(false)]
    public class BasePropertyWrapper: UserControl
    {
        private UserControl _ucWrapper = null;
        public BasePropertyWrapper(UserControl uc)
        {
            _ucWrapper = uc;
        }

         
        public new DockStyle Dock
        {
            get { return _ucWrapper.Dock; }
            set { _ucWrapper.Dock = value; }
        }

        public new  bool AllowDrop
        {
            get { return _ucWrapper.AllowDrop; }
            set { _ucWrapper.AllowDrop = value; }
        }

         
        public new AnchorStyles Anchor
        {
            get { return _ucWrapper.Anchor; }
            set { _ucWrapper.Anchor = value; }
        }
         
        public new bool AutoScroll
        {
            get { return _ucWrapper.AutoScroll; }
            set { _ucWrapper.AutoScroll = value; }
        }
         
        public new bool AutoSize
        {
            get { return _ucWrapper.AutoSize; }
            set { _ucWrapper.AutoSize = value; }
        }
         
        public new Size AutoScrollMargin
        {
            get { return _ucWrapper.AutoScrollMargin; }
            set { _ucWrapper.AutoScrollMargin = value; }
        }
         
        public new Size AutoScrollMinSize
        {
            get { return _ucWrapper.AutoScrollMinSize; }
            set { _ucWrapper.AutoScrollMinSize = value; }
        }
         
        public new AutoSizeMode AutoSizeMode
        {
            get { return _ucWrapper.AutoSizeMode; }
            set { _ucWrapper.AutoSizeMode = value; }
        }
         
        public new Image BackgroundImage
        {
            get { return _ucWrapper.BackgroundImage; }
            set { _ucWrapper.BackgroundImage = value; }
        }
         
        public new ImageLayout BackgroundImageLayout
        {
            get { return _ucWrapper.BackgroundImageLayout; }
            set { _ucWrapper.BackgroundImageLayout = value; }
        } 

        public new bool CausesValidation
        {
            get { return _ucWrapper.CausesValidation; }
            set { _ucWrapper.CausesValidation = value; }
        }
         
        public new Cursor Cursor
        {
            get { return _ucWrapper.Cursor; }
            set { _ucWrapper.Cursor = value; }
        }
         
        public new Point Location
        {
            get { return _ucWrapper.Location; }
            set { _ucWrapper.Location = value; }
        }
         
        public new Size MaximumSize
        {
            get { return _ucWrapper.MaximumSize; }
            set { _ucWrapper.MaximumSize = value; }
        }

         
        public new Size MinimumSize
        {
            get { return _ucWrapper.MinimumSize; }
            set { _ucWrapper.MinimumSize = value; }
        }
         
        public new Size Size
        {
            get { return _ucWrapper.Size; }
            set { _ucWrapper.Size = value; }
        }
         
        public new RightToLeft RightToLeft
        {
            get { return _ucWrapper.RightToLeft; }
            set { _ucWrapper.RightToLeft = value; }
        }


         
        public new object Tag
        {
            get { return _ucWrapper.Tag; }
            set { _ucWrapper.Tag = value; }
        }
         
        public new bool UseWaitCursor
        {
            get { return _ucWrapper.UseWaitCursor; }
            set { _ucWrapper.UseWaitCursor = value; }
        }

         
        public new string AccessibleDescription
        {
            get { return _ucWrapper.AccessibleDescription; }
            set { _ucWrapper.AccessibleDescription = value; }
        }
         
        public new string AccessibleName
        {
            get { return _ucWrapper.AccessibleName; }
            set { _ucWrapper.AccessibleName = value; }
        }

         
        public new AccessibleRole AccessibleRole
        {
            get { return _ucWrapper.AccessibleRole; }
            set { _ucWrapper.AccessibleRole = value; }
        }
         
        public new AutoValidate AutoValidate
        {
            get { return _ucWrapper.AutoValidate; }
            set { _ucWrapper.AutoValidate = value; }
        }
         
        public new bool TabStop
        {
            get { return _ucWrapper.TabStop; }
            set { _ucWrapper.TabStop = value; }
        }
         
        public new bool Visible
        {
            get { return _ucWrapper.Visible; }
            set { _ucWrapper.Visible = value; }
        }
         
        public new bool Enabled
        {
            get { return _ucWrapper.Enabled; }
            set { _ucWrapper.Enabled = value; }
        }
         
        public new Font Font
        {
            get { return _ucWrapper.Font; }
            set { _ucWrapper.Font = value; }
        }
         
        public new Padding Margin
        {
            get { return _ucWrapper.Margin; }
            set { _ucWrapper.Margin = value; }
        }
         
        public new Padding Padding
        {
            get { return _ucWrapper.Padding; }
            set { _ucWrapper.Padding = value; }
        }
         
        public new ControlBindingsCollection DataBindings
        {
            get { return _ucWrapper.DataBindings; }
        }
         
        public new ContextMenuStrip ContextMenuStrip
        {
            get { return _ucWrapper.ContextMenuStrip; }
            set { _ucWrapper.ContextMenuStrip = value; }
        }
    }
}
