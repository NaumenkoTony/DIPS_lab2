namespace ReservationService.Data.RepositoriesPostgreSQL;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Repository<Model>(DbContext context) : IRepository<Model> where Model : class
{
    private readonly DbContext db = context;

    public async Task CreateAsync(Model model)
    {
        await db.Set<Model>().AddAsync(model);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Model>> ReadAsync()
    {
        return await db.Set<Model>().ToListAsync();
    }

    public async Task<Model?> ReadAsync(int id)
    {
        return await db.Set<Model>().FindAsync(id);
    }

    public async Task DeleteAsync(int id)
    {
        var model = await db.Set<Model>().FindAsync(id);
        if (model != null)
        {
            db.Set<Model>().Remove(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Model model)
    {
        db.Entry(model).State = EntityState.Modified;
        await db.SaveChangesAsync();
    }
}
