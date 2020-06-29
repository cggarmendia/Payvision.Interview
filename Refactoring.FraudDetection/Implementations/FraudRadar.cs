// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Contracts;
    using Refactoring.FraudDetection.Dto;
    using System.Collections.Generic;
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
        public IEnumerable<FraudResult> Check(IEnumerable<string> serializedOrders)
        {
            var ordersDeserialize = _orderDeserializer.Deserialize(serializedOrders);

            _normalizer.NormalizeOrders(ordersDeserialize);

            return _fraudInspector.InspectOrders(ordersDeserialize.ToList());
        }
        #endregion
    }
}