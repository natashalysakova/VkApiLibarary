using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApiLibrary;
using VkApiLibrary.Objects;

namespace VkApiLibraryTests
{
    [TestClass]
    public class DatabaseTestClass
    {
        private VkontakteApi api;

        public void Auth()
        {
            AuthForm form = new AuthForm("");

            if (form.ShowDialog() == DialogResult.OK)
            {
                int userid; string token;
                var res = form.GetRes();
                userid = Convert.ToInt32(res[0]);
                token = res[1];
                api = new VkontakteApi(userid, token);
            }
        }

        [TestMethod]
        public void GetCountriesTestMethod()
        {
            Auth();

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
            Auth();

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
            Auth();

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
            Auth();

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
            Auth();

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
            Auth();

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
            Auth();

            var countries = api.Database.GetUniversities(api.CurrentUser.City);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetSchoolsTestMethod()
        {
            Auth();

            var countries = api.Database.GetSchools(api.CurrentUser.City, count:1000);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetSchoolClassesTestMethod()
        {
            Auth();

            var countries = api.Database.GetSchoolClasses(api.CurrentUser.Country);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetFacultiesTestMethod()
        {
            Auth();

            var countries = api.Database.GetFaculties(1);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }

        [TestMethod]
        public void GetChairsTestMethod()
        {
            Auth();

            var countries = api.Database.GetChairs(1);

            foreach (KeyValuePair<int, string> region in countries)
            {
                Console.WriteLine(region.Value);
            }
        }
    }
}