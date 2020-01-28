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
    public struct Vector4d
    {
        public double X;
        public double Y;
        public double Z;
        public double W;

        public Vector3d XYZ
        {
            get
            {
                return new Vector3d(X, Y, Z);
            }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        public Vector2d XY
        {
            get
            {
                return new Vector2d(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2d ZW
        {
            get
            {
                return new Vector2d(Z, W);
            }
            set
            {
                Z = value.X;
                W = value.Y;
            }
        }

        public Vector4d(double[] xyzw)
        {
            X = xyzw[0];
            Y = xyzw[1];
            Z = xyzw[2];
            W = xyzw[3];
        }

        public Vector4d(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4d(Vector3d xyz, double w)
        {
            X = xyz.X;
            Y = xyz.Y;
            Z = xyz.Z;
            W = w;
        }

        public double this[int index]
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

        public double Length
        {
            get
            {
                return (double)System.Math.Sqrt(LengthSquared);
            }
        }

        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z + W * W;
            }
        }

        public Vector4d Normalized
        {
            get
            {
                double len = Length;
                Vector4d result = new Vector4d();
                if (len == 0)
                    return result;

                result.X = X / len;
                result.Y = Y / len;
                result.Z = Z / len;
                result.W = W / len;

                return result;
            }
        }

        public double Dot(Vector4d v)
        {
            return X * v.X + Y * v.Y + Z * v.Z + W * v.W;
        }

        public Vector4d DivW
        {
            get
            {
                if (W != 0)
                {
                    return new Vector4d(X / W, Y / W, Z / W, 1);
                }
                return this;
            }
        }

        public static Vector4d operator *(Vector4d v, double n)
        {
            return new Vector4d(v.X * n, v.Y * n, v.Z * n, v.W * n);
        }

        public static Vector4d operator *(double n, Vector4d v)
        {
            return v * n;
        }

        public static Vector4d operator /(Vector4d v, double n)
        {
            return new Vector4d(v.X / n, v.Y / n, v.Z / n, v.W / n);
        }

        public static Vector4d operator +(Vector4d v0, Vector4d v1)
        {
            return new Vector4d(v0.X + v1.X, v0.Y + v1.Y, v0.Z + v1.Z, v0.W + v1.W);
        }

        public static Vector4d operator -(Vector4d v0, Vector4d v1)
        {
            return new Vector4d(v0.X - v1.X, v0.Y - v1.Y, v0.Z - v1.Z, v0.W - v1.W);
        }

        public static bool operator ==(Vector4d left, Vector4d right)
        {
            return
                (left.X == right.X) &&
                (left.Y == right.Y) &&
                (left.Z == right.Z) &&
                (left.W == right.W);
        }

        public static bool operator !=(Vector4d left, Vector4d right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector4d)
            {
                return this == (Vector4d)obj;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2} {3}]", X, Y, Z, W);
        }
    }
}
