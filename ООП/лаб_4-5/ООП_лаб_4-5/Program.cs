using System;

namespace ООП_лаб_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Rose rose1 = new Rose("красная роза", cost: 10);
            Rose rose2 = new Rose("белая роза", color: "белый", cost: 15);
            Gladiolus alive_gladiolus = new Gladiolus("живой гладиолус", cost: 5);
            Bouquet bouquet = new Bouquet();//
            bouquet.Add(rose2);
            bouquet.Add(alive_gladiolus);
            bouquet.Add(rose1);


            Console.WriteLine(bouquet._flowers[0].color);
            Console.WriteLine(bouquet._flowers[1].color);
            Console.WriteLine(bouquet._flowers[2].color);
            try
            {
               
               
                Gladiolus not_alive_gladiolus = new Gladiolus("мертвый гладиолус", color: "красный", age: 100);
               
                Cactus cactus = new Cactus("Кактус колючий");
                
                Printer iIAmPrinter = new Printer();

                

                Paper paper = new Paper("Бумага", "дуб", age: 3);
                Bush bush = new Bush("куст обыкновенный");

               
            }
            catch(ExceptionAge e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("недопустимое значение - " + e.Value);
                
                
            }
           catch(ExceptionCost e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("недопустимое значение - " + e.Value);
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");

            }
            finally
            {
                Console.WriteLine("Объект не был создан");

                
            }
            Bush[] bushes = new Bush[5];

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        bushes[i] = new Bush("куст обыкновенный", age: (uint)(i * 20));
                    }
                    catch(ExceptionAge)
                    {
                        Console.WriteLine("xnj-nj yt nfr");
                        throw;
                    }

                }
            }
            catch (ExceptionAge e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("недопустимое значение - " + e.Value);
            }


            //bush.Info();
            //rose1.Info();
            //rose1.info(rose1);
            //rose2.Info();
            //alive_gladiolus.Info();
            //not_alive_gladiolus.Info();
            //cactus.Info();
            //paper.Info();
            //iIAmPrinter.iIAmPrinting(rose1);
            //Console.WriteLine(rose1 is Rose);
            //Rose? rose = rose1 as Rose;
            //Console.WriteLine("--------------------------------------------");
            
            //bouquet.Add(not_alive_gladiolus);
            //bouquet.Add(not_alive_gladiolus);
            //Console.WriteLine("--------------------------------------------");
            //BouquetControler.Info();
            //BouquetControler.CurrentBouquet(bouquet);
            //BouquetControler.Info();
            //BouquetControler.DeleteFlower(rose1, "красная роза");
            //BouquetControler.Info();

            Bouquet bouquetFromFile  = BouquetControler.ReadBouquet("Bouquet.txt");
            BouquetControler.CurrentBouquet(bouquetFromFile);
            BouquetControler.Info();
            Bouquet bouquetFromJSON = BouquetControler.ReadBouquetFromJSON("Bouquet.json");
            BouquetControler.CurrentBouquet(bouquetFromJSON);
            BouquetControler.Info();
        }
    }
}
