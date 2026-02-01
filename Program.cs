using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MaximHilaryC;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
using var response = await http.GetAsync("appsettings.json");
if (response.IsSuccessStatusCode)
{
    using var stream = await response.Content.ReadAsStreamAsync();
    builder.Configuration.AddJsonStream(stream);
}

await builder.Build().RunAsync();
