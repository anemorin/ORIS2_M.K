using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core;
using PokemonAPI.Core.Services;
using PokemonAPI.DAL;
using PokemonAPI.DAL.EfCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlPath = string.Format(@"{0}PokemonsAPI.xml", AppDomain.CurrentDomain.BaseDirectory);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration["ConnectionString:DefaultConnection"]));

builder.Services.AddCors(options =>
{
    options
        .AddPolicy(
            "AllowAnyOrigin",
            opt => opt.AllowAnyOrigin());
});
builder.Services.AddCore();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddPostgreSqlCore();

// var dbSeeder = new DbSeeder(new AppDbContext(), new HttpClient());
// dbSeeder.SeedAsync(new CancellationToken());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAnyOrigin");

app.UseAuthorization();
app.MapControllers();

app.Run();