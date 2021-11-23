using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using TestApp.Core.Commands.RelayCommand;

namespace TestApp.MVVM.ViewModels.TestViewModel {
    public class TestViewModel : BaseViewModel.BaseViewModel {
        public TestViewModel() {

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

        //--------------------- TESTS -----------------------------//



        //--------------------- MULTITESTS -----------------------------//



        //--------------------- QUESTION -----------------------------//


    }
}
