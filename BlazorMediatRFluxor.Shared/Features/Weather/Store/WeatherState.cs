using BlazorMediatRFluxor.Shared;
using Fluxor; // Required namespace
using System.Collections.Generic;

namespace BlazorMediatRFluxor.Shared.Features.Weather.Store;

    // Defines the state slice for the weather feature
   // [FeatureState] // Marks this class as a Fluxor feature state
    public record WeatherState // Using record for immutability (good practice with Fluxor)
    {
        public bool IsLoading { get; init; }
        public IEnumerable<WeatherForecast>? Forecasts { get; init; }
        public string? ErrorMessage { get; init; }

        // Private constructor for Fluxor initialization
        private WeatherState() { }

        // Public constructor for initial state (optional, can be done in Feature)
        public WeatherState(bool isLoading, IEnumerable<WeatherForecast>? forecasts, string? errorMessage)
        {
            IsLoading = isLoading;
            Forecasts = forecasts;
            ErrorMessage = errorMessage;
        }
    }
