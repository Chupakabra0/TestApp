using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using TestApp.Core.Commands.RelayCommand;
using TestApp.Core.Quadro;
using TestApp.Core.Repository.Question;
//using TestLibrary;

namespace TestApp.MVVM.ViewModels.TestViewModel {
    public class TestViewModel : BaseViewModel.BaseViewModel {
        public TestViewModel() {
            this.obj_common = this.repository.GetSavageCommonTest();
            this.obj_multitest = this.repository.GetSavageMultitestTest();
            this.obj_quiz = this.repository.GetSavageQuizTest();
            this.bools = new ObservableCollection<Quadro<bool, bool, bool, bool>>();
            this.answers = new ObservableCollection<string>();
            for(var i = 0; i < 9; i++)
            {
                this.bools.Add(new Quadro<bool, bool, bool, bool>(false, false, false, false));
            }
            for (var i = 0; i < 3; i++)
            {
                this.answers.Add(" ");
            }
            this.NumberOfTests = bools.Count + answers.Count;
            this.IsTestComplete = false;
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

        public ICommand SendResultCommand =>
            new RelayCommand(() => {
                ValidationTest();
                this.IsTestComplete = true;
            });

        public bool IsTestChosen      { get; set; }
        public bool IsMenuEnabled  => !this.IsTestChosen;
        public bool IsTestComplete    { get; set; }
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
                (this.obj_common[j], this.obj_common[i]) = (this.obj_common[i], this.obj_common[j]);
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
                (this.obj_multitest[j], this.obj_multitest[i]) = (this.obj_multitest[i], this.obj_multitest[j]);
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
                (this.obj_quiz[j], this.obj_quiz[i]) = (this.obj_quiz[i], this.obj_quiz[j]);
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

        public bool RB_a1_Checked { get; set; }
        public bool RB_b1_Checked { get; set; }
        public bool RB_c1_Checked { get; set; }
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

#region [VALIDATION]
        public void ValidationTest()
        {
            int i;
            this.NumberOfCorrect = 0;
            for(i = 0; i < 6; i++)
            {
                if (bools[i].Item1 == obj_common[i].variantA.isCorrect && bools[i].Item2 == obj_common[i].variantB.isCorrect && bools[i].Item3 == obj_common[i].variantC.isCorrect && bools[i].Item4 == obj_common[i].variantD.isCorrect)
                {
                    this.NumberOfCorrect++;
                }
            }
            for (int j = 0; j < 3; j++, i++)
            {
                if (bools[i].Item1 == obj_multitest[j].variantA.isCorrect && bools[i].Item2 == obj_multitest[j].variantB.isCorrect && bools[i].Item3 == obj_multitest[j].variantC.isCorrect && bools[i].Item4 == obj_multitest[j].variantD.isCorrect)
                {
                    this.NumberOfCorrect++;
                }
            }
            for (int j = 0; j < answers.Count; j++)
            {
                if(answers[j] == obj_quiz[j].answer)
                {
                    this.NumberOfCorrect++;
                }
            }
        }
        public int NumberOfCorrect { get; set; }
        public int NumberOfTests { get; set; }
        public ObservableCollection<Quadro<bool,bool,bool,bool>> bools { get; set; }
        public ObservableCollection<string> answers;
#endregion
    }
}
