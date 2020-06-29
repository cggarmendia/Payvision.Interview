// <copyright file="FraudRadarTests.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Contracts;
using Refactoring.FraudDetection.Domain.Services;
using Refactoring.FraudDetection.Implementations;
using Refactoring.FraudDetection.Infrastructure.Cache.Contracts;
using Refactoring.FraudDetection.Infrastructure.Cache.Implementations;
using Refactoring.FraudDetection.Infrastructure.Deserializer.Implementations;
using Refactoring.FraudDetection.Infrastructure.Normalizer.Implementations;
using Refactoring.FraudDetection.Specification.Contracts.Factory;
using Refactoring.FraudDetection.Specification.Contracts.Strategy;
using Refactoring.FraudDetection.Specification.Implementations.Factory;
using Refactoring.FraudDetection.Specification.Implementations.Strategy;

namespace Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class FraudRadarTests
    {
        private IFraudRadar _systemUnderTest;
        private IDeserializer _orderDeserializer;
        private INormalizer _normalizer;
        private IFraudInspector _fraudInspector;
        private ICustomCache _customCache;
        private ISpecificationFactory _specificationFactory;
        private ISpecificationStrategyContext _specificationStrategyContext;

        [TestInitialize]
        public void Setup()
        {
            _orderDeserializer = new Deserializer();
            _normalizer = new Normalizer();
            _customCache = new CustomCache();
            _specificationFactory = new SpecificationFactory(_customCache);
            _specificationStrategyContext = new SpecificationStrategyContext(_specificationFactory);
            _fraudInspector = new FraudInspector(_specificationStrategyContext);
            _systemUnderTest = new FraudRadar(_orderDeserializer, _normalizer, _fraudInspector);
        }

        [TestMethod]
        [DeploymentItem("./Files/OneLineFile.txt", "Files")]
        public void CheckFraud_OneLineFile_NoFraudExpected()
        {
            var result = _systemUnderTest.Check(File.ReadAllLines("./Files/OneLineFile.txt")).ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(0, "The result should not contains fraudulent lines");
        }

        [TestMethod]
        [DeploymentItem("./Files/TwoLines_FraudulentSecond.txt", "Files")]
        public void CheckFraud_TwoLines_SecondLineFraudulent()
        {
            var result = _systemUnderTest.Check(File.ReadAllLines("./Files/TwoLines_FraudulentSecond.txt")).ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        [DeploymentItem("./Files/ThreeLines_FraudulentSecond.txt", "Files")]
        public void CheckFraud_ThreeLines_SecondLineFraudulent()
        {
            var result = _systemUnderTest.Check(File.ReadAllLines("./Files/ThreeLines_FraudulentSecond.txt")).ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        [DeploymentItem("./Files/FourLines_MoreThanOneFraudulent.txt", "Files")]
        public void CheckFraud_FourLines_MoreThanOneFraudulent()
        {
            var result = _systemUnderTest.Check(File.ReadAllLines("./Files/FourLines_MoreThanOneFraudulent.txt")).ToList();

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(2, "The result should contains the number of lines of the file");
        }
    }
}