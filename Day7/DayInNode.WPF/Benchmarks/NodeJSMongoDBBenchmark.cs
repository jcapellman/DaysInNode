namespace DayInNode.WPF.Benchmarks {
    public class NodeJSMongoDBBenchmark : BaseBenchmark {
        public override string GetName() => "Node.js with MongoDB";

        public override int GetPort() => 1338;
    }
}