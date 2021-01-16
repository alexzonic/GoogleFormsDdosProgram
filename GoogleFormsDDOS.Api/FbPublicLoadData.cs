using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleFormsDDOS.Api
{
    // эта та штука, на которую Александр как-то указал, когда объяснял Егору что-то по этому заданию после занятий.
    // честно сказать, если бы я тогда это не послушал, я бы вряд ли смог сделать это задание, ибо мои познания в json
    // все еще очень скудные
    public class FbPublicLoadData
    {
        [JsonProperty("FB_PUBLIC_LOAD_DATA_")]
        public List<List<List<List<object>>>> FBPUBLICLOADDATA { get; set; }
    }
}