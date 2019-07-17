using System;
using System.Collections.Generic;

namespace AddingExits
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


            var graph = CreateGraph(numOfVertices, edges);

            int count = 0;
            Dictionary<int, bool> visited = new Dictionary<int, bool>();

            foreach (var key in graph.Keys)
            {
                if(!visited.ContainsKey(key))
                {
                    count++;
                    DFS(graph, visited, key);
                }
            }

            Console.WriteLine(count);
        }

        private static Dictionary<int, IList<int>> CreateGraph(int vertices, int[,] edges)
        {
            var graph = new Dictionary<int, IList<int>>();

            for (int i = 1; i <= vertices; i++)
            {
                graph.Add(i, new List<int>());
            }

            //GetLength is used for multi dimensional array
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int v1 = edges[i, 0];
                int v2 = edges[i, 1];

                graph[v1].Add(v2);
                graph[v2].Add(v1);
            }

            return graph;
        }

        private static void DFS(Dictionary<int, IList<int>> graph, Dictionary<int, bool> visited, int start)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                // If this vertex is visited, no-op
                if (visited.ContainsKey(vertex))
                {
                    continue;
                }

                // mark this vertex as visited
                visited.Add(vertex, true);

                // Add non-visted neighbors of this vertex to the stack
                IList<int> neighbors = graph[vertex];
                foreach (int neighbor in neighbors)
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }
    }
}

