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

        //BOOK METHODS
        public static Book CreateNewBook(string title, string section, int pages)
        {
            File.AppendAllText(booksFilePath, $"{GetAvailableBookID() + 1}, {title},{section},{pages},0\n"); //Add new line to .txt file           
            return new Book(title, section, GetAvailableBookID() + 1, pages);
        }

        public static int GetAvailableBookID()
        {
            string lastLine = File.ReadLines(booksFilePath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
                return int.Parse(argumentsFromFile[0]);
            }
            return 0;
        }

        public static bool RemoveBook(int bookID)
        {
            List<string> bookList = File.ReadAllLines(booksFilePath).ToList();

            int indexToRemove;

            indexToRemove = FindBookIndexToRemove(bookList, bookID);

            if (indexToRemove > -1 )
            {
                bookList.RemoveAt(indexToRemove);
                File.WriteAllLines(booksFilePath, bookList);

                return true;
            }

            return false;
        }

        public static int FindBookIndexToRemove(List<string> bookList, int bookID)
        {
            string[] bookDataTmp;

            for (int i = 0; i < bookList.Count; i++)
            {
                bookDataTmp = bookList[i].Split(',');

                if (int.Parse(bookDataTmp[0]) == bookID)
                {
                    return i;
                }
            }
            return -1;
        }

        public static string SearchBookByTitle(string title)
        {
            string bookStatus = null;
            List<string> bookListFromFile = File.ReadAllLines(booksFilePath).ToList();

            string[] bookSeparatedData;

            StringBuilder booksList = new System.Text.StringBuilder();

            booksList.AppendLine("Znalezione książki: ");
            booksList.AppendLine("ID\t|Tytuł\t|Rodzaj\t|Liczba stron\t|Status");

            foreach (string book in bookListFromFile)
            {
                if (book.Contains(title))
                {
                    bookSeparatedData = book.Split(',');
                    bookStatus = ShowLibraryElementStatusAsStatement(bookSeparatedData[4]);
                    booksList.AppendLine($"{bookSeparatedData[0]}\t|{bookSeparatedData[1]}\t|{bookSeparatedData[2]}|{bookSeparatedData[3]}|{bookStatus}");
                }
            }

            return booksList.ToString();
        }

        public static bool CheckIfBookExistsById(int id)
        {
            string[] allBooks = File.ReadAllLines(booksFilePath);
            foreach (string line in allBooks)
            {
                string[] parts = line.Split(',');
                if (int.Parse(parts[0]) == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetBooksListFromFile()
        {
            string bookStatus = null;
            List<string> booksListFromFile = File.ReadAllLines(booksFilePath).ToList();
            string[] bookSeparatedData;

            StringBuilder bookList = new System.Text.StringBuilder();
            bookList.AppendLine("ID\t|Tytuł\t|Rodzaj\t|Ilość stron|\tStatus");

            foreach (string line in booksListFromFile)
            {
                bookSeparatedData = line.Split(',');
                bookStatus = ShowLibraryElementStatusAsStatement(bookSeparatedData[4]);                
                bookList.AppendLine($"{bookSeparatedData[0]}\t|{bookSeparatedData[1]}\t|{bookSeparatedData[2]}\t|{bookSeparatedData[3]}\t|{bookStatus}");
            }

            return bookList.ToString();
        }

        
        //MOVIE METHODS
        public static Movie CreateNewMovie(string title, string section, int duration)
        {
            File.AppendAllText(moviesFilePath, $"{GetAvailableMovieID() + 1},{title},{section},{duration},0\n"); //Add new line to .txt file           
            return new Movie(title, section, GetAvailableMovieID() + 1, duration);
        }

        public static int GetAvailableMovieID()
        {
            string lastLine = File.ReadLines(moviesFilePath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
                return int.Parse(argumentsFromFile[0]);
            }
            return 0;
        }

        public static bool RemoveMovie(int movieID)
        {
            List<string> movieList = File.ReadAllLines(moviesFilePath).ToList();

            int indexToRemove;

            indexToRemove = FindMovieIndexToRemove(movieList, movieID);

            if (indexToRemove > -1)
            {
                movieList.RemoveAt(indexToRemove);
                File.WriteAllLines(moviesFilePath, movieList);

                return true;
            }

            return false;
        }

        public static int FindMovieIndexToRemove(List<string> movieList, int movieID)
        {
            string[] movieDataTmp;

            for (int i = 0; i < movieList.Count; i++)
            {
                movieDataTmp = movieList[i].Split(',');

                if (int.Parse(movieDataTmp[0]) == movieID)
                {
                    return i;
                }
            }
            return -1;
        }

        public static string SearchMovieByTitle(string title)
        {
            string movieStatus = null;
            List<string> movieListFromFile = File.ReadAllLines(moviesFilePath).ToList();
        
            string[] movieSeparatedData;

            StringBuilder moviesList = new System.Text.StringBuilder();

            moviesList.AppendLine("Znalezione filmy: ");
            moviesList.AppendLine("ID\t|Tytuł\t|Rodzaj\t|Czas trwania\t|Status");

            foreach (string movie in movieListFromFile)
            {
                if (movie.Contains(title))
                {
                    movieSeparatedData = movie.Split(',');
                    movieStatus = ShowLibraryElementStatusAsStatement(movieSeparatedData[4]);
                    moviesList.AppendLine($"{movieSeparatedData[0]}\t|{movieSeparatedData[1]}\t|{movieSeparatedData[2]}|{movieSeparatedData[3]}|{movieStatus}"); 
                }
            }

            return moviesList.ToString();
        }
      
        public static bool CheckIfMovieExistsById(int id)
        {
            string[] allMovies = File.ReadAllLines(moviesFilePath);
            foreach (string line in allMovies)
            {
                string[] parts = line.Split(',');
                if (int.Parse(parts[0]) == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetMoviesListFromFile()
        {
            string movieStatus = null;
            List<string> moviesListFromFile = File.ReadAllLines(moviesFilePath).ToList();
            string[] movieSeparatedData;

            StringBuilder movieList = new System.Text.StringBuilder();
            movieList.AppendLine("ID\t|Tytuł\t|Rodzaj\t|Czas trwania");

            foreach (string line in moviesListFromFile)
            {
                movieSeparatedData = line.Split(',');
                movieStatus = ShowLibraryElementStatusAsStatement(movieSeparatedData[4]);               
                movieList.AppendLine($"{movieSeparatedData[0]}\t|{movieSeparatedData[1]}\t|{movieSeparatedData[2]}\t|{movieSeparatedData[3]}\t|{movieStatus}");
            }

            return movieList.ToString();
        }

        //LIBRARY ELEMENT METHODS
        public static string ShowLibraryElementStatusAsStatement(string bookStatus)
        {
            if (bookStatus == "0")
            {
                return "Dostępna";
            }
            else if (bookStatus == "1")
            {
                return "Oczekująca";
            }
            else if (bookStatus == "2")
            {
                return "Wypożyczona";
            }
            return "Błąd";
        }

        //ORDINARY USER METHODS
        public static OrdinaryUser CreateNewOrdinaryUser(string name, string surname, string password)
        {
            OrdinaryUser newOrdinaryUser = new OrdinaryUser(name, surname, 2, getCurrentOrdinaryUserID() + 1, password, $"OrdinaryUser{getCurrentOrdinaryUserID() + 1}");

            File.AppendAllText(ordinaryUsersListPath, $"{newOrdinaryUser.UserID},{name},{surname},{2},0\n"); //Add new line to .txt file
            File.AppendAllText(accountsInfoPath, $"{newOrdinaryUser.Login},{password},{newOrdinaryUser.UserType},{newOrdinaryUser.UserID}\n");

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

        //LIBRARIAN METHODS
        public static Librarian CreateNewLibrarian(string name, string surname, string password)
        {
            Librarian newLibrarian = new Librarian(name, surname, 1, getCurrentLibrarianID() + 1, password, $"Librarian{getCurrentLibrarianID() + 1}");

            File.AppendAllText(librariansListPath, $"{newLibrarian.UserID},{name},{surname},{1}\n"); //Add new line to .txt file
            File.AppendAllText(accountsInfoPath, $"{newLibrarian.Login},{password},{newLibrarian.UserType},{newLibrarian.UserID}\n");

            CreateNewLibrarianDataFiles(newLibrarian);

            return newLibrarian;
        }
        
        public static void CreateNewLibrarianDataFiles(Librarian newLibrarian)
        {
            string newLibrariansDirectory = librariansDirectoryPath + @"\Librarian" + newLibrarian.UserID;

            Directory.CreateDirectory(newLibrariansDirectory);
            File.Create(newLibrariansDirectory + @"\Requests_Librarian" + newLibrarian.UserID + ".txt");
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

        //REQUEST METHODS
        public static void BorrowRequest(DateTime date, ushort elementID, byte elementType, int ordinaryUserID)
        {
            List<string> librarianListFromFile = File.ReadAllLines(librariansListPath).ToList();

            for (int i = 0; i < librarianListFromFile.Count; i++)
            {
                string[] parts = librarianListFromFile[i].Split(',');
                string requestListPath = librariansDirectoryPath + @"\Librarian" + parts[0] + @"\Requests_Librarian" + parts[0] + ".txt";

                int availableRequestID = GetCurrentRequestID(int.Parse(parts[0]));
                File.AppendAllText(requestListPath, $"{availableRequestID + 1},{elementID},{elementType},{ordinaryUserID},{DateTime.Now}\n");
            }
        }

        public static int GetCurrentRequestID(int requestID)
        {
            string requestListPath = librariansDirectoryPath + @"\Librarian" + requestID + @"\Requests_Librarian" + requestID + ".txt";

            string lastLine = File.ReadLines(requestListPath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromRequest = lastLine.Split(',');
                return int.Parse(argumentsFromRequest[0]);
            }

            return 0;
        }

        public static void ChangeBookStatusToPending(int bookID)
        {
            List<string> bookList = File.ReadAllLines(booksFilePath).ToList();

            string[] bookDataTmp;
            for (int i = 0; i < bookList.Count; i++)
            {
                bookDataTmp = bookList[i].Split(',');

                if (int.Parse(bookDataTmp[0]) == bookID)
                {
                    bookDataTmp[4] = "1";
                    bookList[i] = string.Join(",", bookDataTmp[0], bookDataTmp[1], bookDataTmp[2], bookDataTmp[3], bookDataTmp[4]);
                }
            }

            File.WriteAllLines(booksFilePath, bookList);
        }

        public static bool CheckIfBookStatusIsAvailable(int bookID)
        {
            List<string> bookList = File.ReadAllLines(booksFilePath).ToList();

            string[] bookDataTmp;
            for (int i = 0; i < bookList.Count; i++)
            {
                bookDataTmp = bookList[i].Split(',');

                if (int.Parse(bookDataTmp[0]) == bookID)
                {
                    if (bookDataTmp[4] == "0")
                    {
                        return true;
                    }                       
                }
            }

            return false;
        }

        public static void ChangeMovieStatusToPending(int movieID)
        {
            List<string> movieList = File.ReadAllLines(moviesFilePath).ToList();

            string[] movieDataTmp;
            for (int i = 0; i < movieList.Count; i++)
            {
                movieDataTmp = movieList[i].Split(',');

                if (int.Parse(movieDataTmp[0]) == movieID)
                {
                    movieDataTmp[4] = "1";
                    movieList[i] = string.Join(",", movieDataTmp[0], movieDataTmp[1], movieDataTmp[2], movieDataTmp[3], movieDataTmp[4]);
                }
            }

            File.WriteAllLines(moviesFilePath, movieList);
        }

        public static bool CheckIfMovieStatusIsAvailable(int movieID)
        {
            List<string> movieList = File.ReadAllLines(moviesFilePath).ToList();

            string[] movieDataTmp;
            for (int i = 0; i < movieList.Count; i++)
            {
                movieDataTmp = movieList[i].Split(',');

                if (int.Parse(movieDataTmp[0]) == movieID)
                {
                    if (movieDataTmp[4] == "0")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string GetRequestsListFromFile(int librarianID)
        {
            string librarianRequestsFilePath = librariansDirectoryPath + @"\Librarian" + librarianID + @"\Requests_Librarian" + librarianID + ".txt";
            List<string> requestListFromFile = File.ReadAllLines(librarianRequestsFilePath).ToList();
            string[] requestSeparatedData;

            StringBuilder requestList = new System.Text.StringBuilder();
            requestList.AppendLine("ID\t|ID Elementu\t|Rodzaj elementu\t|ID Użytkownika|Data\t");

            foreach (string requestInLine in requestListFromFile)
            {
                requestSeparatedData = requestInLine.Split(',');               
                requestList.AppendLine($"{requestSeparatedData[0]}\t|{requestSeparatedData[1]}\t\t|{requestSeparatedData[2]}\t\t\t|{requestSeparatedData[3]}\t\t|{requestSeparatedData[4]}");
            }

            return requestList.ToString();
        }

        public static int GetLastRequestID(int librarianID)
        {
            string librarianRequestsFilePath = librariansDirectoryPath + @"\Librarian" + librarianID + @"\Requests_Librarian" + librarianID + ".txt";

            string lastLine = File.ReadLines(librarianRequestsFilePath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
                return int.Parse(argumentsFromFile[0]);
            }
            return -1;           
        }

        public static string GetRequestDataToString(int requestNumber, int librarianID)
        {
            string librarianRequestsFilePath = librariansDirectoryPath + @"\Librarian" + librarianID + @"\Requests_Librarian" + librarianID + ".txt";
            List<string> requestListFromFile = File.ReadAllLines(librarianRequestsFilePath).ToList();
            string[] requestSeparatedData;

            foreach (string requestInLine in requestListFromFile)
            {
                requestSeparatedData = requestInLine.Split(',');
                if (int.Parse(requestSeparatedData[0]) == requestNumber)
                {
                    return requestInLine;
                }
            }

            return null;
        }

        //BORROW METHODS
        public static int GetCurrentBorrowingID(int ordinaryUserID)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";

            string lastLine = File.ReadLines(borrowingListPath).LastOrDefault(); //Reading last line from .txt file
            if (lastLine != null)
            {
                string[] argumentsFromFile = lastLine.Split(',');
                return int.Parse(argumentsFromFile[0]);
            }

            return 0;
        }
        
        public static void AddNewBorrowingToOrdinaryUserFile(int ordinaryUserID, DateTime date, ushort elementID, byte elementType, int borrowID, byte borrowingStatus)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";

            File.AppendAllText(borrowingListPath, $"{borrowID},{elementID},{elementType},{date},{borrowingStatus}\n");

            //ChangeBookStatusToPending(elementID);
        }


        //public static void AddNewBorrowingToUserFile(string requestData, int ordinaryUserID)
        //{
        //    string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + ordinaryUserID + @"\Borrowings_" + ordinaryUserID + ".txt";

        //    File.AppendAllText(borrowingListPath, $"\n{requestData}");

        //    //ChangeBookStatusToPending(elementID);
        //}

        //CLEAR ALL DATA BASE
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

