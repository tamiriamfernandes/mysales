using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_Client_Add_Phone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Client",
                type: "varchar(11)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Client");
        }
    }
}
