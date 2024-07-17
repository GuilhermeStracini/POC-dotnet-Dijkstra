// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 21/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="INode.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using POCDijkstra.Edges;

namespace POCDijkstra.Nodes
{
    /// <summary>
    /// Interface INode
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>The label.</value>
        string Label { get; }

        /// <summary>
        /// Gets the neighbors.
        /// </summary>
        /// <value>The neighbors.</value>
        IEnumerable<NeighborhoodInfo> Neighbors { get; }

        /// <summary>
        /// Assigns the specified edge.
        /// </summary>
        /// <param name="edge">The edge.</param>
        void Assign(IEdge edge);
    }
}
