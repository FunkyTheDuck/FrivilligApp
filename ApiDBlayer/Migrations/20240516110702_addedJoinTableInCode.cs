using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class addedJoinTableInCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DtoEventInfoDtoInterests");

            migrationBuilder.DropTable(
                name: "DtoEventInfoDtoSkills");

            migrationBuilder.DropTable(
                name: "DtoInterestsDtoUserInfo");

            migrationBuilder.DropTable(
                name: "DtoSkillsDtoUserInfo");

            migrationBuilder.CreateTable(
                name: "EventInfoInterests",
                columns: table => new
                {
                    EventInfoId = table.Column<int>(type: "int", nullable: false),
                    InterestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfoInterests", x => new { x.EventInfoId, x.InterestsId });
                    table.ForeignKey(
                        name: "FK_EventInfoInterests_EventsInfo_EventInfoId",
                        column: x => x.EventInfoId,
                        principalTable: "EventsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventInfoInterests_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventInfoSkills",
                columns: table => new
                {
                    EventInfoId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfoSkills", x => new { x.EventInfoId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_EventInfoSkills_EventsInfo_EventInfoId",
                        column: x => x.EventInfoId,
                        principalTable: "EventsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventInfoSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoInterests",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false),
                    InterestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoInterests", x => new { x.InterestsId, x.UserInfoId });
                    table.ForeignKey(
                        name: "FK_UserInfoInterests_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInfoInterests_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoSkills",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoSkills", x => new { x.SkillsId, x.UserInfoId });
                    table.ForeignKey(
                        name: "FK_UserInfoSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInfoSkills_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventInfoInterests_InterestsId",
                table: "EventInfoInterests",
                column: "InterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventInfoSkills_SkillsId",
                table: "EventInfoSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfoInterests_UserInfoId",
                table: "UserInfoInterests",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfoSkills_UserInfoId",
                table: "UserInfoSkills",
                column: "UserInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventInfoInterests");

            migrationBuilder.DropTable(
                name: "EventInfoSkills");

            migrationBuilder.DropTable(
                name: "UserInfoInterests");

            migrationBuilder.DropTable(
                name: "UserInfoSkills");

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
    }
}
