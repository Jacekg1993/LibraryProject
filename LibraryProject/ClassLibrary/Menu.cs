using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class Menu
    {
        public static void LogInView()
        {
            Librarian LoggedLibrarian;
            string userData;
            string[] userArguments;

            Console.WriteLine("Witaj! Zaloguj sie na konto");
            userData = GetUserData();
            userArguments = userData.Split(',');

            LoggedLibrarian = new Librarian(userArguments[1], userArguments[2], byte.Parse(userArguments[3]), int.Parse(userArguments[0]), userArguments[4]);

            Console.WriteLine(LoggedLibrarian.UserType);
            Console.ReadKey();
        }

        public static string GetUserData()
        {
            string userData;
            string login;
            string password;

            Console.Write("Login: ");
            login = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            int LibrarianId = TextFileHandler.GetLibrarianIdIfExist(login, password);

            if ( LibrarianId != -1)
            {
                userData = TextFileHandler.GetLibrarianDataFromFile(LibrarianId);
                return userData + $",{password}";
            }
            return null;
        }
    }
}
