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
            var prices = await _pharmacyContext.MedicinePrices.Include(x=>x.PharmacyAddress).Include(x=>x.Medicine).ToListAsync();
            
            return View(prices);
        }
    }
}