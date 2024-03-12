namespace OracleConnectionTest.Services;

public static class QueryExecutorFactory
{
    public static IQueryExecutor CreateQueryExecutor(int choice)
    {
        return choice switch
        {
            1 => new OracleVersionQueryExecutor(),
            _ => throw new NotImplementedException()
        };
    }
}