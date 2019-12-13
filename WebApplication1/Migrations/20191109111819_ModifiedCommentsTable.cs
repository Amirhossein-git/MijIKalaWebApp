using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MijiKalaWebApp.Migrations
{
    public partial class ModifiedCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentTitle",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentTitle",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "Comments");
        }
    }
}
