using System.Windows.Documents;
using System.Windows.Input;
using TestApp.Core.Commands.RelayCommand;
using TestApp.Core.Repository.Theory;

namespace TestApp.MVVM.ViewModels.TheoryViewModel
{
    public class TheoryViewModel : BaseViewModel.BaseViewModel {
        public TheoryViewModel() {
            this.TheoryRepository = DummyTheoryRepository.Instance;
        }

        public FlowDocument Document     { get; set; }
        public string       DocumentName { get; set; }

        public ITheoryRepository TheoryRepository { get; set; }

        public ICommand OpenSavageCommand =>
            new RelayCommand(() => {
                this.Document       = this.TheoryRepository?.GetSavageTheory();
                this.DocumentName   = this.TheoryRepository?.GetSavageName();
                this.IsTheoryChosen = true;
            });
        
        public ICommand OpenPearsonCommand =>
            new RelayCommand(() => {
                this.Document       = this.TheoryRepository?.GetPearsonTheory();
                this.DocumentName   = this.TheoryRepository?.GetPearsonName();
                this.IsTheoryChosen = true;
            });

        public ICommand BackCommand =>
            new RelayCommand(() => {
                this.Document       = null;
                this.DocumentName   = null;
                this.IsTheoryChosen = false;
            });

        public bool IsTheoryChosen { get; set; }
        public bool IsMenuEnabled  => !this.IsTheoryChosen;
    }
}
