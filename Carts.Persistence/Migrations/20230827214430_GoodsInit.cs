using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carts.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GoodsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodName = table.Column<string>(type: "text", nullable: false),
                    GoodImg = table.Column<string>(type: "text", nullable: false),
                    GoodPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodId",
                table: "Goods",
                column: "GoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
