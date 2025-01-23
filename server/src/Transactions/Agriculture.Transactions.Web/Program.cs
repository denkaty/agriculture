using Agriculture.Shared.Web.Extensions;
using Agriculture.Shared.Web.Utilities;
using Agriculture.Transactions.Application.Extensions;
using Agriculture.Transactions.Infrastructure.Extensions;
using Agriculture.Transactions.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

builder.Host.AddSerilog();

var app = builder.Build();

await app.SetupDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDevelopment();
}

app.UseCors(AppPolicies.CorsPolicy);

app.UseRateLimiter();

app.UseCustomMiddlewares();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

