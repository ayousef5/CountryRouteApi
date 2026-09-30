# Country Route API

A C# ASP.NET Core Web API that finds a route from the USA to a destination country based on shared borders.

## Live Demo

**Azure:**
https://country-route-api-ahmed-2026-g8fygwf0eve4h0d0.centralus-01.azurewebsites.net

**Example:**
https://country-route-api-ahmed-2026-g8fygwf0eve4h0d0.centralus-01.azurewebsites.net/PAN

## How It Works

The countries are represented as a graph:

* Countries = nodes
* Shared borders = edges
* Breadth-First Search (BFS) finds the route from the USA

Example:

```text
USA → MEX → GTM → HND → NIC → CRI → PAN
```

## Technologies

* C#
* ASP.NET Core
* .NET 10
* REST API
* GitHub Actions
* Microsoft Azure App Service

## Run Locally

```bash
git clone https://github.com/ayousef5/CountryRouteApi.git
cd CountryRouteApi
dotnet run
```

Then visit:

`http://localhost:5297/PAN`

## Deployment

Deployed to **Microsoft Azure App Service** using **GitHub Actions** for automatic deployment from the `main` branch.
