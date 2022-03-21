
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class FilmyController : Controller
    {
        FilmyContext db;

        public FilmyController(FilmyContext db)
        {
            this.db = db;
        }

        public IActionResult Lista(string nazwaKategorii)
        {
            var kategoria = db.Kategorie.Include("Filmy").Where(k => k.Nazwa.ToUpper() == nazwaKategorii).Single();
            var filmy = kategoria.Filmy.ToList();

            FilmyKategorii model = new FilmyKategorii();
            model.Kategoria = kategoria;
            model.FilmyKategoria = filmy;
            model.FilmyNajnowsze = db.Filmy.OrderByDescending(f => f.DataDodania).Take(3);
            model.FilmyNajdluzsze= db.Filmy.OrderByDescending(f => f.DlugoscFilmu).Take(3);

            return View(model);
        }
        public IActionResult Szczegoly(int idFilmu)
        {
            var kategoria = db.Kategorie.Find(db.Filmy.Find(idFilmu).KategoriaId);
            var film = db.Filmy.Find(idFilmu);
            return View(film);
        }
    }
}
