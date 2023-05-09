using Microsoft.EntityFrameworkCore;
using Zainab_Baloch_cultural_.Model;

namespace Zainab_Baloch_cultural_.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<SignIn> signIns { get; set; }
    }
}

