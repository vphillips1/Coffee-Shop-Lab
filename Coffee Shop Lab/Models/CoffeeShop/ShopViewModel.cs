using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee_Shop_Lab.Models.CoffeeShop
{
    public class ShopViewModel
    {
        public static void Shop()
        {
            List<string> items = new List<string>()

         {
                "Pop tart",
                "Fruit cup",
                "Soup"
         };
            items.Add("Donut");
            items.Add("Banana Nut Bread");
            items.Add("Bagel");
            items.Add("Iced Coffee");
            items.Add("Lemon Ice Tea");
            items.Add("Hot Chocolate");

        }

    }

}