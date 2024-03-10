using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonRegister.Migrations
{
    public partial class CreatedRegionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RegionId",
                table: "Persons",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Regions_RegionId",
                table: "Persons",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Regions_RegionId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RegionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");
        }
    }
}
