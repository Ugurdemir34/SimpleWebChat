using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleWebChat.DataAccess.Migrations
{
    public partial class IsAdmin_type_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "IsAdmin",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
