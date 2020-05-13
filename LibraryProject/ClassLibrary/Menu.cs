using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class Menu
    {
        public static void LogInView()
        {
            Console.WriteLine("Witaj! Zaloguj sie na konto");
            LogIn();
           
        }

        public static void LogIn()
        {
            string login;
            string password;

            Console.Write("Login: ");
            login = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            Console.WriteLine(TextFileHandler.LogInValidation(login, password));

        }
    }
}
