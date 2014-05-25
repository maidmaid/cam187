using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.GPU;
using System.Diagnostics;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private DateTime date;
        private ImageBox ibxEdit;
        private ImageBox forgroundImageBox;
        private IBGFGDetector<Bgr> forgroundDetector;
        private String[] files;
        private int indexFiles;
        private Timer timerLocal;
        private String localPath;
        private Rectangle zoneDetection;

        public Form1()
        {
            InitializeComponent();

            // PictureBox original
            pbxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pbxOriginal.LoadCompleted += pbxOriginal_LoadCompleted;
            pbxOriginal.LoadProgressChanged += pbxOriginal_LoadProgressChanged;

            // ImageBox forground
            forgroundImageBox = new ImageBox();
            forgroundImageBox.Size = pbxOriginal.Size;
            forgroundImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            flowLayoutPanel.Controls.Add(forgroundImageBox);

            // ImageBox Edit
            ibxEdit = new ImageBox();
            //ibxEdit.Size = pbxOriginal.Size;
            ibxEdit.Size = new Size(800, 600);
            ibxEdit.SizeMode = PictureBoxSizeMode.Zoom;
            flowLayoutPanel.Controls.Add(ibxEdit);

            // FGDetector
            Emgu.CV.CvEnum.FORGROUND_DETECTOR_TYPE detectorType = FORGROUND_DETECTOR_TYPE.FGD;
            forgroundDetector = new FGDetector<Bgr>(detectorType);

            // Timer local
            timerLocal = new Timer();
            timerLocal.Tick += timer_Tick;
            timerLocal.Interval = 500;

            // Rectangle zone de détection
            zoneDetection = new Rectangle(new Point(0, 0), pbxOriginal.Size);
        }

        void pbxOriginal_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbOriginal.Value = e.ProgressPercentage;
        }

        private void LoadImage()
        {
            date = DateTime.Now;
            pbxOriginal.LoadAsync("http://213.221.150.11:8882/record/current.jpg?counter=0");
            //pbxOriginal.LoadAsync("http://213.221.150.11/record/current.jpg?counter=0");
        }

        private void pbxOriginal_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pbxOriginal.Image.Save(filename());

            Image<Bgr, Byte> diff = new Image<Bgr, Byte>(filename());

            // Dessine la zone de détection
            zoneDetection.Location = new Point(int.Parse(txtDetectionZoneX.Text), int.Parse(txtDetectionZoneY.Text));
            zoneDetection.Size = new Size(int.Parse(txtDetectionZoneW.Text), int.Parse(txtDetectionZoneH.Text));
            diff.Draw(zoneDetection, new Bgr(Color.Yellow), 1);

            #region Encadre les objets trouvés et dessine les infos
            double minArea = 200;
            double maxArea = 1000;
            double originalArea = pbxOriginal.Size.Width * pbxOriginal.Size.Height;
            Contour<Point> contours = Compare(filename());

            #region Rectangles contained
            List<Rectangle> containedKo = FilterContours(contours, zoneDetection, ZoneDetectorType.contains, 0, minArea);
            containedKo.AddRange(FilterContours(contours, zoneDetection, ZoneDetectorType.contains, maxArea, originalArea));
            List<Rectangle> containedOk = FilterContours(contours, zoneDetection, ZoneDetectorType.contains, minArea, maxArea);
            #endregion

            #region Rectangles intercepted
            List<Rectangle> interceptedKo = FilterContours(contours, zoneDetection, ZoneDetectorType.intersects, 0, minArea);
            interceptedKo.AddRange(FilterContours(contours, zoneDetection, ZoneDetectorType.intersects, maxArea, originalArea));
            List<Rectangle> interceptedOk = FilterContours(contours, zoneDetection, ZoneDetectorType.intersects, minArea, maxArea);
            #endregion

            #region Rectangles external
            List<Rectangle> externalKo = FilterContours(contours, zoneDetection, ZoneDetectorType.external, 0, minArea);
            externalKo.AddRange(FilterContours(contours, zoneDetection, ZoneDetectorType.external, maxArea, originalArea));
            List<Rectangle> externalOk = FilterContours(contours, zoneDetection, ZoneDetectorType.external, minArea, maxArea);
            #endregion

            #endregion

            #region Dessine
            //DrawInfosContours(diff, contours);
            DrawContours(diff, containedOk, Color.Green, 2);
            DrawContours(diff, containedKo, Color.Green, 1);
            DrawContours(diff, interceptedOk, Color.Orange, 2);
            DrawContours(diff, interceptedKo, Color.Orange, 1);
            DrawContours(diff, externalOk, Color.Red, 2);
            DrawContours(diff, externalKo, Color.Red, 1);
            #endregion

            #region Dessine test
            /*
            while (contours != null)
            {
                Console.WriteLine("a");
                try
                {
                    diff.Draw(contours.ApproxPoly(1).GetMinAreaRect(), new Bgr(Color.Red), 1);
                }
                catch (CvException exception) { }
                catch (StackOverflowException exception2) { }

                contours = contours.VNext;
            }
            */
            #endregion

            #region Export
            if (containedOk.Count > 0)
            {
                double rotate = double.Parse(txtRotate.Text);
                Rectangle crop = new Rectangle(int.Parse(txtCropX.Text), int.Parse(txtCropY.Text), int.Parse(txtCropW.Text), int.Parse(txtCropH.Text));

                Image<Bgr, Byte> exported = diff.Copy();
                exported.ROI = zoneDetection;
                exported = exported.Rotate(rotate, new Bgr(Color.Violet));
                exported.ROI = crop;
                exported.Save(filename("exported"));

                ImageBox ib = new ImageBox();
                ib.Image = exported;
                ib.SizeMode = PictureBoxSizeMode.Zoom;
                ib.Size = new Size(100, 100);
                ib.HorizontalScrollBar.Visible = false;
                ib.VerticalScrollBar.Visible = false;
                //flowLayoutEdit.Controls.Add(ib);
            }
            #endregion

            File.Delete(filename());

            // Affiche l'image de résultat
            ibxEdit.Image = diff;

            LoadImage();
        }

        private String filename(String subfolder = "")
        {
            String filename = String.Format(@"D:\Desktop\cam187\{0}\{1}.jpg", subfolder, String.Format("{0:yyyyMdHHmmssfff}", date));
            return filename;
        }

        public Contour<Point> CompareOld(String previousImage, String currentImage)
        {
            if (!File.Exists(previousImage))
            {
                return null;
            }

            Image<Bgr, Byte> img1 = new Image<Bgr, Byte>(previousImage);
            Image<Bgr, Byte> img2 = new Image<Bgr, Byte>(currentImage);
            Image<Bgr, Byte> diff = img1.AbsDiff(img2);
            diff = diff.ThresholdBinary(new Bgr(60, 60, 60), new Bgr(255, 255, 255));
            
            Image<Gray, Byte> diffGray = diff.Convert<Gray, Byte>();
            Contour<Point> contours = FindAllContours(diffGray);
            return contours;
        }

        private Contour<Point> Compare(String currentImage)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(currentImage);

            forgroundDetector.Update(image);
            forgroundImageBox.Image = forgroundDetector.BackgroundMask;

            Contour<Point> contours = FindAllContours(forgroundDetector.ForegroundMask);

            return contours;
        }

        private Contour<Point> FindAllContours(Image<Gray, Byte> image)
        {
            Emgu.CV.CvEnum.CHAIN_APPROX_METHOD approxMethod = CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE;
            Emgu.CV.CvEnum.RETR_TYPE retrievalMode = RETR_TYPE.CV_RETR_EXTERNAL;

            using (MemStorage storage = new MemStorage())
            {
                Contour<Point> contours = image.FindContours(approxMethod, retrievalMode, storage);
                return contours;
            }
        }

        private List<Rectangle> FilterContours(Contour<Point> contours, Rectangle zone, ZoneDetectorType type, double minArea, double maxArea = 800)
        {
            // Liste de rectangles filtrée
            List<Rectangle> filtered = new List<Rectangle>();

            // Parcourt tous les contours
            while (contours != null)
            {
                if (contours.Area >= minArea && contours.Area < maxArea)
                {
                    Rectangle rectangle = contours.BoundingRectangle;

                    switch (type)
                    {
                        // Recherche de rectanges contenus dans la zone de détection
                        case ZoneDetectorType.contains:
                            if (zone.Contains(rectangle))
                            {
                                filtered.Add(rectangle);
                            }
                            break;

                        // Recherche de rectanges en intersection avec la zone de détection
                        case ZoneDetectorType.intersects:
                            if (!zone.Contains(rectangle) && zone.IntersectsWith(rectangle))
                            {
                                filtered.Add(rectangle);
                            }
                            break;

                        // Recherche de rectanges extérieurs à la zone de détection
                        case ZoneDetectorType.external:
                            if (!zone.Contains(rectangle) && !zone.IntersectsWith(rectangle))
                            {
                                filtered.Add(rectangle);
                            }
                            break;
                    }
                }

                contours = contours.HNext;
            }

            return filtered;
        }

        enum ZoneDetectorType
        {
            intersects,
            contains,
            external
        }

        private void DrawInfosContours(Image<Bgr, Byte> image, Contour<Point> contours)
        {
            while (contours != null)
            {
                MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5);
                try
                {
                    image.Draw(contours.Area.ToString(), ref font, contours.BoundingRectangle.Location, new Bgr(Color.Blue));
                }
                catch (CvException e) { }
                catch (AccessViolationException e) { }

                contours = contours.HNext;
            }
        }

        private void DrawContours(Image<Bgr, Byte> image, List<Rectangle> rectangles, Color color, int thinkness)
        {
            foreach (Rectangle rectangle in rectangles)
            {
                image.Draw(rectangle, new Bgr(color), thinkness);
            }
        }

        private void StartLocal()
        {
            indexFiles = 0;
            files = Directory.GetFiles(localPath);

            timerLocal.Start();
        }

        private void StopLocal()
        {
            timerLocal.Stop();
        }

        private void StartWeb()
        {
            LoadImage();
        }

        private void StopWeb()
        {
            pbxOriginal.CancelAsync();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            /*
            String file = files[indexFiles];
            Image<Bgr, Byte> diff = new Image<Bgr, Byte>(file);

            pbxOriginal.Image = Image.FromFile(file);

            // Dessine la zone de détection
            diff.Draw(zoneDetection, new Bgr(Color.Green), 1);

            if (indexFiles != 0)
            {
                Contour<Point> contours = Compare(file);
                DrawContours(diff, contours, 10, Color.Red);
                
                // Véréfie si un objet trouvé est dans la zone de détection
                bool intersect = InZoneDetection(contours);
                Console.WriteLine(intersect);
            }

            ibxEdit.Image = diff;

            if (++indexFiles >= files.Length)
            {
                timerLocal.Stop();
            }
             * */
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (radLocal.Checked)
            {
                StopLocal();
            }
            else if (radWeb.Checked)
            {
                StopWeb();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (radLocal.Checked)
            {
                StartLocal();
            }
            else if (radWeb.Checked)
            {
                StartWeb();
            }
        }

        private void radLocal_CheckedChanged(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.SelectedPath = @"D:\Desktop\cam187\1";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                localPath = browser.SelectedPath;
            }
        }
    }
}
