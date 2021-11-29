using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
//using TestApp.MVVM.Models;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Common c = new Common();
            //c.description = "qwerty";

            //Multitest m = new Multitest();
            //m.description = "ytrewq";

            //Quiz q1 = new Quiz();
            //q1.description = "quiz";

            //Question q = new Question(c, m, q1);

            //Pulls p = new Pulls("Pirson", "Huila", q);

            //Pulls obj = new Pulls();

            //obj = JsonConvert.DeserializeObject<Pulls>(File.ReadAllText("test.json"));

            //Console.WriteLine(obj.pulls[0].questions.common_tests[0].variantB.text);

            //string jsonData = JsonConvert.SerializeObject(obj);

            //var obj1 = JsonConvert.DeserializeObject<Pulls>(jsonData);


            var url = "https://pa-18-2-test-app.herokuapp.com/api/tests/61a25771088c3e91a3525bda/results";
            var httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Proxy = null;

            //string jsonData = JsonConvert.SerializeObject(user);


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"student\" : \"Ленусик\", \"result\" : \"12\", \"time\" : \"12:00\" }";
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                Console.WriteLine(responseText);   
            }


            Console.ReadKey();

        }
    }
}
