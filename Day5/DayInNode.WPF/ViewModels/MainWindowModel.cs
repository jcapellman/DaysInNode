using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

using DayInNode.WPF.Benchmarks;

namespace DayInNode.WPF.ViewModels {
    public class MainWindowModel : INotifyPropertyChanged {
        private ObservableCollection<BaseBenchmark> _benchmarks;

        public ObservableCollection<BaseBenchmark> Benchmarks {
            get { return _benchmarks; }
            set { _benchmarks = value; OnPropertyChanged(); }
        }

        private BaseBenchmark _selectedBenchmark;

        public BaseBenchmark SelectedBenchmark {
            get { return _selectedBenchmark; }
            set { _selectedBenchmark = value; OnPropertyChanged(); }
        }

        private bool _enableRunButton;

        public bool EnableRunButton
        {
            get { return _enableRunButton; }
            set { _enableRunButton = value; OnPropertyChanged(); }
        }

        private Visibility _progressIndicatorVisibility;

        public Visibility ProgressIndicatorVisibility {
            get { return _progressIndicatorVisibility; }
            set { _progressIndicatorVisibility = value; OnPropertyChanged();
                EnableRunButton = (value != Visibility.Visible);
            }
        }

        private string _benchmarkText;

        public string BenchmarkTestString {
            get { return _benchmarkText; }
            set { _benchmarkText = value; OnPropertyChanged(); }
        }
        
        public void LoadBenchmarks() {
            ProgressIndicatorVisibility = Visibility.Visible;

            Benchmarks = new ObservableCollection<BaseBenchmark>();

            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types.Where(type => type.IsSubclassOf(typeof(BaseBenchmark)))) {
                Benchmarks.Add((BaseBenchmark)Activator.CreateInstance(type));
            }

            if (!Benchmarks.Any()) {
                ProgressIndicatorVisibility = Visibility.Hidden;
                return;
            }

            SelectedBenchmark = Benchmarks.FirstOrDefault();

            ProgressIndicatorVisibility = Visibility.Hidden;
        }

        public async void RunBenchmark() {
            ProgressIndicatorVisibility = Visibility.Visible;

            BenchmarkTestString = await SelectedBenchmark.RunBenchmark();

            ProgressIndicatorVisibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}