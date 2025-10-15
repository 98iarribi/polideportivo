using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Playwright;
using Polideportivo;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Polideportivo API is running!");


app.MapPost("/book", async (Polideportivo.LoginRequest request) =>
{
    var browser = await StartBrowserAsync();

    var loginPage = new LoginPage();
    var success = await loginPage.LoginAsync(browser, request.Username, request.Password);

    // Go to booking page and try to book

    await browser.CloseAsync();

    return success ? Results.Ok("Login successful") : Results.BadRequest("Login failed");
});



static async Task<IBrowser> StartBrowserAsync()
{
    var playwright = await Playwright.CreateAsync();
    var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = false // set true if you don’t want the browser UI
    });

    return browser;
}

app.Run();
