using System.Windows.Controls;
using System.Windows.Input;
using TestApp.Core.Commands.RelayCommand;
using TestApp.MVVM.Views.BlankPage;
using TestApp.MVVM.Views.TestPage;
using TestApp.MVVM.Views.HomePage;
using TestApp.MVVM.Views.SettingsPage;
using System;

namespace TestApp.MVVM.ViewModels.MainViewModel {
    public class MainViewModel : BaseViewModel.BaseViewModel {

        public string userFullName => Environment.UserName;

        public Page CurrentView { get; set; } = new HomePage();

        public ICommand Command_home => new RelayCommand(this.Open_home_page);
        public ICommand Command_theory => new RelayCommand(this.Open_theory_page);
        public ICommand Command_test => new RelayCommand(this.Open_test_page);
        public ICommand Command_settings => new RelayCommand(this.Open_settings_page);

        private Page TheoryPage = new BlankPage();
        private Page HomePage = new HomePage();
        private Page TestPage = new TestPage();
        private Page SettingsPage = new SettingsPage();

        #region [ OPEN PAGES ]
        void Open_home_page()
        {
            this.CurrentView = this.HomePage;
        }
        void Open_test_page()
        {
            this.CurrentView = this.TestPage;
        }
        void Open_theory_page()
        {
            this.CurrentView = this.TheoryPage;
        }
        void Open_settings_page()
        {
            this.CurrentView = this.SettingsPage;
        }
        #endregion
    }
}
