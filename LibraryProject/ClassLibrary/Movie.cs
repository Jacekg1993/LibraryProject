using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Movie : LibraryCollectionElement
    {
        public uint Duration { get; private set; }

        public Movie(string title, string section, int ID, uint duration ) : base(title, section, ID)
        {
            this.Duration = duration;
        }

    }
}
