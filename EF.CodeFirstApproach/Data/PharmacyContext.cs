using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirstApproach.DomainModels
{
    public class PharmacyContext :  DbContext
    {
        public DbSet<PharmacyNetwork> PharmacyNetworks { get; set; }
        public DbSet<PharmacyAddress> PharmacyAddresses { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicinePrice> MedicinePrices { get; set; }

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
