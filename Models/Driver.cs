using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models;

public partial class Driver
{
    
    public int Id { get; set; }

    public string? DriverName { get; set; }

    public string? Address { get; set; }

    public string? MobileNumber { get; set; }

    public int? Age { get; set; }

    public int? Experience { get; set; }

    public string? ImagePath { get; set; }

    [NotMapped]
    public IFormFile DriverImage { get; set; }
}
