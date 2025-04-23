using Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints(typeof(ItemsService.CreateItem).Assembly);
builder.Services.AddEndpoints(typeof(SupplierService.CreateSupplier).Assembly);
builder.Services.AddServices([typeof(ItemsService.CreateItem).Assembly, typeof(SupplierService.CreateSupplier).Assembly]);

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
