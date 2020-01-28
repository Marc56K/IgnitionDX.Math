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
    public struct Fraction
    {
        public float Numerator;
        public float Denominator;

        public float Value
        {
            get { return Numerator / Denominator; }
        }

        public Fraction(float numerator, float denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Numerator;
                    case 1:
                        return Denominator;
                    default:
                        throw new IndexOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Numerator = value;
                        break;
                    case 1:
                        Denominator = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("index");
                }
            }
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            return (left.Numerator == right.Numerator) && (left.Denominator == right.Denominator);
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                return this == (Fraction)obj;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("[{0}/{1} = {2}]", Numerator, Denominator, Value);
        }
    }
}
