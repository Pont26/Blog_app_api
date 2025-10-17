using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_api.Migrations
{
    /// <inheritdoc />
    public partial class inf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Blogs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
