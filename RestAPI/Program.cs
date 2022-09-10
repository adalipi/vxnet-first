using NLog.Web;
using System.Text.Json.Serialization;
using vxnet.RestAPI;
using vxnet.RestAPI.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.RegisterDependecies(builder.Configuration);

builder.Host.UseNLog();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
