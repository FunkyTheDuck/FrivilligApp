using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class addjointable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsInfo_Events_EventId",
                table: "EventsInfo");

            migrationBuilder.DropIndex(
                name: "IX_EventsInfo_EventId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "EventsInfo");

            migrationBuilder.AddColumn<double>(
                name: "LocationX",
                table: "UserInfo",
                type: "float",
                maxLength: 50,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LocationY",
                table: "UserInfo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CoordinateX",
                table: "EventsInfo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CoordinateY",
                table: "EventsInfo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "EventInfoId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventInfoId",
                table: "Events",
                column: "EventInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventsInfo_EventInfoId",
                table: "Events",
                column: "EventInfoId",
                principalTable: "EventsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventsInfo_EventInfoId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventInfoId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocationX",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "LocationY",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "CoordinateX",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "CoordinateY",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "EventInfoId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "InterestsId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventsInfo",
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

            migrationBuilder.CreateIndex(
                name: "IX_EventsInfo_EventId",
                table: "EventsInfo",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsInfo_Events_EventId",
                table: "EventsInfo",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
