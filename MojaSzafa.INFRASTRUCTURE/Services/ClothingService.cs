using MojaSzafa.DB.Entities;
using MojaSzafa.INFRASTRUCTURE.DTOs;
using MojaSzafa.INFRASTRUCTURE.Mappers;
using MojaSzafa.INFRASTRUCTURE.Repositories;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MojaSzafa.INFRASTRUCTURE.Services
{
    public class ClothingService
    {
        private readonly IClothingRepository _clothingRepository;

        public ClothingService(IClothingRepository clothingRepository)
        {
            _clothingRepository = clothingRepository;
        }

        public ICollection<ClothingDTO> GetAll(string filter, int? pageNum, string sortingOrder)
        {
            var clothes = _clothingRepository.GetAll().Select(c => Mapper.Map<ClothingDTO>(c));

            if (!String.IsNullOrEmpty(filter))
            {
                clothes = clothes.Where(c => c.Name.Contains(filter) || c.Color.Contains(filter) || c.Material.Contains(filter));
            }
            if (!String.IsNullOrEmpty(sortingOrder))
            {
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
            }
            if (pageNum != null)
            {
                clothes = Pagination<ClothingDTO>.Create(clothes.AsQueryable(), pageIndex: (int)pageNum, pageSize: 9);
            }

            return clothes.ToList();
        }
        public ClothingDTO GetById(int id)
        {
            var clothing = _clothingRepository.GetById(id);
            if (clothing == null)
            {
                return null;
            }
            return Mapper.Map<ClothingDTO>(clothing);
        }
        public void Add(ClothingDTO clothing)
        {
            _clothingRepository.Add(Mapper.Map<Clothing>(clothing));
        }
        public void Edit(ClothingDTO clothing)
        {
            _clothingRepository.Edit(Mapper.Map<Clothing>(clothing));
        }
        public void Delete(int id)
        {
            var clothing = _clothingRepository.GetById(id);
            if (clothing != null)
            {
                _clothingRepository.Remove(clothing);
            }   
        }
    }
}
