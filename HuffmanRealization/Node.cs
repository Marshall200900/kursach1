using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    public class Node
    {
        public char? Symbol { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        private int weight;
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0) Weight = 0; else weight = value;
            }
        }
        public Node(int weight, char? symbol = null)
        {
            Weight = weight;
            Symbol = symbol;
        }
        public Node(Node left=null, Node right=null, char? symbol = null)
        {
            LeftNode = left;
            RightNode = right;
            Weight = (left != null ? left.Weight : 0) + (right != null ? right.Weight : 0);
            Symbol = symbol;


        }

        //Создание дерева из конечных узлов
        public static Node MakeTreeFromEnds(List<Node> nodes)
        {
            while (nodes.Count > 1)
            {
                CombineMins(nodes);
            }
            return nodes.First();
        }


        public static void CombineMins(List<Node> nodes)
        {
            Node min = new Node();
            Node min2 = new Node();
            int pos;
            int pos2;
            if (nodes[0].Weight < nodes[1].Weight)
            {
                min = nodes[0];
                min2 = nodes[1];
                pos = 0;
                pos2 = 1;
            }
            else
            {
                min = nodes[1];
                min2 = nodes[0];
                pos = 1;
                pos2 = 0;
            }
            
            for(int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Weight < min.Weight)
                {
                    min = nodes[i];
                    pos = i;

                }
            }
            
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Weight < min2.Weight && i != pos)
                {
                    min2 = nodes[i];
                    pos2 = i;

                }
            }
            nodes.Remove(min);
            nodes.Remove(min2);
            nodes.Add(new Node(min, min2));

        }

    }
}
