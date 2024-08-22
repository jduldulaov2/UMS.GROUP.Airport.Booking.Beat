using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateRestaurantOrderDetailCommand : IRequest<Result<UpdateRestaurantOrderDetailCommandDto>>
{
    public string? UniqueId { get; init; }

    public int? RestaurantOrderID { get; init; }

    public int? FoodID { get; init; }

    public float? OrderDetailFoodPrice { get; init; }

    public float? OrderQuantity { get; init; }

    public float? OrderTotalAmount { get; init; }

    public string? OrderSource { get; init; }

    public string? OrderDetailNotes { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateRestaurantOrderDetailCommandHandler : IRequestHandler<UpdateRestaurantOrderDetailCommand, Result<UpdateRestaurantOrderDetailCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateRestaurantOrderDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateRestaurantOrderDetailCommandDto>> Handle(UpdateRestaurantOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.RestaurantOrderDetail.FirstOrDefault(item => item.UniqueId == request.UniqueId);

        if (entity != null)
        {
            entity.RestaurantOrderID = request.RestaurantOrderID;

            entity.FoodID = request.FoodID;

            entity.OrderDetailFoodPrice = request.OrderDetailFoodPrice;

            entity.OrderQuantity = request.OrderQuantity;

            entity.OrderTotalAmount = request.OrderTotalAmount;

            entity.OrderSource = request.OrderSource;

            entity.OrderDetailNotes = request.OrderDetailNotes;

            entity.IsActive = request.IsActive;

            _context.RestaurantOrderDetail.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new UpdateRestaurantOrderDetailCommandDto
                {
                    Id = entity.UniqueId,
                    UpdatedDate = DateTime.Now,
                },
                Message = "Updated successfully.",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new UpdateRestaurantOrderDetailCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
