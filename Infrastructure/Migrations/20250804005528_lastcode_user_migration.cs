using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiAll.Migrations
{
    /// <inheritdoc />
    public partial class lastcode_user_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastCode",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCode",
                table: "Users");
        }
    }
}
