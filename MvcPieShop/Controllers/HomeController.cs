using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcPieShop.Models;
using MvcPieShop.ViewModels;

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
            
            // get all pies and order by name then pass to view.
            var pies = _pieRepository.GetAllPies().OrderBy(p=>p.Name);

            //using ViewModel instead of viewbag etc.
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to the Pie Shop",
                Pies = pies.ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}