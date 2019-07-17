using System;
using System.Threading;

namespace ParallelProcessing
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Enter the numbers of threads and jobs");
            string[] threadsAndJobs = Console.ReadLine().Split(' ');

            int threadCount = int.Parse(threadsAndJobs[0]);
            int jobCount = int.Parse(threadsAndJobs[1]);

            string[] jobTime = Console.ReadLine().Split(' ');
            int[] jobDuration = new int[jobCount];
            for (int l = 0; l < jobTime.Length; l++)
            {
                jobDuration[l] = int.Parse(jobTime[l]);
            }

            long[] threadTotalTime = new long[threadCount];

            MinHeap pq = new MinHeap();

            // Initialize thread total count and pq
            for (int i = 0; i < threadCount; i++)
            {
                threadTotalTime[i] = 0;
                pq.Add(new JobInfo(i, 0));
            }

            // Now pq contains 0 value job for each thread
            for (int j = 0; j < jobCount; j++)
            {
                // Dequeue pg and assign the new job to the thread id of the dequeued item
                var jobInfo = pq.Pop();

                int threadId = jobInfo.ThreadId;

                // update dequeued thread's total time
                Console.WriteLine("{0} {1}", threadId, threadTotalTime[threadId]);
                threadTotalTime[threadId] += jobDuration[j];


                // Put the new job time back into pq
                pq.Add(new JobInfo(threadId, threadTotalTime[threadId]));

            }
        }
    }
}
