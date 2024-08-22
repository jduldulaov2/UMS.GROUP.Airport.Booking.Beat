using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateRestaurantOrderDetailCommandDto
{
    public string? Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? PrimaryId { get; set; }
}

