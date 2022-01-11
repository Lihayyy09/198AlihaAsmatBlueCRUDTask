using DepStoreAliha198.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepStoreAliha198.Data
{
    public class StoreDB : DbContext
    {
        public StoreDB(DbContextOptions<StoreDB> options) : base(options)
        {

        }
        public DbSet<OrderModel> Orders { get; set; }
    }
}
