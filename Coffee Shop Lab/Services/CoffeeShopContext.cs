using Coffee_Shop_Lab.DALModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee_Shop_Lab.Services
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions options) : base(options)
        {

        }

        // DBSets represents your table in your DB
        public DbSet<UsersDAL> Users { get; set; }

    }
}
