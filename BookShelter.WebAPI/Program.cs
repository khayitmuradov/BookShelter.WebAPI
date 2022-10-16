#region Services
using BookShelter.WebAPI.Commons.Configurations;
using BookShelter.WebAPI.DbContexts;
using BookShelter.WebAPI.Interfaces.Managers;
using BookShelter.WebAPI.Interfaces.Repositories;
using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.Repositories;
using BookShelter.WebAPI.Security;
using BookShelter.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureSwaggerAuthorize();
#endregion

#region Database
var connectionString = builder.Configuration.GetConnectionString("BookShelterProductionDb");
builder.Services.AddDbContext<ApplicationDbContext>(dbOptions =>
{
    dbOptions.UseNpgsql(connectionString);
    dbOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
#endregion

#region RepositoryRelations
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
#endregion

#region ServiceRelations
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
#endregion

#region Middlewares
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion
