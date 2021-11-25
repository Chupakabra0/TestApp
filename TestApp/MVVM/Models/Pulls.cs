using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public Question(Common c, Multitest m, Quiz q)
        {
            common_tests = new List<Common>();
            common_tests.Add(c);

            multi_tests = new List<Multitest>();
            multi_tests.Add(m);

            quiz_tests = new List<Quiz>();
            quiz_tests.Add(q);
        }
        [JsonProperty("common")]
        public List<Common> common_tests { get; set; }
        [JsonProperty("multitest")]
        public List<Multitest> multi_tests { get; set; }
        [JsonProperty("quiz")]
        public List<Quiz> quiz_tests { get; set; }


    }
    public class Pulls
    {
        public List<Pull> pulls { get; set; }
    }
    public class Pull
    {
        public Pull()
        {
            name = null;
            description = null;
            questions = null;
        }
        public Pull(string n, string d, Question q)
        {
            name = n;
            description = d;
            questions = q;
        }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("questions")]
        public Question questions { get; set; }
    }
}
