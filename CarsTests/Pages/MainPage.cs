using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;
using TestFramework.BaseForm;

namespace CarTests.Pages
{
    public class MainPage : BaseForm
    {
        private readonly Button researchButton = new Button(By.XPath("//*[@class='_10R4q']//*[@class='_1U4gk']//*[text()='Research']"), "Research button");

        public MainPage() : base()
        {
            SingleWebDriver.Open(SingleWebDriver.Configuration.GetParameter("SiteName"));
        }
        
        public void ClickResearchButton()
        {
            researchButton.Click();
        }
    }
}
