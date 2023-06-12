using MyPage.Application.Models.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<GoogleProfileModel> GetGoogleProfile(string code);
        public ClaimsPrincipal CreateUserIdentity(GoogleProfileModel googleProfile);
    }
}
