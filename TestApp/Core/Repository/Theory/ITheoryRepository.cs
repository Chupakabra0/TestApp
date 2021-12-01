using System.Windows.Documents;

namespace TestApp.Core.Repository.Theory {
    public interface ITheoryRepository {
        public FlowDocument GetSavageTheory();
        public FlowDocument GetPearsonTheory();

        public string GetSavageName();
        public string GetPearsonName();
    }
}
