using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

            Pulls obj = new Pulls();

            obj = JsonConvert.DeserializeObject<Pulls>(File.ReadAllText("test.json"));

            Console.WriteLine(obj.pulls[0].questions.common_tests[0].variantB.text);

            string jsonData = JsonConvert.SerializeObject(obj);

            //var obj1 = JsonConvert.DeserializeObject<Pulls>(jsonData);
            Console.ReadKey();

        }
    }
}
