using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure()
                .AddCore();

builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthorization()
   .UseAuthentication();

app.MapControllers();

app.Run();
