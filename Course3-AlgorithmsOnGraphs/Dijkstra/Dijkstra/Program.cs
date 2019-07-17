using System;
using System.Collections.Generic;

namespace Dijkstra
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

            //Console.WriteLine("Vertices to find shortest path between");
            string[] verticesPath = Console.ReadLine().Split(' ');
            int startVertex = Convert.ToInt32(verticesPath[0]);
            int endVertex = Convert.ToInt32(verticesPath[1]);

            var graph = CreateGraph(edges);

            if(!graph.ContainsKey(startVertex) || !graph.ContainsKey(endVertex))
            {
                Console.WriteLine(-1);
                return;
            }

            Dictionary<int, int> dist = new Dictionary<int, int>();

            // Approach 1 (Dijkshtra's)
            FindShortedPathUsingHeap(graph, dist, numberOfEdges, startVertex);

            // Approach 2 (Bellman Ford)
            // FindShortestPathWithoutHeap(graph, dist, startVertex, 0);

            Console.WriteLine(!dist.ContainsKey(endVertex) ? -1 : dist[endVertex]);

        }

        // Bellman Ford algorithm
        private static void FindShortestPathWithoutHeap(Dictionary<int, Dictionary<int, int>> graph, Dictionary<int, int> dist, int start, int cost)
        {
            if(dist.ContainsKey(start) && dist[start] <= cost)
            {
                return;
            }

            if(!dist.ContainsKey(start))
            {
                dist.Add(start, cost);
            }
            else
            {
                dist[start] = cost;    
            }


            var neighbors = graph[start];

            foreach(var key in neighbors.Keys)
            {
                var neighbor = key;
                var pathCost = neighbors[key];

                FindShortestPathWithoutHeap(graph, dist, key, cost + pathCost);
            }
        }

        // Dijkshtra's algorithm
        private static void FindShortedPathUsingHeap(Dictionary<int, Dictionary<int, int>> graph, Dictionary<int, int> dist, int numberOfEdges, int start)
        {
            var minComparer = Comparer<int[]>.Create((a, b) =>
            {
               return a[1] - b[1];
            });

            Heap<int[]> minHeap = new Heap<int[]>(numberOfEdges+1, minComparer);

            dist.Add(start, 0);

            minHeap.Push(new int[] { start, 0 });

            while(minHeap.Size() > 0 )
            {
                int[] cur = minHeap.Pop();
                int node = cur[0];
                int distance = cur[1];


                if(dist.ContainsKey(node) && dist[node] < distance)
                {
                    continue;
                }

                var neighbors = graph[node];

                foreach(int key in neighbors.Keys)
                {
                    int nextNode = key;
                    int nodeDistance = neighbors[key];

                    int newDistance = distance + nodeDistance;

                    if(dist.ContainsKey(nextNode) && dist[nextNode] <= newDistance)
                    {
                        continue;
                    }

                    if(!dist.ContainsKey(nextNode))
                    {
                        dist.Add(nextNode, newDistance);
                    }
                    else
                    {
                        dist[nextNode] = newDistance;
                    }

                    minHeap.Push(new int[] { nextNode, newDistance });
                }
            }
        }

        private static Dictionary<int, Dictionary<int,int>> CreateGraph(int[,] edges)
        {
            var graph = new Dictionary<int, Dictionary<int,int>>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int fromVertex = edges[i, 0];
                int toVertex = edges[i, 1];
                int weight = edges[i, 2];

                if(!graph.ContainsKey(fromVertex))
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
    }


    /*---------------------HELPER ITEMS------------------------*/


    /*
           var minComparer = Comparer<int[]>.Create((a, b) =>
           {
               return a[0] - b[0];
           });

           Heap<int[]> minHeap = new Heap<int[]>(numVertices, minComparer);

           for (int i = 1; i <= numVertices; i++)
           {
               int[] data = new int[] { i, i == src ? 0 : int.MaxValue };
               minHeap.Push(data);
           }
           */

    public class Heap<T>
    {
        T[] arr;

        int size;
        int capacity;
        IComparer<T> comparer;

        public Heap(int capacity, IComparer<T> comparer)
        {
            this.capacity = capacity;
            this.size = 0;
            this.arr = new T[capacity];
            this.comparer = comparer;
        }

        public int Size()
        {
            return this.size;
        }

        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        public T GetMin()
        {
            if (this.size <= 0)
                return default(T);

            return arr[0];
        }

        public T Peek()
        {
            return arr[0];
        }

        public T Pop()
        {
            if (this.size == 1)
            {
                this.size--;
                return arr[0];
            }

            T root = arr[0];
            arr[0] = arr[this.size - 1];
            this.size--;
            this.HeapifyDown(0);

            return root;
        }

        public void Push(T key)
        {
            if (this.size == this.capacity)
            {
                throw new InvalidOperationException(string.Format("Heap is full. HeapSize: {0}", this.size));
            }

            arr[this.size] = key;
            this.size++;
            HeapifyUp(this.size - 1);

        }

        public void DeleteKey(int index)
        {
            DecreaseKey(index, default(T));
            arr[0] = arr[this.size - 1];
            this.size--;
            this.HeapifyDown(0);
        }

        public void DecreaseKey(int index, T val)
        {
            arr[index] = val;
            HeapifyUp(index);
        }

        private int Left(int index)
        {
            return (2 * index + 1);
        }

        private int Right(int index)
        {
            return (2 * index + 2);
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int i1, int i2)
        {
            T temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
        }

        private void HeapifyUp(int index)
        {
            int i = index;
            while (i > 0 && this.comparer.Compare(arr[Parent(i)], arr[i]) > 0)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;

            int left = Left(index);
            int right = Right(index);

            if (left < this.size && this.comparer.Compare(arr[left], arr[smallest]) < 0)
                smallest = left;

            if (right < this.size && this.comparer.Compare(arr[right], arr[smallest]) < 0)
                smallest = right;

            if (smallest != index)
            {
                Swap(smallest, index);
                HeapifyDown(smallest);
            }
        }
    }

}
