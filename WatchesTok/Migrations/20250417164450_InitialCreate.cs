using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchesTok.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EleOrologi",
                columns: table => new
                {
                    OrologioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Modello = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Prezzo = table.Column<decimal>(type: "TEXT", nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ImmagineURL = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    AnnoProduzione = table.Column<int>(type: "INTEGER", nullable: true),
                    DataCreazione = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleOrologi", x => x.OrologioID);
                });

            migrationBuilder.CreateTable(
                name: "EleUtenti",
                columns: table => new
                {
                    UtenteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleUtenti", x => x.UtenteID);
                });

            migrationBuilder.CreateTable(
                name: "ElePost",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UtenteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Titolo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Hashtags = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MarcaModello = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MediaPath = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DataCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrologioID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElePost", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_ElePost_EleOrologi_OrologioID",
                        column: x => x.OrologioID,
                        principalTable: "EleOrologi",
                        principalColumn: "OrologioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElePost_EleUtenti_UtenteID",
                        column: x => x.UtenteID,
                        principalTable: "EleUtenti",
                        principalColumn: "UtenteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleCommenti",
                columns: table => new
                {
                    CommentiID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleCommenti", x => x.CommentiID);
                    table.ForeignKey(
                        name: "FK_EleCommenti_ElePost_PostId",
                        column: x => x.PostId,
                        principalTable: "ElePost",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleCommenti_EleUtenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "EleUtenti",
                        principalColumn: "UtenteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleLikes",
                columns: table => new
                {
                    LikeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostID = table.Column<int>(type: "INTEGER", nullable: false),
                    UtenteID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCreazione = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleLikes", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_EleLikes_ElePost_PostID",
                        column: x => x.PostID,
                        principalTable: "ElePost",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleLikes_EleUtenti_UtenteID",
                        column: x => x.UtenteID,
                        principalTable: "EleUtenti",
                        principalColumn: "UtenteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EleCommenti_PostId",
                table: "EleCommenti",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_EleCommenti_UtenteId",
                table: "EleCommenti",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_EleLikes_PostID",
                table: "EleLikes",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_EleLikes_UtenteID",
                table: "EleLikes",
                column: "UtenteID");

            migrationBuilder.CreateIndex(
                name: "IX_ElePost_OrologioID",
                table: "ElePost",
                column: "OrologioID");

            migrationBuilder.CreateIndex(
                name: "IX_ElePost_UtenteID",
                table: "ElePost",
                column: "UtenteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EleCommenti");

            migrationBuilder.DropTable(
                name: "EleLikes");

            migrationBuilder.DropTable(
                name: "ElePost");

            migrationBuilder.DropTable(
                name: "EleOrologi");

            migrationBuilder.DropTable(
                name: "EleUtenti");
        }
    }
}
