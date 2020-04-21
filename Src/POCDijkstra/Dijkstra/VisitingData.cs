// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="Dijkstra.VisitingData.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using POCDijkstra.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace POCDijkstra.Dijkstra
{
    /// <summary>
    /// Class VisitingData.
    /// </summary>
    internal class VisitingData
    {
        /// <summary>
        /// The visited
        /// </summary>
        private readonly List<INode> _visited = new List<INode>();

        /// <summary>
        /// The weights
        /// </summary>
        readonly Dictionary<INode, Weight> _weights = new Dictionary<INode, Weight>();

        /// <summary>
        /// The scheduled
        /// </summary>
        readonly List<INode> _scheduled = new List<INode>();

        /// <summary>
        /// Registers the visit to.
        /// </summary>
        /// <param name="node">The node.</param>
        public void RegisterVisitTo(INode node)
        {
            if (!_visited.Contains(node))
                _visited.Add(node);
        }

        /// <summary>
        /// Wases the visited.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool WasVisited(INode node)
        {
            return _visited.Contains(node);
        }

        /// <summary>
        /// Updates the weight.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="newWeight">The new weight.</param>
        public void UpdateWeight(INode node, Weight newWeight)
        {
            if (!_weights.ContainsKey(node))
                _weights.Add(node, newWeight);
            else
                _weights[node] = newWeight;
        }

        /// <summary>
        /// Queries the weight.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>Weight.</returns>
        public Weight QueryWeight(INode node)
        {
            Weight result;
            if (!_weights.ContainsKey(node))
            {
                result = new Weight(null, int.MaxValue);
                _weights.Add(node, result);
            }
            else
                result = _weights[node];

            return result;
        }

        /// <summary>
        /// Schedules the visit to.
        /// </summary>
        /// <param name="node">The node.</param>
        public void ScheduleVisitTo(INode node)
        {
            _scheduled.Add(node);
        }

        /// <summary>
        /// Gets a value indicating whether this instance has scheduled visits.
        /// </summary>
        /// <value><c>true</c> if this instance has scheduled visits; otherwise, <c>false</c>.</value>
        public bool HasScheduledVisits => _scheduled.Count > 0;

        /// <summary>
        /// Gets the node to visit.
        /// </summary>
        /// <returns>Node.</returns>
        public INode GetNodeToVisit()
        {
            var ordered = from n in _scheduled orderby QueryWeight(n).Value select n;

            var result = ordered.First();
            _scheduled.Remove(result);
            return result;
        }

        /// <summary>
        /// Determines whether [has computed path to origin] [the specified node].
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if [has computed path to origin] [the specified node]; otherwise, <c>false</c>.</returns>
        public bool HasComputedPathToOrigin(INode node)
        {
            return QueryWeight(node).From != null;
        }

        /// <summary>
        /// Computeds the path to origin.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IEnumerable&lt;Node&gt;.</returns>
        public IEnumerable<INode> ComputedPathToOrigin(INode node)
        {
            var n = node;
            while (n != null)
            {
                yield return n;
                n = QueryWeight(n).From;
            }
        }

    }
}