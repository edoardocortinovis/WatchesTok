using Microsoft.EntityFrameworkCore;
using WatchesTok.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configura il DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Orologi.db"));

// Aggiungi i servizi di Razor Pages, Controllers, HttpClient
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        // Configura le opzioni di Razor Pages
        options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddHttpClient();

// Configura CORS per risolvere problemi cross-origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Inizializzazione del database
using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Initialize(dbcontext);
}

// Configurazione del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Abilita CORS
app.UseCors("AllowAll");

app.MapRazorPages();
app.MapControllers();

app.Run();