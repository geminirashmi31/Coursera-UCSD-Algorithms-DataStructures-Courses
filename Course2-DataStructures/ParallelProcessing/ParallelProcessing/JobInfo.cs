using System;
namespace ParallelProcessing
{
    public class JobInfo
    {
        public JobInfo(int threadId, long time)
        {
            this.ThreadId = threadId;
            this.PriorityTime = time;
        }

        public int ThreadId { get; set; }

        public long PriorityTime { get; set; }
    }
}
