using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

//builder.Services.AddControllers();
//builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();


//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");

//app.Map("/error", (HttpContext httpContext) =>
//{
//    var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//    return Results.Problem(title: exception?.Message);
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

