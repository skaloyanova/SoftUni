using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonRegister.Migrations
{
    public partial class CreatedAssosiationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssociationsPerson",
                columns: table => new
                {
                    AssociationsId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationsPerson", x => new { x.AssociationsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_AssociationsPerson_Associations_AssociationsId",
                        column: x => x.AssociationsId,
                        principalTable: "Associations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationsPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociationsPerson_PersonsId",
                table: "AssociationsPerson",
                column: "PersonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationsPerson");

            migrationBuilder.DropTable(
                name: "Associations");
        }
    }
}
