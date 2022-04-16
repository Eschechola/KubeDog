using KubeDog.Services;
using KubeDog.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IApiService, ApiService>()
    .AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
