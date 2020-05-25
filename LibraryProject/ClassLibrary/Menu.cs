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
        ApproveReturn,
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
                LibrarianMenuView();
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

        public static void LibrarianMenuView()
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
                Console.WriteLine("9. Zatwierdź zwrócenie");
                Console.WriteLine("10. Wyloguj");

                Console.Write("Wybierz opcje: ");
                librarianMenuSelectedOptionInt = int.Parse(Console.ReadLine());

                if (librarianMenuSelectedOptionInt > 0 && librarianMenuSelectedOptionInt < 10)
                {
                    librarianMenuSelectedOption = (LibrarianMenuOption)librarianMenuSelectedOptionInt;
                    LibrarianMenuOptionSelection(librarianMenuSelectedOption);
                }
                else if (librarianMenuSelectedOptionInt == 10)
                {
                    LogInView();
                } 
            }
        }

        public static void LibrarianMenuOptionSelection(LibrarianMenuOption option)
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
                    break;
                case LibrarianMenuOption.ApproveReturn:
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
                    
                    break;
                case OrdinaryUserMenuOption.GetBorrowingsList:
                    
                    break;
                case OrdinaryUserMenuOption.SettlePenalties:
                    
                    break;
                default:
                    break;
            }
        }

        public static void CreateNewUser()
        {
            byte type;

            Console.Clear();
            Console.WriteLine("Ekran tworzenia użytkownika");
            Console.WriteLine("___________________________");

            Console.Write("Podaj typ użytkownika:\nBibliotekarz: 1\nZwykły użytkownik: 2\n");
            type = byte.Parse(Console.ReadLine());

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
            else
            {
                Console.WriteLine("Podano zły typ użytkownika!");
                Console.ReadKey();
                CreateNewUser();
            }
        }

        public static void RemoveUser()
        {
            string userToDeleteLogin;
            string[] userDataSplit;
            int userToDeleteId;

            Console.Clear();

            Console.WriteLine("Ekran usuwania użytkownika");
            Console.WriteLine("___________________________");

            Console.Write("Podaj nazwe użytkownika do usunięcia: ");
            userToDeleteLogin = Console.ReadLine();

            userDataSplit = userToDeleteLogin.Split('r');
            userToDeleteId = int.Parse(userDataSplit[3]);

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
            byte type;

            Console.Clear();
            Console.WriteLine("Ekran dodawania nowego elementu do zbioru");
            Console.WriteLine("___________________________");

            Console.Write("Podaj typ elementu:\nKsiążka: 1\nFilm: 2\n");
            type = byte.Parse(Console.ReadLine());

            if (type == 1)
            {
                string title;
                string section;
                int pages;

                Console.Write("Tytuł: ");
                title = Console.ReadLine();

                Console.Write("Rodzaj: ");
                section = Console.ReadLine();

                Console.Write("Ilość stron: ");
                pages = int.Parse(Console.ReadLine());

                TextFileHandler.CreateNewBook(title, section, pages);

                Console.WriteLine("Element dodano pomyślnie");
                Console.ReadKey();
            }
            else if (type == 2)
            {
                string title;
                string section;
                int duration;

                Console.Write("Tytuł: ");
                title = Console.ReadLine();

                Console.Write("Rodzaj: ");
                section = Console.ReadLine();

                Console.Write("Czas trwania [minuty]: ");
                duration = int.Parse(Console.ReadLine());

                TextFileHandler.CreateNewMovie(title, section, duration);

                Console.WriteLine("Element dodano pomyślnie");
                Console.ReadKey();
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
            byte type;
            int id;

            Console.Clear();
            Console.WriteLine("Ekran usuwanie elementu zbioru");
            Console.WriteLine("___________________________");

            Console.Write("Podaj typ elementu:\nKsiążka: 1\nFilm: 2\n");
            type = byte.Parse(Console.ReadLine());

            if (type == 1)
            {
                Console.Write("Podaj ID książki: ");
                id = int.Parse(Console.ReadLine());

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
                id = int.Parse(Console.ReadLine());
               
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
            else
            {
                Console.WriteLine("Podano zły typ elementu!");
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
                Console.Write("\nPodaj ID elementu: ");
                id = ushort.Parse(Console.ReadLine());

                if (TextFileHandler.CheckIfBookExistsById(id))
                {
                    int availableBorrowingIdTmp = TextFileHandler.GetCurrentBorrowingID(LoggedOrdinaryUser) + 1;

                    LoggedOrdinaryUser.BorrowLibraryElement(DateTime.Now, id, type, availableBorrowingIdTmp);
                    Console.ReadKey();
                } 
                else
                {
                    Console.WriteLine("Nie ma takiego elementu w zbiorze!");
                    Console.ReadKey();
                    BorrowALibraryElement(LoggedOrdinaryUser);
                }

                Console.ReadKey();
            }
            else if (type == 2)
            {
                Console.Write("\nPodaj ID elementu: ");
                id = ushort.Parse(Console.ReadLine());

                if (TextFileHandler.CheckIfMovieExistsById(id))
                {
                    int availableBorrowingIdTmp = TextFileHandler.GetCurrentBorrowingID(LoggedOrdinaryUser) + 1;
                    LoggedOrdinaryUser.BorrowLibraryElement(DateTime.Now, id, type, availableBorrowingIdTmp);
                    Console.WriteLine("SKonczono"); //usun
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Nie ma takiego elementu w zbiorze!");
                    Console.ReadKey();
                    BorrowALibraryElement(LoggedOrdinaryUser);
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Podano zły typ elementu!");
                Console.ReadKey();
                BorrowALibraryElement(LoggedOrdinaryUser);
            }
            
        }

    }

}
