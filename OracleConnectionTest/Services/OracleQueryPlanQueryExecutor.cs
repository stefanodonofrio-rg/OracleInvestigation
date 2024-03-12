using Oracle.ManagedDataAccess.Client;

namespace OracleConnectionTest.Services;

public class OracleQueryPlanQueryExecutor :IQueryExecutor
{
    public void Execute()
    {
        var commandText =
            "SELECT ADDRESS, HASH_VALUE, OPERATION FROM (SELECT * FROM V$SQL_PLAN) where ROWNUM <10";
        
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
            Console.Write(BitConverter.ToString(reader["ADDRESS"] as byte[]).Replace("-","")+ " "));
            Console.Write(reader["HASH_VALUE"]+ " ");
            Console.WriteLine(reader["OPERATION"]);
            Console.WriteLine();
        }    
    }
}