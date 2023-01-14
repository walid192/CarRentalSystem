using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models;

public partial class Car
{
    public string? Brand { get; set; }

    public string? Model { get; set; }

    public int? PassingYear { get; set; }

    public string? CarNumber { get; set; }

    public string? Engine { get; set; }

    public string? FuelType { get; set; }
    
    public string? ImagePath { get; set; }

    public int? SeatingCapacity { get; set; }

    public int Id { get; set; }

    [NotMapped]
    public IFormFile CarImage { get; set; }
}
