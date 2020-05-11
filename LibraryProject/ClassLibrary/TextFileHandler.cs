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
        static string librariansDirectoryPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory\librariansDirectory";

        static List<string> booksFileLines = File.ReadAllLines(booksFilePath).ToList();
        static List<string> moviesFileLines = File.ReadAllLines(moviesFilePath).ToList();
        
        public static Book CreateNewBook(string title, string section, int pages)
        {
            File.AppendAllText(booksFilePath, $"\n{title},{section},{pages}"); //Add new line to .txt file           
            return new Book(title, section, pages);
        }

        public static OrdinaryUser CreateNewOrdinaryUser(string name, string surname, byte type)
        {
            OrdinaryUser newOrdinaryUser = new OrdinaryUser(name, surname, type, getCurrentOrdinaryUserID() + 1);

            File.AppendAllText(ordinaryUsersListPath, $"\n{newOrdinaryUser.UserID},{name},{surname},{type}"); //Add new line to .txt file

            CreateNewOrdinaryUserDataFiles(newOrdinaryUser);

            return newOrdinaryUser;
        }

        public static Librarian CreateNewLibrarian(string name, string surname, byte type)
        {
            Librarian newLibrarian = new Librarian(name, surname, type, getCurrentLibrarianID() + 1);

            File.AppendAllText(librariansListPath, $"\n{newLibrarian.UserID},{name},{surname},{type}"); //Add new line to .txt file

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
            string lastLine = File.ReadLines(ordinaryUsersListPath).Last(); //Reading last line from .txt file
            string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
            return int.Parse(argumentsFromFile[0]);
        }

        public static int getCurrentLibrarianID()
        {
            string lastLine = File.ReadLines(librariansListPath).Last(); //Reading last line from .txt file
            string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
            return int.Parse(argumentsFromFile[0]);
        }

        //public static void 
    }
}
