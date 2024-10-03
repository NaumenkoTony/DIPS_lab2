﻿using System;
using System.Collections.Generic;

namespace ReservationService.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public Guid ReservationUid { get; set; }

    public string Username { get; set; } = null!;

    public Guid PaymentUid { get; set; }

    public int? HotelId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndData { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
