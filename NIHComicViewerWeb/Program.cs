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

// Use request-scoped DbContext so repositories and UnitOfWork can accept NihcomicContext via ctor.
builder.Services.AddDbContext<NihcomicContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
    }

    var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString)
    {
        MaxPoolSize = 100,
        MinPoolSize = 1,
        ConnectionIdleLifetime = 300,
        ConnectionPruningInterval = 10,
        Timeout = 30,
        CommandTimeout = 30
    };

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

// Repositories — scoped so they share the same request DbContext instance.
builder.Services.AddScoped<IComicRepository, ComicRepository>();
builder.Services.AddScoped<IComicPageRepository, ComicPageRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Unit of Work — single, correct scoped registration.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Application service registrations
builder.Services.AddScoped<IComicAppService, ComicAppService>();
builder.Services.AddScoped<IComicPageAppService, ComicPageAppService>();
builder.Services.AddScoped<ITagAppService, TagAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

// HTTP clients
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
