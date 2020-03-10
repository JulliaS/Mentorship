using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF.CodeFirstApproach.DomainModels
{
    public class MedicinePrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PharmacyAddressId { get; set; }
        public int MedicineId { get; set; }
        public PharmacyAddress PharmacyAddress { get; set; }
        public Medicine Medicine { get; set; }
        public double Price { get; set; }
    }
}
