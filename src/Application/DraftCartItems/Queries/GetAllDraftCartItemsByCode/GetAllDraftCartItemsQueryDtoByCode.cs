using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllDraftCartItemsQueryDtoByCode
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? BookingReservationId { get; set; }

    public int? FoodId { get; set; }

    public bool? IsActive { get; set; }
}
