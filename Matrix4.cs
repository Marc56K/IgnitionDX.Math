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
    public struct Matrix4
    {
        /// <summary>
        /// Gets or sets the element of the matrix that exists in the first row and first column. 
        /// </summary>
        public float M11;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the second row and first column. 
        /// </summary>
        public float M21;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the third row and first column. 
        /// </summary>
        public float M31;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the fourth row and first column. 
        /// </summary>
        public float M41;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the first row and second column. 
        /// </summary>
        public float M12;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the second row and second column. 
        /// </summary>
        public float M22;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the third row and second column. 
        /// </summary>
        public float M32;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the fourth row and second column. 
        /// </summary>
        public float M42;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the first row and third column. 
        /// </summary>
        public float M13;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the second row and third column. 
        /// </summary>
        public float M23;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the third row and third column. 
        /// </summary>
        public float M33;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the fourth row and third column. 
        /// </summary>
        public float M43;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the first row and fourth column. 
        /// </summary>
        public float M14;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the second row and fourth column. 
        /// </summary>
        public float M24;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the third row and fourth column. 
        /// </summary>
        public float M34;

        /// <summary>
        /// Gets or sets the element of the matrix that exists in the fourth row and fourth column. 
        /// </summary>
        public float M44;

        /// <summary>
        /// Instantiates a new matrix4.
        /// </summary>
        /// <param name="m11">The first matrix element in the first row.</param>
        /// <param name="m12">The second matrix element in the first row.</param>
        /// <param name="m13">The third matrix element in the first row.</param>
        /// <param name="m14">The fourth matrix element in the first row.</param>
        /// <param name="m21">The first matrix element in the second row.</param>
        /// <param name="m22">The second matrix element in the second row.</param>
        /// <param name="m23">The third matrix element in the second row.</param>
        /// <param name="m24">The fourth matrix element in the second row.</param>
        /// <param name="m31">The first matrix element in the third row.</param>
        /// <param name="m32">The second matrix element in the third row.</param>
        /// <param name="m33">The third matrix element in the third row.</param>
        /// <param name="m34">The fourth matrix element in the third row.</param>
        /// <param name="m41">The first matrix element in the fourth row.</param>
        /// <param name="m42">The second matrix element in the fourth row.</param>
        /// <param name="m43">The third matrix element in the fourth row.</param>
        /// <param name="m44">The fourth matrix element in the fourth row.</param>
        public Matrix4(
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row > 3)
                    throw new IndexOutOfRangeException("row");

                if (column < 0 || column > 3)
                    throw new IndexOutOfRangeException("column");

                int index = row * 4 + column;
                switch (index)
                {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                }

                return 0.0f;
            }

            set
            {
                if (row < 0 || row > 3)
                    throw new IndexOutOfRangeException("row");

                if (column < 0 || column > 3)
                    throw new IndexOutOfRangeException("column");

                int index = row * 4 + column;
                switch (index)
                {
                    case 0: M11 = value; break;
                    case 1: M12 = value; break;
                    case 2: M13 = value; break;
                    case 3: M14 = value; break;
                    case 4: M21 = value; break;
                    case 5: M22 = value; break;
                    case 6: M23 = value; break;
                    case 7: M24 = value; break;
                    case 8: M31 = value; break;
                    case 9: M32 = value; break;
                    case 10: M33 = value; break;
                    case 11: M34 = value; break;
                    case 12: M41 = value; break;
                    case 13: M42 = value; break;
                    case 14: M43 = value; break;
                    case 15: M44 = value; break;
                }
            }
        }

        public float this[int index]
        {
            get
            {
                if (index < 0 || index > 15)
                    throw new IndexOutOfRangeException("index");

                switch (index)
                {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                }

                return 0.0f;
            }

            set
            {
                if (index < 0 || index > 15)
                    throw new IndexOutOfRangeException("index");

                switch (index)
                {
                    case 0: M11 = value; break;
                    case 1: M12 = value; break;
                    case 2: M13 = value; break;
                    case 3: M14 = value; break;
                    case 4: M21 = value; break;
                    case 5: M22 = value; break;
                    case 6: M23 = value; break;
                    case 7: M24 = value; break;
                    case 8: M31 = value; break;
                    case 9: M32 = value; break;
                    case 10: M33 = value; break;
                    case 11: M34 = value; break;
                    case 12: M41 = value; break;
                    case 13: M42 = value; break;
                    case 14: M43 = value; break;
                    case 15: M44 = value; break;
                }
            }
        }

        public static Matrix4 Identity
        {
            get
            {
                Matrix4 result = new Matrix4();
                result.M11 = 1.0f;
                result.M22 = 1.0f;
                result.M33 = 1.0f;
                result.M44 = 1.0f;

                return result;
            }
        }

        public bool IsIdentity
        {
            get
            {
                if (M11 != 1.0f || M22 != 1.0f || M33 != 1.0f || M44 != 1.0f)
                    return false;

                if (M12 != 0.0f || M13 != 0.0f || M14 != 0.0f ||
                    M21 != 0.0f || M23 != 0.0f || M24 != 0.0f ||
                    M31 != 0.0f || M32 != 0.0f || M34 != 0.0f ||
                    M41 != 0.0f || M42 != 0.0f || M43 != 0.0f)
                    return false;

                return true;
            }
        }

        public Matrix4 Inverse
        {
            get
            {
                Matrix4 dst = Matrix4.Identity;

                if (this.IsIdentity)
                {
                    return dst;
                }

                /* temp array for pairs */
                float[] tmp = new float[12];

                /* array of transpose source matrix */
                float[] src = new float[16];

                /* determinant */
                float det;

                /* transpose matrix */
                for (int i = 0; i < 4; i++)
                {
                    src[i] = this[i * 4];
                    src[i + 4] = this[i * 4 + 1];
                    src[i + 8] = this[i * 4 + 2];
                    src[i + 12] = this[i * 4 + 3];
                }

                /* calculate pairs for first 8 elements (cofactors) */
                tmp[0] = src[10] * src[15];
                tmp[1] = src[11] * src[14];
                tmp[2] = src[9] * src[15];
                tmp[3] = src[11] * src[13];
                tmp[4] = src[9] * src[14];
                tmp[5] = src[10] * src[13];
                tmp[6] = src[8] * src[15];
                tmp[7] = src[11] * src[12];
                tmp[8] = src[8] * src[14];
                tmp[9] = src[10] * src[12];
                tmp[10] = src[8] * src[13];
                tmp[11] = src[9] * src[12];

                /* calculate first 8 elements (cofactors) */
                dst[0] = tmp[0] * src[5] + tmp[3] * src[6] + tmp[4] * src[7];
                dst[0] -= tmp[1] * src[5] + tmp[2] * src[6] + tmp[5] * src[7];
                dst[1] = tmp[1] * src[4] + tmp[6] * src[6] + tmp[9] * src[7];
                dst[1] -= tmp[0] * src[4] + tmp[7] * src[6] + tmp[8] * src[7];
                dst[2] = tmp[2] * src[4] + tmp[7] * src[5] + tmp[10] * src[7];
                dst[2] -= tmp[3] * src[4] + tmp[6] * src[5] + tmp[11] * src[7];
                dst[3] = tmp[5] * src[4] + tmp[8] * src[5] + tmp[11] * src[6];
                dst[3] -= tmp[4] * src[4] + tmp[9] * src[5] + tmp[10] * src[6];
                dst[4] = tmp[1] * src[1] + tmp[2] * src[2] + tmp[5] * src[3];
                dst[4] -= tmp[0] * src[1] + tmp[3] * src[2] + tmp[4] * src[3];
                dst[5] = tmp[0] * src[0] + tmp[7] * src[2] + tmp[8] * src[3];
                dst[5] -= tmp[1] * src[0] + tmp[6] * src[2] + tmp[9] * src[3];
                dst[6] = tmp[3] * src[0] + tmp[6] * src[1] + tmp[11] * src[3];
                dst[6] -= tmp[2] * src[0] + tmp[7] * src[1] + tmp[10] * src[3];
                dst[7] = tmp[4] * src[0] + tmp[9] * src[1] + tmp[10] * src[2];
                dst[7] -= tmp[5] * src[0] + tmp[8] * src[1] + tmp[11] * src[2];

                /* calculate pairs for second 8 elements (cofactors) */
                tmp[0] = src[2] * src[7];
                tmp[1] = src[3] * src[6];
                tmp[2] = src[1] * src[7];
                tmp[3] = src[3] * src[5];
                tmp[4] = src[1] * src[6];
                tmp[5] = src[2] * src[5];
                tmp[6] = src[0] * src[7];
                tmp[7] = src[3] * src[4];
                tmp[8] = src[0] * src[6];
                tmp[9] = src[2] * src[4];
                tmp[10] = src[0] * src[5];
                tmp[11] = src[1] * src[4];

                /* calculate second 8 elements (cofactors) */
                dst[8] = tmp[0] * src[13] + tmp[3] * src[14] + tmp[4] * src[15];
                dst[8] -= tmp[1] * src[13] + tmp[2] * src[14] + tmp[5] * src[15];
                dst[9] = tmp[1] * src[12] + tmp[6] * src[14] + tmp[9] * src[15];
                dst[9] -= tmp[0] * src[12] + tmp[7] * src[14] + tmp[8] * src[15];
                dst[10] = tmp[2] * src[12] + tmp[7] * src[13] + tmp[10] * src[15];
                dst[10] -= tmp[3] * src[12] + tmp[6] * src[13] + tmp[11] * src[15];
                dst[11] = tmp[5] * src[12] + tmp[8] * src[13] + tmp[11] * src[14];
                dst[11] -= tmp[4] * src[12] + tmp[9] * src[13] + tmp[10] * src[14];
                dst[12] = tmp[2] * src[10] + tmp[5] * src[11] + tmp[1] * src[9];
                dst[12] -= tmp[4] * src[11] + tmp[0] * src[9] + tmp[3] * src[10];
                dst[13] = tmp[8] * src[11] + tmp[0] * src[8] + tmp[7] * src[10];
                dst[13] -= tmp[6] * src[10] + tmp[9] * src[11] + tmp[1] * src[8];
                dst[14] = tmp[6] * src[9] + tmp[11] * src[11] + tmp[3] * src[8];
                dst[14] -= tmp[10] * src[11] + tmp[2] * src[8] + tmp[7] * src[9];
                dst[15] = tmp[10] * src[10] + tmp[4] * src[8] + tmp[9] * src[9];
                dst[15] -= tmp[8] * src[9] + tmp[11] * src[10] + tmp[5] * src[8];

                /* calculate determinant */
                det = src[0] * dst[0] + src[1] * dst[1] + src[2] * dst[2] + src[3] * dst[3];

                if (det == 0.0f)
                    return Matrix4.Identity;

                /* calculate matrix inverse */
                det = 1 / det;

                for (int j = 0; j < 16; j++)
                {
                    dst[j] *= det;
                }

                return dst;
            }
        }

        public Matrix4 Transpose
        {
            get
            {
                Matrix4 result = new Matrix4();

                result.M11 = M11;
                result.M12 = M21;
                result.M13 = M31;
                result.M14 = M41;
                result.M21 = M12;
                result.M22 = M22;
                result.M23 = M32;
                result.M24 = M42;
                result.M31 = M13;
                result.M32 = M23;
                result.M33 = M33;
                result.M34 = M43;
                result.M41 = M14;
                result.M42 = M24;
                result.M43 = M34;
                result.M44 = M44;

                return result;
            }
        }

        public Matrix4 NormalMatrix
        {
            get
            {
                Matrix4 result = Matrix4.Identity;
                float det = M11 * M22 * M33 + M12 * M23 * M31 + M13 * M21 * M32 - M13 * M22 * M31 - M12 * M21 * M33 - M11 * M23 * M32;

                if (det == 0.0f)
                    return Matrix4.Identity;
                
                result.M11 = (M22 * M33 - M23 * M32) / det;
                result.M21 = (M13 * M32 - M12 * M33) / det;
                result.M31 = (M12 * M23 - M13 * M22) / det;
                           
                result.M12 = (M23 * M31 - M21 * M33) / det;
                result.M22 = (M11 * M33 - M13 * M31) / det;
                result.M32 = (M13 * M21 - M11 * M23) / det;
                           
                result.M13 = (M21 * M32 - M22 * M31) / det;
                result.M23 = (M12 * M31 - M11 * M32) / det;
                result.M33 = (M11 * M22 - M12 * M21) / det;

                return result;
            }
        }

        public static Matrix4 operator +(Matrix4 left, Matrix4 right)
        {
            Matrix4 result = Matrix4.Identity;
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;
            result.M13 = left.M13 + right.M13;
            result.M14 = left.M14 + right.M14;
            result.M21 = left.M21 + right.M21;
            result.M22 = left.M22 + right.M22;
            result.M23 = left.M23 + right.M23;
            result.M24 = left.M24 + right.M24;
            result.M31 = left.M31 + right.M31;
            result.M32 = left.M32 + right.M32;
            result.M33 = left.M33 + right.M33;
            result.M34 = left.M34 + right.M34;
            result.M41 = left.M41 + right.M41;
            result.M42 = left.M42 + right.M42;
            result.M43 = left.M43 + right.M43;
            result.M44 = left.M44 + right.M44;

            return result;
        }

        public static Matrix4 operator -(Matrix4 left, Matrix4 right)
        {
            Matrix4 result = Matrix4.Identity;
            result.M11 = left.M11 - right.M11;
            result.M12 = left.M12 - right.M12;
            result.M13 = left.M13 - right.M13;
            result.M14 = left.M14 - right.M14;
            result.M21 = left.M21 - right.M21;
            result.M22 = left.M22 - right.M22;
            result.M23 = left.M23 - right.M23;
            result.M24 = left.M24 - right.M24;
            result.M31 = left.M31 - right.M31;
            result.M32 = left.M32 - right.M32;
            result.M33 = left.M33 - right.M33;
            result.M34 = left.M34 - right.M34;
            result.M41 = left.M41 - right.M41;
            result.M42 = left.M42 - right.M42;
            result.M43 = left.M43 - right.M43;
            result.M44 = left.M44 - right.M44;

            return result;
        }

        public static Matrix4 operator *(Matrix4 left, Matrix4 right)
        {
            if (left.IsIdentity)
                return right;

            if (right.IsIdentity)
                return left;
            
            Matrix4 result = Matrix4.Identity;
            result.M11 = (left.M11 * right.M11) + (left.M12 * right.M21) + (left.M13 * right.M31) + (left.M14 * right.M41);
            result.M12 = (left.M11 * right.M12) + (left.M12 * right.M22) + (left.M13 * right.M32) + (left.M14 * right.M42);
            result.M13 = (left.M11 * right.M13) + (left.M12 * right.M23) + (left.M13 * right.M33) + (left.M14 * right.M43);
            result.M14 = (left.M11 * right.M14) + (left.M12 * right.M24) + (left.M13 * right.M34) + (left.M14 * right.M44);
            result.M21 = (left.M21 * right.M11) + (left.M22 * right.M21) + (left.M23 * right.M31) + (left.M24 * right.M41);
            result.M22 = (left.M21 * right.M12) + (left.M22 * right.M22) + (left.M23 * right.M32) + (left.M24 * right.M42);
            result.M23 = (left.M21 * right.M13) + (left.M22 * right.M23) + (left.M23 * right.M33) + (left.M24 * right.M43);
            result.M24 = (left.M21 * right.M14) + (left.M22 * right.M24) + (left.M23 * right.M34) + (left.M24 * right.M44); 
            result.M31 = (left.M31 * right.M11) + (left.M32 * right.M21) + (left.M33 * right.M31) + (left.M34 * right.M41);
            result.M32 = (left.M31 * right.M12) + (left.M32 * right.M22) + (left.M33 * right.M32) + (left.M34 * right.M42);
            result.M33 = (left.M31 * right.M13) + (left.M32 * right.M23) + (left.M33 * right.M33) + (left.M34 * right.M43);
            result.M34 = (left.M31 * right.M14) + (left.M32 * right.M24) + (left.M33 * right.M34) + (left.M34 * right.M44);
            result.M41 = (left.M41 * right.M11) + (left.M42 * right.M21) + (left.M43 * right.M31) + (left.M44 * right.M41);
            result.M42 = (left.M41 * right.M12) + (left.M42 * right.M22) + (left.M43 * right.M32) + (left.M44 * right.M42);
            result.M43 = (left.M41 * right.M13) + (left.M42 * right.M23) + (left.M43 * right.M33) + (left.M44 * right.M43);
            result.M44 = (left.M41 * right.M14) + (left.M42 * right.M24) + (left.M43 * right.M34) + (left.M44 * right.M44);

            return result;
        }

        public static Matrix4 operator *(Matrix4 left, float right)
        {
            Matrix4 result = Matrix4.Identity;
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;
            result.M13 = left.M13 * right;
            result.M14 = left.M14 * right;
            result.M21 = left.M21 * right;
            result.M22 = left.M22 * right;
            result.M23 = left.M23 * right;
            result.M24 = left.M24 * right;
            result.M31 = left.M31 * right;
            result.M32 = left.M32 * right;
            result.M33 = left.M33 * right;
            result.M34 = left.M34 * right;
            result.M41 = left.M41 * right;
            result.M42 = left.M42 * right;
            result.M43 = left.M43 * right;
            result.M44 = left.M44 * right;

            return result;
        }

        public static Vector4 operator *(Matrix4 left, Vector4 right)
        {
            if (left.IsIdentity)
                return right;
            
            float x = left.M11 * right.X + left.M12 * right.Y + left.M13 * right.Z + left.M14 * right.W;
            float y = left.M21 * right.X + left.M22 * right.Y + left.M23 * right.Z + left.M24 * right.W;
            float z = left.M31 * right.X + left.M32 * right.Y + left.M33 * right.Z + left.M34 * right.W;
            float w = left.M41 * right.X + left.M42 * right.Y + left.M43 * right.Z + left.M44 * right.W;

            return new Vector4(x, y, z, w);
        }

        public static bool operator ==(Matrix4 left, Matrix4 right)
        {            
            return
                (left.M11 == right.M11) &&
                (left.M12 == right.M12) &&
                (left.M13 == right.M13) &&
                (left.M14 == right.M14) &&
                (left.M21 == right.M21) &&
                (left.M22 == right.M22) &&
                (left.M23 == right.M23) &&
                (left.M24 == right.M24) &&
                (left.M31 == right.M31) &&
                (left.M32 == right.M32) &&
                (left.M33 == right.M33) &&
                (left.M34 == right.M34) &&
                (left.M41 == right.M41) &&
                (left.M42 == right.M42) &&
                (left.M43 == right.M43) &&
                (left.M44 == right.M44);
        }

        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !(left == right);
        }

        public static Matrix4 Translation(float dx, float dy, float dz)
        {
            Matrix4 result = Matrix4.Identity;
            result.M14 = dx;
            result.M24 = dy;
            result.M34 = dz;

            return result;
        }

        public static Matrix4 Translation(Vector3 v)
        {
            return Translation(v.X, v.Y, v.Z);
        }

        public static Matrix4 Rotation(Vector3 axis, float angle)
        {
            if (angle == 0.0f)
                return Matrix4.Identity;

            axis = axis.Normalized;

            float x, y, z, s, c, t;
            x = axis.X;
            y = axis.Y;
            z = axis.Z;
            s = (float)System.Math.Sin(angle);
            c = (float)System.Math.Cos(angle);
            t = 1 - c;

            return new Matrix4(c + x * x * t, x * y * t - z * s, x * z * t + y * s, 0, y * x * t + z * s, c + y * y * t, y * z * t - x * s, 0, z * x * t - y * s, z * y * t + x * s, c + z * z * t, 0, 0, 0, 0, 1);
        }

        public static Matrix4 RotationDeg(float axisX, float axisY, float axisZ, float angle)
        {
            return Rotation(axisX, axisY, axisZ, (float)(System.Math.PI * angle / 180.0));
        }

        public static Matrix4 Rotation(float axisX, float axisY, float axisZ, float angle)
        {
            return Rotation(new Vector3(axisX, axisY, axisZ), angle);
        }

        public static Matrix4 RotationXDeg(float angle)
        {
            return Rotation(1, 0, 0, (float)(System.Math.PI * angle / 180.0));
        }

        public static Matrix4 RotationX(float angle)
        {
            return Rotation(1, 0, 0, angle);
        }

        public static Matrix4 RotationYDeg(float angle)
        {
            return Rotation(0, 1, 0, (float)(System.Math.PI * angle / 180.0));
        }

        public static Matrix4 RotationY(float angle)
        {
            return Rotation(0, 1, 0, angle);
        }

        public static Matrix4 RotationZDeg(float angle)
        {
            return Rotation(0, 0, 1, (float)(System.Math.PI * angle / 180.0));
        }

        public static Matrix4 RotationZ(float angle)
        {
            return Rotation(0, 0, 1, angle);
        }

        public static Matrix4 Scaling(float scale)
        {
            return Scaling(scale, scale, scale);
        }

        public static Matrix4 Scaling(float scaleX, float scaleY, float scaleZ)
        {
            Matrix4 result = Matrix4.Identity;

            result.M11 = scaleX == 0 ? 0.001f : scaleX;
            result.M22 = scaleY == 0 ? 0.001f : scaleY;
            result.M33 = scaleZ == 0 ? 0.001f : scaleZ;

            return result;
        }

        public static Matrix4 PerspectiveFovRH(float fov, float aspect, float nearPlane, float farPlane)
        {
            return FromSharpDXMatrix(SharpDX.Matrix.PerspectiveFovRH(fov, aspect, nearPlane, farPlane));
        }

        public static Matrix4 OrthoRH(float width, float height, float nearPlane, float farPlane)
        {
            return FromSharpDXMatrix(SharpDX.Matrix.OrthoRH(width, height, nearPlane, farPlane));
        }

        public static Matrix4 OrthoOffCenterRH(float left, float right, float bottom, float top, float nearPlane, float farPlane)
        {
            return FromSharpDXMatrix(SharpDX.Matrix.OrthoOffCenterRH(left, right, bottom, top, nearPlane, farPlane));
        }

        public static Matrix4 FromSharpDXMatrix(SharpDX.Matrix m)
        {
            m = SharpDX.Matrix.Transpose(m);

            Matrix4 result = Matrix4.Identity;

            result.M11 = m.M11;
            result.M12 = m.M12;
            result.M13 = m.M13;
            result.M14 = m.M14;

            result.M21 = m.M21;
            result.M22 = m.M22;
            result.M23 = m.M23;
            result.M24 = m.M24;

            result.M31 = m.M31;
            result.M32 = m.M32;
            result.M33 = m.M33;
            result.M34 = m.M34;

            result.M41 = m.M41;
            result.M42 = m.M42;
            result.M43 = m.M43;
            result.M44 = m.M44;

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix4)
            {
                return this == (Matrix4)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return
                M11.GetHashCode() ^
                M12.GetHashCode() ^
                M13.GetHashCode() ^
                M14.GetHashCode() ^
                M21.GetHashCode() ^
                M22.GetHashCode() ^
                M23.GetHashCode() ^
                M24.GetHashCode() ^
                M31.GetHashCode() ^
                M32.GetHashCode() ^
                M33.GetHashCode() ^
                M34.GetHashCode() ^
                M41.GetHashCode() ^
                M42.GetHashCode() ^
                M43.GetHashCode() ^
                M44.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2} {3}] [{4} {5} {6} {7}] [{8} {9} {10} {11}] [{12} {13} {14} {15}]", M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }
    }
}
