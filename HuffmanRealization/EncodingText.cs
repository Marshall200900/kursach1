using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    public class EncodingText
    {
        public static Node Root { get; private set; } // Свойство дерева
        public static string RootCode { get; set; } // Свойство двоичного кода дерева 
        public static Dictionary<char?, string> BinaryStr { get; set; } // Словарь символ - двоичный код

        // Назначение символам двоичное представление в свойстве BinaryStr
        private static Dictionary<char?, string> AssignBytesWrapper(Node root, string n)
        {
            BinaryStr = new Dictionary<char?, string>();
            AssignBytes(root, n, BinaryStr);
            return BinaryStr;
        }

        private static void AssignBytes(Node node, string n, Dictionary<char?, string> bytesStr)
        {
            if (node.LeftNode != null)
                AssignBytes(node.LeftNode, n + "0", bytesStr);

            if (node.RightNode != null)
                AssignBytes(node.RightNode, n + "1", bytesStr);

            if (node.LeftNode == null && node.RightNode == null)
            {
                bytesStr.Add(node.Symbol, n);
            }
        }

        //Создание словаря из исходной строки
        private static List<KeyValuePair<char, int>> MakeList(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in str)
            {
                //Если словарь не содержит символ
                //Добавить его со значением 1
                if (!dict.ContainsKey(c))
                    dict.Add(c, 1);
                //Иначе прибавить к значению 1
                else
                    dict[c]++;
            }
            //Получить список из словаря
            return dict.ToList();

        }

        //Получение списка из узлов на основе массива пар ключ - значение
        private static List<Node> GetNodeList(List<KeyValuePair<char, int>> dictList)
        {
            List<Node> nodeList = new List<Node>();

            foreach (KeyValuePair<char, int> pair in dictList)
            {
                nodeList.Add(new Node(pair.Value, pair.Key));
            }
            return nodeList;
        }

        // Формирование итоговой строки на вывод
        private static string MakeCompressedString(string str, Dictionary<char?, string> bytesStr)
        {
            string compressedStr = "";
            foreach(char c in str)
            {
                compressedStr += bytesStr[c];
            }
            return compressedStr;
        }

        // Функция кодирования по Хаффману
        public static string EncodeHuffman(string str)
        {
            //Если строка пустая, бросить исключение
            if(str == "")
            {
                throw new Exception();
            }

            // Создание словаря
            List<KeyValuePair<char, int>> dictionaryList = MakeList(str);

            //Создание массива узлов
            List<Node> nodeList = GetNodeList(dictionaryList);

            //Создание дерева
            Root = Node.MakeTreeFromEnds(nodeList);

            //Назначение символам их двоичные коды
            Dictionary<char?, string> binaryStr = AssignBytesWrapper(Root, dictionaryList.Count == 1 ? "0" : "");

            // Возвращение полученной строки
            return MakeCompressedString(str, binaryStr);
        }

        // Кодирование дерева
        public static string EncodeTree(Node node)
        {
            string s = "";
            Run(node, ref s);
            foreach (char c in BinaryStr.Keys)
            {
                var bytes = Encoding.GetEncoding(1251).GetBytes(c.ToString());
                var binstr = string.Join("", bytes.Select(b => Convert.ToString(b, 2)));
                s += string.Format("{0:d8}", int.Parse(binstr));

            }
            return s;

        }

        //Создание двоичного представления по принципу:
        //Если отдаляемся от корня, то пишем 1
        //Если приближаемся, пишем 0
        private static void Run(Node node, ref string s)
        {
            if (node.LeftNode != null)
            {
                s += "1";
                Run(node.LeftNode, ref s);
            }
            if (node.RightNode != null)
            {
                s += "1";
                Run(node.RightNode, ref s);

            }
            s += "0";

        }
    }
}
