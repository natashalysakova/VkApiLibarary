using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Xml;
using VkApiLibrary.Objects;

namespace VkApiLibrary.Categories
{
    public class WallCategory
    {
        public int Post(int ownerId, string message, bool friendsOnly = false,
            bool fromGroup = false,
            Attachment[] attachments = null, Services[] services = null, bool signed = false,
            int lat = 0, int longt = 0, int placeId = -1, int postId = -1)
        {
            return Post(ownerId, message, DateTime.MinValue, friendsOnly, fromGroup, attachments, services, signed, lat, longt,
                placeId, postId);
        }

        public int Post(int ownerId, string message, DateTime publishDate, bool friendsOnly = false, bool fromGroup = false,
            Attachment[] attachments = null, Services[] services = null, bool signed = false,
             int lat = 0, int longt = 0, int placeId = -1, int postId = -1)
        {
            NameValueCollection qs = new NameValueCollection();

            qs["ownerId"] = ownerId.ToString();
            qs["message"] = message;

            if (publishDate != DateTime.MinValue)
            {
                long time = (publishDate.ToUniversalTime().Ticks - 621355968000000000) / 10000000; //перевод числа в unixtime
                qs["publish_date"] = time.ToString();

            }

            if (friendsOnly)
            {
                qs["friends_only"] = 1.ToString();
            }

            if (attachments != null)
                qs["attachments"] = string.Join(",", from attachment in attachments select attachment.ToString());
            if (services != null)
                qs["services"] = string.Join(",", from service in services select service.ToString());

            if (signed)
            {
                qs["signed"] = 1.ToString();
            }

            if (lat > 0)
            {
                qs["lat"] = lat.ToString();
            }

            if (longt > 0)
            {
                qs["long"] = longt.ToString();
            }

            if (placeId != -1)
            {
                qs["place_id"] = placeId.ToString();
            }

            if (postId != -1)
            {
                qs["post_id"] = postId.ToString();
            }

            XmlDocument answer = VkResponse.ExecuteCommand("wall.post", qs);

            return Convert.ToInt32(VkResponse.GetDataFromXmlNode(answer.SelectSingleNode("response/post_id")));
        }
    }
}
