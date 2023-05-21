using AutoMapper;
using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.Domain.Models.Common;

namespace FinalApp.Services.Mapping
{
    /// <summary>
    /// Helper class for initializing AutoMapper mappings between a source entity type (T) and a destination DTO type (Tmodel).
    /// </summary>
    /// <typeparam name="T">The type of the source entity.</typeparam>
    /// <typeparam name="Tmodel">The type of the destination DTO.</typeparam>
    public class AutoMapperConfig<T, Tmodel> 
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        /// <summary>
        /// Initializes and configures the AutoMapper with the specified mappings between the source entity type and destination DTO type.
        /// </summary>
        /// <returns>An instance of IMapper.</returns>
        public static IMapper Initialize()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, Tmodel>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
