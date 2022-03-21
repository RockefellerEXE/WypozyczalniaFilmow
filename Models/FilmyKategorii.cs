using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow.Models
{
    public class FilmyKategorii
    {
        public Kategoria Kategoria { get; set; }
        public IEnumerable<Film> FilmyKategoria { get; set; }
        public IEnumerable<Film> FilmyNajnowsze { get; set; }
        public IEnumerable<Film> FilmyNajdluzsze { get; set; }
    }
}
