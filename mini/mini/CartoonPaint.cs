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
    public partial class CartoonPaint : Form
    {
        
        Image<Bgr, byte> painted;
        Image<Gray, byte> img;
        public CartoonPaint(string loc)
        {   

            InitializeComponent();
            painted = new Image<Bgr, byte>(loc);
            img = new Image<Gray, Byte>(Properties.Resources.Rose_Amber_Flush_20070601);
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            double th = 30;
            Image<Gray, byte> input = new Image<Gray, byte>(img.Width + 2, img.Height + 2 );
          //  transferring to bigger padded img - "Temp"
            for (int i = 0; i < img.Height; i++)
                for (int j = 0; j < img.Width; j++)
                {
                    input.Data[i + 1, j + 1,0] = img.Data[i, j,0];
                            //input.Data[i + 1, j + 1,0] = input.Data[i, j, 0];
                            //input.Data[i + 1, j + 1, 1] = input.Data[i, j, 1];
                            //input.Data[i + 1, j + 1, 2] = input.Data[i, j, 2];
            
                }
            //finding edges and replacing in painted image

            for (int i=1 ; i < input.Height-1;i++)
                for (int j = 1; j < input.Width-1; j++) 
               {
                    //finding left-right gradient
                   if (Math.Abs(input.Data[i - 1, j, 0] - input.Data[i + 1, j, 0]) >= th)
                   {
                     painted.Data[i-1, j-1, 0] = 0;
                     painted.Data[i-1, j-1, 1] = 0;
                     painted.Data[i-1, j-1, 2] = 0;
                   }
                 //finding top-bottom gradient
                   if (Math.Abs(input.Data[i, j - 1, 0] - input.Data[i, j + 1, 0]) >= th)
                   {
                       painted.Data[i - 1, j - 1, 0] = 0;
                       painted.Data[i - 1, j - 1, 1] = 0;
                       painted.Data[i - 1, j - 1, 2] = 0;
                   }
                    //diagonal gradient [NW-SE]
                   if (Math.Abs(input.Data[i - 1, j - 1, 0] - input.Data[i + 1, j + 1, 0]) >= th)
                   {
                       painted.Data[i - 1, j - 1, 0] = 0;
                       painted.Data[i - 1, j - 1, 1] = 0;
                       painted.Data[i - 1, j - 1, 2] = 0;

                   }
                    //diagonal gradient [NE-SW]
                   if (Math.Abs(input.Data[i + 1, j - 1, 0] - input.Data[i - 1, j + 1, 0]) >= th)
                   {
                       painted.Data[i - 1, j - 1, 0] = 0;
                       painted.Data[i - 1, j - 1, 1] = 0;
                       painted.Data[i - 1, j - 1, 2] = 0;

                   }
               }
            result.Image = painted;
        }
    }
}
