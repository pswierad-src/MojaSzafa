using MojaSzafa.DB.Entities;
using MojaSzafa.INFRASTRUCTURE.DTOs;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MojaSzafa.INFRASTRUCTURE.Mappers
{
    public static class MapperConfig
    {
        public static void Init()
        {
            Mapper.AddMap<ClothingDTO, Clothing>(s => new Clothing
            {
                Id = s.Id,
                Name = s.Name,
                Color = s.Color,
                Material = s.Material,
                DateAdded = s.DateAdded
            });
        }
    }
}
