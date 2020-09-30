// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The SuppressCondition. </summary>
    public partial class SuppressCondition
    {
        /// <summary> Initializes a new instance of SuppressCondition. </summary>
        /// <param name="minimumNumber"> min point number, value range : [1, +∞). </param>
        /// <param name="minimumRatio"> min point ratio, value range : (0, 100]. </param>
        public SuppressCondition(int minimumNumber, double minimumRatio)
        {
            MinimumNumber = minimumNumber;
            MinimumRatio = minimumRatio;
        }
    }
}