using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.MainDataAccess
{
    public class DataAccessResult
    {
        private static readonly DataAccessResult _success = new DataAccessResult { Succeeded = true };
        private readonly List<DataAccessError> _errors = new List<DataAccessError>();

        public bool Succeeded { get; protected set; }

        public IEnumerable<DataAccessError> Errors => _errors;
      
        public static DataAccessResult Success => _success;

        public static DataAccessResult Failed(params DataAccessError[] errors)
        {
            var result = new DataAccessResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }

    public class DataAccessError
    {
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
