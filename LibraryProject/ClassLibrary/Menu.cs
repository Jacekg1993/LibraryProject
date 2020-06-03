using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public enum LibrarianMenuOption
    {
        CreateNewAccount = 1,
        RemoveAccount,
        AddNewLibraryElement,
        RemoveLibraryElement,
        GetUsersList,
        GetLibrarianElementsList,
        SearchLibraryElement,
        ApproveBorrow,     
        LogOut
    }

    public enum OrdinaryUserMenuOption
    {
        SearchLibraryElement = 1,
        Borrow,
        Return,
        GetBorrowingsList,
        SettlePenalties,
        LogOut      
    }

    public static class Menu
    {
        public static void LogInView()
        {
            Console.Clear();

            Librarian LoggedLibrarian;
            OrdinaryUser LoggedOrdinaryUser;

            string userData = null;
            string[] userArguments;

            while (userData == null)
            {
                userData = GetUserDataByEnteringPasses();
            }
            userArguments = userData.Split(',');
            
            if (byte.Parse(userArguments[3]) == 1)
            {
                LoggedLibrarian = new Librarian(name: userArguments[1], surname: userArguments[2], type: byte.Parse(userArguments[3]), id: int.Parse(userArguments[0]), password: userArguments[4], login: userArguments[5]);

                Console.Clear();
                Console.WriteLine($"Witaj {LoggedLibrarian.Name}!");
                Console.Write("kliknij aby kontynuować");
                Console.ReadKey();
                LibrarianMenuView(LoggedLibrarian);
            }
            else if(byte.Parse(userArguments[3]) == 2)
            {
                LoggedOrdinaryUser = new OrdinaryUser(name: userArguments[1], surname: userArguments[2], type: byte.Parse(userArguments[3]), id: int.Parse(userArguments[0]), password: userArguments[5], login: userArguments[6]);

                Console.Clear();
                Console.WriteLine($"Witaj {LoggedOrdinaryUser.Name}!");
                Console.Write("kliknij aby kontynuować");
                Console.ReadKey();
                OrdinaryUserMenuView(LoggedOrdinaryUser);
            }             
        }

        public static string GetUserDataByEnteringPasses()
        {
            Console.Clear();

            string userData;
            string login;
            string password;

            Console.WriteLine("Witaj! Zaloguj sie na konto");

            Console.Write("Login: ");
            login = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            int UserId = TextFileHandler.GetUserIdIfExist(login, password);

            if (UserId > -1)
            {
                if (login.Contains("Librarian"))
                {
                    userData = TextFileHandler.GetLibrarianDataFromFile(UserId);
                    return userData + $",{password},{login}";
                }
                else if (login.Contains("User"))
                {
                    userData = TextFileHandler.GetOrdinaryUserDataFromFile(UserId);
                    return userData + $",{password},{login}";
                }
            }
           
            return null;
        }

        public static void LibrarianMenuView(Librarian LoggedLibrarian)
        {
            int librarianMenuSelectedOptionInt = 0;
            LibrarianMenuOption librarianMenuSelectedOption;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Stwórz nowe konto");
                Console.WriteLine("2. Usuń konto");
                Console.WriteLine("3. Dodaj nowy element do zbioru");
                Console.WriteLine("4. Usuń element zbioru");
                Console.WriteLine("5. Lista użytkowników");
                Console.WriteLine("6. Lista elementów w zbiorze");
                Console.WriteLine("7. Wyszukawiarka elementów w zbiorze");
                Console.WriteLine("8. Zatwierdź wypożyczenie");
                Console.WriteLine("9. Wyloguj");

                Console.Write("Wybierz opcje: ");
                try
                {
                    librarianMenuSelectedOptionInt = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podano nieprawidłową wartość!");
                    Console.ReadKey();
                }

                if (librarianMenuSelectedOptionInt > 0 && librarianMenuSelectedOptionInt < 9)
                {
                    librarianMenuSelectedOption = (LibrarianMenuOption)librarianMenuSelectedOptionInt;
                    LibrarianMenuOptionSelection(librarianMenuSelectedOption, LoggedLibrarian);
                }
                else if (librarianMenuSelectedOptionInt == 9)
                {
                    LogInView();
                } 
            }
        }

        public static void LibrarianMenuOptionSelection(LibrarianMenuOption option, Librarian LoggedLibrarian)
        {
            switch (option)
            {
                case LibrarianMenuOption.CreateNewAccount:
                    CreateNewUser();
                    break;
                case LibrarianMenuOption.RemoveAccount:
                    RemoveUser();
                    break;
                case LibrarianMenuOption.AddNewLibraryElement:
                    AddNewLibraryElement();
                    break;
                case LibrarianMenuOption.RemoveLibraryElement:
                    RemoveLibraryElement();
                    break;
                case LibrarianMenuOption.GetUsersList:
                    GetAllUsersList();
                    break;
                case LibrarianMenuOption.GetLibrarianElementsList:
                    GetAllLibraryElementsList();
                    break;
                case LibrarianMenuOption.SearchLibraryElement:
                    SearchLibraryElement();
                    break;
                case LibrarianMenuOption.ApproveBorrow:
                    ApproveOrRejectBorrowing(LoggedLibrarian.UserID);
                    break;
                default:
                    break;
            }
        }

        public static void OrdinaryUserMenuView(OrdinaryUser LoggedOrdinaryUser)
        {
            int ordinaryUserMenuSelectedOptionInt = 0;
            OrdinaryUserMenuOption ordinaryUserMenuSelectedOption;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Wyszukawiarka elementów w zbiorze");
                Console.WriteLine("2. Wypożycz");
                Console.WriteLine("3. Zwróć");
                Console.WriteLine("4. Lista aktualnych wypożyczeń");
                Console.WriteLine("5. Rozliczenie kar");
                Console.WriteLine("6. Wyloguj");

                Console.Write("Wybierz opcje: ");
                ordinaryUserMenuSelectedOptionInt = int.Parse(Console.ReadLine());

                if (ordinaryUserMenuSelectedOptionInt > 0 && ordinaryUserMenuSelectedOptionInt < 6)
                {
                    ordinaryUserMenuSelectedOption = (OrdinaryUserMenuOption)ordinaryUserMenuSelectedOptionInt;
                    OrdinaryUserMenuOptionSelection(ordinaryUserMenuSelectedOption, LoggedOrdinaryUser);
                }
                else if (ordinaryUserMenuSelectedOptionInt == 6)
                {
                    LogInView();
                }
            }
        }

        public static void OrdinaryUserMenuOptionSelection(OrdinaryUserMenuOption option, OrdinaryUser LoggedOrdinaryUser)
        {
            switch (option)
            {
                case OrdinaryUserMenuOption.SearchLibraryElement:
                    SearchLibraryElement();
                    break;
                case OrdinaryUserMenuOption.Borrow:
                    BorrowALibraryElement(LoggedOrdinaryUser);
                    break;
                case OrdinaryUserMenuOption.Return:
                    ReturnLibraryElement(LoggedOrdinaryUser);
                    break;
                case OrdinaryUserMenuOption.GetBorrowingsList:
                    GetAllOrdinaryUserBorrowingsList(LoggedOrdinaryUser.UserID);
                    break;
                case OrdinaryUserMenuOption.SettlePenalties:
                    
                    break;
                default:
                    break;
            }
        }

        public static void CreateNewUser()
        {
            byte type = 0;

            Console.Clear();
            Console.WriteLine("Ekran tworzenia użytkownika");
            Console.WriteLine("___________________________");

            Console.WriteLine("Podaj typ użytkownika:\nBibliotekarz: 1\nZwykły użytkownik: 2");
            Console.WriteLine("_______________________\nPowrót: 3");

            try
            {
                type = byte.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                
            }
            if (type == 1)
            {
                //TextFileHandler.CreateNewLibrarian(); 
                Console.WriteLine("Opcja chwilowo niedostępna");

                Console.ReadKey();
            }
            else if (type == 2)
            {
                string name;
                string surName;
                string password;

                Console.Write("Imie: ");
                name = Console.ReadLine();

                Console.Write("Nazwisko: ");
                surName = Console.ReadLine();

                Console.Write("Hasło: ");
                password = Console.ReadLine();

                TextFileHandler.CreateNewOrdinaryUser(name, surName, password);

                Console.WriteLine("Nowy użytkownik dodany pomyślnie");
                Console.ReadKey();
            }
            else if (type == 3)
            {
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Podano nieprawidłowy typ użytkownika!");
                Console.ReadKey();
                CreateNewUser();
            }
        }

        public static void RemoveUser()
        {
            string userToDeleteLogin;
            string[] userDataSplit;
            int userToDeleteId = 0;

            Console.Clear();

            Console.WriteLine("Ekran usuwania użytkownika");
            Console.WriteLine("___________________________");

            Console.Write("Podaj nazwe użytkownika do usunięcia: ");
            userToDeleteLogin = Console.ReadLine();

            userDataSplit = userToDeleteLogin.Split('r');
            try
            {
                userToDeleteId = int.Parse(userDataSplit[3]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Podano nieprawidłową nazwę użytkownika!");
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Podano nieprawidłową nazwę użytkownika!");
                Console.ReadKey();
            }

            if (TextFileHandler.RemoveOrdinaryUserDataFromFile(userToDeleteId, userToDeleteLogin))
            {
                Console.WriteLine("Konto usunięto pomyślnie");
            }
            else
            {
                Console.WriteLine("Coś poszło nie tak");
            }

            Console.ReadKey();
        }

        public static void AddNewLibraryElement()
        {
            byte type = 0;

            Console.Clear();
            Console.WriteLine("Ekran dodawania nowego elementu do zbioru");
            Console.WriteLine("___________________________");

            Console.WriteLine("Podaj typ elementu:\nKsiążka: 1\nFilm: 2");
            Console.WriteLine("_______________________\nPowrót: 3");

            try
            {
                type = byte.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                
            }
            if (type == 1)
            {
                string title;
                string section;
                uint pages = 0;

                Console.Write("Tytuł: ");
                title = Console.ReadLine();

                Console.Write("Rodzaj: ");
                section = Console.ReadLine();

                Console.Write("Ilość stron: ");
                try
                {
                    pages = uint.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Coś poszło nie tak!");
                    Console.ReadKey();
                    return;
                }

                TextFileHandler.CreateNewBook(title, section, pages);

                Console.WriteLine("Element dodano pomyślnie");
                Console.ReadKey();
            }
            else if (type == 2)
            {
                string title;
                string section;
                uint duration = 0;

                Console.Write("Tytuł: ");
                title = Console.ReadLine();

                Console.Write("Rodzaj: ");
                section = Console.ReadLine();

                Console.Write("Czas trwania [minuty]: ");
                try
                {
                    duration = uint.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Coś poszło nie tak!");
                    Console.ReadKey();
                    return;
                }
                TextFileHandler.CreateNewMovie(title, section, duration);

                Console.WriteLine("Element dodano pomyślnie");
                Console.ReadKey();
            }
            else if (type == 3)
            {
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Podano zły typ elementu!");
                Console.ReadKey();
                AddNewLibraryElement();
            }
        }

        public static void RemoveLibraryElement()
        {
            byte type = 0;
            int id = 0;

            Console.Clear();
            Console.WriteLine("Ekran usuwanie elementu zbioru");
            Console.WriteLine("___________________________");

            Console.WriteLine("Podaj typ elementu:\nKsiążka: 1\nFilm: 2");
            Console.WriteLine("_______________________\nPowrót: 3");

            try
            {
                type = byte.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

            }
            if (type == 1)
            {
                Console.Write("Podaj ID książki: ");
                try
                {
                    id = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Coś poszło nie tak!");
                    Console.ReadKey();
                    return;
                }

                if (TextFileHandler.RemoveBook(id))
                {
                    Console.WriteLine("Książkę usunięto ze zbioru");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Coś poszło nie tak");
                    Console.ReadKey();
                }
            }
            else if (type == 2)
            {
                Console.Write("Podaj ID filmu: ");
                try
                {
                    id = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Coś poszło nie tak!");
                    Console.ReadKey();
                    return;
                }

                if (TextFileHandler.RemoveMovie(id))
                {
                    Console.WriteLine("Film usunięto ze zbioru");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Coś poszło nie tak");
                    Console.ReadKey();
                }
            }
            else if (type == 3)
            {
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Podano nieprawidłowy typ elementu!");
                Console.ReadKey();
                RemoveLibraryElement();
            }
        }

        public static void GetAllUsersList()
        {
            Console.Clear();

            Console.WriteLine("Lista pracowników biblioteki: ");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine(TextFileHandler.GetLibrarianListFromFile());

            Console.WriteLine("Lista użytkowników biblioteki: ");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine(TextFileHandler.GetOrdinaryUserListFromFile());

            Console.WriteLine("Powrót");

            Console.ReadKey();
        }

        public static void GetAllLibraryElementsList()
        {
            Console.Clear();

            Console.WriteLine("Lista książek w zbiorze: ");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine(TextFileHandler.GetBooksListFromFile());

            Console.WriteLine("Lista filmów w zbiorze: ");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine(TextFileHandler.GetMoviesListFromFile());

            Console.WriteLine("Powrót");

            Console.ReadKey();
        }

        public static void SearchLibraryElement()
        {
            string title;

            Console.Clear();

            Console.WriteLine("Wyszukiwarka");
            Console.WriteLine("___________________________");

            Console.Write("Podaj tytul: ");
            title = Console.ReadLine();

            Console.WriteLine(TextFileHandler.SearchBookByTitle(title));
            Console.WriteLine(TextFileHandler.SearchMovieByTitle(title));

            Console.Write("Powrót");

            Console.ReadKey();
        }

        public static void ApproveOrRejectBorrowing(int loggedLibrarianID)
        {
            byte librarianRequestSelection = 0;

            Console.Clear();

            Console.WriteLine("Lista zapytań o wypożyczenie:");
            Console.WriteLine("___________________________");
            Console.WriteLine(TextFileHandler.GetRequestsListFromFile(loggedLibrarianID));

            Console.WriteLine("1. Wybór zapytania");
            Console.WriteLine("2. Powrót");

            Console.Write("Wybierz opcje: ");
            librarianRequestSelection = byte.Parse(Console.ReadLine());

            if (librarianRequestSelection == 1)
            {              
                LibrarianRequestMenu(loggedLibrarianID);
                ApproveOrRejectBorrowing(loggedLibrarianID);
            }
            else if (librarianRequestSelection == 2)
            {
                Console.ReadKey();
            }
        }

        public static void LibrarianRequestMenu(int loggedLibrarianID)
        {
            byte librarianRequestIdSelection = 0;
            bool exitMenu = false;

            while (exitMenu == false)
            {
                Console.Clear();

                Console.WriteLine(TextFileHandler.GetRequestsListFromFile(loggedLibrarianID));
                Console.WriteLine("___________________________");

                Console.Write("Wybierz zapytanie: ");
                librarianRequestIdSelection = byte.Parse(Console.ReadLine());

                if (librarianRequestIdSelection > 0 && librarianRequestIdSelection <= TextFileHandler.GetLastRequestID(loggedLibrarianID))
                {
                    string requestData = TextFileHandler.GetRequestDataToString(librarianRequestIdSelection, loggedLibrarianID);
                    exitMenu = LibrarianRequestAcceptance(requestData);
                }
                else 
                {
                    Console.WriteLine("Wybrano zły numer zapytania!");
                    Console.ReadKey();
                } 
            }
        }

        public static bool LibrarianRequestAcceptance(string requestData)
        {
            byte librarianRequestSelection = 0;
            
            while (true)
            {
                Console.Clear();

                Console.WriteLine("___________________________");
                Console.WriteLine("1. Zaakceptuj");
                Console.WriteLine("2. Odrzuć");

                Console.Write("Twój wybór: ");
                librarianRequestSelection = byte.Parse(Console.ReadLine());

                if (librarianRequestSelection == 1)
                {
                    string[] requestSeparatedData = requestData.Split(',');
                    int requestID = int.Parse(requestSeparatedData[0]);
                    int ordinaryUserID = int.Parse(requestSeparatedData[3]);
                    int borrowID = TextFileHandler.GetCurrentBorrowingID(ordinaryUserID) + 1;                   
                    DateTime date = DateTime.Now;
                    ushort elementID = ushort.Parse(requestSeparatedData[1]);
                    byte elementType = byte.Parse(requestSeparatedData[2]);

                    TextFileHandler.AddNewBorrowingToOrdinaryUserFile(ordinaryUserID, date, elementID, elementType, borrowID, 1);
                    TextFileHandler.RemoveRequest(requestID);

                    if (elementType == 1)
                    {
                        TextFileHandler.ChangeBookStatusToBorrowed(elementID);
                    }
                    else
                    {
                        TextFileHandler.ChangeMovieStatusToBorrowed(elementID);
                    }
                    Console.WriteLine("Wypożyczenie zostało zaakceptowane");
                    Console.ReadKey();
                    return true;
                } 
                else if (librarianRequestSelection == 2)
                {
                    string[] requestSeparatedData = requestData.Split(',');
                    int requestID = int.Parse(requestSeparatedData[0]);
                    ushort elementID = ushort.Parse(requestSeparatedData[1]);
                    byte elementType = byte.Parse(requestSeparatedData[2]);

                    if (elementType == 1)
                    {
                        TextFileHandler.ChangeBookStatusToAvailable(elementID);
                    }
                    else
                    {
                        TextFileHandler.ChangeMovieStatusToAvailable(elementID);
                    }

                    Console.WriteLine("Wypożyczenie zostało odrzucone");
                    TextFileHandler.RemoveRequest(requestID);

                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną opcje!");
                }
            }
        }

        public static void BorrowALibraryElement(OrdinaryUser LoggedOrdinaryUser)
        {
            ushort id;
            byte type;

            Console.Clear();

            Console.WriteLine("Wypożyczalnia");
            Console.WriteLine("___________________________");

            Console.Write("Podaj typ elementu:\nKsiążka: 1\nFilm: 2\n");
            type = byte.Parse(Console.ReadLine());

            if (type == 1)
            {
                Console.Write("Podaj ID elementu: ");
                id = ushort.Parse(Console.ReadLine());

                if (TextFileHandler.CheckIfBookExistsById(id) && TextFileHandler.CheckIfBookStatusIsAvailable(id))
                {
                    //int availableBorrowingIdTmp = TextFileHandler.GetCurrentBorrowingID(LoggedOrdinaryUser) + 1;

                    //LoggedOrdinaryUser.BorrowLibraryElement(DateTime.Now, id, type, availableBorrowingIdTmp);

                    TextFileHandler.BorrowRequestAddToFile(DateTime.Now, id, type, LoggedOrdinaryUser.UserID);
                    TextFileHandler.ChangeBookStatusToPending(id);

                    Console.WriteLine("Element oczekuje na zatwierdzenie");
                } 
                else
                {
                    Console.WriteLine("Podano błędne ID elementu!");
                    Console.ReadKey();
                    //BorrowALibraryElement(LoggedOrdinaryUser);
                }
            }
            else if (type == 2)
            {
                Console.Write("Podaj ID elementu: ");
                id = ushort.Parse(Console.ReadLine());

                if (TextFileHandler.CheckIfMovieExistsById(id) && TextFileHandler.CheckIfMovieStatusIsAvailable(id))
                {
                    //int availableBorrowingIdTmp = TextFileHandler.GetCurrentBorrowingID(LoggedOrdinaryUser) + 1;

                    //LoggedOrdinaryUser.BorrowLibraryElement(DateTime.Now, id, type, availableBorrowingIdTmp);

                    TextFileHandler.BorrowRequestAddToFile(DateTime.Now, id, type, LoggedOrdinaryUser.UserID);
                    TextFileHandler.ChangeMovieStatusToPending(id);

                    Console.WriteLine("Element oczekuje na zatwierdzenie");
                }
                else
                {
                    Console.WriteLine("Podano błędne ID elementu!");
                    Console.ReadKey();
                    //BorrowALibraryElement(LoggedOrdinaryUser);
                }
            }
            else
            {
                Console.WriteLine("Podano zły typ elementu!");
                Console.ReadKey();
                BorrowALibraryElement(LoggedOrdinaryUser);
            }

            Console.ReadKey();
        }

        public static void ReturnLibraryElement(OrdinaryUser LoggedOrdinaryUser)
        {
            int borrowingIdToReturn;

            Console.Clear();

            Console.WriteLine(TextFileHandler.GetOrdinaryUserBorrowingsListFromFile(LoggedOrdinaryUser.UserID));

            Console.Write("Który element chcesz zwrócić?[Podaj ID]: ");
            borrowingIdToReturn = int.Parse(Console.ReadLine());

            if (TextFileHandler.CheckReturnValidation(borrowingIdToReturn, LoggedOrdinaryUser.UserID))
            {
                TextFileHandler.ChangeBorrowingStatusToReturned(borrowingIdToReturn, LoggedOrdinaryUser.UserID);

                if (TextFileHandler.GetBorrowingElementType(borrowingIdToReturn, LoggedOrdinaryUser.UserID) == 1)
                {
                    int bookID = TextFileHandler.GetBorrowingElementId(borrowingIdToReturn, LoggedOrdinaryUser.UserID);
                    TextFileHandler.ChangeBookStatusToAvailable(bookID);
                }
                else if (TextFileHandler.GetBorrowingElementType(borrowingIdToReturn, LoggedOrdinaryUser.UserID) == 2)
                {
                    int movieID = TextFileHandler.GetBorrowingElementId(borrowingIdToReturn, LoggedOrdinaryUser.UserID);
                    TextFileHandler.ChangeMovieStatusToAvailable(movieID);
                }
                Console.WriteLine("Element oddano do zbioru biblioteki");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Podano niepoprawne ID!");
                Console.ReadKey();
            }
        }

        public static void GetAllOrdinaryUserBorrowingsList(int ordinaryUserID)
        {
            Console.Clear();

            Console.WriteLine("Lista wypożyczeń: ");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine(TextFileHandler.GetOrdinaryUserBorrowingsListFromFile(ordinaryUserID));

            Console.WriteLine("Powrót");

            Console.ReadKey();
        }
    }
}
