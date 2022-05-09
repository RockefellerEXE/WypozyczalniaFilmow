using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow.Models
{
    public class UsuwanieVievModel
    {
        public int ItemId { get; set; }

        public int ItemQuantity { get; set; }

        public decimal CartValue { get; set; }

        public int CartQuantityTotal { get; set; }

    }
}
