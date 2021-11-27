using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.MVVM.Models;

namespace TestApp.Core.Repository
{
    public class JsonPostResult : IPostResult
    {
        public void ConvertToJson(User user)
        {
            jsonData = JsonConvert.SerializeObject(user);
            System.IO.File.WriteAllText("result.json", jsonData);
        }
        public string jsonData { get; set;}
    }
}
