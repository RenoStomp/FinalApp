using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallApp.ValidationHelper
{
    public class StringValidator
    {
        /// <summary>
        /// String validation.
        /// </summary>
        public static class ValidationString
        {
            /// <summary>
            /// Checks if the string is not null or empty.
            /// </summary>
            /// <param name="text">The string to be checked.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public static void CheckIsNotNull(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    throw new ArgumentNullException(nameof(text), "Параметр не должен быть равен Null");
                }
            }
        }
    }
}
