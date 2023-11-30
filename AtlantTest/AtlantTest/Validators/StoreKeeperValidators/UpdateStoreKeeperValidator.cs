using AtlantTest.DTO.StoreKeeperRequests;
using FluentValidation;

namespace AtlantTest.Validators.StoreKeeperValidators
{
    public class UpdateStoreKeeperValidator:AbstractValidator<UpdateStoreKeeperRequest>
    {
        public UpdateStoreKeeperValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FIO).NotEmpty() ;
        }
    }
}
