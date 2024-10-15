using Microsoft.AspNetCore.Mvc;
using ReservationService.Data;
using ReservationService.Models.DomainModels;
using ReservationService.Models.Dto;

namespace ReservationService.Controllers;

public class LoyaltiesController(ILoyalityRepository repository) : Controller
{
    private readonly ILoyalityRepository repository = repository;
}