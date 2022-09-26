using Microsoft.AspNetCore.Mvc;
using Subway.UI.Models;

namespace Subway.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
 
        readonly IConfiguration _configuration;
        public LoginController( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<Token> Login( UserLogin userLogin)
        {
            User user = new User()
            {

            };
            //User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);

            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                //await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }
}
