using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PxRT
{
    class UnsafePixelSorter
    {
        public unsafe static void SortWhole(PixelWrapper Image)
        {
            Pixel[] px = Image.FastGetPixels();
            Array.Sort(px);

            Image.FastSetPixels(px);

        }
    }
}
