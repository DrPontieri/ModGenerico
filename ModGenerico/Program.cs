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
builder.Services.AddScoped<ILogradouroAbstractRepository, LogradouroAbstractRepository>();
builder.Services.AddScoped<IPaymentDetailAbstractRepository, PaymentDetailAbstractRepository>();
//builder.Services.AddScoped<IDadosPessoaisAbstractRepository, DadosPessoaisAbstractRepository>();
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
                    policy.WithOrigins("http://localhost:4200")
                          //.WithMethods("GET", "POST", "PUT", "DELETE")
                          .AllowAnyMethod()
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
