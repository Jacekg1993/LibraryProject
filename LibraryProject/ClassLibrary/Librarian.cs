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

        public Librarian(string name, string surname, byte type, int id, string password, string login) : base(name, surname, type, id, password, login)
        {

        }
   
        public void ConfirmUsersBorrowing()
        {

        }

        public void ConfirmUsersReturning()
        {

        }

        private class Request
        {
            public int RequestID { get; private set; }
            public int ElementID { get; private set; }
            public byte ElementType { get; private set; } // 1 - book, 2 - movie

            public Request(DateTime date, int elementID, byte elementType, int borrowID)
            {
                this.ElementID = elementID;
                this.ElementType = elementType;
                this.RequestID = borrowID;
            }
        }

    }
}
