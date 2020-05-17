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
            //TextFileHandler.ClearData();


            //List<Book> listbook = new List<Book>();
            //listbook.Add(TextFileHandler.CreateNewBook("metro 2033", "fantasy", 709));
            //listbook.Add(TextFileHandler.CreateNewBook("metro 2034", "fantasy", 109));
            //listbook.Add(TextFileHandler.CreateNewBook("metro 2035", "fantasy", 79));
            //listbook.Add(TextFileHandler.CreateNewBook("metro 2036", "fantasy", 809));

            //List<Movie> listmovie = new List<Movie>();
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny", "kryminalny", 60));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny2", "kryminalny", 602));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny3", "kryminalny", 603));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny4", "kryminalny", 75));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny5", "kryminalny", 890));

            //List<OrdinaryUser> listusers = new List<OrdinaryUser>();
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Jacek", "Gos", "a"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Szymon", "Gos", "a"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Łukasz", "Gos", "a"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Wojciech", "Gos", "a"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Dominik", "Gos", "a"));

            //List<Librarian> listlibrarians = new List<Librarian>();
            //listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Jacek", "Gos", "a"));
            //listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Tata", "Gos", "a"));

            Menu.LogInView();

            Console.ReadKey();
        }
    }
}
