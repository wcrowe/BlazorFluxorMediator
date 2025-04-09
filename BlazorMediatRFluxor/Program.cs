using BlazorMediatRFluxor.Components;
using Fluxor;
using System.Reflection;
using BlazorMediatRFluxor.Client; // Add reference to Client project's assembly name
using BlazorMediatRFluxor.Shared.Features.Weather.Store;
using Fluxor.Blazor.Web.ReduxDevTools; // For scanning shared Fluxor items; // <-- Add Fluxor namespace using System.Reflection; // <-- Add Reflection namespace


using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents();
// --- MediatR Configuration ---
// Scans the assembly containing this Program class for MediatR handlers (IRequestHandler, INotificationHandler) 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// --- Fluxor Configuration ---
builder.Services.AddFluxor(options =>
{
    // Scan the assembly containing this Program class for Fluxor features, reducers, effects
    options.ScanAssemblies(typeof(WeatherState).Assembly);

#if DEBUG
    // Enable Redux DevTools integration (install the browser extension)
    options.UseReduxDevTools(devToolsOptions =>
    {
        devToolsOptions.Name = "Blazor MediatR Fluxor App";
    });
#endif
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging(); // <-- Enable WASM debugging
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<BlazorMediatRFluxor.Components.App>()
    .AddInteractiveServerRenderMode()
        // Map requests to the Client project's entry point (_framework/blazor.webassembly.js)
        .AddInteractiveWebAssemblyRenderMode()
        // Tell the server where to find the WASM files
        .AddAdditionalAssemblies(typeof(BlazorMediatRFluxor.Client._Imports).Assembly); // Use a type from Client proj

app.MapControllers(); // <-- Map API controller routes

app.Run();
