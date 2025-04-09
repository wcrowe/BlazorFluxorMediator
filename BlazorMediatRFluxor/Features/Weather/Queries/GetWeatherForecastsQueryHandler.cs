using BlazorMediatRFluxor.Shared;
using BlazorMediatRFluxor.Shared.Features.Weather.Queries;
using MediatR; // Required namespace
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    namespace BlazorMediatRFluxor.Features.Weather.Queries;

    // Handles the GetWeatherForecastsQuery request
    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
    {
        // In a real app, inject services like HttpClient, DbContext, etc. here
        // private readonly IMyDataService _dataService;
        // public GetWeatherForecastsQueryHandler(IMyDataService dataService) { ... }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            // Simulate asynchronous work (e.g., API call, database query)
            await Task.Delay(1500, cancellationToken); // Simulate network latency

            // Simulate potential failure
            // if (Random.Shared.Next(0, 5) == 0) // Uncomment to test error case
            // {
            //     throw new InvalidOperationException("Failed to fetch weather data from the source!");
            // }

            // Generate sample data
            var forecasts = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                )).ToArray();

            return forecasts;
        }
    }
