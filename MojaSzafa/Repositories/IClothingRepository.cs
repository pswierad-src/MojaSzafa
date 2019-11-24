using System.Collections.Generic;
using System.Linq;
using MojaSzafa.Models;

namespace MojaSzafa.Repositories
{
    /// <summary>
    /// Interface implemented by ClothingRepository class
    /// </summary>
    public interface IClothingRepository : IRepository
    {
        /// <summary>
        /// Declaration of method that returns collection of all clothes in queryable form
        /// </summary>
        /// <returns>Collection of clothes</returns>
        IQueryable<Clothing> GetAll();

        /// <summary>
        /// Declaration of method that returns piece of clothing specified by Id
        /// </summary>
        /// <param name="id">Clothing id</param>
        /// <returns>Piece of clothing</returns>
        Clothing GetById(int id);

        /// <summary>
        /// Declaration of method for adding clothing to database
        /// </summary>
        /// <param name="clothing">Piece of clothing</param>
        void Add(Clothing clothing);

        /// <summary>
        /// Declaration of method that edits existing clothing
        /// </summary>
        /// <param name="clothing">Edited piece of clothing</param>
        void Edit(Clothing clothing);  

        /// <summary>
        /// Declaration of method for removing clothing
        /// </summary>
        /// <param name="clothing">Piece of clothing to remove</param>
        void Remove(Clothing clothing);
    }
}