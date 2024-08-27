using BlazorCine;
using BlazorCine.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Components.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Declarar Servicios 
builder.Services.AddScoped<IHorario, HorarioService>();
builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<ToastService>();



//comunicacion con la APPI
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7118") });

await builder.Build().RunAsync();
