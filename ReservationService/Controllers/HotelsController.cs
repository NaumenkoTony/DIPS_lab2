using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Data;
using ReservationService.Models.DomainModels;

namespace ReservationService.Controllers;

public class HotelsControllers(IHotelRepository repository, IMapper mapper) : Controller
{
    private readonly IHotelRepository repository = repository;
    private readonly IMapper mapper = mapper;

    [Route("/api/v1/[controller]")]
    [HttpGet]
    public ActionResult<IEnumerable<HotelResponse>> Get([FromQuery] int page = 0, [FromQuery] int size = 10)
    {   
        var hotels = repository.GetHotels(page, size);
        if (hotels == null)
        {
            return NoContent();
        }

        return Ok(mapper.Map<IEnumerable<HotelResponse>>(hotels));
    }
}