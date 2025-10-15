using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Polideportivo;

public class LoginPage
{
    // URL for the login page
    private readonly string _url = "https://deportes.zizurmayor.es:8443/zonaabo.php";

    // Credentials (ideally these should come from config, not hardcoded)
    public async Task<bool> LoginAsync(IBrowser browser, string username, string password)
    {
        // Create a new tab (page)
        var page = await browser.NewPageAsync();

        // Navigate to login page
        await page.GotoAsync(_url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

        // Fill login form
        await page.FillAsync("#usuario", username);
        await page.FillAsync("#password", password);

        // Click the login button (id="validar" on the site)
        await page.ClickAsync("#validar");

        // Wait until we know login succeeded.
        try
        {
            // Wait for either a redirect or a known element on the next page
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


