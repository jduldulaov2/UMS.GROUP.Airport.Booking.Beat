using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateRestaurantOrderDetailCommand : IRequest<Result<CreateRestaurantOrderDetailCommandDto>>
{
    public int? RestaurantOrderID { get; init; }

    public int? FoodID { get; init; }

    public float? OrderDetailFoodPrice { get; init; }

    public float? OrderQuantity { get; init; }

    public float? OrderTotalAmount { get; init; }

    public string? OrderSource { get; init; }

    public string? OrderDetailNotes { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateRestaurantOrderDetailCommandHandler : IRequestHandler<CreateRestaurantOrderDetailCommand, Result<CreateRestaurantOrderDetailCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateRestaurantOrderDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateRestaurantOrderDetailCommandDto>> Handle(CreateRestaurantOrderDetailCommand request, CancellationToken cancellationToken)
    {
        // Add new record

        var entity = new RestaurantOrderDetail();

        entity.RestaurantOrderID = request.RestaurantOrderID;

        entity.FoodID = request.FoodID;

        entity.OrderDetailFoodPrice = request.OrderDetailFoodPrice;

        entity.OrderQuantity = request.OrderQuantity;

        entity.OrderTotalAmount = request.OrderTotalAmount;

        entity.OrderSource = request.OrderSource;

        entity.OrderDetailNotes = request.OrderDetailNotes;

        entity.IsActive = request.IsActive;

        _context.RestaurantOrderDetail.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Data = new CreateRestaurantOrderDetailCommandDto
            {
                Id = entity.UniqueId,
                CreatedDate = DateTime.Now,
                PrimaryId = entity.Id
            },
            Message = "success",
            ResultType = ResultType.Success,
        };
    }
}

