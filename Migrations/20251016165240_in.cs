using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_api.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Blogs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Blogs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Blogs",
                newName: "Content");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Blogs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Blogs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blogs",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Blogs",
                newName: "content");

            migrationBuilder.AlterColumn<Guid>(
                name: "userId",
                table: "Blogs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
