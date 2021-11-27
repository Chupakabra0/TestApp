using System;
using System.Windows.Documents;

namespace TestApp.Core.Repository.Theory {
    public class DummyTheoryRepository : ITheoryRepository {
        private static readonly string SavageStr  = "<?xml version=\"1.0\"?>\r\n<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:controls=\"clr-namespace:WpfMath.Controls;assembly=WpfMath\"><Paragraph>\r\n                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce faucibus odio arcu, luctus\r\n                    vestibulum tortor congue in. Lorem ipsum dolor sit amet, consectetur,\r\n                    <InlineUIContainer BaselineAlignment=\"TextBottom\"><controls:FormulaControl Formula=\"\\sum d\\theta = \\tan^{-1}\\theta+C\" Scale=\"15\" SnapsToDevicePixels=\"True\"/></InlineUIContainer>\r\n                    adipiscing elit. Fusce nec lacinia neque. Donec malesuada, ligula non vestibulum cursus, urna purus\r\n                    pellentesque orci,\r\n                    aliquet accumsan dui velit ac justo.\r\n                </Paragraph><BlockUIContainer><controls:FormulaControl Formula=\"L = \\int_a^b \\sqrt{2f(x)}\" Scale=\"20\" SnapsToDevicePixels=\"True\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/></BlockUIContainer><Paragraph>\r\n                    Nulla vitae suscipit tellus. Nunc sit amet tortor fermentum, sollicitudin enim cursus, sagittis\r\n                    lacus. Pellentesque tincidunt massa nisl, nec tempor nulla\r\n                    consequat a. Proin pharetra neque vel dolor congue, at condimentum arcu varius. Sed vel luctus\r\n                    enim. Curabitur eleifend dui et arcu faucibus, sit amet\r\n                    vulputate libero suscipit.\r\n                </Paragraph><Paragraph>\r\n                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce faucibus odio arcu, luctus\r\n                    vestibulum tortor congue in. Lorem ipsum dolor sit amet, consectetur,\r\n                    <InlineUIContainer BaselineAlignment=\"TextBottom\"><controls:FormulaControl Formula=\"\\sum d\\theta = \\tan^{-1}\\theta+C\" Scale=\"12\" SnapsToDevicePixels=\"True\"/></InlineUIContainer>\r\n                    adipiscing elit. Fusce nec lacinia neque. Donec malesuada, ligula non vestibulum cursus, urna purus\r\n                    pellentesque orci,\r\n                    aliquet accumsan dui velit ac justo.\r\n                </Paragraph><BlockUIContainer><controls:FormulaControl Formula=\"L = \\int_a^b \\sqrt{2f(x)}\" Scale=\"20\" SnapsToDevicePixels=\"True\" VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"/></BlockUIContainer><Paragraph>\r\n                    Nulla vitae suscipit tellus. Nunc sit amet tortor fermentum, sollicitudin enim cursus, sagittis\r\n                    lacus. Pellentesque tincidunt massa nisl, nec tempor nulla\r\n                    consequat a. Proin pharetra neque vel dolor congue, at condimentum arcu varius. Sed vel luctus\r\n                    enim. Curabitur eleifend dui et arcu faucibus, sit amet\r\n                    vulputate libero suscipit.\r\n                </Paragraph></FlowDocument>\r\n";
        private static readonly string PearsonStr = SavageStr;
        private static readonly string ThrollStr = "<?xml version=\"1.0\"?>\r\n<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n<Paragraph TextAlignment=\"Center\" FontFamily=\"{StaticResource WorkSansBlack}\">\r\n                            <Bold>Слухай, а вправно ти це вигадав, я навіть спочатку не зрозумів, молодець...</Bold>\r\n                        </Paragraph>\r\n                        <Paragraph TextAlignment=\"Center\" FontFamily=\"{StaticResource WorkSansBlack}\">\r\n                            <Bold>Але списати тут не вийде(((</Bold>\r\n                        </Paragraph>\r\n                    </FlowDocument>";

        private static readonly Lazy<DummyTheoryRepository> lazy =
            new (() => new DummyTheoryRepository());

        private DummyTheoryRepository() {

        }

        public static DummyTheoryRepository Instance => DummyTheoryRepository.lazy.Value;

        public FlowDocument GetSavageTheory() {
            return this.IsThroll ?
                System.Windows.Markup.XamlReader.Parse(DummyTheoryRepository.ThrollStr) as FlowDocument : 
                System.Windows.Markup.XamlReader.Parse(DummyTheoryRepository.SavageStr) as FlowDocument;
        }

        public FlowDocument GetPearsonTheory() {
            return this.IsThroll ?
                System.Windows.Markup.XamlReader.Parse(DummyTheoryRepository.ThrollStr) as FlowDocument :
                System.Windows.Markup.XamlReader.Parse(DummyTheoryRepository.PearsonStr) as FlowDocument;
        }

        public bool IsThroll { get; set; }
    }
}
