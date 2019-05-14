using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcPieShop.Models;

namespace MvcPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "ViewbagTitlePieShop";
            // get all pies and order by name then pass to view.
            var pies = _pieRepository.GetAllPies().OrderBy(p=>p.Name);

            return View(pies);
        }
    }
}