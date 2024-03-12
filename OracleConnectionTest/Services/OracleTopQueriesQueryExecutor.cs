using Oracle.ManagedDataAccess.Client;

namespace OracleConnectionTest.Services;

public class OracleTopQueriesQueryExecutor : IQueryExecutor
{
    public void Execute()
    {
        var commandText =
            "SELECT SQL_TEXT ,EXECUTIONS , CPU_TIME , BUFFER_GETS , DISK_READS  from (SELECT * FROM v$sqlarea) WHERE rownum <10";
        
        Console.WriteLine("Executing the following query:");
        Console.WriteLine(commandText);
        Console.WriteLine("...");
        Console.WriteLine("The result is:");
        using var con = new OracleConnection(OracleParameters.ConnectionString);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = commandText;
     
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.Write(reader["SQL_TEXT"]+ " ");
            Console.Write(reader["EXECUTIONS"]+ " ");
            Console.Write(reader["CPU_TIME"]+ " ");
            Console.Write(reader["BUFFER_GETS"]+ " ");
            Console.WriteLine(reader["DISK_READS"]);
            Console.WriteLine();
        }
    }
}

