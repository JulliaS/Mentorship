using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.CodeFirstApproach.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirstApproach.Controllers
{
    public class MedicinePriceController : Controller
    {
        private readonly PharmacyContext _pharmacyContext;
        public MedicinePriceController(PharmacyContext pharmacyContext)
        {
            _pharmacyContext = pharmacyContext;
        }
        public async Task<IActionResult> Index()
        {
            var prices = await _pharmacyContext.MedicinePrices.ToListAsync();

            prices.ForEach(pr =>
            {
                var address = _pharmacyContext.PharmacyAddresses.Find(pr.PharmacyAddressId).Address;
                pr.PharmacyAddress.Address = address;
                var medicineName = _pharmacyContext.Medicines.Find(pr.MedicineId).Name;
                pr.Medicine.Name = medicineName;
            });

            return View(prices);
        }
    }
}