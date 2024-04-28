using System;
using System.Collections.Generic;
using DataStructures.Graphs;
using Algorithms.Graphs;
using Xunit;
using System.Diagnostics;
using System.Linq;

namespace UnitTest.AlgorithmsTests
{
    public static class GraphsBreadthFirstPathsTest
    {
        private static string PrintPath(IEnumerable<string> path)
        {
            string output = string.Empty;

            foreach (var node in path)
                output = String.Format("{0}({1}) -> ", output, node);

            output += "/TERMINATE/";

            return output;
        }

        [Fact]
        public static void DoTest()
        {
            //<image url="$(ProjectDir)\DocumentImages\Graph02.png"/>
            IGraph<string> graph = new UndirectedSparseGraph<string>();

            // Add vertices
            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v", "w", "m" };
            graph.AddVertices(verticesSet1);

            // Add edges
            graph.AddEdge("a", "s");
            graph.AddEdge("a", "z");
            graph.AddEdge("s", "x");
            graph.AddEdge("x", "d");
            graph.AddEdge("x", "c");
            graph.AddEdge("x", "w");
            graph.AddEdge("x", "m");
            graph.AddEdge("d", "f");
            graph.AddEdge("d", "c");
            graph.AddEdge("c", "f");
            graph.AddEdge("c", "v");
            graph.AddEdge("v", "f");
            graph.AddEdge("w", "m");

            var sourceNode = "f";
            var bfsPaths = new BreadthFirstShortestPaths<string>(graph, sourceNode);

            // TODO:
            // - Assert distances
            // - Assert ShortestPathTo a node

            var distance = bfsPaths.DistanceTo("a");

            Trace.WriteLine("Distance from '" + sourceNode + "' to 'a' is: " + bfsPaths.DistanceTo("a"));
            Trace.WriteLine("Path from '" + sourceNode + "' to 'a' is : " + PrintPath(bfsPaths.ShortestPathTo("a")));

            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Distance from '" + sourceNode + "' to 'w' is: " + bfsPaths.DistanceTo("w"));
            Trace.WriteLine("Path from '" + sourceNode + "' to 'w' is : " + PrintPath(bfsPaths.ShortestPathTo("w")));

            //删除节点后的处理
            graph.RemoveVertex("x");
            //计算各分部组件
            var components = ConnectedComponents.Compute(graph);

            //分别打印各组件元素
            foreach (var item in components)
            {
                if (item == null) continue;
                var node = item.First();

                BreadthFirstSearcher.PrintAll(graph, node);
                Trace.Write("\n");
            }
        }
    }
}