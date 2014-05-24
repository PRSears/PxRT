using System;
using System.Drawing;
using System.Collections.Generic;


namespace PxRT
{
    class PixelWrapper
    {

        protected Bitmap Bmp;
        protected IntPtr Scan0ptr;
        protected System.Drawing.Imaging.BitmapData Data 
        {
            get; set; 
        }
        protected byte[] RawBytes
        { 
            get; set; 
        }
        protected int TotalBytes 
        { 
            get; set; 
        }
        protected bool Locked = false;

        public bool Unsafe = false;

        public string ImagePath
        {
            get;
            private set;
        }
        public int Stride
        {
            get
            {
                return Data.Stride;
            }
        }
        public int Width
        {
            get
            {
                return Bmp.Width;
            }
        }
        public int Height
        {
            get
            {
                return Bmp.Height;
            }
        }
        public int PixelCount
        {
            get
            {
                return (Width * Height);
            }
        }
        public int PixelSize
        {
            get
            {
                if (Data.PixelFormat.Equals(System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                    return 3;
                if (Data.PixelFormat.Equals(System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                    return 4;
                else
                    throw new ArgumentException("Formats other than 24bit per pixel RGB, and 32bpp ARGB are not currently supported.");

            }
        }

        public PixelWrapper(string pathToImage)
        {
            ImagePath = pathToImage;
            Load(ImagePath);
        }

        public PixelWrapper(string path, bool safe)
        {
            ImagePath = path;
            Unsafe = !safe;
        }

        public PixelWrapper(Image image)
        {
            Bmp = (Bitmap)image;
            Lock();
        }

        public PixelWrapper(Bitmap bitmap)
        {
            Bmp = bitmap;
            Lock();
        }

        public void Load(string pathToImage)
        {
            if (Locked) Unlock();
            Bmp = (Bitmap)Image.FromFile(pathToImage);
            Lock();
        }

        public void Save()
        {
            SaveAs(ImagePath);
        }

        public void SaveAs(string path)
        {
            this.Unlock();

            Bmp.Save(path);
        }

        /// <summary>
        /// Locks the bitmap data into memory as a byte array for faster pixel editing.
        /// </summary>
        public void Lock()
        {
            if (!Locked)
            {
                Data = Bmp.LockBits(new Rectangle(0, 0, Bmp.Width, Bmp.Height),
                                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                    Bmp.PixelFormat);

                Scan0ptr = Data.Scan0;

                TotalBytes = Math.Abs(Data.Stride) * Bmp.Height;

                if (!Unsafe)
                {
                    RawBytes = new byte[TotalBytes];

                    // Copy the pixel data into the RawBytes array
                    System.Runtime.InteropServices.Marshal.Copy(Scan0ptr, RawBytes, 0, TotalBytes);
                }
                Locked = true;
            }

            System.Diagnostics.Debug.WriteLine("Image was already locked. Did not re-lock.");
        }

        /// <summary>
        /// Unlocks the pixel data byte array copies the data back into the source bitmap.
        /// </summary>
        public void Unlock()
        {
            if (Locked)
            {
                if (!Unsafe)
                {
                    // Copy RawBytes back to the BitmapData
                    System.Runtime.InteropServices.Marshal.Copy(RawBytes, 0, Scan0ptr, TotalBytes);
                }
                Bmp.UnlockBits(Data);

                Locked = false;
            }

            System.Diagnostics.Debug.WriteLine("Image was already unlocked. Did not unlock.");
        }

        /// <summary>
        /// Creates a linked list of Pixels from the RawBytes array for easier manipulation.
        /// </summary>
        /// <returns>Linked-List of Pixel objects.</returns>
        public List<Pixel> GetPixels()
        {
            List<Pixel> pixels = new List<Pixel>();

            // Iterate through subpixel groups
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    byte[] subpixels = new byte[PixelSize];
                    Array.Copy(RawBytes, (x * PixelSize) + (y * Stride), subpixels, 0, PixelSize);

                    pixels.Add(new Pixel(subpixels));
                }
            }

            return pixels;
        }

        /// <summary>
        /// Saves the List of Pixel objects back into the RawBytes array.
        /// </summary>
        /// <param name="pixels">Linked list of Pixel objects to overrite RawBytes with.</param>
        public void SetPixels(List<Pixel> pixels)
        {
            if (pixels.Count != (this.Width * this.Height))
                throw new ArgumentException("Number of pixels does not match source image.");

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    byte[] subpixels = pixels[(y * this.Width) + x].ToBytes();

                    for (int i = 0; i < PixelSize; i++)
                    {
                        RawBytes[(y * Stride) + (x * PixelSize) + i] = subpixels[i];
                    }
                }
            }
        }


        public unsafe Pixel[] FastGetPixels()
        {
            Pixel[] pixels = new Pixel[this.Width * this.Height];

            for (int y = 0; y < this.Height; y++)
            {
		// pointer to the first byte in the row
		byte* row = (byte*)Scan0ptr + (y * Stride);
                for (int x = 0; x < this.Width; x++)
                {
                    byte[] subpixels = new byte[PixelSize];
                    for (int i = 0; i < PixelSize; i++)
                    {
                        subpixels[i] = row[(x * PixelSize) + i]; 
                    }
		    pixels[(y * Width) + x] = new Pixel(subpixels);
                }
            }

            return pixels;	    
        }

        /// <summary>
        /// Writes a pixel list into memory. This is potentially unsafe, and probably not much faster. 
        /// </summary>
        /// <param name="pixels"></param>
        public unsafe void FastSetPixels(Pixel[] pixels)
        {
            if (pixels.Length != (this.Width * this.Height))
                throw new ArgumentException("Number of pixels does not match source image.");

            for (int y = 0; y < this.Height; y++)
            {
                byte* row = (byte*)this.Scan0ptr + (y * this.Stride);
                for (int x = 0; x < this.Width; x++)
                {
		    byte[] subpixels = pixels[(y * this.Width) + x].ToBytes();
                    for (int i = 0; i < this.PixelSize; i++)
                    {
			row[(x*PixelSize) + i] = subpixels[i]; 
                    }
                }
            }
        }

        public unsafe IntPtr CoordToPointer(int x, int y)
        {
            return Scan0ptr + (y * Stride) + (x * PixelSize);
        }

        /// <summary>
        /// Gets the Color of the pixel at provided point. 
        /// </summary>
        /// <param name="point">Point to check color information at.</param>
        /// <returns>Color of the pixel at queried point.</returns>
        public Color GetPixel(Point point)
        {
            return this.GetPixel(point.X, point.Y);
        }

        /// <summary>
        /// Gets the Color of the pixel at provided point. 
        /// </summary>
        /// <param name="x">X coordinate of the pixel at which to check.</param>
        /// <param name="y">Y coordinate of the pixel at which to check.</param>
        /// <returns>Color of the pixel at queried point.</returns>
        public Color GetPixel(int x, int y)
        {
            byte[] s = GetSubPixels(x, y);

            return Color.FromArgb(s[0], s[1], s[2]);
        }
        
        public byte[] GetSubPixels(int x, int y)
        {
            if (!Bmp.PixelFormat.Equals(System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                throw new NotImplementedException("Pixel Formats other than 24bppRgb are not supported.");

            int rawPosition = (x * 3) + (y * Data.Stride);
            byte R, G, B;
            B = RawBytes[rawPosition];
            G = RawBytes[rawPosition + 1];
            R = RawBytes[rawPosition + 2];

            return new byte[3]{R, G, B};
        }

        /// <summary>
        /// Changes the color of the specified pixel.
        /// </summary>
        /// <param name="point">Point coordinate of the pixel to edit.</param>
        /// <param name="newColor">New color to set the pixel to.</param>
        public void EditPixel(Point point, Color newColor)
        {
            this.EditPixel(point.X, point.Y, newColor);
        }

        /// <summary>
        /// Changes the color of the specified pixel.
        /// </summary>
        /// <param name="x">X coordinate of the pixel to edit.</param>
        /// <param name="y">Y coordinate of the pixel to edit.</param>
        /// <param name="newColor">New color to set the pixel to.</param>
        public void EditPixel(int x, int y, Color newColor)
        {
            this.EditPixel(x, y, newColor.R, newColor.G, newColor.B);
        }

        /// <summary>
        /// Changes the color of the specified pixel.
        /// </summary>
        /// <param name="x">X coordinate of the pixel to edit.</param>
        /// <param name="y">Y coordinate of the pixel to edit.</param>
        /// <param name="r">Red value of the pixel to edit.</param>
        /// <param name="g">Green value of the pixel to edit.</param>
        /// <param name="b">Blue value of the pixel to edit.</param>
        public void EditPixel(int x, int y, byte r, byte g, byte b)
        {
            if (!Bmp.PixelFormat.Equals(System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                throw new NotImplementedException("Pixel Formats other than 24bppRgb are not supported.");

            int rawPosition = (x * 3) + (y * Data.Stride); 
            int Rindex, Gindex, Bindex;
            Bindex = rawPosition;
            Gindex = rawPosition + 1;
            Rindex = rawPosition + 2;

            RawBytes[Rindex] = r;
            RawBytes[Gindex] = g;
            RawBytes[Bindex] = b;
        }

    }
}
