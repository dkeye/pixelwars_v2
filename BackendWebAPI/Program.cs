using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Prometheus;

// условная бд с пользователями
var people = new List<Person>
{
    new Person("tom", "tom")
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PixelWarsDatabaseSettings>(builder.Configuration.GetSection("PixelWarsDatabase"));
builder.Services.AddSingleton<PixelWarsService>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
// аутентификация с помощью куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    // получаем из формы UserName и пароль
    var form = context.Request.Form;
    // если UserName и/или пароль не установлены, посылаем статусный код ошибки 400
    if (!form.ContainsKey("userName") || !form.ContainsKey("password"))
        return Results.BadRequest("userName и/или пароль не установлены");

    string userName = form["userName"];
    string password = form["password"];

    // находим пользователя 
    Person? person = people.FirstOrDefault(p => p.UserName == userName && p.Password == password);
    // если пользователь не найден, отправляем статусный код 401
    if (person is null) return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.UserName) };
    // создаем объект ClaimsIdentity
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    // установка аутентификационных куки
    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    return Results.Redirect(returnUrl?? "/");
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMetricServer();
app.UseHttpMetrics();
app.MapControllers();

app.Run();

