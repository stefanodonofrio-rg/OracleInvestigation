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
        var con = new OracleConnection(OracleParameters.ConnectionString);
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = commandText;
     
        var reader = cmd.ExecuteReader();
        reader.Read();
        Console.WriteLine(reader.GetString(0));
    }
}