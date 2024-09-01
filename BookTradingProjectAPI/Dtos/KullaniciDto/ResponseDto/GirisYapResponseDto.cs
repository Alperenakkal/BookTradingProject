using BookTradingProjectAPI.Dtos.Token.Cookie;

namespace BookTradingProjectAPI.Dtos.KullaniciDto.ResponseDto
{
    public class GirisYapResponseDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public CookieDto Cookie { get; set; }

    }
}
    