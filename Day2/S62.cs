using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LearnCS.ooad
{
    internal class AccumulateBookDetails
    {
        internal int InvalidRecords;
        internal double TotalPrice;
        internal int ValidRecords;

        public void Process(Func<String> input, Func<String, Double> extractPrice)
        {
            string next = input.Invoke(); //Skip header
            while ((next = input.Invoke()) != "")
            {
                double price = extractPrice.Invoke(next);
                if (price > 0) ValidRecords++;
                else InvalidRecords++;
                TotalPrice += price;
            }
        }
    }

    internal class ReadEachLineOfFile
    {
        private readonly StreamReader s;

        public ReadEachLineOfFile()
        {
            try
            {
                s = new StreamReader("book.csv");
            }
            catch (FileNotFoundException e)
            {
                Console.Error.WriteLine("File not found ${0}", e);
            }
        }

        public String nextLine()
        {
            if (s == null) return "";
            if (s.EndOfStream)
            {
                s.Dispose();
                return "";
            }
            return s.ReadLine();
        }
    }

    internal class BookRecord
    {
        private static readonly BookRecord Empty = new BookRecord("", "", "");
        private readonly String _isbn;
        private readonly String _price;
        private readonly String _title;

        public BookRecord(String isbn, String title, String price)
        {
            _isbn = isbn;
            _title = title;
            _price = price;
        }

        public static BookRecord CreateFrom(String line)
        {
            if (string.IsNullOrEmpty(line)) return Empty;
            string[] items = line.Split(',');
            if (items.Length != 3) return Empty;
            return new BookRecord(items[0], items[1], items[2]);
        }

        public static double GetValidPrice(BookRecord b)
        {
            double r = 0;
            if (new Regex("[0-9]+").IsMatch(b._price))
                Double.TryParse(b._price, out r);
            return r;
        }
    }

    public class OOFunctionalCSV
    {
        public static void Main1()
        {
            var acc = new AccumulateBookDetails();
            var rin = new ReadEachLineOfFile();
            acc.Process(rin.nextLine, line => BookRecord.GetValidPrice(BookRecord.CreateFrom(line)));
            Console.WriteLine(
                "Total price of all Books {0}\n. Total Valid records - {1}.    Total Invalid records - {2}",
                acc.TotalPrice, acc.ValidRecords, acc.InvalidRecords);
        }
    }

// The above code is better designed because it can easily accommodate 
// new features like take sum of costliest 3 books only.
}