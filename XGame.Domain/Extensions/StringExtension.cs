﻿using System.Text;

namespace XGame.Domain.Extensions
{
    public static class StringExtension
    {

        public static string ConvertToMD5(this string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            var pass = (password + "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
            {
                sbString.Append(t.ToString("x2"));
            }

            return sbString.ToString();
        }

    }

}