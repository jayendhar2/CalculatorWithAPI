using CoinApi.DB_Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace CoinApi.Context
{
    public partial class CoinApiContext : DbContext
    {
        public CoinApiContext(DbContextOptions<CoinApiContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
