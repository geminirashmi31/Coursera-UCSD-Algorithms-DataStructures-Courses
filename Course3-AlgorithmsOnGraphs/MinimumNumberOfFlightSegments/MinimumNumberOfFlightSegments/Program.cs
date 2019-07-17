using System;
using System.Collections.Generic;

namespace MinimumNumberOfFlightSegments
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Enter number of vertices and edges");
            string[] verticesAndEdges = Console.ReadLine().Split(' ');
            int numberOfVertices = Convert.ToInt32(verticesAndEdges[0]);
            int numberOfEdges = Convert.ToInt32(verticesAndEdges[1]);

            int[,] edges = new int[numberOfEdges, 2];

            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] verticesStringArray = Console.ReadLine().Split(' ');
                int vertex1 = Convert.ToInt32(verticesStringArray[0]);
                int vertex2 = Convert.ToInt32(verticesStringArray[1]);

                edges[i, 0] = vertex1;
                edges[i, 1] = vertex2;
            }

            //Console.WriteLine("Vertices to find shortest path between");
            string[] verticesPath = Console.ReadLine().Split(' ');
            int startVertex = Convert.ToInt32(verticesPath[0]);
            int endVertex = Convert.ToInt32(verticesPath[1]);

            var graph = CreateGraph(numberOfVertices, edges);

            if(startVertex == endVertex && graph.ContainsKey(startVertex))
            {
                Console.WriteLine(0);
                return;
            }

            int count = BFS(graph, startVertex, endVertex);

            Console.WriteLine(count -1);
        }

        private static int BFS(Dictionary<int, IList<int>> graph, int start, int end)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            Dictionary<int, int> visited = new Dictionary<int, int>();
            visited.Add(start, -1);

            while(queue.Count > 0)
            {
                int from = queue.Dequeue();

                IList<int> neighbors = graph[from];

                for (int i = 0; i < neighbors.Count; i++)
                {
                    int to = neighbors[i];

                    if(!visited.ContainsKey(to))
                    {
                        queue.Enqueue(to);
                        visited.Add(to, from);
                    }

                    if(to == end)
                    {
                        break;
                    }
                }
            }


            int edgeCount = 0;

            int node = end;

            while(visited.ContainsKey(node))
            {
                edgeCount++;
                node = visited[node];
            }

            return edgeCount;

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
    }
}
