using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace zlMedimgSystem.BusinessBase
{
    public enum ImageOperType
    {
        iotCursor = 0,
        iotDrag = 1,
        iotZoom = 2,
        iotLight = 3,
        iotContrast = 4,
        iotRotate = 5
    }
    public partial class ImageEditor : UserControl
    {
        private ImageOperType _curOper = ImageOperType.iotCursor;
        public ImageEditor()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Size _imgArea = new Size(0, 0);
        private double _minRate = 0.1;
        private Image _imgSource = null;
        public Image Image
        {
            get { return pictureBox1.Image; }
            set
            {
                _zoomRate = 1;
                _initRate = 1;

                _light = 0;
                _contrast = 0;

                if (value == null) return;

                _imgSource = value.Clone() as Image;

                _imgArea = new Size(value.Width, value.Height);
                _minRate = ((double)50 / (double)value.Width);

                FullDisplay();

                pictureBox1.Image = value;
            }
        }


        public ImageOperType OperType
        {
            get { return _curOper; }
            set
            {
                if (_imgSource == null) return;

                _curOper = value;
            }
        }

        public void LoadImage(string file)
        {
            Image img = ImageEx.LoadFile(file);

            Image = img;
        }


        public void Restore()
        {
            _zoomRate = 1;

            _light = 0;
            _contrast = 0;

            Image = _imgSource;
        }


        private void FullDisplay()
        {
            if (_imgSource == null)
            {
                pictureBox1.Left = 3;
                pictureBox1.Top = 3;
                pictureBox1.Width = this.Width - 6;
                pictureBox1.Height = this.Height - 6;

                return;
            }

            double sourceRate = (double)_imgSource.Height / (double)_imgSource.Width;
            double controlRate = (double)this.Height / (double)this.Width;

            if (controlRate > sourceRate)
            {
                _zoomRate = (double)this.Width / (double)_imgSource.Width;
            }
            else
            {
                _zoomRate = (double)this.Height / (double)_imgSource.Height;
            }

            _initRate = _zoomRate;

            _imgArea.Width = (int)(_imgSource.Width * _zoomRate);
            _imgArea.Height = (int)(_imgSource.Height * _zoomRate);

            pictureBox1.Width = _imgArea.Width;
            pictureBox1.Height = _imgArea.Height;

            pictureBox1.Left = (this.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.Height - pictureBox1.Height) / 2;
        }

        private void ImageEditor_Resize(object sender, EventArgs e)
        {
            try
            {
                if (_initRate == _zoomRate)
                {
                    FullDisplay();
                }
            }
            catch { }
        }

        private bool _isMouseDown = false;
        private Point _mouseDownPoint = new Point(0, 0);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                if (_imgSource == null) return;

                _isMouseDown = true;
                _mouseDownPoint = new Point(e.X, e.Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_isMouseDown == false) return;

                _isMouseDown = false;
                _mouseDownPoint = new Point(0, 0);

                switch (_curOper)
                {
                    case ImageOperType.iotZoom:
                        _zoomRate = _curZoom;
                        break;

                    case ImageOperType.iotLight:
                        _light = _curLight;
                        break;

                    case ImageOperType.iotContrast:
                        _contrast = _curContrast;
                        break;

                    case ImageOperType.iotDrag:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Bitmap ImgLighten(Bitmap img, int light)
        {
            if (img == null) return null;

            try
            {
                int width = img.Width;
                int height = img.Height;

                BitmapData data = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;

                    int pix = 0;
                    int offset = data.Stride - width * 3;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的亮度
                            for (int i = 0; i < 3; i++)
                            {

                                pix = p[i] + light;

                                if (light < 0) p[i] = (byte)Math.Max(0, pix);
                                if (light > 0) p[i] = (byte)Math.Min(255, pix);

                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }

                img.UnlockBits(data);

                return img;
            }
            catch
            {
                return null;
            }

        }



        public static Bitmap ImgContrast(Bitmap img, int degree)
        {
            if (img == null)
            {
                return null;
            }

            try
            {

                double pixel = 0;
                double contrast = (120.0 + degree) / 120.0;

                contrast *= contrast;
                int width = img.Width;
                int height = img.Height;
                BitmapData data = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的对比度
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                p[i] = (byte)pixel;
                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }
                img.UnlockBits(data);
                return img;
            }
            catch
            {
                return null;
            }
        }


        private double _initRate = 1;
        private double _zoomRate = 1;
        private double _curZoom = 1;

        private int _light = 0;
        private int _curLight = 0;

        private int _contrast = 0;
        private int _curContrast = 0;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                switch (_curOper)
                {
                    case ImageOperType.iotCursor:
                        return;

                    case ImageOperType.iotLight:
                        if (_isMouseDown == false) return;

                        _curLight = _light + (e.X - _mouseDownPoint.X) / 5;

                        if (_curLight <= -255) _curLight = -255;
                        if (_curLight >= 255) _curLight = 255;

                        Bitmap lightBmp = _imgSource.Clone() as Bitmap;

                        if (_contrast != 0)
                        {
                            ImgContrast(lightBmp, _contrast);
                        }

                        pictureBox1.Image = ImgLighten(lightBmp, _curLight);

                        break;

                    case ImageOperType.iotContrast:
                        if (_isMouseDown == false) return;

                        _curContrast = _contrast + (e.X - _mouseDownPoint.X) / 5;

                        if (_curContrast <= -120) _curContrast = -120;
                        if (_curContrast >= 120) _curContrast = 120;

                        Bitmap contrastBmp = _imgSource.Clone() as Bitmap;

                        contrastBmp = ImgContrast(contrastBmp, _curContrast);

                        if (_light != 0)
                        {
                            ImgLighten(contrastBmp, _light);
                        }

                        pictureBox1.Image = contrastBmp;

                        break;

                    case ImageOperType.iotZoom:
                        if (_isMouseDown == false) return;

                        double distance = (e.X - _mouseDownPoint.X);
                        if (distance == 0) return;


                        _curZoom = _zoomRate + (distance / (double)100);

                        if (_curZoom <= _minRate) _curZoom = _minRate;

                        _imgArea.Width = (int)(pictureBox1.Image.Width * _curZoom);
                        _imgArea.Height = (int)(pictureBox1.Image.Height * _curZoom);

                        pictureBox1.Width = _imgArea.Width;
                        pictureBox1.Height = _imgArea.Height;


                        break;

                    case ImageOperType.iotDrag:
                        if (_isMouseDown == false) return;

                        int xPos = pictureBox1.Left + (e.X - _mouseDownPoint.X);
                        int yPos = pictureBox1.Top + (e.Y - _mouseDownPoint.Y);

                        pictureBox1.Location = new Point(xPos, yPos);

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            try
            {
                FullDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
