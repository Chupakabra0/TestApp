using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestApp.Core.Repository.Question
{
    public class JsonQuestionRepository : IQuestionRepository
    {
        public string FileName { get; set; }
        Pulls result;
        public JsonQuestionRepository(string file)
        {
            this.FileName = file;
            result = JsonConvert.DeserializeObject<Pulls>(File.ReadAllText(this.FileName));
        }
        public List<Common> GetPearsonCommonTest()
        {
            return result.pulls[1].questions.common_tests;
        }

        public List<Multitest> GetPearsonMultitestTest()
        {
            return result.pulls[1].questions.multi_tests;
        }

        public List<Quiz> GetPearsonQuizTest()
        {
            return result.pulls[1].questions.quiz_tests;
        }

        public List<Common> GetSavageCommonTest()
        {
            return result.pulls[0].questions.common_tests;
        }

        public List<Multitest> GetSavageMultitestTest()
        {
            return result.pulls[0].questions.multi_tests;
        }

        public List<Quiz> GetSavageQuizTest()
        {
            return result.pulls[0].questions.quiz_tests;
        }
    }
}
