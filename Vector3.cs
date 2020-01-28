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
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float[] xyz)
        {
            X = xyz[0];
            Y = xyz[1];
            Z = xyz[2];
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Vector2 xy, float z)
        {
            X = xy.X;
            Y = xy.Y;
            Z = z;
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
                    case 2:
                        return Z;
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
                    case 2:
                        Z = value;
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
                return X * X + Y * Y + Z * Z;
            }
        }

        public Vector3 Normalized
        {
            get
            {
                float len = Length;
                Vector3 result = new Vector3();
                if (len == 0)
                    return result;

                result.X = X / len;
                result.Y = Y / len;
                result.Z = Z / len;

                return result;
            }
        }

        public Vector3 Cross(Vector3 v)
        {
            return new Vector3(
                Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X);
        }

        public float Dot(Vector3 v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public float Angle(Vector3 v)
        {
            return (float)System.Math.Acos(System.Math.Max(-1, System.Math.Min(1, this.Dot(v) / (this.Length * v.Length))));
        }

        public float SmallAngle(Vector3 v)
        {
            float angle = Angle(v);
            return (float)System.Math.Min(angle, System.Math.PI - angle);
        }

        public static Vector3 operator *(float n, Vector3 v)
        {
            return v * n;
        }

        public static Vector3 operator *(Vector3 v, float n)
        {
            return new Vector3(v.X * n, v.Y * n, v.Z * n);
        }

        public static Vector3 operator /(Vector3 v, float n)
        {
            return new Vector3(v.X / n, v.Y / n, v.Z / n);
        }

        public static Vector3 operator +(Vector3 v0, Vector3 v1)
        {
            return new Vector3(v0.X + v1.X, v0.Y + v1.Y, v0.Z + v1.Z);
        }

        public static Vector3 operator -(Vector3 v0, Vector3 v1)
        {
            return new Vector3(v0.X - v1.X, v0.Y - v1.Y, v0.Z - v1.Z);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return
                (left.X == right.X) &&
                (left.Y == right.Y) &&
                (left.Z == right.Z);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3)
            {
                return this == (Vector3)obj;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2}]", X, Y, Z);
        }
    }
}
