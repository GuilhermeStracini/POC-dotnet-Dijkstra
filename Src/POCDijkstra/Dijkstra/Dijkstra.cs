// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="Dijkstra.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
using POCDijkstra.Nodes;
using System.Linq;

namespace POCDijkstra.Dijkstra
{
    /// <summary>
    /// Class Dijkstra.
    /// Implements the <see cref="IShortestPathFinder" />
    /// </summary>
    /// <seealso cref="IShortestPathFinder" />
    public class Dijkstra : IShortestPathFinder
    {
        #region Implementation of IShortestPathFinder

        /// <summary>
        /// Finds the shortest path.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>Node[].</returns>
        public INode[] FindShortestPath(INode @from, INode to)
        {
            var control = new VisitingData();

            control.UpdateWeight(@from, new Weight(null, 0));
            control.ScheduleVisitTo(@from);

            while (control.HasScheduledVisits)
            {
                var visitingNode = control.GetNodeToVisit();
                var visitingNodeWeight = control.QueryWeight(visitingNode);
                control.RegisterVisitTo(visitingNode);

                foreach (var neighborhoodInfo in visitingNode.Neighbors)
                {
                    if (!control.WasVisited(neighborhoodInfo.Node))
                        control.ScheduleVisitTo(neighborhoodInfo.Node);

                    var neighborWeight = control.QueryWeight(neighborhoodInfo.Node);

                    var probableWeight = (visitingNodeWeight.Value + neighborhoodInfo.WeightToNode);
                    if (neighborWeight.Value > probableWeight)
                        control.UpdateWeight(neighborhoodInfo.Node, new Weight(visitingNode, probableWeight));
                }
            }

            return control.HasComputedPathToOrigin(to)
                ? control.ComputedPathToOrigin(to).Reverse().ToArray()
                : null;
        }

        #endregion
    }
}
