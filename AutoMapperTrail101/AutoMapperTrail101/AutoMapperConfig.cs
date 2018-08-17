using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTrail101
{
    //https://ppolyzos.com/2015/09/29/map-one-object-to-another-using-automapper/
    public class AutoMapperConfig 
    {
        public void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            Mapper.Initialize(cfg => {
                cfg.AllowNullDestinationValues = false;
            });

            RegisterStandardMappings(types);
            RegisterReverseMappings(types);
            ReverseCustomMappings(types);
        }

        /// <summary>
        /// Load all types that implement interface <see cref="IMapFrom{T}"/>
        /// and create a map between {T} and them
        /// </summary>
        /// <param name="types"></param>
        private void RegisterStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapForm<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        /// <summary>
        /// Load all types that implement interface <see cref="IMapFrom{T}"/>
        /// and create a map between them and {T}
        /// </summary>
        /// <param name="types"></param>
        private void RegisterReverseMappings(IEnumerable<Type> types)
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
                //Mapper.CreateMap(map.Source, map.Destination);
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        /// <summary>
        /// Load all types that implement interface <see cref="IHaveCustomMappings"/>
        /// and register their mapping
        /// </summary>
        /// <param name="types"></param>
        private void ReverseCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }
    }
}
