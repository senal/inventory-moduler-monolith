using Microsoft.AspNetCore.Routing;

namespace Extensions;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}