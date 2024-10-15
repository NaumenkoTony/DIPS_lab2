namespace ReservationService.Data;
using ReservationService.Models.DomainModels;

public interface IHotelRepository : IRepository<Hotel>
{
    public Task<IEnumerable<Hotel>> GetHotels(int page, int size);
}
