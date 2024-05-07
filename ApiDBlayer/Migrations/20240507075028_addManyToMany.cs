using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class addManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_EventsInfo_DtoEventInfoId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_UserInfo_DtoUserInfoId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_EventsInfo_DtoEventInfoId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_UserInfo_DtoUserInfoId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_DtoEventInfoId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_DtoUserInfoId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Interests_DtoEventInfoId",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_DtoUserInfoId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "DtoEventInfoId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DtoUserInfoId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DtoEventInfoId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "DtoUserInfoId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "InterestsId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "EventsInfo");

            migrationBuilder.CreateTable(
                name: "DtoEventInfoDtoInterests",
                columns: table => new
                {
                    EventInfoId = table.Column<int>(type: "int", nullable: false),
                    InterestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoEventInfoDtoInterests", x => new { x.EventInfoId, x.InterestsId });
                    table.ForeignKey(
                        name: "FK_DtoEventInfoDtoInterests_EventsInfo_EventInfoId",
                        column: x => x.EventInfoId,
                        principalTable: "EventsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DtoEventInfoDtoInterests_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DtoEventInfoDtoSkills",
                columns: table => new
                {
                    EventInfoId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoEventInfoDtoSkills", x => new { x.EventInfoId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_DtoEventInfoDtoSkills_EventsInfo_EventInfoId",
                        column: x => x.EventInfoId,
                        principalTable: "EventsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DtoEventInfoDtoSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DtoInterestsDtoUserInfo",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoInterestsDtoUserInfo", x => new { x.InterestsId, x.UserInfoId });
                    table.ForeignKey(
                        name: "FK_DtoInterestsDtoUserInfo_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DtoInterestsDtoUserInfo_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DtoSkillsDtoUserInfo",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoSkillsDtoUserInfo", x => new { x.SkillsId, x.UserInfoId });
                    table.ForeignKey(
                        name: "FK_DtoSkillsDtoUserInfo_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DtoSkillsDtoUserInfo_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DtoEventInfoDtoInterests_InterestsId",
                table: "DtoEventInfoDtoInterests",
                column: "InterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_DtoEventInfoDtoSkills_SkillsId",
                table: "DtoEventInfoDtoSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_DtoInterestsDtoUserInfo_UserInfoId",
                table: "DtoInterestsDtoUserInfo",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DtoSkillsDtoUserInfo_UserInfoId",
                table: "DtoSkillsDtoUserInfo",
                column: "UserInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DtoEventInfoDtoInterests");

            migrationBuilder.DropTable(
                name: "DtoEventInfoDtoSkills");

            migrationBuilder.DropTable(
                name: "DtoInterestsDtoUserInfo");

            migrationBuilder.DropTable(
                name: "DtoSkillsDtoUserInfo");

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
                name: "DtoEventInfoId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DtoUserInfoId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DtoEventInfoId",
                table: "Interests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DtoUserInfoId",
                table: "Interests",
                type: "int",
                nullable: true);

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
                name: "IX_Skills_DtoEventInfoId",
                table: "Skills",
                column: "DtoEventInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DtoUserInfoId",
                table: "Skills",
                column: "DtoUserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_DtoEventInfoId",
                table: "Interests",
                column: "DtoEventInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_DtoUserInfoId",
                table: "Interests",
                column: "DtoUserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_EventsInfo_DtoEventInfoId",
                table: "Interests",
                column: "DtoEventInfoId",
                principalTable: "EventsInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_UserInfo_DtoUserInfoId",
                table: "Interests",
                column: "DtoUserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_EventsInfo_DtoEventInfoId",
                table: "Skills",
                column: "DtoEventInfoId",
                principalTable: "EventsInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_UserInfo_DtoUserInfoId",
                table: "Skills",
                column: "DtoUserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }
    }
}
