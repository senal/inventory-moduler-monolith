using Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SupplierService;

public class CreateSupplier : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/suppliers/create",
            async (CreateSupplierRequest request, CancellationToken cancellationToken,
                ICreateSupplierHandler handler) =>
            {
                var results = await handler.Handle(request, cancellationToken);
                return Results.Ok(results);
            });
    }
}

public interface ICreateSupplierHandler
{
    Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken);
}

[Scoped]
public class CreateSupplierHandler : ICreateSupplierHandler
{
    public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new CreateSupplierResponse(Guid.NewGuid()));
    }
}

public record CreateSupplierRequest(string Name, int PostCode);
public record CreateSupplierResponse(Guid Id);
