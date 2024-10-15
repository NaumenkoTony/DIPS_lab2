namespace ReservationService.Data;

public interface IRepository<Model> where Model : class
{
    Task CreateAsync(Model model);

    Task<IEnumerable<Model>> ReadAsync();

    Task<Model?> ReadAsync(int id);

    Task UpdateAsync(Model model);

    Task DeleteAsync(int id);
}
