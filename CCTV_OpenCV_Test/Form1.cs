using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace CCTV_OpenCV_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture();
            capture.Open(0);
            using (Mat image = new Mat())
            {
                while (true)
                {
                    if (!capture.Read(image))
                    {
                        Cv2.WaitKey();
                    }
                    if(image.Size().Width > 0 && image.Size().Height > 0)
                    {
                        Bitmap bitmap = BitmapConverter.ToBitmap(image);
                        pictureBox1.Image = bitmap;
                    }
                    if (Cv2.WaitKey(1) >= 0) break;
                }
            }
        }
    }
}
