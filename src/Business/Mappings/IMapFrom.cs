using AutoMapper;
namespace ECommerse.Business.Mappings;

internal interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
}
