using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DixCordesServeur.Migrations
{
    /// <inheritdoc />
    public partial class asdas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "642b0c4f-09f4-4f13-856d-11e478faecd6", "AQAAAAIAAYagAAAAEEQG+7BkhI4dG88ktabGIYSvy54g3TgVFwAcQ2y7Ixmx/EDGMg4dpzFKZdhP39n/hA==", "8d427c0f-528d-4712-8289-928e17d77f12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d38b80d-2fdc-4f94-abb1-76e192c42f23", "AQAAAAIAAYagAAAAELS5TU0kt1Ev2oZZ71dPm14iyEPpc1cPEy0FX162p1hUYElJ4cOtoDo4KLCzxWroZA==", "8c48bc7d-4e79-43c1-9c9d-2eab3377456d" });
        }
    }
}
