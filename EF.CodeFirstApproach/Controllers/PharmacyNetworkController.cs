using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.CodeFirstApproach.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirstApproach.Controllers
{
    public class PharmacyNetworkController : Controller
    {
        private readonly PharmacyContext _pharmacyContext;

        public PharmacyNetworkController(PharmacyContext pharmacyContext)
        {
            _pharmacyContext = pharmacyContext;
        }
        public async  Task<IActionResult> Index()
        {
            return View(await _pharmacyContext.PharmacyNetworks.ToListAsync());
        }
    }
}