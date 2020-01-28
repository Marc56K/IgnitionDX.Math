/* MIT License (MIT)
 *
 * Copyright (c) 2020 Marc Roßbach
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace IgnitionDX.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color4
    {
        public float R;
        public float G;
        public float B;
        public float A;

        public Color4(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color4(Vector4 v)
        {
            R = v.X;
            G = v.Y;
            B = v.Z;
            A = v.W;
        }

        public static bool operator ==(Color4 left, Color4 right)
        {
            return
                (left.R == right.R) &&
                (left.G == right.G) &&
                (left.B == right.B) &&
                (left.A == right.A);
        }

        public static bool operator !=(Color4 left, Color4 right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode() ^ A.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Color4)
            {
                return this == (Color4)obj;
            }

            return false;
        }

        public static implicit operator System.Drawing.Color(Color4 color)
        {
            int a = (int)(color.A * 255);
            int r = (int)(color.R * 255);
            int g = (int)(color.G * 255);
            int b = (int)(color.B * 255);
            return System.Drawing.Color.FromArgb(a, r, g, b);
        }

        public static implicit operator Color4(System.Drawing.Color color)
        {
            float a = (float)color.A / 255;
            float r = (float)color.R / 255;
            float g = (float)color.G / 255;
            float b = (float)color.B / 255;
            return new Color4(r, g, b, a);
        }

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}, {3}]", R, G, B, A);
        }
    }
}
