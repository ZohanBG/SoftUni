using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver goodDriver1;
        private UnitDriver goodDriver2;
        private UnitDriver goodDriver3;
        private UnitDriver goodDriver4;
        private UnitDriver badDriver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            goodDriver1 = new UnitDriver("Driver1", new UnitCar("Car1", 10, 100));
            goodDriver2 = new UnitDriver("Driver2", new UnitCar("Car2", 10, 100));
            goodDriver3 = new UnitDriver("Driver3", new UnitCar("Car3", 10, 100));
            goodDriver4 = new UnitDriver("Driver4", new UnitCar("Car4", 10, 100));
            badDriver = null;
            race = new RaceEntry();
        }

        [Test]
        public void ThrowsInvalidOperationExceptionWhenNullDriverIsAdded()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(badDriver));
        }

        [Test]
        public void ThrowsInvalidOperationExceptionWhenSameDriverIsAdded()
        {
            race.AddDriver(goodDriver1);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(goodDriver1));
        }

        [Test]
        public void ChecksIfDriverIsAddedFromString()
        {
            string result = race.AddDriver(goodDriver1);
            Assert.That(result, Is.EqualTo($"Driver {goodDriver1.Name} added in race."));            
        }

        [Test]
        public void ChecksIfDriverIsAddedFromCounter()
        {
            race.AddDriver(goodDriver1);
            Assert.That(race.Counter, Is.EqualTo(1));
        }

        [Test]
        public void ThrowsInvalidOperationExceptionWhenAverageHpIsCalculatedWithNotEnoughDrivers()
        {          
            Assert.Throws<InvalidOperationException>(()=>race.CalculateAverageHorsePower());
        }

        [Test]
        public void ChecksIfValueIsReturned()
        {
            race.AddDriver(goodDriver1);
            race.AddDriver(goodDriver2);
            race.AddDriver(goodDriver3);
            race.AddDriver(goodDriver4);
            double avrgHp = race.CalculateAverageHorsePower();
            Assert.That(avrgHp, Is.EqualTo(10));
        }





    }
}