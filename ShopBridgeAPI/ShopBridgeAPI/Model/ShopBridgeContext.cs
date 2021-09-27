using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Model
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext(DbContextOptions<ShopBridgeContext> options) : base(options)
        {

        }
        public DbSet<tblShopBridge> tblShopBridge { get; set; }
    }
}
