using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JungmhaApp.form
{
    [Serializable]
    public class DogForm
    {
        [JsonProperty("dogImage")]
        public string DogImage { get; set; }

        [JsonProperty("breedName")]
        public string BreedName { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }
}
