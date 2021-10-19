using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NotesBin.App;
using NotesBin.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ConfigManager>();
builder.Services.AddScoped<ICryptoProvider, JsCryptoProvider>();
builder.Services.AddScoped<IFileSystemProvider, IndexedDbFileSystemProvider>();
builder.Services.AddScoped<NotesManagerSetupProvider>();
builder.Services.AddScoped<FileUtilities>();

await builder.Build().RunAsync();
