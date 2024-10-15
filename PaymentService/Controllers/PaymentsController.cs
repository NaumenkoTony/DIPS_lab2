using Microsoft.AspNetCore.Mvc;
using ReservationService.Data;
using ReservationService.Models.DomainModels;
using ReservationService.Models.Dto;

namespace ReservationService.Controllers;

public class PaymentsController(IPaymentRepository repository) : Controller
{
    private readonly IPaymentRepository repository = repository;
}