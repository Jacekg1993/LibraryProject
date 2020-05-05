using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class User
    {
        private static int currentUserID = 0;
        private int userID;
        private string name;
        private string surName;
        private float penalty;
        private List<Borrowing> UsersBorrowings = new List<Borrowing>();

        public User()
        {
            this.Name = null;
            this.SurName = null;
            this.Penalty = 0;
            this.UsersBorrowings.Clear();
            this.UserID = 0;
        }

        public User(string name, string surname)
        {
            this.Name = null;
            this.SurName = null;
            this.UserID = currentUserID++;
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
            private set
            {
                this.userID = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public string SurName
        {
            get
            {
                return this.surName;
            }
            private set
            {
                this.surName = value;
            }
        }

        public float Penalty
        {
            get
            {
                return this.penalty;
            }
            private set
            {
                this.penalty = value;
            }
        }

        public void BorrowLibraryElement(DateTime date, ushort elementID)
        {
            UsersBorrowings.Add(new Borrowing(date, elementID));
        }

        public void ReturnLibraryElement(DateTime date, int borrowID)
        {
            UsersBorrowings[borrowID].BorrowStatus = false;
        }

        

        private class Borrowing
        {
            private static int currentBorrowID = 0;

            private int borrowID;
            private int elementID;
            private DateTime borrowDate;
            private DateTime returnDate;
            private bool borrowStatus;

            public Borrowing(DateTime date, int elementID)
            {
                this.BorrowDate = date;
                this.ElementID = elementID;
                this.BorrowID = currentBorrowID++;
                this.BorrowStatus = true;
            }

            public int BorrowID
            {
                get
                {
                    return this.borrowID;
                }
                private set
                {
                    this.borrowID = value;
                }
            }

            public int ElementID
            {
                get
                {
                    return this.elementID;
                }
                private set
                {
                    this.elementID = value;
                }
            }
            
            public DateTime BorrowDate
            {
                get
                {
                    return this.borrowDate;
                }
                private set
                {
                    this.borrowDate = value;
                }
            }
           
            public DateTime ReturnDate
            {
                get
                {
                    return this.returnDate;
                }
                private set
                {
                    this.returnDate = value;
                }
            }

            public bool BorrowStatus
            {
                get
                {
                    return this.borrowStatus;
                }
                set
                {
                    this.borrowStatus = value;
                }
            }
        }
    }
}
