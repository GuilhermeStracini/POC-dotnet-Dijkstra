// ***********************************************************************
// Assembly         : POCDijkstra.Tests
// Author           : Guilherme Branco Stracini
// Created          : 21/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="DirectionalNodeTests.cs" company="POCDijkstra.Tests">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using POCDijkstra.Nodes;
using Xunit;

namespace POCDijkstra.Tests
{
    /// <summary>
    /// Class DirectionalNodeTests.
    /// </summary>
    public class DirectionalNodeTests
    {
        /// <summary>
        /// Defines the test method ValidateSampleTwoFrom9To6.
        /// </summary>
        [Fact]
        public void ValidateSampleTwoFrom9To6()
        {
            var one = new DirectionalNode("1");
            var two = new DirectionalNode("2");
            var three = new DirectionalNode("3");
            var four = new DirectionalNode("4");
            var five = new DirectionalNode("5");
            var six = new DirectionalNode("6");
            var seven = new DirectionalNode("7");
            var height = new DirectionalNode("8");
            var nine = new DirectionalNode("9");
            var ten = new DirectionalNode("10");

            one.ConnectTo(two, 10);
            one.ConnectTo(four, 20);
            one.ConnectTo(five, 20);
            one.ConnectTo(six, 5);
            one.ConnectTo(seven, 15);

            two.ConnectTo(four, 10);
            two.ConnectTo(three, 5);

            three.ConnectTo(four, 5);
            three.ConnectTo(two, 15);

            four.ConnectTo(five, 10);

            five.ConnectTo(six, 5);

            seven.ConnectTo(six, 10);

            height.ConnectTo(one, 5);
            height.ConnectTo(two, 20);
            height.ConnectTo(seven, 5);

            nine.ConnectTo(two, 15);
            nine.ConnectTo(height, 20);
            nine.ConnectTo(ten, 10);

            ten.ConnectTo(two, 5);
            ten.ConnectTo(three, 15);

            var dijkstra = new Dijkstra.Dijkstra();
            var result = dijkstra.FindShortestPath(nine, six);

            Assert.NotNull(result);
            Assert.Equal(4, result.Length);
        }

        /// <summary>
        /// Defines the test method ValidateInvalidDistance.
        /// </summary>
        [Fact]
        public void ValidateInvalidDistance()
        {
            var node1 = new DirectionalNode("Node 1");
            var node2 = new DirectionalNode("Node 2");

            var result = Assert.Throws<ArgumentException>(() => node1.ConnectTo(node2, -1));
            Assert.Equal("Edge value needs to be positive.", result.Message);
        }
    }
}
