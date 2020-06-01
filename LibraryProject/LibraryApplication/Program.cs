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


            ////List<Book> listbook = new List<Book>();
            ////listbook.Add(TextFileHandler.CreateNewBook("Gra o tron", "fantasy", 500));
            ////listbook.Add(TextFileHandler.CreateNewBook("Starcie królów", "fantasy", 605));
            ////listbook.Add(TextFileHandler.CreateNewBook("Nawałnica mieczy", "fantasy", 679));
            ////listbook.Add(TextFileHandler.CreateNewBook("Uczta dla wron", "fantasy", 1029));
            ////listbook.Add(TextFileHandler.CreateNewBook("Taniec ze smokami", "fantasy", 849));
            ////listbook.Add(TextFileHandler.CreateNewBook("Władca pierścieni", "fantasy", 743));
            ////listbook.Add(TextFileHandler.CreateNewBook("Hobbit", "fantasy", 567));
            ////listbook.Add(TextFileHandler.CreateNewBook("Ojciec chrzestny", "kryminał", 543));

            ////List<Movie> listmovie = new List<Movie>();
            ////listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny", "kryminał", 156));
            ////listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny 2", "kryminał", 189));
            ////listmovie.Add(TextFileHandler.CreateNewMovie("Ojciec chrzestny 3", "kryminał", 165));
            ////listmovie.Add(TextFileHandler.CreateNewMovie("Władca pierścieni: drużyna pierścienia", "fantasy", 196));
            ////listmovie.Add(TextFileHandler.CreateNewMovie("Władca pierścieni: dwie wieże", "fantasy", 204));
            ////listmovie.Add(TextFileHandler.CreateNewMovie("Władca pierścieni: powrót króla", "fantasy", 176));

            ////List<OrdinaryUser> listusers = new List<OrdinaryUser>();
            ////listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Zenek", "Gos", "a"));
            ////listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Szymon", "Gos", "a"));
            ////listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Łukasz", "Gos", "a"));
            ////listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Wojciech", "Gos", "a"));
            ////listusers.Add(TextFileHandler.CreateNewOrdinaryUser("Dominik", "Gos", "a"));

            //List<Librarian> listlibrarians = new List<Librarian>();
            //listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Jacek", "Gos", "a"));
            ////listlibrarians.Add(TextFileHandler.CreateNewLibrarian("Mama", "Gos", "a"));

            Menu.LogInView();

            //Console.WriteLine(TextFileHandler.GetBorrowingElementId(6, 2));


            Console.ReadKey();
        }
    }
}
