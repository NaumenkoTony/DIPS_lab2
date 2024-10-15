namespace ReservationService.Models.Dto;

public partial class HotelBookRequest
{
    public int HotelId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndData { get; set; }
}
