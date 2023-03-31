using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Face_Recongnition_ID
{
    public partial class Form1 : Form
    {
        #region Variables
        int testid = 0;
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat Frame = new Mat();
        private bool facesDetectionEnabled = false;
        private bool eyeDetectionEnabled = false;
        private bool smileDetectionEnabled = false;
        CascadeClassifier faceCascadeClassifier = new CascadeClassifier("C:\\Users\\AMStudent\\source\\repos\\Face Recongnition ID\\Face Recongnition ID\\haarcascade_frontalface_alt.xml");
        CascadeClassifier eyeCascadeClassifier = new CascadeClassifier("C:\\Users\\AMStudent\\source\\repos\\Face Recongnition ID\\Face Recongnition ID\\haarcascade_eye.xml");
        CascadeClassifier smileCascadeClassifer = new CascadeClassifier("C:\\Users\\AMStudent\\source\\repos\\Face Recongnition ID\\Face Recongnition ID\\haarcascade_smile.xml");
        Image<Bgr, Byte> faceResult = null;
        Image<Bgr, Byte> eyeResult = null;
        Image<Bgr, Byte> smileResult = null;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        bool EnableSaveImage = false;
        /// this variable on the variable area 
        private static bool isTrained = false;
        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //Dispose of Capture if it was created before
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();

            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            //Step1. Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(Frame, 0);
                currentFrame = Frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);
            }


            //Step 2: Face Detection
            if (facesDetectionEnabled)
            {
                //Convert from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                Mat grayImage2 = new Mat();
                //Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                Rectangle[] faces = faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                Rectangle[] eyes = eyeCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                Rectangle[] smile = smileCascadeClassifer.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                //If faces detected, eyes detected, and smile detected
                if (faces.Length > 0)
                {

                    foreach (var face in faces)
                    {
                        //Draw square around each face
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);                                           

                        //Step 3: Add Person
                        //Assign the face to the picture Box face picDetection
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        picDetection.SizeMode = PictureBoxSizeMode.StretchImage;
                        picDetection.Image = resultImage.Bitmap;



                        if (EnableSaveImage)
                        {
                            //We will create a directory if does not exists!
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);

                            //we will save 10 images with dwlay a second for each image
                            Task.Factory.StartNew(() => {
                                for (int i = 0; i < 10; i++)
                                {
                                    //resize the image then saving it
                                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    Thread.Sleep(1000);
                                }

                            });

                        }

                        EnableSaveImage = false;

                        if (btnAddperson.InvokeRequired)
                        {
                            btnAddperson.Invoke(new ThreadStart(delegate {
                                btnAddperson.Enabled = true;
                            }));

                        }

                        //Step 5: Recongnize  the faces
                        if (isTrained)
                        {
                            Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);
                            pictureBox1.Image = grayFaceResult.Bitmap;
                            pictureBox2.Image = TrainedFaces[result.Label].Bitmap;
                            Debug.WriteLine(result.Label + ". " + result.Distance);

                            //Here results found Known faces
                            if (result.Label != -1 && result.Distance < 2000)
                            {
                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar);
                            }
                            //Here results did not found any known faces
                            else
                            {
                                CvInvoke.PutText(currentFrame, " ID Unknown", new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                            }

                        }
                    }
                } //Render the video capture into the Picture Box picCapture
                picCapture.Image = currentFrame.Bitmap;
            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrame != null)
                currentFrame.Dispose();

        }


        private void btnDetectface_Click(object sender, EventArgs e)
        {
            facesDetectionEnabled = true;
            eyeDetectionEnabled = true;
            smileDetectionEnabled = true;
        }

        private void btnAddperson_Click(object sender, EventArgs e)
        {

            btnAddperson.Enabled = false;
            EnableSaveImage = true;

        }

        private void btnTrainImages_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();

        }

        //Step 4: train Images .. we will use the saved images fromm previous example
        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, Byte> trainedImage = new Image<Gray, Byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);
                }

                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                    isTrained = true;
                    Debug.WriteLine(ImagesCount);
                    Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }


            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            //Search file to find Images that already Captured
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

            
        } 
    }
}
