using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.CreateFoodCategory;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateFoodCommand : IRequest<Result<CreateFoodCommandDto>>
{
    public string? FoodName { get; init; }

    public string? FoodDescription { get; init; }

    public float? FoodPrice { get; init; }

    public int? FoodCategoryId { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Result<CreateFoodCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateFoodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateFoodCommandDto>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.Food.Where(p => p.FoodName == request.FoodName).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new Food();

            entity.FoodName = request.FoodName;

            entity.FoodDescription = request.FoodDescription;

            entity.FoodPrice = request.FoodPrice;

            entity.FoodCategoryId = request.FoodCategoryId;

            entity.IsActive = request.IsActive;

            _context.Food.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateFoodCommandDto
                {
                    Id = entity.UniqueId,
                    CreatedDate = DateTime.Now,
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new CreateFoodCommandDto
                {

                },
                Message = "Record '" + request.FoodName + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

