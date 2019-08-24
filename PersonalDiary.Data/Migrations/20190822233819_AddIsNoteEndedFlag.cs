using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalDiary.Data.Migrations
{
    public partial class AddIsNoteEndedFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNoteEnded",
                table: "PersonalDiaries",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNoteEnded",
                table: "PersonalDiaries");
        }
    }
}
