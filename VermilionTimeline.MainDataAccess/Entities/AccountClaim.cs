using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess.Entities
{
    public class AccountClaim
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }

        public string Type { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }

    }
}
