using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class LibraryCollectionElement
    {
        protected static int currentElementID = 0;

        public int ElementID { get; private set; }
        public string ElementTitle { get; private set; }
        public string ElementSection { get; private set; }
        public bool ElementAvailability { get; set; }

        public LibraryCollectionElement(string title, string section)
        {
            this.ElementTitle = title;
            this.ElementSection = section;
            this.ElementID = currentElementID++;
            this.ElementAvailability = true;
        } 
    }
}
