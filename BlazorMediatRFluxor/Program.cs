using System.Reflection;
using BlazorMediatRFluxor.Components;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools; // <-- Add Fluxor namespace using System.Reflection; // <-- Add Reflection namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Make sure you have interactivity enabled

// --- MediatR Configuration ---
// Scans the assembly containing this Program class for MediatR handlers (IRequestHandler, INotificationHandler) 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// --- Fluxor Configuration ---
builder.Services.AddFluxor(options =>
{
    // Scan the assembly containing this Program class for Fluxor features, reducers, effects
    options.ScanAssemblies(typeof(Program).Assembly);

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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
