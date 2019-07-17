using System;
using System.Collections.Generic;

namespace ConnectingPoints
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numberOfPoints = Convert.ToInt32(Console.ReadLine());

            int[,] points = new int[numberOfPoints, 2];

            for (int i = 0; i < numberOfPoints; i++)
            {
                string[] coordinatesStringArray = Console.ReadLine().Split(' ');
                int xCoordinate = Convert.ToInt32(coordinatesStringArray[0]);
                int yCoordinate = Convert.ToInt32(coordinatesStringArray[1]);

                points[i, 0] = xCoordinate;
                points[i, 1] = yCoordinate;
            }

            var edges = GetEdges(points);


            double total = FindMSTDistance(edges, numberOfPoints);

            Console.WriteLine("{0:R}", total);

        }

        private static double FindMSTDistance(List<Edge> edges, int numberOfVertices)
        {
            edges.Sort((a, b) => (a.Distance > b.Distance ? 1 : (a.Distance < b.Distance ? -1 : 0) ));

            var disjointSet = new DisjointSet();

            for (int i = 0; i < numberOfVertices; i++)
            {
                disjointSet.MakeSet(i);
            }

          
            double total = 0;
            // int edgeCount = 0;

            foreach(Edge edge in edges)
            {
                int x = disjointSet.FindSet(edge.V1);
                int y = disjointSet.FindSet(edge.V2);

                if(x == y)
                {
                    continue;
                }

                disjointSet.Union(edge.V1, edge.V2);
                total += edge.Distance;

                // edgeCount++;


            }

            return total;
        }

        private static List<Edge> GetEdges(int[,] points)
        {
            var edges = new List<Edge>();

            int len = points.GetLength(0);

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                { 
                    double distance = Math.Sqrt(Math.Pow(points[i, 0] - points[j,0], 2) + Math.Pow(points[i,1] - points[j,1], 2));

                    edges.Add(new Edge(i, j, distance));
                }
            }

            return edges;
        }

        public class Edge
        {
            public Edge(int v1, int v2, double distance)
            {
                this.V1 = v1;
                this.V2 = v2;
                this.Distance = distance;
            }

            public int V1 { get; set; }
            public int V2 { get; set; }
            public double Distance { get; set; }
        }
    }

/* Disjoint sets using path compression and union by rank
 * Supports 3 operations
 * 1) makeSet
 * 2) union
 * 3) findSet
 *
 * For m operations and total n elements time complexity is O(m* f(n)) where f(n) is 
 * very slowly growing function.For most cases f(n) <= 4 so effectively
 * total time will be O(m). Proof in Coreman book.
 */
public class DisjointSet
    {

        private Dictionary<int, Node> map = new Dictionary<int, Node>();

        public class Node
        {
            public int data;
            public Node parent;
            public int rank;
        }

        /**
         * Create a set with only one element.
         */
        public void MakeSet(int data)
        {
            Node node = new Node();
            node.data = data;
            node.parent = node;
            node.rank = 0;
            map.Add(data, node);
        }

        /**
         * Combines two sets together to one.
         * Does union by rank
         *
         * @return true if data1 and data2 are in different set before union else false.
         */
        public bool Union(int data1, int data2)
        {
            Node node1 = map[data1];
            Node node2 = map[data2];

            Node parent1 = FindSet(node1);
            Node parent2 = FindSet(node2);

            //if they are part of same set do nothing
            if (parent1.data == parent2.data)
            {
                return false;
            }

            //else whoever's rank is higher becomes parent of other
            if (parent1.rank >= parent2.rank)
            {
                //increment rank only if both sets have same rank
                parent1.rank = (parent1.rank == parent2.rank) ? parent1.rank + 1 : parent1.rank;
                parent2.parent = parent1;
            }
            else
            {
                parent1.parent = parent2;
            }
            return true;
        }

        /**
         * Finds the representative of this set
         */
        public int FindSet(int data)
        {
            return FindSet(map[data]).data;
        }

        /**
         * Find the representative recursively and does path
         * compression as well.
         */
        private Node FindSet(Node node)
        {
            Node parent = node.parent;
            if (parent == node)
            {
                return parent;
            }
            node.parent = FindSet(node.parent);
            return node.parent;
        }
    }
}
