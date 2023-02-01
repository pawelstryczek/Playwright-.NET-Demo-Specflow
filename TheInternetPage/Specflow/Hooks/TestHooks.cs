using BoDi;
using Microsoft.Playwright;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;
using TheInternetPage.PageObject;

namespace TheInternetPage.Specflow.Hooks
{
    [Binding]
    public class TestHooks
    {
        public IPage Page { get; private set; } = null!;

        public IBrowser Browser { get; private set; } = null!;

        internal TheInternet? TheInternet;

        [BeforeScenario]
        public async Task BeforeScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright
                .Chromium
                .LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
            Page = await Browser.NewPageAsync();
            TheInternet = TheInternet.Initialize(Page);
            container.RegisterInstanceAs(Page);
            container.RegisterInstanceAs(TheInternet);
        }

        [AfterScenario]
        public async void AfterScenario(IObjectContainer container)
        {
            await Browser.CloseAsync();
        }
    }
}
