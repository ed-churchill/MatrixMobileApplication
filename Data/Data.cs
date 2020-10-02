using FirstApplication;
using System.Collections.Generic;

namespace MatrixMobileApplication
{
    public static class Data
    {
        /// <summary>
        /// List storing the RealMatrices
        /// </summary>
        public static List<RealMatrix> MatrixList = new List<RealMatrix>();

        /// <summary>
        /// List storing the available names for matrices
        /// </summary>
        public static List<string> DynamicAlphabet = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    }
}