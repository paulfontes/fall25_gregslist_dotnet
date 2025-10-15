namespace gregslist_api_dotnet.Controllers;

[ApiController]
[Route("api/houses")]
public class HousesController : ControllerBase
{
    private readonly HousesService _housesService;
    private readonly Auth0Provider _auth;

    public HousesController(HousesService housesService, Auth0Provider auth)
    {
        _housesService = housesService;
        _auth = auth;
    }

    [HttpGet("test")]
    public string Test()
    {
        return "Houses Controller is ready to build 🛖";
    }

    [HttpGet]
    public ActionResult<List<House>> GetHouses()
    {
        try
        {
            List<House> houses = _housesService.GetHouses();
            return Ok(houses);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(int houseId)
    {
        try
        {
            House house = _housesService.GetHouseById(houseId);
            return Ok(house);

        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<House>> CreateHouse([FromBody] House houseData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>
            (HttpContext);
            houseData.CreatorId = userInfo.Id;
            House house = _housesService.createHouse(houseData);
            return Ok(house);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }

}