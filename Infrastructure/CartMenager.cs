using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using WypozyczalniaFilmow.Helpers;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Infrastructure
{
    public class CartMenager
    {
        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);
            var thisFilm = cart.Find(i => i.Film.Id == id);
            int ilosc = 0;

            if (thisFilm == null)
            {
                return ilosc;
            }
            if (thisFilm.Ilosc > 1)
            {
                thisFilm.Ilosc--;
                ilosc = thisFilm.Ilosc;
            }
            else
            {
                cart.Remove(thisFilm);
            }
            session.SetObjectAsJson(Consts.CartSessionKey, cart);

            return ilosc;
        }
        public static int GetCartQuantity (ISession session)
        {
            var cart = GetItems(session);

            return cart.Sum(i => i.Ilosc);
        }

        public static decimal GetCartValue(ISession session)
        {
            var items = GetItems(session);
            return items.Sum(i => i.Ilosc * i.Wartosc);
        }

        private static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(session, Consts.CartSessionKey);
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }
    }
}
