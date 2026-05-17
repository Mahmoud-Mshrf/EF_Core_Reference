using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Scaffolding
{
    internal class Instructions
    {
        /* Steps To Make EF Core Model & Code from DB Schema Database-Scaffolding [ReverseEngineering]:
         * - Open Package Manager console (PMC):
         *      Tools -> NUget Package Manager -> Package Manager Console
         *      
         * - In PMC :
         *      Install-Package Microsoft.EntityFrameworkCore.Tools
         *      Install-Package Microsoft.EntityFrameworkCore.Design
         *      Install-Package Microsoft.EntityFrameworkCore.SqlServer
         * 
         * - Run Command:
         *      Scaffold-DbContext 'Connection String' Provider 
         *      EX: Scaffold-DbContext ' Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS ; Initial Catalog=TechTalk ;  Integrated Security= SSPI; TrustServerCertificate= True; Microsoft.EntityFrameworkCore.SqlServer
         *       
         *       We can make it more specialized:
         *       
         *       -DataAnnotations :make the configuration be DataAnnotation based
         *       -Context AppDbContext: Name the context class  (AppDbContext) 
         *       -ContextDir Data : put the context class in Data Folder 
         *       -OutputDir Entities : put the Entities in Entities folder
         *       -Tables TableName : Include this table only and doesn't include the others tables
         *       
         *       Full Example:
         *        Scaffold-DbContext ' Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS ; Initial Catalog=TechTalk ;  Integrated Security= SSPI; TrustServerCertificate= True;' Microsoft.EntityFrameworkCore.SqlServer -DataAnnotations -Context AppDbContext -ContextDir Data -OutputDir Entities 
         */ 


        /* Using .NET CLI:
         * Steps To Make EF Core Model & Code from DB Schema:
         * Install Microsoft.EntityFrameworkCore.Tools
         * Install Microsoft.EntityFrameworkCore.SqlServer 
         * on this project 
         * then go to the dirictory of this project and open Command Prompt
         * Install EF Core Globally:
         * dotnet tool install --global dotnet-ef (if new )
         * dotnet tool upgrade --global dotnet-ef (if exists)
         * 
         * Run Command:
         * dotnet ef dbcontext scaffold 'Connection String' provider 
         * EX:
         * dotnet ef dbcontext scaffold 'Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS ; Initial Catalog=TechTalk ;  Integrated Security= SSPI; TrustServerCertificate= True;' Microsoft.EntityFrameworkCore.SqlServer
         * 
         * to make it more specialized :
         * --context contextname: make the context class with this name 
         * --context-dir contextDirName: put the context in folder with this name
         * --output-dir entitiesDirName: put entities in folder with this name
         * --Table tableName: Include only this table
         */
    }
}
