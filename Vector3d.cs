﻿/* MIT License (MIT)
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
    public struct Vector3d
    {
        public double X;
        public double Y;
        public double Z;

        public Vector3d(double[] xyz)
        {
            X = xyz[0];
            Y = xyz[1];
            Z = xyz[2];
        }

        public Vector3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3d(Vector2d xy, double z)
        {
            X = xy.X;
            Y = xy.Y;
            Z = z;
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
                return X * X + Y * Y + Z * Z;
            }
        }

        public Vector3d Normalized
        {
            get
            {
                double len = Length;
                Vector3d result = new Vector3d();
                if (len == 0)
                    return result;

                result.X = X / len;
                result.Y = Y / len;
                result.Z = Z / len;

                return result;
            }
        }

        public Vector3d Cross(Vector3d v)
        {
            return new Vector3d(
                Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X);
        }

        public double Dot(Vector3d v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public double Angle(Vector3d v)
        {
            return (double)System.Math.Acos(System.Math.Max(-1, System.Math.Min(1, this.Dot(v) / (this.Length * v.Length))));
        }

        public double SmallAngle(Vector3d v)
        {
            double angle = Angle(v);
            return (double)System.Math.Min(angle, System.Math.PI - angle);
        }

        public static Vector3d operator *(double n, Vector3d v)
        {
            return v * n;
        }

        public static Vector3d operator *(Vector3d v, double n)
        {
            return new Vector3d(v.X * n, v.Y * n, v.Z * n);
        }

        public static Vector3d operator /(Vector3d v, double n)
        {
            return new Vector3d(v.X / n, v.Y / n, v.Z / n);
        }

        public static Vector3d operator +(Vector3d v0, Vector3d v1)
        {
            return new Vector3d(v0.X + v1.X, v0.Y + v1.Y, v0.Z + v1.Z);
        }

        public static Vector3d operator -(Vector3d v0, Vector3d v1)
        {
            return new Vector3d(v0.X - v1.X, v0.Y - v1.Y, v0.Z - v1.Z);
        }

        public static bool operator ==(Vector3d left, Vector3d right)
        {
            return
                (left.X == right.X) &&
                (left.Y == right.Y) &&
                (left.Z == right.Z);
        }

        public static bool operator !=(Vector3d left, Vector3d right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3d)
            {
                return this == (Vector3d)obj;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2}]", X, Y, Z);
        }
    }
}
