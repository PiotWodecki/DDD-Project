using System;

namespace DDD.CarRentalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleContainer = new SimpleTestContainer();
            var scenarioHelper = new ScenarioHelper(
                simpleContainer.DriverService,
                simpleContainer.CarService,
                simpleContainer.RentalService,
                simpleContainer.FinishRentalService
            );

            var scenarioTest = new ScenarioTest(scenarioHelper);

            scenarioTest.Test();
        }
    }
}
