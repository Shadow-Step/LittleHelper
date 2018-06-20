using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImgRdr
{
    public class ImageReader
    {
        private static int temp = 0; //temp;
        private int alpha = 15;
        
        public List<Pair> FindImageOnScreen(Rectangle area, Bitmap example, int bias_y)
        {
            Bitmap image = new Bitmap(area.Width, area.Height);
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.CopyFromScreen(area.X,area.Y,0,0,image.Size);
            }
            return FindAllPairs(image,area, GetExampleColorList(example, bias_y));
        }
        public List<Pair> FindImageOnScreen(Rectangle area, string example, int bias_y, int alpha = 15)
        {
            this.alpha = alpha;
            Bitmap image = new Bitmap(area.Width, area.Height);
            Bitmap example_image = (Bitmap)Bitmap.FromFile(example);
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.CopyFromScreen(area.X, area.Y, 0, 0, image.Size);
            }
            return FindAllPairs(image, area, GetExampleColorList(example_image, bias_y));
        }
        public bool CheckExist(Rectangle area, string example)
        {
            Bitmap example_image = (Bitmap)Bitmap.FromFile(example);
            Bitmap image = new Bitmap(example_image.Width, example_image.Height);
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.CopyFromScreen(area.X, area.Y, 0, 0, image.Size);
            }
            int result = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (image.GetPixel(x, y) == example_image.GetPixel(x, y))
                        result++;
                }
            }
            int pixels = image.Width * image.Height;
            return result > (pixels * 0.80);
        }

        private List<Color> GetExampleColorList(Bitmap example,int bias_y = 0)
        {
            List<Color> color_list = new List<Color>(example.Width);
            for (int i = 0; i < example.Width; i++)
            {
                color_list.Add(example.GetPixel(i, bias_y));
            }
            return color_list;
        }
        private List<Pair> FindAllPairs(Bitmap image,Rectangle area, List<Color> color_list)
        {
            List<Pair> pairs = new List<Pair>();
            int step = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int r = Math.Abs(pixel.R - color_list[step].R);
                    int g = Math.Abs(pixel.G - color_list[step].G);
                    int b = Math.Abs(pixel.B - color_list[step].B);
                    if (r < alpha && g < alpha && b < alpha)
                    {
                        image.SetPixel(x, y, Color.Red);//temp
                        step++;
                        if(step >= color_list.Count * 0.80)
                        {
                            pairs.Add(new Pair((x - color_list.Count / 2) + area.X, y + area.Y));
                            step = 0;
                        }
                            
                    }
                    else
                    {
                        step = 0;
                    }
                }
            }
            image.Save($"img_{temp}.bmp"); // temp;
            temp++; // temp;
            return pairs;
        }
        
        private double Alpha(Color x)
        {
            return x.R + x.G + x.B;
        }
        
    }
}
