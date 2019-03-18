using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    class DecodingHuffman
    {
        

        public static string DecodeHuffman(Node tree, string binaryCode)
        {
            Node pointer = tree; //Маркер для перемещения по дереву
            string decompressedText = ""; //Строка на вывод
            foreach (char c in binaryCode)
            {
                
                //Если символ строки равен 0, перейти в левое поддерево
                if (c == '0' && pointer.LeftNode !=null)
                    pointer = pointer.LeftNode;
                //Иначе в правое поддерево
                else if (c == '1' && pointer.RightNode!=null)
                    pointer = pointer.RightNode;
                //Если в узле есть символ, то добавить его в строку на вывод
                if (pointer.Symbol != null)
                {
                    decompressedText += pointer.Symbol;
                    pointer = tree;
                }



            }
            return decompressedText;
        }
        public static Node DecodeTree(ref string s)
        {
            Node tree = new Node();
            Run(tree, tree, ref s);
            return tree;
        }
        private static void Run(Node tree,Node ptr, ref string s)
        {
            if (s[0] == '1')
            {
                ptr.LeftNode = new Node();
                s = s.Substring(1, s.Length-1);
                Run(tree, ptr.LeftNode, ref s);
            }
            if (s[0] == '1')
            {
                ptr.RightNode = new Node();
                s = s.Substring(1, s.Length-1);
                Run(tree, ptr.RightNode, ref s);

            }
            s = s.Substring(1, s.Length-1);
            //if (ptr == tree && s[0] == '0')
            //{
            //    s = s.Substring(1, s.Length - 1);
            //    return;
            //}
        }
    }
}
