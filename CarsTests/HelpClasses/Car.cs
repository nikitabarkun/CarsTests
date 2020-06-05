namespace CarTests.HelpClasses
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }

        public Car(string make, string model, string year, string engine, string transmission)
        {
            Make = make;
            Model = model;
            Year = year;
            Engine = engine;
            Transmission = transmission;
        }
    }
}
