using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojaSzafa.INFRASTRUCTURE.Repositories;

namespace MojaSzafa.WEB.Controllers
{
    public class WardrobeController : Controller
    {
        private readonly IClothingRepository _clothingRepository;

        public WardrobeController(IClothingRepository clothingRepository)
        {
            _clothingRepository = clothingRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}