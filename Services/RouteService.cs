namespace CountryRouteApi.Services; // Puts this class inside the Services namespace

public class RouteService // Creates the service that will find country routes
{
    // Stores which countries share a border
    private readonly Dictionary<string, List<string>> borders = new()
    {
        ["USA"] = new() { "CAN", "MEX" }, // USA borders Canada and Mexico
        ["CAN"] = new() { "USA" },
        ["MEX"] = new() { "USA", "GTM", "BLZ" }, 
        ["BLZ"] = new() { "MEX", "GTM" },
        ["GTM"] = new() { "MEX", "BLZ", "SLV", "HND" }, 
        ["SLV"] = new() { "GTM", "HND" },
        ["HND"] = new() { "GTM", "SLV", "NIC" },
        ["NIC"] = new() { "HND", "CRI" },
        ["CRI"] = new() { "NIC", "PAN" },
        ["PAN"] = new() { "CRI" }
    };

    public List<string> FindRoute(string destination) // Finds a route from USA to the destination
{
    destination = destination.ToUpper(); // Makes the country code uppercase

    Queue<string> queue = new(); // Holds countries we need to explore

    HashSet<string> visited = new(); // Keeps track of countries we already visited

    Dictionary<string, string?> previous = new(); // Remembers where each country came from

    queue.Enqueue("USA"); // Start the search from USA

    visited.Add("USA"); // Mark USA as visited

    previous["USA"] = null; // USA is the starting point, so it has no previous country

    while (queue.Count > 0) // Keep searching while countries are in the queue
    {
        string current = queue.Dequeue(); // Take the next country from the queue

        if (current == destination) // Check if we reached the destination
        {
            break; // Stop searching
        }

        foreach (string neighbor in borders[current]) // Look at countries next to the current country
        {
            if (!visited.Contains(neighbor)) // Only visit countries we have not seen
            {
                visited.Add(neighbor); // Mark this country as visited

                previous[neighbor] = current; // Remember how we reached this country

                queue.Enqueue(neighbor); // Add this country to the queue
            }
        }
    }

    if (!visited.Contains(destination)) // Check if we could not reach the destination
    {
        return new List<string>(); // Return an empty list
    }

    List<string> route = new(); // Creates the final route

    string? currentCountry = destination; // Start building the route from the destination

    while (currentCountry != null) // Keep going until we reach USA
    {
        route.Add(currentCountry); // Add the current country to the route

        currentCountry = previous[currentCountry]; // Move to the country we came from
    }

    route.Reverse(); // Reverse the route so it starts at USA

    return route; // Return the completed route
}
}