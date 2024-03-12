using OracleConnectionTest.Services;

namespace OracleConnectionTest;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Goodmorning, NotNamedTeam!");
        Console.WriteLine("Chose the option you want to test:");
        Console.WriteLine("");
        Console.WriteLine("1. Check the Version of Oracle");
        Console.WriteLine("2. How do we sample queries?");
        Console.WriteLine("3. How do we sample QueryPlans?");
        Console.WriteLine();
        var choiceAsString = Console.ReadLine();
        var choice = int.Parse(string.IsNullOrEmpty(choiceAsString)? "0": choiceAsString);
        var queryExecutor = QueryExecutorFactory.CreateQueryExecutor(choice);
        queryExecutor.Execute();

    }
}