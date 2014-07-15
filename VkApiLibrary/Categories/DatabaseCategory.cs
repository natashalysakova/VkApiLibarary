using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Xml;

namespace VkApiLibrary
{
    public class DatabaseCategory
    {
        public Dictionary<int, string> GetCountries(bool needAll = false, CountryCode[] codes = null, int offset = 0, int  count = 100)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();
            if (needAll)
                qs["need_all"] = "1";
            else
                qs["need_all"] = "0";

            if(codes != null)
                qs["code"] = String.Join(",", from CountryCode c in codes select c);

            qs["offset"] = offset.ToString();
           
            if(count > 0)
                qs["count"] = count.ToString();

            XmlDocument answer = VkResponse.ExecuteCommand("database.getCountries", qs);
            XmlNodeList usersNodes = answer.SelectNodes("response/country");
            
            if (usersNodes != null)
                foreach (XmlNode node in usersNodes)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("cid")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    countries.Add(id, title);
                }

            return countries;
        }

        public Dictionary<int, string> GetRegions(int countryId, string request, int offset = 0, int count = 100)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["country_id"] = countryId.ToString();

            qs["q"] = request;

            qs["offset"] = offset.ToString();

            if (count > 0)
                qs["count"] = count.ToString();

            XmlDocument answer = VkResponse.ExecuteCommand("database.getRegions", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/region");
            
            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("region_id")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    countries.Add(id, title);
                }

            return countries;
        }

        public Dictionary<int, string> GetStreetsById(int[] streetsIds)
        {
            Dictionary<int, string> regions = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["street_ids"] = String.Join(",", from id in streetsIds select id);


            XmlDocument answer = VkResponse.ExecuteCommand("database.getStreetsById", qs);
            XmlNodeList streetsList = answer.SelectNodes("response/street");

            if (streetsList != null)
                foreach (XmlNode node in streetsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("sid")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("name"));

                    regions.Add(id, title);
                }

            return regions;
        }

        public Dictionary<int, string> GetCountriesById(int[] countryIds)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["country_ids"] = String.Join(",", from id in countryIds select id);


            XmlDocument answer = VkResponse.ExecuteCommand("database.getCountriesById", qs);
            XmlNodeList streetsList = answer.SelectNodes("response/country");

            if (streetsList != null)
                foreach (XmlNode node in streetsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("cid")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("name"));

                    countries.Add(id, title);
                }

            return countries;
        }

        public Dictionary<int, string> GetCities(int countryId, string request, bool needAll = false, int regionId = 0, int offset = 0, int count = 100)
        {
            Dictionary<int, string> cities = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["country_id"] = countryId.ToString();
            qs["region_id"] = regionId.ToString();

            qs["q"] = request;

            qs["offset"] = offset.ToString();

            if (needAll)
                qs["need_all"] = "1";
            else
                qs["need_all"] = "0";



            if (count > 0)
                qs["count"] = count.ToString();

            XmlDocument answer = VkResponse.ExecuteCommand("database.getCities", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/city");

            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("cid")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    cities.Add(id, title);
                }

            return cities;
        }

        public Dictionary<int, string> GetCitiesById(int[] cityIds)
        {
            Dictionary<int, string> cities = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["city_ids"] = String.Join(",", from id in cityIds select id);


            XmlDocument answer = VkResponse.ExecuteCommand("database.getCitiesById", qs);
            XmlNodeList streetsList = answer.SelectNodes("response/city");

            if (streetsList != null)
                foreach (XmlNode node in streetsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("cid")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("name"));

                    cities.Add(id, title);
                }

            return cities;
        }

        public Dictionary<int, string> GetUniversities(int cityId, string request = "", int countryId = 0, int offset = 0, int count = 100)
        {
            Dictionary<int, string> universities = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["q"] = request;
            if (countryId != 0)
                qs["country_id"] = countryId.ToString();
                
            qs["city_id"] = cityId.ToString();
            qs["offset"] = offset.ToString();
            qs["count"] = count.ToString();


            XmlDocument answer = VkResponse.ExecuteCommand("database.getUniversities", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/university");

            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("id")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    universities.Add(id, title);
                }

            return universities;
        }

        public Dictionary<int, string> GetSchools(int cityId, string request = "", int offset = 0, int count = 100)
        {
            Dictionary<int, string> schools = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["q"] = request;
            qs["city_id"] = cityId.ToString();
            qs["offset"] = offset.ToString();
            qs["count"] = count.ToString();


            XmlDocument answer = VkResponse.ExecuteCommand("database.getSchools", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/school");

            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("id")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    schools.Add(id, title);
                }

            return schools;
        }

        public Dictionary<int, string> GetSchoolClasses(int countryId)
        {
            Dictionary<int, string> cities = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["country_id"] = countryId.ToString();

            XmlDocument answer = VkResponse.ExecuteCommand("database.getSchoolClasses", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/list");

            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.ChildNodes[0]));
                    string title = VkResponse.GetDataFromXmlNode(node.ChildNodes[1]);

                    cities.Add(id, title);
                }

            return cities;
        }

        public Dictionary<int, string> GetFaculties(int universityId, int offset = 0, int count = 100)
        {
            Dictionary<int, string> schools = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["university_id"] = universityId.ToString();
            qs["offset"] = offset.ToString();
            qs["count"] = count.ToString();


            XmlDocument answer = VkResponse.ExecuteCommand("database.getFaculties", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/faculty");

            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("id")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    schools.Add(id, title);
                }

            return schools;
        }

        public Dictionary<int, string> GetChairs(int facultyId, int offset = 0, int count = 100)
        {
            Dictionary<int, string> schools = new Dictionary<int, string>();

            NameValueCollection qs = new NameValueCollection();

            qs["faculty_id"] = facultyId.ToString();
            qs["offset"] = offset.ToString();
            qs["count"] = count.ToString();


            XmlDocument answer = VkResponse.ExecuteCommand("database.getChairs", qs);
            XmlNodeList regionsList = answer.SelectNodes("response/faculty");

            if (regionsList != null)
                foreach (XmlNode node in regionsList)
                {
                    int id = Convert.ToInt32(VkResponse.GetDataFromXmlNode(node.SelectSingleNode("id")));
                    string title = VkResponse.GetDataFromXmlNode(node.SelectSingleNode("title"));

                    schools.Add(id, title);
                }

            return schools;
        }


    }
}
