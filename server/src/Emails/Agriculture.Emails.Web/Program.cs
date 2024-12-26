using Agriculture.Emails.Application.Extensions;
using Agriculture.Emails.Infrastructure.Extensions;
using Agriculture.Emails.Web.Extensions;
using Agriculture.Shared.Web.Extensions;
using Agriculture.Shared.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

builder.Host.AddSerilog();

var app = builder.Build();

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