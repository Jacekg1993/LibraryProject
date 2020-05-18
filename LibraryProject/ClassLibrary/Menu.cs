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
                LoggedLibrarian = new Librarian(name: userArguments[1], surname: userArguments[2], type: byte.Parse(userArguments[3]), id: int.Parse(userArguments[0]), password: userArguments[4]);

                Console.Clear();
                Console.WriteLine($"Witaj {LoggedLibrarian.Name}!");
                Console.Write("kliknij aby kontynuować");
                Console.ReadKey();
                LibrarianMenuView();
            }
            else if(byte.Parse(userArguments[3]) == 2)
            {
                LoggedOrdinaryUser = new OrdinaryUser(name: userArguments[1], surname: userArguments[2], type: byte.Parse(userArguments[3]), id: int.Parse(userArguments[0]), password: userArguments[4]);

                Console.Clear();
                Console.WriteLine($"Witaj {LoggedOrdinaryUser.Name}!");
                Console.Write("kliknij aby kontynuować");
                Console.ReadKey();
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
                    return userData + $",{password}";
                }
                else if (login.Contains("User"))
                {
                    userData = TextFileHandler.GetOrdinaryUserDataFromFile(UserId);
                    return userData + $",{password}";
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
                    
                    break;
                case LibrarianMenuOption.RemoveLibraryElement:
                    
                    break;
                case LibrarianMenuOption.GetUsersList:
                    GetAllUsersList();
                    break;
                case LibrarianMenuOption.GetLibrarianElementsList:
                    GetAllLibraryElementsList();
                    break;
                case LibrarianMenuOption.SearchLibraryElement:
                    break;
                case LibrarianMenuOption.ApproveBorrow:
                    break;
                case LibrarianMenuOption.ApproveReturn:
                    break;
                case LibrarianMenuOption.LogOut:
                    
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

            }
            else if (type == 2)
            {

            }
            else
            {
                Console.WriteLine("Podano zły typ elementu!");
                Console.ReadKey();
                AddNewLibraryElement();
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
    }
}
