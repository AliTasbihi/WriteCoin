using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace writeCoin_Lib
{
    
    public class WriteCoin
    {
        public string apiBitCoin = "https://api.lunarcrush.com/v2?data=assets&key={API_KEY_HERE}&symbol=BTC";
        public HttpClient HttpClient { get; set; }=new HttpClient();

        public WriteCoin()
        {
            Task<string> ApiRespone = Respone();
            ClassConfig config = DeserializeApiRespone(ApiRespone.Result);
            bool resultLogWrite = LogWrite(config);
            bool resultDataBaseWrite = DataBaseWrite(config);
            //var respone = HttpClient.GetAsync(apiBitCoin);
            //var readAsStringAsync = respone.Result.Content.ReadAsStringAsync().Result;
            //var config = JsonSerializer.Deserialize<ClassConfig>(readAsStringAsync);
            //var testconfig = config;
        }

        private bool DataBaseWrite(ClassConfig config)
        {
          
        }

        private bool LogWrite(object classConfig)
        {
            throw new NotImplementedException();
        }

        private ClassConfig DeserializeApiRespone(string apiRespone)=>
             JsonSerializer.Deserialize<ClassConfig>(apiRespone);
        
        //حالتی که حتما جواب بده
        public  async  Task<string> Respone()
        {
            var respone = await HttpClient.GetAsync(apiBitCoin);
            respone.EnsureSuccessStatusCode();
            var readAsStringAsync = await respone.Content.ReadAsStringAsync();
            return readAsStringAsync;
            //var deserialize = JsonSerializer.Deserialize<ClassConfig>(readAsStringAsync);


            //        var serializer = new DataContractJsonSerializer(typeof(GroupingJsonFile));
            //        var ms = new MemoryStream(Encoding.UTF8.GetBytes(readAsStringAsync));
            //        GroupingJsonFile jsonReadObject = (GroupingJsonFile)serializer.ReadObject(ms);
            //        var data = jsonReadObject;

        }
    }
}