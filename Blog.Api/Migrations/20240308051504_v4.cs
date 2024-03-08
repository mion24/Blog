using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerID",
                table: "Post",
                type: "VARCHAR(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(32)",
                oldMaxLength: 32);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerID",
                table: "Post",
                type: "VARCHAR(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(36)",
                oldMaxLength: 36);
        }
    }
}
