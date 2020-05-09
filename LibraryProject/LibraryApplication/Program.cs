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
            List<Book> listbook = new List<Book>();
            listbook.Add(TextFileHandler.CreateNewBook("Wiedzmin 3", "fantasy", 500));

            Console.WriteLine(listbook[0].ElementTitle);

            Console.ReadKey();
        }
    }
}
