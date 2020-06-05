using OpenQA.Selenium;
using TestFramework.BaseForm;
using TestFramework.Elements;

namespace CarTests.Pages
{
    public class TrimsPage : BaseForm
    {
        private readonly Button homeButton = new Button(By.XPath("//img[@class='global-nav__logo']"), "Home button");
        private readonly Label baseEngineLabel = new Label(By.XPath("//*[@id='trim-table']//*[@class='cell cell-bg grow-2']"), "Base engine label");
        private readonly Label baseTransmissonLabel = new Label(By.XPath("//*[@id='trim-table']//*[@class='cell grow-2']"), "Base transmission label");

        //TODO: заставить селектор работать
        //private const string carParameterSelectorPattern = "//*[@class='trim-details']//*[contains(@class, 'cell')][count((//*[@id='labels-row'])[1]//*[contains(text(), 'PARAM')]/preceding-sibling::div)+1]";
        //private readonly Label baseEngineLabel = new Label(By.XPath(getCarParameterSelector("Engine")), "Base engine label");
        //private readonly Label baseTransLabel = new Label(By.XPath(getCarParameterSelector("Trans")), "Base trans label");

        public TrimsPage() : base()
        {

        }

        public string GetCarEngine()
        {
            return baseEngineLabel.GetAttribute("innerText");
        }

        public string GetCarTransmission()
        {
            return baseTransmissonLabel.GetAttribute("innerText");
        }

        public void ClickHomeButton()
        {
            homeButton.Click();
        }

        //TODO: ввести после селектора
        //private static string getCarParameterSelector(string param)
        //{
        //    Console.WriteLine(carParameterSelectorPattern.Replace("PARAM", param));
        //    return carParameterSelectorPattern.Replace("PARAM", param);
        //}
    }
}
