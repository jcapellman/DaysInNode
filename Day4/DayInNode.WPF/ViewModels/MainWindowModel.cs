using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace DayInNode.WPF.ViewModels {
    public class MainWindowModel : INotifyPropertyChanged {
        private string _benchmarkText;

        public string BenchmarkTest {
            get { return _benchmarkText; }
            set { _benchmarkText = value; OnPropertyChanged(); }
        }

        private static HttpClient httpClient = new HttpClient();

        private const int WebAPIPort = 1337;
        private const int NodeJSPort = 1338;

        private const int MAX_BENCH = 10000;

        private static string getURL(bool forWebAPI) {
            var port = forWebAPI ? WebAPIPort : NodeJSPort;

            return $"http://localhost:{port}/api/Test?id=2";
        }
        
        public bool RunBenchmark(bool forWebAPI) {
            BenchmarkTest = string.Empty;

            for (var x = 10; x < MAX_BENCH; x *= 2) {
                runBench(x, forWebAPI);
            }

            return true;
        }
        
        private async void runBench(int numIterations, bool forWebAPI) {
            var start = DateTime.Now;

            for (var x = 0; x < numIterations; x++) {
                var result = await httpClient.GetStringAsync(getURL(forWebAPI));
            }

            BenchmarkTest += "Completed " + (forWebAPI ? "WebAPI" : "NodeJS") + " Test for " + numIterations +
                             " iterations in " + $"Completed in {DateTime.Now.Subtract(start).TotalSeconds}" +
                             System.Environment.NewLine;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}