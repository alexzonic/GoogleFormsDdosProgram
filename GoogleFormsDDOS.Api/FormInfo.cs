using System.Collections.Generic;

namespace GoogleFormsDDOS.Api
{
    // каждый вопрос имеет id и список вариантов ответов
    public class FormInfo
    {
        public long Id { get; set; } // хз почему, но айдишники чет слишком длинные бывают
        public IList<string> Variants { get; set; }
        
    }
}