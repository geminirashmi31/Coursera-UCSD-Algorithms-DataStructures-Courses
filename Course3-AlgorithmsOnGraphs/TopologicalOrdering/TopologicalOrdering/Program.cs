using System;
using System.Collections.Generic;

namespace TopologicalOrdering
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

            int[] incoming = new int[numOfVertices + 1];

            var graph = CreateGraph(numOfVertices, edges, incoming);

            // Special case
            int sourceCount = 0;

            for (int i = 1; i <= numOfVertices; i++)
            {
                if (incoming[i] == 0) // it is a source vertex
                {
                    sourceCount++;
                }
            }

            if (numOfVertices > 0 && sourceCount == 0)
            {
                //Console.WriteLine(1);
                return;
            }

            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            Dictionary<int, bool> visiting = new Dictionary<int, bool>();
            List<int> ordered = new List<int>();

            bool hasCycle = false;

            foreach (var key in graph.Keys)
            {
                if (incoming[key] == 0 && !visited.ContainsKey(key))
                {
                    hasCycle = DFS(graph, visited, visiting, key, ordered);

                    if (hasCycle == true) // cycle is found
                    {
                        break;
                    }

                }
            }

            for (int i = 0; i < ordered.Count; i++)
            {
                Console.Write(ordered[i] + " ");
            }

            //Console.WriteLine(hasCycle == true ? 1 : 0);
        }

        private static Dictionary<int, IList<int>> CreateGraph(int vertices, int[,] edges, int[] incoming)
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

                incoming[v2]++;

                graph[v1].Add(v2);
            }

            return graph;
        }

        private static bool DFS(Dictionary<int, IList<int>> graph, Dictionary<int, bool> visited, Dictionary<int, bool> visiting, int start, List<int> ordered)
        {
            // Previously visited, but not through current recursive depth. In that case, this node is already validated
            if (visited.ContainsKey(start) && !visiting.ContainsKey(start))
            {
                return false;
            }

            // if already encountered as part of current recursive depth, it indicates a cycle
            if (visiting.ContainsKey(start))
            {
                return true;
            }



            // Add/update visited
            if (!visited.ContainsKey(start))
            {
                visited.Add(start, true);
            }

            // Add current vertex to visiting, as it denotes current path
            visiting.Add(start, true);

            IList<int> neighbors = graph[start];


            for (int i = 0; i < neighbors.Count; i++)
            {
                if (DFS(graph, visited, visiting, neighbors[i], ordered) == true)
                {
                    return true;
                }
            }

            // Remove current vertex from visiting, returning from current path
            visiting.Remove(start);

            ordered.Insert(0, start);

            return false;
        }
    }
}



