using TF.Repositories.Repositories;
using TF.Services.Services.Auth;

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

builder.Services.AddSingleton<NpgsqlRepository>(_ => new NpgsqlRepository(connectionString));

#endregion

builder.Services.AddScoped<IAuthService, AuthService>();

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