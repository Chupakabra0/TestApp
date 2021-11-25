using Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using TestApp.Core.Commands.RelayCommand;
using TestApp.Core.Repository.Question;
//using TestLibrary;

namespace TestApp.MVVM.ViewModels.TestViewModel {
    public class TestViewModel : BaseViewModel.BaseViewModel {
        public TestViewModel() {
            this.obj_common = this.repository.GetSavageCommonTest();
            this.obj_multitest = this.repository.GetSavageMultitestTest();
            this.obj_quiz = this.repository.GetSavageQuizTest();

            MixCommon();
            MixMultiTest();
            MixQuiz();

            this.test1 = new Test(obj_common[0]);
            this.test2 = new Test(obj_common[1]);
            this.test3 = new Test(obj_common[2]);
            this.test4 = new Test(obj_common[3]);
            this.test5 = new Test(obj_common[4]);
            this.test6 = new Test(obj_common[5]);

            this.test7 = new Test(obj_multitest[0]);
            this.test8 = new Test(obj_multitest[1]);
            this.test9 = new Test(obj_multitest[2]);

            this.test10 = new Test(obj_quiz[0]);
            this.test11 = new Test(obj_quiz[1]);
            this.test12 = new Test(obj_quiz[2]);
        }

        public ICommand OpenSavageCommand =>
            new RelayCommand(() => {
                // TODO: savage test generate
                this.IsTestChosen = true;
            });

        public ICommand OpenPearsonCommand =>
            new RelayCommand(() => {
                // TODO: pearson test generate
                this.IsTestChosen = true;
            });

        public ICommand BackCommand =>
            new RelayCommand(() => {
                this.IsTestChosen = false;
            });

        public bool IsTestChosen      { get; set; }
        public bool IsMenuEnabled  => !this.IsTestChosen;
        public IQuestionRepository repository = new JsonQuestionRepository("test.json");

#region [SHUFFLE]
        public List<int> rand_common = new List<int>();
        public List<int> rand_multitest = new List<int>();
        public List<int> rand_quiz = new List<int>();

        public void MixCommon()
        {
            Random random = new Random();
            int j = 0;
            for (int i = this.obj_common.Count - 1; i >= 1; i--)
            {
                j = random.Next(i + 1);
                rand_common.Add(j);
                var tmp = this.obj_common[j];
                this.obj_common[j] = this.obj_common[i];
                this.obj_common[i] = tmp;
            }
        }
        public void MixMultiTest()
        {
            Random random = new Random();
            int j = 0;
            for (int i = this.obj_multitest.Count - 1; i >= 1; i--)
            {
                j = random.Next(i + 1);
                rand_multitest.Add(j);
                var tmp = this.obj_multitest[j];
                this.obj_multitest[j] = this.obj_multitest[i];
                this.obj_multitest[i] = tmp;
            }
        }
        public void MixQuiz()
        {
            Random random = new Random();
            int j = 0;
            for (int i = this.obj_quiz.Count - 1; i >= 1; i--)
            {
                j = random.Next(i + 1);
                rand_quiz.Add(j);
                var tmp = this.obj_quiz[j];
                this.obj_quiz[j] = this.obj_quiz[i];
                this.obj_quiz[i] = tmp;
            }
        }
        #endregion

#region [TESTS]
        //--------------------- TESTS -----------------------------//
        public List<Common> obj_common { get; set; }
        public List<Multitest> obj_multitest { get; set; }
        public List<Quiz> obj_quiz { get; set; }

        public Test test1 { get; set; }
        public Test test2 { get; set; }
        public Test test3 { get; set; }
        public Test test4 { get; set; }
        public Test test5 { get; set; }
        public Test test6 { get; set; }



        private string desc_1 =
                "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><TextBlock Style=\"{StaticResource Content}\" Text=\"За якою формулою можна знайти значення точки, що відповідає розв’язку в алгоритмі пошуку рандомізованого розв'язку за критерієм Неймана-Пірсона?\"></TextBlock></StackPanel>";
        public object RB_Desc_1 => XamlReader.Parse(this.desc_1);

        private string a1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Controls:FormulaControl HorizontalAlignment=\"Center\" Style=\"{StaticResource BasicFormula}\" Formula=\"x_{i} \\pmatrix{ l_{i 1} \\cr l_{i 2} } - (1 - x_{i}) \\pmatrix{ l_{j 1} \\cr l_{j 2} } = \\pmatrix{ L_{1} \\cr L_{2} } \" Margin=\"0\" Scale=\"20\"></Controls:FormulaControl></StackPanel>";
        public object RB_a1_Content => XamlReader.Parse(this.a1_content);
        public bool RB_a1_Checked { get; set; }

        private string b1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Controls:FormulaControl HorizontalAlignment=\"Center\" Style=\"{StaticResource BasicFormula}\" Formula=\"x_{i} \\pmatrix{ l_{i 1} \\cr l_{i 2} } + (1 - x_{i}) \\pmatrix{ l_{j 1} \\cr l_{j 2} } = \\pmatrix{ L_{1} \\cr L_{2} } \" Margin=\"0\" Scale=\"20\"></Controls:FormulaControl></StackPanel>";
        public object RB_b1_Content => XamlReader.Parse(this.b1_content);
        public bool RB_b1_Checked { get; set; }

        private string c1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Controls:FormulaControl HorizontalAlignment=\"Center\" Style=\"{StaticResource BasicFormula}\" Formula=\"(1 - x_{i}) \\pmatrix{ l_{j 1} \\cr l_{j 2} } -x_{i} \\pmatrix{ l_{i 1} \\cr l_{i 2} } = \\pmatrix{ L_{1} \\cr L_{2} } \" Margin=\"0\" Scale=\"20\"></Controls:FormulaControl></StackPanel>";
        public object RB_c1_Content => XamlReader.Parse(this.c1_content);
        public bool RB_c1_Checked { get; set; }

        private string d1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Controls:FormulaControl HorizontalAlignment=\"Center\" Style=\"{StaticResource BasicFormula}\" Formula=\"x_{i} \\pmatrix{ l_{i 1} \\cr l_{i 2} } + (1 - x_{i}) \\pmatrix{ l_{j 1} \\cr l_{j 2} } = 0 \" Margin=\"0\" Scale=\"20\"></Controls:FormulaControl></StackPanel>";
        public object RB_d1_Content => XamlReader.Parse(this.d1_content);
        public bool RB_d1_Checked { get; set; }


        public bool CheckMark_1 => this.RB_d1_Checked;

        //--------------------- MULTITESTS -----------------------------//
        public Test test7 { get; set; }
        public Test test8 { get; set; }
        public Test test9 { get; set; }


        //--------------------- QUESTION -----------------------------//
        public Test test10 { get; set; }
        public Test test11 { get; set; }
        public Test test12 { get; set; }
#endregion
    }
}
