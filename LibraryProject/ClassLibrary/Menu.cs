using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public enum LibrarianMenuOption
    {
        CreateNewAccount = 1,
        RemoveAccount,
        GetUsersList,
        GetLibrarianElementsList,
        SearchLibraryElement,
        AddNewLibraryElement,
        RemoveLibraryElement,
        ApproveBorrow,
        ApproveReturn,
        LogOut
    }

    public static class Menu
    {
        public static void LogInView()
        {
            Librarian LoggedLibrarian;
            string userData = null;
            string[] userArguments;
            int c = 0;
            while (userData == null)
            {
                userData = GetUserDataByEnteringPasses();
            }
            userArguments = userData.Split(',');

            LoggedLibrarian = new Librarian(name: userArguments[1], surname: userArguments[2], type: byte.Parse(userArguments[3]), id: int.Parse(userArguments[0]), password: userArguments[4]);

            Console.Clear();

            Console.WriteLine($"Witaj {LoggedLibrarian.Name}!");

            Console.Write("kliknij aby kontynuować");

            LibrarianMenuView();
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

            int LibrarianId = TextFileHandler.GetLibrarianIdIfExist(login, password);

            if ( LibrarianId > -1)
            {
                userData = TextFileHandler.GetLibrarianDataFromFile(LibrarianId);
                return userData + $",{password}";
            }
            return null;
        }

        public static void LibrarianMenuView()
        {
            Console.Clear();

            Console.WriteLine("1. Stwórz nowe konto");
            Console.WriteLine("2. Usuń konto");
            Console.WriteLine("3. Lista użytkowników");
            Console.WriteLine("4. Lista elementów biblioteki");
            Console.WriteLine("5. Wyszukaj element");
            Console.WriteLine("6. Dodaj element");
            Console.WriteLine("7. Usuń element");
            Console.WriteLine("8. Zatwierdź wypożyczenie");
            Console.WriteLine("9. Zatwierdź zwrócenie");
            Console.WriteLine("10. Wyloguj");
        }

        public static void LibrarianMenuOptionSelection(LibrarianMenuOption option)
        {
            switch (option)
            {
                case LibrarianMenuOption.CreateNewAccount:
                    break;
                case LibrarianMenuOption.RemoveAccount:
                    break;
                case LibrarianMenuOption.GetUsersList:
                    break;
                case LibrarianMenuOption.GetLibrarianElementsList:
                    break;
                case LibrarianMenuOption.SearchLibraryElement:
                    break;
                case LibrarianMenuOption.AddNewLibraryElement:
                    break;
                case LibrarianMenuOption.RemoveLibraryElement:
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
    }
}
