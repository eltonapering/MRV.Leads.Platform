using MediatR;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Application.CQRS.Queries.Handlers;
using MRV.Leads.Platform.Application.Bootstrap;
using MRV.Leads.Platform.Domain.Interfaces;
using MRV.Leads.Platform.Infrastructure;
using MRV.Leads.Platform.Infrastructure.Repositories;
using MRV.Leads.Platform.Infrastructure.UoW;
using MRV.Leads.Platform.Application.Events.Publishers;
using RabbitMQ.Client;
using MRV.Leads.Platform.Infrastructure.EventStore;
using MRV.Leads.Platform.Infrastructure.Settings;
using MRV.Leads.Platform.Application.Services;
using MRV.Leads.Platform.Application.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.MongoDbConnection

builder.Services.AddControllers();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure MongoDB
var mongoSettings = builder.Configuration.GetSection("MongoDbConnection").Get<MongoDbSettings>();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbConnection"));

builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoSettings.ConnectionString));

builder.Services.AddScoped<IMongoDatabase>(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(mongoSettings.DatabaseName));

builder.Services.AddScoped<IEventStore>(sp =>
    new MongoDbEventStore(
        sp.GetRequiredService<IMongoDatabase>(),
        mongoSettings.CollectionName
    ));

// Register the generic repository and UnitOfWork
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Event Sourcing
builder.Services.AddScoped<IEventStoreRepository, EventStoreRepository>();
builder.Services.AddScoped<IEventSourcingService, EventSourcingService>();
builder.Services.AddScoped(typeof(IEventSourcingHandler<>), typeof(EventSourcingHandler<>));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MRV LEADS API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";    
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    
    c.IncludeXmlComments(xmlPath);
});

//Cors Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Register MediatR services
builder.Services.AddMediatR(typeof(GetIntentByIdQueryHandler).Assembly);

//Initialize queue
var rabbitMqInitializer = new RabbitMqInitializer("localhost", "intent.accepted.queue");
rabbitMqInitializer.Initialize();

builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    return new ConnectionFactory() { HostName = "localhost" };
});

builder.Services.AddScoped<IntentAcceptedPublisher>(sp =>
{
    var connectionFactory = sp.GetRequiredService<IConnectionFactory>();
    var connection = connectionFactory.CreateConnection();
    var channel = connection.CreateModel();
    
    return new IntentAcceptedPublisher(channel, () =>
    {
        channel.Dispose();
        connection.Dispose();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
