using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.BusinessBase
{
    static public class ImageEx
    {
        static public Image LoadFile(string imgFile)
        {
            using (Image img = Image.FromFile(imgFile))
            {
                return new Bitmap(img);
            }

        }


    }
}
