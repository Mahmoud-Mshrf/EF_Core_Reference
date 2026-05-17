namespace Migrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    /*
     *  Migration Commands In VisualStudio & .NET_CLI  
     *  
     *  Add New Migration :- 
     *  VisualStudio :Add-Migration AddNewTables
     *  .NET_CLI :dotnet ef migrations add AddNewTables
     *  
     *  Updates your database to the latest migration:-
     *  VisualStudio :Update-Database
     *  .NET_CLI :dotnet ef database update
     *  
     *  Updates your database to a given migration:-
     *  VisualStudio :Update-Database AddNewTables
     *  .NET_CLI :dotnet ef database update AddNewTables
     *  
     *  Remove Last Migration:-
     *  VisualStudio :Remove-Migration
     *  .NET_CLI :dotnet ef migrations remove
     *  
     *  Generates a SQL script from a blank database to thelatest migration:-
     *  VisualStudio :Script-Migration
     *  .NET_CLI :dotnet ef migrations script
     *  
     *  Generates a SQL script from the given migration to the latest migration:-
     *  VisualStudio :Script-Migration AddNewTables
     *  .NET_CLI :dotnet ef migrations script AddNewTables
     *  
     *  Generates a SQL script from thespecified from migration to thespecified to migration:-
     *  VisualStudio :Script-Migration AddNewTables AddAuditTable
     *  .NET_CLI :dotnet ef migrations script AddNewTables AddAuditTable
     *  
     *  Listing migrations:-
     *  VisualStudio :Get-Migration
     *  .NET_CLI :dotnet ef migrations list
     *  
     */
}