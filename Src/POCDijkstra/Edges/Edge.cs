// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 21/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="Edge.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using POCDijkstra.Nodes;
using System;

namespace POCDijkstra.Edges
{
    /// <summary>
    /// Class Edge.
    /// Implements the <see cref="IEdge" />
    /// </summary>
    /// <seealso cref="IEdge" />
    internal class Edge : IEdge
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; }
        /// <summary>
        /// Gets the node1.
        /// </summary>
        /// <value>The node1.</value>
        public INode Node1 { get; }
        /// <summary>
        /// Gets the node2.
        /// </summary>
        /// <value>The node2.</value>
        public INode Node2 { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edge" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="node1">The node1.</param>
        /// <param name="node2">The node2.</param>
        /// <exception cref="ArgumentException">Edge value needs to be positive.</exception>
        private Edge(int value, INode node1, INode node2)
        {
            if (value <= 0)
                throw new ArgumentException("Edge value needs to be positive.");
            Value = value;
            Node1 = node1;
            node1.Assign(this);
            Node2 = node2;
            node2.Assign(this);
        }

        /// <summary>
        /// Creates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="node1">The node1.</param>
        /// <param name="node2">The node2.</param>
        /// <returns>Edge.</returns>
        public static Edge Create(int value, INode node1, INode node2)
        {
            return new Edge(value, node1, node2);
        }
    }
}
