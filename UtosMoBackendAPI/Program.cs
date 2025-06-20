using UtosMoBackendAPI.Extensions.ContextExtensions;
using UtosMoBackendAPI.Extensions.ServiceExtensions;
using UtosMoBackendAPI.RepositoryManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterUserDbContext(builder.Configuration.GetConnectionString("UtosMoUserDb")!);
builder.Services.RegisterReviewDbContext(builder.Configuration.GetConnectionString("UtosMoReviewDb")!);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.RegisterUserServices();
builder.Services.RegisterReviewService();

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
