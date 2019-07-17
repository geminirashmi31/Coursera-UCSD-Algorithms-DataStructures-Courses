using System;
using System.Collections.Generic;
namespace ParallelProcessing
{
    public class JobPriorityQueue
    {
        List<JobInfo> jobOrder = new List<JobInfo>();

        public int Count
        {
            get
            {
                return this.jobOrder.Count;
            }
        }

        public void Enqueue(int threadId, long time)
        {
            if (this.Count == 0)
            {
                this.jobOrder.Add(new JobInfo(threadId, time));
                return;
            }

            int pos = 0;

            for (int i = 0; i < this.jobOrder.Count; i++)
            {
                if (time > this.jobOrder[i].PriorityTime)
                {
                    pos++;
                }
                else if (time == this.jobOrder[i].PriorityTime && threadId > this.jobOrder[i].ThreadId)
                {
                    pos++;
                }
                else
                {
                    break;
                }

            }

            this.jobOrder.Insert(pos, new JobInfo(threadId, time));
        }

        public JobInfo Dequeue()
        {
            if (this.Count == 0)
            {
                return null;
            }

            JobInfo topJob = this.jobOrder[0];
            this.jobOrder.RemoveAt(0);

            return topJob;
        }
    }
}
