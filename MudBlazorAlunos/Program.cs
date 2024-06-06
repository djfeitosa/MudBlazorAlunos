using MudBlazorAlunos.Components;
using MudBlazor.Services;
using MudBlazorAlunos.Context;
using Microsoft.EntityFrameworkCore;
using MudBlazorAlunos.Service;
using MudBlazorAlunos.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddScoped<IAlunoService, AlunoService>();

var conDb = builder.Configuration.GetConnectionString("ConSqlDesMac");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(conDb);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
