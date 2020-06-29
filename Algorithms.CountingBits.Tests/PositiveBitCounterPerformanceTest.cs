// <copyright file="PositiveBitCounterTest.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PositiveBitCounterPerformanceTest
    {
        private readonly PositiveBitCounterPerformance bitCounterPerformance = new PositiveBitCounterPerformance();

        [TestMethod]
        [Ignore]
        [DataRow(4)]
        [DataRow(10000000)]
        public void The_Best_Count_Method_Is_CountWithList(int numberOfInput)
        {
            var inputList = Enumerable.Range(0, numberOfInput);

            var countWithListTimeSpan = ExecutePositiveBitCounterMethod(inputList, bitCounterPerformance.CountWithList);
            Thread.Sleep(1000);
            var countWithArrayListTimeSpan = ExecutePositiveBitCounterMethod(inputList, bitCounterPerformance.CountWithArrayList);
            Thread.Sleep(1000);
            var countWithLinkedListTimeSpan = ExecutePositiveBitCounterMethod(inputList, bitCounterPerformance.CountWithLinkedList);

            Assert.AreEqual(
                expected: true,
                actual: (countWithListTimeSpan < countWithArrayListTimeSpan) && (countWithListTimeSpan < countWithLinkedListTimeSpan),
                message: $"countWithListTimeSpan: {countWithListTimeSpan.TotalMilliseconds}, countWithArrayListTimeSpan: {countWithArrayListTimeSpan.TotalMilliseconds},  countWithLinkedListTimeSpan: {countWithLinkedListTimeSpan.TotalMilliseconds}");
        }

        private TimeSpan ExecutePositiveBitCounterMethod(IEnumerable<int> list, Action<int> method)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var item in list)
            {
                method(item);
            }
            var ts = stopWatch.Elapsed;
            stopWatch.Stop();
            return ts;
        }
    }
}