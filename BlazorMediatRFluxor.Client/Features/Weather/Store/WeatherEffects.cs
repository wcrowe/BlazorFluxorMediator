using BlazorMediatRFluxor.Shared.Features.Weather.Store;
using BlazorMediatRFluxor.Shared;
using Fluxor;
using System.Net.Http.Json;

namespace BlazorMediatRFluxor.Client.Features.Weather.Store;

public class WeatherEffects
{
    private readonly HttpClient _httpClient; // Inject HttpClient
    private readonly ILogger<WeatherEffects> _logger;

    // Inject HttpClient configured in Program.cs
    public WeatherEffects(HttpClient httpClient, ILogger<WeatherEffects> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [EffectMethod(typeof(FetchWeatherAction))]
    public async Task HandleFetchWeatherAction(IDispatcher dispatcher)
    {
        _logger.LogInformation("Handling FetchWeatherAction effect (WASM)...");
        try
        {
            // Call the API endpoint on the server
            var forecasts = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("api/weather"); // Relative URL

            if (forecasts != null)
            {
                // Dispatch success action with data from API
                dispatcher.Dispatch(new FetchWeatherSuccessAction(forecasts));
                _logger.LogInformation("Weather data fetched successfully via API.");
            }
            else
            {
                _logger.LogWarning("Received null forecast data from API.");
                dispatcher.Dispatch(new FetchWeatherFailureAction("Received no data from the server."));
            }
        }
        catch (Exception ex) // Catch HttpRequestException, JsonException, etc.
        {
            _logger.LogError(ex, "Error fetching weather data via API");
            // Dispatch failure action
            dispatcher.Dispatch(new FetchWeatherFailureAction($"Failed to fetch weather via API: {ex.Message}"));
        }
    }

}
