using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CodeFood.Service;

public class AdminAreaAuthorization : IControllerModelConvention
{
    private readonly string? _area;
    private readonly string? _policy;

    public AdminAreaAuthorization(string? area, string? policy)
    {
        _policy = policy;
        _area = area;
    }

    public void Apply(ControllerModel controller)
    {
        if (controller.Attributes.Any(area => 
                area is AreaAttribute 
                && (area as AreaAttribute)!.RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase))
            || controller.RouteValues.Any(route =>
                route.Key.Equals("area", StringComparison.OrdinalIgnoreCase)
                && route.Value!.Equals(_area, StringComparison.OrdinalIgnoreCase)))
        {
            controller.Filters.Add(new AuthorizeFilter(_policy!));
        }
    }
}
