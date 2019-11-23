using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojaSzafa.Models;

namespace MojaSzafa.Controllers
{
    public class WardrobeController : Controller
    {
        private MojaSzafaContext _context;

        public WardrobeController(MojaSzafaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clothes = from c in _context.Clothes select c;
            return View(clothes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothing);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(clothing);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothing = _context.Clothes.Find(id);
            if (clothing == null)
            {
                return NotFound();
            }
            return View(clothing);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(clothing);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(clothing);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothing = _context.Clothes.Find(id);
            _context.Remove(clothing);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}