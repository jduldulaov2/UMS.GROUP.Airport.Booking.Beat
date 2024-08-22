using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.CreateFoodCategory;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateFoodCategoryCommand : IRequest<Result<CreateFoodCategoryCommandDto>>
{
    public string? CategoryName { get; init; }

    public string? CategoryDescription { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateFoodCategoryCommandHandler : IRequestHandler<CreateFoodCategoryCommand, Result<CreateFoodCategoryCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateFoodCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateFoodCategoryCommandDto>> Handle(CreateFoodCategoryCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.FoodCategory.Where(p => p.CategoryName == request.CategoryName).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new FoodCategory();

            entity.CategoryName = request.CategoryName;

            entity.CategoryDescription = request.CategoryDescription;

            entity.IsActive = request.IsActive;

            _context.FoodCategory.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateFoodCategoryCommandDto
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
                Data = new CreateFoodCategoryCommandDto
                {

                },
                Message = "Record '" + request.CategoryName + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

