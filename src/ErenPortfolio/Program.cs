using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ErenPortfolio;
using ErenPortfolio.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new GitHubCommitService(sp.GetRequiredService<HttpClient>(), request =>
{
    // Fetch options avoid the browser cache without adding a CORS-unsupported Cache-Control header.
    request.SetBrowserRequestCache(BrowserRequestCache.NoStore);
    request.SetBrowserRequestCredentials(BrowserRequestCredentials.Omit);
}));

await builder.Build().RunAsync();
