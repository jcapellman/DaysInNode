namespace DayInNode.WPF.Benchmarks {
    public class ASPNETRedisDBBenchmark : BaseBenchmark {
        public override string GetName() => "ASP.NET WebAPI with redis";

        public override int GetPort() => 1337;
    }
}