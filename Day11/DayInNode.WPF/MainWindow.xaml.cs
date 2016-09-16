using System.Windows;

using DayInNode.WPF.ViewModels;

namespace DayInNode.WPF {
    public partial class MainWindow : Window {
        private MainWindowModel viewModel => (MainWindowModel)DataContext;

        public MainWindow() {
            InitializeComponent();

            DataContext = new MainWindowModel();

            viewModel.LoadBenchmarks();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            viewModel.RunBenchmark();
        }
    }
}