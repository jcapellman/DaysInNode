namespace DayInNode.WPF.Benchmarks {
    public class ASPNETSQLServerBenchmark : BaseBenchmark {
        public override string GetName() => "ASP.NET WebAPI with SQL Server";

        public override string MethodName() => "TestSQLServer";

        public override int GetPort() => 1337;
    }
}