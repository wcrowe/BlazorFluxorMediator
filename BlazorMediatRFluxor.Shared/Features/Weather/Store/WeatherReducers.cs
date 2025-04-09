using Fluxor; // Required namespace
using System.Linq;

namespace BlazorMediatRFluxor.Shared.Features.Weather.Store;

    // Contains pure functions that modify the state based on actions
    public static class WeatherReducers
    {
        [ReducerMethod] // Marks this method as a reducer for FetchWeatherAction
        public static WeatherState ReduceFetchWeatherAction(WeatherState state, FetchWeatherAction action) =>
            state with // Using C# 'with' expression for immutability with records
            {
                IsLoading = true,
                ErrorMessage = null // Clear previous errors
            };

        [ReducerMethod]
        public static WeatherState ReduceFetchWeatherSuccessAction(WeatherState state, FetchWeatherSuccessAction action) =>
            state with
            {
                IsLoading = false,
                Forecasts = action.Forecasts,
                ErrorMessage = null
            };

        [ReducerMethod]
        public static WeatherState ReduceFetchWeatherFailureAction(WeatherState state, FetchWeatherFailureAction action) =>
            state with
            {
                IsLoading = false,
                Forecasts = null, // Or Enumerable.Empty<WeatherForecast>()
                ErrorMessage = action.ErrorMessage
            };
    }
