
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class FilmyController : Controller
    {
        FilmyContext db;
        IWebHostEnvironment webHostEnvironment;

        public FilmyController(FilmyContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
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
        public IActionResult Wszystkie()
        {
            var filmy = db.Filmy.ToList();
            return View(filmy);
        }




        [HttpGet]
        public ActionResult DodajFilm()
        {
            DodawanieViewModel dodaj = new DodawanieViewModel();
            var kategora = db.Kategorie.ToList();
            dodaj.Kategorie = kategora;
            return View(dodaj);
        }
        [HttpPost]
        public ActionResult DodajFilm(DodawanieViewModel obj)
        {
            obj.Film.DataDodania = DateTime.Now;

            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "plakaty");
            var uniquePosterName = Guid.NewGuid() + "_" + obj.Plakat.FileName;
            var picFilePath = Path.Combine(filePath, uniquePosterName);

            obj.Plakat.CopyTo(new FileStream(picFilePath, FileMode.Create));

            obj.Film.Plakat = uniquePosterName;
            db.Filmy.Add(obj.Film);
            db.SaveChanges();
            return RedirectToAction("DodajFilm");
        }
    }
}
