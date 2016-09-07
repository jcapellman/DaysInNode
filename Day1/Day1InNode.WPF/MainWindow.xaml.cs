using System.Windows;

using Day1InNode.WPF.ViewModels;

namespace Day1InNode.WPF {    
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            DataContext = new MainWindowModel();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            ((MainWindowModel)DataContext).RunBenchmark(false);
        }

        private void btnRunWebAPI_OnClick(object sender, RoutedEventArgs e) {
            ((MainWindowModel)DataContext).RunBenchmark(true);
        }
    }
}