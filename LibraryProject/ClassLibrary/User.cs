﻿using System;
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
        
        public User()
        {
            this.Name = null;
            this.SurName = null;           
            this.UserID = 0;
        }

        public User(string name, string surname, byte type, int id)
        {
            this.Name = name;
            this.SurName = surname;
            this.UserID = id;
            this.UserType = type;
        }                         
    }
}
