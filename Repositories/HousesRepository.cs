

namespace gregslist_api_dotnet.Repositories;


public class HousesRepository
{

    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }
    // internal House GetHouses(House houseData)
    // {
    //     string sql = @"
    // INSERT INTO
    //     houses 
    //     (
    //     price,
    //     img_url,
    //     bedrooms,
    //     bathrooms,
    //     stories
    //     )
    // VALUES
    //     (
    //     @Price,
    //     @ImgUrl,
    //     @Bedrooms,
    //     @Bathrooms,
    //     @Stories
    //     );

    //     SELECT
    //         houses.*,
    //         accounts.*
    //     FROM houses
    //     ";
    //     House house = _db.Query<House>(sql).SingleOrDefault();

    //     return house;
    // }

    internal List<House> GetHouses()
    {
        string sql = @"
        SELECT
          houses.*,
          accounts.*
        FROM
          houses;";
        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;

    }
}