using Agriculture.Transactions.Contracts.Features.Suppliers.Commands.CreateSupplier;
using Mapster;

namespace Agriculture.Transactions.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateSupplierCommandRequest, CreateSupplierCommand>()
                  .ConstructUsing(src => new(
                      src.CreateSupplierCommandBindingModel.TaxIdentificationNumber,
                      src.CreateSupplierCommandBindingModel.Name,
                      src.CreateSupplierCommandBindingModel.Email,
                      src.CreateSupplierCommandBindingModel.PhoneNumber,
                      src.CreateSupplierCommandBindingModel.Address,
                      src.CreateSupplierCommandBindingModel.ContactPerson));
        }
    }
}
