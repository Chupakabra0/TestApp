using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TestApp.Core.Repository.Question
{
    class HttpQuestionsRepository : IQuestionRepository
    {
        public Pull result { get; set; }

        public List<Common> GetPearsonCommonTest()
        {
            ServerPearson();
            return result.questions.common_tests;
        }

        public List<Multitest> GetPearsonMultitestTest()
        {
            ServerPearson();
            return result.questions.multi_tests;
        }

        public List<Quiz> GetPearsonQuizTest()
        {
            ServerPearson();
            return result.questions.quiz_tests;
        }

        public List<Common> GetSavageCommonTest()
        {
            ServerSavage();
            return result.questions.common_tests;
        }

        public List<Multitest> GetSavageMultitestTest()
        {
            ServerSavage();
            return result.questions.multi_tests;
        }

        public List<Quiz> GetSavageQuizTest()
        {
            ServerSavage();
            return result.questions.quiz_tests;
        }

        private void ServerSavage()
        {
            var url = "https://pa-18-2-test-app.herokuapp.com/api/tests/61a25771088c3e91a3525bda";
            Server(url);
        }
        private void ServerPearson()
        {
            var url = "https://pa-18-2-test-app.herokuapp.com/api/tests/61a25f6f088c3e91a3525bef";
            Server(url);
        }

        private void Server(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);

            string data = reader.ReadToEnd();

            result = JsonConvert.DeserializeObject<Pull>(data);
        }

        public string GetNameSavage()
        {
            return result.name;
        }

        public string GetNamePearson()
        {
            return result.name;
        }
    }
}
