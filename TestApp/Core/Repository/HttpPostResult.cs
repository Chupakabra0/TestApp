using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestApp.MVVM.Models;

namespace TestApp.Core.Repository
{
    class HttpPostResult : IPostResult
    {
        public void ConvertToJson(User user)
        {
            throw new NotImplementedException();
        }
        public async void PostPearson(User user)
        {
            var url = "https://pa-18-2-test-app.herokuapp.com/api/tests/61a25f6f088c3e91a3525bef/results";
            try
            {
                await Task.Run(()=>Server(url, user));
            }
            catch
            {
                try
                {
                    await Task.Run(() => ServerPut(url, user));
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }
        public async void PostSavage(User user)
        {
            var url = "https://pa-18-2-test-app.herokuapp.com/api/tests/61a25771088c3e91a3525bda/results";
            try
            {
                await Task.Run(() => Server(url, user));
            }
            catch
            {
                try
                {
                    await Task.Run(() => ServerPut(url, user));
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }
        public void Server(string url, User user)
        {
            var httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Proxy = null;
            ServerString(httpWebRequest, user);
        }
        public void ServerPut(string url, User user)
        {
            var httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            httpWebRequest.Proxy = null;
            ServerString(httpWebRequest, user);
        }
        public void ServerString(HttpWebRequest httpWebRequest, User user)
        {
            string jsonData = JsonConvert.SerializeObject(user);


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonData);
                streamWriter.Flush();
            }

            var webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                Console.WriteLine(responseText);
            }
        }
    }
}
