using FinanMEI.DAL;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Injecao de Dependencia
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurar a cultura padrão para pt-BR
var defaultDateCulture = "pt-BR";
var ci = new CultureInfo(defaultDateCulture);
ci.NumberFormat.CurrencySymbol = "R$";
ci.NumberFormat.CurrencyDecimalSeparator = ",";
ci.NumberFormat.CurrencyGroupSeparator = ".";
ci.NumberFormat.NumberDecimalSeparator = ",";
ci.NumberFormat.NumberGroupSeparator = ".";

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo> { ci },
    SupportedUICultures = new List<CultureInfo> { ci }
};

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
