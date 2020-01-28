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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IgnitionDX.Math
{
    /// <summary>
    /// Adapted from http://www.namirshammas.com/CSharp/SLE1.htm
    /// </summary>
    public class Solver
    {
        public static Vector2d? GetIntersectionPoint(Vector2d firstLineP0, Vector2d firstLineP1, Vector2d secondLineP0, Vector2d secondLineP1, bool ignoreLineEnds)
        {
            Func<double, double, double, double, double> det2 = (double x1, double x2, double y1, double y2) => (x1 * y2 - y1 * x2);

            double a = det2(firstLineP0.X - firstLineP1.X, firstLineP0.Y - firstLineP1.Y, secondLineP0.X - secondLineP1.X, secondLineP0.Y - secondLineP1.Y);

            if (a == 0)
            {
                return null; // Lines are parallel
            }

            double d1 = det2(firstLineP0.X, firstLineP0.Y, firstLineP1.X, firstLineP1.Y);
            double d2 = det2(secondLineP0.X, secondLineP0.Y, secondLineP1.X, secondLineP1.Y);
            double x = det2(d1, firstLineP0.X - firstLineP1.X, d2, secondLineP0.X - secondLineP1.X) / a;
            double y = det2(d1, firstLineP0.Y - firstLineP1.Y, d2, secondLineP0.Y - secondLineP1.Y) / a;

            if (!ignoreLineEnds)
            {
                if (x < System.Math.Min(firstLineP0.X, firstLineP1.X) || x > System.Math.Max(firstLineP0.X, firstLineP1.X)) return null;
                if (y < System.Math.Min(firstLineP0.Y, firstLineP1.Y) || y > System.Math.Max(firstLineP0.Y, firstLineP1.Y)) return null;
                if (x < System.Math.Min(secondLineP0.X, secondLineP1.X) || x > System.Math.Max(secondLineP0.X, secondLineP1.X)) return null;
                if (y < System.Math.Min(secondLineP0.Y, secondLineP1.Y) || y > System.Math.Max(secondLineP0.Y, secondLineP1.Y)) return null;
            }

            return new Vector2d(x, y);
        }

        public static bool SolveLinearEquation(float[,] equationLeftPart, float[] equationRightPart, ref float[] result)
        {
            int[] pvtIdx;
            float factor;

            pvtIdx = new int[equationRightPart.Length];
            factor = 1;
            Array.Copy(equationRightPart, result, equationRightPart.Length);

            if (!LuDecomp(ref equationLeftPart, equationRightPart.Length, ref pvtIdx, ref factor))
            {
                return false;
            }
            return LuBackSubst(ref equationLeftPart, equationRightPart.Length, ref pvtIdx, ref result);
        }
        
        private static bool LuBackSubst(ref float[,] a, int nNumRows, ref int[] pivotIndex, ref float[] bVect)
        {
            int i1, i, j, ip;
            float fSum;

            i1 = 0;
            try
            {
                for (i = 0; i < nNumRows; i++)
                {
                    ip = pivotIndex[i];
                    fSum = bVect[ip];
                    bVect[ip] = bVect[i];
                    if (i1 != 0)
                    {
                        for (j = i1 - 1; j < i; j++)
                        {
                            fSum -= a[i, j] * bVect[j];
                        }
                    }
                    else if (fSum != 0.0)
                    {
                        i1 = i + 1;
                    }
                    bVect[i] = fSum;
                }
                for (i = nNumRows - 1; i >= 0; i--)
                {
                    fSum = bVect[i];
                    for (j = i + 1; j < nNumRows; j++)
                    {
                        fSum -= a[i, j] * bVect[j];
                    }
                    bVect[i] = fSum / a[i, i];
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool LuDecomp(ref float[,] a, int nNumRows, ref int[] pivotIndex, ref float factor)
        {
            float[] VV;
            int iMax, i, j, k;
            float big, dum, fSum, temp;

            iMax = 0;
            try
            {
                VV = new float[nNumRows];
                factor = 1.0f;
                for (i = 0; i < nNumRows; i++)
                {
                    big = 0.0f;
                    for (j = 0; j < nNumRows; j++)
                    {
                        temp = System.Math.Abs(a[i, j]);
                        if (temp > big) //ToDo: Unsupported feature: assignment within expression.
                        {
                            big = temp;
                        }
                    }
                    if (big == 0.0)
                    {
                        return false;
                    }
                    VV[i] = 1.0f / big;
                }
                for (j = 0; j < nNumRows; j++)
                {
                    for (i = 0; i < j; i++)
                    {
                        fSum = a[i, j];
                        for (k = 0; k < i; k++)
                        {
                            fSum -= a[i, k] * a[k, j];
                        }
                        a[i, j] = fSum;
                    }
                    big = 0.0f;
                    for (i = j; i < nNumRows; i++)
                    {
                        fSum = a[i, j];
                        for (k = 0; k < j; k++)
                        {
                            fSum -= a[i, k] * a[k, j];
                        }
                        a[i, j] = fSum;
                        dum = VV[i] * System.Math.Abs(fSum);
                        if (dum >= big)
                        {
                            big = dum;
                            iMax = i;
                        }
                    }
                    if (j != iMax)
                    {
                        for (k = 0; k < nNumRows; k++)
                        {
                            dum = a[iMax, k];
                            a[iMax, k] = a[j, k];
                            a[j, k] = dum;
                        }
                        factor = -factor;
                        VV[iMax] = VV[j];
                    }
                    pivotIndex[j] = iMax;
                    if (a[j, j] == 0.0)
                    {
                        a[j, j] = float.Epsilon;
                    }
                    if (j != nNumRows - 1)
                    {
                        dum = 1.0f / a[j, j];
                        for (i = j + 1; i < nNumRows; i++)
                        {
                            a[i, j] *= dum;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
