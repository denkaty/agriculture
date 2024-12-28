using Agriculture.Transactions.Contracts.Features.Clients.Commands;

using Mapster;

namespace Agriculture.Transactions.Application.Features.Clients.Commands
{
    public class CreateClientCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateClientCommandRequest, CreateClientCommand>()
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
