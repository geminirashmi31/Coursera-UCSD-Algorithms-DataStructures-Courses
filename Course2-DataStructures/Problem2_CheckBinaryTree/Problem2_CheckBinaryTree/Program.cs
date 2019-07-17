using System;
using System.Text;
using System.Collections.Generic;

namespace Problem2_CheckBinaryTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numberOfVertices = Convert.ToInt32(Console.ReadLine());

            if(numberOfVertices < 1)
            {
                Console.WriteLine("CORRECT");
                return;
            }

            int[,] multiArray = new int[numberOfVertices, 3];

            for (int i = 0; i < numberOfVertices; i++)
            {
                string[] stringArray = Console.ReadLine().Split(' ');

                multiArray[i, 0] = Convert.ToInt32(stringArray[0]);
                multiArray[i, 1] = Convert.ToInt32(stringArray[1]);
                multiArray[i, 2] = Convert.ToInt32(stringArray[2]);
            }

            /* var root = CreateTree(multiArray, 0);

             CheckBinaryTree cbt = new CheckBinaryTree();
             List<int> list = new List<int>();

             bool result = cbt.CheckTree(root, list);

             if (result == true && IsIncreasing(list))
             {
                 Console.WriteLine("CORRECT");
             }

             else
             {
                 Console.WriteLine("INCORRECT");
             } */

            CheckBinaryTree2 cbt2 = new CheckBinaryTree2();
            List<int> list = new List<int>();

            bool result = cbt2.CheckTree(multiArray, 0, list);

            if(result == true && IsIncreasing(list))
            {
                Console.WriteLine("CORRECT");
            }

            else
            {
                Console.WriteLine("INCORRECT");
            }

        }

        private static bool IsIncreasing(List<int> list)
        {
            if (list.Count <= 1)
            {
                return true;
            }

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] > list[i])
                {
                    return false;
                }
            }

            return true;
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
    /*public class Node
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

    /*public class CheckBinaryTree
    {
        public bool CheckTree(Node root, List<int> list)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Left != null && root.Key <= root.Left.Key)
            {
                return false;
            }

            else if (root.Right != null && root.Key > root.Right.Key)
            {
                return false;
            }

            bool left = CheckTree(root.Left, list);
            // Add item to list
            list.Add(root.Key);

            bool right = CheckTree(root.Right, list);

            return left && right;
        }*/

        public class CheckBinaryTree2
        {
            public bool CheckTree(int[,] data, int index, List<int> list)
            {
                if(index == -1)
                {
                    return true;
                }

                int leftChildIndex = data[index, 1];
                int rightChildIndex = data[index, 2];

                if(leftChildIndex != -1 && data[leftChildIndex, 0] >= data[index, 0])
                {
                    return false;
                }

                else if(rightChildIndex != -1 && data[rightChildIndex, 0] < data[index, 0])
                {
                    return false;
                }

                bool left = CheckTree(data, leftChildIndex, list);
                list.Add(data[index, 0]);
                bool right = CheckTree(data, rightChildIndex, list);

                return left && right;
            }
        }
    }
