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
            firstTopper.Edges.Add(secondTopper);
            secondTopper.Edges.Add(firstTopper);
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
                foreach (var neighbour in currentTopper.Edges)
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
                foreach (var neighbour in currentTopper.Edges)
                {
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return visited.Select(x => x.Name).ToArray();
        }
    }

    public class Topper
    {
        public string Name { get; }
        
        public List<Topper> Edges { get; set; }

        public Topper(string name)
        {
            Name = name;
            Edges = new List<Topper>();
        }
    }
}