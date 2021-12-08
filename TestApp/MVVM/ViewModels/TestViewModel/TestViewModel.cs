using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using TestApp.Core.Commands.RelayCommand;
using TestApp.Core.Quadro;
using TestApp.Core.Repository;
using TestApp.Core.Repository.Question;
using TestApp.Core.Repository.Theory;
using TestApp.MVVM.Models;

//using TestLibrary;

namespace TestApp.MVVM.ViewModels.TestViewModel {
    public class TestViewModel : BaseViewModel.BaseViewModel
    {
        public TestViewModel()
        {
            this.Internet = CheckForInternetConnection();
            this.IsTestComplete = false;
            this.Loading = false;
            this.bools = new ObservableCollection<Quadro<bool, bool, bool, bool>>();
            this.answers = new ObservableCollection<string>();
            this.AhShitHereWeGoAgain = new ObservableCollection<bool>();

            for (var i = 0; i < 9; i++)
            {
                this.bools.Add(new Quadro<bool, bool, bool, bool>(false, false, false, false));
            }
            for (var i = 0; i < 3; i++)
            {
                this.answers.Add(string.Empty);
            }

            this.NumberOfTests = bools.Count + answers.Count;

            for (var i = 0; i < NumberOfTests; i++)
            {
                this.AhShitHereWeGoAgain.Add(false);
            }
        }

        public string HeaderText { get; set; }
        public bool Loading { get; set; }
        public bool IsTestChosen { get; set; }
        public bool IsMenuEnabled => !this.IsTestChosen;
        public bool Internet { get; set; }
        public bool IsTestComplete    { get; set; }
        public bool IsTestNotComplete => !this.IsTestComplete;
        //public IQuestionRepository repository = new JsonQuestionRepository("test.json");
        public IQuestionRepository repository = new HttpQuestionsRepository();

        public User user;
        public JsonPostResult future_file = new ();
        public IPostResult post_result = new HttpPostResult();

#region [COMMANDS]

        public ICommand OpenSavageCommand =>
            new RelayCommand(() => {
                try
                {
                    SavageOpenBody();
                    //this.Loading = true;
                    //MessageBox.Show("Загрузка", "Сообщение", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так... Проверьте подключение к интернету", "Сообщение", MessageBoxButton.OK);
                }
            }, () => !this.Loading);

        public ICommand OpenPearsonCommand =>
            new RelayCommand(() => {
                try
                {
                    PearsonOpenBody();
                    //this.Loading = true;
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так... Проверьте подключение к интернету", "Сообщение",MessageBoxButton.OK);
                }
            }, () => !this.Loading);

        public ICommand BackCommand =>
            new RelayCommand(() => {
                Clear();
                this.IsTestComplete = false;
                this.IsTestChosen = false;
                //this.Loading = false;
                DummyTheoryRepository.Instance.IsThroll = false;
            });

        public ICommand SendResultCommand =>
            new RelayCommand(() => {
                ValidationTest();
                //this.Loading = false;
                this.IsTestComplete = true;
                user = new User( Environment.UserName, String.Format("{0}/{1}", NumberOfCorrect.ToString(), NumberOfTests.ToString()));
                //future_file.ConvertToJson(user);
                if(HeaderText == repository.GetNamePearson())
                {
                    post_result.PostPearson(user);
                }
                else if(HeaderText == repository.GetNameSavage())
                {
                    post_result.PostSavage(user);
                }
                else
                {
                    throw new NotImplementedException();
                }
                //post_result.ConvertToJson(user);
                DummyTheoryRepository.Instance.IsThroll = false;
            });

        #endregion

        #region [SHUFFLE]

        public int random_seed { get; set; }

        public async void MixCommon()
        {
            Random random = new Random(random_seed);
            int j = 0;
            await Task.Run(() => {
                for (int i = this.obj_common.Count - 1; i >= 1; i--)
                {
                    j = random.Next(i + 1);
                    (this.obj_common[j], this.obj_common[i]) = (this.obj_common[i], this.obj_common[j]);
                }
            });
            
        }
        public async void MixMultiTest()
        {
            Random random = new Random(random_seed);
            int j = 0;
            await Task.Run(()=>{
                for (int i = this.obj_multitest.Count - 1; i >= 1; i--)
                {
                    j = random.Next(i + 1);
                    (this.obj_multitest[j], this.obj_multitest[i]) = (this.obj_multitest[i], this.obj_multitest[j]);
                }
            });
            
        }
        public async void MixQuiz()
        {
            Random random = new Random(random_seed);
            int j = 0;
            await Task.Run(()=> {
                for (int i = this.obj_quiz.Count - 1; i >= 1; i--)
                {
                    j = random.Next(i + 1);
                    (this.obj_quiz[j], this.obj_quiz[i]) = (this.obj_quiz[i], this.obj_quiz[j]);
                }
            });
            
        }
        #endregion

#region [TESTS]
        //--------------------- TESTS -----------------------------//
        public List<Common> obj_common { get; set; }
        public List<Multitest> obj_multitest { get; set; }
        public List<Quiz> obj_quiz { get; set; }

        //--------------------- COMMONS -----------------------------//
        public Test test1 { get; set; }
        public Test test2 { get; set; }
        public Test test3 { get; set; }
        public Test test4 { get; set; }
        public Test test5 { get; set; }
        public Test test6 { get; set; }

        //--------------------- MULTITESTS -----------------------------//
        public Test test7 { get; set; }
        public Test test8 { get; set; }
        public Test test9 { get; set; }


        //--------------------- QUIZ -----------------------------//
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
                    AhShitHereWeGoAgain[i] = true;
                }
                else
                {
                    var temp = new Quadro<bool, bool, bool, bool>(
                      obj_common[i].variantA.isCorrect,
                      obj_common[i].variantB.isCorrect,
                      obj_common[i].variantC.isCorrect,
                      obj_common[i].variantD.isCorrect
                    );
                    this.bools[i] = temp;
                }
            }
            for (int j = 0; j < 3; j++, i++)
            {
                if (bools[i].Item1 == obj_multitest[j].variantA.isCorrect && bools[i].Item2 == obj_multitest[j].variantB.isCorrect && bools[i].Item3 == obj_multitest[j].variantC.isCorrect && bools[i].Item4 == obj_multitest[j].variantD.isCorrect)
                {
                    this.NumberOfCorrect++;
                    AhShitHereWeGoAgain[i] = true;
                }
                else {
                    var temp = new Quadro<bool, bool, bool, bool>(
                      obj_multitest[j].variantA.isCorrect,
                      obj_multitest[j].variantB.isCorrect,
                      obj_multitest[j].variantC.isCorrect,
                      obj_multitest[j].variantD.isCorrect
                    );
                    this.bools[i] = temp;
                }
            }
            for (int j = 0; j < answers.Count; j++, i++)
            {
                if(answers[j] == obj_quiz[j].answer)
                {
                    this.NumberOfCorrect++;
                    AhShitHereWeGoAgain[i] = true;
                }
                else
                {
                    this.answers[j] = obj_quiz[j].answer;
                }
            }
        }
        public int NumberOfCorrect { get; set; }
        public int NumberOfTests   { get; set; }

        public ObservableCollection<bool> AhShitHereWeGoAgain      { get; set; }

        public ObservableCollection<Quadro<bool,bool,bool,bool>> bools { get; set; }
        public ObservableCollection<string> answers { get; set; }


        #endregion

#region [FUNCTIONS]
        void InitializationComponents()
        {
            this.random_seed = Guid.NewGuid().GetHashCode();

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

        void Clear() {
            for (var i = 0; i < 9; i++)
            {
                this.bools[i] = new (false, false, false, false);
            }
            for (var i = 0; i < 3; i++)
            {
                this.answers[i] = string.Empty;
            }

            for (var i = 0; i < NumberOfTests; i++)
            {
                this.AhShitHereWeGoAgain[i] = false;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        async void PearsonOpenBody()
        {
            this.Loading = true;

            await Task.Run(()=> this.obj_common = this.repository.GetPearsonCommonTest());
            await Task.Run(() => this.obj_multitest = this.repository.GetPearsonMultitestTest());
            await Task.Run(() => this.obj_quiz = this.repository.GetPearsonQuizTest());

            // DON'T MOVE THIS TO ANOTHER POSITION
            this.HeaderText = this.repository.GetNamePearson();

            InitializationComponents();

            this.IsTestChosen = true;

            DummyTheoryRepository.Instance.IsThroll = true;
            this.Loading                            = false;
        }
        async void SavageOpenBody()
        {
            this.Loading = true;

            await Task.Run(() => this.obj_common = this.repository.GetSavageCommonTest());
            await Task.Run(() => this.obj_multitest = this.repository.GetSavageMultitestTest());
            await Task.Run(() => this.obj_quiz = this.repository.GetSavageQuizTest());
            // DON'T MOVE THIS TO ANOTHER POSITION
            this.HeaderText = this.repository.GetNameSavage();

            InitializationComponents();

            this.IsTestChosen = true;

            DummyTheoryRepository.Instance.IsThroll = true;
            this.Loading                            = false;
        }
        #endregion

    }
}
