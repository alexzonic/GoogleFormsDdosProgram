using Newtonsoft.Json;

namespace GoogleFormsDDOS.Api
{
    public class JsonGetter
    {
        private readonly string _htmlPart;
        
        public JsonGetter(string url)
        {
            var htmlParser = new HtmlParser(url);
            _htmlPart = htmlParser.GetJsonInHtml();
        }
        
        // кусок сериализуем в класс FbPublicLoadData
        public FbPublicLoadData GetJsonData()
        {
            return JsonConvert.DeserializeObject<FbPublicLoadData>(_htmlPart);
        }
    }
}