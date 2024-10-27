namespace Agriculture.Shared.Application.Abstractions.Mapper
{
    public interface IAgricultureMapper
    {
        TDestination Map<TDestination>(object source);
        void Map(object source, object destination);
    }
}
