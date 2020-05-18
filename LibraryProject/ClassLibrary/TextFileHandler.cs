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

        static string accountsInfoPath = @"D:\C#\ProjectLibrary\LibraryProject\DataDirectory\UsersDirectory\AccountsInfo.txt";

        static List<string> booksFileLines = File.ReadAllLines(booksFilePath).ToList();
        static List<string> moviesFileLines = File.ReadAllLines(moviesFilePath).ToList();

        public static Book CreateNewBook(string title, string section, int pages)
        {
            File.AppendAllText(booksFilePath, $"{getCurrentBookID() + 1}, {title},{section},{pages}\n"); //Add new line to .txt file           
            return new Book(title, section, getCurrentBookID() + 1, pages);
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

        public static Movie CreateNewMovie(string title, string section, int duration)
        {
            File.AppendAllText(moviesFilePath, $"{getCurrentMovieID() + 1},{title},{section},{duration}\n"); //Add new line to .txt file           
            return new Movie(title, section, getCurrentMovieID() + 1, duration);
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

        public static OrdinaryUser CreateNewOrdinaryUser(string name, string surname, string password)
        {
            OrdinaryUser newOrdinaryUser = new OrdinaryUser(name, surname, 2, getCurrentOrdinaryUserID() + 1, password);

            File.AppendAllText(ordinaryUsersListPath, $"{newOrdinaryUser.UserID},{name},{surname},{2},0\n"); //Add new line to .txt file
            File.AppendAllText(accountsInfoPath, $"OrdinaryUser{newOrdinaryUser.UserID},{password},{newOrdinaryUser.UserType},{newOrdinaryUser.UserID}\n");

            CreateNewOrdinaryUserDataFiles(newOrdinaryUser);
         
            return newOrdinaryUser;
        }

        public static void CreateNewOrdinaryUserDataFiles(OrdinaryUser newOrdinaryUser)
        {
            string newOrdinaryUsersDirectory = ordinaryUsersDirectoryPath + @"\OrdinaryUser" + newOrdinaryUser.UserID;

            Directory.CreateDirectory(newOrdinaryUsersDirectory);
            File.Create(newOrdinaryUsersDirectory + @"\Borrowings_OrdinaryUser" + newOrdinaryUser.UserID + ".txt");
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

        public static string GetOrdinaryUserDataFromFile(int ordinaryUserID)
        {
            string[] lines = File.ReadAllLines(ordinaryUsersListPath);
            string ordinaryUserData;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] arguments = lines[i].Split(',');
                if (arguments[0] == $"{ordinaryUserID}")
                {
                    ordinaryUserData = lines[i];
                    return ordinaryUserData;
                }
            }

            return null;
        }

        public static Librarian CreateNewLibrarian(string name, string surname, string password)
        {
            Librarian newLibrarian = new Librarian(name, surname, 1, getCurrentLibrarianID() + 1, password);

            File.AppendAllText(librariansListPath, $"{newLibrarian.UserID},{name},{surname},{1}\n"); //Add new line to .txt file
            File.AppendAllText(accountsInfoPath, $"Librarian{newLibrarian.UserID},{password},{newLibrarian.UserType},{newLibrarian.UserID}\n");

            CreateNewLibrarianDataFiles(newLibrarian);

            return newLibrarian;
        }
        
        public static void CreateNewLibrarianDataFiles(Librarian newLibrarian)
        {
            string newLibrariansDirectory = librariansDirectoryPath + @"\Librarian" + newLibrarian.UserID;

            Directory.CreateDirectory(newLibrariansDirectory);
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

        public static string GetLibrarianDataFromFile(int librarianID)
        {
            string[] lines = File.ReadAllLines(librariansListPath);
            string librarianData;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] arguments = lines[i].Split(',');
                if (arguments[0] == $"{librarianID}")
                {
                    librarianData = lines[i];
                    return librarianData;
                }
            }

            return null;
        }

        public static int GetUserIdIfExist(string login, string password)
        {
            string[] lines = File.ReadAllLines(accountsInfoPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == login && parts[1] == password)
                {
                    return int.Parse(parts[3]);
                }
            }
            return -1;
        }

        public static bool RemoveOrdinaryUserDataFromFile(int ordinaryUserID, string OrdinaryUserAccountName)
        {
            List<string> ordinaryUserList = File.ReadAllLines(ordinaryUsersListPath).ToList();
            List<string> UserAccountDataList = File.ReadAllLines(accountsInfoPath).ToList();

            int indexToRemove1;
            int indexToRemove2;

            indexToRemove1 = FindOrdinaryUserIndexToRemove(ordinaryUserList, ordinaryUserID);
            indexToRemove2 = FindUserAccountListIndexToRemove(UserAccountDataList, OrdinaryUserAccountName);

            if (indexToRemove1 > -1 && indexToRemove2 > -1 && RemoveOrdinaryUserDirectories(OrdinaryUserAccountName))
            {
                ordinaryUserList.RemoveAt(indexToRemove1);
                File.WriteAllLines(ordinaryUsersListPath, ordinaryUserList);

                UserAccountDataList.RemoveAt(indexToRemove2);
                File.WriteAllLines(accountsInfoPath, UserAccountDataList);

                return true;
            }
            return false;
        }

        public static int FindOrdinaryUserIndexToRemove(List<string> ordinaryUserList, int ordinaryUserID)
        {
            string[] ordinaryUserDataTmp;

            for (int i = 0; i < ordinaryUserList.Count; i++)
            {
                ordinaryUserDataTmp = ordinaryUserList[i].Split(',');

                if (int.Parse(ordinaryUserDataTmp[0]) == ordinaryUserID)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindUserAccountListIndexToRemove(List<string> UserAccountDataList, string OrdinaryUserAccountName)
        {
            string[] UserDataTmp;

            for (int i = 0; i < UserAccountDataList.Count; i++)
            {
                UserDataTmp = UserAccountDataList[i].Split(',');

                if (UserDataTmp[0] == OrdinaryUserAccountName)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool RemoveOrdinaryUserDirectories(string OrdinaryUserAccountName)
        {
            string newOrdinaryUsersDirectory = ordinaryUsersDirectoryPath + @"\" + OrdinaryUserAccountName;

            if (Directory.Exists(newOrdinaryUsersDirectory))
            {
                Directory.Delete(newOrdinaryUsersDirectory, true);
                return true;
            }
            return false;           
        }

        public static string GetLibrarianListFromFile()
        {
            List<string> librarianListFromFile = File.ReadAllLines(librariansListPath).ToList();
            string[] librarianSeparatedData;

            StringBuilder librarianList = new System.Text.StringBuilder();
            librarianList.AppendLine("ID\t|Imię\t|Nazwisko");

            foreach (string line in librarianListFromFile)
            {
                librarianSeparatedData = line.Split(',');
                librarianList.AppendLine($"{librarianSeparatedData[0]}\t|{librarianSeparatedData[1]}\t|{librarianSeparatedData[2]}");
            }

            return librarianList.ToString();
        }

        public static string GetOrdinaryUserListFromFile()
        {
            List<string> ordinaryUserListFromFile = File.ReadAllLines(ordinaryUsersListPath).ToList();
            string[] ordinaryUserSeparatedData;

            StringBuilder ordinaryUserList = new System.Text.StringBuilder();
            ordinaryUserList.AppendLine("ID\t|Imię\t|Nazwisko\t|Naliczone kary [zł]");

            foreach (string line in ordinaryUserListFromFile)
            {
                ordinaryUserSeparatedData = line.Split(',');
                ordinaryUserList.AppendLine($"{ordinaryUserSeparatedData[0]}\t|{ordinaryUserSeparatedData[1]}\t|{ordinaryUserSeparatedData[2]}\t|{ordinaryUserSeparatedData[4]}");
            }

            return ordinaryUserList.ToString();
        }

        public static string GetBooksListFromFile()
        {
            List<string> booksListFromFile = File.ReadAllLines(booksFilePath).ToList();
            string[] bookSeparatedData;

            StringBuilder bookList = new System.Text.StringBuilder();
            bookList.AppendLine("ID\t|Tytuł\t|Rodzaj\t|Ilość stron");

            foreach (string line in booksListFromFile)
            {
                bookSeparatedData = line.Split(',');
                bookList.AppendLine($"{bookSeparatedData[0]}\t|{bookSeparatedData[1]}\t|{bookSeparatedData[2]}\t|{bookSeparatedData[3]}");
            }

            return bookList.ToString();
        }

        public static string GetMoviesListFromFile()
        {
            List<string> moviesListFromFile = File.ReadAllLines(moviesFilePath).ToList();
            string[] movieSeparatedData;

            StringBuilder movieList = new System.Text.StringBuilder();
            movieList.AppendLine("ID\t|Tytuł\t|Rodzaj\t|Czas trwania");

            foreach (string line in moviesListFromFile)
            {
                movieSeparatedData = line.Split(',');
                movieList.AppendLine($"{movieSeparatedData[0]}\t|{movieSeparatedData[1]}\t|{movieSeparatedData[2]}\t|{movieSeparatedData[3]}");
            }

            return movieList.ToString();
        }

        public static void ClearData()
        {
            File.Create(booksFilePath);
            File.Create(moviesFilePath);
            File.Create(ordinaryUsersListPath);
            File.Create(librariansListPath);
            File.Create(accountsInfoPath);

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
    }
}

