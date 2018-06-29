using Microsoft.EntityFrameworkCore.Migrations;

namespace RennixCMS.EntityFramework.Migrations
{
    public partial class add_contenthtml_to_post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentHTML",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentHTML",
                table: "Post");
        }
    }
}
