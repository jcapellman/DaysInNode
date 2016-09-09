using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DayInNode.WPF.Benchmarks {
    public abstract class BaseBenchmark {
        public abstract string GetName();

        public abstract int GetPort();

        private static readonly HttpClient httpClient = new HttpClient();

        public virtual string MethodName() => "Test";

        private string URL => $"http://localhost:{Port}/api/{MethodName()}?id=2";

        private const int MAX_BENCH = 100;
        
        public string Name => GetName();

        public int Port => GetPort();

        public async Task<string> RunBenchmark() {
            var start = DateTime.Now;

            var benchString = $"--Starting {Name} test @ {start}--{System.Environment.NewLine}";

            for (var x = 10; x < MAX_BENCH; x *= 2) {
                benchString += await RunBench(x);
            }

            benchString += $"--Completed {Name} test in {DateTime.Now.Subtract(start).TotalSeconds} seconds--";

            return benchString;
        }

        public async Task<string> RunBench(int numIterations) {
            var start = DateTime.Now;
            
            for (var x = 0; x < numIterations; x++) {
                var result = await httpClient.GetStringAsync(URL);
            }

            return $"Completed {numIterations} iterations in {DateTime.Now.Subtract(start).TotalSeconds} seconds {System.Environment.NewLine}";
        }
    }
}