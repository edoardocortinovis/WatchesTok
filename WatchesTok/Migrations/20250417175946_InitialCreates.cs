using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchesTok.Migrations
{
    public partial class InitialCreates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElePost_EleOrologi_OrologioID",
                table: "ElePost");

            migrationBuilder.AlterColumn<int>(
                name: "OrologioID",
                table: "ElePost",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ElePost_EleOrologi_OrologioID",
                table: "ElePost",
                column: "OrologioID",
                principalTable: "EleOrologi",
                principalColumn: "OrologioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElePost_EleOrologi_OrologioID",
                table: "ElePost");

            migrationBuilder.AlterColumn<int>(
                name: "OrologioID",
                table: "ElePost",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ElePost_EleOrologi_OrologioID",
                table: "ElePost",
                column: "OrologioID",
                principalTable: "EleOrologi",
                principalColumn: "OrologioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
