using Final.Bl.Dtos.ColorDtos;
using Final.Bl.Dtos.SizeDtos;
using Final.Core;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Interfaces
{
    public interface IColorService
    {
        Task<Color> Create(CreateColorDto createColorDto);
        Task<bool> DeleteAsync(int id);
        Task<Color> GetById(int id);
        Task<List<Color>> GetAll();
        Task<bool> Update(int id, UpdateColorDto updateColorDto);
    }
}
