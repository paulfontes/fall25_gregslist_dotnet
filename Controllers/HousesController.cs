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

}