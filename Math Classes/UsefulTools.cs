using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApplication
{
    public static class UsefulTools
    {
        /// <summary>
        /// Returns a string of the integer <paramref name="num"/> as a superscript 
        /// </summary>
        public static string Superscript(int num)
        {
            var digits = num.ToString().Select(digit => DigitSuperscript(digit - '0'));
            return string.Concat(digits);

            static char DigitSuperscript(int num)
            {
                if (num == 1)
                    return '\u0089';
                if (num == 2 || num == 3)
                    return (char)('\u00B0' + num);

                return (char)('\u2070' + num);
            }
        }

        /// <summary>
        /// Returns a 2D array form of the double array <paramref name="d"/> 
        /// </summary>
        public static double[,] To2DArray(double[] d)
        {
            double[,] _d = new double[d.Length, 1];
            for (int i = 0; i < d.Length; i++)
            {
                _d[i, 0] = d[i];
            }

            return _d;
        }

    }
}
