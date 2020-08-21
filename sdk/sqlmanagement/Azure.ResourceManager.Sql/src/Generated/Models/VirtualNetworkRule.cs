// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> A virtual network rule. </summary>
    public partial class VirtualNetworkRule : Resource
    {
        /// <summary> Initializes a new instance of VirtualNetworkRule. </summary>
        public VirtualNetworkRule()
        {
        }

        /// <summary> Initializes a new instance of VirtualNetworkRule. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="virtualNetworkSubnetId"> The ARM resource id of the virtual network subnet. </param>
        /// <param name="ignoreMissingVnetServiceEndpoint"> Create firewall rule before the virtual network has vnet service endpoint enabled. </param>
        /// <param name="state"> Virtual Network Rule State. </param>
        internal VirtualNetworkRule(string id, string name, string type, string virtualNetworkSubnetId, bool? ignoreMissingVnetServiceEndpoint, VirtualNetworkRuleState? state) : base(id, name, type)
        {
            VirtualNetworkSubnetId = virtualNetworkSubnetId;
            IgnoreMissingVnetServiceEndpoint = ignoreMissingVnetServiceEndpoint;
            State = state;
        }

        /// <summary> The ARM resource id of the virtual network subnet. </summary>
        public string VirtualNetworkSubnetId { get; set; }
        /// <summary> Create firewall rule before the virtual network has vnet service endpoint enabled. </summary>
        public bool? IgnoreMissingVnetServiceEndpoint { get; set; }
        /// <summary> Virtual Network Rule State. </summary>
        public VirtualNetworkRuleState? State { get; }
    }
}