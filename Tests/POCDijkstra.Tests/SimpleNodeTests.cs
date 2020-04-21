// ***********************************************************************
// Assembly         : POCDijkstra.Tests
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="SimpleNodeTests.cs" company="POCDijkstra.Tests">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using POCDijkstra.Nodes;
using System;
using System.Linq;
using Xunit;

namespace POCDijkstra.Tests
{
    /// <summary>
    /// Class SimpleNodeTests.
    /// </summary>
    public class SimpleNodeTests
    {
        /// <summary>
        /// Defines the test method ValidateSampleOneFromAToF.
        /// </summary>
        [Fact]
        public void ValidateSampleOneFromAToF()
        {
            var a = new SimpleNode("A");
            var b = new SimpleNode("B");
            var c = new SimpleNode("C");
            var d = new SimpleNode("D");
            var e = new SimpleNode("E");
            var f = new SimpleNode("F");

            a.ConnectTo(b, 4);
            a.ConnectTo(c, 2);
            b.ConnectTo(c, 1);
            b.ConnectTo(d, 5);
            c.ConnectTo(d, 8);
            c.ConnectTo(e, 10);
            d.ConnectTo(f, 6);
            d.ConnectTo(e, 2);
            e.ConnectTo(f, 2);

            var dijkstra = new Dijkstra.Dijkstra();
            var result = dijkstra.FindShortestPath(a, f);

            Assert.NotNull(result);
            Assert.Equal(6, result.Length);
            Assert.Equal("A", result[0].Label);
            Assert.Equal("C", result[1].Label);
            Assert.Equal("B", result[2].Label);
            Assert.Equal("D", result[3].Label);
            Assert.Equal("E", result[4].Label);
            Assert.Equal("F", result[5].Label);

            var weight = 0;

            for (var i = 0; i < result.Length; i++)
            {
                var currentWeight = 0;
                if (i < result.Length - 1)
                    currentWeight = result[i].Neighbors
                                             .Single(n => n.Node.Label.Equals(result[i + 1].Label))
                                             .WeightToNode;
                weight += currentWeight;
            }

            Assert.Equal(12, weight);
        }

        /// <summary>
        /// Defines the test method ValidateInvalidDistance.
        /// </summary>
        [Fact]
        public void ValidateInvalidDistance()
        {
            var node1 = new SimpleNode("Node 1");
            var node2 = new SimpleNode("Node 2");

            var result = Assert.Throws<ArgumentException>(() => node1.ConnectTo(node2, -1));
            Assert.Equal("Edge value needs to be positive.", result.Message);
        }
    }
}
