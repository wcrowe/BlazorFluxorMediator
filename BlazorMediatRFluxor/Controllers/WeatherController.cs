



using BlazorMediatRFluxor.Shared;
using BlazorMediatRFluxor.Shared.Features.Weather.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMediatRFluxor.Controllers;

[ApiController]
[Route("/api/[controller]")] // Route: /api/weather
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherController> _logger;

    public WeatherController(IMediator mediator, ILogger<WeatherController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet] // Handles GET /api/weather
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecasts()
    {
        try
        {
            _logger.LogInformation("API endpoint called: GetWeatherForecasts");
            // The Server project's MediatR instance resolves the handler
            var forecasts = await _mediator.Send(new GetWeatherForecastsQuery());
            return Ok(forecasts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching weather forecasts via API");
            // Return a suitable error response for the client
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}