// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        private const string EXCEPTION_MESSAGE = "The input must be greater than or equal to zero.";
        private const char POSITVE_BIT = '1';

        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
                throw new ArgumentException(EXCEPTION_MESSAGE);

            var result = GetPositivesIndex(Convert.ToString(input, 2), out var positivesCount);

            result.AddFirst(positivesCount);

            return result;
        }

        private LinkedList<int> GetPositivesIndex(string binaryString, out int positivesCount)
        {
            positivesCount = 0;
            var positivesIndex = new LinkedList<int>();
            var binaryStringLastIndex = binaryString.Length - 1;

            for (var index = binaryStringLastIndex; index >= 0; index--)
            {
                if (binaryString[index].Equals(POSITVE_BIT))
                {
                    positivesIndex.AddLast(Math.Abs(index - binaryStringLastIndex));
                    positivesCount++;
                }
            }

            return positivesIndex;
        }

    }
}
