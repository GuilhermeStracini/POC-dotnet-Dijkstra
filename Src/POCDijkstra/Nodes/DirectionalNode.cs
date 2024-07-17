// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="DirectionalNode.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace POCDijkstra.Nodes
{
    /// <summary>
    /// Class DirectionalNode.
    /// Implements the <see cref="INode" />
    /// </summary>
    /// <seealso cref="INode" />
    public class DirectionalNode : SimpleNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectionalNode"/> class.
        /// </summary>
        /// <param name="label">The label.</param>
        public DirectionalNode(string label)
            : base(label) { }

        /// <summary>
        /// Gets the neighbors.
        /// </summary>
        /// <value>The neighbors.</value>
        public new IEnumerable<NeighborhoodInfo> Neighbors =>
            from edge in Edges
            where edge.Node2 == this
            select new NeighborhoodInfo(edge.Node1, edge.Value);
    }
}
