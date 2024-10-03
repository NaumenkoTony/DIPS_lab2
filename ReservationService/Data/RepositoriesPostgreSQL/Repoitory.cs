namespace ReservationService.Data.RepositoriesPostgreSQL;

using Microsoft.EntityFrameworkCore;

public class Repository<Model>(ReservationsContext context) : IRepository<Model> where Model : class
{
    private readonly ReservationsContext db = context;

    public void Create(Model model)
    {
        db.Set<Model>().Add(model);
        db.SaveChanges();
    }

    public IEnumerable<Model> Read()
    {
        return db.Set<Model>().AsEnumerable();
    }

    public Model? Read(int id)
    {
        return db.Set<Model>().Find(id);
    }

    public void Delete(int id)
    {
        var model = db.Set<Model>().Find(id);
        if (model != null)
        {
            db.Set<Model>().Remove(model);
            db.SaveChanges();
        }
    }
    public void Update(Model model)
    {
        db.Entry(model).State = EntityState.Modified;
        db.SaveChanges();
    }
}