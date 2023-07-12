using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid? AreaId { get; set; }
        public Guid? TopicId { get; set; }
        public Guid? ClueId { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string UrlHandle { get; set; }
        public DateTime LastModifiedDateUTC { get; set; }

        public DateTime? PublishedDateUTC { get; set; }
        public bool Visible { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        public ICollection<PostComment> PostComments { get; set; }

    }
}
