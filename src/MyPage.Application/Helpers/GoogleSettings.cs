using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Helpers
{
    public class GoogleSettings
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string CallbackUrl { get; init; }
        public string FirebaseProjectId { get; init; }
    }
}
