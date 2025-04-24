using Extensions;
using MessageBroker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsFrom([typeof(ItemsService.CreateItem).Assembly, typeof(SupplierService.CreateSupplier).Assembly]);
builder.Services.AddServicesFrom([typeof(ItemsService.CreateItem).Assembly, typeof(SupplierService.CreateSupplier).Assembly]);
builder.Services.AddMessageBroker(builder.Configuration);

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
