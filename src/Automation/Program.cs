using Microsoft.Extensions.Configuration;
using PuppeteerSharp;


var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);
var config = builder.Build();

var email = config["login:Email"];
var password = config["login:Password"];
var signInUrl = config["login:url"];
var stockUrl = config["stock:url"];

await new BrowserFetcher(Product.Chrome).DownloadAsync();

var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Product = Product.Chrome,
    Headless = false
});

// Setup 
var page = await browser.NewPageAsync();
await page.SetViewportAsync(new ViewPortOptions() { Width = 1920, Height = 1080 });

// Navigate to sign in page
await page.GoToAsync(signInUrl);

// Wait for the selector to appear
await page.WaitForSelectorAsync(StockOptionsSelector.InputFormSelector);
await page.FocusAsync(StockOptionsSelector.InputFormSelector);

// Enter the credentials
await page.Keyboard.TypeAsync(email);
await page.Keyboard.PressAsync(StockOptionsSelector.EscapeKey);
await page.Keyboard.PressAsync(StockOptionsSelector.TabKey);
await page.Keyboard.TypeAsync(password);


// Login
await page.ClickAsync(StockOptionsSelector.SubmitForm);
await page.WaitForNavigationAsync();

// Go to Stock Page
await page.GoToAsync(page.Url + stockUrl);

// Open export window
await page.WaitForSelectorAsync(StockOptionsSelector.OpenExportButton);
await page.ClickAsync(StockOptionsSelector.OpenExportButton);

// Click download
await page.WaitForSelectorAsync(StockOptionsSelector.DownloadButton);
await page.ClickAsync(StockOptionsSelector.DownloadButton);
//Thread.Sleep(10000); // Chill for the download 

await page.CloseAsync();

