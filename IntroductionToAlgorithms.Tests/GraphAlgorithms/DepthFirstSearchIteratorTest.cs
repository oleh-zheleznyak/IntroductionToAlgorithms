﻿using IntroductionToAlgorithms.GraphAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Tests.GraphAlgorithms
{
    [TestClass]
    public class DepthFirstSearchIteratorTest
    {
        [TestMethod]
        public void DepthFirstSearchIteratorTest_ShouldYieldElements_InCorrectOrder()
        {
            var builder = new DirectedGraphBuilder<int>();

            builder.AddEdge(0, 1);
            builder.AddEdge(0, 2);
            builder.AddEdge(1, 3);
            builder.AddEdge(2, 4);

            var graph = builder.AsDirectedGraph();

            var sequence = new DepthFirstSearchIterator<int>(graph, 0);

            var expected = new DfsVertice<int>[] { Create(4, 2, 3, 4), Create(2, 0, 2, 5), Create(3, 1, 7, 8), Create(1, 0, 6, 9), Create(0, 0, 1, 10) };
            var actual = sequence.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        private DfsVertice<int> Create(int vertice, int predescessor, int discovered, int traversed)
        {
            var result = new DfsVertice<int>(vertice, predescessor);
            result.DiscoveredTimestamp = discovered;
            result.TraversedTimestamp = traversed;

            return result;
        }
    }
}
