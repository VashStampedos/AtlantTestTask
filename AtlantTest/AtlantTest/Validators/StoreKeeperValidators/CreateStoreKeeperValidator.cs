using AtlantTest.DTO.StoreKeeperRequests;
using FluentValidation;

namespace AtlantTest.Validators.StoreKeeperValidators
{
    public class CreateStoreKeeperValidator: AbstractValidator<CreateStoreKeeperRequest>
    {
        public CreateStoreKeeperValidator()
        {
            RuleFor(x => x.FIO).NotEmpty().MinimumLength(1);
        }
    }
}
