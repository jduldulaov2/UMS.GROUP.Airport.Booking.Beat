using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantTableQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? TableName { get; set; }

    public string? TableDescription { get; set; }

    public string? TableLocation { get; set; }

    public bool? IsActive { get; set; }
}
