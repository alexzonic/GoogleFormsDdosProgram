using System;

/*
 получаем html код страницы
 парсим html и получаем нужный кусок
 кусок сериализуем в класс FbPublicLoadData
 получаем все вопросы формы в виде List<FormInfo>
 генерируем ответы и url который запостим
 */

namespace GoogleFormsDDOS.Api
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var uri = Console.ReadLine();
            //const string uri = "https://docs.google.com/forms/d/e/1FAIpQLSfICHtD4yVZ1tVZYGlD5fA1Srt5ORLggznZT2GR4agkfDDf0w/viewform";
            
            var json = new JsonGetter(uri);
            var data = json.GetJsonData();
            var form = new Form(data);
            var postForm = new PostForm(form.GetFromInfo(), uri);
            
            // обернем в цикл и можно делать пост много много раз
            for (var i = 0; i < 10; i++)
            {
                postForm.Post(); 
            }
        }
    }
}