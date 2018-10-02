using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { set; get; }
        public decimal AmountDue
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
