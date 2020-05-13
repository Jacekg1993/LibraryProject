using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace ClassLibrary
{    
    public static class TextFileHandler
    {
        static string booksFilePath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\LibraryElementsDirectory\Books.txt";
        static string moviesFilePath = @"\C#\ProjectLibrary\LibraryProject\DataDirectory\LibraryElementsDirectory\Movies.txt";

        static string ordinaryUsersListPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory\OrdinaryUsers.txt";
        static string librariansListPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory\Librarians.txt";

        static string usersDirectoryPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory";
        static string ordinaryUsersDirectoryPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory\OrdinaryUsersDirectory";        
        static string librariansDirectoryPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory\LibrariansDirectory";

        static List<string> booksFileLines = File.ReadAllLines(booksFilePath).ToList();
        static List<string> moviesFileLines = File.ReadAllLines(moviesFilePath).ToList();
        
        public static Book CreateNewBook(string title, string section, int pages)
        {
            File.AppendAllText(booksFilePath, $"{getCurrentBookID() + 1}, {title},{section},{pages}\n"); //Add new line to .txt file           
            return new Book(title, section, getCurrentBookID() + 1, pages);
        }

        public static Movie CreateNewMovie(string title, string section, int duration)
        {
            File.AppendAllText(moviesFilePath, $"{getCurrentMovieID() + 1},{title},{section},{duration}\n"); //Add new line to .txt file           
            return new Movie(title, section, getCurrentMovieID() + 1, duration);
        }

        public static OrdinaryUser CreateNewOrdinaryUser(string name, string surname)
        {
            OrdinaryUser newOrdinaryUser = new OrdinaryUser(name, surname, 2, getCurrentOrdinaryUserID() + 1);

            File.AppendAllText(ordinaryUsersListPath, $"{newOrdinaryUser.UserID},{name},{surname},{2}\n"); //Add new line to .txt file

            CreateNewOrdinaryUserDataFiles(newOrdinaryUser);

            return newOrdinaryUser;
        }

        public static Librarian CreateNewLibrarian(string name, string surname)
        {
            Librarian newLibrarian = new Librarian(name, surname, 1, getCurrentLibrarianID() + 1);

            File.AppendAllText(librariansListPath, $"{newLibrarian.UserID},{name},{surname},{1}\n"); //Add new line to .txt file

            CreateNewLibrarianDataFiles(newLibrarian);

            return newLibrarian;
        }

        public static void CreateNewOrdinaryUserDataFiles(OrdinaryUser newOrdinaryUser)
        {
            string newOrdinaryUsersDirectory = ordinaryUsersDirectoryPath + @"\OrdinaryUser_" + newOrdinaryUser.UserID;

            Directory.CreateDirectory(newOrdinaryUsersDirectory);
            File.Create(newOrdinaryUsersDirectory + @"\Borrowings_OrdinaryUser_" + newOrdinaryUser.UserID + ".txt");
        }

        public static void CreateNewLibrarianDataFiles(Librarian newLibrarian)
        {
            string newLibrariansDirectory = librariansDirectoryPath + @"\Librarian_" + newLibrarian.UserID;

            Directory.CreateDirectory(newLibrariansDirectory);
        }

        public static int getCurrentOrdinaryUserID()
        {
            string lastLine = File.ReadLines(ordinaryUsersListPath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(',');
                return int.Parse(argumentsFromFile[0]); 
            }
            return 0;
        }

        public static int getCurrentLibrarianID()
        {
            string lastLine = File.ReadLines(librariansListPath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
                return int.Parse(argumentsFromFile[0]); 
            }
            return 0;
        }

        public static int getCurrentBookID()
        {
            string lastLine = File.ReadLines(booksFilePath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
                return int.Parse(argumentsFromFile[0]);
            }           
            return 0;
        }

        public static int getCurrentMovieID()
        {
            string lastLine = File.ReadLines(moviesFilePath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
                return int.Parse(argumentsFromFile[0]);
            }
            return 0;
        }

        public static void ClearData()
        {
            File.Create(booksFilePath);
            File.Create(moviesFilePath);
            File.Create(ordinaryUsersListPath);
            File.Create(librariansListPath);

            DirectoryInfo dirOrdinaryUsers = new DirectoryInfo(ordinaryUsersDirectoryPath);
            foreach (DirectoryInfo dir in dirOrdinaryUsers.GetDirectories())
            {
                dir.Delete(true);
            }

            DirectoryInfo dirLibrarians = new DirectoryInfo(librariansDirectoryPath);
            foreach (DirectoryInfo dir in dirLibrarians.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        //public static void 
    }
}
