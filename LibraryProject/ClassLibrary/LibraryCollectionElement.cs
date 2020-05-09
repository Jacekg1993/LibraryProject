using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class LibraryCollectionElement
    {
        protected static int currentElementID = 0;

        protected int ElementID { get; private set; }
        protected string ElementTitle { get; private set; }
        protected string ElementSection { get; private set; }
        protected bool ElementAvailability { get; set; }

        public LibraryCollectionElement(string title, string section)
        {
            this.ElementTitle = title;
            this.ElementSection = section;
            this.ElementID = currentElementID++;
            this.ElementAvailability = true;
        } 
    }
}
