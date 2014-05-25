using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.GPU;
using Emgu.CV.UI;
using System.Drawing.Imaging;
using System.Net;
using System.IO;

namespace WindowsFormsApplication2
{
    class Analyzer : FlowLayoutPanel
    {
        private ProgressBar bar;
        private Label label;
        public PictureBox pictureBox;
        private DateTime date;

        public Analyzer()
        {
            Size = new Size(50, 50);

            bar = new ProgressBar();
            bar.Size = new Size(50, 10);
            bar.Maximum = 100;

            label = new Label();
            label.Size = new Size(50, 10);

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(50, 30);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.LoadProgressChanged += this.pb_LoadProgressChanged;
            pictureBox.LoadCompleted += this.pb_LoadCompleted;
            pictureBox.Click += pb_Click;

            Controls.Add(pictureBox);
            Controls.Add(bar);
            Controls.Add(label);
        }

        public void LoadPicture()
        {
            date = DateTime.Now;

            if (!File.Exists(filename()))
            {
                pictureBox.LoadAsync("http://213.221.150.11:8882/record/current.jpg?counter=0");
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxTemp = new PictureBox();
            pictureBoxTemp.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxTemp.Image = pictureBox.Image;

            Form f = new Form();
            f.Controls.Add(pictureBoxTemp);
            f.Dock = DockStyle.Fill;
            f.Visible = true;
        }

        void pb_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label.Text = "";
            
            pictureBox.Image.Save(filename(), ImageFormat.Jpeg);

            //Analyze();
            AnalyzeTest();

            if (File.Exists(filename()))
            {
                pictureBox.Load(filename());
            }
            else
            {
                //Dispose();
            }

            BoxOriginal.Image = new Image<Bgr, Byte>(filename());
        }

        void pb_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label.Text = "Téléchargement...";
            bar.Value = e.ProgressPercentage;
        }

        public String filename()
        {
            String filename = String.Format(@"C:\temp\cam187\{0}.jpg", String.Format("{0:yyyyMdHHmmss}", date));
            return filename;
        }

        public Image<Bgr, Byte> Compare(Analyzer analyser)
        {
            try
            {
                if (analyser == null)
                {
                    return new Image<Bgr, Byte>(filename());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            if (!File.Exists(analyser.filename()))
            {
                return new Image<Bgr, Byte>(filename());
            }

            Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(filename());
            Image<Bgr, Byte> img2 = new Image<Bgr, Byte>(analyser.filename());
            Image<Bgr, Byte> diff = img1.AbsDiff(img2);
            diff = diff.ThresholdBinary(new Bgr(60, 60, 60), new Bgr(255, 255, 255));

            using (MemStorage storage = new MemStorage())
            {
                for (Contour<Point> contours = diff.Convert<Gray, Byte>().FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
                {
                    if (contours.Area > 10)
                    {
                        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);
                        diff.Draw(currentContour.BoundingRectangle, new Bgr(Color.Red), 2);
                    }
                }
            }

            return diff;
        }

        public Analyzer PreviousAnalyzer { get; set; }

        public void AnalyzeTest()
        {
            Image<Bgr, Byte> diff = Compare(PreviousAnalyzer);
            
            BoxDiff.Image = diff;
        }

        public ImageBox BoxOriginal { get; set; }

        public ImageBox BoxDiff { get; set; }
    }
}
