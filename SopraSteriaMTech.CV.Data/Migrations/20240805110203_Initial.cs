using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SopraSteriaMTech.Cv.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Personalia",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Personalia", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Cv",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PersonaliaId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cv", x => x.Id);
                table.ForeignKey(
                    name: "FK_Cv_Personalia_PersonaliaId",
                    column: x => x.PersonaliaId,
                    principalTable: "Personalia",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Cursus",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Instituut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                Certificaat = table.Column<bool>(type: "bit", nullable: true),
                CvId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cursus", x => x.Id);
                table.ForeignKey(
                    name: "FK_Cursus_Cv_CvId",
                    column: x => x.CvId,
                    principalTable: "Cv",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Kennis",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Kennisgebied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Kennisniveau = table.Column<int>(type: "int", nullable: false),
                Jaren = table.Column<int>(type: "int", nullable: false),
                CvId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Kennis", x => x.Id);
                table.ForeignKey(
                    name: "FK_Kennis_Cv_CvId",
                    column: x => x.CvId,
                    principalTable: "Cv",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Opleiding",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Niveau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumVan = table.Column<DateTime>(type: "datetime2", nullable: false),
                DatumTm = table.Column<DateTime>(type: "datetime2", nullable: true),
                Diploma = table.Column<bool>(type: "bit", nullable: false),
                CvId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Opleiding", x => x.Id);
                table.ForeignKey(
                    name: "FK_Opleiding_Cv_CvId",
                    column: x => x.CvId,
                    principalTable: "Cv",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Taal",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Schriftelijk = table.Column<int>(type: "int", nullable: false),
                Mondeling = table.Column<int>(type: "int", nullable: false),
                CvId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Taal", x => x.Id);
                table.ForeignKey(
                    name: "FK_Taal_Cv_CvId",
                    column: x => x.CvId,
                    principalTable: "Cv",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Werkervaring",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DatumVan = table.Column<DateTime>(type: "datetime2", nullable: false),
                DatumTm = table.Column<DateTime>(type: "datetime2", nullable: true),
                Organisatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Functie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CvId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Werkervaring", x => x.Id);
                table.ForeignKey(
                    name: "FK_Werkervaring_Cv_CvId",
                    column: x => x.CvId,
                    principalTable: "Cv",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Cursus_CvId",
            table: "Cursus",
            column: "CvId");

        migrationBuilder.CreateIndex(
            name: "IX_Cv_PersonaliaId",
            table: "Cv",
            column: "PersonaliaId");

        migrationBuilder.CreateIndex(
            name: "IX_Kennis_CvId",
            table: "Kennis",
            column: "CvId");

        migrationBuilder.CreateIndex(
            name: "IX_Opleiding_CvId",
            table: "Opleiding",
            column: "CvId");

        migrationBuilder.CreateIndex(
            name: "IX_Taal_CvId",
            table: "Taal",
            column: "CvId");

        migrationBuilder.CreateIndex(
            name: "IX_Werkervaring_CvId",
            table: "Werkervaring",
            column: "CvId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Cursus");

        migrationBuilder.DropTable(
            name: "Kennis");

        migrationBuilder.DropTable(
            name: "Opleiding");

        migrationBuilder.DropTable(
            name: "Taal");

        migrationBuilder.DropTable(
            name: "Werkervaring");

        migrationBuilder.DropTable(
            name: "Cv");

        migrationBuilder.DropTable(
            name: "Personalia");
    }
}
