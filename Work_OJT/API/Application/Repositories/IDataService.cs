using API.Application.Services;

namespace API.Application.Repositories
{
    public interface IDataService
    {
        void SaveData(Data data);
        List<Data> ReadData();
    }
}
