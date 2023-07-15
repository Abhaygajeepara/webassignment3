using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_assignment3.Migrations
{
    /// <inheritdoc />
    public partial class update_table_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Cart");
        }
    }
}
