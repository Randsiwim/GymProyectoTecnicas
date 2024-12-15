using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using proyectoGymBlazor.Data;
using proyectoGymBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de base de datos
builder.Services.AddDbContext<GimnasioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GimnasioDB")));

// Registrar los servicios
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ClaseService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<MembresiaService>();
builder.Services.AddScoped<ProgresoUsuarioService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<UsuarioService>();

// Agregar servicios de Blazor Server
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configurar el middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub(); // Para Blazor Server
app.MapFallbackToPage("/_Host"); // Ruta predeterminada para Razor Pages

app.Run();
