using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class Area
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ResourceUrl { get; set; }
        public int Priority { get; set; }
        public string Begins { get; set; }
        public string Ends { get; set; }
        public string Status { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
