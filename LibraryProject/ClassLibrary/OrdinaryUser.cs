using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class OrdinaryUser : User
    {
        public float Penalty { get; set; }
        private List<Borrowing> UserBorrowings = new List<Borrowing>();

        public OrdinaryUser() : base()
        {
            this.Penalty = 0;
            this.UserBorrowings.Clear(); // Pozniej do zmiany, poniewaz Borrowings beda sie znajdowac rowniez w pliku.txt i tam tez trzeba to usunac
        }

        public OrdinaryUser(string name, string surname, byte type, int id, string password, string login) : base(name, surname, type, id, password, login)
        {
            this.Penalty = 0;
        }

        public void BorrowLibraryElement(DateTime date, ushort elementID, byte elementType, int borrowID)
        {
            Borrowing newBorrowing = new Borrowing(date.Date, elementID, elementType, borrowID);
            UserBorrowings.Add(newBorrowing);

            byte borrowingStatusTmp = newBorrowing.BorrowStatus;

            TextFileHandler.AddNewBorrowingToUserFile(this, date, elementID, elementType, borrowID, borrowingStatusTmp);

            Console.ReadKey();
        }

        public void ReturnLibraryElement(DateTime date, int borrowID)
        {
            UserBorrowings[borrowID].BorrowStatus = 0;
        }

        public string GetUsersLibraryElementsList()
        {
            return null;
        }

        public void SettlePenalties()
        {

        }

        private class Borrowing
        {
            public int BorrowID { get; private set; }
            public int ElementID { get; private set; }
            public byte ElementType { get; private set; } // 1 - book, 2 - movie
            public DateTime BorrowDate { get; private set; }
            public DateTime ReturnDate { get; private set; }
            public byte BorrowStatus { get; set; } //0 - available, 1 - pending, 2 - borrowed
      
            public Borrowing(DateTime date, int elementID, byte elementType, int borrowID)
            {
                this.BorrowDate = date;
                this.ElementID = elementID;
                this.ElementType = elementType;
                this.BorrowStatus = 1;
                this.BorrowID = borrowID;
            }
        }
    }
}
