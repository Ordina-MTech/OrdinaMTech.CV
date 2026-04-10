using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SopraSteriaMTech.Cv.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Cvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cvs_Personalia_PersonaliaId",
                        column: x => x.PersonaliaId,
                        principalTable: "Personalia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursussen",
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
                    table.PrimaryKey("PK_Cursussen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursussen_Cvs_CvId",
                        column: x => x.CvId,
                        principalTable: "Cvs",
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
                        name: "FK_Kennis_Cvs_CvId",
                        column: x => x.CvId,
                        principalTable: "Cvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opleidingen",
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
                    table.PrimaryKey("PK_Opleidingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opleidingen_Cvs_CvId",
                        column: x => x.CvId,
                        principalTable: "Cvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talen",
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
                    table.PrimaryKey("PK_Talen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talen_Cvs_CvId",
                        column: x => x.CvId,
                        principalTable: "Cvs",
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
                        name: "FK_Werkervaring_Cvs_CvId",
                        column: x => x.CvId,
                        principalTable: "Cvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursussen_CvId",
                table: "Cursussen",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_Cvs_PersonaliaId",
                table: "Cvs",
                column: "PersonaliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennis_CvId",
                table: "Kennis",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_Opleidingen_CvId",
                table: "Opleidingen",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_Talen_CvId",
                table: "Talen",
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
                name: "Cursussen");

            migrationBuilder.DropTable(
                name: "Kennis");

            migrationBuilder.DropTable(
                name: "Opleidingen");

            migrationBuilder.DropTable(
                name: "Talen");

            migrationBuilder.DropTable(
                name: "Werkervaring");

            migrationBuilder.DropTable(
                name: "Cvs");

            migrationBuilder.DropTable(
                name: "Personalia");
        }
    }
}
