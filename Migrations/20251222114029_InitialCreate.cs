using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAssessment.WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            // migrationBuilder.CreateTable(
            //     name: "Products",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //         Des = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //         ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         UnitPrice = table.Column<double>(type: "float", nullable: false),
            //         Likes = table.Column<int>(type: "int", nullable: false),
            //         Quantity = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Products", x => x.Id);
            //     });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
