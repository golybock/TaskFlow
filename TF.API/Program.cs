using TF.Auth.AuthManager;
using TF.Repositories.Repositories;
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

#region db

var connectionString = builder.Configuration.GetConnectionString("task_flow");

builder.Services.AddSingleton<NpgsqlRepository>(_ => new NpgsqlRepository(connectionString!));

// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
// builder.Services.AddScoped<ICardRepository, CardRepository>();

#endregion

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthManager, AuthManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();