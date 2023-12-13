using System.Drawing;
using System.Drawing.Imaging;

namespace ImageBlur
{
    internal class ImageBlur
    {
        public static void Main(string[] args)
        {
            using Bitmap image = new Bitmap("..\\..\\..\\image.jpg");

            using Bitmap blurredImage = ApplyBlur(image); // 2) ApplyFilter

            blurredImage.Save("..\\..\\..\\blurred_image.jpg", ImageFormat.Jpeg); //6) out.jpg
        }

        public static Bitmap ApplyBlur(Bitmap image) // 2) ApplyFilter
        {
            Bitmap blurredImage = new Bitmap(image.Width, image.Height);

            double[,] blurFilter = { { 1.0 / 9.0, 1.0 / 9.0, 1.0 / 9.0 }, { 1.0 / 9.0, 1.0 / 9.0, 1.0 / 9.0 }, { 1.0 / 9.0, 1.0 / 9.0, 1.0 / 9.0 } };

            for (int i = 1; i < image.Width - 1; i++)
            {
                for (int j = 1; j < image.Height - 1; j++)
                {
                    double redComponent = 0;
                    double greenComponent = 0;
                    double blueComponent = 0;

                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            Color pixel = image.GetPixel(i + x, j + y);

                            redComponent += pixel.R * blurFilter[x + 1, y + 1];
                            greenComponent += pixel.G * blurFilter[x + 1, y + 1];
                            blueComponent += pixel.B * blurFilter[x + 1, y + 1];
                        }
                    }

                    blurredImage.SetPixel(i, j, Color.FromArgb((int)redComponent, (int)greenComponent, (int)blueComponent));
                }
            }

            return blurredImage;
        }
    }
}