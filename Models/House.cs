namespace gregslist_api_dotnet.Models;


public class House
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string ImgUrl { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Stories { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}




