using System;
using System.Collections.Generic;

namespace Car_Rental_System.Models;

public partial class Rent
{
    public int Id { get; set; }

    public string? PickUp { get; set; }

    public string? DropOff { get; set; }

    public string? PickUpDate { get; set; }

    public string? DropOffDate { get; set; }

    public int? TotalRun { get; set; }

    public int? Rate { get; set; }

    public int? TotalAmount { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public int? DriverId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerContactNo { get; set; }
}
