namespace OracleConnectionTest.Services;

public static class QueryExecutorFactory
{
    public static IQueryExecutor CreateQueryExecutor(int choice)
    {
        return choice switch
        {
            1 => new OracleVersionQueryExecutor(),
            2 => new OracleTopQueriesQueryExecutor(),
            3 => new OracleQueryPlanQueryExecutor(),
            _ => throw new NotImplementedException()
        };
    }
}