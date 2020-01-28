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
using System.Runtime.InteropServices;

namespace IgnitionDX.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public float X;
        public float Y;

        public Vector2(float[] xy)
        {
            X = xy[0];
            Y = xy[1];
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    default:
                        throw new IndexOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("index");
                }
            }
        }

        public float Length
        {
            get
            {
                return (float)System.Math.Sqrt(LengthSquared);
            }
        }

        public float LengthSquared
        {
            get
            {
                return X * X + Y * Y;
            }
        }

        public Vector2 Normalized
        {
            get
            {
                float len = Length;
                Vector2 result = new Vector2();
                if (len == 0)
                    return result;

                result.X = X / len;
                result.Y = Y / len;

                return result;
            }
        }

        public static Vector2 operator *(Vector2 v, float n)
        {
            return new Vector2(v.X * n, v.Y * n);
        }

        public static Vector2 operator *(float n, Vector2 v)
        {
            return v * n;
        }

        public static Vector2 operator /(Vector2 v, float n)
        {
            return new Vector2(v.X / n, v.Y / n);
        }

        public static Vector2 operator +(Vector2 v0, Vector2 v1)
        {
            return new Vector2(v0.X + v1.X, v0.Y + v1.Y);
        }

        public static Vector2 operator -(Vector2 v0, Vector2 v1)
        {
            return new Vector2(v0.X - v1.X, v0.Y - v1.Y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return (left.X == right.X) && (left.Y == right.Y);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                return this == (Vector2)obj;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("[{0} {1}]", X, Y);
        }
    }
}
