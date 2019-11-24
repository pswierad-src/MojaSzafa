using MojaSzafa.Models;
using MojaSzafa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojaSzafa.Services
{
    public class ClothingService : IClothingService
    {
        private readonly IClothingRepository _clothingRepository;

        public ClothingService(IClothingRepository clothingRepository)
        {
            _clothingRepository = clothingRepository;
        }

        public IQueryable<Clothing> GetAll()
        {
            var clothes = _clothingRepository.GetAll();
            return clothes;
        }

        public Clothing GetById(int id)
        {
            var clothing = _clothingRepository.GetById(id);
            if (clothing == null)
            {
                return null;
            }
            return clothing;
        }

        public void Add(Clothing clothing)
        {
            _clothingRepository.Add(clothing);

        }

        public void Edit(Clothing clothing)
        {
            _clothingRepository.Edit(clothing);
        }

        public void Delete(int id)
        {
            var clothing = _clothingRepository.GetById(id);
            _clothingRepository.Remove(clothing);
        }
    }
}
