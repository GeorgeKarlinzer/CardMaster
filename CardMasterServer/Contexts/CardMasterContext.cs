using CardMaster.Data;
using Microsoft.EntityFrameworkCore;

namespace CardMaster.Server
{
    public class CardMasterContext : DbContext
    {
        public CardMasterContext(DbContextOptions<CardMasterContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardCollection> CardCollections { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
