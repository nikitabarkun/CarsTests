using OpenQA.Selenium;
using TestFramework.Elements;
using TestFramework.BaseForm;
using CarTests.HelpClasses;
using System;

namespace CarTests.Pages
{
    public class ComparePage : BaseForm
    {
        public string FirstCarEngine => firstCarEngine.GetAttribute("innerText");
        public string SecondCarEngine => secondCarEngine.GetAttribute("innerText");
        public string FirstCarTrans => firstCarTrans.GetAttribute("innerText");
        public string SecondCarTrans => secondCarTrans.GetAttribute("innerText");

        private AddAnotherCarForm addAnotherCarForm;
        private readonly Select makeSelect = new Select(By.XPath("//select[@id='make-dropdown']"), "Make select");
        private readonly Select modelSelect = new Select(By.XPath("//select[@id='model-dropdown']"), "Model select");
        private readonly Select yearSelect = new Select(By.XPath("//select[@id='year-dropdown']"), "Year select");
        private readonly Button startComparingButton = new Button(By.XPath("//button[@class='done-button']"), "Start comparing");
        private readonly Button addAnotherCarButton = new Button(By.XPath("//div[@id='icon-div']"), "Add another car button");

        private readonly Label firstCarEngine = new Label(By.XPath(getCarParameterSelector("Engine", 0)), "First car engine");
        private readonly Label secondCarEngine = new Label(By.XPath(getCarParameterSelector("Engine", 1)), "Second car engine");
        private readonly Label firstCarTrans = new Label(By.XPath(getCarParameterSelector("Transmission", 0)), "First car transmission");
        private readonly Label secondCarTrans = new Label(By.XPath(getCarParameterSelector("Transmission", 1)), "Second car transmission");

        private const string carParametersSelectorPattern = "//*[@header='TYPE']//*[@compare-item='itemINDEX']";

        public ComparePage() : base()
        {

        }

        public void AddAnotherCar(Car car)
        {
            addAnotherCarButton.Click();

            addAnotherCarForm = new AddAnotherCarForm();

            addAnotherCarForm.SelectMakeByText(car.Make);
            addAnotherCarForm.SelectModelByText(car.Model);
            addAnotherCarForm.SelectYearByText(car.Year);

            addAnotherCarForm.ClickDoneButton();
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

        public void ClickStartComparingButton()
        {
            startComparingButton.Click();
        }

        private static string getCarParameterSelector(string type, int index)
        {
            return carParametersSelectorPattern.Replace("TYPE", type).Replace("INDEX", Convert.ToString(index));
        }
    }
}
