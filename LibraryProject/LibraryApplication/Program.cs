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
            //List<Book> listbook = new List<Book>();
            //listbook.Add(TextFileHandler.CreateNewBook("metro 2033", "fantasy", 709));


            //List<OrdinaryUser> listusers = new List<OrdinaryUser>();
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Maciek", "Gos", 2));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Miłosz", "Gos", 4));

            List<Librarian> listlibrarians = new List<Librarian>();
            listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Dominik", "Gos", 1));
            listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Łukasz", "Gos", 1));

            Console.ReadKey();
        }
    }
}
