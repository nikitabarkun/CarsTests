using OpenQA.Selenium;

namespace TestFramework.BaseForm
{
    public abstract class BaseForm
    {
        protected IWebDriver driver;

        public BaseForm()
        {
            this.driver = SingleWebDriver.GetInstance();
        }
    }
}
