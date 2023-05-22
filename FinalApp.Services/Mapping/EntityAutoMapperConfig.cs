using AutoMapper;

namespace FinalApp.Services.Mapping
{
    public class EntityAutoMapperConfig<Tmodel, T>
    {

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
