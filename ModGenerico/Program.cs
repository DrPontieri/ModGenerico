using Data.Context;
using Data.Repositories.Abstractions;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using core.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IPessoaAbstractRepository, PessoaAbstractRepository>();
builder.Services.AddScoped<IDadosPessoaisAbstractRepository, DadosPessoaisAbstractRepository>();
//builder.Services.AddScoped<ICarroRepository, CarroRepository>();

//builder.Services.AddScoped<IUnitOfWork,  UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    //c.IgnoreObsoleteActions();
    //c.IgnoreObsoleteProperties();
    //c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecrutadoresWeb", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins("https://localhost:7086", "https://cloudy-crescent-73244.postman.co/workspace/ApiDaniel~535487cf-111b-40e3-91bb-354c57a6b43e/request/create?requestId=2c486436-7484-4694-972e-5acae47e366b")
                          .WithMethods("GET", "POST", "PUT", "DELETE")
                          .AllowAnyHeader();
                            
                });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecrutadoresWeb v1"));
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
