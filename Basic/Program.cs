var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddAuthentication("CookieAuth").AddCookie("CookieAuth",x => {

    x.Cookie.Name = "MyCookie";
    x.LoginPath = "/Login"; 

});

var app = builder.Build();

app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
