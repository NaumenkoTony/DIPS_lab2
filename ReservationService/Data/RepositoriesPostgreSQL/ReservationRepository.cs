namespace ReservationService.Data.RepositoriesPostgreSQL;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationService.Models.DomainModels;

public class ReservationRepository(ReservationsContext context) : Repository<Reservation>(context), IReservationRepository
{
    private ReservationsContext db = context;

    public async Task<IEnumerable<Reservation>> GetReservationsByUsername(string username)
    {
        return await db.Reservations
                       .Where(r => r.Username == username)
                       .ToListAsync(); 
    }
}