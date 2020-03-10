using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.CodeFirstApproach.DomainModels
{
    public class PharmacyAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PharmacyNetworkId { get; set; }
        public PharmacyNetwork PharmacyNetwork { get; set; }
        public string Address { get; set; }
        public List<MedicinePrice> MedicinePrices { get; set; }
    }
}