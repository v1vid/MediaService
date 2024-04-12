#pragma warning disable CA1506

using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sample.Application.Sample.Application.Extensions;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Contexts;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Extensions;
using Sample.Presentation.Sample.Presentation.Http.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddDbContext<ApplicationDbContext>(x =>
    x.UseNpgsql("Host=localhost;Database=cms;Username=postgres;Password=1472"));
builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence();
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();



builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();

WebApplication  app = builder.Build();


app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();


app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();