using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApiLibrary;
using VkApiLibrary.Objects;

namespace VkApiLibraryTests
{
    [TestClass]
    public class WallCategoryTest
    {
        private VkontakteApi api;

        public void Auth()
        {
            AuthForm form = new AuthForm("wall");

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
        public void PostTest()
        {
            Auth();

            api.Wall.Post(api.CurrentUser.Id, "Test API Message");

        }
    }
}
