using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class removejointable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterestsId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterestsId",
                table: "EventsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "EventsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "EventsInfo");
        }
    }
}
