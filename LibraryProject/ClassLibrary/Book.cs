using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Book : LibraryCollectionElement
    {
        public int PageAmount { get; private set; }
   
        public Book(string title, string section, int pageAmount) : base(title, section)
        {
            this.PageAmount = pageAmount;
        }
    }
}
