using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Polideportivo;

public class LoginPage
{
    private readonly string _url = "https://deportes.zizurmayor.es:8443/zonaabo.php";

    public async Task<bool> LoginAsync(IBrowser browser, string username, string password)
    {
        var page = await browser.NewPageAsync();
        await page.GotoAsync(_url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

        await page.FillAsync("#usuario", username);
        await page.FillAsync("#password", password);
        await page.ClickAsync("#validar");

        // Wait until  succeeded.
        try
        {
            // Wait for either a redirect
            await page.WaitForURLAsync("**/index.php", new PageWaitForURLOptions { Timeout = 5000 });
            Console.WriteLine("✅ Login successful.");
            return true;
        }
        catch (TimeoutException)
        {
            Console.WriteLine("❌ Login may have failed — timeout waiting for redirect.");
            return false;
        }
    }
}


public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}


