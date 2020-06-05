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
        public void The_Best_Count_Method_Is_CountWithLinkedList()
        {
            var list = Enumerable.Range(1, 100000);

            var countWithLinkedListTimeSpan = ExecuteBitCounterMethod(list, bitCounterPerformance.CountWithLinkedList);
            Thread.Sleep(1000);
            var countWithListTimeSpan = ExecuteBitCounterMethod(list, bitCounterPerformance.CountWithList);
            Thread.Sleep(1000);
            var countWithArrayListTimeSpan = ExecuteBitCounterMethod(list, bitCounterPerformance.CountWithArrayList);

            Assert.AreEqual(
                expected: true,
                actual: (countWithLinkedListTimeSpan < countWithArrayListTimeSpan) && (countWithLinkedListTimeSpan < countWithListTimeSpan),
                message: $"countWithListTimeSpan: {countWithListTimeSpan.TotalMilliseconds}, countWithArrayListTimeSpan: {countWithArrayListTimeSpan.TotalMilliseconds},  countWithLinkedListTimeSpan: {countWithLinkedListTimeSpan.TotalMilliseconds}");
        }

        private TimeSpan ExecuteBitCounterMethod(IEnumerable<int> list, Action<int> method)
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