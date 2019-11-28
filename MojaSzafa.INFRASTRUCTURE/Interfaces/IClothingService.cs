using System.Collections.Generic;
using MojaSzafa.INFRASTRUCTURE.DTOs;
using MojaSzafa.INFRASTRUCTURE.Mappers;

namespace MojaSzafa.INFRASTRUCTURE.Interfaces
{
    public interface IClothingService : IService
    {
        ICollection<ClothingDTO> GetAll(string filter, int? pageNum, string sortingOrder);
        ClothingDTO GetById(int id);
        void Add(ClothingDTO clothing);
        void Delete(int id);
        void Edit(ClothingDTO clothing);
    }
}