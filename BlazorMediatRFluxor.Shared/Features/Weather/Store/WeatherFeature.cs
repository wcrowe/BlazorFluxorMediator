using BlazorMediatRFluxor.Shared;
using Fluxor; // Required namespace
using System.Collections.Generic;

namespace BlazorMediatRFluxor.Shared.Features.Weather.Store;

    // Defines the feature itself, linking it to the state and providing initial state
    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName() => "Weather"; // Unique name for this feature state slice

        protected override WeatherState GetInitialState() =>
            new WeatherState(
                isLoading: false,
                forecasts: null, // Enumerable.Empty<WeatherForecast>(),
                errorMessage: null);
    }
