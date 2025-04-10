using System.Reflection;
using BlazorFluxorMediator.Client;
using BlazorFluxorMediator.Client.Features.Weather.Store;
using BlazorMediatRFluxor.Shared.Features.Weather.Store;
using Fluxor;

using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
builder.Services.AddScoped(sp =>
{
//    NavigationManager navigation = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
}));

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(
        typeof(WeatherState).Assembly, // Scan Shared assembly
        //typeof(WeatherEffects).Assembly,
       Assembly.GetExecutingAssembly() // Scan Client assembly (for Effects)
    );
#if DEBUG
options.UseReduxDevTools(devToolsOptions =>
{
    devToolsOptions.Name = "Blazor Test";
});
#endif
});


await builder.Build().RunAsync();
