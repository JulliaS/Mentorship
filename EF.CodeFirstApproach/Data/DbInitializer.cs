using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.CodeFirstApproach.DomainModels
{
    public static class DbInitializer
    {
        public static void Initialize(PharmacyContext context)
        {
            var pharmacyNetworks = GetPharmacyNetworks();
            context.PharmacyNetworks.AddRange(pharmacyNetworks);
            context.SaveChanges();

            var pharmacyAddresses = GetPharmacyAddresses(pharmacyNetworks);
            context.PharmacyAddresses.AddRange(pharmacyAddresses);
            context.SaveChanges();

            var medicines = GetMedicines();
            context.Medicines.AddRange(medicines);
            context.SaveChanges();

            var medicinePrices = GetMedicinePrices(medicines, pharmacyAddresses);
            context.MedicinePrices.AddRange(medicinePrices);
            context.SaveChanges();
        }

        private static List<PharmacyNetwork> GetPharmacyNetworks()
        {
            return new List<PharmacyNetwork>
            {
                new PharmacyNetwork{Name = "Znakhar", Email = "znakhar@gmail.com", PhoneNumber = "3809765403450"}, 
                new PharmacyNetwork{Name = "DS", Email = "ds@gmail.com", PhoneNumber = "3809365468468"},
                new PharmacyNetwork{Name = "Podorozhnyk", Email = "podoroznyk@gmail.com", PhoneNumber = "380689023457"}
            };
        }

        private static List<PharmacyAddress> GetPharmacyAddresses(List<PharmacyNetwork> pharmacyNetworks)
        {
            return new List<PharmacyAddress>
            {
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[0].Id, Address = "Horodotcka, 71"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[0].Id, Address = "Henerala Chuprynky, 42"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[0].Id, Address = "Leontovycha, 1"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[1].Id, Address = "Horodotcka, 171"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[1].Id, Address = "Stepana Bandery, 68"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[1].Id, Address = "Shevchenka, 42"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[2].Id, Address = "Horodotcka, 227"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[2].Id, Address = "Teatralna, 9"},
               new PharmacyAddress{PharmacyNetworkId = pharmacyNetworks[2].Id, Address = "Virmenska, 24"}

            };
        }

        private static List<Medicine> GetMedicines()
        {
            return new List<Medicine>
            {
                new Medicine{Name = "Matipred", Instruction = "..."},
                new Medicine{Name = "Sorbex", Instruction = "..."},
                new Medicine{Name = "Spazmalgon", Instruction = "..."},
                new Medicine{Name = "Mezym", Instruction = "..."},
            };
        }

        private static List<MedicinePrice> GetMedicinePrices(List<Medicine> medicines, List<PharmacyAddress> pharmacyAdresses)
        {
            return new List<MedicinePrice>
            {
                new MedicinePrice{MedicineId = medicines[0].Id, PharmacyAddressId = pharmacyAdresses[0].Id, Price = 290},
                new MedicinePrice{MedicineId = medicines[0].Id, PharmacyAddressId = pharmacyAdresses[1].Id, Price = 310},
                new MedicinePrice{MedicineId = medicines[1].Id, PharmacyAddressId = pharmacyAdresses[0].Id, Price = 131},
                new MedicinePrice{MedicineId = medicines[2].Id, PharmacyAddressId = pharmacyAdresses[4].Id, Price = 87},
                new MedicinePrice{MedicineId = medicines[3].Id, PharmacyAddressId = pharmacyAdresses[6].Id, Price = 65},
                new MedicinePrice{MedicineId = medicines[3].Id, PharmacyAddressId = pharmacyAdresses[3].Id, Price = 68}
            };
        }

    }
}
