using proyectoGymBlazor.Components;
using Microsoft.EntityFrameworkCore;
using proyectoGym;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Controllers;




var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de base de datos
builder.Services.AddDbContext<GimnasioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GimnasioDB")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ClaseService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<MembresiaService>();
builder.Services.AddScoped<ProgresoUsuarioService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<UsuarioService>();



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
