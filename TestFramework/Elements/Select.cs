using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Elements
{
    public class Select : BaseElement
    {
        private SelectElement elements;

        public Select(By locator, string name) : base(locator, name)
        {
            elements = new SelectElement(SingleWebDriver.GetInstance().FindElement(locator));
        }

        public void SelectByIndex(int index)
        {
            elements.SelectByIndex(index);

            Logger.GetInstance().LogLine($"Selected element {index} in {Name}.");
        }

        public void SelectByText(string text)
        {
            elements.SelectByText(text);

            Logger.GetInstance().LogLine($"Selected element '{text}' in {Name}.");
        }

        public int GetSize()
        {
            Logger.GetInstance().LogLine($"Getting size of {Name}.");
            return elements.Options.Count;
        }

        public string GetText()
        {
            Logger.GetInstance().LogLine($"Getting text of {Name}.");
            return elements.SelectedOption.Text;
        }
    }
}
