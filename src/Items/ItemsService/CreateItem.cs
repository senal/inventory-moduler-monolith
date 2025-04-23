using Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ItemsService;

public class CreateItem : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    { 
        app.MapPost("api/items/create", async (CreateItemRequest request, CancellationToken cancellationToken, ICreateItemHandler handler) =>
        {
            var results = await handler.Handle(request, cancellationToken);
            return Results.Ok(results);
        });
    }
}

public interface ICreateItemHandler
{
    Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken);
}

[Scoped]
public class CreateItemHandler : ICreateItemHandler
{
    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new CreateItemResponse(Guid.NewGuid()));
    }
}


public record CreateItemRequest(string ItemName);
public record CreateItemResponse(Guid Id);