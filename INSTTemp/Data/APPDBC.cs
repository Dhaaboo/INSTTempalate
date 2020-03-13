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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //new INSTTempUser(builder.Entity<INSTTempUser>());
            //new CoinQuotesDailyMap(modelBuilder.Entity<CoinQuotesDaily>());
        }
    }
}
