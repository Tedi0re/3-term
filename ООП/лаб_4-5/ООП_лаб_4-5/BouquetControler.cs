using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    
    static partial class BouquetControler
    {
        static Bouquet bouquet;

        public static void CurrentBouquet(Bouquet NewBouquet)
        {
            BouquetControler.bouquet = NewBouquet;
        }

        public static void DeleteFlower(Flower obj, string name)
        {
            if (bouquet._flowers.Contains(obj))
            {
                if(obj.name == name)
                {
                    bouquet.Delete(obj);
                }
                
            }
            else
            {
                Console.WriteLine($"Элемент {name} не найден");
            }
        }

        public static Bouquet Copy(Bouquet bouquet)
        {
            return bouquet;
        }

        public static void Info()
        {
            bouquet.Info();
        }

        static BouquetControler()
        {
            bouquet = new Bouquet();
        }
    }
}
