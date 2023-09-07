using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Security
{
    public class HashString
    {
        public static string hashString(string str)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;

            MD5 mD5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(str);
            encodedBytes = mD5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
    }
}
