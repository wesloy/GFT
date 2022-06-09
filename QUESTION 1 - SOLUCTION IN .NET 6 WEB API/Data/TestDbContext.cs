using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{

    public class TestDbContext : DbContext
    {

        public DbSet<RuleModel> Rules { get; set; }
        public DbSet<TradeModel> Trades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=test.db;Cache=Shared");

    }

}