using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            // var arr = new[] { "Бегемот", "Арбуз", "Бездарь", "Абрикос"};
            // var result = Sort.ABSSort(arr);
            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine();

            // Graph g = new Graph();
            // var minCost = 0;
            // var graph = new List<Graph.WeightNode>();
            // graph.Add(new Graph.WeightNode());
            // graph.Add(new Graph.WeightNode());
            // graph.Add(new Graph.WeightNode());
            // graph[0].fromMe = new List<Graph.WeightNode>() {graph[1], graph[2]};
            // graph[1].fromMe = new List<Graph.WeightNode>() {graph[0], graph[2]};
            // graph[2].fromMe = new List<Graph.WeightNode>() {graph[0], graph[1]};
            // graph[0].SetWeight(graph[1], 4);
            // graph[0].SetWeight(graph[2], 10);
            // graph[1].SetWeight(graph[0], 4);
            // graph[1].SetWeight(graph[2], 3);
            // graph[2].SetWeight(graph[0], 10);
            // graph[2].SetWeight(graph[1], 3);
            // var res = Graph.DjikstraAlgorithm(graph[0], graph[2], graph.ToArray());


            var graph2 = new Graph.GraphInfo();
            graph2.AddTopper(new Graph.TopperInfo("a"));
            graph2.AddTopper(new Graph.TopperInfo("b"));
            graph2.AddTopper(new Graph.TopperInfo("c"));
            graph2.Toppers["a"].InsertEdge(graph2.Toppers["b"], 4);
            graph2.Toppers["b"].InsertEdge(graph2.Toppers["c"], 3);
            graph2.Toppers["a"].InsertEdge(graph2.Toppers["c"], 10);
            var res2 = Graph.DjikstraAlgorithm(graph2.Toppers["a"], graph2.Toppers["c"]);
            //WeightNode[] wg = new[] {new WeightNode()};
            //Graph.AlgorithmDeikstra(new WeightNode(), new WeightNode(), out minCost, out wg);
        }
    }
}