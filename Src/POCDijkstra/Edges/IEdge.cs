// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 21/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="IEdge.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using POCDijkstra.Nodes;

namespace POCDijkstra.Edges
{
    /// <summary>
    /// Interface IEdge
    /// </summary>
    public interface IEdge
    {
        /// <summary>
        /// Gets the node1.
        /// </summary>
        /// <value>The node1.</value>
        INode Node1 { get; }
        /// <summary>
        /// Gets the node2.
        /// </summary>
        /// <value>The node2.</value>
        INode Node2 { get; }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        int Value { get; }
    }
}
