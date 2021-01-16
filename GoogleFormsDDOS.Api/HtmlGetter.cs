using System.IO;
using System.Net;

namespace GoogleFormsDDOS.Api
{
    // получаем html код страницы
    public class HtmlGetter
    {
        public static string GetHypertext(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var str = "";
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                str = reader.ReadToEnd();
            }

            return str;
        }
    }
}