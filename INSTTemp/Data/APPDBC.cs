using INSTTemp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace INSTTemp.Data
{
    public class APPDBC : IdentityDbContext<INSTTempUser>
    {
        public APPDBC(DbContextOptions<APPDBC> options)
            : base(options)
        {
        }

        public DbSet<Upload> Uploads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Upload>().ToTable("Uploads");
            //new CoinQuotesDailyMap(modelBuilder.Entity<CoinQuotesDaily>());
        }
    }
}
