using System.Reflection;
using BlazorFluxorMediator.Client;
using BlazorMediatRFluxor.Shared.Features.Weather.Store;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Fluxor for WASM execution phase
//builder.Services.AddFluxor(options =>
//{
//    options.ScanAssemblies(
//        typeof(WeatherState).Assembly, // Scan Shared assembly
//        Assembly.GetExecutingAssembly() // Scan Client assembly (for Effects)
//    );
//#if DEBUG
//    options.UseReduxDevTools(devToolsOptions => { devToolsOptions.Name = "Blazor Test";
//    });
//#endif
//});


await builder.Build().RunAsync();
