using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class LibraryCollectionElement
    {
        protected static int currentElementID = 0;

        protected int elementID;
        protected string elementTitle;
        protected string elementSection;
        private bool elementAvailability;

        public LibraryCollectionElement(string title, string section)
        {
            this.ElementTitle = title;
            this.ElementSection = section;
            this.ElementID = currentElementID++;
            this.ElementAvailability = false;
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

        public string ElementTitle
        {
            get
            {
                return this.elementTitle;
            }
            private set
            {
                this.elementTitle = value;
            }
        }

        public string ElementSection
        {
            get
            {
                return this.elementSection;
            }
            private set
            {
                this.elementSection = value;
            }
        }
      
        public bool ElementAvailability
        {
            get
            {
                return this.elementAvailability;
            }
            set
            {
                this.elementAvailability = value;
            }
        }
    }
}
