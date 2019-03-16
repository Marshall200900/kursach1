using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanRealization
{
    public class Encoding
    {
        public static Node Root { get; private set; }
        private static Dictionary<char?, string> AssignBytesWrapper(Node root, string n)
        {
            Dictionary<char?, string> bytesStr = new Dictionary<char?, string>();
            AssignBytes(root, n, bytesStr);
            return bytesStr;
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

        private static string MakeCompressedString(string str, Dictionary<char?, string> bytesStr)
        {
            string compressedStr = "";
            foreach(char c in str)
            {
                compressedStr += bytesStr[c];
            }
            return compressedStr;
        }


        public static string Encode(string str)
        {
            if(str == "")
            {
                throw new Exception();
            }
            List<KeyValuePair<char, int>> dictionaryList = MakeList(str);
            List<Node> nodeList = GetNodeList(dictionaryList);

            Root = Node.MakeTreeFromEnds(nodeList);

            Dictionary<char?, string> bytesStr = AssignBytesWrapper(Root, dictionaryList.Count == 1 ? "0" : "");
            
            string compressedString = MakeCompressedString(str, bytesStr);

            return compressedString;
        }
    }
}
