using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class Gain
    {
        public Guid Id { get; set; }
        public Guid ClueId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AddedDateUTC { get; set; }

    }
}
