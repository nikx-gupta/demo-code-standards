using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.OpenAPI.Models
{
    public class ApplicationDetailVM
    {
        public ApplicationDetailVM()
        {
        }

        public Guid AppRequestId { get; set; }
        public string ShortAppId { get; set; }
        public string TenantName { get; set; }
    }
}
