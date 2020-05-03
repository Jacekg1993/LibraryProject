using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class User
    {       
        private string name;
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

        private string surName;
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

        private float penalty;
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

        List<Borrowing> UsersBorrowings = new List<Borrowing>();





        private class Borrowing
        {
            private ushort bookID;


        }
    }
}
