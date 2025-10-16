



namespace gregslist_api_dotnet.Repositories;


public class HousesRepository
{

    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }


    internal House GetHouseById(int houseId)
    {
        string sql = @"
        SELECT
          *
        FROM
          houses
        WHERE
          id = @HouseId;";

        object param = new { HouseId = houseId };

        House house = _db.Query<House>(sql, param).SingleOrDefault();

        return house;

    }

    internal House CreateHouse(House houseData)
    {
        string sql = @"
    INSERT INTO
        houses 
        (
        price,
        img_url,
        bedrooms,
        bathrooms,
        stories,
        creator_id
        )
    VALUES
        (
        @Price,
        @ImgUrl,
        @Bedrooms,
        @Bathrooms,
        @Stories,
        @CreatorId
        );

        SELECT
            houses.*,
            accounts.*
        FROM houses
        JOIN accounts ON houses.creator_id = accounts.id
        WHERE houses.id = LAST_INSERT_ID();";
        House house = _db.Query(sql, (House house, Account account) =>
        {
            house.Creator = account;
            return house;
        }, houseData).SingleOrDefault();

        return house;
    }

    internal List<House> GetHouses()
    {
        string sql = @"
        SELECT
          *
        FROM
          houses;
          ";
        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;

    }
}