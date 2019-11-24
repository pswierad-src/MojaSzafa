using System.Collections.Generic;
using System.Linq;
using MojaSzafa.Models;

namespace MojaSzafa.Services
{
    public interface IClothingService : IService
    {
        IQueryable<Clothing> GetAll();
        Clothing GetById(int id);
        void Add(Clothing clothing);
        void Edit(Clothing clothing);
        void Delete(int id);       
    }
}