using System;
using System.Linq;
using System.Text;

namespace GoogleFormsDDOS.Api
{
    public class HtmlParser
    {
        private readonly string _htmlCode;
        private const string StopWord = "FB_PUBLIC_LOAD_DATA_"; // стоп слово - вспомнил 50 оттенков серого и поржал
        
        public HtmlParser(string url)
        {
            _htmlCode = HtmlGetter.GetHypertext(url);
        }
    
        // парсим html и получаем нужный кусок
        public string GetJsonInHtml()
        {
            var jsonIndex = _htmlCode.IndexOf(StopWord, StringComparison.Ordinal);
            var chars = new[]{'\n', '\t', '\r', '\b'};
            var html = new string(_htmlCode.Skip(jsonIndex + StopWord.Length + 2).Where(c => !chars.Contains(c)).ToArray());
            var builder = new StringBuilder();
            for (var i = 0; i < html.Length; i++)
            {
                if (html[i] == ']' && html[i + 1] == ']' && html[i + 2] == ']' &&
                    html[i + 3] == ']')
                {
                    builder.Append("]]]]]]");
                    break;
                }

                builder.Append(html[i]);
            }

            return "{ \"FB_PUBLIC_LOAD_DATA_\": " + builder + "}";
        }
    }
}