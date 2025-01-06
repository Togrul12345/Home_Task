using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_AppUserId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AppUserId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AppUserId",
                table: "Product",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_AppUserId",
                table: "Product",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_AppUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AppUserId",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AppUserId1",
                table: "Product",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_AppUserId1",
                table: "Product",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
