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

        public void PostPearson(User user)
        {
            throw new NotImplementedException();
        }

        public void PostSavage(User user)
        {
            throw new NotImplementedException();
        }

        public string jsonData { get; set;}
    }
}
