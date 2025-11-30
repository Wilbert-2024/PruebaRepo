using MartinWilbert.Dtos;

namespace MartinWilbert.Services
{
    public interface ILaboratorioService
    {
        Task<IEnumerable<LaboratorioResponseDto>> GetAllAsync();
        Task<LaboratorioResponseDto?> GetByIdAsync(int id);
        Task CreateAsync(LaboratorioResponseDto dto);
        Task<bool> UpdateAsync(int id, LaboratorioResponseDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
