using System;
using System.Collections.Generic;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, Pages: {1}", Title, Pages);
        }
    }

    internal class CD
    {
        public string Name { get; set; }
        public int Volume { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Volume: {1}", Name, Volume);
        }
    }

    internal class AbstractFactory
    {
        public static object CreateInstance(string className, Dictionary<string, Object> values)
        {
            var type = Type.GetType(className);
            var instance = Activator.CreateInstance(type);
            foreach (var entry in values)
                type.GetProperty(entry.Key).SetValue(instance, entry.Value, null);
            return instance;
        }

        public static void MainDemo()
        {
            var book = (Book) CreateInstance("LearnCS.patterns.Book", new Dictionary<string, object>
            {
                {"Title", "Who moved my cheese?"},
                {"Pages", 94}
            });
            Console.WriteLine(book);
            var cd = (CD) CreateInstance("LearnCS.patterns.CD", new Dictionary<string, object>
            {
                {"Name", "Dhoom"},
                {"Volume", 80}
            });
            Console.WriteLine(cd);
        }
    }
}