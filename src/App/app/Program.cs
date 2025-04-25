using System.Reflection;
using Extensions;
using MessageBroker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Assembly[] moduleAssemblies =
[
    typeof(ItemsService.EntryPoint).Assembly,
    typeof(SupplierService.EntryPoint).Assembly,
    typeof(ProductService.EntryPoint).Assembly
];
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsFrom(moduleAssemblies);
builder.Services.AddServicesFrom(moduleAssemblies);
builder.Services.AddMessageBroker(builder.Configuration, moduleAssemblies);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();
