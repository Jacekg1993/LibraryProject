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
        public static Book CreateNewBook(string title, string section, uint pages)
        {
            File.AppendAllText(booksFilePath, $"{GetAvailableBookID() + 1},{title},{section},{pages},0\n"); //Add new line to .txt file           
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
        public static Movie CreateNewMovie(string title, string section, uint duration)
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
        public static void BorrowRequestAddToFile(DateTime date, ushort elementID, byte elementType, int ordinaryUserID)
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

        public static int GetCurrentRequestID(int librarianID)
        {
            string requestListPath = librariansDirectoryPath + @"\Librarian" + librarianID + @"\Requests_Librarian" + librarianID + ".txt";

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

        public static bool CheckByIdIfRequestExists(int librarianID, int requestID)
        {
            string librarianRequestsFilePath = librariansDirectoryPath + @"\Librarian" + librarianID + @"\Requests_Librarian" + librarianID + ".txt";
            List<string> requestListFromFile = File.ReadAllLines(librarianRequestsFilePath).ToList();
            string[] requestSeparatedData;

            foreach (string requestInLine in requestListFromFile)
            {
                requestSeparatedData = requestInLine.Split(',');

                if (int.Parse(requestSeparatedData[0]) == requestID)
                {
                    return true;
                }
            }

            return false;           
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

        public static void RemoveRequest(int requestID)
        {
            List<string> librarianListFromFile = File.ReadAllLines(librariansListPath).ToList();      

            for (int i = 0; i < librarianListFromFile.Count; i++)
            {
                string[] parts = librarianListFromFile[i].Split(',');
                string requestListPath = librariansDirectoryPath + @"\Librarian" + parts[0] + @"\Requests_Librarian" + parts[0] + ".txt";

                List<string> requestList = File.ReadAllLines(requestListPath).ToList();
                int requestIndexToRemove = FindRequestIndexToRemove(requestList, requestID);
                requestList.RemoveAt(requestIndexToRemove);
                File.WriteAllLines(requestListPath, requestList);
            }
        }

        public static int FindRequestIndexToRemove(List<string> requestList, int requestID)
        {
            string[] requestDataTmp;

            for (int i = 0; i < requestList.Count; i++)
            {
                requestDataTmp = requestList[i].Split(',');

                if (int.Parse(requestDataTmp[0]) == requestID)
                {
                    return i;
                }
            }
            return -1;
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

        }

        public static void ChangeBookStatusToBorrowed(int bookID)
        {
            List<string> bookList = File.ReadAllLines(booksFilePath).ToList();

            string[] bookDataTmp;
            for (int i = 0; i < bookList.Count; i++)
            {
                bookDataTmp = bookList[i].Split(',');

                if (int.Parse(bookDataTmp[0]) == bookID)
                {
                    bookDataTmp[4] = "2";
                    bookList[i] = string.Join(",", bookDataTmp[0], bookDataTmp[1], bookDataTmp[2], bookDataTmp[3], bookDataTmp[4]);
                }
            }

            File.WriteAllLines(booksFilePath, bookList);
        }

        public static void ChangeBookStatusToAvailable(int bookID)
        {
            List<string> bookList = File.ReadAllLines(booksFilePath).ToList();

            string[] bookDataTmp;
            for (int i = 0; i < bookList.Count; i++)
            {
                bookDataTmp = bookList[i].Split(',');

                if (int.Parse(bookDataTmp[0]) == bookID)
                {
                    bookDataTmp[4] = "0";
                    bookList[i] = string.Join(",", bookDataTmp[0], bookDataTmp[1], bookDataTmp[2], bookDataTmp[3], bookDataTmp[4]);
                }
            }

            File.WriteAllLines(booksFilePath, bookList);
        }

        public static void ChangeMovieStatusToBorrowed(int movieID)
        {
            List<string> movieList = File.ReadAllLines(moviesFilePath).ToList();

            string[] movieDataTmp;
            for (int i = 0; i < movieList.Count; i++)
            {
                movieDataTmp = movieList[i].Split(',');

                if (int.Parse(movieDataTmp[0]) == movieID)
                {
                    movieDataTmp[4] = "2";
                    movieList[i] = string.Join(",", movieDataTmp[0], movieDataTmp[1], movieDataTmp[2], movieDataTmp[3], movieDataTmp[4]);
                }
            }

            File.WriteAllLines(moviesFilePath, movieList);
        }

        public static void ChangeMovieStatusToAvailable(int movieID)
        {
            List<string> movieList = File.ReadAllLines(moviesFilePath).ToList();

            string[] movieDataTmp;
            for (int i = 0; i < movieList.Count; i++)
            {
                movieDataTmp = movieList[i].Split(',');

                if (int.Parse(movieDataTmp[0]) == movieID)
                {
                    movieDataTmp[4] = "0";
                    movieList[i] = string.Join(",", movieDataTmp[0], movieDataTmp[1], movieDataTmp[2], movieDataTmp[3], movieDataTmp[4]);
                }
            }

            File.WriteAllLines(moviesFilePath, movieList);
        }

        public static string GetOrdinaryUserBorrowingsListFromFile(int ordinaryUserID)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";
            List<string> borrowingsListFromFile = File.ReadAllLines(borrowingListPath).ToList();
            string[] borrowingSeparatedData;
            string borrowingStatus = null;
            string borrowingElementTitle = null;

            StringBuilder borrowingList = new System.Text.StringBuilder();
            borrowingList.AppendLine("ID\t|Tytuł\t|Rodzaj elementu\t|Data|Status\t");

            foreach (string requestInLine in borrowingsListFromFile)
            {
                borrowingSeparatedData = requestInLine.Split(',');
                borrowingStatus = ShowBorrowingStatusAsStatement(borrowingSeparatedData[4]);
                borrowingElementTitle = ShowBorrowingIdAsTitle(byte.Parse(borrowingSeparatedData[2]), int.Parse(borrowingSeparatedData[1]));

                borrowingList.AppendLine($"{borrowingSeparatedData[0]}\t|{borrowingElementTitle}\t\t|{borrowingSeparatedData[2]}\t\t\t|{borrowingSeparatedData[3]}\t\t|{borrowingStatus}");
            }

            return borrowingList.ToString();
        }

        public static string ShowBorrowingStatusAsStatement(string borrowingStatus)
        {
            if (borrowingStatus == "0")
            {
                return "Zwrócona";
            }
            else if (borrowingStatus == "1")
            {
                return "Wypożyczona";
            }
            return "Błąd";
        }

        public static string ShowBorrowingIdAsTitle(byte elementType, int elementID)
        {
            string[] separatedData;

            if (elementType == 1)
            {
                List<string> bookList = File.ReadAllLines(booksFilePath).ToList();

                foreach (string book in bookList)
                {
                    separatedData = book.Split(',');
                    if (int.Parse(separatedData[0]) == elementID)
                    {
                        return separatedData[1];
                    }
                }
            }
            else if (elementType == 2)
            {
                List<string> movieList = File.ReadAllLines(moviesFilePath).ToList();

                foreach (string movie in movieList)
                {
                    separatedData = movie.Split(',');
                    if (int.Parse(separatedData[0]) == elementID)
                    {
                        return separatedData[1];
                    }
                }
            }
            return "Błąd";
        }

        public static bool CheckReturnValidation(int borrowID, int ordinaryUserID)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";
            List<string> borrowingsListFromFile = File.ReadAllLines(borrowingListPath).ToList();
            string[] separatedData;

            foreach (string borrowing in borrowingsListFromFile)
            {
                separatedData = borrowing.Split(',');

                if ((int.Parse(separatedData[0]) == borrowID) && (separatedData[4] == "1")) 
                {
                    return true;
                }
            }

            return false;
        }

        public static void ChangeBorrowingStatusToReturned(int borrowID, int ordinaryUserID)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";
            List<string> borrowingsList = File.ReadAllLines(borrowingListPath).ToList();

            string[] borrowingDataTmp;
            for (int i = 0; i < borrowingsList.Count; i++)
            {
                borrowingDataTmp = borrowingsList[i].Split(',');

                if (int.Parse(borrowingDataTmp[0]) == borrowID)
                {
                    borrowingDataTmp[4] = "0";
                    borrowingsList[i] = string.Join(",", borrowingDataTmp[0], borrowingDataTmp[1], borrowingDataTmp[2], borrowingDataTmp[3], borrowingDataTmp[4]);
                }
            }

            File.WriteAllLines(borrowingListPath, borrowingsList);
        }

        public static byte GetBorrowingElementType(int borrowID, int ordinaryUserID)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";
            List<string> borrowingsListFromFile = File.ReadAllLines(borrowingListPath).ToList();
            string[] separatedData;

            foreach (string borrowing in borrowingsListFromFile)
            {
                separatedData = borrowing.Split(',');

                if (int.Parse(separatedData[0]) == borrowID)
                {
                    return byte.Parse(separatedData[2]);
                }
            }

            return 0;
        }

        public static int GetBorrowingElementId(int borrowID, int ordinaryUserID)
        {
            string borrowingListPath = ordinaryUsersDirectoryPath + @"\" + "OrdinaryUser" + ordinaryUserID + @"\Borrowings_OrdinaryUser" + ordinaryUserID + ".txt";
            List<string> borrowingsListFromFile = File.ReadAllLines(borrowingListPath).ToList();
            string[] separatedData;

            foreach (string borrowing in borrowingsListFromFile)
            {
                separatedData = borrowing.Split(',');

                if (int.Parse(separatedData[0]) == borrowID)
                {
                    return int.Parse(separatedData[1]);
                }
            }

            return 0;
        }

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

