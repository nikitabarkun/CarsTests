using NUnit.Framework;
using TestFramework;
using CarTests.Pages;
using CarTests.HelpClasses;
using OpenQA.Selenium;

namespace CarTests
{
    [TestFixture]
    class CarsComparisonTests : CarsBaseTest
    { 
        [Test]
        public void CarModelComparison()
        {
            Logger.GetInstance().LogLine("STEP 1: Opening main page.");
            MainPage mainPage = new MainPage();

            Car car1 = SelectCarTrim(mainPage);
            Logger.GetInstance().LogLine("STEP 7: Repeating steps 2-5 for the second car.");
            Car car2 = SelectCarTrim(mainPage);

            Logger.GetInstance().LogLine("STEP 8: Selecting 'research'.");
            mainPage.ClickResearchButton();

            ResearchPage researchPage = new ResearchPage();
            Logger.GetInstance().LogLine("STEP 9: Clicking 'Side-by-side comparisons'.");
            researchPage.ClickCompareButton();

            ComparePage comparePage = new ComparePage();
            Logger.GetInstance().LogLine("STEP 10: Adding first car data.");
            comparePage.SelectMakeByText(car1.Make);
            comparePage.SelectModelByText(car1.Model);
            comparePage.SelectYearByText(car1.Year);
            comparePage.ClickStartComparingButton();

            Logger.GetInstance().LogLine("STEP 11: Adding second car data.");
            comparePage.AddAnotherCar(car2);

            Logger.GetInstance().LogLine("STEP 12: Comparing first and second cars engine and transmisson data with the saved values.");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(comparePage.FirstCarEngine.Contains(car1.Engine), "ERROR: First car engine data is not equal.");
                Assert.IsTrue(comparePage.FirstCarTrans.Contains(car1.Transmission), "ERROR: First car transmission data is not equal.");
                Assert.IsTrue(comparePage.SecondCarEngine.Contains(car2.Engine), "ERROR: Second car engine data is not equal.");
                Assert.IsTrue(comparePage.SecondCarTrans.Contains(car2.Transmission), "ERROR: Second car transmission data is not equal.");
            }
            );
        }

        private static Car SelectCarTrim(MainPage mainPage)
        {
            Logger.GetInstance().LogLine("STEP 2: Selecting 'research'.");
            mainPage.ClickResearchButton();

            ResearchPage researchPage = new ResearchPage();
            Logger.GetInstance().LogLine("STEP 3: Selecting random car data.");
            Car car = researchPage.SelectRandomCar();

            researchPage.ClickSearchButton();

            CarPage carPage = new CarPage();

            Logger.GetInstance().LogLine("STEP 4: Clicking 'compare trims' button.");

            if (carPage.IsCompareTrimsButtonPresent())
            {
                carPage.ClickCompareTrimsButton();
            }
            else
            {
                Logger.GetInstance().LogLine("WARNING: Failed to find 'Compare-trims' button, trying to select other car...");
                carPage.ClickResearchButton();

                ResearchPage secondTryResearchPage = new ResearchPage();
                car = secondTryResearchPage.SelectRandomCar();
                secondTryResearchPage.ClickSearchButton();

                CarPage secondTryCarPage = new CarPage(); 
                if (secondTryCarPage.IsCompareTrimsButtonPresent())
                {
                    secondTryCarPage.ClickCompareTrimsButton();
                }
                else
                {
                    Logger.GetInstance().LogLine("ERROR: Cannot find 'Compare trims' button: choosen parameters of car is incorrect!");
                    throw new System.Exception("ERROR: Cannot find 'Compare trims' button: choosen parameters of car is incorrect!");
                }
            }

            TrimsPage trimsPage = new TrimsPage();

            try
            {
                Logger.GetInstance().LogLine("STEP 5: Saving engine and trans data.");

                string engine = trimsPage.GetCarEngine();
                string transmission = trimsPage.GetCarTransmission();

                car.Engine = engine;
                car.Transmission = transmission;

                Logger.GetInstance().LogLine("STEP 6: Navigating to main page.");
                trimsPage.ClickHomeButton();

                return car;
            }
            catch (NoSuchElementException)
            {
                Logger.GetInstance().LogLine("ERROR: Cannot find engine or trans data!");
                throw new System.Exception("ERROR: Cannot find engine or trans data!");
            }
        }
    }
}
