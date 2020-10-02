using System;
using System.Text;

namespace FirstApplication
{
    public class RealMatrix
    {
        /// <summary>
        /// 2D array containing the elements of the RealMatrix 
        /// </summary>
        protected readonly double[,] data;

        /// <summary>
        /// Integer storing the number of rows of the RealMatrix
        /// </summary>
        protected readonly int m;

        /// <summary>
        /// Integer storing the number of columns of the RealMatrix
        /// </summary>
        protected readonly int n;

        /// <summary>
        /// String containing the name of the RealMatrix (this is not assigned in the constructor and is optional)
        /// </summary>
        public string name;

        /// <summary>
        /// Returns a string representation of the RealMatrix with its name.
        /// </summary>
        public string RealMatrixString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Matrix " + name + " :\n\n");
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sb.Append(Math.Round(data[i, j], 3) + "\t\t");
                    }
                    sb.Append("\n");
                }
                return sb.ToString();
            }
        }

        //constructors

        /// <summary>
        /// Creates a new <paramref name="m"/> x <paramref name="n"/> RealMatrix and fills it with zeros.
        /// </summary>
        public RealMatrix(int m, int n)
        {
            if (m <= 0 | n <= 0)
            {
                throw new Exception("Matrices must have positive dimensions");
            }

            else
            {
                data = new double[m, n];
                this.m = m;
                this.n = n;
            }
        }

        /// <summary>
        /// Creates a new RealMatrix filled with the elements of the 2D array <paramref name="d"/> with <paramref name="d"/>.GetLength(0) rows and <paramref name="d"/>.GetLength(1) columns 
        /// </summary>
        public RealMatrix(double[,] d)
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
        /// Creates a new <paramref name="n"/> x <paramref name="n"/> RealMatrix with <paramref name="d"/> on the leading diagonal and zeros everywhere else 
        /// </summary>
        public RealMatrix(int n, double d)
        {
            if (n <= 0)
            {
                throw new Exception("Matrices must have positive dimensions");
            }

            else
            {
                double[,] _diag = new double[n, n];

                for (int i = 0; i < n; i++)
                {
                    _diag[i, i] = d;
                }

                data = _diag;
                m = n;
                this.n = n;
            }
        }

        /// <summary>
        /// Returns element (<paramref name="i"/>, <paramref name="j"/>) of the RealMatrix.
        /// </summary>
        public double GetIJ(int i, int j)
        {
            return data[i, j];
        }

        /// <summary>
        /// Returns the number of rows of the RealMatrix
        /// </summary>
        public int NumRows()
        {
            return m;
        }

        /// <summary>
        /// Returns the number of columns of the RealMatrix
        /// </summary>
        public int NumColumns()
        {
            return n;
        }


        /// <summary>
        /// Returns a string representation of the RealMatrix.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append(Math.Round(data[i, j], 3) + "\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the sum of RealMatrix <paramref name="A"/> and RealMatrix <paramref name="B"/>
        /// </summary>
        public static RealMatrix operator +(RealMatrix A, RealMatrix B)
        {
            if ((A.m != B.m) | (A.n != B.n))
            {
                throw new Exception("Matrices are not compatable for addition");
            }

            else
            {
                double[,] sum = new double[A.m, B.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < A.n; j++)
                    {
                        sum[i, j] = A.GetIJ(i, j) + B.GetIJ(i, j);
                    }
                }

                return new RealMatrix(sum);
            }
        }


        /// <summary>
        /// Returns RealMatrix <paramref name="B"/> subtracted from RealMatrix <paramref name="A"/>
        /// </summary>
        public static RealMatrix operator -(RealMatrix A, RealMatrix B)
        {
            if ((A.m != B.m) | (A.n != B.n))
            {
                throw new Exception("Matrices are not compatable for subtraction");
            }

            else
            {
                double[,] diff = new double[A.m, A.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < A.n; j++)
                    {
                        diff[i, j] = A.GetIJ(i, j) - B.GetIJ(i, j);
                    }
                }

                return new RealMatrix(diff);
            }
        }

        /// <summary>
        /// Returns RealMatrix <paramref name="A"/> right-multiplied by RealMatrix <paramref name="B"/>
        /// </summary>
        public static RealMatrix operator *(RealMatrix A, RealMatrix B)
        {
            if (A.n != B.m)
            {
                throw new Exception("Matrices are not compatiable for multpilication.");
            }

            else
            {
                double[,] product = new double[A.m, B.n];

                for (int i = 0; i < A.m; i++)
                {
                    for (int j = 0; j < B.n; j++)
                    {
                        double elementIJ = 0;
                        for (int k = 0; k < A.n; k++)
                        {
                            elementIJ += A.GetIJ(i, k) * B.GetIJ(k, j);
                        }

                        product[i, j] = elementIJ;
                    }
                }

                return new RealMatrix(product);
            }
        }

        /// <summary>
        /// Returns RealMatrix <paramref name="A"/> multiplied by double <paramref name="scalar"/>
        /// </summary>
        public static RealMatrix operator *(RealMatrix A, double scalar)
        {
            double[,] product = new double[A.m, A.n];

            for (int i = 0; i < A.m; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    product[i, j] = A.GetIJ(i, j) * scalar;
                }
            }

            return new RealMatrix(product);
        }

        /// <summary>
        /// Returns RealMatrix <paramref name="A"/> multiplied by double <paramref name="scalar"/>
        /// </summary>
        public static RealMatrix operator *(double scalar, RealMatrix A)
        {
            return A * scalar;
        }


        //elementary row operations

        /// <summary>
        /// Returns the RealMatrix with '<paramref name="row"/>' multiplied by the non-zero double <paramref name="scalar"/>
        /// </summary>
        public RealMatrix RowScale(int row, double scalar)
        {
            if (row < 0 | row >= m)
            {
                throw new Exception("Please select a valid row (note that the 1st row is actually the 0th row etc.)");
            }

            else if (scalar == 0)
            {
                throw new Exception("The scalar must be non-zero");
            }

            else
            {
                double[,] scaled = data;

                for (int k = 0; k < n; k++)
                {
                    scaled[row, k] = scalar * GetIJ(row, k);
                }

                return new RealMatrix(scaled);
            }
        }

        /// <summary>
        /// Returns the RealMatrix with <paramref name="rowOne"/> and <paramref name="rowTwo"/> interchanged
        /// </summary>
        public RealMatrix RowInterchange(int rowOne, int rowTwo)
        {
            if (rowOne < 0 | rowTwo < 0 | rowOne >= m | rowTwo >= m)
            {
                throw new Exception("Please select a valid row (note that the 1st row is actually the 0th row etc.)");
            }

            else
            {
                double[,] interchange = new double[m, n];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == rowOne)
                        {
                            interchange[i, j] = GetIJ(rowTwo, j);
                        }

                        else if (i == rowTwo)
                        {
                            interchange[i, j] = GetIJ(rowOne, j);
                        }

                        else
                        {
                            interchange[i, j] = GetIJ(i, j);
                        }
                    }
                }

                return new RealMatrix(interchange);
            }
        }

        /// <summary>
        /// Returns the RealMatrix with the non-zero multiple '<paramref name="scalar"/>' of <paramref name="rowTwo"/> added to <paramref name="rowOne"/> 
        /// </summary>
        public RealMatrix AddScaledRow(int rowOne, int rowTwo, double scalar)
        {
            if (rowOne < 0 | rowTwo < 0 | rowOne >= m | rowTwo >= m)
            {
                throw new Exception("Please select a valid row(note that the 1st row is actually the 0th row etc.)");
            }

            else if (scalar == 0)
            {
                throw new Exception("The scalar must be non-zero");
            }

            else if (rowOne == rowTwo)
            {
                throw new Exception("The two rows must be different");
            }

            else
            {
                double[,] A = new double[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == rowOne)
                        {
                            A[i, j] = GetIJ(i, j) + (scalar * GetIJ(rowTwo, j));
                        }

                        else
                        {
                            A[i, j] = GetIJ(i, j);
                        }
                    }
                }

                return new RealMatrix(A);
            }
        }

        /// <summary>
        /// Returns the row-reduced echelon form of the RealMatrix
        /// </summary>
        public RealMatrix Rref()
        {
            /// <summary>
            /// Local method that returns the given 2d array with rowOne and rowTwo interchanged
            /// </summary>
            static double[,] RowInterchange(double[,] d, int rowOne, int rowTwo)
            {
                double[,] interchanged = d;

                if (rowOne < 0 | rowTwo < 0 | rowOne >= d.GetLength(0) | rowTwo >= d.GetLength(1))
                {
                    throw new Exception("Please select a valid row (note that the 1st row is actually the 0th row etc.)");
                }

                for (int j = 0; j < interchanged.GetLength(1); j++)
                {
                    interchanged[rowOne, j] = d[rowTwo, j];
                    interchanged[rowTwo, j] = d[rowOne, j];
                }

                return interchanged;
            }

            /// <summary>
            /// Local method that returns the given 2d array with row multiplied by scalar
            /// </summary>
            static double[,] RowScale(double[,] d, int row, double scalar)
            {
                if (row < 0 | row >= d.GetLength(0))
                {
                    throw new Exception("Please select a valid row (note that the 1st row is actually the 0th row etc.)");
                }

                else
                {
                    double[,] scaled = d;
                    for (int j = 0; j < scaled.GetLength(1); j++)
                    {
                        scaled[row, j] = d[row, j] * scalar;
                    }

                    return scaled;
                }
            }

            /// <summary>
            /// Returns the 2d array with the non-zero multiple '<paramref name="scalar"/>' of <paramref name="rowTwo"/> added to <paramref name="rowOne"/> 
            /// </summary>
            static double[,] AddScaledRow(double[,] d, int rowOne, int rowTwo, double scalar)
            {
                if (rowOne < 0 | rowTwo < 0 | rowOne >= d.GetLength(0) | rowTwo >= d.GetLength(0))
                {
                    throw new Exception("Please select a valid row(note that the 1st row is actually the 0th row etc.)");
                }

                else if (scalar == 0)
                {
                    throw new Exception("The scalar must be non-zero");
                }

                else if (rowOne == rowTwo)
                {
                    throw new Exception("The two rows must be different");
                }

                else
                {
                    double[,] A = new double[d.GetLength(0), d.GetLength(1)];

                    for (int i = 0; i < d.GetLength(0); i++)
                    {
                        for (int j = 0; j < d.GetLength(1); j++)
                        {
                            if (i == rowOne)
                            {
                                A[i, j] = d[i, j] + (scalar * d[rowTwo, j]);
                            }

                            else
                            {
                                A[i, j] = d[i, j];
                            }
                        }
                    }

                    return A;
                }
            }


            double[,] rref = new double[m, n];

            for (int i = 0; i < m; i++)  //sets rref to the RealMatrix 
            {
                for (int j = 0; j < n; j++)
                {
                    rref[i, j] = GetIJ(i, j);
                }
            }

            int[] pivotPosition = new int[2]; //pivotPosition starting at (0,0)
            pivotPosition[0] = 0;
            pivotPosition[1] = 0;

            bool zeroColumn = true;

        Step1:;

            for (int i = 0; i < m; i++) //checks if each element in the column of the current pivotPosition is 0.
            {
                if (rref[i, pivotPosition[1]] == 0)
                {
                    continue;
                }

                else
                {
                    zeroColumn = false;
                    break;
                }
            }

            if (zeroColumn == true) //returns the zero matrix if the original matrix was the zero matrix
            {
                if (pivotPosition[1] < n - 1)
                {
                    pivotPosition[1]++;
                    goto Step1;
                }

                else
                {
                    return new RealMatrix(rref);
                }
            }

            else  //there is a non-zero column and we find the non-zero element. 
            {
                for (int i = pivotPosition[0]; i < m; i++)
                {
                    if (rref[i, pivotPosition[1]] == 0)
                    {
                        continue;
                    }

                    else //we have found the non-zero element
                    {
                        rref = RowInterchange(rref, i, pivotPosition[0]); //element in the pivotPosition is now non-zero

                        rref = RowScale(rref, pivotPosition[0], 1 / rref[pivotPosition[0], pivotPosition[1]]); //we scale this element to 1
                        break;
                    }
                }
            }

            //we are now at step 4 in the algorithm. 

            for (int i = 0; i < m; i++) //this for loop makes the other elements in the column 0
            {
                if (i == pivotPosition[0] | rref[i, pivotPosition[1]] == 0)
                {
                    continue;
                }

                else
                {
                    rref = AddScaledRow(rref, i, pivotPosition[0], -rref[i, pivotPosition[1]]);
                }
            }

            //the column is now zero except for a 1 in the pivotPosition. We are now at step 5 in the algorithm.

            if (pivotPosition[0] == m - 1 | pivotPosition[1] == n - 1)
            {
                return new RealMatrix(rref);
            }

            else
            {
                pivotPosition[0]++;
                pivotPosition[1]++;
                goto Step1;
            }

        }

        /// <summary>
        /// Returns the transpose of the RealMatrix
        /// </summary>
        public RealMatrix Transpose()
        {
            double[,] transpose = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    transpose[i, j] = GetIJ(j, i);
                }
            }

            return new RealMatrix(transpose);
        }

        /// <summary>
        /// Returns the rank of the RealMatrix
        /// </summary>
        public int Rank()
        {
            int rank = 0;
            bool zeroRow = true;
            int rowNumber = 0;

        rowRight:;

            for (int j = 0; j < Rref().n; j++)
            {
                if (Rref().GetIJ(rowNumber, j) == 0)
                {
                    continue;
                }

                else
                {
                    zeroRow = false;
                    rank++;

                    if (rowNumber == Rref().m - 1)
                    {
                        return rank;
                    }

                    else
                    {
                        rowNumber++;
                        goto rowRight;
                    }
                }
            }

            if (zeroRow == true)
            {
                if (rowNumber == Rref().m - 1)
                {
                    return rank;
                }

                else
                {
                    rowNumber++;
                    goto rowRight;
                }
            }

            return rank;
        }

        /// <summary>
        /// Returns the nullity of the RealMatrix
        /// </summary>
        public int Nullity()
        {
            int nullity;
            nullity = n - Rank();
            return nullity;
        }


        public RealMatrix Decomp(double[] d)
        {
            if (m != n)
            {
                throw new Exception("Matrix is not square");
            }

            int i, imax = -10, j, k;
            double big, dum, sum, temp;
            double[] vv = new double[n];

            double[,] a = new double[m, n];
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    a[x, y] = GetIJ(x, y);
                }
            }

            d[0] = 1.0;

            for (i = 1; i <= n; i++)
            {
                big = 0.0;

                for (j = 1; j <= n; j++)
                {
                    temp = Math.Abs(a[i - 1, j - 1]);
                    if (temp > big)
                    {
                        big = temp;
                    }
                }

                if (big == 0.0)
                {
                    throw new Exception("Matrix is singular");
                }

                vv[i - 1] = 1.0 / big;
            }

            for (j = 1; j <= n; j++)
            {
                for (i = 1; i < j; i++)
                {
                    sum = a[i - 1, j - 1];
                    for (k = 1; k < i; k++)
                    {
                        sum -= a[i - 1, k - 1] * a[k - 1, j - 1];
                    }

                    a[i - 1, j - 1] = sum;
                }

                big = 0.0;
                for (i = j; i <= n; i++)
                {
                    sum = a[i - 1, j - 1];
                    for (k = 1; k < j; k++)
                    {
                        sum -= a[i - 1, k - 1] * a[k - 1, j - 1];
                    }

                    a[i - 1, j - 1] = sum;
                    if ((dum = vv[i - 1] * Math.Abs(sum)) >= big)
                    {
                        big = dum;
                        imax = i;
                    }
                }

                if (j != imax)
                {
                    for (k = 1; k <= n; k++)
                    {
                        dum = a[imax - 1, k - 1];
                        a[imax - 1, k - 1] = a[j - 1, k - 1];
                        a[j - 1, k - 1] = dum;
                    }
                    d[0] = -d[0];
                    vv[imax - 1] = vv[j - 1];
                }

                if (a[j - 1, j - 1] == 0.0)
                {
                    a[j - 1, j - 1] = 1.0e-20;
                }

                if (j != n)
                {
                    dum = 1.0 / a[j - 1, j - 1];

                    for (i = j + 1; i <= n; i++)
                    {
                        a[i - 1, j - 1] = a[i - 1, j - 1] * dum;
                    }
                }
            }

            return new RealMatrix(a);
        }

        /// <summary>
        /// Returns the determinant of the RealMatrix
        /// </summary>
        public double Det()
        {
            if (m != n)
            {
                throw new Exception("Matrix must be square to have a determinant");
            }

            double[] d = new double[1];
            RealMatrix lu = Decomp(d);

            double diagProd = 1;
            for (int i = 0; i < lu.m; i++)
            {
                diagProd *= lu.GetIJ(i, i);
            }

            double det = d[0] * diagProd; // Allows for sign changes
            return Math.Round(det, 10);
        }

        /// <summary>
        /// Returns true if the RealMatrix is invertible (has 0 determinant) and returns false otherwise
        /// </summary>
        public bool IsInvertible()
        {
            if (Det() == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns the inverse of the RealMatrix if it exists, otherwise throws an exception
        /// </summary>
        public RealMatrix Inv()
        {
            if (m != n)
            {
                throw new Exception("Non-square matrices don't have inverses");
            }

            else if (Det() == 0)
            {
                throw new Exception("The matrix has determinant 0 so has no inverse");
            }

            else
            {
                double[,] comb = new double[n, 2 * n]; //This will be the current matrix with the n x n idendity matrix next to it

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        comb[i, j] = GetIJ(i, j);
                    }
                }

                RealMatrix idendity = new RealMatrix(n, (double)1);
                for (int i = 0; i < n; i++)
                {
                    for (int j = n; j < 2 * n; j++)
                    {
                        comb[i, j] = idendity.GetIJ(i, j - n);
                    }
                }

                RealMatrix _comb = new RealMatrix(comb).Rref();
                double[,] inverse = new double[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        inverse[i, j] = _comb.GetIJ(i, j + n);
                    }
                }

                return new RealMatrix(inverse);
            }
        }

        /// <summary>
        /// Returns the characteristic polynomial of the RealMatrix
        /// </summary>
        public RealPolynomial CharacteristicPolynomial()
        {
            if (m != n)
            {
                throw new Exception("Matrix must be square to have a characteristic polynomial");
            }

            else
            {
                RealPolynomial[,] A = new RealPolynomial[n, n];
                double[] d = { 0, -1 };
                RealPolynomial minusX = new RealPolynomial(d);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            A[i, j] = minusX + GetIJ(i, j);
                        }

                        else
                        {
                            double[] e = { GetIJ(i, j) };
                            RealPolynomial elementIJ = new RealPolynomial(e);
                            A[i, j] = elementIJ;
                        }
                    }
                }

                RealPolynomialMatrix _A = new RealPolynomialMatrix(A);
                return _A.Det();
            }
        }


    }



}

