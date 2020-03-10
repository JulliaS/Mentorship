using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.CodeFirstApproach.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirstApproach.Controllers
{
    public class PharmacyAddressController : Controller
    {
        private readonly PharmacyContext _pharmacyContext;
        public PharmacyAddressController(PharmacyContext pharmacyContext)
        {
                _pharmacyContext = pharmacyContext;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = await _pharmacyContext.PharmacyAddresses.ToListAsync();

            addresses.ForEach(adr =>
            {
                var pharmacyNetwork = _pharmacyContext.PharmacyNetworks.Where(n => n.Id == adr.PharmacyNetworkId).FirstOrDefault().Name;
                adr.PharmacyNetwork.Name = pharmacyNetwork;
            });
            return View(addresses);
        }
    }
}