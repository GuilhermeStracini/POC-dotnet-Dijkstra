// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 21/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="NeighborhoodInfo.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace POCDijkstra.Nodes
{
    /// <summary>
    /// Struct NeighborhoodInfo
    /// </summary>
    public readonly struct NeighborhoodInfo
    {
        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>The node.</value>
        public INode Node { get; }

        /// <summary>
        /// Gets the weight to node.
        /// </summary>
        /// <value>The weight to node.</value>
        public int WeightToNode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NeighborhoodInfo" /> struct.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="weightToNode">The weight to node.</param>
        public NeighborhoodInfo(INode node, int weightToNode)
        {
            Node = node;
            WeightToNode = weightToNode;
        }
    }
}
