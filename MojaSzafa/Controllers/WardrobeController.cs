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

        public IActionResult Index(string search, int? pageNum, string filter, string sortingOrder)
        {
            var clothes = from c in _context.Clothes select c;

            #region pagination
            if (search != null)
            {
                pageNum = 1;
            }
            else
            {
                search = filter;
            }
            #endregion

            #region filtering
            ViewData["filter"] = filter;
            if (!String.IsNullOrEmpty(filter))
            {
                clothes = clothes.Where(c => c.Name.Contains(filter) || c.Color.Contains(filter) || c.Material.Contains(filter));  
            }
            #endregion

            #region sorting
            //Field for holding way of sorting for pagination
            ViewData["CurrentSortingMethod"] = sortingOrder;

            ViewData["NameSortParm"] = sortingOrder == "name" ? "name_desc" : "name";
            ViewData["ColorSortParm"] = sortingOrder == "color" ? "color_desc" : "color";
            ViewData["MaterialSortParm"] = sortingOrder == "material" ? "material_desc" : "material";
            ViewData["DateSortParm"] = sortingOrder == "date" ? "date_desc" : "date";
            switch (sortingOrder)
            {
                case "name": clothes = clothes.OrderBy(c => c.Name); break;
                case "name_desc": clothes = clothes.OrderByDescending(c => c.Name); break;
                case "color": clothes = clothes.OrderBy(c => c.Color); break;
                case "color_desc": clothes = clothes.OrderByDescending(c => c.Color); break;
                case "material": clothes = clothes.OrderBy(c => c.Material); break;
                case "material_desc": clothes = clothes.OrderByDescending(c => c.Material); break;
                case "date": clothes = clothes.OrderBy(c => c.DateAdded); break;
                case "date_desc": clothes = clothes.OrderByDescending(c => c.DateAdded); break;
                default: break;
            }
            #endregion

            //returns new paginated list with source, currently viewed index and size of page(how many entries are displayed)
            return View(Pagination<Clothing>.Create(clothes, pageIndex: pageNum ?? 1, pageSize: 9));
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