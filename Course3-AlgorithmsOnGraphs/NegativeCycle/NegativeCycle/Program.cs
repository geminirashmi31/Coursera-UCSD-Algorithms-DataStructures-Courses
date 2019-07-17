using System;
using System.Collections.Generic;

namespace NegativeCycle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Enter number of vertices and edges");
            string[] verticesAndEdges = Console.ReadLine().Split(' ');
            int numberOfVertices = Convert.ToInt32(verticesAndEdges[0]);
            int numberOfEdges = Convert.ToInt32(verticesAndEdges[1]);

            int[,] edges = new int[numberOfEdges, 3];

            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] verticesStringArray = Console.ReadLine().Split(' ');
                int vertex1 = Convert.ToInt32(verticesStringArray[0]);
                int vertex2 = Convert.ToInt32(verticesStringArray[1]);
                int weight = Convert.ToInt32(verticesStringArray[2]);

                edges[i, 0] = vertex1;
                edges[i, 1] = vertex2;
                edges[i, 2] = weight;
            }

            // Create graph
            var graph = CreateGraph(edges);

            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            IList<int> visiting;

            bool hasCycle = false;
            bool hasNegativeCycle = false;

            foreach (var key in graph.Keys)
            {
                visiting = new List<int>();

                if (!visited.ContainsKey(key))  
                {
                    hasCycle = DFS(graph, visited, visiting, key);

                    if (hasCycle && HasNegativeCycle(graph, visiting)) // cycle is found
                    {
                        hasNegativeCycle = true;
                        break;
                    }

                }
            }

            Console.WriteLine(hasNegativeCycle == true ? 1 : 0); 
        }

        private static bool HasNegativeCycle(Dictionary<int, Dictionary<int, int>> graph, IList<int> visiting)
        {
            int startNode = visiting[visiting.Count - 1];

            // Console.WriteLine("Start: {0}", startNode);

            // visiting.RemoveAt(visiting.Count - 1);

            int startIndex = 0;

            while(startIndex < visiting.Count && visiting[startIndex] != startNode)
            {
                startIndex++;
            }

            bool hasNegativeCycle = false;

            for (int i = startIndex; i + 1 < visiting.Count; i++)
            {
                int fromNode = visiting[i];
                int toNode = visiting[i + 1];
                int weight = graph[fromNode][toNode];

                // Console.WriteLine("{0} - {1} : {2}", fromNode, toNode, weight);


                if(weight < 0)
                {
                    hasNegativeCycle = true;
                    break;
                }
            }

            return hasNegativeCycle;
        }

        private static Dictionary<int, Dictionary<int, int>> CreateGraph(int[,] edges)
        {
            var graph = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int fromVertex = edges[i, 0];
                int toVertex = edges[i, 1];
                int weight = edges[i, 2];

                if (!graph.ContainsKey(fromVertex))
                {
                    graph.Add(fromVertex, new Dictionary<int, int>());
                }

                if (!graph.ContainsKey(toVertex))
                {
                    graph.Add(toVertex, new Dictionary<int, int>());
                }


                graph[fromVertex].Add(toVertex, weight);
            }

            return graph;
        }

        private static bool DFS(Dictionary<int, Dictionary<int, int>> graph, Dictionary<int, bool> visited, IList<int> visiting, int start)
        {
            // Previously visited, but not through current recursive depth. In that case, this node is already validated
            if (visited.ContainsKey(start) && !visiting.Contains(start))
            {
                return false;
            }

            // if already encountered as part of current recursive depth, it indicates a cycle
            if (visiting.Contains(start))
            {
                // Add the cyclic node also at the end of the list to identify thecycle point 
                visiting.Add(start);
                return true;
            }

            // Add/update visited
            if (!visited.ContainsKey(start))
            {
                visited.Add(start, true);
            }

            // Add current vertex to visiting, as it denotes current path
            visiting.Add(start);

            Dictionary<int, int> neighbors = graph[start];

            foreach (int node in neighbors.Keys)
            {
                if (DFS(graph, visited, visiting, node) == true)
                {
                    return true;
                }
            }

            // Remove current vertex from visiting, returning from current path
            visiting.RemoveAt(visiting.Count -1);

            return false;
        }

    }
}
