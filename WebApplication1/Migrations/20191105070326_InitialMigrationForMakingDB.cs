using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MijiKalaWebApp.Migrations
{
    public partial class InitialMigrationForMakingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Slogan = table.Column<string>(nullable: true, defaultValue: "-خالی-"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ImgSource = table.Column<string>(nullable: true, defaultValue: "-خالی-"),
                    DiscountPercentage = table.Column<int>(nullable: false, defaultValue: 0),
                    Category = table.Column<int>(nullable: false),
                    HtmlProductDemonstration = table.Column<string>(nullable: true, defaultValue: "-خالی-")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
