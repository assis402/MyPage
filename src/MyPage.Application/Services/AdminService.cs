using GoogleAuthentication.Services;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Google;
using MyPage.Application.Services.Interfaces;
using System.Security.Claims;

namespace MyPage.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly GoogleSettings _googleSettings;

        public AdminService(Settings settings)
        {
            _googleSettings = settings.GoogleSettings;
        }

        public async Task<GoogleProfileModel> GetGoogleProfile(string code)
        {
            var token = await GoogleAuth.GetAuthAccessToken(code,
                _googleSettings.ClientId,
                _googleSettings.ClientSecret,
                _googleSettings.CallbackUrl);

            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());
            return userProfile.ToObject<GoogleProfileModel>();
        }

        public ClaimsPrincipal CreateUserIdentity(GoogleProfileModel googleProfile)
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, googleProfile.Name),
                new Claim(ClaimTypes.Email, googleProfile.Email)
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User");
            return new ClaimsPrincipal(new[] { userIdentity });
        }
    }
}