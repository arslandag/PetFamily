using FluentValidation;
using PetFamily.Application.CommonValidators;

namespace PetFamily.Application.Features.Pets.GetPets;

public record GetPetsRequest(
    string? Nickname,
    string? Breed,
    string? Color,
    int Size = 9,
    int Page = 1);

public class GetPetsValidator : AbstractValidator<GetPetsRequest>
{
    public GetPetsValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThanWithError(0);
        RuleFor(x => x.Size).NotNull().GreaterThanWithError(0);
    }
}