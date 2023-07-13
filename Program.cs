using GCGov.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Carregar a configuração do arquivo appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configurar a string de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adicionar o DbContext usando a string de conexão
builder.Services.AddDbContext<GCGovContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Adicionar os serviãos ao contãiner
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline de requisiãão HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
