using Agriculture.Items.Application.Extensions;
using Agriculture.Items.Infrastructure.Extensions;
using Agriculture.Items.Web.Extensions;
using Agriculture.Shared.Web.Extensions;
using Agriculture.Shared.Web.Utilities;

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
