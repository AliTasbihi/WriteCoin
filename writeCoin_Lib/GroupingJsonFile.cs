using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace writeCoin_Lib
{
    [Serializable]
    public class GroupingJsonFile
    {
        public ClassConfig Config { get; set; }
    }
    [Serializable]
    public class ClassConfig
    {
        public Config config { get; set; }
        public List<Data> data { get; set; }
    }
    [Serializable]
    public class Config
    {
        public string data { get; set; }
    }

    [Serializable]
    public class Data   
    {
        public string name { get; set; }
        public object price { get; set; }
    }
}
