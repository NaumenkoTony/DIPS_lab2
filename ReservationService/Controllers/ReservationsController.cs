using Microsoft.AspNetCore.Mvc;
using ReservationService.Data;
using ReservationService.Models.DomainModels;
using ReservationService.Models.Dto;

namespace ReservationService.Controllers;

public class ReservationsController(IReservationRepository repository) : Controller
{
    private readonly IReservationRepository repository = repository;

    [Route("/api/v1/[controller]/{username}")]
    [HttpGet]
    public ActionResult<IEnumerable<Hotel>> GetByUsername(string username)
    {
        return Ok(repository.GetReservationsByUsername(username));
    }

}