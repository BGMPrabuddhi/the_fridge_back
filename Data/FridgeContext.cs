using Microsoft.EntityFrameworkCore;
using FridgeAPI.Models;

namespace FridgeAPI.Data
{
    public class FridgeContext : DbContext
    {
        public FridgeContext(DbContextOptions<FridgeContext> options) : base(options) { }

        public DbSet<FridgeItem> FridgeItems { get; set; }
    }
}
