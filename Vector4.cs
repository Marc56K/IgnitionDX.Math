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
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector3 XYZ
        {
            get
            {
                return new Vector3(X, Y, Z);
            }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        public Vector2 XY
        {
            get
            {
                return new Vector2(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2 ZW
        {
            get
            {
                return new Vector2(Z, W);
            }
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        public Vector4(float[] xyzw)
        {
            X = xyzw[0];
            Y = xyzw[1];
            Z = xyzw[2];
            W = xyzw[3];
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4(Vector3 xyz, float w)
        {
            X = xyz.X;
            Y = xyz.Y;
            Z = xyz.Z;
            W = w;
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
                    case 3:
                        return W;
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
                    case 3:
                        W = value;
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
                return X * X + Y * Y + Z * Z + W * W;
            }
        }

        public Vector4 Normalized
        {
            get
            {
                float len = Length;
                Vector4 result = new Vector4();
                if (len == 0)
                    return result;

                result.X = X / len;
                result.Y = Y / len;
                result.Z = Z / len;
                result.W = W / len;

                return result;
            }
        }

        public float Dot(Vector4 v)
        {
            return X * v.X + Y * v.Y + Z * v.Z + W * v.W;
        }

        public Vector4 DivW
        {
            get
            {
                if (W != 0)
                {
                    return new Vector4(X / W, Y / W, Z / W, 1);
                }
                return this;
            }
        }

        public static Vector4 operator *(Vector4 v, float n)
        {
            return new Vector4(v.X * n, v.Y * n, v.Z * n, v.W * n);
        }

        public static Vector4 operator *(float n, Vector4 v)
        {
            return v * n;
        }

        public static Vector4 operator /(Vector4 v, float n)
        {
            return new Vector4(v.X / n, v.Y / n, v.Z / n, v.W / n);
        }

        public static Vector4 operator +(Vector4 v0, Vector4 v1)
        {
            return new Vector4(v0.X + v1.X, v0.Y + v1.Y, v0.Z + v1.Z, v0.W + v1.W);
        }

        public static Vector4 operator -(Vector4 v0, Vector4 v1)
        {
            return new Vector4(v0.X - v1.X, v0.Y - v1.Y, v0.Z - v1.Z, v0.W - v1.W);
        }

        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return
                (left.X == right.X) &&
                (left.Y == right.Y) &&
                (left.Z == right.Z) &&
                (left.W == right.W);
        }

        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector4)
            {
                return this == (Vector4)obj;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2} {3}]", X, Y, Z, W);
        }
    }
}
