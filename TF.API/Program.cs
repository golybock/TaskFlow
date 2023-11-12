using TF.Auth;
using TF.Auth.AuthManager;
using TF.Auth.CacheService;
using TF.Auth.Options;
using TF.Auth.Tokens;
using TF.Repositories.Repositories;
using TF.Repositories.Repositories.Card;
using TF.Repositories.Repositories.Users;
using TF.Repositories.Repositories.Workspace;
using TF.Services.Services.Auth;
using TF.Services.Services.Card;
using TF.Services.Services.Users;
using TF.Services.Services.Workspace;

var builder = WebApplication.CreateBuilder(args);

// todo refactor

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

RefreshCookieOptions GetOptions(IConfiguration configuration)
{
    return new RefreshCookieOptions()
    {
        Secret = configuration["RefreshCookieOptions:Secret"],
        TokenLifeTimeTicks = int.Parse(configuration["RefreshCookieOptions:TokenValidityInMinutes"]!),
        RefreshTokenLifeTimeTicks = Int32.Parse(configuration["RefreshCookieOptions:RefreshTokenValidityInDays"]!),
        ValidIssuer = configuration["RefreshCookieOptions:ValidIssuer"],
        ValidAudience = configuration["RefreshCookieOptions:ValidAudience"],
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true
    };
}

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "127.0.0.1:6379";
    options.InstanceName = "notes:";
});

builder.Services.AddAuthentication(RefreshCookieDefaults.AuthenticationScheme)
    .AddRefreshCookie(
        RefreshCookieDefaults.AuthenticationScheme,
        RefreshCookieDefaults.AuthenticationScheme,
        _ => GetOptions(builder.Configuration));

// auth options
builder.Services.AddSingleton<IRefreshCookieOptions>(_ => GetOptions(builder.Configuration));
builder.Services.AddSingleton<RefreshCookieOptions>(_ => GetOptions(builder.Configuration));
#region db

var connectionString = builder.Configuration.GetConnectionString("task_flow");

builder.Services.AddSingleton<NpgsqlRepository>(_ => new NpgsqlRepository(connectionString!));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();

#endregion

// auth
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ITokenCacheService, TokenCacheService>();
builder.Services.AddScoped<ITokenManager, TokenManager>();

// services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();