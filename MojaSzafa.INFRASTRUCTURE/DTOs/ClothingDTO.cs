using System;
using System.Collections.Generic;
using System.Text;

namespace MojaSzafa.INFRASTRUCTURE.DTOs
{
    public class ClothingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
