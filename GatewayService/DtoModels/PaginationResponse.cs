namespace GatewayService.DtoModels;

public class PagedHotelResponse<THotel>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalElements { get; set; }
    public List<THotel> Items { get; set; } = [];
}