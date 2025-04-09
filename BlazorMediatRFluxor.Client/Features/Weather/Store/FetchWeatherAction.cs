using System.Collections.Generic;
using System.Diagnostics;
using BlazorMediatRFluxor.Shared;

namespace BlazorMediatRFluxor.Client.Features.Weather.Store;

    // Action to initiate the fetch process
    public class FetchWeatherAction {
        
}

// Action dispatched when fetching succeeds
public class FetchWeatherSuccessAction
    {
        public IEnumerable<WeatherForecast> Forecasts { get; }

        public FetchWeatherSuccessAction(IEnumerable<WeatherForecast> forecasts)
        {
            Forecasts = forecasts;
        }
    }

    // Action dispatched when fetching fails
    public class FetchWeatherFailureAction
    {
        public string ErrorMessage { get; }

        public FetchWeatherFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
