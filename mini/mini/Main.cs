using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace mini
{

    public partial class Main : Form
    {
        string Chosen_File = "";

        List<Image<Bgr, Byte>> arr = new List<Image<Bgr, Byte>>();
        List<Image<Bgr, Byte>> out_arr = new List<Image<Bgr, Byte>>();
        Capture _capture;
        Image<Bgr, byte> img;
        Image<Bgr, byte> painted;

        public Main()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {

            openFD.Title = "Insert an Image";
            openFD.FileName = "";
            // openFD.Filter = " TIFF Images|*.tif|JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp|PNG Images|*.png|PICT Images|*.pct";
            if (openFD.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Choose image to proceed");
            }
            else
            {
                Chosen_File = openFD.FileName;
                Image<Bgr, byte> img = new Image<Bgr, byte>(Chosen_File);
                Original.Image = img;
            }
        }



        //-------------------------------- Timer Function to extract----------------------------------
        private void My_Timer_Tick(object sender, EventArgs e)
        {
            // string OutFileLocation = "D:\\IIITD\\Sem5\\IA\\IA mini";
            try
            {
                arr.Add(_capture.QueryFrame().Copy());
                // _capture.QueryFrame().Save(OutFileLocation + "\\" + "op" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpg");

            }
            catch (NullReferenceException n)
            {
            }


        }
        //------------------------------OIL PAINTING---------------------
       
        
        private void oil_paint()
        {
            int radius = Convert.ToInt32(this.txt_r.Text);
            float intensity = (float)Convert.ToDecimal(this.txt_l.Text);
            for (int q = 0; q < arr.Count; q++)
            {
                img = arr.ElementAt(q);


                int i, j;
                Image<Bgr, Byte> input = new Image<Bgr, Byte>(img.Width + radius, img.Height + radius);

                //transferring to bigger(padded) image :  "input"
                for (i = 0; i < img.Height; i++)
                {
                    for (j = 0; j < img.Width; j++)
                    {
                        if ((i + radius < input.Height) && (i + radius >= 0) && (j + radius < input.Width) && (j + radius >= 0))
                        {
                            input.Data[i + radius, j + radius, 0] = img.Data[i, j, 0];
                            input.Data[i + radius, j + radius, 1] = img.Data[i, j, 1];
                            input.Data[i + radius, j + radius, 2] = img.Data[i, j, 2];
                        }
                    }
                }
                Image<Bgr, Byte> convolve = new Image<Bgr, Byte>(img.Width + radius, img.Height + radius);
                Image<Bgr, Byte> output = new Image<Bgr, Byte>(img.Width, img.Height);
                int ycount;
                int xcount = radius;
                int x, sum_r = 0, sum_g, sum_b;
                int max = 0;
                int maxat;
                int y;
                int[,] temp = new int[(2 * radius) + 1, (2 * radius) + 1];
                while (xcount < convolve.Height - radius)
                {
                    ycount = radius;
                    while (ycount < convolve.Width - radius)
                    {
                        int[] counter = new int[(int)intensity];
                        for (x = -radius; x <= radius; x++)
                        {
                            for (y = -radius; y <= radius; y++)
                            {
                                if ((xcount + x < input.Height) && (xcount + x >= 0) && (ycount + y < input.Width) && (ycount + y >= 0))
                                {

                                    temp[x + radius, y + radius] = (int)(((input.Data[xcount + x, ycount + y, 0] + input.Data[xcount + x, ycount + y, 1] + input.Data[xcount + x, ycount + y, 2]) / (3.0F)) * (intensity / 255));
                                    if ((temp[x + radius, y + radius] >= 0) && (temp[x + radius, y + radius] < counter.Length))
                                        counter[temp[x + radius, y + radius]]++;
                                }
                            }
                        }
                        max = counter[0];
                        maxat = 0;
                        for (x = 0; x < counter.Length; x++)
                        {
                            if (counter[x] > max)
                            {
                                max = counter[x];
                                maxat = x;
                            }
                        }

                        sum_r = 0;
                        sum_g = 0;
                        sum_b = 0;
                        for (x = -radius; x <= radius; x++)
                        {
                            for (y = -radius; y <= radius; y++)
                            {
                                if (temp[x + radius, y + radius] == maxat)
                                {
                                    if ((xcount + x < input.Height) && (xcount + x >= 0) && (ycount + y < input.Width) && (ycount + y >= 0))
                                    {
                                        sum_r = sum_r + input.Data[xcount + x, ycount + y, 0];
                                        sum_g = sum_g + input.Data[xcount + x, ycount + y, 1];
                                        sum_b = sum_b + input.Data[xcount + x, ycount + y, 2];
                                    }
                                }
                            }
                        }
                        if (max > 0)
                        {
                            byte t = (byte)(sum_r / max);
                            if (t < 0)
                                convolve.Data[xcount, ycount, 0] = (byte)0;
                            else if (t > 255)
                                convolve.Data[xcount, ycount, 0] = (byte)255;
                            else
                            {
                                convolve.Data[xcount, ycount, 0] = (byte)(t);

                            }
                            if (sum_g / max < 0)
                                convolve.Data[xcount, ycount, 1] = (byte)0;
                            else if (sum_g / max > 255)
                                convolve.Data[xcount, ycount, 1] = (byte)255;
                            else
                                convolve.Data[xcount, ycount, 1] = (byte)(sum_g / max);
                            if (sum_b / max < 0)
                                convolve.Data[xcount, ycount, 2] = (byte)0;
                            else if (sum_b / max > 255)
                                convolve.Data[xcount, ycount, 2] = (byte)255;
                            else
                                convolve.Data[xcount, ycount, 2] = (byte)(sum_b / max);
                        }
                        ycount++;
                    }
                    xcount++;
                }
                for (i = 0; i < output.Height; i++)
                {
                    for (j = 0; j < output.Width; j++)
                    {
                        if ((i + radius < convolve.Height) && (i + radius >= 0) && (j + radius < convolve.Width) && (j + radius >= 0))
                        {
                            output.Data[i, j, 0] = convolve.Data[i + radius, j + radius, 0];
                            output.Data[i, j, 1] = convolve.Data[i + radius, j + radius, 1];
                            output.Data[i, j, 2] = convolve.Data[i + radius, j + radius, 2];
                        }
                    }
                }
               
                out_arr.Add(output);
                //    out_arr[q].Save(OutFileLocation + "\\" + "op" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpg");
                // _capture.QueryFrame().Save(OutFileLocation + "\\" + "op" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpg");
            }

        
        }

        
        // ----------------------------- COMBINING FRAMES --------------------------------
        private void join()
        {

            try
            {
                //VideoWriter output = new VideoWriter(@"C:\\pics\\result.avi", (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC), (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS), (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH), (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT), true);

                //    "C:\\pics\\result.avi"
                VideoWriter output3 = new VideoWriter("D:\\IIITD\\Sem5\\IA\\IA mini\\result.avi", 29, 320, 240, true);
                for (int j = 0; j < out_arr.Count; j++)
                    output3.WriteFrame(out_arr.ElementAt(j));
            }
            catch (NullReferenceException en)
            {
            }


        } 
        
        //----------------------------------- button oil paint------------------------------------------
        private void btn_paint_Click(object sender, EventArgs e)
        {


            //     _capture = new Capture("C:\\pics\\main.wmv");

            _capture = new Capture("D:\\IIITD\\Sem5\\IA\\IA mini\\main.wmv");

            //  string OutFileLocation = "C:\\pics\\effects";

            Timer My_Timer = new Timer();
            My_Timer.Interval = 1000 / 29;
            My_Timer.Tick += new EventHandler(My_Timer_Tick);
            My_Timer.Start();
            oil_paint();
            join();
        }



        //----------------------- CARTOON EFFECT -------------------------------
        private void cartoon()
        { 
       
         double th = 20;
            
            List<Image<Bgr,byte>> painted ;
             oil_paint();
             painted=out_arr;
            for (int a = 0; a < arr.Count(); a++)
            {
                //  transferring to bigger padded img - "Temp"
                img = arr[a];
                Image<Gray, byte> input = new Image<Gray, byte>(img.Width + 2, img.Height + 2);
                for (int i = 0; i < img.Height; i++)
                    for (int j = 0; j < img.Width; j++)
                    {
                        input.Data[i + 1, j + 1, 0] = img.Data[i, j, 0];


                    }
                //finding edges and replacing in painted image

                for (int i = 1; i < input.Height - 1; i++)
                    for (int j = 1; j < input.Width - 1; j++)
                    {
                        //finding left-right gradient
                        if (Math.Abs(input.Data[i - 1, j, 0] - input.Data[i + 1, j, 0]) >= th)
                        {
                            painted[a].Data[i - 1, j - 1, 0] = 0;
                            painted[a].Data[i - 1, j - 1, 1] = 0;
                            painted[a].Data[i - 1, j - 1, 2] = 0;
                        }
                        //finding top-bottom gradient
                        if (Math.Abs(input.Data[i, j - 1, 0] - input.Data[i, j + 1, 0]) >= th)
                        {
                            painted[a].Data[i - 1, j - 1, 0] = 0;
                            painted[a].Data[i - 1, j - 1, 1] = 0;
                            painted[a].Data[i - 1, j - 1, 2] = 0;
                        }
                        //diagonal gradient [NW-SE]
                        if (Math.Abs(input.Data[i - 1, j - 1, 0] - input.Data[i + 1, j + 1, 0]) >= th)
                        {
                            painted[a].Data[i - 1, j - 1, 0] = 0;
                            painted[a].Data[i - 1, j - 1, 1] = 0;
                            painted[a].Data[i - 1, j - 1, 2] = 0;

                        }
                        //diagonal gradient [NE-SW]
                        if (Math.Abs(input.Data[i + 1, j - 1, 0] - input.Data[i - 1, j + 1, 0]) >= th)
                        {
                            painted[a].Data[i - 1, j - 1, 0] = 0;
                            painted[a].Data[i - 1, j - 1, 1] = 0;
                            painted[a].Data[i - 1, j - 1, 2] = 0;

                        }
                    }
                out_arr = painted;           
        }
        }




        private void btn_cartoon_Click(object sender, EventArgs e)
        {

            _capture = new Capture("D:\\IIITD\\Sem5\\IA\\IA mini\\main.wmv");

            //   string OutFileLocation = "C:\\pics\\effects";

            Timer My_Timer = new Timer();
            My_Timer.Interval = 1000 / 29;
            My_Timer.Tick += new EventHandler(My_Timer_Tick);
            My_Timer.Start();
            cartoon();
            join();
              //  result.Image = painted;
            }
        }

    }

     
    

