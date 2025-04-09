    using Fluxor; // Required namespace
    using MediatR; // Required namespace
    using System;
    using System.Threading.Tasks;
    using BlazorMediatRFluxor.Features.Weather.Queries;
using BlazorMediatRFluxor.Shared.Features.Weather.Store;
using BlazorMediatRFluxor.Shared.Features.Weather.Queries; // Import the MediatR query

namespace BlazorMediatRFluxor.Features.Weather.Store;

    // Handles side effects, like API calls, triggered by actions
    public class WeatherEffects
    {
        private readonly IMediator _mediator; // Inject MediatR
        private readonly ILogger<WeatherEffects> _logger;

        public WeatherEffects(IMediator mediator, ILogger<WeatherEffects> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [EffectMethod] // Marks this as an effect method triggered by FetchWeatherAction
        public async Task HandleFetchWeatherAction(FetchWeatherAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Handling FetchWeatherAction effect...");
            try
            {
                // Use MediatR to send the query. The handler we created will execute.
                var forecasts = await _mediator.Send(new GetWeatherForecastsQuery());

                // Dispatch the success action with the result from MediatR handler
                dispatcher.Dispatch(new FetchWeatherSuccessAction(forecasts));
                _logger.LogInformation("Weather data fetched successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weather data via MediatR");
                // Dispatch the failure action if the MediatR handler throws an exception
                dispatcher.Dispatch(new FetchWeatherFailureAction($"Failed to fetch weather: {ex.Message}"));
            }
        }
    }
