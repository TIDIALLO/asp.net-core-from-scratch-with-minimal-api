using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GestionBibliotheque.Frontend;
using GestionBibliotheque.Frontend.Services;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Configurer HttpClient pour interagir avec l'API backend
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5062/") });
builder.Services.AddScoped<BookService>();
// Ajoutez cette ligne pour MudBlazor
builder.Services.AddMudServices();
await builder.Build().RunAsync();
