namespace GatewayService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using GatewayService.DtoModels;
using Newtonsoft.Json.Linq;

[Route("api/v1/")]
public class GatewayController(IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

    [HttpGet("hotels")]
    public async Task<IActionResult> GetHotels([FromQuery] int page, [FromQuery] int size)
    {
        if (page < 0 || size < 1)
        {
            return BadRequest(new { message = "Invalid pagination parameters" });
        }

        var client = httpClientFactory.CreateClient("ReservationService");
        var response = await client.GetAsync($"/api/v1/hotels?page={page}&size={size}");
        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, new { message = "Error fetching hotels from microservice" });
        }

        var jsonString = await response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(jsonString);
        var pagedResponse = new PagedHotelResponse<string>
        {
            Page = page,
            PageSize = size,
            TotalElements = jsonArray.Count,
            Items = [jsonString]
        };

        return Ok(pagedResponse);
    }
}
