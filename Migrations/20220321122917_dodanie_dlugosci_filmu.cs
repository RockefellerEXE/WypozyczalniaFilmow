using Microsoft.EntityFrameworkCore.Migrations;

namespace WypozyczalniaFilmow.Migrations
{
    public partial class dodanie_dlugosci_filmu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DlugoscFilmu",
                table: "Filmy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 1,
                column: "DlugoscFilmu",
                value: 81);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 2,
                column: "DlugoscFilmu",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 3,
                column: "DlugoscFilmu",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 4,
                column: "DlugoscFilmu",
                value: 178);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 5,
                column: "DlugoscFilmu",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 6,
                column: "DlugoscFilmu",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 7,
                column: "DlugoscFilmu",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 8,
                column: "DlugoscFilmu",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 9,
                column: "DlugoscFilmu",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Filmy",
                keyColumn: "Id",
                keyValue: 10,
                column: "DlugoscFilmu",
                value: 118);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DlugoscFilmu",
                table: "Filmy");
        }
    }
}
