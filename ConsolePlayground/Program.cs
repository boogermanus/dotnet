using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace ConsolePlayground
{
    class Program
    {
        static void Main(string[] args)
        {

            // var date = DateTime.UtcNow;
            // Console.WriteLine(date);
            // date = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);
            // Console.WriteLine(date);

            // Console.WriteLine(GeneratePassword("GovPay"));

            TestXDocument();
        }


        public static string GeneratePassword(string userId)
        {
            string passwordKey = "1ncode123!" + userId;
            var encoder = System.Text.Encoding.ASCII.GetEncoder();

            byte[] data = new byte[passwordKey.Length];

            encoder.GetBytes(passwordKey.ToCharArray(), 0, passwordKey.Length, data, 0, true);

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] result = md5.ComputeHash(data);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        public static void TestXDocument()
        {
            var doc = new XDocument(new XElement("transactionResult", new XAttribute("receiptNumber", "test")));

            var result = doc.Descendants("transactionResult").SingleOrDefault();
            Console.WriteLine(result);
        }
    }

}
