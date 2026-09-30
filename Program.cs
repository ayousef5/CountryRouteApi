using CountryRouteApi.Services; // Lets us use RouteService

var builder = WebApplication.CreateBuilder(args); // Creates the web app

var app = builder.Build(); // Builds the web app

RouteService routeService = new RouteService(); // Creates our route service

app.MapGet("/{code}", (string code) => // Creates an endpoint like /PAN
{
    List<string> route = routeService.FindRoute(code); // Find the route to the country

    if (route.Count == 0) // Check if no route was found
    {
        return Results.NotFound(new { message = "Country not found" }); // Return a 404 error
    }

    return Results.Ok(new // Return a successful response
    {
        destination = code.ToUpper(), // Show the destination country
        list = route // Show the route
    });
});

app.Run(); // Starts the web server