using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MojaSzafa.Models;
using MojaSzafa.Services;

namespace MojaSzafa.Controllers
{
    /// <summary>
    /// Controller handling CRUD operations for clothes
    /// </summary>
    public class WardrobeController : Controller
    {
        private readonly IClothingService _clothingService;

        public WardrobeController(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        /// <summary>
        /// Default action, retrives list of all clothes with possible filtering/sorting and pagination
        /// </summary>
        /// <param name="search">Helper phrase for handling filering with pagination</param>
        /// <param name="pageNum">current page number</param>
        /// <param name="filter">phrase for filtering list for desired items</param>
        /// <param name="sortingOrder">Order in wchich items are presented. Can contain sorting for every parameter in ascending or descending order</param>
        /// <returns>List of clothes</returns>
        public IActionResult Index(string search, int? pageNum, string filter, string sortingOrder)
        {
            var clothes = _clothingService.GetAll(); 

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

        /// <summary>
        /// Redirects to adding form
        /// </summary>
        /// <returns>Add clothing view</returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// POST action for adding clothes and validating input
        /// </summary>
        /// <param name="clothing">Piece of clothing to add</param>
        /// <returns>Redirects to index or in case of invalid model passed returns to add view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                _clothingService.Add(clothing);
                return RedirectToAction(nameof(Index));
            }
            return View(clothing);
        }

        /// <summary>
        /// Redirects to editing form
        /// </summary>
        /// <param name="id">Edited clothing id</param>
        /// <returns>Edit view</returns>
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothing = _clothingService.GetById((int)id);
            if (clothing == null)
            {
                return NotFound();
            }
            return View(clothing);
        }

        /// <summary>
        /// POST method for editing existing clothing piece
        /// </summary>
        /// <param name="id">clothing id</param>
        /// <param name="clothing">edited piece of clothing</param>
        /// <returns>Redirects to index or in case of invalid model passed returns to edit view</returns>
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
                _clothingService.Edit(clothing);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(clothing);
            }
        }

        /// <summary>
        /// Action for deleting piece of clothing designated by id
        /// </summary>
        /// <param name="id">Id of piece of clothing to delete</param>
        /// <returns>Redirects to index</returns>
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _clothingService.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }

    }
}