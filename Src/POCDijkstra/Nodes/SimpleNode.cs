// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 20/04/2020
// ***********************************************************************
// <copyright file="SimpleNode.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using POCDijkstra.Edges;

namespace POCDijkstra.Nodes
{
    /// <summary>
    /// Class SimpleNode.
    /// Implements the <see cref="INode" />
    /// </summary>
    /// <seealso cref="INode" />
    public class SimpleNode : INode
    {
        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleNode"/> class.
        /// </summary>
        /// <param name="label">The label.</param>
        public SimpleNode(string label)
        {
            Label = label;
        }

        /// <summary>
        /// The edges
        /// </summary>
        private readonly List<IEdge> _edges = new List<IEdge>();

        /// <summary>
        /// Gets the edges.
        /// </summary>
        /// <value>The edges.</value>
        public IEnumerable<IEdge> Edges => _edges;

        /// <summary>
        /// Gets the neighbors.
        /// </summary>
        /// <value>The neighbors.</value>
        public IEnumerable<NeighborhoodInfo> Neighbors =>
            from edge in Edges
            select new NeighborhoodInfo(edge.Node1 == this ? edge.Node2 : edge.Node1, edge.Value);

        /// <summary>
        /// Assigns the specified edge.
        /// </summary>
        /// <param name="edge">The edge.</param>
        public void Assign(IEdge edge)
        {
            _edges.Add(edge);
        }

        /// <summary>
        /// Connects to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <param name="connectionValue">The connection value.</param>
        public void ConnectTo(SimpleNode other, int connectionValue)
        {
            Edge.Create(connectionValue, this, other);
        }
    }
}
