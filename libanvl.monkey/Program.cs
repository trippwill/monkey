using libanvl.monkey;
using libanvl.monkey.theme.futureimperfect;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using site.demo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.AddThemedSiteBuilder(new FutureImperfectSiteBuilder());

#if DEBUG
Console.WriteLine(builder.Configuration.GetDebugView());
#endif

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddGitHubApiClient();
builder.Services.AddRenderedMarkdownServices();
builder.Services.AddHttpClient("libanvl.github.io", client => client.BaseAddress = new Uri("https://raw.githubusercontent.com/libanvl/libanvl.github.io/main/"));

await builder.Build().RunAsync();
