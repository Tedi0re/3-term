using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.StatePattern
{
    

    class Context
    {
        private enum State
        {
            NormalLib,
            LibWithName,
            Undefined
        }

        private State stateContext = State.Undefined;

        public string Start(Library library)
        {
            if(stateContext == State.NormalLib)
            {
                stateContext = State.NormalLib;
                return ("Из обычной бибиотеки, идем в обычную библиотеку");
            }
            if(stateContext == State.Undefined)
            {
                stateContext = State.NormalLib;
                return ("Заходим в первую библиотеку. Она обычная");
            }
            if(stateContext == State.LibWithName)
            {
                stateContext = State.NormalLib;
                return ("Из именной библиотеки, идем в обычную библиотеку");
            }

            return null;
        }

        public string Start(AdapterPattern.Adapter library)
        {
            if (stateContext == State.NormalLib)
            {
                stateContext = State.LibWithName;
                return ("Из обычной бибиотеки, идем в именную библиотеку");
            }
            if (stateContext == State.Undefined)
            {
                stateContext = State.LibWithName;
                return ("Заходим в первую библиотеку. Она именная");
            }
            if (stateContext == State.LibWithName)
            {
                stateContext = State.LibWithName;
                return ("Из именной библиотеки, идем в именную библиотеку");
            }
            
            return null;
        }
    }
}
