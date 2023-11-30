using AtlantTest.DTO.DetailRequsts;
using FluentValidation;

namespace AtlantTest.Validators.DetailValidators
{
    public class CreateDetailValidator:AbstractValidator<CreateDetailRequest>
    {
        public CreateDetailValidator()
        {
            RuleFor(x=> x.DetailName).NotEmpty();
            RuleFor(x => x.NomenclCode).NotEmpty();
            RuleFor(x => x.StorekeeperId).NotEmpty();
            RuleFor(x => x.DateOfCreation).NotEmpty();
            RuleFor(x => x.DetailCount).GreaterThanOrEqualTo(0);
        }
    }
}
