using AtlantTest.DTO.DetailRequsts;
using FluentValidation;
using System.Data;

namespace AtlantTest.Validators.DetailValidators
{
    public class UpdateDetailValidator:AbstractValidator<UpdateDetailRequest>
    {
        public UpdateDetailValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.DetailName).NotEmpty();
            RuleFor(x => x.NomenclCode).NotEmpty();
            RuleFor(x => x.StorekeeperId).NotEmpty();
            RuleFor(x => x.DateOfCreation).NotEmpty();
        }
    }
}
