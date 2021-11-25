using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Multitest: ITest
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("explanation")]
        public string explanation { get; set; }

        [JsonProperty("variantA")]
        public Variant variantA { get; set; }

        [JsonProperty("variantB")]
        public Variant variantB { get; set; }

        [JsonProperty("variantC")]
        public Variant variantC { get; set; }

        [JsonProperty("variantD")]
        public Variant variantD { get; set; }
    }
}
