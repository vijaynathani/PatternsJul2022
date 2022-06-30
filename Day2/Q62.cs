using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LearnCS.ooad
{
// A CSV file book.csv contains lots of information in format
// ISBN,Title,Price
// 123,Java,500
// 234,C#,700
// 345,OOAD,600
//
// Our goal is to find sum all the book prices.
// Also report number of valid and invalid books.
// The procedural code is given below.
    internal class ProceduralCSV
    {
        private static double _currentBookPrice;

        public static void Main1()
        {
            double totalPrice = 0;
            int validRecords = 0, invalidRecords = 0;
            using (var s = new StreamReader("book.csv"))
            {
                s.ReadLine(); //Skip the header line
                while (!s.EndOfStream)
                {
                    ValidatePrice(s.ReadLine());
                    if (_currentBookPrice > 0) validRecords++;
                    else invalidRecords++;
                    totalPrice += _currentBookPrice;
                }
            }
            Console.WriteLine(
                "Total price of all Books {0}\n. Total Valid records - {1}.    Total Invalid records - {2}",
                totalPrice, validRecords, invalidRecords);
        }

        public static void ValidatePrice(String line)
        {
            _currentBookPrice = 0;
            if (string.IsNullOrEmpty(line)) return;
            string[] items = line.Split(',');
            if (items.Length != 3) return;
            String price = items[2].Trim();
            if (! new Regex("[0-9]+").IsMatch(price)) return;
            Double.TryParse(price, out _currentBookPrice);
        }
    }
}