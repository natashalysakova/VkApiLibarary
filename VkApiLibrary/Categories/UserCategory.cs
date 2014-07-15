using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml;

namespace VkApiLibrary
{
    public class UserCategory
    {
        public User Get(int userId, ProfileFields[] fields = null, NameCase nameCase = NameCase.nom)
        {

            NameValueCollection qs = new NameValueCollection();
            qs["uids"] = userId.ToString();

            if (fields != null)
                qs["fields"] = String.Join(",", from field in fields select field.ToString());

            qs["name_case"] = nameCase.ToString();
            XmlDocument answer = VkResponse.ExecuteCommand("users.get", qs);
            XmlNode usersNodes = answer.SelectSingleNode("response/user");
            User user = new User(usersNodes);
            return user;

        }

        public User Get(int userId, ProfileFields field = ProfileFields.all, NameCase nameCase = NameCase.nom)
        {
            if (field == ProfileFields.all)
            {
                var values = Enum.GetValues(typeof(ProfileFields));
                List<ProfileFields> allfields = new List<ProfileFields>();

                for (int i = 0; i < values.Length; i++)
                {
                    if ((ProfileFields)values.GetValue(i) != ProfileFields.all)
                        allfields.Add((ProfileFields)values.GetValue(i));
                }
                return Get(userId, allfields.ToArray(), nameCase);
            }

            return Get(userId, new[] { field }, nameCase);
        }

        public List<User> Get(List<int> userIds, ProfileFields[] fields = null, NameCase nameCase = NameCase.nom)
        {
            List<User> users = new List<User>();

            NameValueCollection qs = new NameValueCollection();
            qs["uids"] = String.Join(",", from id in userIds select id);

            if (fields != null)
                qs["fields"] = String.Join(",", from field in fields select field.ToString());

            qs["name_case"] = nameCase.ToString();

            XmlDocument answer = VkResponse.ExecuteCommand("users.get", qs);
            XmlNodeList usersNodes = answer.SelectNodes("response/user");


            if (usersNodes != null)
                foreach (XmlNode user in usersNodes)
                {
                    users.Add(new User(user));
                }

            return users;
        }

        public List<User> Search(string request, Sort sort, out int count, int offset = 0,
            SearchProfileFields[] fields = null)
        {
            List<User> users = new List<User>();

            NameValueCollection qs = new NameValueCollection();
            qs["q"] = request;

            if (fields != null)
                qs["fields"] = String.Join(",", from field in fields select field.ToString());

            qs["sort"] = ((int)sort).ToString();
            qs["offset"] = offset.ToString();

            XmlDocument answer = VkResponse.ExecuteCommand("users.search", qs);

            XmlNode node = answer.SelectSingleNode("response/count");
            if (node != null)
                count = Convert.ToInt32(node.InnerText);
            else
            {
                count = 0;
            }

            XmlNodeList usersNodes = answer.SelectNodes("response/user");



            if (usersNodes != null)
                foreach (XmlNode user in usersNodes)
                {
                    users.Add(new User(user));
                }

            return users;

        }

    }
}