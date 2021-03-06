﻿using System;
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
using System.Windows.Forms;

namespace mini
{
    public partial class OilPaint : Form
    {

        List<Image<Bgr, Byte>> arr = new List<Image<Bgr, Byte>>();
        List<Image<Bgr, Byte>> out_arr = new List<Image<Bgr, Byte>>();
       Capture _capture;
        Image<Bgr, byte> img;
        public OilPaint(string loc)
        {
  
            
                InitializeComponent();
               //img = new Image<Bgr, byte>(loc);
           // img = new Image<Bgr, Byte>(Properties.Resources.Rose_Amber_Flush_20070601);
        }

        private void My_Timer_Tick(object sender, EventArgs e)
        {
           // string OutFileLocation = "D:\\IIITD\\Sem5\\IA\\IA mini";
            //if (_capture.QueryFrame() != null)
            //
            try
            {
                arr.Add(_capture.QueryFrame().Copy());

              //  Result.Image = arr[0];
               // _capture.QueryFrame().Save(OutFileLocation + "\\" + "op" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpg");
                
            }
            catch(NullReferenceException n)
            {
               
            }
            //else
            //{ My_Timer.Stop(); }
        }
        private void btn_click(object sender, EventArgs e)
        {
            _capture = new Capture("C:\\pics\\main.wmv");
            string OutFileLocation = "C:\\pics\\effects";

            Timer My_Timer = new Timer();
            My_Timer.Interval = 1000 / 29;
            My_Timer.Tick += new EventHandler(My_Timer_Tick);
            My_Timer.Start();
            int radius = Convert.ToInt32(this.txt_r.Text);
            float intensity = (float)Convert.ToDecimal(this.txt_l.Text);
            for (int q= 0; q < arr.Count; q++)
            {
                img = arr.ElementAt(q);

                
                int  i,j;
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
                //this.Result.Image = output;
                out_arr.Add(output);
                out_arr[q].Save(OutFileLocation + "\\" + "op" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpg");
               // _capture.QueryFrame().Save(OutFileLocation + "\\" + "op" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpg");
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            try
            {
                //VideoWriter output = new VideoWriter(@"C:\\pics\\result.avi", (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FOURCC), (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS), (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH), (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT), true);
                VideoWriter output2 = new VideoWriter("C:\\pics\\original.avi", 29, 320, 240, true);
                for (i = 0; i < arr.Count; i++)
                    output2.WriteFrame(arr.ElementAt(i));
                VideoWriter output = new VideoWriter("C:\\pics\\result.avi", 29, 320, 240, true);
                for (i = 0; i < out_arr.Count; i++)
                    output.WriteFrame(out_arr.ElementAt(i));
            }
            catch (NullReferenceException en)
            {
            }
            
        }



        }
    }
