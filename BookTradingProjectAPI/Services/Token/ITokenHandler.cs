namespace BookTradingProjectAPI.Services.Token
{
    public interface ITokenHandler
    {
        Dtos.Token.Token CreateAccessToken(int minutes);
    }
}
