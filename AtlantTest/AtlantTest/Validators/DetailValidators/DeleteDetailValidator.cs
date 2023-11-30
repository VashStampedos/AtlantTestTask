using AtlantTest.DTO.DetailRequsts;
using FluentValidation;

namespace AtlantTest.Validators.DetailValidators
{
    public class DeleteDetailValidator:AbstractValidator<DeleteDetailRequest>
    {
        public DeleteDetailValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.DateOfRemoving).NotEmpty();
        }
    }
}
