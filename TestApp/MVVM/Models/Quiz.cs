using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Quiz: ITest
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("explanation")]
        public string explanation { get; set; }

        [JsonProperty("answer")]
        public string answer { get; set; }
    }
}
