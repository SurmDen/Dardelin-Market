using DardelinMarket.Data;
using DardelinMarket.Hubs;
using DardelinMarket.Interfaces;
using DardelinMarket.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using Dadata;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSession();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.IsEssential = true;

    options.Cookie.HttpOnly = true;

    options.LoginPath = "/loginpage";

});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source = dardelinmarket.db");
});

builder.Services.AddCors();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IBasketRepository, BasketRepository>();

builder.Services.AddTransient<IChatRepository, ChatRepository>();

builder.Services.AddSignalR();

var app = builder.Build();

app.UseStatusCodePagesWithRedirects("/mainpage");

app.UseRouting();

app.UseCors(options =>
{
    options.AllowAnyOrigin();

    options.AllowAnyMethod();

    options.AllowAnyHeader();
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {

        try
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = await client.GetAsync("https://api.ipify.org?format=json");

            string data = await httpResponse.Content.ReadAsStringAsync();

            ICustomerRepository repository = context.RequestServices.GetRequiredService<ICustomerRepository>();

            IpModel ipModel = JsonConvert.DeserializeObject<IpModel>(data);

            string city = string.Empty;

            var api = new SuggestClientAsync("675a1fb2f5e78420ff195e5e98d1bbd4c5f2e392");

            var response = await api.Iplocate(ipModel.ip);

            var address = response.location.data;

            city = address.city ?? "underfind";

            Random random = new Random();

            long dick = random.Next(5, 25);

            repository.AddIpDataModel(ipModel.ip, $"{DateTime.Now.ToLongDateString()}   {DateTime.Now.ToLongTimeString()}", city, dick);

        }
        catch (Exception e)
        {
            await Console.Out.WriteLineAsync(e.Message);
        }

    }

    await next.Invoke();
});

app.UseSession();

app.UseStaticFiles();

app.UseDefaultFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapHub<ChatHub>("/chat");

app.Run();
