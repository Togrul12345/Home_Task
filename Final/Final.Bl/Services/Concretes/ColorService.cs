using AutoMapper;
using Final.Bl.Dtos.ColorDtos;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Final.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Concretes
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<Color> Create(CreateColorDto createColorDto)
        {
           Color color= _mapper.Map<Color>(createColorDto);
           await _colorRepository.CreateAsync(color);
            await _colorRepository.SaveChangesAsync();
            return color;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           await _colorRepository.HardDeleteAsync(id);
           await _colorRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<Color>> GetAll()
        {
            return await _colorRepository.GetAllAsync();
        }

        public async Task<Color> GetById(int id)
        {
            return await _colorRepository.GetByIdAsync(id);
        }

        public async Task<bool> Update(int id, UpdateColorDto updateColorDto)
        {
           Color color= _mapper.Map<Color>(updateColorDto);
            color.Id = id;
            _colorRepository.Update(color);
           await _colorRepository.SaveChangesAsync();
            return true;
        }
    }
}
