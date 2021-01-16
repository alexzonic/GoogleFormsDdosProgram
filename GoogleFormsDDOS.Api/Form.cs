using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace GoogleFormsDDOS.Api
{
    public class Form
    {
        private readonly List<List<object>> _data;

        public Form(FbPublicLoadData data)
        {
            _data = data.FBPUBLICLOADDATA[1][1];
        }
        
        // самая геморрная часть программы - получаем все вопросы формы в виде List<FormInfo>
        public List<FormInfo> GetFromInfo()
        {
            var chars = new[] { '\r', '\t', '\n', ',', '[', ']', '\"'};
            
            var arrays = new List<string[]>();
            foreach (var arr in _data.Select(list => list[4] as JArray))
            {
                arrays.AddRange(arr
                    .Select(token => token.ToString().Split(chars, StringSplitOptions.RemoveEmptyEntries)));
            }
            
            var infos = arrays.Select(array => 
                array.Select(w => w.Trim())
                    .Where(w => w != "null" && w != "" && w != "0")
                    .ToArray())
                .ToList();

            return infos
                .Select(info => 
                    new FormInfo {Id = long.Parse(info[0]), Variants = info.Skip(1).Select(w => w).ToList()})
                .ToList();
        }
    }
}