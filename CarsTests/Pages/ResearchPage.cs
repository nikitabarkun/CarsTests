using OpenQA.Selenium;
using CarTests.HelpClasses;
using System;
using TestFramework.BaseForm;
using TestFramework.Elements;

namespace CarTests.Pages
{
    public class ResearchPage : BaseForm
    {
        private readonly Select makeSelect = new Select(By.XPath("//select[@name='makeId']"), "Make select");
        private readonly Select modelSelect = new Select(By.XPath("//select[@name='modelId']"), "Model select");
        private readonly Select yearSelect = new Select(By.XPath("//select[@name='year']"), "Year select");
        private readonly Button searchButton = new Button(By.XPath("//form[@class='_24sct']//*[@type='submit']"), "Search button");
        private readonly Button compareButton = new Button(By.XPath("//*[@class='m6uQf']//*[@data-linkname='compare-cars']"), "Side-by-side compare button");

        public ResearchPage() : base()
        {

        }

        public Car SelectRandomCar()
        {
            Random rand = new Random();

            makeSelect.SelectByIndex(rand.Next(1, makeSelect.GetSize()));
            modelSelect.SelectByIndex(rand.Next(1, modelSelect.GetSize()));
            yearSelect.SelectByIndex(rand.Next(1, yearSelect.GetSize()));

            return new Car(makeSelect.GetText(), modelSelect.GetText(), yearSelect.GetText(), null, null);
        }

        public string GetCarMake()
        {
            return makeSelect.GetText();
        }

        public string GetCarModel()
        {
            return modelSelect.GetText();
        }

        public string GetCarYear()
        {
            return yearSelect.GetText();
        }

        public void ClickSearchButton()
        {
            searchButton.Click();
        }

        public void ClickCompareButton()
        {
            compareButton.Click();
        }
    }
}
