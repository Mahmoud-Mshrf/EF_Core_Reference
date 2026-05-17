using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelectOneItem.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Symbol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Sector = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Industry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Balance = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
