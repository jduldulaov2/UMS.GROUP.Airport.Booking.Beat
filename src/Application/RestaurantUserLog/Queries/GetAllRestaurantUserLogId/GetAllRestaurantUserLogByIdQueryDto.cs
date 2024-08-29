using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantUserLogByIdQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? BookingNumber { get; set; }

    public string? FullName { get; set; }

    public string? BookingLogs { get; set; }

    public string? BookingStatusId { get; set; }

    public string? BookingUniqueId { get; set; }

    public bool? IsActive { get; set; }
}
