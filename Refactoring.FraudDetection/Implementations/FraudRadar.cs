// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Contracts;
    using Refactoring.FraudDetection.Dto;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public partial class FraudRadar : IFraudRadar
    {
        #region Properties
        private readonly IOrderDeserializer _orderDeserializer;
        private readonly INormalizer _normalizer;
        private readonly IFraudInspector _fraudInspector;
        #endregion

        #region Ctors.
        public FraudRadar(IOrderDeserializer orderDeserializer,
            INormalizer normalizer,
            IFraudInspector fraudInspector)
        {
            _orderDeserializer = orderDeserializer;
            _normalizer = normalizer;
            _fraudInspector = fraudInspector;
        }
        #endregion

        #region Public_Methods        
        public IEnumerable<FraudResult> Check(string filePath)
        {
            var orders = _orderDeserializer.Deserialize(File.ReadAllLines(filePath));

            _normalizer.NormalizeOrders(orders);

            return _fraudInspector.InspectOrders(orders.ToList());
        }
        #endregion
    }
}