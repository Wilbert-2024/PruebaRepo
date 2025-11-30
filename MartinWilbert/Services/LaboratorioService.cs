using AutoMapper;
using MartinWilbert.Dtos;
using MartinWilbert.Models;
using MartinWilbert.Repository;

namespace MartinWilbert.Services
{
    public class LaboratorioService : ILaboratorioService
    {
        private readonly ILaboratorioRepository _repository;
        private readonly IMapper _mapper;

        public LaboratorioService(ILaboratorioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LaboratorioResponseDto>> GetAllAsync()
        {
            var laboratorios = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LaboratorioResponseDto>>(laboratorios);
        }

        public async Task<LaboratorioResponseDto?> GetByIdAsync(int id)
        {
            var lab = await _repository.GetByIdAsync(id);
            return lab == null ? null : _mapper.Map<LaboratorioResponseDto>(lab);
        }

        public async Task CreateAsync(LaboratorioResponseDto dto)
        {
            var lab = _mapper.Map<Laboratorio>(dto);
            await _repository.AddAsync(lab);
        }

        public async Task<bool> UpdateAsync(int id, LaboratorioResponseDto dto)
        {
            var lab = await _repository.GetByIdAsync(id);
            if (lab == null) return false;

            lab.LabName = dto.LabName;
            lab.Descripcion = dto.Descripcion;

            await _repository.UpdateAsync(lab);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lab = await _repository.GetByIdAsync(id);
            if (lab == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
