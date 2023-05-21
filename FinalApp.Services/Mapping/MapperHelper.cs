using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.Domain.Models.Common;

namespace FinalApp.Services.Mapping
{
    /// <summary>
    /// Helper class for mapping between source entities of type T and destination DTOs of type Tmodel.
    /// </summary>
    /// <typeparam name="T">The type of the source entity.</typeparam>
    /// <typeparam name="Tmodel">The type of the destination DTO.</typeparam>
    public static class MapperHelper<T, Tmodel>
        where T : BaseEntity
        where Tmodel : BaseEntityDTO
    {
        /// <summary>
        /// Maps a collection of source entities to a collection of destination DTOs.
        /// </summary>
        /// <param name="sourceCollection">The collection of source entities.</param>
        /// <returns>A collection of destination DTOs.</returns>
        public static IEnumerable<Tmodel> Map(IEnumerable<T> sourceCollection)
        {
            var mapper = AutoMapperConfig<T, Tmodel>.Initialize();
            return mapper.Map<IEnumerable<Tmodel>>(sourceCollection);
        }
        /// <summary>
        /// Maps a single source entity to a destination DTO.
        /// </summary>
        /// <param name="source">The source entity.</param>
        /// <returns>The destination DTO.</returns>
        public static Tmodel Map(T source)
        {
            var mapper = AutoMapperConfig<T, Tmodel>.Initialize();
            return mapper.Map<Tmodel>(source);
        }
    }
}
