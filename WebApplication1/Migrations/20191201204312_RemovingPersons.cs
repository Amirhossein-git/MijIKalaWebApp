using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MijiKalaWebApp.Migrations
{
    public partial class RemovingPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItem_Products_ProductId",
                table: "WarehouseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItem_Warehouses_WarehouseId",
                table: "WarehouseItem");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseItem",
                table: "WarehouseItem");

            migrationBuilder.RenameTable(
                name: "WarehouseItem",
                newName: "WarehouseItems");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItem_WarehouseId",
                table: "WarehouseItems",
                newName: "IX_WarehouseItems_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItem_ProductId",
                table: "WarehouseItems",
                newName: "IX_WarehouseItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseItems",
                table: "WarehouseItems",
                column: "WraehouseItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Products_ProductId",
                table: "WarehouseItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Warehouses_WarehouseId",
                table: "WarehouseItems",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItems_Products_ProductId",
                table: "WarehouseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItems_Warehouses_WarehouseId",
                table: "WarehouseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseItems",
                table: "WarehouseItems");

            migrationBuilder.RenameTable(
                name: "WarehouseItems",
                newName: "WarehouseItem");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItems_WarehouseId",
                table: "WarehouseItem",
                newName: "IX_WarehouseItem_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItems_ProductId",
                table: "WarehouseItem",
                newName: "IX_WarehouseItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseItem",
                table: "WarehouseItem",
                column: "WraehouseItemId");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingUpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PersonId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItem_Products_ProductId",
                table: "WarehouseItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItem_Warehouses_WarehouseId",
                table: "WarehouseItem",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
