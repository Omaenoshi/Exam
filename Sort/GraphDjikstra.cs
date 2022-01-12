using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    public class GraphDjikstra
    {
        public class Graph
        {
            public Dictionary<Node, int> MinCost;

            public List<Node> Visited;

            public Dictionary<string, Node> Toppers;

            public Graph()
            {
                MinCost = new();
                Visited = new();
                Toppers = new();
            }

            public void AddNode(string name)
            {
                Toppers.Add(name, new Node(name));
            }

            public int DijkstraAlgorithm(Node start, Node end)
            {
                MinCost.Add(start, 0);
                Do(start);
                return MinCost[end];
            }

            public void Do(Node current)
            {
                foreach (var node in current.fromMe)
                {
                    if (!Visited.Contains(node))
                    {
                        if (!MinCost.ContainsKey(node))
                            MinCost.Add(node, MinCost[current] + current.GetWeight(node));
                        else if (MinCost[node] > MinCost[current] + current.GetWeight(node))
                            MinCost[node] = MinCost[current] + current.GetWeight(node);
                    }
                }
            
                Visited.Add(current);

                foreach (var node in current.fromMe.OrderBy(x => current.GetWeight(x)))
                {
                    if (!Visited.Contains(node))
                        Do(node);
                }
            }
        }

        public class Node
        {
            public string Name;

            public List<Node> fromMe;

            public Dictionary<Node, int> edges;

            public Node(string name)
            {
                Name = name;
                fromMe = new List<Node>();
                edges = new Dictionary<Node, int>();
            }

            public void AddEdge(Node value, int weight)
            {
                fromMe.Add(value);
                edges.Add(value, weight);
                value.fromMe.Add(this);
                value.edges.Add(this, weight);
            }

            public int GetWeight(Node value) => edges[value];
        }
    }
}