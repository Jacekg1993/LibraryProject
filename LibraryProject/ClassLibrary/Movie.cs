using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Movie : LibraryCollectionElement
    {
        private int duration;

        public int Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                this.duration = value;
            }
        }

        public Movie(string title, string section, int duration) : base(title, section)
        {
            this.Duration = duration;
        }

    }
}
