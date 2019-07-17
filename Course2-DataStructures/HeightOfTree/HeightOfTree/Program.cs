using System;
using System.Collections.Generic;

namespace HeightOfTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string nodeCount = Console.ReadLine();
            string[] nodeIndexesStr = Console.ReadLine().Split(' ');

            int[] nodeIndexes = Array.ConvertAll(nodeIndexesStr, int.Parse);

            int len = nodeIndexes.Length;

            Node[] nodes = new Node[len];

            // Create node objects
            for (int i = 0; i < len; i++)
            {
                Node node = new Node(i);
                nodes[i] = node;
            }

            // Create tree
            Node rootNode = CreateTree(nodes, nodeIndexes);

            // Find height
            int height = FindTreeHeight(rootNode);

            Console.WriteLine(height);

            // Console.ReadKey();
        }


        public static Node CreateTree(Node[] nodes, int[] nodeIndexes)
        {
            Node root = null;

            int len = nodes.Length;

            // Create tree
            for (int j = 0; j < len; j++)
            {
                int parentIndex = nodeIndexes[j];
                int childIndex = j;

                if (parentIndex == -1)
                {
                    root = nodes[childIndex];
                }
                else
                {
                    Node parentNode = nodes[parentIndex];
                    Node childNode = nodes[childIndex];

                    parentNode.AddChild(childNode);
                }

            }

            return root;
        }

        public static int FindTreeHeight(Node rootNode)
        {
            Queue<Node> q = new Queue<Node>();

            Node dummy = new Node(-1);

            q.Enqueue(dummy);
            q.Enqueue(rootNode);

            int count = 0;
            while(q.Count > 0)
            {
                Node current = q.Dequeue();

                if (current.Key == -1)
                {
                    count++;

                    if(q.Count != 0)
                    {
                        q.Enqueue(current);
                    }
                }

                // Console.WriteLine(current.Key);

                foreach(Node child in current.Children)
                {
                    q.Enqueue(child);
                }
            }

            return count - 1;
        }
    }

    public class Node
    {
        public int Key { get; set; }

        public Node(int key)
        {
            this.Children = new List<Node>();
            this.Key = key;
        }

        public List<Node> Children { get; set; }

        public void AddChild(Node node)
        {
            this.Children.Add(node);
        }
    }
}
