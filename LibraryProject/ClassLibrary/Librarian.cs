using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Librarian : User
    {
        public Librarian() : base()
        {

        }

        public Librarian(string name, string surname, byte type, int id, string password) : base(name, surname, type, id, password)
        {

        }

        public void CreateNewAccount()
        {

        }

        public void RemoveAccount()
        {

        }

        public string GetUsersList()
        {
            return null;
        }

        public string GetAllLibraryElementsList()
        {
            return null;
        }

        public void AddLibraryElement()
        {

        }

        public void RemoveLibraryElement()
        {

        }

        public void ConfirmUsersBorrowing()
        {

        }

        public void ConfirmUsersReturning()
        {

        }

    }
}
