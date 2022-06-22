using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Organizations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Organizations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "People",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_People", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "OrganizationPerson",
            columns: table => new
            {
                OrganizationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrganizationPerson", x => new { x.OrganizationsId, x.PeopleId });
                table.ForeignKey(
                    name: "FK_OrganizationPerson_Organizations_OrganizationsId",
                    column: x => x.OrganizationsId,
                    principalTable: "Organizations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_OrganizationPerson_People_PeopleId",
                    column: x => x.PeopleId,
                    principalTable: "People",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_OrganizationPerson_PeopleId",
            table: "OrganizationPerson",
            column: "PeopleId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OrganizationPerson");

        migrationBuilder.DropTable(
            name: "Organizations");

        migrationBuilder.DropTable(
            name: "People");
    }
}
