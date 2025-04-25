using Extensions;
using ItemEvents;
using MessageBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace ItemsService;

public class CreateItem : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/items/create",
            async Task<Results<Ok<CreateItemResponse>, NotFound, BadRequest, ProblemHttpResult>> (CreateItemRequest request,
                CancellationToken cancellationToken, ICreateItemHandler handler) =>
            {
                var results = await handler.Handle(request, cancellationToken);
                return TypedResults.Ok(results);
            });
    }
}

public interface ICreateItemHandler
{
    Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken);
}

[Scoped]
public class CreateItemHandler(IEventBus eventBus) : ICreateItemHandler
{
    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        await eventBus.PublishAsync(new ItemCreatedEvent{ Id = Guid.NewGuid()}, cancellationToken);
        return await Task.FromResult(new CreateItemResponse(Guid.NewGuid()));
    }
}


public record CreateItemRequest(string ItemName);
public record CreateItemResponse(Guid Id);


