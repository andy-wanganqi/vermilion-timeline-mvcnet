using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class PostComment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }

        public string Content { get; set; }
        public DateTime AddedDateUTC { get; set; }
        public DateTime? ModifiedDateUTC { get; set; }
    }
}
