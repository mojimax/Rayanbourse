using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connString = builder.Configuration.GetConnectionString("RayanboursConnection");
builder.Services.AddDbContext<RayanbourseDbContext>(item => item.UseSqlServer(connString));
builder.Services.AddDbContext<RayanbourseDbContext>();
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<RayanbourseDbContext>().AddDefaultTokenProviders();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RayanbourseDbContext>();
        var exsistDatabase = ((RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>()).Exists();
        if (!exsistDatabase)
        {
            await context.Database.EnsureCreatedAsync();
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        throw;
    }

}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
