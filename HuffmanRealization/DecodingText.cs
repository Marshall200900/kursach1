using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    class DecodingText
    {
        // Функция декодирования строки
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

        // Функция декодирования дерева
        public static Node DecodeTree(ref string s)
        {
            Node tree = new Node();
            Run(tree, ref s); // Вызов вспомогательной функции Run

            int number = tree.FindNumberOfEnds(); // Нахождение количества конечных элементов дерева

            List<byte> byteList = new List<byte>();

            for (int i = 0; i < number; i++)
            {
                byteList.Add(Convert.ToByte(s.Substring(0, 8), 2)); // Добавление в массив байтов Строку из 8 битов, преобразованную в байт
                s = s.Substring(8); // Удаление первых восьми символов из строки
            }
            string symbols = Encoding.GetEncoding(1251).GetString(byteList.ToArray()); // Преобразование массива байтов в текстовую строку
            Node.AttachSymbols(tree, ref symbols); // Назначить конечным элементам символы
            return tree;
        }
        private static void Run(Node ptr, ref string s)
        {
            // Если первый символ равен 1, то создать левое поддерево и перейти в него
            if (s[0] == '1')
            {
                ptr.LeftNode = new Node();
                s = s.Substring(1, s.Length-1); // Удаление первого символа
                Run(ptr.LeftNode, ref s);
            }
            // Если первый символ равен 1, то создать левое поддерево и перейти в него
            if (s[0] == '1')
            {
                ptr.RightNode = new Node();
                s = s.Substring(1, s.Length-1); // Удаление первого символа
                Run(ptr.RightNode, ref s);

            }
            s = s.Substring(1, s.Length-1); // Удаление первого символа
        }
    }
}
