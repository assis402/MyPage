using MyPage.Application.Models.Google;
using System.Security.Claims;

namespace MyPage.Application.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<GoogleProfileModel> GetGoogleProfile(string code);

        public ClaimsPrincipal CreateUserIdentity(GoogleProfileModel googleProfile);
    }
}