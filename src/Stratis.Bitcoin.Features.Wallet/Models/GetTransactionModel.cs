﻿using System.Collections.Generic;
using NBitcoin;
using Newtonsoft.Json;
using Stratis.Bitcoin.Utilities.JsonConverters;

namespace Stratis.Bitcoin.Features.Wallet.Models
{
    /// <summary>Transaction details model for RPC method gettransaction.</summary>
    public class GetTransactionDetailsModel
    {
        // Required to be returned according to the Bitcoin developer reference. Can be empty string for default account.
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("amount")]
        [JsonConverter(typeof(MoneyInCoinsJsonConverter))]
        public Money Amount { get; set; }
    }

    /// <summary>Model for RPC method gettransaction.</summary>
    public class GetTransactionModel
    {
        [JsonProperty("amount")]
        [JsonConverter(typeof(MoneyInCoinsJsonConverter))]
        public Money Amount { get; set; }

        [JsonProperty("blockhash")]
        public uint256 BlockHash { get; set; }

        [JsonProperty("txid")]
        public uint256 TransactionId { get; set; }

        [JsonProperty("time")]
        public long? TransactionTime { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("details")]
        public List<GetTransactionDetailsModel> Details { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }
    }
}
