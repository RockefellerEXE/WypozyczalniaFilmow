﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class HomeController : Controller
    {
        FilmyContext db;

        public HomeController(FilmyContext db)
        {
            this.db = db;
        }
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        public IActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

        public IActionResult Index()
        {
            var kategoria = db.Kategorie.ToList();
            return View(kategoria);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
