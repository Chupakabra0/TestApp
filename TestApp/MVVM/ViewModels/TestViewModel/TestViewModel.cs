using System.Windows;
using System.Windows.Input;
using TestApp.Core.Commands.RelayCommand;

namespace TestApp.MVVM.ViewModels.TestViewModel {
    class TestViewModel : BaseViewModel.BaseViewModel {
        public ICommand ButtonCommand
            => new RelayCommand(() => MessageBox.Show("It works perfectly!", "YES!!!"));
    }
}
