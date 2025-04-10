using BlazorMediatRFluxor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using System.Reflection;
using BlazorMediatRFluxor.Shared.Features.Weather.Store; // For scanning shared Fluxor items
using BlazorMediatRFluxor.Client.Features.Weather.Store;
using Fluxor.Blazor.Web.ReduxDevTools; // For scanning client effects

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// --- Fluxor Configuration ---
builder.Services.AddFluxor(options =>
{
    // Scan Shared assembly for Features, Reducers
    options.ScanAssemblies(typeof(WeatherState).Assembly);
    // Scan Client assembly for Effects
    options.ScanAssemblies(Assembly.GetExecutingAssembly());

#if DEBUG
    options.UseReduxDevTools(devToolsOptions =>
    {
        devToolsOptions.Name = "Blazor MediatR Fluxor App (WASM)";
    });
#endif
});

await builder.Build().RunAsync();
