namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public sealed record CreateUserResponse(Guid Id, string? Email, string? Name);
}
