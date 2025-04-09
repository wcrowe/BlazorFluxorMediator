using BlazorMediatRFluxor.Shared;
using MediatR; // Required namespace

    namespace BlazorMediatRFluxor.Features.Weather.Queries;

    // Defines the request and the expected response type (IEnumerable<WeatherForecast>)
    public class GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        // Queries can have parameters, e.g., public int DaysToForecast { get; init; }
        // For this example, it's parameterless.
    }
