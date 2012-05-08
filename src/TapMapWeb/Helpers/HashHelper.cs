using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace TapMapWeb.Helpers
{
    public static class HashHelper
    {
        public static string ToHashedString(string source)
        {
            var bytesToHash = Encoding.ASCII.GetBytes(source);
            var hashedBytes = HashAlgorithm.Create("SHA1").ComputeHash(bytesToHash);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}