using AutoMapper;
using Final.Bl.Dtos.SizeDtos;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Final.Data.GenericRepositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Concretes
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<Size> Create(CreateSizeDto createSizeDto)
        {
           Size size= _mapper.Map<Size>(createSizeDto);
           await _sizeRepository.CreateAsync(size);
            await _sizeRepository.SaveChangesAsync();
            return size;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           await _sizeRepository.HardDeleteAsync(id);
            await _sizeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<Size>> GetAll()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetById(int id)
        {
          return await _sizeRepository.GetByIdAsync(id);
        }

        public async Task<bool> Update(int id, UpdateSizeDto updateSizeDto)
        {
           Size size= _mapper.Map<Size>(updateSizeDto);
            size.Id = id;
            _sizeRepository.Update(size);
           await _sizeRepository.SaveChangesAsync();
            return true;
        }
    }
}
