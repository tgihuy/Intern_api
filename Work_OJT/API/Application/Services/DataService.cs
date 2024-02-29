using API.Application.Repositories;
using Newtonsoft.Json;

namespace API.Application.Services
{
    public class Data{ 
        public string Name { get; set; }
        public string Value { get; set;}
    }
    public class DataService : IDataService
    {
        private const string FilePath = "data.json";
        private readonly ILogger<DataService> _logger;

        public DataService(ILogger<DataService> logger)
        {
            _logger = logger;
        }
        public void SaveData(Data data)
        {
            try {

                string jsonData = JsonConvert.SerializeObject(data);
                File.WriteAllText(FilePath, jsonData);
            }
            catch (Exception e) {
                _logger.LogInformation(e.ToString());
            }
        }

        public List<Data> ReadData()
        {
            if (File.Exists(FilePath))
            {
                string jsonData = File.ReadAllText(FilePath);
                var data = JsonConvert.DeserializeObject<Data>(jsonData);
                var listData = new List<Data>();
                listData.Add(data);
                return listData;
            }
            else
            {
                return new List<Data>();
            }
        }
    }
}
