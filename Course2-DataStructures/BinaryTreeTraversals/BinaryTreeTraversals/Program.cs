using System;
using System.Text;

namespace BinaryTreeTraversal
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] array = new int[n, 3];

            for (int i = 0; i < n; i++)
            {
                string[] stringArray = Console.ReadLine().Split(' ');

                array[i, 0] = Convert.ToInt32(stringArray[0]);
                array[i, 1] = Convert.ToInt32(stringArray[1]);
                array[i, 2] = Convert.ToInt32(stringArray[2]);
            }

            /*
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }*/

            /* Create Binary Tree and display
            var root = CreateTree(array, 0);
            StringBuilder sb = new StringBuilder();

            TreeTraversal.Inorder(root, sb);
            Console.WriteLine(sb.ToString());

            sb.Clear();
            TreeTraversal.Preorder(root, sb);
            Console.WriteLine(sb.ToString());

            sb.Clear();
            TreeTraversal.Postorder(root, sb);
            Console.WriteLine(sb.ToString());
            */

            StringBuilder sb = new StringBuilder();

            TreeTraversal2.Inorder(array, 0, sb);
            Console.WriteLine(sb);

            sb.Clear();
            TreeTraversal2.Preorder(array, 0, sb);
            Console.WriteLine(sb);

            sb.Clear();
            TreeTraversal2.Postorder(array, 0, sb);
            Console.WriteLine(sb);
        }

        /*private static Node CreateTree(int[,] data, int index)
        {
            if (index < 0 || index >= data.GetLength(0))
            {
                return null;
            }

            int key = data[index, 0];
            int leftChildIndex = data[index, 1];
            int rightChildIndex = data[index, 2];

            var node = new Node(key);
            node.Left = CreateTree(data, leftChildIndex);
            node.Right = CreateTree(data, rightChildIndex);

            return node;
        }*/
    }

    // Node class
   /* public class Node
    {
        public int Key { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int key)
        {
            this.Key = key;
            this.Left = null;
            this.Right = null;
        }

    }*/

    public class TreeTraversal2
    {
        public static void Inorder(int[,] data, int index, StringBuilder sb)
        {
            if (index >= 0 && index < data.GetLength(0))
            {
                Inorder(data, data[index, 1], sb);

                //Console.Write(data[index, 0] + " ");
                sb.Append(data[index, 0]).Append(" ");

                Inorder(data, data[index, 2], sb);
            }
        }

        public static void Preorder(int[,] data, int index, StringBuilder sb)
        {
            if (index >= 0 && index < data.GetLength(0))
            {
                //Console.Write(data[index, 0] + " ");
                sb.Append(data[index, 0]).Append(" ");
              
                Preorder(data, data[index, 1], sb);
                Preorder(data, data[index, 2], sb);
            }
        }

        public static void Postorder(int[,] data, int index, StringBuilder sb)
        {
            if (index >= 0 && index < data.GetLength(0))
            {
                Postorder(data, data[index, 1], sb);
                Postorder(data, data[index, 2], sb);
                //Console.Write(data[index, 0] + " ");

                sb.Append(data[index, 0]).Append(" ");
            }

        }
    }

    // Tree traversal
    public class TreeTraversal
    {
        public static void Inorder(Node root, StringBuilder sb)
        {
            if (root != null)
            {
                Inorder(root.Left, sb);
                sb.Append(root.Key + " ");
                Inorder(root.Right, sb);
            }
        }

        public static void Preorder(Node root, StringBuilder sb)
        {
            if (root != null)
            {
                sb.Append(root.Key + " ");
                Preorder(root.Left, sb);
                Preorder(root.Right, sb);
            }
        }

        public static void Postorder(Node root, StringBuilder sb)
        {
            if (root != null)
            {
                Postorder(root.Left, sb);
                Postorder(root.Right, sb);
                sb.Append(root.Key + " ");
            }

        }
    }
}