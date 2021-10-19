// See https://aka.ms/new-console-template for more information
using PuppeteerSharp;

Console.WriteLine("Hello, World!");

string outputFile = "./gg.txt";
await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = true
});
var page = await browser.NewPageAsync();
await page.GoToAsync("http://www.google.com");
await page.ScreenshotAsync(outputFile);