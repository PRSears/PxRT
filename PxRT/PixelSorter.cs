using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PxRT
{

    /// <summary>
    /// Provides static methods for sorting pixels in a PixelWrapper object.
    /// </summary>
    class PixelSorter
    {
        public static void SortWhole(PixelWrapper Image)
        {
            List<Pixel> Sorted = Image.GetPixels();
            Sorted.Sort();

            Image.SetPixels(Sorted);
        }

        public static void SortVerticals(PixelWrapper Image)
        {
            List<Pixel> Unsorted = Image.GetPixels();
            Pixel[] Sorted = new Pixel[Unsorted.Count];

            for (int x = 0; x < Image.Width; x++)
            {
                List<Pixel> Col = new List<Pixel>();
                // Split out vertical column
                for (int y = 0; y < Image.Height; y++)
                {
                    Col.Add(Unsorted[(y * Image.Width) + x]);
                }
                Col.Sort();

                // Reconstruct 
                for (int y = 0; y < Col.Count; y++)
                {
                    Sorted[(y * Image.Width) + x] = Col[y];
                }
            }

            Image.SetPixels(Sorted.ToList());
        }

        public static void SortHorizontals(PixelWrapper Image)
        {
            List<Pixel> Unsorted = Image.GetPixels();
            Pixel[] Sorted = new Pixel[Unsorted.Count];

            for (int y = 0; y < Image.Height; y++)
            {
                List<Pixel> Row = new List<Pixel>();
                // Split out vertical column
                for (int x = 0; x < Image.Width; x++)
                {
                    Row.Add(Unsorted[(y * Image.Width) + x]);
                }
                Row.Sort();

                // Reconstruct 
                for (int x = 0; x < Row.Count; x++)
                {
                    Sorted[(y * Image.Width) + x] = Row[x];
                }
            }

            Image.SetPixels(Sorted.ToList());
        }

        public static void SortVerticalsBelowThreshold(PixelWrapper Image, byte threshold)
        {
            List<Pixel> Unsorted = Image.GetPixels();
            Pixel[] Sorted = Unsorted.ToArray();

            for (int x = 0; x < Image.Width; x++)
            {
                List<Pixel> Col = new List<Pixel>();

                // Split out vertical column
                for (int y = Image.Height-1; y >= 0; y--)
                {
                    Col.Add(Unsorted[(y * Image.Width) + x]);
                }
                int i = NextOverThreshold(Col, 0, Col.Count, threshold);
                int end = (i >= 0) ? i : Col.Count;

                Col.RemoveRange(end, Col.Count - end);
                Col.Sort();

                // Reconstruct 
                for (int y = Image.Height-1, j = 0; j < Col.Count ; y--, j++)
                {
                    Sorted[(y * Image.Width) + x] = Col[j];
                }
            }

            Image.SetPixels(Sorted.ToList());
        }

        public static void SortHorizontalsBelowThreshold(PixelWrapper Image, byte threshold)
        {
            List<Pixel> Unsorted = Image.GetPixels();
            Pixel[] Sorted = Unsorted.ToArray();

            for (int y = 0; y < Image.Height; y++)
            {
                List<Pixel> Row = new List<Pixel>();

                // NextOverThreshold returns -1 if no matching pixel is found
                // so set 'end' index to the first thresholded pixel if it's not -1, 
                // otherwise set it to the end of the row (Image.Width)
                int i = NextOverThreshold(Unsorted, (y * Image.Width), (y * Image.Width) + Image.Width, threshold);
                int end = (i >= 0) ? (i - (y * Image.Width)) : Image.Width; 

                // Split out vertical column
                for (int x = 0; x < end; x++)
                {
                    Row.Add(Unsorted[(y * Image.Width) + x]);
                }
                Row.Sort();

                // Reconstruct 
                for (int x = 0; x < Row.Count; x++)
                {
                    Sorted[(y * Image.Width) + x] = Row[x];
                }
            }

            Image.SetPixels(Sorted.ToList());
        }

        public static int NextOverThreshold(List<Pixel> pixels, int startIndex, int endIndex, byte threshold)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                if (pixels[i].Luminance > threshold)
                    return i;
            }
            return -1;
        }

        public static int NextOverThreshold(Pixel[] pixels, int startIndex, int endIndex, byte threshold)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                if (pixels[i].Luminance > threshold)
                    return i;
            }
            return -1;
        }
    }
}
