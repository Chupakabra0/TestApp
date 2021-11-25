using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace Models
{
    public class Test : ITest
    {
        public Test(Common test)
        {
            id = test.id;
            description = XamlReader.Parse(test.description);
            //explanation = XamlReader.Parse(test.explanation);
            explanation = test.explanation;
            variantA = XamlReader.Parse(test.variantA.text);
            variantB = XamlReader.Parse(test.variantB.text);
            variantC = XamlReader.Parse(test.variantC.text);
            variantD = XamlReader.Parse(test.variantD.text);
        }
        public Test(Multitest test)
        {
            id = test.id;
            description = XamlReader.Parse(test.description);
            explanation = XamlReader.Parse(test.explanation);
            variantA = XamlReader.Parse(test.variantA.text);
            variantB = XamlReader.Parse(test.variantB.text);
            variantC = XamlReader.Parse(test.variantC.text);
            variantD = XamlReader.Parse(test.variantD.text);
        }
        public Test(Quiz test)
        {
            id = test.id;
            description = XamlReader.Parse(test.description);
            explanation = XamlReader.Parse(test.explanation);
            answer = test.answer;
        }
        public int id { get; set; }

        public object description { get; set; }

        public object explanation { get; set; }

        public object variantA { get; set; }

        public object variantB { get; set; }

        public object variantC { get; set; }

        public object variantD { get; set; }
        public string answer { get; set; }
    }
}
