using IdentityProject.Data;
using IdentityProject.Models;
using IdentityProject.Services;
using IdentityProject.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var stringDeConexao = builder.Configuration.GetConnectionString("ConexaoUsuario");
builder.Services.AddDbContext<UsuarioDbContext>(opts => 
{
    opts.UseMySql(stringDeConexao,
                 ServerVersion.AutoDetect(stringDeConexao));
});

builder.Services
    .AddIdentity<UsuarioModel, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthorization(opcoes => 
{
    opcoes.AddPolicy("IdadeMinima", policy =>
    {
        policy.AddRequirements(new IdadeMinima(18));
    });
});

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
