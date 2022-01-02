using System;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Business.AutoMapperImplementation.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Initialize()
        {
            MapperConfiguration = new MapperConfiguration(config =>
           {
               var profiles = Assembly.GetExecutingAssembly()
               .GetExportedTypes()
               .Where(m => m.IsClass && typeof(Profile).IsAssignableFrom(m));

               foreach (var profile in profiles)
               {
                   config.AddProfile((Profile)Activator.CreateInstance(profile));
               }
           });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}
