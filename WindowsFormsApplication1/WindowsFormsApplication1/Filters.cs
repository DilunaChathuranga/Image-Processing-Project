using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace WindowsFormsApplication1
{
    class Filters
    {
        IplImage src;
        IplImage originalRed;
        IplImage originalGreen;
        IplImage originalBlue;
        IplImage resultedRed;
        IplImage resultedGreen;
        IplImage resultedBlue;
        IplImage processedImage;
        IplImage median;
        IplImage max;
        IplImage min;

        bool imageready = false;

        public bool LoadImage(string fname)
        {
            src = Cv.LoadImage(fname, LoadMode.Color);
            Cv.SaveImage("1.jpg", src);
            if (src != null)
                imageready = true;
            return imageready;
        }

        public void Extract()
        {
            System.Windows.Forms.MessageBox.Show(
                "Height: " + src.Height
                + "\nWidth: " + src.Width
                + "\nNo of Channels: " + src.NChannels);

        }

        public void Arithmetic()
        {
            originalRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            Cv.Split(src, originalRed, originalGreen, originalBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            processedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);



            for (int y = 1; y < src.Height - 1; y++)
            {

                double r = 0;
                double g = 0;
                double b = 0;

                for (int x = 1; x < src.Width - 1; x++)
                {
                    r += Cv.GetReal2D(originalRed, y - 1, x - 1);
                    r += Cv.GetReal2D(originalRed, y - 1, x);
                    r += Cv.GetReal2D(originalRed, y - 1, x + 1);
                    r += Cv.GetReal2D(originalRed, y, x - 1);
                    r += Cv.GetReal2D(originalRed, y, x);
                    r += Cv.GetReal2D(originalRed, y, x + 1);
                    r += Cv.GetReal2D(originalRed, y + 1, x - 1);
                    r += Cv.GetReal2D(originalRed, y + 1, x);
                    r += Cv.GetReal2D(originalRed, y + 1, x + 1);

                    g += Cv.GetReal2D(originalGreen, y - 1, x - 1);
                    g += Cv.GetReal2D(originalGreen, y - 1, x);
                    g += Cv.GetReal2D(originalGreen, y - 1, x + 1);
                    g += Cv.GetReal2D(originalGreen, y, x - 1);
                    g += Cv.GetReal2D(originalGreen, y, x);
                    g += Cv.GetReal2D(originalGreen, y, x + 1);
                    g += Cv.GetReal2D(originalGreen, y + 1, x - 1);
                    g += Cv.GetReal2D(originalGreen, y + 1, x);
                    g += Cv.GetReal2D(originalGreen, y + 1, x + 1);

                    b += Cv.GetReal2D(originalBlue, y - 1, x - 1);
                    b += Cv.GetReal2D(originalBlue, y - 1, x);
                    b += Cv.GetReal2D(originalBlue, y - 1, x + 1);
                    b += Cv.GetReal2D(originalBlue, y, x - 1);
                    b += Cv.GetReal2D(originalBlue, y, x);
                    b += Cv.GetReal2D(originalBlue, y, x + 1);
                    b += Cv.GetReal2D(originalBlue, y + 1, x - 1);
                    b += Cv.GetReal2D(originalBlue, y + 1, x);
                    b += Cv.GetReal2D(originalBlue, y + 1, x + 1);

                    r = (double)r / 9.0;
                    g = (double)g / 9.0;
                    b = (double)b / 9.0;

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);
                }
            }

            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, processedImage);
            Cv.SaveImage("2.jpg", processedImage);
        }

        public void Geometric()
        {
            originalRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            Cv.Split(src, originalRed, originalGreen, originalBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            processedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);



            for (int y = 1; y < src.Height - 1; y++)
            {

                for (int x = 1; x < src.Width - 1; x++)
                {
                    double r = 1;
                    double g = 1;
                    double b = 1;


                    r *= Cv.GetReal2D(originalRed, y - 1, x - 1);
                    r *= Cv.GetReal2D(originalRed, y - 1, x);
                    r *= Cv.GetReal2D(originalRed, y - 1, x + 1);
                    r *= Cv.GetReal2D(originalRed, y, x - 1);
                    r *= Cv.GetReal2D(originalRed, y, x);
                    r *= Cv.GetReal2D(originalRed, y, x + 1);
                    r *= Cv.GetReal2D(originalRed, y + 1, x - 1);
                    r *= Cv.GetReal2D(originalRed, y + 1, x);
                    r *= Cv.GetReal2D(originalRed, y + 1, x + 1);

                    g *= Cv.GetReal2D(originalGreen, y - 1, x - 1);
                    g *= Cv.GetReal2D(originalGreen, y - 1, x);
                    g *= Cv.GetReal2D(originalGreen, y - 1, x + 1);
                    g *= Cv.GetReal2D(originalGreen, y, x - 1);
                    g *= Cv.GetReal2D(originalGreen, y, x);
                    g *= Cv.GetReal2D(originalGreen, y, x + 1);
                    g *= Cv.GetReal2D(originalGreen, y + 1, x - 1);
                    g *= Cv.GetReal2D(originalGreen, y + 1, x);
                    g *= Cv.GetReal2D(originalGreen, y + 1, x + 1);

                    b *= Cv.GetReal2D(originalBlue, y - 1, x - 1);
                    b *= Cv.GetReal2D(originalBlue, y - 1, x);
                    b *= Cv.GetReal2D(originalBlue, y - 1, x + 1);
                    b *= Cv.GetReal2D(originalBlue, y, x - 1);
                    b *= Cv.GetReal2D(originalBlue, y, x);
                    b *= Cv.GetReal2D(originalBlue, y, x + 1);
                    b *= Cv.GetReal2D(originalBlue, y + 1, x - 1);
                    b *= Cv.GetReal2D(originalBlue, y + 1, x);
                    b *= Cv.GetReal2D(originalBlue, y + 1, x + 1);

                    r = (double)(Math.Pow(r, 1 / 9.0));
                    g = (double)(Math.Pow(g, 1 / 9.0));
                    b = (double)(Math.Pow(b, 1 / 9.0));

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);
                }
            }

            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, processedImage);
            Cv.SaveImage("3.jpg", processedImage);

        }

        public void Harmonic()
        {
            originalRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            Cv.Split(src, originalRed, originalGreen, originalBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            processedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);



            for (int y = 1; y < src.Height - 1; y++)
            {

                double r = 0;
                double g = 0;
                double b = 0;

                for (int x = 1; x < src.Width - 1; x++)
                {
                    r += 1 / Cv.GetReal2D(originalRed, y - 1, x - 1);
                    r += 1 / Cv.GetReal2D(originalRed, y - 1, x);
                    r += 1 / Cv.GetReal2D(originalRed, y - 1, x + 1);
                    r += 1 / Cv.GetReal2D(originalRed, y, x - 1);
                    r += 1 / Cv.GetReal2D(originalRed, y, x);
                    r += 1 / Cv.GetReal2D(originalRed, y, x + 1);
                    r += 1 / Cv.GetReal2D(originalRed, y + 1, x - 1);
                    r += 1 / Cv.GetReal2D(originalRed, y + 1, x);
                    r += 1 / Cv.GetReal2D(originalRed, y + 1, x + 1);

                    g += 1 / Cv.GetReal2D(originalGreen, y - 1, x - 1);
                    g += 1 / Cv.GetReal2D(originalGreen, y - 1, x);
                    g += 1 / Cv.GetReal2D(originalGreen, y - 1, x + 1);
                    g += 1 / Cv.GetReal2D(originalGreen, y, x - 1);
                    g += 1 / Cv.GetReal2D(originalGreen, y, x);
                    g += 1 / Cv.GetReal2D(originalGreen, y, x + 1);
                    g += 1 / Cv.GetReal2D(originalGreen, y + 1, x - 1);
                    g += 1 / Cv.GetReal2D(originalGreen, y + 1, x);
                    g += 1 / Cv.GetReal2D(originalGreen, y + 1, x + 1);

                    b += 1 / Cv.GetReal2D(originalBlue, y - 1, x - 1);
                    b += 1 / Cv.GetReal2D(originalBlue, y - 1, x);
                    b += 1 / Cv.GetReal2D(originalBlue, y - 1, x + 1);
                    b += 1 / Cv.GetReal2D(originalBlue, y, x - 1);
                    b += 1 / Cv.GetReal2D(originalBlue, y, x);
                    b += 1 / Cv.GetReal2D(originalBlue, y, x + 1);
                    b += 1 / Cv.GetReal2D(originalBlue, y + 1, x - 1);
                    b += 1 / Cv.GetReal2D(originalBlue, y + 1, x);
                    b += 1 / Cv.GetReal2D(originalBlue, y + 1, x + 1);

                    r = Cv.Round(9.0 / (double)r);
                    g = Cv.Round(9.0 / (double)g);
                    b = Cv.Round(9.0 / (double)b);

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);
                }
            }

            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, processedImage);
            Cv.SaveImage("4.jpg", processedImage);
        }

        public void ContraHarmonic()
        {
            originalRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            originalBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            Cv.Split(src, originalRed, originalGreen, originalBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            processedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);



            for (int y = 1; y < src.Height - 1; y++)
            {



                for (int x = 1; x < src.Width - 1; x++)
                {
                    //when Q value change contra harmonic functipon decide which noise should remove(salt,paper)
                    double Q = -2;

                    double r = 0;
                    double g = 0;
                    double b = 0;

                    double r1 = 0;
                    double g1 = 0;
                    double b1 = 0;

                    r += Math.Pow(Cv.GetReal2D(originalRed, y - 1, x - 1), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y - 1, x), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y - 1, x + 1), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y, x - 1), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y, x), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y, x + 1), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y + 1, x - 1), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y + 1, x), Q + 1);
                    r += Math.Pow(Cv.GetReal2D(originalRed, y + 1, x + 1), Q + 1);

                    g += Math.Pow(Cv.GetReal2D(originalGreen, y - 1, x - 1), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y - 1, x), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y - 1, x + 1), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y, x - 1), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y, x), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y, x + 1), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y + 1, x - 1), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y + 1, x), Q + 1);
                    g += Math.Pow(Cv.GetReal2D(originalGreen, y + 1, x + 1), Q + 1);

                    b += Math.Pow(Cv.GetReal2D(originalBlue, y - 1, x - 1), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y - 1, x), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y - 1, x + 1), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y, x - 1), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y, x), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y, x + 1), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y + 1, x - 1), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y + 1, x), Q + 1);
                    b += Math.Pow(Cv.GetReal2D(originalBlue, y + 1, x + 1), Q + 1);

                    //add

                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y - 1, x - 1), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y - 1, x), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y - 1, x + 1), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y, x - 1), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y, x), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y, x + 1), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y + 1, x - 1), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y + 1, x), Q);
                    r1 += Math.Pow(Cv.GetReal2D(originalRed, y + 1, x + 1), Q);

                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y - 1, x - 1), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y - 1, x), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y - 1, x + 1), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y, x - 1), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y, x), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y, x + 1), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y + 1, x - 1), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y + 1, x), Q);
                    g1 += Math.Pow(Cv.GetReal2D(originalGreen, y + 1, x + 1), Q);

                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y - 1, x - 1), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y - 1, x), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y - 1, x + 1), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y, x - 1), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y, x), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y, x + 1), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y + 1, x - 1), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y + 1, x), Q);
                    b1 += Math.Pow(Cv.GetReal2D(originalBlue, y + 1, x + 1), Q);


                    r = Cv.Round((double)r / (double)r1);
                    g = Cv.Round((double)g / (double)g1);
                    b = Cv.Round((double)b / (double)b1);

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);
                }
            }

            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, processedImage);
            Cv.SaveImage("5.jpg", processedImage);
        }

        public void Median()
        {
            median = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            //smooth func for median
            Cv.Smooth(src, median, SmoothType.Median, 3);//last parameter is kernal size
            Cv.SaveImage("median.jpg", median);

        }

        public void Max()
        {
            max = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            //Dilate func for max
            Cv.Dilate(src, max, null, 1);//last parameter is iteration.here here before last parameter is kernal size we don't use it
            Cv.SaveImage("max.jpg", max);

        }

        public void Min()
        {
            min = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            //Erode func for max
            Cv.Erode(src, min, null, 1);//last parameter is iteration.here before last parameter is kernal size. we don't use it
            Cv.SaveImage("min.jpg", min);

        }

    }
}
