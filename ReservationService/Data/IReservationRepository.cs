namespace ReservationService.Data;
using ReservationService.Models.DomainModels;

public interface IReservationRepository : IRepository<Reservation>
{
    public Task<IEnumerable<Reservation>> GetReservationsByUsername(string username);
}
