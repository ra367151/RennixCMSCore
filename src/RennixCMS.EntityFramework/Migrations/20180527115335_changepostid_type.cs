using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RennixCMS.EntityFramework.Migrations
{
    public partial class changepostid_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId1",
                table: "Comment",
                column: "PostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId1",
                table: "Comment",
                column: "PostId1",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
