using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Dtos;
using PetFamily.Application.Features.Pets.GetPets;
using PetFamily.Application.Providers;
using PetFamily.Infrastructure.DbContexts;
using PetFamily.Infrastructure.Queries.Volunteers;

namespace PetFamily.Infrastructure.Queries.Pets;

public class GetPetsQuery
{
    private readonly PetFamilyReadDbContext _dbContext;
    private readonly ICacheProvider _cacheProvider;

    public GetPetsQuery(PetFamilyReadDbContext dbContext, ICacheProvider cacheProvider)
    {
        _dbContext = dbContext;
        _cacheProvider = cacheProvider;
    }

    public async Task<Result<GetPetsResponse>> Handle(GetPetsRequest request, CancellationToken ct)
    {
         return await _cacheProvider.GetOrSetAsync(
             CacheKeys.Pets,
             async () =>
             {
                 var pet = await _dbContext.Pets
                     .OrderBy(p => p.CreatedDate)
                     .Skip(request.Size * (request.Page - 1))
                     .Take(request.Size)
                     .ToListAsync(cancellationToken: ct);

                 var petDto = pet.Select(p => new PetDto(
                     p.Id,
                     p.Nickname,
                     p.Description,
                     p.Address.City,
                     p.Address.Street,
                     p.Address.Building,
                     p.Address.Index,
                     p.ContactPhoneNumber.Number,
                     p.CreatedDate)).ToList();

                 return new GetPetsResponse(petDto);
             },
             ct) ?? new([]);
     }
}