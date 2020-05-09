using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class User
    {
        public int UserID { get; private set; }
        public string Name { get; private set; }
        public string SurName { get; private set; }       
        public byte UserType { get; private set; }
        protected List<Borrowing> UsersBorrowings = new List<Borrowing>();

        private static int currentUserID = 0;

        public User()
        {
            this.Name = null;
            this.SurName = null;
            this.UsersBorrowings.Clear();
            this.UserID = 0;
        }

        public User(string name, string surname, byte type)
        {
            this.Name = name;
            this.SurName = surname;
            this.UserID = currentUserID++;
            this.UserType = type;
        }
                    
        protected class Borrowing
        {
            public int BorrowID { get; private set; }
            public int ElementID { get; private set; }
            public DateTime BorrowDate { get; private set; }
            public DateTime ReturnDate { get; private set; }
            public bool BorrowStatus { get; set; }

            private static int currentBorrowID = 0;
           
            public Borrowing(DateTime date, int elementID)
            {
                this.BorrowDate = date;
                this.ElementID = elementID;
                this.BorrowID = currentBorrowID++;
                this.BorrowStatus = true;

            }           
        }
    }
}
