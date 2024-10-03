using Microsoft.EntityFrameworkCore;
using ReservationService.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<ReservationsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ReservationService")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

app.Run();
