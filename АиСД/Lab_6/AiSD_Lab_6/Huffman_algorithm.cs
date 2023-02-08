using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace AiSD_Lab_6
{
    interface IHuffman_algorithm
    {
        List<Tuple<char, int>> Counter(string str);//Подсчет символов
        List <Tuple<char, string>> UnionNodes(List<Tuple<char, int>> Symbols);//построение дерева. создание кодировок
        List<Tuple<char, int>> Sort(ref List<Tuple<char, int>> Symbols);//сортировка кортежей
        List<Tree> SortTree(ref List<Tree> Nodes);//сортировка дерева
        List<Tuple<char, string>> LPK(Tree tree, List<Tuple<char, string>> Encoding, string code = "");//обход дерева
        void HuffmanAlgorithm();//вызывающая функция

    }

    class Huffman_algorithm : IHuffman_algorithm
    {
        public List<Tuple<char, int>> Sort(ref List<Tuple<char, int>> Symbols)
        {
            for (int i = 0; Symbols.Count - i > 0; i++)
            {
                for (int j = Symbols.Count - 1; j > 0; j--)
                {
                    if (Symbols[j].Item2 < Symbols[j - 1].Item2)
                    {
                        var buf = Symbols[j];
                        Symbols[j] = Symbols[j - 1];
                        Symbols[j - 1] = buf;
                    }
                }
            }
            return Symbols;
        }

        public List<Tree> SortTree(ref List<Tree> Nodes)
        {
            for (int i = 0; Nodes.Count - i > 0; i++)
            {
                for (int j = Nodes.Count - 1; j > 0; j--)
                {
                    if (Nodes[j].Priority < Nodes[j - 1].Priority)
                    {
                        var buf = Nodes[j];
                        Nodes[j] = Nodes[j - 1];
                        Nodes[j - 1] = buf;
                    }
                }
            }
            return Nodes;
        }

        public List<Tuple<char, int>> Counter(string str)
        {
            List<Tuple<char, int>> Symbols = new List<Tuple<char, int>>();

            for (int i = 0; str.Length != 0; i++)
            {
                if (str != "")
                {
                    char CurrentSymbol = str[0];
                    int CurrentMatch = 0;
                    for (int j = 0; j < str.Length; )
                    {
                        if (CurrentSymbol == str[j])
                        {
                            CurrentMatch++;
                            str = str.Remove(j, 1);
                            //j--;
                        }
                        else j++;
                    }
                    Tuple<char, int> tuple = new Tuple<char, int>(CurrentSymbol, CurrentMatch);
                    Symbols.Add(tuple);
                }
                else break;
                
            }
            Sort(ref Symbols);
            return Symbols;
        }



        public List<Tuple<char, string>> UnionNodes(List<Tuple<char, int>> Symbols)
        {
           
            List<Tree> HuffmanTree = new List<Tree>();

            for (int i = 0; i < Symbols.Count; i++)
            {
                Tree tree = new Tree(Convert.ToString(Symbols[i].Item1), Symbols[i].Item2);
                HuffmanTree.Add(tree);
            }
           
            for (int i = 0; i < HuffmanTree.Count - 2;)
            {
               
                if(HuffmanTree[i].Priority + HuffmanTree[i + 1].Priority <= HuffmanTree[i].Priority + HuffmanTree[i + 2].Priority)
                {
                    Tree tree = new Tree(HuffmanTree[i].Data + HuffmanTree[i + 1].Data, HuffmanTree[i].Priority + HuffmanTree[i + 1].Priority, HuffmanTree[i], HuffmanTree[i + 1]);
                    HuffmanTree.Add(tree);
                    HuffmanTree.Remove(HuffmanTree[i]);
                    HuffmanTree.Remove(HuffmanTree[i]);
                }
                else
                {
                    Tree tree = new Tree(HuffmanTree[i].Data + HuffmanTree[i + 2].Data, HuffmanTree[i].Priority + HuffmanTree[i + 2].Priority, HuffmanTree[i], HuffmanTree[i + 2]);
                    HuffmanTree.Add(tree);
                    HuffmanTree.Remove(HuffmanTree[i]);
                    HuffmanTree.Remove(HuffmanTree[i + 1]);
                }
                SortTree(ref HuffmanTree);
            }
            Tree _tree = new Tree(HuffmanTree[0].Data + HuffmanTree[1].Data, HuffmanTree[0].Priority + HuffmanTree[1].Priority, HuffmanTree[0], HuffmanTree[1]);
            HuffmanTree.Add(_tree);
            HuffmanTree.Remove(HuffmanTree[0]);
            HuffmanTree.Remove(HuffmanTree[0]);

            List<Tuple<char, string>> Encoding = new List<Tuple<char, string>>();
            Encoding = LPK(HuffmanTree[0], Encoding);
            return Encoding;
        }

        public List<Tuple<char, string>> LPK(Tree tree, List<Tuple<char, string>> Encoding, string code = "")
        {
            
            if (tree != null)
            {
                if(tree.LeftChild == null && tree.RightChild == null)
                {
                    Tuple<char, string> tuple = new Tuple<char, string>(Convert.ToChar(tree.Data), code);
                    Encoding.Add(tuple);
                    
                }
                if(tree.LeftChild != null)
                {
                    //code += "0";
                    LPK(tree.LeftChild, Encoding, code + "0");

                }
               if(tree.RightChild != null)
                {
                   // code += "1";
                    LPK(tree.RightChild, Encoding, code + "1");
                }
                
                
            }
           
            return Encoding;
        }

        public void HuffmanAlgorithm()
        {
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            Huffman_algorithm a = new Huffman_algorithm();
            List<Tuple<char, int>> b = a.Counter(str);
            foreach (var item in b)
            {
                Console.WriteLine(item.Item1 + " " + item.Item2);
            }
            List<Tuple<char, string>> c = a.UnionNodes(b);
            foreach (var item in c)
            {
                Console.WriteLine(item.Item1 + " : " + item.Item2);
            }

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < c.Count; j++)
                {
                    if(str[i] == c[j].Item1)
                    {
                        Console.Write(c[j].Item2);
                    }
                }
            }
        }
    }
}
