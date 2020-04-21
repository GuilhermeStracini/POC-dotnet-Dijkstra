// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="IShortestPathFinder.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using POCDijkstra.Nodes;

namespace POCDijkstra.Dijkstra
{
    /// <summary>
    /// Interface IShortestPathFinder
    /// </summary>
    interface IShortestPathFinder
    {
        /// <summary>
        /// Finds the shortest path.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>Node[].</returns>
        INode[] FindShortestPath(INode from, INode to);
    }
}
