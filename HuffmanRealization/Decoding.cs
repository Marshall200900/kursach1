using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanRealization
{
    class Decoding
    {
        public static string Decode(Node tree, string binaryCode)
        {
            Node pointer = tree; //Маркер для перемещения по дереву
            string decompressedText = ""; //Строка на вывод
            foreach (char c in binaryCode)
            {

                //Если символ строки равен 0, перейти в левое поддерево
                if (c == '0')
                    pointer = pointer.LeftNode;
                //Иначе в правое поддерево
                else if (c == '1')
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
    }
}
