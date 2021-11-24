using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using TestApp.Core.Commands.RelayCommand;
using TestLibrary;

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

        private string desc_1 =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><TextBlock Style=\"{StaticResource Content}\">Нехай маємо матрицю S. Знайдіть (вкажіть номер), чому дорівнює α<Run BaselineAlignment=\"TextTop\">*</Run>, якщо матриця S має наступний вигляд:</TextBlock><Controls:FormulaControl Style=\"{StaticResource BasicFormula}\" HorizontalAlignment=\"Center\" Formula=\"Q = \\pmatrix{7 &amp; 2 &amp; 8 \\cr 3 &amp; 9 &amp; 4 \\cr 1 &amp; 6 &amp; 0 }\" Margin=\"20\" Scale=\"25\"></Controls:FormulaControl></StackPanel>";
        public object RB_Desc_1 => XamlReader.Parse(this.desc_1);

        private string a1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Controls:FormulaControl Scale=\"20\" Style=\"{StaticResource BasicFormula}\" Formula=\"x l'_{i 1} + (1 - x) l'_{j 1} = x l'_{i 2} + (1 - x) l'_{j 2}\"></Controls:FormulaControl></StackPanel>";
        public object RB_a1_Content => XamlReader.Parse(this.a1_content);
        public bool RB_a1_Checked { get; set; }

        private string b1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Controls:FormulaControl Scale=\"20\" Style=\"{StaticResource BasicFormula}\" Formula=\"x l'_{i 1} + (1 - x) l'_{j 1} = 0\"></Controls:FormulaControl></StackPanel>";
        public object RB_b1_Content => XamlReader.Parse(this.b1_content);
        public bool RB_b1_Checked { get; set; }

        private string c1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><TextBlock Style=\"{StaticResource BoxText}\">По осі абсцис відкладаємо втрати, відповідні β<Run BaselineAlignment=\"Subscript\">2</Run>, по осі ординат відповідні втрати при β<Run BaselineAlignment=\"Subscript\">1</Run></TextBlock></StackPanel>";
        public object RB_c1_Content => XamlReader.Parse(this.c1_content);
        public bool RB_c1_Checked { get; set; }

        private string d1_content =
            "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:Controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><TextBlock Style=\"{StaticResource BoxText}\">По осі абсцис відкладаємо втрати, відповідні β<Run BaselineAlignment=\"Subscript\">2</Run>, по осі ординат відповідні втрати при β<Run BaselineAlignment=\"Subscript\">1</Run></TextBlock></StackPanel>";
        public object RB_d1_Content => XamlReader.Parse(this.d1_content);
        public bool RB_d1_Checked { get; set; }

        //--------------------- MULTITESTS -----------------------------//



        //--------------------- QUESTION -----------------------------//


    }
}
