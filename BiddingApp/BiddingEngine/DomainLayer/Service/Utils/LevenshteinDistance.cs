//-----------------------------------------------------------------------
// <copyright file="LevenshteinDistance.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//----------------------------------------------------------------------- 

namespace BiddingApp.BiddingEngine.DomainLayer.Service.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains approximate string matching
    /// </summary>
    public static class LevenshteinDistance
    { 
        /// <summary>
        /// Computes the distance.
        /// </summary>
        /// <param name="firstString">The first string.</param>
        /// <param name="secondString">The second string.</param>
        /// <returns>The distance between two strings.</returns>
        public static int ComputeDistance(string firstString, string secondString)
        {
            int fistStringLength = firstString.Length;
            int secondStringLength = secondString.Length;
            int[,] distance = new int[fistStringLength + 1, secondStringLength + 1];

            //// Step 1
            if (fistStringLength == 0)
            {
                return secondStringLength;
            }

            if (secondStringLength == 0)
            {
                return fistStringLength;
            }

            //// Step 2
            for (int i = 0; i <= fistStringLength; distance[i, 0] = i++)
            {
            }

            for (int j = 0; j <= secondStringLength; distance[0, j] = j++)
            {
            }

            //// Step 3
            for (int i = 1; i <= fistStringLength; i++)
            {
                ////Step 4
                for (int j = 1; j <= secondStringLength; j++)
                {
                    //// Step 5
                    int cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : 1;

                    //// Step 6
                    distance[i, j] = Math.Min(
                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }
            //// Step 7
            return distance[fistStringLength, secondStringLength];
        }
    }
}
