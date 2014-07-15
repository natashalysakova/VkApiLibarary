using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApiLibrary;

namespace VkApiLibraryTests
{
    [TestClass]
    public class DatabaseTestClass
    {
        private VkontakteApi api;

        [TestMethod]
        public void GetCountriesTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetCountries(true, count:1000);

            foreach (KeyValuePair<int, string> country in countries)
            {
                Console.WriteLine(country.Value);
            }

            Assert.AreNotEqual(0, countries.Count);
        }

        [TestMethod]
        public void GetRegionsTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var regions = api.Database.GetRegions(api.CurrentUser.Country, String.Empty);

            foreach (KeyValuePair<int, string> region in regions)
            {
                Console.WriteLine(region.Value);
            }

            Assert.AreNotEqual(0, regions.Count);
        }


        [TestMethod]
        public void GetStreetsByIdTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var streets = api.Database.GetStreetsById(new []{1});

            foreach (KeyValuePair<int, string> region in streets)
            {
                Console.WriteLine(region.Value);
            }

            Assert.AreEqual(1, streets.Count);
        }

        [TestMethod]
        public void GetCountriesByIdTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetCountriesById(new[] { 1 });

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }

            Assert.AreEqual(1, countries.Count);
        }

        [TestMethod]
        public void GetCitiesTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetCities(2, String.Empty);

            foreach (KeyValuePair<int, string> country in countries)
            {
                Console.WriteLine(country.Value);
            }

            Assert.AreNotEqual(0, countries.Count);
        }


        [TestMethod]
        public void GetCitiesByIdTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetCitiesById(new[] { 1 });

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }

            Assert.AreEqual(1, countries.Count);
        }

        [TestMethod]
        public void GetUniversitiesTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetUniversities(api.CurrentUser.City);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetSchoolsTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetSchools(api.CurrentUser.City, count:1000);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetSchoolClassesTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetSchoolClasses(api.CurrentUser.Country);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetFacultiesTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetFaculties(1);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetChairsTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            var countries = api.Database.GetChairs(1);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }
    }
}