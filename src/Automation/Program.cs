// See https://aka.ms/new-console-template for more information
using PuppeteerSharp;

Console.WriteLine("Hello, World!");

string outputFile = @"C:\Users\alexi\OneDrive\Desktop\gg.jpg";
await new BrowserFetcher(Product.Chrome).DownloadAsync();

var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Product = Product.Chrome,
    Headless = false
});

var page = await browser.NewPageAsync();
await page.SetViewportAsync(new ViewPortOptions() { Width = 1920, Height = 1080 });
await page.GoToAsync("https://app.tcgpowertools.com/signin");
// Wait for the selector to appear
await page.WaitForSelectorAsync(".o--FormGroup--formGroup input");
await page.FocusAsync(".o--FormGroup--formGroup input");
await page.Keyboard.TypeAsync("");
await page.Keyboard.PressAsync("Escape");
await page.Keyboard.PressAsync("Tab");
await page.Keyboard.TypeAsync("");



await page.ClickAsync(".o--Button--children");
await page.WaitForNavigationAsync();

await page.ScreenshotAsync(outputFile);
await page.CloseAsync();