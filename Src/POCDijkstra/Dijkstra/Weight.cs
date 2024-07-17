// ***********************************************************************
// Assembly         : POCDijkstra
// Author           : Guilherme Branco Stracini
// Created          : 20/04/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 21/04/2020
// ***********************************************************************
// <copyright file="Dijkstra.Weight.cs" company="Guilherme Branco Stracini ME">
//     2020 © Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using POCDijkstra.Nodes;

namespace POCDijkstra.Dijkstra
{
    /// <summary>
    /// Class Weight.
    /// </summary>
    internal class Weight
    {
        /// <summary>
        /// Gets from.
        /// </summary>
        /// <value>From.</value>
        public INode From { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weight" /> class.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="value">The value.</param>
        public Weight(INode @from, int value)
        {
            From = @from;
            Value = value;
        }
    }
}
