using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Demo.OpenAPI.Models;
using Demo.OpenAPI.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.OpenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRequestController : ControllerBase
    {
        public AppRequestController()
        {
        }

        /// <summary>
        /// Retreives All valid Application Requests for given LanId
        /// </summary>
        /// <param name="ntLoginId">LanId for the user</param>
        /// <returns></returns>
        [HttpGet("{ntLoginId}")]
        [ProducesResponseType(typeof(List<ApplicationDetailVM>), 200)]
        [ProducesResponseType(404)]
        public List<ApplicationDetailVM> Get(string ntLoginId)
        {
            // Parameter Validations Using FluentValidations

            return new List<ApplicationDetailVM>
            {
                new ApplicationDetailVM()
                {
                    AppRequestId =  Guid.NewGuid(),
                    ShortAppId = "SampleAppId",
                    TenantName = "TenantName"
                }
            };
        }

        /// <summary>
        /// Add employee to one of the AD Group of application request.
        /// </summary>
        /// <param name="appRequestId">AppRequestId</param>
        /// <param name="employeeId">EmployeeId for the user who needs to be added</param>
        /// <param name="adGroupId">Required ADGroupID to be added into</param>
        /// <param name="ntLoginId">LanId for the user who needs to be added</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("addEmployeeToAdGroup/{appRequestId}/{employeeId}/{adGroupId}/{ntLoginId}")]
        public Guid AddEmployeetoAdGroup(AddAdGroupRequest request)
        {
            if (!ModelState.IsValid)
            {
                // Replase with Custom Validation Exception and Handle in Global Exception Handler
                throw new InvalidOperationException();
            }

            // Add Business Logic Here
            return Guid.Empty;
        }
    }
}
