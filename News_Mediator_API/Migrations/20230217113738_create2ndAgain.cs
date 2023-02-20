using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsMediatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class create2ndAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMark_News",
                table: "BookMark");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMark_Users",
                table: "BookMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookMark",
                table: "BookMark");

            migrationBuilder.DropIndex(
                name: "IX_BookMark_NewsId",
                table: "BookMark");

            migrationBuilder.RenameTable(
                name: "BookMark",
                newName: "BookMarks");

            migrationBuilder.RenameIndex(
                name: "IX_BookMark_UserId",
                table: "BookMarks",
                newName: "IX_BookMarks_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "News",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "News",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BookMarks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BookMarks",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookMarks",
                table: "BookMarks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookMarks_NewsId_UserId",
                table: "BookMarks",
                columns: new[] { "NewsId", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_News_NewsId",
                table: "BookMarks",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Users_UserId",
                table: "BookMarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_News_NewsId",
                table: "BookMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Users_UserId",
                table: "BookMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookMarks",
                table: "BookMarks");

            migrationBuilder.DropIndex(
                name: "IX_BookMarks_NewsId_UserId",
                table: "BookMarks");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "News");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BookMarks");

            migrationBuilder.RenameTable(
                name: "BookMarks",
                newName: "BookMark");

            migrationBuilder.RenameIndex(
                name: "IX_BookMarks_UserId",
                table: "BookMark",
                newName: "IX_BookMark_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "News",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "News",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BookMark",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookMark",
                table: "BookMark",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookMark_NewsId",
                table: "BookMark",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMark_News",
                table: "BookMark",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMark_Users",
                table: "BookMark",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
