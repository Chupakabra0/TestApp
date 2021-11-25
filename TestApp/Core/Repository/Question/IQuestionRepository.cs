using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Core.Repository.Question
{
    public interface IQuestionRepository
    {
        public List<Common> GetSavageCommonTest();
        public List<Common> GetPearsonCommonTest();

        public List<Multitest> GetSavageMultitestTest();
        public List<Multitest> GetPearsonMultitestTest();

        public List<Quiz> GetSavageQuizTest();
        public List<Quiz> GetPearsonQuizTest();

    } 
}
