using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.DAL
{
    public class FilmyContext:DbContext
    {
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        
        public FilmyContext(DbContextOptions<FilmyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>().HasData(
                new Kategoria 
                { 
                    Id=1,
                    Nazwa="Horror",
                    Opis="Straszne filmy"
                },
                new Kategoria{
                    Id = 2,
                    Nazwa = "Dokumentalne",
                    Opis = "Filmy oparte na faktach"
                },
                new Kategoria
                {
                    Id = 3,
                    Nazwa = "Thriller",
                    Opis = "Dreszczowce"
                },
                new Kategoria
                {
                    Id = 4,
                    Nazwa = "Sensacyjne",
                    Opis = "Filmy z akcją"
                },
                new Kategoria
                {
                    Id = 5,
                    Nazwa = "Fantasy",
                    Opis = "Elementy magiczne i nadprzyrodzone"
                }
                );
            modelBuilder.Entity<Film>().HasData(
                new Film()
                {
                    Id = 1,
                    KategoriaId = 1,
                    Tytul = "Teksańska Masakra Piłą Mechaniczną",
                    Rezyser = "Marcus Nispel",
                    Opis = "20 sierpnia 1973 roku teksańska policja trafiła do stojącego na uboczu domu Thomasa Hewitta - byłego pracownika lokalnej rzeźni. Na miejscu odkryli rozkładające się zwłoki 33 osób, które zostały zamordowane przez psychopatycznego zabójcę noszącego na twarzy maskę z ludzkiej skóry i posługującego się piłą mechaniczną.",
                    Cena = 10,
                    DataDodania = new DateTime(2020, 5, 4),
                    DlugoscFilmu =81,
                    Plakat= "teksanska-masakra-pila-mechaniczna.jpg"
                },
                new Film()
                {
                    Id = 2,
                    KategoriaId = 3,
                    Tytul = "Numer 23",
                    Rezyser = "Joel Schumacher",
                    Opis = "Mężczyzna dostaje obsesji na punkcie książki, która według niego opisuje i przewiduje jego życie i przyszłość.",
                    Cena = 14,
                    DataDodania = new DateTime(2021, 3, 16),
                    DlugoscFilmu = 98,
                    Plakat= "numer-23.jpg"
                },
                new Film()
                {
                    Id = 3,
                    KategoriaId = 3,
                    Tytul = "Sekretne Okno",
                    Rezyser = "David Koepp",
                    Opis = "Uznany pisarz przenosi się na prowincję, by w spokoju tworzyć kolejne książki. Wkrótce odwiedzi go tajemniczy mężczyzna, który oskarży Raineya o plagiat.",
                    Cena = 12,
                    DataDodania = new DateTime(2020, 5, 4),
                    DlugoscFilmu = 95,
                    Plakat= "sekretne-okno.jpg"
                },
                new Film()
                {
                    Id = 4,
                    KategoriaId = 5,
                    Tytul = "Władca Pierścieni: Drużyna Pierścienia",
                    Rezyser = "Peter Jackson",
                    Opis = "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.",
                    Cena = 20,
                    DataDodania = new DateTime(2020, 5, 4),
                    DlugoscFilmu = 178,
                    Plakat= "wladca-pierscieni-druzyna-pierscienia.jpg"
                },
                new Film()
                {
                    Id = 5,
                    KategoriaId = 4,
                    Tytul = "Red",
                    Rezyser = "Robert Schwentke",
                    Opis = "Emerytowani agenci specjalni CIA zostają wrobieni w zamach. By się ratować, muszą reaktywować stary zespół.",
                    Cena = 11,
                    DataDodania = new DateTime(2020, 5, 4),
                    DlugoscFilmu = 111,
                    Plakat= "red.jpg"
                },
                new Film()
                {
                    Id = 6,
                    KategoriaId = 2,
                    Tytul = "Tylko nie mów nikomu",
                    Rezyser = "Tomasz Sekielski",
                    Opis = "Dziennikarz śledczy rozmawia z dziewięcioma księżmi katolickimi, którzy dopuścili się zbrodni pedofilii i molestowania nieletnich, a także ich ofiarami.",
                    Cena = 0,
                    DataDodania = new DateTime(2021, 4, 4),
                    DlugoscFilmu = 121,
                    Plakat= "tylko-nie-mow-nikomu.jpg"
                },
                new Film()
                {
                    Id = 7,
                    KategoriaId = 5,
                    Tytul = "Iluzjonista",
                    Rezyser = "Neil Burger",
                    Opis = "Wiedeń u progu XX w. Syn rzemieślnika, iluzjonista Eisenheim, wykorzystuje niezwykłe umiejętności, by zdobyć miłość arystokratki, narzeczonej austro-węgierskiego księcia.",
                    Cena = 13,
                    DataDodania = new DateTime(2020, 5, 4),
                    DlugoscFilmu = 110,
                    Plakat= "iluzjonista.jpg"
                },
                new Film()
                {
                    Id = 8,
                    KategoriaId = 3,
                    Tytul = "Cube",
                    Rezyser = "Vincenzo Natali",
                    Opis = "Grupa osób budzi się w pełnym śmiertelnych pułapek sześcianie. Nieznajomi muszą zacząć współpracować ze sobą, by przeżyć.",
                    Cena = 15,
                    DataDodania = new DateTime(2021, 2, 1),
                    DlugoscFilmu = 90,
                    Plakat= "cube.jpg"
                },
                new Film()
                {
                    Id = 9,
                    KategoriaId = 1,
                    Tytul = "Hellraiser: Wysłannik Piekieł",
                    Rezyser = "Clive Barker",
                    Opis = "Frank Cotton nabywa tajemniczą kostkę, za pomocą której można przywołać demony z piekła.",
                    Cena = 16,
                    DataDodania = new DateTime(2020, 6, 21),
                    DlugoscFilmu = 94,
                    Plakat = "hellriser.jpg"
                },
                new Film()
                {
                    Id = 10,
                    KategoriaId = 3,
                    Tytul = "Milczenie Owiec",
                    Rezyser = "Jonathan Demme",
                    Opis = "Seryjny morderca i inteligentna agentka łączą siły, by znaleźć przestępcę obdzierającego ze skóry swoje ofiary.",
                    Cena = 17,
                    DataDodania = new DateTime(2020, 10, 10),
                    DlugoscFilmu = 118,
                    Plakat= "milczenie-owiec.jpg"

                }
            );


        }
    }
}
