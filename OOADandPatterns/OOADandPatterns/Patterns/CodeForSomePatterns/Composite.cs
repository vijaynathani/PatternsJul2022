using System;
using System.Collections.Generic;
using System.Linq;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal interface DiskObject
    {
        int GetSize();
        void Delete();
    }

    internal class File : DiskObject
    {
        private readonly string _name;
        private readonly int _size;

        public File(string name, int size)
        {
            this._name = name;
            this._size = size;
        }

        public void Delete()
        {
            Console.WriteLine("{0} deleted", _name);
        }

        public int GetSize()
        {
            return _size;
        }
    }

    internal class Directory : DiskObject
    {
        public List<DiskObject> Children = new List<DiskObject>();
        private readonly String _name;

        public Directory(String name)
        {
            this._name = name;
        }

        public int GetSize()
        {
            return Children.Sum(d => d.GetSize());
        }

        public void Delete()
        {
            foreach (var d in Children)
                d.Delete();
            Console.WriteLine("{0} deleted", _name);
        }
    }

    internal class Composite
    {
        public static void Main1(string[] args)
        {
            DiskObject f1 = new File("a", 50);
            DiskObject f2 = new File("b", 30);
            DiskObject f3 = new File("c", 100);
            var d1 = new Directory("d1");
            var d2 = new Directory("d2");
            d1.Children.Add(f1);
            d1.Children.Add(f2);
            d2.Children.Add(f3);
            d2.Children.Add(d1);
            Console.WriteLine("The size of top dir is " + d2.GetSize());
            d2.Delete();
        }
    }
}