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
            var addresses = await _pharmacyContext.PharmacyAddresses.ToListAsync();
            var medicines = await _pharmacyContext.Medicines.ToListAsync();

            foreach (var pr in prices)
            {
                pr.PharmacyAddress.Address = _pharmacyContext.PharmacyAddresses.Find(pr.PharmacyAddressId).Address;
                pr.Medicine.Name = _pharmacyContext.Medicines.Find(pr.MedicineId).Name;

            }

            prices.ForEach(pr =>
            {
                pr.PharmacyAddress.Address = _pharmacyContext.PharmacyAddresses.Find(pr.PharmacyAddressId).Address;
                pr.Medicine.Name = _pharmacyContext.Medicines.Find(pr.MedicineId).Name;
            });

            return View(prices);
        }
    }
}