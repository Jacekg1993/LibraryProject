using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class User
    {
        private string password;
        public int UserID { get; private set; }
        public string Name { get; private set; }
        public string SurName { get; private set; }       
        public byte UserType { get; private set; }
        public string Password
        {
            get
            {
                return "Access denied";
            }
            private set
            {
                this.password = value;
            }
        }
        
        public User()
        {
            this.Name = null;
            this.SurName = null;           
            this.UserID = 0;
            this.Password = null;
        }

        public User(string name, string surname, byte type, int id, string password)
        {
            this.Name = name;
            this.SurName = surname;
            this.UserID = id;
            this.UserType = type;
            this.Password = password;
        }                         
    }
}
