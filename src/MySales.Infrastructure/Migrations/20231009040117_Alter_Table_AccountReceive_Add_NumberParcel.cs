using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_AccountReceive_Add_NumberParcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberParcel",
                table: "AccountsReceive",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberParcel",
                table: "AccountsReceive");
        }
    }
}
