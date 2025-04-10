using BlazorMediatRFluxor.Components;
using Fluxor;
using System.Reflection;
using BlazorMediatRFluxor.Shared.Features.Weather.Store;
using Fluxor.Blazor.Web.ReduxDevTools; // For scanning shared Fluxor items; // <-- Add Fluxor namespace using System.Reflection; // <-- Add Reflection namespace
using BlazorFluxorMediator.Client;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient();
builder.Services.AddControllers(); // <-- Add API controller services
builder.Services.AddScoped(sp =>
{
    NavigationManager navigation = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(navigation.BaseUri) };
});
// --- MediatR Configuration ---
// Scans the assembly containing this Program class for MediatR handlers (IRequestHandler, INotificationHandler) 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// --- Fluxor Configuration ---
builder.Services.AddFluxor(options =>
{
    // Scan the assembly containing this Program class for Fluxor features, reducers, effects
    options.ScanAssemblies(typeof(WeatherState).Assembly);
    options.ScanAssemblies(typeof(BlazorMediatRFluxor.Shared.WeatherForecast).Assembly);
    options.ScanAssemblies(Assembly.GetExecutingAssembly()); 
    options.ScanAssemblies(typeof(BlazorFluxorMediator.Client.Features.Weather.Store.WeatherEffects).Assembly);

#if DEBUG
    // Enable Redux DevTools integration (install the browser extension)
    options.UseReduxDevTools(devToolsOptions =>
    {
        devToolsOptions.Name = "Blazor MediatR Fluxor App";
    });
#endif
});
//builder.Services.AddCascadingAuthenticationState();
//builder.Services.AddAuthorization();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
        // Map requests to the Client project's entry point (_framework/blazor.webassembly.js)
        .AddInteractiveWebAssemblyRenderMode()
        // Tell the server where to find the WASM files
        .AddAdditionalAssemblies(typeof(BlazorFluxorMediator.Client._Imports).Assembly); // Use a type from Client proj
app.MapControllers(); // <-- Map API controller routes

app.Run();
