namespace ReservationService.Models.DomainModels;

public partial class HotelResponse
{
    public Guid HotelUid { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? Stars { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
