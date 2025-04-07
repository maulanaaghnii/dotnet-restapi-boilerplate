using Microsoft.EntityFrameworkCore;
using UserProfileApi.Data;
using UserProfileApi.Repositories;
using UserProfileApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Get database provider from config
var provider = builder.Configuration["DatabaseProvider"] ?? 
    throw new Exception("Database provider not found in configuration");
string connectionString;

if (provider == "MySQL")
{
    connectionString = builder.Configuration.GetConnectionString("MySQL") ?? 
        throw new Exception("MySQL connection string not found in configuration");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}
else if (provider == "PostgreSQL")
{
    connectionString = builder.Configuration.GetConnectionString("PostgreSQL") ?? 
        throw new Exception("PostgreSQL connection string not found in configuration");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseNpgsql(connectionString));
}
else
{
    throw new Exception("Invalid or missing database provider configuration.");
}

// Dependency Injection & App Setup
builder.Services.AddScoped<IUserProfileRepository, UserProfileEfRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostEfRepository>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
