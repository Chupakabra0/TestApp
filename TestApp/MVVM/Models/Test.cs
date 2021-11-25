using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Test : ITest
    {
        public Test(Common test)
        {
            id = test.id;
            description = test.description;
            explanation = test.explanation;
            variantA = test.variantA.text;
            variantB = test.variantB.text;
            variantC = test.variantC.text;
            variantD = test.variantD.text;
        }
        public Test(Multitest test)
        {
            id = test.id;
            description = test.description;
            explanation = test.explanation;
            variantA = test.variantA.text;
            variantB = test.variantB.text;
            variantC = test.variantC.text;
            variantD = test.variantD.text;
        }
        public Test(Quiz test)
        {
            id = test.id;
            description = test.description;
            explanation = test.explanation;
            answer = test.answer;
        }
        public int id { get; set; }

        public string description { get; set; }

        public string explanation { get; set; }

        public string variantA { get; set; }

        public string variantB { get; set; }

        public string variantC { get; set; }

        public string variantD { get; set; }
        public string answer { get; set; }
    }
}
