using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalConsole
{
    public class ScenarioTest
    {
        private ScenarioHelper _scenarioHelper;

        public ScenarioTest(ScenarioHelper scenarioHelper)
        {
            _scenarioHelper = scenarioHelper;
        }

        public void Test()
        {
            Guid d1 = _scenarioHelper.CreateDriver("Jan", "Kowalski", "ABCD");
            Guid d2 = _scenarioHelper.CreateDriver("Patrycja", "Milka", "COVID");

            Guid c1 = _scenarioHelper.CreateCar("WWA123");
            Guid c2 = _scenarioHelper.CreateCar("TORPEDA");

            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowDrivers();
            _scenarioHelper.ShowRentals();

            Guid rental1 = _scenarioHelper.StartRental(d1, c1);
            Guid rental2 = _scenarioHelper.StartRental(d2, c2);

            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowDrivers();
            _scenarioHelper.ShowRentals();

            _scenarioHelper.FinishRental(rental1, c1, d1);
            _scenarioHelper.FinishRental(rental2, c2, d2);

            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowDrivers();
            _scenarioHelper.ShowRentals();
        }
    }
}
