using FluentValidation;

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
}
