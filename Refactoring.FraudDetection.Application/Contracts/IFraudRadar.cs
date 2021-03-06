﻿// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using Refactoring.FraudDetection.Domain.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Contracts
{
    public interface IFraudRadar
    {
        IEnumerable<FraudResult> Check(IEnumerable<string> serializedOrders);
    }
}