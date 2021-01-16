using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GoogleFormsDDOS.Api
{
    public class PostForm
    {
        private readonly List<FormInfo> _infos;
        private readonly string _url;
        private readonly HttpClient _client;
        private readonly Random _random;
        
        public PostForm(List<FormInfo> infos, string url)
        {
            _infos = infos;
            _client = new HttpClient();
            _random = new Random();
            _url = url.Replace("viewform", "formResponse?");
        }

        // генерируем ответы и url который запостим
        public void Post()
        {
            // ваще хз как назвать эту переменную
            var uriInfo = new StringBuilder();

            foreach (var info in _infos)
            {
                uriInfo.Append($"entry.{info.Id}={GenerateAnswer(info.Variants)}&");
            }

            var uri = _url + uriInfo;
            
            _client.PostAsync(uri, null).GetAwaiter().GetResult();
        }

        private string GenerateAnswer(IList<string> variants)
        {
            if (variants.Count == 0) // 0 если это поле, где надо вводить текст (хз будет работать или нет)
                return "произошел тролленг";
            return variants[_random.Next(variants.Count)];
        }
    }
}