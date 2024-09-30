using ProductosWEB.Services;
using proyectoWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<HttpClient>(o =>
new HttpClient { BaseAddress = new Uri("https://localhost:7283/") });

builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<CompraService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ArticuloService>();
builder.Services.AddScoped<UsuarioRolService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<ImagenArticuloService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
