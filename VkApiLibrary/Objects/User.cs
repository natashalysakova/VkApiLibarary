using System;
using System.Xml;

namespace VkApiLibrary.Objects
{
    public class User
    {

        public User(XmlNode answer)
        {

            FirstName = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("first_name"));
            LastName = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("last_name"));
            Id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("uid")));
            Deactivated = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("deactivated"));
            Hidden = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("hidden")) != "0";

            Verified = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("verified")) == "1";
            BlackListed = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("blacklisted")) == "1";

            Sex _tmp;
            Enum.TryParse(VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("sex")), out _tmp);
            Sex = _tmp;

            DateTime _date;
            DateTime.TryParse(VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("bdate")), out _date);
            Birthday = _date;

            HomeTown = VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("home_town"));

            int cityid;
            int.TryParse(VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("city")), out cityid);
            City = cityid;

            int countryid;
            int.TryParse(VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("country")), out countryid);
            Country = countryid;

        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Deactivated { get; private set; }
        public bool Hidden { get; private set; }

        public bool Verified { get; private set; }
        public bool BlackListed { get; private set; }

        public Sex Sex { get; private set; }
        public DateTime Birthday { get; private set; }

        public int City { get; private set; }
        public int Country { get; private set; }

        public string HomeTown { get; private set; }

        public string Photo50 { get; private set; }
        public string Photo100 { get; private set; }

        public string Photo200 { get; private set; }
        public string Photo200Orig { get; private set; }

        public string Photo400Orig { get; private set; }

        public string PhotoMax { get; private set; }
        public string PhotoMaxOrig { get; private set; }

        public bool Online { get; private set; }

        public string Domain { get; private set; }

        public bool HasMobile { get; private set; }


    }

}