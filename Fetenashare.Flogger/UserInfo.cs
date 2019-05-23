using System.Collections.Generic;

namespace Fetenashare.Flogger
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public Dictionary<string, List<string>> UserClaims { get; set; }
    }
}
