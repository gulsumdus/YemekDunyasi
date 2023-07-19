using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekDünyasi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantTable_CategoryTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTable_RestaurantTable_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTable_UsersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTable_RestaurantTable_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemTable",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemTable", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItemTable_OrderTable_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemTable_ProductTable_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSepetTable",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSepetTable", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_UserSepetTable_ProductTable_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSepetTable_UsersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Döner" },
                    { 2, "Burger" },
                    { 3, "Tavuk" },
                    { 4, "Pasta&Tatlı" },
                    { 5, "Tost&Sandviç" },
                    { 6, "Sokak Lezzetleri" },
                    { 7, "Kebap" },
                    { 8, "Pizza" },
                    { 9, "Pide" },
                    { 10, "Kahvaltı" },
                    { 11, "Lahmacun" },
                    { 12, "Ev yemekleri" },
                    { 13, "Kahve" },
                    { 14, "Vejetaryen" },
                    { 15, "Dünya Mutfağı" },
                    { 16, "Köfte" },
                    { 17, "Börek" },
                    { 18, "Çiğ Köfte" },
                    { 19, "Salata" },
                    { 20, "İçecek" },
                    { 21, "Deniz Ürünleri" },
                    { 22, "Dondurma" }
                });

            migrationBuilder.InsertData(
                table: "UsersTable",
                columns: new[] { "Id", "Adress", "Email", "Name", "Surname", "TelNo" },
                values: new object[,]
                {
                    { 1, "Batıkent", "Durayse@gmail.com", "Ayşe", "Duran", "05434346578" },
                    { 2, "Ümitköy", "Durayse@gmail.com", "Ai", "Kaşcı", "05434346578" },
                    { 3, "Çamlıca", "ahmet1987@gmail.com", "Ahmet", "Satır", "05434346579" },
                    { 4, "Sıhiyye", "12345@gmail.com", "Kemal", "Kuru", "05434346574" },
                    { 5, "Ulus", "sk1234@gmail.com", "Selvi", "Kara", "05434346573" },
                    { 6, "Etimesgut", "2Mel@gmail.com", "Melih", "Mutlu", "05434346575" },
                    { 7, "Bahçelievler", "taskadir@gmail.com", "Kadir", "Taş", "05434346570" },
                    { 8, "Emek", "elifs@gmail.com", "Elif", "Salkım", "05434346572" },
                    { 9, "Mamak", "daylin@gmail.com", "aylin", "Durmuş", "05434346571" },
                    { 10, "Batımerkez", "kalden@gmail.com", "Deniz", "Kaleci", "05434346576" }
                });

            migrationBuilder.InsertData(
                table: "OrderTable",
                columns: new[] { "Id", "OrderDate", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(742), null, 1 },
                    { 2, new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(743), null, 2 },
                    { 3, new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(744), null, 3 },
                    { 4, new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(745), null, 4 },
                    { 5, new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(746), null, 5 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantTable",
                columns: new[] { "Id", "Address", "CategoryId", "Name", "TelNo" },
                values: new object[,]
                {
                    { 111, "Batıkent", 1, "Ala kebap", "08505678990" },
                    { 112, "Kızılay", 7, "Lezzet Sofrası", "03123456789" },
                    { 113, "Çankaya", 8, "Pizza Evi", "03127894561" },
                    { 114, "Bahçelievler", 2, "Burger Land", "03125678321" },
                    { 115, "Gölbaşı", 21, "Deniz Mahsülleri", "03123450987" },
                    { 116, "Etimesgut", 5, "Tost Köşesi", "03127895678" },
                    { 117, "Tunalı Hilmi", 13, "Kahve Dünyası", "03125678901" },
                    { 118, "Ankara Üniversitesi", 9, "Pideci Baba", "03123456789" },
                    { 119, "Yıldırım Beyazıt Üniversitesi", 10, "Kahvaltı Bahçesi", "03127894567" },
                    { 120, "Cebeci", 11, "Lahmacun Dükkanı", "03125678912" }
                });

            migrationBuilder.InsertData(
                table: "ProductTable",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "İskender", 120m, 111 },
                    { 2, "Kuzu Şiş", 120m, 111 },
                    { 3, "Tavuk Şiş", 120m, 111 },
                    { 4, "Lokma", 120m, 111 },
                    { 5, "Alinazik", 120m, 111 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemTable_ProductId",
                table: "OrderItemTable",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_RestaurantId",
                table: "OrderTable",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_UserId",
                table: "OrderTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_RestaurantId",
                table: "ProductTable",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTable_CategoryId",
                table: "RestaurantTable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSepetTable_ProductId",
                table: "UserSepetTable",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemTable");

            migrationBuilder.DropTable(
                name: "UserSepetTable");

            migrationBuilder.DropTable(
                name: "OrderTable");

            migrationBuilder.DropTable(
                name: "ProductTable");

            migrationBuilder.DropTable(
                name: "UsersTable");

            migrationBuilder.DropTable(
                name: "RestaurantTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");
        }
    }
}
