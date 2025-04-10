using BlazorMediatRFluxor.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using BlazorMediatRFluxor.Shared.Features.Weather.Store; // For scanning shared Fluxor items
using Fluxor.Blazor.Web.ReduxDevTools; // For scanning client effects

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
builder.Services.AddHttpClient();
// --- Fluxor Configuration ---
builder.Services.AddFluxor(options =>
{
    // Scan Shared assembly for Features, Reducers
 
    // Scan Client assembly for Effects
    options.ScanAssemblies(typeof(_Imports).Assembly);

#if DEBUG
    options.UseReduxDevTools(devToolsOptions =>
    {
        devToolsOptions.Name = "Blazor MediatR Fluxor App (WASM)";
    });
#endif
});

await builder.Build().RunAsync();
