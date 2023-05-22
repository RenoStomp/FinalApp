using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.Domain.Models.Common;

namespace FinalApp.Services.Mapping
{
    public class MapperHelperForEntity<Tmodel, T>
        where Tmodel : BaseEntityDTO
        where T : BaseEntity
    {
        public static IEnumerable<T> Map(IEnumerable<Tmodel> sourceCollection)
        {
            var mapper = EntityAutoMapperConfig<Tmodel, T>.Initialize();
            return mapper.Map<IEnumerable<T>>(sourceCollection);
        }
        public static T Map(Tmodel source)
        {
            var mapper = EntityAutoMapperConfig<Tmodel, T>.Initialize();
            return mapper.Map<T>(source);
        }
    }
}
