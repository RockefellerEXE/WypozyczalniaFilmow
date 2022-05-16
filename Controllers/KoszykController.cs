using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Helpers;
using WypozyczalniaFilmow.Infrastructure;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class KoszykController : Controller
    {
        FilmyContext db;

        public KoszykController(FilmyContext db)
        {
            this.db = db;
        }

        [Route("Cart")]
        public IActionResult Index()
        {
            var cart = CartMenager.GetItems(HttpContext.Session);
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Film.Cena * item.Ilosc);
            return View();
        }
        public IActionResult Kup(int id)
        {

            CartMenager.AddToCart(HttpContext.Session, db, id);
            //var film = db.Filmy.Find(id);
            //if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey) == null)
            //{
            //    List<CartItem> cart = new List<CartItem>();
            //    cart.Add(new CartItem { Film = film, Ilosc = 1, Wartosc = film.Cena });
            //    SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cart);

            //}
            //else
            //{
            //    List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
            //    int index = InCart(id);
            //    if (index != -1)
            //    {
            //        cart[index].Ilosc++;
            //    }
            //    else
            //    {
            //        cart.Add(new CartItem { Film = film, Ilosc = 1, Wartosc = film.Cena });

            //    }
            //    SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cart);
            //}
            return RedirectToAction("Index");
        }
        public IActionResult Usun(int id)
        {
            //List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
            //int index = InCart(id);
            //cart.RemoveAt(index);
            //SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartSessionKey, cart);
            //return RedirectToAction("Index");

            var model = new UsuwanieVievModel()
            {
                ItemId = id,
                ItemQuantity = CartMenager.RemoveFromCart(HttpContext.Session, id),
                CartValue = CartMenager.GetCartValue(HttpContext.Session),
                CartQuantityTotal = CartMenager.GetCartQuantity(HttpContext.Session)

            };
            return Json(model);
        }
        private int InCart(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
            for (int i = 0; i < cart.Count(); i++)
            {
                if (cart[i].Film.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
