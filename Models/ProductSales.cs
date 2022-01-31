using System;
using FrontToBack.Models;

namespace FronToBack.Models
{
    public class ProductSales
    {
        public int Id { get; set; }

        public int SalesId { get; set; }

        public Sales Sales { get; set; }

        public int PRODUCTS1Id { get; set; }

        public PRODUCTS1 PRODUCTS1 { get; set; }
    }
}
