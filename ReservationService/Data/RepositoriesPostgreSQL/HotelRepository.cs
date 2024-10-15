namespace ReservationService.Data.RepositoriesPostgreSQL;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationService.Models.DomainModels;

public class HotelRepository(ReservationsContext context) : Repository<Hotel>(context), IHotelRepository
{
    private ReservationsContext db = context;    

    public async Task<IEnumerable<Hotel>> GetHotels(int page, int size)
    {
        return await db.Hotels
                       .Skip((page) * size)
                       .Take(size)
                       .ToListAsync();
    }
}