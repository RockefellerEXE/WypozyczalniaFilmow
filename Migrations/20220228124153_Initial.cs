using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WypozyczalniaFilmow.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rezyser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmy_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "Nazwa", "Opis" },
                values: new object[,]
                {
                    { 1, "Horror", "Straszne filmy" },
                    { 2, "Dokumentalne", "Filmy oparte na faktach" },
                    { 3, "Thriller", "Dreszczowce" },
                    { 4, "Sensacyjne", "Filmy z akcją" },
                    { 5, "Fantasy", "Elementy magiczne i nadprzyrodzone" }
                });

            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "Id", "Cena", "DataDodania", "KategoriaId", "Opis", "Rezyser", "Tytul" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.", "Marcus Nispel", "Teksańska Masakra Piłą Mechaniczną" },
                    { 9, 16m, new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.", "Clive Barker", "Hellraiser: Wysłannik Piekieł" },
                    { 6, 0m, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.", "Tomasz Sekielski", "Tylko nie mów nikomu" },
                    { 2, 14m, new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.", "Joel Schumacher", "Numer 23" },
                    { 3, 12m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.", "David Koepp", "Sekretne Okno" },
                    { 8, 15m, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.", "Vincenzo Natali", "Cube" },
                    { 10, 17m, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.", "Jonathan Demme", "Milczenie Owiec" },
                    { 5, 11m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.", "Robert Schwentke", "Red" },
                    { 4, 20m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.", "Peter Jackson", "Władca Pierścieni: Drużyna Pierścienia" },
                    { 7, 13m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.", "Neil Burger", "Iluzjonista" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_KategoriaId",
                table: "Filmy",
                column: "KategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
