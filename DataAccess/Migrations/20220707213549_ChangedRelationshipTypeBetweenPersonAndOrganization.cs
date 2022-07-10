using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations;

public partial class ChangedRelationshipTypeBetweenPersonAndOrganization : Migration
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
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_People", x => x.Id);
                table.ForeignKey(
                    name: "FK_People_Organizations_OrganizationId",
                    column: x => x.OrganizationId,
                    principalTable: "Organizations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "LoginInformation",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LoginInformation", x => x.Id);
                table.ForeignKey(
                    name: "FK_LoginInformation_People_PersonId",
                    column: x => x.PersonId,
                    principalTable: "People",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_LoginInformation_PersonId",
            table: "LoginInformation",
            column: "PersonId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_People_OrganizationId",
            table: "People",
            column: "OrganizationId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "LoginInformation");

        migrationBuilder.DropTable(
            name: "People");

        migrationBuilder.DropTable(
            name: "Organizations");
    }
}
