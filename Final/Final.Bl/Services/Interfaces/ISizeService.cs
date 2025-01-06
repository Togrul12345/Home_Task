using Final.Bl.Dtos.CategoryDtos;
using Final.Bl.Dtos.ProductDtos;
using Final.Bl.Dtos.SizeDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Interfaces
{
    public interface ISizeService
    {
        Task<Size> Create(CreateSizeDto createSizeDto);
        Task<bool> DeleteAsync(int id);
        Task<Size> GetById(int id);
        Task<List<Size>> GetAll();
        Task<bool> Update(int id, UpdateSizeDto updateSizeDto);
    }
}
