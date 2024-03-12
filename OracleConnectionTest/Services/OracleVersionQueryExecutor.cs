using Oracle.ManagedDataAccess.Client;

namespace OracleConnectionTest.Services;

public class OracleVersionQueryExecutor : IQueryExecutor
{
    public void Execute()
    {
        var commandText = "SELECT PRODUCT, VERSION, VERSION_FULL, STATUS FROM PRODUCT_COMPONENT_VERSION";
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
            Console.Write(reader["PRODUCT"]+ " ");
            Console.Write(reader["VERSION"]+ " ");
            Console.Write(reader["VERSION_FULL"]+ " ");
            Console.WriteLine(reader["STATUS"]);
        }
    }
}