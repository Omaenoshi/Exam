using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    public class Graph
    {
        public List<Topper> Toppers { get; }

        public Graph()
        {
            Toppers = new List<Topper>();
        }

        public void AddTopper(string name)
        {
            Toppers.Add(new Topper(name));
        }

        public void AddEdges(string firstName, string secondName)
        {
            Topper firstTopper = Toppers.Where(x => x.Name == firstName).ToArray().FirstOrDefault();
            Topper secondTopper = Toppers.Where(x => x.Name == secondName).ToArray().FirstOrDefault();
            firstTopper.Neighbours.Add(secondTopper);
            secondTopper.Neighbours.Add(firstTopper);
        }

        public string[] DFS(Topper startTopper)
        {
            var stack = new Stack<Topper>();
            var visited = new List<Topper>();
            stack.Push(startTopper);

            while (stack.Count > 0)
            {
                var currentTopper = stack.Pop();
                if (visited.Contains(currentTopper))
                    continue;

                visited.Add(currentTopper);
                foreach (var neighbour in currentTopper.Neighbours)
                {
                    if (!visited.Contains(neighbour))
                        stack.Push(neighbour);
                }
            }

            return visited.Select(x => x.Name).ToArray();
        }

        public string[] BFS(Topper startTopper)
        {
            var queue = new Queue<Topper>();
            var visited = new List<Topper>();
            queue.Enqueue(startTopper);

            while (queue.Count > 0)
            {
                var currentTopper = queue.Dequeue();
                if (visited.Contains(currentTopper))
                    continue;

                visited.Add(currentTopper);
                foreach (var neighbour in currentTopper.Neighbours)
                {
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return visited.Select(x => x.Name).ToArray();
        }

        private static List<TopperInfo> allChecked;
        private static Dictionary<TopperInfo, int> minCostThere;

        public static int DjikstraAlgorithm(TopperInfo start, TopperInfo end)
        {
            minCostThere = new Dictionary<TopperInfo, int>();
            allChecked = new List<TopperInfo>();
            minCostThere.Add(start, 0);
            ReSearch(start);
            var minCost = minCostThere[end];

            return minCost;
        }

        private static void ReSearch(TopperInfo current)
        {
            foreach (var item in current.fromMe)
            {
                if (!allChecked.Contains(item))
                {
                    if (!minCostThere.ContainsKey(item))
                        minCostThere.Add(item, minCostThere[current] + current.GetWeight(item));
                    else if (minCostThere[current] + current.GetWeight(item) < minCostThere[item])
                        minCostThere[item] = minCostThere[current] + current.GetWeight(item);
                }

            }
            
            allChecked.Add(current);
            foreach (var item in current.fromMe.OrderBy(x => current.GetWeight(x)))
            {
                if (!allChecked.Contains(item))
                    ReSearch(item);
            }
        }
        

        public class TopperInfo
        {
            public List<TopperInfo> fromMe;

            public string Name;

            public Dictionary<TopperInfo, int> edgeWeights;

            public int GetWeight(TopperInfo value) => edgeWeights[value];

            public TopperInfo(string name)
            {
                fromMe = new List<TopperInfo>();
                edgeWeights = new Dictionary<TopperInfo, int>();
                Name = name;
            }

            public void InsertEdge(TopperInfo value, int weight)
            {
                fromMe.Add(value);
                edgeWeights.Add(value, weight);
                value.fromMe.Add(this);
                value.edgeWeights.Add(this, weight);
            }
        }

        public class GraphInfo
        {
            public Dictionary<string, TopperInfo> Toppers;

            public GraphInfo()
            {
                Toppers = new Dictionary<string, TopperInfo>();
            }

            public void AddTopper(TopperInfo value)
            {
                Toppers.Add(value.Name, value);
            }

            public TopperInfo[] GetArray()
            {
                var res = new List<TopperInfo>();
                foreach (var item in Toppers)
                {
                    res.Add(item.Value);
                }

                return res.ToArray();
            }
        }

        public class Topper
        {
            public string Name { get; }

            public List<Topper> Neighbours { get; set; }

            public Topper(string name)
            {
                Name = name;
                Neighbours = new List<Topper>();
            }
        }
    }
}