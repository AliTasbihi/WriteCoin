using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using dataLayer.Model;
using Serilog;


namespace writeCoin_Lib
{
    
    public class WriteCoin
    {
        public string apiBitCoin = "https://api.lunarcrush.com/v2?data=assets&key={API_KEY_HERE}&symbol=BTC";
        public HttpClient HttpClient { get; set; }=new HttpClient();

        public WriteCoin()
        {
            string respone = ResponeSimple(); 
            //Task<string> ApiRespone = Respone();
            ClassConfig? classConfig = JsonSerializer.Deserialize<ClassConfig>(respone);
            ClassConfig config = DeserializeApiRespone(respone.ToString());
            bool resultDataBaseWrite = DataBaseWrite(config);
            bool resultLogWrite = LogWrite(config,resultDataBaseWrite);
            //var respone = HttpClient.GetAsync(apiBitCoin);
            //var readAsStringAsync = respone.Result.Content.ReadAsStringAsync().Result;
            //var config = JsonSerializer.Deserialize<ClassConfig>(readAsStringAsync);
            //var testconfig = config;
        }


        private bool DataBaseWrite(ClassConfig config)
        {
            var provider = new dataLayer.Service.Provider();
            EndPointCoin point = new EndPointCoin();
            point.Name = config.data[0].name.ToString();
            point.Time = DateTime.Now.ToShortTimeString();
            point.History = DateTime.Now.Date.ToShortDateString().ToString();
            point.Price = config.data[0].price.ToString();
            bool resultInsertToDataBase = provider.Insert(point);
            return resultInsertToDataBase;
        }

        private bool LogWrite(ClassConfig config, bool resultDataBase)
        {
            if (resultDataBase)
            {
                Log.Information("Successful to add database" + JsonSerializer.Serialize(config));
                return true;
            }
            else
            {
                Log.Error("Error to add database" + JsonSerializer.Serialize(config));
                return false;
            }
        }

        private ClassConfig DeserializeApiRespone(string apiRespone)=>
             JsonSerializer.Deserialize<ClassConfig>(apiRespone);
        
        //حالتی که حتما جواب بده
        public  async  Task<string> Respone()
        {
            var respone = await HttpClient.GetAsync(apiBitCoin);
            //respone.EnsureSuccessStatusCode();
            var readAsStringAsync = await respone.Content.ReadAsStringAsync();
            return readAsStringAsync;
            //var deserialize = JsonSerializer.Deserialize<ClassConfig>(readAsStringAsync);


            //        var serializer = new DataContractJsonSerializer(typeof(GroupingJsonFile));
            //        var ms = new MemoryStream(Encoding.UTF8.GetBytes(readAsStringAsync));
            //        GroupingJsonFile jsonReadObject = (GroupingJsonFile)serializer.ReadObject(ms);
            //        var data = jsonReadObject;

        }
        public string ResponeSimple()
        {
            var async = HttpClient.GetAsync(apiBitCoin);
            var stringAsync = async.Result.Content.ReadAsStringAsync();
            return stringAsync.Result;
        }
    }
}