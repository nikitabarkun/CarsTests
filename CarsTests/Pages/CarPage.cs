using OpenQA.Selenium;
using TestFramework.BaseForm;
using TestFramework.Elements;

namespace CarTests.Pages
{
    public class CarPage : BaseForm
    {
        private readonly Button researchButton = new Button(By.XPath("(//header//*[contains(text(), 'Research')])[2]"), "Research button");
        private readonly Button compareTrimsButton = new Button(By.XPath("//*[@id='mmy-specs']//*[@data-linkname='trim-compare']"), "Compare trims");

        public CarPage() : base()
        {

        }

        public void ClickResearchButton()
        {
            researchButton.Click();
        }

        public void ClickCompareTrimsButton()
        {
            compareTrimsButton.Click();
        }

        public bool IsCompareTrimsButtonPresent()
        {
            return compareTrimsButton.IsPresent();
        }
    }
}
