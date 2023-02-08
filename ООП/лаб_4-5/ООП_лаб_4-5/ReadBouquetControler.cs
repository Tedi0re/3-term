using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ООП_лаб_4_5
{
    static partial class BouquetControler
    {
        static public Bouquet ReadBouquet(string  path)//запись в букет
        {
            bouquet = new Bouquet();
            StreamReader streamReader = File.OpenText(path);//нужна проверка на открытие
            string text = streamReader.ReadToEnd() +'\0';
            string temp = null;
            for (int j = -1, i = 0;; i++)//i - для символов в строке, j - для объектов
            {
                switch (text[i])
                {
                    case '\r':
                        {
                            break;
                        }
                    case '\n':
                        {
                            WriteField(temp, ref j);
                            temp = "";
                            break;
                        }
                    case '\0':
                        {
                            return bouquet;
                        }
                    default:
                        temp += text[i];
                        break;
                }
            }
        }


        static Bouquet WriteField(string str, ref int index)//запись поля
        {
            string field = "";
            for (int i = 0;; i++)
            {
                field += str[i];
                if(str[i] == ':')
                {
                    break;
                }
            }

            switch (field)
            {
                case "Type:":
                    {
                        bouquet.NumberOfFlowers++;
                        index++;
                        switch (SubStrDel(str, field))
                        {
                            case "Rose":
                                {
                                    Rose rose = new Rose("undefined");
                                    bouquet._flowers.Add(rose);
                                    break;
                                }
                            case "Gladiolus":
                                {
                                    Gladiolus gladiolus = new Gladiolus("undefined");
                                    bouquet._flowers.Add(gladiolus);
                                    break;
                                }
                            case "Cactus":
                                {
                                    Cactus cactus = new Cactus("undefined");
                                    bouquet._flowers.Add(cactus);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case "Name:":
                    {
                        bouquet._flowers[index].name = SubStrDel(str, field);
                        break;
                    }
                case "Color:":
                    {
                        bouquet._flowers[index].color = SubStrDel(str, field);
                        break;
                    }
                case "Alive:":
                    {
                        bouquet._flowers[index].alive = Convert.ToBoolean(SubStrDel(str, field));
                        break;
                    }
                case "Age:":
                    {
                        bouquet._flowers[index].age = Convert.ToUInt32(SubStrDel(str, field));
                        break;
                    }
                case "NumberOfPetals:":
                    {
                        bouquet._flowers[index].numberOfPetals = Convert.ToUInt32(SubStrDel(str, field));
                        break;
                    }
                case "Cost:":
                    {
                        bouquet._flowers[index].cost = Convert.ToUInt32(SubStrDel(str, field));
                        bouquet.CostOfBouquet+= Convert.ToUInt32(SubStrDel(str, field));
                        break;
                    }
                default:
                    break;
            }
            return bouquet;
        }

        static string SubStrDel(string str, string substr)//удаление подстроки
        {
            int n = str.IndexOf(substr);
            str = str.Remove(n, substr.Length);
            return str;
        }

    }
}
