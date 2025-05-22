using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DixCordesServeur.Migrations
{
    /// <inheritdoc />
    public partial class asdas22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d4141e2-ad56-47bc-a0bd-40f5b37bca63", "AQAAAAIAAYagAAAAEOa9GqYwHHOxI9DkNdQqNfstWHAdvlbPiluA12XSQK2aQlaFRAxGs6XUgVXK6mK1qQ==", "4984f952-bade-49c8-b666-3445f6ff2ccf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de5a73de-3f54-4f00-be5a-97cdf99207d8", "AQAAAAIAAYagAAAAEJAHvponphm6IUV4cEPTOmWvceqWjhYKu5858VvwLmkytoN9Rxv80uhJXeRPC3/QXg==", "13c3a1c5-013d-4d0e-b36b-52c8e45f8b7b" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChannelId", "SentAt", "Text", "UserId" },
                values: new object[] { 12, 1, new DateTime(2023, 5, 10, 20, 15, 27, 0, DateTimeKind.Unspecified), "default comment", "11111111-1111-1111-1111-111111111111" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aefc8bf0-125a-4451-83e6-45856335bb44", "AQAAAAIAAYagAAAAEEjl1ckvUxUm3Veyksmh1mh7/Cx8OnsZ+Y0qi+aSwWCNlBnrYzgGtUyrn1g0Ji3zUQ==", "baa801d6-aa97-4f4d-986f-555b52051f0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c908a92b-30b5-4095-956c-38940c7a5ee6", "AQAAAAIAAYagAAAAEKZEL6XVSMtJS689cGy20SOZZCpoycZRCHKaOln2yGR4eeihB3w05Ns9dRDJaD0fvQ==", "f8dbaf2c-f789-4c4a-85b6-104a815887ac" });
        }
    }
}
