using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class addDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventsInfo",
                columns: new[] { "Id", "Address", "CoordinateX", "CoordinateY" },
                values: new object[] { 1, "Herning", 56.137632000000004, 8.9738469999999992 });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Interest" },
                values: new object[,]
                {
                    { 1, "Udendørs" },
                    { 2, "Sport" },
                    { 3, "Moter" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Skill" },
                values: new object[,]
                {
                    { 1, "Lave mad" },
                    { 2, "Kører bil" },
                    { 3, "Kundeservice" }
                });

            migrationBuilder.InsertData(
                table: "UserCredentials",
                columns: new[] { "Id", "Password" },
                values: new object[,]
                {
                    { 1, "$2a$12$7nLP/OJ.RafjttMu9yC8jOntDE1b0mnEKiy0UzGvUlGh5DgQBt0rO" },
                    { 2, "$2a$12$06vfmlMA4hTPDA1WPKxe4eRGv1oE.r7NSyfZasKUCJL0R.4VXnH12" },
                    { 3, "$2a$12$C2YIlWVnVjko847ttKeB.ekm6StFHU0CvXiDaKbtRg32svt.6Bozi" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "LocationX", "LocationY" },
                values: new object[,]
                {
                    { 1, 56.073746, 8.7916690000000006 },
                    { 2, 8.7916690000000006, 56.073746 },
                    { 3, 52.073746, 10.791669000000001 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventInfoId", "ImageUrl", "OwnerId", "Title", "VoluntaryId", "WantedVolunteers" },
                values: new object[] { 1, "Det er et sejt event som alle gerne vil være med til", 1, "https://www.blivgladnu.dk/wp-content/uploads/2018/06/Messe_Luzern_Corporate_Event.jpg", 3, "Sejt event", 0, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EventId", "IsVoluntary", "UserCredebtialsId", "UserInfoId", "Username" },
                values: new object[,]
                {
                    { 1, 0, true, 1, 1, "test1" },
                    { 2, 0, true, 2, 2, "test2" },
                    { 3, 0, false, 3, 3, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventsInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
