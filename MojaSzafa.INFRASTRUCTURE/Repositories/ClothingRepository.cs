using MojaSzafa.DB;
using MojaSzafa.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MojaSzafa.INFRASTRUCTURE.Repositories
{
    /// <summary>
    /// Class that implements IClothingRepository interface
    /// </summary>
    public class ClothingRepository : IClothingRepository
    {
        private readonly MojaSzafaContext _context;

        public ClothingRepository(MojaSzafaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns collection of all clothes in queryable form
        /// </summary>
        /// <returns>Collection of clothes</returns>
        public ICollection<Clothing> GetAll()
        {
            return _context.Clothes.ToList();
        }

        /// <summary>
        /// Method that returns piece of clothing specified by Id
        /// </summary>
        /// <param name="id">Clothing id</param>
        /// <returns>Piece of clothing</returns>
        public Clothing GetById(int id)
        {
            return _context.Clothes.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Method for adding clothing to database
        /// </summary>
        /// <param name="clothing">Piece of clothing</param>
        public void Add(Clothing clothing)
        {
            _context.Add(clothing);

            _context.SaveChanges();
        }

        /// <summary>
        /// Method that edits existing clothing
        /// </summary>
        /// <param name="clothing">Edited piece of clothing</param>
        public void Edit(Clothing clothing)
        {
            _context.Update(clothing);
            _context.SaveChanges();
        }

        /// <summary>
        /// Method for removing clothing
        /// </summary>
        /// <param name="clothing">Piece of clothing to remove</param>
        public void Remove(Clothing clothing)
        {
            _context.Remove(clothing);
            _context.SaveChanges();
        }
    }
}
