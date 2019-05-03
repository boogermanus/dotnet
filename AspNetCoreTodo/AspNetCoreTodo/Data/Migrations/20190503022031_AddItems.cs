using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTodo.Data.Migrations
{
    public partial class AddItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DueAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                });

            migrationBuilder.CreateIndex("PK_Items", "Items","Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Items");
        }
    }
}
