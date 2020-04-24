using System;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Services;

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
                simpleContainer.OfficeService,
                simpleContainer.FinishRentalService
                    );

            var scenarioTest = new ScenarioTest(scenarioHelper);

            scenarioTest.Test();

            //Console.WriteLine(DialCode.GetAreaCodeByCountry("Poland"));

            // DialCode dc = new DialCode();

            //Console.Write(dc.GetAreaCodeByCountry("Poland"));

            //PostalCode pc = new PostalCode("26", "001");

            //pc.GetLocalityByPostalCode(pc);

            //Address a = new Address();
            //a.GetLocalitiesByPostalCode(new PostalCode("26", "001"));

            // RootObject r = new RootObject();
            //r.GetLocalitiesByPostalCode(new PostalCode("26", "001"));
            //AddressByPostalService.GetLocalitiesByPostalCode(new PostalCode("30", "002"));

            Console.ReadKey();
        }
    }
}
