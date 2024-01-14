using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JungmhaApp.form
{
    [Serializable]
    public class WalkerForm
    {
        public class Walker
        {
            [JsonPropertyName("walkerID")]
            public int WalkerID { get; set; }

            [JsonPropertyName("totalReview")]
            public int TotalReview { get; set; }

            [JsonPropertyName("detail")]
            public WalkerDetail Detail { get; set; }
        }

        [Serializable]
        public class WalkerDetail
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("profileImage")]
            public string ProfileImage { get; set; }

            [JsonPropertyName("verify")]
            public string Verify { get; set; }

            [JsonPropertyName("location")]
            public string Location { get; set; }

            [JsonPropertyName("price")]
            public Price Price { get; set; }
        }

        [Serializable]
        public class Price
        {
            [JsonPropertyName("small")]
            public decimal Small { get; set; }

            [JsonPropertyName("medium")]
            public decimal Medium { get; set; }

            [JsonPropertyName("big")]
            public decimal Big { get; set; }
        }

        public WalkerForm() { }
    }
}
