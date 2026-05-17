using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
     class Instructions
    {
        /* First Of All :
         * We Setup {EntityFramework.SqlServer , EntityFramework.Tools} Package on the project 
         * then make AppDbContext Class That inherit from DBContext Class
         * then we Override OnConfiguring Method in It and provide the connection string to it 
         * then we start Package Manager Console On the startup Project 
         * we Write This Command : add-migration "migration-name" example: add-migration initialCreate
         * then we write this command to apply this on the DataBase If It Exists Or Create it if it not exists:
         * update-database
         * 
         * then the created migration have two method :
         * UP: in this the created migration it represent the what this migration made or provide
         * DOWN: it represent the redo of the Down Method 
         * Example:
         *  protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "Employees",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Employees", x => x.Id);
                    });
            }

            /// <inheritdoc />
            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "Employees");
            }
           
         * if you want to remove the migration write this command:
         * remove-migration 
         * if the migration applied to database we write this command:
         * update-database migration:0      this if we want to return to the deafult case without any migration  this command by default calls the down method to return to the previous migration
         * 
         * if we have more than one migration and want to return to specific migration we writhe this command:
         * update-database "migrationName"
         * 
         * if we want to insert data in a migration we make a new migration and insert data in it :
         * write this command : add-migration addData   this make a new migration and in the up and down we insert and delete the data 
         * Example :
           protected override void Up(MigrationBuilder migrationBuilder)
           {
               migrationBuilder.Sql("insert into Employees values ('Employee 1') ");
           }

           /// <inheritdoc />
           protected override void Down(MigrationBuilder migrationBuilder)
           {
               migrationBuilder.Sql("delete from Employees where Name ='Employee 1'");
           }
         * then updata-database 
         * 
         * 
         */
    }
}
