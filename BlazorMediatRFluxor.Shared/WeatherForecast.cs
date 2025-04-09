namespace BlazorMediatRFluxor.Shared; // Namespace for the Shared project

// Using a 'record' provides value-based equality and immutability features, // which are often beneficial, especially when working with state management like Fluxor.
// You could also use a 'class'.
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    // Example of a calculated property within the record
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
