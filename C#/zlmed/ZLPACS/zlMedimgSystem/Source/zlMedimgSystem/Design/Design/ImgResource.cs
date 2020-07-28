using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Design
{

    static public class Img24Resource
    {
        static private ImageList _imgs = null;
        static frmImageResourceSelector _selector = null;
        static Img24Resource()
        {
            _imgs = new ImageList();
            _imgs.ImageSize = new Size(24, 24);
        }

        static public string ShowImgResourcesSelector(IWin32Window owner)
        {
            if (_selector == null) _selector = new frmImageResourceSelector();
            return _selector.ShowImageResourceSelector(owner);
        }

        static public Image LoadImg(string imgResourceName)
        {
            if (_imgs.Images.ContainsKey(imgResourceName) == false)
            {
                string imgFile = Dir.GetAppResourceDir() + @"\" + imgResourceName;
                if (File.Exists(imgFile) == false) return null;

                _imgs.Images.Add(imgResourceName, DesignHelper.LoadFile(imgFile));
            }

            if (_imgs.Images.ContainsKey(imgResourceName) == false) return null;

            return _imgs.Images[imgResourceName];
        }

        static public ImageList Imgs
        {
            get { return _imgs; }
        }
    }


    static public class Img32Resource
    {
        static private ImageList _imgs = null;
        static frmImageResourceSelector _selector = null;
        static Img32Resource()
        {
            _imgs = new ImageList();
            _imgs.ImageSize = new Size(32, 32);
        }

        static public string ShowImgResourcesSelector(IWin32Window owner)
        {
            if (_selector == null) _selector = new frmImageResourceSelector();
            return _selector.ShowImageResourceSelector(owner);
        }
        static public Image LoadImg(string imgResourceName)
        {
            if (_imgs.Images.ContainsKey(imgResourceName) == false)
            {
                string imgFile = Dir.GetAppResourceDir() + @"\" + imgResourceName;
                if (File.Exists(imgFile) == false) return null;

                _imgs.Images.Add(imgResourceName, DesignHelper.LoadFile(imgFile));
            }

            if (_imgs.Images.ContainsKey(imgResourceName) == false) return null;

            return _imgs.Images[imgResourceName];
        }

        static public ImageList Imgs
        {
            get { return _imgs; }
        }
    }


    static public class Img16Resource
    {
        static private ImageList _imgs = null;
        static frmImageResourceSelector _selector = null;
        static Img16Resource()
        {
            _imgs = new ImageList();
            _imgs.ImageSize = new Size(16, 16);
        }

        static public string ShowImgResourcesSelector(IWin32Window owner)
        {
            if (_selector == null) _selector = new frmImageResourceSelector();
            return _selector.ShowImageResourceSelector(owner);
        }
        static public Image LoadImg(string imgResourceName)
        {
            if (_imgs.Images.ContainsKey(imgResourceName) == false)
            {
                string imgFile = Dir.GetAppResourceDir() + @"\" + imgResourceName;
                if (File.Exists(imgFile) == false) return null;

                _imgs.Images.Add(imgResourceName, DesignHelper.LoadFile(imgFile));
            }

            if (_imgs.Images.ContainsKey(imgResourceName) == false) return null;

            return _imgs.Images[imgResourceName];
        }

        static public ImageList Imgs
        {
            get { return _imgs; }
        }
    }


    static public class BigImgResource
    { 
        static frmImageResourceSelector _selector = null;
        static BigImgResource()
        {            
        }

        static public string ShowImgResourcesSelector(IWin32Window owner)
        {
            if (_selector == null) _selector = new frmImageResourceSelector();
            return _selector.ShowImageResourceSelector(owner);
        }
        static public Image LoadImg(string imgResourceName)
        {
            using (Image img = Image.FromFile(Dir.GetAppResourceDir() + @"\" + imgResourceName))
            {
                return new Bitmap(img);
            }
        }
         
    }

}
