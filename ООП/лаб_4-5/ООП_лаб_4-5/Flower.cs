using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    [Serializable]
    public abstract  class Flower : Plant
    {
        public abstract uint numberOfPetals { get; set; }
        public abstract uint cost { get; set; }
        public virtual void Blomming()
        {
            Console.WriteLine("Пынь");
        }
    }
}
