using System.Windows.Controls;
using System.Windows.Input;
using TestApp.Core.Commands.RelayCommand;
using TestApp.MVVM.Views.BlankPage;
using TestApp.MVVM.Views.TestPage;

namespace TestApp.MVVM.ViewModels.MainViewModel {
    public class MainViewModel : BaseViewModel.BaseViewModel {
        public Page CurrentView { get; set; } = new BlankPage();

        public ICommand Command => new RelayCommand(this.Method);

        void Method() {
            this.CurrentView = new TestPage();
        }
    }
}
