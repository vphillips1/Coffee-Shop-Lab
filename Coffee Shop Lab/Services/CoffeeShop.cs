using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee_Shop_Lab.Services
{
    public class CoffeeShop : ICoffeeShop
    {
        public List<Users> Users { get; } = new List<Users>();
    }
}
