using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApplication
{
    public class RealPolynomialMatrix
    {
        /// <summary>
        /// 2D array containing the elements of the RealPolynomialMatrix 
        /// </summary>
        private readonly RealPolynomial[,] data;

        /// <summary>
        /// Integer storing the number of rows of the RealPolynomialMatrix
        /// </summary>
        private readonly int m;

        /// <summary>
        /// Integer storing the number of columns of the RealPolynomialMatrix
        /// </summary>
        private readonly int n; 

        //constructors

        /// <summary>
        /// Creates a new <paramref name="m"/> x <paramref name="n"/> RealPolynomialMatrix and fills it with zeros
        /// </summary>
        public RealPolynomialMatrix(int m, int n)
        {
            if (m <= 0 | n <= 0)
            {
                throw new Exception("Matrices must have positive dimensions");
            }

            else
            {
                data = new RealPolynomial[m, n];
                this.m = m;
                this.n = n;

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        data[i, j] = RealPolynomial.zeroPolynomial;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new RealPolynomialMatrix filled with the elements of the 2D array <paramref name="d"/> with <paramref name="d"/>.GetLength(0) rows and <paramref name="d"/>.GetLength(1) columns 
        /// </summary>
        public RealPolynomialMatrix(RealPolynomial[,] d)
        {
            if (d.GetLength(0) <= 0 | d.GetLength(1) <= 0)
            {
                throw new Exception("Matrices must have positive dimensions");
            }

            else
            {
                data = d;
                m = d.GetLength(0);
                n = d.GetLength(1);
            }
        }

        /// <summary>
        /// Creates a new <paramref name="n"/> x <paramref name="n"/> RealPolynomialMatrix with RealPolynomial <paramref name="f"/> on the leading diagonal and zeros everywhere else 
        /// </summary>
        public RealPolynomialMatrix(int n, RealPolynomial f)
        {
            if (n <= 0)
            {
                throw new Exception("Matrices must have positive dimensions");
            }

            else
            {
                RealPolynomial[,] _diag = new RealPolynomial[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(i == j)
                        {
                            _diag[i, i] = f;
                        }

                        else
                        {
                            _diag[i, j] = RealPolynomial.zeroPolynomial;
                        }
                    }
                }

                data = _diag;
                m = n;
                this.n = n;
            }
        }

        /// <summary>
        /// Returns element (<paramref name="i"/>, <paramref name="j"/>) of the RealPolynomialMatrix
        /// </summary>
        public RealPolynomial GetIJ(int i, int j)
        {
            return data[i, j];
        }

        /// <summary>
        /// Returns the number of rows of the RealPolynomialMatrix
        /// </summary>
        public int NumRows()
        {
            return m;
        }

        /// <summary>
        /// Returns the number of columns of the RealPolynomialMatrix
        /// </summary>
        public int NumColumns()
        {
            return n;
        }


        /// <summary>
        /// Returns a string representation of the RealPolynomialMatrix.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append(data[i, j] + "\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the sum of RealPolynomialMatrix <paramref name="A"/> and RealPolynomialMatrix <paramref name="B"/>
        /// </summary>
        public static RealPolynomialMatrix operator +(RealPolynomialMatrix A, RealPolynomialMatrix B)
        {
            if ((A.m != B.m) | (A.n != B.n))
            {
                throw new Exception("Matrices are not compatable for addition");
            }

            else
            {
                RealPolynomial[,] sum = new RealPolynomial[A.m, A.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < A.n; j++)
                    {
                        sum[i, j] = A.GetIJ(i, j) + B.GetIJ(i, j);
                    }
                }

                return new RealPolynomialMatrix(sum);
            }
        }

        /// <summary>
        /// Returns the sum of RealPolynomialMatrix <paramref name="A"/> RealMatrix <paramref name="B"/>
        /// </summary>
        public static RealPolynomialMatrix operator +(RealPolynomialMatrix A, RealMatrix B)
        {
            if ((A.m != B.NumRows()) | (A.n != B.NumColumns()))
            {
                throw new Exception("Matrices are not compatable for addition");
            }

            else
            {
                RealPolynomial[,] sum = new RealPolynomial[A.m, A.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < A.n; j++)
                    {
                        sum[i, j] = A.GetIJ(i, j) + B.GetIJ(i, j);
                    }
                }

                return new RealPolynomialMatrix(sum);
            }
        }

        /// <summary>
        /// Returns the sum of RealMatrix <paramref name="A"/> RealPolynomialMatrix <paramref name="B"/>
        /// </summary>
        public static RealPolynomialMatrix operator +(RealMatrix A, RealPolynomialMatrix B)
        {
            return B + A;
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="B"/> subtracted from RealPolynomialMatrix <paramref name="A"/>
        /// </summary>
        public static RealPolynomialMatrix operator -(RealPolynomialMatrix A, RealPolynomialMatrix B)
        {
            if ((A.m != B.m) | (A.n != B.n))
            {
                throw new Exception("Matrices are not compatable for subtraction");
            }

            else
            {
                RealPolynomial[,] diff = new RealPolynomial[A.m, A.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < A.n; j++)
                    {
                        diff[i, j] = A.GetIJ(i, j) - B.GetIJ(i, j);
                    }
                }

                return new RealPolynomialMatrix(diff);
            }
        }

        /// <summary>
        /// Returns RealMatrix <paramref name="B"/> subtracted from RealPolynomialMatrix <paramref name="A"/>
        /// </summary>
        public static RealPolynomialMatrix operator -(RealPolynomialMatrix A, RealMatrix B)
        {
            if ((A.m != B.NumRows()) | (A.n != B.NumColumns()))
            {
                throw new Exception("Matrices are not compatable for subtraction");
            }

            else
            {
                RealPolynomial[,] diff = new RealPolynomial[A.m, A.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < A.n; j++)
                    {
                        diff[i, j] = A.GetIJ(i, j) - B.GetIJ(i, j);
                    }
                }

                return new RealPolynomialMatrix(diff);
            }
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="B"/> subtracted from RealMatrix <paramref name="A"/>
        /// </summary>
        public static RealPolynomialMatrix operator -(RealMatrix A, RealPolynomialMatrix B)
        {
            if ((A.NumRows() != B.NumRows()) | (A.NumColumns() != B.NumColumns()))
            {
                throw new Exception("Matrices are not compatable for subtraction");
            }

            else
            {
                RealPolynomial[,] diff = new RealPolynomial[A.NumRows(), A.NumColumns()];

                for (int i = 0; i < A.NumRows(); i++)
                {
                    for (int j = 0; j < A.NumColumns(); j++)
                    {
                        diff[i, j] = A.GetIJ(i, j) - B.GetIJ(i, j);
                    }
                }

                return new RealPolynomialMatrix(diff);
            }
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="A"/> right-multiplied by RealPolynomialMatrix <paramref name="B"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(RealPolynomialMatrix A, RealPolynomialMatrix B)
        {
            if (A.n != B.m)
            {
                throw new Exception("Matrices are not compatiable for multpilication.");
            }

            else
            {
                RealPolynomial[,] product = new RealPolynomial[A.m, B.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < B.n; j++)
                    {
                        RealPolynomial elementIJ = RealPolynomial.zeroPolynomial;
                        for (int k = 0; k < A.n; k++)
                        {
                            elementIJ += A.GetIJ(i, k) * B.GetIJ(k, j);
                        }

                        product[i, j] = elementIJ;
                    }
                }

                return new RealPolynomialMatrix(product);
            }
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="A"/> right-multiplied by RealMatrix <paramref name="B"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(RealPolynomialMatrix A, RealMatrix B)
        {
            if (A.n != B.NumRows())
            {
                throw new Exception("Matrices are not compatiable for multpilication.");
            }

            else
            {
                RealPolynomial[,] product = new RealPolynomial[A.m, B.NumColumns()];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < B.NumColumns(); j++)
                    {
                        RealPolynomial elementIJ = RealPolynomial.zeroPolynomial;
                        for (int k = 0; k < A.n; k++)
                        {
                            elementIJ += A.GetIJ(i, k) * B.GetIJ(k, j);
                        }

                        product[i, j] = elementIJ;
                    }
                }

                return new RealPolynomialMatrix(product);
            }
        }

        /// <summary>
        /// Returns RealMatrix <paramref name="A"/> right-multiplied by RealPolynomialMatrix <paramref name="B"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(RealMatrix A, RealPolynomialMatrix B)
        {
            if (A.NumColumns() != B.NumRows())
            {
                throw new Exception("Matrices are not compatiable for multpilication.");
            }

            else
            {
                RealPolynomial[,] product = new RealPolynomial[A.NumRows(), B.NumColumns()];

                for (int i = 0; i < A.NumRows(); i++)
                {
                    for (int j = 0; j < B.NumColumns(); j++)
                    {
                        RealPolynomial elementIJ = RealPolynomial.zeroPolynomial;
                        for (int k = 0; k < A.NumColumns(); k++)
                        {
                            elementIJ += A.GetIJ(i, k) * B.GetIJ(k, j);
                        }

                        product[i, j] = elementIJ;
                    }
                }

                return new RealPolynomialMatrix(product);
            }
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="A"/> multiplied by RealPolynomial <paramref name="scalar"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(RealPolynomialMatrix A, RealPolynomial scalar)
        {
            RealPolynomial[,] product = new RealPolynomial[A.m, A.n];

            for (int i = 0; i < A.m; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    product[i, j] = A.GetIJ(i, j) * scalar;
                }
            }

            return new RealPolynomialMatrix(product);
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="A"/> multiplied by RealPolynomial <paramref name="scalar"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(RealPolynomial scalar, RealPolynomialMatrix A)
        {
            return A * scalar;
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="A"/> multiplied by double <paramref name="scalar"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(RealPolynomialMatrix A, double scalar)
        {
            RealPolynomial[,] product = new RealPolynomial[A.m, A.n];

            for (int i = 0; i < A.m; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    product[i, j] = A.GetIJ(i, j) * scalar;
                }
            }

            return new RealPolynomialMatrix(product);
        }

        /// <summary>
        /// Returns RealPolynomialMatrix <paramref name="A"/> multiplied by double <paramref name="scalar"/>
        /// </summary>
        public static RealPolynomialMatrix operator *(double scalar, RealPolynomialMatrix A)
        {
            return A * scalar;
        }


        /// <summary>
        /// Returns the transpose of the RealPolynomialMatrix
        /// </summary>
        public RealPolynomialMatrix Transpose()
        {
            RealPolynomial[,] transpose = new RealPolynomial[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    transpose[i, j] = GetIJ(j, i);
                }
            }

            return new RealPolynomialMatrix(transpose);
        }


        /// <summary>
        /// Returns the RealPolynomialMatrix obtained by deleting <paramref name="row"/> and <paramref name="column"/> of the PolynomialMatrix
        /// </summary>
        public RealPolynomialMatrix DeleteRowColumn(int row, int column)
        {
            if (m != n)
            {
                throw new Exception("We only define minors for square matrices");
            }

            else //splits matrix into 4 (possibly empty) 'boxes' in order to construct the new matrix
            {
                RealPolynomial[,] deleteRowColumn = new RealPolynomial[n - 1, n - 1];

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        deleteRowColumn[i, j] = GetIJ(i, j);
                    }
                }

                if (row == n - 1 & column == n - 1) //makes the method more efficient if we delete the last row and last column
                {
                    return new RealPolynomialMatrix(deleteRowColumn);
                }

                for (int i = row + 1; i < m; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        deleteRowColumn[i - 1, j] = GetIJ(i, j);
                    }
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = column + 1; j < n; j++)
                    {
                        deleteRowColumn[i, j - 1] = GetIJ(i, j);
                    }
                }

                for (int i = row + 1; i < m; i++)
                {
                    for (int j = column + 1; j < n; j++)
                    {
                        deleteRowColumn[i - 1, j - 1] = GetIJ(i, j);
                    }
                }

                return new RealPolynomialMatrix(deleteRowColumn);
            }
        }


        /// <summary>
        /// Returns the determinant of the RealPolynomialMatrix
        /// </summary>
        public RealPolynomial Det()
        {
            if (m != n)
            {
                throw new Exception("Matrix must be square to have a determinant");
            }

            else
            {
                RealPolynomial total = RealPolynomial.zeroPolynomial;

                RealPolynomial det;
                if (n == 2)
                {
                    RealPolynomial leadProd = GetIJ(0, 0) * GetIJ(1, 1);
                    RealPolynomial infProd = GetIJ(0, 1) * GetIJ(1, 0);
                    det = leadProd - infProd;
                    return det;
                }

                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        RealPolynomialMatrix tempArr = DeleteRowColumn(0, j);
                        RealPolynomial x = tempArr.Det();
                        RealPolynomial y = GetIJ(0, j) * Math.Pow(-1, j);
                        det = x * y;
                        total += det;
                    }

                    return total;
                }
            }
        }
    }
}
