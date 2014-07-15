using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApiLibrary;
using VkApiLibrary.Objects;

namespace VkApiLibraryTests
{
    [TestClass]
    public class UsersCategoryTest
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
        public void GetTestMethod()
        {
            Auth();

            User me;
            
            me = api.Users.Get(api.CurrentUser.Id, new[] { ProfileFields.sex, ProfileFields.bdate }, NameCase.dat);
            Assert.AreEqual(me.Id, api.CurrentUser.Id);
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

            Auth();

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
