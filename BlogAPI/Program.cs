using BlogAPI.BusinessLogic;
using BlogAPI.BusinessLogic.Posts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BlogDataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("BlogDatabase")).EnableSensitiveDataLogging());
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
