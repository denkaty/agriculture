using Agriculture.Inventories.Contracts.Features.Inventories.Commands.Transfer;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Inventories.Commands.Transfer
{
    public class TransferCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TransferCommandRequest, TransferCommand>()
                  .ConstructUsing(src => new(src.TransferCommandBindingModel.SourceWarehouseId, src.TransferCommandBindingModel.DestinationWarehouseId, src.TransferCommandBindingModel.Items));

        }
    }
}
