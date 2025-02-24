using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Purchase = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "text", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StockId = table.Column<int>(type: "integer", nullable: true),
                    StockModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_comment_tb_stock_StockModelId",
                        column: x => x.StockModelId,
                        principalTable: "tb_stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_comment_StockModelId",
                table: "tb_comment",
                column: "StockModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_comment");

            migrationBuilder.DropTable(
                name: "tb_stock");
        }
    }
}
