using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class PostLike
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public DateTime AddedDateUTC { get; set; }
    }
}
