using NUnit.Framework;
using System.IO;
using TestFramework;

namespace CarTests
{
    public class CarsBaseTest
    {
        protected TestConfiguration Configuration;

        [SetUp]
        public void Setup()
        {
            SingleWebDriver.GetInstance();
            Configuration = new TestConfiguration($"{Path.GetFullPath("..\\..\\..\\")}/config.json");
        }

        [TearDown]
        public void TearDown()
        {
            SingleWebDriver.Quit();
            Logger.GetInstance().CreateLog(Configuration.GetParameter("OutputPath"));
        }
    }
}
