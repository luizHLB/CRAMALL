using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMALL.Api.Security
{
    public class UserInfo
    {
        public UserInfo(int id, Guid token, ProfileEnum profile)
        {
            Id = id;
            Token = token;
            LastConnection = DateTime.Now;
            Profile = profile;
        }

        public int Id { get; set; }
        public Guid Token { get; set; }
        public Guid BranchId { get; set; }
        public DateTime LastConnection { get; set; }
        public ProfileEnum Profile { get; set; }
    }
}
