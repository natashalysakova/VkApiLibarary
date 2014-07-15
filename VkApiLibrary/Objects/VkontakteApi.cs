using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Xml;

namespace VkApiLibrary
{
    public class VkontakteApi
    {
        internal static string _token;
        int _userId;

        public UserCategory Users { private set; get; }
        public DatabaseCategory Database { private set; get; }

        public User CurrentUser;


        public VkontakteApi(int userId, string token)
        {
            _userId = userId;
            _token = token;

            Users = new UserCategory();
            Database = new DatabaseCategory();


            CurrentUser = Users.Get(userId, ProfileFields.all);
        }
    }
}
