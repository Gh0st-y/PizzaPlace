using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PizzaPlace.Client.Scripts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AppStateService>();

await builder.Build().RunAsync();
