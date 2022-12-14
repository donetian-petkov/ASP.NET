using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;

public class HouseService : IHouseService
{

    private readonly IRepository repository;

    public HouseService(IRepository _repository)
    {
        repository = _repository;
    }

    public async Task<IEnumerable<HouseHomeModel>> LastThreeHouses()
    {
        return await repository.AllReadonly<House>()
            .OrderByDescending(h => h.Id)
            .Take(3)
            .Select(h => new HouseHomeModel()
            {
                Id = h.Id,
                ImageUrl = h.ImageUrl,
                Title = h.Title
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseCategoryModel>> AllCategories()
    {
        return await repository.AllReadonly<Category>()
            .OrderBy(c => c.Name)
            .Select(c => new HouseCategoryModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<bool> CategoryExists(int categoryId)
    {
        return await repository.AllReadonly<Category>()
            .AnyAsync(h => h.Id == categoryId);
    }

    public async Task<int> Create(HouseModel model, int agentId)
    {
        var house = new House()
        {
            Address = model.Address,
            CategoryId = model.CategoryId,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            Title = model.Title,
            AgentId = agentId
        };

        await repository.AddAsync(house);
        await repository.SaveChangesAsync();

        return house.Id;
    }
}