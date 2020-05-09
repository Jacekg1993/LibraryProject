using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Book a = new Book("Godfather", "Criminal", 300);

            OrdinaryUser b = new OrdinaryUser("Jacek", "Gos", 2);


            Console.WriteLine(b.SurName);

            Console.ReadKey();
        }
    }
}
