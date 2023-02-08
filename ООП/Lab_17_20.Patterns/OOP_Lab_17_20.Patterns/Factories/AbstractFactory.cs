using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.Factories
{
    public interface LibraryAbstactFactory
    {
        public Library CreateLibrary();
        public AdapterPattern.Adapter CreateLibraryWithName();
    }

    
}
