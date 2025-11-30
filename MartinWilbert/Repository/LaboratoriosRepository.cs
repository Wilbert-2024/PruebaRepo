namespace MartinWilbert.Repository

    public interface LaboratoriosRepository
    {
        Task<IEnumerable<Laboratorio>> GetAllAsync();
        Task<Laboratorio> GetByIdAsync(int id);
        Task AddAsync(Laboratorio laboratorio);
        Task UpdateAsync(Laboratorio laboratorio);
        Task DeleteAsync(int id);

    }
}
