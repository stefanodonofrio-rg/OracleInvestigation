using Oracle.ManagedDataAccess.Client;

namespace OracleConnectionTest.Services;

public class OracleVersionQueryExecutor : IQueryExecutor
{
    public void Execute()
    {
        var commandText = "select con_id, name, open_mode, total_size from v$pdbs";
        using var con = new OracleConnection(OracleParameters.ConnectionString);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = commandText;
     
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.Write(reader["PRODUCT"]+ " ");
            Console.Write(reader["VERSION"]+ " ");
            Console.Write(reader["VERSION_FULL"]+ " ");
            Console.WriteLine(reader["STATUS"]);
        }
    }
}