using System.Threading.Tasks;

namespace MicroServiceStructure.BuildingBlocks.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handler(dynamic eventData);
    }
}