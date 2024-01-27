using Microsoft.EntityFrameworkCore;
using Talabat.BLL;
using Talabat.BLL.Helper.Mapper;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Dependancy Injection of DbContext .
builder.Services.AddDbContext<StoreContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("StoreConn")));

// Dependancy Of Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository<>));

// Dependency of IMapper 
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();
// Handle Error Execution In Case of Not Found Api
  app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
