using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.OpenAPI.Validations
{
    public class AddAdGroupRequestValidator : AbstractValidator<AddAdGroupRequest>
    {
        public AddAdGroupRequestValidator()
        {
            RuleFor(x => x.AppRequestId).NotNull();
            RuleFor(x => x.EmployeeId).NotNull();
            RuleFor(x => x.AdGroupId).NotNull().NotEmpty();
            RuleFor(x => x.NtLoginId).NotNull().Must(str => str.StartsWith("UID"));
        }
    }

    public class AddAdGroupRequest
    {
        public Guid AppRequestId { get; set; }
        public int EmployeeId { get; set; }
        public int AdGroupId { get; set; }
        public string NtLoginId { get; set; }
    }
}
