using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class OrdinaryUser : User
    {
        public float Penalty { get; set; }
        private List<int> UserElementsList = new List<int>(); // czy na pewno potrzebne? elementy wypozyczone mam w liscie UserBorrowings
        private List<Borrowing> UserBorrowings = new List<Borrowing>();

        public OrdinaryUser() : base()
        {
            this.Penalty = 0;
            this.UserBorrowings.Clear(); // Pozniej do zmiany, poniewaz Borrowings beda sie znajdowac rowniez w pliku.txt i tam tez trzeba to usunac
        }

        public OrdinaryUser(string name, string surname, byte type, int id, string password) : base(name, surname, type, id, password)
        {

        }

        public void BorrowLibraryElement(DateTime date, ushort elementID)
        {
            UserBorrowings.Add(new Borrowing(date, elementID));
        }

        public void ReturnLibraryElement(DateTime date, int borrowID)
        {
            UserBorrowings[borrowID].BorrowStatus = false;
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
