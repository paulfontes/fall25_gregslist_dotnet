

namespace gregslist_api_dotnet.Services;


public class HousesService
{
    private readonly HousesRepository _repository;

    public HousesService(HousesRepository repository)
    {
        _repository = repository;
    }

    internal House createHouse(House houseData)
    {
        House house = _repository.CreateHouse(houseData);
        return house;
    }

    internal House GetHouseById(int houseId)
    {
        House house = _repository.GetHouseById(houseId);

        if (house == null)
        {
            throw new Exception("No house with id:" + houseId);
        }
        return house;
    }

    internal List<House> GetHouses()
    {
        List<House> houses = _repository.GetHouses();
        return houses;
    }
}