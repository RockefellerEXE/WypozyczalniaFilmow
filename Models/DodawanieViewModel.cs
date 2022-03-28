using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow.Models
{
    public class DodawanieViewModel
    {
        public Film Film { get; set; }
        public List<Kategoria> Kategorie { get; set; }
    }
}
