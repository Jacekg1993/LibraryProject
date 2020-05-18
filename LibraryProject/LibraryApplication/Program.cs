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
            //listbook.Add(TextFileHandler.CreateNewBook("Władca pierścieni", "fantasy", 1029));

            //List<Movie> listmovie = new List<Movie>();
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny", "kryminalny", 60));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny2", "kryminalny", 602));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny3", "kryminalny", 603));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Władca pierścieni 1", "fantasy", 75));
            //listmovie.Add(TextFileHandler.CreateNewMovie("Władca pierścieni 1", "fantasy", 890));

            //List<OrdinaryUser> listusers = new List<OrdinaryUser>();
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Zenek", "Gos", "b"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Szymon", "Gos", "c"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Łukasz", "Gos", "d"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Wojciech", "Gos", "e"));
            //listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Dominik", "Gos", "f"));

            //List<Librarian> listlibrarians = new List<Librarian>();
            //listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Jacek", "Gos", "a"));
            //listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Tata", "Gos", "a"));

            Menu.LogInView();

            //Console.WriteLine(TextFileHandler.GetMoviesListFromFile());
            //Console.WriteLine();
            //Console.WriteLine(TextFileHandler.GetBooksListFromFile());

            Console.ReadKey();
        }
    }
}
