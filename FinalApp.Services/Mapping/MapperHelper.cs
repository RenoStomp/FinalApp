using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.Domain.Models.Common;

namespace FinalApp.Services.Mapping
{
    public static class MapperHelper<T, Tmodel>
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        public static IEnumerable<Tmodel> Map(IEnumerable<T> sourceCollection)
        {
            var mapper = AutoMapperConfig<T, Tmodel>.Initialize();
            return mapper.Map<IEnumerable<Tmodel>>(sourceCollection);
        }
        public static Tmodel Map(T source)
        {
            var mapper = AutoMapperConfig<T, Tmodel>.Initialize();
            return mapper.Map<Tmodel>(source);
        }
    }
}
