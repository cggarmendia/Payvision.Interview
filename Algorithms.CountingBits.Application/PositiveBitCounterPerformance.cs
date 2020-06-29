// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PositiveBitCounterPerformance
    {
        private const string EXCEPTION_MESSAGE = "The input must be greater than or equal to zero.";
        private const char POSITVE_BIT = '1';

        #region CountWithArrayList
        public void CountWithArrayList(int input)
        {
            if (input < 0)
                throw new ArgumentException(EXCEPTION_MESSAGE);

            var result = GetPositivesIndexWithArrayList(Convert.ToString(input, 2), out var positivesCount);

            result[0] = positivesCount;
        }

        private ArrayList GetPositivesIndexWithArrayList(string binaryString, out int positivesCount)
        {
            positivesCount = 0;
            var positivesIndex = new ArrayList() { 0 };
            var binaryStringLastIndex = binaryString.Length - 1;

            for (var index = binaryStringLastIndex; index >= 0; index--)
            {
                if (binaryString[index].Equals(POSITVE_BIT))
                {
                    positivesIndex.Add(Math.Abs(index - binaryStringLastIndex));
                    positivesCount++;
                }
            }

            return positivesIndex;
        }
        #endregion

        #region CountWithLinkedList
        public void CountWithLinkedList(int input)
        {
            if (input < 0)
                throw new ArgumentException(EXCEPTION_MESSAGE);

            var result = GetPositivesIndexWithLinkedList(Convert.ToString(input, 2), out var positivesCount);

            result.AddFirst(positivesCount);
        }

        private LinkedList<int> GetPositivesIndexWithLinkedList(string binaryString, out int positivesCount)
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
        #endregion

        #region CountWithList
        public void CountWithList(int input)
        {
            if (input < 0)
                throw new ArgumentException(EXCEPTION_MESSAGE);


            var positivesIndex = GetPositivesIndexWithList(Convert.ToString(input, 2), out var positivesCount);

            var result = new List<int>(positivesCount + 1)
            {
                positivesCount
            };

            result.AddRange(positivesIndex);
        }

        private List<int> GetPositivesIndexWithList(string binaryString, out int positivesCount)
        {
            positivesCount = 0;
            var positivesIndex = new List<int>();
            var binaryStringLastIndex = binaryString.Length - 1;

            for (var index = binaryStringLastIndex; index >= 0; index--)
            {
                if (binaryString[index].Equals(POSITVE_BIT))
                {
                    positivesIndex.Add(Math.Abs(index - binaryStringLastIndex));
                    positivesCount++;
                }
            }

            return positivesIndex;
        }
        #endregion
    }
}
