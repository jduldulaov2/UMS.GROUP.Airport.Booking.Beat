using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantUserLogQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? BookingNumber { get; set; }

    public string? FullName { get; set; }

    public string? BookingLogs { get; set; }

    public string? BookingStatusId { get; set; }

    public bool? IsActive { get; set; }
}
