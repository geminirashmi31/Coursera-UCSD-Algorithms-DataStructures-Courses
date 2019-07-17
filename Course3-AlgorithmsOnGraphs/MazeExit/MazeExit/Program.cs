using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MazeExit
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Enter number of vertices and edges");
            string[] numberOfVerticesAndEdges = Console.ReadLine().Split(' ');
            int numOfVertices = Convert.ToInt32(numberOfVerticesAndEdges[0]);
            int numOfEdges = Convert.ToInt32(numberOfVerticesAndEdges[1]);
           // Console.WriteLine("Enter the two vertices");

            int[,] edges = new int[numOfEdges, 2];

            for (int i = 0; i < numOfEdges; i++)
            {
                string[] verticesStringArray = Console.ReadLine().Split(' ');
                int vertex1 = Convert.ToInt32(verticesStringArray[0]);
                int vertex2 = Convert.ToInt32(verticesStringArray[1]);

                edges[i, 0] = vertex1;
                edges[i, 1] = vertex2;
            }

            //Console.WriteLine("Enter source and target vertices");
            string[] sourceAndTarget = Console.ReadLine().Split(' ');
            int src = Convert.ToInt32(sourceAndTarget[0]);
            int target = Convert.ToInt32(sourceAndTarget[1]);


            var graph = CreateGraph(edges);

            bool found = DFS(graph, src, target);

            Console.WriteLine(found == true ? 1 : 0);
        }

        private static Dictionary<int, IList<int>> CreateGraph(int[,] edges)
        {
            var graph = new Dictionary<int, IList<int>>();

            //GetLength is used for multi dimensional array
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int v1 = edges[i, 0];
                int v2 = edges[i, 1];

                if(!graph.ContainsKey(v1))
                {
                    graph.Add(v1, new List<int>());
                }

                if (!graph.ContainsKey(v2))
                {
                    graph.Add(v2, new List<int>());
                }

                IList<int> list1 = graph[v1];
                list1.Add(v2);

                graph[v2].Add(v1);
            }

            return graph;
        }

        private static bool DFS(Dictionary<int, IList<int>> graph, int start, int target)
        {
            if(!graph.ContainsKey(start))
            {
                return false;
            }

            Stack<int> stack = new Stack<int>();
            Dictionary<int, bool> visited = new Dictionary<int, bool>();

            stack.Push(start);

            while(stack.Count > 0)
            {
                var vertex = stack.Pop();

                if(vertex == target)
                {
                    return true;
                }


                // If this vertex is visited, no-op
                if(visited.ContainsKey(vertex))
                {
                    continue;
                }

                // mark this vertex as visited
                visited.Add(vertex, true);

                // Add non-visted neighbors of this vertex to the stack
                IList<int> neighbors = graph[vertex];
                foreach(int neighbor in neighbors)
                {
                    if(!visited.ContainsKey(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return false;
        }
    }
}
