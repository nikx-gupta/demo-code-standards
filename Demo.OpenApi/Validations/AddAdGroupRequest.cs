using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.OpenAPI.Validations
{

    public class AddAdGroupRequest
    {
        public Guid AppRequestId { get; set; }
        public int EmployeeId { get; set; }
        public int AdGroupId { get; set; }
        public string NtLoginId { get; set; }
    }
}
