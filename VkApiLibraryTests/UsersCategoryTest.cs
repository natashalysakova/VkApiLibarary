using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApiLibrary;

namespace VkApiLibraryTests
{
    [TestClass]
    public class UsersCategoryTest
    {
        private VkontakteApi api;

        [TestMethod]
        public void GetTestMethod()
        {
            api = new VkontakteApi(Const.userId, Const.token);

            User me;
            me = api.Users.Get(Const.userId, new[] { ProfileFields.sex, ProfileFields.bdate }, NameCase.dat);
            Assert.AreEqual(me.Id, Const.userId);
            Console.WriteLine(me.FirstName);

            Assert.AreEqual(string.Empty, me.Deactivated);

            Assert.AreEqual(Sex.Female, me.Sex);
            Assert.AreEqual("22.08.1992", me.Birthday.ToShortDateString());

            var users = api.Users.Get(new List<int>() { 205387401, 5452142 });

            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void SearchTestMethod()
        {

            api = new VkontakteApi(Const.userId, Const.token);
            int count;
            List<User> users = api.Users.Search("Лысакова Наташа", Sort.ByPopularity, out count, 0,
                new SearchProfileFields[]
                {
                    SearchProfileFields.city, SearchProfileFields.country
                });

            foreach (User user in users)
            {
                Console.WriteLine(user.City + " " + user.Country);
            }


        }
    }
}
