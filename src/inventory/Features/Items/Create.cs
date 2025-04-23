using inventory.Common;
using Mediator;

namespace inventory.Features.Items;


public class CreateEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/item", async (CreateCommand command, ISender sender) =>
        {
            var itemId = await sender.Send(command);
            return Results.Ok(itemId);
        });
    }
}

public class CreateReponse
{
    public Guid Id { get; set; }
}

public class CreateCommand : IRequest<CreateReponse>
{
    public required string Name { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public Guid SupplierId { get; set; }
    public DateTimeOffset ExpiryDate { get; set; }
}

public class CreateHandler : IRequestHandler<CreateCommand, CreateReponse>
{
    public ValueTask<CreateReponse> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        return new ValueTask<CreateReponse>(new CreateReponse());
    }
}

