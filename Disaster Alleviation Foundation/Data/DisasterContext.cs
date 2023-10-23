using Disaster_Alleviation_Foundation.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation.Data
{
    public class DisasterContext : DbContext
    {
        public DisasterContext(DbContextOptions<DisasterContext> options)
        : base (options) { }

        public DbSet<GoodsDonationModel> GoodsDonation { get; set; }
        public DbSet<MonetaryDonationModel> MonetaryDonation { get; set; }
        public DbSet<DisasterModel> Disasters { get; set; }
    }
}
