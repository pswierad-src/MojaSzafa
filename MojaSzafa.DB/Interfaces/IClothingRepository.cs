using System.Collections.Generic;
using MojaSzafa.DB.Entities;
using MojaSzafa.DB.Interfaces;

namespace MojaSzafa.INFRASTRUCTURE.Repositories
{
    public interface IClothingRepository : IRepository
    {
        void Add(Clothing clothing);
        void Edit(Clothing clothing);
        ICollection<Clothing> GetAll();
        Clothing GetById(int id);
        void Remove(Clothing clothing);
    }
}