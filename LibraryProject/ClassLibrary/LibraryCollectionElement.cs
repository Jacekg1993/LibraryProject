﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class LibraryCollectionElement
    {
        public int ElementID { get; private set; }
        public string ElementTitle { get; private set; }
        public string ElementSection { get; private set; }
        public bool ElementAvailability { get; set; }

        public LibraryCollectionElement(string title, string section, int ID)
        {
            this.ElementTitle = title;
            this.ElementSection = section;
            this.ElementID = ID;
            this.ElementAvailability = true;
        } 
    }
}
