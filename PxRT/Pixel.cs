using System;

namespace PxRT
{
    struct Pixel : IComparable
    {
        public readonly byte r, g, b, a, l;

        /// <summary>
        /// Constructs a Pixel from the Red, Green and Blue subpixel color channels.
        /// </summary>
        /// <param name="R">Red channel value.</param>
        /// <param name="G">Green channel value.</param>
        /// <param name="B">Blue channel value.</param>
        public Pixel(byte R, byte G, byte B)
        {
            r = R;
            g = G;
            b = B;
            a = 255; // default to fully opaque

	    // Fast approximate perceived luminance calculation.
	    // See here (https://en.wikipedia.org/wiki/Brightness) and here (http://stackoverflow.com/a/596241/2712232) for some explanation.

            l = (byte)((r + r + r + b + g + g + g + g) >> 3);
        }

        /// <summary>
        /// Constructs a Pixel from the Red, Green Blue and Alpha subpixel color channels.
        /// </summary>
        /// <param name="R">Red channel value.</param>
        /// <param name="G">Green channel value.</param>
        /// <param name="B">Blue channel value.</param>
        /// <param name="A">Alpha channel value.</param>
        public Pixel(byte R, byte G, byte B, byte A)
        {
            r = R;
            g = G;
            b = B;
            a = A;

            l = (byte)((r + r + r + b + g + g + g + g) >> 3);
        }

        /// <summary>
        /// Tries to construct a new Pixel from a byte array representation of the subpixels.
        /// </summary>
        /// <param name="subpixels">Byte array to parse. Must be of the form {B, G, R} or {B, G, R, A}.</param>
        public Pixel(byte[] subpixels)
        {
            if (subpixels.Length < 3 || subpixels.Length > 4)
                throw new ArgumentException("Too few or too many elemnts in the subpixel array.");

            r = subpixels[2];
            g = subpixels[1];
            b = subpixels[0];

            // has an alpha channel
            if (subpixels.Length == 4)
                a = subpixels[3];
            else
                a = 255; // default to fully opaque

            l = (byte)((r + r + r + b + g + g + g + g) >> 3);
        }

        /// <summary>
        /// Legacy only. Read this.l directly instead.
        /// </summary>
        public byte Luminance
        {
            get
            {
                return l;
            }
        }

        /// <summary>
        /// Generates a new byte array representation of the subpixel data of the form { B, G, R, A }.
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { b, g, r, a };
        }

        /// <summary>
        /// Compares the luminance values of two pixel objects. 
        /// </summary>
        /// <returns>this.l > obj.l = 1, this.l < obj.l = -1, this.l == obj.l = 0.</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Pixel))
                throw new ArgumentException("obj is not a pixel");

            Pixel p2 = (Pixel)obj;

            if (this.l > p2.l)
                return 1;
            if (this.l < p2.l)
                return -1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            int hash = 42;
            hash = hash * 23 + r.GetHashCode();
            hash = hash * 23 + b.GetHashCode();
            hash = hash * 23 + g.GetHashCode();
            hash = hash * 23 + a.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return "[" + r + ", " + g + ", " + b + ", " + a + "]";
        }

        public static bool operator ==(Pixel a, Pixel b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

	    return (a.r == b.r) && (a.g == b.g) && (a.r == b.r) && (a.a == b.a);        
        }

        public static bool operator ==(Pixel a, object b)
        {
            if (b is Pixel)
                b = (Pixel)b;
            else
                return false;

            return a == b;
        }

        public static bool operator ==(object a, Pixel b)
        {
            if (a is Pixel)
                a = (Pixel)a;
            else
                return false;

            return a == b;
        }

        public static bool operator !=(Pixel a, Pixel b)
        {
            return !(a == b);
        }

        public static bool operator !=(Pixel a, object b)
        {
            if (b is Pixel)
                b = (Pixel)b;
            else
                return false;

            return !(a == b);
        }

        public static bool operator !=(object a, Pixel b)
        {
            if (a is Pixel)
                a = (Pixel)a;
            else
                return false;

            return !(a == b);
        }

        public static bool operator >(Pixel a, Pixel b)
        {
            return a.l > b.l;
        }

        public static bool operator <(Pixel a, Pixel b)
        {
            return a.l < b.l;
        }


    }
}
