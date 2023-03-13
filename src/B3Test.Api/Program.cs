using B3Test.Api.Extensions;
using B3Test.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseCors("CorsPolicy");
app.MapControllers();

//Use application monitoring
app.ConfigureApplicationMonitoring(builder.Configuration);

app.SupportLocalizationOptions(builder.Configuration);

app.Run();
