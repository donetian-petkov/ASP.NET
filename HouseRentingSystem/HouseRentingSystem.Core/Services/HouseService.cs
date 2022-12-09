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

}