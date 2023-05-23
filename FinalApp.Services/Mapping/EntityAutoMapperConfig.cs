using AutoMapper;

namespace FinalApp.Services.Mapping
{
    /// <summary>
    /// Configuration class for AutoMapper to map entities between two models.
    /// </summary>
    /// <typeparam name="Tmodel">Source model type.</typeparam>
    /// <typeparam name="T">Destination model type.</typeparam>
    public class EntityAutoMapperConfig<Tmodel, T>
    {
        /// <summary>
        /// Initializes and configures AutoMapper for mapping between source and destination models.
        /// </summary>
        /// <returns>An instance of IMapper for performing the mappings.</returns>
        public static IMapper Initialize()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tmodel, T>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
