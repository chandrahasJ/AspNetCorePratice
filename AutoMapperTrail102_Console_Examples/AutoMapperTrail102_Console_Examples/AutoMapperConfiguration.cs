using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoMapperTrail102_Console_Examples
{
    class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullDestinationValues = false;

                RegisterStandardMappings(types, cfg);
                RegisterReverseMappings(types, cfg);
                ReverseCustomMappings(types, cfg);

            });
        }

        private static void RegisterStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mce)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                mce.CreateMap(map.Source, map.Destination);
            }
        }

        private static void RegisterReverseMappings(IEnumerable<Type> types, IMapperConfigurationExpression mce)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = t,
                            Destination = i.GetGenericArguments()[0]
                        }).ToArray();

            foreach (var map in maps)
            {
                mce.CreateMap(map.Source, map.Destination);
            }
        }

        private static void ReverseCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mce)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(mce);
            }
        }
    }

    public interface IMapFrom<T> { }

    public interface IMapTo<T> { }

    public interface IHaveCustomMappings { void CreateMappings(IMapperConfigurationExpression mce); }

}
