using Microsoft.EntityFrameworkCore;
using NIHComicViewer.Application.Services;
using NIHComicViewer.Application.Services.Interfaces;
using NIHComicViewer.Infrastructure.Entities;
using NIHComicViewer.Infrastructure.Repositories;
using NIHComicViewer.Infrastructure.Repositories.Interface;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContextFactory<NihcomicContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
    connectionStringBuilder.MaxPoolSize = 100;
    connectionStringBuilder.MinPoolSize = 1;   // Minimum number of connections to keep in the pool
    connectionStringBuilder.ConnectionIdleLifetime = 300; // How long a connection can be idle before being removed (in seconds)
    connectionStringBuilder.ConnectionPruningInterval = 10; // How often to check for idle connections (in seconds)
    connectionStringBuilder.Timeout = 30; // Connection timeout in seconds
    connectionStringBuilder.CommandTimeout = 30; // Command timeout in seconds

    options.UseNpgsql(connectionStringBuilder.ToString(),
        x =>
        {
            x.MinBatchSize(1);
            x.MaxBatchSize(100);
            x.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorCodesToAdd: null);
        });
});

builder.Services.AddScoped<IComicRepository, ComicRepository>();
builder.Services.AddScoped<IComicPageRepository, ComicPageRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Unit of Work and Repository registrations
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork>(unitOfWork =>
    new UnitOfWork(
        unitOfWork.GetRequiredService<NihcomicContext>(),
        unitOfWork.GetRequiredService<IComicRepository>(),
        unitOfWork.GetRequiredService<IComicPageRepository>(),
        unitOfWork.GetRequiredService<ITagRepository>(),
        unitOfWork.GetRequiredService<IUserRepository>()
    )
);

// Application service registrations
builder.Services.AddScoped<IComicAppService, ComicAppService>();
builder.Services.AddScoped<IComicPageAppService, ComicPageAppService>();
builder.Services.AddScoped<ITagAppService, TagAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddHttpClient();


var app = builder.Build();

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
