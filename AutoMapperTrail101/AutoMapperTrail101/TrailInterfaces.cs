using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTrail101
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }

    public interface IMapForm<TEntity>
    {
    }

    public interface IMapTo<TEntity>
    {
    }
}
