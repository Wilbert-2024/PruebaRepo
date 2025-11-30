using MartinWilbert.Data;
using MartinWilbert.Models;
using MartinWilbert.Repository;
using Microsoft.EntityFrameworkCore;

namespace MartinWilbert.Repositories
{
    public class LaboratorioRepository : ILaboratorioRepository
    {
        private readonly AppDbContext _context;
        public LaboratorioRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Laboratorio>> GetAllAsync()
        {
            return await _context.Laboratorios
                .Include(l => l.Reservas) // si quieres incluir reservas
                .ToListAsync();
        }

        public async Task<Laboratorio> GetByIdAsync(int id)
        {
            return await _context.Laboratorios
                .Include(l => l.Reservas)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(Laboratorio laboratorio)
        {
            await _context.Laboratorios.AddAsync(laboratorio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Laboratorio laboratorio)
        {
            _context.Laboratorios.Update(laboratorio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var laboratorio = await GetByIdAsync(id);
            if (laboratorio != null)
            {
                _context.Laboratorios.Remove(laboratorio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
