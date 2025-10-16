using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Polideportivo;

public class PadelCourtPageScraper
{
    private readonly string _url = "https://deportes.zizurmayor.es:8443/alqInst.php?alq=1&t=3";
    public async Task<bool> GoToDate(IBrowser browser)
    {
        var page = browser.Contexts[0].Pages.Last();
        await page.GotoAsync(_url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

        DateTime targetDate = DateTime.Now.AddDays(8);
        string targetDay = targetDate.Day.ToString("D2");
        
        await page.ClickAsync("#se4"); //Open calendar
        var calendarTable = await page.WaitForSelectorAsync(".table-condensed") ?? throw new Exception("Calendar table not found.");
        await calendarTable.WaitForSelectorAsync("td");
        
        var targetDayElement = await calendarTable.QuerySelectorAsync($"td:text-is('{targetDay}')") ?? throw new Exception("Target day element not found.");
        await targetDayElement.ClickAsync(); // Click on the target day
        
        var okButton = await page.WaitForSelectorAsync(".applyBtn") ?? throw new Exception("OK button not found.");
        await okButton.ClickAsync();
        await page.ClickAsync("#botonbuscar"); // Load selected date
        
        return true;
    }


}