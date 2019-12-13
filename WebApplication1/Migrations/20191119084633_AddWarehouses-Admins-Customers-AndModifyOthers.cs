using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MijiKalaWebApp.Migrations
{
    public partial class AddWarehousesAdminsCustomersAndModifyOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentText",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "CommentText",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    MobilePhoneNumber = table.Column<string>(nullable: true),
                    HomePhoneNumber = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    MobilePhoneNumber = table.Column<string>(nullable: true),
                    HomePhoneNumber = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    SingUpDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseItem",
                columns: table => new
                {
                    WraehouseItemId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    NumberInWarehouse = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseItem", x => x.WraehouseItemId);
                    table.ForeignKey(
                        name: "FK_WarehouseItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItem_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItem_ProductId",
                table: "WarehouseItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItem_WarehouseId",
                table: "WarehouseItem",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "WarehouseItem");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CommentText",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "ComentText",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
