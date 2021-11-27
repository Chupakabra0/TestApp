using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.MVVM.Models
{
    public class User
    {
        public User(string student, int res)
        {
            name = student;
            result = res;
            time = DateTime.Now;
        }
        [JsonProperty("student")]
        public string name { get; set; }
        [JsonProperty("result")]
        public int result { get; set; }
        [JsonProperty("time")]
        public DateTime time { get; set; }
    }
}
