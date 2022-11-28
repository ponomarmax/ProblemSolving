using System.Text;

public class Solution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var sortedStartTime = SortMerge(startTime, 0, startTime.Length - 1);
        var lines = new List<JobLink>();
        for (int i = 0; i < sortedStartTime.Length; i++)
        {
            var realIndex = sortedStartTime[i].Key;
            var job = new Job(profit[realIndex], startTime[realIndex], endTime[realIndex]);
            List<JobLink> newLines = new();
            foreach (var line in lines)
            {
                var lastJob = line.LastJob;
                if (job.start >= lastJob.end)
                {
                    newLines.Add(new JobLink(line));
                    line.AddJob(job);
                }
            }
            if (!newLines.Any())
            {
                lines.Add(new JobLink(job));
            }
            else
            {
                lines.AddRange(newLines);
            }
            //Display(lines);
            //Console.WriteLine("========================================");
        }
        
        return lines.Select(x => x.Sum()).Max();
    }

    private KeyValuePair<int, int>[] SortMerge(int[] origin, int l, int r)
    {
        if (l >= r)
        {
            return new KeyValuePair<int, int>[] { new KeyValuePair<int, int>(r, origin[r]) };
        }
        int m = (l + r) / 2;
        var left = SortMerge(origin, l, m);
        var right = SortMerge(origin, m + 1, r);
        var result = new KeyValuePair<int, int>[left.Length + right.Length];
        int i, j, res;
        i = j = res = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i].Value < right[j].Value)
            {
                result[res] = left[i];
                res++;
                i++;
            }
            else
            {
                result[res] = right[j];
                res++;
                j++;
            }
        }
        while (i < left.Length)
        {
            result[res] = left[i];
            res++;
            i++;
        }
        while (j < right.Length)
        {
            result[res] = right[j];
            res++;
            j++;
        }
        return result;
    }
    private void Display(List<JobLink> link)
    {
        foreach (var item in link)
        {
            Console.WriteLine(item.ToString());
        }
    }
    class Job
    {
        public Job(int profit, int start, int end)
        {
            this.profit = profit;
            this.start = start;
            this.end = end;
        }

        public int profit { get; set; }
        public int start { get; set; }
        public int end { get; set; }

        public override string ToString()
        {
            return $"({start} {end}) -> {profit}";
        }
    }

    class JobLink
    {
        private List<Job> Jobs { get; set; }
        private int takeFromTail = 1;
        public JobLink Tail { get; set; }

        public JobLink(JobLink tail)
        {

            if (tail.Jobs == null)
            {
                Tail = tail.Tail;
                takeFromTail = tail.takeFromTail;
            }
            else
            {
                Tail = tail;
                takeFromTail = tail.Jobs.Count;
            }

        }

        public JobLink(Job job)
        {
            Jobs = new List<Job>();
            Jobs.Add(job);
        }

        public Job LastJob
        {
            get
            {
                if (Jobs == null)
                {
                    return Tail.Jobs[takeFromTail - 1];
                }
                return Jobs.Last();
            }
        }

        public void AddJob(Job job)
        {
            if (Jobs == null)
            {
                Jobs = new List<Job>();
            }
            Jobs.Add(job);
        }

        public int Sum()
        {

            var sum = Jobs?.Select(x => x.profit).Sum() ?? 0;
            var take = takeFromTail;
            if (Tail != null)
            {
                var current = Tail;
                while (true)
                {
                    sum += current.Jobs.Take(take).Select(x => x.profit).Sum();
                    if (current.Tail == null)
                    {
                        break;
                    }
                    take = current.takeFromTail;
                    current = current.Tail;
                    
                }
            }
            return sum;
        }

        public override string ToString()
        {
            return $"{Sum()} {GetTail(this, Jobs?.Count??0)}";
        }

        private static string GetTail(JobLink current, int take)
        {
            var line = new StringBuilder();
            if (current.Tail != null)
            {
                line.Append(GetTail(current.Tail, current.takeFromTail));
            }
            if (current.Jobs != null)
                line.Append(string.Concat(current.Jobs?.Take(take).Select(x => x.ToString() + " ")));
            return line.ToString();
        }
    }


}