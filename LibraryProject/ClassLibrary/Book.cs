using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Book : LibraryCollectionElement
    {
        public uint PageAmount { get; private set; }
   
        public Book(string title, string section, int ID, uint pageAmount ) : base(title, section, ID)
        {
            this.PageAmount = pageAmount;
        }
    }
}
