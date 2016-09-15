namespace DayInNode.WPF.Benchmarks {
    public class ASPNETMongoDBBenchmark : BaseBenchmark {
        public override string GetName() => "ASP.NET WebAPI with MongoDB";

        public override int GetPort() => 1337;

        public override string MethodName() => "TestMongo";
    }
}