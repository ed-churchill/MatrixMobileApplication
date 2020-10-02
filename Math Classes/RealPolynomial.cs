using System;
using System.Linq;
using System.Text;

namespace FirstApplication
{
    public class RealPolynomial
    {
        /// <summary>
        /// Array storing the coefficients of the RealPolynomial
        /// </summary>
        private readonly double[] coeff;

        /// <summary>
        /// Integer storing the degree of the RealPolynomial 
        /// </summary>
        private readonly int n; 

        public static double[] zero = { 0 };

        /// <summary>
        /// The zero RealPolynomial
        /// </summary>
        public static RealPolynomial zeroPolynomial = new RealPolynomial(zero);


        //Constructors

        /// <summary>
        /// Creates a new RealPolynomial, where the coefficient of x^i is <paramref name="d"/>[i]
        /// </summary>
        public RealPolynomial(double[] d)
        {
            bool ZeroArray = true;

            for (int i = d.Length - 1; i >= 0; i--)
            {
                if (d[i] != 0)
                {
                    n = i;
                    ZeroArray = false;
                    break;
                }
            }

            if (ZeroArray == false)
            {
                coeff = new double[n + 1];
                for (int i = 0; i < coeff.Length; i++)
                {
                    coeff[i] = d[i];
                }
            }

            else
            {
                n = -1;
                coeff = new double[1];
            }
        }


        /// <summary>
        /// Returns a string of the RealPolynomial
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int zeroCounter = 0;

            for (int i = 0; i < coeff.Length; i++)
            {
                switch (i)
                {
                    //case dealing with the constant term
                    case 0:

                        if (coeff[i] != 0)
                        {
                            sb.Append(coeff[i] + " ");
                        }

                        else
                        {
                            zeroCounter++;
                        }

                        break;

                    //case dealing with the linear term
                    case 1:

                        if (coeff[i - 1] != 0) //deals with case when constant term is non-zero
                        {
                            if (coeff[i] > 0)
                            {
                                if (coeff[i] == 1)
                                {
                                    sb.Append("+ x ");
                                }

                                else
                                {
                                    sb.Append("+ " + coeff[i] + "x ");
                                }
                            }

                            if (coeff[i] < 0)
                            {
                                if (coeff[i] == -1)
                                {
                                    sb.Append("- x ");
                                }

                                else
                                {
                                    sb.Append("- " + Math.Abs(coeff[i]) + "x ");
                                }
                            }

                            if (coeff[i] == 0)
                            {
                                zeroCounter++;
                            }
                        }

                        else //deals with case when constant term is 0
                        {
                            if (coeff[i] > 0)
                            {
                                if (coeff[i] == 1)
                                {
                                    sb.Append("x ");
                                }

                                else
                                {
                                    sb.Append(coeff[i] + "x ");
                                }
                            }

                            if (coeff[i] < 0)
                            {
                                if (coeff[i] == -1)
                                {
                                    sb.Append("- x ");
                                }

                                else
                                {
                                    sb.Append("- " + Math.Abs(coeff[i]) + "x ");
                                }
                            }

                            if (coeff[i] == 0)
                            {
                                zeroCounter++;
                            }
                        }

                        break;

                    default:

                        if (zeroCounter == i) //case when all the coefficients before the current one are 0
                        {
                            if (coeff[i] > 0)
                            {
                                if (coeff[i] == 1)
                                {
                                    sb.Append("x" + UsefulTools.Superscript(i) + " ");
                                }

                                else
                                {
                                    sb.Append(coeff[i] + "x" + UsefulTools.Superscript(i) + " ");
                                }
                            }

                            if (coeff[i] < 0)
                            {
                                if (coeff[i] == -1)
                                {
                                    sb.Append("- x" + UsefulTools.Superscript(i) + " ");
                                }

                                else
                                {
                                    sb.Append("- " + Math.Abs(coeff[i]) + "x" + UsefulTools.Superscript(i) + " ");
                                }
                            }

                            if (coeff[i] == 0)
                            {
                                zeroCounter++;
                            }
                        }

                        else //case where there's already been a non-zero coefficient
                        {
                            if (coeff[i] > 0)
                            {
                                if (coeff[i] == 1)
                                {
                                    sb.Append("+ x" + UsefulTools.Superscript(i) + " ");
                                }

                                else
                                {
                                    sb.Append("+ " + coeff[i] + "x" + UsefulTools.Superscript(i) + " ");
                                }
                            }

                            if (coeff[i] < 0)
                            {
                                if (coeff[i] == -1)
                                {
                                    sb.Append("- x" + UsefulTools.Superscript(i) + " ");
                                }

                                else
                                {
                                    sb.Append("- " + Math.Abs(coeff[i]) + "x" + UsefulTools.Superscript(i) + " ");
                                }
                            }

                            if (coeff[i] == 0)
                            {
                                zeroCounter++;
                            }
                        }

                        break;
                }
            }

            if (zeroCounter == coeff.Length)
            {
                return 0.ToString();
            }

            else
            {
                return sb.ToString();
            }

        }


        /// <summary>
        /// Returns the degree of the RealPolynomial
        /// </summary>
        public int Degree()
        {
            return n;
        }

        /// <summary>
        /// Returns coeff[<paramref name="i"/>] of the RealPolynomial
        /// </summary>
        public double GetCoeff(int i)
        {
            return coeff[i];
        }


        /// <summary>
        /// Returns the sum of RealPolynomial <paramref name="p"/> and RealPolynomial <paramref name="q"/>
        /// </summary>
        public static RealPolynomial operator +(RealPolynomial p, RealPolynomial q)
        {
            if (p.n == q.n) //case where the degrees are the same
            {
                double[] sumCoeff = new double[p.n + 1];
                for (int i = 0; i < sumCoeff.Length; i++)
                {
                    sumCoeff[i] = p.coeff[i] + q.coeff[i];
                }

                RealPolynomial sum = new RealPolynomial(sumCoeff);
                return sum;
            }

            else if (p.n > q.n) //case where degree of p is bigger than degree of q
            {
                double[] sumCoeff = new double[p.n + 1];
                for (int i = 0; i < q.coeff.Length; i++)
                {
                    sumCoeff[i] = p.coeff[i] + q.coeff[i];
                }

                for (int i = q.coeff.Length; i < sumCoeff.Length; i++)
                {
                    sumCoeff[i] = p.coeff[i];
                }

                RealPolynomial sum = new RealPolynomial(sumCoeff);
                return sum;
            }

            else //case where degree of q is greater than degree of p
            {
                double[] sumCoeff = new double[q.n + 1];
                for (int i = 0; i < p.coeff.Length; i++)
                {
                    sumCoeff[i] = p.coeff[i] + q.coeff[i];
                }

                for (int i = p.coeff.Length; i < sumCoeff.Length; i++)
                {
                    sumCoeff[i] = q.coeff[i];
                }

                RealPolynomial sum = new RealPolynomial(sumCoeff);
                return sum;
            }
        }

        /// <summary>
        /// Returns the sum of RealPolynomial <paramref name="p"/> and double <paramref name="d"/>
        /// </summary>
        public static RealPolynomial operator +(RealPolynomial p, double d)
        {
            double[] sumCoeff = new double[p.coeff.Length];
            sumCoeff[0] = d + p.coeff[0];

            for (int i = 1; i < sumCoeff.Length; i++)
            {
                sumCoeff[i] = p.coeff[i];
            }

            RealPolynomial sum = new RealPolynomial(sumCoeff);
            return sum;
        }

        /// <summary>
        /// Returns the sum of Complex <paramref name="z"/> and RealPolynomial <paramref name="p"/>
        /// </summary>
        public static RealPolynomial operator +(double d, RealPolynomial p)
        {
            return p + d;
        }


        /// <summary>
        /// Returns RealPolynomial <paramref name="q"/> subtracted from RealPolynomial <paramref name="p"/>
        /// </summary>
        public static RealPolynomial operator -(RealPolynomial p, RealPolynomial q)
        {
            if (p.n == q.n) //case where the degrees are the same
            {
                double[] diffCoeff = new double[p.n + 1];
                for (int i = 0; i < diffCoeff.Length; i++)
                {
                    diffCoeff[i] = p.coeff[i] - q.coeff[i];
                }

                RealPolynomial diff = new RealPolynomial(diffCoeff);
                return diff;
            }

            else if (p.n > q.n) //case where degree of p is greater than degree of q
            {
                double[] diffCoeff = new double[p.n + 1];
                for (int i = 0; i < q.coeff.Length; i++)
                {
                    diffCoeff[i] = p.coeff[i] - q.coeff[i];
                }

                for (int i = q.coeff.Length; i < diffCoeff.Length; i++)
                {
                    diffCoeff[i] = p.coeff[i];
                }

                RealPolynomial diff = new RealPolynomial(diffCoeff);
                return diff;
            }

            else //case where degree of q is greater than degree of p
            {
                double[] diffCoeff = new double[q.n + 1];
                for (int i = 0; i < p.coeff.Length; i++)
                {
                    diffCoeff[i] = p.coeff[i] - q.coeff[i];
                }

                for (int i = p.coeff.Length; i < diffCoeff.Length; i++)
                {
                    diffCoeff[i] = -q.coeff[i];
                }

                RealPolynomial diff = new RealPolynomial(diffCoeff);
                return diff;
            }
        }


        /// <summary>
        /// Returns double <paramref name="d"/> subtracted from RealPolynomial <paramref name="p"/>
        /// </summary>
        public static RealPolynomial operator -(RealPolynomial p, double d)
        {
            double[] diffCoeff = new double[p.coeff.Length];
            diffCoeff[0] = p.coeff[0] - d;

            for (int i = 1; i < diffCoeff.Length; i++)
            {
                diffCoeff[i] = p.coeff[i];
            }

            RealPolynomial diff = new RealPolynomial(diffCoeff);
            return diff;
        }

        /// <summary>
        /// Returns RealPolynomial <paramref name="p"/> subtracted from double <paramref name="d"/>
        /// </summary>
        public static RealPolynomial operator -(double d, RealPolynomial p)
        {
            return (p - d) * -1;
        }

        /// <summary>
        /// Returns RealPolynomial -<paramref name="p"/> 
        /// </summary>
        public static RealPolynomial operator -(RealPolynomial p)
        {
            return -1 * p;
        }
        /// <summary>
        /// Returns the product of RealPolynomial <paramref name="p"/> and RealPolynomial <paramref name="q"/>
        /// </summary>
        public static RealPolynomial operator *(RealPolynomial p, RealPolynomial q)
        {
            double[] product = new double[p.n + q.n + 1];

            for (int i = 0; i < p.n + 1; i++)
            {
                for (int j = 0; j < q.n + 1; j++)
                {
                    product[i + j] += p.coeff[i] * q.coeff[j];
                }
            }

            return new RealPolynomial(product);
        }


        /// <summary>
        /// Returns the product of RealPolynomial <paramref name="p"/> and double <paramref name="scalar"/>
        /// </summary>
        public static RealPolynomial operator *(RealPolynomial p, double scalar)
        {
            double[] prod = new double[p.coeff.Length];

            for (int i = 0; i < p.coeff.Length; i++)
            {
                prod[i] = scalar * p.coeff[i];
            }

            RealPolynomial scaled = new RealPolynomial(prod);
            return scaled;
        }

        /// <summary>
        /// Returns the product of double <paramref name="scalar"/> and RealPolynomial <paramref name="p"/>
        /// </summary>
        public static RealPolynomial operator *(double scalar, RealPolynomial p)
        {
            return p * scalar;
        }


        /// <summary>
        /// Returns a double of the RealPolynomial evaluated at x = <paramref name="d"/> 
        /// </summary>
        public double Evaluate(double d)
        {
            double value = 0;
            for (int i = 0; i < coeff.Length; i++)
            {
                value += coeff[i] * Math.Pow(d, i);
            }

            return value;
        }

        /// <summary>
        /// Returns true if RealPolynomial <paramref name="p"/> and RealPolynomial <paramref name="q"/> are equal; returns false otherwise
        /// </summary>
        public static bool Equals(RealPolynomial p, RealPolynomial q)
        {
            if (p.n != q.n)
            {
                return false;
            }

            else
            {
                for (int i = 0; i < p.coeff.Length; i++)
                {
                    if (p.coeff[i] != q.coeff[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }


    }
}
