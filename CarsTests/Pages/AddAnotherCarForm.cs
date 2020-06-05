using OpenQA.Selenium;
using TestFramework.BaseForm;
using TestFramework.Elements;

namespace CarTests.Pages
{
    public class AddAnotherCarForm : BaseForm
    {
        private readonly Select makeSelect = new Select(By.XPath("//select[@id='make-dropdown']"), "Make select");
        private readonly Select modelSelect = new Select(By.XPath("//select[@id='model-dropdown']"), "Model select");
        private readonly Select yearSelect = new Select(By.XPath("//select[@id='year-dropdown']"), "Year select");
        private readonly Button doneButton = new Button(By.XPath("//button[@class='modal-button']"), "Done");

        public AddAnotherCarForm() : base()
        {

        }

        public void SelectMakeByText(string text)
        {
            makeSelect.SelectByText(text);
        }

        public void SelectModelByText(string text)
        {
            modelSelect.SelectByText(text);
        }

        public void SelectYearByText(string text)
        {
            yearSelect.SelectByText(text);
        }

        public void ClickDoneButton()
        {
            doneButton.Click();
        }
    }
}
