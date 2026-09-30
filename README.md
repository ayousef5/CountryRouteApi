# Country Route API

A C# ASP.NET Web API that finds the route a driver must travel from the USA to a destination country.

## How It Works

The countries are represented as a graph.

- Each country is a node.
- A shared border is an edge.
- Breadth-First Search (BFS) finds a route from the USA to the destination.

The API uses a queue to explore countries and keeps track of visited countries to avoid repeating them.

## API Endpoint

```text
GET /{country-code}

