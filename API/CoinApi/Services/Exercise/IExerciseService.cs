using CoinApi.DB_Models;
using CoinApi.Request_Models;
using CoinApi.Shared;

namespace CoinApi.Services.Exercise
{
    public interface IExerciseService
    {
        List<Object> loadDB();
    }
}
