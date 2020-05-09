using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class OrdinaryUser : User
    {
        public float Penalty { get; set; }
        private List<int> UserElementsList = new List<int>(); 

        public OrdinaryUser() : base()
        {
            this.Penalty = 0;
        }

        public OrdinaryUser(string name, string surname, byte type) : base(name, surname, type)
        {

        }

        public void BorrowLibraryElement(DateTime date, ushort elementID)
        {
            UsersBorrowings.Add(new Borrowing(date, elementID));
        }

        public void ReturnLibraryElement(DateTime date, int borrowID)
        {
            UsersBorrowings[borrowID].BorrowStatus = false;
        }

        public string GetUsersLibraryElementsList()
        {
            return null;
        }

        public void SettlePenalties()
        {

        }

    }
}
