using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSD600.GoodLinkOrBadLink
{
    public class CheckURL
    {
        public static int GetURLStatusCode(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                int statusCode = (int)response.StatusCode;
                return statusCode;
            }
            catch (Exception e)
            {

                if (e.Message.Contains("400"))
                {
                    return 400;
                }
                else if (e.Message.Contains("404"))
                {
                    return 404;
                }
                else
                {
                    return 0;
                }
            }



        }
    }

}