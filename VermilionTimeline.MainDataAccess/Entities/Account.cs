using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }

        public ICollection<AccountClaim> AccountClaims { get; set; }
        public ICollection<Area> Areas { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }
}
